namespace PPE_관제_시스템
{
    partial class LoginForm
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblLoginHeader = new System.Windows.Forms.Label();
            this.grpLogin = new System.Windows.Forms.GroupBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblPwd = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.grpLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLoginHeader
            // 
            this.lblLoginHeader.AutoSize = true;
            this.lblLoginHeader.Font = new System.Drawing.Font("맑은 고딕", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLoginHeader.Location = new System.Drawing.Point(152, 35);
            this.lblLoginHeader.Name = "lblLoginHeader";
            this.lblLoginHeader.Size = new System.Drawing.Size(267, 45);
            this.lblLoginHeader.TabIndex = 0;
            this.lblLoginHeader.Text = "PPE 관제 시스템";
            // 
            // grpLogin
            // 
            this.grpLogin.Controls.Add(this.btnLogin);
            this.grpLogin.Controls.Add(this.txtPwd);
            this.grpLogin.Controls.Add(this.txtId);
            this.grpLogin.Controls.Add(this.lblPwd);
            this.grpLogin.Controls.Add(this.lblId);
            this.grpLogin.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grpLogin.Location = new System.Drawing.Point(12, 111);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new System.Drawing.Size(558, 330);
            this.grpLogin.TabIndex = 1;
            this.grpLogin.TabStop = false;
            this.grpLogin.Text = "Login";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(148, 222);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(266, 51);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "로그인";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(201, 146);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(256, 31);
            this.txtPwd.TabIndex = 3;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(201, 96);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(256, 31);
            this.txtId.TabIndex = 2;
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(105, 149);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(88, 25);
            this.lblPwd.TabIndex = 1;
            this.lblPwd.Text = "Password";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(105, 99);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(30, 25);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 453);
            this.Controls.Add(this.grpLogin);
            this.Controls.Add(this.lblLoginHeader);
            this.Name = "LoginForm";
            this.Text = "PPE 관제 시스템";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLoginHeader;
        private System.Windows.Forms.GroupBox grpLogin;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnLogin;
    }
}

