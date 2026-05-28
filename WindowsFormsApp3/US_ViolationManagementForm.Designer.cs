namespace PPE_관제_시스템
{
    partial class US_ViolationManagementForm
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
            this.lblFilterDate = new System.Windows.Forms.Label();
            this.dtpDateStart = new System.Windows.Forms.DateTimePicker();
            this.lblTilde = new System.Windows.Forms.Label();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.cmbTime = new System.Windows.Forms.ComboBox();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.pnlViolationMain = new System.Windows.Forms.Panel();
            this.flpViolationList = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lnkPrev = new System.Windows.Forms.LinkLabel();
            this.lblPage = new System.Windows.Forms.Label();
            this.lnkNext = new System.Windows.Forms.LinkLabel();
            this.pnlFilterBar.SuspendLayout();
            this.pnlViolationMain.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilterBar
            // 
            this.pnlFilterBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilterBar.BackColor = AppColors.SurfaceAlt;
            this.pnlFilterBar.Controls.Add(this.lblFilterDate);
            this.pnlFilterBar.Controls.Add(this.dtpDateStart);
            this.pnlFilterBar.Controls.Add(this.lblTilde);
            this.pnlFilterBar.Controls.Add(this.dtpDateEnd);
            this.pnlFilterBar.Controls.Add(this.cmbTime);
            this.pnlFilterBar.Controls.Add(this.cmbState);
            this.pnlFilterBar.Controls.Add(this.cmbZone);
            this.pnlFilterBar.Location = new System.Drawing.Point(20, 10);
            this.pnlFilterBar.Name = "pnlFilterBar";
            this.pnlFilterBar.Size = new System.Drawing.Size(1188, 70);
            this.pnlFilterBar.TabIndex = 0;
            // 
            // lblFilterDate
            // 
            this.lblFilterDate.AutoSize = true;
            this.lblFilterDate.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.lblFilterDate.ForeColor = AppColors.PrimaryDark;
            this.lblFilterDate.Location = new System.Drawing.Point(20, 25);
            this.lblFilterDate.Name = "lblFilterDate";
            this.lblFilterDate.Size = new System.Drawing.Size(49, 23);
            this.lblFilterDate.TabIndex = 0;
            this.lblFilterDate.Text = "기간";
            // 
            // dtpDateStart
            // 
            this.dtpDateStart.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.dtpDateStart.Location = new System.Drawing.Point(80, 20);
            this.dtpDateStart.Name = "dtpDateStart";
            this.dtpDateStart.Size = new System.Drawing.Size(180, 30);
            this.dtpDateStart.TabIndex = 1;
            // 
            // lblTilde
            // 
            this.lblTilde.AutoSize = true;
            this.lblTilde.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lblTilde.ForeColor = AppColors.Text;
            this.lblTilde.Location = new System.Drawing.Point(265, 24);
            this.lblTilde.Name = "lblTilde";
            this.lblTilde.Size = new System.Drawing.Size(19, 25);
            this.lblTilde.TabIndex = 2;
            this.lblTilde.Text = "~";
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.dtpDateEnd.Location = new System.Drawing.Point(290, 20);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(180, 30);
            this.dtpDateEnd.TabIndex = 3;
            // 
            // cmbTime
            // 
            this.cmbTime.BackColor = AppColors.Surface;
            this.cmbTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTime.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cmbTime.ForeColor = AppColors.Text;
            this.cmbTime.FormattingEnabled = true;
            this.cmbTime.Location = new System.Drawing.Point(820, 20);
            this.cmbTime.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTime.Name = "cmbTime";
            this.cmbTime.Size = new System.Drawing.Size(110, 31);
            this.cmbTime.TabIndex = 4;
            this.cmbTime.Text = "시간";
            // 
            // cmbState
            // 
            this.cmbState.BackColor = AppColors.Surface;
            this.cmbState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbState.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cmbState.ForeColor = AppColors.Text;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(940, 20);
            this.cmbState.Margin = new System.Windows.Forms.Padding(2);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(110, 31);
            this.cmbState.TabIndex = 5;
            this.cmbState.Text = "상태";
            // 
            // cmbZone
            // 
            this.cmbZone.BackColor = AppColors.Surface;
            this.cmbZone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbZone.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cmbZone.ForeColor = AppColors.Text;
            this.cmbZone.FormattingEnabled = true;
            this.cmbZone.Location = new System.Drawing.Point(1060, 20);
            this.cmbZone.Margin = new System.Windows.Forms.Padding(2);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(110, 31);
            this.cmbZone.TabIndex = 6;
            this.cmbZone.Text = "구역";
            // 
            // pnlViolationMain
            // 
            this.pnlViolationMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlViolationMain.BackColor = AppColors.Surface;
            this.pnlViolationMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlViolationMain.Controls.Add(this.flpViolationList);
            this.pnlViolationMain.Location = new System.Drawing.Point(20, 90);
            this.pnlViolationMain.Name = "pnlViolationMain";
            this.pnlViolationMain.Size = new System.Drawing.Size(1188, 570);
            this.pnlViolationMain.TabIndex = 1;
            // 
            // flpViolationList
            // 
            this.flpViolationList.AutoScroll = true;
            this.flpViolationList.BackColor = AppColors.Surface;
            this.flpViolationList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpViolationList.Location = new System.Drawing.Point(0, 0);
            this.flpViolationList.Name = "flpViolationList";
            this.flpViolationList.Padding = new System.Windows.Forms.Padding(10);
            this.flpViolationList.Size = new System.Drawing.Size(1186, 568);
            this.flpViolationList.TabIndex = 0;
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
            this.lnkPrev.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular);
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
            this.lnkNext.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular);
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
            // US_ViolationManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = AppColors.Background;
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlViolationMain);
            this.Controls.Add(this.pnlFilterBar);
            this.Name = "US_ViolationManagementForm";
            this.Size = new System.Drawing.Size(1228, 762);
            this.Load += new System.EventHandler(this.US_ViolationManagementForm_Load);
            this.pnlFilterBar.ResumeLayout(false);
            this.pnlFilterBar.PerformLayout();
            this.pnlViolationMain.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlFilterBar;
        private System.Windows.Forms.Label lblFilterDate;
        private System.Windows.Forms.DateTimePicker dtpDateStart;
        private System.Windows.Forms.Label lblTilde;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.ComboBox cmbTime;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.ComboBox cmbZone;
        private System.Windows.Forms.Panel pnlViolationMain;
        private System.Windows.Forms.FlowLayoutPanel flpViolationList;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.LinkLabel lnkPrev;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.LinkLabel lnkNext;
    }
}