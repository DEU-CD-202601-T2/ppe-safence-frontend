using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Security;
using System.Drawing.Text;
using System.IO;

namespace PPE_관제_시스템
{
    public partial class MainForm : Form
    {
        // 사용자 정의 컨트롤 폼 저장하는 딕셔너리
        private Dictionary<string, UserControl> userControls = new Dictionary<string, UserControl>();

        // ===== 위반관리 전용 헤더 부가요소 (통계 + 시계 + 새로고침) =====
        private Label lblHeaderStats;
        private Label lblHeaderClock;
        private PictureBox picHeaderRefresh;
        private System.Windows.Forms.Timer headerClockTimer;
        private US_ViolationManagementForm _violationFormRef;

        // 새로고침 아이콘 회전 애니메이션
        private System.Windows.Forms.Timer _refreshSpinTimer;
        private float _refreshAngle = 0f;
        private Image _refreshBaseIcon;

        // ===== 알림 미확인 뱃지 + 폴링 =====
        private Label lblAlertBadge;
        private System.Windows.Forms.Timer _alertPollTimer;
        private int _lastSeenMaxId = 0;      // 토스트용 — 마지막으로 본 최대 위반 id
        private bool _alertPollBusy = false;
        private bool _toastBaselineSet = false;  // 첫 폴링은 기준선만 (시작 시 과거 위반 토스트 방지)

        // ===== 접이식 사이드바 =====
        private const int SidebarCollapsed = 64;
        private const int SidebarExpanded = 236;
        private System.Windows.Forms.Timer _sidebarTimer;
        private bool _sidebarExpanding = false;
        private readonly Dictionary<Button, Image> _menuIcons = new Dictionary<Button, Image>();
        private bool _sidebarReady = false;

        public MainForm()
        {
            InitializeComponent();

            this.Text = "PPE 관제 시스템";

            string iconPath = Path.Combine(Application.StartupPath, "Resources", "PPE_Icon.ico");
            if (File.Exists(iconPath))
            {
                this.Icon = new Icon(iconPath);
            }

            BuildHeaderExtras();
            BuildAlertBadge();
            SetupCollapsibleSidebar();

            // 실행 시 전체화면(최대화). 사용자가 크기 조정 가능하도록 FormBorderStyle 유지.
            this.WindowState = FormWindowState.Maximized;

            this.Load += MainForm_Load;
        }

        // pnlMain 을 (메뉴 우측, 헤더 아래) 영역에 맞춤
        private void LayoutContentArea()
        {
            if (pnlMain == null || pnlMenu == null) return;
            int left = pnlMenu.Width;
            int top = 63;   // 헤더 높이 (lblMenuName 영역)
            int w = this.ClientSize.Width - left;
            int h = this.ClientSize.Height - top;
            if (w < 0) w = 0;
            if (h < 0) h = 0;
            pnlMain.Location = new Point(left, top);
            pnlMain.Size = new Size(w, h);
        }

        // 사이드바를 코드로 재구성: 아이콘+왼쪽정렬, 도킹, 호버 펼침/접힘
        private void SetupCollapsibleSidebar()
        {
            // 메뉴 버튼 ↔ 아이콘 파일 매핑
            var iconMap = new Dictionary<Button, string>
            {
                { btnLiveMonitoring,      "live_monitoring_icon.png" },
                { btnAlerts,              "notifications_icon.png" },
                { btnViolationManagement, "dangerous_icon.png" },
                { btnDetectionLog,        "logs_icon.png" },
                { btnAnalysis,            "analytics_icon.png" },
                { btnSettings,            "settings_icon.png" },
            };

            // 버튼 공통 스타일: 아이콘 왼쪽, 텍스트 왼쪽 정렬
            foreach (var kv in iconMap)
            {
                var btn = kv.Key;
                if (btn == null) continue;

                Image icon = LoadMenuIcon(kv.Value);
                if (icon != null) _menuIcons[btn] = icon;

                btn.Image = icon;
                btn.ImageAlign = ContentAlignment.MiddleLeft;
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                btn.Padding = new Padding(20, 0, 0, 0);   // 아이콘 좌측 여백
                btn.Dock = DockStyle.Top;
                btn.Height = 48;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.AutoEllipsis = false;
                btn.UseCompatibleTextRendering = false;
            }

            // 도킹은 역순으로 쌓이므로, 원하는 시각 순서(위→아래)의 역으로 SendToBack
            // 순서: 실시간 → 알림 → 위반관리 → 이력 → 분석 → 설정
            btnSettings?.SendToBack();
            btnAnalysis?.SendToBack();
            btnDetectionLog?.SendToBack();
            btnViolationManagement?.SendToBack();
            btnAlerts?.SendToBack();
            btnLiveMonitoring?.SendToBack();
            // 타이틀 라벨이 가장 위
            if (lblPPESystem != null) { lblPPESystem.Dock = DockStyle.Top; lblPPESystem.SendToBack(); }

            // 타이틀 라벨: 아이콘 + 왼쪽 정렬
            if (lblPPESystem != null)
            {
                lblPPESystem.AutoSize = false;
                lblPPESystem.Height = 56;
                lblPPESystem.TextAlign = ContentAlignment.MiddleLeft;
                lblPPESystem.Padding = new Padding(16, 0, 0, 0);
                lblPPESystem.Image = LoadMenuIcon("PPE_Icon.ico");
                lblPPESystem.ImageAlign = ContentAlignment.MiddleLeft;
                lblPPESystem.TextAlign = ContentAlignment.MiddleLeft;
            }

            // pnlMain 을 헤더 아래 + 메뉴 우측에 맞춤 (메뉴 폭 변화/리사이즈 시 갱신)
            pnlMain.Dock = DockStyle.None;
            pnlMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlMain.BringToFront();
            LayoutContentArea();
            this.Resize += (s, e) => LayoutContentArea();

            // 사이드바 초기 상태: 접힘
            pnlMenu.Width = SidebarCollapsed;

            // 호버 이벤트 (pnlMenu 와 그 자식 전체에 적용)
            AttachSidebarHover(pnlMenu);
            foreach (Control c in pnlMenu.Controls)
                AttachSidebarHover(c);

            // 슬라이드 애니메이션 타이머
            _sidebarTimer = new System.Windows.Forms.Timer { Interval = 12 };
            _sidebarTimer.Tick += SidebarAnimate_Tick;

            _sidebarReady = true;
            UpdateMenuTextVisibility();
            lblAlertBadge?.BringToFront();

            // 선택 표시 바는 도킹에서 제외하고 버튼 위에 표시
            if (pnlBar != null)
            {
                pnlBar.Dock = DockStyle.None;
                pnlBar.Width = 4;
                pnlBar.Left = 0;
                pnlBar.BringToFront();
            }
            // 헤더 요소가 콘텐츠 패널에 가리지 않도록 앞으로
            lblMenuName?.BringToFront();
            lblHeaderStats?.BringToFront();
            lblHeaderClock?.BringToFront();
            picHeaderRefresh?.BringToFront();
        }

        private Image LoadMenuIcon(string fileName)
        {
            // 여러 후보 경로 시도 (출력 폴더 구조가 다를 수 있어 방어적으로)
            var candidates = new List<string>
            {
                Path.Combine(Application.StartupPath, "Resources", fileName),
                Path.Combine(Application.StartupPath, fileName),
                Path.Combine(Directory.GetCurrentDirectory(), "Resources", fileName),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", fileName),
            };

            foreach (var path in candidates)
            {
                try
                {
                    if (File.Exists(path))
                    {
                        if (fileName.EndsWith(".ico", StringComparison.OrdinalIgnoreCase))
                            using (var ic = new Icon(path, 28, 28))
                                return ic.ToBitmap();
                        // 파일 잠금 방지: 스트림으로 읽어 복사본 반환
                        using (var tmp = Image.FromFile(path))
                            return new Bitmap(tmp);
                    }
                }
                catch { }
            }

            // 못 찾으면 코드로 그린 폴백 아이콘 (회색 원형) — 빈자리 방지
            return MakeFallbackIcon();
        }

        private Image MakeFallbackIcon()
        {
            var bmp = new Bitmap(24, 24);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);
                using (var b = new SolidBrush(Color.FromArgb(180, 200, 220)))
                    g.FillEllipse(b, 4, 4, 16, 16);
            }
            return bmp;
        }

        private void AttachSidebarHover(Control c)
        {
            c.MouseEnter += (s, e) => ExpandSidebar(true);
            c.MouseLeave += (s, e) => { if (!PointerInsideSidebar()) ExpandSidebar(false); };
        }

        private bool PointerInsideSidebar()
        {
            if (pnlMenu == null) return false;
            var p = pnlMenu.PointToClient(Cursor.Position);
            return pnlMenu.ClientRectangle.Contains(p);
        }

        private void ExpandSidebar(bool expand)
        {
            if (!_sidebarReady) return;
            _sidebarExpanding = expand;
            if (!_sidebarTimer.Enabled) _sidebarTimer.Start();
        }

        private void SidebarAnimate_Tick(object sender, EventArgs e)
        {
            int target = _sidebarExpanding ? SidebarExpanded : SidebarCollapsed;
            int cur = pnlMenu.Width;
            int step = 22;

            if (Math.Abs(cur - target) <= step)
            {
                pnlMenu.Width = target;
                _sidebarTimer.Stop();
                UpdateMenuTextVisibility();
                LayoutContentArea();
                return;
            }
            pnlMenu.Width = cur + (cur < target ? step : -step);
            // 펼치는 도중 텍스트가 보이기 시작하도록 일정 폭 넘으면 텍스트 표시
            UpdateMenuTextVisibility();
            LayoutContentArea();
        }

        // 접힘 상태에서는 텍스트 숨김(아이콘만), 펼침에선 텍스트 표시
        private void UpdateMenuTextVisibility()
        {
            bool showText = pnlMenu.Width > (SidebarCollapsed + 40);
            foreach (var btn in _menuIcons.Keys)
            {
                btn.Text = showText ? GetMenuText(btn) : "";
            }
            if (lblPPESystem != null)
                lblPPESystem.Text = showText ? "PPE 관제시스템" : "";

            // 알림 뱃지 위치도 폭 따라 재배치
            RepositionAlertBadge();
        }

        private string GetMenuText(Button btn)
        {
            if (btn == btnLiveMonitoring) return "실시간 모니터링";
            if (btn == btnAlerts) return "알림";
            if (btn == btnViolationManagement) return "위반관리";
            if (btn == btnDetectionLog) return "이력 / 로그";
            if (btn == btnAnalysis) return "분석";
            if (btn == btnSettings) return "설정";
            return "";
        }

        private void RepositionAlertBadge()
        {
            if (lblAlertBadge == null || btnAlerts == null) return;
            // 펼침: 버튼 우측 안쪽 / 접힘: 아이콘 우상단
            if (pnlMenu.Width > (SidebarCollapsed + 40))
                lblAlertBadge.Location = new Point(pnlMenu.Width - 40, btnAlerts.Top + 14);
            else
                lblAlertBadge.Location = new Point(SidebarCollapsed - 26, btnAlerts.Top + 6);
        }

        // btnAlerts 우측에 미확인 개수 뱃지 생성 + 10초 폴링 시작
        private void BuildAlertBadge()
        {
            lblAlertBadge = new Label
            {
                AutoSize = false,
                Size = new Size(24, 20),
                BackColor = Color.FromArgb(211, 47, 47),   // 빨강
                ForeColor = Color.White,
                Font = new Font("맑은 고딕", 8.5F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "",
                Visible = false
            };
            // 위치는 RepositionAlertBadge() 에서 사이드바 폭 기준으로 잡음
            // 둥근 모서리
            try
            {
                using (var gp = new GraphicsPath())
                {
                    int r = 10;
                    var rect = new Rectangle(0, 0, lblAlertBadge.Width, lblAlertBadge.Height);
                    gp.AddArc(rect.X, rect.Y, r, r, 180, 90);
                    gp.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
                    gp.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
                    gp.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
                    gp.CloseAllFigures();
                    lblAlertBadge.Region = new Region(gp);
                }
            }
            catch { }

            pnlMenu.Controls.Add(lblAlertBadge);
            lblAlertBadge.BringToFront();

            _alertPollTimer = new System.Windows.Forms.Timer { Interval = 10000 }; // 10초
            _alertPollTimer.Tick += async (s, e) => await PollAlertCountAsync();
            _alertPollTimer.Start();
        }

        // 미확인 개수 조회 → 뱃지 갱신 + 새 위반 토스트
        private async Task PollAlertCountAsync()
        {
            if (_alertPollBusy) return;
            _alertPollBusy = true;
            try
            {
                var info = await ApiService.GetUnackInfoAsync();
                if (info == null) return;

                UpdateAlertBadge(info.UnackCount);

                // 새 위반 감지: max_id 가 이전보다 커졌으면
                if (!_toastBaselineSet)
                {
                    // 첫 폴링은 기준선만 설정 (시작 시 과거 위반이 우르르 뜨는 것 방지)
                    _lastSeenMaxId = info.MaxId;
                    _toastBaselineSet = true;
                }
                else if (info.MaxId > _lastSeenMaxId)
                {
                    int prevMaxId = _lastSeenMaxId;
                    _lastSeenMaxId = info.MaxId;
                    await ShowToastsForNewViolations(prevMaxId);
                }
            }
            catch { }
            finally { _alertPollBusy = false; }
        }

        // prevMaxId 보다 큰 id 의 새 위반들을 토스트로 표시 (최대 3건)
        private async Task ShowToastsForNewViolations(int prevMaxId)
        {
            try
            {
                var all = await ApiService.GetViolationsAsync();
                if (all == null) return;

                // 새 위반(미해결) 중 id > prevMaxId 인 것만, 그룹으로 묶어서
                var fresh = all
                    .Where(v => v != null && v.IsChecked == 0)
                    .Where(v =>
                    {
                        int idv;
                        return int.TryParse(v.Id, out idv) && idv > prevMaxId;
                    })
                    .ToList();

                if (fresh.Count == 0) return;

                var groups = ViolationGroup.BuildGroups(fresh);
                // 최신순으로 최대 3건만 토스트
                int shown = 0;
                foreach (var g in groups)
                {
                    if (shown >= 3) break;
                    ShowOneToast(g);
                    shown++;
                }
            }
            catch { }
        }

        private void ShowOneToast(ViolationGroup g)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => ShowOneToast(g)));
                return;
            }
            string title = g.MissingSummary;
            string subtitle = "📍 " + (string.IsNullOrEmpty(g.AreaName) ? "구역 미지정" : g.AreaName)
                            + "   👷 " + (string.IsNullOrEmpty(g.PersonId) ? "미지정" : g.PersonId);
            string timeText = "🕒 " + (g.DetectedAt ?? "-");

            // 긴급(높음)은 더 오래 표시
            int life = (g.RiskLevel ?? "").Trim() == "높음" ? 9000 : 6000;

            var toast = new ToastNotification(title, subtitle, timeText, g.RiskLevel, life);
            toast.OnClicked += () =>
            {
                // 토스트 클릭 → 알림 화면으로 이동
                btnAlerts_Click(btnAlerts, EventArgs.Empty);
            };
            toast.ShowToast();
        }

        // 뱃지 숫자 갱신 (0이면 숨김, 99 초과는 99+)
        private void UpdateAlertBadge(int count)
        {
            if (lblAlertBadge == null) return;
            if (lblAlertBadge.InvokeRequired)
            {
                lblAlertBadge.BeginInvoke(new Action(() => UpdateAlertBadge(count)));
                return;
            }
            if (count <= 0)
            {
                lblAlertBadge.Visible = false;
            }
            else
            {
                lblAlertBadge.Text = count > 99 ? "99+" : count.ToString();
                lblAlertBadge.Visible = true;
                lblAlertBadge.BringToFront();
            }
        }

        // 외부(알림 화면 등)에서 즉시 갱신하고 싶을 때 호출
        public async Task RefreshAlertBadgeAsync()
        {
            await PollAlertCountAsync();
        }

        // lblMenuName 옆에 통계 / 시계 / 새로고침 아이콘 생성 (기본 숨김)
        private void BuildHeaderExtras()
        {
            int baseY = lblMenuName.Top + 6;   // lblMenuName 과 세로 정렬 (약간 보정)

            lblHeaderStats = new Label
            {
                AutoSize = true,
                Font = new Font("맑은 고딕", 10.5F, FontStyle.Regular),
                ForeColor = Color.FromArgb(120, 120, 120),
                BackColor = Color.Transparent,
                Location = new Point(lblMenuName.Right + 16, baseY),
                Text = "",
                Visible = false
            };
            this.Controls.Add(lblHeaderStats);

            lblHeaderClock = new Label
            {
                AutoSize = true,
                Font = new Font("맑은 고딕", 10.5F, FontStyle.Regular),
                ForeColor = Color.FromArgb(150, 150, 150),
                BackColor = Color.Transparent,
                Location = new Point(lblHeaderStats.Right + 6, baseY),
                Text = "",
                Visible = false
            };
            this.Controls.Add(lblHeaderClock);

            picHeaderRefresh = new PictureBox
            {
                Size = new Size(24, 24),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
                Location = new Point(lblHeaderClock.Right + 8, baseY - 2),
                Visible = false
            };
            picHeaderRefresh.Image = GetRefreshIcon();
            _refreshBaseIcon = picHeaderRefresh.Image;
            picHeaderRefresh.Click += async (s, e) =>
            {
                if (_violationFormRef != null && picHeaderRefresh.Enabled)
                {
                    picHeaderRefresh.Enabled = false;
                    StartRefreshSpin();
                    try { await _violationFormRef.ManualRefreshAsync(); }
                    finally { StopRefreshSpin(); picHeaderRefresh.Enabled = true; }
                }
            };
            var tip = new ToolTip();
            tip.SetToolTip(picHeaderRefresh, "데이터 새로고침");
            this.Controls.Add(picHeaderRefresh);

            lblHeaderStats.BringToFront();
            lblHeaderClock.BringToFront();
            picHeaderRefresh.BringToFront();

            headerClockTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            headerClockTimer.Tick += (s, e) =>
            {
                lblHeaderClock.Text = $"({DateTime.Now:yyyy.MM.dd HH:mm:ss})";
                RepositionHeaderExtras();
            };

            // 새로고침 회전 타이머 (16ms 마다 18도 회전)
            _refreshSpinTimer = new System.Windows.Forms.Timer { Interval = 16 };
            _refreshSpinTimer.Tick += RefreshSpin_Tick;
        }

        private void StartRefreshSpin()
        {
            _refreshAngle = 0f;
            if (_refreshBaseIcon == null) _refreshBaseIcon = GetRefreshIcon();
            _refreshSpinTimer.Start();
        }

        private void StopRefreshSpin()
        {
            _refreshSpinTimer.Stop();
            _refreshAngle = 0f;
            var old = picHeaderRefresh.Image;
            picHeaderRefresh.Image = _refreshBaseIcon;
            if (old != null && old != _refreshBaseIcon) old.Dispose();
        }

        private void RefreshSpin_Tick(object sender, EventArgs e)
        {
            _refreshAngle += 18f;
            if (_refreshAngle >= 360f) _refreshAngle -= 360f;
            if (_refreshBaseIcon == null) return;

            var rotated = new Bitmap(picHeaderRefresh.Width, picHeaderRefresh.Height);
            using (var g = Graphics.FromImage(rotated))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);
                g.TranslateTransform(rotated.Width / 2f, rotated.Height / 2f);
                g.RotateTransform(_refreshAngle);
                g.TranslateTransform(-rotated.Width / 2f, -rotated.Height / 2f);
                g.DrawImage(_refreshBaseIcon, new Rectangle(0, 0, rotated.Width, rotated.Height));
            }
            var oldImg = picHeaderRefresh.Image;
            picHeaderRefresh.Image = rotated;
            if (oldImg != null && oldImg != _refreshBaseIcon) oldImg.Dispose();
        }

        private void RepositionHeaderExtras()
        {
            int baseY = lblMenuName.Top + 6;
            lblHeaderStats.Location = new Point(lblMenuName.Right + 16, baseY);
            lblHeaderClock.Location = new Point(lblHeaderStats.Right + 6, baseY);
            picHeaderRefresh.Location = new Point(lblHeaderClock.Right + 8, baseY - 2);
        }

        private Image GetRefreshIcon()
        {
            try
            {
                string path = Path.Combine(Application.StartupPath, "Resources", "Refresh.png");
                if (File.Exists(path)) return Image.FromFile(path);
            }
            catch { }
            // 폴백: 코드로 그린 새로고침 아이콘
            var bmp = new Bitmap(24, 24);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (var pen = new Pen(Color.FromArgb(25, 118, 210), 2.3f))
                {
                    pen.StartCap = LineCap.Round; pen.EndCap = LineCap.Round;
                    g.DrawArc(pen, 4, 4, 15, 15, 60, 280);
                    g.DrawLine(pen, 18, 3, 20, 8);
                    g.DrawLine(pen, 20, 8, 15, 8);
                }
            }
            return bmp;
        }

        // 위반관리 화면이면 헤더 부가요소 켜고 폼과 연동, 아니면 끔
        private void SetHeaderExtrasForViolation(bool on)
        {
            lblHeaderStats.Visible = on;
            lblHeaderClock.Visible = on;
            picHeaderRefresh.Visible = on;

            if (on)
            {
                lblHeaderClock.Text = $"({DateTime.Now:yyyy.MM.dd HH:mm:ss})";
                headerClockTimer.Start();
            }
            else
            {
                headerClockTimer.Stop();
            }
            RepositionHeaderExtras();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowForm("LiveMonitoringForm");
            pnlBar.Visible = true;
            lblMenuName.Text = "실시간 모니터링";
            SelectMenuButton(btnLiveMonitoring);
            MoveSideBar(btnLiveMonitoring);
            SetHeaderExtrasForViolation(false);

            // 시작 시 미확인 뱃지 즉시 1회 갱신
            _ = PollAlertCountAsync();
        }

        private void ShowForm(string formName)
        {
            if (userControls.ContainsKey(formName))
            {
                foreach (var control in userControls.Values)
                    control.Hide();

                userControls[formName].Show();

                if (formName == "LiveMonitoringForm" && userControls[formName] is US_LiveMonitoringForm liveForm)
                {
                    _ = liveForm.RefreshPageAsync();
                }
                else if (formName == "ViolationManagementForm" && userControls[formName] is US_ViolationManagementForm vmForm)
                {
                    _ = vmForm.ManualRefreshAsync();
                }
                else if (formName == "SettingsForm" && userControls[formName] is US_SettingsForm setForm)
                {
                    setForm.RefreshCurrentMenu();
                }
            }
            else
            {
                UserControl newForm = null;
                if (formName == "LiveMonitoringForm")
                    newForm = new US_LiveMonitoringForm();
                else if (formName == "AlertsForm")
                    newForm = new US_AlertsForm();
                else if (formName == "ViolationManagementForm")
                    newForm = new US_ViolationManagementForm();
                else if (formName == "ControlForm")
                    newForm = new US_ControlForm();
                else if (formName == "DetectionLogForm")
                    newForm = new US_DetectionLogForm();
                else if (formName == "AnalysisForm")
                    newForm = new US_AnalysisForm();
                else if (formName == "SettingsForm")
                    newForm = new US_SettingsForm();

                if (newForm != null)
                {
                    newForm.Dock = DockStyle.Fill;
                    pnlMain.Controls.Add(newForm);
                    userControls.Add(formName, newForm);
                    newForm.Show();
                }
            }

            // 위반관리 폼이면 통계 이벤트 연결
            if (formName == "ViolationManagementForm" &&
                userControls[formName] is US_ViolationManagementForm vForm)
            {
                if (_violationFormRef != vForm)
                {
                    if (_violationFormRef != null)
                        _violationFormRef.StatsChanged -= OnViolationStatsChanged;
                    _violationFormRef = vForm;
                    _violationFormRef.StatsChanged += OnViolationStatsChanged;
                }
                // 현재 통계 즉시 반영
                lblHeaderStats.Text = _violationFormRef.CurrentStatsText;
            }
        }

        private void OnViolationStatsChanged(string statsText)
        {
            if (lblHeaderStats.InvokeRequired)
            {
                lblHeaderStats.BeginInvoke(new Action(() => OnViolationStatsChanged(statsText)));
                return;
            }
            lblHeaderStats.Text = statsText;
            RepositionHeaderExtras();
        }

        private void SelectMenuButton(Button selectedButton)
        {
            foreach (Control control in pnlMenu.Controls)
            {
                if (control is Button button)
                    button.Font = new Font(button.Font, FontStyle.Regular);
            }
            selectedButton.Font = new Font(selectedButton.Font, FontStyle.Bold);
        }

        private void MoveSideBar(Control btn)
        {
            pnlBar.Height = btn.Height;
            pnlBar.Top = btn.Top;
        }

        private void btnLiveMonitoring_Click(object sender, EventArgs e)
        {
            ShowForm("LiveMonitoringForm");
            pnlBar.Visible = true;
            lblMenuName.Text = "실시간 모니터링";
            SelectMenuButton(btnLiveMonitoring);
            MoveSideBar(btnLiveMonitoring);
            SetHeaderExtrasForViolation(false);
        }

        private void btnAlerts_Click(object sender, EventArgs e)
        {
            ShowForm("AlertsForm");
            pnlBar.Visible = true;
            lblMenuName.Text = "알림";
            SelectMenuButton(btnAlerts);
            MoveSideBar(btnAlerts);
            SetHeaderExtrasForViolation(false);

            _ = PollAlertCountAsync();   // 알림 화면 진입 시 뱃지 즉시 갱신
        }

        private void btnViolationManagement_Click(object sender, EventArgs e)
        {
            ShowForm("ViolationManagementForm");
            pnlBar.Visible = true;
            lblMenuName.Text = "위반 관리";
            SelectMenuButton(btnViolationManagement);
            MoveSideBar(btnViolationManagement);
            SetHeaderExtrasForViolation(true);   // 위반관리에서만 통계+시계+새로고침 표시
        }

        private void btnControl_Click_1(object sender, EventArgs e)
        {
            ShowForm("ControlForm");
            pnlBar.Visible = true;
            lblMenuName.Text = "대응 / 제어";
            SelectMenuButton(btnControl);
            MoveSideBar(btnControl);
            SetHeaderExtrasForViolation(false);
        }

        private void btnDetectionLog_Click_1(object sender, EventArgs e)
        {
            ShowForm("DetectionLogForm");
            pnlBar.Visible = true;
            lblMenuName.Text = "이력 / 로그";
            SelectMenuButton(btnDetectionLog);
            MoveSideBar(btnDetectionLog);
            SetHeaderExtrasForViolation(false);
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            ShowForm("AnalysisForm");
            pnlBar.Visible = true;
            lblMenuName.Text = "분석";
            SelectMenuButton(btnAnalysis);
            MoveSideBar(btnAnalysis);
            SetHeaderExtrasForViolation(false);
        }

        private void btnSettings_Click_1(object sender, EventArgs e)
        {
            ShowForm("SettingsForm");
            pnlBar.Visible = true;
            lblMenuName.Text = "설정";
            SelectMenuButton(btnSettings);
            MoveSideBar(btnSettings);
            SetHeaderExtrasForViolation(false);
        }
    }
}