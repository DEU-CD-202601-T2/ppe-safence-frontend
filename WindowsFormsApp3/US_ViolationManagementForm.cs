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
        private static readonly HttpClient client = new HttpClient();
        private List<US_AlertCard> alertCards = new List<US_AlertCard>(); // 모든 카드 저장 리스트
        private int currentPage = 0; //현재 페이지 인덱스
        private int pageSize = 10; //한 페이지에 보여줄 카드 수

        public US_ViolationManagementForm()
        {
            InitializeComponent();

            DataManager.OnDataChanged += RefreshCardList;
            if (cmbState != null)
                cmbState.SelectedIndexChanged += (s, e) => { currentPage = 0; RefreshCardList(); };
            if (cmbZone != null)
                cmbZone.SelectedIndexChanged += (s, e) => { currentPage = 0; RefreshCardList(); };
            if (cmbTime != null)
                cmbTime.SelectedIndexChanged += (s, e) => { currentPage = 0; RefreshCardList(); };
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
            int totalPages = (alertCards.Count + pageSize - 1) / pageSize;
            if (currentPage + 1 < totalPages)
            {
                currentPage++;
                UpdateCardVisibility();
            }
        }

        private async void US_ViolationManagementForm_Load(object sender, EventArgs e)
        {
            SetFilterItems();
            await LoadViolationData();

            dtpDateStart.Value = DateTime.Now.AddDays(-7);
            dtpDateEnd.Value = DateTime.Now;
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
            for(int i=0; i<24; i++)
            {
                string startTime = ($"{i:D2}:00");
                string endTime = ($"{(i+1):D2}:00");

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
            flpViolationList.Controls.Clear();
            alertCards.Clear();
            flpViolationList.SuspendLayout();

            string statusFilter = cmbState?.SelectedItem?.ToString().Trim() ?? "전체";
            string zoneFilter = cmbZone?.SelectedItem?.ToString().Trim() ?? "전체";
            string timeFilter = cmbTime?.SelectedItem?.ToString() ?? "전체";

            DateTime startDate = dtpDateStart.Value.Date;
            DateTime endDate = dtpDateEnd.Value.Date.AddDays(1).AddTicks(-1);

            foreach(var data in Filt)
            {
                var card = new US_AlertCard();

                card.SetData(data.Type,data.Time, data.Zone, data.Cam, data.Id, data.Uid, data.Status,data.Img,true);
                card.Width = flpViolationList.Width - 35;

                alertCards.Add(card);
                flpViolationList.Controls.Add(card);
            }
            flpViolationList.ResumeLayout();
            UpdateCardVisibility();
        }
        private async Task LoadViolationData()
        {
            try
            {
                List<AlterDataClass> violations = await ApiService.GetViolationsAsync();

                if (violations != null && violations.Count > 0)
                {
                    DataManager.AllAlerts.Clear();
                    DataManager.AllAlerts = violations;
                    RefreshCardList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("데이터 로드 실패" + ex.Message);
            }
        }

    }
}
