namespace PPE_관제_시스템
{
    partial class US_AlertsForm
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
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.cmbCamera = new System.Windows.Forms.ComboBox();
            this.cmbViolation = new System.Windows.Forms.ComboBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblPage = new System.Windows.Forms.Label();
            this.lnkNext = new System.Windows.Forms.LinkLabel();
            this.lnkPrev = new System.Windows.Forms.LinkLabel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.flpAlertsList = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFooter.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbZone
            // 
            this.cmbZone.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbZone.FormattingEnabled = true;
            this.cmbZone.Items.AddRange(new object[] {
            "전체",
            "A구역",
            "B구역"});
            this.cmbZone.Location = new System.Drawing.Point(1090, 19);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(121, 31);
            this.cmbZone.TabIndex = 20;
            this.cmbZone.Text = "구역";
            // 
            // cmbCamera
            // 
            this.cmbCamera.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbCamera.FormattingEnabled = true;
            this.cmbCamera.Items.AddRange(new object[] {
            "전체",
            "Camera 1",
            "Camera 2"});
            this.cmbCamera.Location = new System.Drawing.Point(963, 19);
            this.cmbCamera.Name = "cmbCamera";
            this.cmbCamera.Size = new System.Drawing.Size(121, 31);
            this.cmbCamera.TabIndex = 19;
            this.cmbCamera.Text = "카메라";
            // 
            // cmbViolation
            // 
            this.cmbViolation.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbViolation.FormattingEnabled = true;
            this.cmbViolation.Items.AddRange(new object[] {
            "전체",
            "안전모 미착용",
            "안전화 미착용"});
            this.cmbViolation.Location = new System.Drawing.Point(836, 19);
            this.cmbViolation.Name = "cmbViolation";
            this.cmbViolation.Size = new System.Drawing.Size(121, 31);
            this.cmbViolation.TabIndex = 18;
            this.cmbViolation.Text = "위반 내용";
            // 
            // pnlFooter
            // 
            this.pnlFooter.AutoScroll = true;
            this.pnlFooter.Controls.Add(this.lblPage);
            this.pnlFooter.Controls.Add(this.lnkNext);
            this.pnlFooter.Controls.Add(this.lnkPrev);
            this.pnlFooter.Location = new System.Drawing.Point(-3, 650);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1235, 94);
            this.pnlFooter.TabIndex = 17;
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
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.Controls.Add(this.flpAlertsList);
            this.pnlMain.Location = new System.Drawing.Point(-3, 61);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1235, 557);
            this.pnlMain.TabIndex = 16;
            // 
            // flpAlertsList
            // 
            this.flpAlertsList.AutoScroll = true;
            this.flpAlertsList.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.flpAlertsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAlertsList.Location = new System.Drawing.Point(0, 0);
            this.flpAlertsList.Name = "flpAlertsList";
            this.flpAlertsList.Size = new System.Drawing.Size(1235, 557);
            this.flpAlertsList.TabIndex = 0;
            // 
            // US_AlertsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbZone);
            this.Controls.Add(this.cmbCamera);
            this.Controls.Add(this.cmbViolation);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlMain);
            this.Name = "US_AlertsForm";
            this.Size = new System.Drawing.Size(1228, 762);
            this.Load += new System.EventHandler(this.US_AlertsForm_Load);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbZone;
        private System.Windows.Forms.ComboBox cmbCamera;
        private System.Windows.Forms.ComboBox cmbViolation;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.LinkLabel lnkNext;
        private System.Windows.Forms.LinkLabel lnkPrev;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.FlowLayoutPanel flpAlertsList;
    }
}
