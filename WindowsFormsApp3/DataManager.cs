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
        public static List<AlterDataClass> AllAlerts = new List<AlterDataClass>();
        public static event Action OnDataChanged;
        public static int CurrentPage = 0;
        public static int PageSize = 10;
        public static void NotifyDataChanged()
        {
            OnDataChanged?.Invoke();
        }
        public static void UpdateAlertsFromServer(List<AlterDataClass> serverAlerts)
        {
            if (serverAlerts == null) return;
            AllAlerts = serverAlerts;
            NotifyDataChanged();
        }
        public static void MergeServerAlerts(List<AlterDataClass> serverAletrs)
        {
            if (serverAletrs == null) return;
            bool isChanged = false;
            foreach(var serverAlert in serverAletrs)
            {
                var localAlerts = AllAlerts.FirstOrDefault(a => a.Id == serverAlert.Id);
                if(localAlerts == null)
                {
                    AllAlerts.Add(serverAlert);
                    isChanged = true;
                }
                else
                {
                    if(localAlerts.Status != serverAlert.Status)
                    {
                        localAlerts.Status = serverAlert.Status;
                        localAlerts.AdminId = serverAlert.AdminId;
                        localAlerts.Memo = serverAlert.Memo;
                        isChanged = true;
                    }
                }
            }
            if (isChanged) NotifyDataChanged();
        }

            public static void ResolveAlert(string alertId, string adminId, string memo)
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
            public static void InitTestData()
            {
                if (AllAlerts.Count == 0)
                {
                    string[] violationTypes = { "마스크 미착용", "왼쪽 장갑 미착용", "오른쪽 장갑 미착용", "보호구 미착용" };
                    string[] zones = { "A구역", "B구역", "C구역" };
                string[] cameras = { "Camera 01", "Camera 02", "Camera 03" };


                for (int i = 0; i < 25; i++)
                    {
                        string tempUid = $"u{i % 5 + 1:D3}";
                        AllAlerts.Add(new AlterDataClass
                        {
                            Id = $"{DateTime.Now:yyyyMMdd}_{100+i+1}_{tempUid}",
                            Uid = tempUid,
                            Type = violationTypes[i%4],
                            Zone = zones[i%3],
                            Cam = cameras[i%3],
                            Time = DateTime.Now.AddMinutes(-i * 5).ToString("yyyy-MM-dd HH:mm:ss"),
                            Status = "미해결"
                        });
                    }
                    NotifyDataChanged();
                }
            }

        public class AlertSettingsData
        {
            public string AlertType { get; set; }
        }
    }
}
