using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PPE_관제_시스템;

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

        //스트리밍 URL 조회
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
                Console.WriteLine(ex.Message);
                return new List<AlterDataClass>();
            }
        }
        public static async Task<bool> ResolveViolationAsync(string alertId, string adminId, string memo)
        {
            try
            {
                SetAuthHeader();
                var data = new { status = "해결",
                    admin_id = adminId,
                    memo = memo };
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"{BaseUrl}/api/alarms/{alertId}")
                {
                    Content = content
                };
                var response = await client.SendAsync(request);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"알람 처리 실패: {ex.Message}");
                return false;
            }
        }

        public static async Task<List<HistoryDto>> LoadHistoryLog() // 이력 / 로그 데이터를 API에서 불러오는 메서드
        {
            try
            {
                SetAuthHeader();

                var response =
                    await client.GetAsync($"{BaseUrl}/api/logs");

                var json =
                    await response.Content.ReadAsStringAsync();

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

        public static async Task<AnalysisDashboardStats> GetDashboardStatsAsync(string range) // 대시보드 통계 데이터 조회 API 호출
        {
            try
            {
                SetAuthHeader();

                var response =
                    await client.GetAsync(
                        $"{BaseUrl}/api/analysis/summary?range={range}");

                if (response.IsSuccessStatusCode)
                {
                    var json =
                        await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<AnalysisDashboardStats>(json);
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        public static async Task<ChartDataResponse> GetChartDataAsync(string range) // 차트 데이터 조회 API 호출
        {
            try
            {
                SetAuthHeader();

                var response =
                    await client.GetAsync(
                        $"{BaseUrl}/api/analysis/chart?range={range}"
                    );

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<ChartDataResponse>(json);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"차트 데이터 로드 실패: {ex.Message}");
                return null;
            }
        }

        // ========================================
        // PPE 기준 설정 API 호출 메서드들
        // ========================================

        public static async Task<List<PPESetting>> GetPpeSettingAsync() // PPE 기준 설정 조회 API 호출
        {
            SetAuthHeader();
            HttpResponseMessage response =
                await client.GetAsync($"{BaseUrl}/api/ppe-standards");

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<PPESetting>>(json);
        }

        public static async Task<bool> SavePpeSettingAsync(PpeSettingRequest request) // PPE 기준 설정 저장 API 호출
        {
            SetAuthHeader();
            string json = JsonConvert.SerializeObject(request);

            StringContent content =
                new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response =
                await client.PostAsync($"{BaseUrl}/api/ppe-standards", content);

            return response.IsSuccessStatusCode;
        }

        public static async Task<List<ZoneItem>> GetPPEZoneListAsync() // PPE 기준 설정에서 구역 목록 조회 API 호출
        {
            SetAuthHeader();
            HttpResponseMessage response =
                await client.GetAsync($"{BaseUrl}/api/ppe-zones");

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<ZoneItem>>(json);
        }

        // ========================================
        // 알림 관리 API 호출 메서드들
        // ========================================

        // ========================================
        // 사용자 관리 API 호출 메서드들
        // ========================================
        public static async Task<List<UserData>> GetUsersAsync() // 사용자 목록 조회 API 호출
        {
            try
            {
                SetAuthHeader();
                var response = await client.GetAsync($"{BaseUrl}/api/users");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<UserData>>(json);
                }
                return new List<UserData>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"사용자 목록 로드 실패: {ex.Message}");
                return new List<UserData>();
            }
        }

        public static async Task<bool> AddUserAsync(UserData user) // 사용자 추가 API 호출
        {
            try
            {
                SetAuthHeader();
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{BaseUrl}/api/register", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"사용자 추가 실패: {ex.Message}");
                return false;
            }
        }

        public static async Task<bool> UpdateUserAsync(UserData user) // 사용자 수정 API 호출
        {
            try
            {
                SetAuthHeader();
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"{BaseUrl}/api/users/{user.userID}", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"사용자 수정 실패: {ex.Message}");
                return false;
            }
        }

        public static async Task<bool> DeleteUserAsync(int userID) // 사용자 삭제 API 호출
        {
            try
            {
                SetAuthHeader();
                var response =
                    await client.DeleteAsync($"{BaseUrl}/api/users/{userID}");

                string result =
                    await response.Content.ReadAsStringAsync();

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return false;
            }
        }

        // ========================================
        // 구역 관리 API 호출 메서드들
        // ========================================
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
                return new List<AlterDataClass>();
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                return new List<AlterDataClass>();
            }
            
        }
    }
}