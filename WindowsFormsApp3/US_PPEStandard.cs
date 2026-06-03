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
        private const string PPE_HELMET = "안전모";
        private const string PPE_MASK = "마스크";
        private const string PPE_LEFT_GLOVE = "왼손 장갑";
        private const string PPE_RIGHT_GLOVE = "오른손 장갑";
        private const string PPE_LEGACY_GLOVE = "장갑";

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

        /// <summary>페이지 재진입 시 외부(설정 폼)에서 호출하는 새로고침.</summary>
        public async Task RefreshPageAsync()
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

                chkSafetyHelmet.Checked = requiredPPE.Contains(PPE_HELMET);
                chkSafetyMask.Checked = requiredPPE.Contains(PPE_MASK);

                // 기존 "장갑" 단일 값이 남아 있어도 좌/우 장갑을 모두 체크 처리한다.
                chkLeftGlove.Checked = requiredPPE.Contains(PPE_LEFT_GLOVE) || requiredPPE.Contains(PPE_LEGACY_GLOVE);
                chkRightGlove.Checked = requiredPPE.Contains(PPE_RIGHT_GLOVE) || requiredPPE.Contains(PPE_LEGACY_GLOVE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResetPPECheckBox()
        {
            // 신규 구역 기본값과 동일하게 전체 단속 상태로 초기화
            chkSafetyHelmet.Checked = true;
            chkSafetyMask.Checked = true;
            chkLeftGlove.Checked = true;
            chkRightGlove.Checked = true;
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
                if (chkSafetyHelmet.Checked) ppeList.Add(PPE_HELMET);
                if (chkSafetyMask.Checked) ppeList.Add(PPE_MASK);
                if (chkLeftGlove.Checked) ppeList.Add(PPE_LEFT_GLOVE);
                if (chkRightGlove.Checked) ppeList.Add(PPE_RIGHT_GLOVE);

                List<PPESetting> currentAllSettings = await ApiService.GetPpeSettingAsync();

                var targetSetting = currentAllSettings.FirstOrDefault(x => x.ZoneID == zoneId);

                if (targetSetting != null)
                {
                    targetSetting.RequiredPPE = ppeList;
                }
                else
                {
                    currentAllSettings.Add(new PPESetting
                    {
                        ZoneID = zoneId,
                        ZoneName = zones[lstPPE_ZoneList.SelectedIndex].ZoneName,
                        RequiredPPE = ppeList
                    });
                }

                List<PpeSettingRequest> requestsToSend = currentAllSettings.Select(x => new PpeSettingRequest
                {
                    ZoneID = x.ZoneID,
                    RequiredPPE = x.RequiredPPE
                }).ToList();

                bool success = await ApiService.SavePpeSettingAsync(requestsToSend);

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