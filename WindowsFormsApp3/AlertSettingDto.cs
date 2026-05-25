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

    public class AlertSettingResponse
    {
        [JsonProperty("alert_type")]
        public Dictionary<string, AlertTypeDetail> AlertType { get; set; }

        [JsonProperty("send_to_admin")]
        public bool SendToAdmin { get; set; }

        [JsonProperty("stop_work_linkage")]
        public bool StopWorkOnViolation { get; set; }

        [JsonProperty("use_vibration")]
        public bool UseVibration { get; set; }
    }

    public class AlertTypeDetail
    {
        [JsonProperty("alert_interval")]
        public int AlertInterval { get; set; }

        [JsonProperty("repeat_interval")]
        public int? RepeatInterval { get; set; }

        [JsonProperty("use_alert")]
        public bool UseAlert { get; set; }

        [JsonProperty("min_risk_level")]
        public string MinRiskLevel { get; set; }
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
