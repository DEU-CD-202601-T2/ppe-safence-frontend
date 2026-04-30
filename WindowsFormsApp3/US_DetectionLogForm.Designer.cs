namespace PPE_관제_시스템
{
    partial class US_DetectionLogForm
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
            this.btnLogSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblTilde = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.pnlGird = new System.Windows.Forms.Panel();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.위치 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlGird.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogSearch
            // 
            this.btnLogSearch.Location = new System.Drawing.Point(269, 61);
            this.btnLogSearch.Name = "btnLogSearch";
            this.btnLogSearch.Size = new System.Drawing.Size(79, 25);
            this.btnLogSearch.TabIndex = 17;
            this.btnLogSearch.Text = "검색";
            this.btnLogSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(3, 61);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(260, 25);
            this.txtSearch.TabIndex = 16;
            // 
            // lblTilde
            // 
            this.lblTilde.AutoSize = true;
            this.lblTilde.Location = new System.Drawing.Point(230, 19);
            this.lblTilde.Name = "lblTilde";
            this.lblTilde.Size = new System.Drawing.Size(18, 15);
            this.lblTilde.TabIndex = 15;
            this.lblTilde.Text = "~";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(574, 63);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(82, 23);
            this.cmbStatus.TabIndex = 14;
            this.cmbStatus.Text = "상태";
            // 
            // cmbLocation
            // 
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(386, 63);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(82, 23);
            this.cmbLocation.TabIndex = 13;
            this.cmbLocation.Text = "위치";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(253, 12);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(215, 25);
            this.dtpEndDate.TabIndex = 12;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(3, 12);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(221, 25);
            this.dtpStartDate.TabIndex = 11;
            // 
            // pnlGird
            // 
            this.pnlGird.Controls.Add(this.dgvLog);
            this.pnlGird.Location = new System.Drawing.Point(3, 128);
            this.pnlGird.Name = "pnlGird";
            this.pnlGird.Size = new System.Drawing.Size(1222, 622);
            this.pnlGird.TabIndex = 10;
            // 
            // dgvLog
            // 
            this.dgvLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Event,
            this.위치,
            this.Status,
            this.Detail});
            this.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLog.EnableHeadersVisualStyles = false;
            this.dgvLog.Location = new System.Drawing.Point(0, 0);
            this.dgvLog.MultiSelect = false;
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.ReadOnly = true;
            this.dgvLog.RowHeadersVisible = false;
            this.dgvLog.RowHeadersWidth = 51;
            this.dgvLog.RowTemplate.Height = 27;
            this.dgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLog.Size = new System.Drawing.Size(1222, 622);
            this.dgvLog.TabIndex = 0;
            // 
            // Date
            // 
            this.Date.HeaderText = "날짜";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Event
            // 
            this.Event.HeaderText = "발생 내용";
            this.Event.MinimumWidth = 6;
            this.Event.Name = "Event";
            this.Event.ReadOnly = true;
            // 
            // 위치
            // 
            this.위치.HeaderText = "위치";
            this.위치.MinimumWidth = 6;
            this.위치.Name = "위치";
            this.위치.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "상태";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Detail
            // 
            this.Detail.HeaderText = "상세";
            this.Detail.MinimumWidth = 6;
            this.Detail.Name = "Detail";
            this.Detail.ReadOnly = true;
            // 
            // US_DetectionLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLogSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblTilde);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.pnlGird);
            this.Name = "US_DetectionLogForm";
            this.Size = new System.Drawing.Size(1228, 762);
            this.pnlGird.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblTilde;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Panel pnlGird;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Event;
        private System.Windows.Forms.DataGridViewTextBoxColumn 위치;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detail;
    }
}
