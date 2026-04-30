using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

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
            try
            {
                var loginData = new { id = txtId, pw = txtPwd.Text };
                var content = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://43.200.27.117:5000/api/login?id=sim&pw=capston", content);
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    dynamic result = JsonConvert.DeserializeObject<dynamic>(responseString);

                    UserContext.JwtToken = result.token;
                    MessageBox.Show("로그인 성공");
                    this.Hide();

                    MainForm mainform = new MainForm();
                    mainform.Show();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("아이디 또는 비밀번호가 일치하지 않습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("서버 오류가 발생하였습니다: " + ex.Message);
                //추후에 삭제예정
                MainForm mainform = new MainForm();
                mainform.Show();
            }
        }



        private async Task<bool> AuthenticateUserAsync(string id, string pwd)
        {
            try
            {
                var loginData = new { user_id = id, password = pwd };
                var json = JsonConvert.SerializeObject(loginData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("http://43.200.27.117:5000", content);

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
