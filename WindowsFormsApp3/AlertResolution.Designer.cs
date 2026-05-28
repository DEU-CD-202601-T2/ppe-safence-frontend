namespace PPE_관제_시스템
{
    partial class AlertResolution
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
            this.lblAdminId = new System.Windows.Forms.Label();
            this.txtAdminId = new System.Windows.Forms.TextBox();
            this.lblWorkerId = new System.Windows.Forms.Label();
            this.txtWorkerId = new System.Windows.Forms.TextBox();
            this.lblMemo = new System.Windows.Forms.Label();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = AppColors.PrimaryDark;
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(116, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "해결 처리";
            // 
            // lblAdminId
            // 
            this.lblAdminId.AutoSize = true;
            this.lblAdminId.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lblAdminId.ForeColor = AppColors.Text;
            this.lblAdminId.Location = new System.Drawing.Point(30, 80);
            this.lblAdminId.Name = "lblAdminId";
            this.lblAdminId.Size = new System.Drawing.Size(82, 23);
            this.lblAdminId.TabIndex = 1;
            this.lblAdminId.Text = "관리자 ID";
            // 
            // txtAdminId
            // 
            this.txtAdminId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdminId.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtAdminId.ForeColor = AppColors.Text;
            this.txtAdminId.Location = new System.Drawing.Point(30, 108);
            this.txtAdminId.Name = "txtAdminId";
            this.txtAdminId.Size = new System.Drawing.Size(318, 30);
            this.txtAdminId.TabIndex = 2;
            // 
            // lblWorkerId
            // 
            this.lblWorkerId.AutoSize = true;
            this.lblWorkerId.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lblWorkerId.ForeColor = AppColors.Text;
            this.lblWorkerId.Location = new System.Drawing.Point(30, 158);
            this.lblWorkerId.Name = "lblWorkerId";
            this.lblWorkerId.Size = new System.Drawing.Size(82, 23);
            this.lblWorkerId.TabIndex = 3;
            this.lblWorkerId.Text = "작업자 ID";
            // 
            // txtWorkerId
            // 
            this.txtWorkerId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWorkerId.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtWorkerId.ForeColor = AppColors.Text;
            this.txtWorkerId.Location = new System.Drawing.Point(30, 186);
            this.txtWorkerId.Name = "txtWorkerId";
            this.txtWorkerId.Size = new System.Drawing.Size(318, 30);
            this.txtWorkerId.TabIndex = 4;
            // 
            // lblMemo
            // 
            this.lblMemo.AutoSize = true;
            this.lblMemo.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lblMemo.ForeColor = AppColors.Text;
            this.lblMemo.Location = new System.Drawing.Point(30, 236);
            this.lblMemo.Name = "lblMemo";
            this.lblMemo.Size = new System.Drawing.Size(80, 23);
            this.lblMemo.TabIndex = 5;
            this.lblMemo.Text = "조치 메모";
            // 
            // txtMemo
            // 
            this.txtMemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMemo.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtMemo.ForeColor = AppColors.Text;
            this.txtMemo.Location = new System.Drawing.Point(30, 264);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(318, 120);
            this.txtMemo.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = AppColors.Surface;
            this.btnCancel.FlatAppearance.BorderColor = AppColors.Border;
            this.btnCancel.FlatAppearance.BorderSize = 1;
            this.btnCancel.FlatAppearance.MouseOverBackColor = AppColors.SurfaceAlt;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.btnCancel.ForeColor = AppColors.Text;
            this.btnCancel.Location = new System.Drawing.Point(30, 410);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 45);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = AppColors.Primary;
            this.btnCheck.FlatAppearance.BorderSize = 0;
            this.btnCheck.FlatAppearance.MouseOverBackColor = AppColors.PrimaryDark;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnCheck.ForeColor = AppColors.TextOnPrimary;
            this.btnCheck.Location = new System.Drawing.Point(208, 410);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(140, 45);
            this.btnCheck.TabIndex = 8;
            this.btnCheck.Text = "확인";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // AlertResolution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = AppColors.Background;
            this.ClientSize = new System.Drawing.Size(380, 480);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.lblMemo);
            this.Controls.Add(this.lblWorkerId);
            this.Controls.Add(this.lblAdminId);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.txtWorkerId);
            this.Controls.Add(this.txtAdminId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlertResolution";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "해결 처리";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAdminId;
        private System.Windows.Forms.TextBox txtAdminId;
        private System.Windows.Forms.Label lblWorkerId;
        private System.Windows.Forms.TextBox txtWorkerId;
        private System.Windows.Forms.Label lblMemo;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnCancel;
    }
}