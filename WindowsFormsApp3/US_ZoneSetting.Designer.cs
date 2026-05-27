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
            this.lblZoneSetting = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.grpAvailableCameras = new System.Windows.Forms.GroupBox();
            this.lstAvailableCameras = new System.Windows.Forms.ListBox();
            this.lblJetsonStatus = new System.Windows.Forms.Label();
            this.btnRefreshCameras = new System.Windows.Forms.Button();
            this.tlpRight = new System.Windows.Forms.TableLayoutPanel();
            this.grpZones = new System.Windows.Forms.GroupBox();
            this.lstZones = new System.Windows.Forms.ListBox();
            this.grpZoneInfo = new System.Windows.Forms.GroupBox();
            this.lblSelectedCameraLabel = new System.Windows.Forms.Label();
            this.lblSelectedCamera = new System.Windows.Forms.Label();
            this.lblZoneName = new System.Windows.Forms.Label();
            this.txtZoneName = new System.Windows.Forms.TextBox();
            this.lblZoneDescription = new System.Windows.Forms.Label();
            this.txtZoneDescription = new System.Windows.Forms.TextBox();
            this.lblZoneRiskLevel = new System.Windows.Forms.Label();
            this.cmbZoneRiskLevel = new System.Windows.Forms.ComboBox();
            this.chkUseZone = new System.Windows.Forms.CheckBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnZoneAdd = new System.Windows.Forms.Button();
            this.btnZoneModify = new System.Windows.Forms.Button();
            this.btnZoneDelete = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.grpAvailableCameras.SuspendLayout();
            this.tlpRight.SuspendLayout();
            this.grpZones.SuspendLayout();
            this.grpZoneInfo.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblZoneSetting
            // 
            this.lblZoneSetting.AutoSize = true;
            this.lblZoneSetting.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZoneSetting.Location = new System.Drawing.Point(20, 10);
            this.lblZoneSetting.Name = "lblZoneSetting";
            this.lblZoneSetting.Size = new System.Drawing.Size(114, 31);
            this.lblZoneSetting.TabIndex = 0;
            this.lblZoneSetting.Text = "구역 설정";
            // 
            // tlpMain
            // 
            this.tlpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.tlpMain.Controls.Add(this.grpAvailableCameras, 0, 0);
            this.tlpMain.Controls.Add(this.tlpRight, 1, 0);
            this.tlpMain.Location = new System.Drawing.Point(20, 50);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1179, 593);
            this.tlpMain.TabIndex = 1;
            // 
            // grpAvailableCameras
            // 
            this.grpAvailableCameras.Controls.Add(this.lstAvailableCameras);
            this.grpAvailableCameras.Controls.Add(this.lblJetsonStatus);
            this.grpAvailableCameras.Controls.Add(this.btnRefreshCameras);
            this.grpAvailableCameras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAvailableCameras.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grpAvailableCameras.Location = new System.Drawing.Point(3, 3);
            this.grpAvailableCameras.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.grpAvailableCameras.Name = "grpAvailableCameras";
            this.grpAvailableCameras.Size = new System.Drawing.Size(484, 587);
            this.grpAvailableCameras.TabIndex = 0;
            this.grpAvailableCameras.TabStop = false;
            this.grpAvailableCameras.Text = "연결 가능한 카메라";
            // 
            // lstAvailableCameras
            // 
            this.lstAvailableCameras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAvailableCameras.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lstAvailableCameras.FormattingEnabled = true;
            this.lstAvailableCameras.ItemHeight = 24;
            this.lstAvailableCameras.Location = new System.Drawing.Point(15, 65);
            this.lstAvailableCameras.Name = "lstAvailableCameras";
            this.lstAvailableCameras.Size = new System.Drawing.Size(454, 460);
            this.lstAvailableCameras.TabIndex = 1;
            this.lstAvailableCameras.SelectedIndexChanged += new System.EventHandler(this.lstAvailableCameras_SelectedIndexChanged);
            // 
            // lblJetsonStatus
            // 
            this.lblJetsonStatus.AutoSize = true;
            this.lblJetsonStatus.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lblJetsonStatus.Location = new System.Drawing.Point(15, 35);
            this.lblJetsonStatus.Name = "lblJetsonStatus";
            this.lblJetsonStatus.Size = new System.Drawing.Size(130, 23);
            this.lblJetsonStatus.TabIndex = 0;
            this.lblJetsonStatus.Text = "Jetson: 확인 중...";
            // 
            // btnRefreshCameras
            // 
            this.btnRefreshCameras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefreshCameras.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.btnRefreshCameras.Location = new System.Drawing.Point(15, 540);
            this.btnRefreshCameras.Name = "btnRefreshCameras";
            this.btnRefreshCameras.Size = new System.Drawing.Size(120, 35);
            this.btnRefreshCameras.TabIndex = 2;
            this.btnRefreshCameras.Text = "🔄 새로고침";
            this.btnRefreshCameras.UseVisualStyleBackColor = true;
            this.btnRefreshCameras.Click += new System.EventHandler(this.btnRefreshCameras_Click);
            // 
            // tlpRight
            // 
            this.tlpRight.ColumnCount = 1;
            this.tlpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.Controls.Add(this.grpZones, 0, 0);
            this.tlpRight.Controls.Add(this.grpZoneInfo, 0, 1);
            this.tlpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRight.Location = new System.Drawing.Point(498, 3);
            this.tlpRight.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tlpRight.Name = "tlpRight";
            this.tlpRight.RowCount = 2;
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tlpRight.Size = new System.Drawing.Size(678, 587);
            this.tlpRight.TabIndex = 1;
            // 
            // grpZones
            // 
            this.grpZones.Controls.Add(this.lstZones);
            this.grpZones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpZones.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grpZones.Location = new System.Drawing.Point(3, 3);
            this.grpZones.Name = "grpZones";
            this.grpZones.Size = new System.Drawing.Size(672, 199);
            this.grpZones.TabIndex = 0;
            this.grpZones.TabStop = false;
            this.grpZones.Text = "등록된 구역";
            // 
            // lstZones
            // 
            this.lstZones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstZones.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lstZones.FormattingEnabled = true;
            this.lstZones.ItemHeight = 24;
            this.lstZones.Location = new System.Drawing.Point(3, 30);
            this.lstZones.Name = "lstZones";
            this.lstZones.Padding = new System.Windows.Forms.Padding(10);
            this.lstZones.Size = new System.Drawing.Size(666, 166);
            this.lstZones.TabIndex = 0;
            this.lstZones.SelectedIndexChanged += new System.EventHandler(this.lstZones_SelectedIndexChanged);
            // 
            // grpZoneInfo
            // 
            this.grpZoneInfo.Controls.Add(this.lblSelectedCameraLabel);
            this.grpZoneInfo.Controls.Add(this.lblSelectedCamera);
            this.grpZoneInfo.Controls.Add(this.lblZoneName);
            this.grpZoneInfo.Controls.Add(this.txtZoneName);
            this.grpZoneInfo.Controls.Add(this.lblZoneDescription);
            this.grpZoneInfo.Controls.Add(this.txtZoneDescription);
            this.grpZoneInfo.Controls.Add(this.lblZoneRiskLevel);
            this.grpZoneInfo.Controls.Add(this.cmbZoneRiskLevel);
            this.grpZoneInfo.Controls.Add(this.chkUseZone);
            this.grpZoneInfo.Controls.Add(this.pnlButtons);
            this.grpZoneInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpZoneInfo.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grpZoneInfo.Location = new System.Drawing.Point(3, 208);
            this.grpZoneInfo.Name = "grpZoneInfo";
            this.grpZoneInfo.Size = new System.Drawing.Size(672, 376);
            this.grpZoneInfo.TabIndex = 1;
            this.grpZoneInfo.TabStop = false;
            this.grpZoneInfo.Text = "구역 정보";
            // 
            // lblSelectedCameraLabel
            // 
            this.lblSelectedCameraLabel.AutoSize = true;
            this.lblSelectedCameraLabel.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lblSelectedCameraLabel.Location = new System.Drawing.Point(25, 40);
            this.lblSelectedCameraLabel.Name = "lblSelectedCameraLabel";
            this.lblSelectedCameraLabel.Size = new System.Drawing.Size(110, 23);
            this.lblSelectedCameraLabel.TabIndex = 0;
            this.lblSelectedCameraLabel.Text = "선택된 카메라:";
            // 
            // lblSelectedCamera
            // 
            this.lblSelectedCamera.AutoSize = true;
            this.lblSelectedCamera.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.lblSelectedCamera.ForeColor = System.Drawing.Color.Gray;
            this.lblSelectedCamera.Location = new System.Drawing.Point(150, 40);
            this.lblSelectedCamera.Name = "lblSelectedCamera";
            this.lblSelectedCamera.Size = new System.Drawing.Size(100, 23);
            this.lblSelectedCamera.TabIndex = 1;
            this.lblSelectedCamera.Text = "(선택 안 됨)";
            // 
            // lblZoneName
            // 
            this.lblZoneName.AutoSize = true;
            this.lblZoneName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lblZoneName.Location = new System.Drawing.Point(25, 85);
            this.lblZoneName.Name = "lblZoneName";
            this.lblZoneName.Size = new System.Drawing.Size(70, 23);
            this.lblZoneName.TabIndex = 2;
            this.lblZoneName.Text = "구역명:";
            // 
            // txtZoneName
            // 
            this.txtZoneName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtZoneName.Location = new System.Drawing.Point(150, 82);
            this.txtZoneName.Name = "txtZoneName";
            this.txtZoneName.Size = new System.Drawing.Size(280, 30);
            this.txtZoneName.TabIndex = 3;
            // 
            // lblZoneDescription
            // 
            this.lblZoneDescription.AutoSize = true;
            this.lblZoneDescription.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lblZoneDescription.Location = new System.Drawing.Point(25, 130);
            this.lblZoneDescription.Name = "lblZoneDescription";
            this.lblZoneDescription.Size = new System.Drawing.Size(90, 23);
            this.lblZoneDescription.TabIndex = 4;
            this.lblZoneDescription.Text = "구역 설명:";
            // 
            // txtZoneDescription
            // 
            this.txtZoneDescription.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtZoneDescription.Location = new System.Drawing.Point(150, 127);
            this.txtZoneDescription.Name = "txtZoneDescription";
            this.txtZoneDescription.Size = new System.Drawing.Size(450, 30);
            this.txtZoneDescription.TabIndex = 5;
            // 
            // lblZoneRiskLevel
            // 
            this.lblZoneRiskLevel.AutoSize = true;
            this.lblZoneRiskLevel.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lblZoneRiskLevel.Location = new System.Drawing.Point(25, 175);
            this.lblZoneRiskLevel.Name = "lblZoneRiskLevel";
            this.lblZoneRiskLevel.Size = new System.Drawing.Size(70, 23);
            this.lblZoneRiskLevel.TabIndex = 6;
            this.lblZoneRiskLevel.Text = "위험도:";
            // 
            // cmbZoneRiskLevel
            // 
            this.cmbZoneRiskLevel.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cmbZoneRiskLevel.FormattingEnabled = true;
            this.cmbZoneRiskLevel.Items.AddRange(new object[] {
            "높음",
            "보통",
            "낮음"});
            this.cmbZoneRiskLevel.Location = new System.Drawing.Point(150, 172);
            this.cmbZoneRiskLevel.Name = "cmbZoneRiskLevel";
            this.cmbZoneRiskLevel.Size = new System.Drawing.Size(150, 31);
            this.cmbZoneRiskLevel.TabIndex = 7;
            this.cmbZoneRiskLevel.Text = "선택";
            // 
            // chkUseZone
            // 
            this.chkUseZone.AutoSize = true;
            this.chkUseZone.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.chkUseZone.Location = new System.Drawing.Point(150, 222);
            this.chkUseZone.Name = "chkUseZone";
            this.chkUseZone.Size = new System.Drawing.Size(130, 27);
            this.chkUseZone.TabIndex = 8;
            this.chkUseZone.Text = "이 구역 사용";
            this.chkUseZone.UseVisualStyleBackColor = true;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlButtons.Controls.Add(this.btnZoneAdd);
            this.pnlButtons.Controls.Add(this.btnZoneModify);
            this.pnlButtons.Controls.Add(this.btnZoneDelete);
            this.pnlButtons.Location = new System.Drawing.Point(25, 305);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(622, 55);
            this.pnlButtons.TabIndex = 9;
            // 
            // btnZoneAdd
            // 
            this.btnZoneAdd.BackColor = System.Drawing.Color.FromArgb(220, 240, 255);
            this.btnZoneAdd.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnZoneAdd.Location = new System.Drawing.Point(0, 5);
            this.btnZoneAdd.Name = "btnZoneAdd";
            this.btnZoneAdd.Size = new System.Drawing.Size(140, 45);
            this.btnZoneAdd.TabIndex = 0;
            this.btnZoneAdd.Text = "추가";
            this.btnZoneAdd.UseVisualStyleBackColor = false;
            this.btnZoneAdd.Click += new System.EventHandler(this.btnZoneAdd_Click);
            // 
            // btnZoneModify
            // 
            this.btnZoneModify.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.btnZoneModify.Location = new System.Drawing.Point(150, 5);
            this.btnZoneModify.Name = "btnZoneModify";
            this.btnZoneModify.Size = new System.Drawing.Size(140, 45);
            this.btnZoneModify.TabIndex = 1;
            this.btnZoneModify.Text = "수정";
            this.btnZoneModify.UseVisualStyleBackColor = true;
            this.btnZoneModify.Click += new System.EventHandler(this.btnZoneModify_Click);
            // 
            // btnZoneDelete
            // 
            this.btnZoneDelete.BackColor = System.Drawing.Color.FromArgb(255, 230, 230);
            this.btnZoneDelete.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.btnZoneDelete.Location = new System.Drawing.Point(300, 5);
            this.btnZoneDelete.Name = "btnZoneDelete";
            this.btnZoneDelete.Size = new System.Drawing.Size(140, 45);
            this.btnZoneDelete.TabIndex = 2;
            this.btnZoneDelete.Text = "삭제";
            this.btnZoneDelete.UseVisualStyleBackColor = false;
            this.btnZoneDelete.Click += new System.EventHandler(this.btnZoneDelete_Click);
            // 
            // US_ZoneSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.lblZoneSetting);
            this.Name = "US_ZoneSetting";
            this.Padding = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.Size = new System.Drawing.Size(1219, 653);
            this.Load += new System.EventHandler(this.US_ZoneSetting_Load);
            this.tlpMain.ResumeLayout(false);
            this.grpAvailableCameras.ResumeLayout(false);
            this.grpAvailableCameras.PerformLayout();
            this.tlpRight.ResumeLayout(false);
            this.grpZones.ResumeLayout(false);
            this.grpZoneInfo.ResumeLayout(false);
            this.grpZoneInfo.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblZoneSetting;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpRight;
        private System.Windows.Forms.GroupBox grpAvailableCameras;
        private System.Windows.Forms.ListBox lstAvailableCameras;
        private System.Windows.Forms.Label lblJetsonStatus;
        private System.Windows.Forms.Button btnRefreshCameras;
        private System.Windows.Forms.GroupBox grpZones;
        private System.Windows.Forms.ListBox lstZones;
        private System.Windows.Forms.GroupBox grpZoneInfo;
        private System.Windows.Forms.Label lblSelectedCameraLabel;
        private System.Windows.Forms.Label lblSelectedCamera;
        private System.Windows.Forms.Label lblZoneName;
        private System.Windows.Forms.TextBox txtZoneName;
        private System.Windows.Forms.Label lblZoneDescription;
        private System.Windows.Forms.TextBox txtZoneDescription;
        private System.Windows.Forms.Label lblZoneRiskLevel;
        private System.Windows.Forms.ComboBox cmbZoneRiskLevel;
        private System.Windows.Forms.CheckBox chkUseZone;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnZoneAdd;
        private System.Windows.Forms.Button btnZoneModify;
        private System.Windows.Forms.Button btnZoneDelete;
    }
}