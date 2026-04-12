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
        private List<US_AlertCard> alertCards = new List<US_AlertCard>(); // 모든 카드 저장 리스트
        private int currentPage = 0; // 현재 페이지 인덱스
        private int pageSize = 5; // 한 페이지에 보여줄 카드 수

        public AlertsForm()
        {
            InitializeComponent();
        }

        private void AddCard() // 카드 추가 (추후 DB 연동 필요)
        {
            alertCards.Clear();
            flpAlertsList.Controls.Clear();

            for (int i = 0; i < 10; i++)
            {
                var card = new US_AlertCard();
                card.SetData($"위반 유형 {i + 1}", $"2026-04-11 20:{56 + i}:25", $"Camera {i % 3 + 1} / {(char)('A' + i % 3)}구역", $"ID: {12345 + i}", null);
                alertCards.Add(card);
                flpAlertsList.Controls.Add(card);
            }

            UpdateCardVisibility();
        }

        private void UpdateCardVisibility() // 페이지에 따라 카드의 Visible 속성 조정
        {
            for (int i = 0; i < alertCards.Count; i++)
            {
                alertCards[i].Visible = i >= currentPage * pageSize && i < (currentPage + 1) * pageSize;
            }
            UpdatePageLabel();
        }

        private void lnkPrev_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // 이전 페이지로 이동
        {
            if (currentPage > 0)
            {
                currentPage--;
                UpdateCardVisibility();
            }
        }

        private void lnkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // 다음 페이지로 이동
        {
            if ((currentPage + 1) * pageSize < alertCards.Count)
            {
                currentPage++;
                UpdateCardVisibility();
            }
        }

        private void UpdatePageLabel() // 페이지 label 업데이트
        { 
            int totalPages = (alertCards.Count + pageSize - 1) / pageSize;
            if(totalPages == 0) 
                totalPages = 1;
            lblPage.Text = $"{currentPage + 1} / {totalPages}";
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
