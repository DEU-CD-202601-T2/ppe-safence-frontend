using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private Image _refreshIcon;
        
        private CancellationTokenSource cameraCts;
        private Task cameraTask;
        private bool isCameraRunning = false;
        private System.Windows.Forms.Timer dataUpdateTimer;
        
        private List<ZoneData> zones = new List<ZoneData>();
        private List<CameraData> cameras = new List<CameraData>();
        private Image _cameraOfflineIcon;
        private bool _isInitialLoadCompleted = false;
        private bool _isReloadingForEnter = false;

        private const int NoZoneId = -1;
        private const string NoZoneDisplayName = "없음";

        public US_LiveMonitoringForm()
        {
            InitializeComponent();
            
            _refreshTimer = new System.Windows.Forms.Timer();
            _refreshTimer.Interval = 16;
            _refreshTimer.Tick += RefreshTimer_Tick;
    
            _refreshPen = new System.Drawing.Pen(AppColors.TextSecondary, 2.2f);
            _refreshPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            _refreshPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            picRefresh.BackColor = Color.Transparent;
            picRefresh.SizeMode = PictureBoxSizeMode.CenterImage;

            picZoneView.BringToFront();
            picZoneView.SizeMode = PictureBoxSizeMode.Zoom;
            picZoneView.BackColor = Color.Black;

            cmbZone.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbZone.DisplayMember = nameof(ZoneData.name);
            cmbZone.ValueMember = nameof(ZoneData.id);

            DataManager.OnDataChanged += OnDashboardUpdated;
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
        
        protected override async void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            // MainForm에서 UserControl을 재사용하므로 Load 이벤트는 최초 1회만 실행됨.
            // 실시간 모니터링 화면이 다시 표시될 때마다 구역 목록 API를 다시 조회한다.
            if (this.Visible && _isInitialLoadCompleted)
            {
                await RefreshLiveMonitoringPageAsync();
            }
        }

        public async Task RefreshLiveMonitoringPageAsync()
        {
            if (_isReloadingForEnter)
            {
                return;
            }

            _isReloadingForEnter = true;

            try
            {
                await LoadZonesToComboAsync();
                UpdateDashboard();
            }
            finally
            {
                _isReloadingForEnter = false;
            }
        }

        private ZoneData CreateNoZoneItem()
        {
            return new ZoneData
            {
                id = NoZoneId,
                name = NoZoneDisplayName,
                is_active = true
            };
        }
        private async Task LoadZonesToComboAsync()
        {
            try
            {
                SetCameraStatus("구역 정보 불러오는 중...", Color.Orange);

                // 설정 탭에서 구역 추가/수정/삭제 후 다시 진입했을 때 바로 반영되도록
                // 실시간 모니터링 화면 진입 시마다 구역 목록 API를 새로 조회한다.
                zones = await ApiService.GetZonesAsync(includeInactive: true);

                var streamResponse = await ApiService.GetStreamUrlsAsync();

                if (streamResponse == null)
                {
                    cameras = new List<CameraData>();
                    ShowCameraOffline();
                }
                else
                {
                    cameras = streamResponse.cameras ?? new List<CameraData>();
                    ShowCameraOnline(streamResponse.online_count);
                }

                cmbZone.SelectedIndexChanged -= cmbZone_SelectedIndexChanged;

                cmbZone.DataSource = null;
                cmbZone.Items.Clear();
                cmbZone.DisplayMember = nameof(ZoneData.name);
                cmbZone.ValueMember = nameof(ZoneData.id);

                var visibleZones = (zones ?? new List<ZoneData>())
                    .Where(z => z != null)
                    .OrderBy(z => z.name)
                    .ToList();

                if (visibleZones.Count == 0)
                {
                    // 구역 데이터가 전혀 없을 때만 "없음" 항목을 표시한다.
                    cmbZone.Enabled = true;
                    cmbZone.DataSource = new List<ZoneData> { CreateNoZoneItem() };
                    cmbZone.SelectedIndex = 0;

                    cmbZone.SelectedIndexChanged += cmbZone_SelectedIndexChanged;

                    StopCamera();
                    SetCameraStatus("등록된 구역 없음", Color.Red);
                    ShowCameraOfflinePlaceholder("등록된 구역이 없습니다");
                    return;
                }

                // 구역이 하나라도 있으면 "없음" 항목은 넣지 않고, 구역 이름만 표시한다.
                cmbZone.Enabled = true;
                cmbZone.DataSource = visibleZones;
                cmbZone.SelectedIndex = 0;

                cmbZone.SelectedIndexChanged += cmbZone_SelectedIndexChanged;

                await StartCameraBySelectedZoneAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"구역 콤보박스 로드 실패: {ex.Message}");
                SetCameraStatus("구역 정보 로드 실패", Color.Red);
                ShowCameraOfflinePlaceholder("구역 정보를 불러오지 못했습니다");
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

                    g.DrawString(message, font, textBrush, textX, textY);
                }
            }

            var oldImage = picZoneView.Image;
            picZoneView.Image = placeholder;
            picZoneView.BackColor = Color.Black;
            oldImage?.Dispose();
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

                if (!(cmbZone.SelectedItem is ZoneData selectedZone) || selectedZone.id == NoZoneId || selectedZone.name == NoZoneDisplayName)
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
                    cameras = new List<CameraData>();
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
                            return;
                        }

                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            SetCameraStatus($"{cameraName} 연결됨", Color.Green);

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
        
        private void ShowJpegFrame(byte[] jpgBytes)
        {
            try
            {
                using (var ms = new MemoryStream(jpgBytes))
                using (var temp = new Bitmap(ms))
                {
                    Bitmap frame = new Bitmap(temp);

                    if (!this.IsHandleCreated || this.IsDisposed)
                    {
                        frame.Dispose();
                        return;
                    }

                    this.BeginInvoke(new Action(() =>
                    {
                        try
                        {
                            var oldImage = picZoneView.Image;

                            picZoneView.Image = frame;
                            picZoneView.BackColor = Color.Black;

                            oldImage?.Dispose();
                        }
                        catch
                        {
                            frame.Dispose();
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

        private void UpdateDashboard() // 대시보드 정보를 업데이트하는 메서드, DataManager에서 데이터를 가져와 UI 요소에 반영
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(UpdateDashboard));

                return;
            }

            try
            {
                string selectedZone = "";

                if (cmbZone.SelectedItem is ZoneData zone)
                {
                    selectedZone = zone.name;
                }
                else
                {
                    selectedZone = cmbZone.SelectedItem?.ToString() ?? "";
                }
                if (selectedZone == NoZoneDisplayName)
                {
                    selectedZone = "";
                }

                var allData = DataManager.AllAlerts ?? new List<AlterDataClass>();
                var zoneData = allData.Where(d =>
                d.Area != null &&
                !string.IsNullOrEmpty(d.Area.AreaName) &&
                d.Area.AreaName.Trim() == selectedZone.Trim()).ToList();

                int unresolvedCount = zoneData.Count(d => d.Status != null && d.Status.Trim() == "미해결");
                lblNoPPECount.Text = unresolvedCount.ToString();

                int activeWorkerCount = zoneData
                    .Where(d => !string.IsNullOrEmpty(d.Uid))
                    .Select(d => d.Uid.Trim())
                    .Distinct()
                    .Count();

                lblActiveWorkersCount.Text = activeWorkerCount.ToString();
                double complianceRate = 100.0;
                if (zoneData.Count > 0)
                {
                    int resolvedCount = zoneData.Count(d => d.Status == "해결");
                    complianceRate = ((double)resolvedCount / zoneData.Count) * 100;
                }

                lblComplianceRate.Text = $"{complianceRate:F0}%";
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"대시보드 업데이트 오류 : {ex.Message}");
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
                UpdateDashboard();
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
                await RefreshLiveMonitoringPageAsync();

                InitUpdateTimer();
                _isInitialLoadCompleted = true;
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
            dataUpdateTimer.Interval = 5000;

            dataUpdateTimer.Tick += async (s, e) =>
            {
                try
                {
                    string selectedZone = "";

                    if (cmbZone.SelectedItem is ZoneData zone)
                    {
                        selectedZone = zone.name;
                    }
                    else
                    {
                        selectedZone = cmbZone.SelectedItem?.ToString() ?? "";
                    }

                    if (string.IsNullOrWhiteSpace(selectedZone) || selectedZone == NoZoneDisplayName)
                    {
                        return;
                    }

                    var newData = await ApiService.GetViolationsAsync(selectedZone, "미해결");

                    if (newData != null)
                    {
                        DataManager.AllAlerts = newData;
                        DataManager.NotifyDataChanged();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"데이터 업데이트 타이머 오류: {ex.Message}");
                }
            };

            dataUpdateTimer.Start();
        }
        
        // === Refresh 아이콘 그리기 ===
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
                    Console.WriteLine("새로고침 아이콘 파일을 찾을 수 없습니다.");
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

        private void picRefresh_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            Image icon = GetRefreshIcon();

            if (icon == null)
            {
                return;
            }

            int iconSize = Math.Max(16, Math.Min(picRefresh.Width, picRefresh.Height) - 2);
            float centerX = picRefresh.Width / 2f;
            float centerY = picRefresh.Height / 2f;

            g.TranslateTransform(centerX, centerY);
            g.RotateTransform(_refreshAngle);
            g.DrawImage(icon, -iconSize / 2f, -iconSize / 2f, iconSize, iconSize);
            g.ResetTransform();
        }

        private async void picRefresh_Click(object sender, EventArgs e)
        {
            if (_isRefreshing) return;
            
            _isRefreshing = true;
            _refreshAngle = 0f;
            _refreshTimer.Start();
            
            try
            {
                await RefreshCameraStatusAsync();
            }
            catch
            {
                // 무시 - RefreshCameraStatusAsync 내부에서 UI 처리
            }
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            _refreshAngle += 12f;
            if (_refreshAngle >= 360f)
            {
                _refreshAngle = 0f;
                _refreshTimer.Stop();
                _isRefreshing = false;
            }
            picRefresh.Invalidate();
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
                    cameras = response.cameras ?? new List<CameraData>();
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
            
            lblCameraCount.Text = $"카메라 {count}대";
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
}
