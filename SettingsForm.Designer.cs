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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.lblSettingHeader = new System.Windows.Forms.Label();
            this.pnlSettingMenu = new System.Windows.Forms.Panel();
            this.btnZoneSettings = new System.Windows.Forms.Button();
            this.btnUserSettings = new System.Windows.Forms.Button();
            this.btnAlertSettings = new System.Windows.Forms.Button();
            this.btnPPEStandard = new System.Windows.Forms.Button();
            this.pnlShow = new System.Windows.Forms.Panel();
            this.pnlSettingMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlMenu.Location = new System.Drawing.Point(1, 1);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(211, 671);
            this.pnlMenu.TabIndex = 1;
            // 
            // lblSettingHeader
            // 
            this.lblSettingHeader.AutoSize = true;
            this.lblSettingHeader.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSettingHeader.Location = new System.Drawing.Point(218, 9);
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
            this.pnlSettingMenu.Location = new System.Drawing.Point(225, 82);
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
            this.pnlShow.Location = new System.Drawing.Point(225, 174);
            this.pnlShow.Name = "pnlShow";
            this.pnlShow.Size = new System.Drawing.Size(945, 487);
            this.pnlShow.TabIndex = 4;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 673);
            this.Controls.Add(this.pnlShow);
            this.Controls.Add(this.pnlSettingMenu);
            this.Controls.Add(this.lblSettingHeader);
            this.Controls.Add(this.pnlMenu);
            this.Name = "SettingsForm";
            this.Text = "설정";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
            this.pnlSettingMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblSettingHeader;
        private System.Windows.Forms.Panel pnlSettingMenu;
        private System.Windows.Forms.Panel pnlShow;
        private System.Windows.Forms.Button btnZoneSettings;
        private System.Windows.Forms.Button btnUserSettings;
        private System.Windows.Forms.Button btnAlertSettings;
        private System.Windows.Forms.Button btnPPEStandard;
    }
}