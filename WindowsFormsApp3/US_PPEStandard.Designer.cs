namespace PPE_관제_시스템
{
    partial class US_PPEStandard
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
            this.lblPPESetting = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.grpZoneList = new System.Windows.Forms.GroupBox();
            this.lstPPE_ZoneList = new System.Windows.Forms.ListBox();
            this.grpPPESetting = new System.Windows.Forms.GroupBox();
            this.lblSettingHint = new System.Windows.Forms.Label();
            this.chkSafetyHelmet = new System.Windows.Forms.CheckBox();
            this.chkLeftGlove = new System.Windows.Forms.CheckBox();
            this.chkRightGlove = new System.Windows.Forms.CheckBox();
            this.chkSafetyMask = new System.Windows.Forms.CheckBox();
            this.pnlPPEButtons = new System.Windows.Forms.Panel();
            this.btnPPEReset = new System.Windows.Forms.Button();
            this.btnPPESave = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.grpZoneList.SuspendLayout();
            this.grpPPESetting.SuspendLayout();
            this.pnlPPEButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPPESetting
            // 
            this.lblPPESetting.AutoSize = true;
            this.lblPPESetting.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPPESetting.ForeColor = AppColors.Text;
            this.lblPPESetting.Location = new System.Drawing.Point(20, 10);
            this.lblPPESetting.Name = "lblPPESetting";
            this.lblPPESetting.Size = new System.Drawing.Size(170, 31);
            this.lblPPESetting.TabIndex = 0;
            this.lblPPESetting.Text = "PPE 기준 설정";
            // 
            // tlpMain
            // 
            this.tlpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMain.BackColor = AppColors.Background;
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.grpZoneList, 0, 0);
            this.tlpMain.Controls.Add(this.grpPPESetting, 1, 0);
            this.tlpMain.Location = new System.Drawing.Point(20, 50);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1179, 593);
            this.tlpMain.TabIndex = 1;
            // 
            // grpZoneList
            // 
            this.grpZoneList.BackColor = AppColors.Surface;
            this.grpZoneList.Controls.Add(this.lstPPE_ZoneList);
            this.grpZoneList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpZoneList.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grpZoneList.ForeColor = AppColors.PrimaryDark;
            this.grpZoneList.Location = new System.Drawing.Point(3, 3);
            this.grpZoneList.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.grpZoneList.Name = "grpZoneList";
            this.grpZoneList.Size = new System.Drawing.Size(578, 587);
            this.grpZoneList.TabIndex = 0;
            this.grpZoneList.TabStop = false;
            this.grpZoneList.Text = "구역 목록";
            // 
            // lstPPE_ZoneList
            // 
            this.lstPPE_ZoneList.BackColor = AppColors.Surface;
            this.lstPPE_ZoneList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstPPE_ZoneList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPPE_ZoneList.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lstPPE_ZoneList.ForeColor = AppColors.Text;
            this.lstPPE_ZoneList.FormattingEnabled = true;
            this.lstPPE_ZoneList.ItemHeight = 28;
            this.lstPPE_ZoneList.Location = new System.Drawing.Point(3, 30);
            this.lstPPE_ZoneList.Name = "lstPPE_ZoneList";
            this.lstPPE_ZoneList.Padding = new System.Windows.Forms.Padding(15);
            this.lstPPE_ZoneList.Size = new System.Drawing.Size(572, 554);
            this.lstPPE_ZoneList.TabIndex = 0;
            this.lstPPE_ZoneList.SelectedIndexChanged += new System.EventHandler(this.lstPPE_ZoneList_SelectedIndexChanged);
            // 
            // grpPPESetting
            // 
            this.grpPPESetting.BackColor = AppColors.Surface;
            this.grpPPESetting.Controls.Add(this.lblSettingHint);
            this.grpPPESetting.Controls.Add(this.chkSafetyHelmet);
            this.grpPPESetting.Controls.Add(this.chkSafetyMask);
            this.grpPPESetting.Controls.Add(this.chkLeftGlove);
            this.grpPPESetting.Controls.Add(this.chkRightGlove);
            this.grpPPESetting.Controls.Add(this.pnlPPEButtons);
            this.grpPPESetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPPESetting.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grpPPESetting.ForeColor = AppColors.PrimaryDark;
            this.grpPPESetting.Location = new System.Drawing.Point(592, 3);
            this.grpPPESetting.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.grpPPESetting.Name = "grpPPESetting";
            this.grpPPESetting.Size = new System.Drawing.Size(584, 587);
            this.grpPPESetting.TabIndex = 1;
            this.grpPPESetting.TabStop = false;
            this.grpPPESetting.Text = "PPE 기준 설정";
            // 
            // lblSettingHint
            // 
            this.lblSettingHint.AutoSize = true;
            this.lblSettingHint.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSettingHint.ForeColor = AppColors.TextSecondary;
            this.lblSettingHint.Location = new System.Drawing.Point(30, 45);
            this.lblSettingHint.Name = "lblSettingHint";
            this.lblSettingHint.Size = new System.Drawing.Size(316, 23);
            this.lblSettingHint.TabIndex = 0;
            this.lblSettingHint.Text = "이 구역에서 필수로 착용해야 할 장비를 선택하세요.";
            // 
            // chkSafetyHelmet
            // 
            this.chkSafetyHelmet.AutoSize = true;
            this.chkSafetyHelmet.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkSafetyHelmet.ForeColor = AppColors.Text;
            this.chkSafetyHelmet.Location = new System.Drawing.Point(40, 110);
            this.chkSafetyHelmet.Name = "chkSafetyHelmet";
            this.chkSafetyHelmet.Size = new System.Drawing.Size(87, 28);
            this.chkSafetyHelmet.TabIndex = 1;
            this.chkSafetyHelmet.Text = "안전모";
            this.chkSafetyHelmet.UseVisualStyleBackColor = true;
            // 
            // chkLeftGlove
            // 
            this.chkLeftGlove.AutoSize = true;
            this.chkLeftGlove.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkLeftGlove.ForeColor = AppColors.Text;
            this.chkLeftGlove.Location = new System.Drawing.Point(40, 220);
            this.chkLeftGlove.Name = "chkLeftGlove";
            this.chkLeftGlove.Size = new System.Drawing.Size(116, 29);
            this.chkLeftGlove.TabIndex = 3;
            this.chkLeftGlove.Text = "왼손 장갑";
            this.chkLeftGlove.UseVisualStyleBackColor = true;
            // 
            // chkRightGlove
            // 
            this.chkRightGlove.AutoSize = true;
            this.chkRightGlove.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkRightGlove.ForeColor = AppColors.Text;
            this.chkRightGlove.Location = new System.Drawing.Point(40, 275);
            this.chkRightGlove.Name = "chkRightGlove";
            this.chkRightGlove.Size = new System.Drawing.Size(133, 29);
            this.chkRightGlove.TabIndex = 4;
            this.chkRightGlove.Text = "오른손 장갑";
            this.chkRightGlove.UseVisualStyleBackColor = true;
            // 
            // chkSafetyMask
            // 
            this.chkSafetyMask.AutoSize = true;
            this.chkSafetyMask.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkSafetyMask.ForeColor = AppColors.Text;
            this.chkSafetyMask.Location = new System.Drawing.Point(40, 165);
            this.chkSafetyMask.Name = "chkSafetyMask";
            this.chkSafetyMask.Size = new System.Drawing.Size(87, 28);
            this.chkSafetyMask.TabIndex = 2;
            this.chkSafetyMask.Text = "마스크";
            this.chkSafetyMask.UseVisualStyleBackColor = true;
            // 
            // pnlPPEButtons
            // 
            this.pnlPPEButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPPEButtons.BackColor = AppColors.Surface;
            this.pnlPPEButtons.Controls.Add(this.btnPPEReset);
            this.pnlPPEButtons.Controls.Add(this.btnPPESave);
            this.pnlPPEButtons.Location = new System.Drawing.Point(20, 520);
            this.pnlPPEButtons.Name = "pnlPPEButtons";
            this.pnlPPEButtons.Size = new System.Drawing.Size(544, 55);
            this.pnlPPEButtons.TabIndex = 4;
            // 
            // btnPPEReset
            // 
            this.btnPPEReset.BackColor = AppColors.Surface;
            this.btnPPEReset.FlatAppearance.BorderColor = AppColors.Primary;
            this.btnPPEReset.FlatAppearance.BorderSize = 1;
            this.btnPPEReset.FlatAppearance.MouseOverBackColor = AppColors.PrimaryLight;
            this.btnPPEReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPPEReset.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular);
            this.btnPPEReset.ForeColor = AppColors.PrimaryDark;
            this.btnPPEReset.Location = new System.Drawing.Point(248, 5);
            this.btnPPEReset.Name = "btnPPEReset";
            this.btnPPEReset.Size = new System.Drawing.Size(140, 45);
            this.btnPPEReset.TabIndex = 0;
            this.btnPPEReset.Text = "초기화";
            this.btnPPEReset.UseVisualStyleBackColor = false;
            this.btnPPEReset.Click += new System.EventHandler(this.btnPPEReset_Click);
            // 
            // btnPPESave
            // 
            this.btnPPESave.BackColor = AppColors.Primary;
            this.btnPPESave.FlatAppearance.BorderSize = 0;
            this.btnPPESave.FlatAppearance.MouseOverBackColor = AppColors.PrimaryDark;
            this.btnPPESave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPPESave.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnPPESave.ForeColor = AppColors.TextOnPrimary;
            this.btnPPESave.Location = new System.Drawing.Point(398, 5);
            this.btnPPESave.Name = "btnPPESave";
            this.btnPPESave.Size = new System.Drawing.Size(140, 45);
            this.btnPPESave.TabIndex = 1;
            this.btnPPESave.Text = "저장";
            this.btnPPESave.UseVisualStyleBackColor = false;
            this.btnPPESave.Click += new System.EventHandler(this.btnPPESave_Click);
            // 
            // US_PPEStandard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = AppColors.Background;
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.lblPPESetting);
            this.Name = "US_PPEStandard";
            this.Padding = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.Size = new System.Drawing.Size(1219, 653);
            this.Load += new System.EventHandler(this.US_PPEStandard_Load);
            this.tlpMain.ResumeLayout(false);
            this.grpZoneList.ResumeLayout(false);
            this.grpPPESetting.ResumeLayout(false);
            this.grpPPESetting.PerformLayout();
            this.pnlPPEButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblPPESetting;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.GroupBox grpZoneList;
        private System.Windows.Forms.ListBox lstPPE_ZoneList;
        private System.Windows.Forms.GroupBox grpPPESetting;
        private System.Windows.Forms.Label lblSettingHint;
        private System.Windows.Forms.CheckBox chkSafetyHelmet;
        private System.Windows.Forms.CheckBox chkSafetyMask;
        private System.Windows.Forms.CheckBox chkLeftGlove;
        private System.Windows.Forms.CheckBox chkRightGlove;
        private System.Windows.Forms.Panel pnlPPEButtons;
        private System.Windows.Forms.Button btnPPEReset;
        private System.Windows.Forms.Button btnPPESave;
    }
}