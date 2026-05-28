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
            this.cmbCamera = new System.Windows.Forms.ComboBox();
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
            this.pnlFilterBar.BackColor = AppColors.SurfaceAlt;
            this.pnlFilterBar.Controls.Add(this.lblFilter);
            this.pnlFilterBar.Controls.Add(this.cmbViolation);
            this.pnlFilterBar.Controls.Add(this.cmbCamera);
            this.pnlFilterBar.Controls.Add(this.cmbZone);
            this.pnlFilterBar.Location = new System.Drawing.Point(20, 10);
            this.pnlFilterBar.Name = "pnlFilterBar";
            this.pnlFilterBar.Size = new System.Drawing.Size(1188, 70);
            this.pnlFilterBar.TabIndex = 0;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.lblFilter.ForeColor = AppColors.PrimaryDark;
            this.lblFilter.Location = new System.Drawing.Point(20, 25);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(57, 23);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "필터";
            // 
            // cmbViolation
            // 
            this.cmbViolation.BackColor = AppColors.Surface;
            this.cmbViolation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbViolation.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cmbViolation.ForeColor = AppColors.Text;
            this.cmbViolation.FormattingEnabled = true;
            this.cmbViolation.Items.AddRange(new object[] {
            "전체",
            "안전모 미착용",
            "안전화 미착용"});
            this.cmbViolation.Location = new System.Drawing.Point(820, 20);
            this.cmbViolation.Name = "cmbViolation";
            this.cmbViolation.Size = new System.Drawing.Size(130, 31);
            this.cmbViolation.TabIndex = 1;
            this.cmbViolation.Text = "위반 내용";
            // 
            // cmbCamera
            // 
            this.cmbCamera.BackColor = AppColors.Surface;
            this.cmbCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCamera.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cmbCamera.ForeColor = AppColors.Text;
            this.cmbCamera.FormattingEnabled = true;
            this.cmbCamera.Items.AddRange(new object[] {
            "전체",
            "Camera 1",
            "Camera 2"});
            this.cmbCamera.Location = new System.Drawing.Point(960, 20);
            this.cmbCamera.Name = "cmbCamera";
            this.cmbCamera.Size = new System.Drawing.Size(105, 31);
            this.cmbCamera.TabIndex = 2;
            this.cmbCamera.Text = "카메라";
            // 
            // cmbZone
            // 
            this.cmbZone.BackColor = AppColors.Surface;
            this.cmbZone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbZone.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cmbZone.ForeColor = AppColors.Text;
            this.cmbZone.FormattingEnabled = true;
            this.cmbZone.Items.AddRange(new object[] {
            "전체",
            "A구역",
            "B구역"});
            this.cmbZone.Location = new System.Drawing.Point(1075, 20);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(95, 31);
            this.cmbZone.TabIndex = 3;
            this.cmbZone.Text = "구역";
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.BackColor = AppColors.Surface;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.flpAlertsList);
            this.pnlMain.Location = new System.Drawing.Point(20, 90);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1188, 570);
            this.pnlMain.TabIndex = 1;
            // 
            // flpAlertsList
            // 
            this.flpAlertsList.AutoScroll = true;
            this.flpAlertsList.BackColor = AppColors.Surface;
            this.flpAlertsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAlertsList.Location = new System.Drawing.Point(0, 0);
            this.flpAlertsList.Name = "flpAlertsList";
            this.flpAlertsList.Padding = new System.Windows.Forms.Padding(10);
            this.flpAlertsList.Size = new System.Drawing.Size(1186, 568);
            this.flpAlertsList.TabIndex = 0;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFooter.BackColor = AppColors.Background;
            this.pnlFooter.Controls.Add(this.lnkPrev);
            this.pnlFooter.Controls.Add(this.lblPage);
            this.pnlFooter.Controls.Add(this.lnkNext);
            this.pnlFooter.Location = new System.Drawing.Point(20, 670);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1188, 60);
            this.pnlFooter.TabIndex = 2;
            // 
            // lnkPrev
            // 
            this.lnkPrev.ActiveLinkColor = AppColors.PrimaryDark;
            this.lnkPrev.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lnkPrev.AutoSize = true;
            this.lnkPrev.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lnkPrev.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkPrev.LinkColor = AppColors.PrimaryDark;
            this.lnkPrev.Location = new System.Drawing.Point(520, 18);
            this.lnkPrev.Name = "lnkPrev";
            this.lnkPrev.Size = new System.Drawing.Size(62, 25);
            this.lnkPrev.TabIndex = 0;
            this.lnkPrev.TabStop = true;
            this.lnkPrev.Text = "◀ 이전";
            this.lnkPrev.VisitedLinkColor = AppColors.PrimaryDark;
            this.lnkPrev.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPrev_LinkClicked);
            // 
            // lblPage
            // 
            this.lblPage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPage.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblPage.ForeColor = AppColors.Text;
            this.lblPage.Location = new System.Drawing.Point(595, 18);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(80, 25);
            this.lblPage.TabIndex = 1;
            this.lblPage.Text = "1 / 2";
            this.lblPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnkNext
            // 
            this.lnkNext.ActiveLinkColor = AppColors.PrimaryDark;
            this.lnkNext.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lnkNext.AutoSize = true;
            this.lnkNext.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lnkNext.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkNext.LinkColor = AppColors.PrimaryDark;
            this.lnkNext.Location = new System.Drawing.Point(685, 18);
            this.lnkNext.Name = "lnkNext";
            this.lnkNext.Size = new System.Drawing.Size(62, 25);
            this.lnkNext.TabIndex = 2;
            this.lnkNext.TabStop = true;
            this.lnkNext.Text = "다음 ▶";
            this.lnkNext.VisitedLinkColor = AppColors.PrimaryDark;
            this.lnkNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNext_LinkClicked);
            // 
            // US_AlertsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = AppColors.Background;
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFilterBar);
            this.Name = "US_AlertsForm";
            this.Size = new System.Drawing.Size(1228, 762);
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
        private System.Windows.Forms.ComboBox cmbCamera;
        private System.Windows.Forms.ComboBox cmbZone;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.FlowLayoutPanel flpAlertsList;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.LinkLabel lnkPrev;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.LinkLabel lnkNext;
    }
}