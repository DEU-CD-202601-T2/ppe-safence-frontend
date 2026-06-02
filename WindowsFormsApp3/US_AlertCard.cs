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
        private RoundedButton btnDelete;

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
        private (string label, bool worn)[] _gearChips = new (string, bool)[0];

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
                foreach (var (label, worn) in _gearChips)
                {
                    string text = (worn ? "✓ " : "✕ ") + label;
                    Size sz = TextRenderer.MeasureText(text, font);
                    int chipW = sz.Width + 24;

                    var rect = new Rectangle(x, chipY, chipW, chipH);
                    Color back = worn ? AppColors.SuccessTint : AppColors.DangerTint;
                    Color fore = worn ? AppColors.Success : AppColors.Danger;

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

            lblViolation.BackColor = AppColors.Surface;
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
            lblViolation.Location = new Point(textLeft, innerTop + 6);
            lblDate.Location = new Point(textLeft, innerTop + 48);
            lblCam.Location = new Point(textLeft, innerTop + 78);
            lblZone.Location = new Point(textLeft, innerTop + 108);
            lblTargetID.Location = new Point(textLeft, innerTop + 138);
            // 장비 칩은 innerTop+168 위치에 OnPaint 에서 그림

            int rightEdge = Width - ShadowDepth - 16;
            lblStatus.Location = new Point(rightEdge - lblStatus.Width, innerTop + 6);
            if (btnResolveRound != null)
                btnResolveRound.Location = new Point(rightEdge - btnResolveRound.Width, innerTop + 50);
            if (btnDetail != null)
                btnDetail.Location = new Point(rightEdge - btnDetail.Width, innerTop + 98);
            if(btnDelete != null)
                btnDelete.Location = new Point(rightEdge - btnDelete.Width, innerTop + 146);
        
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

            btnDelete = new RoundedButton
            {
                Text = "삭제",
                Size = new Size(120, 40),
                Font = new Font("맑은 고딕", 10F, FontStyle.Bold),
                Name = "btnDelete"
            };
            AppStyle.MakePrimaryButton(btnDelete, 12);
            btnDelete.Click += (s, e) => OnDeleteRequested?.Invoke(this);

            btnDetail = new RoundedButton
            {
                Text = "상세 보기",
                Size = new Size(120, 38),
                Font = new Font("맑은 고딕", 9.5F, FontStyle.Bold),
                Name = "btnDetail"
            };
            AppStyle.MakeOutlineButton(btnDetail, 12);
            btnDetail.Click += (s, e) => OnDetailRequested?.Invoke(this);

            this.Controls.Add(btnResolveRound);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnDetail);
            btnResolveRound.BringToFront();
            btnDetail.BringToFront();
            UpdateChildOuterBg();
        }

        private void UpdateChildOuterBg()
        {
            if (btnResolveRound != null) btnResolveRound.OuterBackColor = AppColors.Surface;
            if (btnDelete != null) btnDelete.OuterBackColor = AppColors.Surface;
            if (btnDetail != null) btnDetail.OuterBackColor = AppColors.Surface;
        }

        /// <summary>그룹 데이터로 카드 채우기</summary>
        public void SetGroup(ViolationGroup group, Image img)
        {
            this.Group = group;

            lblViolation.Text = group.MissingSummary;
            lblDate.Text = "🕒 " + (group.DetectedAt ?? "-");
            lblCam.Text = "📷 " + (string.IsNullOrEmpty(group.CameraName) ? "카메라01" : group.CameraName);
            lblZone.Text = "📍 " + (string.IsNullOrEmpty(group.AreaName) ? "구역 미지정" : group.AreaName);
            lblTargetID.Text = "👷 작업자 " + (string.IsNullOrEmpty(group.PersonId) ? "미지정" : group.PersonId);
            lblStatus.Text = group.Status;

            // 장비 칩 4개
            _gearChips = new (string, bool)[]
            {
                ("안전모", group.HelmetWorn),
                ("마스크", group.MaskWorn),
                ("왼손", group.GloveLWorn),
                ("오른손", group.GloveRWorn),
            };

            if (img != null)
            {
                if (picPPEImage.Image != null) picPPEImage.Image.Dispose();
                picPPEImage.Image = img;
                picPPEImage.SizeMode = PictureBoxSizeMode.Zoom;
            }

            bool isResolved = group.IsChecked;
            _stripColor = isResolved ? AppColors.Success : AppColors.Danger;
            lblStatus.ForeColor = isResolved ? AppColors.Success : AppColors.Danger;

            btnResolveRound.Visible = true;
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
            if (!string.IsNullOrEmpty(type)) lblViolation.Text = type;

            // 관리 모드 아니면(알림 화면) 상세 버튼 숨김, 해결 버튼은 미해결일 때만
            if (btnDetail != null) btnDetail.Visible = isManagementMode;
            if (!isManagementMode && btnResolveRound != null)
                btnResolveRound.Visible = (status != "해결");

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
        }

        private void btnResolve_Click(object sender, EventArgs e)
        {
            OnResolveRequested?.Invoke(this);
        }
    }
}