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

        public MainForm()
        {
            InitializeComponent();
            
            this.Text = "PPE 관제 시스템";
            
            string iconPath = Path.Combine(Application.StartupPath, "Resources", "PPE_Icon.ico");
            if (File.Exists(iconPath))
            {
                this.Icon = new Icon(iconPath);
            }
            
            this.Load += MainForm_Load; // 폼 로드 이벤트 핸들러 등록
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 초기 화면으로 실시간 모니터링 폼 보여주기
            ShowForm("LiveMonitoringForm");
            pnlBar.Visible = true;
            lblMenuName.Text = "실시간 모니터링";
            SelectMenuButton(btnLiveMonitoring);
            MoveSideBar(btnLiveMonitoring);
        }

        private void ShowForm(string formName)
        {
            // 폼을 이미 생성했으면 그냥 보여주기
            if (userControls.ContainsKey(formName))
            {
                // 모든 폼 숨기기
                foreach (var control in userControls.Values)
                {
                    control.Hide();
                }

                // 선택한 폼만 보이게 하기
                userControls[formName].Show();

                // 실시간 모니터링 화면은 다시 접속할 때마다 구역 목록/금일 위반 현황을 API로 재조회
                if (formName == "LiveMonitoringForm" && userControls[formName] is US_LiveMonitoringForm liveForm)
                {
                    _ = liveForm.RefreshPageAsync();
                }
            }
            else
            {
                // 새로운 폼을 생성하고 저장
                UserControl newForm = null;
                if (formName == "LiveMonitoringForm") // 실시간 모니터링 폼
                {
                    newForm = new US_LiveMonitoringForm();
                }
                else if (formName == "AlertsForm") // 알림 폼
                {
                    newForm = new US_AlertsForm();
                }
                else if (formName == "ViolationManagementForm") // 위반 관리 폼
                {
                    newForm = new US_ViolationManagementForm();
                }
                else if (formName == "ControlForm") // 대응 / 제어 폼
                {
                    newForm = new US_ControlForm();
                }
                else if (formName == "DetectionLogForm") // 이력 / 로그 폼
                {
                    newForm = new US_DetectionLogForm();
                }
                else if (formName == "AnalysisForm") // 분석 폼
                {
                    newForm = new US_AnalysisForm();
                }
                else if (formName == "SettingsForm") // 설정 폼
                {
                    newForm = new US_SettingsForm();
                }

                if (newForm != null)
                {
                    newForm.Dock = DockStyle.Fill; // 폼이 패널 전체를 채우도록 설정
                    pnlMain.Controls.Add(newForm); // 패널에 폼 추가
                    userControls.Add(formName, newForm); // 딕셔너리에 저장
                    newForm.Show();
                }
            }
        }

        private void SelectMenuButton(Button selectedButton) // 버튼 선택 시 폰트 스타일 변경
        {
            foreach (Control control in pnlMenu.Controls)
            {
                if (control is Button button)
                {
                    button.Font = new Font(button.Font, FontStyle.Regular);
                }
            }

            selectedButton.Font = new Font(selectedButton.Font, FontStyle.Bold);
        }

        private void MoveSideBar(Control btn) // 사이드바 위치 이동
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
        }

        private void btnAlerts_Click(object sender, EventArgs e)
        {
            ShowForm("AlertsForm");
            pnlBar.Visible = true;
            lblMenuName.Text = "알림";
            SelectMenuButton(btnAlerts);
            MoveSideBar(btnAlerts);
        }
        private void btnViolationManagement_Click(object sender, EventArgs e)
        {
            ShowForm("ViolationManagementForm");
            pnlBar.Visible = true;
            lblMenuName.Text = "위반 관리";
            SelectMenuButton(btnViolationManagement);
            MoveSideBar(btnViolationManagement);
        }

        private void btnControl_Click_1(object sender, EventArgs e)
        {
            ShowForm("ControlForm");
            pnlBar.Visible = true;
            lblMenuName.Text = "대응 / 제어";
            SelectMenuButton(btnControl);
            MoveSideBar(btnControl);
        }

        private void btnDetectionLog_Click_1(object sender, EventArgs e)
        {
            ShowForm("DetectionLogForm");
            pnlBar.Visible = true;
            lblMenuName.Text = "이력 / 로그";
            SelectMenuButton(btnDetectionLog);
            MoveSideBar(btnDetectionLog);
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            ShowForm("AnalysisForm");
            pnlBar.Visible = true;
            lblMenuName.Text = "분석";
            SelectMenuButton(btnAnalysis);
            MoveSideBar(btnAnalysis);
        }

        private void btnSettings_Click_1(object sender, EventArgs e)
        {
            ShowForm("SettingsForm");
            pnlBar.Visible = true;
            lblMenuName.Text = "설정";
            SelectMenuButton(btnSettings);
            MoveSideBar(btnSettings);
        }
    }
}
