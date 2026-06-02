using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPE_관제_시스템
{
    public partial class US_ViolationManagementForm : UserControl
    {
        private List<AlterDataClass> localViolations = new List<AlterDataClass>();
        private List<ViolationGroup> groups = new List<ViolationGroup>();
        private List<US_AlertCard> alertCards = new List<US_AlertCard>();
        private int currentPage = 0;
        private int pageSize = 10;

        private readonly Dictionary<string, Image> _imageCache = new Dictionary<string, Image>();
        private readonly Dictionary<string, string> _zoneNameToId = new Dictionary<string, string>();

        private const int CardHeight = 250;

        // ===== MainForm 헤더 연동 =====
        // 통계 문자열(예: "총 772건 · 해결 1 · 미해결 771")이 갱신될 때 발생
        public event Action<string> StatsChanged;
        public string CurrentStatsText { get; private set; } = "총 0건 · 해결 0 · 미해결 0";
        private bool _isRefreshing = false;

        // 조회 결과가 없을 때 표시하는 안내 라벨
        private Label lblEmptyState;

        public US_ViolationManagementForm()
        {
            InitializeComponent();
            ApplyRoundedTheme();
            BuildEmptyState();
            DataManager.OnDataChanged += RefreshCardList;

            // 반응형: 리스트 폭이 바뀌면 카드 폭도 따라가게
            flpViolationList.SizeChanged += (s, e) => { ResizeCardsToFit(); CenterEmptyState(); };
        }

        private void BuildEmptyState()
        {
            lblEmptyState = new Label
            {
                Text = "위반 데이터가 존재하지 않습니다",
                Font = new Font("맑은 고딕", 13F, FontStyle.Regular),
                ForeColor = AppColors.TextMuted,
                BackColor = AppColors.Surface,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(360, 40),
                Visible = false
            };
            pnlViolationMain.Controls.Add(lblEmptyState);
            lblEmptyState.BringToFront();
            CenterEmptyState();
        }

        private void CenterEmptyState()
        {
            if (lblEmptyState == null) return;
            lblEmptyState.Location = new Point(
                (pnlViolationMain.ClientSize.Width - lblEmptyState.Width) / 2,
                (pnlViolationMain.ClientSize.Height - lblEmptyState.Height) / 2);
        }

        private void ResizeCardsToFit()
        {
            if (alertCards == null || alertCards.Count == 0) return;
            int w = flpViolationList.ClientSize.Width - 28;
            if (w < 200) return;
            flpViolationList.SuspendLayout();
            foreach (var card in alertCards)
            {
                if (!card.IsDisposed) card.Width = w;
            }
            flpViolationList.ResumeLayout();
        }

        /// <summary>MainForm 의 새로고침 아이콘이 호출하는 수동 새로고침.</summary>
        public async Task ManualRefreshAsync()
        {
            if (_isRefreshing) return;
            _isRefreshing = true;
            try { await LoadViolationData(); }
            finally { _isRefreshing = false; }
        }

        // ===== 디자인: 흰색 기조 + 둥근 카드 =====
        private void ApplyRoundedTheme()
        {
            this.BackColor = AppColors.Surface;   // 회색→흰색

            pnlFilterBar.BackColor = Color.Transparent;
            WrapWithRounded(pnlFilterBar, AppColors.Surface, 14, shadow: true, border: false);

            pnlViolationMain.BorderStyle = BorderStyle.None;
            pnlViolationMain.BackColor = Color.Transparent;
            WrapWithRounded(pnlViolationMain, AppColors.Surface, 16, shadow: true, border: false);

            flpViolationList.BackColor = AppColors.Surface;
            flpViolationList.BorderStyle = BorderStyle.None;
            // 카드가 한 줄에 하나씩 세로로 쌓이고, 가로 스크롤이 안 생기게
            flpViolationList.FlowDirection = FlowDirection.TopDown;
            flpViolationList.WrapContents = false;
            flpViolationList.AutoScroll = true;
            pnlViolationMain.Resize += (s, e) => CenterEmptyState();

            pnlFooter.BackColor = Color.Transparent;
            lnkPrev.LinkColor = AppColors.PrimaryDark;
            lnkNext.LinkColor = AppColors.PrimaryDark;
            lblPage.ForeColor = AppColors.Text;

            // "기간" → "검색"
            lblFilterDate.Text = "검색";

            LayoutFilterBar();
            pnlFilterBar.Resize += (s, e) => LayoutFilterBar();
        }

        private void LayoutFilterBar()
        {
            int barW = pnlFilterBar.Width;
            int topY = 14;

            lblFilterDate.Location = new Point(18, topY + 4);
            dtpDateStart.Width = 200;
            dtpDateStart.Location = new Point(70, topY);
            lblTilde.Location = new Point(dtpDateStart.Right + 8, topY + 4);
            dtpDateEnd.Width = 200;
            dtpDateEnd.Location = new Point(lblTilde.Right + 8, topY);

            int dropW = 130, gap = 12, rightPad = 20;
            cmbZone.Width = dropW;
            cmbZone.Location = new Point(barW - rightPad - dropW, topY);
            cmbState.Width = dropW;
            cmbState.Location = new Point(cmbZone.Left - gap - dropW, topY);
            cmbTime.Width = dropW;
            cmbTime.Location = new Point(cmbState.Left - gap - dropW, topY);
        }

        private void WrapWithRounded(Panel target, Color fill, int radius, bool shadow, bool border)
        {
            var bg = new RoundedPanel
            {
                FillColor = fill,
                CornerRadius = radius,
                HasShadow = shadow,
                BorderColorCustom = border ? AppColors.Border : Color.Empty,
                BorderThickness = border ? 1 : 0,
                OuterBackColor = AppColors.Surface,
                Location = target.Location,
                Size = target.Size,
                Anchor = target.Anchor,
                Padding = new Padding(0)
            };
            var parent = target.Parent;
            parent.Controls.Add(bg);
            bg.SendToBack();
            target.BringToFront();

            // 원본 패널 크기/위치가 바뀌면(반응형) 배경도 따라가게 동기화
            target.SizeChanged += (s, e) => { bg.Size = target.Size; bg.Location = target.Location; };
            target.LocationChanged += (s, e) => { bg.Location = target.Location; };
        }

        private async void US_ViolationManagementForm_Load(object sender, EventArgs e)
        {
            SetFilterItems();
            await LoadZonesAsync();

            dtpDateStart.Value = DateTime.Now.AddDays(-7).Date;
            dtpDateEnd.Value = DateTime.Now.Date;

            cmbState.SelectedIndexChanged += async (s, ev) => { currentPage = 0; await LoadViolationData(); };
            cmbZone.SelectedIndexChanged += async (s, ev) => { currentPage = 0; await LoadViolationData(); };
            cmbTime.SelectedIndexChanged += (s, ev) => { currentPage = 0; RefreshCardList(); };
            dtpDateStart.ValueChanged += async (s, ev) => { currentPage = 0; await LoadViolationData(); };
            dtpDateEnd.ValueChanged += async (s, ev) => { currentPage = 0; await LoadViolationData(); };

            LayoutFilterBar();
            await LoadViolationData();
        }

        private void SetFilterItems()
        {
            cmbState.Items.Clear();
            cmbState.Items.AddRange(new object[] { "상태 전체", "미해결", "해결" });
            cmbState.SelectedIndex = 0;

            cmbTime.Items.Clear();
            cmbTime.Items.Add("시간대 전체");
            for (int i = 0; i < 24; i++)
            {
                string startTime = $"{i:D2}:00";
                string endTime = $"{(i + 1):D2}:00";
                if (i == 23) endTime = "00:00";
                cmbTime.Items.Add($"{startTime} - {endTime}");
            }
            cmbTime.SelectedIndex = 0;
        }

        private async Task LoadZonesAsync()
        {
            try
            {
                cmbZone.Items.Clear();
                _zoneNameToId.Clear();
                cmbZone.Items.Add("구역 전체");

                var zones = await ApiService.GetZonesAsync(includeInactive: true) ?? new List<ZoneData>();
                foreach (var z in zones.Where(z => z != null && !string.IsNullOrWhiteSpace(z.name)))
                {
                    if (!_zoneNameToId.ContainsKey(z.name))
                    {
                        cmbZone.Items.Add(z.name);
                        _zoneNameToId[z.name] = z.id.ToString();
                    }
                }
                cmbZone.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"구역 목록 로드 실패: {ex.Message}");
                if (cmbZone.Items.Count == 0) cmbZone.Items.Add("구역 전체");
                cmbZone.SelectedIndex = 0;
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible) RefreshCardList();
        }

        private void RefreshCardList()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(RefreshCardList));
                return;
            }
            flpViolationList.SuspendLayout();

            for (int i = flpViolationList.Controls.Count - 1; i >= 0; i--)
            {
                var ctrl = flpViolationList.Controls[i];
                flpViolationList.Controls.Remove(ctrl);
                ctrl.Dispose();
            }

            alertCards.Clear();

            var filteredRows = GetFilteredRows();
            groups = ViolationGroup.BuildGroups(filteredRows);

            int totalPages = (int)Math.Ceiling((double)groups.Count / pageSize);
            if (totalPages == 0) totalPages = 1;
            if (currentPage >= totalPages) currentPage = totalPages - 1;
            if (currentPage < 0) currentPage = 0;

            var pageData = groups.Skip(currentPage * pageSize).Take(pageSize).ToList();

            foreach (var data in pageData)
            {
                var card = new US_AlertCard();

                card.Width = flpViolationList.ClientSize.Width - 28;
                card.Height = CardHeight;
                card.OuterBackColor = flpViolationList.BackColor;

                Image cached = null;
                string repId = data.RepresentativeId;
                if (!string.IsNullOrEmpty(repId)) _imageCache.TryGetValue(repId, out cached);
                data.Image = cached;

                card.SetGroup(data, cached);

                card.OnResolveRequested -= HandleResolveRequested;
                card.OnResolveRequested += HandleResolveRequested;

                card.OnDetailRequested -= HandleDetailRequested;
                card.OnDetailRequested += HandleDetailRequested;

                card.OnDeleteRequested -= HandleDeleteRequested;
                card.OnDeleteRequested += HandleDeleteRequested;

                flpViolationList.Controls.Add(card);
                alertCards.Add(card);

                if (cached == null && !string.IsNullOrEmpty(repId))
                {
                    var capturedCard = card;
                    var capturedGroup = data;
                    _ = Task.Run(async () =>
                    {
                        Image downloadImg = await ApiService.GetViolationImageAsync(repId);
                        if (downloadImg != null && capturedCard != null && !capturedCard.IsDisposed)
                        {
                            this.BeginInvoke(new Action(() =>
                            {
                                if (!_imageCache.ContainsKey(repId)) _imageCache[repId] = downloadImg;
                                capturedGroup.Image = downloadImg;
                                if (!capturedCard.IsDisposed)
                                    capturedCard.SetGroup(capturedGroup, downloadImg);
                            }));
                        }
                    });
                }
            }
            flpViolationList.ResumeLayout();

            // 조회 결과 없으면 안내 문구 표시
            if (lblEmptyState != null)
            {
                bool isEmpty = (groups.Count == 0);
                lblEmptyState.Visible = isEmpty;
                if (isEmpty)
                {
                    CenterEmptyState();
                    lblEmptyState.BringToFront();
                }
            }

            lblPage.Text = $"{currentPage + 1} / {totalPages}";
            lnkPrev.Enabled = (currentPage > 0);
            lnkNext.Enabled = (currentPage + 1 < totalPages);

            UpdateStats();
        }

        private void UpdateStats()
        {
            int total = groups.Count;
            int resolved = groups.Count(g => g.IsChecked);
            int unresolved = total - resolved;
            CurrentStatsText = $"총 {total}건 · 해결 {resolved} · 미해결 {unresolved}";
            StatsChanged?.Invoke(CurrentStatsText);
        }

        private async Task LoadViolationData()
        {
            try
            {
                string startDate = dtpDateStart.Value.ToString("yyyy-MM-dd");
                string endDate = dtpDateEnd.Value.ToString("yyyy-MM-dd");

                string statusSel = cmbState.SelectedItem?.ToString() ?? "상태 전체";
                if (statusSel == "상태 전체") statusSel = null;

                string zoneSel = cmbZone.SelectedItem?.ToString() ?? "구역 전체";
                string areaId = null;
                if (zoneSel != "구역 전체" && _zoneNameToId.TryGetValue(zoneSel, out string mappedId))
                    areaId = mappedId;

                var violations = await ApiService.GetViolationsAsync(
                    startDate: startDate, endDate: endDate,
                    areaId: areaId, violationType: null, status: statusSel);

                if (violations != null)
                {
                    localViolations = violations;
                    RefreshCardList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("데이터 로드 실패: " + ex.Message);
            }
        }

        private List<AlterDataClass> GetFilteredRows()
        {
            string selectedTime = cmbTime.SelectedItem?.ToString().Trim() ?? "시간대 전체";

            return localViolations.Where(data =>
            {
                if (selectedTime != "시간대 전체")
                {
                    if (!string.IsNullOrEmpty(data.Time) && DateTime.TryParse(data.Time, out DateTime recordTime))
                    {
                        int filterHour = int.Parse(selectedTime.Substring(0, 2));
                        if (recordTime.Hour != filterHour) return false;
                    }
                    else return false;
                }
                return true;
            }).ToList();
        }

        // ===== 액션 =====

        private async void HandleResolveRequested(US_AlertCard card)
        {
            var group = card?.Group;
            if (group == null || group.Ids.Count == 0) return;

            bool makeResolved = !group.IsChecked;
            card.SetActionsEnabled(false);

            bool allOk = true;
            foreach (var id in group.Ids)
            {
                bool ok = await ApiService.UpdateViolationCheckedAsync(id, makeResolved);
                if (!ok) allOk = false;
            }
            

            if (allOk)
            {
                foreach (var row in localViolations.Where(r => group.Ids.Contains(r.Id)))
                {
                    //row.IsChecked = makeResolved ? 1 : 0;
                    row.Status = makeResolved ? "해결" : "미해결";
                }
                await LoadViolationData();
            }
            else
            {
                MessageBox.Show("일부 항목의 상태 변경에 실패했습니다. 새로고침 후 다시 시도해주세요.");
                await LoadViolationData();
            }
        }

        private async void HandleDetailRequested(US_AlertCard card)
        {
            var group = card?.Group;
            if (group == null) return;

            Image img = group.Image;
            string repId = group.RepresentativeId;
            if (img == null && !string.IsNullOrEmpty(repId))
            {
                _imageCache.TryGetValue(repId, out img);
                if (img == null)
                {
                    img = await ApiService.GetViolationImageAsync(repId);
                    if (img != null) _imageCache[repId] = img;
                }
            }

            DialogResult result;
            using (var dlg = new ViolationDetailForm(group, img))
            {
                result = dlg.ShowDialog(this.FindForm());
            }

            // 팝업에서 삭제 확정(Yes) → 그룹 전체 삭제 후 새로고침
            if (result == DialogResult.Yes)
            {
                bool allOk = true;
                foreach (var id in group.Ids)
                {
                    bool ok = await ApiService.DeleteViolationAsync(id);
                    if (!ok) allOk = false;
                }

                if (allOk)
                {
                    localViolations.RemoveAll(r => group.Ids.Contains(r.Id));
                    if (!string.IsNullOrEmpty(repId)) _imageCache.Remove(repId);
                }
                else
                {
                    MessageBox.Show("일부 항목 삭제에 실패했습니다. 목록을 새로고침합니다.");
                }
                await LoadViolationData();   // 서버 기준 새로고침
            }
        }

        private void lnkPrev_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
                RefreshCardList();
            }
        }

        private void lnkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)groups.Count / pageSize);
            if ((currentPage + 1) < totalPages)
            {
                currentPage++;
                RefreshCardList();
            }
        }

        private async void HandleDeleteRequested(US_AlertCard card)
        {
            var group = card?.Group;
            if (group == null || group.Ids.Count == 0) return;
            var confirm = MessageBox.Show("선택한 위반 이력을 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;
            bool allOk = true;
            foreach (var id in group.Ids)
            {
                bool ok = await ApiService.DeleteViolationAsync(id);
                if (!ok) allOk = false;
            }
            if (allOk)
            {
                localViolations.RemoveAll(r => group.Ids.Contains(r.Id));
                RefreshCardList();
            }
            else
            {
                MessageBox.Show("일부 항목의 삭제에 실패했습니다. 새로고침 후 다시 시도해주세요.");
                await LoadViolationData();
            }
        }
    }
}