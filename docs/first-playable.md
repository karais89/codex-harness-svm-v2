# First Playable

## 목적

SVM v3 first playable은 Safe Village 마이크로 하루 루프를 Unity Play Mode에서 구현하고 검증하는 것이다.

이 문서는 구현 계획서가 아니다. 무엇을 만들고, 무엇을 제외하며, 어떤 상태를 완료로 볼지 정하는 기준 문서다.

## 컨셉

좀비 세계의 작은 마을에서 제한된 주민과 자원을 어디에 배치할지 정하고 하루를 버티는 초소형 생존 운영 게임.

핵심 감각은 `오늘 뭘 포기할 것인가?`다.

## 핵심 루프

```text
DayStart
-> Assignment
-> DayAction
-> NightCheck
-> DayEnd
```

- `DayStart`: 날짜, 식량, 벽 상태, 주민 상태를 보여준다.
- `Assignment`: 주민을 `Forage`, `Guard`, `Repair` 행동에 배치한다.
- `DayAction`: 낮 동안 배치 결과를 계산한다.
- `NightCheck`: 밤 위험 판정을 처리한다.
- `DayEnd`: 식량 소비, 피해, 실패 여부를 확인하고 다음 날로 넘어간다.

## 최소 자원

- Food: 주민 생존에 필요한 기본 자원
- Wall: 밤 위험을 막는 방어 상태
- Villagers: 행동을 수행할 수 있는 주민 수

## 주민 행동

- `Forage`: Food를 얻는다.
- `Guard`: 밤 위험 피해를 줄인다.
- `Repair`: Wall을 회복한다.

## 구현 방식

- first playable은 순수 C# domain을 먼저 만들고 Unity UI를 얇게 붙이는 방식으로 구현한다.
- Domain은 하루 루프, 자원 상태, 주민 배치, 낮 결과, 밤 판정, 성공/실패 조건을 계산하는 일반 C# 코드다.
- Unity UI는 현재 상태를 보여주고 플레이어 입력을 domain에 전달하며 결과 로그를 표시하는 adapter 역할만 한다.
- MonoBehaviour, Canvas, TextMeshPro 컴포넌트 안에 gameplay rule을 직접 넣지 않는다.
- Domain은 가능하면 Unity Play Mode 없이도 검증할 수 있게 유지한다.

## UI 기준

- Runtime UI는 Unity UI와 TextMeshPro를 사용한다.
- 기본 폰트 후보는 Pretendard다.
- Pretendard를 프로젝트에 포함하기 전에는 공식 배포처와 SIL Open Font License 1.1 조건을 확인한다.
- Editor tool 작업이 필요하면 UI Toolkit을 우선 사용한다.

## 포함 범위

- 1개 Unity scene
- 텍스트 또는 간단 UI 중심 표현
- 주민 배치 선택
- 낮 결과 계산
- 밤 위험 판정
- 다음 날 상태 변화
- 3일 생존 목표
- 식량 부족 또는 벽 붕괴 실패 조건
- 하루 결과 로그

## 제외 범위

- 3D 마을 구현
- 건물, 캐릭터, 좀비 애니메이션
- 물, 전력, 의약품
- 장기 캠페인
- 스토리 이벤트
- 복잡한 인벤토리 또는 생산 체인
- 하네스 기능을 보여주기 위한 gameplay 범위 확장

## 완료 기준

first playable은 다음을 만족하면 완료로 본다.

- Unity Play Mode에서 하루 루프를 시작할 수 있다.
- 플레이어가 주민 배치를 선택할 수 있다.
- 낮 결과와 밤 판정이 화면 또는 로그로 표시된다.
- 다음 날로 넘어가면 Food, Wall, Villagers 중 최소 하나가 이전 날과 달라진다.
- 3일을 생존하거나 실패 조건에 도달할 수 있다.
- 실패 조건에 도달하면 실패 상태가 표시된다.
- 한 번의 전체 루프 검증 중 Console error가 없어야 한다.

## 검증 방식

- Domain rule은 Edit Mode test 또는 동등한 빠른 검증으로 먼저 확인한다.
- Unity Play Mode에서 수동으로 하루 루프를 끝까지 진행한다.
- 서로 다른 배치 선택을 최소 2번 확인한다.
- 성공 경로와 실패 경로를 각각 최소 1번 확인한다.
- Console error 여부를 확인한다.
- `IvanMurzak/Unity-MCP`는 scene 상태, UI 배치, Console log, screenshot 확인에 사용할 수 있다.

## 구현 계획 방식

- first playable 전체를 하나의 ExecPlan으로 관리한다.
- GitHub Issues는 ExecPlan의 milestone 또는 vertical slice를 나눈 작업 단위로 사용한다.
- ExecPlan은 전체 구현 맥락과 검증 기록을 유지하고, issue는 AFK agent가 집을 수 있는 작은 범위와 의존성을 관리한다.
