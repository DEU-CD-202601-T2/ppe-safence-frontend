using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PPE_관제_시스템
{
    public class HistoryDto
    {
        [JsonProperty("logID")]
        public int LogID { get; set; }

        [JsonProperty("logType")]
        public string LogType { get; set; }

        [JsonProperty("user")]
        public UserDto User { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("camera")]
        public CameraDto Camera { get; set; }

        [JsonProperty("area")]
        public AreaDto Zone { get; set; }

        public string UserName =>
            User?.Name ?? "-";

        public string CameraName =>
            Camera?.Name ?? "-";

        public string ZoneName =>
            Zone?.Name ?? "-";

        public string StatusText =>
            string.IsNullOrWhiteSpace(Status)
            ? "-"
            : Status;
    }

    public class CameraDto
    {
        [JsonProperty("id")]
        public int CameraID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class AreaDto
    {
        [JsonProperty("id")]
        public int AreaID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class UserDto
    {
        [JsonProperty("id")]
        public int UserID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }

}
