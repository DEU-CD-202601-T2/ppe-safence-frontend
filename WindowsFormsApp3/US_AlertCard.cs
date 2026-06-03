using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPE_관제_시스템
{
    public partial class US_AlertCard : UserControl
    {
        public US_AlertCard()
        {
            InitializeComponent();
            EnableSmoothPainting();
            BuildActionButtons();
            StyleExistingControls();
        }

        public event Action<US_AlertCard> OnResolveRequested;
        public event Action<US_AlertCard> OnDetailRequested;
        public event Action<US_AlertCard> OnDeleteRequested;
        public event Action<US_AlertCard> OnAckRequested;
        private RoundedButton btnDelete;
        private RoundedButton btnAck;

        // 카드가 대표하는 그룹
        public ViolationGroup Group { get; private set; }

        public string AlertId => Group?.RepresentativeId;
        public string Zone => Group?.AreaName;
        public string Cam => Group?.CameraName;
        public string WorkerId => Group?.PersonId;
        public string DateText => Group?.DetectedAt;
        public string StatusText => Group?.Status;
        public bool IsResolved => Group != null && Group.IsChecked;
        public Image CurrentImage => picPPEImage?.Image;

        private RoundedButton btnDetail;
        private RoundedButton btnResolveRound;

        private const int CardRadius = 16;
        private const int ShadowDepth = 6;
        private const int StripWidth = 6;
        private Color _stripColor = AppColors.Danger;

        // 장비 칩 데이터 (그리기용)
        private (string label, GearState state)[] _gearChips = new (string, GearState)[0];

        // 제목 마퀴 라벨 (Designer lblViolation 을 대체)
        private MarqueeLabel mqTitle;

        private Color _outerBackColor = AppColors.Surface;
        public Color OuterBackColor
        {
            get => _outerBackColor;
            set { _outerBackColor = value; UpdateChildOuterBg(); Invalidate(); }
        }

        private void EnableSmoothPainting()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);
            this.BorderStyle = BorderStyle.None;
            this.BackColor = AppColors.Surface;
            this.Padding = new Padding(ShadowDepth + StripWidth + 6, ShadowDepth + 4, ShadowDepth + 4, ShadowDepth + 4);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (var bg = new SolidBrush(_outerBackColor))
                g.FillRectangle(bg, 0, 0, Width, Height);

            var cardRect = new Rectangle(
                ShadowDepth, ShadowDepth,
                Width - ShadowDepth * 2 - 1,
                Height - ShadowDepth * 2 - 1);
            if (cardRect.Width <= 0 || cardRect.Height <= 0) return;

            for (int i = ShadowDepth; i > 0; i--)
            {
                int alpha = 8 + (int)(12.0 * (ShadowDepth - i) / ShadowDepth);
                var sRect = new Rectangle(cardRect.Left - i / 2, cardRect.Top + i, cardRect.Width + i, cardRect.Height + i);
                using (var sp = RoundedRect(sRect, CardRadius + i))
                using (var sb = new SolidBrush(Color.FromArgb(alpha, AppColors.Shadow)))
                    g.FillPath(sb, sp);
            }

            using (var path = RoundedRect(cardRect, CardRadius))
            {
                using (var fill = new SolidBrush(AppColors.Surface))
                    g.FillPath(fill, path);

                var clip = g.Clip;
                g.SetClip(path);
                using (var stripBrush = new SolidBrush(_stripColor))
                    g.FillRectangle(stripBrush, cardRect.Left, cardRect.Top, StripWidth, cardRect.Height);
                g.Clip = clip;

                using (var pen = new Pen(AppColors.Surface, 1f))
                    g.DrawPath(pen, path);
            }

            // 장비 칩 그리기 (텍스트 영역 하단)
            DrawGearChips(g);
        }

        private void DrawGearChips(Graphics g)
        {
            if (_gearChips == null || _gearChips.Length == 0) return;

            int textLeft = picPPEImage.Right + 24;
            int chipY = ShadowDepth + 10 + 168;   // 정보 라벨들 아래
            int x = textLeft;
            int chipH = 30;

            using (var font = new Font("맑은 고딕", 9.5F, FontStyle.Bold))
            {
                foreach (var (label, state) in _gearChips)
                {
                    string mark = state == GearState.Worn ? "✓ "
                                : state == GearState.Missing ? "✕ " : "− ";
                    string text = mark + label;
                    Size sz = TextRenderer.MeasureText(text, font);
                    int chipW = sz.Width + 24;

                    var rect = new Rectangle(x, chipY, chipW, chipH);
                    Color back, fore;
                    if (state == GearState.Worn) { back = AppColors.SuccessTint; fore = AppColors.Success; }
                    else if (state == GearState.Missing) { back = AppColors.DangerTint; fore = AppColors.Danger; }
                    else { back = Color.FromArgb(238, 238, 238); fore = Color.FromArgb(140, 140, 140); }

                    using (var path = RoundedRect(rect, chipH / 2))
                    using (var b = new SolidBrush(back))
                        g.FillPath(b, path);

                    TextRenderer.DrawText(g, text, font, rect, fore,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    x += chipW + 8;
                }
            }
        }

        private GraphicsPath RoundedRect(Rectangle rect, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            if (d > rect.Width) d = rect.Width;
            if (d > rect.Height) d = rect.Height;
            path.AddArc(rect.Left, rect.Top, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Top, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.Left, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void StyleExistingControls()
        {
            picPPEImage.BorderStyle = BorderStyle.None;
            picPPEImage.BackColor = AppColors.Surface;
            picPPEImage.SizeMode = PictureBoxSizeMode.Zoom;
            picPPEImage.Cursor = Cursors.Default;

            lblViolation.Visible = false;   // 마퀴로 대체

            if (mqTitle == null)
            {
                mqTitle = new MarqueeLabel
                {
                    Font = lblViolation.Font,
                    ForeColor = AppColors.Danger,
                    BackColor = AppColors.Surface,
                    Size = new Size(300, 34)
                };
                this.Controls.Add(mqTitle);
                mqTitle.BringToFront();
            }
            lblDate.BackColor = AppColors.Surface;
            lblCam.BackColor = AppColors.Surface;
            lblZone.BackColor = AppColors.Surface;
            lblTargetID.BackColor = AppColors.Surface;
            lblStatus.BackColor = AppColors.Surface;

            btnResolve.Visible = false;

            LayoutCard();
            this.Resize += (s, e) => LayoutCard();
        }

        private void LayoutCard()
        {
            int innerTop = ShadowDepth + 10;
            int innerBottom = Height - ShadowDepth - 10;
            int innerLeft = ShadowDepth + StripWidth + 12;

            int imgH = innerBottom - innerTop;
            int imgW = (int)(imgH * 0.95);
            picPPEImage.Location = new Point(innerLeft, innerTop);
            picPPEImage.Size = new Size(imgW, imgH);
            ApplyControlRound(picPPEImage, 12);

            int textLeft = picPPEImage.Right + 24;
            int rightEdge = Width - ShadowDepth - 16;
            lblStatus.Location = new Point(rightEdge - lblStatus.Width, innerTop + 6);

            lblViolation.Location = new Point(textLeft, innerTop + 6);
            if (mqTitle != null)
            {
                int titleRight = lblStatus.Left - 16;
                int titleW = Math.Max(120, titleRight - textLeft);
                mqTitle.Location = new Point(textLeft, innerTop + 4);
                mqTitle.Size = new Size(titleW, 36);
            }
            lblDate.Location = new Point(textLeft, innerTop + 48);
            lblCam.Location = new Point(textLeft, innerTop + 78);
            lblZone.Location = new Point(textLeft, innerTop + 108);
            lblTargetID.Location = new Point(textLeft, innerTop + 138);
            // 장비 칩은 innerTop+168 위치에 OnPaint 에서 그림

            if (btnResolveRound != null)
                btnResolveRound.Location = new Point(rightEdge - btnResolveRound.Width, innerTop + 50);
            if (btnAck != null)
                btnAck.Location = new Point(rightEdge - btnAck.Width, innerTop + 98);
            if (btnDetail != null)
                btnDetail.Location = new Point(rightEdge - btnDetail.Width, innerTop + 146);
            if (btnDelete != null)
                btnDelete.Location = new Point(rightEdge - btnDelete.Width, innerTop + 194);

        }

        private void ApplyControlRound(Control c, int radius)
        {
            if (c.Width <= 0 || c.Height <= 0) return;
            using (var path = RoundedRect(new Rectangle(0, 0, c.Width, c.Height), radius))
                c.Region = new Region(path);
        }

        private void BuildActionButtons()
        {
            btnResolveRound = new RoundedButton
            {
                Text = "해결 처리",
                Size = new Size(120, 40),
                Font = new Font("맑은 고딕", 10F, FontStyle.Bold),
                Name = "btnResolveRound"
            };
            AppStyle.MakePrimaryButton(btnResolveRound, 12);
            btnResolveRound.Click += (s, e) =>
            {
                btnResolveRound.Enabled = false;
                OnResolveRequested?.Invoke(this);
            };

            // btnDelete = new RoundedButton
            // {
            //     Text = "삭제",
            //     Size = new Size(120, 40),
            //     Font = new Font("맑은 고딕", 10F, FontStyle.Bold),
            //     Name = "btnDelete"
            // };
            // AppStyle.MakePrimaryButton(btnDelete, 12);
            // btnDelete.Click += (s, e) => OnDeleteRequested?.Invoke(this);

            btnDetail = new RoundedButton
            {
                Text = "상세 보기",
                Size = new Size(120, 38),
                Font = new Font("맑은 고딕", 9.5F, FontStyle.Bold),
                Name = "btnDetail"
            };
            AppStyle.MakeOutlineButton(btnDetail, 12);
            btnDetail.Click += (s, e) => OnDetailRequested?.Invoke(this);

            btnAck = new RoundedButton
            {
                Text = "확인",
                Size = new Size(120, 38),
                Font = new Font("맑은 고딕", 9.5F, FontStyle.Bold),
                Name = "btnAck"
            };
            AppStyle.MakeOutlineButton(btnAck, 12);
            btnAck.Click += (s, e) =>
            {
                btnAck.Enabled = false;
                OnAckRequested?.Invoke(this);
            };

            this.Controls.Add(btnResolveRound);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnDetail);
            this.Controls.Add(btnAck);
            btnResolveRound.BringToFront();
            btnDetail.BringToFront();
            btnAck.BringToFront();
            UpdateChildOuterBg();
        }

        private void UpdateChildOuterBg()
        {
            if (btnResolveRound != null) btnResolveRound.OuterBackColor = AppColors.Surface;
            if (btnDelete != null) btnDelete.OuterBackColor = AppColors.Surface;
            if (btnDetail != null) btnDetail.OuterBackColor = AppColors.Surface;
        }

        /// <summary>그룹 데이터로 카드 채우기</summary>
        // 위험도 → 심각도 색 (높음=빨강 긴급 / 중간=주황 주의 / 낮음=파랑 일반)
        private Color SeverityColor(string risk)
        {
            switch ((risk ?? "").Trim())
            {
                case "높음": return AppColors.Danger;
                case "중간": return Color.FromArgb(245, 124, 0);   // 주황
                case "낮음": return AppColors.Primary;
                default: return AppColors.Danger;                  // 미지정 시 보수적으로 긴급
            }
        }

        // 위험도 → 상태 라벨 (미해결·미확인일 때 표시)
        private string SeverityLabel(string risk)
        {
            switch ((risk ?? "").Trim())
            {
                case "높음": return "긴급";
                case "중간": return "주의";
                case "낮음": return "일반";
                default: return "미해결";
            }
        }

        // 확인됨 카드 흐리게 처리
        private void ApplyAckDim(bool dim)
        {
            Color textNormal = AppColors.Text;
            Color textMuted = Color.FromArgb(160, 160, 160);
            Color target = dim ? textMuted : textNormal;

            lblDate.ForeColor = dim ? textMuted : AppColors.TextSecondary;
            lblCam.ForeColor = dim ? textMuted : AppColors.TextSecondary;
            lblZone.ForeColor = dim ? textMuted : AppColors.TextSecondary;
            lblTargetID.ForeColor = dim ? textMuted : AppColors.TextSecondary;
        }

        public void SetGroup(ViolationGroup group, Image img)
        {
            this.Group = group;

            lblViolation.Text = group.MissingSummary;
            if (mqTitle != null) { mqTitle.ForeColor = lblViolation.ForeColor; mqTitle.Text = group.MissingSummary; }
            lblDate.Text = "🕒 " + (group.DetectedAt ?? "-");
            lblCam.Text = "📷 " + (string.IsNullOrEmpty(group.CameraName) ? "카메라01" : group.CameraName);
            lblZone.Text = "📍 " + (string.IsNullOrEmpty(group.AreaName) ? "구역 미지정" : group.AreaName);
            lblTargetID.Text = "👷 작업자 " + (string.IsNullOrEmpty(group.PersonId) ? "미지정" : group.PersonId);
            lblStatus.Text = group.Status;

            // 장비 칩 4개
            _gearChips = new (string, GearState)[]
            {
                ("안전모", group.HelmetState),
                ("마스크", group.MaskState),
                ("왼손", group.GloveLState),
                ("오른손", group.GloveRState),
            };

                picPPEImage.Image = null;
            if(img != null)
                picPPEImage.Image = img;
            
            picPPEImage.SizeMode = PictureBoxSizeMode.Zoom;
            

            bool isResolved = group.IsChecked;
            bool isAcked = group.IsAcknowledged;

            // 심각도(위험도) 색 — 미해결일 때만 위험도 색, 해결되면 초록
            Color sevColor = SeverityColor(group.RiskLevel);
            _stripColor = isResolved ? AppColors.Success : sevColor;
            lblStatus.ForeColor = isResolved ? AppColors.Success : sevColor;
            if (mqTitle != null) mqTitle.ForeColor = isResolved ? AppColors.Success : sevColor;

            // 상태 텍스트: 확인됨이면 "확인됨" 병기
            if (isResolved) lblStatus.Text = "해결";
            else if (isAcked) lblStatus.Text = "확인됨";
            else lblStatus.Text = SeverityLabel(group.RiskLevel);

            // 해결 버튼: 표시 여부(Visible)는 각 화면이 Show/HideResolveButton 으로 결정한다.
            // 여기서는 상태에 따른 텍스트/색/활성만 갱신 (미해결="해결 처리", 해결="미해결로").
            btnResolveRound.Enabled = true;
            if (isResolved)
            {
                btnResolveRound.Text = "미해결로";
                AppStyle.MakeNeutralButton(btnResolveRound, 12);
            }
            else
            {
                btnResolveRound.Text = "해결 처리";
                AppStyle.MakePrimaryButton(btnResolveRound, 12);
            }
            btnResolveRound.OuterBackColor = AppColors.Surface;

            // 확인 버튼: 표시 여부(Visible)는 각 화면이 Show/HideAckButton 으로 결정한다.
            // 여기서는 확인 상태(미확인="확인" 활성 / 확인됨="확인됨" 비활성)만 갱신.
            if (btnAck != null)
            {
                if (isAcked)
                {
                    btnAck.Text = "확인됨";
                    btnAck.Enabled = false;
                }
                else
                {
                    btnAck.Text = "확인";
                    btnAck.Enabled = true;
                }
                btnAck.OuterBackColor = AppColors.Surface;
            }

            // 확인됨이면 카드 전체를 살짝 흐리게 (해결 전까지 추적용으로 남김)
            ApplyAckDim(isAcked && !isResolved);

            LayoutCard();
            Invalidate();
        }

        /// <summary>
        /// 단일 항목용 (US_AlertsForm 등 기존 호출 호환).
        /// 내부적으로 단일 type 그룹을 만들어 SetGroup 으로 렌더링한다.
        /// isManagementMode=false 이면 상세 버튼 숨기고 해결 버튼만 노출(미해결일 때).
        /// </summary>
        public void SetData(string type, string time, string zone, string cam, string id,
                            string uid, string status, Image img, bool isManagementMode)
        {
            var group = new ViolationGroup
            {
                DetectedAt = time,
                AreaName = zone,
                CameraName = cam,
                PersonId = uid,
                IsChecked = (status == "해결"),
            };
            if (!string.IsNullOrEmpty(id)) group.Ids.Add(id);

            string code = MapToTypeCode(type);
            if (!string.IsNullOrEmpty(code)) group.MissingTypes.Add(code);

            SetGroup(group, img);

            // 제목은 넘겨받은 type 우선 (알림 화면은 단일 위반명이 자연스러움)
            if (!string.IsNullOrEmpty(type)) { lblViolation.Text = type; if (mqTitle != null) mqTitle.Text = type; }

            // 관리 모드 아니면(알림 화면) 상세 버튼 숨김, 해결 버튼은 미해결일 때만
            if (btnDetail != null) btnDetail.Visible = isManagementMode;
            if (btnResolveRound != null)
            {
                if (isManagementMode)
                    btnResolveRound.Visible = false;
                else
                    btnResolveRound.Visible = (status != "해결");
            }


            LayoutCard();
            Invalidate();
        }

        private string MapToTypeCode(string type)
        {
            if (string.IsNullOrEmpty(type)) return null;
            string t = type.Trim();
            if (t == "no_helmet" || t == "no_mask" || t == "no_glove_left" || t == "no_glove_right")
                return t;
            if (t.Contains("안전모")) return "no_helmet";
            if (t.Contains("마스크")) return "no_mask";
            if (t.Contains("왼") && t.Contains("장갑")) return "no_glove_left";
            if (t.Contains("오른") && t.Contains("장갑")) return "no_glove_right";
            return null;
        }

        public void SetActionsEnabled(bool enabled)
        {
            if (btnResolveRound != null) btnResolveRound.Enabled = enabled;
            if (btnDetail != null) btnDetail.Enabled = enabled;
            if (btnAck != null) btnAck.Enabled = enabled;
        }

        private void btnResolve_Click(object sender, EventArgs e)
        {
            OnResolveRequested?.Invoke(this);
        }

        public void HideDetailButton()
        {
            if (btnDetail != null)
                btnDetail.Visible = false;
        }
        public void HideResolveButton()
        {
            if (btnResolveRound != null)
                btnResolveRound.Visible = false;
        }

        public void ShowDetailButton()
        {
            if (btnDetail != null)
                btnDetail.Visible = true;
        }
        public void ShowResolveButton()
        {
            if (btnResolveRound != null)
                btnResolveRound.Visible = true;
        }

        public void ShowAckButton()
        {
            if (btnAck != null)
                btnAck.Visible = true;
        }
        public void HideAckButton()
        {
            if (btnAck != null)
                btnAck.Visible = false;
        }
    }
}