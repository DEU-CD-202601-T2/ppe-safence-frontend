namespace PPE_관제_시스템
{
    partial class US_AnalysisForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpCards = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTotalWorkers = new System.Windows.Forms.Panel();
            this.lblTotalWorkersCount = new System.Windows.Forms.Label();
            this.lblTotalWorkers = new System.Windows.Forms.Label();
            this.pnlPPECompliance = new System.Windows.Forms.Panel();
            this.lblPPEComplianceRate = new System.Windows.Forms.Label();
            this.lblPPECompliance = new System.Windows.Forms.Label();
            this.pnlAccidents = new System.Windows.Forms.Panel();
            this.lblViolationCount = new System.Windows.Forms.Label();
            this.lblViolation = new System.Windows.Forms.Label();
            this.pnlWarnings = new System.Windows.Forms.Panel();
            this.lblWarningCount = new System.Windows.Forms.Label();
            this.lblWarnings = new System.Windows.Forms.Label();
            this.pnlComboRow = new System.Windows.Forms.Panel();
            this.cmbPeriod = new System.Windows.Forms.ComboBox();
            this.cmbChartType = new System.Windows.Forms.ComboBox();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.chtAnalysis = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tlpMain.SuspendLayout();
            this.tlpCards.SuspendLayout();
            this.pnlTotalWorkers.SuspendLayout();
            this.pnlPPECompliance.SuspendLayout();
            this.pnlAccidents.SuspendLayout();
            this.pnlWarnings.SuspendLayout();
            this.pnlComboRow.SuspendLayout();
            this.pnlChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtAnalysis)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.White;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpCards, 0, 0);
            this.tlpMain.Controls.Add(this.pnlComboRow, 0, 1);
            this.tlpMain.Controls.Add(this.pnlChart, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1228, 762);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpCards
            // 
            this.tlpCards.ColumnCount = 4;
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCards.Controls.Add(this.pnlTotalWorkers, 0, 0);
            this.tlpCards.Controls.Add(this.pnlPPECompliance, 1, 0);
            this.tlpCards.Controls.Add(this.pnlAccidents, 2, 0);
            this.tlpCards.Controls.Add(this.pnlWarnings, 3, 0);
            this.tlpCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCards.Location = new System.Drawing.Point(3, 3);
            this.tlpCards.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tlpCards.Name = "tlpCards";
            this.tlpCards.RowCount = 1;
            this.tlpCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCards.Size = new System.Drawing.Size(1222, 157);
            this.tlpCards.TabIndex = 0;
            // 
            // pnlTotalWorkers
            // 
            this.pnlTotalWorkers.BackColor = System.Drawing.Color.White;
            this.pnlTotalWorkers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTotalWorkers.Controls.Add(this.lblTotalWorkersCount);
            this.pnlTotalWorkers.Controls.Add(this.lblTotalWorkers);
            this.pnlTotalWorkers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTotalWorkers.Location = new System.Drawing.Point(8, 8);
            this.pnlTotalWorkers.Margin = new System.Windows.Forms.Padding(8);
            this.pnlTotalWorkers.Name = "pnlTotalWorkers";
            this.pnlTotalWorkers.Size = new System.Drawing.Size(289, 141);
            this.pnlTotalWorkers.TabIndex = 0;
            // 
            // lblTotalWorkersCount
            // 
            this.lblTotalWorkersCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalWorkersCount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalWorkersCount.Font = new System.Drawing.Font("맑은 고딕", 28F, System.Drawing.FontStyle.Bold);
            this.lblTotalWorkersCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblTotalWorkersCount.Location = new System.Drawing.Point(18, 73);
            this.lblTotalWorkersCount.Name = "lblTotalWorkersCount";
            this.lblTotalWorkersCount.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lblTotalWorkersCount.Size = new System.Drawing.Size(253, 62);
            this.lblTotalWorkersCount.TabIndex = 1;
            this.lblTotalWorkersCount.Text = "0";
            this.lblTotalWorkersCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalWorkers
            // 
            this.lblTotalWorkers.AutoSize = true;
            this.lblTotalWorkers.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalWorkers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.lblTotalWorkers.Location = new System.Drawing.Point(18, 15);
            this.lblTotalWorkers.Name = "lblTotalWorkers";
            this.lblTotalWorkers.Size = new System.Drawing.Size(121, 25);
            this.lblTotalWorkers.TabIndex = 0;
            this.lblTotalWorkers.Text = "총 작업자 수";
            // 
            // pnlPPECompliance
            // 
            this.pnlPPECompliance.BackColor = System.Drawing.Color.White;
            this.pnlPPECompliance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPPECompliance.Controls.Add(this.lblPPEComplianceRate);
            this.pnlPPECompliance.Controls.Add(this.lblPPECompliance);
            this.pnlPPECompliance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPPECompliance.Location = new System.Drawing.Point(313, 8);
            this.pnlPPECompliance.Margin = new System.Windows.Forms.Padding(8);
            this.pnlPPECompliance.Name = "pnlPPECompliance";
            this.pnlPPECompliance.Size = new System.Drawing.Size(289, 141);
            this.pnlPPECompliance.TabIndex = 1;
            // 
            // lblPPEComplianceRate
            // 
            this.lblPPEComplianceRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPPEComplianceRate.BackColor = System.Drawing.Color.Transparent;
            this.lblPPEComplianceRate.Font = new System.Drawing.Font("맑은 고딕", 28F, System.Drawing.FontStyle.Bold);
            this.lblPPEComplianceRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.lblPPEComplianceRate.Location = new System.Drawing.Point(18, 73);
            this.lblPPEComplianceRate.Name = "lblPPEComplianceRate";
            this.lblPPEComplianceRate.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lblPPEComplianceRate.Size = new System.Drawing.Size(253, 62);
            this.lblPPEComplianceRate.TabIndex = 1;
            this.lblPPEComplianceRate.Text = "0";
            this.lblPPEComplianceRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPPECompliance
            // 
            this.lblPPECompliance.AutoSize = true;
            this.lblPPECompliance.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblPPECompliance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.lblPPECompliance.Location = new System.Drawing.Point(18, 15);
            this.lblPPECompliance.Name = "lblPPECompliance";
            this.lblPPECompliance.Size = new System.Drawing.Size(141, 25);
            this.lblPPECompliance.TabIndex = 0;
            this.lblPPECompliance.Text = "PPE 준수율(%)";
            // 
            // pnlAccidents
            // 
            this.pnlAccidents.BackColor = System.Drawing.Color.White;
            this.pnlAccidents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAccidents.Controls.Add(this.lblViolationCount);
            this.pnlAccidents.Controls.Add(this.lblViolation);
            this.pnlAccidents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAccidents.Location = new System.Drawing.Point(618, 8);
            this.pnlAccidents.Margin = new System.Windows.Forms.Padding(8);
            this.pnlAccidents.Name = "pnlAccidents";
            this.pnlAccidents.Size = new System.Drawing.Size(289, 141);
            this.pnlAccidents.TabIndex = 2;
            // 
            // lblViolationCount
            // 
            this.lblViolationCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblViolationCount.BackColor = System.Drawing.Color.Transparent;
            this.lblViolationCount.Font = new System.Drawing.Font("맑은 고딕", 28F, System.Drawing.FontStyle.Bold);
            this.lblViolationCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.lblViolationCount.Location = new System.Drawing.Point(18, 73);
            this.lblViolationCount.Name = "lblViolationCount";
            this.lblViolationCount.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lblViolationCount.Size = new System.Drawing.Size(253, 62);
            this.lblViolationCount.TabIndex = 1;
            this.lblViolationCount.Text = "0";
            this.lblViolationCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblViolation
            // 
            this.lblViolation.AutoSize = true;
            this.lblViolation.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblViolation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.lblViolation.Location = new System.Drawing.Point(18, 15);
            this.lblViolation.Name = "lblViolation";
            this.lblViolation.Size = new System.Drawing.Size(121, 25);
            this.lblViolation.TabIndex = 0;
            this.lblViolation.Text = "총 위반 건수";
            // 
            // pnlWarnings
            // 
            this.pnlWarnings.BackColor = System.Drawing.Color.White;
            this.pnlWarnings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlWarnings.Controls.Add(this.lblWarningCount);
            this.pnlWarnings.Controls.Add(this.lblWarnings);
            this.pnlWarnings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWarnings.Location = new System.Drawing.Point(923, 8);
            this.pnlWarnings.Margin = new System.Windows.Forms.Padding(8);
            this.pnlWarnings.Name = "pnlWarnings";
            this.pnlWarnings.Size = new System.Drawing.Size(291, 141);
            this.pnlWarnings.TabIndex = 3;
            this.pnlWarnings.Visible = false;
            // 
            // lblWarningCount
            // 
            this.lblWarningCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWarningCount.BackColor = System.Drawing.Color.Transparent;
            this.lblWarningCount.Font = new System.Drawing.Font("맑은 고딕", 28F, System.Drawing.FontStyle.Bold);
            this.lblWarningCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.lblWarningCount.Location = new System.Drawing.Point(18, 73);
            this.lblWarningCount.Name = "lblWarningCount";
            this.lblWarningCount.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lblWarningCount.Size = new System.Drawing.Size(253, 62);
            this.lblWarningCount.TabIndex = 1;
            this.lblWarningCount.Text = "0";
            this.lblWarningCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblWarningCount.Visible = false;
            // 
            // lblWarnings
            // 
            this.lblWarnings.AutoSize = true;
            this.lblWarnings.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblWarnings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.lblWarnings.Location = new System.Drawing.Point(18, 15);
            this.lblWarnings.Name = "lblWarnings";
            this.lblWarnings.Size = new System.Drawing.Size(121, 25);
            this.lblWarnings.TabIndex = 0;
            this.lblWarnings.Text = "경고 발생 수";
            this.lblWarnings.Visible = false;
            // 
            // pnlComboRow
            // 
            this.pnlComboRow.BackColor = System.Drawing.Color.White;
            this.pnlComboRow.Controls.Add(this.cmbPeriod);
            this.pnlComboRow.Controls.Add(this.cmbChartType);
            this.pnlComboRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlComboRow.Location = new System.Drawing.Point(8, 165);
            this.pnlComboRow.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.pnlComboRow.Name = "pnlComboRow";
            this.pnlComboRow.Size = new System.Drawing.Size(1212, 40);
            this.pnlComboRow.TabIndex = 1;
            // 
            // cmbPeriod
            // 
            this.cmbPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPeriod.BackColor = System.Drawing.Color.White;
            this.cmbPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPeriod.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cmbPeriod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cmbPeriod.FormattingEnabled = true;
            this.cmbPeriod.Items.AddRange(new object[] {
            "이번 달",
            "이번 주"});
            this.cmbPeriod.Location = new System.Drawing.Point(950, 5);
            this.cmbPeriod.Name = "cmbPeriod";
            this.cmbPeriod.Size = new System.Drawing.Size(120, 31);
            this.cmbPeriod.TabIndex = 0;
            this.cmbPeriod.Text = "이번 달";
            this.cmbPeriod.SelectedIndexChanged += new System.EventHandler(this.cmbPeriod_SelectedIndexChanged);
            // 
            // cmbChartType
            // 
            this.cmbChartType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbChartType.BackColor = System.Drawing.Color.White;
            this.cmbChartType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbChartType.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cmbChartType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cmbChartType.FormattingEnabled = true;
            this.cmbChartType.Items.AddRange(new object[] {
            "PPE 준수율",
            "위반 건수",
            "구역별 위반 현황"});
            this.cmbChartType.Location = new System.Drawing.Point(1080, 5);
            this.cmbChartType.Name = "cmbChartType";
            this.cmbChartType.Size = new System.Drawing.Size(125, 31);
            this.cmbChartType.TabIndex = 1;
            this.cmbChartType.Text = "PPE 준수율";
            this.cmbChartType.SelectedIndexChanged += new System.EventHandler(this.cmbChartType_SelectedIndexChanged);
            // 
            // pnlChart
            // 
            this.pnlChart.BackColor = System.Drawing.Color.White;
            this.pnlChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChart.Controls.Add(this.chtAnalysis);
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart.Location = new System.Drawing.Point(8, 210);
            this.pnlChart.Margin = new System.Windows.Forms.Padding(8, 0, 8, 8);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(1212, 544);
            this.pnlChart.TabIndex = 2;
            // 
            // chtAnalysis
            // 
            chartArea4.BackColor = System.Drawing.Color.White;
            chartArea4.Name = "ChartArea1";
            this.chtAnalysis.ChartAreas.Add(chartArea4);
            this.chtAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.BackColor = System.Drawing.Color.White;
            legend4.Name = "Legend1";
            this.chtAnalysis.Legends.Add(legend4);
            this.chtAnalysis.Location = new System.Drawing.Point(0, 0);
            this.chtAnalysis.Name = "chtAnalysis";
            series4.ChartArea = "ChartArea1";
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chtAnalysis.Series.Add(series4);
            this.chtAnalysis.Size = new System.Drawing.Size(1210, 542);
            this.chtAnalysis.TabIndex = 0;
            this.chtAnalysis.Text = "chart1";
            // 
            // US_AnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tlpMain);
            this.Name = "US_AnalysisForm";
            this.Size = new System.Drawing.Size(1228, 762);
            this.Load += new System.EventHandler(this.US_AnalysisForm_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpCards.ResumeLayout(false);
            this.pnlTotalWorkers.ResumeLayout(false);
            this.pnlTotalWorkers.PerformLayout();
            this.pnlPPECompliance.ResumeLayout(false);
            this.pnlPPECompliance.PerformLayout();
            this.pnlAccidents.ResumeLayout(false);
            this.pnlAccidents.PerformLayout();
            this.pnlWarnings.ResumeLayout(false);
            this.pnlWarnings.PerformLayout();
            this.pnlComboRow.ResumeLayout(false);
            this.pnlChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtAnalysis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpCards;
        private System.Windows.Forms.Panel pnlTotalWorkers;
        private System.Windows.Forms.Label lblTotalWorkersCount;
        private System.Windows.Forms.Label lblTotalWorkers;
        private System.Windows.Forms.Panel pnlPPECompliance;
        private System.Windows.Forms.Label lblPPEComplianceRate;
        private System.Windows.Forms.Label lblPPECompliance;
        private System.Windows.Forms.Panel pnlAccidents;
        private System.Windows.Forms.Label lblViolationCount;
        private System.Windows.Forms.Label lblViolation;
        private System.Windows.Forms.Panel pnlWarnings;
        private System.Windows.Forms.Label lblWarningCount;
        private System.Windows.Forms.Label lblWarnings;
        private System.Windows.Forms.Panel pnlComboRow;
        private System.Windows.Forms.ComboBox cmbPeriod;
        private System.Windows.Forms.ComboBox cmbChartType;
        private System.Windows.Forms.Panel pnlChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtAnalysis;
    }
}