using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_관제_시스템
{
    public class ChartData
    {
        [JsonProperty("PPE 준수율 추이")]
        public List<string> ComplianceTrend { get; set; }

        [JsonProperty("구역별 위반 현황")]
        public Dictionary<string, int> ZoneViolations { get; set; }

        [JsonProperty("시계열")]
        public List<string> Timeline { get; set; }

        [JsonProperty("위반 건수 추이")]
        public List<int> ViolationTrend { get; set; }
    }

    public class ChartDataResponse
    {
        [JsonProperty("선택된 범위")]
        public string SelectedRange { get; set; }

        [JsonProperty("차트 데이터")]
        public ChartData ChartData { get; set; }
    }
}
