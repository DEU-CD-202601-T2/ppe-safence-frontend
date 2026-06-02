using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PPE_관제_시스템
{
    public class AreaInfo
    {
        [JsonProperty("area_id")]
        public int? AreaId { get; set; }
        [JsonProperty("area_name")]
        public string AreaName { get; set; }
        [JsonProperty("camera_key")]
        public string CameraKey { get; set; }
        [JsonProperty("description")]
        public int Description { get; set; }
        [JsonProperty("is_active")]
        public bool? IsActive { get; set; }
        [JsonProperty("risk_level")]
        public string RiskLevel { get; set; }
    }
    public class AlterDataClass
    {
        [JsonProperty("id")]
        public int? IdRaw { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("time")]
        public string Time { get; set; }
        [JsonProperty("area_name")]
        public string AreaNameFlat { get; set; }
        [JsonProperty("camera_key")]
        public string CameraKeyFlat { get; set; }

        [JsonProperty("camera_name")]
        public string Cam { get; set; }

        [JsonProperty("worker_id")]
        public int? UidRaw { get; set; }
        [JsonProperty("person_id")]
        public int? PersonIdRaw { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("is_checked")]
        public int? IsCheckedRaw { get; set; }
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("admin_id")]
        public string AdminId { get; set; }
        [JsonProperty("resolution_memo")]
        public string Memo { get; set; }
        [JsonProperty("area")]
        public AreaInfo AreaNested { get; set; }
        [JsonIgnore]
        public string Id => IdRaw?.ToString();
        [JsonIgnore]
        public string Uid => UidRaw?.ToString();
        [JsonIgnore]
        public string PersonId => PersonIdRaw?.ToString();
        [JsonIgnore]
        public int IsChecked => IsCheckedRaw ?? 0;
        [JsonIgnore]
        public AreaInfo Area { get; set; }
        [JsonIgnore]
        public Image Img { get; set; }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            if (AreaNested != null)
                Area = AreaNested;

            else if (!string.IsNullOrEmpty(AreaNameFlat) || !string.IsNullOrEmpty(CameraKeyFlat))
            {
                Area = new AreaInfo
                {
                    AreaName = AreaNameFlat,
                    CameraKey = CameraKeyFlat
                };
            }
        }



        public string DisplayType
        {
            get
            {
                var t = Type?.Trim().ToLower();
                switch (t)
                {
                    case "no_helmet":
                        return "안전모 미착용";
                    case "no_mask":
                        return "마스크 미착용";
                    case "no_glove_left":
                        return "왼쪽 장갑 미착용";
                    case "no_glove_right":
                        return "오른쪽 장갑 미착용";
                    default:
                        return Type;
                }

            }
        }
    }
}

