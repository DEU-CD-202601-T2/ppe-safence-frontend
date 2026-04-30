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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.chtAnalysis = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlWarnings = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlAccidents = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlPPECompliance = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlTotalWorkers = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
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
            chartArea2.Name = "ChartArea1";
            this.chtAnalysis.ChartAreas.Add(chartArea2);
            this.chtAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chtAnalysis.Legends.Add(legend2);
            this.chtAnalysis.Location = new System.Drawing.Point(0, 0);
            this.chtAnalysis.Name = "chtAnalysis";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chtAnalysis.Series.Add(series2);
            this.chtAnalysis.Size = new System.Drawing.Size(1222, 530);
            this.chtAnalysis.TabIndex = 0;
            this.chtAnalysis.Text = "chart1";
            // 
            // pnlWarnings
            // 
            this.pnlWarnings.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlWarnings.Controls.Add(this.label4);
            this.pnlWarnings.Location = new System.Drawing.Point(937, 3);
            this.pnlWarnings.Name = "pnlWarnings";
            this.pnlWarnings.Size = new System.Drawing.Size(288, 156);
            this.pnlWarnings.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(7, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "경고 발생 수";
            // 
            // pnlAccidents
            // 
            this.pnlAccidents.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlAccidents.Controls.Add(this.label3);
            this.pnlAccidents.Location = new System.Drawing.Point(626, 3);
            this.pnlAccidents.Name = "pnlAccidents";
            this.pnlAccidents.Size = new System.Drawing.Size(288, 156);
            this.pnlAccidents.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(7, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "사고 발생 수";
            // 
            // pnlPPECompliance
            // 
            this.pnlPPECompliance.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlPPECompliance.Controls.Add(this.label2);
            this.pnlPPECompliance.Location = new System.Drawing.Point(313, 3);
            this.pnlPPECompliance.Name = "pnlPPECompliance";
            this.pnlPPECompliance.Size = new System.Drawing.Size(288, 156);
            this.pnlPPECompliance.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "PPE 준수율(%)";
            // 
            // pnlTotalWorkers
            // 
            this.pnlTotalWorkers.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlTotalWorkers.Controls.Add(this.label1);
            this.pnlTotalWorkers.Location = new System.Drawing.Point(3, 3);
            this.pnlTotalWorkers.Name = "pnlTotalWorkers";
            this.pnlTotalWorkers.Size = new System.Drawing.Size(288, 154);
            this.pnlTotalWorkers.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "총 작업자 수";
            // 
            // US_AnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlChart);
            this.Controls.Add(this.pnlWarnings);
            this.Controls.Add(this.pnlAccidents);
            this.Controls.Add(this.pnlPPECompliance);
            this.Controls.Add(this.pnlTotalWorkers);
            this.Name = "US_AnalysisForm";
            this.Size = new System.Drawing.Size(1228, 762);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlAccidents;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlPPECompliance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlTotalWorkers;
        private System.Windows.Forms.Label label1;
    }
}
