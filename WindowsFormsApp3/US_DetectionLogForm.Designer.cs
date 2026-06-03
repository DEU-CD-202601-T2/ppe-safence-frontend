namespace PPE_관제_시스템
{
    partial class US_DetectionLogForm
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
            this.pnlFilterBar = new System.Windows.Forms.Panel();
            this.lblFilterDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblTilde = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.txtLogSearch = new System.Windows.Forms.TextBox();
            this.btnLogSearch = new System.Windows.Forms.Button();
            this.pnlGird = new System.Windows.Forms.Panel();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFilterBar.SuspendLayout();
            this.pnlGird.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.SuspendLayout();
            // 
            // 
            // 
            // pnlFilterBar
            // 
            this.pnlFilterBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilterBar.BackColor = AppColors.SurfaceAlt;
            this.pnlFilterBar.Controls.Add(this.lblFilterDate);
            this.pnlFilterBar.Controls.Add(this.dtpStartDate);
            this.pnlFilterBar.Controls.Add(this.lblTilde);
            this.pnlFilterBar.Controls.Add(this.dtpEndDate);
            this.pnlFilterBar.Controls.Add(this.txtLogSearch);
            this.pnlFilterBar.Controls.Add(this.btnLogSearch);
            this.pnlFilterBar.Location = new System.Drawing.Point(20, 50);
            this.pnlFilterBar.Name = "pnlFilterBar";
            this.pnlFilterBar.Size = new System.Drawing.Size(1188, 70);
            this.pnlFilterBar.TabIndex = 1;
            // 
            // lblFilterDate
            // 
            this.lblFilterDate.AutoSize = true;
            this.lblFilterDate.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.lblFilterDate.ForeColor = AppColors.PrimaryDark;
            this.lblFilterDate.Location = new System.Drawing.Point(20, 25);
            this.lblFilterDate.Name = "lblFilterDate";
            this.lblFilterDate.Size = new System.Drawing.Size(49, 23);
            this.lblFilterDate.TabIndex = 0;
            this.lblFilterDate.Text = "기간";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.dtpStartDate.Location = new System.Drawing.Point(80, 20);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(180, 30);
            this.dtpStartDate.TabIndex = 1;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // lblTilde
            // 
            this.lblTilde.AutoSize = true;
            this.lblTilde.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lblTilde.ForeColor = AppColors.Text;
            this.lblTilde.Location = new System.Drawing.Point(265, 24);
            this.lblTilde.Name = "lblTilde";
            this.lblTilde.Size = new System.Drawing.Size(19, 25);
            this.lblTilde.TabIndex = 2;
            this.lblTilde.Text = "~";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.dtpEndDate.Location = new System.Drawing.Point(290, 20);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(180, 30);
            this.dtpEndDate.TabIndex = 3;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            // 
            // txtLogSearch
            // 
            this.txtLogSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogSearch.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtLogSearch.ForeColor = AppColors.Text;
            this.txtLogSearch.Location = new System.Drawing.Point(850, 20);
            this.txtLogSearch.Name = "txtLogSearch";
            this.txtLogSearch.Size = new System.Drawing.Size(220, 30);
            this.txtLogSearch.TabIndex = 4;
            this.txtLogSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLogSearch_KeyDown);
            // 
            // btnLogSearch
            // 
            this.btnLogSearch.BackColor = AppColors.Primary;
            this.btnLogSearch.FlatAppearance.BorderSize = 0;
            this.btnLogSearch.FlatAppearance.MouseOverBackColor = AppColors.PrimaryDark;
            this.btnLogSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogSearch.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogSearch.ForeColor = AppColors.TextOnPrimary;
            this.btnLogSearch.Location = new System.Drawing.Point(1080, 18);
            this.btnLogSearch.Name = "btnLogSearch";
            this.btnLogSearch.Size = new System.Drawing.Size(90, 34);
            this.btnLogSearch.TabIndex = 5;
            this.btnLogSearch.Text = "검색";
            this.btnLogSearch.UseVisualStyleBackColor = false;
            this.btnLogSearch.Click += new System.EventHandler(this.btnLogSearch_Click);
            // 
            // pnlGird
            // 
            this.pnlGird.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGird.BackColor = AppColors.Surface;
            this.pnlGird.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGird.Controls.Add(this.dgvLog);
            this.pnlGird.Location = new System.Drawing.Point(20, 130);
            this.pnlGird.Name = "pnlGird";
            this.pnlGird.Size = new System.Drawing.Size(1188, 615);
            this.pnlGird.TabIndex = 2;
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToResizeRows = false;
            this.dgvLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLog.BackgroundColor = AppColors.Surface;
            this.dgvLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLog.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvLog.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvLog.ColumnHeadersDefaultCellStyle.BackColor = AppColors.PrimaryLight;
            this.dgvLog.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.dgvLog.ColumnHeadersDefaultCellStyle.ForeColor = AppColors.PrimaryDark;
            this.dgvLog.ColumnHeadersDefaultCellStyle.SelectionBackColor = AppColors.PrimaryLight;
            this.dgvLog.ColumnHeadersDefaultCellStyle.SelectionForeColor = AppColors.PrimaryDark;
            this.dgvLog.ColumnHeadersHeight = 50;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Event,
            this.Detail});
            this.dgvLog.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvLog.DefaultCellStyle.BackColor = AppColors.Surface;
            this.dgvLog.DefaultCellStyle.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.dgvLog.DefaultCellStyle.ForeColor = AppColors.Text;
            this.dgvLog.DefaultCellStyle.SelectionBackColor = AppColors.PrimaryLight;
            this.dgvLog.DefaultCellStyle.SelectionForeColor = AppColors.Text;
            this.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLog.EnableHeadersVisualStyles = false;
            this.dgvLog.GridColor = AppColors.Border;
            this.dgvLog.Location = new System.Drawing.Point(0, 0);
            this.dgvLog.MultiSelect = false;
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.ReadOnly = true;
            this.dgvLog.RowHeadersVisible = false;
            this.dgvLog.RowHeadersWidth = 51;
            this.dgvLog.RowTemplate.Height = 40;
            this.dgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLog.Size = new System.Drawing.Size(1186, 613);
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
            this.BackColor = AppColors.Background;
            this.Controls.Add(this.pnlGird);
            this.Controls.Add(this.pnlFilterBar);
            this.Name = "US_DetectionLogForm";
            this.Size = new System.Drawing.Size(1228, 762);
            this.Load += new System.EventHandler(this.US_DetectionLogForm_Load);
            this.pnlFilterBar.ResumeLayout(false);
            this.pnlFilterBar.PerformLayout();
            this.pnlGird.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlFilterBar;
        private System.Windows.Forms.Label lblFilterDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblTilde;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.TextBox txtLogSearch;
        private System.Windows.Forms.Button btnLogSearch;
        private System.Windows.Forms.Panel pnlGird;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Event;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detail;
    }
}