using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace PPE_관제_시스템
{
    /// <summary>
    /// 이미지 뷰어 창.
    /// - 마우스 휠 / 버튼으로 확대·축소
    /// - 드래그로 이동(팬)
    /// - 클립보드 복사, 파일 저장
    /// - ESC 로 닫기, 더블클릭으로 화면맞춤
    /// </summary>
    public class ImageViewerForm : Form
    {
        private readonly Image _image;
        private float _zoom = 1.0f;
        private PointF _offset = PointF.Empty;
        private bool _dragging = false;
        private Point _lastMouse;
        private readonly ZoomCanvas _canvas;
        private readonly Label _lblZoom;

        public ImageViewerForm(Image image, string title)
        {
            _image = image;
            this.Text = "이미지 뷰어 - " + title;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(900, 720);
            this.BackColor = Color.FromArgb(33, 33, 33);
            this.KeyPreview = true;

            // ===== 상단 툴바 =====
            var toolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 52,
                BackColor = Color.FromArgb(45, 45, 45)
            };
            this.Controls.Add(toolbar);

            var btnZoomIn = MakeToolButton("＋ 확대", 12);
            btnZoomIn.Click += (s, e) => ApplyZoom(_zoom * 1.25f);
            var btnZoomOut = MakeToolButton("－ 축소", 120);
            btnZoomOut.Click += (s, e) => ApplyZoom(_zoom / 1.25f);
            var btnFit = MakeToolButton("⤢ 화면맞춤", 228);
            btnFit.Click += (s, e) => FitToScreen();
            var btnCopy = MakeToolButton("📋 복사", 356);
            btnCopy.Click += (s, e) => CopyToClipboard();
            var btnSave = MakeToolButton("💾 저장", 464);
            btnSave.Click += (s, e) => SaveToFile();

            toolbar.Controls.Add(btnZoomIn);
            toolbar.Controls.Add(btnZoomOut);
            toolbar.Controls.Add(btnFit);
            toolbar.Controls.Add(btnCopy);
            toolbar.Controls.Add(btnSave);

            _lblZoom = new Label
            {
                Text = "100%",
                ForeColor = Color.White,
                Font = new Font("맑은 고딕", 10F, FontStyle.Bold),
                AutoSize = false,
                Size = new Size(80, 32),
                Location = new Point(580, 10),
                TextAlign = ContentAlignment.MiddleCenter
            };
            toolbar.Controls.Add(_lblZoom);

            // ===== 캔버스 =====
            _canvas = new ZoomCanvas(this)
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(33, 33, 33)
            };
            this.Controls.Add(_canvas);
            _canvas.BringToFront();

            _canvas.MouseWheel += Canvas_MouseWheel;
            _canvas.MouseDown += (s, e) => { _dragging = true; _lastMouse = e.Location; };
            _canvas.MouseUp += (s, e) => _dragging = false;
            _canvas.MouseMove += Canvas_MouseMove;
            _canvas.DoubleClick += (s, e) => FitToScreen();

            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape) this.Close();
                else if (e.Control && e.KeyCode == Keys.C) CopyToClipboard();
                else if (e.Control && e.KeyCode == Keys.S) SaveToFile();
                else if (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add) ApplyZoom(_zoom * 1.25f);
                else if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract) ApplyZoom(_zoom / 1.25f);
            };

            this.Shown += (s, e) => FitToScreen();
        }

        private Button MakeToolButton(string text, int x)
        {
            var b = new Button
            {
                Text = text,
                Size = new Size(text.Length > 4 ? 104 : 100, 32),
                Location = new Point(x, 10),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                Font = new Font("맑은 고딕", 9.5F, FontStyle.Bold)
            };
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 80, 80);
            return b;
        }

        public float Zoom => _zoom;
        public PointF Offset => _offset;
        public Image SourceImage => _image;

        private void Canvas_MouseWheel(object sender, MouseEventArgs e)
        {
            float factor = e.Delta > 0 ? 1.15f : 1 / 1.15f;
            ApplyZoom(_zoom * factor);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                _offset.X += e.X - _lastMouse.X;
                _offset.Y += e.Y - _lastMouse.Y;
                _lastMouse = e.Location;
                _canvas.Invalidate();
            }
        }

        private void ApplyZoom(float z)
        {
            _zoom = Math.Max(0.1f, Math.Min(8f, z));
            _lblZoom.Text = $"{_zoom * 100:F0}%";
            _canvas.Invalidate();
        }

        private void FitToScreen()
        {
            if (_image == null) return;
            float ratio = Math.Min(
                (float)_canvas.Width / _image.Width,
                (float)_canvas.Height / _image.Height);
            _zoom = Math.Max(0.1f, Math.Min(8f, ratio));
            _offset = PointF.Empty;
            _lblZoom.Text = $"{_zoom * 100:F0}%";
            _canvas.Invalidate();
        }

        private void CopyToClipboard()
        {
            try
            {
                if (_image != null)
                {
                    Clipboard.SetImage(_image);
                    ShowToast("클립보드에 복사되었습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("복사 실패: " + ex.Message);
            }
        }

        private void SaveToFile()
        {
            if (_image == null) return;
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG 이미지|*.png|JPEG 이미지|*.jpg";
                sfd.FileName = $"violation_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        var fmt = sfd.FilterIndex == 2 ? ImageFormat.Jpeg : ImageFormat.Png;
                        _image.Save(sfd.FileName, fmt);
                        ShowToast("저장되었습니다.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("저장 실패: " + ex.Message);
                    }
                }
            }
        }

        private void ShowToast(string msg)
        {
            _lblZoom.Text = msg;
            var t = new Timer { Interval = 1200 };
            t.Tick += (s, e) => { _lblZoom.Text = $"{_zoom * 100:F0}%"; t.Stop(); t.Dispose(); };
            t.Start();
        }

        // 이미지 그리기 전용 캔버스
        private class ZoomCanvas : Panel
        {
            private readonly ImageViewerForm _owner;
            public ZoomCanvas(ImageViewerForm owner)
            {
                _owner = owner;
                SetStyle(ControlStyles.UserPaint |
                         ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.ResizeRedraw, true);
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                var g = e.Graphics;
                var img = _owner.SourceImage;
                if (img == null) return;

                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                float w = img.Width * _owner.Zoom;
                float h = img.Height * _owner.Zoom;
                float x = (Width - w) / 2 + _owner.Offset.X;
                float y = (Height - h) / 2 + _owner.Offset.Y;

                g.DrawImage(img, x, y, w, h);
            }
        }
    }
}