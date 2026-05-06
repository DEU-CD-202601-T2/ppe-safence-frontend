using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PPE_관제_시스템
{
    public static class ApiService
    {
        private static readonly HttpClient client = new HttpClient();
        private const string BaseUrl = "http://43.200.27.117:5000";

        private static void SetAuthHeader()
        {
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", UserContext.JwtToken);
        }

        public static async Task<CameraInfo> GetCameraStreamInfoAsync() // 카메라 스트리밍 URL과 카메라 수 조회
        {
            try
            {
                SetAuthHeader(); // 토큰 장착

                // 서버의 스트리밍 URL 조회 API 호출
                var response = await client.GetAsync($"{BaseUrl}/api/stream-urls");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var result = Newtonsoft.Json.Linq.JObject.Parse(json);

                    return new CameraInfo
                    {
                        // 서버 응답 JSON의 키값(url, count)에 맞춰 파싱
                        Url = result["url"]?.ToString(),
                        Count = result["count"]?.ToObject<int>() ?? 1
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"카메라 정보 로드 실패: {ex.Message}");
                return null;
            }
        }

        public static async Task<List<AlterDataClass>> GetViolationsAsync()
        {
            try
            {
                SetAuthHeader();
                var response = await client.GetAsync($"{BaseUrl}/api/violations");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<AlterDataClass>>(json);
                }
                return new List<AlterDataClass>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<AlterDataClass>();
            }
        }
        public static async Task<bool> ResolveViolationAsync(string alertId)
        {
            SetAuthHeader();
            var data = new { status = "해결" };
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{BaseUrl}/api/violations/{alertId}/resolve", content);
            return response.IsSuccessStatusCode;
        }
    }
    
}

