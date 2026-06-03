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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlBar = new System.Windows.Forms.Panel();
            this.lblBar = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnAnalysis = new System.Windows.Forms.Button();
            this.btnDetectionLog = new System.Windows.Forms.Button();
            this.lblPPESystem = new System.Windows.Forms.Label();
            this.btnViolationManagement = new System.Windows.Forms.Button();
            this.btnAlerts = new System.Windows.Forms.Button();
            this.btnLiveMonitoring = new System.Windows.Forms.Button();
            this.pnlMenuDivider = new System.Windows.Forms.Panel();
            this.btnControl = new System.Windows.Forms.Button();
            this.lblMenuName = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.Controls.Add(this.pnlBar);
            this.pnlMenu.Controls.Add(this.lblBar);
            this.pnlMenu.Controls.Add(this.btnSettings);
            this.pnlMenu.Controls.Add(this.btnAnalysis);
            this.pnlMenu.Controls.Add(this.btnDetectionLog);
            this.pnlMenu.Controls.Add(this.lblPPESystem);
            this.pnlMenu.Controls.Add(this.btnViolationManagement);
            this.pnlMenu.Controls.Add(this.btnAlerts);
            this.pnlMenu.Controls.Add(this.btnLiveMonitoring);
            this.pnlMenu.Controls.Add(this.pnlMenuDivider);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(236, 682);
            this.pnlMenu.TabIndex = 9;
            // 
            // pnlBar
            // 
            this.pnlBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.pnlBar.Location = new System.Drawing.Point(0, 102);
            this.pnlBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlBar.Name = "pnlBar";
            this.pnlBar.Size = new System.Drawing.Size(4, 41);
            this.pnlBar.TabIndex = 10;
            // 
            // lblBar
            // 
            this.lblBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblBar.Location = new System.Drawing.Point(39, 68);
            this.lblBar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBar.Name = "lblBar";
            this.lblBar.Size = new System.Drawing.Size(158, 1);
            this.lblBar.TabIndex = 9;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.White;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnSettings.Location = new System.Drawing.Point(19, 322);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(2);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(198, 41);
            this.btnSettings.TabIndex = 5;
            this.btnSettings.Text = "설정";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click_1);
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.BackColor = System.Drawing.Color.White;
            this.btnAnalysis.FlatAppearance.BorderSize = 0;
            this.btnAnalysis.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.btnAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalysis.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAnalysis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnAnalysis.Location = new System.Drawing.Point(20, 278);
            this.btnAnalysis.Margin = new System.Windows.Forms.Padding(2);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(198, 41);
            this.btnAnalysis.TabIndex = 4;
            this.btnAnalysis.Text = "분석";
            this.btnAnalysis.UseVisualStyleBackColor = false;
            this.btnAnalysis.Click += new System.EventHandler(this.btnAnalysis_Click);
            // 
            // btnDetectionLog
            // 
            this.btnDetectionLog.BackColor = System.Drawing.Color.White;
            this.btnDetectionLog.FlatAppearance.BorderSize = 0;
            this.btnDetectionLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.btnDetectionLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetectionLog.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDetectionLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnDetectionLog.Location = new System.Drawing.Point(19, 234);
            this.btnDetectionLog.Margin = new System.Windows.Forms.Padding(2);
            this.btnDetectionLog.Name = "btnDetectionLog";
            this.btnDetectionLog.Size = new System.Drawing.Size(198, 41);
            this.btnDetectionLog.TabIndex = 3;
            this.btnDetectionLog.Text = "이력 / 로그";
            this.btnDetectionLog.UseVisualStyleBackColor = false;
            this.btnDetectionLog.Click += new System.EventHandler(this.btnDetectionLog_Click_1);
            // 
            // lblPPESystem
            // 
            this.lblPPESystem.AutoSize = true;
            this.lblPPESystem.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPPESystem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.lblPPESystem.Location = new System.Drawing.Point(39, 30);
            this.lblPPESystem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPPESystem.Name = "lblPPESystem";
            this.lblPPESystem.Size = new System.Drawing.Size(148, 25);
            this.lblPPESystem.TabIndex = 2;
            this.lblPPESystem.Text = "PPE 관제시스템";
            // 
            // btnViolationManagement
            // 
            this.btnViolationManagement.BackColor = System.Drawing.Color.White;
            this.btnViolationManagement.FlatAppearance.BorderSize = 0;
            this.btnViolationManagement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.btnViolationManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViolationManagement.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViolationManagement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnViolationManagement.Location = new System.Drawing.Point(20, 190);
            this.btnViolationManagement.Margin = new System.Windows.Forms.Padding(2);
            this.btnViolationManagement.Name = "btnViolationManagement";
            this.btnViolationManagement.Size = new System.Drawing.Size(198, 41);
            this.btnViolationManagement.TabIndex = 2;
            this.btnViolationManagement.Text = "위반관리";
            this.btnViolationManagement.UseVisualStyleBackColor = false;
            this.btnViolationManagement.Click += new System.EventHandler(this.btnViolationManagement_Click);
            // 
            // btnAlerts
            // 
            this.btnAlerts.BackColor = System.Drawing.Color.White;
            this.btnAlerts.FlatAppearance.BorderSize = 0;
            this.btnAlerts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.btnAlerts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlerts.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAlerts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnAlerts.Location = new System.Drawing.Point(20, 146);
            this.btnAlerts.Margin = new System.Windows.Forms.Padding(2);
            this.btnAlerts.Name = "btnAlerts";
            this.btnAlerts.Size = new System.Drawing.Size(198, 41);
            this.btnAlerts.TabIndex = 1;
            this.btnAlerts.Text = "알림";
            this.btnAlerts.UseVisualStyleBackColor = false;
            this.btnAlerts.Click += new System.EventHandler(this.btnAlerts_Click);
            // 
            // btnLiveMonitoring
            // 
            this.btnLiveMonitoring.BackColor = System.Drawing.Color.White;
            this.btnLiveMonitoring.FlatAppearance.BorderSize = 0;
            this.btnLiveMonitoring.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.btnLiveMonitoring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLiveMonitoring.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLiveMonitoring.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnLiveMonitoring.Location = new System.Drawing.Point(19, 102);
            this.btnLiveMonitoring.Margin = new System.Windows.Forms.Padding(2);
            this.btnLiveMonitoring.Name = "btnLiveMonitoring";
            this.btnLiveMonitoring.Size = new System.Drawing.Size(198, 41);
            this.btnLiveMonitoring.TabIndex = 0;
            this.btnLiveMonitoring.Text = "실시간 모니터링";
            this.btnLiveMonitoring.UseVisualStyleBackColor = false;
            this.btnLiveMonitoring.Click += new System.EventHandler(this.btnLiveMonitoring_Click);
            // 
            // pnlMenuDivider
            // 
            this.pnlMenuDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlMenuDivider.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMenuDivider.Location = new System.Drawing.Point(235, 0);
            this.pnlMenuDivider.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMenuDivider.Name = "pnlMenuDivider";
            this.pnlMenuDivider.Size = new System.Drawing.Size(1, 682);
            this.pnlMenuDivider.TabIndex = 12;
            // 
            // btnControl
            // 
            this.btnControl.BackColor = System.Drawing.Color.White;
            this.btnControl.FlatAppearance.BorderSize = 0;
            this.btnControl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.btnControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnControl.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnControl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnControl.Location = new System.Drawing.Point(22, 293);
            this.btnControl.Margin = new System.Windows.Forms.Padding(2);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(226, 51);
            this.btnControl.TabIndex = 99;
            this.btnControl.Text = "대응 / 제어";
            this.btnControl.UseVisualStyleBackColor = false;
            this.btnControl.Visible = false;
            this.btnControl.Click += new System.EventHandler(this.btnControl_Click_1);
            // 
            // lblMenuName
            // 
            this.lblMenuName.AutoSize = true;
            this.lblMenuName.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMenuName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblMenuName.Location = new System.Drawing.Point(250, 27);
            this.lblMenuName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMenuName.Name = "lblMenuName";
            this.lblMenuName.Size = new System.Drawing.Size(175, 30);
            this.lblMenuName.TabIndex = 10;
            this.lblMenuName.Text = "실시간 모니터링";
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Location = new System.Drawing.Point(256, 63);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(13, 4, 22, 12);
            this.pnlMain.Size = new System.Drawing.Size(1074, 610);
            this.pnlMain.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1384, 682);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.lblMenuName);
            this.Controls.Add(this.pnlMenu);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(790, 488);
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