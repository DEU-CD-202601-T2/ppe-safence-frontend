namespace PPE_관제_시스템
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSettingHeader = new System.Windows.Forms.Label();
            this.pnlSettingMenu = new System.Windows.Forms.Panel();
            this.btnZoneSettings = new System.Windows.Forms.Button();
            this.btnUserSettings = new System.Windows.Forms.Button();
            this.btnAlertSettings = new System.Windows.Forms.Button();
            this.btnPPEStandard = new System.Windows.Forms.Button();
            this.pnlShow = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnAnalysis = new System.Windows.Forms.Button();
            this.btnDetectionLog = new System.Windows.Forms.Button();
            this.btnControl = new System.Windows.Forms.Button();
            this.lblPPESystem = new System.Windows.Forms.Label();
            this.btnViolationManagement = new System.Windows.Forms.Button();
            this.btnAlerts = new System.Windows.Forms.Button();
            this.btnMonitoring = new System.Windows.Forms.Button();
            this.pnlSettingMenu.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSettingHeader
            // 
            this.lblSettingHeader.AutoSize = true;
            this.lblSettingHeader.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSettingHeader.Location = new System.Drawing.Point(273, 9);
            this.lblSettingHeader.Name = "lblSettingHeader";
            this.lblSettingHeader.Size = new System.Drawing.Size(73, 38);
            this.lblSettingHeader.TabIndex = 2;
            this.lblSettingHeader.Text = "설정";
            // 
            // pnlSettingMenu
            // 
            this.pnlSettingMenu.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlSettingMenu.Controls.Add(this.btnZoneSettings);
            this.pnlSettingMenu.Controls.Add(this.btnUserSettings);
            this.pnlSettingMenu.Controls.Add(this.btnAlertSettings);
            this.pnlSettingMenu.Controls.Add(this.btnPPEStandard);
            this.pnlSettingMenu.Location = new System.Drawing.Point(280, 78);
            this.pnlSettingMenu.Name = "pnlSettingMenu";
            this.pnlSettingMenu.Size = new System.Drawing.Size(645, 70);
            this.pnlSettingMenu.TabIndex = 3;
            // 
            // btnZoneSettings
            // 
            this.btnZoneSettings.Location = new System.Drawing.Point(483, 3);
            this.btnZoneSettings.Name = "btnZoneSettings";
            this.btnZoneSettings.Size = new System.Drawing.Size(154, 64);
            this.btnZoneSettings.TabIndex = 3;
            this.btnZoneSettings.Text = "구역 설정";
            this.btnZoneSettings.UseVisualStyleBackColor = true;
            this.btnZoneSettings.Click += new System.EventHandler(this.btnZoneSettings_Click);
            // 
            // btnUserSettings
            // 
            this.btnUserSettings.Location = new System.Drawing.Point(323, 3);
            this.btnUserSettings.Name = "btnUserSettings";
            this.btnUserSettings.Size = new System.Drawing.Size(154, 64);
            this.btnUserSettings.TabIndex = 2;
            this.btnUserSettings.Text = "사용자 설정";
            this.btnUserSettings.UseVisualStyleBackColor = true;
            this.btnUserSettings.Click += new System.EventHandler(this.btnUserSettings_Click);
            // 
            // btnAlertSettings
            // 
            this.btnAlertSettings.Location = new System.Drawing.Point(163, 3);
            this.btnAlertSettings.Name = "btnAlertSettings";
            this.btnAlertSettings.Size = new System.Drawing.Size(154, 64);
            this.btnAlertSettings.TabIndex = 1;
            this.btnAlertSettings.Text = "알림 설정";
            this.btnAlertSettings.UseVisualStyleBackColor = true;
            this.btnAlertSettings.Click += new System.EventHandler(this.btnAlertSettings_Click);
            // 
            // btnPPEStandard
            // 
            this.btnPPEStandard.Location = new System.Drawing.Point(3, 3);
            this.btnPPEStandard.Name = "btnPPEStandard";
            this.btnPPEStandard.Size = new System.Drawing.Size(154, 64);
            this.btnPPEStandard.TabIndex = 0;
            this.btnPPEStandard.Text = "PPE 기준";
            this.btnPPEStandard.UseVisualStyleBackColor = true;
            this.btnPPEStandard.Click += new System.EventHandler(this.btnPPEStandard_Click);
            // 
            // pnlShow
            // 
            this.pnlShow.Location = new System.Drawing.Point(280, 189);
            this.pnlShow.Name = "pnlShow";
            this.pnlShow.Size = new System.Drawing.Size(890, 472);
            this.pnlShow.TabIndex = 4;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlMenu.Controls.Add(this.label11);
            this.pnlMenu.Controls.Add(this.btnSettings);
            this.pnlMenu.Controls.Add(this.btnAnalysis);
            this.pnlMenu.Controls.Add(this.btnDetectionLog);
            this.pnlMenu.Controls.Add(this.btnControl);
            this.pnlMenu.Controls.Add(this.lblPPESystem);
            this.pnlMenu.Controls.Add(this.btnViolationManagement);
            this.pnlMenu.Controls.Add(this.btnAlerts);
            this.pnlMenu.Controls.Add(this.btnMonitoring);
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(268, 676);
            this.pnlMenu.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(56, 78);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(160, 2);
            this.label11.TabIndex = 9;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSettings.Location = new System.Drawing.Point(21, 452);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(2);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(226, 51);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "설정";
            this.btnSettings.UseVisualStyleBackColor = false;
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnAnalysis.FlatAppearance.BorderSize = 0;
            this.btnAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalysis.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAnalysis.Location = new System.Drawing.Point(22, 397);
            this.btnAnalysis.Margin = new System.Windows.Forms.Padding(2);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(226, 51);
            this.btnAnalysis.TabIndex = 5;
            this.btnAnalysis.Text = "분석";
            this.btnAnalysis.UseVisualStyleBackColor = false;
            // 
            // btnDetectionLog
            // 
            this.btnDetectionLog.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnDetectionLog.FlatAppearance.BorderSize = 0;
            this.btnDetectionLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetectionLog.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDetectionLog.Location = new System.Drawing.Point(21, 341);
            this.btnDetectionLog.Margin = new System.Windows.Forms.Padding(2);
            this.btnDetectionLog.Name = "btnDetectionLog";
            this.btnDetectionLog.Size = new System.Drawing.Size(226, 51);
            this.btnDetectionLog.TabIndex = 4;
            this.btnDetectionLog.Text = "이력 / 로그";
            this.btnDetectionLog.UseVisualStyleBackColor = false;
            // 
            // btnControl
            // 
            this.btnControl.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnControl.FlatAppearance.BorderSize = 0;
            this.btnControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnControl.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnControl.Location = new System.Drawing.Point(21, 285);
            this.btnControl.Margin = new System.Windows.Forms.Padding(2);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(226, 51);
            this.btnControl.TabIndex = 3;
            this.btnControl.Text = "대응 / 제어";
            this.btnControl.UseVisualStyleBackColor = false;
            // 
            // lblPPESystem
            // 
            this.lblPPESystem.AutoSize = true;
            this.lblPPESystem.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPPESystem.Location = new System.Drawing.Point(51, 37);
            this.lblPPESystem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPPESystem.Name = "lblPPESystem";
            this.lblPPESystem.Size = new System.Drawing.Size(177, 31);
            this.lblPPESystem.TabIndex = 2;
            this.lblPPESystem.Text = "PPE 관제시스템";
            // 
            // btnViolationManagement
            // 
            this.btnViolationManagement.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnViolationManagement.FlatAppearance.BorderSize = 0;
            this.btnViolationManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViolationManagement.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViolationManagement.Location = new System.Drawing.Point(21, 229);
            this.btnViolationManagement.Margin = new System.Windows.Forms.Padding(2);
            this.btnViolationManagement.Name = "btnViolationManagement";
            this.btnViolationManagement.Size = new System.Drawing.Size(226, 51);
            this.btnViolationManagement.TabIndex = 2;
            this.btnViolationManagement.Text = "위반관리";
            this.btnViolationManagement.UseVisualStyleBackColor = false;
            // 
            // btnAlerts
            // 
            this.btnAlerts.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnAlerts.FlatAppearance.BorderSize = 0;
            this.btnAlerts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlerts.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAlerts.Location = new System.Drawing.Point(22, 173);
            this.btnAlerts.Margin = new System.Windows.Forms.Padding(2);
            this.btnAlerts.Name = "btnAlerts";
            this.btnAlerts.Size = new System.Drawing.Size(226, 51);
            this.btnAlerts.TabIndex = 1;
            this.btnAlerts.Text = "알림";
            this.btnAlerts.UseVisualStyleBackColor = false;
            // 
            // btnMonitoring
            // 
            this.btnMonitoring.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnMonitoring.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnMonitoring.FlatAppearance.BorderSize = 0;
            this.btnMonitoring.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnMonitoring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonitoring.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMonitoring.Location = new System.Drawing.Point(22, 118);
            this.btnMonitoring.Margin = new System.Windows.Forms.Padding(2);
            this.btnMonitoring.Name = "btnMonitoring";
            this.btnMonitoring.Size = new System.Drawing.Size(226, 51);
            this.btnMonitoring.TabIndex = 0;
            this.btnMonitoring.Text = "실시간 모니터링";
            this.btnMonitoring.UseVisualStyleBackColor = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 673);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlShow);
            this.Controls.Add(this.pnlSettingMenu);
            this.Controls.Add(this.lblSettingHeader);
            this.Name = "SettingsForm";
            this.Text = "설정";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
            this.pnlSettingMenu.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSettingHeader;
        private System.Windows.Forms.Panel pnlSettingMenu;
        private System.Windows.Forms.Panel pnlShow;
        private System.Windows.Forms.Button btnZoneSettings;
        private System.Windows.Forms.Button btnUserSettings;
        private System.Windows.Forms.Button btnAlertSettings;
        private System.Windows.Forms.Button btnPPEStandard;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnAnalysis;
        private System.Windows.Forms.Button btnDetectionLog;
        private System.Windows.Forms.Button btnControl;
        private System.Windows.Forms.Label lblPPESystem;
        private System.Windows.Forms.Button btnViolationManagement;
        private System.Windows.Forms.Button btnAlerts;
        private System.Windows.Forms.Button btnMonitoring;
    }
}