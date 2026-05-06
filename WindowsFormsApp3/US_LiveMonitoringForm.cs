using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPE_관제_시스템
{
    public partial class US_LiveMonitoringForm : UserControl
    {
        private OpenCvSharp.VideoCapture capture;
        private Mat frame;
        private Thread cameraThread;
        private bool isCameraRunning = false;

        public US_LiveMonitoringForm() // 폼 초기화 및 이벤트 핸들러 등록
        {
            InitializeComponent();
            picZoneView.Dock = DockStyle.None;

            DataManager.OnDataChanged += () =>
            {
                if (this.IsHandleCreated)
                {
                    this.BeginInvoke(new Action(() => {
                        UpdateDashboard();
                    }));
                }
            };

            if (cmbZone != null)
            {
                cmbZone.SelectedIndexChanged += (s, e) => UpdateDashboard();
            }

            picZoneView.BringToFront();
            picZoneView.SizeMode = PictureBoxSizeMode.Zoom;
            picZoneView.BackColor = Color.Black;
            this.Load += US_LiveMonitoringForm_Load; // 폼 로드 이벤트 핸들러 등록
        }

        private async void StartCamera() // 카메라 스트림을 시작하는 메서드, API에서 스트림 URL을 받아 OpenCV로 연결 시도
        {
            try
            {
                StopCamera(); // 시작 전 기존 연결 정리
                SetCameraStatus("연결 중...", Color.Orange);

                var streamData = await ApiService.GetCameraStreamInfoAsync();

                if (streamData != null && !string.IsNullOrEmpty(streamData.Url))
                {
                    // UI의 "카메라 1대" 라벨 업데이트
                    this.BeginInvoke(new Action(() => {
                        lblCameraCount.Text = $"카메라 {streamData.Count}대";
                    }));

                    // OpenCV 비디오 캡처 시작
                    capture = new VideoCapture(streamData.Url);
                    capture.Set(VideoCaptureProperties.BufferSize, 1);

                    if (!capture.IsOpened()) throw new Exception("Capture Open 실패");

                    isCameraRunning = true;
                    cameraThread = new Thread(CaptureCameraCallback) { IsBackground = true };
                    cameraThread.Start();

                    SetCameraStatus("정상", Color.Green);
                }
                else
                {
                    SetCameraStatus("인증 실패", Color.Red); // API에서 스트림 정보가 없거나 URL이 비어있는 경우
                }
            }
            catch (Exception ex)
            {
                SetCameraStatus("오류", Color.Red);
                this.BeginInvoke(new Action(() => MessageBox.Show($"카메라 연결 실패: {ex.Message}")));
            }
        }

        private void CaptureCameraCallback() // 카메라 스트림을 읽고 PictureBox에 표시하는 백그라운드 스레드 메서드
        {
   
            while (isCameraRunning)
            {
                if (capture == null || !capture.IsOpened()) break;

                using (Mat frame = new Mat())
                {
                    if (capture.Read(frame) && !frame.Empty())
                    {
                        Bitmap bitmap = BitmapConverter.ToBitmap(frame);

                        this.BeginInvoke(new MethodInvoker(delegate
                        {
                            var oldImg = picZoneView.Image;
                            picZoneView.Image = bitmap;
                            oldImg?.Dispose();
                        }));
                    }
                }
                Thread.Sleep(33);
            }
        }

        public void StopCamera() // 카메라 스트림과 관련된 리소스 정리
        {
            isCameraRunning = false;
            if(cameraThread != null && cameraThread.IsAlive)
            {
                cameraThread.Join(500);
            }
            capture?.Release();
            frame?.Dispose();

            if(picZoneView.Image != null)
            {
                picZoneView.Image.Dispose();
                picZoneView.Image = null;
            }
        }

        private void UpdateDashboard() // 대시보드의 통계 및 상태 정보를 업데이트하는 메서드, UI 스레드에서 안전하게 호출
        {
            if (this.InvokeRequired) { this.Invoke(new Action(UpdateDashboard)); return; }

            try
            {
                var allData = DataManager.AllAlerts ?? new List<AlterDataClass>();

                int unwornCount = allData.Count(d => d.Status?.Trim() == "미해결");
                lblNoPPECount.Text = unwornCount.ToString();

                int activeWorkers = allData.Count;
                lblActiveWorkersCount.Text = activeWorkers.ToString();

                double complianceRate = 100.0;
                if (activeWorkers > 0)
                {
                    complianceRate = ((double)(activeWorkers - unwornCount) / activeWorkers) * 100;

                    if (complianceRate < 0) complianceRate = 0;
                }
                lblComplianceRate.Text = $"{complianceRate:F0}%";

                if (unwornCount > 0)
                    SetCameraStatus("위험", Color.Red);
                else
                    SetCameraStatus("정상", Color.Green);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"대시보드 업데이트 오류: {ex.Message}");
            }
        }

        private void SetCameraStatus(string text, Color color) // UI 스레드에서 안전하게 카메라 상태 업데이트
        {
            if (lblCameraStatus.InvokeRequired)
            {
                lblCameraStatus.Invoke(new Action(() => SetCameraStatus(text, color)));
                return;
            }
            lblCameraStatus.Text = text;
            lblCameraStatus.ForeColor = color;
        }

        private void US_LiveMonitoringForm_Load(object sender, EventArgs e) // 폼이 로드될 때 대시보드 업데이트 및 카메라 스트림 시작
        {
            if (cmbZone != null && cmbZone.Items.Count > 0) cmbZone.SelectedIndex = 0;
            UpdateDashboard();
            StartCamera();
        }

        private void cmbZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            StopCamera();
            SetCameraStatus("구역 변경 중...", Color.Orange);
            UpdateDashboard();
            StartCamera();
        }
    }
}
