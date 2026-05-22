# Safe Village Micro First Playable 구현

This ExecPlan is a living document. The sections `Progress`, `Surprises & Discoveries`, `Decision Log`, and `Outcomes & Retrospective` must be kept up to date as work proceeds.

이 ExecPlan은 repository root의 `.agent/PLANS.md` 기준을 따른다. 이 파일 하나만 읽어도 새로운 작업자가 Safe Village Micro first playable을 구현하고 검증할 수 있어야 한다.

## Purpose / Big Picture

이 작업이 끝나면 Unity Play Mode에서 Safe Village Micro의 3일 생존 루프를 직접 플레이할 수 있다. 플레이어는 매일 3명의 주민을 `Forage`, `Guard`, `Repair`에 배치하고, 낮 결과와 밤 위험 판정을 확인한 뒤 다음 날로 넘어간다. 3일을 버티면 승리하고, 식량이 부족하거나 벽이 무너지면 실패한다.

이 first playable의 목적은 큰 생존 시뮬레이션을 만드는 것이 아니다. `오늘 뭘 포기할 것인가?`라는 핵심 감각을 가장 작은 Unity 실행물로 검증하고, 동시에 Codex가 순수 C# domain, Edit Mode tests, Unity UI adapter, Unity MCP 검증을 어떤 순서로 안정적으로 수행하는지 확인하는 것이다.

## Progress

- [x] (2026-05-22T23:13:15Z) 현재 repo 상태, `docs/first-playable.md`, `.agent/PLANS.md`, `AGENTS.md`, Unity package manifest, 기존 C# 파일 구성을 확인했다.
- [x] (2026-05-22T23:13:15Z) first playable 구현을 위한 deterministic domain rule과 Unity UI adapter 범위를 이 ExecPlan에 초안으로 기록했다.
- [x] (2026-05-22T23:25:57Z) first playable 전체를 하나의 ExecPlan으로 관리하고 GitHub Issues로 vertical slice를 분해하는 방향을 사용자와 확정했다.
- [x] (2026-05-22T23:25:57Z) GitHub Issues #1-#5를 dependency order로 발행하고 이 ExecPlan의 work queue로 연결했다.
- [x] (2026-05-22T23:41:28Z) Issue #2 범위로 `SafeVillage.Core` 초기 상태 domain model과 Edit Mode tests를 추가하고 `SafeVillage.Core.Tests` 2개를 통과시켰다.
- [x] (2026-05-22T23:41:28Z) Issue #2 범위로 `SafeVillage.Runtime` presenter와 `Assets/Scenes/SafeVillageMicro.unity` scene을 추가하고 Play Mode에서 초기 Day/Food/Wall/Villagers/Outcome text 표시를 확인했다.
- [ ] Issue #3 범위에서 assignment validation, one-day resolution, result log, invalid assignment UI를 추가한다.
- [ ] 성공 경로와 실패 경로를 Play Mode에서 수동 검증하고, Unity MCP로 Console log, screenshot, scene 상태를 확인한다.
- [ ] 검증 결과를 이 ExecPlan의 `Outcomes & Retrospective`와 `Artifacts and Notes`에 기록한 뒤 커밋한다.

## Surprises & Discoveries

- Observation: 현재 repo에는 gameplay runtime code와 test assembly가 없다. C# 파일은 `Assets/Editor/PromptsLab/SvmConsoleLogBridge.cs`만 확인됐다.
  Evidence: `rg --files Assets | rg '\.(cs|asmdef|asmref|unity)$|Tests|Test'` 결과가 PromptsLab editor script와 scene 파일만 반환했다.
- Observation: TextMeshPro runtime assembly는 별도 `com.unity.textmeshpro` package가 아니라 현재 설치된 `com.unity.ugui` package 아래 `Unity.TextMeshPro` asmdef로 제공된다.
  Evidence: `Library/PackageCache/com.unity.ugui@473409526770/Runtime/TMP/Unity.TextMeshPro.asmdef`가 존재한다.
- Observation: `docs/first-playable.md`는 구현 계획서가 아니라 범위와 완료 기준 문서이며, 마지막 항목에는 ExecPlan 여부가 아직 미정으로 남아 있다.
  Evidence: `docs/first-playable.md`의 "아직 정하지 않은 것" 섹션이 "구현을 ExecPlan으로 진행할지 여부"만 포함한다.
- Observation: Unity `tests-run`은 열린 scene이 dirty이면 Edit Mode tests도 거부한다.
  Evidence: 첫 `tests-run` 시도는 unsaved `(untitled)` scene 때문에 실패했다. `Assets/Scenes/SafeVillageMicro.unity`를 만들고 저장한 뒤 같은 test assembly가 Passed 상태가 됐다.
## Decision Log

- Decision: active ExecPlan 파일은 `docs/first-playable-execplan.md`에 둔다.
  Rationale: `docs/first-playable.md`가 mini PRD 역할을 하므로, 구현 계획을 같은 `docs/` 계층에 나란히 두면 범위 문서와 실행 계획의 역할 분리가 명확하다. `.agent/PLANS.md`는 원문 기준 파일이므로 수정하지 않는다.
  Date/Author: 2026-05-22 / Codex

- Decision: first playable domain rule은 deterministic rule로 구현한다. 무작위 밤 위험, 이벤트, 주민 사망, 장기 캠페인은 넣지 않는다.
  Rationale: `docs/first-playable.md`의 제외 범위가 큰 시스템 확장을 막고 있으며, 첫 playable은 성공과 실패를 반복 검증할 수 있어야 한다. deterministic rule이면 Edit Mode test와 Play Mode 수동 검증이 정확히 같은 기대값을 공유한다.
  Date/Author: 2026-05-22 / Codex

- Decision: 주민 수는 first playable 동안 3명으로 고정한다. `Villagers`는 행동 배치 capacity로만 쓰고, 사망이나 신규 영입은 구현하지 않는다.
  Rationale: 문서상 최소 자원에는 `Villagers`가 포함되지만 실패 조건은 식량 부족 또는 벽 붕괴다. 주민 증감까지 넣으면 핵심 tradeoff가 흐려지고 첫 playable 범위를 넘는다.
  Date/Author: 2026-05-22 / Codex

- Decision: first playable UI는 Unity UI와 TextMeshPro를 사용하되, Pretendard font asset은 이번 구현에 포함하지 않는다.
  Rationale: `docs/first-playable.md`는 Pretendard를 "기본 폰트 후보"로만 두고, 포함 전 공식 배포처와 SIL Open Font License 1.1 조건 확인을 요구한다. 이번 작업은 network/license 확인 없이 gameplay loop를 검증하는 것이므로 TMP default font로 시작한다.
  Date/Author: 2026-05-22 / Codex

- Decision: Runtime UI는 scene에 많은 serialized reference를 직접 얽기보다, `SafeVillageGamePresenter`가 Canvas와 controls를 생성하거나 소유하는 얇은 adapter로 둔다.
  Rationale: 현재 scene에는 gameplay UI가 없고, first playable의 핵심 위험은 gameplay rule이 MonoBehaviour 안으로 새는 것이다. UI 생성과 표시 코드는 adapter에 둘 수 있지만, 하루 루프와 판정 숫자는 `SafeVillage.Core`만 계산한다.
  Date/Author: 2026-05-22 / Codex

## Outcomes & Retrospective

Issue #2는 완료됐다. 현재 Play Mode에서 `SafeVillageMicro` scene을 열면 `SafeVillageGamePresenter`가 `VillageGame`의 초기 상태를 읽어 `Safe Village Micro`, `Day: 1`, `Food: 3`, `Wall: 3/5`, `Villagers: 3`, `Outcome: InProgress`를 표시한다. `Resolve Day`, assignment controls, day report log는 아직 없으며 Issue #3 범위로 남긴다.

검증 중 처음 `tests-run`은 dirty untitled scene 때문에 실패했다. 이 실패는 gameplay code 문제가 아니라 Unity test runner precondition 문제였고, 새 scene을 저장한 뒤 재실행해 `SafeVillage.Core.Tests` 2개가 통과했다. 최종 Console 검증 전 Console log를 clear한 뒤 Error와 Exception이 비어 있음을 다시 확인했다.

## Context and Orientation

이 repository는 Unity 6000.4.6f1 프로젝트다. `ProjectSettings/ProjectVersion.txt`에 해당 Editor version이 기록되어 있다. `Packages/manifest.json`에는 `com.unity.test-framework`, `com.unity.ugui`, `com.ivanmurzak.unity.mcp` 0.73.0이 포함되어 있다. Unity MCP smoke gate는 이미 통과했지만, 이 ExecPlan을 실행하는 작업자는 실제 변경 후 다시 Console log와 screenshot을 확인해야 한다.

`docs/first-playable.md`는 first playable의 mini PRD다. 핵심 루프는 `DayStart -> Assignment -> DayAction -> NightCheck -> DayEnd`다. 포함 범위는 1개 Unity scene, 텍스트 또는 간단 UI 중심 표현, 주민 배치 선택, 낮 결과 계산, 밤 위험 판정, 다음 날 상태 변화, 3일 생존 목표, 식량 부족 또는 벽 붕괴 실패 조건, 하루 결과 로그다. 제외 범위는 3D 마을, 애니메이션, 물/전력/의약품, 장기 캠페인, 스토리 이벤트, 복잡한 인벤토리나 생산 체인, 하네스 전시용 gameplay 확장이다.

`AGENTS.md`는 first playable 구현 방식을 순수 C# domain first, Unity UI thin adapter로 확정한다. Domain은 하루 루프, 자원 상태, 주민 배치, 낮 결과, 밤 판정, 성공/실패 조건을 계산한다. Unity UI는 상태 표시, 입력 전달, 결과 로그 표시만 담당한다. MonoBehaviour, Canvas, TextMeshPro component 안에 gameplay rule을 직접 넣으면 안 된다.

현재 gameplay source code는 없다. 기존 `Assets/Editor/PromptsLab/SvmConsoleLogBridge.cs`는 Prompts Lab에서 만든 Editor-only helper이므로 first playable 구현 중 수정하지 않는다. Unity MCP package artifacts인 `Assets/Plugins/NuGet/`도 package 설치 결과물이므로 직접 수정하지 않는다.

이 문서에서 "domain"은 Unity scene이나 MonoBehaviour 없이 실행 가능한 순수 C# 규칙 코드를 뜻한다. "adapter"는 Unity 입력과 화면 표시를 domain API에 연결하는 얇은 MonoBehaviour 코드를 뜻한다. "Edit Mode test"는 Unity Test Framework에서 Play Mode 진입 없이 실행되는 빠른 테스트를 뜻한다. "Play Mode"는 Unity Editor에서 실제 scene을 실행해 사용자가 UI를 누를 수 있는 상태를 뜻한다.

## Domain Rules for This First Playable

새 게임은 `Day = 1`, `Food = 3`, `Wall = 3`, `MaxWall = 5`, `Villagers = 3`, `Outcome = InProgress`로 시작한다. `Day`는 현재 해결해야 할 날짜다. `Food`는 주민 생존 자원이고, 매일 끝에 주민 수만큼 감소한다. `Wall`은 밤 위험을 막는 방어 상태다. `Villagers`는 매일 행동에 배치할 수 있는 주민 수이며 first playable에서는 변하지 않는다.

플레이어는 매일 정확히 3명의 주민을 `Forage`, `Guard`, `Repair`에 배치해야 한다. 세 값 중 하나라도 음수이면 invalid assignment다. 세 값의 합이 `Villagers`와 다르면 invalid assignment다. Unity UI는 invalid assignment일 때 `Resolve Day`를 실행하지 않고 validation message를 보여준다. Domain API도 invalid assignment를 거부해야 한다.

하루 해결은 항상 같은 순서로 계산한다. 먼저 `DayAction`에서 `Forage` 주민 1명당 Food를 2 얻고, `Repair` 주민 1명당 Wall을 1 회복한다. Wall은 `MaxWall`을 넘을 수 없다. 그 다음 `NightCheck`에서 밤 위험을 계산한다. 밤 위험 수치는 현재 Day와 같으므로 Day 1 threat는 1, Day 2 threat는 2, Day 3 threat는 3이다. `Guard` 주민 1명은 threat를 1 줄인다. 실제 damage는 `max(0, threat - guard)`이고, Wall에서 damage만큼 뺀다. 마지막 `DayEnd`에서 Food를 `Villagers`만큼 소비한다.

DayEnd 후 `Wall <= 0`이면 `WallCollapsed` 실패다. 그렇지 않고 `Food < 0`이면 `FoodDepleted` 실패다. 그렇지 않고 Day 3 해결을 마쳤으면 `Victory`다. 그 외에는 Day를 1 증가시키고 다음 assignment를 기다린다. failure와 victory는 terminal outcome이며, terminal outcome 이후에는 `Restart` 외에 새 day를 해결하지 않는다.

검증용 성공 경로는 다음과 같다. Day 1에 `Forage=2, Guard=1, Repair=0`을 선택하면 Day 2는 `Food=4, Wall=3`으로 시작한다. Day 2에 `Forage=1, Guard=1, Repair=1`을 선택하면 Day 3은 `Food=3, Wall=3`으로 시작한다. Day 3에 `Forage=0, Guard=3, Repair=0`을 선택하면 `Food=0, Wall=3, Outcome=Victory`가 된다.

검증용 실패 경로는 두 가지를 둔다. `Forage=3, Guard=0, Repair=0`을 반복하면 Day 2 밤에 Wall이 0이 되어 `WallCollapsed`로 실패한다. `Forage=0, Guard=3, Repair=0`을 반복하면 Day 2 DayEnd에서 Food가 -3이 되어 `FoodDepleted`로 실패한다.

## Plan of Work

첫 번째 milestone은 순수 C# domain과 tests다. `Assets/SafeVillage/Core/`를 만들고 `SafeVillage.Core.asmdef`를 추가한다. 이 assembly는 `UnityEngine`에 의존하지 않는 일반 C# code만 담는다. 같은 milestone에서 `Assets/Tests/EditMode/SafeVillage.Core.Tests/`를 만들고 `SafeVillage.Core.Tests.asmdef`와 `VillageGameTests.cs`를 추가한다. 테스트를 먼저 작성해 invalid assignment, Forage/Guard/Repair 계산, wall failure, food failure, 3일 victory를 고정한 뒤 domain code를 구현한다.

두 번째 milestone은 Unity Runtime adapter다. `Assets/SafeVillage/Runtime/`에 `SafeVillage.Runtime.asmdef`와 `SafeVillageGamePresenter.cs`를 추가한다. 이 assembly는 `SafeVillage.Core`, `UnityEngine.UI`, `Unity.TextMeshPro`를 참조한다. `SafeVillageGamePresenter`는 `VillageGame` instance를 소유하고, TMP text와 UGUI button을 통해 현재 state, assignment counts, validation message, day report log, terminal outcome을 표시한다. 이 class는 food gain, wall damage, victory/failure 같은 gameplay 숫자를 직접 계산하지 않고 domain의 state와 report를 표시한다.

세 번째 milestone은 Unity scene이다. `Assets/Scenes/SafeVillageMicro.unity`를 만들고, scene 안에는 Main Camera와 `SafeVillageGame` root GameObject를 둔다. root GameObject에는 `SafeVillageGamePresenter`를 붙인다. UI가 presenter에서 runtime 생성되는 방식이면 scene은 최소 구성만 가진다. scene-authored UI로 바꾸기로 결정하면 이 ExecPlan의 Decision Log를 먼저 갱신하고, Canvas와 TMP/Button reference wiring을 scene에 명시적으로 남긴다.

네 번째 milestone은 Play Mode 검증이다. Unity Editor에서 `Assets/Scenes/SafeVillageMicro.unity`를 열고 Play Mode를 시작한다. success path와 wall failure path를 직접 눌러 확인한다. 추가로 food failure path를 확인해 `FoodDepleted`가 표시되는지 본다. UI에는 Day, Food, Wall, Villagers, current assignment, Resolve/Restart controls, 하루 결과 log, Victory/Failure 상태가 보여야 한다.

다섯 번째 milestone은 MCP와 repository 검증이다. Unity MCP로 scene 상태, Console error, Game View screenshot을 확인한다. `git diff --check`와 `git status --short`로 whitespace와 변경 범위를 확인한다. 결과가 기준을 만족하면 이 ExecPlan의 Progress, Artifacts, Outcomes를 갱신하고 commit policy에 따라 커밋한다.

## Concrete Steps

모든 명령은 repository root인 `/Users/kaya/Documents/Codex/codex-harness-svm-v2`에서 실행한다.

먼저 현재 상태를 확인한다.

    git status --short
    rg --files Assets | rg '\.(cs|asmdef|asmref|unity)$|Tests|Test'

기대 상태는 gameplay 구현 전이라면 `git status --short`가 비어 있고, C# 파일은 기존 PromptsLab editor script만 보이는 것이다. 이미 다른 작업자가 구현을 시작했다면 기존 파일을 읽고 이 ExecPlan의 Progress를 실제 상태에 맞게 갱신한다.

domain milestone에서는 다음 파일을 추가한다.

    Assets/SafeVillage/Core/SafeVillage.Core.asmdef
    Assets/SafeVillage/Core/VillageAction.cs
    Assets/SafeVillage/Core/VillageAssignment.cs
    Assets/SafeVillage/Core/VillageOutcome.cs
    Assets/SafeVillage/Core/VillageState.cs
    Assets/SafeVillage/Core/DayReport.cs
    Assets/SafeVillage/Core/VillageGame.cs
    Assets/Tests/EditMode/SafeVillage.Core.Tests/SafeVillage.Core.Tests.asmdef
    Assets/Tests/EditMode/SafeVillage.Core.Tests/VillageGameTests.cs

`SafeVillage.Core.asmdef`의 assembly name은 `SafeVillage.Core`다. `SafeVillage.Core.Tests.asmdef`의 assembly name은 `SafeVillage.Core.Tests`이고, `SafeVillage.Core`를 reference로 갖고, `includePlatforms`는 `Editor`, `optionalUnityReferences`는 `TestAssemblies`로 둔다.

`SafeVillage.Core`에는 다음 public interface가 있어야 한다.

    namespace SafeVillage.Core
    {
        public enum VillageAction { Forage, Guard, Repair }
        public enum VillageOutcome { InProgress, Victory, FoodDepleted, WallCollapsed }

        public readonly struct VillageAssignment
        {
            public VillageAssignment(int forage, int guard, int repair);
            public int Forage { get; }
            public int Guard { get; }
            public int Repair { get; }
            public int Total { get; }
            public bool IsValidFor(int villagers);
        }

        public readonly struct VillageState
        {
            public int Day { get; }
            public int Food { get; }
            public int Wall { get; }
            public int MaxWall { get; }
            public int Villagers { get; }
            public VillageOutcome Outcome { get; }
            public bool IsTerminal { get; }
        }

        public sealed class DayReport
        {
            public int Day { get; }
            public VillageAssignment Assignment { get; }
            public int FoodGained { get; }
            public int WallRepaired { get; }
            public int Threat { get; }
            public int Damage { get; }
            public int FoodConsumed { get; }
            public VillageState ResultingState { get; }
            public string Summary { get; }
        }

        public sealed class VillageGame
        {
            public VillageState State { get; }
            public DayReport LastReport { get; }
            public void Restart();
            public bool CanResolve(VillageAssignment assignment, out string reason);
            public DayReport ResolveDay(VillageAssignment assignment);
        }
    }

이 interface는 구현 중 더 단순하게 조정할 수 있지만, 조정하면 이 ExecPlan의 `Interfaces and Dependencies`와 관련 테스트명을 함께 갱신해야 한다. `VillageGame.ResolveDay`는 invalid assignment나 terminal state에서 호출되면 `InvalidOperationException` 또는 `ArgumentException`을 던져야 한다. UI adapter는 이 예외를 정상 흐름에 쓰지 말고 `CanResolve`로 먼저 막는다.

Edit Mode tests를 실행한다.

    unity-mcp-cli run-tool tests-run --input '{"testMode":"EditMode","testAssembly":"SafeVillage.Core.Tests","includePassingTests":true,"includeMessages":true}'

기대 결과는 `Status`가 `Passed`이고, 새 테스트가 모두 passed인 것이다. domain milestone 완료 시점에는 적어도 다음 테스트가 있어야 한다.

- 새 게임은 Day 1, Food 3, Wall 3, Villagers 3으로 시작한다.
- 음수 배치 또는 합계가 주민 수와 다른 배치는 거부된다.
- Forage, Guard, Repair는 Food, Wall, damage를 deterministic rule대로 바꾼다.
- success path는 Day 3 해결 후 `Victory`가 된다.
- all forage 반복은 `WallCollapsed`가 된다.
- all guard 반복은 `FoodDepleted`가 된다.

Runtime adapter milestone에서는 다음 파일을 추가한다.

    Assets/SafeVillage/Runtime/SafeVillage.Runtime.asmdef
    Assets/SafeVillage/Runtime/SafeVillageGamePresenter.cs

`SafeVillage.Runtime.asmdef`는 `SafeVillage.Core`, `UnityEngine.UI`, `Unity.TextMeshPro`를 참조한다. presenter는 TMP text와 UGUI button을 만들거나 연결한다. 화면에는 최소한 다음 정보가 있어야 한다: Day, Food, Wall, Villagers, Forage count, Guard count, Repair count, validation message, day report log, terminal outcome, Resolve Day button, Restart button.

scene milestone에서는 Unity MCP나 Unity Editor를 사용해 scene을 만든다. Unity MCP를 사용할 경우 다음 명령으로 시작한다.

    unity-mcp-cli run-tool scene-create --input '{"path":"Assets/Scenes/SafeVillageMicro.unity","newSceneSetup":"DefaultGameObjects","newSceneMode":"Single"}'

그 뒤 `SafeVillageGame` root GameObject를 만들고 `SafeVillageGamePresenter` component를 붙인다. scene을 저장한 뒤 다음 명령으로 열린 scene 상태를 확인한다.

    unity-mcp-cli run-tool scene-list-opened --input '{}'

기대 결과는 `SafeVillageMicro` scene이 loaded 상태이고 dirty가 아닌 것이다. scene-authored UI를 만드는 경우 Canvas와 Button/TMP object가 scene hierarchy에 보여야 한다. runtime-generated UI를 유지하는 경우 hierarchy에는 root GameObject와 presenter component만 있어도 된다.

Play Mode 수동 검증은 Unity Editor에서 수행한다. `Assets/Scenes/SafeVillageMicro.unity`를 열고 Play를 누른다. 먼저 success path를 입력한다.

    Day 1: Forage 2, Guard 1, Repair 0, Resolve Day
    Day 2: Forage 1, Guard 1, Repair 1, Resolve Day
    Day 3: Forage 0, Guard 3, Repair 0, Resolve Day

기대 관찰은 Victory 표시, Food 0, Wall 3, day report log가 3일치 보이는 것이다.

다음으로 Restart 후 wall failure path를 입력한다.

    Day 1: Forage 3, Guard 0, Repair 0, Resolve Day
    Day 2: Forage 3, Guard 0, Repair 0, Resolve Day

기대 관찰은 Failure 또는 WallCollapsed 표시, Wall 0 이하, Resolve Day가 더 진행되지 않는 것이다.

다음으로 Restart 후 food failure path를 입력한다.

    Day 1: Forage 0, Guard 3, Repair 0, Resolve Day
    Day 2: Forage 0, Guard 3, Repair 0, Resolve Day

기대 관찰은 Failure 또는 FoodDepleted 표시, Food -3, Resolve Day가 더 진행되지 않는 것이다.

Unity MCP 검증은 Play Mode 수동 검증 직후 수행한다.

    unity-mcp-cli run-tool console-get-logs --input '{"maxEntries":20,"logTypeFilter":"Error","includeStackTrace":false,"lastMinutes":10}'
    unity-mcp-cli run-tool console-get-logs --input '{"maxEntries":20,"logTypeFilter":"Exception","includeStackTrace":false,"lastMinutes":10}'
    unity-mcp-cli run-tool screenshot-game-view --input '{}'

Console error와 exception 조회는 빈 배열이어야 한다. screenshot에는 Safe Village Micro UI가 보이고, Day/Food/Wall/Villagers/status/log text가 서로 겹치지 않아야 한다.

마지막으로 repository 상태를 확인한다.

    git diff --check
    git status --short

`git diff --check`는 출력 없이 성공해야 한다. `git status --short`에는 이 first playable에 필요한 새 source, test, scene, meta 파일과 이 ExecPlan 갱신만 있어야 한다. Unity가 unrelated Library, Temp, UserSettings 파일을 만들었으면 commit에 포함하지 않는다.

## Validation and Acceptance

Domain acceptance는 Edit Mode tests로 판단한다. `SafeVillage.Core.Tests`가 모두 통과해야 하고, tests는 success path, wall failure path, food failure path를 모두 고정해야 한다. Domain tests가 실패하면 UI 구현으로 넘어가지 않는다.

Unity acceptance는 Play Mode에서 판단한다. 플레이어가 `Forage`, `Guard`, `Repair` 배치를 바꿀 수 있고, invalid assignment일 때 해결 버튼이 막히거나 validation message가 떠야 한다. Day를 해결하면 Food 또는 Wall 중 최소 하나가 바뀌고, 결과 log가 추가되어야 한다. 3일 생존 시 Victory가 표시되고, 식량 부족 또는 벽 붕괴 시 Failure가 표시되어야 한다.

MCP acceptance는 evidence capture로 판단한다. `console-get-logs`에서 Error와 Exception이 없어야 하고, `screenshot-game-view`가 실제 UI를 보여야 한다. `scene-list-opened`는 target scene이 loaded이고 saved 상태임을 보여야 한다.

Repository acceptance는 변경 범위로 판단한다. 구현 완료 후 diff는 `Assets/SafeVillage/`, `Assets/Tests/EditMode/SafeVillage.Core.Tests/`, `Assets/Scenes/SafeVillageMicro.unity`, 관련 `.meta`, 이 ExecPlan 갱신 정도로 제한되어야 한다. `Assets/Editor/PromptsLab/SvmConsoleLogBridge.cs`, `Assets/Plugins/NuGet/`, `.agent/PLANS.md`는 수정하지 않는다.

## Idempotence and Recovery

Domain code와 tests는 반복 실행해도 상태를 남기지 않는다. tests가 실패하면 먼저 failing test name과 expected/actual 값을 이 ExecPlan의 `Surprises & Discoveries`에 짧게 기록하고, domain code를 수정한다. UI나 scene을 수정하기 전에 domain tests를 다시 통과시킨다.

`scene-create`가 이미 존재하는 scene 때문에 실패하면 기존 `Assets/Scenes/SafeVillageMicro.unity`를 열고 현재 hierarchy를 확인한다. 기존 scene이 이 ExecPlan의 작업물이라면 이어서 수정한다. 다른 작업자의 scene이면 삭제하거나 덮어쓰지 말고 사용자에게 충돌을 보고한다.

Unity compilation이 domain reload 중이면 기다렸다가 `editor-application-get-state` 또는 `tests-run`을 다시 시도한다. dirty scene 때문에 tests-run이 거부되면 scene을 저장한 뒤 재시도한다.

Pretendard font는 이번 plan에 포함하지 않는다. 사용자가 font asset 추가를 명시하면 공식 배포처와 license 조건을 확인한 뒤 별도 decision 또는 ExecPlan update로 진행한다.

## Artifacts and Notes

현재까지 확인한 기준 정보는 다음과 같다.

    Unity Editor: 6000.4.6f1
    Current gameplay code: none
    Existing C# file: Assets/Editor/PromptsLab/SvmConsoleLogBridge.cs
    Unity MCP package: com.ivanmurzak.unity.mcp 0.73.0
    Runtime UI packages available: com.unity.ugui, Unity.TextMeshPro
    First playable source of truth: docs/first-playable.md
    ExecPlan source standard: .agent/PLANS.md

GitHub issue queue는 dependency order로 다음과 같다.

    #1 Lock SVM first playable scope and ExecPlan tracking
    #2 Display initial village day state in Play Mode
    #3 Resolve one day assignment end-to-end
    #4 Reach victory through the 3-day survival path
    #5 Show failure paths and close first playable verification

구현 중 새 test output, MCP response summary, screenshot observation, final diff summary를 이 섹션에 추가한다.

Issue #2 구현 산출물은 다음과 같다.

    Assets/SafeVillage/Core/SafeVillage.Core.asmdef
    Assets/SafeVillage/Core/VillageOutcome.cs
    Assets/SafeVillage/Core/VillageState.cs
    Assets/SafeVillage/Core/VillageGame.cs
    Assets/SafeVillage/Runtime/SafeVillage.Runtime.asmdef
    Assets/SafeVillage/Runtime/SafeVillageGamePresenter.cs
    Assets/Tests/EditMode/SafeVillage.Core.Tests/SafeVillage.Core.Tests.asmdef
    Assets/Tests/EditMode/SafeVillage.Core.Tests/VillageGameTests.cs
    Assets/Scenes/SafeVillageMicro.unity

Issue #2 검증 결과는 다음과 같다.

    unity-mcp-cli run-tool tests-run --input '{"testMode":"EditMode","testAssembly":"SafeVillage.Core.Tests","includePassingTests":true,"includeMessages":true}'
    Status: Passed
    TotalTests: 2
    PassedTests: 2

    unity-mcp-cli run-tool gameobject-component-get --input '{"gameObjectRef":{"instanceID":0,"path":"SafeVillageGame/SafeVillageCanvas/InitialStateText"},"componentRef":{"index":2,"instanceID":-6342},"paths":["text"]}'
    text: Safe Village Micro
          Day: 1
          Food: 3
          Wall: 3/5
          Villagers: 3
          Outcome: InProgress

    unity-mcp-cli run-tool screenshot-game-view --input '{}'
    Screenshot from Game View (714x402)

    unity-mcp-cli run-tool console-get-logs --input '{"maxEntries":20,"logTypeFilter":"Error","includeStackTrace":false,"lastMinutes":10}'
    result: []

    unity-mcp-cli run-tool console-get-logs --input '{"maxEntries":20,"logTypeFilter":"Exception","includeStackTrace":false,"lastMinutes":10}'
    result: []

## Interfaces and Dependencies

`SafeVillage.Core`는 Unity runtime assemblies를 참조하지 않는다. 이 assembly는 deterministic state transition만 제공한다. Public API는 `VillageGame`, `VillageState`, `VillageAssignment`, `DayReport`, `VillageOutcome` 중심으로 유지한다.

`SafeVillage.Core.Tests`는 Unity Test Framework의 Edit Mode test assembly다. 이 assembly는 `SafeVillage.Core`와 NUnit test support만 참조한다. tests는 gameplay rule을 문서화하는 역할도 하므로, tuning number를 바꾸면 tests와 이 ExecPlan의 Domain Rules를 함께 갱신한다.

`SafeVillage.Runtime`은 Unity scene과 UI를 연결한다. 이 assembly는 `SafeVillage.Core`, `UnityEngine.UI`, `Unity.TextMeshPro`를 참조한다. Runtime code는 UI formatting과 input forwarding을 담당한다. Food gain, threat, damage, victory/failure 판단은 `SafeVillage.Core`에서만 한다.

`Assets/Scenes/SafeVillageMicro.unity`는 first playable scene이다. first playable 검증은 이 scene을 열고 Play Mode에서 수행한다. Build Settings 등록은 이번 acceptance에 필요하지 않으므로 기본적으로 하지 않는다.

## Change Note

2026-05-22 / Codex: `docs/first-playable.md`와 현재 repo 상태를 기준으로 first playable 구현용 initial ExecPlan을 작성했다. 아직 사용자 승인 전이므로 gameplay code와 Unity scene 변경은 시작하지 않았다.

2026-05-22 / Codex: 사용자가 first playable 전체 ExecPlan 하나와 GitHub issue vertical slice 분해를 승인했다. `docs/first-playable.md`와 `docs/bootstrap-plan.md`를 확정 방향에 맞게 갱신하고, GitHub Issues #1-#5를 발행했다.

2026-05-22 / Codex: Issue #2를 실행했다. `SafeVillage.Core` 초기 상태, `SafeVillage.Core.Tests`, `SafeVillage.Runtime` presenter, `SafeVillageMicro` scene을 추가했다. Day resolution과 assignment UI는 Issue #3으로 남겼다.
