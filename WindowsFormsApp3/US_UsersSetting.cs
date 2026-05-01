using Org.BouncyCastle.Asn1.Cmp;
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
    public partial class US_UsersSetting : UserControl
    {
        public US_UsersSetting()
        {
            InitializeComponent();
            //DataManager.OnDataChanged += RefreshCardList;

            //if (cmbZone != null)
            //    cmbZone.SelectedIndexChanged += (s, e) => RefreshCardList();
            //if (cmbStatus != null)
            //    cmbStatus.SelectedIndexChanged += (s, e) => RefreshCardList();
        }
        //private void US_UsersSettings_Load(object sender, EventArgs e)
        //{
        //    if (cmbStatus != null && cmbStatus.Items.Count > 0)
        //        cmbStatus.SelectedIndex = 0;
        //    RefreshCardList();

        //    if (cmbZone != null && cmbZone.Items.Count > 0)
        //        cmbZone.SelectedIndex = 0;
        //    RefreshCardList();
        //}
        //private void RefreshCardList()
        //{
        //    if (this.InvokeRequired)
        //    {
        //        this.Invoke(new Action(RefreshCardList));
        //        return;
        //    }
        //    flpUserAlerts.Controls.Clear();
        //    flpUserAlerts.SuspendLayout();

        //    string statusFilter = cmbStatus.SelectedItem?.ToString() ?? cmbStatus.Text;
        //    if(statusFilter == "상태" || string.IsNullOrWhiteSpace(statusFilter))
        //        statusFilter = "전체";
        //    string zoneFilter = cmbZone.SelectedItem?.ToString() ?? cmbZone.Text;
        //    if (zoneFilter == "구역" || string.IsNullOrWhiteSpace(zoneFilter))
        //        zoneFilter = "전체";

        //    var filteredList = DataManager.AllAlerts.Where(d =>
        //    (statusFilter == "전체" || d.Status == statusFilter) &&
        //    (zoneFilter == "전체" || d.Location.Contains(zoneFilter))
        //    ).ToList();


        //    foreach (var data in filteredList)
        //    {
        //        var card = new US_AlertCard();
        //        card.SetData(data.Type, data.Time, data.Location, data.ID, data.Status, data.Img, true);
        //        card.HideResolveButton();

        //        card.Width = flpUserAlerts.Width - 35;
        //        flpUserAlerts.Controls.Add(card);
        //    }
        //    flpUserAlerts.ResumeLayout();
        //}
        //protected override void OnVisibleChanged(EventArgs e)
        //{
        //    base.OnVisibleChanged(e);
        //    if (this.Visible)
        //    {
        //        RefreshCardList();
        //    }
        //}
    }
}
