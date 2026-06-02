using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PPE_관제_시스템
{
    /// <summary>장비 단속/착용 상태 3종.</summary>
    public enum GearState
    {
        NotEnforced,  // 이 판정에서 단속하지 않은 장비
        Worn,         // 단속 대상 + 위반 없음 = 착용
        Missing       // 단속 대상 + 위반 있음 = 미착용
    }

    /// <summary>
    /// detected_at + area_id + person_id + is_checked 가 같은 위반 row 들을
    /// 하나로 묶은 그룹. 카드/상세보기의 단위가 된다.
    ///
    /// [방식 B] 각 위반 row 가 그 판정 시점의 단속 목록(enforced_ppe 스냅샷)을
    /// 들고 있으므로, 그룹의 EnforcedTypes 는 이 스냅샷에서 채운다.
    /// 따라서 현재 PPE 설정과 무관하게 "그때 단속한 기준"으로 정확히 표시된다.
    /// </summary>
    public class ViolationGroup
    {
        public string DetectedAt { get; set; }      // time
        public string AreaId { get; set; }
        public string AreaName { get; set; }
        public string CameraName { get; set; }
        public string PersonId { get; set; }
        public bool IsChecked { get; set; }
        public string Status => IsChecked ? "해결" : "미해결";

        public List<string> Ids { get; set; } = new List<string>();
        public string RepresentativeId => Ids.FirstOrDefault();
        public Image Image { get; set; }

        // 미착용한 장비 type 집합 (no_helmet 등)
        public HashSet<string> MissingTypes { get; set; } = new HashSet<string>();

        // 이 판정에서 단속한 장비 코드 집합 (enforced_ppe 스냅샷 기반).
        // null 이면 "스냅샷 정보 없음"(구버전 데이터 등) → 전부 단속한 것으로 간주(폴백).
        public HashSet<string> EnforcedTypes { get; set; } = null;

        // --- 3-상태 판정 ---
        private bool IsEnforced(string typeCode)
        {
            if (EnforcedTypes == null) return true;        // 스냅샷 없으면 단속한다고 가정
            return EnforcedTypes.Contains(typeCode);
        }

        private GearState StateOf(string typeCode)
        {
            if (!IsEnforced(typeCode)) return GearState.NotEnforced;
            return MissingTypes.Contains(typeCode) ? GearState.Missing : GearState.Worn;
        }

        public GearState HelmetState => StateOf("no_helmet");
        public GearState MaskState   => StateOf("no_mask");
        public GearState GloveLState => StateOf("no_glove_left");
        public GearState GloveRState => StateOf("no_glove_right");

        // (하위호환) bool — true=착용/단속안함, false=미착용
        public bool HelmetWorn => HelmetState != GearState.Missing;
        public bool MaskWorn   => MaskState   != GearState.Missing;
        public bool GloveLWorn => GloveLState != GearState.Missing;
        public bool GloveRWorn => GloveRState != GearState.Missing;

        // 미착용 장비 요약 텍스트 (Missing 인 것만)
        public string MissingSummary
        {
            get
            {
                var names = new List<string>();
                if (HelmetState == GearState.Missing) names.Add("안전모");
                if (MaskState == GearState.Missing) names.Add("마스크");
                if (GloveLState == GearState.Missing) names.Add("왼손장갑");
                if (GloveRState == GearState.Missing) names.Add("오른손장갑");
                return names.Count == 0 ? "위반 없음" : string.Join(", ", names) + " 미착용";
            }
        }

        /// <summary>"no_helmet,no_mask,..." 스냅샷 문자열 → 코드 집합.</summary>
        public static HashSet<string> ParseEnforcedSnapshot(string snapshot)
        {
            var set = new HashSet<string>();
            if (string.IsNullOrWhiteSpace(snapshot)) return null;  // 빈 값 = 정보 없음
            foreach (var raw in snapshot.Split(','))
            {
                var c = (raw ?? "").Trim().ToLowerInvariant();
                if (c == "no_helmet" || c == "no_mask" ||
                    c == "no_glove_left" || c == "no_glove_right")
                    set.Add(c);
            }
            return set.Count > 0 ? set : null;
        }

        /// <summary>
        /// AlterDataClass 리스트를 4-키 기준으로 그룹핑.
        /// 각 row 의 enforced_ppe 스냅샷으로 EnforcedTypes 를 채운다.
        /// (같은 판정의 row 들은 스냅샷이 동일하므로 첫 row 의 것을 사용)
        /// </summary>
        public static List<ViolationGroup> BuildGroups(IEnumerable<AlterDataClass> rows)
        {
            var groups = new List<ViolationGroup>();
            if (rows == null) return groups;

            var grouped = rows
                .Where(r => r != null)
                .GroupBy(r => string.Join("|",
                    (r.Time ?? "").Trim(),
                    (r.Area?.AreaId?.ToString() ?? "").Trim(),
                    (r.Uid ?? "").Trim(),
                    r.IsChecked));

            foreach (var g in grouped)
            {
                var first = g.First();
                var vg = new ViolationGroup
                {
                    DetectedAt = first.Time,
                    AreaId = first.Area?.AreaId?.ToString(),
                    AreaName = first.Area?.AreaName,
                    CameraName = first.Cam,
                    PersonId = first.Uid,
                    IsChecked = first.IsChecked == 1,
                };

                // 스냅샷: 그룹 내 row 중 비어있지 않은 첫 스냅샷 사용
                foreach (var r in g)
                {
                    var parsed = ParseEnforcedSnapshot(r.EnforcedPpe);
                    if (parsed != null) { vg.EnforcedTypes = parsed; break; }
                }

                foreach (var r in g)
                {
                    if (!string.IsNullOrEmpty(r.Id)) vg.Ids.Add(r.Id);
                    var t = (r.Type ?? "").Trim().ToLowerInvariant();
                    if (!string.IsNullOrEmpty(t)) vg.MissingTypes.Add(t);
                }
                groups.Add(vg);
            }

            return groups
                .OrderByDescending(vg =>
                {
                    DateTime dt;
                    return DateTime.TryParse(vg.DetectedAt, out dt) ? dt : DateTime.MinValue;
                })
                .ToList();
        }
    }
}