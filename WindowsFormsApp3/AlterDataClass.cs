using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            [JsonProperty("area")]
            public AreaInfo Area { get; set; }

            [JsonProperty("admin_id")]
            public string AdminId { get; set; }
            [JsonProperty("memo")]
            public string Memo { get; set; }
            [JsonIgnore]
                public string Zone => Area?.AreaName ?? "알 수 없음";
            [JsonIgnore]
                public string Cam => "Camera 01";
            [JsonIgnore]
                public Image Img { get; set; }

            public AlterDataClass() { }

        public AlterDataClass(string id, string uid, string type, string time, AreaInfo area, string status, Image img = null, string adminId = null, string memo = null)
        {
            Id = id;
            Uid = uid;
            Type = type;
            Time = time;
            Area = area;
            Status = status;
            AdminId = adminId;
            Memo = memo;
            Img = img;
        }
    }

    public class AreaInfo
    {
        [JsonProperty("area_id")]
        public string AreaId { get; set; }

        [JsonProperty("area_name")]
        public string AreaName { get; set; }

        [JsonProperty("area_code")]
        public string AreaCode { get; set; }

        [JsonProperty("camera_key")]
        public string CameraKey { get; set; }
    }
}
