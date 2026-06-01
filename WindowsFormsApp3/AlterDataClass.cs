using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.RightsManagement;
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
        [JsonProperty("time")]
        public string Time { get; set; }
        [JsonProperty("area")]
        public AreaInfo Area{ get; set; }
        [JsonProperty("camera_name")]
        public string Cam { get; set; }
        [JsonProperty("worker_id")]
        public string Uid { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("is_checked")]
        public int IsChecked { get; set; }
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
        [JsonProperty("Img")]
        public System.Drawing.Image Img { get; set; }
        [JsonProperty("AdminId")]
        public string AdminId { get; set; }
        [JsonProperty("Memo")]
        public string Memo { get; set; }
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

        public string DisplayType
        {
            get
            {
                if (Type == "no_helmet") return "안전모 미착용";
                if (Type == "no_mask") return "마스크 미착용";
                if (Type == "no_glove_left") return "왼쪽 장갑 미착용";
                if (Type == "no_glove_right") return "오른쪽 장갑 미착용";
                return Type;
            }
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
