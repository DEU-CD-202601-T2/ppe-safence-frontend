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
        //스트리밍 URL 조회
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

        //필터링된 위반 내역 조회
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
        public static async Task<bool> ResolveViolationAsync(string alertId, string adminId, string memo)
        {
            try
            {
                SetAuthHeader();
                var data = new {
                    status = "해결",
                    admin_id = adminId,
                    resolve_memo = memo
                };
                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"{BaseUrl}/api/violations/{alertId}/resolve")
                {
                    Content = content
                };
                var response = await client.SendAsync(request);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"해결 처리 오류: {ex.Message}");
                return false;
            }
        }

        public static async Task<List<AlterDataClass>> GetViolationsAsync(string area = null, string status = null)
        {
            try
            {
                SetAuthHeader();
                string url = $"{BaseUrl}/api/violations?";
                if (!string.IsNullOrEmpty(area)) url += $"area={Uri.EscapeDataString(area)}&";
                if (!string.IsNullOrEmpty(status)) url += $"status={Uri.EscapeDataString(status)}&";

                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<AlterDataClass>>(json) ?? new List<AlterDataClass>();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return new List<AlterDataClass>();
        }
    }
    
}

