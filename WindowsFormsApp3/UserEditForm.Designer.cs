namespace PPE_관제_시스템
{
    partial class UserEditForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = AppColors.PrimaryDark;
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(141, 31);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "사용자 정보";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblName.ForeColor = AppColors.Text;
            this.lblName.Location = new System.Drawing.Point(30, 80);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 23);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "이름";
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtName.ForeColor = AppColors.Text;
            this.txtName.Location = new System.Drawing.Point(30, 108);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(280, 30);
            this.txtName.TabIndex = 5;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblId.ForeColor = AppColors.Text;
            this.lblId.Location = new System.Drawing.Point(330, 80);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(64, 23);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "아이디";
            // 
            // txtId
            // 
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtId.ForeColor = AppColors.Text;
            this.txtId.Location = new System.Drawing.Point(330, 108);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(280, 30);
            this.txtId.TabIndex = 6;
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPwd.ForeColor = AppColors.Text;
            this.lblPwd.Location = new System.Drawing.Point(30, 160);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(80, 23);
            this.lblPwd.TabIndex = 2;
            this.lblPwd.Text = "비밀번호";
            // 
            // txtPwd
            // 
            this.txtPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPwd.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtPwd.ForeColor = AppColors.Text;
            this.txtPwd.Location = new System.Drawing.Point(30, 188);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(280, 30);
            this.txtPwd.TabIndex = 7;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRole.ForeColor = AppColors.Text;
            this.lblRole.Location = new System.Drawing.Point(330, 160);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(45, 23);
            this.lblRole.TabIndex = 3;
            this.lblRole.Text = "역할";
            // 
            // txtRole
            // 
            this.txtRole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRole.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtRole.ForeColor = AppColors.Text;
            this.txtRole.Location = new System.Drawing.Point(330, 188);
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(280, 30);
            this.txtRole.TabIndex = 8;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDepartment.ForeColor = AppColors.Text;
            this.lblDepartment.Location = new System.Drawing.Point(30, 240);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(90, 23);
            this.lblDepartment.TabIndex = 4;
            this.lblDepartment.Text = "소속(구역)";
            // 
            // txtDepartment
            // 
            this.txtDepartment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepartment.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtDepartment.ForeColor = AppColors.Text;
            this.txtDepartment.Location = new System.Drawing.Point(30, 268);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(580, 30);
            this.txtDepartment.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = AppColors.Primary;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseOverBackColor = AppColors.PrimaryDark;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = AppColors.TextOnPrimary;
            this.btnSave.Location = new System.Drawing.Point(470, 330);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 45);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // UserEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = AppColors.Background;
            this.ClientSize = new System.Drawing.Size(640, 400);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.txtRole);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "사용자 정보";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Button btnSave;
    }
}