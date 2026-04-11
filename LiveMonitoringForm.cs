using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PPE_관제_시스템
{
    public partial class LiveMonitoringForm : Form
    {
        public LiveMonitoringForm()
        {
            InitializeComponent();
        }

        private void btnAlerts_Click(object sender, EventArgs e)
        {
            AlertsForm alertsForm = new AlertsForm();
            alertsForm.Show();
            this.Close();
        }
    }
}
