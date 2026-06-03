namespace PPE_관제_시스템
{
    partial class US_AlertSettings
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
            this.lblAlertSetting = new System.Windows.Forms.Label();
            this.grpAlertType = new System.Windows.Forms.GroupBox();
            this.cmbAlertType = new System.Windows.Forms.ComboBox();
            this.grpUseAlert = new System.Windows.Forms.GroupBox();
            this.chkUseAlert = new System.Windows.Forms.CheckBox();
            this.lblAlertStatus = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpAlertMethod = new System.Windows.Forms.GroupBox();
            this.chkSendManager = new System.Windows.Forms.CheckBox();
            this.grpDetailSetting = new System.Windows.Forms.GroupBox();
            this.lblInterval = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.lblSecond = new System.Windows.Forms.Label();
            this.lblSeverity = new System.Windows.Forms.Label();
            this.cmbSeverity = new System.Windows.Forms.ComboBox();
            this.lblStopWork = new System.Windows.Forms.Label();
            this.chkStopWork = new System.Windows.Forms.CheckBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnAlertReset = new System.Windows.Forms.Button();
            this.btnAlertSave = new System.Windows.Forms.Button();
            this.grpAlertType.SuspendLayout();
            this.grpUseAlert.SuspendLayout();
            this.grpAlertMethod.SuspendLayout();
            this.grpDetailSetting.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAlertSetting
            // 
            this.lblAlertSetting.AutoSize = true;
            this.lblAlertSetting.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblAlertSetting.ForeColor = AppColors.Text;
            this.lblAlertSetting.Location = new System.Drawing.Point(20, 10);
            this.lblAlertSetting.Name = "lblAlertSetting";
            this.lblAlertSetting.Size = new System.Drawing.Size(116, 31);
            this.lblAlertSetting.TabIndex = 0;
            this.lblAlertSetting.Text = "알림 설정";
            // 
            // grpAlertType
            // 
            this.grpAlertType.BackColor = AppColors.Surface;
            this.grpAlertType.Controls.Add(this.cmbAlertType);
            this.grpAlertType.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.grpAlertType.ForeColor = AppColors.PrimaryDark;
            this.grpAlertType.Location = new System.Drawing.Point(20, 55);
            this.grpAlertType.Name = "grpAlertType";
            this.grpAlertType.Size = new System.Drawing.Size(580, 180);
            this.grpAlertType.TabIndex = 1;
            this.grpAlertType.TabStop = false;
            this.grpAlertType.Text = "알림 유형";
            // 
            // cmbAlertType
            // 
            this.cmbAlertType.BackColor = AppColors.Surface;
            this.cmbAlertType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAlertType.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular);
            this.cmbAlertType.ForeColor = AppColors.Text;
            this.cmbAlertType.FormattingEnabled = true;
            this.cmbAlertType.Items.AddRange(new object[] {
            "안전모",
            "장갑",
            "마스크"});
            this.cmbAlertType.Location = new System.Drawing.Point(25, 65);
            this.cmbAlertType.Name = "cmbAlertType";
            this.cmbAlertType.Size = new System.Drawing.Size(280, 31);
            this.cmbAlertType.TabIndex = 0;
            this.cmbAlertType.Text = "PPE 위반";
            this.cmbAlertType.SelectedIndexChanged += new System.EventHandler(this.cmbAlertType_SelectedIndexChanged);
            // 
            // grpUseAlert
            // 
            this.grpUseAlert.BackColor = AppColors.Surface;
            this.grpUseAlert.Controls.Add(this.chkUseAlert);
            this.grpUseAlert.Controls.Add(this.lblAlertStatus);
            this.grpUseAlert.Controls.Add(this.lblStatus);
            this.grpUseAlert.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.grpUseAlert.ForeColor = AppColors.PrimaryDark;
            this.grpUseAlert.Location = new System.Drawing.Point(615, 55);
            this.grpUseAlert.Name = "grpUseAlert";
            this.grpUseAlert.Size = new System.Drawing.Size(580, 180);
            this.grpUseAlert.TabIndex = 2;
            this.grpUseAlert.TabStop = false;
            this.grpUseAlert.Text = "알림 사용";
            // 
            // chkUseAlert
            // 
            this.chkUseAlert.AutoSize = true;
            this.chkUseAlert.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular);
            this.chkUseAlert.ForeColor = AppColors.Text;
            this.chkUseAlert.Location = new System.Drawing.Point(25, 65);
            this.chkUseAlert.Name = "chkUseAlert";
            this.chkUseAlert.Size = new System.Drawing.Size(112, 28);
            this.chkUseAlert.TabIndex = 0;
            this.chkUseAlert.Text = "알림 사용";
            this.chkUseAlert.UseVisualStyleBackColor = true;
            this.chkUseAlert.CheckedChanged += new System.EventHandler(this.chkUseAlert_CheckedChanged);
            // 
            // lblAlertStatus
            // 
            this.lblAlertStatus.AutoSize = true;
            this.lblAlertStatus.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular);
            this.lblAlertStatus.ForeColor = AppColors.Text;
            this.lblAlertStatus.Location = new System.Drawing.Point(25, 115);
            this.lblAlertStatus.Name = "lblAlertStatus";
            this.lblAlertStatus.Size = new System.Drawing.Size(56, 25);
            this.lblAlertStatus.TabIndex = 1;
            this.lblAlertStatus.Text = "상태:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = AppColors.Danger;
            this.lblStatus.Location = new System.Drawing.Point(85, 115);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(83, 25);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "비활성화";
            // 
            // grpAlertMethod
            // 
            this.grpAlertMethod.BackColor = AppColors.Surface;
            this.grpAlertMethod.Controls.Add(this.chkSendManager);
            this.grpAlertMethod.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.grpAlertMethod.ForeColor = AppColors.PrimaryDark;
            this.grpAlertMethod.Location = new System.Drawing.Point(20, 250);
            this.grpAlertMethod.Name = "grpAlertMethod";
            this.grpAlertMethod.Size = new System.Drawing.Size(580, 280);
            this.grpAlertMethod.TabIndex = 3;
            this.grpAlertMethod.TabStop = false;
            this.grpAlertMethod.Text = "알림 방식";
            // 
            // chkSendManager
            // 
            this.chkSendManager.AutoSize = true;
            this.chkSendManager.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.chkSendManager.ForeColor = AppColors.Text;
            this.chkSendManager.Location = new System.Drawing.Point(25, 70);
            this.chkSendManager.Name = "chkSendManager";
            this.chkSendManager.Size = new System.Drawing.Size(207, 28);
            this.chkSendManager.TabIndex = 0;
            this.chkSendManager.Text = "관리자에게 알림 전송";
            this.chkSendManager.UseVisualStyleBackColor = true;
            // 
            // grpDetailSetting
            // 
            this.grpDetailSetting.BackColor = AppColors.Surface;
            this.grpDetailSetting.Controls.Add(this.lblInterval);
            this.grpDetailSetting.Controls.Add(this.txtInterval);
            this.grpDetailSetting.Controls.Add(this.lblSecond);
            this.grpDetailSetting.Controls.Add(this.lblSeverity);
            this.grpDetailSetting.Controls.Add(this.cmbSeverity);
            this.grpDetailSetting.Controls.Add(this.lblStopWork);
            this.grpDetailSetting.Controls.Add(this.chkStopWork);
            this.grpDetailSetting.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.grpDetailSetting.ForeColor = AppColors.PrimaryDark;
            this.grpDetailSetting.Location = new System.Drawing.Point(615, 250);
            this.grpDetailSetting.Name = "grpDetailSetting";
            this.grpDetailSetting.Size = new System.Drawing.Size(580, 280);
            this.grpDetailSetting.TabIndex = 4;
            this.grpDetailSetting.TabStop = false;
            this.grpDetailSetting.Text = "세부 설정";
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lblInterval.ForeColor = AppColors.Text;
            this.lblInterval.Location = new System.Drawing.Point(25, 60);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(127, 23);
            this.lblInterval.TabIndex = 0;
            this.lblInterval.Text = "반복 알림 간격:";
            // 
            // txtInterval
            // 
            this.txtInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInterval.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtInterval.ForeColor = AppColors.Text;
            this.txtInterval.Location = new System.Drawing.Point(180, 57);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(120, 30);
            this.txtInterval.TabIndex = 1;
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lblSecond.ForeColor = AppColors.Text;
            this.lblSecond.Location = new System.Drawing.Point(306, 60);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(28, 23);
            this.lblSecond.TabIndex = 2;
            this.lblSecond.Text = "초";
            // 
            // lblSeverity
            // 
            this.lblSeverity.AutoSize = true;
            this.lblSeverity.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lblSeverity.ForeColor = AppColors.Text;
            this.lblSeverity.Location = new System.Drawing.Point(25, 115);
            this.lblSeverity.Name = "lblSeverity";
            this.lblSeverity.Size = new System.Drawing.Size(105, 23);
            this.lblSeverity.TabIndex = 3;
            this.lblSeverity.Text = "최소 위험도:";
            // 
            // cmbSeverity
            // 
            this.cmbSeverity.BackColor = AppColors.Surface;
            this.cmbSeverity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSeverity.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cmbSeverity.ForeColor = AppColors.Text;
            this.cmbSeverity.FormattingEnabled = true;
            this.cmbSeverity.Items.AddRange(new object[] {
            "높음",
            "보통",
            "낮음"});
            this.cmbSeverity.Location = new System.Drawing.Point(180, 112);
            this.cmbSeverity.Name = "cmbSeverity";
            this.cmbSeverity.Size = new System.Drawing.Size(120, 31);
            this.cmbSeverity.TabIndex = 4;
            this.cmbSeverity.Text = "보통";
            // 
            // lblStopWork
            // 
            this.lblStopWork.AutoSize = true;
            this.lblStopWork.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lblStopWork.ForeColor = AppColors.Text;
            this.lblStopWork.Location = new System.Drawing.Point(25, 175);
            this.lblStopWork.Name = "lblStopWork";
            this.lblStopWork.Size = new System.Drawing.Size(123, 23);
            this.lblStopWork.TabIndex = 5;
            this.lblStopWork.Text = "작업 중지 연동:";
            // 
            // chkStopWork
            // 
            this.chkStopWork.AutoSize = true;
            this.chkStopWork.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.chkStopWork.ForeColor = AppColors.Text;
            this.chkStopWork.Location = new System.Drawing.Point(180, 175);
            this.chkStopWork.Name = "chkStopWork";
            this.chkStopWork.Size = new System.Drawing.Size(202, 27);
            this.chkStopWork.TabIndex = 6;
            this.chkStopWork.Text = "위반 발생 시 작업 중지";
            this.chkStopWork.UseVisualStyleBackColor = true;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlButtons.BackColor = AppColors.Background;
            this.pnlButtons.Controls.Add(this.btnAlertReset);
            this.pnlButtons.Controls.Add(this.btnAlertSave);
            this.pnlButtons.Location = new System.Drawing.Point(20, 580);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(1175, 55);
            this.pnlButtons.TabIndex = 5;
            // 
            // btnAlertReset
            // 
            this.btnAlertReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlertReset.BackColor = AppColors.Surface;
            this.btnAlertReset.FlatAppearance.BorderColor = AppColors.Primary;
            this.btnAlertReset.FlatAppearance.BorderSize = 1;
            this.btnAlertReset.FlatAppearance.MouseOverBackColor = AppColors.PrimaryLight;
            this.btnAlertReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlertReset.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.btnAlertReset.ForeColor = AppColors.PrimaryDark;
            this.btnAlertReset.Location = new System.Drawing.Point(875, 5);
            this.btnAlertReset.Name = "btnAlertReset";
            this.btnAlertReset.Size = new System.Drawing.Size(140, 45);
            this.btnAlertReset.TabIndex = 0;
            this.btnAlertReset.Text = "초기화";
            this.btnAlertReset.UseVisualStyleBackColor = false;
            this.btnAlertReset.Click += new System.EventHandler(this.btnAlertReset_Click);
            // 
            // btnAlertSave
            // 
            this.btnAlertSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlertSave.BackColor = AppColors.Primary;
            this.btnAlertSave.FlatAppearance.BorderSize = 0;
            this.btnAlertSave.FlatAppearance.MouseOverBackColor = AppColors.PrimaryDark;
            this.btnAlertSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlertSave.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnAlertSave.ForeColor = AppColors.TextOnPrimary;
            this.btnAlertSave.Location = new System.Drawing.Point(1025, 5);
            this.btnAlertSave.Name = "btnAlertSave";
            this.btnAlertSave.Size = new System.Drawing.Size(140, 45);
            this.btnAlertSave.TabIndex = 1;
            this.btnAlertSave.Text = "저장";
            this.btnAlertSave.UseVisualStyleBackColor = false;
            this.btnAlertSave.Click += new System.EventHandler(this.btnAlertSave_Click);
            // 
            // US_AlertSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = AppColors.Background;
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.grpDetailSetting);
            this.Controls.Add(this.grpAlertMethod);
            this.Controls.Add(this.grpUseAlert);
            this.Controls.Add(this.grpAlertType);
            this.Controls.Add(this.lblAlertSetting);
            this.Name = "US_AlertSettings";
            this.Size = new System.Drawing.Size(1219, 653);
            this.Load += new System.EventHandler(this.US_AlertSettings_Load);
            this.grpAlertType.ResumeLayout(false);
            this.grpUseAlert.ResumeLayout(false);
            this.grpUseAlert.PerformLayout();
            this.grpAlertMethod.ResumeLayout(false);
            this.grpAlertMethod.PerformLayout();
            this.grpDetailSetting.ResumeLayout(false);
            this.grpDetailSetting.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblAlertSetting;
        private System.Windows.Forms.GroupBox grpAlertType;
        private System.Windows.Forms.ComboBox cmbAlertType;
        private System.Windows.Forms.GroupBox grpUseAlert;
        private System.Windows.Forms.CheckBox chkUseAlert;
        private System.Windows.Forms.Label lblAlertStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox grpAlertMethod;
        private System.Windows.Forms.CheckBox chkSendManager;
        private System.Windows.Forms.GroupBox grpDetailSetting;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.Label lblSeverity;
        private System.Windows.Forms.ComboBox cmbSeverity;
        private System.Windows.Forms.Label lblStopWork;
        private System.Windows.Forms.CheckBox chkStopWork;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnAlertReset;
        private System.Windows.Forms.Button btnAlertSave;
    }
}