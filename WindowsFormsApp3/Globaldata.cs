using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_관제_시스템
{
    public static class UserContext
    {
        public static string JwtToken { get; set; }
        public static string CurrentLoginId { get; set; }
        public static string ApiBaseUrl => ServerConfig.BaseUrl;
    }
    
}