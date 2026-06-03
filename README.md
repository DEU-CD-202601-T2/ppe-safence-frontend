# PPE-Safence 관제 프로그램 (Windows)

> 산업 현장 개인보호구(PPE) 착용 준수를 실시간으로 관제하는 **PPE-Safence** 시스템의 Windows 데스크톱 클라이언트

C# WinForms로 구현한 관리자용 관제 프로그램입니다. 엣지 AI(Jetson)가 감지한 위반 데이터를 실시간으로 모니터링하고, 위반 내역 관리·통계 분석·시스템 설정을 하나의 화면에서 제공합니다.

---

## 소개

PPE-Safence는 현장 카메라 영상을 엣지에서 AI로 분석해 작업자의 안전모·마스크·장갑 착용 여부를 감지하고, 위반을 기록·관리하는 통합 안전 관제 시스템입니다. 전체 시스템은 네 부분으로 구성됩니다.

| 구성 | 역할 |
|------|------|
| 엣지 AI (Jetson Orin Nano) | 현장 영상 분석 · PPE 미착용 감지 |
| 백엔드 (Flask · AWS EC2) | REST API · 인증 · 영상 스트림 중계 |
| 데이터베이스 (MariaDB · AWS EC2) | 사용자 · 구역 · 위반 · 로그 저장 |
| **관제 프로그램 (이 저장소)** | **실시간 모니터링 · 위반 관리 · 통계 · 설정** |

이 저장소는 그중 **관제 프로그램(C# WinForms)** 의 소스 코드입니다.

---

## 주요 기능

- **실시간 모니터링** — 구역 설정이 완료된 카메라의 실시간 탐지 영상을 표시
- **위반 알림** — 새 위반 발생 시 우측 상단 알림, 미해결 위반 목록 관리
- **위반 관리** — 미해결·해결 위반 조회, 기간·시간·상태·구역별 필터, 상세 조회·이미지 저장·삭제
- **통계 분석** — 금월·금주 PPE 준수율, 위반 건수, 구역별 현황 시각화
- **이력/로그** — 로그인 등 시스템 접속 이력 조회
- **설정** — 구역 설정(카메라 매핑), PPE 기준 설정(구역별 단속 항목), 사용자 관리

---

## 화면 구성

UserControl 기반으로 화면을 모듈화하고, 메인 창의 사이드바로 전환합니다.

| 화면 | 소스 파일 | 설명 |
|------|-----------|------|
| 로그인 | `LoginForm.cs` | 관리자 인증, 접속 로그 기록 |
| 실시간 모니터링 | `US_LiveMonitoringForm.cs` | 실시간 탐지 영상 표시 |
| 알림 | `US_AlertsForm.cs`, `US_AlertCard.cs` | 미해결 위반 알림 |
| 위반 관리 | `US_ViolationManagementForm.cs` | 위반 목록·필터·대응 처리 |
| 위반 상세 | `ViolationDetailForm.cs`, `ImageViewerForm.cs` | 위반 상세·이미지 뷰어 |
| 통계 분석 | `US_AnalysisForm.cs` | 준수율·건수·구역별 그래프 |
| 이력/로그 | `US_DetectionLogForm.cs` | 접속 이력 조회 |
| 설정 | `US_SettingsForm.cs` | 설정 탭 컨테이너 |
| └ 구역 설정 | `US_ZoneSetting.cs` | 구역–카메라 매핑 |
| └ PPE 기준 | `US_PPEStandard.cs` | 구역별 단속 항목 |
| └ 사용자 설정 | `US_UsersSetting.cs`, `UserEditForm.cs` | 사용자 추가·수정·역할·활성 |

> 화면 캡처: `<스크린샷 이미지를 docs/ 폴더에 추가하고 여기에 삽입하세요>`

---

## 기술 스택

- **언어/프레임워크**: C# · .NET Framework · Windows Forms
- **HTTP 통신**: `System.Net.Http.HttpClient` (REST API)
- **JSON 직렬화**: Newtonsoft.Json
- **영상**: MJPEG over HTTP 스트림 수신
- **백엔드 연동**: Flask REST API (JWT 인증), MariaDB
- **네트워크**: Jetson ↔ AWS 간 Tailscale VPN

---

## 프로젝트 구조

```
PPE_관제_시스템/
├─ Program.cs                       # 진입점
├─ MainForm.cs                      # 메인 창 · 사이드바 · 화면 전환
├─ LoginForm.cs                     # 로그인
│
├─ ApiService.cs                    # REST API 호출 래퍼 (HttpClient)
├─ ServerConfig.cs                  # server.config에서 API 서버 주소 로드
├─ Globaldata.cs                    # 전역 상태 (JWT 토큰, 로그인 ID)
│
├─ US_LiveMonitoringForm.cs         # 실시간 모니터링
├─ US_AlertsForm.cs / US_AlertCard.cs   # 알림
├─ US_ViolationManagementForm.cs    # 위반 관리
├─ ViolationDetailForm.cs / ImageViewerForm.cs  # 위반 상세 · 이미지
├─ US_AnalysisForm.cs               # 통계 분석
├─ US_DetectionLogForm.cs           # 이력/로그
├─ US_SettingsForm.cs               # 설정 컨테이너
├─ US_ZoneSetting.cs                # 구역 설정
├─ US_PPEStandard.cs                # PPE 기준 설정
├─ US_UsersSetting.cs / UserEditForm.cs  # 사용자 설정
│
├─ AppColors.cs / AppStyle.cs       # 공통 색상 · UI 스타일
└─ UserData.cs / HistoryDto.cs / ViolationGroup.cs / AlterDataClass.cs / DataManager.cs  # 모델 · DTO
```

---

## 시작하기

### 요구사항

- Windows 10 / 11
- Visual Studio (.NET Framework · Windows Forms 워크로드)
- 동작 중인 PPE-Safence 백엔드 서버 (Flask · MariaDB)

### 빌드 및 실행

1. 저장소를 클론합니다.
   ```bash
   git clone <YOUR_REPOSITORY_URL>
   ```
2. Visual Studio에서 솔루션(`PPE_관제_시스템`)을 엽니다.
3. 서버 주소를 설정합니다 (아래 [서버 설정](#서버-설정) 참고).
4. `Release` 구성으로 빌드한 뒤 실행하고, 등록된 관리자 계정으로 로그인합니다.

### 서버 설정

관제 프로그램은 실행 파일과 같은 폴더의 `server.config` 파일에서 API 서버 주소를 읽습니다. 파일이 없으면 `ServerConfig.cs`의 기본값을 사용합니다.

`server.config` 예시:
```
http://<백엔드 서버 IP>:5002
```

> 설치 프로그램(아래)을 사용하면 설치 마법사에서 입력한 주소가 `server.config`로 자동 저장됩니다.

---

## 팀

동의대학교 캡스톤디자인 2조

- **김나현** (팀장) — AI · 실시간 영상 송출 · 총괄
- **심가현** — Flask 백엔드 · REST API
- **안주희 · 한경미** — 관제 프로그램 (현 레포지토리)

---

## 관련 저장소

- 엣지 AI (Jetson) : https://github.com/DEU-CD-202601-T2/ppe_detector_capstone_2601
- 백엔드 (Flask) : https://github.com/DEU-CD-202601-T2/ppe-safence-backend
