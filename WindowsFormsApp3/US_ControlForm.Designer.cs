namespace PPE_관제_시스템
{
    partial class US_ControlForm
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpCards = new System.Windows.Forms.TableLayoutPanel();
            this.pnlNoPPEPersonnel = new System.Windows.Forms.Panel();
            this.lblPersonCount = new System.Windows.Forms.Label();
            this.lblNoPPEPersonnel = new System.Windows.Forms.Label();
            this.pnlNumberofAlerts = new System.Windows.Forms.Panel();
            this.lblAlertCount = new System.Windows.Forms.Label();
            this.lblNumberofAlerts = new System.Windows.Forms.Label();
            this.pnlSensorStatus = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblSensorStatus = new System.Windows.Forms.Label();
            this.pnlHeaderRow = new System.Windows.Forms.Panel();
            this.lblActiveWorkers = new System.Windows.Forms.Label();
            this.btnResumeOperation = new System.Windows.Forms.Button();
            this.pnlWorkersList = new System.Windows.Forms.Panel();
            this.dgvActiveWorkers = new System.Windows.Forms.DataGridView();
            this.colWorkerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPpeStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpMain.SuspendLayout();
            this.tlpCards.SuspendLayout();
            this.pnlNoPPEPersonnel.SuspendLayout();
            this.pnlNumberofAlerts.SuspendLayout();
            this.pnlSensorStatus.SuspendLayout();
            this.pnlHeaderRow.SuspendLayout();
            this.pnlWorkersList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveWorkers)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = AppColors.Background;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpCards, 0, 0);
            this.tlpMain.Controls.Add(this.pnlHeaderRow, 0, 1);
            this.tlpMain.Controls.Add(this.pnlWorkersList, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1228, 762);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpCards
            // 
            this.tlpCards.ColumnCount = 3;
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpCards.Controls.Add(this.pnlNoPPEPersonnel, 0, 0);
            this.tlpCards.Controls.Add(this.pnlNumberofAlerts, 1, 0);
            this.tlpCards.Controls.Add(this.pnlSensorStatus, 2, 0);
            this.tlpCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCards.Location = new System.Drawing.Point(3, 3);
            this.tlpCards.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tlpCards.Name = "tlpCards";
            this.tlpCards.RowCount = 1;
            this.tlpCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCards.Size = new System.Drawing.Size(1222, 157);
            this.tlpCards.TabIndex = 0;
            // 
            // pnlNoPPEPersonnel
            // 
            this.pnlNoPPEPersonnel.BackColor = AppColors.Surface;
            this.pnlNoPPEPersonnel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNoPPEPersonnel.Controls.Add(this.lblPersonCount);
            this.pnlNoPPEPersonnel.Controls.Add(this.lblNoPPEPersonnel);
            this.pnlNoPPEPersonnel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNoPPEPersonnel.Location = new System.Drawing.Point(8, 8);
            this.pnlNoPPEPersonnel.Margin = new System.Windows.Forms.Padding(8);
            this.pnlNoPPEPersonnel.Name = "pnlNoPPEPersonnel";
            this.pnlNoPPEPersonnel.Size = new System.Drawing.Size(391, 141);
            this.pnlNoPPEPersonnel.TabIndex = 0;
            // 
            // lblNoPPEPersonnel
            // 
            this.lblNoPPEPersonnel.AutoSize = true;
            this.lblNoPPEPersonnel.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblNoPPEPersonnel.ForeColor = AppColors.PrimaryDark;
            this.lblNoPPEPersonnel.Location = new System.Drawing.Point(18, 15);
            this.lblNoPPEPersonnel.Name = "lblNoPPEPersonnel";
            this.lblNoPPEPersonnel.Size = new System.Drawing.Size(143, 25);
            this.lblNoPPEPersonnel.TabIndex = 0;
            this.lblNoPPEPersonnel.Text = "PPE 미착용 인원";
            // 
            // lblPersonCount
            // 
            this.lblPersonCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPersonCount.AutoSize = true;
            this.lblPersonCount.BackColor = System.Drawing.Color.Transparent;
            this.lblPersonCount.Font = new System.Drawing.Font("맑은 고딕", 28F, System.Drawing.FontStyle.Bold);
            this.lblPersonCount.ForeColor = AppColors.Danger;
            this.lblPersonCount.Location = new System.Drawing.Point(298, 73);
            this.lblPersonCount.Name = "lblPersonCount";
            this.lblPersonCount.Size = new System.Drawing.Size(82, 62);
            this.lblPersonCount.TabIndex = 1;
            this.lblPersonCount.Text = "0명";
            // 
            // pnlNumberofAlerts
            // 
            this.pnlNumberofAlerts.BackColor = AppColors.Surface;
            this.pnlNumberofAlerts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNumberofAlerts.Controls.Add(this.lblAlertCount);
            this.pnlNumberofAlerts.Controls.Add(this.lblNumberofAlerts);
            this.pnlNumberofAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNumberofAlerts.Location = new System.Drawing.Point(415, 8);
            this.pnlNumberofAlerts.Margin = new System.Windows.Forms.Padding(8);
            this.pnlNumberofAlerts.Name = "pnlNumberofAlerts";
            this.pnlNumberofAlerts.Size = new System.Drawing.Size(391, 141);
            this.pnlNumberofAlerts.TabIndex = 1;
            // 
            // lblNumberofAlerts
            // 
            this.lblNumberofAlerts.AutoSize = true;
            this.lblNumberofAlerts.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblNumberofAlerts.ForeColor = AppColors.PrimaryDark;
            this.lblNumberofAlerts.Location = new System.Drawing.Point(18, 15);
            this.lblNumberofAlerts.Name = "lblNumberofAlerts";
            this.lblNumberofAlerts.Size = new System.Drawing.Size(114, 25);
            this.lblNumberofAlerts.TabIndex = 0;
            this.lblNumberofAlerts.Text = "경고 발생 수";
            // 
            // lblAlertCount
            // 
            this.lblAlertCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlertCount.AutoSize = true;
            this.lblAlertCount.BackColor = System.Drawing.Color.Transparent;
            this.lblAlertCount.Font = new System.Drawing.Font("맑은 고딕", 28F, System.Drawing.FontStyle.Bold);
            this.lblAlertCount.ForeColor = AppColors.Accent;
            this.lblAlertCount.Location = new System.Drawing.Point(298, 73);
            this.lblAlertCount.Name = "lblAlertCount";
            this.lblAlertCount.Size = new System.Drawing.Size(82, 62);
            this.lblAlertCount.TabIndex = 1;
            this.lblAlertCount.Text = "0건";
            // 
            // pnlSensorStatus
            // 
            this.pnlSensorStatus.BackColor = AppColors.Surface;
            this.pnlSensorStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSensorStatus.Controls.Add(this.lblStatus);
            this.pnlSensorStatus.Controls.Add(this.lblSensorStatus);
            this.pnlSensorStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSensorStatus.Location = new System.Drawing.Point(822, 8);
            this.pnlSensorStatus.Margin = new System.Windows.Forms.Padding(8);
            this.pnlSensorStatus.Name = "pnlSensorStatus";
            this.pnlSensorStatus.Size = new System.Drawing.Size(392, 141);
            this.pnlSensorStatus.TabIndex = 2;
            // 
            // lblSensorStatus
            // 
            this.lblSensorStatus.AutoSize = true;
            this.lblSensorStatus.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblSensorStatus.ForeColor = AppColors.PrimaryDark;
            this.lblSensorStatus.Location = new System.Drawing.Point(18, 15);
            this.lblSensorStatus.Name = "lblSensorStatus";
            this.lblSensorStatus.Size = new System.Drawing.Size(92, 25);
            this.lblSensorStatus.TabIndex = 0;
            this.lblSensorStatus.Text = "센서 상태";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("맑은 고딕", 28F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = AppColors.Success;
            this.lblStatus.Location = new System.Drawing.Point(282, 73);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 62);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "정상";
            // 
            // pnlHeaderRow
            // 
            this.pnlHeaderRow.BackColor = AppColors.Background;
            this.pnlHeaderRow.Controls.Add(this.lblActiveWorkers);
            this.pnlHeaderRow.Controls.Add(this.btnResumeOperation);
            this.pnlHeaderRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeaderRow.Location = new System.Drawing.Point(8, 165);
            this.pnlHeaderRow.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.pnlHeaderRow.Name = "pnlHeaderRow";
            this.pnlHeaderRow.Size = new System.Drawing.Size(1212, 50);
            this.pnlHeaderRow.TabIndex = 1;
            // 
            // lblActiveWorkers
            // 
            this.lblActiveWorkers.AutoSize = true;
            this.lblActiveWorkers.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.lblActiveWorkers.ForeColor = AppColors.Text;
            this.lblActiveWorkers.Location = new System.Drawing.Point(15, 12);
            this.lblActiveWorkers.Name = "lblActiveWorkers";
            this.lblActiveWorkers.Size = new System.Drawing.Size(187, 29);
            this.lblActiveWorkers.TabIndex = 0;
            this.lblActiveWorkers.Text = "실시간 작업자 목록";
            // 
            // btnResumeOperation
            // 
            this.btnResumeOperation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResumeOperation.BackColor = AppColors.Accent;
            this.btnResumeOperation.FlatAppearance.BorderSize = 0;
            this.btnResumeOperation.FlatAppearance.MouseOverBackColor = AppColors.AccentDark;
            this.btnResumeOperation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResumeOperation.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnResumeOperation.ForeColor = AppColors.TextOnAccent;
            this.btnResumeOperation.Location = new System.Drawing.Point(1037, 5);
            this.btnResumeOperation.Margin = new System.Windows.Forms.Padding(2);
            this.btnResumeOperation.Name = "btnResumeOperation";
            this.btnResumeOperation.Size = new System.Drawing.Size(170, 40);
            this.btnResumeOperation.TabIndex = 1;
            this.btnResumeOperation.Text = "작업 중지 해제";
            this.btnResumeOperation.UseVisualStyleBackColor = false;
            this.btnResumeOperation.Click += new System.EventHandler(this.btnResumeOperation_Click);
            // 
            // pnlWorkersList
            // 
            this.pnlWorkersList.BackColor = AppColors.Surface;
            this.pnlWorkersList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlWorkersList.Controls.Add(this.dgvActiveWorkers);
            this.pnlWorkersList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWorkersList.Location = new System.Drawing.Point(8, 223);
            this.pnlWorkersList.Margin = new System.Windows.Forms.Padding(8, 0, 8, 8);
            this.pnlWorkersList.Name = "pnlWorkersList";
            this.pnlWorkersList.Size = new System.Drawing.Size(1212, 531);
            this.pnlWorkersList.TabIndex = 2;
            // 
            // dgvActiveWorkers
            // 
            this.dgvActiveWorkers.AllowUserToAddRows = false;
            this.dgvActiveWorkers.AllowUserToResizeRows = false;
            this.dgvActiveWorkers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActiveWorkers.BackgroundColor = AppColors.Surface;
            this.dgvActiveWorkers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvActiveWorkers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvActiveWorkers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvActiveWorkers.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvActiveWorkers.ColumnHeadersDefaultCellStyle.BackColor = AppColors.PrimaryLight;
            this.dgvActiveWorkers.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.dgvActiveWorkers.ColumnHeadersDefaultCellStyle.ForeColor = AppColors.PrimaryDark;
            this.dgvActiveWorkers.ColumnHeadersDefaultCellStyle.SelectionBackColor = AppColors.PrimaryLight;
            this.dgvActiveWorkers.ColumnHeadersDefaultCellStyle.SelectionForeColor = AppColors.PrimaryDark;
            this.dgvActiveWorkers.ColumnHeadersHeight = 50;
            this.dgvActiveWorkers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvActiveWorkers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colWorkerId,
            this.colName,
            this.colLocation,
            this.colPpeStatus,
            this.colStatus,
            this.colTime});
            this.dgvActiveWorkers.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvActiveWorkers.DefaultCellStyle.BackColor = AppColors.Surface;
            this.dgvActiveWorkers.DefaultCellStyle.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.dgvActiveWorkers.DefaultCellStyle.ForeColor = AppColors.Text;
            this.dgvActiveWorkers.DefaultCellStyle.SelectionBackColor = AppColors.PrimaryLight;
            this.dgvActiveWorkers.DefaultCellStyle.SelectionForeColor = AppColors.Text;
            this.dgvActiveWorkers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActiveWorkers.EnableHeadersVisualStyles = false;
            this.dgvActiveWorkers.GridColor = AppColors.Border;
            this.dgvActiveWorkers.Location = new System.Drawing.Point(0, 0);
            this.dgvActiveWorkers.Margin = new System.Windows.Forms.Padding(2);
            this.dgvActiveWorkers.Name = "dgvActiveWorkers";
            this.dgvActiveWorkers.RowHeadersVisible = false;
            this.dgvActiveWorkers.RowHeadersWidth = 62;
            this.dgvActiveWorkers.RowTemplate.Height = 40;
            this.dgvActiveWorkers.Size = new System.Drawing.Size(1210, 529);
            this.dgvActiveWorkers.TabIndex = 0;
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
            this.BackColor = AppColors.Background;
            this.Controls.Add(this.tlpMain);
            this.Name = "US_ControlForm";
            this.Size = new System.Drawing.Size(1228, 762);
            this.Load += new System.EventHandler(this.US_ControlForm_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpCards.ResumeLayout(false);
            this.pnlNoPPEPersonnel.ResumeLayout(false);
            this.pnlNoPPEPersonnel.PerformLayout();
            this.pnlNumberofAlerts.ResumeLayout(false);
            this.pnlNumberofAlerts.PerformLayout();
            this.pnlSensorStatus.ResumeLayout(false);
            this.pnlSensorStatus.PerformLayout();
            this.pnlHeaderRow.ResumeLayout(false);
            this.pnlHeaderRow.PerformLayout();
            this.pnlWorkersList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveWorkers)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpCards;
        private System.Windows.Forms.Panel pnlNoPPEPersonnel;
        private System.Windows.Forms.Label lblPersonCount;
        private System.Windows.Forms.Label lblNoPPEPersonnel;
        private System.Windows.Forms.Panel pnlNumberofAlerts;
        private System.Windows.Forms.Label lblAlertCount;
        private System.Windows.Forms.Label lblNumberofAlerts;
        private System.Windows.Forms.Panel pnlSensorStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblSensorStatus;
        private System.Windows.Forms.Panel pnlHeaderRow;
        private System.Windows.Forms.Label lblActiveWorkers;
        private System.Windows.Forms.Button btnResumeOperation;
        private System.Windows.Forms.Panel pnlWorkersList;
        private System.Windows.Forms.DataGridView dgvActiveWorkers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPpeStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
    }
}