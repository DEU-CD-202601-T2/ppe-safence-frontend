namespace PPE_관제_시스템
{
    partial class US_UsersSettings
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
            this.dgvUserSetting = new System.Windows.Forms.DataGridView();
            this.user_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserSetting)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUserSetting
            // 
            this.dgvUserSetting.AllowUserToAddRows = false;
            this.dgvUserSetting.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUserSetting.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUserSetting.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUserSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserSetting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.user_name,
            this.user_id,
            this.role,
            this.location,
            this.status,
            this.manage});
            this.dgvUserSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUserSetting.Location = new System.Drawing.Point(0, 0);
            this.dgvUserSetting.MultiSelect = false;
            this.dgvUserSetting.Name = "dgvUserSetting";
            this.dgvUserSetting.RowHeadersWidth = 51;
            this.dgvUserSetting.RowTemplate.Height = 27;
            this.dgvUserSetting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserSetting.Size = new System.Drawing.Size(945, 487);
            this.dgvUserSetting.TabIndex = 0;
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
            // US_UsersSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.dgvUserSetting);
            this.Name = "US_UsersSettings";
            this.Size = new System.Drawing.Size(945, 487);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserSetting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUserSetting;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn role;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn manage;
    }
}
