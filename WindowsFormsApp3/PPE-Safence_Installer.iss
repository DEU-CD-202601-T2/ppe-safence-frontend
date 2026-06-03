; ============================================================
;  PPE-Safence 관제 프로그램 설치 스크립트 (Inno Setup)
;  - 이 .iss 파일을 Inno Setup Compiler로 열어 [Build > Compile] 하면
;    Output\PPE-Safence_Setup.exe 가 생성됩니다.
;  - 아래 #define 4개만 실제 프로젝트에 맞게 수정하면 됩니다.
; ============================================================

; ▼▼▼ 빌드 환경에 맞게 수정하세요 ▼▼▼
#define MyAppName        "PPE-Safence 관제 시스템"
#define MyAppVersion     "1.0.0"
#define MyAppPublisher   "동의대학교 캡스톤디자인 2조"
#define MyAppExeName      "PPE_관제_시스템.exe"      ; ← 실제 빌드된 실행 파일 이름
#define MyBuildDir        "bin\x64\Release"               ; ← Visual Studio Release 빌드 산출물 폴더
;   (.NET 6/7/8 이면 보통 bin\Release\net8.0-windows 처럼 하위 폴더입니다)
; ▲▲▲ 여기까지 ▲▲▲

[Setup]
AppId={{A1B2C3D4-E5F6-47A8-9B0C-1D2E3F4A5B6C}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\PPE-Safence
DefaultGroupName=PPE-Safence
DisableProgramGroupPage=yes
OutputDir=Output
OutputBaseFilename=PPE-Safence_Setup
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
PrivilegesRequired=admin
ArchitecturesInstallIn64BitMode=x64compatible
UninstallDisplayIcon={app}\{#MyAppExeName}

[Languages]
Name: "korean"; MessagesFile: "compiler:Languages\Korean.isl"

[Tasks]
Name: "desktopicon"; Description: "바탕화면에 바로가기 만들기"; GroupDescription: "추가 아이콘:"

[Files]
; 빌드 폴더의 모든 파일(exe, dll, 설정 등)을 통째로 설치합니다.
Source: "{#MyBuildDir}\*"; DestDir: "{app}"; Flags: recursesubdirs createallsubdirs ignoreversion

[Icons]
Name: "{group}\{#MyAppName}";       Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{#MyAppName} 제거";  Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
; 설치 완료 후 바로 실행 옵션
Filename: "{app}\{#MyAppExeName}"; Description: "{#MyAppName} 지금 실행"; Flags: nowait postinstall skipifsilent

; ============================================================
;  서버 주소 입력 페이지
;  - 설치 중 입력한 API 서버 주소를 {app}\server.config 에 저장합니다.
;  - ★ 관제 프로그램이 실행 시 이 server.config 파일을 읽어
;     API 기본 URL로 사용하도록 구현되어 있어야 동작합니다.
;     (아직 그렇게 구현돼 있지 않다면, 이 페이지는 참고용이며
;      프로그램 내 설정 화면에서 직접 입력해도 됩니다.)
; ============================================================
[Code]
var
  ServerPage: TInputQueryWizardPage;

procedure InitializeWizard;
begin
  ServerPage := CreateInputQueryPage(wpSelectDir,
    '서버 설정',
    'API 서버 주소를 입력하세요.',
    '관제 프로그램이 연결할 백엔드(Flask) 서버 주소를 입력하세요. ' +
    '설치 후 프로그램 설정에서도 변경할 수 있습니다.');
  ServerPage.Add('API 서버 주소 (예: http://<서버 IP>:5002):', False);
  ServerPage.Values[0] := 'http://43.200.27.117:5002';
end;

procedure CurStepChanged(CurStep: TSetupStep);
var
  ConfigPath: string;
begin
  if CurStep = ssPostInstall then
  begin
    ConfigPath := ExpandConstant('{app}\server.config');
    SaveStringToFile(ConfigPath, Trim(ServerPage.Values[0]), False);
  end;
end;
