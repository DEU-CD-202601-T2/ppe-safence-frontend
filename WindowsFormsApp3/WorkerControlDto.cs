using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_관제_시스템
{
    public class WorkerControlDto
    {
        [JsonProperty("worker_id")]
        public string WorkerId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("zone")]
        public string Zone { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("last_violation")]
        public string LastViolation { get; set; }
    }
}
