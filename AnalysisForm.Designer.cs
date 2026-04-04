namespace PPE_관제_시스템
{
    partial class AnalysisForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.lblAnalysisHeader = new System.Windows.Forms.Label();
            this.pnlTotalWorkers = new System.Windows.Forms.Panel();
            this.pnlPPECompliance = new System.Windows.Forms.Panel();
            this.pnlAccidents = new System.Windows.Forms.Panel();
            this.pnlWarnings = new System.Windows.Forms.Panel();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chtAnalysis = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlTotalWorkers.SuspendLayout();
            this.pnlPPECompliance.SuspendLayout();
            this.pnlAccidents.SuspendLayout();
            this.pnlWarnings.SuspendLayout();
            this.pnlChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtAnalysis)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.Location = new System.Drawing.Point(0, 1);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(211, 671);
            this.pnlMenu.TabIndex = 1;
            // 
            // lblAnalysisHeader
            // 
            this.lblAnalysisHeader.AutoSize = true;
            this.lblAnalysisHeader.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAnalysisHeader.Location = new System.Drawing.Point(217, 9);
            this.lblAnalysisHeader.Name = "lblAnalysisHeader";
            this.lblAnalysisHeader.Size = new System.Drawing.Size(73, 38);
            this.lblAnalysisHeader.TabIndex = 2;
            this.lblAnalysisHeader.Text = "분석";
            // 
            // pnlTotalWorkers
            // 
            this.pnlTotalWorkers.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlTotalWorkers.Controls.Add(this.label1);
            this.pnlTotalWorkers.Location = new System.Drawing.Point(224, 68);
            this.pnlTotalWorkers.Name = "pnlTotalWorkers";
            this.pnlTotalWorkers.Size = new System.Drawing.Size(200, 200);
            this.pnlTotalWorkers.TabIndex = 3;
            // 
            // pnlPPECompliance
            // 
            this.pnlPPECompliance.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlPPECompliance.Controls.Add(this.label2);
            this.pnlPPECompliance.Location = new System.Drawing.Point(473, 68);
            this.pnlPPECompliance.Name = "pnlPPECompliance";
            this.pnlPPECompliance.Size = new System.Drawing.Size(200, 200);
            this.pnlPPECompliance.TabIndex = 4;
            // 
            // pnlAccidents
            // 
            this.pnlAccidents.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlAccidents.Controls.Add(this.label3);
            this.pnlAccidents.Location = new System.Drawing.Point(719, 68);
            this.pnlAccidents.Name = "pnlAccidents";
            this.pnlAccidents.Size = new System.Drawing.Size(200, 200);
            this.pnlAccidents.TabIndex = 4;
            // 
            // pnlWarnings
            // 
            this.pnlWarnings.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlWarnings.Controls.Add(this.label4);
            this.pnlWarnings.Location = new System.Drawing.Point(970, 68);
            this.pnlWarnings.Name = "pnlWarnings";
            this.pnlWarnings.Size = new System.Drawing.Size(200, 200);
            this.pnlWarnings.TabIndex = 4;
            // 
            // pnlChart
            // 
            this.pnlChart.Controls.Add(this.chtAnalysis);
            this.pnlChart.Location = new System.Drawing.Point(224, 276);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(946, 385);
            this.pnlChart.TabIndex = 5;
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
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chtAnalysis.Series.Add(series1);
            this.chtAnalysis.Size = new System.Drawing.Size(946, 385);
            this.chtAnalysis.TabIndex = 0;
            this.chtAnalysis.Text = "Chart";
            // 
            // AnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 673);
            this.Controls.Add(this.pnlChart);
            this.Controls.Add(this.pnlWarnings);
            this.Controls.Add(this.pnlAccidents);
            this.Controls.Add(this.pnlPPECompliance);
            this.Controls.Add(this.pnlTotalWorkers);
            this.Controls.Add(this.lblAnalysisHeader);
            this.Controls.Add(this.pnlMenu);
            this.Name = "AnalysisForm";
            this.Text = "분석";
            this.pnlTotalWorkers.ResumeLayout(false);
            this.pnlTotalWorkers.PerformLayout();
            this.pnlPPECompliance.ResumeLayout(false);
            this.pnlPPECompliance.PerformLayout();
            this.pnlAccidents.ResumeLayout(false);
            this.pnlAccidents.PerformLayout();
            this.pnlWarnings.ResumeLayout(false);
            this.pnlWarnings.PerformLayout();
            this.pnlChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtAnalysis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblAnalysisHeader;
        private System.Windows.Forms.Panel pnlTotalWorkers;
        private System.Windows.Forms.Panel pnlPPECompliance;
        private System.Windows.Forms.Panel pnlAccidents;
        private System.Windows.Forms.Panel pnlWarnings;
        private System.Windows.Forms.Panel pnlChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtAnalysis;
    }
}