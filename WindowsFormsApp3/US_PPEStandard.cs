using Google.Protobuf.WellKnownTypes;
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
        private List<ZoneItem> zones = new List<ZoneItem>();

        public US_PPEStandard()
        {
            InitializeComponent();
        }

        private async Task LoadPPE_ZoneList() // PPE 구역 리스트 로드
        {
            try
            {
                lstPPE_ZoneList.Items.Clear();

                zones = await ApiService.GetPPEZoneListAsync();

                if (zones == null)
                    return;

                foreach (var zone in zones)
                {
                    lstPPE_ZoneList.Items.Add(zone.ZoneName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void US_PPEStandard_Load(object sender, EventArgs e)
        {
            await LoadPPE_ZoneList();
        }

        private async void lstPPE_ZoneList_SelectedIndexChanged(object sender, EventArgs e) // 리스트에서 선택된 구역의 PPE 기준을 UI에 반영
        {
            if (lstPPE_ZoneList.SelectedIndex < 0)
                return;

            try
            {
                int zoneId = zones[lstPPE_ZoneList.SelectedIndex].ZoneID;

                var results = await ApiService.GetPpeSettingAsync();

                var result = results.FirstOrDefault(x => x.ZoneID == zoneId);

                ResetPPECheckBox();

                if (result == null)
                    return;

                List<string> requiredPPE = result.RequiredPPE ?? new List<string>();

                if (requiredPPE.Contains("안전모"))
    chkSafetyHelmet.Checked = true;

if (requiredPPE.Contains("장갑"))
    chkSafetyGloves.Checked = true;

if (requiredPPE.Contains("마스크"))
    chkSafetyMask.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResetPPECheckBox()
        {
            chkSafetyHelmet.Checked = false;
            chkSafetyGloves.Checked = false;
            chkSafetyMask.Checked = false;
        }

        private void btnPPEReset_Click(object sender, EventArgs e)
        {
            ResetPPECheckBox();
        }

        private async void btnPPESave_Click(object sender, EventArgs e)
        {
            if (lstPPE_ZoneList.SelectedIndex < 0)
            {
                MessageBox.Show("구역을 선택해주세요.");
                return;
            }

            try
            {
                int zoneId = zones[lstPPE_ZoneList.SelectedIndex].ZoneID;

                List<string> ppeList = new List<string>();

                if (chkSafetyHelmet.Checked)
                    ppeList.Add("안전모");

                if (chkSafetyGloves.Checked)
                    ppeList.Add("장갑");

                if (chkSafetyMask.Checked)
                    ppeList.Add("마스크");

                PpeSettingRequest request = new PpeSettingRequest
                {
                    ZoneID = zoneId,
                    RequiredPPE = ppeList
                };

                bool success =
                    await ApiService.SavePpeSettingAsync(request);

                if (success)
                {
                    MessageBox.Show("저장 성공");

                    await LoadPPE_ZoneList();
                }
                else
                {
                    MessageBox.Show("저장 실패");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
