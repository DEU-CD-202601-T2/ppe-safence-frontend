using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PPE_관제_시스템
{
    /// <summary>
    /// detected_at + area_id + person_id + is_checked 가 같은 위반 row 들을
    /// 하나로 묶은 그룹. 카드/상세보기의 단위가 된다.
    /// 그룹 안의 여러 violation_type = 미착용 장비 목록.
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

        // 그룹에 속한 모든 위반 id (해결/삭제 시 전부 처리)
        public List<string> Ids { get; set; } = new List<string>();

        // 대표 이미지 (그룹 첫 row 의 id 로 로딩)
        public string RepresentativeId => Ids.FirstOrDefault();
        public Image Image { get; set; }

        // 미착용한 장비 type 집합 (no_helmet 등)
        public HashSet<string> MissingTypes { get; set; } = new HashSet<string>();

        // 4대 장비 착용 여부 (true = 착용, false = 미착용)
        public bool HelmetWorn   => !MissingTypes.Contains("no_helmet");
        public bool MaskWorn     => !MissingTypes.Contains("no_mask");
        public bool GloveLWorn   => !MissingTypes.Contains("no_glove_left");
        public bool GloveRWorn   => !MissingTypes.Contains("no_glove_right");

        // 미착용 장비 요약 텍스트 (카드 제목용)
        public string MissingSummary
        {
            get
            {
                var names = new List<string>();
                if (!HelmetWorn) names.Add("안전모");
                if (!MaskWorn) names.Add("마스크");
                if (!GloveLWorn) names.Add("왼손장갑");
                if (!GloveRWorn) names.Add("오른손장갑");
                return names.Count == 0 ? "위반 없음" : string.Join(", ", names) + " 미착용";
            }
        }

        /// <summary>
        /// AlterDataClass 리스트를 4-키 기준으로 그룹핑.
        /// 최신 detected_at 순으로 정렬해서 반환.
        /// </summary>
        public static List<ViolationGroup> BuildGroups(IEnumerable<AlterDataClass> rows)
        {
            var groups = new List<ViolationGroup>();
            if (rows == null) return groups;

            // 4-키로 그룹핑 (area_id 는 AreaInfo.AreaId, is_checked 는 IsChecked)
            var grouped = rows
                .Where(r => r != null)
                .GroupBy(r => string.Join("|",
                    (r.Time ?? "").Trim(),
                    (r.Area?.AreaId ?? "").Trim(),
                    (r.Uid ?? "").Trim(),
                    r.IsChecked));

            foreach (var g in grouped)
            {
                var first = g.First();
                var vg = new ViolationGroup
                {
                    DetectedAt = first.Time,
                    AreaId = first.Area?.AreaId,
                    AreaName = first.Area?.AreaName,
                    CameraName = first.Cam,
                    PersonId = first.Uid,
                    IsChecked = first.IsChecked == 1,
                };
                foreach (var r in g)
                {
                    if (!string.IsNullOrEmpty(r.Id)) vg.Ids.Add(r.Id);
                    var t = (r.Type ?? "").Trim().ToLowerInvariant();
                    if (!string.IsNullOrEmpty(t)) vg.MissingTypes.Add(t);
                }
                groups.Add(vg);
            }

            // 최신순 정렬
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