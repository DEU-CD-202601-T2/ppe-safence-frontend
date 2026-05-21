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
        public US_AlertsForm()
        {
            InitializeComponent();
            DataManager.OnDataChanged += ApplyFilter;

            //이벤트 연결
            cmbViolation.SelectedIndexChanged += (s, e) => { DataManager.CurrentPage = 0; ApplyFilter(); };
            cmbCamera.SelectedIndexChanged += (s, e) => { DataManager.CurrentPage = 0; ApplyFilter(); };
            cmbZone.SelectedIndexChanged += (s, e) => { DataManager.CurrentPage = 0; ApplyFilter(); };

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
                ApplyFilter();
            }
        }

        private void lnkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var filteredList = GetFilteredList();
            int totalPages = (int)Math.Ceiling((double)filteredList.Count / DataManager.PageSize);
            if ((DataManager.CurrentPage + 1) < totalPages)
            {
                DataManager.CurrentPage++;
                ApplyFilter();
            }
        }

        private async void US_AlertsForm_Load(object sender, EventArgs e)
        {
            cmbViolation.Items.Clear();
            cmbViolation.Items.AddRange(new object[]
            {
                "전체",
                "마스크 미착용",
                "왼쪽 장갑 미착용",
                "오른쪽 장갑 미착용",
                "보호구 미착용"
            });
            cmbViolation.SelectedIndex = 0;

            cmbCamera.Items.Clear();
            cmbCamera.Items.AddRange(new object[]
            {
                "전체",
                "Camera 01",
                "Camera 02",
                "Camera 03",
            });
            cmbCamera.SelectedIndex = 0;

            cmbZone.Items.Clear();
            cmbZone.Items.AddRange(new object[]
            {
                "전체",
                "A구역",
                "B구역",
                "C구역",
            });
            cmbZone.SelectedIndex = 0;

            await RefreshServerDataAsync();
        }

        private async Task RefreshServerDataAsync()
        {
            try
            {
                var data = await ApiService.GetViolationsAsync();
                if (data != null)
                {
                    DataManager.UpdateAlertsFromServer(data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터를 불러오는 중 오류가 발생했습니다: {ex.Message}");
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

                if (!string.IsNullOrEmpty(data.Id) && data.Img == null)
                {
                    string targetFilename = $"{data.Id}.jpg";
                    Task.Run(async () =>
                    {
                    var serverImg = await ApiService.GetVioationImageAsync(targetFilename);
                    if (serverImg != null) {
                        this.Invoke(new Action(() =>
                        { 
                        data.Img = serverImg;
                            card.SetData(data.Type, data.Time, data.Zone, data.Cam, data.Id, data.Uid, data.Status, serverImg, false);
                    }));
                }
            });
        }
        card.OnResolveRequested += async (targetCard) =>
        {
            bool isSuccess = false;
            string saveAdminId = string.Empty;
            string saveMemo = string.Empty;

            using (var frm = new AlertResolution(targetCard.WorkerId))
            { 
                    if(frm.ShowDialog() == DialogResult.OK)
                    {
                    saveAdminId = frm.AdminId;
                    saveMemo = frm.Memo;
                    isSuccess = await ApiService.ResolveViolationAsync(targetCard.AlertId, saveAdminId, saveMemo);
                    }
            }
                    if (isSuccess)
                    {
                        MessageBox.Show("해결 처리가 완료되었습니다");
                        this.BeginInvoke(new Action(() =>
                        {
                            DataManager.ResolveAlert(targetCard.AlertId, saveAdminId, saveMemo);
                            ApplyFilter();
                        }));
                    }
            else
            {
                MessageBox.Show("네트워크 상태를 다시 확인해주세요");
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
                d.Status == "미해결" &&
                (typeFilter == "전체" || d.Type.Contains(typeFilter)) &&
                (camFilter == "전체" || d.Cam.Contains(camFilter)) &&
                (zoneFilter == "전체" || d.Zone.Contains(zoneFilter))
            ).ToList();

            return filteredList;
        }
    }
}
