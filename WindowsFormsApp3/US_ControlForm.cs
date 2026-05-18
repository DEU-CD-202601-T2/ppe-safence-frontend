using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace PPE_관제_시스템
{
    public partial class US_ControlForm : UserControl
    {
        public US_ControlForm()
        {
            InitializeComponent();
            DataManager.OnDataChanged += UpdateUI;
            DataManager.InitTestData();
        }
        private void UpdateUI()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(UpdateUI));
                return;
            }

            var alerts = DataManager.AllAlerts;
            lblAlertCount.Text = $"{alerts.Count}건";
            lblPersonCount.Text = $"{alerts.Count(a => a.Status == "미해결")}명";

            dgvActiveWorkers.Rows.Clear();
            foreach (var alert in alerts)
            {
                dgvActiveWorkers.Rows.Add(
                    alert.Uid,
                    "이름 없음",
                    alert.Zone,
                    alert.Type,
                    alert.Status,
                    alert.Time
                    );
            }
        }
    }
}
