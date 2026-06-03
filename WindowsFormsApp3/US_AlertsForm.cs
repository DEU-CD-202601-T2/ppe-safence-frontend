using Org.BouncyCastle.Tls;
using PPE_관제_시스템.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        //10초 자동 새로고침 타이머 (알림 화면이 보일 때만 동작)
        private System.Windows.Forms.Timer _autoRefreshTimer;

        //필터바 오른쪽 "일괄 확인" 버튼 (현재 알림 전체를 확인 처리)
        private RoundedButton btnAckAll;

        //미확인 알림이 없을 때 중앙에 표시하는 안내 라벨
        private Label lblEmptyState;

        public US_AlertsForm()
        {
            InitializeComponent();

            _autoRefreshTimer = new System.Windows.Forms.Timer { Interval = 10000 }; // 10초
            _autoRefreshTimer.Tick += async (s, e) => await RefreshAlarmsFromServer();
        }

        //외부(MainForm 헤더 새로고침)에서 호출하는 수동 새로고침
        public async Task ManualRefreshAsync()
        {
            await RefreshAlarmsFromServer();
        }

        //화면이 보일 때만 자동 새로고침을 돌린다 (다른 메뉴로 가면 멈춤)
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (_autoRefreshTimer == null) return;
            if (this.Visible) _autoRefreshTimer.Start();
            else _autoRefreshTimer.Stop();
        }

        //컨트롤 파괴 시 타이머 정리
        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (_autoRefreshTimer != null)
            {
                _autoRefreshTimer.Stop();
                _autoRefreshTimer.Dispose();
                _autoRefreshTimer = null;
            }
            base.OnHandleDestroyed(e);
        }

        private async void US_AlertsForm_Load(object sender, EventArgs e)
        {
            ApplyAlertsTheme();
            InitializeFilterItems();
            //구역 드롭다운: 서버에서 구역 목록을 불러와 항목 구성 (이벤트 등록 전에 먼저 채움)
            await LoadZonesAsync();
            RegisterFilterEvents();
            //서버 알람 데이터 조회
            await RefreshAlarmsFromServer();
        }

        // ===== 디자인: 위반관리 화면과 동일한 흰색 기조 + 둥근 카드 + 반응형 =====
        private void ApplyAlertsTheme()
        {
            this.BackColor = AppColors.Surface;

            // 필터바: 흰 배경 둥근 패널 (그림자), 검은 테두리 제거
            pnlFilterBar.BackColor = Color.Transparent;
            WrapWithRounded(pnlFilterBar, AppColors.Surface, 14, shadow: true, border: false);

            // 메인(카드 목록) 패널: 검은 실선 제거
            pnlMain.BorderStyle = BorderStyle.None;
            pnlMain.BackColor = Color.Transparent;
            WrapWithRounded(pnlMain, AppColors.Surface, 16, shadow: true, border: false);

            flpAlertsList.BackColor = AppColors.Surface;
            flpAlertsList.BorderStyle = BorderStyle.None;
            flpAlertsList.FlowDirection = FlowDirection.TopDown;
            flpAlertsList.WrapContents = false;
            flpAlertsList.AutoScroll = true;

            // 패널 크기 변하면(사이드바 접힘/펼침 포함) 카드 폭 재조정
            flpAlertsList.SizeChanged += (s, e) => ResizeCardsToFit();

            pnlFooter.BackColor = Color.Transparent;
            lnkPrev.LinkColor = AppColors.PrimaryDark;
            lnkNext.LinkColor = AppColors.PrimaryDark;
            lblPage.ForeColor = AppColors.Text;

            // 필터바 오른쪽 "일괄 확인" 버튼 생성 (카드의 '확인' 버튼과 동일한 아웃라인 스타일)
            if (btnAckAll == null)
            {
                btnAckAll = new RoundedButton
                {
                    Text = "일괄 확인",
                    Size = new Size(110, 36),
                    Font = new Font("맑은 고딕", 10F, FontStyle.Bold),
                    Name = "btnAckAll"
                };
                AppStyle.MakeOutlineButton(btnAckAll, 10);
                btnAckAll.OuterBackColor = AppColors.Surface;
                btnAckAll.Click += btnAckAll_Click;
                pnlFilterBar.Controls.Add(btnAckAll);
                btnAckAll.BringToFront();
            }

            // 미확인 알림이 없을 때 표시할 중앙 안내 라벨
            if (lblEmptyState == null)
            {
                lblEmptyState = new Label
                {
                    AutoSize = true,
                    Text = "모든 위반 알림을 확인하였습니다",
                    Font = new Font("맑은 고딕", 14F, FontStyle.Bold),
                    ForeColor = AppColors.TextMuted,
                    BackColor = Color.Transparent,
                    Visible = false
                };
                pnlMain.Controls.Add(lblEmptyState);
                lblEmptyState.BringToFront();
                pnlMain.SizeChanged += (s, e) => { if (lblEmptyState != null && lblEmptyState.Visible) CenterEmptyState(); };
            }

            LayoutFilterBar();
            pnlFilterBar.Resize += (s, e) => LayoutFilterBar();
        }

        // "필터" 왼쪽 끝, 오른쪽부터 [일괄확인][구역][위반유형] 순으로 정렬
        private void LayoutFilterBar()
        {
            int barW = pnlFilterBar.Width;
            int topY = 24;

            lblFilter.Location = new Point(18, topY + 4);

            int dropW = 150, gap = 12, rightPad = 20;

            // 일괄 확인 버튼: 오른쪽 끝, 드롭다운과 세로 중앙 정렬(버튼이 더 커서 살짝 위로 올라감 → 하단 잘림 방지)
            int rightCursor = barW - rightPad;
            if (btnAckAll != null)
            {
                int btnTop = topY + (cmbZone.Height - btnAckAll.Height) / 2;
                btnAckAll.Location = new Point(rightCursor - btnAckAll.Width, btnTop);
                rightCursor = btnAckAll.Left - gap;
            }

            // 구역 드롭다운: 버튼 왼쪽
            cmbZone.Width = dropW;
            cmbZone.Location = new Point(rightCursor - dropW, topY);

            // 위반 유형 드롭다운: 구역 왼쪽
            cmbViolation.Width = dropW;
            cmbViolation.Location = new Point(cmbZone.Left - gap - dropW, topY);
        }

        // 카드 폭을 목록 패널 폭에 맞춤 (반응형)
        private void ResizeCardsToFit()
        {
            int w = flpAlertsList.ClientSize.Width - 28;
            if (w < 200) return;
            flpAlertsList.SuspendLayout();
            foreach (Control c in flpAlertsList.Controls)
            {
                if (c is US_AlertCard card && !card.IsDisposed) card.Width = w;
            }
            flpAlertsList.ResumeLayout();
        }

        private void WrapWithRounded(Panel target, Color fill, int radius, bool shadow, bool border)
        {
            var bg = new RoundedPanel
            {
                FillColor = fill,
                CornerRadius = radius,
                HasShadow = shadow,
                BorderColorCustom = border ? AppColors.Border : Color.Empty,
                BorderThickness = border ? 1 : 0,
                OuterBackColor = AppColors.Surface,
                Location = target.Location,
                Size = target.Size,
                Anchor = target.Anchor,
                Padding = new Padding(0)
            };
            var parent = target.Parent;
            parent.Controls.Add(bg);
            bg.SendToBack();
            target.BringToFront();
            target.SizeChanged += (s, e) => { bg.Size = target.Size; bg.Location = target.Location; };
            target.LocationChanged += (s, e) => { bg.Location = target.Location; };
        }

        private void InitializeFilterItems()
        {
            //위반 유형 및 구역 필터
            cmbViolation.Items.Clear();
            cmbViolation.Items.AddRange(new object[] { "위반 전체", "마스크 미착용", "안전모 미착용", "왼쪽 장갑 미착용", "오른쪽 장갑 미착용" });
            cmbViolation.SelectedIndex = 0;
            //구역 항목은 LoadZonesAsync() 에서 서버 데이터로 채움
        }

        private void RegisterFilterEvents()
        {
            //필터 변경시 목록 갱신
            cmbViolation.SelectedIndexChanged += (s, e) => { currentPage = 0; ApplyFilter(); };
            cmbZone.SelectedIndexChanged += (s, e) => { currentPage = 0; ApplyFilter(); };
        }

        //구역 드롭다운을 서버 구역 데이터로 채움 (위반관리 화면과 동일 방식)
        //알림 화면은 클라이언트 측에서 data.AreaName 으로 필터링하므로 구역명만 채우면 됨
        private async Task LoadZonesAsync()
        {
            try
            {
                cmbZone.Items.Clear();
                cmbZone.Items.Add("구역 전체");

                var zones = await ApiService.GetZonesAsync(includeInactive: true) ?? new List<ZoneData>();
                foreach (var z in zones.Where(z => z != null && !string.IsNullOrWhiteSpace(z.name)))
                {
                    if (!cmbZone.Items.Contains(z.name))
                        cmbZone.Items.Add(z.name);
                }
                cmbZone.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"구역 목록 로드 실패: {ex.Message}");
                if (cmbZone.Items.Count == 0) cmbZone.Items.Add("구역 전체");
                cmbZone.SelectedIndex = 0;
            }
        }

        //일괄 확인: 현재 알림(미해결) 전체를 "확인(ack)" 처리한다. 해결(resolve)은 하지 않는다.
        private async void btnAckAll_Click(object sender, EventArgs e)
        {
            if (localAlerts == null || localAlerts.Count == 0)
            {
                MessageBox.Show("확인할 알림이 없습니다.", "일괄 확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 아직 확인되지 않은 알림의 모든 위반 id 수집
            var ids = localAlerts
                .Where(g => g != null && !g.IsAcknowledged)
                .SelectMany(g => g.Ids ?? new List<string>())
                .Where(id => !string.IsNullOrEmpty(id))
                .Distinct()
                .ToList();

            if (ids.Count == 0)
            {
                MessageBox.Show("이미 모든 알림이 확인 처리되어 있습니다.", "일괄 확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"현재 미확인 알림 {ids.Count}건을 모두 확인 처리하시겠습니까?\n(해결 처리가 아니라 '확인' 표시만 됩니다.)",
                "일괄 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            btnAckAll.Enabled = false;
            var overlay = ShowLoadingOverlay("확인 처리 중...");
            try
            {
                bool allOk = true;
                foreach (var id in ids)
                {
                    bool ok = await ApiService.AcknowledgeViolationAsync(id, true);
                    if (!ok) allOk = false;
                }

                // 서버 기준으로 다시 불러와 목록 갱신 + 미확인 뱃지 갱신
                await RefreshAlarmsFromServer();

                if (!allOk)
                    MessageBox.Show("일부 항목의 확인 처리에 실패했습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HideLoadingOverlay(overlay);
                btnAckAll.Enabled = true;
            }
        }

        // 일괄 처리 중 알림 화면 전체를 덮는 반투명 로딩 오버레이 표시
        private LoadingOverlay ShowLoadingOverlay(string message)
        {
            var overlay = new LoadingOverlay(message);
            try
            {
                // 오버레이를 올리기 전 현재 화면을 캡처해 배경(어둡게 비치는 효과)으로 사용
                var bmp = new Bitmap(Math.Max(1, this.Width), Math.Max(1, this.Height));
                this.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                overlay.SetSnapshot(bmp);
            }
            catch { }

            this.Controls.Add(overlay);
            overlay.BringToFront();
            overlay.Start();
            overlay.Refresh();
            return overlay;
        }

        private void HideLoadingOverlay(LoadingOverlay overlay)
        {
            if (overlay == null) return;
            this.Controls.Remove(overlay);
            overlay.Dispose();
        }

        private async Task RefreshAlarmsFromServer()
        {
            try
            {
                //위반 이력 조회
                var serverData = await ApiService.GetViolationsAsync();

                if (serverData != null)
                {
                    //미해결(IsChecked==0) 이면서 아직 확인(ack)되지 않은 알림만 표시
                    //  → 확인 처리하거나 해결 처리하면 알림 목록에서 사라진다.
                    var unresolved = serverData.Where(
                        v => v.IsChecked == 0).ToList();
                    localAlerts = ViolationGroup.BuildGroups(unresolved)
                        .Where(g => g != null && !g.IsAcknowledged)
                        .ToList();
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
                card.Width = flpAlertsList.ClientSize.Width - 28;
                card.Height = 240;
                card.OuterBackColor = flpAlertsList.BackColor;

                //그룹 정보로 카드 설정 (알림 화면: 해결 처리 + 확인 버튼 표시, 상세 보기 숨김)
                card.SetGroup(group, group.Image);
                card.ShowResolveButton();
                card.ShowAckButton();
                card.HideDetailButton();

                //이벤트 핸들러 연결 (repId 유무와 무관하게 항상 연결)
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

                //이미지: 캐시 우선 적용, 없으면 비동기 다운로드
                string repId = group.RepresentativeId;
                if (!string.IsNullOrEmpty(repId))
                {
                    if (_ImageCache.TryGetValue(repId, out Image cached))
                    {
                        group.Image = cached;
                        card.SetGroup(group, cached);
                        card.HideDetailButton();
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
                            {
                                card.SetGroup(group, img);
                                card.HideDetailButton();
                            }
                        }));
                    });
                }

                //카드는 repId 유무와 무관하게 항상 목록에 추가
                flpAlertsList.Controls.Add(card);
            }

            //레이아웃/페이지 갱신은 루프 종료 후 한 번만 실행
            flpAlertsList.ResumeLayout();
            flpAlertsList.Refresh();
            UpdatePageLabel(filteredList.Count);
            lblPage.Text = $"{currentPage + 1} / {totalPages}";
            lnkPrev.Enabled = (currentPage > 0);
            lnkNext.Enabled = (currentPage + 1 < totalPages);

            //미확인 알림이 하나도 없으면 안내 문구를 화면 중앙에 표시
            UpdateEmptyState(filteredList.Count == 0);
        }

        // 빈 상태 안내 라벨 토글 + 중앙 정렬
        private void UpdateEmptyState(bool isEmpty)
        {
            if (lblEmptyState == null) return;
            lblEmptyState.Visible = isEmpty;
            if (isEmpty)
            {
                CenterEmptyState();
                lblEmptyState.BringToFront();
            }
        }

        private void CenterEmptyState()
        {
            if (lblEmptyState == null || lblEmptyState.Parent == null) return;
            var host = lblEmptyState.Parent;
            lblEmptyState.Location = new Point(
                (host.ClientSize.Width - lblEmptyState.Width) / 2,
                (host.ClientSize.Height - lblEmptyState.Height) / 2);
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