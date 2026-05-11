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
    public partial class US_PPEStandard : UserControl
    {
        public US_PPEStandard()
        {
            InitializeComponent();

            this.Load += US_PPEStandard_Load;
        }

        private async Task LoadZoneList_PPE()
        {
            try
            {
                var zones = await ApiService.GetZonesAsync();

                if (zones == null) return;

                cmbZoneList.SelectedIndex = -1;

                cmbZoneList.DataSource = null;

                cmbZoneList.Items.Clear();

                cmbZoneList.DataSource =
                    zones
                    .Where(z => z.is_active)
                    .ToList();

                cmbZoneList.DisplayMember = "name";

                cmbZoneList.ValueMember = "id";

                if (cmbZoneList.Items.Count > 0)
                {
                    cmbZoneList.SelectedIndex = 0;
                }

                cmbZoneList.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"구역 목록 로드 실패: {ex.Message}");
            }
        }

        private async void US_PPEStandard_Load(object sender, EventArgs e)
        {
            await LoadZoneList_PPE();
        }
    }
}
