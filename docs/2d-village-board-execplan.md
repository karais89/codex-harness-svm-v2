# 2D 마을 보드 playable 구현

This ExecPlan is a living document. The sections `Progress`, `Surprises & Discoveries`, `Decision Log`, and `Outcomes & Retrospective` must be kept up to date as work proceeds.

이 ExecPlan은 repository root의 `.agent/PLANS.md` 기준을 따른다. 이 파일 하나만 읽어도 새로운 작업자가 GitHub Issues #7, #8, #9를 순서대로 구현하고 검증할 수 있어야 한다.

## Purpose / Big Picture

현재 `SafeVillageMicro`는 하루 생존 규칙을 검증할 수 있지만, 화면은 게임이라기보다 텍스트와 버튼으로 만든 검증 UI에 가깝다. 이 작업이 끝나면 플레이어는 한 화면의 2D 마을 보드에서 주민 토큰을 보고, 주민을 작업 장소에 클릭으로 배치하고, 하루 결과를 보드 변화와 간단한 피드백 애니메이션으로 이해할 수 있다.

이 계획은 기존 `SafeVillage.Core` domain rule을 바꾸지 않는다. `Forage`, `Guard`, `Repair`, Food, Wall, Victory, Failure 계산은 이미 검증된 domain code에 남기고, Unity Runtime UI adapter를 2D 마을 보드 playable로 바꾼다. 구현은 GitHub Issues #7, #8, #9 순서로 진행하며, #8과 #9는 `/tdd` skill의 red-green-refactor loop를 사용한다.

## Progress

- [x] (2026-05-23T01:10:00Z) `.agent/PLANS.md`, `/tdd` skill, `docs/2d-village-board-playable.md`, GitHub Issues #6-#9, 현재 Runtime presenter와 tests 구조를 확인했다.
- [x] (2026-05-23T01:10:00Z) 이 Delivery ExecPlan을 `docs/2d-village-board-execplan.md`에 작성했다.
- [x] (2026-05-23) Issue #7 범위로 `docs/references/2d-village-board-concept.png` reference 이미지를 만들었다. Runtime `Assets/` 파일은 변경하지 않았다.
- [x] (2026-05-23) 사람이 reference 이미지의 시각 방향이 다음 구현으로 넘어갈 만큼 적절하다고 확인했다. #7을 evidence와 함께 닫는다.
- [ ] Issue #8 범위로 Runtime UI를 고정 한 화면 2D 마을 보드 구조로 교체하고 Play Mode test와 screenshot으로 검증한다.
- [ ] Issue #9 범위로 클릭 선택 배치와 간단한 보드 피드백 애니메이션을 구현하고 Play Mode test, actual pointer input, screenshot으로 검증한다.
- [ ] Issues #7, #8, #9를 각각 evidence와 함께 닫고, tracking issue #6에 최종 결과를 보고한다.

## Surprises & Discoveries

- Observation: 현재 `SafeVillageGamePresenter`는 runtime에서 `Canvas`, `EventSystem`, `InputSystemUIInputModule`, TMP text, UGUI button을 직접 생성한다.
  Evidence: `Assets/SafeVillage/Runtime/SafeVillageGamePresenter.cs`의 `EnsureUi()`와 `EnsureEventSystem()`이 UI와 input path를 만든다.
- Observation: 현재 Runtime UI는 `Forage +`, `Guard +`, `Repair +` 숫자 버튼 중심이라 `CONTEXT.md`의 `2D 마을 보드 playable`이나 `클릭 선택 배치`와 다르다.
  Evidence: `SafeVillageGamePresenter.CreateAssignmentRow()`가 각 action마다 label, count, minus button, plus button을 만든다.
- Observation: 현재 test assembly는 domain Edit Mode tests만 있다. Runtime UI interaction을 TDD로 검증하려면 새 Play Mode test assembly가 필요하다.
  Evidence: `Assets/Tests/EditMode/SafeVillage.Core.Tests/VillageGameTests.cs`는 `VillageGame` public API만 검증하고 Runtime presenter를 실행하지 않는다.
- Observation: DOTween은 현재 설치되어 있지 않다.
  Evidence: `Packages/manifest.json`에 DOTween이나 `com.demigiant` dependency가 없다.

## Decision Log

- Decision: 이 작업은 #7, #8, #9를 한 번에 구현하지 않고 issue 단위로 진행한다.
  Rationale: #7의 컨셉 reference는 사람의 시각 판단이 필요한 gate다. #7 방향이 틀리면 #8과 #9 구현이 낭비될 수 있다.
  Date/Author: 2026-05-23 / Codex

- Decision: `/tdd` red-green-refactor loop는 #8과 #9에서 사용한다. #7은 reference 이미지와 human review가 핵심이라 TDD 대상이 아니다.
  Rationale: `/tdd` skill은 behavior를 public interface로 검증하는 데 적합하다. 이미지 reference 자체는 자동 테스트보다 사람의 방향 확인이 acceptance 기준이다.
  Date/Author: 2026-05-23 / Codex

- Decision: Runtime UI 테스트는 implementation detail이 아니라 observable Play Mode behavior를 검증한다.
  Rationale: `/tdd` skill은 private method나 내부 구조가 아니라 public interface와 사용자 행동을 통해 테스트하라고 요구한다. UI에서는 GameObject 이름, visible text, EventSystem pointer input, domain state 결과가 관찰 가능한 behavior다.
  Date/Author: 2026-05-23 / Codex

- Decision: DOTween은 처음부터 설치하지 않는다. 간단한 Unity coroutine 또는 UI 상태 변화로 충분하지 않을 때만 설치한다.
  Rationale: PRD는 DOTween을 허용하지만 필수 전제로 두지 않는다. 새 dependency는 package resolution, asmdef reference, verification 비용을 만들기 때문에 필요성이 확인될 때만 추가한다.
  Date/Author: 2026-05-23 / Codex

## Outcomes & Retrospective

Runtime 구현은 아직 시작하지 않았다. 이 문서는 #7-#9를 진행할 때 각 issue의 검증 evidence와 결정 변경 사항을 누적하는 living document다.

Issue #7 reference 이미지는 `docs/references/2d-village-board-concept.png`에 생성했다. 이 이미지는 runtime asset이 아니라 HUD, 작업 장소 3곳, 주민 토큰 3개, 벽, 마을 중심부, Resolve/Restart 조작 배치의 방향을 확인하기 위한 layout/mood reference다. 사용자가 시각 방향이 다음 구현으로 넘어갈 만큼 적절하다고 확인했다.

Issue #7 완료 후에는 컨셉 reference가 실제 Unity runtime asset이 아니라 보드 레이아웃과 분위기 기준으로 충분했는지 기록한다. Issue #8 완료 후에는 기존 폼형 UI가 고정 한 화면 마을 보드로 바뀌었는지 screenshot과 Console 결과를 기록한다. Issue #9 완료 후에는 실제 클릭 입력으로 주민 배치와 하루 해결이 동작했는지, 간단한 피드백 애니메이션이 게임처럼 읽히는지 기록한다.

## Context and Orientation

이 repository는 Unity 6000.4.6f1 프로젝트다. `ProjectSettings/ProjectVersion.txt`에 해당 Editor version이 기록되어 있다. `Packages/manifest.json`에는 `com.unity.test-framework`, `com.unity.ugui`, `com.unity.inputsystem`, `com.ivanmurzak.unity.mcp` 0.73.0이 포함되어 있다. Runtime UI는 UGUI와 TextMeshPro를 사용한다.

주요 문서는 다음과 같다. `docs/2d-village-board-playable.md`는 이번 개선의 mini PRD다. `CONTEXT.md`는 domain glossary이며, `2D 마을 보드 playable`, `고정 한 화면 마을 보드`, `클릭 선택 배치`, `작업 장소`, `주민 토큰`, `결과 피드백`을 정의한다. `.agent/PLANS.md`는 이 ExecPlan의 형식과 운영 기준이다. `.agents/skills/tdd/SKILL.md`는 테스트 주도 개발 방식의 기준이다.

현재 gameplay domain은 `Assets/SafeVillage/Core/` 아래에 있다. `VillageGame`은 `State`, `Restart()`, `CanResolve(VillageAssignment, out string)`, `ResolveDay(VillageAssignment)` public API를 제공한다. `VillageAssignment`는 `Forage`, `Guard`, `Repair` count를 담고, 총합이 주민 수와 일치하는지 검증한다. `VillageOutcome`은 `InProgress`, `Victory`, `FoodDepleted`, `WallCollapsed`를 나타낸다.

현재 runtime adapter는 `Assets/SafeVillage/Runtime/SafeVillageGamePresenter.cs`다. 이 class는 `VillageGame` instance를 소유하고 runtime에 `SafeVillageCanvas`를 만든다. 현재 UI는 state text, action별 plus/minus button, resolve/restart button, day report log로 구성되어 있다. 이번 작업에서는 gameplay rule을 이 class 안에 새로 넣지 않고, 이 class가 domain API와 보드 UI를 연결하는 얇은 adapter 역할을 계속 하게 한다.

현재 domain tests는 `Assets/Tests/EditMode/SafeVillage.Core.Tests/VillageGameTests.cs`에 있다. 이번 UI 개선은 domain rule 변경이 아니므로 기존 tests는 계속 통과해야 한다. Runtime UI behavior는 새 Play Mode tests로 검증한다. Play Mode test는 Unity scene과 runtime UI를 실제로 실행하는 테스트다. 이 작업에서는 `Assets/Tests/PlayMode/SafeVillage.Runtime.Tests/` 아래에 새 test assembly를 만들 수 있다.

GitHub issue queue는 다음과 같다. #6은 tracking issue다. #7은 컨셉 reference 생성과 human review다. #8은 Runtime UI를 고정 한 화면 2D 마을 보드로 교체하는 작업이다. #9는 클릭 선택 배치와 보드 피드백 애니메이션 검증이다. 구현은 #7, #8, #9 순서로 진행한다.

## Plan of Work

Issue #7에서는 컨셉 reference 이미지를 만든다. 이 단계는 runtime code를 건드리지 않는다. `docs/references/2d-village-board-concept.png`에 탑다운 또는 살짝 비스듬한 2D 보드게임 느낌의 reference image를 둔다. 이미지에는 HUD, `Forage`, `Guard`, `Repair` 작업 장소, 주민 토큰 3개, 벽, 마을 중심부가 보여야 한다. 생성 후 사람에게 방향 확인을 받는다. 필요하면 `docs/2d-village-board-playable.md`에 레이아웃 제약을 짧게 추가한다. #7은 사람이 시각 방향을 승인하기 전에는 닫지 않는다.

Issue #8부터 `/tdd` skill을 명시적으로 사용한다. 먼저 Runtime UI를 테스트할 Play Mode test assembly를 추가한다. 첫 tracer bullet은 "Play Mode에서 고정 한 화면 마을 보드가 HUD, 작업 장소 3곳, 주민 토큰 3개를 보여준다"는 behavior다. RED 단계에서는 current form UI가 이 테스트를 만족하지 못해야 한다. GREEN 단계에서는 `SafeVillageGamePresenter`가 board root, HUD, three work locations, three resident tokens를 생성하도록 최소 변경한다. 이때 plus/minus action row를 계속 유지하지 말고 보드 구조로 바꾼다. Refactor 단계에서는 중복된 UI 생성 helper를 정리하되 gameplay rule을 건드리지 않는다.

Issue #8 완료 시점에는 Play Mode에서 화면이 폼형 카운터 레이아웃이 아니라 고정 한 화면 마을 보드처럼 보여야 한다. `Resolve Day`와 `Restart`는 여전히 조작 가능해야 하고, result log는 보조 정보로 남아도 된다. 기존 `SafeVillage.Core.Tests`와 새 Runtime Play Mode tests가 모두 통과해야 한다. Unity MCP screenshot으로 HUD, 작업 장소, 주민 토큰이 겹치지 않는지 확인한다.

Issue #9에서도 `/tdd` vertical slice를 유지한다. 한 번에 모든 interaction test를 쓰지 않는다. 첫 cycle은 "주민 토큰을 클릭하고 작업 장소를 클릭하면 보드의 배치 상태가 바뀐다"는 behavior만 테스트한다. 두 번째 cycle은 "Resolve Day가 보드 배치 상태를 사용해 기존 하루 루프를 진행한다"는 behavior를 테스트한다. 세 번째 cycle은 "Food 또는 Wall 변화와 terminal outcome이 보드에서 먼저 보인다"는 behavior를 테스트한다. 애니메이션은 internal tween value가 아니라, 플레이어가 관찰 가능한 movement/highlight/center banner로 검증한다.

Issue #9 구현은 실제 pointer input path를 검증해야 한다. `Button.onClick.Invoke()`나 private method 호출은 smoke에는 쓸 수 있지만 acceptance evidence로 쓰지 않는다. Play Mode test나 MCP probe는 `EventSystem`과 `InputSystemUIInputModule`을 통해 pointer event를 보내거나, 사람이 수동으로 클릭해 확인해야 한다. 이 guardrail은 `docs/agents/ai-mistakes.md`에 이미 기록되어 있다.

각 issue를 완료할 때마다 해당 issue에 한국어 evidence comment를 남기고 close한다. issue comment는 project work document이므로 한국어로 작성한다. `/triage` 중 남기는 comment가 아니라면 triage disclaimer는 필요하지 않다. 하지만 triage 작업 중 comment를 남길 때는 `/triage` skill의 disclaimer 규칙을 따른다.

## Concrete Steps

모든 명령은 repository root인 `/Users/kaya/Documents/Codex/codex-harness-svm-v2`에서 실행한다.

시작 전 현재 상태를 확인한다.

    git status --short --branch
    gh issue list --state open --limit 20 --json number,title,labels
    sed -n '1,180p' docs/2d-village-board-playable.md
    sed -n '1,180p' CONTEXT.md

기대 상태는 worktree가 clean이고, #6, #7, #8, #9가 open이며, #7과 #6은 `ready-for-human`, #8과 #9는 `ready-for-agent`인 것이다.

Issue #7을 시작할 때는 다음을 확인한다.

    gh issue view 7 --comments

그 다음 reference image를 `docs/references/2d-village-board-concept.png`에 만든다. 이미지 생성 도구를 사용할 경우 prompt는 다음 내용을 포함해야 한다: Safe Village Micro, fixed one-screen 2D village board, top-down or slightly angled board game view, HUD area, three work locations for Forage Guard Repair, three identical resident tokens, wall, village center, readable layout reference, not final game asset. 생성 후 `docs/references/` 아래에 저장하고, runtime `Assets/` 파일은 변경하지 않는다.

Issue #7 검증은 사람의 확인이 필요하다. 최소 검증은 다음이다.

    test -f docs/references/2d-village-board-concept.png
    git status --short

사람이 방향을 승인하면 `docs/2d-village-board-execplan.md`의 Progress와 Outcomes를 갱신하고 #7을 닫는다.

Issue #8을 시작할 때는 `/tdd` skill을 명시적으로 호출한 뒤 첫 Play Mode test를 작성한다. 새 test assembly 후보는 다음 파일이다.

    Assets/Tests/PlayMode/SafeVillage.Runtime.Tests/SafeVillage.Runtime.Tests.asmdef
    Assets/Tests/PlayMode/SafeVillage.Runtime.Tests/SafeVillageBoardPresenterTests.cs

`SafeVillage.Runtime.Tests.asmdef`는 `SafeVillage.Runtime`, `SafeVillage.Core`, `UnityEngine.TestRunner`, `Unity.InputSystem`, `UnityEngine.UI`, `Unity.TextMeshPro`를 참조해야 한다. 실제 asmdef reference 이름은 Unity가 인식하는 assembly name 기준으로 맞춘다. includePlatforms는 비워 Play Mode tests로 동작하게 한다.

첫 RED test는 scene에 `SafeVillageGamePresenter`를 붙인 GameObject를 만들고 frame을 한두 번 기다린 뒤, 다음 observable elements가 존재하는지 확인한다: `SafeVillageCanvas`, `VillageBoard`, `HudPanel`, `ForageLocation`, `GuardLocation`, `RepairLocation`, `ResidentToken1`, `ResidentToken2`, `ResidentToken3`, `ResolveButton`, `RestartButton`. 현재 구현에는 이 board object 이름들이 없으므로 실패해야 한다.

테스트 실패를 확인한 뒤 GREEN 구현을 한다. `SafeVillageGamePresenter`의 `EnsureUi()`를 보드 구조 중심으로 바꾼다. 배경, HUD, board area, work locations, resident tokens, controls, log area를 명확한 named GameObject로 생성한다. TextMeshPro와 UGUI `Image`, `Button`만 사용한다. Domain rule 계산은 계속 `VillageGame.ResolveDay()`만 사용한다.

Issue #8 검증 명령은 다음을 기본으로 한다.

    unity-mcp-cli run-tool tests-run --input '{"testMode":"EditMode","testAssembly":"SafeVillage.Core.Tests","includePassingTests":true,"includeMessages":true}'
    unity-mcp-cli run-tool tests-run --input '{"testMode":"PlayMode","testAssembly":"SafeVillage.Runtime.Tests","includePassingTests":true,"includeMessages":true}'
    unity-mcp-cli run-tool console-get-logs --input '{"maxEntries":20,"logTypeFilter":"Error","includeStackTrace":false,"lastMinutes":10}'
    unity-mcp-cli run-tool console-get-logs --input '{"maxEntries":20,"logTypeFilter":"Exception","includeStackTrace":false,"lastMinutes":10}'
    unity-mcp-cli run-tool screenshot-game-view --input '{}'
    git diff --check

기대 결과는 core Edit Mode tests와 runtime Play Mode tests가 Passed이고, Console Error와 Exception이 빈 배열이며, screenshot에서 HUD, 작업 장소 3곳, 주민 토큰 3개, Resolve/Restart controls가 겹치지 않는 것이다.

Issue #9를 시작할 때도 `/tdd` skill을 명시적으로 호출한다. 첫 RED test는 actual pointer input을 사용해 `ResidentToken1`을 클릭하고 `ForageLocation`을 클릭했을 때 보드 assignment state가 바뀌는지 확인한다. 구현은 주민 토큰 클릭으로 selected state를 만들고, work location click으로 해당 주민의 assigned action을 바꾸는 방식으로 한다. 선택된 토큰과 배치된 장소는 색, outline, label, 위치 중 최소 하나로 보드에서 관찰 가능해야 한다.

두 번째 RED test는 board assignment state가 `VillageAssignment`로 변환되어 `Resolve Day`에 쓰이는지 확인한다. 예를 들어 토큰 2개를 `ForageLocation`, 1개를 `GuardLocation`에 배치하고 `ResolveButton`을 실제 pointer input으로 누르면 Day 2, Food 4, Wall 3, Outcome InProgress가 HUD에 보여야 한다. 이 수치는 기존 domain rule의 success path 첫날과 일치한다.

세 번째 RED test는 terminal outcome feedback이다. Play Mode에서 failure 또는 victory path 중 하나를 실제 입력으로 진행하고, board center의 terminal banner가 `Victory`, `WallCollapsed`, 또는 `FoodDepleted`를 보여야 한다. 이 테스트는 animation의 internal time curve를 고정하지 않는다. 대신 banner가 visible해지는지, Food 또는 Wall feedback element가 변화했는지 같은 player-visible outcome을 본다.

Issue #9 검증 명령은 #8과 같다. 추가로 실제 pointer input path를 확인하는 probe 또는 test evidence를 기록한다. `Button.onClick.Invoke()`만으로 검증한 경우 acceptance를 만족하지 못한다.

각 issue를 닫기 전에는 다음 repository 검증을 한다.

    git status --short
    git diff --check

필요 파일만 stage하고 commit한다. commit 후 issue에는 한국어로 commit hash, 테스트 결과, screenshot/Console 확인 결과를 남긴다. 예시는 다음 형식이다.

    완료했습니다.

    - Commit: <hash>
    - 검증: SafeVillage.Core.Tests Passed, SafeVillage.Runtime.Tests Passed
    - Play Mode: HUD/작업 장소/주민 토큰 확인
    - Console: Error/Exception 없음
    - Screenshot: Game View에서 주요 요소 확인

## Validation and Acceptance

전체 계획의 최종 acceptance는 #7, #8, #9가 모두 닫히고 #6 tracking issue가 완료 조건을 만족하는 것이다. 최종 Play Mode screenshot에는 `Day`, `Food`, `Wall`, `Outcome` HUD, `Forage`, `Guard`, `Repair` 작업 장소, 주민 토큰 3개, board center terminal feedback 영역이 보여야 한다. 플레이어는 주민 토큰을 클릭하고 작업 장소를 클릭해 주민 배치를 바꾸고, `Resolve Day`를 눌러 기존 domain rule에 맞는 하루 결과를 볼 수 있어야 한다.

자동 검증은 두 층이다. Domain rule은 `SafeVillage.Core.Tests` Edit Mode tests로 검증한다. Runtime UI behavior는 `SafeVillage.Runtime.Tests` Play Mode tests로 검증한다. Play Mode tests는 가능한 실제 pointer input path를 사용한다. pointer input test가 환경 문제로 불안정하면, 실패 이유를 `Surprises & Discoveries`에 기록하고 사람의 수동 클릭 검증을 evidence로 보완하되, `Button.onClick.Invoke()`만으로 acceptance를 대체하지 않는다.

Unity Console 검증은 final run에서 Error와 Exception이 없어야 한다. screenshot 검증은 UI 요소가 보이며 서로 크게 겹치지 않아야 한다. 새 dependency를 추가했다면 package resolution 후 compile/test/screenshot까지 다시 확인해야 한다.

## Idempotence and Recovery

Issue #7 reference image 생성은 같은 path에 다시 생성해도 된다. 단, 이전 image를 바꿀 때는 왜 바꿨는지 이 ExecPlan의 Decision Log나 Outcomes에 기록한다.

Issue #8과 #9의 Runtime UI 변경은 additive test를 먼저 추가하고, 최소 구현으로 green을 만든 뒤 refactor한다. RED 상태에서 큰 refactor를 하지 않는다. Play Mode tests가 Unity dirty scene 때문에 실패하면 먼저 열린 scene을 저장하거나 clean scene으로 전환한 뒤 다시 실행한다. Unity MCP command가 transport 문제로 실패하면 Console log와 Editor state를 확인하고, 실패 사실과 우회 검증을 이 문서에 기록한다.

DOTween을 설치했다가 필요 없다고 판단되면 package 변경을 되돌리기 전에 어떤 테스트와 화면 검증이 대체 수단으로 충분했는지 기록한다. package install은 `Packages/manifest.json`과 `Packages/packages-lock.json`을 바꿀 수 있으므로, 관련 변경만 stage한다.

## Artifacts and Notes

초기 확인 시점의 핵심 파일은 다음과 같다.

    docs/2d-village-board-playable.md
    CONTEXT.md
    Assets/SafeVillage/Runtime/SafeVillageGamePresenter.cs
    Assets/SafeVillage/Runtime/SafeVillage.Runtime.asmdef
    Assets/Tests/EditMode/SafeVillage.Core.Tests/VillageGameTests.cs
    Packages/manifest.json

현재 issue queue는 다음 순서다.

    #6 2D 마을 보드 playable 만들기
    #7 2D 마을 보드 컨셉 reference 만들기
    #8 Runtime UI를 고정 한 화면 2D 마을 보드로 교체
    #9 클릭 선택 배치와 보드 피드백 애니메이션 검증

`/tdd` skill에서 이 계획에 특히 중요한 규칙은 다음이다. 모든 테스트를 한 번에 쓰지 않는다. 하나의 behavior test를 먼저 실패시키고, 그 테스트를 통과시키는 최소 구현을 한 뒤 다음 behavior로 넘어간다. 테스트는 private method나 internal helper가 아니라 Play Mode에서 관찰 가능한 behavior를 검증한다.

## Interfaces and Dependencies

기존 public domain interface는 유지한다. `SafeVillage.Core.VillageGame`, `VillageAssignment`, `VillageState`, `DayReport`, `VillageOutcome`의 의미를 바꾸지 않는다. Runtime UI는 이 public API를 사용해 state를 읽고 day를 resolve한다.

Runtime presenter는 계속 `SafeVillage.Runtime.SafeVillageGamePresenter`를 중심으로 둔다. 필요하면 내부 helper methods나 small private data structures를 추가할 수 있지만, gameplay rule을 presenter에 복제하지 않는다. 최종적으로 Runtime UI에는 다음 observable GameObject names가 있어야 한다.

    SafeVillageCanvas
    VillageBoard
    HudPanel
    ForageLocation
    GuardLocation
    RepairLocation
    ResidentToken1
    ResidentToken2
    ResidentToken3
    ResolveButton
    RestartButton

새 Runtime Play Mode test assembly는 `Assets/Tests/PlayMode/SafeVillage.Runtime.Tests/`에 둔다. Tests는 presenter를 scene에 instantiate하고 public user behavior를 검증한다. 가능한 경우 `UnityEngine.InputSystem` test utilities 또는 EventSystem pointer path를 사용해 실제 click behavior를 재현한다.

허용 dependency는 현재 Unity packages인 UGUI, TextMeshPro, Input System, Unity Test Framework, Unity MCP다. DOTween 같은 tween dependency는 #9에서 간단한 Unity coroutine이나 built-in UI 상태 변화로 충분하지 않다는 증거가 생길 때만 추가한다. dependency를 추가하면 이 ExecPlan의 Decision Log와 `Packages/manifest.json`/`packages-lock.json` 변경, compile/test evidence를 함께 기록한다.

## Revision Notes

2026-05-23 / Codex: #7-#9를 `/tdd` 기반으로 구현하고 검증하기 위한 initial Delivery ExecPlan을 작성했다. #7은 human visual gate로 두고, #8과 #9는 Play Mode behavior tests를 통한 red-green-refactor loop로 진행하도록 정했다.
