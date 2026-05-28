using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPE_관제_시스템
{
    public partial class US_ZoneSetting : UserControl
    {
        private List<ZoneData> zones = new List<ZoneData>();
        private List<CameraData> allCameras = new List<CameraData>();
        private int selectedZoneId = -1;
        private CameraData selectedCamera = null;

        public US_ZoneSetting()
        {
            InitializeComponent();
        }

        private async void US_ZoneSetting_Load(object sender, EventArgs e)
        {
            await RefreshAllAsync();
        }

        // 카메라 + 구역 정보 모두 새로 불러옴
        private async Task RefreshAllAsync()
        {
            await LoadCamerasAsync();
            await LoadZonesAsync();
            RefreshLists();
        }

        private async Task LoadCamerasAsync()
        {
            try
            {
                var response = await ApiService.GetStreamUrlsAsync();

                if (response == null)
                {
                    lblJetsonStatus.Text = "Jetson: API 호출 실패";
                    lblJetsonStatus.ForeColor = Color.Red;
                    allCameras.Clear();
                }
                else
                {
                    allCameras = response.cameras ?? new List<CameraData>();

                    lblJetsonStatus.Text = $"Jetson: 온라인 ({allCameras.Count}대)";
                    lblJetsonStatus.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                lblJetsonStatus.Text = "Jetson: 오류";
                lblJetsonStatus.ForeColor = Color.Red;
                allCameras.Clear();

                Console.WriteLine($"카메라 목록 로드 실패: {ex.Message}");
            }
        }

        private async Task LoadZonesAsync()
        {
            try
            {
                zones = await ApiService.GetZonesAsync(includeInactive: true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"구역 목록 로드 실패: {ex.Message}");
                zones = new List<ZoneData>();
            }
        }

        // 두 리스트박스 동시 갱신
        private void RefreshLists()
        {
            /*
             * 중요:
             * 비활성 구역도 삭제된 것이 아니므로 카메라 점유 상태로 처리한다.
             * 따라서 z.is_active 조건을 넣으면 안 된다.
             */
            var usedCameraTokens = new HashSet<string>(
                zones.Where(z => !string.IsNullOrEmpty(z.camera_key))
                    .Select(z => $"{z.camera_key}|{z.camera_name}")
            );

            var usedCameraKeys = new HashSet<string>(
                zones.Where(z => !string.IsNullOrEmpty(z.camera_key))
                    .Select(z => z.camera_key)
            );

            lstAvailableCameras.Items.Clear();

            foreach (var cam in allCameras)
            {
                string camToken = $"{cam.key}|{cam.name}";

                bool inUse =
                    cam.area != null ||
                    usedCameraTokens.Contains(camToken) ||
                    usedCameraKeys.Contains(cam.key);

                if (!inUse)
                {
                    lstAvailableCameras.Items.Add(cam);
                }
            }

            if (lstAvailableCameras.Items.Count == 0)
            {
                lstAvailableCameras.Items.Add("(연결 가능한 카메라 없음)");
                lstAvailableCameras.Enabled = false;
            }
            else
            {
                lstAvailableCameras.Enabled = true;
            }

            lstZones.Items.Clear();

            foreach (var zone in zones)
            {
                string camInfo = !string.IsNullOrEmpty(zone.camera_name)
                    ? $" [{zone.camera_name}]"
                    : "";

                string status = zone.is_active ? "" : " (비활성)";

                lstZones.Items.Add($"{zone.name}{camInfo} · 위험도 {zone.risk_level}{status}");
            }
        }

        private void lstAvailableCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            // CameraData가 아니라 "연결 가능한 카메라 없음" 문자열이면 무시
            if (!(lstAvailableCameras.SelectedItem is CameraData camera)) return;

            selectedCamera = camera;
            lblSelectedCamera.Text = camera.name;
            lblSelectedCamera.ForeColor = Color.DarkBlue;

            // 구역 선택 해제 - 새로 추가 모드
            selectedZoneId = -1;
            lstZones.SelectedIndex = -1;

            // 폼 초기화
            txtZoneName.Text = "";
            txtZoneDescription.Text = "";
            cmbZoneRiskLevel.SelectedIndex = -1;
            cmbZoneRiskLevel.Text = "선택";
            chkUseZone.Checked = true; // 새 구역은 기본 활성화
        }

        private void lstZones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstZones.SelectedIndex == -1) return;

            var zone = zones[lstZones.SelectedIndex];
            selectedZoneId = zone.id;

            txtZoneName.Text = zone.name;
            txtZoneDescription.Text = zone.description;
            cmbZoneRiskLevel.SelectedItem = zone.risk_level;
            chkUseZone.Checked = zone.is_active;

            selectedCamera = allCameras.FirstOrDefault(c =>
                c.key == zone.camera_key && c.name == zone.camera_name);

            if (selectedCamera == null)
            {
                selectedCamera = allCameras.FirstOrDefault(c => c.key == zone.camera_key);
            }

            if (selectedCamera != null)
            {
                lblSelectedCamera.Text = selectedCamera.name;
                lblSelectedCamera.ForeColor = Color.DarkBlue;
            }
            else if (!string.IsNullOrEmpty(zone.camera_name))
            {
                lblSelectedCamera.Text = $"{zone.camera_name} (오프라인)";
                lblSelectedCamera.ForeColor = Color.OrangeRed;
            }
            else
            {
                lblSelectedCamera.Text = "(없음)";
                lblSelectedCamera.ForeColor = Color.Gray;
            }

            lstAvailableCameras.SelectedIndex = -1;
        }

        private ZoneData GetZoneDataFromUI()
        {
            ZoneData originalZone = null;

            if (selectedZoneId != -1)
            {
                originalZone = zones.FirstOrDefault(z => z.id == selectedZoneId);
            }

            return new ZoneData
            {
                name = txtZoneName.Text.Trim(),
                description = txtZoneDescription.Text.Trim(),
                risk_level = cmbZoneRiskLevel.SelectedItem?.ToString() ?? "낮음",
                is_active = chkUseZone.Checked,

                // 새 카메라를 선택하지 않았다면 기존 연결 유지
                camera_key = selectedCamera?.key ?? originalZone?.camera_key,
                camera_name = selectedCamera?.name ?? originalZone?.camera_name
            };
        }

        private async void btnZoneAdd_Click(object sender, EventArgs e)
        {
            if (selectedCamera == null)
            {
                MessageBox.Show("좌측에서 연결할 카메라를 먼저 선택해주세요.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtZoneName.Text))
            {
                MessageBox.Show("구역명을 입력해주세요.");
                return;
            }

            if (cmbZoneRiskLevel.SelectedIndex == -1)
            {
                MessageBox.Show("위험도를 선택해주세요.");
                return;
            }

            // 기존 구역 선택 상태에서 "추가" 누른 경우 → 새 구역 의도이므로 차단
            if (selectedZoneId != -1)
            {
                MessageBox.Show("기존 구역이 선택된 상태입니다. 새 구역 추가는 좌측에서 카메라를 다시 선택해주세요.");
                return;
            }

            var newZone = GetZoneDataFromUI();
            bool success = await ApiService.AddZoneAsync(newZone);

            if (success)
            {
                MessageBox.Show($"'{newZone.name}' 구역이 추가되었습니다.");
                ResetForm();
                await RefreshAllAsync();
            }
            else
            {
                MessageBox.Show("구역 추가에 실패했습니다.");
            }
        }

        private async void btnZoneModify_Click(object sender, EventArgs e)
        {
            if (selectedZoneId == -1)
            {
                MessageBox.Show("수정할 구역을 리스트에서 선택해주세요.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtZoneName.Text))
            {
                MessageBox.Show("구역명을 입력해주세요.");
                return;
            }

            if (cmbZoneRiskLevel.SelectedIndex == -1)
            {
                MessageBox.Show("위험도를 선택해주세요.");
                return;
            }

            var updatedZone = GetZoneDataFromUI();

            bool success = await ApiService.UpdateZoneAsync(selectedZoneId, updatedZone);

            if (success)
            {
                MessageBox.Show("구역 정보가 수정되었습니다.");
                ResetForm();
                await RefreshAllAsync();
            }
            else
            {
                MessageBox.Show("구역 수정에 실패했습니다.");
            }
        }

        private async void btnZoneDelete_Click(object sender, EventArgs e)
        {
            if (selectedZoneId == -1)
            {
                MessageBox.Show("삭제할 구역을 선택해주세요.");
                return;
            }

            var selectedZone = zones.FirstOrDefault(z => z.id == selectedZoneId);
            string zoneName = selectedZone?.name ?? "선택한 구역";

            var result = MessageBox.Show(
                $"'{zoneName}' 구역을 영구 삭제합니다.\n\n삭제하면 연결된 카메라는 다시 연결 가능 목록에 표시됩니다.\n정말 삭제하시겠습니까?",
                "구역 영구 삭제 확인",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes) return;

            btnZoneDelete.Enabled = false;

            bool success = await ApiService.DeleteZoneAsync(selectedZoneId, hard: true);

            btnZoneDelete.Enabled = true;

            if (success)
            {
                MessageBox.Show("구역이 삭제되었습니다.");

                ResetForm();

                await Task.Delay(200);
                await RefreshAllAsync();
            }
            else
            {
                MessageBox.Show("구역 삭제에 실패했습니다. 서버 로그 또는 콘솔 출력을 확인해주세요.");
            }
        }

        private async void btnRefreshCameras_Click(object sender, EventArgs e)
        {
            btnRefreshCameras.Enabled = false;
            await RefreshAllAsync();
            btnRefreshCameras.Enabled = true;
        }

        private void ResetForm()
        {
            selectedZoneId = -1;
            selectedCamera = null;
            lblSelectedCamera.Text = "(선택 안 됨)";
            lblSelectedCamera.ForeColor = Color.Gray;
            txtZoneName.Text = "";
            txtZoneDescription.Text = "";
            cmbZoneRiskLevel.SelectedIndex = -1;
            cmbZoneRiskLevel.Text = "선택";
            chkUseZone.Checked = false;
            lstZones.SelectedIndex = -1;
            lstAvailableCameras.SelectedIndex = -1;
        }
    }
}