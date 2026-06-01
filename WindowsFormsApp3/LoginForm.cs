using System.IO;
using Newtonsoft.Json;
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
            
            this.Text = "PPE 관제 시스템";
            
            string iconPath = Path.Combine(Application.StartupPath, "Resources", "PPE_Icon.ico");
            if (File.Exists(iconPath))
            {
                this.Icon = new Icon(iconPath);
            }
            
            txtPwd.PasswordChar = '*';
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {

                var loginData = new { login_id = txtId.Text, password = txtPwd.Text };
                var json = JsonConvert.SerializeObject(loginData);
                var content = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://43.200.27.117:5002/api/login", content);
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    dynamic result = JsonConvert.DeserializeObject<dynamic>(responseString);
                    UserContext.JwtToken = (string)result["token"];

                    ProceedToMain();
                }
                else
                {
                    string errorBody = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"아이디 또는 비밀번호가 일치하지 않습니다.\n({(int)response.StatusCode}: {errorBody})");
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
