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
    public partial class US_DetectionLogForm : UserControl
    {
        public US_DetectionLogForm()
        {
            InitializeComponent();
        }
        private void US_DetectionLogForm_Load(object sender, EventArgs e)
        {
            LoadLogData();
        }

        private async void LoadLogData()
        {
            var logs = await ApiService.GetViolationsAsync();
            if(logs != null && logs.Count > 0)
            {
                dgvLog.DataSource = null;
                dgvLog.DataSource = logs;
            }
            else
            {
                MessageBox.Show("no");
            }
        }
    }
}
