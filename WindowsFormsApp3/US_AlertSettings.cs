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

        private async void btnAlertReset_Click(object sender, EventArgs e)
        {
            try
            {
                ResetAlertSettingResponse result = await ApiService.ResetAlertSettingsAsync();

                alertSettings = result.Settings;

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

        private void cmbAlertType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCurrentAlertSetting();
        }

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
