using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_관제_시스템
{
    public class AnalysisDashboardStats
    {
        [JsonProperty("총 작업자 수")]
        public int TotalWorkersCount { get; set; }
        [JsonProperty("PPE 준수율")]
        public int PPEComplianceRate { get; set; }
        [JsonProperty("사고 발생 수")]
        public int TotalAccidentCount { get; set; }
        [JsonProperty("경고 발생 수")]
        public int TotalWarningCount { get; set; }
    }
}
