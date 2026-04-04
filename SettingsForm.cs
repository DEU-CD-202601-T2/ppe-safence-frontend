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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            ShowControl(new US_PPEStandard());
        }

        private void ShowControl(UserControl us)
        {
            pnlShow.Controls.Clear();
            us.Dock = DockStyle.Fill;
            pnlShow.Controls.Add(us);
        }

        private void btnPPEStandard_Click(object sender, EventArgs e)
        {
            ShowControl(new US_PPEStandard());
        }

        private void btnAlertSettings_Click(object sender, EventArgs e)
        {
            ShowControl(new US_AlertSettings());
        }

        private void btnUserSettings_Click(object sender, EventArgs e)
        {
            ShowControl(new US_UsersSettings());
        }

        private void btnZoneSettings_Click(object sender, EventArgs e)
        {
            ShowControl(new US_ZoneSettings());
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
