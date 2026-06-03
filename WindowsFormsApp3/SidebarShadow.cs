using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PPE_관제_시스템
{
    /// <summary>
    /// 사이드바 우측 경계에 입체감을 주는 그림자 패널.
    /// 왼쪽(사이드바 쪽)은 진하고 오른쪽(콘텐츠 쪽)으로 갈수록 투명해지는
    /// 가로 그라데이션을 그려서 사이드바가 콘텐츠 위에 떠 있는 느낌을 준다.
    /// 마우스 이벤트는 통과시켜 아래 콘텐츠 조작을 방해하지 않는다.
    /// </summary>
    public class SidebarShadow : Panel
    {
        public SidebarShadow()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            TabStop = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            var rect = this.ClientRectangle;
            if (rect.Width <= 0 || rect.Height <= 0) return;

            // 왼쪽 진함 → 오른쪽 투명
            using (var brush = new LinearGradientBrush(
                       new Rectangle(0, 0, rect.Width, rect.Height),
                       Color.FromArgb(55, 0, 0, 0),   // 좌측: 반투명 검정
                       Color.FromArgb(0, 0, 0, 0),    // 우측: 완전 투명
                       LinearGradientMode.Horizontal))
            {
                g.FillRectangle(brush, rect);
            }
        }

        // 마우스 이벤트를 아래 컨트롤로 통과 (그림자가 클릭을 가로채지 않게)
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_TRANSPARENT = 0x20;
                var cp = base.CreateParams;
                cp.ExStyle |= WS_EX_TRANSPARENT;
                return cp;
            }
        }
    }
}