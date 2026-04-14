using System;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.CodeDom;
using System.Diagnostics.Eventing.Reader;

namespace PPE_관제_시스템
{
    public partial class LoginForm : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public LoginForm()
        {
            InitializeComponent();
            txtPwd.PasswordChar = '*';
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string id = txtId.Text.Trim();
            string pwd = txtPwd.Text.Trim();

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("아이디와 비밀번호를 모두 입력해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                btnLogin.Enabled = false;
                btnLogin.Text = "로그인 중...";

                bool loginsuccess = await AuthenticateUserAsync(id, pwd);

                if (loginsuccess)
                {
                    this.Hide();
                    LiveMonitoringForm ManagerView = new LiveMonitoringForm();
                    ManagerView.Show();
                }
                else
                {
                    MessageBox.Show("아이디 또는 비밀번호가 올바르지 않습니다", "로그인 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPwd.Clear();
                    txtId.Focus();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("서버 연결에 실패했습니다:", "연결 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "로그인";
            }
        }
        
        private async Task<bool> AuthenticateUserAsync(string id, string pwd)
        {
            try
            {
                var loginData = new { user_id = id, password = pwd };
                var json = JsonConvert.SerializeObject(loginData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("http://192.168.1.103:5000/api/login", content);

                return response.IsSuccessStatusCode;
            }
            catch
            {
                throw new Exception("네트워크 오류");
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
