using Google.Protobuf.WellKnownTypes;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PPE_관제_시스템.DataManager;

namespace PPE_관제_시스템
{
    public partial class US_ViolationManagementForm : UserControl
    {
        private List<AlterDataClass> localViolations = new List<AlterDataClass>(); // API에서 가져온 모든 위반 데이터 저장 리스트
        private List<US_AlertCard> alertCards = new List<US_AlertCard>(); // 모든 카드 저장 리스트
        private int currentPage = 0; //현재 페이지 인덱스
        private int pageSize = 10; //한 페이지에 보여줄 카드 수

        public US_ViolationManagementForm()
        {
            InitializeComponent();

            DataManager.OnDataChanged += RefreshCardList;
        }
        private async void US_ViolationManagementForm_Load(object sender, EventArgs e)
        {
            SetFilterItems();
            dtpDateStart.Value = DateTime.Now.AddDays(-7).Date;
            dtpDateEnd.Value = DateTime.Now.Date;

            cmbState.SelectedIndexChanged += (s, ev) => { currentPage = 0; RefreshCardList(); };
            cmbZone.SelectedIndexChanged += (s, ev) => { currentPage = 0; RefreshCardList(); };
            cmbTime.SelectedIndexChanged += (s, ev) => { currentPage = 0; RefreshCardList(); };

            dtpDateStart.ValueChanged += (s, ev) => { currentPage = 0; RefreshCardList(); };
            dtpDateEnd.ValueChanged += (s, ev) => { currentPage = 0; RefreshCardList(); };

            await LoadViolationData();
        }

        private void SetFilterItems()
        {
            cmbState.Items.Clear();
            cmbState.Items.AddRange(new object[] { "전체", "미해결", "해결" });
            cmbState.SelectedIndex = 0;

            cmbZone.Items.Clear();
            cmbZone.Items.AddRange(new object[] { "전체", "A구역", "B구역", "C구역" });
            cmbZone.SelectedIndex = 0;

            cmbTime.Items.Clear();
            cmbTime.Items.Add("전체");
            for (int i = 0; i < 24; i++)
            {
                string startTime = ($"{i:D2}:00");
                string endTime = ($"{(i + 1):D2}:00");

                if (i == 23) endTime = "00:00";
                cmbTime.Items.Add($"{startTime} - {endTime}");
            }
            cmbState.SelectedIndex = 0;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                RefreshCardList();
            }
        }

        private void RefreshCardList()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(RefreshCardList));
                return;
            }
            flpViolationList.SuspendLayout();

            for (int i = flpViolationList.Controls.Count - 1; i >= 0; i--)
            {
                var ctrl = flpViolationList.Controls[i];
                flpViolationList.Controls.Remove(ctrl);
                ctrl.Dispose();
            }

            alertCards.Clear();
            var filteredList = GetFilteredList();

            int totalPages = (int)Math.Ceiling((double)filteredList.Count / pageSize);
            if (totalPages == 0) totalPages = 1;
            if (currentPage >= totalPages) currentPage = totalPages - 1;
            if (currentPage < 0) currentPage = 0;

            var pageData = filteredList.Skip(currentPage * pageSize).Take(pageSize).ToList();


            foreach (var data in pageData)
            {
                var card = new US_AlertCard();

                card.SetData(data.Type, data.Time, data.Zone, data.Cam, data.Id, data.Uid, data.Status, data.Img, true);
                card.Width = flpViolationList.Width - 25;
                flpViolationList.Controls.Add(card);

                alertCards.Add(card);
            }
            flpViolationList.ResumeLayout();

            lblPage.Text = $"{currentPage + 1} / {totalPages}";
            lblPage.Enabled = (currentPage > 0);
            lnkNext.Enabled = (currentPage + 1 < totalPages);
        }

        private async Task LoadViolationData()
        {
            try
            {
                List<AlterDataClass> violations = await ApiService.GetViolationsAsync();

                if (violations != null)
                {
                    localViolations = violations;
                    RefreshCardList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("데이터 로드 실패" + ex.Message);
            }
        }

        private void UpdateCardVisibility() // 페이지에 따라 카드의 Visible 속성 조정
        {
            for (int i = 0; i < alertCards.Count; i++)
            {
                alertCards[i].Visible = i >= currentPage * pageSize && i < (currentPage + 1) * pageSize;
            }
            UpdatePageLabel();
        }

        private void UpdatePageLabel() // 페이지 label 업데이트
        {
            int totalPages = (alertCards.Count + pageSize - 1) / pageSize;
            if (totalPages == 0)
                totalPages = 1;
            lblPage.Text = $"{currentPage + 1} / {totalPages}";

            lnkPrev.Enabled = (currentPage > 0);
            lnkNext.Enabled = (currentPage + 1 < totalPages);
            
        }

        private void lnkPrev_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
                UpdateCardVisibility();
            }
        }

        private void lnkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var filteredList = GetFilteredList();
            int totalPages = (int)Math.Ceiling((double)filteredList.Count / pageSize);
            if (currentPage + 1 < totalPages)
            {
                currentPage++;
                RefreshCardList();
            }
        }
        private List<AlterDataClass> GetFilteredList()
        {
            string selectedState = cmbState.SelectedItem?.ToString() ?? "전체";
            string selectedZone = cmbZone.SelectedItem?.ToString() ?? "전체";
            string selectedTime = cmbTime.SelectedItem?.ToString() ?? "전체";
            DateTime startDate = dtpDateStart.Value.Date;
            DateTime endDate = dtpDateEnd.Value.Date.AddDays(1).AddSeconds(-1);

            return localViolations.Where(data =>
            {
                if (!DateTime.TryParse(data.Time, out DateTime recordTime)) return false;
                if(recordTime < startDate || recordTime > endDate) return false;

                if(selectedState != "전체" && (data.Status == null || data.Status.Trim() != selectedState)) return false;
                if(selectedZone != "전체" && (data.Zone == null || data.Zone.Trim() != selectedZone)) return false;
                if(selectedTime != "전체")
                {
                    int filterHour = int.Parse(selectedTime.Substring(0, 2));
                    if (recordTime.Hour != filterHour) return false;
                }
                return true;
            }).ToList();
        }

    }
}
