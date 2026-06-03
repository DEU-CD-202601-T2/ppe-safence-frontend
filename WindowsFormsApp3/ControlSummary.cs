using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PPE_관제_시스템
{
    public class ControlSummary
    {
        [JsonProperty("PPE 미착용 인원수")]
        public int PpeNotWearingCount { get; set; }

        [JsonProperty("경고 발생 수")]
        public int WarningCount { get; set; }

        [JsonProperty("센서 상태")]
        public string SensorStatus { get; set; }
    }
}
