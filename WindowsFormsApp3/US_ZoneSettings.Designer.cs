namespace PPE_관제_시스템
{
    partial class US_ZoneSettings
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
            this.btnZoneAdd = new System.Windows.Forms.Button();
            this.btnZoneModify = new System.Windows.Forms.Button();
            this.btnZoneDelete = new System.Windows.Forms.Button();
            this.dgvZones = new System.Windows.Forms.DataGridView();
            this.lblZones = new System.Windows.Forms.Label();
            this.lblZoneInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZones)).BeginInit();
            this.SuspendLayout();
            // 
            // btnZoneAdd
            // 
            this.btnZoneAdd.Location = new System.Drawing.Point(481, 418);
            this.btnZoneAdd.Name = "btnZoneAdd";
            this.btnZoneAdd.Size = new System.Drawing.Size(128, 51);
            this.btnZoneAdd.TabIndex = 0;
            this.btnZoneAdd.Text = "추가";
            this.btnZoneAdd.UseVisualStyleBackColor = true;
            // 
            // btnZoneModify
            // 
            this.btnZoneModify.Location = new System.Drawing.Point(615, 418);
            this.btnZoneModify.Name = "btnZoneModify";
            this.btnZoneModify.Size = new System.Drawing.Size(128, 51);
            this.btnZoneModify.TabIndex = 1;
            this.btnZoneModify.Text = "수정";
            this.btnZoneModify.UseVisualStyleBackColor = true;
            // 
            // btnZoneDelete
            // 
            this.btnZoneDelete.Location = new System.Drawing.Point(749, 418);
            this.btnZoneDelete.Name = "btnZoneDelete";
            this.btnZoneDelete.Size = new System.Drawing.Size(128, 51);
            this.btnZoneDelete.TabIndex = 2;
            this.btnZoneDelete.Text = "삭제";
            this.btnZoneDelete.UseVisualStyleBackColor = true;
            // 
            // dgvZones
            // 
            this.dgvZones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZones.Location = new System.Drawing.Point(0, 89);
            this.dgvZones.Name = "dgvZones";
            this.dgvZones.RowHeadersWidth = 51;
            this.dgvZones.RowTemplate.Height = 27;
            this.dgvZones.Size = new System.Drawing.Size(464, 380);
            this.dgvZones.TabIndex = 3;
            // 
            // lblZones
            // 
            this.lblZones.AutoSize = true;
            this.lblZones.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZones.Location = new System.Drawing.Point(154, 21);
            this.lblZones.Name = "lblZones";
            this.lblZones.Size = new System.Drawing.Size(139, 38);
            this.lblZones.TabIndex = 4;
            this.lblZones.Text = "구역 목록";
            // 
            // lblZoneInfo
            // 
            this.lblZoneInfo.AutoSize = true;
            this.lblZoneInfo.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZoneInfo.Location = new System.Drawing.Point(608, 21);
            this.lblZoneInfo.Name = "lblZoneInfo";
            this.lblZoneInfo.Size = new System.Drawing.Size(139, 38);
            this.lblZoneInfo.TabIndex = 5;
            this.lblZoneInfo.Text = "구역 정보";
            // 
            // US_ZoneSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.lblZoneInfo);
            this.Controls.Add(this.lblZones);
            this.Controls.Add(this.dgvZones);
            this.Controls.Add(this.btnZoneDelete);
            this.Controls.Add(this.btnZoneModify);
            this.Controls.Add(this.btnZoneAdd);
            this.Name = "US_ZoneSettings";
            this.Size = new System.Drawing.Size(890, 472);
            ((System.ComponentModel.ISupportInitialize)(this.dgvZones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnZoneAdd;
        private System.Windows.Forms.Button btnZoneModify;
        private System.Windows.Forms.Button btnZoneDelete;
        private System.Windows.Forms.DataGridView dgvZones;
        private System.Windows.Forms.Label lblZones;
        private System.Windows.Forms.Label lblZoneInfo;
    }
}
