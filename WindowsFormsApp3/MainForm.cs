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

            this.Load += MainForm_Load;
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