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
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblPPESystem = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            this.pnlMenu.Controls.Add(this.button7);
            this.pnlMenu.Controls.Add(this.button6);
            this.pnlMenu.Controls.Add(this.button5);
            this.pnlMenu.Controls.Add(this.button4);
            this.pnlMenu.Controls.Add(this.lblPPESystem);
            this.pnlMenu.Controls.Add(this.button3);
            this.pnlMenu.Controls.Add(this.button2);
            this.pnlMenu.Controls.Add(this.button1);
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
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(21, 452);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(226, 51);
            this.button7.TabIndex = 6;
            this.button7.Text = "설정";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(22, 397);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(226, 51);
            this.button6.TabIndex = 5;
            this.button6.Text = "분석";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(21, 341);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(226, 51);
            this.button5.TabIndex = 4;
            this.button5.Text = "이력 / 로그";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(21, 285);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(226, 51);
            this.button4.TabIndex = 3;
            this.button4.Text = "대응 / 제어";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // lblPPESystem
            // 
            this.lblPPESystem.AutoSize = true;
            this.lblPPESystem.Location = new System.Drawing.Point(79, 45);
            this.lblPPESystem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPPESystem.Name = "lblPPESystem";
            this.lblPPESystem.Size = new System.Drawing.Size(116, 15);
            this.lblPPESystem.TabIndex = 2;
            this.lblPPESystem.Text = "PPE 관제시스템";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(21, 229);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(226, 51);
            this.button3.TabIndex = 2;
            this.button3.Text = "위반관리";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(22, 173);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(226, 51);
            this.button2.TabIndex = 1;
            this.button2.Text = "알림";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(22, 118);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "실시간 모니터링";
            this.button1.UseVisualStyleBackColor = false;
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
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblPPESystem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}