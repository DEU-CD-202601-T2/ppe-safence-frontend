using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PPE_관제_시스템
{
    public partial class US_ZoneSetting : UserControl
    {
        private List<ZoneData> zones = new List<ZoneData>();
        private int selectedZoneId = -1;

        public US_ZoneSetting()
        {
            InitializeComponent();
            this.Load += async (s, e) => await LoadZonesList();
        }

        private ZoneData GetZoneDataFromUI()
        {
            return new ZoneData
            {
                name = txtZoneName.Text,
                description = txtZoneDescription.Text,
                risk_level = cmbZoneRiskLevel.SelectedItem?.ToString() ?? "낮음",
                is_active = chkUseZone.Checked
            };
        }

        private async Task LoadZonesList()
        {
            try
            {
                zones = await ApiService.GetZonesAsync();
                lstZones.Items.Clear();

                foreach (var zone in zones)
                {
                    string activeStatus = zone.is_active ? "" : " (비활성)";
                    lstZones.Items.Add($"{zone.name} | 위험도 {zone.risk_level}{activeStatus}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"목록 로드 실패: {ex.Message}");
            }
        }

        private void lstZones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstZones.SelectedIndex == -1) return;

            var selectedZone = zones[lstZones.SelectedIndex];
            selectedZoneId = selectedZone.id;

            txtZoneName.Text = selectedZone.name;
            txtZoneDescription.Text = selectedZone.description;
            cmbZoneRiskLevel.SelectedItem = selectedZone.risk_level;
            chkUseZone.Checked = selectedZone.is_active;
        }

        private async void btnZoneAdd_Click(object sender, EventArgs e)
        {
            var newZone = GetZoneDataFromUI();

            bool success = await ApiService.AddZoneAsync(newZone);

            if (success)
            {
                MessageBox.Show("새로운 구역이 성공적으로 추가되었습니다.");
                await LoadZonesList();
            }
            else
            {
                MessageBox.Show("구역 추가에 실패했습니다.");
            }

            await LoadZonesList();
        }

        private async void btnZoneModify_Click(object sender, EventArgs e)
        {
            if (selectedZoneId == -1)
            {
                MessageBox.Show("수정할 구역을 리스트에서 선택해주세요.");
                return;
            }

            var updatedZone = GetZoneDataFromUI();
            bool success = await ApiService.UpdateZoneAsync(selectedZoneId, updatedZone);

            if (success)
            {
                MessageBox.Show("구역 정보가 수정되었습니다.");
                await LoadZonesList();
            }
            else
            {
                MessageBox.Show("구역 수정에 실패했습니다.");
            }

            await LoadZonesList();
        }

        private async void btnZoneDelete_Click(object sender, EventArgs e)
        {
            if (selectedZoneId == -1)
            {
                MessageBox.Show("삭제할 구역을 선택해주세요.");
                return;
            }

            if (MessageBox.Show("정말 이 구역을 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool success = await ApiService.DeleteZoneAsync(selectedZoneId);
                if (success)
                {
                    MessageBox.Show("삭제되었습니다.");
                    await LoadZonesList();
                }
            }

            await LoadZonesList();
        }

        private async void US_ZoneSetting_Load(object sender, EventArgs e)
        {
            await LoadZonesList();
        }
    }
}
