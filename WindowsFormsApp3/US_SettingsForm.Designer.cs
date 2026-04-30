namespace PPE_관제_시스템
{
    partial class US_SettingsForm
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMenuShow = new System.Windows.Forms.Panel();
            this.pnlSettingsMenu = new System.Windows.Forms.Panel();
            this.btnZoneSettings = new System.Windows.Forms.Button();
            this.btnUserSettings = new System.Windows.Forms.Button();
            this.btnAlertSettings = new System.Windows.Forms.Button();
            this.btnPPEStandard = new System.Windows.Forms.Button();
            this.pnlBar = new System.Windows.Forms.Panel();
            this.pnlSettingsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenuShow
            // 
            this.pnlMenuShow.Location = new System.Drawing.Point(6, 106);
            this.pnlMenuShow.Name = "pnlMenuShow";
            this.pnlMenuShow.Size = new System.Drawing.Size(1219, 653);
            this.pnlMenuShow.TabIndex = 6;
            // 
            // pnlSettingsMenu
            // 
            this.pnlSettingsMenu.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlSettingsMenu.Controls.Add(this.pnlBar);
            this.pnlSettingsMenu.Controls.Add(this.btnZoneSettings);
            this.pnlSettingsMenu.Controls.Add(this.btnUserSettings);
            this.pnlSettingsMenu.Controls.Add(this.btnAlertSettings);
            this.pnlSettingsMenu.Controls.Add(this.btnPPEStandard);
            this.pnlSettingsMenu.Location = new System.Drawing.Point(3, 3);
            this.pnlSettingsMenu.Name = "pnlSettingsMenu";
            this.pnlSettingsMenu.Size = new System.Drawing.Size(645, 70);
            this.pnlSettingsMenu.TabIndex = 5;
            // 
            // btnZoneSettings
            // 
            this.btnZoneSettings.FlatAppearance.BorderSize = 0;
            this.btnZoneSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoneSettings.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            this.btnUserSettings.FlatAppearance.BorderSize = 0;
            this.btnUserSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserSettings.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            this.btnAlertSettings.FlatAppearance.BorderSize = 0;
            this.btnAlertSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlertSettings.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAlertSettings.ForeColor = System.Drawing.SystemColors.ControlText;
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
            this.btnPPEStandard.FlatAppearance.BorderSize = 0;
            this.btnPPEStandard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPPEStandard.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPPEStandard.Location = new System.Drawing.Point(3, 3);
            this.btnPPEStandard.Name = "btnPPEStandard";
            this.btnPPEStandard.Size = new System.Drawing.Size(154, 64);
            this.btnPPEStandard.TabIndex = 0;
            this.btnPPEStandard.Text = "PPE 기준";
            this.btnPPEStandard.UseVisualStyleBackColor = true;
            this.btnPPEStandard.Click += new System.EventHandler(this.btnPPEStandard_Click);
            // 
            // pnlBar
            // 
            this.pnlBar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlBar.Location = new System.Drawing.Point(39, 50);
            this.pnlBar.Name = "pnlBar";
            this.pnlBar.Size = new System.Drawing.Size(79, 5);
            this.pnlBar.TabIndex = 11;
            // 
            // US_SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMenuShow);
            this.Controls.Add(this.pnlSettingsMenu);
            this.Name = "US_SettingsForm";
            this.Size = new System.Drawing.Size(1228, 762);
            this.Load += new System.EventHandler(this.US_SettingsForm_Load);
            this.pnlSettingsMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenuShow;
        private System.Windows.Forms.Panel pnlSettingsMenu;
        private System.Windows.Forms.Button btnZoneSettings;
        private System.Windows.Forms.Button btnUserSettings;
        private System.Windows.Forms.Button btnAlertSettings;
        private System.Windows.Forms.Button btnPPEStandard;
        private System.Windows.Forms.Panel pnlBar;
    }
}
