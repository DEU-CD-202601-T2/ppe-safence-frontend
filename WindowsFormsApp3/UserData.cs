using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_관제_시스템
{
    internal class UserData
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string Role { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public static string JwtToken { get; set; } // JWT 토큰을 저장하는 정적 속성
    }
}
