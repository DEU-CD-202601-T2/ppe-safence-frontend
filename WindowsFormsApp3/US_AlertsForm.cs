using Org.BouncyCastle.Tls;
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
        //미해결 알람 목록
        private List<ViolationGroup> localAlerts = new List<ViolationGroup>();
        //페이지네이션 상태
        private int currentPage = 0;
        private int pageSize = 10;
        private readonly Dictionary<string, Image> _ImageCache
            = new Dictionary<string, Image>();

        public US_AlertsForm()
        {
            InitializeComponent();
        }

        private async void US_AlertsForm_Load(object sender, EventArgs e)
        {
            InitializeFilterItems();
            RegisterFilterEvents();
            //서버 알람 데이터 조회
            await RefreshAlarmsFromServer();
        }

        private void InitializeFilterItems()
        {
            //위반 유형 및 구역 필터
            cmbViolation.Items.Clear();
            cmbViolation.Items.AddRange(new object[] { "위반 전체", "마스크 미착용", "안전모 미착용", "왼쪽 장갑 미착용", "오른쪽 장갑 미착용" });
            cmbViolation.SelectedIndex = 0;
            cmbZone.Items.Clear();
            cmbZone.Items.AddRange(new object[] { "구역 전체", "A구역", "B구역", "C구역" });
            cmbZone.SelectedIndex = 0;
        }

        private void RegisterFilterEvents()
        {
            //필터 변경시 목록 갱신
            cmbViolation.SelectedIndexChanged += (s, e) => { currentPage = 0; ApplyFilter(); };
            cmbZone.SelectedIndexChanged += (s, e) => { currentPage = 0; ApplyFilter(); };
        }

        private async Task RefreshAlarmsFromServer()
        {
            try
            {
                //위반 이력 조회
                var serverData = await ApiService.GetViolationsAsync();

                if (serverData != null)
                {
                    //미해결 알람만 알람으로 표시
                    var unresolved = serverData.Where(
                        v => v.IsChecked == 0).ToList();
                    localAlerts = ViolationGroup.BuildGroups(unresolved);
                }

                //동일 작업자 및 시간대의 알람을 그룹화하여 표시
                DataManager.AllAlerts = serverData;
                ApplyFilter();

                // 부모 MainForm 의 미확인 뱃지도 즉시 갱신
                var main = this.FindForm() as MainForm;
                if (main != null)
                    await main.RefreshAlertBadgeAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"알람 갱신 오류: {ex.Message}");
            }
        }

        private void UpdatePageLabel(int totalCount)
        {
            //페이지 계산
            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            if (totalPages == 0) totalPages = 1;
            if (currentPage >= totalPages) currentPage = totalPages - 1;
            if (currentPage < 0) currentPage = 0;

            lblPage.Text = $"{currentPage + 1} / {totalPages}";
            lnkPrev.Enabled = (currentPage > 0);
            lnkNext.Enabled = (currentPage + 1 < totalPages);
        }

        private void lnkPrev_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //이전 페이지로 이동
            if (currentPage > 0)
            {
                currentPage--;
                ApplyFilter();
            }
        }

        private void lnkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //다음 페이지로 이동
            var filteredList = GetFilteredList();
            int totalPages = (int)Math.Ceiling((double)filteredList.Count / pageSize);
            if ((currentPage + 1) < totalPages)
            {
                currentPage++;
                ApplyFilter();
            }
        }

        private void ApplyFilter()
        {
            //UI 스레드에서 실행 보장
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

            //필터 적용된 데이터 조회
            var filteredList = GetFilteredList();
            int totalPages = (int)Math.Ceiling((double)filteredList.Count / pageSize);
            if (totalPages == 0) totalPages = 1;

            if (currentPage >= totalPages)
                currentPage = totalPages - 1;

            if (currentPage < 0)
                currentPage = 0;

            var pageItems = filteredList
                .Skip(currentPage * pageSize)
                .Take(pageSize)
                .ToList();

            foreach (var group in pageItems)
            {
                //알람 카드 생성 및 설정
                var card = new US_AlertCard();

                //크기 조정 
                card.Width = flpAlertsList.ClientSize.Width - 25;
                card.Height = 240;
                card.OuterBackColor = flpAlertsList.BackColor;

                //그룹 정보로 카드 설정
                card.SetGroup(group, group.Image);
                card.HideDetailButton();

                string repId = group.RepresentativeId;
                if (!string.IsNullOrEmpty(repId))
                {
                    if (_ImageCache.TryGetValue(repId, out Image cached))
                    {
                        group.Image = cached;
                        card.SetGroup(group, cached);
                    }

                    _ = Task.Run(async () =>
                    {
                        Image img = await ApiService.GetViolationImageAsync(repId);
                        if (img == null || card == null || card.IsDisposed)
                            return;

                        this.BeginInvoke(new Action(() =>
                        {
                            _ImageCache[repId] = img;
                            group.Image = img;
                            if (!card.IsDisposed)
                                card.SetGroup(group, img);
                        }));
                    });


                    card.OnAckRequested += async (targetCard) =>
                    {
                        // 그룹에 속한 모든 위반 id 를 확인 처리
                        var ids = targetCard.Group?.Ids ?? new List<string>();
                        bool allOk = ids.Count > 0;
                        foreach (var id in ids)
                        {
                            bool ok = await ApiService.AcknowledgeViolationAsync(id, true);
                            if (!ok) allOk = false;
                        }
                        if (allOk)
                        {
                            // 서버에서 최신 데이터 다시 조회 → "확인됨" 흐리게로 다시 그려짐
                            await RefreshAlarmsFromServer();
                        }
                        else
                        {
                            MessageBox.Show("확인 처리 중 일부가 실패했습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            targetCard.SetActionsEnabled(true);
                        }
                    };

                    card.OnResolveRequested += async (targetCard) =>
                    {
                        //해결 처리 폼 표시
                        using (var frm = new AlertResolution(targetCard.WorkerId))
                        {
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                bool success = await ApiService.UpdateViolationCheckedAsync(
                                    targetCard.AlertId, true);
                                if (success)
                                {//서버 상태 변경 성공 시 UI 갱신
                                    MessageBox.Show("해결 처리가 완료되었습니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //데이터 동기화
                                    DataManager.ResolveAlert(targetCard.AlertId, frm.AdminId, frm.Memo);
                                    DataManager.NotifyDataChanged();
                                    //서버에서 최신 데이터 다시 조회
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
                    flpAlertsList.Controls.Add(card);

                }
                flpAlertsList.ResumeLayout();
                flpAlertsList.Refresh();
                UpdatePageLabel(filteredList.Count);
                lblPage.Text = $"{currentPage + 1} / {totalPages}";
                lnkPrev.Enabled = (currentPage > 0);
                lnkNext.Enabled = (currentPage + 1 < totalPages);
            }
        }

        private List<ViolationGroup> GetFilteredList()
        {
            //선택된 필터 값 가져오기
            string selectedViolation = cmbViolation.SelectedItem?.ToString() ?? "위반 전체";
            string selectedZone = cmbZone.SelectedItem?.ToString() ?? "구역 전체";

            return localAlerts.Where(data =>
            {
                //위반 유형 필터 적용
                if (selectedViolation != "위반 전체")
                {
                    switch (selectedViolation)
                    {
                        case "안전모 미착용":
                            if (data.HelmetWorn) return false;
                            break;
                        case "마스크 미착용":
                            if (data.MaskWorn) return false;
                            break;
                        case "왼쪽 장갑 미착용":
                            if (data.GloveLWorn) return false;
                            break;
                        case "오른쪽 장갑 미착용":
                            if (data.GloveRWorn) return false;
                            break;
                    }
                }
                if (selectedZone != "구역 전체") 
                {
                    if ((data.AreaName ?? "") != selectedZone)
                        return false;
                }
                return true;
            })
            // 정렬: 미확인 먼저 → 위험도 높은 순 → 최신순
            .OrderBy(d => d.IsAcknowledged ? 1 : 0)
            .ThenBy(d => RiskRank(d.RiskLevel))
            .ThenByDescending(d =>
            {
                DateTime dt;
                return DateTime.TryParse(d.DetectedAt, out dt) ? dt : DateTime.MinValue;
            })
            .ToList();
        }

        // 위험도 정렬 순위 (높음=0 이 최상단)
        private int RiskRank(string risk)
        {
            switch ((risk ?? "").Trim())
            {
                case "높음": return 0;
                case "중간": return 1;
                case "낮음": return 2;
                default: return 1;
            }
        }
    }       
}