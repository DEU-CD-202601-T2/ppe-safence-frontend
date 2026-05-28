//NuGet에서 OpenCvSharp4설치

namespace PPE_관제_시스템
{
    partial class US_LiveMonitoringForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                StopCamera();
                DataManager.OnDataChanged -= OnDashboardUpdated;
                if (_refreshTimer != null)
                {
                    _refreshTimer.Stop();
                    _refreshTimer.Dispose();
                }
                if (_refreshPen != null) _refreshPen.Dispose();
                if (_refreshIcon != null) _refreshIcon.Dispose();
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        private void InitializeComponent()
        {
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTop = new System.Windows.Forms.TableLayoutPanel();
            this.pnlNoPPE = new System.Windows.Forms.Panel();
            this.lblNoPPECount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNoPPE = new System.Windows.Forms.Label();
            this.pnlWarning = new System.Windows.Forms.Panel();
            this.lblActiveWorkersCount = new System.Windows.Forms.Label();
            this.lblActiveWorkers = new System.Windows.Forms.Label();
            this.pnlCompliance = new System.Windows.Forms.Panel();
            this.lblComplianceRate = new System.Windows.Forms.Label();
            this.lblCompliance = new System.Windows.Forms.Label();
            this.pnlCamera = new System.Windows.Forms.Panel();
            this.lblCameraCount = new System.Windows.Forms.Label();
            this.picRefresh = new System.Windows.Forms.PictureBox();
            this.lblCamera = new System.Windows.Forms.Label();
            this.pnlComboRow = new System.Windows.Forms.Panel();
            this.lblZoneSelect = new System.Windows.Forms.Label();
            this.pnlZoneComboBorder = new System.Windows.Forms.Panel();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.pnlVideoContainer = new System.Windows.Forms.Panel();
            this.picZoneView = new System.Windows.Forms.PictureBox();
            this.tlpMain.SuspendLayout();
            this.tlpTop.SuspendLayout();
            this.pnlNoPPE.SuspendLayout();
            this.pnlWarning.SuspendLayout();
            this.pnlCompliance.SuspendLayout();
            this.pnlCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRefresh)).BeginInit();
            this.pnlComboRow.SuspendLayout();
            this.pnlZoneComboBorder.SuspendLayout();
            this.pnlVideoContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picZoneView)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = AppColors.Background;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpTop, 0, 0);
            this.tlpMain.Controls.Add(this.pnlComboRow, 0, 1);
            this.tlpMain.Controls.Add(this.pnlVideoContainer, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1228, 762);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpTop
            // 
            this.tlpTop.ColumnCount = 4;
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpTop.Controls.Add(this.pnlNoPPE, 0, 0);
            this.tlpTop.Controls.Add(this.pnlWarning, 1, 0);
            this.tlpTop.Controls.Add(this.pnlCompliance, 2, 0);
            this.tlpTop.Controls.Add(this.pnlCamera, 3, 0);
            this.tlpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTop.Location = new System.Drawing.Point(3, 3);
            this.tlpTop.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tlpTop.Name = "tlpTop";
            this.tlpTop.RowCount = 1;
            this.tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.Size = new System.Drawing.Size(1222, 157);
            this.tlpTop.TabIndex = 0;
            // 
            // pnlNoPPE
            // 
            this.pnlNoPPE.BackColor = AppColors.Surface;
            this.pnlNoPPE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNoPPE.Controls.Add(this.lblNoPPECount);
            this.pnlNoPPE.Controls.Add(this.label6);
            this.pnlNoPPE.Controls.Add(this.lblNoPPE);
            this.pnlNoPPE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNoPPE.Location = new System.Drawing.Point(8, 8);
            this.pnlNoPPE.Margin = new System.Windows.Forms.Padding(8);
            this.pnlNoPPE.Name = "pnlNoPPE";
            this.pnlNoPPE.Size = new System.Drawing.Size(289, 141);
            this.pnlNoPPE.TabIndex = 0;
            // 
            // lblNoPPE
            // 
            this.lblNoPPE.AutoSize = true;
            this.lblNoPPE.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNoPPE.ForeColor = AppColors.PrimaryDark;
            this.lblNoPPE.Location = new System.Drawing.Point(18, 15);
            this.lblNoPPE.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNoPPE.Name = "lblNoPPE";
            this.lblNoPPE.Size = new System.Drawing.Size(74, 25);
            this.lblNoPPE.TabIndex = 0;
            this.lblNoPPE.Text = "PPE 미착용";
            // 
            // lblNoPPECount
            // 
            this.lblNoPPECount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoPPECount.AutoSize = false;
            this.lblNoPPECount.BackColor = System.Drawing.Color.Transparent;
            this.lblNoPPECount.Font = new System.Drawing.Font("맑은 고딕", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNoPPECount.ForeColor = AppColors.Danger;
            this.lblNoPPECount.Location = new System.Drawing.Point(18, 73);
            this.lblNoPPECount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNoPPECount.Padding = new System.Windows.Forms.Padding(0, 0, 24, 0);
            this.lblNoPPECount.Name = "lblNoPPECount";
            this.lblNoPPECount.Size = new System.Drawing.Size(253, 62);
            this.lblNoPPECount.TabIndex = 0;
            this.lblNoPPECount.Text = "0";
            this.lblNoPPECount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 36);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 15);
            this.label6.TabIndex = 0;
            // 
            // pnlWarning
            // 
            this.pnlWarning.BackColor = AppColors.Surface;
            this.pnlWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlWarning.Controls.Add(this.lblActiveWorkersCount);
            this.pnlWarning.Controls.Add(this.lblActiveWorkers);
            this.pnlWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWarning.Location = new System.Drawing.Point(313, 8);
            this.pnlWarning.Margin = new System.Windows.Forms.Padding(8);
            this.pnlWarning.Name = "pnlWarning";
            this.pnlWarning.Size = new System.Drawing.Size(289, 141);
            this.pnlWarning.TabIndex = 0;
            // 
            // lblActiveWorkers
            // 
            this.lblActiveWorkers.AutoSize = true;
            this.lblActiveWorkers.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblActiveWorkers.ForeColor = AppColors.PrimaryDark;
            this.lblActiveWorkers.Location = new System.Drawing.Point(18, 15);
            this.lblActiveWorkers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblActiveWorkers.Name = "lblActiveWorkers";
            this.lblActiveWorkers.Size = new System.Drawing.Size(125, 25);
            this.lblActiveWorkers.TabIndex = 0;
            this.lblActiveWorkers.Text = "현재 작업자 수";
            // 
            // lblActiveWorkersCount
            // 
            this.lblActiveWorkersCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActiveWorkersCount.AutoSize = false;
            this.lblActiveWorkersCount.BackColor = System.Drawing.Color.Transparent;
            this.lblActiveWorkersCount.Font = new System.Drawing.Font("맑은 고딕", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblActiveWorkersCount.ForeColor = AppColors.Text;
            this.lblActiveWorkersCount.Location = new System.Drawing.Point(18, 73);
            this.lblActiveWorkersCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblActiveWorkersCount.Padding = new System.Windows.Forms.Padding(0, 0, 24, 0);
            this.lblActiveWorkersCount.Name = "lblActiveWorkersCount";
            this.lblActiveWorkersCount.Size = new System.Drawing.Size(253, 62);
            this.lblActiveWorkersCount.TabIndex = 0;
            this.lblActiveWorkersCount.Text = "0";
            this.lblActiveWorkersCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlCompliance
            // 
            this.pnlCompliance.BackColor = AppColors.Surface;
            this.pnlCompliance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCompliance.Controls.Add(this.lblComplianceRate);
            this.pnlCompliance.Controls.Add(this.lblCompliance);
            this.pnlCompliance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCompliance.Location = new System.Drawing.Point(618, 8);
            this.pnlCompliance.Margin = new System.Windows.Forms.Padding(8);
            this.pnlCompliance.Name = "pnlCompliance";
            this.pnlCompliance.Size = new System.Drawing.Size(289, 141);
            this.pnlCompliance.TabIndex = 0;
            // 
            // lblCompliance
            // 
            this.lblCompliance.AutoSize = true;
            this.lblCompliance.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCompliance.ForeColor = AppColors.PrimaryDark;
            this.lblCompliance.Location = new System.Drawing.Point(18, 15);
            this.lblCompliance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCompliance.Name = "lblCompliance";
            this.lblCompliance.Size = new System.Drawing.Size(58, 25);
            this.lblCompliance.TabIndex = 0;
            this.lblCompliance.Text = "준수율";
            // 
            // lblComplianceRate
            // 
            this.lblComplianceRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblComplianceRate.AutoSize = false;
            this.lblComplianceRate.BackColor = System.Drawing.Color.Transparent;
            this.lblComplianceRate.Font = new System.Drawing.Font("맑은 고딕", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblComplianceRate.ForeColor = AppColors.Success;
            this.lblComplianceRate.Location = new System.Drawing.Point(18, 73);
            this.lblComplianceRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComplianceRate.Padding = new System.Windows.Forms.Padding(0, 0, 24, 0);
            this.lblComplianceRate.Name = "lblComplianceRate";
            this.lblComplianceRate.Size = new System.Drawing.Size(253, 62);
            this.lblComplianceRate.TabIndex = 0;
            this.lblComplianceRate.Text = "0%";
            this.lblComplianceRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlCamera
            // 
            this.pnlCamera.BackColor = AppColors.Surface;
            this.pnlCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCamera.Controls.Add(this.lblCameraCount);
            this.pnlCamera.Controls.Add(this.picRefresh);
            this.pnlCamera.Controls.Add(this.lblCamera);
            this.pnlCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCamera.Location = new System.Drawing.Point(923, 8);
            this.pnlCamera.Margin = new System.Windows.Forms.Padding(8);
            this.pnlCamera.Name = "pnlCamera";
            this.pnlCamera.Size = new System.Drawing.Size(291, 141);
            this.pnlCamera.TabIndex = 0;
            // 
            // lblCamera
            // 
            this.lblCamera.AutoSize = true;
            this.lblCamera.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCamera.ForeColor = AppColors.PrimaryDark;
            this.lblCamera.Location = new System.Drawing.Point(18, 15);
            this.lblCamera.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCamera.Name = "lblCamera";
            this.lblCamera.Size = new System.Drawing.Size(58, 25);
            this.lblCamera.TabIndex = 0;
            this.lblCamera.Text = "카메라";
            // 
            // picRefresh
            // 
            this.picRefresh.BackColor = System.Drawing.Color.Transparent;
            this.picRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picRefresh.Location = new System.Drawing.Point(82, 15);
            this.picRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.picRefresh.Name = "picRefresh";
            this.picRefresh.Size = new System.Drawing.Size(26, 26);
            this.picRefresh.TabIndex = 1;
            this.picRefresh.TabStop = false;
            this.picRefresh.Paint += new System.Windows.Forms.PaintEventHandler(this.picRefresh_Paint);
            this.picRefresh.Click += new System.EventHandler(this.picRefresh_Click);
            // 
            // lblCameraCount
            // 
            this.lblCameraCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCameraCount.AutoSize = false;
            this.lblCameraCount.BackColor = System.Drawing.Color.Transparent;
            this.lblCameraCount.Font = new System.Drawing.Font("맑은 고딕", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCameraCount.ForeColor = AppColors.Text;
            this.lblCameraCount.Location = new System.Drawing.Point(18, 73);
            this.lblCameraCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCameraCount.Padding = new System.Windows.Forms.Padding(0, 0, 24, 0);
            this.lblCameraCount.Name = "lblCameraCount";
            this.lblCameraCount.Size = new System.Drawing.Size(253, 62);
            this.lblCameraCount.TabIndex = 0;
            this.lblCameraCount.Text = "0대";
            this.lblCameraCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlComboRow
            // 
            this.pnlComboRow.BackColor = AppColors.Background;
            this.pnlComboRow.Controls.Add(this.lblZoneSelect);
            this.pnlComboRow.Controls.Add(this.pnlZoneComboBorder);
            this.pnlComboRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlComboRow.Location = new System.Drawing.Point(8, 165);
            this.pnlComboRow.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.pnlComboRow.Name = "pnlComboRow";
            this.pnlComboRow.Size = new System.Drawing.Size(1212, 40);
            this.pnlComboRow.TabIndex = 0;
            // 
            // lblZoneSelect
            // 
            this.lblZoneSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblZoneSelect.AutoSize = true;
            this.lblZoneSelect.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular);
            this.lblZoneSelect.ForeColor = AppColors.TextSecondary;
            this.lblZoneSelect.Location = new System.Drawing.Point(1015, 10);
            this.lblZoneSelect.Name = "lblZoneSelect";
            this.lblZoneSelect.Size = new System.Drawing.Size(57, 23);
            this.lblZoneSelect.TabIndex = 0;
            this.lblZoneSelect.Text = "구역:";
            // 
            // pnlZoneComboBorder
            // 
            this.pnlZoneComboBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlZoneComboBorder.BackColor = AppColors.BorderDark;
            this.pnlZoneComboBorder.Controls.Add(this.cmbZone);
            this.pnlZoneComboBorder.Location = new System.Drawing.Point(1080, 5);
            this.pnlZoneComboBorder.Name = "pnlZoneComboBorder";
            this.pnlZoneComboBorder.Padding = new System.Windows.Forms.Padding(1);
            this.pnlZoneComboBorder.Size = new System.Drawing.Size(127, 32);
            this.pnlZoneComboBorder.TabIndex = 1;
            // 
            // cmbZone
            // 
            this.cmbZone.BackColor = AppColors.Surface;
            this.cmbZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbZone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbZone.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbZone.ForeColor = AppColors.Text;
            this.cmbZone.FormattingEnabled = true;
            this.cmbZone.Items.AddRange(new object[] {
            "A구역",
            "B구역",
            "C구역"});
            this.cmbZone.Location = new System.Drawing.Point(1, 1);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(125, 31);
            this.cmbZone.TabIndex = 0;
            this.cmbZone.Text = "A구역";
            this.cmbZone.SelectedIndexChanged += new System.EventHandler(this.cmbZone_SelectedIndexChanged);
            // 
            // pnlVideoContainer
            // 
            this.pnlVideoContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.pnlVideoContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlVideoContainer.Controls.Add(this.picZoneView);
            this.pnlVideoContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVideoContainer.Location = new System.Drawing.Point(8, 213);
            this.pnlVideoContainer.Margin = new System.Windows.Forms.Padding(8, 0, 8, 8);
            this.pnlVideoContainer.Name = "pnlVideoContainer";
            this.pnlVideoContainer.Size = new System.Drawing.Size(1212, 541);
            this.pnlVideoContainer.TabIndex = 0;
            // 
            // picZoneView
            // 
            this.picZoneView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.picZoneView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picZoneView.Location = new System.Drawing.Point(0, 0);
            this.picZoneView.Name = "picZoneView";
            this.picZoneView.Size = new System.Drawing.Size(1210, 539);
            this.picZoneView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picZoneView.TabIndex = 0;
            this.picZoneView.TabStop = false;
            // 
            // US_LiveMonitoringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = AppColors.Background;
            this.Controls.Add(this.tlpMain);
            this.Padding = new System.Windows.Forms.Padding(0);
            this.Name = "US_LiveMonitoringForm";
            this.Size = new System.Drawing.Size(1228, 762);
            this.Load += new System.EventHandler(this.US_LiveMonitoringForm_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpTop.ResumeLayout(false);
            this.pnlNoPPE.ResumeLayout(false);
            this.pnlNoPPE.PerformLayout();
            this.pnlWarning.ResumeLayout(false);
            this.pnlWarning.PerformLayout();
            this.pnlCompliance.ResumeLayout(false);
            this.pnlCompliance.PerformLayout();
            this.pnlCamera.ResumeLayout(false);
            this.pnlCamera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRefresh)).EndInit();
            this.pnlComboRow.ResumeLayout(false);
            this.pnlComboRow.PerformLayout();
            this.pnlZoneComboBorder.ResumeLayout(false);
            this.pnlVideoContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picZoneView)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpTop;
        private System.Windows.Forms.Panel pnlComboRow;
        private System.Windows.Forms.Label lblZoneSelect;
        private System.Windows.Forms.Panel pnlZoneComboBorder;
        private System.Windows.Forms.ComboBox cmbZone;
        private System.Windows.Forms.Panel pnlVideoContainer;
        private System.Windows.Forms.PictureBox picZoneView;
        private System.Windows.Forms.Panel pnlCamera;
        private System.Windows.Forms.Label lblCamera;
        private System.Windows.Forms.PictureBox picRefresh;
        private System.Windows.Forms.Panel pnlCompliance;
        private System.Windows.Forms.Label lblComplianceRate;
        private System.Windows.Forms.Label lblCompliance;
        private System.Windows.Forms.Panel pnlWarning;
        private System.Windows.Forms.Label lblActiveWorkersCount;
        private System.Windows.Forms.Label lblActiveWorkers;
        private System.Windows.Forms.Panel pnlNoPPE;
        private System.Windows.Forms.Label lblNoPPECount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNoPPE;
        private System.Windows.Forms.Label lblCameraCount;
    }
}