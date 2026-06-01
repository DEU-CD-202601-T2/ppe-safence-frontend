using System.Drawing;

namespace PPE_관제_시스템
{
    /// <summary>
    /// 앱 전역 색상 팔레트.
    /// 디자인 변경 시 이 파일만 수정하면 됩니다.
    /// </summary>
    public static class AppColors
    {
        // ===== 배경 / 표면 =====
        public static readonly Color Background = Color.White;
        public static readonly Color Surface = Color.White;
        public static readonly Color SurfaceAlt = Color.FromArgb(248, 249, 250);

        // ===== 테두리 =====
        public static readonly Color Border = Color.FromArgb(224, 224, 224);
        public static readonly Color BorderDark = Color.FromArgb(189, 189, 189);

        // ===== Primary (파란색 - 메인 액센트) =====
        public static readonly Color Primary = Color.FromArgb(33, 150, 243);
        public static readonly Color PrimaryDark = Color.FromArgb(25, 118, 210);
        public static readonly Color PrimaryLight = Color.FromArgb(227, 242, 253);
        public static readonly Color PrimaryHover = Color.FromArgb(187, 222, 251);

        // ===== Accent (노란색 - 보조 액센트) =====
        public static readonly Color Accent = Color.FromArgb(255, 193, 7);
        public static readonly Color AccentDark = Color.FromArgb(255, 160, 0);
        public static readonly Color AccentLight = Color.FromArgb(255, 248, 225);

        // ===== 텍스트 (모두 검정 계열) =====
        public static readonly Color Text = Color.FromArgb(33, 33, 33);
        public static readonly Color TextSecondary = Color.FromArgb(97, 97, 97);
        public static readonly Color TextMuted = Color.FromArgb(158, 158, 158);
        public static readonly Color TextOnPrimary = Color.White;
        public static readonly Color TextOnAccent = Color.FromArgb(33, 33, 33);

        // ===== 상태 =====
        public static readonly Color Success = Color.FromArgb(56, 142, 60);
        public static readonly Color Warning = Color.FromArgb(255, 152, 0);
        public static readonly Color Danger = Color.FromArgb(211, 47, 47);
        
        // ===== 그림자 / 입체감 =====
        public static readonly Color Shadow = Color.FromArgb(28, 33, 56);       // 카드 그림자 베이스(알파는 코드에서 조절)
 
        // ===== 상태 배경 틴트 (카드 좌측 띠 / 뱃지 배경) =====
        public static readonly Color DangerTint = Color.FromArgb(253, 237, 237);  // 미해결 연한 빨강 배경
        public static readonly Color SuccessTint = Color.FromArgb(237, 247, 237); // 해결 연한 초록 배경
        public static readonly Color PrimaryTint = Color.FromArgb(232, 242, 254); // 정보 연한 파랑 배경
    }
}