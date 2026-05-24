using System.Runtime.CompilerServices;

namespace PPE_관제_시스템
{
    partial class US_UsersSetting
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
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.dgvUsersSetting = new System.Windows.Forms.DataGridView();
            this.user_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUsersSetting = new System.Windows.Forms.Label();
            this.btnUserAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersSetting)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbZone
            // 
            this.cmbZone.Location = new System.Drawing.Point(0, 0);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(121, 23);
            this.cmbZone.TabIndex = 0;
            // 
            // dgvUsersSetting
            // 
            this.dgvUsersSetting.AllowUserToAddRows = false;
            this.dgvUsersSetting.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsersSetting.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsersSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsersSetting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.user_name,
            this.user_id,
            this.role,
            this.location,
            this.status,
            this.manage});
            this.dgvUsersSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsersSetting.Location = new System.Drawing.Point(0, 0);
            this.dgvUsersSetting.MultiSelect = false;
            this.dgvUsersSetting.Name = "dgvUsersSetting";
            this.dgvUsersSetting.RowHeadersVisible = false;
            this.dgvUsersSetting.RowHeadersWidth = 51;
            this.dgvUsersSetting.RowTemplate.Height = 27;
            this.dgvUsersSetting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsersSetting.Size = new System.Drawing.Size(1219, 605);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvUsersSetting);
            this.panel1.Location = new System.Drawing.Point(1, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1219, 605);
            this.panel1.TabIndex = 1;
            // 
            // lblUsersSetting
            // 
            this.lblUsersSetting.AutoSize = true;
            this.lblUsersSetting.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUsersSetting.Location = new System.Drawing.Point(3, 3);
            this.lblUsersSetting.Name = "lblUsersSetting";
            this.lblUsersSetting.Size = new System.Drawing.Size(137, 31);
            this.lblUsersSetting.TabIndex = 2;
            this.lblUsersSetting.Text = "사용자 설정";
            // 
            // btnUserAdd
            // 
            this.btnUserAdd.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUserAdd.Location = new System.Drawing.Point(1068, 3);
            this.btnUserAdd.Name = "btnUserAdd";
            this.btnUserAdd.Size = new System.Drawing.Size(129, 39);
            this.btnUserAdd.TabIndex = 3;
            this.btnUserAdd.Text = "사용자 추가";
            this.btnUserAdd.UseVisualStyleBackColor = true;
            this.btnUserAdd.Click += new System.EventHandler(this.btnUserAdd_Click);
            // 
            // US_UsersSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.btnUserAdd);
            this.Controls.Add(this.lblUsersSetting);
            this.Controls.Add(this.panel1);
            this.Name = "US_UsersSetting";
            this.Size = new System.Drawing.Size(1219, 653);
            this.Load += new System.EventHandler(this.US_UsersSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersSetting)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbZone;
        private System.Windows.Forms.DataGridView dgvUsersSetting;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn role;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn manage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUsersSetting;
        private System.Windows.Forms.Button btnUserAdd;
    }
}