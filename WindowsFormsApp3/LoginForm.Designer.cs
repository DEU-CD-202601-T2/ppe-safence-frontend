namespace PPE_관제_시스템
{
    partial class LoginForm
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

        #region Windows Form 디자이너에서 생성한 코드

        private void InitializeComponent()
        {
            this.lblLoginHeader = new System.Windows.Forms.Label();
            this.lblLoginSub = new System.Windows.Forms.Label();
            this.pnlLoginCard = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblPwd = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.pnlLoginCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLoginHeader
            // 
            this.lblLoginHeader.AutoSize = true;
            this.lblLoginHeader.Font = new System.Drawing.Font("맑은 고딕", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLoginHeader.ForeColor = AppColors.PrimaryDark;
            this.lblLoginHeader.Location = new System.Drawing.Point(140, 50);
            this.lblLoginHeader.Name = "lblLoginHeader";
            this.lblLoginHeader.Size = new System.Drawing.Size(303, 49);
            this.lblLoginHeader.TabIndex = 0;
            this.lblLoginHeader.Text = "PPE 관제 시스템";
            // 
            // lblLoginSub
            // 
            this.lblLoginSub.AutoSize = true;
            this.lblLoginSub.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLoginSub.ForeColor = AppColors.TextSecondary;
            this.lblLoginSub.Location = new System.Drawing.Point(168, 105);
            this.lblLoginSub.Name = "lblLoginSub";
            this.lblLoginSub.Size = new System.Drawing.Size(247, 23);
            this.lblLoginSub.TabIndex = 5;
            this.lblLoginSub.Text = "안전을 위한 실시간 모니터링 솔루션";
            // 
            // pnlLoginCard
            // 
            this.pnlLoginCard.BackColor = AppColors.Surface;
            this.pnlLoginCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLoginCard.Controls.Add(this.btnLogin);
            this.pnlLoginCard.Controls.Add(this.txtPwd);
            this.pnlLoginCard.Controls.Add(this.txtId);
            this.pnlLoginCard.Controls.Add(this.lblPwd);
            this.pnlLoginCard.Controls.Add(this.lblId);
            this.pnlLoginCard.Location = new System.Drawing.Point(60, 160);
            this.pnlLoginCard.Name = "pnlLoginCard";
            this.pnlLoginCard.Size = new System.Drawing.Size(462, 260);
            this.pnlLoginCard.TabIndex = 1;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblId.ForeColor = AppColors.Text;
            this.lblId.Location = new System.Drawing.Point(40, 30);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(28, 23);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID";
            // 
            // txtId
            // 
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.txtId.ForeColor = AppColors.Text;
            this.txtId.Location = new System.Drawing.Point(40, 58);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(380, 30);
            this.txtId.TabIndex = 0;
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPwd.ForeColor = AppColors.Text;
            this.lblPwd.Location = new System.Drawing.Point(40, 105);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(86, 23);
            this.lblPwd.TabIndex = 1;
            this.lblPwd.Text = "Password";
            // 
            // txtPwd
            // 
            this.txtPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPwd.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.txtPwd.ForeColor = AppColors.Text;
            this.txtPwd.Location = new System.Drawing.Point(40, 133);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(380, 30);
            this.txtPwd.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = AppColors.Primary;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseOverBackColor = AppColors.PrimaryDark;
            this.btnLogin.FlatAppearance.MouseDownBackColor = AppColors.PrimaryDark;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLogin.ForeColor = AppColors.TextOnPrimary;
            this.btnLogin.Location = new System.Drawing.Point(40, 190);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(380, 48);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "로그인";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = AppColors.Background;
            this.ClientSize = new System.Drawing.Size(582, 480);
            this.Controls.Add(this.lblLoginSub);
            this.Controls.Add(this.pnlLoginCard);
            this.Controls.Add(this.lblLoginHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PPE 관제 시스템";
            this.pnlLoginCard.ResumeLayout(false);
            this.pnlLoginCard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblLoginHeader;
        private System.Windows.Forms.Label lblLoginSub;
        private System.Windows.Forms.Panel pnlLoginCard;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnLogin;
    }
}