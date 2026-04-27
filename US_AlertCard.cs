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

        public void SetData(string violation, string date, string camerazone, string targetid, string status, Image ppeimage) // 카드에 데이터 설정하는 메서드
        {
            lblViolation.Text = violation;
            lblDate.Text = date;
            lblCameraZone.Text = camerazone;
            lblTargetID.Text = targetid;
            lblStatus.Text = status; // 상태 설정
            if (ppeimage != null)
            {
                picPPEImage.Image = ppeimage;
            }

            if (status == "해결")
            {
                lblStatus.ForeColor = Color.Green; // 해결인 경우 초록색으로 표시
            }
            else
            {
                lblStatus.ForeColor = Color.Red; // 미해결인 경우 빨간색으로 표시
            }
        }

        public void HideResolveButton() // 해결 버튼 숨기는 메서드
        {
            btnResolve.Visible = false;
        }

        private void btnResolve_Click(object sender, EventArgs e) // 해결 버튼 클릭 시 이벤트 발생
        {
            
        }
    }
}
