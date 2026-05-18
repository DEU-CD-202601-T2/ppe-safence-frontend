namespace PPE_관제_시스템
{
    partial class US_AnalysisForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.chtAnalysis = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlWarnings = new System.Windows.Forms.Panel();
            this.lblWarnings = new System.Windows.Forms.Label();
            this.pnlAccidents = new System.Windows.Forms.Panel();
            this.lblAccidents = new System.Windows.Forms.Label();
            this.pnlPPECompliance = new System.Windows.Forms.Panel();
            this.lblPPECompliance = new System.Windows.Forms.Label();
            this.pnlTotalWorkers = new System.Windows.Forms.Panel();
            this.lblTotalWorkers = new System.Windows.Forms.Label();
            this.cmbPeriod = new System.Windows.Forms.ComboBox();
            this.cmbChartType = new System.Windows.Forms.ComboBox();
            this.lblTotalWorkersCount = new System.Windows.Forms.Label();
            this.lblPPEComplianceRate = new System.Windows.Forms.Label();
            this.lblAccidentCount = new System.Windows.Forms.Label();
            this.lblWarningCount = new System.Windows.Forms.Label();
            this.pnlChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtAnalysis)).BeginInit();
            this.pnlWarnings.SuspendLayout();
            this.pnlAccidents.SuspendLayout();
            this.pnlPPECompliance.SuspendLayout();
            this.pnlTotalWorkers.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlChart
            // 
            this.pnlChart.Controls.Add(this.chtAnalysis);
            this.pnlChart.Location = new System.Drawing.Point(3, 218);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(1222, 530);
            this.pnlChart.TabIndex = 10;
            // 
            // chtAnalysis
            // 
            chartArea1.Name = "ChartArea1";
            this.chtAnalysis.ChartAreas.Add(chartArea1);
            this.chtAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chtAnalysis.Legends.Add(legend1);
            this.chtAnalysis.Location = new System.Drawing.Point(0, 0);
            this.chtAnalysis.Name = "chtAnalysis";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chtAnalysis.Series.Add(series1);
            this.chtAnalysis.Size = new System.Drawing.Size(1222, 530);
            this.chtAnalysis.TabIndex = 0;
            this.chtAnalysis.Text = "chart1";
            // 
            // pnlWarnings
            // 
            this.pnlWarnings.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlWarnings.Controls.Add(this.lblWarningCount);
            this.pnlWarnings.Controls.Add(this.lblWarnings);
            this.pnlWarnings.Location = new System.Drawing.Point(937, 3);
            this.pnlWarnings.Name = "pnlWarnings";
            this.pnlWarnings.Size = new System.Drawing.Size(288, 156);
            this.pnlWarnings.TabIndex = 7;
            // 
            // lblWarnings
            // 
            this.lblWarnings.AutoSize = true;
            this.lblWarnings.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWarnings.Location = new System.Drawing.Point(7, 9);
            this.lblWarnings.Name = "lblWarnings";
            this.lblWarnings.Size = new System.Drawing.Size(114, 25);
            this.lblWarnings.TabIndex = 2;
            this.lblWarnings.Text = "경고 발생 수";
            // 
            // pnlAccidents
            // 
            this.pnlAccidents.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlAccidents.Controls.Add(this.lblAccidentCount);
            this.pnlAccidents.Controls.Add(this.lblAccidents);
            this.pnlAccidents.Location = new System.Drawing.Point(626, 3);
            this.pnlAccidents.Name = "pnlAccidents";
            this.pnlAccidents.Size = new System.Drawing.Size(288, 156);
            this.pnlAccidents.TabIndex = 8;
            // 
            // lblAccidents
            // 
            this.lblAccidents.AutoSize = true;
            this.lblAccidents.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAccidents.Location = new System.Drawing.Point(7, 9);
            this.lblAccidents.Name = "lblAccidents";
            this.lblAccidents.Size = new System.Drawing.Size(114, 25);
            this.lblAccidents.TabIndex = 1;
            this.lblAccidents.Text = "사고 발생 수";
            // 
            // pnlPPECompliance
            // 
            this.pnlPPECompliance.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlPPECompliance.Controls.Add(this.lblPPEComplianceRate);
            this.pnlPPECompliance.Controls.Add(this.lblPPECompliance);
            this.pnlPPECompliance.Location = new System.Drawing.Point(313, 3);
            this.pnlPPECompliance.Name = "pnlPPECompliance";
            this.pnlPPECompliance.Size = new System.Drawing.Size(288, 156);
            this.pnlPPECompliance.TabIndex = 9;
            // 
            // lblPPECompliance
            // 
            this.lblPPECompliance.AutoSize = true;
            this.lblPPECompliance.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPPECompliance.Location = new System.Drawing.Point(7, 9);
            this.lblPPECompliance.Name = "lblPPECompliance";
            this.lblPPECompliance.Size = new System.Drawing.Size(132, 25);
            this.lblPPECompliance.TabIndex = 1;
            this.lblPPECompliance.Text = "PPE 준수율(%)";
            // 
            // pnlTotalWorkers
            // 
            this.pnlTotalWorkers.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlTotalWorkers.Controls.Add(this.lblTotalWorkersCount);
            this.pnlTotalWorkers.Controls.Add(this.lblTotalWorkers);
            this.pnlTotalWorkers.Location = new System.Drawing.Point(3, 3);
            this.pnlTotalWorkers.Name = "pnlTotalWorkers";
            this.pnlTotalWorkers.Size = new System.Drawing.Size(288, 154);
            this.pnlTotalWorkers.TabIndex = 6;
            // 
            // lblTotalWorkers
            // 
            this.lblTotalWorkers.AutoSize = true;
            this.lblTotalWorkers.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTotalWorkers.Location = new System.Drawing.Point(7, 9);
            this.lblTotalWorkers.Name = "lblTotalWorkers";
            this.lblTotalWorkers.Size = new System.Drawing.Size(114, 25);
            this.lblTotalWorkers.TabIndex = 0;
            this.lblTotalWorkers.Text = "총 작업자 수";
            // 
            // cmbPeriod
            // 
            this.cmbPeriod.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbPeriod.FormattingEnabled = true;
            this.cmbPeriod.Items.AddRange(new object[] {
            "전체",
            "이번 달",
            "이번 주"});
            this.cmbPeriod.Location = new System.Drawing.Point(977, 181);
            this.cmbPeriod.Name = "cmbPeriod";
            this.cmbPeriod.Size = new System.Drawing.Size(121, 31);
            this.cmbPeriod.TabIndex = 11;
            this.cmbPeriod.Text = "이번 달";
            this.cmbPeriod.SelectedIndexChanged += new System.EventHandler(this.cmbPeriod_SelectedIndexChanged);
            // 
            // cmbChartType
            // 
            this.cmbChartType.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbChartType.FormattingEnabled = true;
            this.cmbChartType.Items.AddRange(new object[] {
            "PPE 준수율",
            "위반 건수",
            "구역별 위반 현황"});
            this.cmbChartType.Location = new System.Drawing.Point(1104, 181);
            this.cmbChartType.Name = "cmbChartType";
            this.cmbChartType.Size = new System.Drawing.Size(121, 31);
            this.cmbChartType.TabIndex = 12;
            this.cmbChartType.Text = "PPE 준수율";
            this.cmbChartType.SelectedIndexChanged += new System.EventHandler(this.cmbChartType_SelectedIndexChanged);
            // 
            // lblTotalWorkersCount
            // 
            this.lblTotalWorkersCount.AutoSize = true;
            this.lblTotalWorkersCount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTotalWorkersCount.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTotalWorkersCount.Location = new System.Drawing.Point(248, 106);
            this.lblTotalWorkersCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalWorkersCount.Name = "lblTotalWorkersCount";
            this.lblTotalWorkersCount.Size = new System.Drawing.Size(33, 38);
            this.lblTotalWorkersCount.TabIndex = 9;
            this.lblTotalWorkersCount.Text = "0";
            // 
            // lblPPEComplianceRate
            // 
            this.lblPPEComplianceRate.AutoSize = true;
            this.lblPPEComplianceRate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPPEComplianceRate.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPPEComplianceRate.Location = new System.Drawing.Point(248, 106);
            this.lblPPEComplianceRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPPEComplianceRate.Name = "lblPPEComplianceRate";
            this.lblPPEComplianceRate.Size = new System.Drawing.Size(33, 38);
            this.lblPPEComplianceRate.TabIndex = 9;
            this.lblPPEComplianceRate.Text = "0";
            // 
            // lblAccidentCount
            // 
            this.lblAccidentCount.AutoSize = true;
            this.lblAccidentCount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAccidentCount.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAccidentCount.Location = new System.Drawing.Point(248, 106);
            this.lblAccidentCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAccidentCount.Name = "lblAccidentCount";
            this.lblAccidentCount.Size = new System.Drawing.Size(33, 38);
            this.lblAccidentCount.TabIndex = 9;
            this.lblAccidentCount.Text = "0";
            // 
            // lblWarningCount
            // 
            this.lblWarningCount.AutoSize = true;
            this.lblWarningCount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblWarningCount.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWarningCount.Location = new System.Drawing.Point(248, 106);
            this.lblWarningCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWarningCount.Name = "lblWarningCount";
            this.lblWarningCount.Size = new System.Drawing.Size(33, 38);
            this.lblWarningCount.TabIndex = 9;
            this.lblWarningCount.Text = "0";
            // 
            // US_AnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbChartType);
            this.Controls.Add(this.cmbPeriod);
            this.Controls.Add(this.pnlChart);
            this.Controls.Add(this.pnlWarnings);
            this.Controls.Add(this.pnlAccidents);
            this.Controls.Add(this.pnlPPECompliance);
            this.Controls.Add(this.pnlTotalWorkers);
            this.Name = "US_AnalysisForm";
            this.Size = new System.Drawing.Size(1228, 762);
            this.Load += new System.EventHandler(this.US_AnalysisForm_Load);
            this.pnlChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtAnalysis)).EndInit();
            this.pnlWarnings.ResumeLayout(false);
            this.pnlWarnings.PerformLayout();
            this.pnlAccidents.ResumeLayout(false);
            this.pnlAccidents.PerformLayout();
            this.pnlPPECompliance.ResumeLayout(false);
            this.pnlPPECompliance.PerformLayout();
            this.pnlTotalWorkers.ResumeLayout(false);
            this.pnlTotalWorkers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtAnalysis;
        private System.Windows.Forms.Panel pnlWarnings;
        private System.Windows.Forms.Label lblWarnings;
        private System.Windows.Forms.Panel pnlAccidents;
        private System.Windows.Forms.Label lblAccidents;
        private System.Windows.Forms.Panel pnlPPECompliance;
        private System.Windows.Forms.Label lblPPECompliance;
        private System.Windows.Forms.Panel pnlTotalWorkers;
        private System.Windows.Forms.Label lblTotalWorkers;
        private System.Windows.Forms.ComboBox cmbPeriod;
        private System.Windows.Forms.ComboBox cmbChartType;
        private System.Windows.Forms.Label lblWarningCount;
        private System.Windows.Forms.Label lblAccidentCount;
        private System.Windows.Forms.Label lblPPEComplianceRate;
        private System.Windows.Forms.Label lblTotalWorkersCount;
    }
}
