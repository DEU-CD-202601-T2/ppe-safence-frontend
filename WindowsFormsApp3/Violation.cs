using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_관제_시스템
{
    public class Violation
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Area { get; set; }
        public string Timestamp { get; set; }
        public string Status { get; set; }
        public string ImagePath { get; set; }
    }
}
