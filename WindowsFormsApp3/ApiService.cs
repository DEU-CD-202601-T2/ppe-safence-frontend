using System.Diagnostics;
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
using System.Windows.Forms;


namespace PPE_관제_시스템
{
    public static class ApiService
    {
        private static readonly HttpClient client = new HttpClient();
        private const string BaseUrl = "http://43.200.27.117:5002";

        private static void SetAuthHeader()
        {
            if(string.IsNullOrEmpty(UserContext.JwtToken))
            {
                throw new InvalidOperationException("JWT 토큰이 설정되지 않았습니다. 로그인 후 다시 시도해주세요.");
            }
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",
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
                if (response.IsSuccessStatusCode)
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
        public static async Task<StreamUrlsResponse> GetStreamUrlsAsync()
        {
            try
            {
                SetAuthHeader();

                var response = await client.GetAsync($"{BaseUrl}/api/stream-urls").ConfigureAwait(false);
                string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                Console.WriteLine($"stream-urls 응답 코드: {(int)response.StatusCode}");
                Console.WriteLine(json);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                // offline_areas가 객체 배열로 내려와도 전체 역직렬화가 실패하지 않도록
                // 화면 표시와 스트리밍에 필요한 cameras, online_count만 안전하게 직접 파싱한다.
                JObject root = JObject.Parse(json);

                return new StreamUrlsResponse
                {
                    cameras = root["cameras"]?.ToObject<List<CameraData>>() ?? new List<CameraData>(),
                    online_count = root["online_count"]?.Value<int>() ?? 0
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"스트림 URL 조회 실패: {ex.Message}");
                return null;
            }
        }

        //실시간 알람 목록 전체 조회
        public static async Task<List<AlterDataClass>> GetAlarmsAsync()
        {
            try
            {
                SetAuthHeader();
                string url = $"{BaseUrl}/api/alarms";

                HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
                string jsonResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                // ==========================================================
                // 🔥 [여기 추가]: 알람 API가 주는 날것의 원본을 무조건 팝업으로 띄웁니다!
                System.Windows.Forms.MessageBox.Show(
                    $"상태 코드: {(int)response.StatusCode}\n\n" +
                    $"[알람 데이터 원본 구조]:\n{jsonResponse}",
                    "알람 세션 리얼 데이터 확인"
                );
                // ==========================================================
                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<AlterDataClass>>(jsonResponse);
                    return result ?? new List<AlterDataClass>();
                }
                Console.WriteLine((int)response.StatusCode);
                return new List<AlterDataClass>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"알람 처리 실패: {ex.Message}");
                return new List<AlterDataClass>();
            }
        }

        public static async Task<bool> ResolveViolationAsync(string alarmId, string adminId, string memo, int isChecked)
        {
            try
            {
                SetAuthHeader();
                string url = $"{BaseUrl}/api/alarms/{alarmId}";

                var patchData = new
                {
                    is_checked = isChecked,
                    admin_id = adminId,
                    resolution_memo = memo,
                    status = "해결"
                };

                string jsonPayload = JsonConvert.SerializeObject(patchData);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

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

        public static async Task<List<WorkerInfo>> GetControlWorkerAsync() // 관제 작업자 목록 조회 API 호출
        {
            try
            {
                SetAuthHeader();
                var response = await client.GetAsync($"{BaseUrl}/api/control/workers");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<WorkerInfo>>(json) ?? new List<WorkerInfo>();
                }
                return new List<WorkerInfo>();

            }
            catch (Exception ex)
            {
                return new List<WorkerInfo>();
            }
        }

        public static async Task<bool> ResumeWorkerAsync(List<string> workerIds) // 작업자 작업 중지 해제 API 호출
        {
            if (workerIds == null || workerIds.Count == 0) return false;
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
        //기간별 이력 검색 목록 조회(GET)
        public static async Task<List<AlterDataClass>> GetViolationsAsync()
        {
            try
            {
                SetAuthHeader();
                string url = $"{BaseUrl}/api/violations";
                HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
                string jsonResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<AlterDataClass>>(jsonResponse);
                    return result ?? new List<AlterDataClass>();
                }
                return new List<AlterDataClass>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"위반 내역 조회 실패: {ex.Message}");
                return new List<AlterDataClass>();
            }
        }

        //위반 관리 구역 및 상태 필터 조회 (GET)
        public static async Task<List<AlterDataClass>> GetViolationsAsync(string startDate = null, string endDate=null,string areaId = null, string violationType = null)
        {
            try
            {
                SetAuthHeader();

                string url = $"{BaseUrl}/api/violations";
                List<string> queryParams = new List<string>();
                if (!string.IsNullOrEmpty(startDate)) queryParams.Add($"start_date={startDate}");
                if (!string.IsNullOrEmpty(endDate)) queryParams.Add($"end_date={endDate}");
                if (!string.IsNullOrEmpty(areaId) && areaId != "전체") queryParams.Add($"area_id={areaId}");
                if (!string.IsNullOrEmpty(violationType) && violationType != "전체") queryParams.Add($"violation_type={violationType}");
                if (queryParams.Count > 0)
                {
                    url += "?" + string.Join("&", queryParams);
                }

                HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
                string jsonResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<AlterDataClass>>(jsonResponse);
                    return result ?? new List<AlterDataClass>();
                }
                return new List<AlterDataClass>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"위반 내역 필터 조회 실패: {ex.Message}");
                return new List<AlterDataClass>();
            }
        }

        //실시간 모니터링 대시보드용 위반 기록 조회 API
        public static async Task<List<LiveViolationRecord>> GetLiveViolationsAsync()
        {
            try
            {
                SetAuthHeader();

                var response = await client.GetAsync($"{BaseUrl}/api/violations").ConfigureAwait(false);
                string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                Console.WriteLine($"violations 응답 코드: {(int)response.StatusCode}");
                Console.WriteLine(json);

                if (!response.IsSuccessStatusCode)
                {
                    return new List<LiveViolationRecord>();
                }

                return JsonConvert.DeserializeObject<List<LiveViolationRecord>>(json) ?? new List<LiveViolationRecord>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"실시간 모니터링 위반 기록 조회 실패: {ex.Message}");
                return new List<LiveViolationRecord>();
            }
        }

        //위반 이미지 조회 API(GET)   
        public static async Task<Image> GetViolationImageAsync(string violationId)
        {
            try
            {
                SetAuthHeader();
                string url = $"{BaseUrl}/api/violations/{violationId}/image";
                HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    byte[] imageBytes = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            return Image.FromStream(ms);
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"위반 증거 이미지 조회 실패: {ex.Message}");
                return null;
            }
        }

        // ========================================
        // 대응/제어 관리 API 호출 메서드들
        // ========================================

        public static async Task<ControlSummary> GetControlSummaryAsync() // 대응/제어 요약 정보 조회 API 호출
        {
            try
            {
                SetAuthHeader();

                var response = await client.GetAsync($"{BaseUrl}/api/control/summary");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ControlSummary>(json);
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"관제 요약 정보 조회 실패: {ex.Message}");
                return null;
            }
        }

        public static async Task<bool> ResumeWorkersAsync(List<string> workerIds) // 작업자 작업 중지 해제 API 호출
        {
            try
            {
                SetAuthHeader();
                var requestBody = new ResumeWorkerRequest
                {
                    Status = "작업 중",
                    WorkerIds = workerIds
                };

                var json = JsonConvert.SerializeObject(requestBody);

                var content = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

                var request = new HttpRequestMessage(
                    new HttpMethod("PATCH"),
                    $"{BaseUrl}/api/control/workers/resume");

                request.Content = content;

                var response = await client.SendAsync(request);

                response.EnsureSuccessStatusCode();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"작업 중지 해제 실패\n{ex.Message}");
                return false;
            }
        }

        public static async Task<List<WorkerInfo>> GetWorkerInfosAsync() // 작업자 목록 데이터를 API에서 불러오는 메서드
        {
            try
            {
                SetAuthHeader();
                var response = await client.GetAsync($"{BaseUrl}/api/control/workers");

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<WorkerInfo>>(json)
                       ?? new List<WorkerInfo>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"작업자 목록 조회 실패\n{ex.Message}");
                return new List<WorkerInfo>();
            }
        }

        // ========================================
        // 이력/로그 관리 API 호출 메서드들
        // ========================================

        public static async Task<List<HistoryDto>> LoadHistoryLog() // 이력/로그 데이터를 API에서 불러오는 메서드
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

        // ========================================
        // 분석 대시보드 API 호출 메서드들
        // ========================================
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

        public static async Task<bool> SavePpeSettingAsync(List<PpeSettingRequest> requestList)
        {
            SetAuthHeader();

            string json = JsonConvert.SerializeObject(requestList, Formatting.Indented);

            Debug.WriteLine("[PPE-SAVE-REQ]");
            Debug.WriteLine(json);

            StringContent content =
                new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response =
                await client.PostAsync($"{BaseUrl}/api/ppe-standards", content);

            string body = await response.Content.ReadAsStringAsync();

            Debug.WriteLine($"[PPE-SAVE-RES] {(int)response.StatusCode}");
            Debug.WriteLine(body);

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

        public static async Task<List<AlertSettingDto>> GetAlertSettingAsync()
        {
            try
            {
                SetAuthHeader();
                var response = await client.GetAsync($"{BaseUrl}/api/alert-settings");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<AlertSettingResponse>(json); // ← AlertSettingResponse로 파싱

                    var list = result.AlertType.Select(x => new AlertSettingDto
                    {
                        AlertType = x.Key,
                        IsEnabled = x.Value.UseAlert,
                        MinRiskLevel = x.Value.MinRiskLevel,
                        RepeatInterval = x.Value.RepeatInterval,
                        SendToAdmin = result.SendToAdmin,
                        StopWorkOnViolation = result.StopWorkOnViolation
                    }).ToList();

                    return list;
                }
                return new List<AlertSettingDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"알림 설정 로드 실패: {ex.Message}");
                return new List<AlertSettingDto>();
            }
        }

        public static async Task<bool> SaveAlertSettingAsync(AlertSettingDto request) // 알림 설정 저장 API 호출
        {
            try
            {
                SetAuthHeader();

                string json = JsonConvert.SerializeObject(request);

                var content = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

                HttpResponseMessage response =
                    await client.PostAsync(
                        $"{BaseUrl}/api/alert-settings",
                        content);

                if (!response.IsSuccessStatusCode)
                {
                    string errorMessage =
                        await response.Content.ReadAsStringAsync();

                    throw new Exception(
                        $"API 호출 실패 ({(int)response.StatusCode}) : {errorMessage}");
                }

                return true;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(
                    $"서버 연결에 실패했습니다.\n{ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"알림 설정 저장 중 오류가 발생했습니다.\n{ex.Message}", ex);
            }
        }

        public static async Task<ResetAlertSettingResponse> ResetAlertSettingsAsync() // 알림 설정 초기화 API 호출
        {
            try
            {
                SetAuthHeader();

                HttpResponseMessage response =
                    await client.PostAsync(
                        $"{BaseUrl}/api/alert-settings/reset",
                        null);

                response.EnsureSuccessStatusCode();

                string json =
                    await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<ResetAlertSettingResponse>(json);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"알림 설정 초기화 실패\n{ex.Message}");
            }
        }

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
        public static async Task<List<ZoneData>> GetZonesAsync(bool includeInactive = true)
        {
            try
            {
                SetAuthHeader();

                string url = $"{BaseUrl}/api/areas?include_inactive={includeInactive.ToString().ToLower()}";

                var response = await client.GetAsync(url).ConfigureAwait(false);
                string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var token = JToken.Parse(json);

                    if (token.Type == JTokenType.Object && token["areas"] != null)
                    {
                        return token["areas"].ToObject<List<ZoneData>>() ?? new List<ZoneData>();
                    }

                    if (token.Type == JTokenType.Array)
                    {
                        return token.ToObject<List<ZoneData>>() ?? new List<ZoneData>();
                    }
                }

                Console.WriteLine($"구역 목록 조회 실패: {(int)response.StatusCode}");
                Console.WriteLine(json);

                return new List<ZoneData>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"구역 목록 로드 실패: {ex.Message}");
                return new List<ZoneData>();
            }
        }

        public static async Task<bool> AddZoneAsync(ZoneData zone)
        {
            try
            {
                SetAuthHeader();

                var requestBody = new
                {
                    area_name = zone.name,
                    description = zone.description,
                    risk_level = zone.risk_level,
                    is_active = zone.is_active,
                    camera_key = zone.camera_key,
                    camera_name = zone.camera_name
                };

                string json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{BaseUrl}/api/areas", content).ConfigureAwait(false);
                string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"구역 추가 실패: {(int)response.StatusCode}");
                    Console.WriteLine(result);
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"구역 추가 실패: {ex.Message}");
                return false;
            }
        }

        public static async Task<bool> UpdateZoneAsync(int zoneId, ZoneData zone)
        {
            try
            {
                SetAuthHeader();

                var requestBody = new
                {
                    area_name = zone.name,
                    description = zone.description,
                    risk_level = zone.risk_level,
                    is_active = zone.is_active,
                    camera_key = zone.camera_key,
                    camera_name = zone.camera_name
                };

                string json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"{BaseUrl}/api/areas/{zoneId}", content).ConfigureAwait(false);
                string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"구역 수정 실패: {(int)response.StatusCode}");
                    Console.WriteLine(result);
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"구역 수정 실패: {ex.Message}");
                return false;
            }
        }

        public static async Task<bool> DeleteZoneAsync(int zoneId, bool hard = true)
        {
            try
            {
                SetAuthHeader();

                string url = $"{BaseUrl}/api/areas/{zoneId}?hard={hard.ToString().ToLower()}";

                var response = await client.DeleteAsync(url).ConfigureAwait(false);
                string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"구역 삭제 실패: {(int)response.StatusCode}");
                    Console.WriteLine(result);
                }

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
                // 아예 네트워크 단절이거나 서버 포트가 닫힌 경우
                System.Windows.Forms.MessageBox.Show(
                    $"네트워크 연결 예외 발생:\n{ex.Message}",
                    "통신 물리적 에러",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Warning
                );
                return null;
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

    public class LiveViolationRecord
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("area_id")]
        public int? area_id { get; set; }

        [JsonProperty("area_name")]
        public string area_name { get; set; }

        [JsonProperty("camera_key")]
        public string camera_key { get; set; }

        [JsonProperty("detected_at")]
        public string detected_at { get; set; }

        [JsonProperty("person_id")]
        public int? person_id { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("violation_type")]
        public string violation_type { get; set; }
    }
}