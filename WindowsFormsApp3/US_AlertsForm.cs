using PPE_관제_시스템.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPE_관제_시스템
{
    public partial class US_AlertsForm : UserControl
    {
        private List<AlterDataClass> localAlerts = new List<AlterDataClass>(); // 모든 카드 저장 리스트
        private int currentPage = 0; //현재 페이지 인덱스
        private int pageSize = 10; //한 페이지에 보여줄 카드 수

        public US_AlertsForm()
        {
            InitializeComponent();

        }

        private async void US_AlertsForm_Load(object sender, EventArgs e)
        {
            InitializeFilterItems();
            RegisterFilterEvents();
            await RefreshAlarmsFromServer();
        }

        private void InitializeFilterItems()
        {
            cmbViolation.Items.Clear();
            cmbViolation.Items.AddRange(new object[] { "전체", "마스크 미착용", "침입", "군중" });
            cmbViolation.SelectedIndex = 0;
            cmbCamera.Items.Clear();
            cmbCamera.Items.AddRange(new object[] { "전체", "카메라1", "카메라2", "카메라3" });
            cmbCamera.SelectedIndex = 0;
            cmbZone.Items.Clear();
            cmbZone.Items.AddRange(new object[] { "전체", "A구역", "B구역" });
            cmbZone.SelectedIndex = 0;
        }

        private void RegisterFilterEvents()
        {
            cmbViolation.SelectedIndexChanged += async (s, e) => { currentPage = 0; await RefreshAlarmsFromServer(); };
            cmbCamera.SelectedIndexChanged += async (s, e) => { currentPage = 0; await RefreshAlarmsFromServer(); };
            cmbZone.SelectedIndexChanged += async (s, e) => { currentPage = 0; await RefreshAlarmsFromServer(); };
        }

        private async Task RefreshAlarmsFromServer()
        {
            try
            {
                var serverData = await ApiService.GetViolationsAsync();
                if (serverData != null)
                {
                    DataManager.AllAlerts = serverData;
                }
                if (serverData == null) // 통신 자체가 실패한 경우
                {
                    MessageBox.Show("백엔드 서버와 통신망 연결 자체가 실패했습니다. (서버 다운 또는 주소 오류)");
                    return;
                }

              
                if (serverData != null)
                {
                    localAlerts = serverData;

                    
                    ApplyFilter();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"알람 갱신 오류: {ex.Message}");
            }
        }


        private void UpdatePageLabel(int totalCount) // 페이지 label 업데이트
        {
            int totalPages = (int)Math.Ceiling((double)totalCount / DataManager.PageSize);
            if (totalPages == 0) totalPages = 1;
            if (DataManager.CurrentPage >= totalPages)
                DataManager.CurrentPage = totalPages - 1;
            if (DataManager.CurrentPage < 0) DataManager.CurrentPage = 0;

            lblPage.Text = $"{DataManager.CurrentPage + 1} / {totalPages}";

            lnkPrev.Enabled = (DataManager.CurrentPage > 0);
            lnkNext.Enabled = (DataManager.CurrentPage + 1 < totalPages);
        }

        private async void lnkPrev_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
                if (DataManager.CurrentPage > 0)
                {
                    DataManager.CurrentPage--;
                await RefreshAlarmsFromServer();
                }
        }



        private async void lnkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var filteredList = GetFilteredList();
            int totalPages = (int)Math.Ceiling((double)filteredList.Count / DataManager.PageSize);

            if((DataManager.CurrentPage + 1) < totalPages)
            {
                DataManager.CurrentPage++;
                await RefreshAlarmsFromServer();
            }
        }

        
        private void ApplyFilter()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(ApplyFilter));
                return;
            }

            flpAlertsList.SuspendLayout();
            for (int i = flpAlertsList.Controls.Count - 1; i >= 0; i--)
            {
                var ctrl = flpAlertsList.Controls[i];
                flpAlertsList.Controls.Remove(ctrl);
                ctrl.Dispose();
            }

            var filteredList = GetFilteredList();

            var pageItems = filteredList
                .Skip(DataManager.CurrentPage * DataManager.PageSize)
                .Take(DataManager.PageSize)
                .ToList();

            foreach (var data in pageItems)
            {
                var card = new US_AlertCard();
                card.SetData(data.Type, data.Time, data.Zone, data.Cam, data.Id, data.Uid, data.Status, data.Img, false);

                card.OnResolveRequested += async (targetCard) =>
                {
                    using (var frm = new AlertResolution(targetCard.WorkerId))
                    {
                        if(frm.ShowDialog() == DialogResult.OK)
                        {
                            bool success = await ApiService.ResolveViolationAsync(targetCard.AlertId, frm.AdminId, frm.Memo);

                            if (success)
                            {
                                MessageBox.Show("해결 처리가 완료되었습니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DataManager.ResolveAlert(targetCard.AlertId, frm.AdminId, frm.Memo);
                                DataManager.NotifyDataChanged();
                                await RefreshAlarmsFromServer();
                            }
                        }
                    }
                };
                card.Width = flpAlertsList.ClientSize.Width - 10;
                flpAlertsList.Controls.Add(card);
            }
            flpAlertsList.ResumeLayout();
            UpdatePageLabel(filteredList.Count);
        }
        private List<AlterDataClass> GetFilteredList()
        {
            string typeFilter = cmbViolation.SelectedItem?.ToString() ?? "전체";
            string camFilter = cmbCamera.SelectedItem?.ToString() ?? "전체";
            string zoneFilter = cmbZone.SelectedItem?.ToString() ?? "전체";

            var filteredList = DataManager.AllAlerts.Where(d =>
            (string.IsNullOrEmpty(d.Status) || d.Status.Trim() == "미해결") &&
                (typeFilter == "전체" || d.Type.Contains(typeFilter)) &&
                (camFilter == "전체" || d.Cam.Contains(camFilter)) &&
                (zoneFilter == "전체" || d.Zone.Contains(zoneFilter))
            ).ToList();

            return filteredList;
        }
    }
}
