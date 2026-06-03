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
    public partial class US_AlertSettings : UserControl
    {
        //서버에서 조회한 알림 설정 목록
        private List<AlertSettingDto> alertSettings;
        public US_AlertSettings()
        {
            InitializeComponent();
        }

        private void LoadCurrentAlertSetting()
        {
            string alertType = cmbAlertType.Text;

            AlertSettingDto setting =
                alertSettings.FirstOrDefault(x =>
                    x.AlertType == alertType);

            if (setting == null)
                return;

            //UI에 설정값 반영
            chkUseAlert.Checked =
                setting.IsEnabled;

            chkSendManager.Checked =
                setting.SendToAdmin;

            chkStopWork.Checked =
                setting.StopWorkOnViolation;

            cmbSeverity.Text =
                setting.MinRiskLevel;

            txtInterval.Text =
                setting.RepeatInterval?.ToString() ?? "";
        }

        //알람 설정 초기화
        private async void btnAlertReset_Click(object sender, EventArgs e)
        {
            try
            {
                ResetAlertSettingResponse result = await ApiService.ResetAlertSettingsAsync();

                alertSettings = result.Settings;
                //초기화된 설정값으로 UI 업데이트
                LoadCurrentAlertSetting();

                MessageBox.Show(
                    result.Message,
                    "알림",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "오류",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        //현재 알람 설정 저장
        private async void btnAlertSave_Click(object sender, EventArgs e)
        {
            try
            {
                AlertSettingDto dto = new AlertSettingDto
                {
                    AlertType = cmbAlertType.Text,
                    MinRiskLevel = cmbSeverity.Text,
                    RepeatInterval = string.IsNullOrWhiteSpace(txtInterval.Text)
                        ? (int?)null
                        : int.Parse(txtInterval.Text),
                    SendToAdmin = chkSendManager.Checked,
                    StopWorkOnViolation = chkStopWork.Checked,
                    IsEnabled = chkUseAlert.Checked
                };

                bool result = await ApiService.SaveAlertSettingAsync(dto);

                if (result)
                {
                    if (alertSettings != null)
                    {
                        var currentSetting = alertSettings.FirstOrDefault(x => x.AlertType == dto.AlertType);
                        if (currentSetting != null)
                        {
                            currentSetting.MinRiskLevel = dto.MinRiskLevel;
                            currentSetting.RepeatInterval = dto.RepeatInterval;
                            currentSetting.SendToAdmin = dto.SendToAdmin;
                            currentSetting.StopWorkOnViolation = dto.StopWorkOnViolation;
                            currentSetting.IsEnabled = dto.IsEnabled;
                        }
                    }
                    MessageBox.Show("저장되었습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"저장 실패: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //알람 유형 변경 시 해당 유형의 설정값 로드
        private void cmbAlertType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCurrentAlertSetting();
        }

        //알람 사용 여부 변경 시 상태 표시 업데이트
        private void chkUseAlert_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseAlert.Checked)
            { 
                lblStatus.Text = "활성화";
                lblStatus.ForeColor = Color.Green;
            }
            else
            {
                lblStatus.Text = "비활성화";
                lblStatus.ForeColor = Color.Red;
            }

        }
        //알람 설정 정보 조회
        private async void US_AlertSettings_Load(object sender, EventArgs e)
        {
            try
            {
                alertSettings = await ApiService.GetAlertSettingAsync();

                LoadCurrentAlertSetting();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
