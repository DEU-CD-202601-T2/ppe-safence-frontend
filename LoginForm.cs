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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            DetectionLogForm detectionLogForm = new DetectionLogForm();
            AnalysisForm analysisForm = new AnalysisForm();
            settingsForm.Show();
            detectionLogForm.Show();
            analysisForm.Show();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
