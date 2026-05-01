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
            this.btnStopOperation = new System.Windows.Forms.Button();
            this.btnAlert = new System.Windows.Forms.Button();
            this.pnlNumberofAlerts = new System.Windows.Forms.Panel();
            this.lblAlertCount = new System.Windows.Forms.Label();
            this.lblNumberofAlerts = new System.Windows.Forms.Label();
            this.pnlSensorStatus = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblSensorStatus = new System.Windows.Forms.Label();
            this.btnSendAlert = new System.Windows.Forms.Button();
            this.pnlNoPPEPersonnel = new System.Windows.Forms.Panel();
            this.lblPersonCount = new System.Windows.Forms.Label();
            this.lblNoPPEPersonnel = new System.Windows.Forms.Label();
            this.pnlWorkersList = new System.Windows.Forms.Panel();
            this.lblActiveWorkers = new System.Windows.Forms.Label();
            this.dgvActiveWorkers = new System.Windows.Forms.DataGridView();
            this.Coumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlNumberofAlerts.SuspendLayout();
            this.pnlSensorStatus.SuspendLayout();
            this.pnlNoPPEPersonnel.SuspendLayout();
            this.pnlWorkersList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveWorkers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStopOperation
            // 
            this.btnStopOperation.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnStopOperation.FlatAppearance.BorderSize = 0;
            this.btnStopOperation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopOperation.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStopOperation.Location = new System.Drawing.Point(884, 177);
            this.btnStopOperation.Margin = new System.Windows.Forms.Padding(2);
            this.btnStopOperation.Name = "btnStopOperation";
            this.btnStopOperation.Size = new System.Drawing.Size(342, 38);
            this.btnStopOperation.TabIndex = 12;
            this.btnStopOperation.Text = "작업 중지";
            this.btnStopOperation.UseVisualStyleBackColor = false;
            // 
            // btnAlert
            // 
            this.btnAlert.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnAlert.FlatAppearance.BorderSize = 0;
            this.btnAlert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlert.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAlert.Location = new System.Drawing.Point(444, 177);
            this.btnAlert.Margin = new System.Windows.Forms.Padding(2);
            this.btnAlert.Name = "btnAlert";
            this.btnAlert.Size = new System.Drawing.Size(342, 38);
            this.btnAlert.TabIndex = 11;
            this.btnAlert.Text = "알림";
            this.btnAlert.UseVisualStyleBackColor = false;
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
            this.lblNumberofAlerts.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNumberofAlerts.Location = new System.Drawing.Point(5, 2);
            this.lblNumberofAlerts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumberofAlerts.Name = "lblNumberofAlerts";
            this.lblNumberofAlerts.Size = new System.Drawing.Size(145, 31);
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
            this.lblSensorStatus.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSensorStatus.Location = new System.Drawing.Point(5, 2);
            this.lblSensorStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSensorStatus.Name = "lblSensorStatus";
            this.lblSensorStatus.Size = new System.Drawing.Size(114, 31);
            this.lblSensorStatus.TabIndex = 6;
            this.lblSensorStatus.Text = "센서 상태";
            // 
            // btnSendAlert
            // 
            this.btnSendAlert.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSendAlert.FlatAppearance.BorderSize = 0;
            this.btnSendAlert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendAlert.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSendAlert.Location = new System.Drawing.Point(0, 177);
            this.btnSendAlert.Margin = new System.Windows.Forms.Padding(2);
            this.btnSendAlert.Name = "btnSendAlert";
            this.btnSendAlert.Size = new System.Drawing.Size(344, 38);
            this.btnSendAlert.TabIndex = 8;
            this.btnSendAlert.Text = "경고 전송";
            this.btnSendAlert.UseVisualStyleBackColor = false;
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
            this.lblNoPPEPersonnel.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNoPPEPersonnel.Location = new System.Drawing.Point(5, 2);
            this.lblNoPPEPersonnel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNoPPEPersonnel.Name = "lblNoPPEPersonnel";
            this.lblNoPPEPersonnel.Size = new System.Drawing.Size(185, 31);
            this.lblNoPPEPersonnel.TabIndex = 4;
            this.lblNoPPEPersonnel.Text = "PPE 미착용 인원";
            // 
            // pnlWorkersList
            // 
            this.pnlWorkersList.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlWorkersList.Controls.Add(this.dgvActiveWorkers);
            this.pnlWorkersList.Location = new System.Drawing.Point(2, 295);
            this.pnlWorkersList.Margin = new System.Windows.Forms.Padding(2);
            this.pnlWorkersList.Name = "pnlWorkersList";
            this.pnlWorkersList.Size = new System.Drawing.Size(1224, 467);
            this.pnlWorkersList.TabIndex = 10;
            // 
            // lblActiveWorkers
            // 
            this.lblActiveWorkers.AutoSize = true;
            this.lblActiveWorkers.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblActiveWorkers.Location = new System.Drawing.Point(9, 257);
            this.lblActiveWorkers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblActiveWorkers.Name = "lblActiveWorkers";
            this.lblActiveWorkers.Size = new System.Drawing.Size(158, 23);
            this.lblActiveWorkers.TabIndex = 9;
            this.lblActiveWorkers.Text = "실시간 작업자 목록";
            // 
            // dgvActiveWorkers
            // 
            this.dgvActiveWorkers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActiveWorkers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActiveWorkers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Coumn1,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvActiveWorkers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActiveWorkers.Location = new System.Drawing.Point(0, 0);
            this.dgvActiveWorkers.Margin = new System.Windows.Forms.Padding(2);
            this.dgvActiveWorkers.Name = "dgvActiveWorkers";
            this.dgvActiveWorkers.RowHeadersWidth = 62;
            this.dgvActiveWorkers.RowTemplate.Height = 30;
            this.dgvActiveWorkers.Size = new System.Drawing.Size(1224, 467);
            this.dgvActiveWorkers.TabIndex = 3;
            // 
            // Coumn1
            // 
            this.Coumn1.HeaderText = "작업자 ID";
            this.Coumn1.MinimumWidth = 8;
            this.Coumn1.Name = "Coumn1";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "이름";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "위치(구역)";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "PPE 착용 상태";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "상태";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "시간";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            // 
            // US_ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblActiveWorkers);
            this.Controls.Add(this.btnStopOperation);
            this.Controls.Add(this.btnAlert);
            this.Controls.Add(this.pnlNumberofAlerts);
            this.Controls.Add(this.pnlSensorStatus);
            this.Controls.Add(this.btnSendAlert);
            this.Controls.Add(this.pnlNoPPEPersonnel);
            this.Controls.Add(this.pnlWorkersList);
            this.Name = "US_ControlForm";
            this.Size = new System.Drawing.Size(1228, 762);
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

        private System.Windows.Forms.Button btnStopOperation;
        private System.Windows.Forms.Button btnAlert;
        private System.Windows.Forms.Panel pnlNumberofAlerts;
        private System.Windows.Forms.Label lblAlertCount;
        private System.Windows.Forms.Label lblNumberofAlerts;
        private System.Windows.Forms.Panel pnlSensorStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblSensorStatus;
        private System.Windows.Forms.Button btnSendAlert;
        private System.Windows.Forms.Panel pnlNoPPEPersonnel;
        private System.Windows.Forms.Label lblPersonCount;
        private System.Windows.Forms.Label lblNoPPEPersonnel;
        private System.Windows.Forms.Panel pnlWorkersList;
        private System.Windows.Forms.Label lblActiveWorkers;
        private System.Windows.Forms.DataGridView dgvActiveWorkers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}
