using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PPE_관제_시스템
{
    /// <summary>
    /// 앱 전역 공통 스타일 키트.
    /// 둥근 모서리 + 그림자 + 부드러운 버튼을 어느 폼에서나 재사용한다.
    /// </summary>
    public static class AppStyle
    {
        public const int CardRadius = 16;
        public const int ButtonRadius = 10;
        public const int InputRadius = 8;

        public static GraphicsPath RoundedRect(Rectangle rect, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            if (radius <= 0 || d > rect.Width || d > rect.Height)
            {
                // 반경이 너무 크거나 0이면 안전하게 사각형
                if (radius <= 0)
                {
                    path.AddRectangle(rect);
                    path.CloseFigure();
                    return path;
                }
                d = Math.Min(d, Math.Min(rect.Width, rect.Height));
            }
            path.AddArc(rect.Left, rect.Top, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Top, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.Left, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        // ===== 버튼 스타일 프리셋 (RoundedButton 에 적용) =====

        public static void MakePrimaryButton(Button btn, int radius = ButtonRadius)
            => ApplyRoundStyle(btn, AppColors.Primary, AppColors.TextOnPrimary, AppColors.PrimaryDark, Color.Empty, radius);

        public static void MakeAccentButton(Button btn, int radius = ButtonRadius)
            => ApplyRoundStyle(btn, AppColors.Accent, AppColors.TextOnAccent, AppColors.AccentDark, Color.Empty, radius);

        public static void MakeDangerOutlineButton(Button btn, int radius = ButtonRadius)
            => ApplyRoundStyle(btn, AppColors.Surface, AppColors.Danger, AppColors.DangerTint, AppColors.Danger, radius);

        public static void MakeOutlineButton(Button btn, int radius = ButtonRadius)
            => ApplyRoundStyle(btn, AppColors.Surface, AppColors.PrimaryDark, AppColors.PrimaryLight, AppColors.Primary, radius);

        public static void MakeNeutralButton(Button btn, int radius = ButtonRadius)
            => ApplyRoundStyle(btn, AppColors.SurfaceAlt, AppColors.Text, AppColors.PrimaryHover, AppColors.Border, radius);

        /// <summary>
        /// 버튼에 둥근 스타일 적용.
        /// RoundedButton 이면 테두리까지 둥글게 페인팅, 일반 Button 이면 Region 으로 처리.
        /// </summary>
        private static void ApplyRoundStyle(Button btn, Color back, Color fore, Color hover, Color border, int radius)
        {
            if (btn is RoundedButton rb)
            {
                rb.FillColor = back;
                rb.ForeColor = fore;
                rb.HoverColor = hover;
                rb.BorderColorCustom = border;
                rb.CornerRadius = radius;
                if (rb.Font == null) rb.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
                rb.Invalidate();
                return;
            }

            // 일반 Button 폴백: FlatStyle + Region (테두리는 둥글게 안 됨)
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = back;
            btn.ForeColor = fore;
            btn.UseVisualStyleBackColor = false;
            btn.FlatAppearance.MouseOverBackColor = hover;
            btn.FlatAppearance.BorderSize = (border == Color.Empty) ? 0 : 1;
            if (border != Color.Empty) btn.FlatAppearance.BorderColor = border;
            ApplyRoundedRegion(btn, radius);
        }

        public static void ApplyRoundedRegion(Control c, int radius)
        {
            if (c.Width <= 0 || c.Height <= 0) return;
            using (var path = RoundedRect(new Rectangle(0, 0, c.Width, c.Height), radius))
            {
                c.Region = new Region(path);
            }
        }
    }

    /// <summary>
    /// 테두리까지 둥글게 직접 페인팅하는 버튼.
    /// (기본 Button 의 FlatAppearance.Border 는 사각으로만 그려져 둥근 Region 에 잘림)
    /// </summary>
    public class RoundedButton : Button
    {
        public Color FillColor { get; set; } = AppColors.Primary;
        public Color HoverColor { get; set; } = AppColors.PrimaryDark;
        public Color BorderColorCustom { get; set; } = Color.Empty;
        public int CornerRadius { get; set; } = 10;

        private bool _hovered = false;

        public RoundedButton()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseOverBackColor = Color.Transparent;
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            BackColor = Color.Transparent;
            ForeColor = AppColors.TextOnPrimary;
            Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            Cursor = Cursors.Hand;
        }

        // 부모 배경색(카드 흰색 등)을 받아 모서리 바깥을 칠함 → 검정 폴백 방지
        public Color OuterBackColor { get; set; } = AppColors.Surface;

        protected override void OnMouseEnter(EventArgs e) { _hovered = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _hovered = false; Invalidate(); base.OnMouseLeave(e); }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // 1) 모서리 바깥을 부모 배경색으로 채움
            using (var ob = new SolidBrush(OuterBackColor))
                g.FillRectangle(ob, 0, 0, Width, Height);

            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using (var path = AppStyle.RoundedRect(rect, CornerRadius))
            {
                // 2) 본체 채움 (hover 시 색 변경)
                Color body = _hovered ? HoverColor : FillColor;
                using (var fill = new SolidBrush(body))
                    g.FillPath(fill, path);

                // 3) 테두리 (둥글게)
                if (BorderColorCustom != Color.Empty)
                {
                    using (var pen = new Pen(BorderColorCustom, 1.4f))
                        g.DrawPath(pen, path);
                }
            }

            // 4) 텍스트
            TextRenderer.DrawText(g, Text, Font, rect, ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }

    /// <summary>
    /// 둥근 모서리 + (선택적) 그림자를 가진 패널.
    /// </summary>
    public class RoundedPanel : Panel
    {
        private int _cornerRadius = AppStyle.CardRadius;
        private bool _hasShadow = false;
        private int _shadowDepth = 6;
        private Color _fillColor = AppColors.Surface;
        private Color _borderColor = Color.Empty;
        private int _borderThickness = 0;
        private Color _outerBackColor = AppColors.SurfaceAlt;

        public int CornerRadius { get => _cornerRadius; set { _cornerRadius = value; Invalidate(); } }
        public bool HasShadow { get => _hasShadow; set { _hasShadow = value; Invalidate(); } }
        public int ShadowDepth { get => _shadowDepth; set { _shadowDepth = value; Invalidate(); } }
        public Color FillColor { get => _fillColor; set { _fillColor = value; Invalidate(); } }
        public Color BorderColorCustom { get => _borderColor; set { _borderColor = value; Invalidate(); } }
        public int BorderThickness { get => _borderThickness; set { _borderThickness = value; Invalidate(); } }
        public Color OuterBackColor { get => _outerBackColor; set { _outerBackColor = value; Invalidate(); } }

        public RoundedPanel()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);
            BackColor = AppColors.Surface;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // 0) 바깥 영역을 부모 배경색으로
            using (var ob = new SolidBrush(_outerBackColor))
                g.FillRectangle(ob, 0, 0, Width, Height);

            int inset = _hasShadow ? _shadowDepth : 0;
            var cardRect = new Rectangle(inset, inset, Width - inset * 2 - 1, Height - inset * 2 - 1);
            if (cardRect.Width <= 0 || cardRect.Height <= 0) return;

            // 1) 그림자
            if (_hasShadow)
            {
                for (int i = _shadowDepth; i > 0; i--)
                {
                    int alpha = 8 + (int)(12.0 * (_shadowDepth - i) / _shadowDepth);
                    var sRect = new Rectangle(cardRect.Left - i / 2, cardRect.Top + i, cardRect.Width + i, cardRect.Height + i);
                    using (var sp = AppStyle.RoundedRect(sRect, _cornerRadius + i))
                    using (var sb = new SolidBrush(Color.FromArgb(alpha, AppColors.Shadow)))
                        g.FillPath(sb, sp);
                }
            }

            // 2) 본체
            using (var path = AppStyle.RoundedRect(cardRect, _cornerRadius))
            {
                using (var fill = new SolidBrush(_fillColor))
                    g.FillPath(fill, path);
                if (_borderColor != Color.Empty && _borderThickness > 0)
                    using (var pen = new Pen(_borderColor, _borderThickness))
                        g.DrawPath(pen, path);
            }
        }
    }

    /// <summary>
    /// 일괄 처리 중 화면을 덮는 반투명 로딩 오버레이 (중앙 회전 스피너).
    /// 알림/위반관리 화면이 공유한다. 표시 직전 호출 측에서 SetSnapshot 으로
    /// 현재 화면 캡처를 넣어주면 어둡게 비치는 배경 효과가 난다.
    /// </summary>
    public sealed class LoadingOverlay : Panel
    {
        private readonly System.Windows.Forms.Timer _spin;
        private float _angle;
        private readonly string _message;
        private Image _snapshot;

        public LoadingOverlay(string message)
        {
            _message = string.IsNullOrEmpty(message) ? "처리 중..." : message;
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            Dock = DockStyle.Fill;
            BackColor = Color.White;
            _spin = new System.Windows.Forms.Timer { Interval = 16 };
            _spin.Tick += (s, e) => { _angle = (_angle + 9f) % 360f; Invalidate(); };
        }

        public void SetSnapshot(Image img) { _snapshot = img; Invalidate(); }
        public void Start() { _spin.Start(); }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (_snapshot != null)
            {
                g.DrawImage(_snapshot, 0, 0, Width, Height);
            }
            else
            {
                using (var bg = new SolidBrush(Color.White)) g.FillRectangle(bg, ClientRectangle);
            }

            using (var dim = new SolidBrush(Color.FromArgb(140, 70, 70, 70)))
                g.FillRectangle(dim, ClientRectangle);

            int cx = Width / 2;
            int cy = Height / 2;
            int r = 26;
            using (var track = new Pen(Color.FromArgb(70, 255, 255, 255), 5f))
                g.DrawEllipse(track, cx - r, cy - r, r * 2, r * 2);
            using (var pen = new Pen(Color.White, 5f) { StartCap = LineCap.Round, EndCap = LineCap.Round })
                g.DrawArc(pen, cx - r, cy - r, r * 2, r * 2, _angle, 300f);

            using (var font = new Font("맑은 고딕", 11F, FontStyle.Bold))
            {
                Size sz = TextRenderer.MeasureText(_message, font);
                TextRenderer.DrawText(g, _message, font,
                    new Point(cx - sz.Width / 2, cy + r + 14), Color.White);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _spin.Stop();
                _spin.Dispose();
                if (_snapshot != null) { _snapshot.Dispose(); _snapshot = null; }
            }
            base.Dispose(disposing);
        }
    }
}