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
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPE_관제_시스템
{
    public partial class US_LiveMonitoringForm : UserControl
    {
        private VideoCapture capture;

        private Thread cameraThread;

        private bool isCameraRunning = false;

        public US_LiveMonitoringForm()
        {
            InitializeComponent();
            
            picZoneView.Dock = DockStyle.None; // PictureBox의 Dock 속성을 None으로 설정하여 위치와 크기를 직접 제어

            picZoneView.BringToFront(); // PictureBox가 다른 컨트롤보다 앞에 오도록 설정

            picZoneView.SizeMode = PictureBoxSizeMode.Zoom; // PictureBox의 SizeMode를 Zoom으로 설정하여 영상이 PictureBox 크기에 맞게 조절되도록 함

            picZoneView.BackColor = Color.Black; 

            this.Load += US_LiveMonitoringForm_Load;

            cmbZone.SelectedIndexChanged += cmbZone_SelectedIndexChanged;

            DataManager.OnDataChanged += OnDashboardUpdated;
        }

        private void OnDashboardUpdated() // DataManager의 데이터 업데이트 이벤트 핸들러, 대시보드 정보 갱신 트리거
        {
            if (this.IsHandleCreated)
            {
                this.BeginInvoke(new Action(async () =>
                {
                    UpdateDashboard();
                }));
            }
        }

        private async Task StartCamera() // 카메라 스트림을 시작하는 메서드, API에서 스트림 URL을 받아 OpenCV로 연결 시도
        {
            try
            {
                if (isCameraRunning) return;

                StopCamera();

                SetCameraStatus("카메라 연결 중...", Color.Orange);

                var streamData = await ApiService.GetCameraStreamInfoAsync();

                if (streamData == null)
                {
                    SetCameraStatus("카메라 정보 불러오기 실패", Color.Red);
                    return;
                }

                if (string.IsNullOrEmpty(streamData.Url))
                {
                    SetCameraStatus("유효한 카메라 URL 없음", Color.Red);
                    return;
                }

                lblCameraCount.Text = $"카메라 {streamData.Count}대";

                capture = new VideoCapture(streamData.Url);

                capture.Set(VideoCaptureProperties.BufferSize, 1);

                if (!capture.IsOpened())
                {
                    SetCameraStatus("연결 실패", Color.Red);
                    return;
                }

                isCameraRunning = true;
                cameraThread = new Thread(CaptureCameraCallback);
                cameraThread.Start();
                SetCameraStatus("연결됨", Color.Green);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"카메라 시작 오류: {ex.Message}");
                SetCameraStatus("연결 오류", Color.Red);
            }

        }

        private void CaptureCameraCallback() // 카메라 스트림을 읽고 PictureBox에 표시하는 백그라운드 스레드 메서드
        {
   
            while (isCameraRunning)
            {
                try
                {
                    if (capture == null ||
                        !capture.IsOpened())
                    {
                        SetCameraStatus("재연결 시도 중...", Color.Orange);

                        Thread.Sleep(3000);

                        this.BeginInvoke(new Action(async () =>
                            {
                                await StartCamera();
                            }));

                        break;
                    }

                    using (Mat frame = new Mat())
                    {
                        bool success = capture.Read(frame);

                        if (!success || frame.Empty())
                        {
                            Thread.Sleep(30);

                            continue;
                        }

                        Bitmap bitmap = BitmapConverter.ToBitmap(frame);

                        this.BeginInvoke(new MethodInvoker(delegate
                            {
                                try
                                {
                                    var oldImage = picZoneView.Image;

                                    picZoneView.Image = (Bitmap)bitmap.Clone();

                                    oldImage?.Dispose();

                                    bitmap.Dispose();
                                }
                                catch
                                {
                                    
                                }
                            }));
                    }

                    Thread.Sleep(33);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"카메라 스레드 오류 : {ex.Message}");

                    Thread.Sleep(1000);
                }
            }
        }

        public void StopCamera() // 카메라 스트림을 안전하게 종료하는 메서드, 스레드와 리소스 정리 포함
        {
            try
            {
                isCameraRunning = false;

                if (cameraThread != null && cameraThread.IsAlive)
                {
                    cameraThread.Join();
                }

                capture?.Release();

                capture?.Dispose();

                capture = null;

                if (picZoneView.Image != null)
                {
                    picZoneView.Image.Dispose();

                    picZoneView.Image = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"카메라 종료 오류 : {ex.Message}");
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
                var allData =
                    DataManager.AllAlerts
                    ?? new List<AlterDataClass>();

                int unwornCount = allData.Count(d => d.Status?.Trim() == "미해결");

                lblNoPPECount.Text = unwornCount.ToString();

                int activeWorkers = allData.Count;

                lblActiveWorkersCount.Text = activeWorkers.ToString();

                double complianceRate = 100;

                if (activeWorkers > 0)
                {
                    complianceRate =
                        ((double)
                        (activeWorkers - unwornCount)
                        / activeWorkers)
                        * 100;

                    if (complianceRate < 0)
                        complianceRate = 0;
                }

                lblComplianceRate.Text = $"{complianceRate:F0}%";

                if (unwornCount > 0)
                {
                    SetCameraStatus("위험", Color.Red);
                }
                else
                {
                    SetCameraStatus("안전", Color.Green);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"대시보드 업데이트 오류 : {ex.Message}");
            }
        }

        private void SetCameraStatus(string text, Color color) // UI 스레드에서 안전하게 카메라 상태 업데이트
        {
            if (lblCameraStatus.InvokeRequired)
            {
                lblCameraStatus.Invoke(
                    new Action(() =>
                    SetCameraStatus(text, color)));

                return;
            }

            lblCameraStatus.Text = text;

            lblCameraStatus.ForeColor = color;
        }

        private async void cmbZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                StopCamera();

                SetCameraStatus("구역 변경 중...", Color.Orange);

                UpdateDashboard();

                await StartCamera();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"구역 변경 실패 : {ex.Message}");
            }
        }

        private async void US_LiveMonitoringForm_Load(object sender, EventArgs e)
        {
            try
            {
                if(cmbZone.Items.Count > 0)
                {
                    cmbZone.SelectedIndex = 0;
                }

                UpdateDashboard();

                await StartCamera();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"폼 로드 오류: {ex.Message}");
            }
        }
    }
}
