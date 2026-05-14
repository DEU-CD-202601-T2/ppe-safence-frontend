using PPE_관제_시스템.Properties;
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

            //이벤트 연결
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

        private async void lnkPrev_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var serverData = await ApiService.GetViolationsAsync();

                if (serverData != null)
                {
                    DataManager.AllAlerts = serverData;
                }
                if (DataManager.CurrentPage > 0)
                {
                    DataManager.CurrentPage--;
                    ApplyFilter();
                }
            }
            catch(Exception ex)
            {
               
            }
        }

        private void lnkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string typeFilter = cmbViolation.SelectedItem?.ToString() ?? "전체";
            string camFilter = cmbCamera.SelectedItem?.ToString() ?? "전체";
            string zoneFilter = cmbZone.SelectedItem?.ToString() ?? "전체";

            int totalCount = DataManager.AllAlerts.Count(d =>
            d.Status == "미해결" &&
            (typeFilter == "전체" || d.Type.Contains(typeFilter)) &&
            (camFilter == "전체" || d.Cam.Contains(camFilter)) &&
            (zoneFilter == "전체" || d.Zone.Contains(zoneFilter))
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
            cmbViolation.Items.Clear();
            cmbViolation.Items.AddRange(new object[]
            {
                "전체",
                "마스크 미착용",
                "왼쪽 장갑 미착용",
                "오른쪽 장갑 미착용",
                "보호구 미착용"
            });
            cmbViolation.SelectedIndex = 0;

            cmbCamera.Items.Clear();
            cmbCamera.Items.AddRange(new object[]
            {
                "전체",
                "Camera 01",
                "Camera 02",
                "Camera 03",
            });
            cmbCamera.SelectedIndex = 0;

            cmbZone.Items.Clear();
            cmbZone.Items.AddRange(new object[]
            {
                "전체",
                "A구역",
                "B구역",
                "C구역",
            });
            cmbZone.SelectedIndex = 0;

            ApplyFilter();
        }
        private void ApplyFilter()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(ApplyFilter));
                return;
            }

            flpAlertsList.SuspendLayout();
            for(int i = flpAlertsList.Controls.Count - 1; i >= 0; i--)
            {
                var ctrl = flpAlertsList.Controls[i];
                flpAlertsList.Controls.Remove(ctrl);
                ctrl.Dispose();
            }

            var filteredList = GetFilteredList();

            var pageItems = filteredList
                .Skip(DataManager.CurrentPage * DataManager.PageSize)
                .Take(DataManager.PageSize)
                .ToList();

            foreach(var data in pageItems)
            {
                var card = new US_AlertCard();
                card.SetData(data.Type, data.Time, data.Zone, data.Cam, data.Id, data.Uid, data.Status, data.Img, false);

                card.OnResolveRequested += async (targetCard) =>
                {
                    using (var frm = new AlertResolution(targetCard.WorkerId))
                    {
                        if(frm.ShowDialog() == DialogResult.OK)
                        {
                            bool success = await ApiService.ResolveViolationAsync(targetCard.AlertId, frm.AdminId, frm.Memo);
                            if (success)
                            {
                                MessageBox.Show("해결 처리가 완료되었습니다");

                                DataManager.ResolveAlert(targetCard.AlertId);
                                DataManager.NotifyDataChanged();
                                ApplyFilter();
                            }
                            }
                    }
                };
                card.Width = flpAlertsList.ClientSize.Width - 10;
                flpAlertsList.Controls.Add(card);
            }
            flpAlertsList.ResumeLayout();
            UpdatePageLabel(filteredList.Count);
        }
        private void btnResolve_Click(object sender, EventArgs e)
        { 
            var card = (sender as Button)?.Parent as US_AlertCard;
            if (card == null) return;
            string targetId = card.AlertId;
            DataManager.ResolveAlert(targetId);
            DataManager.NotifyDataChanged();
            
   
        }
        private List<AlterDataClass> GetFilteredList()
        {
            string typeFilter = cmbViolation.SelectedItem?.ToString() ?? "전체";
            string camFilter = cmbCamera.SelectedItem?.ToString() ?? "전체";
            string zoneFilter = cmbZone.SelectedItem?.ToString() ?? "전체";

            var filteredList = DataManager.AllAlerts.Where(d =>
                d.Status == "미해결" &&
                (typeFilter == "전체" || d.Type.Contains(typeFilter)) &&
                (camFilter == "전체" || d.Cam.Contains(camFilter)) &&
                (zoneFilter == "전체" || d.Zone.Contains(zoneFilter))
            ).ToList();

            return filteredList;
        }
    }
}
