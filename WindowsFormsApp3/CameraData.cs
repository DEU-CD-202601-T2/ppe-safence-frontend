using System.Collections.Generic;

namespace PPE_관제_시스템
{
    public class CameraData
    {
        public ZoneData area { get; set; }   // null이면 미할당 카메라
        public string key { get; set; }
        public string name { get; set; }
        public string url { get; set; }

        public override string ToString() => name;
    }

    public class StreamUrlsResponse
    {
        public List<CameraData> cameras { get; set; }
        public List<string> offline_areas { get; set; }
        public int offline_count { get; set; }
        public int online_count { get; set; }
        public string status { get; set; }
    }
}