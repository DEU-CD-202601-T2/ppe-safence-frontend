using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace PPE_관제_시스템
{
    public partial class US_LiveMonitoringForm : UserControl
    {
        private OpenCvSharp.VideoCapture capture;
        private Mat frame;
        private Thread cameraThread;
        private bool isCameraRunning = false;

        public US_LiveMonitoringForm()
        {
            InitializeComponent();
            picZoneView.Dock = DockStyle.None;

            picZoneView.Size = new System.Drawing.Size(800, 450);
            picZoneView.Location = new System.Drawing.Point(50, 200);

            picZoneView.BringToFront();
            picZoneView.SizeMode = PictureBoxSizeMode.Zoom;
            picZoneView.BackColor = Color.Black;
            this.Load += US_LiveMonitoringForm_Load; // 폼 로드 이벤트 핸들러 등록

            DataManager.OnDataChanged += () =>
            {
                if (this.Visible)
                {
                    UpdateLiveAlarmList();
                }
            };
        }

        private void UpdateLiveAlarmList()
        {
            if (this.InvokeRequired) { }
        }

        private void US_LiveMonitoringForm_Load(object sender, EventArgs e)
        {
            StartCamera();
        }

        private void StartCamera()
        {
            try {

                string rtsUrl = "http://43.200.27.117:5000/api/stream-urls";
                capture = new VideoCapture(0);
                if (!capture.IsOpened())
                {
                    lblCameraStatus.Text = "연결 실패";
                    lblCameraStatus.ForeColor = Color.Red;
                    return;
                }

                isCameraRunning = true;
                frame = new Mat();

                cameraThread = new Thread(new ThreadStart(CaptureCameraCallback));
                cameraThread.IsBackground = true;
                cameraThread.Start();

                lblCameraStatus.Text = "정상";
                lblCameraStatus.ForeColor = Color.Green;
            } catch (Exception ex) {
                MessageBox.Show("카메라 로딩 중 오류가 발생했습니다: " + ex.Message, "카메라 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    };
            }

        private void CaptureCameraCallback()
        {
   
            while (isCameraRunning)
            {
                if (capture == null || !capture.IsOpened()) break;

                capture.Read(frame);
                if (!frame.Empty()) continue;

                Bitmap bitmap = BitmapConverter.ToBitmap(frame);

                this.BeginInvoke(new MethodInvoker(delegate
                {
                    if (picZoneView.Image != null) picZoneView.Image.Dispose();
                    picZoneView.Image = bitmap;
                }));
                Thread.Sleep(33);
            }
        }
        public void StopCamera()
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
    }
}
