using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PPE_관제_시스템
{
    public partial class US_LiveMonitoringForm : UserControl
    {
        // === Refresh 아이콘 애니메이션 ===
        private System.Windows.Forms.Timer _refreshTimer;
        private float _refreshAngle = 0f;
        private bool _isRefreshing = false;
        private System.Drawing.Pen _refreshPen;
        
        private CancellationTokenSource cameraCts;
        private Task cameraTask;
        private bool isCameraRunning = false;
        private System.Windows.Forms.Timer dataUpdateTimer;
        
        private List<ZoneData> zones = new List<ZoneData>();
        private List<CameraData> cameras = new List<CameraData>();
        private List<LiveViolationRecord> todayViolations = new List<LiveViolationRecord>();
        private Image _cameraOfflineIcon;
        private Image _refreshIcon;
        private bool _isPageRefreshing = false;
        private bool _isDashboardRefreshing = false;

        // === 영상 오버레이 재생/정지 컨트롤 바 ===
        private VideoControlOverlayPanel pnlStreamControlBar;
        private Button btnStreamPlayPause;
        private Button btnStreamStop;
        private Button btnStreamFullScreen;
        private Label lblStreamState;
        private volatile bool _isVideoPaused = false;
        private bool _isStreamStoppedByUser = false;

        // === 영상 전체 화면 전환 ===
        private bool _isFullScreenMode = false;
        private Form _fullScreenForm;
        private FullScreenHintPanel pnlFullScreenHint;
        private System.Windows.Forms.Timer _fullScreenHintTimer;
        private System.Windows.Forms.Timer _fullScreenHintFadeTimer;
        private System.Windows.Forms.Timer _videoControlHideTimer;
        private const int VideoControlBarHeight = 58;
        private const int VideoControlBottomHotZone = 110;
        private const int VideoControlAutoHideMilliseconds = 3000;
        private Control _videoOriginalParent;
        private int _videoOriginalChildIndex = -1;
        private DockStyle _videoOriginalDock;
        private AnchorStyles _videoOriginalAnchor;
        private Padding _videoOriginalMargin;
        private Rectangle _videoOriginalBounds;
        private BorderStyle _videoOriginalBorderStyle;
        private PictureBoxSizeMode _videoOriginalPictureSizeMode;
        private DockStyle _picOriginalDock;
        private AnchorStyles _picOriginalAnchor;
        private Padding _picOriginalMargin;
        private Rectangle _picOriginalBounds;
        private int _videoOriginalTableRow = -1;
        private int _videoOriginalTableColumn = -1;
        private int _videoOriginalTableRowSpan = 1;
        private int _videoOriginalTableColumnSpan = 1;


        public US_LiveMonitoringForm()
        {
            InitializeComponent();
            
            _refreshTimer = new System.Windows.Forms.Timer();
            _refreshTimer.Interval = 16;
            _refreshTimer.Tick += RefreshTimer_Tick;
    
            _refreshPen = new System.Drawing.Pen(AppColors.TextSecondary, 2.2f);
            _refreshPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            _refreshPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            ConfigureRefreshIcon();

            picZoneView.BringToFront();
            picZoneView.SizeMode = PictureBoxSizeMode.Zoom;
            picZoneView.BackColor = Color.Black;

            CreateVideoControlOverlay();

            cmbZone.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbZone.DisplayMember = nameof(ZoneData.name);
            cmbZone.ValueMember = nameof(ZoneData.id);

            DataManager.OnDataChanged += OnDashboardUpdated;
        }

        private void ConfigureRefreshIcon()
        {
            try
            {
                // Resources\Refresh.png 파일을 PictureBox 이미지로 그대로 사용한다.
                // Designer에 직접 그리기 Paint 이벤트가 남아 있어도 여기서 제거한다.
                picRefresh.Paint -= picRefresh_Paint;
                picRefresh.SizeMode = PictureBoxSizeMode.Zoom;

                Image icon = GetRefreshIcon();
                if (icon != null)
                {
                    picRefresh.Image = icon;
                }
                else
                {
                    Console.WriteLine("새로고침 아이콘 파일을 찾을 수 없습니다: Resources\\Refresh.png");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"새로고침 아이콘 적용 실패: {ex.Message}");
            }
        }

        private void OnDashboardUpdated()
        {
            if (this.IsHandleCreated && !this.IsDisposed)
            {
                this.BeginInvoke(new Action(() =>
                {
                    UpdateDashboard();
                }));
            }
        }

        private void CreateVideoControlOverlay()
        {
            pnlStreamControlBar = new VideoControlOverlayPanel();
            pnlStreamControlBar.Name = "pnlStreamControlBar";
            pnlStreamControlBar.BackColor = Color.Transparent;
            pnlStreamControlBar.Visible = false;
            pnlStreamControlBar.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            // 상태 문구는 표시하지 않고, 하단 왼쪽에 유니코드 아이콘 버튼만 표시한다.
            lblStreamState = new Label();
            lblStreamState.Name = "lblStreamState";
            lblStreamState.Visible = false;
            lblStreamState.AutoSize = false;

            btnStreamPlayPause = CreateStreamControlButton("▶");
            btnStreamPlayPause.Name = "btnStreamPlayPause";
            btnStreamPlayPause.Click += async (s, e) => await ToggleStreamPlayPauseAsync();

            btnStreamStop = CreateStreamControlButton("■");
            btnStreamStop.Name = "btnStreamStop";
            btnStreamStop.Click += async (s, e) => await StopStreamFromOverlayAsync();

            btnStreamFullScreen = CreateStreamControlButton("⛶");
            btnStreamFullScreen.Name = "btnStreamFullScreen";
            btnStreamFullScreen.Font = new Font("Segoe UI Symbol", 18F, FontStyle.Bold);
            btnStreamFullScreen.Click += (s, e) => ToggleFullScreenMode();

            pnlStreamControlBar.Controls.Add(lblStreamState);
            pnlStreamControlBar.Controls.Add(btnStreamPlayPause);
            pnlStreamControlBar.Controls.Add(btnStreamStop);
            pnlStreamControlBar.Controls.Add(btnStreamFullScreen);

            pnlVideoContainer.Controls.Add(pnlStreamControlBar);
            pnlStreamControlBar.BringToFront();

            _videoControlHideTimer = new System.Windows.Forms.Timer();
            _videoControlHideTimer.Interval = VideoControlAutoHideMilliseconds;
            _videoControlHideTimer.Tick += (s, e) => HideVideoControlBar();

            RegisterVideoControlMouseEvents(pnlVideoContainer);
            RegisterVideoControlMouseEvents(picZoneView);
            RegisterVideoControlMouseEvents(pnlStreamControlBar);
            RegisterVideoControlMouseEvents(btnStreamPlayPause);
            RegisterVideoControlMouseEvents(btnStreamStop);
            RegisterVideoControlMouseEvents(btnStreamFullScreen);

            pnlVideoContainer.Resize += (s, e) => PositionVideoControlOverlay();
            PositionVideoControlOverlay();
            UpdateVideoControlBarState();
        }

        private Button CreateStreamControlButton(string text)
        {
            Button button = new Button();
            button.Text = text;
            button.AutoSize = false;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 70);
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(36, 36, 36);
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(62, 62, 62);
            button.BackColor = Color.Black;
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI Symbol", 17F, FontStyle.Bold);
            button.TextAlign = ContentAlignment.MiddleCenter;
            button.Cursor = Cursors.Hand;
            button.TabStop = false;
            button.Padding = Padding.Empty;
            button.Margin = Padding.Empty;
            button.UseVisualStyleBackColor = false;

            return button;
        }

        private void PositionVideoControlOverlay()
        {
            if (pnlStreamControlBar == null || pnlVideoContainer == null)
            {
                return;
            }

            if (_isFullScreenMode && _fullScreenForm != null && !_fullScreenForm.IsDisposed)
            {
                Rectangle clientRect = _fullScreenForm.ClientRectangle;
                if (clientRect.Width > 0 && clientRect.Height > 0 && pnlVideoContainer.Parent == _fullScreenForm)
                {
                    pnlVideoContainer.Bounds = clientRect;
                    picZoneView.Bounds = new Rectangle(Point.Empty, pnlVideoContainer.ClientSize);
                }
            }

            int barHeight = VideoControlBarHeight;
            int barWidth = Math.Max(1, pnlVideoContainer.ClientSize.Width);
            int y = Math.Max(0, pnlVideoContainer.ClientSize.Height - barHeight);

            pnlStreamControlBar.Bounds = new Rectangle(0, y, barWidth, barHeight);
            LayoutVideoControlBarButtons();
            pnlStreamControlBar.BringToFront();
        }

        private void LayoutVideoControlBarButtons()
        {
            if (pnlStreamControlBar == null || btnStreamPlayPause == null || btnStreamStop == null || btnStreamFullScreen == null)
            {
                return;
            }

            int buttonHeight = 44;
            int playPauseWidth = 56;     // ❚❚ 두 글자가 잘리지 않도록 재생/일시정지 버튼만 넓게 확보
            int stopWidth = 44;
            int fullScreenWidth = 44;
            int gap = 10;
            int startX = 16;
            int rightPadding = 16;
            int y = Math.Max(0, (pnlStreamControlBar.ClientSize.Height - buttonHeight) / 2);

            // 왼쪽 끝: 재생/일시정지 + 정지 버튼
            btnStreamPlayPause.Location = new Point(startX, y);
            btnStreamPlayPause.Size = new Size(playPauseWidth, buttonHeight);

            btnStreamStop.Location = new Point(startX + playPauseWidth + gap, y);
            btnStreamStop.Size = new Size(stopWidth, buttonHeight);

            // 오른쪽 끝: 전체 화면 버튼
            btnStreamFullScreen.Location = new Point(
                Math.Max(startX + playPauseWidth + gap + stopWidth + gap, pnlStreamControlBar.ClientSize.Width - fullScreenWidth - rightPadding),
                y
            );
            btnStreamFullScreen.Size = new Size(fullScreenWidth, buttonHeight);
        }

        private void BringVideoControlOverlayToFront()
        {
            if (pnlStreamControlBar != null && !pnlStreamControlBar.IsDisposed && pnlStreamControlBar.Visible)
            {
                pnlStreamControlBar.BringToFront();
            }
        }

        private void RegisterVideoControlMouseEvents(Control control)
        {
            if (control == null)
            {
                return;
            }

            control.MouseMove -= VideoControlSurface_MouseMove;
            control.MouseLeave -= VideoControlSurface_MouseLeave;
            control.MouseMove += VideoControlSurface_MouseMove;
            control.MouseLeave += VideoControlSurface_MouseLeave;
        }

        private void VideoControlSurface_MouseMove(object sender, MouseEventArgs e)
        {
            UpdateVideoControlBarVisibilityByMousePosition();
        }

        private void VideoControlSurface_MouseLeave(object sender, EventArgs e)
        {
            UpdateVideoControlBarVisibilityByMousePosition();
        }

        private void UpdateVideoControlBarVisibilityByMousePosition()
        {
            if (pnlVideoContainer == null || pnlVideoContainer.IsDisposed || pnlStreamControlBar == null || pnlStreamControlBar.IsDisposed)
            {
                return;
            }

            Point cursorPoint = pnlVideoContainer.PointToClient(Cursor.Position);
            Rectangle videoRect = new Rectangle(Point.Empty, pnlVideoContainer.ClientSize);
            bool isInsideVideo = videoRect.Contains(cursorPoint);
            bool isBottomZone = isInsideVideo && cursorPoint.Y >= Math.Max(0, pnlVideoContainer.ClientSize.Height - VideoControlBottomHotZone);

            if (isBottomZone)
            {
                ShowVideoControlBarTemporarily();
            }
            else
            {
                HideVideoControlBar();
            }
        }

        private void ShowVideoControlBarTemporarily()
        {
            if (pnlStreamControlBar == null || pnlStreamControlBar.IsDisposed)
            {
                return;
            }

            if (pnlStreamControlBar.InvokeRequired)
            {
                pnlStreamControlBar.BeginInvoke(new Action(ShowVideoControlBarTemporarily));
                return;
            }

            PositionVideoControlOverlay();
            pnlStreamControlBar.Visible = true;
            pnlStreamControlBar.BringToFront();

            _videoControlHideTimer?.Stop();
            _videoControlHideTimer?.Start();
        }

        private void HideVideoControlBar()
        {
            if (pnlStreamControlBar == null || pnlStreamControlBar.IsDisposed)
            {
                return;
            }

            if (pnlStreamControlBar.InvokeRequired)
            {
                pnlStreamControlBar.BeginInvoke(new Action(HideVideoControlBar));
                return;
            }

            _videoControlHideTimer?.Stop();
            pnlStreamControlBar.Visible = false;
        }

        private void UpdateVideoControlBarState()
        {
            if (pnlStreamControlBar == null || pnlStreamControlBar.IsDisposed)
            {
                return;
            }

            if (pnlStreamControlBar.InvokeRequired)
            {
                pnlStreamControlBar.BeginInvoke(new Action(UpdateVideoControlBarState));
                return;
            }

            bool running = isCameraRunning && cameraCts != null && !cameraCts.IsCancellationRequested;

            if (!running)
            {
                // 영상이 멈춰있거나 재생 중이 아닐 때: 재생(▶), 정지(■)
                btnStreamPlayPause.Text = "▶";
                btnStreamStop.Text = "■";
                btnStreamStop.Enabled = true;
            }
            else if (_isVideoPaused)
            {
                // 일시정지 상태일 때: 재생(▶), 정지(■)
                btnStreamPlayPause.Text = "▶";
                btnStreamStop.Text = "■";
                btnStreamStop.Enabled = true;
            }
            else
            {
                // 영상 재생 중일 때: 일시정지(❚❚), 정지(■)
                btnStreamPlayPause.Text = "❚❚";
                btnStreamStop.Text = "■";
                btnStreamStop.Enabled = true;
            }

            if (btnStreamFullScreen != null)
            {
                btnStreamFullScreen.Text = "⛶";
            }

            LayoutVideoControlBarButtons();
            BringVideoControlOverlayToFront();
        }

        private void ToggleFullScreenMode()
        {
            if (_isFullScreenMode)
            {
                ExitFullScreenMode();
            }
            else
            {
                EnterFullScreenMode();
            }
        }

        private void EnterFullScreenMode()
        {
            if (_isFullScreenMode || pnlVideoContainer == null || pnlVideoContainer.IsDisposed)
            {
                return;
            }

            try
            {
                _isFullScreenMode = true;

                _videoOriginalParent = pnlVideoContainer.Parent;
                _videoOriginalChildIndex = _videoOriginalParent != null ? _videoOriginalParent.Controls.GetChildIndex(pnlVideoContainer) : -1;
                _videoOriginalDock = pnlVideoContainer.Dock;
                _videoOriginalAnchor = pnlVideoContainer.Anchor;
                _videoOriginalMargin = pnlVideoContainer.Margin;
                _videoOriginalBounds = pnlVideoContainer.Bounds;
                _videoOriginalBorderStyle = pnlVideoContainer.BorderStyle;
                _videoOriginalPictureSizeMode = picZoneView.SizeMode;
                _picOriginalDock = picZoneView.Dock;
                _picOriginalAnchor = picZoneView.Anchor;
                _picOriginalMargin = picZoneView.Margin;
                _picOriginalBounds = picZoneView.Bounds;

                if (_videoOriginalParent is TableLayoutPanel tableLayoutPanel)
                {
                    _videoOriginalTableRow = tableLayoutPanel.GetRow(pnlVideoContainer);
                    _videoOriginalTableColumn = tableLayoutPanel.GetColumn(pnlVideoContainer);
                    _videoOriginalTableRowSpan = tableLayoutPanel.GetRowSpan(pnlVideoContainer);
                    _videoOriginalTableColumnSpan = tableLayoutPanel.GetColumnSpan(pnlVideoContainer);
                }

                Screen screen = Screen.FromControl(this);

                _fullScreenForm = new Form();
                _fullScreenForm.Name = "LiveMonitoringFullScreenForm";
                _fullScreenForm.Text = "실시간 모니터링 전체 화면";
                _fullScreenForm.StartPosition = FormStartPosition.Manual;
                _fullScreenForm.FormBorderStyle = FormBorderStyle.None;
                _fullScreenForm.WindowState = FormWindowState.Normal;
                _fullScreenForm.Bounds = screen.Bounds;
                _fullScreenForm.ClientSize = screen.Bounds.Size;
                _fullScreenForm.MinimumSize = Size.Empty;
                _fullScreenForm.MaximumSize = Size.Empty;
                _fullScreenForm.BackColor = Color.Black;
                _fullScreenForm.KeyPreview = true;
                _fullScreenForm.ShowInTaskbar = false;
                _fullScreenForm.TopMost = true;
                _fullScreenForm.AutoScaleMode = AutoScaleMode.None;
                _fullScreenForm.KeyDown += FullScreenForm_KeyDown;
                _fullScreenForm.Resize += FullScreenForm_Resize;
                _fullScreenForm.MouseMove += VideoControlSurface_MouseMove;
                _fullScreenForm.MouseLeave += VideoControlSurface_MouseLeave;
                _fullScreenForm.Shown += (s, e) =>
                {
                    _fullScreenForm.Bounds = screen.Bounds;
                    ForceFullScreenVideoLayout();
                    PositionFullScreenExitHint();
                };

                _videoOriginalParent?.Controls.Remove(pnlVideoContainer);

                // Dock에만 맡기면 기존 UserControl 레이아웃 값이 남아 전체 화면에서도 일부 영역만 차지할 수 있다.
                // 전체 화면에서는 매번 Form.ClientRectangle 기준으로 직접 Bounds를 강제한다.
                pnlVideoContainer.Dock = DockStyle.None;
                pnlVideoContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                pnlVideoContainer.Margin = Padding.Empty;
                pnlVideoContainer.BorderStyle = BorderStyle.None;

                picZoneView.Dock = DockStyle.None;
                picZoneView.Margin = Padding.Empty;
                picZoneView.SizeMode = PictureBoxSizeMode.StretchImage;
                picZoneView.BackColor = Color.Black;

                _fullScreenForm.Controls.Add(pnlVideoContainer);
                pnlVideoContainer.BringToFront();

                _fullScreenForm.Show();
                _fullScreenForm.Bounds = screen.Bounds;
                ForceFullScreenVideoLayout();
                _fullScreenForm.Activate();
                _fullScreenForm.Focus();

                UpdateVideoControlBarState();
                HideVideoControlBar();
                ShowFullScreenExitHint();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"전체 화면 전환 실패: {ex.Message}");
                ExitFullScreenMode();
            }
        }

        private void ExitFullScreenMode()
        {
            if (!_isFullScreenMode)
            {
                return;
            }

            try
            {
                _isFullScreenMode = false;

                if (_fullScreenHintTimer != null)
                {
                    _fullScreenHintTimer.Stop();
                    _fullScreenHintTimer.Dispose();
                    _fullScreenHintTimer = null;
                }

                if (_fullScreenHintFadeTimer != null)
                {
                    _fullScreenHintFadeTimer.Stop();
                    _fullScreenHintFadeTimer.Dispose();
                    _fullScreenHintFadeTimer = null;
                }

                HideVideoControlBar();

                if (pnlFullScreenHint != null)
                {
                    pnlFullScreenHint.Parent?.Controls.Remove(pnlFullScreenHint);
                    pnlFullScreenHint.Dispose();
                    pnlFullScreenHint = null;
                }

                Form formToClose = _fullScreenForm;

                if (formToClose != null)
                {
                    formToClose.KeyDown -= FullScreenForm_KeyDown;
                    formToClose.Resize -= FullScreenForm_Resize;
                    formToClose.MouseMove -= VideoControlSurface_MouseMove;
                    formToClose.MouseLeave -= VideoControlSurface_MouseLeave;
                    formToClose.Controls.Remove(pnlVideoContainer);
                    _fullScreenForm = null;
                }

                pnlVideoContainer.Dock = _videoOriginalDock;
                pnlVideoContainer.Anchor = _videoOriginalAnchor;
                pnlVideoContainer.Margin = _videoOriginalMargin;
                pnlVideoContainer.Bounds = _videoOriginalBounds;
                pnlVideoContainer.BorderStyle = _videoOriginalBorderStyle;
                picZoneView.SizeMode = _videoOriginalPictureSizeMode;
                picZoneView.Dock = _picOriginalDock;
                picZoneView.Anchor = _picOriginalAnchor;
                picZoneView.Margin = _picOriginalMargin;
                picZoneView.Bounds = _picOriginalBounds;

                if (_videoOriginalParent is TableLayoutPanel tableLayoutPanel)
                {
                    tableLayoutPanel.Controls.Add(pnlVideoContainer, _videoOriginalTableColumn, _videoOriginalTableRow);
                    tableLayoutPanel.SetColumnSpan(pnlVideoContainer, _videoOriginalTableColumnSpan);
                    tableLayoutPanel.SetRowSpan(pnlVideoContainer, _videoOriginalTableRowSpan);
                }
                else
                {
                    _videoOriginalParent?.Controls.Add(pnlVideoContainer);

                    if (_videoOriginalParent != null && _videoOriginalChildIndex >= 0 && _videoOriginalChildIndex < _videoOriginalParent.Controls.Count)
                    {
                        _videoOriginalParent.Controls.SetChildIndex(pnlVideoContainer, _videoOriginalChildIndex);
                    }
                }

                if (formToClose != null && !formToClose.IsDisposed)
                {
                    formToClose.Close();
                    formToClose.Dispose();
                }

                PositionVideoControlOverlay();
                UpdateVideoControlBarState();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"전체 화면 종료 실패: {ex.Message}");
            }
        }

        private void ForceFullScreenVideoLayout()
        {
            if (!_isFullScreenMode || _fullScreenForm == null || _fullScreenForm.IsDisposed || pnlVideoContainer == null || picZoneView == null)
            {
                return;
            }

            Rectangle clientRect = _fullScreenForm.ClientRectangle;
            if (clientRect.Width <= 0 || clientRect.Height <= 0)
            {
                return;
            }

            if (pnlVideoContainer.Parent != _fullScreenForm)
            {
                _fullScreenForm.Controls.Add(pnlVideoContainer);
            }

            pnlVideoContainer.SuspendLayout();
            pnlVideoContainer.Dock = DockStyle.None;
            pnlVideoContainer.Margin = Padding.Empty;
            pnlVideoContainer.Location = Point.Empty;
            pnlVideoContainer.Size = clientRect.Size;
            pnlVideoContainer.Bounds = clientRect;

            picZoneView.Dock = DockStyle.None;
            picZoneView.Margin = Padding.Empty;
            picZoneView.Location = Point.Empty;
            picZoneView.Size = pnlVideoContainer.ClientSize;
            picZoneView.Bounds = new Rectangle(Point.Empty, pnlVideoContainer.ClientSize);
            picZoneView.SizeMode = PictureBoxSizeMode.StretchImage;
            pnlVideoContainer.ResumeLayout(false);

            PositionVideoControlOverlay();
            pnlVideoContainer.BringToFront();
            BringVideoControlOverlayToFront();
            PositionFullScreenExitHint();
        }

        private void FullScreenForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                ExitFullScreenMode();
            }
        }

        private void FullScreenForm_Resize(object sender, EventArgs e)
        {
            ForceFullScreenVideoLayout();
            PositionFullScreenExitHint();
        }

        private void ShowFullScreenExitHint()
        {
            if (_fullScreenForm == null || _fullScreenForm.IsDisposed)
            {
                return;
            }

            if (_fullScreenHintTimer != null)
            {
                _fullScreenHintTimer.Stop();
                _fullScreenHintTimer.Dispose();
                _fullScreenHintTimer = null;
            }

            if (_fullScreenHintFadeTimer != null)
            {
                _fullScreenHintFadeTimer.Stop();
                _fullScreenHintFadeTimer.Dispose();
                _fullScreenHintFadeTimer = null;
            }

            if (pnlFullScreenHint != null)
            {
                pnlFullScreenHint.Parent?.Controls.Remove(pnlFullScreenHint);
                pnlFullScreenHint.Dispose();
                pnlFullScreenHint = null;
            }

            pnlFullScreenHint = new FullScreenHintPanel();
            pnlFullScreenHint.Name = "pnlFullScreenHint";
            pnlFullScreenHint.Size = new Size(430, 44);
            pnlFullScreenHint.PanelOpacity = 255;
            pnlFullScreenHint.Visible = true;

            _fullScreenForm.Controls.Add(pnlFullScreenHint);
            PositionFullScreenExitHint();
            pnlFullScreenHint.BringToFront();

            _fullScreenHintTimer = new System.Windows.Forms.Timer();
            _fullScreenHintTimer.Interval = 3000;
            _fullScreenHintTimer.Tick += (s, e) =>
            {
                _fullScreenHintTimer.Stop();
                StartFullScreenHintFadeOut();
            };
            _fullScreenHintTimer.Start();
        }

        private void StartFullScreenHintFadeOut()
        {
            if (pnlFullScreenHint == null || pnlFullScreenHint.IsDisposed)
            {
                return;
            }

            if (_fullScreenHintFadeTimer != null)
            {
                _fullScreenHintFadeTimer.Stop();
                _fullScreenHintFadeTimer.Dispose();
            }

            _fullScreenHintFadeTimer = new System.Windows.Forms.Timer();
            _fullScreenHintFadeTimer.Interval = 30;
            _fullScreenHintFadeTimer.Tick += (s, e) =>
            {
                if (pnlFullScreenHint == null || pnlFullScreenHint.IsDisposed)
                {
                    _fullScreenHintFadeTimer.Stop();
                    return;
                }

                pnlFullScreenHint.PanelOpacity -= 18;

                if (pnlFullScreenHint.PanelOpacity <= 0)
                {
                    _fullScreenHintFadeTimer.Stop();
                    pnlFullScreenHint.Visible = false;
                }
            };
            _fullScreenHintFadeTimer.Start();
        }

        private void PositionFullScreenExitHint()
        {
            if (_fullScreenForm == null || pnlFullScreenHint == null || pnlFullScreenHint.IsDisposed)
            {
                return;
            }

            int x = Math.Max(0, (_fullScreenForm.ClientSize.Width - pnlFullScreenHint.Width) / 2);
            int y = 16;
            pnlFullScreenHint.Location = new Point(x, y);
            pnlFullScreenHint.BringToFront();
        }

        private async Task ToggleStreamPlayPauseAsync()
        {
            bool running = isCameraRunning && cameraCts != null && !cameraCts.IsCancellationRequested;

            if (!running)
            {
                _isStreamStoppedByUser = false;
                _isVideoPaused = false;
                UpdateVideoControlBarState();
                await StartCameraBySelectedZoneAsync();
                UpdateVideoControlBarState();
                ShowVideoControlBarTemporarily();
                return;
            }

            _isVideoPaused = !_isVideoPaused;
            UpdateVideoControlBarState();
            ShowVideoControlBarTemporarily();
        }

        private async Task StopStreamFromOverlayAsync()
        {
            _isStreamStoppedByUser = true;
            _isVideoPaused = false;
            StopCamera();
            ShowCameraOfflinePlaceholder("영상 재생이 정지되었습니다");
            UpdateVideoControlBarState();
            ShowVideoControlBarTemporarily();
            await Task.CompletedTask;
        }
        
        public async Task RefreshPageAsync()
        {
            if (_isPageRefreshing)
            {
                return;
            }

            _isPageRefreshing = true;

            try
            {
                await LoadZonesToComboAsync();
            }
            finally
            {
                _isPageRefreshing = false;
            }
        }

        private ZoneData CreateNoneZone()
        {
            return new ZoneData
            {
                id = -1,
                name = "없음",
                is_active = false
            };
        }

        private bool IsNoneZone(ZoneData zone)
        {
            return zone == null || zone.id < 0 || string.IsNullOrWhiteSpace(zone.name) || zone.name.Trim() == "없음";
        }

        private string GetSelectedZoneName()
        {
            if (cmbZone.SelectedItem is ZoneData zone)
            {
                return zone.name ?? string.Empty;
            }

            return cmbZone.SelectedItem?.ToString() ?? string.Empty;
        }
        
        private async Task LoadZonesToComboAsync()
        {
            try
            {
                SetCameraStatus("구역 정보 불러오는 중...", Color.Orange);

                // 실시간 모니터링 화면에 진입할 때마다 구역 설정 변경사항을 즉시 반영하기 위해 API를 다시 조회
                zones = await ApiService.GetZonesAsync(includeInactive: true) ?? new List<ZoneData>();

                cmbZone.SelectedIndexChanged -= cmbZone_SelectedIndexChanged;

                cmbZone.DataSource = null;
                cmbZone.Items.Clear();
                cmbZone.DisplayMember = nameof(ZoneData.name);
                cmbZone.ValueMember = nameof(ZoneData.id);

                var loadedZones = zones
                    .Where(z => z != null && !string.IsNullOrWhiteSpace(z.name))
                    .ToList();

                if (loadedZones.Count == 0)
                {
                    cmbZone.Enabled = true;
                    cmbZone.DataSource = new List<ZoneData> { CreateNoneZone() };
                    cmbZone.DisplayMember = nameof(ZoneData.name);
                    cmbZone.ValueMember = nameof(ZoneData.id);
                    cmbZone.SelectedIndex = 0;

                    cmbZone.SelectedIndexChanged += cmbZone_SelectedIndexChanged;

                    ResetDashboard();
                    SetCameraStatus("등록된 구역 없음", Color.Red);
                    StopCamera();
                    ShowCameraOfflinePlaceholder("등록된 구역이 없습니다");
                    return;
                }

                cmbZone.Enabled = true;
                cmbZone.DataSource = loadedZones;
                cmbZone.DisplayMember = nameof(ZoneData.name);
                cmbZone.ValueMember = nameof(ZoneData.id);
                cmbZone.SelectedIndex = 0;

                cmbZone.SelectedIndexChanged += cmbZone_SelectedIndexChanged;

                await RefreshDashboardForSelectedZoneAsync();
                await StartCameraBySelectedZoneAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"구역 콤보박스 로드 실패: {ex.Message}");
                SetCameraStatus("구역 정보 로드 실패", Color.Red);
                ResetDashboard();
            }
        }
        
        private void ClearCameraImage()
        {
            if (picZoneView.InvokeRequired)
            {
                picZoneView.Invoke(new Action(ClearCameraImage));
                return;
            }

            var oldImage = picZoneView.Image;
            picZoneView.Image = null;
            oldImage?.Dispose();

            picZoneView.BackColor = Color.Black;
            BringVideoControlOverlayToFront();
        }
        
        private Image GetCameraOfflineIcon()
        {
            if (_cameraOfflineIcon != null)
            {
                return _cameraOfflineIcon;
            }

            try
            {
                string[] candidatePaths =
                {
                    Path.Combine(Application.StartupPath, "Resources", "videocam_off.png"),
                    Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\Resources\videocam_off.png")),
                    Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\Resources\videocam_off.png"))
                };

                string iconPath = candidatePaths.FirstOrDefault(File.Exists);

                if (string.IsNullOrEmpty(iconPath))
                {
                    Console.WriteLine("오프라인 아이콘 파일을 찾을 수 없습니다.");
                    return null;
                }

                using (FileStream fs = new FileStream(iconPath, FileMode.Open, FileAccess.Read))
                using (Image temp = Image.FromStream(fs))
                {
                    _cameraOfflineIcon = new Bitmap(temp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오프라인 아이콘 로드 실패: {ex.Message}");
                _cameraOfflineIcon = null;
            }

            return _cameraOfflineIcon;
        }

        private void ShowCameraOfflinePlaceholder()
        {
            ShowCameraOfflinePlaceholder("해당 구역 카메라는 오프라인 상태입니다");
        }

        private void ShowCameraOfflinePlaceholder(string message)
        {
            if (picZoneView.InvokeRequired)
            {
                picZoneView.Invoke(new Action(() => ShowCameraOfflinePlaceholder(message)));
                return;
            }

            int width = Math.Max(picZoneView.Width, 640);
            int height = Math.Max(picZoneView.Height, 360);

            Bitmap placeholder = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(placeholder))
            {
                g.Clear(Color.Black);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                Image icon = GetCameraOfflineIcon();
                int iconSize = 64;
                int gap = 18;

                using (Font font = new Font("맑은 고딕", 15F, FontStyle.Regular))
                using (Brush textBrush = new SolidBrush(Color.FromArgb(180, 180, 180)))
                {
                    SizeF textSize = g.MeasureString(message, font);
                    float totalHeight = iconSize + gap + textSize.Height;
                    float iconX = (width - iconSize) / 2f;
                    float iconY = (height - totalHeight) / 2f;
                    float textX = (width - textSize.Width) / 2f;
                    float textY = iconY + iconSize + gap;

                    if (icon != null)
                    {
                        g.DrawImage(icon, iconX, iconY, iconSize, iconSize);
                    }
                    else
                    {
                        DrawFallbackCameraOffIcon(g, iconX, iconY, iconSize);
                    }

                    g.DrawString(message, font, textBrush, textX, textY);
                }
            }

            var oldImage = picZoneView.Image;
            picZoneView.Image = placeholder;
            picZoneView.BackColor = Color.Black;
            oldImage?.Dispose();
            BringVideoControlOverlayToFront();
        }

        private void DrawFallbackCameraOffIcon(Graphics g, float x, float y, int size)
        {
            using (Pen pen = new Pen(Color.FromArgb(120, 120, 120), Math.Max(3, size / 14)))
            {
                pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

                RectangleF body = new RectangleF(x + size * 0.16f, y + size * 0.30f, size * 0.42f, size * 0.34f);
                PointF[] lens =
                {
                    new PointF(x + size * 0.60f, y + size * 0.38f),
                    new PointF(x + size * 0.84f, y + size * 0.24f),
                    new PointF(x + size * 0.84f, y + size * 0.70f),
                    new PointF(x + size * 0.60f, y + size * 0.56f)
                };

                g.DrawRectangle(pen, body.X, body.Y, body.Width, body.Height);
                g.DrawPolygon(pen, lens);
                g.DrawLine(pen, x + size * 0.12f, y + size * 0.12f, x + size * 0.88f, y + size * 0.88f);
            }
        }

        private CameraData FindCameraByZone(ZoneData zone)
        {
            if (zone == null) return null;

            // 1순위: area_id로 매칭
            var camera = cameras.FirstOrDefault(c =>
                c.area != null &&
                c.area.id == zone.id);

            if (camera != null) return camera;

            // 2순위: camera_key + camera_name으로 매칭
            if (!string.IsNullOrEmpty(zone.camera_key) &&
                !string.IsNullOrEmpty(zone.camera_name))
            {
                camera = cameras.FirstOrDefault(c =>
                    c.key == zone.camera_key &&
                    c.name == zone.camera_name);

                if (camera != null) return camera;
            }

            // 3순위: camera_key만으로 매칭
            if (!string.IsNullOrEmpty(zone.camera_key))
            {
                camera = cameras.FirstOrDefault(c =>
                    c.key == zone.camera_key);

                if (camera != null) return camera;
            }

            return null;
        }
        
        private async Task StartCameraBySelectedZoneAsync()
        {
            try
            {
                StopCamera();
                ClearCameraImage();

                if (!(cmbZone.SelectedItem is ZoneData selectedZone) || IsNoneZone(selectedZone))
                {
                    SetCameraStatus("구역 선택 안 됨", Color.Red);
                    ShowCameraOfflinePlaceholder("등록된 구역이 없습니다");
                    return;
                }

                if (string.IsNullOrEmpty(selectedZone.camera_key))
                {
                    SetCameraStatus("연결된 카메라 없음", Color.Red);
                    ShowCameraOfflinePlaceholder("해당 구역에 연결된 카메라가 없습니다");
                    return;
                }

                SetCameraStatus("카메라 정보 확인 중...", Color.Orange);

                var streamResponse = await ApiService.GetStreamUrlsAsync();

                if (streamResponse == null)
                {
                    SetCameraStatus("카메라 API 호출 실패", Color.Red);
                    ShowCameraOffline();
                    ShowCameraOfflinePlaceholder();
                    return;
                }

                cameras = streamResponse.cameras ?? new List<CameraData>();
                ShowCameraOnline(streamResponse.online_count);

                CameraData camera = FindCameraByZone(selectedZone);

                if (camera == null)
                {
                    SetCameraStatus("해당 구역 카메라 오프라인", Color.Red);
                    ShowCameraOfflinePlaceholder();
                    return;
                }

                if (string.IsNullOrWhiteSpace(camera.url))
                {
                    SetCameraStatus("카메라 URL 없음", Color.Red);
                    ShowCameraOfflinePlaceholder();
                    return;
                }

                await StartCameraAsync(camera.url, camera.name);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"선택 구역 카메라 시작 실패: {ex.Message}");
                SetCameraStatus("카메라 연결 오류", Color.Red);
                ShowCameraOfflinePlaceholder();
            }
        }
        
        private async Task StartCameraAsync(string streamUrl, string cameraName)
        {
            try
            {
                StopCamera();

                SetCameraStatus($"{cameraName} 연결 중...", Color.Orange);

                cameraCts = new CancellationTokenSource();
                isCameraRunning = true;
                _isStreamStoppedByUser = false;
                _isVideoPaused = false;
                UpdateVideoControlBarState();

                cameraTask = Task.Run(() =>
                    ReadMjpegStreamAsync(streamUrl, cameraName, cameraCts.Token));

                await Task.Delay(100);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"카메라 시작 오류: {ex}");
                SetCameraStatus("카메라 연결 오류", Color.Red);
            }
        }
        
        private async Task ReadMjpegStreamAsync(string streamUrl, string cameraName, CancellationToken token)
        {
            const int MaxFrameBytes = 5 * 1024 * 1024;

            try
            {
                using (var http = new HttpClient())
                {
                    http.Timeout = Timeout.InfiniteTimeSpan;

                    using (var response = await http.GetAsync(
                        streamUrl,
                        HttpCompletionOption.ResponseHeadersRead,
                        token))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            SetCameraStatus($"스트림 응답 실패: {(int)response.StatusCode}", Color.Red);

                            if ((int)response.StatusCode == 503)
                            {
                                ShowCameraOffline();
                            }

                            ShowCameraOfflinePlaceholder();
                            return;
                        }

                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            SetCameraStatus($"{cameraName} 연결됨", Color.Green);
                            _isStreamStoppedByUser = false;
                            UpdateVideoControlBarState();

                            byte[] buffer = new byte[8192];
                            List<byte> jpgBuffer = new List<byte>(256 * 1024);

                            bool capturing = false;
                            int prev = -1;
                            DateTime lastDrawTime = DateTime.MinValue;

                            while (!token.IsCancellationRequested && isCameraRunning)
                            {
                                int read = await stream.ReadAsync(buffer, 0, buffer.Length, token);

                                if (read <= 0)
                                {
                                    await Task.Delay(10, token);
                                    continue;
                                }

                                for (int i = 0; i < read; i++)
                                {
                                    byte current = buffer[i];

                                    // JPEG 시작 마커: FF D8
                                    if (!capturing)
                                    {
                                        if (prev == 0xFF && current == 0xD8)
                                        {
                                            capturing = true;
                                            jpgBuffer.Clear();
                                            jpgBuffer.Add(0xFF);
                                            jpgBuffer.Add(0xD8);
                                        }
                                    }
                                    else
                                    {
                                        jpgBuffer.Add(current);

                                        if (jpgBuffer.Count > MaxFrameBytes)
                                        {
                                            capturing = false;
                                            jpgBuffer.Clear();
                                        }

                                        // JPEG 종료 마커: FF D9
                                        if (prev == 0xFF && current == 0xD9)
                                        {
                                            byte[] jpgBytes = jpgBuffer.ToArray();

                                            capturing = false;
                                            jpgBuffer.Clear();

                                            // 약 30fps 이하로 화면 갱신 제한
                                            if ((DateTime.Now - lastDrawTime).TotalMilliseconds >= 33)
                                            {
                                                lastDrawTime = DateTime.Now;
                                                ShowJpegFrame(jpgBytes);
                                            }
                                        }
                                    }

                                    prev = current;
                                }
                            }
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // 정상 종료
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MJPEG 스트림 읽기 오류: {ex}");
                SetCameraStatus("카메라 스트림 오류", Color.Red);
            }
        }
        
        private Bitmap BuildDisplayFrame(Bitmap sourceFrame)
        {
            if (!_isFullScreenMode || picZoneView == null || picZoneView.IsDisposed)
            {
                return new Bitmap(sourceFrame);
            }

            int targetWidth;
            int targetHeight;

            if (_fullScreenForm != null && !_fullScreenForm.IsDisposed)
            {
                targetWidth = Math.Max(1, _fullScreenForm.ClientSize.Width);
                targetHeight = Math.Max(1, _fullScreenForm.ClientSize.Height);
            }
            else
            {
                targetWidth = Math.Max(1, picZoneView.ClientSize.Width);
                targetHeight = Math.Max(1, picZoneView.ClientSize.Height);
            }

            Bitmap canvas = new Bitmap(targetWidth, targetHeight);

            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.Black);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                // YouTube 전체 화면처럼 화면 전체를 덮는 cover 방식이다.
                // 영상 비율은 유지하되, 화면과 비율이 다르면 남는 쪽을 잘라내서 검은 여백을 만들지 않는다.
                float scale = Math.Max(
                    targetWidth / (float)sourceFrame.Width,
                    targetHeight / (float)sourceFrame.Height
                );

                int drawWidth = (int)Math.Ceiling(sourceFrame.Width * scale);
                int drawHeight = (int)Math.Ceiling(sourceFrame.Height * scale);
                int drawX = (targetWidth - drawWidth) / 2;
                int drawY = (targetHeight - drawHeight) / 2;

                Rectangle dest = new Rectangle(drawX, drawY, drawWidth, drawHeight);
                g.DrawImage(sourceFrame, dest);
            }

            return canvas;
        }

        private void ShowJpegFrame(byte[] jpgBytes)
        {
            if (_isVideoPaused)
            {
                return;
            }

            try
            {
                using (var ms = new MemoryStream(jpgBytes))
                using (var temp = new Bitmap(ms))
                {
                    Bitmap sourceFrame = new Bitmap(temp);

                    if (!this.IsHandleCreated || this.IsDisposed)
                    {
                        sourceFrame.Dispose();
                        return;
                    }

                    this.BeginInvoke(new Action(() =>
                    {
                        Bitmap displayFrame = null;

                        try
                        {
                            if (_isFullScreenMode)
                            {
                                ForceFullScreenVideoLayout();
                            }

                            displayFrame = BuildDisplayFrame(sourceFrame);
                            sourceFrame.Dispose();

                            var oldImage = picZoneView.Image;

                            picZoneView.Image = displayFrame;
                            picZoneView.BackColor = Color.Black;
                            BringVideoControlOverlayToFront();

                            oldImage?.Dispose();
                        }
                        catch
                        {
                            sourceFrame.Dispose();
                            displayFrame?.Dispose();
                        }
                    }));
                }
            }
            catch
            {
                // 깨진 JPEG 조각은 무시
            }
        }
        
        public void StopCamera()
        {
            try
            {
                isCameraRunning = false;

                if (cameraCts != null)
                {
                    cameraCts.Cancel();
                }

                if (cameraTask != null && !cameraTask.IsCompleted)
                {
                    try
                    {
                        cameraTask.Wait(1000);
                    }
                    catch
                    {
                        // 종료 중 예외 무시
                    }
                }

                cameraTask = null;

                if (cameraCts != null)
                {
                    cameraCts.Dispose();
                    cameraCts = null;
                }

                _isVideoPaused = false;
                UpdateVideoControlBarState();

                if (picZoneView != null && !picZoneView.IsDisposed)
                {
                    if (picZoneView.InvokeRequired)
                    {
                        picZoneView.Invoke(new Action(ClearCameraImage));
                    }
                    else
                    {
                        ClearCameraImage();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"카메라 종료 오류: {ex.Message}");
            }
        }

        private void ResetDashboard()
        {
            lblNoPPECount.Text = "0건";
            lblActiveWorkersCount.Text = "0명";
            lblComplianceRate.Text = "100%";
            lblComplianceRate.ForeColor = AppColors.Success;
        }

        private async Task RefreshDashboardForSelectedZoneAsync()
        {
            if (_isDashboardRefreshing)
            {
                return;
            }

            _isDashboardRefreshing = true;

            try
            {
                if (!(cmbZone.SelectedItem is ZoneData selectedZone) || IsNoneZone(selectedZone))
                {
                    todayViolations = new List<LiveViolationRecord>();
                    ResetDashboard();
                    return;
                }

                var violations = await ApiService.GetLiveViolationsAsync();

                todayViolations = (violations ?? new List<LiveViolationRecord>())
                    .Where(IsTodayViolation)
                    .ToList();

                UpdateDashboard();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"금일 위반 데이터 조회 실패: {ex.Message}");
                todayViolations = new List<LiveViolationRecord>();
                ResetDashboard();
            }
            finally
            {
                _isDashboardRefreshing = false;
            }
        }

        private bool IsTodayViolation(LiveViolationRecord violation)
        {
            if (violation == null || string.IsNullOrWhiteSpace(violation.detected_at))
            {
                return false;
            }

            DateTime detectedAt;
            if (!DateTime.TryParse(violation.detected_at, out detectedAt))
            {
                return false;
            }

            return detectedAt.Date == DateTime.Today;
        }

        private string NormalizeDetectedAt(string detectedAtText)
        {
            if (string.IsNullOrWhiteSpace(detectedAtText))
            {
                return string.Empty;
            }

            DateTime detectedAt;
            if (DateTime.TryParse(detectedAtText, out detectedAt))
            {
                return detectedAt.ToString("yyyy-MM-dd HH:mm:ss");
            }

            return detectedAtText.Trim();
        }

        private string NormalizeViolationType(string violationType)
        {
            return (violationType ?? string.Empty).Trim().ToLowerInvariant();
        }

        private double CalculateComplianceRate(List<LiveViolationRecord> zoneData)
        {
            if (zoneData == null || zoneData.Count == 0)
            {
                return 100.0;
            }

            string[] targetViolationTypes =
            {
                "no_helmet",
                "no_mask",
                "no_glove_left",
                "no_glove_right"
            };

            HashSet<string> targetSet = new HashSet<string>(targetViolationTypes, StringComparer.OrdinalIgnoreCase);

            var personEventGroups = zoneData
                .Where(v => v.person_id.HasValue)
                .GroupBy(v => string.Join("|",
                    v.area_id.HasValue ? v.area_id.Value.ToString() : (v.area_name ?? string.Empty).Trim(),
                    v.person_id.Value.ToString(),
                    NormalizeDetectedAt(v.detected_at)))
                .ToList();

            if (personEventGroups.Count == 0)
            {
                return 100.0;
            }

            double totalCompliance = 0.0;

            foreach (var group in personEventGroups)
            {
                int missingEquipmentCount = group
                    .Select(v => NormalizeViolationType(v.violation_type))
                    .Where(v => targetSet.Contains(v))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .Count();

                if (missingEquipmentCount > 4)
                {
                    missingEquipmentCount = 4;
                }

                double personCompliance = ((4.0 - missingEquipmentCount) / 4.0) * 100.0;
                totalCompliance += personCompliance;
            }

            return totalCompliance / personEventGroups.Count;
        }

        private void UpdateDashboard() // 금일 위반 기록 API 결과를 기준으로 대시보드 정보를 업데이트
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(UpdateDashboard));
                return;
            }

            try
            {
                if (!(cmbZone.SelectedItem is ZoneData selectedZone) || IsNoneZone(selectedZone))
                {
                    Console.WriteLine($"[실시간 모니터링 대시보드] {DateTime.Now:yyyy-MM-dd HH:mm:ss} 데이터 새로고침");
                    Console.WriteLine("[실시간 모니터링 대시보드] 선택 구역: 없음, 금일 위반 데이터 수: 0건");
                    Console.WriteLine("[실시간 모니터링 대시보드] person_id 목록: 없음");
                    ResetDashboard();
                    return;
                }

                string selectedZoneName = (selectedZone.name ?? string.Empty).Trim();

                var zoneData = todayViolations
                    .Where(d => string.Equals((d.area_name ?? string.Empty).Trim(), selectedZoneName, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                List<int> personIds = zoneData
                    .Where(d => d.person_id.HasValue)
                    .Select(d => d.person_id.Value)
                    .Distinct()
                    .OrderBy(id => id)
                    .ToList();

                Console.WriteLine($"[실시간 모니터링 대시보드] {DateTime.Now:yyyy-MM-dd HH:mm:ss} 데이터 새로고침");
                Console.WriteLine($"[실시간 모니터링 대시보드] 선택 구역: {selectedZoneName}, 금일 위반 데이터 수: {zoneData.Count}건");
                Console.WriteLine($"[실시간 모니터링 대시보드] person_id 목록: {(personIds.Count > 0 ? string.Join(", ", personIds) : "없음")}");

                // 선택된 구역의 금일 PPE 미착용 위반 데이터 개수
                lblNoPPECount.Text = $"{zoneData.Count}건";

                // 선택된 구역의 금일 위반 데이터에 포함된 고유 person_id 수
                int todayWorkerCount = personIds.Count;

                lblActiveWorkersCount.Text = $"{todayWorkerCount}명";

                // 같은 detected_at + 같은 area_id/area_name + 같은 person_id를 한 사람의 1회 착용 상태로 보고 평균 준수율 산정
                double complianceRate = CalculateComplianceRate(zoneData);
                lblComplianceRate.Text = $"{complianceRate:F0}%";
                lblComplianceRate.ForeColor = complianceRate >= 80 ? AppColors.Success : AppColors.Danger;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"대시보드 업데이트 오류 : {ex.Message}");
            }
        }

        private void SetCameraStatus(string text, Color color)
        {
            // lblCameraStatus는 디자이너에서 제거됨.
            // 카메라 상태는 이제 lblCameraCount (초록/빨강) + picRefresh 아이콘이 담당.
            // 호출은 그대로 유지하되 본문에서는 디버그 로그만 남김.
            System.Diagnostics.Debug.WriteLine($"[CameraStatus] {text}");
        }

        private async void cmbZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                await RefreshDashboardForSelectedZoneAsync();
                await StartCameraBySelectedZoneAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"구역 변경 실패: {ex.Message}");
            }
        }

        private async void US_LiveMonitoringForm_Load(object sender, EventArgs e)
        {
            try
            {
                await RefreshPageAsync();
                InitUpdateTimer();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"폼 로드 오류: {ex.Message}");
            }
        }
        private void InitUpdateTimer()
        {
            if (dataUpdateTimer != null)
            {
                dataUpdateTimer.Stop();
                dataUpdateTimer.Dispose();
            }

            dataUpdateTimer = new System.Windows.Forms.Timer();
            dataUpdateTimer.Interval = 60000; // 1분마다 데이터 자동 새로고침

            dataUpdateTimer.Tick += async (s, e) =>
            {
                try
                {
                    await RefreshMonitoringDataAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"데이터 업데이트 타이머 오류: {ex.Message}");
                }
            };

            dataUpdateTimer.Start();
        }
        
        private Image GetRefreshIcon()
        {
            if (_refreshIcon != null)
            {
                return _refreshIcon;
            }

            try
            {
                string[] candidatePaths =
                {
                    Path.Combine(Application.StartupPath, "Resources", "Refresh.png"),
                    Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\Resources\Refresh.png")),
                    Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\Resources\Refresh.png"))
                };

                string iconPath = candidatePaths.FirstOrDefault(File.Exists);

                if (string.IsNullOrEmpty(iconPath))
                {
                    return null;
                }

                using (FileStream fs = new FileStream(iconPath, FileMode.Open, FileAccess.Read))
                using (Image temp = Image.FromStream(fs))
                {
                    _refreshIcon = new Bitmap(temp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"새로고침 아이콘 로드 실패: {ex.Message}");
                _refreshIcon = null;
            }

            return _refreshIcon;
        }

        // === Refresh 아이콘 그리기 ===
        private void picRefresh_Paint(object sender, PaintEventArgs e)
        {
            // Resources\Refresh.png 이미지를 그대로 사용하므로 직접 그리지 않는다.
        }

        private async void picRefresh_Click(object sender, EventArgs e)
        {
            if (_isRefreshing) return;

            await RefreshMonitoringDataAsync();
        }

        private async Task RefreshMonitoringDataAsync()
        {
            if (_isRefreshing) return;

            _isRefreshing = true;
            picRefresh.Enabled = false;
            StartRefreshIconAnimation();

            try
            {
                await RefreshDashboardForSelectedZoneAsync();
                await RefreshCameraStatusAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"실시간 모니터링 새로고침 실패: {ex.Message}");
            }
            finally
            {
                StopRefreshIconAnimation();
                picRefresh.Enabled = true;
                _isRefreshing = false;
            }
        }

        private void StartRefreshIconAnimation()
        {
            _refreshAngle = 0f;
            _refreshTimer.Start();
        }

        private void StopRefreshIconAnimation()
        {
            _refreshTimer.Stop();
            _refreshAngle = 0f;
            picRefresh.Image = GetRefreshIcon();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            _refreshAngle += 18f;

            if (_refreshAngle >= 360f)
            {
                _refreshAngle -= 360f;
            }

            Image baseIcon = GetRefreshIcon();
            if (baseIcon == null)
            {
                return;
            }

            Bitmap rotatedIcon = new Bitmap(picRefresh.Width, picRefresh.Height);

            using (Graphics g = Graphics.FromImage(rotatedIcon))
            {
                g.Clear(Color.Transparent);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                g.TranslateTransform(rotatedIcon.Width / 2f, rotatedIcon.Height / 2f);
                g.RotateTransform(_refreshAngle);
                g.TranslateTransform(-rotatedIcon.Width / 2f, -rotatedIcon.Height / 2f);

                Rectangle dest = new Rectangle(0, 0, rotatedIcon.Width, rotatedIcon.Height);
                g.DrawImage(baseIcon, dest);
            }

            Image oldImage = picRefresh.Image;
            picRefresh.Image = rotatedIcon;

            if (oldImage != null && !ReferenceEquals(oldImage, _refreshIcon))
            {
                oldImage.Dispose();
            }
        }

        // === 카메라 상태 갱신 ===
        private async Task RefreshCameraStatusAsync()
        {
            try
            {
                var response = await ApiService.GetStreamUrlsAsync();
                
                if (response == null)
                {
                    ShowCameraOffline();
                }
                else
                {
                    ShowCameraOnline(response.online_count);
                }
            }
            catch
            {
                ShowCameraOffline();
            }
        }

        private void ShowCameraOnline(int count)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => ShowCameraOnline(count)));
                return;
            }
            
            lblCameraCount.Text = $"{count}대";
            lblCameraCount.ForeColor = AppColors.Success;
            lblCameraCount.Font = new Font("맑은 고딕", 28F, FontStyle.Bold);
        }

        private void ShowCameraOffline()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(ShowCameraOffline));
                return;
            }
            
            lblCameraCount.Text = "오프라인";
            lblCameraCount.ForeColor = AppColors.Danger;
            lblCameraCount.Font = new Font("맑은 고딕", 28F, FontStyle.Bold);
        }
    }

    public class FullScreenHintPanel : Control
    {
        private int _panelOpacity = 255;

        public int PanelOpacity
        {
            get { return _panelOpacity; }
            set
            {
                _panelOpacity = Math.Max(0, Math.Min(255, value));
                Invalidate();
            }
        }

        public FullScreenHintPanel()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;
            ForeColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (PanelOpacity <= 0)
            {
                return;
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            Rectangle backgroundRect = new Rectangle(0, 0, Width - 1, Height - 1);
            int backgroundAlpha = ScaleAlpha(236);
            int borderAlpha = ScaleAlpha(70);
            int textAlpha = ScaleAlpha(255);
            int keyBackAlpha = ScaleAlpha(45);
            int keyBorderAlpha = ScaleAlpha(230);

            using (GraphicsPath backgroundPath = CreateRoundRectanglePath(backgroundRect, 4))
            using (SolidBrush backgroundBrush = new SolidBrush(Color.FromArgb(backgroundAlpha, 33, 40, 48)))
            using (Pen borderPen = new Pen(Color.FromArgb(borderAlpha, 255, 255, 255), 1f))
            {
                e.Graphics.FillPath(backgroundBrush, backgroundPath);
                e.Graphics.DrawPath(borderPen, backgroundPath);
            }

            using (Font textFont = new Font("맑은 고딕", 10F, FontStyle.Regular))
            using (Font keyFont = new Font("Segoe UI", 9.5F, FontStyle.Bold))
            using (Brush textBrush = new SolidBrush(Color.FromArgb(textAlpha, 255, 255, 255)))
            using (Brush keyBrush = new SolidBrush(Color.FromArgb(textAlpha, 255, 255, 255)))
            using (Pen keyBorderPen = new Pen(Color.FromArgb(keyBorderAlpha, 255, 255, 255), 1f))
            {
                string leftText = "전체 화면을 종료하려면";
                string keyText = "Esc";
                string rightText = "키를 누르세요.";

                SizeF leftSize = e.Graphics.MeasureString(leftText, textFont);
                SizeF keyTextSize = e.Graphics.MeasureString(keyText, keyFont);
                SizeF rightSize = e.Graphics.MeasureString(rightText, textFont);

                int gap = 8;
                int keyPaddingX = 10;
                int keyBoxWidth = (int)Math.Ceiling(keyTextSize.Width) + keyPaddingX * 2;
                int keyBoxHeight = 28;

                float totalWidth = leftSize.Width + gap + keyBoxWidth + gap + rightSize.Width;
                float startX = (Width - totalWidth) / 2f;
                float centerY = Height / 2f;

                float leftY = centerY - leftSize.Height / 2f;
                Rectangle keyRect = new Rectangle(
                    (int)Math.Round(startX + leftSize.Width + gap),
                    (int)Math.Round(centerY - keyBoxHeight / 2f),
                    keyBoxWidth,
                    keyBoxHeight
                );

                e.Graphics.DrawString(leftText, textFont, textBrush, startX, leftY);

                using (GraphicsPath keyPath = CreateRoundRectanglePath(keyRect, 3))
                using (SolidBrush keyBackBrush = new SolidBrush(Color.FromArgb(keyBackAlpha, 255, 255, 255)))
                {
                    e.Graphics.FillPath(keyBackBrush, keyPath);
                    e.Graphics.DrawPath(keyBorderPen, keyPath);
                }

                float keyX = keyRect.Left + (keyRect.Width - keyTextSize.Width) / 2f;
                float keyY = keyRect.Top + (keyRect.Height - keyTextSize.Height) / 2f;
                e.Graphics.DrawString(keyText, keyFont, keyBrush, keyX, keyY);

                float rightX = keyRect.Right + gap;
                float rightY = centerY - rightSize.Height / 2f;
                e.Graphics.DrawString(rightText, textFont, textBrush, rightX, rightY);
            }
        }

        private int ScaleAlpha(int baseAlpha)
        {
            return Math.Max(0, Math.Min(255, (int)Math.Round(baseAlpha * (PanelOpacity / 255.0))));
        }

        private GraphicsPath CreateRoundRectanglePath(Rectangle rect, int radius)
        {
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();

            path.AddArc(rect.Left, rect.Top, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Top, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.Left, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }
    }

    public class VideoControlOverlayPanel : Panel
    {
        public VideoControlOverlayPanel()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // 부모 배경을 그대로 유지하고, OnPaint에서 반투명 배경을 직접 그림
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rect = new Rectangle(0, 0, Width, Height);

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(155, 0, 0, 0)))
            using (Pen topLinePen = new Pen(Color.FromArgb(65, 255, 255, 255), 1f))
            {
                e.Graphics.FillRectangle(brush, rect);
                e.Graphics.DrawLine(topLinePen, 0, 0, Width, 0);
            }
        }

        private GraphicsPath CreateRoundRectanglePath(Rectangle rect, int radius)
        {
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();

            path.AddArc(rect.Left, rect.Top, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Top, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.Left, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}
