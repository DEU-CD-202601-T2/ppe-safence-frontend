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
            this.lblAnalysisHeader = new System.Windows.Forms.Label();
            this.pnlTotalWorkers = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlPPECompliance = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlAccidents = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlWarnings = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.chtAnalysis = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlTotalWorkers.SuspendLayout();
            this.pnlPPECompliance.SuspendLayout();
            this.pnlAccidents.SuspendLayout();
            this.pnlWarnings.SuspendLayout();
            this.pnlChart.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtAnalysis)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAnalysisHeader
            // 
            this.lblAnalysisHeader.AutoSize = true;
            this.lblAnalysisHeader.Font = new System.Drawing.Font("맑은 고딕", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAnalysisHeader.Location = new System.Drawing.Point(273, 9);
            this.lblAnalysisHeader.Name = "lblAnalysisHeader";
            this.lblAnalysisHeader.Size = new System.Drawing.Size(73, 38);
            this.lblAnalysisHeader.TabIndex = 2;
            this.lblAnalysisHeader.Text = "분석";
            // 
            // pnlTotalWorkers
            // 
            this.pnlTotalWorkers.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlTotalWorkers.Controls.Add(this.label1);
            this.pnlTotalWorkers.Location = new System.Drawing.Point(280, 70);
            this.pnlTotalWorkers.Name = "pnlTotalWorkers";
            this.pnlTotalWorkers.Size = new System.Drawing.Size(200, 154);
            this.pnlTotalWorkers.TabIndex = 3;
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
            // pnlPPECompliance
            // 
            this.pnlPPECompliance.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlPPECompliance.Controls.Add(this.label2);
            this.pnlPPECompliance.Location = new System.Drawing.Point(509, 68);
            this.pnlPPECompliance.Name = "pnlPPECompliance";
            this.pnlPPECompliance.Size = new System.Drawing.Size(200, 156);
            this.pnlPPECompliance.TabIndex = 4;
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
            // pnlAccidents
            // 
            this.pnlAccidents.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlAccidents.Controls.Add(this.label3);
            this.pnlAccidents.Location = new System.Drawing.Point(742, 68);
            this.pnlAccidents.Name = "pnlAccidents";
            this.pnlAccidents.Size = new System.Drawing.Size(200, 156);
            this.pnlAccidents.TabIndex = 4;
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
            // pnlWarnings
            // 
            this.pnlWarnings.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlWarnings.Controls.Add(this.label4);
            this.pnlWarnings.Location = new System.Drawing.Point(970, 68);
            this.pnlWarnings.Name = "pnlWarnings";
            this.pnlWarnings.Size = new System.Drawing.Size(200, 156);
            this.pnlWarnings.TabIndex = 4;
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
            // pnlChart
            // 
            this.pnlChart.Controls.Add(this.chtAnalysis);
            this.pnlChart.Location = new System.Drawing.Point(280, 285);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(890, 376);
            this.pnlChart.TabIndex = 5;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlMenu.Controls.Add(this.label11);
            this.pnlMenu.Controls.Add(this.button7);
            this.pnlMenu.Controls.Add(this.button6);
            this.pnlMenu.Controls.Add(this.button5);
            this.pnlMenu.Controls.Add(this.button4);
            this.pnlMenu.Controls.Add(this.label5);
            this.pnlMenu.Controls.Add(this.button3);
            this.pnlMenu.Controls.Add(this.button2);
            this.pnlMenu.Controls.Add(this.button1);
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(268, 676);
            this.pnlMenu.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(56, 78);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(160, 2);
            this.label11.TabIndex = 9;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(21, 452);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(226, 51);
            this.button7.TabIndex = 6;
            this.button7.Text = "설정";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(22, 397);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(226, 51);
            this.button6.TabIndex = 5;
            this.button6.Text = "분석";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(21, 341);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(226, 51);
            this.button5.TabIndex = 4;
            this.button5.Text = "이력 / 로그";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(21, 285);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(226, 51);
            this.button4.TabIndex = 3;
            this.button4.Text = "대응 / 제어";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 45);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "PPE 관제시스템";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(21, 229);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(226, 51);
            this.button3.TabIndex = 2;
            this.button3.Text = "위반관리";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(22, 173);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(226, 51);
            this.button2.TabIndex = 1;
            this.button2.Text = "알림";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(22, 118);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "실시간 모니터링";
            this.button1.UseVisualStyleBackColor = false;
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
            this.chtAnalysis.Size = new System.Drawing.Size(890, 376);
            this.chtAnalysis.TabIndex = 0;
            this.chtAnalysis.Text = "chart1";
            // 
            // AnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 673);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlChart);
            this.Controls.Add(this.pnlWarnings);
            this.Controls.Add(this.pnlAccidents);
            this.Controls.Add(this.pnlPPECompliance);
            this.Controls.Add(this.pnlTotalWorkers);
            this.Controls.Add(this.lblAnalysisHeader);
            this.Name = "AnalysisForm";
            this.Text = "분석";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AnalysisForm_FormClosed);
            this.pnlTotalWorkers.ResumeLayout(false);
            this.pnlTotalWorkers.PerformLayout();
            this.pnlPPECompliance.ResumeLayout(false);
            this.pnlPPECompliance.PerformLayout();
            this.pnlAccidents.ResumeLayout(false);
            this.pnlAccidents.PerformLayout();
            this.pnlWarnings.ResumeLayout(false);
            this.pnlWarnings.PerformLayout();
            this.pnlChart.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtAnalysis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtAnalysis;
    }
}