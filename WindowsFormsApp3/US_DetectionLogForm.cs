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
        private List<HistoryDto> HistoryLogs = new List<HistoryDto>();

        public US_DetectionLogForm()
        {
            InitializeComponent();

            this.Load += US_DetectionLogForm_Load;
            btnLogSearch.Click += btnLogSearch_Click;
            txtLogSearch.KeyDown += txtLogSearch_KeyDown;
            dgvLog.CellContentClick += dgvLog_CellContentClick;

            dtpStartDate.ValueChanged += dtpStartDate_ValueChanged;
            dtpEndDate.ValueChanged += dtpEndDate_ValueChanged;
        }

        private void InitGrid() // DataGridView 초기 설정 메서드
        {
            dgvLog.AutoGenerateColumns = false;
            dgvLog.Columns.Clear();
            dgvLog.AllowUserToAddRows = false;
            dgvLog.ReadOnly = true;
            dgvLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvLog.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "날짜", DataPropertyName = "Timestamp", Width = 150 });
            dgvLog.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "발생 내용", DataPropertyName = "LogType", Width = 100 });
            dgvLog.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "이름", DataPropertyName = "UserName", Width = 120 });

            DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn
            {
                Name = "btnDetail",
                HeaderText = "상세",
                Text = "보기",
                UseColumnTextForButtonValue = true,
                Width = 100
            };
            dgvLog.Columns.Add(btnDetail);
        }

        private void FilterLog() // 날짜 범위와 검색어를 기준으로 로그 데이터를 필터링하여 DataGridView에 표시하는 메서드
        {
            if (HistoryLogs == null) return;

            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1);
            string keyword = txtLogSearch.Text.Trim().ToLower();

            var filteredLogs = HistoryLogs
                .Where(log =>
                {
                    // 날짜 조건 검사
                    DateTime logDate;
                    bool isDateInRange = DateTime.TryParse(log.Timestamp, out logDate)
                        ? (logDate >= startDate && logDate <= endDate)
                        : true;

                    // 키워드 조건 검사
                    bool isKeywordValid = string.IsNullOrEmpty(keyword)
                        || (log.CameraName != null && log.CameraName.ToLower().Contains(keyword))
                        || (log.LogType != null && log.LogType.ToLower().Contains(keyword))
                        || (log.ZoneName != null && log.ZoneName.ToLower().Contains(keyword))
                        || (log.StatusText != null && log.StatusText.ToLower().Contains(keyword))
                        || (log.Detail != null && log.Detail.ToLower().Contains(keyword));

                    return isDateInRange && isKeywordValid;
                })
                .OrderByDescending(log =>
                {
                    return DateTime.TryParse(log.Timestamp, out DateTime dt) ? dt : DateTime.MinValue;
                })
                .ToList();

            dgvLog.DataSource = null;
            dgvLog.DataSource = filteredLogs;
        }


        private void dgvLog_CellContentClick(object sender, DataGridViewCellEventArgs e) // DataGridView의 버튼 클릭 이벤트 핸들러
        {
            try
            {
                if (e.RowIndex < 0) return;

                if (e.ColumnIndex == dgvLog.Columns["btnDetail"].Index)
                {
                    HistoryDto row = (HistoryDto)dgvLog.Rows[e.RowIndex].DataBoundItem;

                    MessageBox.Show
                    (
                        $"로그 ID : {row.LogID}\n\n" +
                        $"사용자 ID : {row.User?.UserID}\n\n" +
                        $"이름 : {row.UserName}\n\n" +
                        $"날짜 : {row.Timestamp}\n\n" +
                        $"발생 내용 : {row.LogType}\n\n" +
                        $"상세 : {row.Detail}",
                        "상세 정보",
                        MessageBoxButtons.OK
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"상세 조회 오류: {ex.Message}");
            }
        }

        private async Task LoadHistoryLog() // 히스토리 로그 데이터를 API에서 불러와 DataGridView에 바인딩하는 메서드
        {
            try
            {
                var logData = await ApiService.LoadHistoryLog();

                if (logData != null)
                {
                    HistoryLogs = logData;

                    FilterLog();
                }
                else
                {
                    MessageBox.Show("로그 데이터를 불러오는데 실패했습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"로그 데이터 로드 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void US_DetectionLogForm_Load(object sender, EventArgs e) // 폼이 로드될 때 히스토리 로그 데이터를 불러오는 이벤트 핸들러
        {
            InitGrid();

            dtpStartDate.Value = DateTime.Now.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;

            await LoadHistoryLog();
        }

        private void btnLogSearch_Click(object sender, EventArgs e) // 검색 버튼 클릭 이벤트 핸들러
        {
            FilterLog();
        }

        private void txtLogSearch_KeyDown(object sender, KeyEventArgs e) // 검색어 입력 텍스트박스에서 Enter 키를 눌렀을 때 검색 버튼 클릭 이벤트를 트리거하는 이벤트 핸들러
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogSearch_Click(sender, e);
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e) // 시작 날짜 변경 이벤트 핸들러
        {
            FilterLog();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e) // 종료 날짜 변경 이벤트 핸들러
        {
            FilterLog();
        }
    }
}