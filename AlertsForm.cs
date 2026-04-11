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
    public partial class AlertsForm : Form
    {
        public AlertsForm()
        {
            InitializeComponent();
        }

        private void AddCard()
        {
            for (int i = 0; i < 10; i++) // 테스트 용 10개의 카드 추가 (추후 DB 연동 필요)
            {
                var card = new US_AlertCard();
                card.SetData($"위반 유형 {i + 1}", $"2026-04-11 20:{56 + i}:25", $"Camera {i % 3 + 1} / {(char)('A' + i % 3)}구역", $"ID: {12345 + i}", null);
                flpAlertsList.Controls.Add(card);
            }
        }

        private void AlertsForm_Load(object sender, EventArgs e)
        {
            AddCard();
        }

        private void btnLiveMonitoring_Click(object sender, EventArgs e)
        {
            LiveMonitoringForm liveMonitoringForm = new LiveMonitoringForm();
            liveMonitoringForm.Show();
            this.Close();
        }
    }
}
