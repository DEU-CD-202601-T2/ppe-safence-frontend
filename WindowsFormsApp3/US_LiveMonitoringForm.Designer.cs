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
            this.lblCameraStatus = new System.Windows.Forms.Label();
            this.lblCamera = new System.Windows.Forms.Label();
            this.pnlComboRow = new System.Windows.Forms.Panel();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.picZoneView = new System.Windows.Forms.PictureBox();
            this.tlpMain.SuspendLayout();
            this.tlpTop.SuspendLayout();
            this.pnlNoPPE.SuspendLayout();
            this.pnlWarning.SuspendLayout();
            this.pnlCompliance.SuspendLayout();
            this.pnlCamera.SuspendLayout();
            this.pnlComboRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picZoneView)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpTop, 0, 0);
            this.tlpMain.Controls.Add(this.pnlComboRow, 0, 1);
            this.tlpMain.Controls.Add(this.picZoneView, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
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
            this.pnlNoPPE.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlNoPPE.Controls.Add(this.lblNoPPECount);
            this.pnlNoPPE.Controls.Add(this.label6);
            this.pnlNoPPE.Controls.Add(this.lblNoPPE);
            this.pnlNoPPE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNoPPE.Location = new System.Drawing.Point(2, 2);
            this.pnlNoPPE.Margin = new System.Windows.Forms.Padding(2);
            this.pnlNoPPE.Name = "pnlNoPPE";
            this.pnlNoPPE.Size = new System.Drawing.Size(301, 153);
            this.pnlNoPPE.TabIndex = 0;
            // 
            // lblNoPPECount
            // 
            this.lblNoPPECount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoPPECount.AutoSize = true;
            this.lblNoPPECount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNoPPECount.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNoPPECount.Location = new System.Drawing.Point(255, 113);
            this.lblNoPPECount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNoPPECount.Name = "lblNoPPECount";
            this.lblNoPPECount.Size = new System.Drawing.Size(33, 38);
            this.lblNoPPECount.TabIndex = 0;
            this.lblNoPPECount.Text = "0";
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
            // lblNoPPE
            // 
            this.lblNoPPE.AutoSize = true;
            this.lblNoPPE.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNoPPE.Location = new System.Drawing.Point(5, 8);
            this.lblNoPPE.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNoPPE.Name = "lblNoPPE";
            this.lblNoPPE.Size = new System.Drawing.Size(72, 28);
            this.lblNoPPE.TabIndex = 0;
            this.lblNoPPE.Text = "미착용";
            // 
            // pnlWarning
            // 
            this.pnlWarning.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlWarning.Controls.Add(this.lblActiveWorkersCount);
            this.pnlWarning.Controls.Add(this.lblActiveWorkers);
            this.pnlWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWarning.Location = new System.Drawing.Point(307, 2);
            this.pnlWarning.Margin = new System.Windows.Forms.Padding(2);
            this.pnlWarning.Name = "pnlWarning";
            this.pnlWarning.Size = new System.Drawing.Size(301, 153);
            this.pnlWarning.TabIndex = 0;
            // 
            // lblActiveWorkersCount
            // 
            this.lblActiveWorkersCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActiveWorkersCount.AutoSize = true;
            this.lblActiveWorkersCount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblActiveWorkersCount.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblActiveWorkersCount.Location = new System.Drawing.Point(255, 113);
            this.lblActiveWorkersCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblActiveWorkersCount.Name = "lblActiveWorkersCount";
            this.lblActiveWorkersCount.Size = new System.Drawing.Size(33, 38);
            this.lblActiveWorkersCount.TabIndex = 0;
            this.lblActiveWorkersCount.Text = "0";
            // 
            // lblActiveWorkers
            // 
            this.lblActiveWorkers.AutoSize = true;
            this.lblActiveWorkers.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblActiveWorkers.Location = new System.Drawing.Point(5, 8);
            this.lblActiveWorkers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblActiveWorkers.Name = "lblActiveWorkers";
            this.lblActiveWorkers.Size = new System.Drawing.Size(146, 28);
            this.lblActiveWorkers.TabIndex = 0;
            this.lblActiveWorkers.Text = "현재 작업자 수";
            // 
            // pnlCompliance
            // 
            this.pnlCompliance.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlCompliance.Controls.Add(this.lblComplianceRate);
            this.pnlCompliance.Controls.Add(this.lblCompliance);
            this.pnlCompliance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCompliance.Location = new System.Drawing.Point(612, 2);
            this.pnlCompliance.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCompliance.Name = "pnlCompliance";
            this.pnlCompliance.Size = new System.Drawing.Size(301, 153);
            this.pnlCompliance.TabIndex = 0;
            // 
            // lblComplianceRate
            // 
            this.lblComplianceRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblComplianceRate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblComplianceRate.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblComplianceRate.Location = new System.Drawing.Point(207, 113);
            this.lblComplianceRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComplianceRate.Name = "lblComplianceRate";
            this.lblComplianceRate.Size = new System.Drawing.Size(87, 38);
            this.lblComplianceRate.TabIndex = 0;
            this.lblComplianceRate.Text = "0%";
            this.lblComplianceRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCompliance
            // 
            this.lblCompliance.AutoSize = true;
            this.lblCompliance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCompliance.Location = new System.Drawing.Point(5, 8);
            this.lblCompliance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCompliance.Name = "lblCompliance";
            this.lblCompliance.Size = new System.Drawing.Size(72, 28);
            this.lblCompliance.TabIndex = 0;
            this.lblCompliance.Text = "준수율";
            // 
            // pnlCamera
            // 
            this.pnlCamera.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlCamera.Controls.Add(this.lblCameraCount);
            this.pnlCamera.Controls.Add(this.lblCameraStatus);
            this.pnlCamera.Controls.Add(this.lblCamera);
            this.pnlCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCamera.Location = new System.Drawing.Point(917, 2);
            this.pnlCamera.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCamera.Name = "pnlCamera";
            this.pnlCamera.Size = new System.Drawing.Size(303, 153);
            this.pnlCamera.TabIndex = 0;
            // 
            // lblCameraCount
            // 
            this.lblCameraCount.AutoSize = true;
            this.lblCameraCount.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCameraCount.Location = new System.Drawing.Point(72, 9);
            this.lblCameraCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCameraCount.Name = "lblCameraCount";
            this.lblCameraCount.Size = new System.Drawing.Size(44, 28);
            this.lblCameraCount.TabIndex = 0;
            this.lblCameraCount.Text = "1대";
            // 
            // lblCameraStatus
            // 
            this.lblCameraStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCameraStatus.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCameraStatus.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCameraStatus.Location = new System.Drawing.Point(10, 113);
            this.lblCameraStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCameraStatus.Name = "lblCameraStatus";
            this.lblCameraStatus.Size = new System.Drawing.Size(290, 38);
            this.lblCameraStatus.TabIndex = 0;
            this.lblCameraStatus.Text = "카메라 정보 불러오기 실패";
            this.lblCameraStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCamera
            // 
            this.lblCamera.AutoSize = true;
            this.lblCamera.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCamera.Location = new System.Drawing.Point(5, 8);
            this.lblCamera.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCamera.Name = "lblCamera";
            this.lblCamera.Size = new System.Drawing.Size(72, 28);
            this.lblCamera.TabIndex = 0;
            this.lblCamera.Text = "카메라";
            // 
            // pnlComboRow
            // 
            this.pnlComboRow.Controls.Add(this.cmbZone);
            this.pnlComboRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlComboRow.Location = new System.Drawing.Point(3, 160);
            this.pnlComboRow.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlComboRow.Name = "pnlComboRow";
            this.pnlComboRow.Size = new System.Drawing.Size(1222, 40);
            this.pnlComboRow.TabIndex = 0;
            // 
            // cmbZone
            // 
            this.cmbZone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbZone.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbZone.FormattingEnabled = true;
            this.cmbZone.Items.AddRange(new object[] {
            "A구역",
            "B구역",
            "C구역"});
            this.cmbZone.Location = new System.Drawing.Point(1090, 5);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(121, 31);
            this.cmbZone.TabIndex = 0;
            this.cmbZone.Text = "A구역";
            this.cmbZone.SelectedIndexChanged += new System.EventHandler(this.cmbZone_SelectedIndexChanged);
            // 
            // picZoneView
            // 
            this.picZoneView.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.picZoneView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picZoneView.Location = new System.Drawing.Point(3, 203);
            this.picZoneView.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.picZoneView.Name = "picZoneView";
            this.picZoneView.Size = new System.Drawing.Size(1222, 556);
            this.picZoneView.TabIndex = 0;
            this.picZoneView.TabStop = false;
            // 
            // US_LiveMonitoringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Padding = new System.Windows.Forms.Padding(0, 5, 70, 5);
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
            this.pnlComboRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picZoneView)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpTop;
        private System.Windows.Forms.Panel pnlComboRow;
        private System.Windows.Forms.ComboBox cmbZone;
        private System.Windows.Forms.PictureBox picZoneView;
        private System.Windows.Forms.Panel pnlCamera;
        private System.Windows.Forms.Label lblCameraStatus;
        private System.Windows.Forms.Label lblCamera;
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
