namespace PPE_관제_시스템
{
    partial class US_PPEStandard
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
            this.btnPPESave = new System.Windows.Forms.Button();
            this.btnPPEReset = new System.Windows.Forms.Button();
            this.lblZoneList = new System.Windows.Forms.Label();
            this.lblPPESetting = new System.Windows.Forms.Label();
            this.pnlZoneList = new System.Windows.Forms.Panel();
            this.pnlPPESetting = new System.Windows.Forms.Panel();
            this.lblSetting = new System.Windows.Forms.Label();
            this.chkSafetyHelmet = new System.Windows.Forms.CheckBox();
            this.chkSafetyMask = new System.Windows.Forms.CheckBox();
            this.chkSafetyGloves = new System.Windows.Forms.CheckBox();
            this.lstPPE_ZoneList = new System.Windows.Forms.ListBox();
            this.pnlZoneList.SuspendLayout();
            this.pnlPPESetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPPESave
            // 
            this.btnPPESave.Location = new System.Drawing.Point(1096, 610);
            this.btnPPESave.Name = "btnPPESave";
            this.btnPPESave.Size = new System.Drawing.Size(120, 40);
            this.btnPPESave.TabIndex = 0;
            this.btnPPESave.Text = "저장";
            this.btnPPESave.UseVisualStyleBackColor = true;
            // 
            // btnPPEReset
            // 
            this.btnPPEReset.Location = new System.Drawing.Point(970, 610);
            this.btnPPEReset.Name = "btnPPEReset";
            this.btnPPEReset.Size = new System.Drawing.Size(120, 40);
            this.btnPPEReset.TabIndex = 1;
            this.btnPPEReset.Text = "초기화";
            this.btnPPEReset.UseVisualStyleBackColor = true;
            // 
            // lblZoneList
            // 
            this.lblZoneList.AutoSize = true;
            this.lblZoneList.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZoneList.Location = new System.Drawing.Point(200, 24);
            this.lblZoneList.Name = "lblZoneList";
            this.lblZoneList.Size = new System.Drawing.Size(139, 38);
            this.lblZoneList.TabIndex = 2;
            this.lblZoneList.Text = "구역 목록";
            // 
            // lblPPESetting
            // 
            this.lblPPESetting.AutoSize = true;
            this.lblPPESetting.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPPESetting.Location = new System.Drawing.Point(3, 3);
            this.lblPPESetting.Name = "lblPPESetting";
            this.lblPPESetting.Size = new System.Drawing.Size(162, 31);
            this.lblPPESetting.TabIndex = 11;
            this.lblPPESetting.Text = "PPE 기준 설정";
            // 
            // pnlZoneList
            // 
            this.pnlZoneList.BackColor = System.Drawing.SystemColors.Control;
            this.pnlZoneList.Controls.Add(this.lstPPE_ZoneList);
            this.pnlZoneList.Controls.Add(this.lblZoneList);
            this.pnlZoneList.Location = new System.Drawing.Point(39, 117);
            this.pnlZoneList.Name = "pnlZoneList";
            this.pnlZoneList.Size = new System.Drawing.Size(551, 445);
            this.pnlZoneList.TabIndex = 12;
            // 
            // pnlPPESetting
            // 
            this.pnlPPESetting.BackColor = System.Drawing.SystemColors.Control;
            this.pnlPPESetting.Controls.Add(this.lblSetting);
            this.pnlPPESetting.Controls.Add(this.chkSafetyHelmet);
            this.pnlPPESetting.Controls.Add(this.chkSafetyMask);
            this.pnlPPESetting.Controls.Add(this.chkSafetyGloves);
            this.pnlPPESetting.Location = new System.Drawing.Point(631, 117);
            this.pnlPPESetting.Name = "pnlPPESetting";
            this.pnlPPESetting.Size = new System.Drawing.Size(551, 445);
            this.pnlPPESetting.TabIndex = 13;
            // 
            // lblSetting
            // 
            this.lblSetting.AutoSize = true;
            this.lblSetting.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSetting.Location = new System.Drawing.Point(244, 24);
            this.lblSetting.Name = "lblSetting";
            this.lblSetting.Size = new System.Drawing.Size(73, 38);
            this.lblSetting.TabIndex = 5;
            this.lblSetting.Text = "설정";
            // 
            // chkSafetyHelmet
            // 
            this.chkSafetyHelmet.AutoSize = true;
            this.chkSafetyHelmet.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkSafetyHelmet.Location = new System.Drawing.Point(100, 102);
            this.chkSafetyHelmet.Name = "chkSafetyHelmet";
            this.chkSafetyHelmet.Size = new System.Drawing.Size(83, 27);
            this.chkSafetyHelmet.TabIndex = 6;
            this.chkSafetyHelmet.Text = "안전모";
            this.chkSafetyHelmet.UseVisualStyleBackColor = true;
            // 
            // chkSafetyMask
            // 
            this.chkSafetyMask.AutoSize = true;
            this.chkSafetyMask.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkSafetyMask.Location = new System.Drawing.Point(100, 190);
            this.chkSafetyMask.Name = "chkSafetyMask";
            this.chkSafetyMask.Size = new System.Drawing.Size(83, 27);
            this.chkSafetyMask.TabIndex = 8;
            this.chkSafetyMask.Text = "마스크";
            this.chkSafetyMask.UseVisualStyleBackColor = true;
            // 
            // chkSafetyGloves
            // 
            this.chkSafetyGloves.AutoSize = true;
            this.chkSafetyGloves.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkSafetyGloves.Location = new System.Drawing.Point(100, 146);
            this.chkSafetyGloves.Name = "chkSafetyGloves";
            this.chkSafetyGloves.Size = new System.Drawing.Size(66, 27);
            this.chkSafetyGloves.TabIndex = 7;
            this.chkSafetyGloves.Text = "장갑";
            this.chkSafetyGloves.UseVisualStyleBackColor = true;
            // 
            // lstPPE_ZoneList
            // 
            this.lstPPE_ZoneList.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lstPPE_ZoneList.FormattingEnabled = true;
            this.lstPPE_ZoneList.ItemHeight = 28;
            this.lstPPE_ZoneList.Items.AddRange(new object[] {
            "A구역 | 위험도 높음",
            "B구역 | 위험도 보통",
            "C구역 | 위험도 낮음"});
            this.lstPPE_ZoneList.Location = new System.Drawing.Point(21, 102);
            this.lstPPE_ZoneList.Name = "lstPPE_ZoneList";
            this.lstPPE_ZoneList.Size = new System.Drawing.Size(505, 228);
            this.lstPPE_ZoneList.TabIndex = 6;
            this.lstPPE_ZoneList.SelectedIndexChanged += new System.EventHandler(this.lstPPE_ZoneList_SelectedIndexChanged);
            // 
            // US_PPEStandard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.pnlPPESetting);
            this.Controls.Add(this.pnlZoneList);
            this.Controls.Add(this.lblPPESetting);
            this.Controls.Add(this.btnPPEReset);
            this.Controls.Add(this.btnPPESave);
            this.Name = "US_PPEStandard";
            this.Size = new System.Drawing.Size(1219, 653);
            this.Load += new System.EventHandler(this.US_PPEStandard_Load);
            this.pnlZoneList.ResumeLayout(false);
            this.pnlZoneList.PerformLayout();
            this.pnlPPESetting.ResumeLayout(false);
            this.pnlPPESetting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPPESave;
        private System.Windows.Forms.Button btnPPEReset;
        private System.Windows.Forms.Label lblZoneList;
        private System.Windows.Forms.Label lblPPESetting;
        private System.Windows.Forms.Panel pnlZoneList;
        private System.Windows.Forms.Panel pnlPPESetting;
        private System.Windows.Forms.Label lblSetting;
        private System.Windows.Forms.CheckBox chkSafetyHelmet;
        private System.Windows.Forms.CheckBox chkSafetyMask;
        private System.Windows.Forms.CheckBox chkSafetyGloves;
        private System.Windows.Forms.ListBox lstPPE_ZoneList;
    }
}
