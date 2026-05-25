using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PPE_관제_시스템
{
    public partial class UserEditForm : Form
    {
        private UserData editUser;
        public UserEditForm() // 추가 모드로 폼을 열 때 사용하는 기본 생성자
        {
            InitializeComponent();
        }

        public UserEditForm(UserData user) // 수정 모드로 폼을 열 때 사용자 데이터를 전달받는 생성자
        {
            InitializeComponent();

            editUser = user;

            LoadUserData();
        }

        private void LoadUserData()
        {
            if (editUser == null)
                return;

            txtName.Text = editUser.name;
            txtId.Text = editUser.login_id;

            txtPwd.Text = "";
            txtPwd.Enabled = false;

            txtRole.Text = editUser.role;
            txtDepartment.Text = editUser.department;

            txtId.Enabled = false;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 추가 모드
                if (editUser == null)
                {
                    UserData user = new UserData()
                    {
                        name = txtName.Text,
                        login_id = txtId.Text,
                        password = txtPwd.Text,
                        role = txtRole.Text,
                        department = txtDepartment.Text,
                        status = "활성"
                    };

                    bool success =
                        await ApiService.AddUserAsync(user);

                    if (success)
                    {
                        MessageBox.Show("사용자 추가 완료");

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("사용자 추가 실패");
                    }
                }
                // 수정 모드
                else
                {
                    UserData updateUser = new UserData()
                    {
                        userID = editUser.userID,
                        name = txtName.Text,
                        login_id = editUser.login_id,
                        role = txtRole.Text,
                        department = txtDepartment.Text,
                        status = editUser.status
                    };

                    bool success =
                        await ApiService.UpdateUserAsync(updateUser);

                    if (success)
                    {
                        MessageBox.Show("사용자 수정 완료");

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("사용자 수정 실패");
                    }
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
