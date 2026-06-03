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
    public partial class AlertResolution : Form
    {
        public string AdminId { get; set; }
        public string WorkerId { get; set; }
        public string Memo { get; private set; }
        public AlertResolution()
        {
            InitializeComponent();
        }

        public AlertResolution(string workerId) : this()
        {
            txtWorkerId.Text = workerId;
            txtWorkerId.ReadOnly = true;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdminId.Text))
            {
                MessageBox.Show("관리자 Id를 입력해주세요");
                return;
            }
            string inadminId = txtAdminId.Text.Trim();
            string inworkerId = txtWorkerId.Text.Trim();
            string inMemo= txtMemo.Text.Trim();

            AdminId = txtAdminId.Text.Trim();
            WorkerId = txtWorkerId.Text.Trim();
            Memo = txtMemo.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
