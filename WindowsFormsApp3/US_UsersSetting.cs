using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PPE_관제_시스템
{
    public partial class US_UsersSetting : UserControl
    {
        private List<WorkerInfo> workerList = new List<WorkerInfo>();
        public US_UsersSetting()
        {
            InitializeComponent();
        }

        private async Task LoadUserList() // 사용자 리스트 로드
        {
            try
            {
                dgvUsersSetting.Rows.Clear();
                var users = await ApiService.GetUsersAsync();
                if (users == null) return;

                foreach (var user in users)
                {
                    dgvUsersSetting.Rows.Add(user.userID, user.name, user.login_id, user.role, user.department, user.status);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"사용자 목록 로드 실패\n{ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitGrid() // DataGridView 초기 설정
        {
            dgvUsersSetting.Columns.Clear();
            dgvUsersSetting.RowHeadersVisible = false;

            dgvUsersSetting.Columns.Add("userID", "ID");
            dgvUsersSetting.Columns["userID"].Visible = false;

            dgvUsersSetting.Columns.Add("name", "이름");
            dgvUsersSetting.Columns.Add("login_id", "ID");
            dgvUsersSetting.Columns.Add("role", "역할");
            dgvUsersSetting.Columns.Add("department", "소속(구역)");
            dgvUsersSetting.Columns.Add("status", "상태");

            DataGridViewButtonColumn manageColumn = new DataGridViewButtonColumn();
            manageColumn.Name = "관리";
            manageColumn.HeaderText = "관리";
            manageColumn.Text = "수정 / 삭제";
            manageColumn.UseColumnTextForButtonValue = true;

            dgvUsersSetting.Columns.Add(manageColumn);

            // 이벤트 중복 등록 방지를 위해 기존 핸들러 제거 후 재등록
            dgvUsersSetting.CellClick -= dgvUsersSetting_CellClick;
            dgvUsersSetting.CellClick += dgvUsersSetting_CellClick;
        }

        private async void dgvUsersSetting_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string columnName = dgvUsersSetting.Columns[e.ColumnIndex].Name;

            if (columnName == "관리")
            {
                UserData user = new UserData()
                {
                    userID = dgvUsersSetting.Rows[e.RowIndex].Cells["userID"].Value?.ToString(),
                    name = dgvUsersSetting.Rows[e.RowIndex].Cells["name"].Value?.ToString(),
                    login_id = dgvUsersSetting.Rows[e.RowIndex].Cells["login_id"].Value?.ToString(),
                    role = dgvUsersSetting.Rows[e.RowIndex].Cells["role"].Value?.ToString(),
                    department = dgvUsersSetting.Rows[e.RowIndex].Cells["department"].Value?.ToString(),
                    status = dgvUsersSetting.Rows[e.RowIndex].Cells["status"].Value?.ToString()
                };

                ContextMenuStrip menu = new ContextMenuStrip();

                // 수정 메뉴
                menu.Items.Add("수정", null, async (s, ev) =>
                {
                    UserEditForm frm = new UserEditForm(user);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        await LoadUserList();
                    }
                });

                // 삭제 메뉴
                menu.Items.Add("삭제", null, async (s, ev) =>
                {
                    DialogResult result = MessageBox.Show("삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        bool success = await ApiService.DeleteUserAsync(Convert.ToInt32(user.userID));
                        if (success)
                        {
                            await LoadUserList();
                        }
                        else
                        {
                            MessageBox.Show("삭제 실패");
                        }
                    }
                });

                Point p = dgvUsersSetting.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location; // 버튼 위치에 메뉴 표시
                menu.Show(dgvUsersSetting, p.X, p.Y + dgvUsersSetting.Rows[e.RowIndex].Height); // 메뉴가 버튼 아래에 나타나도록 조정
            }
        }

        private async void US_UsersSetting_Load(object sender, EventArgs e)
        {
            try { 
                InitGrid();
                await LoadUserList();
                }
                
      
            catch(Exception ex)
            {
                MessageBox.Show($"사용자 데이터 불러오는 중 오류가 발생");
            }
        }

        private async void US_UserSetting_Load(object sender, EventArgs e)
        {
            try
            {
                InitGrid();
                await LoadUserList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"사용자 데이터를 불러오는 중 오류가 발생했습니다.\n{ex.Message}");
            }
        }

        private async void btnUserAdd_Click(object sender, EventArgs e)
        {
            try
            {
                UserEditForm frm = new UserEditForm();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    await LoadUserList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}