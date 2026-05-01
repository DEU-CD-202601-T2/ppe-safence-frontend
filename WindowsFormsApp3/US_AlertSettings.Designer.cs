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
            this.btnAlertDelete = new System.Windows.Forms.Button();
            this.chkSound = new System.Windows.Forms.CheckBox();
            this.chkPopup = new System.Windows.Forms.CheckBox();
            this.chkEnableAlerts = new System.Windows.Forms.CheckBox();
            this.lblSetting = new System.Windows.Forms.Label();
            this.cmbAlertTypeList = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAlertType = new System.Windows.Forms.Label();
            this.lblAlertMethod = new System.Windows.Forms.Label();
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
            this.btnAlertSave.Location = new System.Drawing.Point(897, 594);
            this.btnAlertSave.Name = "btnAlertSave";
            this.btnAlertSave.Size = new System.Drawing.Size(149, 42);
            this.btnAlertSave.TabIndex = 6;
            this.btnAlertSave.Text = "저장";
            this.btnAlertSave.UseVisualStyleBackColor = true;
            // 
            // btnAlertDelete
            // 
            this.btnAlertDelete.Location = new System.Drawing.Point(1052, 594);
            this.btnAlertDelete.Name = "btnAlertDelete";
            this.btnAlertDelete.Size = new System.Drawing.Size(149, 42);
            this.btnAlertDelete.TabIndex = 7;
            this.btnAlertDelete.Text = "삭제";
            this.btnAlertDelete.UseVisualStyleBackColor = true;
            // 
            // chkSound
            // 
            this.chkSound.AutoSize = true;
            this.chkSound.Location = new System.Drawing.Point(687, 287);
            this.chkSound.Name = "chkSound";
            this.chkSound.Size = new System.Drawing.Size(59, 19);
            this.chkSound.TabIndex = 19;
            this.chkSound.Text = "소리";
            this.chkSound.UseVisualStyleBackColor = true;
            // 
            // chkPopup
            // 
            this.chkPopup.AutoSize = true;
            this.chkPopup.Location = new System.Drawing.Point(687, 249);
            this.chkPopup.Name = "chkPopup";
            this.chkPopup.Size = new System.Drawing.Size(59, 19);
            this.chkPopup.TabIndex = 18;
            this.chkPopup.Text = "팝업";
            this.chkPopup.UseVisualStyleBackColor = true;
            // 
            // chkEnableAlerts
            // 
            this.chkEnableAlerts.AutoSize = true;
            this.chkEnableAlerts.Location = new System.Drawing.Point(660, 175);
            this.chkEnableAlerts.Name = "chkEnableAlerts";
            this.chkEnableAlerts.Size = new System.Drawing.Size(94, 19);
            this.chkEnableAlerts.TabIndex = 17;
            this.chkEnableAlerts.Text = "알림 사용";
            this.chkEnableAlerts.UseVisualStyleBackColor = true;
            // 
            // lblSetting
            // 
            this.lblSetting.AutoSize = true;
            this.lblSetting.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSetting.Location = new System.Drawing.Point(766, 110);
            this.lblSetting.Name = "lblSetting";
            this.lblSetting.Size = new System.Drawing.Size(73, 38);
            this.lblSetting.TabIndex = 16;
            this.lblSetting.Text = "설정";
            // 
            // cmbAlertTypeList
            // 
            this.cmbAlertTypeList.FormattingEnabled = true;
            this.cmbAlertTypeList.Location = new System.Drawing.Point(217, 182);
            this.cmbAlertTypeList.Name = "cmbAlertTypeList";
            this.cmbAlertTypeList.Size = new System.Drawing.Size(223, 23);
            this.cmbAlertTypeList.TabIndex = 15;
            this.cmbAlertTypeList.Text = "PPE 위반";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(580, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 434);
            this.panel1.TabIndex = 14;
            // 
            // lblAlertType
            // 
            this.lblAlertType.AutoSize = true;
            this.lblAlertType.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAlertType.Location = new System.Drawing.Point(265, 110);
            this.lblAlertType.Name = "lblAlertType";
            this.lblAlertType.Size = new System.Drawing.Size(139, 38);
            this.lblAlertType.TabIndex = 13;
            this.lblAlertType.Text = "알림 유형";
            // 
            // lblAlertMethod
            // 
            this.lblAlertMethod.AutoSize = true;
            this.lblAlertMethod.Location = new System.Drawing.Point(657, 215);
            this.lblAlertMethod.Name = "lblAlertMethod";
            this.lblAlertMethod.Size = new System.Drawing.Size(72, 15);
            this.lblAlertMethod.TabIndex = 22;
            this.lblAlertMethod.Text = "알림 방식";
            // 
            // US_AlertSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.lblAlertMethod);
            this.Controls.Add(this.chkSound);
            this.Controls.Add(this.chkPopup);
            this.Controls.Add(this.chkEnableAlerts);
            this.Controls.Add(this.lblSetting);
            this.Controls.Add(this.cmbAlertTypeList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblAlertType);
            this.Controls.Add(this.btnAlertDelete);
            this.Controls.Add(this.btnAlertSave);
            this.Controls.Add(this.lblAlertSetting);
            this.Name = "US_AlertSettings";
            this.Size = new System.Drawing.Size(1219, 653);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblAlertSetting;
        private System.Windows.Forms.Button btnAlertSave;
        private System.Windows.Forms.Button btnAlertDelete;
        private System.Windows.Forms.CheckBox chkSound;
        private System.Windows.Forms.CheckBox chkPopup;
        private System.Windows.Forms.CheckBox chkEnableAlerts;
        private System.Windows.Forms.Label lblSetting;
        private System.Windows.Forms.ComboBox cmbAlertTypeList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAlertType;
        private System.Windows.Forms.Label lblAlertMethod;
    }
}
