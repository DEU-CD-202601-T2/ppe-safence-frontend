using System;
using System.Drawing;
using System.Windows.Forms;

namespace PPE_관제_시스템
{
    /// <summary>
    /// 텍스트가 컨트롤 폭보다 길 때만 가로로 흐르는(마퀴) 라벨.
    /// 짧으면 일반 라벨처럼 고정 표시(정렬은 LeftCenter).
    /// </summary>
    public class MarqueeLabel : Control
    {
        private System.Windows.Forms.Timer _timer;
        private float _offset = 0f;
        private int _textWidth = 0;
        private bool _needsScroll = false;

        // 흐르는 속도(px/틱)와 양끝 멈춤 간격
        private const float Speed = 1.0f;
        private const int GapBetweenLoops = 60;   // 한 바퀴 끝나고 다음 시작까지 간격(px)
        private const int PauseTicks = 40;        // 시작 시 잠깐 멈춤(틱)
        private int _pauseCounter = 0;

        public MarqueeLabel()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);
            DoubleBuffered = true;

            _timer = new System.Windows.Forms.Timer { Interval = 20 };  // ~50fps
            _timer.Tick += Timer_Tick;
        }

        public override string Text
        {
            get => base.Text;
            set { base.Text = value; RecalcAndReset(); Invalidate(); }
        }

        public override Font Font
        {
            get => base.Font;
            set { base.Font = value; RecalcAndReset(); Invalidate(); }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            RecalcAndReset();
        }

        private void RecalcAndReset()
        {
            if (string.IsNullOrEmpty(Text)) { _needsScroll = false; _timer.Stop(); Invalidate(); return; }
            _textWidth = TextRenderer.MeasureText(Text, Font).Width;
            _needsScroll = _textWidth > Width;
            _offset = 0f;
            _pauseCounter = PauseTicks;

            if (_needsScroll)
            {
                if (Visible) _timer.Start();
            }
            else
            {
                _timer.Stop();
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible && _needsScroll) _timer.Start();
            else _timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!_needsScroll) { _timer.Stop(); return; }

            // 시작 시 잠깐 멈춤
            if (_pauseCounter > 0) { _pauseCounter--; return; }

            _offset += Speed;
            // 텍스트가 완전히 왼쪽으로 빠지면 다시 오른쪽 끝에서 시작
            if (_offset > _textWidth + GapBetweenLoops)
            {
                _offset = 0f;
                _pauseCounter = PauseTicks;
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            // 배경
            using (var b = new SolidBrush(BackColor))
                g.FillRectangle(b, ClientRectangle);

            if (string.IsNullOrEmpty(Text)) return;

            int textY = (Height - TextRenderer.MeasureText(Text, Font).Height) / 2;

            if (!_needsScroll)
            {
                // 안 넘치면 그냥 좌측 정렬 표시
                TextRenderer.DrawText(g, Text, Font, new Point(0, textY), ForeColor);
            }
            else
            {
                // 넘치면 흐르게: 본체 + 한 바퀴용 복제본
                int x1 = (int)(-_offset);
                TextRenderer.DrawText(g, Text, Font, new Point(x1, textY), ForeColor);
                int x2 = x1 + _textWidth + GapBetweenLoops;
                TextRenderer.DrawText(g, Text, Font, new Point(x2, textY), ForeColor);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) { _timer?.Stop(); _timer?.Dispose(); }
            base.Dispose(disposing);
        }
    }
}