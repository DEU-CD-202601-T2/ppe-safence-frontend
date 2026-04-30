using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_관제_시스템
{
    public class AlterDataClass
    {
        public string ID { get; set; }
        public string Type { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public Image Img { get; set; }

        public AlterDataClass() { }

        public AlterDataClass(string id, string type, string time, string location, string status, Image img = null)
        {
            ID = id;
            Type = type;
            Time = time;
            Location = location;
            Status = status;
            Img = img;
        }
    }
}
