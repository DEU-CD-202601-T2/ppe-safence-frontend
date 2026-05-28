namespace PPE_관제_시스템
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        private void InitializeComponent()
        {
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlMenuDivider = new System.Windows.Forms.Panel();
            this.pnlBar = new System.Windows.Forms.Panel();
            this.lblBar = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnAnalysis = new System.Windows.Forms.Button();
            this.btnDetectionLog = new System.Windows.Forms.Button();
            this.btnControl = new System.Windows.Forms.Button();
            this.lblPPESystem = new System.Windows.Forms.Label();
            this.btnViolationManagement = new System.Windows.Forms.Button();
            this.btnAlerts = new System.Windows.Forms.Button();
            this.btnLiveMonitoring = new System.Windows.Forms.Button();
            this.lblMenuName = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = AppColors.Surface;
            this.pnlMenu.Controls.Add(this.pnlBar);
            this.pnlMenu.Controls.Add(this.lblBar);
            this.pnlMenu.Controls.Add(this.btnSettings);
            this.pnlMenu.Controls.Add(this.btnAnalysis);
            this.pnlMenu.Controls.Add(this.btnDetectionLog);
            this.pnlMenu.Controls.Add(this.btnControl);
            this.pnlMenu.Controls.Add(this.lblPPESystem);
            this.pnlMenu.Controls.Add(this.btnViolationManagement);
            this.pnlMenu.Controls.Add(this.btnAlerts);
            this.pnlMenu.Controls.Add(this.btnLiveMonitoring);
            this.pnlMenu.Controls.Add(this.pnlMenuDivider);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(270, 853);
            this.pnlMenu.TabIndex = 9;
            // 
            // pnlMenuDivider
            // 
            this.pnlMenuDivider.BackColor = AppColors.Border;
            this.pnlMenuDivider.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMenuDivider.Location = new System.Drawing.Point(269, 0);
            this.pnlMenuDivider.Name = "pnlMenuDivider";
            this.pnlMenuDivider.Size = new System.Drawing.Size(1, 853);
            this.pnlMenuDivider.TabIndex = 12;
            // 
            // pnlBar
            // 
            this.pnlBar.BackColor = AppColors.Primary;
            this.pnlBar.Location = new System.Drawing.Point(0, 128);
            this.pnlBar.Name = "pnlBar";
            this.pnlBar.Size = new System.Drawing.Size(4, 51);
            this.pnlBar.TabIndex = 10;
            // 
            // lblBar
            // 
            this.lblBar.BackColor = AppColors.Border;
            this.lblBar.Location = new System.Drawing.Point(45, 85);
            this.lblBar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBar.Name = "lblBar";
            this.lblBar.Size = new System.Drawing.Size(180, 1);
            this.lblBar.TabIndex = 9;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = AppColors.Surface;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseOverBackColor = AppColors.SurfaceAlt;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSettings.ForeColor = AppColors.Text;
            this.btnSettings.Location = new System.Drawing.Point(22, 458);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(2);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(226, 51);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "설정";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click_1);
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.BackColor = AppColors.Surface;
            this.btnAnalysis.FlatAppearance.BorderSize = 0;
            this.btnAnalysis.FlatAppearance.MouseOverBackColor = AppColors.SurfaceAlt;
            this.btnAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalysis.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAnalysis.ForeColor = AppColors.Text;
            this.btnAnalysis.Location = new System.Drawing.Point(23, 403);
            this.btnAnalysis.Margin = new System.Windows.Forms.Padding(2);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(226, 51);
            this.btnAnalysis.TabIndex = 5;
            this.btnAnalysis.Text = "분석";
            this.btnAnalysis.UseVisualStyleBackColor = false;
            this.btnAnalysis.Click += new System.EventHandler(this.btnAnalysis_Click);
            // 
            // btnDetectionLog
            // 
            this.btnDetectionLog.BackColor = AppColors.Surface;
            this.btnDetectionLog.FlatAppearance.BorderSize = 0;
            this.btnDetectionLog.FlatAppearance.MouseOverBackColor = AppColors.SurfaceAlt;
            this.btnDetectionLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetectionLog.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDetectionLog.ForeColor = AppColors.Text;
            this.btnDetectionLog.Location = new System.Drawing.Point(22, 348);
            this.btnDetectionLog.Margin = new System.Windows.Forms.Padding(2);
            this.btnDetectionLog.Name = "btnDetectionLog";
            this.btnDetectionLog.Size = new System.Drawing.Size(226, 51);
            this.btnDetectionLog.TabIndex = 4;
            this.btnDetectionLog.Text = "이력 / 로그";
            this.btnDetectionLog.UseVisualStyleBackColor = false;
            this.btnDetectionLog.Click += new System.EventHandler(this.btnDetectionLog_Click_1);
            // 
            // btnControl
            // 
            this.btnControl.BackColor = AppColors.Surface;
            this.btnControl.FlatAppearance.BorderSize = 0;
            this.btnControl.FlatAppearance.MouseOverBackColor = AppColors.SurfaceAlt;
            this.btnControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnControl.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnControl.ForeColor = AppColors.Text;
            this.btnControl.Location = new System.Drawing.Point(22, 293);
            this.btnControl.Margin = new System.Windows.Forms.Padding(2);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(226, 51);
            this.btnControl.TabIndex = 3;
            this.btnControl.Text = "대응 / 제어";
            this.btnControl.UseVisualStyleBackColor = false;
            this.btnControl.Click += new System.EventHandler(this.btnControl_Click_1);
            // 
            // lblPPESystem
            // 
            this.lblPPESystem.AutoSize = true;
            this.lblPPESystem.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPPESystem.ForeColor = AppColors.PrimaryDark;
            this.lblPPESystem.Location = new System.Drawing.Point(45, 37);
            this.lblPPESystem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPPESystem.Name = "lblPPESystem";
            this.lblPPESystem.Size = new System.Drawing.Size(177, 31);
            this.lblPPESystem.TabIndex = 2;
            this.lblPPESystem.Text = "PPE 관제시스템";
            // 
            // btnViolationManagement
            // 
            this.btnViolationManagement.BackColor = AppColors.Surface;
            this.btnViolationManagement.FlatAppearance.BorderSize = 0;
            this.btnViolationManagement.FlatAppearance.MouseOverBackColor = AppColors.SurfaceAlt;
            this.btnViolationManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViolationManagement.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViolationManagement.ForeColor = AppColors.Text;
            this.btnViolationManagement.Location = new System.Drawing.Point(23, 238);
            this.btnViolationManagement.Margin = new System.Windows.Forms.Padding(2);
            this.btnViolationManagement.Name = "btnViolationManagement";
            this.btnViolationManagement.Size = new System.Drawing.Size(226, 51);
            this.btnViolationManagement.TabIndex = 2;
            this.btnViolationManagement.Text = "위반관리";
            this.btnViolationManagement.UseVisualStyleBackColor = false;
            this.btnViolationManagement.Click += new System.EventHandler(this.btnViolationManagement_Click);
            // 
            // btnAlerts
            // 
            this.btnAlerts.BackColor = AppColors.Surface;
            this.btnAlerts.FlatAppearance.BorderSize = 0;
            this.btnAlerts.FlatAppearance.MouseOverBackColor = AppColors.SurfaceAlt;
            this.btnAlerts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlerts.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAlerts.ForeColor = AppColors.Text;
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
            this.btnLiveMonitoring.BackColor = AppColors.Surface;
            this.btnLiveMonitoring.FlatAppearance.BorderSize = 0;
            this.btnLiveMonitoring.FlatAppearance.MouseOverBackColor = AppColors.SurfaceAlt;
            this.btnLiveMonitoring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLiveMonitoring.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLiveMonitoring.ForeColor = AppColors.Text;
            this.btnLiveMonitoring.Location = new System.Drawing.Point(22, 128);
            this.btnLiveMonitoring.Margin = new System.Windows.Forms.Padding(2);
            this.btnLiveMonitoring.Name = "btnLiveMonitoring";
            this.btnLiveMonitoring.Size = new System.Drawing.Size(226, 51);
            this.btnLiveMonitoring.TabIndex = 0;
            this.btnLiveMonitoring.Text = "실시간 모니터링";
            this.btnLiveMonitoring.UseVisualStyleBackColor = false;
            this.btnLiveMonitoring.Click += new System.EventHandler(this.btnLiveMonitoring_Click);
            // 
            // lblMenuName
            // 
            this.lblMenuName.AutoSize = true;
            this.lblMenuName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMenuName.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMenuName.ForeColor = AppColors.Text;
            this.lblMenuName.Location = new System.Drawing.Point(286, 34);
            this.lblMenuName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMenuName.Name = "lblMenuName";
            this.lblMenuName.Size = new System.Drawing.Size(223, 38);
            this.lblMenuName.TabIndex = 10;
            this.lblMenuName.Text = "실시간 모니터링";
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.BackColor = AppColors.Background;
            this.pnlMain.Location = new System.Drawing.Point(293, 79);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(15, 5, 25, 15);
            this.pnlMain.Size = new System.Drawing.Size(1228, 762);
            this.pnlMain.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = AppColors.Background;
            this.ClientSize = new System.Drawing.Size(1582, 853);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.lblMenuName);
            this.Controls.Add(this.pnlMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "MainForm";
            this.Text = "PPE 관제 시스템";
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlMenuDivider;
        private System.Windows.Forms.Label lblBar;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnAnalysis;
        private System.Windows.Forms.Button btnDetectionLog;
        private System.Windows.Forms.Button btnControl;
        private System.Windows.Forms.Label lblPPESystem;
        private System.Windows.Forms.Button btnViolationManagement;
        private System.Windows.Forms.Button btnAlerts;
        private System.Windows.Forms.Button btnLiveMonitoring;
        private System.Windows.Forms.Label lblMenuName;
        private System.Windows.Forms.Panel pnlBar;
        private System.Windows.Forms.Panel pnlMain;
    }
}