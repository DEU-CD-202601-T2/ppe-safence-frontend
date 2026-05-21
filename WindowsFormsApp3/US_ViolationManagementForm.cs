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
        private int totalCount = 0;
        private int currentPage = 0; //현재 페이지 인덱스
        private int pageSize = 10; //한 페이지에 보여줄 카드 수

        public US_ViolationManagementForm()
        {
            InitializeComponent();

            DataManager.OnDataChanged += RefreshCardList;
            cmbState.SelectedIndexChanged += (s, e) => { currentPage = 0; RefreshCardList(); };
            cmbZone.SelectedIndexChanged += (s, e) => { currentPage = 0; RefreshCardList(); };
            cmbTime.SelectedIndexChanged += (s, e) => { currentPage = 0; RefreshCardList(); };
            dtpDateStart.ValueChanged += (s, e) => { currentPage = 0; RefreshCardList(); };
            dtpDateEnd.ValueChanged += (s, e) => { currentPage = 0; RefreshCardList(); };
        }

        private void UpdatePageLabel() // 페이지 label 업데이트
        {
            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            if (totalPages == 0) totalPages = 1;
            if (currentPage == totalPages) currentPage = totalPages - 1;
            if (currentPage < 0) currentPage = 1;

            lblPage.Text = $"{currentPage + 1} / {totalPages}";
            lnkPrev.Enabled = (currentPage > 0);
            lnkNext.Enabled = (currentPage + 1 < totalPages);
        }

        private void lnkPrev_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
                RefreshCardList();
            }
        }

        private void lnkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            if (currentPage + 1 < totalPages)
            {
                currentPage++;
                RefreshCardList();
            }
        }

        private async void US_ViolationManagementForm_Load(object sender, EventArgs e)
        {
            dtpDateStart.Value = DateTime.Now.AddDays(-7);
            dtpDateEnd.Value = DateTime.Now;

            SetFilterItems();
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
            for (int i = flpViolationList.Controls.Count - 1; i >= 0; i--)
            {
                var ctrl = flpViolationList.Controls[i];
                flpViolationList.Controls.Remove(ctrl);
                ctrl.Dispose();
            }

            string statusFilter = cmbState?.SelectedItem?.ToString().Trim() ?? "전체";
            string zoneFilter = cmbZone?.SelectedItem?.ToString().Trim() ?? "전체";
            string timeFilter = cmbTime?.SelectedItem?.ToString() ?? "전체";

            DateTime startDate = dtpDateStart.Value.Date;
            DateTime endDate = dtpDateEnd.Value.Date.AddDays(1).AddTicks(-1);

            var filteredList = DataManager.AllAlerts.Where(data =>
            {
                if (!DateTime.TryParse(data.Time.ToString(), out DateTime recordTime)) return false;

                if (recordTime.Date < startDate || recordTime.Date > endDate) return false;

                if (statusFilter != "전체" && data.Status != statusFilter) return false;

                if (zoneFilter != "전체" && data.Zone != zoneFilter) return false;

                if (timeFilter != "전체")
                {
                    int filterHour = int.Parse(timeFilter.Substring(0, 2));
                    if (recordTime.Hour != filterHour) return false;
                }
                return true;
            }).ToList();

            totalCount = filteredList.Count;
            var pageItmes = filteredList.Skip(currentPage * pageSize).Take(pageSize).ToList();

            foreach (var data in pageItmes)
            {
                var card = new US_AlertCard();
                card.SetData(data.Type, data.Time, data.Zone, data.Cam, data.Id, data.Uid, data.Status, data.Img, true);
                card.Width = flpViolationList.Width - 35;
                flpViolationList.Controls.Add(card);
            }
            flpViolationList.ResumeLayout();
            UpdatePageLabel();
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
