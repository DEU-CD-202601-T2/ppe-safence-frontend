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
            this.pnlFilterBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlFilterBar.Controls.Add(this.lblFilterDate);
            this.pnlFilterBar.Controls.Add(this.dtpDateStart);
            this.pnlFilterBar.Controls.Add(this.lblTilde);
            this.pnlFilterBar.Controls.Add(this.dtpDateEnd);
            this.pnlFilterBar.Controls.Add(this.cmbTime);
            this.pnlFilterBar.Controls.Add(this.cmbState);
            this.pnlFilterBar.Controls.Add(this.cmbZone);
            this.pnlFilterBar.Location = new System.Drawing.Point(25, 12);
            this.pnlFilterBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlFilterBar.Name = "pnlFilterBar";
            this.pnlFilterBar.Size = new System.Drawing.Size(1485, 84);
            this.pnlFilterBar.TabIndex = 0;
            // 
            // lblFilterDate
            // 
            this.lblFilterDate.AutoSize = true;
            this.lblFilterDate.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.lblFilterDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.lblFilterDate.Location = new System.Drawing.Point(25, 30);
            this.lblFilterDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilterDate.Name = "lblFilterDate";
            this.lblFilterDate.Size = new System.Drawing.Size(52, 28);
            this.lblFilterDate.TabIndex = 0;
            this.lblFilterDate.Text = "기간";
            // 
            // dtpDateStart
            // 
            this.dtpDateStart.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.dtpDateStart.Location = new System.Drawing.Point(100, 24);
            this.dtpDateStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDateStart.Name = "dtpDateStart";
            this.dtpDateStart.Size = new System.Drawing.Size(224, 34);
            this.dtpDateStart.TabIndex = 1;
            // 
            // lblTilde
            // 
            this.lblTilde.AutoSize = true;
            this.lblTilde.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lblTilde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblTilde.Location = new System.Drawing.Point(331, 29);
            this.lblTilde.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTilde.Name = "lblTilde";
            this.lblTilde.Size = new System.Drawing.Size(28, 30);
            this.lblTilde.TabIndex = 2;
            this.lblTilde.Text = "~";
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.dtpDateEnd.Location = new System.Drawing.Point(362, 24);
            this.dtpDateEnd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(224, 34);
            this.dtpDateEnd.TabIndex = 3;
            // 
            // cmbTime
            // 
            this.cmbTime.BackColor = System.Drawing.Color.White;
            this.cmbTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTime.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cmbTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cmbTime.FormattingEnabled = true;
            this.cmbTime.Location = new System.Drawing.Point(931, 24);
            this.cmbTime.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTime.Name = "cmbTime";
            this.cmbTime.Size = new System.Drawing.Size(136, 36);
            this.cmbTime.TabIndex = 4;
            this.cmbTime.Text = "시간";
            // 
            // cmbState
            // 
            this.cmbState.BackColor = System.Drawing.Color.White;
            this.cmbState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbState.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cmbState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(1106, 26);
            this.cmbState.Margin = new System.Windows.Forms.Padding(2);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(136, 36);
            this.cmbState.TabIndex = 5;
            this.cmbState.Text = "상태";
            // 
            // cmbZone
            // 
            this.cmbZone.BackColor = System.Drawing.Color.White;
            this.cmbZone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbZone.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cmbZone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cmbZone.FormattingEnabled = true;
            this.cmbZone.Location = new System.Drawing.Point(1281, 26);
            this.cmbZone.Margin = new System.Windows.Forms.Padding(2);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(136, 36);
            this.cmbZone.TabIndex = 6;
            this.cmbZone.Text = "구역";
            // 
            // pnlViolationMain
            // 
            this.pnlViolationMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlViolationMain.BackColor = System.Drawing.Color.White;
            this.pnlViolationMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlViolationMain.Controls.Add(this.flpViolationList);
            this.pnlViolationMain.Location = new System.Drawing.Point(25, 108);
            this.pnlViolationMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlViolationMain.Name = "pnlViolationMain";
            this.pnlViolationMain.Size = new System.Drawing.Size(1484, 684);
            this.pnlViolationMain.TabIndex = 1;
            // 
            // flpViolationList
            // 
            this.flpViolationList.AutoScroll = true;
            this.flpViolationList.BackColor = System.Drawing.Color.White;
            this.flpViolationList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpViolationList.Location = new System.Drawing.Point(0, 0);
            this.flpViolationList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flpViolationList.Name = "flpViolationList";
            this.flpViolationList.Padding = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.flpViolationList.Size = new System.Drawing.Size(1482, 682);
            this.flpViolationList.TabIndex = 0;
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
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            // US_ViolationManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlViolationMain);
            this.Controls.Add(this.pnlFilterBar);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "US_ViolationManagementForm";
            this.Size = new System.Drawing.Size(1535, 914);
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