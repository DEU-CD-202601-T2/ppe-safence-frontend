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
    public partial class US_AlertsForm : UserControl
    {
        public US_AlertsForm()
        {
            InitializeComponent();
            DataManager.OnDataChanged += ApplyFilter;

            cmbViolation.SelectedIndexChanged += (s, e) => { DataManager.CurrentPage = 0; ApplyFilter(); };
            cmbCamera.SelectedIndexChanged += (s, e) => { DataManager.CurrentPage = 0; ApplyFilter(); };
            cmbZone.SelectedIndexChanged += (s, e) => { DataManager.CurrentPage = 0; ApplyFilter(); };

        }


        private void UpdatePageLabel(int totalCount) // 페이지 label 업데이트
        {
            int totalPages = (int)Math.Ceiling((double)totalCount / DataManager.PageSize);
            if (totalPages == 0)
                totalPages = 1;
            if (DataManager.CurrentPage >= totalPages)
                DataManager.CurrentPage = totalPages - 1;
            if (DataManager.CurrentPage < 0) DataManager.CurrentPage = 0;

            lblPage.Text = $"{DataManager.CurrentPage + 1} / {totalPages}";

            lnkPrev.Enabled = (DataManager.CurrentPage > 0);
            lnkNext.Enabled = (DataManager.CurrentPage + 1 < totalPages);
        }

        private void lnkPrev_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (DataManager.CurrentPage > 0)
            {
                DataManager.CurrentPage--;
                ApplyFilter();
            }
        }

        private void lnkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string typeFilter = cmbViolation.SelectedItem?.ToString() ?? "전체";
            string camFilter = cmbCamera.SelectedItem?.ToString() ?? "전체";


            int totalCount = DataManager.AllAlerts.Count(d =>
            d.Status == "미해결" &&
            (typeFilter == "전체" || d.Type.Contains(typeFilter)) &&
            (camFilter == "전체" || d.Location.Contains(camFilter))
            );
            int totalPages = (int)Math.Ceiling((double)totalCount / DataManager.PageSize);
            if ((DataManager.CurrentPage + 1) < totalPages)
            {
                DataManager.CurrentPage++;
                ApplyFilter();
            }
        }

        private void US_AlertsForm_Load(object sender, EventArgs e)
        {
            if(cmbViolation != null)
            {
                cmbViolation.Items.Clear();
                cmbViolation.Items.AddRange(new object[]
                {
                    "전체",
                    "방진마스크 미착용",
                    "안전화 미착용",
                    "장갑 미착용",
                    "보호구 미착용"
                });
                cmbViolation.SelectedIndex = 0;
            }
            ApplyFilter();
        }
        private void LoadDataFromDB()
        {
            if(DataManager.AllAlerts.Count == 0)
            {
                string[] violationTypes = { "방진마스크 미착용", "안전화 미착용", "장갑 미착용", "보호구 미착용" };

                for (int i = 1; i<= 25; i++) {
                    DataManager.AddAlert(
                        violationTypes[i%4],
                        $"Camera {i % 3 + 1} / {(char)('A' + i % 3)}구역"
                    );
                }
            }
            ApplyFilter();
        }
        
        private void ApplyFilter()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(ApplyFilter));
                return;
            }
            flpAlertsList.Controls.Clear();
            flpAlertsList.SuspendLayout();

            string typeFilter = cmbViolation.SelectedItem?.ToString() ?? "전체";
            string camFilter = cmbCamera.SelectedItem?.ToString() ?? "전체";

            var filteredList = DataManager.AllAlerts.Where(d =>
                d.Status == "미해결" &&
                (typeFilter == "전체" || d.Type.Contains(typeFilter)) &&
                (camFilter == "전체" || d.Location.Contains(camFilter))
            ).ToList();

            var pageItems = filteredList
            .Skip(DataManager.CurrentPage * DataManager.PageSize)
            .Take(DataManager.PageSize)
            .ToList();

            foreach(var data in pageItems)
            {
                var card = new US_AlertCard();
                card.SetData(data.Type, data.Time, data.Location, data.ID, data.Status, data.Img, false);

                card.OnResolveRequested += (targetCard) =>
                {
                    DialogResult result = MessageBox.Show("이 알람을 해결 처리하겠습니까?", "확인", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                        DataManager.ResolveAlert(targetCard.AlertID);
                };

               card.Width = flpAlertsList.Width - 30;
               flpAlertsList.Controls.Add(card);
            }
            flpAlertsList.ResumeLayout();
            UpdatePageLabel(filteredList.Count);
        }
    }
}
