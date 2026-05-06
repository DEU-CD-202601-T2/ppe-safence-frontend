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
using System.Drawing.Text;
using System.Security.Policy;

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

            DataManager.OnDataChanged += () =>
            {
                if (this.IsHandleCreated)
                {

                    this.BeginInvoke(new Action(() => {
                        UpdateDashboard();
                        UpdateLiveAlarmList(); 
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

            DataManager.OnDataChanged += () =>
            {
                if (this.Visible)
                {
                    UpdateLiveAlarmList();
                }
            };
        }

        private void US_LiveMonitoringForm_Load(object sender, EventArgs e)
        {
            if (cmbZone != null && cmbZone.Items.Count > 0) cmbZone.SelectedIndex = 0;
            UpdateDashboard();
            StartCamera();
        }

        private async void StartCamera()
        {
            try {

                string rtsUrl = "http://43.200.27.117:5000/api/stream-urls";
                capture = new VideoCapture(rtsUrl);
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

        private void UpdateDashboard()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(UpdateDashboard));
                return;
            }
            try
            {
                var allData = DataManager.AllAlerts ?? new List<AlterDataClass>();
                var zoneData = allData;
  
                int unwornCount = zoneData.Count(d => d.Status != null && d.Status.Trim().Contains ("미해결"));
                lblNoPPECount.Text = unwornCount.ToString();

                int warningCount = zoneData.Count(d => d.Status == "미해결" && d.Type.Contains("미착용"));
                lblWarningCount.Text = warningCount.ToString();

                double complianceRate = 100.0;
                if (zoneData.Count > 0)
                {
                    int resolvedCount = zoneData.Count(d => d.Status == "해결");
                    complianceRate = ((double)resolvedCount / zoneData.Count) * 100;
                }
                lblComplianceRate.Text = $"{complianceRate:F0}%";

                if (unwornCount > 0)
                {
                    lblCameraStatus.Text = "위험";
                    lblCameraStatus.ForeColor = Color.Red;
                }
                else
                {
                    lblCameraStatus.Text = "정상";
                    lblCameraStatus.ForeColor = Color.Green;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void UpdateLiveAlarmList()
        {

        }
    }
}
