using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PPE_관제_시스템;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PPE_관제_시스템
{
    public static class ApiService
    {
        private static readonly HttpClient client = new HttpClient();
        private const string BaseUrl = "http://43.200.27.117:5002";

        private static void SetAuthHeader()
        {
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue(
                    "Bearer",
                    UserContext.JwtToken
                );
        }

        public static async Task<bool> LoginAsync(string id, string password)
        {
            try
            {
                var loginData = new { login_id = id, password = password };
                string json = JsonConvert.SerializeObject(loginData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{BaseUrl}/api/login", content);
                if(response.IsSuccessStatusCode)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();
                    var result = JObject.Parse(responseJson);

                    UserContext.JwtToken = result["token"]?.ToString();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($" 실패: {ex.Message}");
                return false;
            }
        }
        
        //스트리밍 URL 조회와 카메라 수 조회API
        public static async Task<CameraInfo> GetCameraStreamInfoAsync() // 카메라 스트리밍 URL과 카메라 수 조회
        {
            try
            {
                SetAuthHeader();
                var response =
                await client.GetAsync($"{BaseUrl}/stream-urls");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var result = JObject.Parse(json);
                    return new CameraInfo
                    {
                        Url = result["url"]?.ToString(),
                        Count = result["count"]?.ToObject<int>() ?? 1
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"카메라 정보 조회 실패: {ex.Message}");
                return null;
            }
        }

        //알람 목록 조회
        public static async Task<List<AlterDataClass>> GetViolationsAsync()
        {
            try
            {
                SetAuthHeader();
                var response = await client.GetAsync($"{BaseUrl}/api/alarms?");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<AlterDataClass>>(json) ?? new List<AlterDataClass>();
                }
                return new List<AlterDataClass>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"알람 목록 조회 실패 : {ex.Message}");
                return new List<AlterDataClass>();
            }
        }
        public static async Task<bool> ResolveViolationAsync(string alertId, string adminId, string memo)
        {
            try
            {
                string url = $"{BaseUrl}/api/alarms/{alertId}";
                SetAuthHeader();

                var data = new { 
                    status = "해결",
                };
                
                string json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(new HttpMethod("PATCH"), url)
                {
                    Content = content
                };
                HttpResponseMessage response = await client.SendAsync(request);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"알람 처리 실패: {ex.Message}");
                return false;
            }
        }

        public static async Task<List<WorkerControlDto>> GetControlWorkerAsync()
        {
            try
            {
                SetAuthHeader();
                var response = await client.GetAsync($"{BaseUrl}/api/control/workers");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<WorkerControlDto>>(json) ?? new List<WorkerControlDto>();
                }
                return new List<WorkerControlDto>();

            }
            catch (Exception ex)
            {
                return new List<WorkerControlDto>();
            }
        }

        public static async Task<bool>ResumeWorkerAsync(List<string> workerIds)
        {
            if(workerIds == null || workerIds.Count == 0) return false;
            try
            {
                SetAuthHeader();
                string url = $"{BaseUrl}/api/control/workers/resume";

                var requestBody = new { workerIds = workerIds };
                string json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(new HttpMethod("PATCH"), url)
                {
                    Content = content
                };
                HttpResponseMessage response = await client.SendAsync(request);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"워커 재개 실패: {ex.Message}");
                return false;
            }
        }
        //위반 관리 구역 필터 api
        public static async Task<List<AlterDataClass>> GetViolationsAsync(string area = null, string status = null)
        {
            try
            {
                SetAuthHeader();
                string url = $"{BaseUrl}/api/violations";
                List<string> queryParams = new List<string>();
                if (!string.IsNullOrEmpty(area) && area != "전체") queryParams.Add($"area={Uri.EscapeDataString(area)}");
                if (!string.IsNullOrEmpty(status) && status != "전체") queryParams.Add($"status={Uri.EscapeDataString(status)}");
                if (queryParams.Count > 0)
                {
                    url += "?" + string.Join("&", queryParams);
                }
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<AlterDataClass>>(json) ?? new List<AlterDataClass>();
                }
                return new List<AlterDataClass>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"위반 내역 조회 실패: {ex.Message}");
                return new List<AlterDataClass>();
            }
        }
        //위반 이미지 조회 API
        public static async Task<Image> GetVioationImageAsync(string filename)
        {
            try
            {
                SetAuthHeader();
                string url = $"{BaseUrl}/api/violations/images/{filename}";
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        return Image.FromStream(stream);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"카메라 이미지 조회 실패: {ex.Message}");
                return null;
            }
        }

       

        public static async Task<List<HistoryDto>> LoadHistoryLog() // 이력 / 로그 데이터를 API에서 불러오는 메서드
        {
            try
            {
                SetAuthHeader();

                var response = await client.GetAsync($"{BaseUrl}/api/logs");

                var json = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<HistoryDto>>(json)
                           ?? new List<HistoryDto>();
                }

                Console.WriteLine(
                    $"이력 로그 조회 실패: {(int)response.StatusCode}");

                Console.WriteLine(json);

                return new List<HistoryDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"이력 로그 조회 실패: {ex}");

                return new List<HistoryDto>();
            }
        }

        public static async Task<List<ZoneData>> GetZonesAsync() // 구역 목록 조회 API 호출
        {
            try
            {
                SetAuthHeader();
                var response = await client.GetAsync($"{BaseUrl}/api/areas?include_inactive=true");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = Newtonsoft.Json.Linq.JObject.Parse(json);
                    var areasJson = result["areas"]?.ToString();

                    if (!string.IsNullOrEmpty(areasJson))
                    {
                        return JsonConvert.DeserializeObject<List<ZoneData>>(areasJson);
                    }
                }
                return new List<ZoneData>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"구역 목록 로드 실패: {ex.Message}");
                return new List<ZoneData>();
            }
        }

        public static async Task<bool> AddZoneAsync(ZoneData zone) // 구역 추가 API 호출
        {
            try
            {
                SetAuthHeader();
                var json = JsonConvert.SerializeObject(zone);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{BaseUrl}/api/areas", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"구역 추가 실패: {ex.Message}");
                return false;
            }
        }

        public static async Task<bool> UpdateZoneAsync(int zoneId, ZoneData zone) // 구역 수정 API 호출
        {
            try
            {
                SetAuthHeader();
                var json = JsonConvert.SerializeObject(zone);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"{BaseUrl}/api/areas/{zoneId}", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"구역 수정 실패: {ex.Message}");
                return false;
            }
        }

        public static async Task<bool> DeleteZoneAsync(int zoneId) // 구역 삭제 API 호출
        {
            try
            {
                SetAuthHeader();
                var response = await client.DeleteAsync($"{BaseUrl}/api/areas/{zoneId}?hard=true");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"구역 삭제 실패: {ex.Message}");
                return false;
            }
        }

        public static async Task<List<string>> GetAreaAsync()
        {
            try
            {
                SetAuthHeader();
                var response = await client.GetAsync($"{BaseUrl}/api/areas");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();   
                    return JsonConvert.DeserializeObject<List<string>>(json) ?? new List<string>();
                }
                return new List<string>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"구역 목록 로드 실패: {ex.Message}");
                return new List<string>();
            }
        }


        public static async Task<bool> LogoutAsync()
        {
            try
            {
                SetAuthHeader();
                var response = await client.GetAsync($"{BaseUrl}/api/logout");
                if (response.IsSuccessStatusCode)
                {
                    client.DefaultRequestHeaders.Authorization = null;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"로그아웃 실패: {ex.Message}");
                return false;
            }
        } 
       
    }
}