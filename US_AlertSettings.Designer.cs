namespace PPE_관제_시스템
{
    partial class US_AlertSettings
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
            this.dgvSettingList = new System.Windows.Forms.DataGridView();
            this.lblSettingList = new System.Windows.Forms.Label();
            this.btnAlertSave = new System.Windows.Forms.Button();
            this.btnAlertDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettingList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSettingList
            // 
            this.dgvSettingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSettingList.Location = new System.Drawing.Point(0, 89);
            this.dgvSettingList.Name = "dgvSettingList";
            this.dgvSettingList.RowHeadersWidth = 51;
            this.dgvSettingList.RowTemplate.Height = 27;
            this.dgvSettingList.Size = new System.Drawing.Size(464, 398);
            this.dgvSettingList.TabIndex = 4;
            // 
            // lblSettingList
            // 
            this.lblSettingList.AutoSize = true;
            this.lblSettingList.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSettingList.Location = new System.Drawing.Point(161, 25);
            this.lblSettingList.Name = "lblSettingList";
            this.lblSettingList.Size = new System.Drawing.Size(139, 38);
            this.lblSettingList.TabIndex = 5;
            this.lblSettingList.Text = "설정 목록";
            // 
            // btnAlertSave
            // 
            this.btnAlertSave.Location = new System.Drawing.Point(524, 432);
            this.btnAlertSave.Name = "btnAlertSave";
            this.btnAlertSave.Size = new System.Drawing.Size(149, 42);
            this.btnAlertSave.TabIndex = 6;
            this.btnAlertSave.Text = "저장";
            this.btnAlertSave.UseVisualStyleBackColor = true;
            // 
            // btnAlertDelete
            // 
            this.btnAlertDelete.Location = new System.Drawing.Point(741, 432);
            this.btnAlertDelete.Name = "btnAlertDelete";
            this.btnAlertDelete.Size = new System.Drawing.Size(149, 42);
            this.btnAlertDelete.TabIndex = 7;
            this.btnAlertDelete.Text = "삭제";
            this.btnAlertDelete.UseVisualStyleBackColor = true;
            // 
            // US_AlertSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.btnAlertDelete);
            this.Controls.Add(this.btnAlertSave);
            this.Controls.Add(this.lblSettingList);
            this.Controls.Add(this.dgvSettingList);
            this.Name = "US_AlertSettings";
            this.Size = new System.Drawing.Size(945, 487);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettingList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSettingList;
        private System.Windows.Forms.Label lblSettingList;
        private System.Windows.Forms.Button btnAlertSave;
        private System.Windows.Forms.Button btnAlertDelete;
    }
}
