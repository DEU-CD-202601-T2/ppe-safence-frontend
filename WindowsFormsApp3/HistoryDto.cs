using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_관제_시스템
{
    public class HistoryDto
    {
        [JsonProperty("logID")]
        public int LogID { get; set; }

        [JsonProperty("logType")]
        public string LogType { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("user")]
        public UserDto User { get; set; }

        [JsonProperty("camera")]
        public object Camera { get; set; }

        [JsonProperty("area")]
        public object Zone { get; set; }

        public string UserName => User?.Name ?? "-";

        public string CameraName
        {
            get
            {
                if (Camera == null) return "-";
                if (Camera is string str) return str;
                if (Camera is JObject jObj) return jObj["name"]?.ToString() ?? "-";
                return "-";
            }
        }

        public string ZoneName
        {
            get
            {
                if (Zone == null) return "-";
                if (Zone is string str) return str;
                if (Zone is JObject jObj) return jObj["name"]?.ToString() ?? "-";
                return "-";
            }
        }

        public string StatusText => string.IsNullOrWhiteSpace(Status) ? "-" : Status;
    }

    public class UserDto
    {
        [JsonProperty("id")]
        public int UserID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }

}
