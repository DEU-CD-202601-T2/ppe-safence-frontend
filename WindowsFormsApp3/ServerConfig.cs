using System;
using System.IO;

namespace PPE_관제_시스템
{
    /// <summary>
    /// 설치 시 생성되는 server.config(실행 파일과 같은 폴더)에서
    /// API 서버 기본 주소를 읽어온다. 파일이 없거나 읽기에 실패하면
    /// DefaultBaseUrl을 사용한다.
    /// </summary>
    public static class ServerConfig
    {
        // server.config가 없을 때 사용할 기본 주소 (환경에 맞게 수정)
        private const string DefaultBaseUrl = "http://43.200.27.117:5002";

        private static string _cached;

        /// <summary>API 서버 기본 주소 (끝의 '/'는 제거됨)</summary>
        public static string BaseUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(_cached))
                    return _cached;

                try
                {
                    string path = Path.Combine(AppContext.BaseDirectory, "server.config");
                    if (File.Exists(path))
                    {
                        string url = File.ReadAllText(path).Trim();
                        if (!string.IsNullOrEmpty(url))
                        {
                            _cached = Normalize(url);
                            return _cached;
                        }
                    }
                }
                catch
                {
                    // 읽기 실패 시 기본값으로 폴백
                }

                _cached = DefaultBaseUrl;
                return _cached;
            }
        }

        /// <summary>설정 화면 등에서 주소를 바꾸고 server.config에 저장할 때 사용</summary>
        public static void Save(string url)
        {
            string path = Path.Combine(AppContext.BaseDirectory, "server.config");
            string value = Normalize(url);
            File.WriteAllText(path, value);
            _cached = value;
        }

        private static string Normalize(string url)
        {
            url = (url ?? string.Empty).Trim();
            while (url.EndsWith("/"))
                url = url.Substring(0, url.Length - 1);
            return url;
        }
    }
}