namespace PPE_관제_시스템
{
    partial class US_ControlForm
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
            this.btnResumeOperation = new System.Windows.Forms.Button();
            this.pnlNumberofAlerts = new System.Windows.Forms.Panel();
            this.lblAlertCount = new System.Windows.Forms.Label();
            this.lblNumberofAlerts = new System.Windows.Forms.Label();
            this.pnlSensorStatus = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblSensorStatus = new System.Windows.Forms.Label();
            this.pnlNoPPEPersonnel = new System.Windows.Forms.Panel();
            this.lblPersonCount = new System.Windows.Forms.Label();
            this.lblNoPPEPersonnel = new System.Windows.Forms.Label();
            this.pnlWorkersList = new System.Windows.Forms.Panel();
            this.dgvActiveWorkers = new System.Windows.Forms.DataGridView();
            this.lblActiveWorkers = new System.Windows.Forms.Label();
            this.colWorkerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPpeStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlNumberofAlerts.SuspendLayout();
            this.pnlSensorStatus.SuspendLayout();
            this.pnlNoPPEPersonnel.SuspendLayout();
            this.pnlWorkersList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveWorkers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnResumeOperation
            // 
            this.btnResumeOperation.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnResumeOperation.FlatAppearance.BorderSize = 0;
            this.btnResumeOperation.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnResumeOperation.Location = new System.Drawing.Point(1081, 215);
            this.btnResumeOperation.Margin = new System.Windows.Forms.Padding(2);
            this.btnResumeOperation.Name = "btnResumeOperation";
            this.btnResumeOperation.Size = new System.Drawing.Size(145, 38);
            this.btnResumeOperation.TabIndex = 12;
            this.btnResumeOperation.Text = "작업 중지 해제";
            this.btnResumeOperation.UseVisualStyleBackColor = false;
            this.btnResumeOperation.Click += new System.EventHandler(this.btnResumeOperation_Click);
            // 
            // pnlNumberofAlerts
            // 
            this.pnlNumberofAlerts.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlNumberofAlerts.Controls.Add(this.lblAlertCount);
            this.pnlNumberofAlerts.Controls.Add(this.lblNumberofAlerts);
            this.pnlNumberofAlerts.Location = new System.Drawing.Point(444, 2);
            this.pnlNumberofAlerts.Margin = new System.Windows.Forms.Padding(2);
            this.pnlNumberofAlerts.Name = "pnlNumberofAlerts";
            this.pnlNumberofAlerts.Size = new System.Drawing.Size(342, 155);
            this.pnlNumberofAlerts.TabIndex = 6;
            // 
            // lblAlertCount
            // 
            this.lblAlertCount.AutoSize = true;
            this.lblAlertCount.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAlertCount.Location = new System.Drawing.Point(285, 118);
            this.lblAlertCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAlertCount.Name = "lblAlertCount";
            this.lblAlertCount.Size = new System.Drawing.Size(44, 28);
            this.lblAlertCount.TabIndex = 9;
            this.lblAlertCount.Text = "0건";
            // 
            // lblNumberofAlerts
            // 
            this.lblNumberofAlerts.AutoSize = true;
            this.lblNumberofAlerts.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNumberofAlerts.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNumberofAlerts.Location = new System.Drawing.Point(5, 2);
            this.lblNumberofAlerts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumberofAlerts.Name = "lblNumberofAlerts";
            this.lblNumberofAlerts.Size = new System.Drawing.Size(126, 28);
            this.lblNumberofAlerts.TabIndex = 5;
            this.lblNumberofAlerts.Text = "경고 발생 수";
            // 
            // pnlSensorStatus
            // 
            this.pnlSensorStatus.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlSensorStatus.Controls.Add(this.lblStatus);
            this.pnlSensorStatus.Controls.Add(this.lblSensorStatus);
            this.pnlSensorStatus.Location = new System.Drawing.Point(884, 2);
            this.pnlSensorStatus.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSensorStatus.Name = "pnlSensorStatus";
            this.pnlSensorStatus.Size = new System.Drawing.Size(342, 155);
            this.pnlSensorStatus.TabIndex = 7;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStatus.ForeColor = System.Drawing.Color.Green;
            this.lblStatus.Location = new System.Drawing.Point(278, 118);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 28);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "정상";
            // 
            // lblSensorStatus
            // 
            this.lblSensorStatus.AutoSize = true;
            this.lblSensorStatus.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSensorStatus.Location = new System.Drawing.Point(5, 2);
            this.lblSensorStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSensorStatus.Name = "lblSensorStatus";
            this.lblSensorStatus.Size = new System.Drawing.Size(99, 28);
            this.lblSensorStatus.TabIndex = 6;
            this.lblSensorStatus.Text = "센서 상태";
            // 
            // pnlNoPPEPersonnel
            // 
            this.pnlNoPPEPersonnel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlNoPPEPersonnel.Controls.Add(this.lblPersonCount);
            this.pnlNoPPEPersonnel.Controls.Add(this.lblNoPPEPersonnel);
            this.pnlNoPPEPersonnel.Location = new System.Drawing.Point(2, 2);
            this.pnlNoPPEPersonnel.Margin = new System.Windows.Forms.Padding(2);
            this.pnlNoPPEPersonnel.Name = "pnlNoPPEPersonnel";
            this.pnlNoPPEPersonnel.Size = new System.Drawing.Size(342, 155);
            this.pnlNoPPEPersonnel.TabIndex = 9;
            // 
            // lblPersonCount
            // 
            this.lblPersonCount.AutoSize = true;
            this.lblPersonCount.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPersonCount.Location = new System.Drawing.Point(284, 118);
            this.lblPersonCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPersonCount.Name = "lblPersonCount";
            this.lblPersonCount.Size = new System.Drawing.Size(44, 28);
            this.lblPersonCount.TabIndex = 8;
            this.lblPersonCount.Text = "0명";
            // 
            // lblNoPPEPersonnel
            // 
            this.lblNoPPEPersonnel.AutoSize = true;
            this.lblNoPPEPersonnel.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNoPPEPersonnel.Location = new System.Drawing.Point(5, 2);
            this.lblNoPPEPersonnel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNoPPEPersonnel.Name = "lblNoPPEPersonnel";
            this.lblNoPPEPersonnel.Size = new System.Drawing.Size(161, 28);
            this.lblNoPPEPersonnel.TabIndex = 4;
            this.lblNoPPEPersonnel.Text = "PPE 미착용 인원";
            // 
            // pnlWorkersList
            // 
            this.pnlWorkersList.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlWorkersList.Controls.Add(this.dgvActiveWorkers);
            this.pnlWorkersList.Location = new System.Drawing.Point(2, 258);
            this.pnlWorkersList.Margin = new System.Windows.Forms.Padding(2);
            this.pnlWorkersList.Name = "pnlWorkersList";
            this.pnlWorkersList.Size = new System.Drawing.Size(1224, 504);
            this.pnlWorkersList.TabIndex = 10;
            // 
            // dgvActiveWorkers
            // 
            this.dgvActiveWorkers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActiveWorkers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActiveWorkers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colWorkerId,
            this.colName,
            this.colLocation,
            this.colPpeStatus,
            this.colStatus,
            this.colTime});
            this.dgvActiveWorkers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActiveWorkers.Location = new System.Drawing.Point(0, 0);
            this.dgvActiveWorkers.Margin = new System.Windows.Forms.Padding(2);
            this.dgvActiveWorkers.Name = "dgvActiveWorkers";
            this.dgvActiveWorkers.RowHeadersVisible = false;
            this.dgvActiveWorkers.RowHeadersWidth = 62;
            this.dgvActiveWorkers.RowTemplate.Height = 30;
            this.dgvActiveWorkers.Size = new System.Drawing.Size(1224, 504);
            this.dgvActiveWorkers.TabIndex = 3;
            // 
            // lblActiveWorkers
            // 
            this.lblActiveWorkers.AutoSize = true;
            this.lblActiveWorkers.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblActiveWorkers.Location = new System.Drawing.Point(6, 216);
            this.lblActiveWorkers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblActiveWorkers.Name = "lblActiveWorkers";
            this.lblActiveWorkers.Size = new System.Drawing.Size(214, 31);
            this.lblActiveWorkers.TabIndex = 9;
            this.lblActiveWorkers.Text = "실시간 작업자 목록";
            // 
            // colWorkerId
            // 
            this.colWorkerId.HeaderText = "작업자 ID";
            this.colWorkerId.MinimumWidth = 8;
            this.colWorkerId.Name = "colWorkerId";
            // 
            // colName
            // 
            this.colName.HeaderText = "이름";
            this.colName.MinimumWidth = 8;
            this.colName.Name = "colName";
            // 
            // colLocation
            // 
            this.colLocation.HeaderText = "위치(구역)";
            this.colLocation.MinimumWidth = 8;
            this.colLocation.Name = "colLocation";
            // 
            // colPpeStatus
            // 
            this.colPpeStatus.HeaderText = "PPE 착용 상태";
            this.colPpeStatus.MinimumWidth = 8;
            this.colPpeStatus.Name = "colPpeStatus";
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "상태";
            this.colStatus.MinimumWidth = 8;
            this.colStatus.Name = "colStatus";
            // 
            // colTime
            // 
            this.colTime.HeaderText = "시간";
            this.colTime.MinimumWidth = 8;
            this.colTime.Name = "colTime";
            // 
            // US_ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblActiveWorkers);
            this.Controls.Add(this.btnResumeOperation);
            this.Controls.Add(this.pnlNumberofAlerts);
            this.Controls.Add(this.pnlSensorStatus);
            this.Controls.Add(this.pnlNoPPEPersonnel);
            this.Controls.Add(this.pnlWorkersList);
            this.Name = "US_ControlForm";
            this.Size = new System.Drawing.Size(1228, 762);
            this.Load += new System.EventHandler(this.US_ControlForm_Load);
            this.pnlNumberofAlerts.ResumeLayout(false);
            this.pnlNumberofAlerts.PerformLayout();
            this.pnlSensorStatus.ResumeLayout(false);
            this.pnlSensorStatus.PerformLayout();
            this.pnlNoPPEPersonnel.ResumeLayout(false);
            this.pnlNoPPEPersonnel.PerformLayout();
            this.pnlWorkersList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveWorkers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnResumeOperation;
        private System.Windows.Forms.Panel pnlNumberofAlerts;
        private System.Windows.Forms.Label lblAlertCount;
        private System.Windows.Forms.Label lblNumberofAlerts;
        private System.Windows.Forms.Panel pnlSensorStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblSensorStatus;
        private System.Windows.Forms.Panel pnlNoPPEPersonnel;
        private System.Windows.Forms.Label lblPersonCount;
        private System.Windows.Forms.Label lblNoPPEPersonnel;
        private System.Windows.Forms.Panel pnlWorkersList;
        private System.Windows.Forms.Label lblActiveWorkers;
        private System.Windows.Forms.DataGridView dgvActiveWorkers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPpeStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
    }
}
