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
            cmbViolation.Items.AddRange(new object[] { "전체", "마스크 미착용", "안전모 미착용", "왼쪽 장갑 미착용", "오른쪽 장갑 미착용" });
            cmbViolation.SelectedIndex = 0;
            cmbCamera.Items.Clear();
            cmbCamera.Items.AddRange(new object[] { "전체", "Camera01", "Camera02", "Camera03" });
            cmbCamera.SelectedIndex = 0;
            cmbZone.Items.Clear();
            cmbZone.Items.AddRange(new object[] { "전체", "A구역", "B구역", "C구역" });
            cmbZone.SelectedIndex = 0;
        }

        private void RegisterFilterEvents()
        {
            cmbViolation.SelectedIndexChanged += async (s, e) => { currentPage = 0; ApplyFilter(); };
            cmbCamera.SelectedIndexChanged += async (s, e) => { currentPage = 0; ApplyFilter(); };
            cmbZone.SelectedIndexChanged += async (s, e) => { currentPage = 0; ApplyFilter(); };
        }

        private async Task RefreshAlarmsFromServer()
        {
            try
            {
                var serverData = await ApiService.GetAlarmsAsync();
                //확인용
                MessageBox.Show(
                    $"[알람 수신 검증] 서버가 던져준 실시간 알람 개수: {serverData?.Count ?? 0}개",
                    "알람 창 최종 데이터 디버깅"
                );
                if (serverData != null)
                {
                    DataManager.AllAlerts = serverData;
                    localAlerts = serverData;
                    ApplyFilter();
                }
                if (serverData == null) // 통신 자체가 실패한 경우
                {
                    MessageBox.Show("백엔드 서버와 통신망 연결 자체가 실패했습니다. (서버 다운 또는 주소 오류)");
                    return;
                }

              
                if (serverData != null)
                {
                    DataManager.AllAlerts = serverData;
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
                ApplyFilter();
                }
        }



        private async void lnkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var filteredList = GetFilteredList();
            int totalPages = (int)Math.Ceiling((double)filteredList.Count / DataManager.PageSize);

            if((DataManager.CurrentPage + 1) < totalPages)
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

                string displayType = string.IsNullOrEmpty(data.Type) ? "미지정 위반" : data.Type;
                string displayTime = string.IsNullOrEmpty(data.Time) ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : data.Time;
                string displayUid = string.IsNullOrEmpty(data.Uid) ? "미지정" : data.Uid;
                string displayZone = (data.Area != null && !string.IsNullOrEmpty(data.Area.AreaName)) ? data.Area.AreaName : "구역 미지정";
                string displayCam = string.IsNullOrEmpty(data.Cam) ? " 카메라01" : data.Cam;
                string displayStatus = string.IsNullOrEmpty(data.Status) ? "미해결" : data.Status;
                
                card.SetData(displayType, displayTime, displayZone, displayCam, data.Id, displayUid, displayStatus, data.Img, false);

                if (!string.IsNullOrEmpty(data.Id))
                {
                    _ = Task.Run(async () =>
                    {
                        Image serverImg = await ApiService.GetViolationImageAsync(data.Id);
                        if (serverImg != null)
                        {
                            this.BeginInvoke(new Action(() =>
                            {
                                if(!card.IsDisposed)
                                    card.SetData(displayType, displayTime, displayZone, displayCam, data.Id, displayUid, displayStatus, serverImg, false);
                            }));
                        }
                    });
                }
                card.OnResolveRequested += async (targetCard) => { 
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
                                targetCard.Controls["btnResolve"].Enabled = true;
                            }
                        }
                        else
                        {
                            targetCard.Controls["btnResolve"].Enabled = true;
                        }
                    }
                };
                card.Width = flpAlertsList.ClientSize.Width - 25;
                flpAlertsList.Controls.Add(card);
            }
            flpAlertsList.ResumeLayout();
            flpAlertsList.Refresh();
            this.Refresh();
            UpdatePageLabel(filteredList.Count);
            
        }
        private List<AlterDataClass> GetFilteredList()
        {
            if(localAlerts == null || localAlerts.Count == 0)
                return new List<AlterDataClass>();

            string typeFilter = cmbViolation.SelectedItem?.ToString() ?? "전체";
            string camFilter = cmbCamera.SelectedItem?.ToString() ?? "전체";
            string zoneFilter = cmbZone.SelectedItem?.ToString() ?? "전체";

            string coreTypeFilter = typeFilter.Replace(" 미착용", "").Trim();
            var filterQuery = localAlerts.Where(d =>
                (d.IsChecked == 0) &&
                (string.IsNullOrEmpty(d.Status) || d.Status.Trim() == "미해결" || d.Status.ToLower().Contains("unresolved")) &&
                (typeFilter == "전체" || (d.Type != null && d.Type.Trim().Contains(coreTypeFilter))) &&
                (camFilter == "전체" || (d.Cam != null && d.Cam.Trim().Contains(camFilter))) &&
                (zoneFilter == "전체" || (d.Area != null && d.Area.AreaName != null && d.Area.AreaName.Trim().Contains(zoneFilter)))
            );

            var distinctList = filterQuery.Any(d => !string.IsNullOrEmpty(d.Id)) 
                ? filterQuery.GroupBy(d => d.Id).Select(g => g.First()).ToList()
                : filterQuery.ToList();

            return distinctList;
        }
    }
}
