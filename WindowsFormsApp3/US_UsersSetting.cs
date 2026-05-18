using Org.BouncyCastle.Asn1.Cmp;
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
    public partial class US_UsersSetting : UserControl
    {
        public US_UsersSetting()
        {
            InitializeComponent();
        }

        private async Task LoadUserList() // 사용자 리스트 로드
        {
            try 
            { dgvUsersSetting.Rows.Clear(); 
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

        private void InitGrid()
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

            dgvUsersSetting.CellClick += dgvUsersSetting_CellClick;
        }

        private async void dgvUsersSetting_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string columnName =
                dgvUsersSetting.Columns[e.ColumnIndex].Name;

            if (columnName == "관리")
            {
                UserData user = new UserData()
                {
                    userID = dgvUsersSetting.Rows[e.RowIndex]
                        .Cells["userID"]
                        .Value?.ToString(),

                    name = dgvUsersSetting.Rows[e.RowIndex]
                        .Cells["name"]
                        .Value?.ToString(),

                    login_id = dgvUsersSetting.Rows[e.RowIndex]
                        .Cells["login_id"]
                        .Value?.ToString(),

                    role = dgvUsersSetting.Rows[e.RowIndex]
                        .Cells["role"]
                        .Value?.ToString(),

                    department = dgvUsersSetting.Rows[e.RowIndex]
                        .Cells["department"]
                        .Value?.ToString(),

                    status = dgvUsersSetting.Rows[e.RowIndex]
                        .Cells["status"]
                        .Value?.ToString()
                };

                ContextMenuStrip menu = new ContextMenuStrip();

                // 수정
                menu.Items.Add("수정", null, async (s, ev) =>
                {
                    UserEditForm frm = new UserEditForm(user);

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        await LoadUserList();
                    }
                });

                // 삭제
                menu.Items.Add("삭제", null, async (s, ev) =>
                {
                    DialogResult result = MessageBox.Show(
                        "삭제하시겠습니까?",
                        "삭제 확인",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        bool success =
                            await ApiService.DeleteUserAsync(
                                Convert.ToInt32(user.userID)
                            );

                        if (success)
                        {
                            MessageBox.Show("삭제 완료");

                            await LoadUserList();
                        }
                        else
                        {
                            MessageBox.Show("삭제 실패");
                        }
                    }
                });

                menu.Show(Cursor.Position);
            }
        }

        private async void US_UsersSetting_Load(object sender, EventArgs e)
        {
            InitGrid();
            await LoadUserList();
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
                MessageBox.Show(
                    ex.Message,
                    "오류",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
