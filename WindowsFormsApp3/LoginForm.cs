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
                var json = JsonConvert.SerializeObject(loginData);
                var content = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "/application/json");

                var response = await client.PostAsync("http://43.200.27.117:5000", content);
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    dynamic result = JsonConvert.DeserializeObject<dynamic>(responseString);
                    UserContext.JwtToken = result.token;

                    ProceedToMain();
                }
                else
                {
                    MessageBox.Show("아이디 또는 비밀번호가 일치하지 않습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("서버 오류가 발생하였습니다: 테스트 모드 진입합니다");
                UserContext.JwtToken = "dumy_token_for_testing";

                ProceedToMain();
            }
        }
        private void ProceedToMain()
        {
            this.Hide();
            MainForm mainform = new MainForm();
            mainform.FormClosed += (s, args) => Application.Exit();
            mainform.Show();
        }
    }
}
