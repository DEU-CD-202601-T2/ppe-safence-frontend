namespace PPE_관제_시스템
{
    partial class US_AlertSettings
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
            this.lblAlertSetting = new System.Windows.Forms.Label();
            this.btnAlertSave = new System.Windows.Forms.Button();
            this.btnAlertReset = new System.Windows.Forms.Button();
            this.cmbAlertType = new System.Windows.Forms.ComboBox();
            this.chkUseAlert = new System.Windows.Forms.CheckBox();
            this.lblAlertStatus = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlAlertType = new System.Windows.Forms.Panel();
            this.lblAlertType = new System.Windows.Forms.Label();
            this.pnlUseAlert = new System.Windows.Forms.Panel();
            this.lblUseAlert = new System.Windows.Forms.Label();
            this.pnlAlertMethod = new System.Windows.Forms.Panel();
            this.lblAlertMethod = new System.Windows.Forms.Label();
            this.pnlDetailSetting = new System.Windows.Forms.Panel();
            this.chkStopWork = new System.Windows.Forms.CheckBox();
            this.cmbSeverity = new System.Windows.Forms.ComboBox();
            this.lblSecond = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.lblStopWork = new System.Windows.Forms.Label();
            this.lblSeverity = new System.Windows.Forms.Label();
            this.lblInterval = new System.Windows.Forms.Label();
            this.lblDetailSetting = new System.Windows.Forms.Label();
            this.chkSendManager = new System.Windows.Forms.CheckBox();
            this.pnlAlertType.SuspendLayout();
            this.pnlUseAlert.SuspendLayout();
            this.pnlAlertMethod.SuspendLayout();
            this.pnlDetailSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAlertSetting
            // 
            this.lblAlertSetting.AutoSize = true;
            this.lblAlertSetting.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAlertSetting.Location = new System.Drawing.Point(3, 3);
            this.lblAlertSetting.Name = "lblAlertSetting";
            this.lblAlertSetting.Size = new System.Drawing.Size(114, 31);
            this.lblAlertSetting.TabIndex = 5;
            this.lblAlertSetting.Text = "알림 설정";
            // 
            // btnAlertSave
            // 
            this.btnAlertSave.Location = new System.Drawing.Point(1050, 608);
            this.btnAlertSave.Name = "btnAlertSave";
            this.btnAlertSave.Size = new System.Drawing.Size(149, 42);
            this.btnAlertSave.TabIndex = 6;
            this.btnAlertSave.Text = "저장";
            this.btnAlertSave.UseVisualStyleBackColor = true;
            // 
            // btnAlertReset
            // 
            this.btnAlertReset.Location = new System.Drawing.Point(895, 608);
            this.btnAlertReset.Name = "btnAlertReset";
            this.btnAlertReset.Size = new System.Drawing.Size(149, 42);
            this.btnAlertReset.TabIndex = 7;
            this.btnAlertReset.Text = "초기화";
            this.btnAlertReset.UseVisualStyleBackColor = true;
            // 
            // cmbAlertType
            // 
            this.cmbAlertType.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbAlertType.FormattingEnabled = true;
            this.cmbAlertType.Location = new System.Drawing.Point(18, 58);
            this.cmbAlertType.Name = "cmbAlertType";
            this.cmbAlertType.Size = new System.Drawing.Size(242, 31);
            this.cmbAlertType.TabIndex = 0;
            this.cmbAlertType.Text = "PPE 위반";
            // 
            // chkUseAlert
            // 
            this.chkUseAlert.AutoSize = true;
            this.chkUseAlert.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkUseAlert.Location = new System.Drawing.Point(21, 58);
            this.chkUseAlert.Name = "chkUseAlert";
            this.chkUseAlert.Size = new System.Drawing.Size(106, 27);
            this.chkUseAlert.TabIndex = 0;
            this.chkUseAlert.Text = "알림 사용";
            this.chkUseAlert.UseVisualStyleBackColor = true;
            // 
            // lblAlertStatus
            // 
            this.lblAlertStatus.AutoSize = true;
            this.lblAlertStatus.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAlertStatus.Location = new System.Drawing.Point(16, 119);
            this.lblAlertStatus.Name = "lblAlertStatus";
            this.lblAlertStatus.Size = new System.Drawing.Size(54, 23);
            this.lblAlertStatus.TabIndex = 10;
            this.lblAlertStatus.Text = "상태: ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(69, 119);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(78, 23);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "비활성화";
            // 
            // pnlAlertType
            // 
            this.pnlAlertType.BackColor = System.Drawing.SystemColors.Control;
            this.pnlAlertType.Controls.Add(this.lblAlertType);
            this.pnlAlertType.Controls.Add(this.cmbAlertType);
            this.pnlAlertType.Location = new System.Drawing.Point(9, 69);
            this.pnlAlertType.Name = "pnlAlertType";
            this.pnlAlertType.Size = new System.Drawing.Size(367, 169);
            this.pnlAlertType.TabIndex = 8;
            // 
            // lblAlertType
            // 
            this.lblAlertType.AutoSize = true;
            this.lblAlertType.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAlertType.Location = new System.Drawing.Point(14, 5);
            this.lblAlertType.Name = "lblAlertType";
            this.lblAlertType.Size = new System.Drawing.Size(84, 23);
            this.lblAlertType.TabIndex = 1;
            this.lblAlertType.Text = "알림 유형";
            // 
            // pnlUseAlert
            // 
            this.pnlUseAlert.BackColor = System.Drawing.SystemColors.Control;
            this.pnlUseAlert.Controls.Add(this.lblUseAlert);
            this.pnlUseAlert.Controls.Add(this.lblStatus);
            this.pnlUseAlert.Controls.Add(this.chkUseAlert);
            this.pnlUseAlert.Controls.Add(this.lblAlertStatus);
            this.pnlUseAlert.Location = new System.Drawing.Point(396, 69);
            this.pnlUseAlert.Name = "pnlUseAlert";
            this.pnlUseAlert.Size = new System.Drawing.Size(361, 169);
            this.pnlUseAlert.TabIndex = 9;
            // 
            // lblUseAlert
            // 
            this.lblUseAlert.AutoSize = true;
            this.lblUseAlert.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUseAlert.Location = new System.Drawing.Point(17, 5);
            this.lblUseAlert.Name = "lblUseAlert";
            this.lblUseAlert.Size = new System.Drawing.Size(84, 23);
            this.lblUseAlert.TabIndex = 12;
            this.lblUseAlert.Text = "알림 사용";
            // 
            // pnlAlertMethod
            // 
            this.pnlAlertMethod.BackColor = System.Drawing.SystemColors.Control;
            this.pnlAlertMethod.Controls.Add(this.chkSendManager);
            this.pnlAlertMethod.Controls.Add(this.lblAlertMethod);
            this.pnlAlertMethod.Location = new System.Drawing.Point(9, 268);
            this.pnlAlertMethod.Name = "pnlAlertMethod";
            this.pnlAlertMethod.Size = new System.Drawing.Size(580, 315);
            this.pnlAlertMethod.TabIndex = 10;
            // 
            // lblAlertMethod
            // 
            this.lblAlertMethod.AutoSize = true;
            this.lblAlertMethod.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAlertMethod.Location = new System.Drawing.Point(14, 12);
            this.lblAlertMethod.Name = "lblAlertMethod";
            this.lblAlertMethod.Size = new System.Drawing.Size(84, 23);
            this.lblAlertMethod.TabIndex = 2;
            this.lblAlertMethod.Text = "알림 방식";
            // 
            // pnlDetailSetting
            // 
            this.pnlDetailSetting.BackColor = System.Drawing.SystemColors.Control;
            this.pnlDetailSetting.Controls.Add(this.chkStopWork);
            this.pnlDetailSetting.Controls.Add(this.cmbSeverity);
            this.pnlDetailSetting.Controls.Add(this.lblSecond);
            this.pnlDetailSetting.Controls.Add(this.txtInterval);
            this.pnlDetailSetting.Controls.Add(this.lblStopWork);
            this.pnlDetailSetting.Controls.Add(this.lblSeverity);
            this.pnlDetailSetting.Controls.Add(this.lblInterval);
            this.pnlDetailSetting.Controls.Add(this.lblDetailSetting);
            this.pnlDetailSetting.Location = new System.Drawing.Point(608, 268);
            this.pnlDetailSetting.Name = "pnlDetailSetting";
            this.pnlDetailSetting.Size = new System.Drawing.Size(580, 315);
            this.pnlDetailSetting.TabIndex = 11;
            // 
            // chkStopWork
            // 
            this.chkStopWork.AutoSize = true;
            this.chkStopWork.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkStopWork.Location = new System.Drawing.Point(167, 210);
            this.chkStopWork.Name = "chkStopWork";
            this.chkStopWork.Size = new System.Drawing.Size(209, 27);
            this.chkStopWork.TabIndex = 10;
            this.chkStopWork.Text = "위반 발생 시 작업 중지";
            this.chkStopWork.UseVisualStyleBackColor = true;
            // 
            // cmbSeverity
            // 
            this.cmbSeverity.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbSeverity.FormattingEnabled = true;
            this.cmbSeverity.Location = new System.Drawing.Point(167, 154);
            this.cmbSeverity.Name = "cmbSeverity";
            this.cmbSeverity.Size = new System.Drawing.Size(121, 31);
            this.cmbSeverity.TabIndex = 9;
            this.cmbSeverity.Text = "보통";
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSecond.Location = new System.Drawing.Point(296, 97);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(27, 23);
            this.lblSecond.TabIndex = 8;
            this.lblSecond.Text = "초";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(167, 97);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(123, 25);
            this.txtInterval.TabIndex = 7;
            // 
            // lblStopWork
            // 
            this.lblStopWork.AutoSize = true;
            this.lblStopWork.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStopWork.Location = new System.Drawing.Point(18, 210);
            this.lblStopWork.Name = "lblStopWork";
            this.lblStopWork.Size = new System.Drawing.Size(134, 23);
            this.lblStopWork.TabIndex = 6;
            this.lblStopWork.Text = "작업 중지 연동: ";
            // 
            // lblSeverity
            // 
            this.lblSeverity.AutoSize = true;
            this.lblSeverity.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSeverity.Location = new System.Drawing.Point(18, 157);
            this.lblSeverity.Name = "lblSeverity";
            this.lblSeverity.Size = new System.Drawing.Size(111, 23);
            this.lblSeverity.TabIndex = 5;
            this.lblSeverity.Text = "최소 위험도: ";
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInterval.Location = new System.Drawing.Point(17, 97);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(134, 23);
            this.lblInterval.TabIndex = 4;
            this.lblInterval.Text = "반복 알림 간격: ";
            // 
            // lblDetailSetting
            // 
            this.lblDetailSetting.AutoSize = true;
            this.lblDetailSetting.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDetailSetting.Location = new System.Drawing.Point(18, 13);
            this.lblDetailSetting.Name = "lblDetailSetting";
            this.lblDetailSetting.Size = new System.Drawing.Size(84, 23);
            this.lblDetailSetting.TabIndex = 3;
            this.lblDetailSetting.Text = "세부 설정";
            // 
            // chkSendManager
            // 
            this.chkSendManager.AutoSize = true;
            this.chkSendManager.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkSendManager.Location = new System.Drawing.Point(18, 97);
            this.chkSendManager.Name = "chkSendManager";
            this.chkSendManager.Size = new System.Drawing.Size(197, 27);
            this.chkSendManager.TabIndex = 5;
            this.chkSendManager.Text = "관리자에게 알림 전송";
            this.chkSendManager.UseVisualStyleBackColor = true;
            // 
            // US_AlertSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.pnlDetailSetting);
            this.Controls.Add(this.pnlAlertMethod);
            this.Controls.Add(this.pnlUseAlert);
            this.Controls.Add(this.pnlAlertType);
            this.Controls.Add(this.btnAlertReset);
            this.Controls.Add(this.btnAlertSave);
            this.Controls.Add(this.lblAlertSetting);
            this.Name = "US_AlertSettings";
            this.Size = new System.Drawing.Size(1219, 653);
            this.pnlAlertType.ResumeLayout(false);
            this.pnlAlertType.PerformLayout();
            this.pnlUseAlert.ResumeLayout(false);
            this.pnlUseAlert.PerformLayout();
            this.pnlAlertMethod.ResumeLayout(false);
            this.pnlAlertMethod.PerformLayout();
            this.pnlDetailSetting.ResumeLayout(false);
            this.pnlDetailSetting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblAlertSetting;
        private System.Windows.Forms.Button btnAlertSave;
        private System.Windows.Forms.Button btnAlertReset;
        private System.Windows.Forms.ComboBox cmbAlertType;
        private System.Windows.Forms.CheckBox chkUseAlert;
        private System.Windows.Forms.Label lblAlertStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel pnlAlertType;
        private System.Windows.Forms.Label lblAlertType;
        private System.Windows.Forms.Panel pnlUseAlert;
        private System.Windows.Forms.Label lblUseAlert;
        private System.Windows.Forms.Panel pnlAlertMethod;
        private System.Windows.Forms.Panel pnlDetailSetting;
        private System.Windows.Forms.Label lblAlertMethod;
        private System.Windows.Forms.Label lblDetailSetting;
        private System.Windows.Forms.Label lblStopWork;
        private System.Windows.Forms.Label lblSeverity;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.ComboBox cmbSeverity;
        private System.Windows.Forms.CheckBox chkStopWork;
        private System.Windows.Forms.CheckBox chkSendManager;
    }
}
