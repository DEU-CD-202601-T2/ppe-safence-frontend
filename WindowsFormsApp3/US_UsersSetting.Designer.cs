namespace PPE_관제_시스템
{
    partial class US_UsersSetting
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
            this.lblUsersSetting = new System.Windows.Forms.Label();
            this.btnUserAdd = new System.Windows.Forms.Button();
            this.pnlGridContainer = new System.Windows.Forms.Panel();
            this.dgvUsersSetting = new System.Windows.Forms.DataGridView();
            this.user_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.pnlGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersSetting)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsersSetting
            // 
            this.lblUsersSetting.AutoSize = true;
            this.lblUsersSetting.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUsersSetting.ForeColor = AppColors.Text;
            this.lblUsersSetting.Location = new System.Drawing.Point(20, 10);
            this.lblUsersSetting.Name = "lblUsersSetting";
            this.lblUsersSetting.Size = new System.Drawing.Size(141, 31);
            this.lblUsersSetting.TabIndex = 0;
            this.lblUsersSetting.Text = "사용자 설정";
            // 
            // btnUserAdd
            // 
            this.btnUserAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserAdd.BackColor = AppColors.Primary;
            this.btnUserAdd.FlatAppearance.BorderSize = 0;
            this.btnUserAdd.FlatAppearance.MouseOverBackColor = AppColors.PrimaryDark;
            this.btnUserAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserAdd.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnUserAdd.ForeColor = AppColors.TextOnPrimary;
            this.btnUserAdd.Location = new System.Drawing.Point(1060, 10);
            this.btnUserAdd.Name = "btnUserAdd";
            this.btnUserAdd.Size = new System.Drawing.Size(140, 40);
            this.btnUserAdd.TabIndex = 1;
            this.btnUserAdd.Text = "+ 사용자 추가";
            this.btnUserAdd.UseVisualStyleBackColor = false;
            this.btnUserAdd.Click += new System.EventHandler(this.btnUserAdd_Click);
            // 
            // pnlGridContainer
            // 
            this.pnlGridContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGridContainer.BackColor = AppColors.Surface;
            this.pnlGridContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGridContainer.Controls.Add(this.dgvUsersSetting);
            this.pnlGridContainer.Location = new System.Drawing.Point(20, 65);
            this.pnlGridContainer.Name = "pnlGridContainer";
            this.pnlGridContainer.Padding = new System.Windows.Forms.Padding(0);
            this.pnlGridContainer.Size = new System.Drawing.Size(1179, 575);
            this.pnlGridContainer.TabIndex = 2;
            // 
            // dgvUsersSetting
            // 
            this.dgvUsersSetting.AllowUserToAddRows = false;
            this.dgvUsersSetting.AllowUserToResizeRows = false;
            this.dgvUsersSetting.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsersSetting.BackgroundColor = AppColors.Surface;
            this.dgvUsersSetting.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsersSetting.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsersSetting.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvUsersSetting.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvUsersSetting.ColumnHeadersDefaultCellStyle.BackColor = AppColors.PrimaryLight;
            this.dgvUsersSetting.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.dgvUsersSetting.ColumnHeadersDefaultCellStyle.ForeColor = AppColors.PrimaryDark;
            this.dgvUsersSetting.ColumnHeadersDefaultCellStyle.SelectionBackColor = AppColors.PrimaryLight;
            this.dgvUsersSetting.ColumnHeadersDefaultCellStyle.SelectionForeColor = AppColors.PrimaryDark;
            this.dgvUsersSetting.ColumnHeadersHeight = 50;
            this.dgvUsersSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUsersSetting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.user_name,
            this.user_id,
            this.role,
            this.location,
            this.status,
            this.manage});
            this.dgvUsersSetting.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvUsersSetting.DefaultCellStyle.BackColor = AppColors.Surface;
            this.dgvUsersSetting.DefaultCellStyle.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.dgvUsersSetting.DefaultCellStyle.ForeColor = AppColors.Text;
            this.dgvUsersSetting.DefaultCellStyle.SelectionBackColor = AppColors.PrimaryLight;
            this.dgvUsersSetting.DefaultCellStyle.SelectionForeColor = AppColors.Text;
            this.dgvUsersSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsersSetting.EnableHeadersVisualStyles = false;
            this.dgvUsersSetting.GridColor = AppColors.Border;
            this.dgvUsersSetting.Location = new System.Drawing.Point(0, 0);
            this.dgvUsersSetting.MultiSelect = false;
            this.dgvUsersSetting.Name = "dgvUsersSetting";
            this.dgvUsersSetting.RowHeadersVisible = false;
            this.dgvUsersSetting.RowHeadersWidth = 51;
            this.dgvUsersSetting.RowTemplate.Height = 40;
            this.dgvUsersSetting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsersSetting.Size = new System.Drawing.Size(1177, 573);
            this.dgvUsersSetting.TabIndex = 0;
            // 
            // user_name
            // 
            this.user_name.HeaderText = "이름";
            this.user_name.MinimumWidth = 6;
            this.user_name.Name = "user_name";
            // 
            // user_id
            // 
            this.user_id.HeaderText = "ID";
            this.user_id.MinimumWidth = 6;
            this.user_id.Name = "user_id";
            // 
            // role
            // 
            this.role.HeaderText = "역할";
            this.role.MinimumWidth = 6;
            this.role.Name = "role";
            // 
            // location
            // 
            this.location.HeaderText = "소속(구역)";
            this.location.MinimumWidth = 6;
            this.location.Name = "location";
            // 
            // status
            // 
            this.status.HeaderText = "상태";
            this.status.MinimumWidth = 6;
            this.status.Name = "status";
            // 
            // manage
            // 
            this.manage.HeaderText = "관리";
            this.manage.MinimumWidth = 6;
            this.manage.Name = "manage";
            // 
            // cmbZone
            // 
            this.cmbZone.Location = new System.Drawing.Point(0, 0);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(121, 23);
            this.cmbZone.TabIndex = 3;
            this.cmbZone.Visible = false;
            // 
            // US_UsersSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = AppColors.Background;
            this.Controls.Add(this.cmbZone);
            this.Controls.Add(this.btnUserAdd);
            this.Controls.Add(this.lblUsersSetting);
            this.Controls.Add(this.pnlGridContainer);
            this.Name = "US_UsersSetting";
            this.Size = new System.Drawing.Size(1219, 653);
            this.Load += new System.EventHandler(this.US_UsersSetting_Load);
            this.pnlGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersSetting)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lblUsersSetting;
        private System.Windows.Forms.Button btnUserAdd;
        private System.Windows.Forms.Panel pnlGridContainer;
        private System.Windows.Forms.DataGridView dgvUsersSetting;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn role;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn manage;
        private System.Windows.Forms.ComboBox cmbZone;
    }
}