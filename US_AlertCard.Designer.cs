namespace PPE_관제_시스템
{
    partial class US_AlertCard
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
            this.lblViolation = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCameraZone = new System.Windows.Forms.Label();
            this.lblTargetID = new System.Windows.Forms.Label();
            this.btnResolve = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.picPPEImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPPEImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblViolation
            // 
            this.lblViolation.AutoSize = true;
            this.lblViolation.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblViolation.ForeColor = System.Drawing.Color.Red;
            this.lblViolation.Location = new System.Drawing.Point(164, 8);
            this.lblViolation.Name = "lblViolation";
            this.lblViolation.Size = new System.Drawing.Size(114, 31);
            this.lblViolation.TabIndex = 1;
            this.lblViolation.Text = "위반 내용";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDate.Location = new System.Drawing.Point(165, 49);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(48, 25);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "날짜";
            // 
            // lblCameraZone
            // 
            this.lblCameraZone.AutoSize = true;
            this.lblCameraZone.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCameraZone.Location = new System.Drawing.Point(165, 83);
            this.lblCameraZone.Name = "lblCameraZone";
            this.lblCameraZone.Size = new System.Drawing.Size(121, 25);
            this.lblCameraZone.TabIndex = 3;
            this.lblCameraZone.Text = "카메라 / 구역";
            // 
            // lblTargetID
            // 
            this.lblTargetID.AutoSize = true;
            this.lblTargetID.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTargetID.Location = new System.Drawing.Point(165, 120);
            this.lblTargetID.Name = "lblTargetID";
            this.lblTargetID.Size = new System.Drawing.Size(72, 25);
            this.lblTargetID.TabIndex = 4;
            this.lblTargetID.Text = "대상 ID";
            // 
            // btnResolve
            // 
            this.btnResolve.AutoSize = true;
            this.btnResolve.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnResolve.FlatAppearance.BorderSize = 0;
            this.btnResolve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResolve.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnResolve.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnResolve.Image = global::PPE_관제_시스템.Properties.Resources.check;
            this.btnResolve.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResolve.Location = new System.Drawing.Point(1132, 120);
            this.btnResolve.Name = "btnResolve";
            this.btnResolve.Size = new System.Drawing.Size(95, 35);
            this.btnResolve.TabIndex = 6;
            this.btnResolve.Text = "해결";
            this.btnResolve.UseVisualStyleBackColor = false;
            this.btnResolve.Click += new System.EventHandler(this.btnResolve_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblStatus.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.Location = new System.Drawing.Point(984, 8);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(110, 45);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "미해결";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picPPEImage
            // 
            this.picPPEImage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.picPPEImage.Location = new System.Drawing.Point(14, 13);
            this.picPPEImage.Name = "picPPEImage";
            this.picPPEImage.Size = new System.Drawing.Size(130, 130);
            this.picPPEImage.TabIndex = 0;
            this.picPPEImage.TabStop = false;
            // 
            // US_AlertCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.btnResolve);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTargetID);
            this.Controls.Add(this.lblCameraZone);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblViolation);
            this.Controls.Add(this.picPPEImage);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "US_AlertCard";
            this.Size = new System.Drawing.Size(1212, 160);
            ((System.ComponentModel.ISupportInitialize)(this.picPPEImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPPEImage;
        private System.Windows.Forms.Label lblViolation;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCameraZone;
        private System.Windows.Forms.Label lblTargetID;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnResolve;
    }
}
