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
    public partial class US_AlertCard : UserControl
    {
        public US_AlertCard()
        {
            InitializeComponent();
        }

        public void SetData(string violation, string date, string camerazone, string targetid, Image ppeimage)
        {
            lblViolation.Text = violation;
            lblDate.Text = date;
            lblCameraZone.Text = camerazone;
            lblTargetID.Text = targetid;
            if (ppeimage != null)
            {
                picPPEImage.Image = ppeimage;
            }
        }

        private void btnResolve_Click(object sender, EventArgs e)
        {
           
        }
    }
}
