using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_관제_시스템
{
    public class WorkerInfo
    {
        [JsonProperty("작업자ID")]
        public int workerId { get; set; }

        [JsonProperty("이름")]
        public string name { get; set; }

        [JsonProperty("구역")]
        public string location { get; set; }

        [JsonProperty("PPE 착용 상태")]
        public string ppeStatus { get; set; }

        [JsonProperty("작업 상태")]
        public string status { get; set; }

        [JsonProperty("시간")]
        public string time { get; set; }
    }

    public class ResumeWorkerRequest
    {
        [JsonProperty("상태")]
        public string Status { get; set; }

        [JsonProperty("작업자 ID 목록")]
        public List<string> WorkerIds { get; set; }
    }
}
