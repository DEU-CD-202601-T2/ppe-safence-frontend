using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_관제_시스템
{
    public class DataManager
    {
        public static List<AlertData> AllAlerts = new List<AlertData>();
        public static event Action OnDataChanged;
        public static int CurrentPage = 0;
        public static int PageSize = 10;
        public static void NotifyDataChanged()
        {
            OnDataChanged?.Invoke();
        }
        public static void AddAlert(string type, string location)
        {
            AllAlerts.Add(new AlertData{
                    ID = $"ID-{100 + AllAlerts.Count + 1}",
                    Type = type,
                    Location = location,
                    Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Status = "미해결"
                });
                OnDataChanged?.Invoke();
                NotifyDataChanged();
            }

            public static void ResolveAlert(string alertId)
            {
                var target = AllAlerts.FirstOrDefault(a => a.ID == alertId);
                if (target != null)
                {
                    target.Status = "해결";
                    NotifyDataChanged();
                }
            }
            public static void InitTestData()
            {
                if (AllAlerts.Count == 0)
                {
                    string[] violationTypes = { "방진마스크 미착용", "안전화 미착용", "장갑 미착용", "보호구 미착용" };

                    for (int i = 0; i < 25; i++)
                    {
                        AllAlerts.Add(new AlertData
                        {
                            ID = $"ID-{100 + i + 1}",
                            Type = violationTypes[i % 4],
                            Location = $"Camera {i % 3 + 1} / {(char)('A' + i % 3)}구역",
                            Time = DateTime.Now.AddMinutes(-i * 5).ToString("yyyy-MM-dd HH:mm:ss"),
                            Status = "미해결"
                        });
                    }
                    NotifyDataChanged();
                }
            }



            public class AlertData
            {
                public string Type { get; set; }
                public string Time { get; set; }
                public string Location { get; set; }
                public string ID { get; set; }

                public string Status { get; set; }
                public System.Drawing.Image Img { get; set; }
            }
    }
}
