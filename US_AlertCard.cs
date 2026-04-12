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

        public void SetData(string violation, string date, string camerazone, string targetid, Image ppeimage) // 카드에 데이터 설정하는 메서드
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

        private void btnResolve_Click(object sender, EventArgs e) // 해결 버튼 클릭 시 이벤트 발생
        {
            
        }
    }
}
