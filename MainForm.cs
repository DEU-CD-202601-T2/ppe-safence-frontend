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

namespace PPE_관제_시스템
{
    public partial class MainForm : Form
    {

        // 사용자 정의 컨트롤 폼 저장하는 딕셔너리
        private Dictionary<string, UserControl> userControls = new Dictionary<string, UserControl>();

        public MainForm()
        {
            InitializeComponent();
            pnlBar.Visible = false; // 왼쪽 패널 초기에는 숨김
            lblMenuName.Text = ""; // 초기 메뉴 이름 설정
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
            }
            else
            {
                // 새로운 폼을 생성하고 저장
                UserControl newForm = null;
                if (formName == "LiveMonitoringForm") // 실시간 모니터링 폼
                {
                    newForm = new US_LiveMonitoringForm();
                }
                else if (formName == "AlertsForm") // 알람 폼
                {
                    newForm = new US_AlertsForm();
                }
                else if (formName == "ViolationManagementForm") // 위반 관리 폼
                {
                    newForm = new US_ViolationManagementForm();
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
            lblMenuName.Text = "알람";
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

        
    }
}
