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
        private int pageSize = 5; //한 페이지에 보여줄 카드 수

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
            if (cmbState != null && cmbState.Items.Count > 0) cmbState.SelectedIndex = 0;
            if (cmbState != null && cmbState.Items.Count > 0) cmbState.SelectedIndex = 0;
            SetFilterItems();

            RefreshCardList();
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
        // 주석 테스트
      
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
            if (statusFilter == "상태" || string.IsNullOrWhiteSpace(statusFilter)) statusFilter = "전체";
            string zoneFilter = cmbZone?.SelectedItem?.ToString().Trim() ?? "전체";
            if (statusFilter == "구역" || string.IsNullOrWhiteSpace(statusFilter)) statusFilter = "전체";
            string timeFilter = cmbTime?.SelectedItem?.ToString() ?? "전체";
            if (statusFilter == "시간" || string.IsNullOrWhiteSpace(statusFilter)) statusFilter = "전체";

            string startTimePrefix = (timeFilter != "전체" && timeFilter.Length >= 5)
                ? timeFilter.Substring(0, 5) : "전체";
            var filteredList = DataManager.AllAlerts.Where(d =>
                (statusFilter == "전체" || d.Status == statusFilter) &&
                (zoneFilter == "전체" || d.Location.Contains(zoneFilter))&&
                (timeFilter == "전체" || d.Time.Contains(startTimePrefix.Substring(0,3)))
            ).ToList();

            foreach(var data in filteredList)
            {
                var card = new US_AlertCard();

                card.SetData(data.Type,data.Time,data.Location,data.ID,data.Status,data.Img,true);
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
                client.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Bearer", UserContext.JwtToken);

                var response = await client.GetAsync("http://localhost:8080/api/violations");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var violations = JsonConvert.DeserializeObject<List<Violation>>(json);
                    
                    DataManager.AllAlerts.Clear();
                    foreach(var item in violations)
                    {
                        DataManager.AllAlerts.Add(new AlertData
                        {
                            Type = item.Type,
                            Time = item.Timestamp,
                            Location = item.Area,
                            ID = item.Id.ToString(),
                            Status = item.Status
                        });
                    }
                    RefreshCardList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("데이터를 불러오는 중 오류 발생" + ex.Message);
            }
        }
    }
}
