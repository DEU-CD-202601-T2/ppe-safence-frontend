using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_관제_시스템
{
    public class DataManager
    {
        private static readonly object _lock = new object();
        public static List<AlterDataClass> AllAlerts = new List<AlterDataClass>();
        public static event Action OnDataChanged;
        public static int CurrentPage = 0;
        public static int PageSize = 10;
        public static void NotifyDataChanged()
        {
            OnDataChanged?.Invoke();
        }
        public static async Task UpdateAlertsFromServer()
        {
            try
            {
                List<AlterDataClass> serverData = await ApiService.GetViolationsAsync();
                if (serverData != null)
                {
                    lock (_lock)
                    {

                        AllAlerts = serverData;
                    }
                    NotifyDataChanged();
                }   
            }
            catch(Exception ex)
            {
                Console.WriteLine("서버 데이터 동기화 중 오류 발생");
            }
        }
        public static void AddAlert(string type, string zone, string cam, string uid)
        {
            Task.Run(async () => await UpdateAlertsFromServer());
        }

        public static void AddAlert(string alertId)
        {
            ResolveAlert(alertId, "admin", "빠른 해결 조치");
        }

        public static void ResolveAlert(string alertId, string adminId, string memo)
        {
            lock (_lock)
            {
                var target = AllAlerts.FirstOrDefault(a => a.Id?.Trim() == alertId.Trim());
                if (target != null)
                {
                    target.Status = "해결";
                    target.AdminId = adminId;
                    target.Memo = memo;
                    NotifyDataChanged();
                }
            }
        }
            public static void InitTestData()
            {
                _ = UpdateAlertsFromServer();
            }

        public class AlertSettingsData
        {
            public string AlertType { get; set; }
        }
    }
}
