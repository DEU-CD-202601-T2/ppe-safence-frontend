using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PPE_관제_시스템
{
    /// <summary>
    /// 위반 상세 팝업 (그룹 기반).
    /// 좌측: 이미지(hover 돋보기 → 클릭 시 뷰어), 우측: 정보 + 장비 4종 착용표.
    /// 하단: 삭제(그룹 전체) / 닫기.
    /// 삭제 확정 시 DialogResult.Yes → 호출측에서 그룹 전체 삭제.
    /// </summary>
    public class ViolationDetailForm : Form
    {
        private readonly ViolationGroup _group;
        private readonly Image _image;

        public ViolationDetailForm(ViolationGroup group, Image image)
        {
            _group = group;
            _image = image;

            this.Text = "위반 상세 정보";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(780, 540);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = AppColors.SurfaceAlt;
            this.Font = new Font("맑은 고딕", 10F);

            string title = $"{group.MissingSummary} ({group.DetectedAt})";

            // ===== 좌측 이미지 =====
            var imagePanel = new HoverImagePanel
            {
                Location = new Point(24, 24),
                Size = new Size(340, 360),
                Image = image
            };
            imagePanel.ImageClicked += (s, e) =>
            {
                if (_image != null)
                    using (var viewer = new ImageViewerForm(_image, title))
                        viewer.ShowDialog(this);
            };
            this.Controls.Add(imagePanel);

            // ===== 우측 정보 카드 =====
            var infoCard = new RoundedPanel
            {
                Location = new Point(384, 24),
                Size = new Size(372, 360),
                FillColor = AppColors.Surface,
                CornerRadius = 14,
                HasShadow = true,
                OuterBackColor = AppColors.SurfaceAlt
            };
            this.Controls.Add(infoCard);

            bool isResolved = group.IsChecked;

            var lblTitle = new MarqueeLabel
            {
                Text = group.MissingSummary,
                Font = new Font("맑은 고딕", 15F, FontStyle.Bold),
                ForeColor = isResolved ? AppColors.Success : AppColors.Danger,
                Size = new Size(320, 34),
                Location = new Point(26, 22),
                BackColor = AppColors.Surface
            };
            infoCard.Controls.Add(lblTitle);

            var lblStatusBadge = new Label
            {
                Text = "  " + group.Status + "  ",
                Font = new Font("맑은 고딕", 9.5F, FontStyle.Bold),
                ForeColor = isResolved ? AppColors.Success : AppColors.Danger,
                BackColor = isResolved ? AppColors.SuccessTint : AppColors.DangerTint,
                AutoSize = false,
                Size = new Size(72, 26),
                Location = new Point(26, 60),
                TextAlign = ContentAlignment.MiddleCenter
            };
            infoCard.Controls.Add(lblStatusBadge);

            AddInfoRow(infoCard, "🕒  발생 시각", group.DetectedAt, 100);
            AddInfoRow(infoCard, "📍  구역", string.IsNullOrEmpty(group.AreaName) ? "-" : group.AreaName, 134);
            AddInfoRow(infoCard, "📷  카메라", string.IsNullOrEmpty(group.CameraName) ? "-" : group.CameraName, 168);
            AddInfoRow(infoCard, "👷  대상 작업자", string.IsNullOrEmpty(group.PersonId) ? "-" : group.PersonId, 202);

            // 장비 착용표 제목
            var lblGearTitle = new Label
            {
                Text = "장비 착용 현황",
                Font = new Font("맑은 고딕", 10F, FontStyle.Bold),
                ForeColor = AppColors.TextSecondary,
                AutoSize = true,
                Location = new Point(26, 244),
                BackColor = AppColors.Surface
            };
            infoCard.Controls.Add(lblGearTitle);

            // 장비 4종 칩 (2x2)
            AddGearChip(infoCard, "안전모", group.HelmetWorn, 26, 276);
            AddGearChip(infoCard, "마스크", group.MaskWorn, 188, 276);
            AddGearChip(infoCard, "왼손 장갑", group.GloveLWorn, 26, 314);
            AddGearChip(infoCard, "오른손 장갑", group.GloveRWorn, 188, 314);

            // ===== 하단 버튼 (위 간격 충분히) =====
            int btnY = this.ClientSize.Height - 36 - 44;
            var btnClose = new RoundedButton
            {
                Text = "닫기",
                Size = new Size(120, 44),
                Location = new Point(this.ClientSize.Width - 24 - 120, btnY),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                OuterBackColor = AppColors.SurfaceAlt
            };
            AppStyle.MakeNeutralButton(btnClose, 10);
            btnClose.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            this.Controls.Add(btnClose);

            var btnDelete = new RoundedButton
            {
                Text = "삭제",
                Size = new Size(120, 44),
                Location = new Point(btnClose.Left - 12 - 120, btnY),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                OuterBackColor = AppColors.SurfaceAlt
            };
            AppStyle.MakeDangerOutlineButton(btnDelete, 10);
            btnDelete.Click += (s, e) =>
            {
                var confirm = MessageBox.Show(
                    $"이 위반 기록을 삭제하시겠습니까?\n\n해당 위반에 연결된 {_group.Ids.Count}개 항목이 모두 삭제되며,\n삭제하면 복구할 수 없습니다.",
                    "위반 삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
            };
            this.Controls.Add(btnDelete);

            this.AcceptButton = btnClose;
        }

        private void AddInfoRow(Control parent, string label, string value, int y)
        {
            var lbl = new Label
            {
                Text = label,
                Font = new Font("맑은 고딕", 9.5F),
                ForeColor = AppColors.TextMuted,
                AutoSize = false,
                Size = new Size(130, 24),
                Location = new Point(26, y),
                BackColor = AppColors.Surface
            };
            var val = new MarqueeLabel
            {
                Text = value,
                Font = new Font("맑은 고딕", 10.5F, FontStyle.Bold),
                ForeColor = AppColors.Text,
                Size = new Size(200, 24),
                Location = new Point(160, y),
                BackColor = AppColors.Surface
            };
            parent.Controls.Add(lbl);
            parent.Controls.Add(val);
        }

        private void AddGearChip(Control parent, string name, bool worn, int x, int y)
        {
            var chip = new Label
            {
                Text = (worn ? "✓ " : "✕ ") + name,
                Font = new Font("맑은 고딕", 9.5F, FontStyle.Bold),
                ForeColor = worn ? AppColors.Success : AppColors.Danger,
                BackColor = worn ? AppColors.SuccessTint : AppColors.DangerTint,
                AutoSize = false,
                Size = new Size(150, 30),
                Location = new Point(x, y),
                TextAlign = ContentAlignment.MiddleCenter
            };
            parent.Controls.Add(chip);
        }
    }

    /// <summary>마우스 hover 시 어두워지며 흰 돋보기를 보여주는 이미지 패널.</summary>
    public class HoverImagePanel : Panel
    {
        private Image _image;
        private bool _hovered = false;
        public event EventHandler ImageClicked;

        public Image Image { get => _image; set { _image = value; Invalidate(); } }

        public HoverImagePanel()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);
            BackColor = AppColors.Surface;
            Cursor = Cursors.Hand;
        }

        protected override void OnMouseEnter(EventArgs e) { _hovered = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _hovered = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnClick(EventArgs e)
        {
            if (_image != null) ImageClicked?.Invoke(this, EventArgs.Empty);
            base.OnClick(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var rect = new Rectangle(0, 0, Width - 1, Height - 1);

            using (var path = AppStyle.RoundedRect(rect, 12))
            {
                var oldClip = g.Clip;
                g.SetClip(path);

                using (var bg = new SolidBrush(AppColors.SurfaceAlt))
                    g.FillRectangle(bg, rect);

                if (_image != null)
                {
                    var dest = FitRect(_image.Size, rect);
                    g.DrawImage(_image, dest);
                }
                else
                {
                    TextRenderer.DrawText(g, "이미지 없음", Font, rect, AppColors.TextMuted,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }

                if (_hovered && _image != null)
                {
                    using (var dark = new SolidBrush(Color.FromArgb(110, 0, 0, 0)))
                        g.FillRectangle(dark, rect);
                    DrawMagnifier(g, rect);
                }

                g.Clip = oldClip;
                using (var pen = new Pen(AppColors.Border, 1f))
                    g.DrawPath(pen, path);
            }
        }

        private Rectangle FitRect(Size img, Rectangle bounds)
        {
            if (img.Width == 0 || img.Height == 0) return bounds;
            float ratio = Math.Min((float)bounds.Width / img.Width, (float)bounds.Height / img.Height);
            int w = (int)(img.Width * ratio);
            int h = (int)(img.Height * ratio);
            int x = bounds.Left + (bounds.Width - w) / 2;
            int y = bounds.Top + (bounds.Height - h) / 2;
            return new Rectangle(x, y, w, h);
        }

        private void DrawMagnifier(Graphics g, Rectangle bounds)
        {
            int cx = bounds.Left + bounds.Width / 2;
            int cy = bounds.Top + bounds.Height / 2;
            int r = 22;
            using (var pen = new Pen(Color.White, 3.5f))
            {
                g.DrawEllipse(pen, cx - r, cy - r - 6, r * 2, r * 2);
                double ang = Math.PI / 4;
                int hx = cx + (int)(r * Math.Cos(ang));
                int hy = (cy - 6) + (int)(r * Math.Sin(ang));
                int hx2 = hx + (int)(16 * Math.Cos(ang));
                int hy2 = hy + (int)(16 * Math.Sin(ang));
                g.DrawLine(pen, hx, hy, hx2, hy2);
            }
            TextRenderer.DrawText(g, "클릭하여 크게 보기", new Font("맑은 고딕", 9F, FontStyle.Bold),
                new Rectangle(bounds.Left, cy + r + 4, bounds.Width, 24), Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.Top);
        }
    }
}