//NuGet에서 OpenCvSharp4설치

namespace PPE_관제_시스템
{
    partial class US_LiveMonitoringForm
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
            if (disposing)
            {
                StopCamera();

                DataManager.OnDataChanged
                    -= OnDashboardUpdated;

                if (components != null)
                {
                    components.Dispose();
                }
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
            this.pnlCamera = new System.Windows.Forms.Panel();
            this.lblCameraCount = new System.Windows.Forms.Label();
            this.lblCameraStatus = new System.Windows.Forms.Label();
            this.lblCamera = new System.Windows.Forms.Label();
            this.pnlCompliance = new System.Windows.Forms.Panel();
            this.lblComplianceRate = new System.Windows.Forms.Label();
            this.lblCompliance = new System.Windows.Forms.Label();
            this.pnlWarning = new System.Windows.Forms.Panel();
            this.lblActiveWorkersCount = new System.Windows.Forms.Label();
            this.lblActiveWorkers = new System.Windows.Forms.Label();
            this.pnlNoPPE = new System.Windows.Forms.Panel();
            this.lblNoPPECount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNoPPE = new System.Windows.Forms.Label();
            this.picZoneView = new System.Windows.Forms.PictureBox();
            this.pnlCamera.SuspendLayout();
            this.pnlCompliance.SuspendLayout();
            this.pnlWarning.SuspendLayout();
            this.pnlNoPPE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picZoneView)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbZone
            // 
            this.cmbZone.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbZone.FormattingEnabled = true;
            this.cmbZone.Items.AddRange(new object[] {
            "A구역",
            "B구역",
            "C구역"});
            this.cmbZone.Location = new System.Drawing.Point(1102, 187);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(121, 31);
            this.cmbZone.TabIndex = 22;
            this.cmbZone.Text = "A구역";
            this.cmbZone.SelectedIndexChanged += new System.EventHandler(this.cmbZone_SelectedIndexChanged);
            // 
            // pnlCamera
            // 
            this.pnlCamera.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlCamera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlCamera.Controls.Add(this.lblCameraCount);
            this.pnlCamera.Controls.Add(this.lblCameraStatus);
            this.pnlCamera.Controls.Add(this.lblCamera);
            this.pnlCamera.Location = new System.Drawing.Point(928, 0);
            this.pnlCamera.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCamera.Name = "pnlCamera";
            this.pnlCamera.Size = new System.Drawing.Size(300, 150);
            this.pnlCamera.TabIndex = 17;
            // 
            // lblCameraCount
            // 
            this.lblCameraCount.AutoSize = true;
            this.lblCameraCount.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCameraCount.Location = new System.Drawing.Point(72, 9);
            this.lblCameraCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCameraCount.Name = "lblCameraCount";
            this.lblCameraCount.Size = new System.Drawing.Size(44, 28);
            this.lblCameraCount.TabIndex = 12;
            this.lblCameraCount.Text = "1대";
            // 
            // lblCameraStatus
            // 
            this.lblCameraStatus.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCameraStatus.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCameraStatus.Location = new System.Drawing.Point(10, 105);
            this.lblCameraStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCameraStatus.Name = "lblCameraStatus";
            this.lblCameraStatus.Size = new System.Drawing.Size(288, 38);
            this.lblCameraStatus.TabIndex = 11;
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
            this.lblCamera.TabIndex = 6;
            this.lblCamera.Text = "카메라";
            // 
            // pnlCompliance
            // 
            this.pnlCompliance.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlCompliance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlCompliance.Controls.Add(this.lblComplianceRate);
            this.pnlCompliance.Controls.Add(this.lblCompliance);
            this.pnlCompliance.Location = new System.Drawing.Point(618, 0);
            this.pnlCompliance.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCompliance.Name = "pnlCompliance";
            this.pnlCompliance.Size = new System.Drawing.Size(300, 150);
            this.pnlCompliance.TabIndex = 18;
            // 
            // lblComplianceRate
            // 
            this.lblComplianceRate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblComplianceRate.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblComplianceRate.Location = new System.Drawing.Point(206, 105);
            this.lblComplianceRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComplianceRate.Name = "lblComplianceRate";
            this.lblComplianceRate.Size = new System.Drawing.Size(87, 38);
            this.lblComplianceRate.TabIndex = 10;
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
            this.lblCompliance.TabIndex = 5;
            this.lblCompliance.Text = "준수율";
            // 
            // pnlWarning
            // 
            this.pnlWarning.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlWarning.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlWarning.Controls.Add(this.lblActiveWorkersCount);
            this.pnlWarning.Controls.Add(this.lblActiveWorkers);
            this.pnlWarning.Location = new System.Drawing.Point(308, 0);
            this.pnlWarning.Margin = new System.Windows.Forms.Padding(2);
            this.pnlWarning.Name = "pnlWarning";
            this.pnlWarning.Size = new System.Drawing.Size(300, 150);
            this.pnlWarning.TabIndex = 19;
            // 
            // lblActiveWorkersCount
            // 
            this.lblActiveWorkersCount.AutoSize = true;
            this.lblActiveWorkersCount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblActiveWorkersCount.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblActiveWorkersCount.Location = new System.Drawing.Point(255, 105);
            this.lblActiveWorkersCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblActiveWorkersCount.Name = "lblActiveWorkersCount";
            this.lblActiveWorkersCount.Size = new System.Drawing.Size(33, 38);
            this.lblActiveWorkersCount.TabIndex = 9;
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
            this.lblActiveWorkers.TabIndex = 4;
            this.lblActiveWorkers.Text = "현재 작업자 수";
            // 
            // pnlNoPPE
            // 
            this.pnlNoPPE.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlNoPPE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlNoPPE.Controls.Add(this.lblNoPPECount);
            this.pnlNoPPE.Controls.Add(this.label6);
            this.pnlNoPPE.Controls.Add(this.lblNoPPE);
            this.pnlNoPPE.Location = new System.Drawing.Point(-1, 0);
            this.pnlNoPPE.Margin = new System.Windows.Forms.Padding(2);
            this.pnlNoPPE.Name = "pnlNoPPE";
            this.pnlNoPPE.Size = new System.Drawing.Size(300, 150);
            this.pnlNoPPE.TabIndex = 20;
            // 
            // lblNoPPECount
            // 
            this.lblNoPPECount.AutoSize = true;
            this.lblNoPPECount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNoPPECount.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNoPPECount.Location = new System.Drawing.Point(255, 105);
            this.lblNoPPECount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNoPPECount.Name = "lblNoPPECount";
            this.lblNoPPECount.Size = new System.Drawing.Size(33, 38);
            this.lblNoPPECount.TabIndex = 8;
            this.lblNoPPECount.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 36);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 15);
            this.label6.TabIndex = 7;
            // 
            // lblNoPPE
            // 
            this.lblNoPPE.AutoSize = true;
            this.lblNoPPE.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNoPPE.Location = new System.Drawing.Point(5, 8);
            this.lblNoPPE.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNoPPE.Name = "lblNoPPE";
            this.lblNoPPE.Size = new System.Drawing.Size(72, 28);
            this.lblNoPPE.TabIndex = 3;
            this.lblNoPPE.Text = "미착용";
            // 
            // picZoneView
            // 
            this.picZoneView.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.picZoneView.Location = new System.Drawing.Point(0, 226);
            this.picZoneView.Margin = new System.Windows.Forms.Padding(2);
            this.picZoneView.Name = "picZoneView";
            this.picZoneView.Size = new System.Drawing.Size(1224, 534);
            this.picZoneView.TabIndex = 21;
            this.picZoneView.TabStop = false;
            // 
            // US_LiveMonitoringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbZone);
            this.Controls.Add(this.picZoneView);
            this.Controls.Add(this.pnlCamera);
            this.Controls.Add(this.pnlCompliance);
            this.Controls.Add(this.pnlWarning);
            this.Controls.Add(this.pnlNoPPE);
            this.Name = "US_LiveMonitoringForm";
            this.Size = new System.Drawing.Size(1228, 762);
            this.Load += new System.EventHandler(this.US_LiveMonitoringForm_Load);
            this.pnlCamera.ResumeLayout(false);
            this.pnlCamera.PerformLayout();
            this.pnlCompliance.ResumeLayout(false);
            this.pnlCompliance.PerformLayout();
            this.pnlWarning.ResumeLayout(false);
            this.pnlWarning.PerformLayout();
            this.pnlNoPPE.ResumeLayout(false);
            this.pnlNoPPE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picZoneView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

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
