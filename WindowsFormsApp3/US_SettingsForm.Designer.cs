namespace PPE_관제_시스템
{
    partial class US_SettingsForm
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

        #region 구성 요소 디자이너에서 생성한 코드

        private void InitializeComponent()
        {
            this.pnlMenuShow = new System.Windows.Forms.Panel();
            this.pnlSettingsMenu = new System.Windows.Forms.Panel();
            this.pnlSettingsMenuDivider = new System.Windows.Forms.Panel();
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
            this.pnlMenuShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMenuShow.BackColor = AppColors.Background;
            this.pnlMenuShow.Location = new System.Drawing.Point(6, 90);
            this.pnlMenuShow.Name = "pnlMenuShow";
            this.pnlMenuShow.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.pnlMenuShow.Size = new System.Drawing.Size(1219, 669);
            this.pnlMenuShow.TabIndex = 6;
            // 
            // pnlSettingsMenu
            // 
            this.pnlSettingsMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSettingsMenu.BackColor = AppColors.Surface;
            this.pnlSettingsMenu.Controls.Add(this.pnlBar);
            this.pnlSettingsMenu.Controls.Add(this.pnlSettingsMenuDivider);
            this.pnlSettingsMenu.Controls.Add(this.btnZoneSettings);
            this.pnlSettingsMenu.Controls.Add(this.btnUserSettings);
            this.pnlSettingsMenu.Controls.Add(this.btnAlertSettings);
            this.pnlSettingsMenu.Controls.Add(this.btnPPEStandard);
            this.pnlSettingsMenu.Location = new System.Drawing.Point(3, 3);
            this.pnlSettingsMenu.Name = "pnlSettingsMenu";
            this.pnlSettingsMenu.Size = new System.Drawing.Size(1222, 80);
            this.pnlSettingsMenu.TabIndex = 5;
            // 
            // pnlSettingsMenuDivider
            // 
            this.pnlSettingsMenuDivider.BackColor = AppColors.Border;
            this.pnlSettingsMenuDivider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSettingsMenuDivider.Location = new System.Drawing.Point(0, 79);
            this.pnlSettingsMenuDivider.Name = "pnlSettingsMenuDivider";
            this.pnlSettingsMenuDivider.Size = new System.Drawing.Size(1222, 1);
            this.pnlSettingsMenuDivider.TabIndex = 12;
            // 
            // btnPPEStandard
            // 
            this.btnPPEStandard.BackColor = AppColors.Surface;
            this.btnPPEStandard.FlatAppearance.BorderSize = 0;
            this.btnPPEStandard.FlatAppearance.MouseOverBackColor = AppColors.SurfaceAlt;
            this.btnPPEStandard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPPEStandard.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPPEStandard.ForeColor = AppColors.PrimaryDark;
            this.btnPPEStandard.Location = new System.Drawing.Point(3, 3);
            this.btnPPEStandard.Name = "btnPPEStandard";
            this.btnPPEStandard.Size = new System.Drawing.Size(160, 70);
            this.btnPPEStandard.TabIndex = 0;
            this.btnPPEStandard.Text = "PPE 기준";
            this.btnPPEStandard.UseVisualStyleBackColor = false;
            this.btnPPEStandard.Click += new System.EventHandler(this.btnPPEStandard_Click);
            // 
            // btnAlertSettings
            // 
            this.btnAlertSettings.BackColor = AppColors.Surface;
            this.btnAlertSettings.FlatAppearance.BorderSize = 0;
            this.btnAlertSettings.FlatAppearance.MouseOverBackColor = AppColors.SurfaceAlt;
            this.btnAlertSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlertSettings.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAlertSettings.ForeColor = AppColors.Text;
            this.btnAlertSettings.Location = new System.Drawing.Point(169, 3);
            this.btnAlertSettings.Name = "btnAlertSettings";
            this.btnAlertSettings.Size = new System.Drawing.Size(160, 70);
            this.btnAlertSettings.TabIndex = 1;
            this.btnAlertSettings.Text = "알림 설정";
            this.btnAlertSettings.UseVisualStyleBackColor = false;
            this.btnAlertSettings.Click += new System.EventHandler(this.btnAlertSettings_Click);
            // 
            // btnUserSettings
            // 
            this.btnUserSettings.BackColor = AppColors.Surface;
            this.btnUserSettings.FlatAppearance.BorderSize = 0;
            this.btnUserSettings.FlatAppearance.MouseOverBackColor = AppColors.SurfaceAlt;
            this.btnUserSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserSettings.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUserSettings.ForeColor = AppColors.Text;
            this.btnUserSettings.Location = new System.Drawing.Point(335, 3);
            this.btnUserSettings.Name = "btnUserSettings";
            this.btnUserSettings.Size = new System.Drawing.Size(160, 70);
            this.btnUserSettings.TabIndex = 2;
            this.btnUserSettings.Text = "사용자 설정";
            this.btnUserSettings.UseVisualStyleBackColor = false;
            this.btnUserSettings.Click += new System.EventHandler(this.btnUserSettings_Click);
            // 
            // btnZoneSettings
            // 
            this.btnZoneSettings.BackColor = AppColors.Surface;
            this.btnZoneSettings.FlatAppearance.BorderSize = 0;
            this.btnZoneSettings.FlatAppearance.MouseOverBackColor = AppColors.SurfaceAlt;
            this.btnZoneSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoneSettings.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnZoneSettings.ForeColor = AppColors.Text;
            this.btnZoneSettings.Location = new System.Drawing.Point(501, 3);
            this.btnZoneSettings.Name = "btnZoneSettings";
            this.btnZoneSettings.Size = new System.Drawing.Size(160, 70);
            this.btnZoneSettings.TabIndex = 3;
            this.btnZoneSettings.Text = "구역 설정";
            this.btnZoneSettings.UseVisualStyleBackColor = false;
            this.btnZoneSettings.Click += new System.EventHandler(this.btnZoneSettings_Click);
            // 
            // pnlBar
            // 
            this.pnlBar.BackColor = AppColors.Primary;
            this.pnlBar.Location = new System.Drawing.Point(41, 73);
            this.pnlBar.Name = "pnlBar";
            this.pnlBar.Size = new System.Drawing.Size(84, 3);
            this.pnlBar.TabIndex = 11;
            // 
            // US_SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = AppColors.Background;
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
        private System.Windows.Forms.Panel pnlSettingsMenuDivider;
        private System.Windows.Forms.Button btnZoneSettings;
        private System.Windows.Forms.Button btnUserSettings;
        private System.Windows.Forms.Button btnAlertSettings;
        private System.Windows.Forms.Button btnPPEStandard;
        private System.Windows.Forms.Panel pnlBar;
    }
}