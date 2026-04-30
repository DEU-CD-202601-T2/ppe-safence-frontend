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
        public event Action<US_AlertCard> OnResolveRequested; // 해결 버튼 클릭 이벤트
        public string LocationInfo { get; set; }
        public string AlertID { get; private set; } // 알람 ID 속성
        public US_AlertCard()
        {
            InitializeComponent();
        }

        public void SetData(string type, string time, string location, string id, string status, Image img, bool isManagementMode) // 카드에 데이터 설정하는 메서드
        {
            this.AlertID = id;
            this.LocationInfo = location;
            lblViolation.Text = type;
            lblDate.Text = time;
            lblCameraZone.Text = location;
            lblTargetID.Text = id;
            lblStatus.Text = status; // 상태 설정
            if (img != null)
            {
                if(picPPEImage.Image != null)picPPEImage.Image.Dispose();
                picPPEImage.Image = img;
                picPPEImage.SizeMode = PictureBoxSizeMode.Zoom;
            }
        
            if (status == "해결")
            {
                lblStatus.ForeColor = Color.Green; // 해결인 경우 초록색으로 표시
                  
            }
            else
            {
                lblStatus.ForeColor = Color.Red; // 미해결인 경우 빨간색으로 표시
            }

            if (isManagementMode)
            {
                btnResolve.Visible = false;
            }
            else
            {
                btnResolve.Visible = (status == "미해결");
            }
        }

        public void HideResolveButton() // 해결 버튼 숨기는 메서드
        {
            btnResolve.Visible = false;
        }

        private void btnResolve_Click(object sender, EventArgs e) // 해결 버튼 클릭 시 이벤트 발생
        {
            OnResolveRequested?.Invoke(this);
            
        }
    }
}
