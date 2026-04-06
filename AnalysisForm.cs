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
    public partial class AnalysisForm : Form
    {
        public AnalysisForm()
        {
            InitializeComponent();
        }

        private void AnalysisForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
