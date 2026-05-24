using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PPE_관제_시스템
{
    public class AlertSettingDto
    {
        [JsonProperty("alert_type")]
        public string AlertType { get; set; }

        [JsonProperty("use_alert")]
        public bool IsEnabled { get; set; }

        [JsonProperty("send_to_admin")]
        public bool SendToAdmin { get; set; }

        [JsonProperty("repeat_interval")]
        public int? RepeatInterval { get; set; }

        [JsonProperty("min_risk_level")]
        public string MinRiskLevel { get; set; }

        [JsonProperty("stop_work_linkage")]
        public bool StopWorkOnViolation { get; set; }
    }

    public class ResetAlertSettingResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("settings")]
        public List<AlertSettingDto> Settings { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
