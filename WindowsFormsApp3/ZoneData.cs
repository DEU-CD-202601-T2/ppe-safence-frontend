using Newtonsoft.Json;
using System.Collections.Generic;

namespace PPE_관제_시스템
{
    public class ZoneData
    {
        [JsonProperty("area_id")]
        public int id { get; set; }

        [JsonProperty("area_name")]
        public string name { get; set; }

        [JsonProperty("area_code")]
        public string area_code { get; set; }

        [JsonProperty("camera_key")]
        public string camera_key { get; set; }

        [JsonProperty("camera_name")]
        public string camera_name { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("risk_level")]
        public string risk_level { get; set; }

        [JsonProperty("is_active")]
        public bool is_active { get; set; }
    }

    public class ZoneListResponse
    {
        [JsonProperty("areas")]
        public List<ZoneData> areas { get; set; }
    }
}