using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PPE_관제_시스템
{
    /// <summary>
    /// 화면 우측 하단에 뜨는 실시간 위반 토스트 알림.
    /// - 슬라이드 인 → 일정 시간 후 자동 사라짐 (마우스 올리면 유지)
    /// - 클릭하면 OnClicked 콜백 (알림 화면 이동 등)
    /// - 여러 개가 위로 스택됨
    /// 심각도(위험도)에 따라 좌측 색 띠와 표시가 달라진다.
    /// </summary>
    public class ToastNotification : Form
    {
        // 현재 떠 있는 토스트들 (스택 위치 계산용)
        private static readonly List<ToastNotification> _active = new List<ToastNotification>();

        private readonly Color _stripColor;
        private readonly System.Windows.Forms.Timer _lifeTimer;
        private int _remainingMs;
        private const int Margin = 16;        // 화면 가장자리 여백
        private const int Gap = 10;           // 토스트 사이 간격
        private bool _closing = false;
        private bool _hovered = false;

        public event Action OnClicked;

        public ToastNotification(string title, string subtitle, string timeText, string riskLevel, int lifeMs = 6000)
        {
            _stripColor = SeverityColor(riskLevel);
            _remainingMs = lifeMs;

            // 폼 기본 설정 (테두리 없음, 작업표시줄 X, 항상 위)
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.Size = new Size(340, 96);
            this.BackColor = Color.White;
            this.TopMost = true;
            this.DoubleBuffered = true;

            BuildContent(title, subtitle, timeText, riskLevel);

            // 수명 타이머 (100ms 틱, 마우스 hover 중엔 줄지 않음)
            _lifeTimer = new System.Windows.Forms.Timer { Interval = 100 };
            _lifeTimer.Tick += (s, e) =>
            {
                if (_hovered) return;
                _remainingMs -= 100;
                if (_remainingMs <= 0) BeginClose();
            };
        }

        private void BuildContent(string title, string subtitle, string timeText, string riskLevel)
        {
            // 클릭 핸들러 (폼 + 모든 자식)
            EventHandler clickHandler = (s, e) =>
            {
                OnClicked?.Invoke();
                BeginClose();
            };
            this.Click += clickHandler;
            this.Cursor = Cursors.Hand;

            // 심각도 라벨
            var lblSeverity = new Label
            {
                Text = SeverityLabel(riskLevel),
                Font = new Font("맑은 고딕", 8.5F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = _stripColor,
                AutoSize = false,
                Size = new Size(44, 22),
                Location = new Point(16, 14),
                TextAlign = ContentAlignment.MiddleCenter
            };
            lblSeverity.Click += clickHandler;
            this.Controls.Add(lblSeverity);

            // 제목 (위반 내용)
            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("맑은 고딕", 11F, FontStyle.Bold),
                ForeColor = AppColors.Text,
                AutoSize = false,
                Size = new Size(250, 26),
                Location = new Point(68, 12),
                AutoEllipsis = true
            };
            lblTitle.Click += clickHandler;
            this.Controls.Add(lblTitle);

            // 부제 (구역 등)
            var lblSub = new Label
            {
                Text = subtitle,
                Font = new Font("맑은 고딕", 9.5F),
                ForeColor = AppColors.TextSecondary,
                AutoSize = false,
                Size = new Size(250, 22),
                Location = new Point(68, 40),
                AutoEllipsis = true
            };
            lblSub.Click += clickHandler;
            this.Controls.Add(lblSub);

            // 시간
            var lblTime = new Label
            {
                Text = timeText,
                Font = new Font("맑은 고딕", 8.5F),
                ForeColor = AppColors.TextMuted,
                AutoSize = false,
                Size = new Size(250, 18),
                Location = new Point(68, 64)
            };
            lblTime.Click += clickHandler;
            this.Controls.Add(lblTime);

            // 닫기(×) 버튼
            var btnClose = new Label
            {
                Text = "✕",
                Font = new Font("맑은 고딕", 9F, FontStyle.Bold),
                ForeColor = AppColors.TextMuted,
                AutoSize = false,
                Size = new Size(24, 24),
                Location = new Point(this.Width - 30, 8),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };
            btnClose.Click += (s, e) => BeginClose();
            this.Controls.Add(btnClose);
            btnClose.BringToFront();

            // hover 시 수명 정지 (폼과 자식 전체)
            this.MouseEnter += (s, e) => _hovered = true;
            this.MouseLeave += (s, e) => _hovered = OnFormArea();
            foreach (Control c in this.Controls)
            {
                c.MouseEnter += (s, e) => _hovered = true;
                c.MouseLeave += (s, e) => _hovered = OnFormArea();
            }
        }

        private bool OnFormArea()
        {
            return this.Bounds.Contains(Cursor.Position);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // 테두리
            using (var pen = new Pen(AppColors.Border, 1f))
                g.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);

            // 좌측 심각도 색 띠
            using (var b = new SolidBrush(_stripColor))
                g.FillRectangle(b, 0, 0, 6, Height);
        }

        // 그림자 효과 (네이티브)
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x00020000;
                var cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        // 포커스 뺏지 않도록
        protected override bool ShowWithoutActivation => true;

        /// <summary>토스트를 화면 우측 하단에 띄운다.</summary>
        public void ShowToast()
        {
            _active.Add(this);
            RepositionAll();
            this.Show();
            _lifeTimer.Start();
        }

        // 모든 활성 토스트를 우측 상단부터 아래로 재배치
        private static void RepositionAll()
        {
            var area = Screen.PrimaryScreen.WorkingArea;
            int y = area.Top + Margin;
            // 먼저 뜬 것이 위, 새로 뜬 것이 아래로 쌓임
            for (int i = 0; i < _active.Count; i++)
            {
                var t = _active[i];
                int x = area.Right - t.Width - Margin;
                t.Location = new Point(x, y);
                y += t.Height + Gap;
            }
        }

        private void BeginClose()
        {
            if (_closing) return;
            _closing = true;
            _lifeTimer.Stop();
            _active.Remove(this);
            RepositionAll();
            this.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _lifeTimer?.Dispose();
                _active.Remove(this);
            }
            base.Dispose(disposing);
        }

        // ===== 심각도 매핑 (US_AlertCard 와 동일 규칙) =====
        private static Color SeverityColor(string risk)
        {
            switch ((risk ?? "").Trim())
            {
                case "높음": return AppColors.Danger;
                case "중간": return Color.FromArgb(245, 124, 0);
                case "낮음": return AppColors.Primary;
                default: return AppColors.Danger;
            }
        }

        private static string SeverityLabel(string risk)
        {
            switch ((risk ?? "").Trim())
            {
                case "높음": return "긴급";
                case "중간": return "주의";
                case "낮음": return "일반";
                default: return "위반";
            }
        }
    }
}