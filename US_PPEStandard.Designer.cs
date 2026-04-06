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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbZoneList = new System.Windows.Forms.ComboBox();
            this.lblPPEStandard = new System.Windows.Forms.Label();
            this.chkHelmet = new System.Windows.Forms.CheckBox();
            this.chkGloves = new System.Windows.Forms.CheckBox();
            this.chkVest = new System.Windows.Forms.CheckBox();
            this.chkSafetyBoots = new System.Windows.Forms.CheckBox();
            this.chkGoggles = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnPPESave
            // 
            this.btnPPESave.Location = new System.Drawing.Point(655, 425);
            this.btnPPESave.Name = "btnPPESave";
            this.btnPPESave.Size = new System.Drawing.Size(120, 40);
            this.btnPPESave.TabIndex = 0;
            this.btnPPESave.Text = "저장";
            this.btnPPESave.UseVisualStyleBackColor = true;
            // 
            // btnPPEReset
            // 
            this.btnPPEReset.Location = new System.Drawing.Point(781, 425);
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
            this.lblZoneList.Location = new System.Drawing.Point(120, 31);
            this.lblZoneList.Name = "lblZoneList";
            this.lblZoneList.Size = new System.Drawing.Size(167, 38);
            this.lblZoneList.TabIndex = 2;
            this.lblZoneList.Text = "구역 리스트";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(431, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 434);
            this.panel1.TabIndex = 3;
            // 
            // cmbZoneList
            // 
            this.cmbZoneList.FormattingEnabled = true;
            this.cmbZoneList.Location = new System.Drawing.Point(87, 104);
            this.cmbZoneList.Name = "cmbZoneList";
            this.cmbZoneList.Size = new System.Drawing.Size(223, 23);
            this.cmbZoneList.TabIndex = 4;
            this.cmbZoneList.Text = "구역 리스트";
            // 
            // lblPPEStandard
            // 
            this.lblPPEStandard.AutoSize = true;
            this.lblPPEStandard.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPPEStandard.Location = new System.Drawing.Point(604, 31);
            this.lblPPEStandard.Name = "lblPPEStandard";
            this.lblPPEStandard.Size = new System.Drawing.Size(198, 38);
            this.lblPPEStandard.TabIndex = 5;
            this.lblPPEStandard.Text = "PPE 기준 설정";
            // 
            // chkHelmet
            // 
            this.chkHelmet.AutoSize = true;
            this.chkHelmet.Location = new System.Drawing.Point(579, 140);
            this.chkHelmet.Name = "chkHelmet";
            this.chkHelmet.Size = new System.Drawing.Size(73, 19);
            this.chkHelmet.TabIndex = 6;
            this.chkHelmet.Text = "Helmet";
            this.chkHelmet.UseVisualStyleBackColor = true;
            // 
            // chkGloves
            // 
            this.chkGloves.AutoSize = true;
            this.chkGloves.Location = new System.Drawing.Point(739, 138);
            this.chkGloves.Name = "chkGloves";
            this.chkGloves.Size = new System.Drawing.Size(76, 19);
            this.chkGloves.TabIndex = 7;
            this.chkGloves.Text = "Gloves";
            this.chkGloves.UseVisualStyleBackColor = true;
            // 
            // chkVest
            // 
            this.chkVest.AutoSize = true;
            this.chkVest.Location = new System.Drawing.Point(579, 204);
            this.chkVest.Name = "chkVest";
            this.chkVest.Size = new System.Drawing.Size(57, 19);
            this.chkVest.TabIndex = 8;
            this.chkVest.Text = "Vest";
            this.chkVest.UseVisualStyleBackColor = true;
            // 
            // chkSafetyBoots
            // 
            this.chkSafetyBoots.AutoSize = true;
            this.chkSafetyBoots.Location = new System.Drawing.Point(739, 204);
            this.chkSafetyBoots.Name = "chkSafetyBoots";
            this.chkSafetyBoots.Size = new System.Drawing.Size(116, 19);
            this.chkSafetyBoots.TabIndex = 9;
            this.chkSafetyBoots.Text = "Safety Boots";
            this.chkSafetyBoots.UseVisualStyleBackColor = true;
            // 
            // chkGoggles
            // 
            this.chkGoggles.AutoSize = true;
            this.chkGoggles.Location = new System.Drawing.Point(579, 270);
            this.chkGoggles.Name = "chkGoggles";
            this.chkGoggles.Size = new System.Drawing.Size(84, 19);
            this.chkGoggles.TabIndex = 10;
            this.chkGoggles.Text = "Goggles";
            this.chkGoggles.UseVisualStyleBackColor = true;
            // 
            // US_PPEStandard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.chkGoggles);
            this.Controls.Add(this.chkSafetyBoots);
            this.Controls.Add(this.chkVest);
            this.Controls.Add(this.chkGloves);
            this.Controls.Add(this.chkHelmet);
            this.Controls.Add(this.lblPPEStandard);
            this.Controls.Add(this.cmbZoneList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblZoneList);
            this.Controls.Add(this.btnPPEReset);
            this.Controls.Add(this.btnPPESave);
            this.Name = "US_PPEStandard";
            this.Size = new System.Drawing.Size(945, 487);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPPESave;
        private System.Windows.Forms.Button btnPPEReset;
        private System.Windows.Forms.Label lblZoneList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbZoneList;
        private System.Windows.Forms.Label lblPPEStandard;
        private System.Windows.Forms.CheckBox chkHelmet;
        private System.Windows.Forms.CheckBox chkGloves;
        private System.Windows.Forms.CheckBox chkVest;
        private System.Windows.Forms.CheckBox chkSafetyBoots;
        private System.Windows.Forms.CheckBox chkGoggles;
    }
}
