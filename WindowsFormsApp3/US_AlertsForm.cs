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
        private List<AlterDataClass> localAlerts = new List<AlterDataClass>();
        private int currentPage = 0;
        private int pageSize = 10;

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
            cmbViolation.Items.AddRange(new object[] { "위반 전체", "마스크 미착용", "안전모 미착용", "왼쪽 장갑 미착용", "오른쪽 장갑 미착용" });
            cmbViolation.SelectedIndex = 0;
            cmbCamera.Items.Clear();
            cmbCamera.Items.AddRange(new object[] { "카메라 전체", "Camera01", "Camera02", "Camera03" });
            cmbCamera.SelectedIndex = 0;
            cmbZone.Items.Clear();
            cmbZone.Items.AddRange(new object[] { "구역 전체", "A구역", "B구역", "C구역" });
            cmbZone.SelectedIndex = 0;
        }

        private void RegisterFilterEvents()
        {
            cmbViolation.SelectedIndexChanged += (s, e) => { currentPage = 0; ApplyFilter(); };
            cmbCamera.SelectedIndexChanged += (s, e) => { currentPage = 0; ApplyFilter(); };
            cmbZone.SelectedIndexChanged += (s, e) => { currentPage = 0; ApplyFilter(); };
        }

        private async Task RefreshAlarmsFromServer()
        {
            try
            {
                var serverData = await ApiService.GetAlarmsAsync();
                if (serverData == null)
                {
                    MessageBox.Show("백엔드 서버와 통신 연결에 실패했습니다. (서버 다운 또는 주소 오류)");
                    return;
                }

                DataManager.AllAlerts = serverData;
                localAlerts = serverData;
                ApplyFilter();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"알람 갱신 오류: {ex.Message}");
            }
        }

        private void UpdatePageLabel(int totalCount)
        {
            int totalPages = (int)Math.Ceiling((double)totalCount / DataManager.PageSize);
            if (totalPages == 0) totalPages = 1;
            if (DataManager.CurrentPage >= totalPages) DataManager.CurrentPage = totalPages - 1;
            if (DataManager.CurrentPage < 0) DataManager.CurrentPage = 0;

            lblPage.Text = $"{DataManager.CurrentPage + 1} / {totalPages}";
            lnkPrev.Enabled = (DataManager.CurrentPage > 0);
            lnkNext.Enabled = (DataManager.CurrentPage + 1 < totalPages);
        }

        private void lnkPrev_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
                card.OuterBackColor = flpAlertsList.BackColor;

                string displayType = string.IsNullOrEmpty(data.DisplayType) ? "미지정 위반" : data.DisplayType;
                string displayTime = string.IsNullOrEmpty(data.Time) ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : data.Time;
                string displayUid = string.IsNullOrEmpty(data.Uid) ? "미지정" : data.Uid;
                string displayZone = (data.Area != null && !string.IsNullOrEmpty(data.Area.AreaName)) ? data.Area.AreaName : "구역 미지정";
                string displayCam = string.IsNullOrEmpty(data.Cam) ? "카메라01" : data.Cam;
                string displayStatus = string.IsNullOrEmpty(data.Status) ? "미해결" : data.Status;

                card.SetData(displayType, displayTime, displayZone, displayCam, data.Id, displayUid, displayStatus, data.Img, false);

                if (!string.IsNullOrEmpty(data.Id))
                {
                    var capturedCard = card;
                    string vid = data.Id;
                    _ = Task.Run(async () =>
                    {
                        Image serverImg = await ApiService.GetViolationImageAsync(vid);
                        if (serverImg != null)
                        {
                            this.BeginInvoke(new Action(() =>
                            {
                                if (!capturedCard.IsDisposed)
                                    capturedCard.SetData(displayType, displayTime, displayZone, displayCam, vid, displayUid, displayStatus, serverImg, false);
                            }));
                        }
                    });
                }

                card.OnResolveRequested += async (targetCard) =>
                {
                    using (var frm = new AlertResolution(targetCard.WorkerId))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            bool success = await ApiService.ResolveViolationAsync(targetCard.AlertId, frm.AdminId, frm.Memo, 1);
                            if (success)
                            {
                                MessageBox.Show("해결 처리가 완료되었습니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DataManager.ResolveAlert(targetCard.AlertId, frm.AdminId, frm.Memo);
                                DataManager.NotifyDataChanged();
                                await RefreshAlarmsFromServer();
                            }
                            else
                            {
                                MessageBox.Show("서버 통신에 실패했습니다", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                targetCard.SetActionsEnabled(true);
                            }
                        }
                        else
                        {
                            targetCard.SetActionsEnabled(true);
                        }
                    }
                };

                card.Width = flpAlertsList.ClientSize.Width - 25;
                card.Height = 240;
                flpAlertsList.Controls.Add(card);
            }
            flpAlertsList.ResumeLayout();
            flpAlertsList.Refresh();
            UpdatePageLabel(filteredList.Count);
        }

        private List<AlterDataClass> GetFilteredList()
        {
            string selectedState = cmbViolation.SelectedItem?.ToString() ?? "상태 전체";
            string selectedZone = cmbCamera.SelectedItem?.ToString() ?? "구역 전체";
            string selectedTime = cmbZone.SelectedItem?.ToString() ?? "시간대 전체";

            return localAlerts.Where(data =>
                {
                    if (selectedState == "미해결")
                    {
                        if (data.IsChecked != 0)
                            return false;
                    }
                    else if (selectedState == "해결")
                    {
                        if (data.IsChecked != 1)
                            return true;
                    }

                    if (selectedZone != "구역 전체")
                    {
                        string areaName = data.Area?.AreaName ?? "";
                        if (areaName != selectedZone)
                            return false;
                    }

                    if (selectedTime != "시간대 전체")
                    {
                        if (!string.IsNullOrEmpty(data.Time) &&
                        DateTime.TryParse(data.Time, out DateTime alertTime))
                        {
                            int filterHour = int.Parse(selectedTime.Substring(0, 2));
                            if (alertTime.Hour != filterHour)
                                return false;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;
                }).ToList();
        }

    }       
}
