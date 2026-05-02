namespace PPE_관제_시스템
{
    partial class US_ZoneSetting
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
            this.btnZoneAdd = new System.Windows.Forms.Button();
            this.btnZoneModify = new System.Windows.Forms.Button();
            this.btnZoneDelete = new System.Windows.Forms.Button();
            this.lblZoneList = new System.Windows.Forms.Label();
            this.lblZoneInfo = new System.Windows.Forms.Label();
            this.lblZoneSetting = new System.Windows.Forms.Label();
            this.pnlZoneList = new System.Windows.Forms.Panel();
            this.lstZones = new System.Windows.Forms.ListBox();
            this.pnlZoneInfo = new System.Windows.Forms.Panel();
            this.lblZoneName = new System.Windows.Forms.Label();
            this.lblZoneDescription = new System.Windows.Forms.Label();
            this.lblZoneRiskLevel = new System.Windows.Forms.Label();
            this.cmbZoneRiskLevel = new System.Windows.Forms.ComboBox();
            this.lblUseZone = new System.Windows.Forms.Label();
            this.chkUseZone = new System.Windows.Forms.CheckBox();
            this.txtZoneName = new System.Windows.Forms.TextBox();
            this.txtZoneDescription = new System.Windows.Forms.TextBox();
            this.pnlZoneList.SuspendLayout();
            this.pnlZoneInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnZoneAdd
            // 
            this.btnZoneAdd.Location = new System.Drawing.Point(399, 462);
            this.btnZoneAdd.Name = "btnZoneAdd";
            this.btnZoneAdd.Size = new System.Drawing.Size(128, 51);
            this.btnZoneAdd.TabIndex = 0;
            this.btnZoneAdd.Text = "추가";
            this.btnZoneAdd.UseVisualStyleBackColor = true;
            // 
            // btnZoneModify
            // 
            this.btnZoneModify.Location = new System.Drawing.Point(269, 462);
            this.btnZoneModify.Name = "btnZoneModify";
            this.btnZoneModify.Size = new System.Drawing.Size(128, 51);
            this.btnZoneModify.TabIndex = 1;
            this.btnZoneModify.Text = "수정";
            this.btnZoneModify.UseVisualStyleBackColor = true;
            // 
            // btnZoneDelete
            // 
            this.btnZoneDelete.Location = new System.Drawing.Point(403, 462);
            this.btnZoneDelete.Name = "btnZoneDelete";
            this.btnZoneDelete.Size = new System.Drawing.Size(128, 51);
            this.btnZoneDelete.TabIndex = 2;
            this.btnZoneDelete.Text = "삭제";
            this.btnZoneDelete.UseVisualStyleBackColor = true;
            // 
            // lblZoneList
            // 
            this.lblZoneList.AutoSize = true;
            this.lblZoneList.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZoneList.Location = new System.Drawing.Point(191, 13);
            this.lblZoneList.Name = "lblZoneList";
            this.lblZoneList.Size = new System.Drawing.Size(139, 38);
            this.lblZoneList.TabIndex = 4;
            this.lblZoneList.Text = "구역 목록";
            // 
            // lblZoneInfo
            // 
            this.lblZoneInfo.AutoSize = true;
            this.lblZoneInfo.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZoneInfo.Location = new System.Drawing.Point(214, 13);
            this.lblZoneInfo.Name = "lblZoneInfo";
            this.lblZoneInfo.Size = new System.Drawing.Size(139, 38);
            this.lblZoneInfo.TabIndex = 5;
            this.lblZoneInfo.Text = "구역 정보";
            // 
            // lblZoneSetting
            // 
            this.lblZoneSetting.AutoSize = true;
            this.lblZoneSetting.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZoneSetting.Location = new System.Drawing.Point(3, 3);
            this.lblZoneSetting.Name = "lblZoneSetting";
            this.lblZoneSetting.Size = new System.Drawing.Size(114, 31);
            this.lblZoneSetting.TabIndex = 6;
            this.lblZoneSetting.Text = "구역 설정";
            // 
            // pnlZoneList
            // 
            this.pnlZoneList.BackColor = System.Drawing.SystemColors.Control;
            this.pnlZoneList.Controls.Add(this.lstZones);
            this.pnlZoneList.Controls.Add(this.btnZoneAdd);
            this.pnlZoneList.Controls.Add(this.lblZoneList);
            this.pnlZoneList.Location = new System.Drawing.Point(39, 97);
            this.pnlZoneList.Name = "pnlZoneList";
            this.pnlZoneList.Size = new System.Drawing.Size(549, 525);
            this.pnlZoneList.TabIndex = 7;
            // 
            // lstZones
            // 
            this.lstZones.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lstZones.FormattingEnabled = true;
            this.lstZones.ItemHeight = 28;
            this.lstZones.Items.AddRange(new object[] {
            "A구역 | 위험도 높음",
            "B구역 | 위험도 보통",
            "C구역 | 위험도 낮음"});
            this.lstZones.Location = new System.Drawing.Point(22, 79);
            this.lstZones.Name = "lstZones";
            this.lstZones.Size = new System.Drawing.Size(505, 228);
            this.lstZones.TabIndex = 5;
            // 
            // pnlZoneInfo
            // 
            this.pnlZoneInfo.BackColor = System.Drawing.SystemColors.Control;
            this.pnlZoneInfo.Controls.Add(this.txtZoneDescription);
            this.pnlZoneInfo.Controls.Add(this.txtZoneName);
            this.pnlZoneInfo.Controls.Add(this.chkUseZone);
            this.pnlZoneInfo.Controls.Add(this.lblUseZone);
            this.pnlZoneInfo.Controls.Add(this.cmbZoneRiskLevel);
            this.pnlZoneInfo.Controls.Add(this.lblZoneRiskLevel);
            this.pnlZoneInfo.Controls.Add(this.lblZoneDescription);
            this.pnlZoneInfo.Controls.Add(this.lblZoneName);
            this.pnlZoneInfo.Controls.Add(this.btnZoneModify);
            this.pnlZoneInfo.Controls.Add(this.btnZoneDelete);
            this.pnlZoneInfo.Controls.Add(this.lblZoneInfo);
            this.pnlZoneInfo.Location = new System.Drawing.Point(632, 97);
            this.pnlZoneInfo.Name = "pnlZoneInfo";
            this.pnlZoneInfo.Size = new System.Drawing.Size(544, 525);
            this.pnlZoneInfo.TabIndex = 8;
            // 
            // lblZoneName
            // 
            this.lblZoneName.AutoSize = true;
            this.lblZoneName.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZoneName.Location = new System.Drawing.Point(34, 79);
            this.lblZoneName.Name = "lblZoneName";
            this.lblZoneName.Size = new System.Drawing.Size(77, 23);
            this.lblZoneName.TabIndex = 6;
            this.lblZoneName.Text = "구역명 : ";
            // 
            // lblZoneDescription
            // 
            this.lblZoneDescription.AutoSize = true;
            this.lblZoneDescription.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZoneDescription.Location = new System.Drawing.Point(35, 138);
            this.lblZoneDescription.Name = "lblZoneDescription";
            this.lblZoneDescription.Size = new System.Drawing.Size(94, 23);
            this.lblZoneDescription.TabIndex = 8;
            this.lblZoneDescription.Text = "구역 설명: ";
            // 
            // lblZoneRiskLevel
            // 
            this.lblZoneRiskLevel.AutoSize = true;
            this.lblZoneRiskLevel.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZoneRiskLevel.Location = new System.Drawing.Point(35, 199);
            this.lblZoneRiskLevel.Name = "lblZoneRiskLevel";
            this.lblZoneRiskLevel.Size = new System.Drawing.Size(61, 23);
            this.lblZoneRiskLevel.TabIndex = 10;
            this.lblZoneRiskLevel.Text = "위험도";
            // 
            // cmbZoneRiskLevel
            // 
            this.cmbZoneRiskLevel.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbZoneRiskLevel.FormattingEnabled = true;
            this.cmbZoneRiskLevel.Location = new System.Drawing.Point(59, 235);
            this.cmbZoneRiskLevel.Name = "cmbZoneRiskLevel";
            this.cmbZoneRiskLevel.Size = new System.Drawing.Size(132, 31);
            this.cmbZoneRiskLevel.TabIndex = 11;
            this.cmbZoneRiskLevel.Text = "높음";
            // 
            // lblUseZone
            // 
            this.lblUseZone.AutoSize = true;
            this.lblUseZone.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUseZone.Location = new System.Drawing.Point(35, 301);
            this.lblUseZone.Name = "lblUseZone";
            this.lblUseZone.Size = new System.Drawing.Size(84, 23);
            this.lblUseZone.TabIndex = 12;
            this.lblUseZone.Text = "사용 여부";
            // 
            // chkUseZone
            // 
            this.chkUseZone.AutoSize = true;
            this.chkUseZone.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkUseZone.Location = new System.Drawing.Point(59, 344);
            this.chkUseZone.Name = "chkUseZone";
            this.chkUseZone.Size = new System.Drawing.Size(129, 27);
            this.chkUseZone.TabIndex = 13;
            this.chkUseZone.Text = "이 구역 사용";
            this.chkUseZone.UseVisualStyleBackColor = true;
            // 
            // txtZoneName
            // 
            this.txtZoneName.Location = new System.Drawing.Point(127, 82);
            this.txtZoneName.Name = "txtZoneName";
            this.txtZoneName.Size = new System.Drawing.Size(168, 25);
            this.txtZoneName.TabIndex = 14;
            // 
            // txtZoneDescription
            // 
            this.txtZoneDescription.Location = new System.Drawing.Point(135, 140);
            this.txtZoneDescription.Name = "txtZoneDescription";
            this.txtZoneDescription.Size = new System.Drawing.Size(354, 25);
            this.txtZoneDescription.TabIndex = 15;
            // 
            // US_ZoneSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.pnlZoneInfo);
            this.Controls.Add(this.pnlZoneList);
            this.Controls.Add(this.lblZoneSetting);
            this.Name = "US_ZoneSetting";
            this.Size = new System.Drawing.Size(1219, 653);
            this.pnlZoneList.ResumeLayout(false);
            this.pnlZoneList.PerformLayout();
            this.pnlZoneInfo.ResumeLayout(false);
            this.pnlZoneInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnZoneAdd;
        private System.Windows.Forms.Button btnZoneModify;
        private System.Windows.Forms.Button btnZoneDelete;
        private System.Windows.Forms.Label lblZoneList;
        private System.Windows.Forms.Label lblZoneInfo;
        private System.Windows.Forms.Label lblZoneSetting;
        private System.Windows.Forms.Panel pnlZoneList;
        private System.Windows.Forms.Panel pnlZoneInfo;
        private System.Windows.Forms.ListBox lstZones;
        private System.Windows.Forms.Label lblZoneName;
        private System.Windows.Forms.Label lblZoneDescription;
        private System.Windows.Forms.Label lblZoneRiskLevel;
        private System.Windows.Forms.ComboBox cmbZoneRiskLevel;
        private System.Windows.Forms.Label lblUseZone;
        private System.Windows.Forms.CheckBox chkUseZone;
        private System.Windows.Forms.TextBox txtZoneDescription;
        private System.Windows.Forms.TextBox txtZoneName;
    }
}
