namespace PPE_관제_시스템
{
    partial class US_AlertCard
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
            this.picPPEImage = new System.Windows.Forms.PictureBox();
            this.lblViolation = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCam = new System.Windows.Forms.Label();
            this.lblZone = new System.Windows.Forms.Label();
            this.lblTargetID = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnResolve = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPPEImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picPPEImage
            // 
            this.picPPEImage.BackColor = AppColors.SurfaceAlt;
            this.picPPEImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPPEImage.Location = new System.Drawing.Point(22, 18);
            this.picPPEImage.Margin = new System.Windows.Forms.Padding(4);
            this.picPPEImage.Name = "picPPEImage";
            this.picPPEImage.Size = new System.Drawing.Size(160, 148);
            this.picPPEImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPPEImage.TabIndex = 0;
            this.picPPEImage.TabStop = false;
            // 
            // lblViolation
            // 
            this.lblViolation.AutoSize = true;
            this.lblViolation.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblViolation.ForeColor = AppColors.Danger;
            this.lblViolation.Location = new System.Drawing.Point(206, 20);
            this.lblViolation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblViolation.Name = "lblViolation";
            this.lblViolation.Size = new System.Drawing.Size(116, 31);
            this.lblViolation.TabIndex = 1;
            this.lblViolation.Text = "위반 내용";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lblDate.ForeColor = AppColors.TextSecondary;
            this.lblDate.Location = new System.Drawing.Point(206, 64);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(45, 23);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "날짜";
            // 
            // lblCam
            // 
            this.lblCam.AutoSize = true;
            this.lblCam.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lblCam.ForeColor = AppColors.TextSecondary;
            this.lblCam.Location = new System.Drawing.Point(206, 92);
            this.lblCam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCam.Name = "lblCam";
            this.lblCam.Size = new System.Drawing.Size(58, 23);
            this.lblCam.TabIndex = 3;
            this.lblCam.Text = "카메라";
            // 
            // lblZone
            // 
            this.lblZone.AutoSize = true;
            this.lblZone.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lblZone.ForeColor = AppColors.TextSecondary;
            this.lblZone.Location = new System.Drawing.Point(206, 120);
            this.lblZone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblZone.Name = "lblZone";
            this.lblZone.Size = new System.Drawing.Size(45, 23);
            this.lblZone.TabIndex = 4;
            this.lblZone.Text = "구역";
            // 
            // lblTargetID
            // 
            this.lblTargetID.AutoSize = true;
            this.lblTargetID.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lblTargetID.ForeColor = AppColors.TextSecondary;
            this.lblTargetID.Location = new System.Drawing.Point(206, 148);
            this.lblTargetID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTargetID.Name = "lblTargetID";
            this.lblTargetID.Size = new System.Drawing.Size(72, 23);
            this.lblTargetID.TabIndex = 5;
            this.lblTargetID.Text = "대상 ID";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = AppColors.Accent;
            this.lblStatus.Location = new System.Drawing.Point(944, 22);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(110, 40);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "미해결";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnResolve
            // 
            this.btnResolve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResolve.BackColor = AppColors.Primary;
            this.btnResolve.FlatAppearance.BorderSize = 0;
            this.btnResolve.FlatAppearance.MouseOverBackColor = AppColors.PrimaryDark;
            this.btnResolve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResolve.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnResolve.ForeColor = AppColors.TextOnPrimary;
            this.btnResolve.Location = new System.Drawing.Point(944, 36);
            this.btnResolve.Margin = new System.Windows.Forms.Padding(4);
            this.btnResolve.Name = "btnResolve";
            this.btnResolve.Size = new System.Drawing.Size(110, 40);
            this.btnResolve.TabIndex = 7;
            this.btnResolve.Text = "해결 처리";
            this.btnResolve.UseVisualStyleBackColor = false;
            this.btnResolve.Click += new System.EventHandler(this.btnResolve_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(699, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 23);
            this.label2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(707, 97);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 23);
            this.label3.TabIndex = 9;
            // 
            // US_AlertCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = AppColors.Surface;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Controls.Add(this.btnResolve);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTargetID);
            this.Controls.Add(this.lblZone);
            this.Controls.Add(this.lblCam);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblViolation);
            this.Controls.Add(this.picPPEImage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.ForeColor = AppColors.Text;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 8);
            this.Name = "US_AlertCard";
            this.Size = new System.Drawing.Size(1080, 250);
            ((System.ComponentModel.ISupportInitialize)(this.picPPEImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox picPPEImage;
        private System.Windows.Forms.Label lblViolation;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCam;
        private System.Windows.Forms.Label lblZone;
        private System.Windows.Forms.Label lblTargetID;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnResolve;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}