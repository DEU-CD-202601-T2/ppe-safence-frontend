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
            cmbStatus.SelectedIndex = 0; // 추가 시 기본 "활성"
        }

        public UserEditForm(UserData user) // 수정 모드로 폼을 열 때 사용자 데이터를 전달받는 생성자
        {
            InitializeComponent();

            editUser = user;

            LoadUserData();
        }

        private void LoadUserData() // 수정 모드로 폼이 열릴 때 사용자 데이터를 폼의 입력 필드에 로드하는 메서드
        {
            if (editUser == null)
                return;

            txtName.Text = editUser.name;
            txtId.Text = editUser.login_id;

            txtPwd.Text = "";

            if (!cmbRole.Items.Contains(editUser.role))
                cmbRole.Items.Add(editUser.role);
            cmbRole.SelectedItem = editUser.role;

            cmbStatus.SelectedItem = editUser.status;
            // 현재 로그인한 계정은 활성화 여부를 변경할 수 없음
            if (editUser.login_id == UserContext.CurrentLoginId)
                cmbStatus.Enabled = false;

            txtId.Enabled = false;
        }

        private async void btnSave_Click(object sender, EventArgs e) // 저장 버튼 클릭 이벤트 핸들러로, 추가 모드와 수정 모드 모두에서 사용자 데이터를 API를 통해 저장하는 기능을 수행
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
                        role = cmbRole.SelectedItem?.ToString(),
                        status = cmbStatus.SelectedItem?.ToString()
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
                        role = cmbRole.SelectedItem?.ToString(),
                        password = txtPwd.Text,
                        status = cmbStatus.SelectedItem?.ToString()
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