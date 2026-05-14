using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PPE_관제_시스템
{
        public class AlterDataClass
        {
            [JsonProperty("id")]
            public string Id { get; set; }
            [JsonProperty("type")]
            public string Type { get; set; }
            [JsonProperty("uid")]
            public string Uid { get; set; }
            [JsonProperty("status")]
            public string Status { get; set; }
            [JsonProperty("time")]
            public string Time { get; set; }
            [JsonProperty("zone")]
            public string Zone { get; set; }
            [JsonProperty("cam")]
            public string Cam { get; set; }
            [JsonIgnore]
            public Image Img { get; set; }

        public AlterDataClass() { }

        public AlterDataClass(string id, string uid, string type, string time, string zone, string cam, string status, Image img = null)
        {
            Id = id;
            Uid = uid;
            Type = type;
            Time = time;
            Zone = zone;
            Cam = cam;
            Status = status;
            Img = img;
        }
    }
}
