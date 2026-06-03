namespace PPE_관제_시스템
{
    partial class US_AlertsForm
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
            this.pnlFilterBar = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cmbViolation = new System.Windows.Forms.ComboBox();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.flpAlertsList = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lnkPrev = new System.Windows.Forms.LinkLabel();
            this.lblPage = new System.Windows.Forms.Label();
            this.lnkNext = new System.Windows.Forms.LinkLabel();
            this.pnlFilterBar.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilterBar
            // 
            this.pnlFilterBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilterBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlFilterBar.Controls.Add(this.lblFilter);
            this.pnlFilterBar.Controls.Add(this.cmbViolation);
            this.pnlFilterBar.Controls.Add(this.cmbZone);
            this.pnlFilterBar.Location = new System.Drawing.Point(25, 12);
            this.pnlFilterBar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFilterBar.Name = "pnlFilterBar";
            this.pnlFilterBar.Size = new System.Drawing.Size(1485, 84);
            this.pnlFilterBar.TabIndex = 0;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.lblFilter.Location = new System.Drawing.Point(25, 30);
            this.lblFilter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(52, 28);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "필터";
            // 
            // cmbViolation
            // 
            this.cmbViolation.BackColor = System.Drawing.Color.White;
            this.cmbViolation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbViolation.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cmbViolation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cmbViolation.FormattingEnabled = true;
            this.cmbViolation.Items.AddRange(new object[] {
            "전체",
            "안전모 미착용",
            "안전화 미착용"});
            this.cmbViolation.Location = new System.Drawing.Point(1036, 27);
            this.cmbViolation.Margin = new System.Windows.Forms.Padding(4);
            this.cmbViolation.Name = "cmbViolation";
            this.cmbViolation.Size = new System.Drawing.Size(162, 36);
            this.cmbViolation.TabIndex = 1;
            this.cmbViolation.Text = "위반 내용";
            // 
            // cmbZone
            // 
            this.cmbZone.BackColor = System.Drawing.Color.White;
            this.cmbZone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbZone.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cmbZone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cmbZone.FormattingEnabled = true;
            this.cmbZone.Items.AddRange(new object[] {
            "전체",
            "A구역",
            "B구역"});
            this.cmbZone.Location = new System.Drawing.Point(1251, 27);
            this.cmbZone.Margin = new System.Windows.Forms.Padding(4);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(118, 36);
            this.cmbZone.TabIndex = 3;
            this.cmbZone.Text = "구역";
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.flpAlertsList);
            this.pnlMain.Location = new System.Drawing.Point(25, 108);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1484, 684);
            this.pnlMain.TabIndex = 1;
            // 
            // flpAlertsList
            // 
            this.flpAlertsList.AutoScroll = true;
            this.flpAlertsList.BackColor = System.Drawing.Color.White;
            this.flpAlertsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAlertsList.Location = new System.Drawing.Point(0, 0);
            this.flpAlertsList.Margin = new System.Windows.Forms.Padding(4);
            this.flpAlertsList.Name = "flpAlertsList";
            this.flpAlertsList.Padding = new System.Windows.Forms.Padding(12);
            this.flpAlertsList.Size = new System.Drawing.Size(1482, 682);
            this.flpAlertsList.TabIndex = 0;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.lnkPrev);
            this.pnlFooter.Controls.Add(this.lblPage);
            this.pnlFooter.Controls.Add(this.lnkNext);
            this.pnlFooter.Location = new System.Drawing.Point(25, 804);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1485, 72);
            this.pnlFooter.TabIndex = 2;
            // 
            // lnkPrev
            // 
            this.lnkPrev.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.lnkPrev.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lnkPrev.AutoSize = true;
            this.lnkPrev.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lnkPrev.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkPrev.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.lnkPrev.Location = new System.Drawing.Point(650, 22);
            this.lnkPrev.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkPrev.Name = "lnkPrev";
            this.lnkPrev.Size = new System.Drawing.Size(87, 30);
            this.lnkPrev.TabIndex = 0;
            this.lnkPrev.TabStop = true;
            this.lnkPrev.Text = "◀ 이전";
            this.lnkPrev.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.lnkPrev.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPrev_LinkClicked);
            // 
            // lblPage
            // 
            this.lblPage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPage.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblPage.Location = new System.Drawing.Point(744, 22);
            this.lblPage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(100, 30);
            this.lblPage.TabIndex = 1;
            this.lblPage.Text = "1 / 2";
            this.lblPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnkNext
            // 
            this.lnkNext.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.lnkNext.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lnkNext.AutoSize = true;
            this.lnkNext.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lnkNext.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkNext.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.lnkNext.Location = new System.Drawing.Point(856, 22);
            this.lnkNext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkNext.Name = "lnkNext";
            this.lnkNext.Size = new System.Drawing.Size(87, 30);
            this.lnkNext.TabIndex = 2;
            this.lnkNext.TabStop = true;
            this.lnkNext.Text = "다음 ▶";
            this.lnkNext.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.lnkNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNext_LinkClicked);
            // 
            // US_AlertsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFilterBar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "US_AlertsForm";
            this.Size = new System.Drawing.Size(1535, 914);
            this.Load += new System.EventHandler(this.US_AlertsForm_Load);
            this.pnlFilterBar.ResumeLayout(false);
            this.pnlFilterBar.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilterBar;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbViolation;
        private System.Windows.Forms.ComboBox cmbZone;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.FlowLayoutPanel flpAlertsList;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.LinkLabel lnkPrev;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.LinkLabel lnkNext;
    }
}