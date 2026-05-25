using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.Design;

namespace PPE_관제_시스템
{
    public partial class US_AnalysisForm : UserControl
    {
        public US_AnalysisForm()
        {
            InitializeComponent();
            this.Load += US_AnalysisForm_Load;
            cmbPeriod.SelectedIndexChanged += cmbPeriod_SelectedIndexChanged;
            cmbChartType.SelectedIndexChanged += cmbChartType_SelectedIndexChanged;
        }

        private async System.Threading.Tasks.Task LoadDashboard()
        {
            try
            {
                string range =
                    cmbPeriod.SelectedItem?.ToString() ?? "";

                AnalysisDashboardStats stats =
                    await ApiService.GetDashboardStatsAsync(range);

                if (stats == null) return;

                lblTotalWorkersCount.Text =
                    stats.TotalWorkersCount.ToString();

                lblPPEComplianceRate.Text =
                    stats.PPEComplianceRate.ToString();

                lblAccidentCount.Text =
                    stats.TotalAccidentCount.ToString();

                lblWarningCount.Text =
                    stats.TotalWarningCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"대시보드 로드 실패\n{ex.Message}");
            }
        }

        private async Task LoadChart()
        {
            try
            {
                string range = cmbPeriod.Text;

                var result =
                    await ApiService.GetChartDataAsync(range);

                if (result == null || result.ChartData == null)
                {
                    MessageBox.Show("차트 데이터가 없습니다.");
                    return;
                }

                // 기존 차트 초기화
                chtAnalysis.Series.Clear();
                chtAnalysis.ChartAreas.Clear();
                chtAnalysis.Legends.Clear();

                // ChartArea 다시 생성
                ChartArea area = new ChartArea();
                chtAnalysis.ChartAreas.Add(area);

                // Legend 다시 생성
                Legend legend = new Legend();
                chtAnalysis.Legends.Add(legend);

                Series series = new Series();
                series.IsValueShownAsLabel = true;

                string chartType = cmbChartType.Text;

                // PPE 준수율
                if (chartType == "PPE 준수율")
                {
                    series.Name = "PPE 준수율";
                    series.ChartType = SeriesChartType.Line;

                    for (int i = 0; i < result.ChartData.Timeline.Count; i++)
                    {
                        string week = result.ChartData.Timeline[i];

                        string valueText =
                            result.ChartData.ComplianceTrend[i]
                            .Replace("%", "");

                        double value = Convert.ToDouble(valueText);

                        series.Points.AddXY(week, value);
                    }
                }

                // 위반 건수
                else if (chartType == "위반 건수")
                {
                    series.Name = "위반 건수";
                    series.ChartType = SeriesChartType.Column;

                    for (int i = 0; i < result.ChartData.Timeline.Count; i++)
                    {
                        string week = result.ChartData.Timeline[i];

                        int value =
                            result.ChartData.ViolationTrend[i];

                        series.Points.AddXY(week, value);
                    }
                }

                // 구역별 위반 현황
                else if (chartType == "구역별 위반 현황")
                {
                    series.Name = "구역별 위반";
                    series.ChartType = SeriesChartType.Pie;

                    foreach (var item in result.ChartData.ZoneViolations)
                    {
                        series.Points.AddXY(item.Key, item.Value);
                    }
                }

                chtAnalysis.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void US_AnalysisForm_Load(object sender, EventArgs e)
        {
            await LoadDashboard();
            await LoadChart();
        }

        private async void cmbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadDashboard();
            await LoadChart();
        }

        private async void cmbChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadDashboard();
            await LoadChart();
        }

    }
}
