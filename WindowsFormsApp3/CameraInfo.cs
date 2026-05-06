using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_관제_시스템
{
    public class CameraInfo // 카메라 정보 모델 클래스, API에서 받아오는 카메라 스트림 URL과 연결된 사람 수를 저장
    {
        public string Url { get; set; }
        public int Count { get; set; }
    }
}
