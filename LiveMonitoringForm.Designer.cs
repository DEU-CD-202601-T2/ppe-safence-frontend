namespace PPE_관제_시스템
{
    partial class LiveMonitoringForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlNoPPE = new System.Windows.Forms.Panel();
            this.lblNoPPECount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNoPPE = new System.Windows.Forms.Label();
            this.pnlCompliance = new System.Windows.Forms.Panel();
            this.lblComplianceRate = new System.Windows.Forms.Label();
            this.lblCompliance = new System.Windows.Forms.Label();
            this.pnlCamera = new System.Windows.Forms.Panel();
            this.lblCameraStatus = new System.Windows.Forms.Label();
            this.lblCamera = new System.Windows.Forms.Label();
            this.pnlWarning = new System.Windows.Forms.Panel();
            this.lblWarningCount = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.picZoneView = new System.Windows.Forms.PictureBox();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBar = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnAnalysis = new System.Windows.Forms.Button();
            this.btnDetectionLog = new System.Windows.Forms.Button();
            this.btnControl = new System.Windows.Forms.Button();
            this.lblPPESystem = new System.Windows.Forms.Label();
            this.btnViolationManagement = new System.Windows.Forms.Button();
            this.btnAlerts = new System.Windows.Forms.Button();
            this.btnLiveMonitoring = new System.Windows.Forms.Button();
            this.lblLiveMonitoring = new System.Windows.Forms.Label();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.pnlNoPPE.SuspendLayout();
            this.pnlCompliance.SuspendLayout();
            this.pnlCamera.SuspendLayout();
            this.pnlWarning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picZoneView)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNoPPE
            // 
            this.pnlNoPPE.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlNoPPE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlNoPPE.Controls.Add(this.lblNoPPECount);
            this.pnlNoPPE.Controls.Add(this.label6);
            this.pnlNoPPE.Controls.Add(this.lblNoPPE);
            this.pnlNoPPE.Location = new System.Drawing.Point(292, 96);
            this.pnlNoPPE.Margin = new System.Windows.Forms.Padding(2);
            this.pnlNoPPE.Name = "pnlNoPPE";
            this.pnlNoPPE.Size = new System.Drawing.Size(300, 150);
            this.pnlNoPPE.TabIndex = 1;
            // 
            // lblNoPPECount
            // 
            this.lblNoPPECount.AutoSize = true;
            this.lblNoPPECount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNoPPECount.Font = new System.Drawing.Font("굴림", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNoPPECount.Location = new System.Drawing.Point(240, 93);
            this.lblNoPPECount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNoPPECount.Name = "lblNoPPECount";
            this.lblNoPPECount.Size = new System.Drawing.Size(34, 33);
            this.lblNoPPECount.TabIndex = 8;
            this.lblNoPPECount.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 36);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 15);
            this.label6.TabIndex = 7;
            // 
            // lblNoPPE
            // 
            this.lblNoPPE.AutoSize = true;
            this.lblNoPPE.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNoPPE.Location = new System.Drawing.Point(5, 8);
            this.lblNoPPE.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNoPPE.Name = "lblNoPPE";
            this.lblNoPPE.Size = new System.Drawing.Size(72, 28);
            this.lblNoPPE.TabIndex = 3;
            this.lblNoPPE.Text = "미착용";
            // 
            // pnlCompliance
            // 
            this.pnlCompliance.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlCompliance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlCompliance.Controls.Add(this.lblComplianceRate);
            this.pnlCompliance.Controls.Add(this.lblCompliance);
            this.pnlCompliance.Location = new System.Drawing.Point(911, 96);
            this.pnlCompliance.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCompliance.Name = "pnlCompliance";
            this.pnlCompliance.Size = new System.Drawing.Size(300, 150);
            this.pnlCompliance.TabIndex = 0;
            // 
            // lblComplianceRate
            // 
            this.lblComplianceRate.AutoSize = true;
            this.lblComplianceRate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblComplianceRate.Font = new System.Drawing.Font("맑은 고딕", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblComplianceRate.Location = new System.Drawing.Point(221, 87);
            this.lblComplianceRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComplianceRate.Name = "lblComplianceRate";
            this.lblComplianceRate.Size = new System.Drawing.Size(66, 45);
            this.lblComplianceRate.TabIndex = 10;
            this.lblComplianceRate.Text = "0%";
            // 
            // lblCompliance
            // 
            this.lblCompliance.AutoSize = true;
            this.lblCompliance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCompliance.Location = new System.Drawing.Point(5, 8);
            this.lblCompliance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCompliance.Name = "lblCompliance";
            this.lblCompliance.Size = new System.Drawing.Size(72, 28);
            this.lblCompliance.TabIndex = 5;
            this.lblCompliance.Text = "준수율";
            // 
            // pnlCamera
            // 
            this.pnlCamera.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlCamera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlCamera.Controls.Add(this.lblCameraStatus);
            this.pnlCamera.Controls.Add(this.lblCamera);
            this.pnlCamera.Location = new System.Drawing.Point(1221, 96);
            this.pnlCamera.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCamera.Name = "pnlCamera";
            this.pnlCamera.Size = new System.Drawing.Size(300, 150);
            this.pnlCamera.TabIndex = 0;
            // 
            // lblCameraStatus
            // 
            this.lblCameraStatus.AutoSize = true;
            this.lblCameraStatus.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCameraStatus.Font = new System.Drawing.Font("굴림", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCameraStatus.Location = new System.Drawing.Point(204, 99);
            this.lblCameraStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCameraStatus.Name = "lblCameraStatus";
            this.lblCameraStatus.Size = new System.Drawing.Size(81, 33);
            this.lblCameraStatus.TabIndex = 11;
            this.lblCameraStatus.Text = "정상";
            // 
            // lblCamera
            // 
            this.lblCamera.AutoSize = true;
            this.lblCamera.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCamera.Location = new System.Drawing.Point(5, 8);
            this.lblCamera.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCamera.Name = "lblCamera";
            this.lblCamera.Size = new System.Drawing.Size(111, 28);
            this.lblCamera.TabIndex = 6;
            this.lblCamera.Text = "카메라 7대";
            // 
            // pnlWarning
            // 
            this.pnlWarning.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlWarning.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlWarning.Controls.Add(this.lblWarningCount);
            this.pnlWarning.Controls.Add(this.lblWarning);
            this.pnlWarning.Location = new System.Drawing.Point(601, 96);
            this.pnlWarning.Margin = new System.Windows.Forms.Padding(2);
            this.pnlWarning.Name = "pnlWarning";
            this.pnlWarning.Size = new System.Drawing.Size(300, 150);
            this.pnlWarning.TabIndex = 1;
            // 
            // lblWarningCount
            // 
            this.lblWarningCount.AutoSize = true;
            this.lblWarningCount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblWarningCount.Font = new System.Drawing.Font("굴림", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWarningCount.Location = new System.Drawing.Point(249, 93);
            this.lblWarningCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWarningCount.Name = "lblWarningCount";
            this.lblWarningCount.Size = new System.Drawing.Size(34, 33);
            this.lblWarningCount.TabIndex = 9;
            this.lblWarningCount.Text = "0";
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWarning.Location = new System.Drawing.Point(5, 8);
            this.lblWarning.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(52, 28);
            this.lblWarning.TabIndex = 4;
            this.lblWarning.Text = "경고";
            // 
            // picZoneView
            // 
            this.picZoneView.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.picZoneView.Location = new System.Drawing.Point(293, 322);
            this.picZoneView.Margin = new System.Windows.Forms.Padding(2);
            this.picZoneView.Name = "picZoneView";
            this.picZoneView.Size = new System.Drawing.Size(1228, 520);
            this.picZoneView.TabIndex = 3;
            this.picZoneView.TabStop = false;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlMenu.Controls.Add(this.panel1);
            this.pnlMenu.Controls.Add(this.lblBar);
            this.pnlMenu.Controls.Add(this.btnSettings);
            this.pnlMenu.Controls.Add(this.btnAnalysis);
            this.pnlMenu.Controls.Add(this.btnDetectionLog);
            this.pnlMenu.Controls.Add(this.btnControl);
            this.pnlMenu.Controls.Add(this.lblPPESystem);
            this.pnlMenu.Controls.Add(this.btnViolationManagement);
            this.pnlMenu.Controls.Add(this.btnAlerts);
            this.pnlMenu.Controls.Add(this.btnLiveMonitoring);
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(270, 853);
            this.pnlMenu.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Location = new System.Drawing.Point(23, 128);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 51);
            this.panel1.TabIndex = 10;
            // 
            // lblBar
            // 
            this.lblBar.BackColor = System.Drawing.Color.DimGray;
            this.lblBar.Location = new System.Drawing.Point(50, 78);
            this.lblBar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBar.Name = "lblBar";
            this.lblBar.Size = new System.Drawing.Size(160, 2);
            this.lblBar.TabIndex = 9;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSettings.Location = new System.Drawing.Point(22, 458);
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
            this.btnAnalysis.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAnalysis.Location = new System.Drawing.Point(23, 403);
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
            this.btnDetectionLog.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDetectionLog.Location = new System.Drawing.Point(22, 348);
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
            this.btnControl.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnControl.Location = new System.Drawing.Point(22, 293);
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
            this.lblPPESystem.Location = new System.Drawing.Point(45, 37);
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
            this.btnViolationManagement.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViolationManagement.Location = new System.Drawing.Point(23, 238);
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
            this.btnAlerts.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAlerts.Location = new System.Drawing.Point(23, 183);
            this.btnAlerts.Margin = new System.Windows.Forms.Padding(2);
            this.btnAlerts.Name = "btnAlerts";
            this.btnAlerts.Size = new System.Drawing.Size(226, 51);
            this.btnAlerts.TabIndex = 1;
            this.btnAlerts.Text = "알림";
            this.btnAlerts.UseVisualStyleBackColor = false;
            this.btnAlerts.Click += new System.EventHandler(this.btnAlerts_Click);
            // 
            // btnLiveMonitoring
            // 
            this.btnLiveMonitoring.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnLiveMonitoring.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnLiveMonitoring.FlatAppearance.BorderSize = 0;
            this.btnLiveMonitoring.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnLiveMonitoring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLiveMonitoring.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLiveMonitoring.Location = new System.Drawing.Point(22, 128);
            this.btnLiveMonitoring.Margin = new System.Windows.Forms.Padding(2);
            this.btnLiveMonitoring.Name = "btnLiveMonitoring";
            this.btnLiveMonitoring.Size = new System.Drawing.Size(226, 51);
            this.btnLiveMonitoring.TabIndex = 0;
            this.btnLiveMonitoring.Text = "실시간 모니터링";
            this.btnLiveMonitoring.UseVisualStyleBackColor = false;
            // 
            // lblLiveMonitoring
            // 
            this.lblLiveMonitoring.AutoSize = true;
            this.lblLiveMonitoring.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLiveMonitoring.Location = new System.Drawing.Point(286, 34);
            this.lblLiveMonitoring.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLiveMonitoring.Name = "lblLiveMonitoring";
            this.lblLiveMonitoring.Size = new System.Drawing.Size(223, 38);
            this.lblLiveMonitoring.TabIndex = 10;
            this.lblLiveMonitoring.Text = "실시간 모니터링";
            // 
            // cmbZone
            // 
            this.cmbZone.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbZone.FormattingEnabled = true;
            this.cmbZone.Items.AddRange(new object[] {
            "B구역",
            "C구역"});
            this.cmbZone.Location = new System.Drawing.Point(1400, 286);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(121, 31);
            this.cmbZone.TabIndex = 16;
            this.cmbZone.Text = "A구역";
            // 
            // LiveMonitoringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 853);
            this.Controls.Add(this.cmbZone);
            this.Controls.Add(this.lblLiveMonitoring);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.picZoneView);
            this.Controls.Add(this.pnlCamera);
            this.Controls.Add(this.pnlCompliance);
            this.Controls.Add(this.pnlWarning);
            this.Controls.Add(this.pnlNoPPE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LiveMonitoringForm";
            this.Text = "실시간 모니터링";
            this.pnlNoPPE.ResumeLayout(false);
            this.pnlNoPPE.PerformLayout();
            this.pnlCompliance.ResumeLayout(false);
            this.pnlCompliance.PerformLayout();
            this.pnlCamera.ResumeLayout(false);
            this.pnlCamera.PerformLayout();
            this.pnlWarning.ResumeLayout(false);
            this.pnlWarning.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picZoneView)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlNoPPE;
        private System.Windows.Forms.Panel pnlCompliance;
        private System.Windows.Forms.Panel pnlCamera;
        private System.Windows.Forms.Panel pnlWarning;
        private System.Windows.Forms.Label lblNoPPE;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Label lblCompliance;
        private System.Windows.Forms.Label lblCamera;
        private System.Windows.Forms.Label lblNoPPECount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblComplianceRate;
        private System.Windows.Forms.Label lblCameraStatus;
        private System.Windows.Forms.Label lblWarningCount;
        private System.Windows.Forms.PictureBox picZoneView;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblBar;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnAnalysis;
        private System.Windows.Forms.Button btnDetectionLog;
        private System.Windows.Forms.Button btnControl;
        private System.Windows.Forms.Label lblPPESystem;
        private System.Windows.Forms.Button btnViolationManagement;
        private System.Windows.Forms.Button btnAlerts;
        private System.Windows.Forms.Button btnLiveMonitoring;
        private System.Windows.Forms.Label lblLiveMonitoring;
        private System.Windows.Forms.ComboBox cmbZone;
        private System.Windows.Forms.Panel panel1;
    }
}

