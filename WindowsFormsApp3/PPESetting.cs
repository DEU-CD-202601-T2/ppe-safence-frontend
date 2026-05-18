using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PPE_관제_시스템
{
    public class PPESetting
    {
        public int ZoneID { get; set; }

        public string ZoneName { get; set; }

        public List<string> RequiredPPE { get; set; }
    }

    public class PpeSettingRequest
    {
        public int ZoneID { get; set; }

        public List<string> RequiredPPE { get; set; }
    }

    public class ZoneItem
    {
        [JsonProperty("zoneID")]
        public int ZoneID { get; set; }
        
        [JsonProperty("zone_name")]
        public string ZoneName { get; set; }
    }
}
