namespace PPE_관제_시스템
{
    partial class DetectionLogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDetectionHeader = new System.Windows.Forms.Label();
            this.pnlGird = new System.Windows.Forms.Panel();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.위치 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblTilde = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnLogSearch = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.lblLine = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnAnalysis = new System.Windows.Forms.Button();
            this.btnDetectionLog = new System.Windows.Forms.Button();
            this.btnControl = new System.Windows.Forms.Button();
            this.lblPPESystem = new System.Windows.Forms.Label();
            this.btnViolationManagement = new System.Windows.Forms.Button();
            this.btnAlerts = new System.Windows.Forms.Button();
            this.btnMonitoring = new System.Windows.Forms.Button();
            this.pnlGird.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDetectionHeader
            // 
            this.lblDetectionHeader.AutoSize = true;
            this.lblDetectionHeader.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDetectionHeader.Location = new System.Drawing.Point(273, 9);
            this.lblDetectionHeader.Name = "lblDetectionHeader";
            this.lblDetectionHeader.Size = new System.Drawing.Size(161, 38);
            this.lblDetectionHeader.TabIndex = 1;
            this.lblDetectionHeader.Text = "이력 / 로그";
            // 
            // pnlGird
            // 
            this.pnlGird.Controls.Add(this.dgvLog);
            this.pnlGird.Location = new System.Drawing.Point(281, 162);
            this.pnlGird.Name = "pnlGird";
            this.pnlGird.Size = new System.Drawing.Size(890, 499);
            this.pnlGird.TabIndex = 2;
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
            this.dgvLog.Size = new System.Drawing.Size(890, 499);
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
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(281, 69);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(221, 25);
            this.dtpStartDate.TabIndex = 3;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(531, 69);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(215, 25);
            this.dtpEndDate.TabIndex = 4;
            // 
            // cmbLocation
            // 
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(664, 120);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(82, 23);
            this.cmbLocation.TabIndex = 5;
            this.cmbLocation.Text = "위치";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(852, 120);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(82, 23);
            this.cmbStatus.TabIndex = 6;
            this.cmbStatus.Text = "상태";
            // 
            // lblTilde
            // 
            this.lblTilde.AutoSize = true;
            this.lblTilde.Location = new System.Drawing.Point(508, 76);
            this.lblTilde.Name = "lblTilde";
            this.lblTilde.Size = new System.Drawing.Size(18, 15);
            this.lblTilde.TabIndex = 7;
            this.lblTilde.Text = "~";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(281, 118);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(260, 25);
            this.txtSearch.TabIndex = 8;
            // 
            // btnLogSearch
            // 
            this.btnLogSearch.Location = new System.Drawing.Point(547, 118);
            this.btnLogSearch.Name = "btnLogSearch";
            this.btnLogSearch.Size = new System.Drawing.Size(79, 25);
            this.btnLogSearch.TabIndex = 9;
            this.btnLogSearch.Text = "검색";
            this.btnLogSearch.UseVisualStyleBackColor = true;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlMenu.Controls.Add(this.lblLine);
            this.pnlMenu.Controls.Add(this.btnSettings);
            this.pnlMenu.Controls.Add(this.btnAnalysis);
            this.pnlMenu.Controls.Add(this.btnDetectionLog);
            this.pnlMenu.Controls.Add(this.btnControl);
            this.pnlMenu.Controls.Add(this.lblPPESystem);
            this.pnlMenu.Controls.Add(this.btnViolationManagement);
            this.pnlMenu.Controls.Add(this.btnAlerts);
            this.pnlMenu.Controls.Add(this.btnMonitoring);
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(268, 676);
            this.pnlMenu.TabIndex = 10;
            // 
            // lblLine
            // 
            this.lblLine.BackColor = System.Drawing.Color.DimGray;
            this.lblLine.Location = new System.Drawing.Point(56, 78);
            this.lblLine.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(160, 2);
            this.lblLine.TabIndex = 9;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSettings.Location = new System.Drawing.Point(21, 452);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(2);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(226, 51);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "설정";
            this.btnSettings.UseVisualStyleBackColor = false;
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnAnalysis.FlatAppearance.BorderSize = 0;
            this.btnAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalysis.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAnalysis.Location = new System.Drawing.Point(22, 397);
            this.btnAnalysis.Margin = new System.Windows.Forms.Padding(2);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(226, 51);
            this.btnAnalysis.TabIndex = 5;
            this.btnAnalysis.Text = "분석";
            this.btnAnalysis.UseVisualStyleBackColor = false;
            // 
            // btnDetectionLog
            // 
            this.btnDetectionLog.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnDetectionLog.FlatAppearance.BorderSize = 0;
            this.btnDetectionLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetectionLog.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDetectionLog.Location = new System.Drawing.Point(21, 341);
            this.btnDetectionLog.Margin = new System.Windows.Forms.Padding(2);
            this.btnDetectionLog.Name = "btnDetectionLog";
            this.btnDetectionLog.Size = new System.Drawing.Size(226, 51);
            this.btnDetectionLog.TabIndex = 4;
            this.btnDetectionLog.Text = "이력 / 로그";
            this.btnDetectionLog.UseVisualStyleBackColor = false;
            // 
            // btnControl
            // 
            this.btnControl.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnControl.FlatAppearance.BorderSize = 0;
            this.btnControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnControl.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnControl.Location = new System.Drawing.Point(21, 285);
            this.btnControl.Margin = new System.Windows.Forms.Padding(2);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(226, 51);
            this.btnControl.TabIndex = 3;
            this.btnControl.Text = "대응 / 제어";
            this.btnControl.UseVisualStyleBackColor = false;
            // 
            // lblPPESystem
            // 
            this.lblPPESystem.AutoSize = true;
            this.lblPPESystem.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPPESystem.Location = new System.Drawing.Point(50, 34);
            this.lblPPESystem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPPESystem.Name = "lblPPESystem";
            this.lblPPESystem.Size = new System.Drawing.Size(177, 31);
            this.lblPPESystem.TabIndex = 2;
            this.lblPPESystem.Text = "PPE 관제시스템";
            // 
            // btnViolationManagement
            // 
            this.btnViolationManagement.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnViolationManagement.FlatAppearance.BorderSize = 0;
            this.btnViolationManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViolationManagement.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViolationManagement.Location = new System.Drawing.Point(21, 229);
            this.btnViolationManagement.Margin = new System.Windows.Forms.Padding(2);
            this.btnViolationManagement.Name = "btnViolationManagement";
            this.btnViolationManagement.Size = new System.Drawing.Size(226, 51);
            this.btnViolationManagement.TabIndex = 2;
            this.btnViolationManagement.Text = "위반관리";
            this.btnViolationManagement.UseVisualStyleBackColor = false;
            // 
            // btnAlerts
            // 
            this.btnAlerts.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnAlerts.FlatAppearance.BorderSize = 0;
            this.btnAlerts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlerts.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAlerts.Location = new System.Drawing.Point(22, 173);
            this.btnAlerts.Margin = new System.Windows.Forms.Padding(2);
            this.btnAlerts.Name = "btnAlerts";
            this.btnAlerts.Size = new System.Drawing.Size(226, 51);
            this.btnAlerts.TabIndex = 1;
            this.btnAlerts.Text = "알림";
            this.btnAlerts.UseVisualStyleBackColor = false;
            // 
            // btnMonitoring
            // 
            this.btnMonitoring.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnMonitoring.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnMonitoring.FlatAppearance.BorderSize = 0;
            this.btnMonitoring.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnMonitoring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonitoring.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMonitoring.Location = new System.Drawing.Point(22, 118);
            this.btnMonitoring.Margin = new System.Windows.Forms.Padding(2);
            this.btnMonitoring.Name = "btnMonitoring";
            this.btnMonitoring.Size = new System.Drawing.Size(226, 51);
            this.btnMonitoring.TabIndex = 0;
            this.btnMonitoring.Text = "실시간 모니터링";
            this.btnMonitoring.UseVisualStyleBackColor = false;
            // 
            // DetectionLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 673);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.btnLogSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblTilde);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.pnlGird);
            this.Controls.Add(this.lblDetectionHeader);
            this.Name = "DetectionLogForm";
            this.Text = "이력 / 로그";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DetectionLogForm_FormClosed);
            this.pnlGird.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDetectionHeader;
        private System.Windows.Forms.Panel pnlGird;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Event;
        private System.Windows.Forms.DataGridViewTextBoxColumn 위치;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detail;
        private System.Windows.Forms.Label lblTilde;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnLogSearch;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnAnalysis;
        private System.Windows.Forms.Button btnDetectionLog;
        private System.Windows.Forms.Button btnControl;
        private System.Windows.Forms.Label lblPPESystem;
        private System.Windows.Forms.Button btnViolationManagement;
        private System.Windows.Forms.Button btnAlerts;
        private System.Windows.Forms.Button btnMonitoring;
    }
}