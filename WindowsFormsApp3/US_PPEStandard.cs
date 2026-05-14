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
        private List<ZoneData> zonelist = new List<ZoneData>();
        private int selectedZoneId = -1;

        public US_PPEStandard()
        {
            InitializeComponent();

            this.Load += US_PPEStandard_Load;
        }

        private async Task LoadPPE_ZoneList() // PPE 기준 설정에서 구역 목록을 불러와 리스트에 표시
        {
            try
            {
                zonelist = await ApiService.GetZonesAsync();
                lstPPE_ZoneList.Items.Clear();

                foreach (var zone in zonelist)
                {
                    lstPPE_ZoneList.Items.Add($"{zone.name}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"목록 로드 실패: {ex.Message}");
            }
        }

        private async void US_PPEStandard_Load(object sender, EventArgs e)
        {
            await LoadPPE_ZoneList();
        }

        private void lstPPE_ZoneList_SelectedIndexChanged(object sender, EventArgs e) // 리스트에서 선택된 구역의 PPE 기준을 UI에 반영
        {
            if (lstPPE_ZoneList.SelectedIndex == -1) return;

            var selectedZone = zonelist[lstPPE_ZoneList.SelectedIndex];
            selectedZoneId = selectedZone.id;

            chkSafetyHelmet.Checked = selectedZone.is_active; // 실제로는 위험도에 따라 체크 여부를 결정해야 하지만, 현재는 is_active로 임시 설정
            chkSafetyGloves.Checked = selectedZone.is_active;
            chkSafetyMask.Checked = selectedZone.is_active;
        }
    }
}
