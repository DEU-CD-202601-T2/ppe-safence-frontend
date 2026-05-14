using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_관제_시스템
{
    public class ZoneData
    {
        [JsonProperty("area_id")]
        public int id {  get; set; }
        [JsonProperty("area_name")]
        public string name { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("risk_level")]
        public string risk_level { get; set; }
        [JsonProperty("is_active")]
        public bool is_active { get; set; }
    }
}
