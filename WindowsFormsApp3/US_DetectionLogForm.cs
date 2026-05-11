using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPE_관제_시스템
{
    public partial class US_DetectionLogForm : UserControl
    {
        public US_DetectionLogForm()
        {
            InitializeComponent();
            this.Load += US_DetectionLogForm_Load;
        }

        private void InitGrid() // DataGridView 초기 설정 메서드
        {
            dgvLog.AutoGenerateColumns = false;

            dgvLog.Columns.Clear();

            dgvLog.AllowUserToAddRows = false;

            dgvLog.ReadOnly = true;

            dgvLog.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // 날짜
            dgvLog.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "날짜",
                DataPropertyName = "date",
                Width = 150
            });

            // 발생 내용
            dgvLog.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "발생 내용",
                DataPropertyName = "content",
                Width = 250
            });

            // 위치
            dgvLog.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "위치",
                DataPropertyName = "location",
                Width = 150
            });

            // 상태
            dgvLog.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "상태",
                DataPropertyName = "status",
                Width = 120
            });

            // 상세 버튼
            DataGridViewButtonColumn btnDetail =
                new DataGridViewButtonColumn();

            btnDetail.HeaderText = "상세";

            btnDetail.Text = "보기";

            btnDetail.UseColumnTextForButtonValue = true;

            btnDetail.Width = 100;

            dgvLog.Columns.Add(btnDetail);

            // 버튼 클릭 이벤트
            dgvLog.CellContentClick += dgvLog_CellContentClick;
        }

        private void dgvLog_CellContentClick(object sender, DataGridViewCellEventArgs e) // DataGridView의 버튼 클릭 이벤트 핸들러
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dgvLog.Columns["btnDetail"].Index)
            {
                HistoryDto row =
                    (HistoryDto)dgvLog.Rows[e.RowIndex].DataBoundItem;

                MessageBox.Show(
                    $"날짜 : {row.date}\n\n" +
                    $"발생 내용 : {row.content}\n\n" +
                    $"위치 : {row.location}\n\n" +
                    $"상태 : {row.status}\n\n" +
                    $"상세 : {row.detail}",
                    "상세 정보");
            }
        }

        private async Task LoadHistoryLog() // 히스토리 로그 데이터를 API에서 불러와 DataGridView에 바인딩하는 메서드
        {
            try
            {
                var LogData = await ApiService.LoadHistoryLog();
                if (LogData != null)
                {
                    dgvLog.DataSource = LogData;
                }
                else
                {
                    MessageBox.Show("히스토리 데이터를 불러오는데 실패했습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"히스토리 데이터 로드 중 오류 발생: {ex.Message}");
            }
        }

        private async void US_DetectionLogForm_Load(object sender, EventArgs e) // 폼이 로드될 때 히스토리 로그 데이터를 불러오는 이벤트 핸들러
        {
            InitGrid();
            await LoadHistoryLog();
        }
    }
}
