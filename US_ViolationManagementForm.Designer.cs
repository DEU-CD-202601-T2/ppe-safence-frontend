namespace PPE_관제_시스템
{
    partial class US_ViolationManagementForm
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
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblPage = new System.Windows.Forms.Label();
            this.lnkNext = new System.Windows.Forms.LinkLabel();
            this.lnkPrev = new System.Windows.Forms.LinkLabel();
            this.pnlViolationMain = new System.Windows.Forms.Panel();
            this.flpViolationList = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbTime = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpDateStart = new System.Windows.Forms.DateTimePicker();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.pnlFooter.SuspendLayout();
            this.pnlViolationMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.lblPage);
            this.pnlFooter.Controls.Add(this.lnkNext);
            this.pnlFooter.Controls.Add(this.lnkPrev);
            this.pnlFooter.Location = new System.Drawing.Point(-3, 644);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1235, 94);
            this.pnlFooter.TabIndex = 26;
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPage.Location = new System.Drawing.Point(578, 30);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(59, 28);
            this.lblPage.TabIndex = 5;
            this.lblPage.Text = "1 / 2";
            // 
            // lnkNext
            // 
            this.lnkNext.AutoSize = true;
            this.lnkNext.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lnkNext.LinkColor = System.Drawing.Color.Black;
            this.lnkNext.Location = new System.Drawing.Point(674, 30);
            this.lnkNext.Name = "lnkNext";
            this.lnkNext.Size = new System.Drawing.Size(64, 28);
            this.lnkNext.TabIndex = 4;
            this.lnkNext.TabStop = true;
            this.lnkNext.Text = "[다음]";
            this.lnkNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNext_LinkClicked);
            // 
            // lnkPrev
            // 
            this.lnkPrev.AutoSize = true;
            this.lnkPrev.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lnkPrev.LinkColor = System.Drawing.Color.Black;
            this.lnkPrev.Location = new System.Drawing.Point(481, 30);
            this.lnkPrev.Name = "lnkPrev";
            this.lnkPrev.Size = new System.Drawing.Size(64, 28);
            this.lnkPrev.TabIndex = 3;
            this.lnkPrev.TabStop = true;
            this.lnkPrev.Text = "[이전]";
            this.lnkPrev.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPrev_LinkClicked);
            // 
            // pnlViolationMain
            // 
            this.pnlViolationMain.Controls.Add(this.flpViolationList);
            this.pnlViolationMain.Location = new System.Drawing.Point(-3, 69);
            this.pnlViolationMain.Name = "pnlViolationMain";
            this.pnlViolationMain.Size = new System.Drawing.Size(1235, 557);
            this.pnlViolationMain.TabIndex = 25;
            // 
            // flpViolationList
            // 
            this.flpViolationList.AutoScroll = true;
            this.flpViolationList.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.flpViolationList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpViolationList.Location = new System.Drawing.Point(0, 0);
            this.flpViolationList.Name = "flpViolationList";
            this.flpViolationList.Size = new System.Drawing.Size(1235, 557);
            this.flpViolationList.TabIndex = 0;
            // 
            // cmbTime
            // 
            this.cmbTime.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbTime.FormattingEnabled = true;
            this.cmbTime.Location = new System.Drawing.Point(884, 24);
            this.cmbTime.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTime.Name = "cmbTime";
            this.cmbTime.Size = new System.Drawing.Size(98, 31);
            this.cmbTime.TabIndex = 24;
            this.cmbTime.Text = "시간";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(628, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "~";
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpDateEnd.Location = new System.Drawing.Point(651, 25);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(217, 30);
            this.dtpDateEnd.TabIndex = 22;
            // 
            // dtpDateStart
            // 
            this.dtpDateStart.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpDateStart.Location = new System.Drawing.Point(407, 25);
            this.dtpDateStart.Name = "dtpDateStart";
            this.dtpDateStart.Size = new System.Drawing.Size(214, 30);
            this.dtpDateStart.TabIndex = 21;
            // 
            // cmbZone
            // 
            this.cmbZone.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbZone.FormattingEnabled = true;
            this.cmbZone.Location = new System.Drawing.Point(1110, 24);
            this.cmbZone.Margin = new System.Windows.Forms.Padding(2);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(98, 31);
            this.cmbZone.TabIndex = 20;
            this.cmbZone.Text = "구역";
            // 
            // cmbState
            // 
            this.cmbState.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(996, 25);
            this.cmbState.Margin = new System.Windows.Forms.Padding(2);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(98, 31);
            this.cmbState.TabIndex = 19;
            this.cmbState.Text = "상태";
            // 
            // US_ViolationManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlViolationMain);
            this.Controls.Add(this.cmbTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDateEnd);
            this.Controls.Add(this.dtpDateStart);
            this.Controls.Add(this.cmbZone);
            this.Controls.Add(this.cmbState);
            this.Name = "US_ViolationManagementForm";
            this.Size = new System.Drawing.Size(1228, 762);
            this.Load += new System.EventHandler(this.US_ViolationManagementForm_Load);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlViolationMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.LinkLabel lnkNext;
        private System.Windows.Forms.LinkLabel lnkPrev;
        private System.Windows.Forms.Panel pnlViolationMain;
        private System.Windows.Forms.FlowLayoutPanel flpViolationList;
        private System.Windows.Forms.ComboBox cmbTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.DateTimePicker dtpDateStart;
        private System.Windows.Forms.ComboBox cmbZone;
        private System.Windows.Forms.ComboBox cmbState;
    }
}
