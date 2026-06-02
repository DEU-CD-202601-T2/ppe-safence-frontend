using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPE_관제_시스템
{
    public partial class US_SettingsForm : UserControl
    {
        private Dictionary<string, UserControl> userControls = new Dictionary<string, UserControl>();
        public US_SettingsForm()
        {
            InitializeComponent();
        }

        private void US_SettingsForm_Load(object sender, EventArgs e)
        {
            ShowMenu("PPEStandard"); // 초기 화면으로 PPE 기준 메뉴 보여주기
        }

        /// <summary>설정 화면 재진입 시 현재 보이는 내부 메뉴를 새로고침.</summary>
        public void RefreshCurrentMenu()
        {
            foreach (var kv in userControls)
            {
                if (kv.Value.Visible)
                {
                    if (kv.Value is US_PPEStandard ppeForm) _ = ppeForm.RefreshPageAsync();
                    else if (kv.Value is US_ZoneSetting zoneForm) _ = zoneForm.RefreshPageAsync();
                    break;
                }
            }
        }

        private void ShowMenu(string formName)
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

                // 재진입 시 최신 데이터로 새로고침
                if (formName == "PPEStandard" && userControls[formName] is US_PPEStandard ppeForm)
                    _ = ppeForm.RefreshPageAsync();
                else if (formName == "ZoneSettings" && userControls[formName] is US_ZoneSetting zoneForm)
                    _ = zoneForm.RefreshPageAsync();
            }
            else
            {
                // 새로운 폼을 생성하고 저장
                UserControl newForm = null;
                if (formName == "PPEStandard") // PPE 기준 메뉴 
                { 
                    newForm = new US_PPEStandard();
                }
                else if (formName == "AlertSettings") // 알림 설정 메뉴
                {
                    newForm = new US_AlertSettings();
                }
                else if (formName == "UserSettings") // 사용자 관리 메뉴
                {
                    newForm = new US_UsersSetting();
                }
                else if (formName == "ZoneSettings") // 구역 관리 메뉴
                {
                    newForm = new US_ZoneSetting();
                }

                if (newForm != null)
                {
                    newForm.Dock = DockStyle.Fill; // 폼이 패널 전체를 채우도록 설정
                    pnlMenuShow.Controls.Add(newForm); // 패널에 폼 추가
                    userControls.Add(formName, newForm); // 딕셔너리에 저장
                    newForm.Show();
                }
            }
        }

        private void SelectMenuButton(Button selectedButton) // 버튼 선택 시 폰트 스타일 변경
        {
            foreach (Control control in pnlSettingsMenu.Controls)
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
            pnlBar.Left = btn.Left + (btn.Width / 2) - (pnlBar.Width / 2);
        }

        private void btnPPEStandard_Click(object sender, EventArgs e)
        {
            ShowMenu("PPEStandard");
            pnlBar.Visible = true;
            SelectMenuButton(btnPPEStandard);
            MoveSideBar(btnPPEStandard);
        }

        private void btnAlertSettings_Click(object sender, EventArgs e)
        {
            ShowMenu("AlertSettings");
            pnlBar.Visible = true;
            SelectMenuButton(btnAlertSettings);
            MoveSideBar(btnAlertSettings);
        }

        private void btnUserSettings_Click(object sender, EventArgs e)
        {
            ShowMenu("UserSettings");
            pnlBar.Visible = true;
            SelectMenuButton(btnUserSettings);
            MoveSideBar(btnUserSettings);
        }

        private void btnZoneSettings_Click(object sender, EventArgs e)
        {
            ShowMenu("ZoneSettings");
            pnlBar.Visible = true;
            SelectMenuButton(btnZoneSettings);
            MoveSideBar(btnZoneSettings);
        }

        
    }
}