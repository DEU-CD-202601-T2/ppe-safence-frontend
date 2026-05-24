using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace PPE_관제_시스템
{
    public partial class US_ControlForm : UserControl
    {
        private CheckBox headerCheckBox = new CheckBox();
        public US_ControlForm()
        {
            InitializeComponent();
        }

        private void HeaderCheckBox_CheckedChanged(object sender, EventArgs e) //체크박스 상태 변경 이벤트 핸들러
        {
            dgvActiveWorkers.EndEdit();

            foreach (DataGridViewRow row in dgvActiveWorkers.Rows)
            {
                row.Cells["colSelect"].Value =
                    headerCheckBox.Checked;
            }
        }

        private void AddCheckBoxColumn() // 체크박스 열 추가 메서드
        {
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();

            chk.Name = "colSelect";
            chk.HeaderText = "선택";
            chk.Width = 40;

            dgvActiveWorkers.Columns.Insert(0, chk);
        }

        private async void btnResumeOperation_Click(object sender, EventArgs e) // 작업 중지 해제 버튼 클릭 이벤트 핸들러
        {
            List<string> selectedWorkerIds = new List<string>();

            foreach (DataGridViewRow row in dgvActiveWorkers.Rows)
            {
                bool isChecked = row.Cells["colSelect"].Value != null &&
                                 Convert.ToBoolean(row.Cells["colSelect"].Value);

                if (isChecked)
                {
                    int workerId =
                        Convert.ToInt32(row.Cells["colWorkerId"].Value);

                    selectedWorkerIds.Add(workerId.ToString());
                }
            }

            if (selectedWorkerIds.Count == 0)
            {
                MessageBox.Show("작업자를 선택하세요.");
                return;
            }

            bool result =
                await ApiService.ResumeWorkersAsync(selectedWorkerIds);

            if (result)
            {
                MessageBox.Show("작업 중지 해제가 완료되었습니다.");

                var workers = await ApiService.GetWorkerInfosAsync();
                dgvActiveWorkers.DataSource = workers;
            }
        }

        private async void US_ControlForm_Load(object sender, EventArgs e)
        {
            dgvActiveWorkers.AllowUserToAddRows = false;
            dgvActiveWorkers.AutoGenerateColumns = false;

            if (!dgvActiveWorkers.Columns.Contains("colSelect"))
            {
                AddCheckBoxColumn();
            }

            var summary = await ApiService.GetControlSummaryAsync();

            // PPE 미착용자 수, 경고 건수, 센서 상태 표시
            lblPersonCount.Text = $"{summary.PpeNotWearingCount}명";
            dgvActiveWorkers.Text = $"{summary.WarningCount}건";
            lblSensorStatus.Text = summary.SensorStatus;

            // DataGridView 컬럼과 WorkerInfo 속성 매핑
            dgvActiveWorkers.Columns["colWorkerId"].DataPropertyName = "workerId";
            dgvActiveWorkers.Columns["colName"].DataPropertyName = "name";
            dgvActiveWorkers.Columns["colLocation"].DataPropertyName = "location";
            dgvActiveWorkers.Columns["colPpeStatus"].DataPropertyName = "ppeStatus";
            dgvActiveWorkers.Columns["colStatus"].DataPropertyName = "status";
            dgvActiveWorkers.Columns["colTime"].DataPropertyName = "time";

            var workers = await ApiService.GetWorkerInfosAsync();
            dgvActiveWorkers.DataSource = workers;
        }
    }
}
