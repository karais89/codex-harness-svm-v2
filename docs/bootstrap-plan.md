# Safe Village Micro 부트스트랩 계획

## 목적

이 문서는 Prompts Lab 이후 Safe Village Micro를 실제 프로젝트 운영 구조로 옮기기 위한 임시 전환 문서다.

역할은 프로젝트의 영구 운영 계획이 아니라, `README.md`, `AGENTS.md`, `.agent/PLANS.md`, 결정 기록 문서, first playable 기준을 만들기 전까지 필요한 구성 작업을 빠짐없이 진행하는 것이다.

이 문서는 gameplay 구현 계획서가 아니며, 구성 작업이 끝나면 완료된 전환 기록으로 남기거나 축소한다.

## 확정된 운영 결정

1. `AGENTS.md`는 채택한다.
   - root `AGENTS.md` 하나를 둔다.
   - 즉시 지켜야 할 행동 규칙과 프로젝트 문서 링크만 짧게 둔다.
   - 기본 코딩 행동 원칙은 `docs/references/karpathy-guidelines.md`를 기준 파일로 둔다.
   - root `AGENTS.md`에는 원문 전체를 복사하지 않고 기준 파일 링크와 SVM 전용 규칙만 둔다.
   - 커밋 규칙은 `docs/agents/commit-policy.md`로 분리하고 root `AGENTS.md`에는 링크만 둔다.
   - 결정 기록 규칙은 `docs/agents/decision-policy.md`로 분리하고 root `AGENTS.md`에는 링크만 둔다.
   - 하위 `AGENTS.md`는 폴더별 반복 실패가 확인된 뒤에만 검토한다.

2. `.agent/PLANS.md`와 ExecPlan은 채택한다.
   - OpenAI Cookbook의 `Using PLANS.md for multi-hour problem solving`을 원천 기준으로 사용한다.
   - OpenAI 기준 원문은 `.agent/PLANS.md`에 둔다.
   - `AGENTS.md`에는 OpenAI 글의 ExecPlan 지시 문장을 직접 둔다.
   - active ExecPlan은 first playable 구현, 큰 리팩터링, 위험한 Unity asset/config 변경처럼 여러 단계와 검증이 필요한 작업에만 만든다.
   - `.agent/PLANS.md` 원문은 수정하지 않는다.
   - 다만 SVM에서는 원문의 자율 진행 규칙을 승인된 ExecPlan 구현 단계에만 적용한다.
   - 부트스트랩, governance, design 결정 단계에서는 사용자 확인을 우선한다.

3. Matt skills는 채택한다.
   - SVM v1의 기본 workflow 후보로 본다.
   - tmp smoke test로 생성 파일과 문서 경계를 확인하기 전에는 setup 결과를 공식 repo에 바로 반영하지 않는다.
   - issue tracker는 Matt skills의 기본 방향에 맞춰 GitHub Issues를 1순위 후보로 둔다.
   - local markdown은 GitHub Issues를 쓰기 어렵거나 repo-local 실험이 필요할 때의 fallback으로만 본다.
   - smoke test는 `/private/tmp`의 throwaway repo에서 진행한다.
   - smoke test에서는 생성 파일, 설정, issue tracker 방식, PRD/issues 위치만 관찰한다.
   - Matt skills가 실제로 만드는 산출물을 tmp smoke에서 확인한 뒤, 그대로 채택할지, 위치만 조정할지, 공식 구조에는 넣지 않고 참조만 할지 결정한다.

4. custom skills 도입 경로는 채택한다.
   - 프로젝트 전용 custom skill은 자동 trigger 방식으로 만들지 않는다.
   - review/evaluator skill은 사용자가 `$`로 명시 호출하는 방식을 우선한다.
   - 첫 custom skill은 AI gap review 이후 선정한다.
   - 현재 1순위 후보는 `ai-persona-architect-evaluator`다.
   - 보조 후보는 `mistake-to-guardrail-reviewer`, `unity-micro-scope-guard`다.

5. hooks 도입 경로는 채택한다.
   - hooks는 guardrail 후보 계층으로 본다. 단, 완전한 보안 경계로 보지는 않는다.
   - 첫 실용 후보는 `Stage Router Hook`과 `Protected Unity Edit Guard`다.
   - blocking 동작을 켜기 전에 dry-run 또는 warning smoke test를 거친다.
   - smoke 결과를 확인한 뒤 실제 채택 범위와 강제 수준을 정한다.
   - 후속 후보는 completion verification, permission/escalation guard, decision capture다.

6. MCP 도입 경로는 채택한다.
   - 구현 단계에서 Editor 상태 검증에는 검증된 Unity MCP를 우선 검토한다.
   - Scene, GameObject, Component, Console, Play Mode 상태 확인은 MCP 대상이다.
   - 실제 MCP 도구와 사용 범위는 Unity 환경 확인 후 확정한다.
   - custom MCP tool은 반복 필요가 확인되기 전까지 공식 도구로 승격하지 않는다.

7. plugin 제작은 보류한다.
   - 지금 plugin을 만들지 않는다.
   - SVM v1 완료 후 pluginization checkpoint를 필수 단계로 둔다.
   - 그때 실제로 반복 사용된 AGENTS 규칙, custom skills, hooks, MCP tools, scripts, templates만 평가한다.

8. `docs/threads`는 폐기한다.
   - 대화 thread 기록용 문서 트리는 만들지 않는다.
   - 결정은 명시적인 decision 또는 planning 문서에 기록한다.

9. Unity 구현은 governance가 잠긴 뒤 시작한다.
   - 구현 전 필수 조건:
     - root `AGENTS.md`
     - `.agent/PLANS.md`
     - Matt skills tmp smoke
     - first playable 범위와 완료 기준
   - custom skill, hook, MCP는 first playable을 반드시 막는 선행 조건이 아니라, 적용할 경우의 최소 기준만 정한다.

10. `docs/current.md`는 폐기한다.
   - 병렬 Codex 작업 조정용 최소 점유판으로 검토했지만, 단일 session에서는 필요 없고 stale 상태 문서가 될 위험이 크다.
   - 병렬 작업은 기본적으로 GitHub Issues, branch, git worktree, PR/commit 범위로 조정한다.
   - 반복 충돌이 실제로 발생하면 그때 `docs/current.md` 또는 별도 coordination 문서를 재검토한다.

11. 결정 기록은 ADR-style 파일로 관리한다.
   - 단일 `docs/decisions.md`는 만들지 않는다.
   - 장기 결정이 필요할 때만 `docs/decisions/NNNN-short-title.md`를 만든다.
   - `docs/decisions/index.md`는 라우팅용 index로 두며, decision 파일 생성 또는 상태 변경 시 반드시 함께 갱신한다.
   - 상세 규칙은 `docs/agents/decision-policy.md`를 따른다.

12. first playable 목표는 Safe Village 마이크로 하루 루프 구현과 검증이다.
   - 이번 버전은 기존 컨셉을 새로 찾는 단계가 아니라, SVM v3에서 마이크로 루프를 구현하고 검증하는 단계다.
   - 핵심 감각은 `오늘 뭘 포기할 것인가?`다.
   - 기본 루프는 `DayStart -> Assignment -> DayAction -> NightCheck -> DayEnd`다.
   - 최소 자원은 Food, Wall, Villagers다.
   - 목표는 1개 씬, 간단 UI, 3일 생존 검증이다.
   - 실패 조건은 식량 부족 또는 벽 붕괴다.
   - Runtime UI는 Unity UI와 TextMeshPro를 사용하고, 기본 폰트 후보는 Pretendard다.
   - Editor tool 작업이 필요하면 UI Toolkit을 우선 사용한다.
   - 3D 마을, 건물/애니메이션, 물/전력/의약품, 장기 캠페인, 스토리 이벤트는 first playable 범위에서 제외한다.

## 문서 역할 분리

- `README.md`: 사람용 프로젝트 소개, 실행 방법, 현재 상태.
- `AGENTS.md`: Codex가 항상 따라야 할 짧은 행동 규칙과 문서 지도.
- `docs/agents/commit-policy.md`: 작업 완료 후 커밋 기본값과 stage/report 규칙.
- `docs/agents/decision-policy.md`: 장기 결정 파일과 `docs/decisions/index.md` 갱신 규칙.
- `.agent/PLANS.md`: OpenAI ExecPlan 원천 기준 원문.
- `docs/decisions/index.md`: 장기 결정 파일의 라우팅 index. 필요할 때 생성한다.
- `docs/first-playable.md`: first playable 범위와 완료 기준.
- `docs/bootstrap-plan.md`: 위 문서들이 준비될 때까지 사용하는 임시 전환 계획.

## 계획 진행 방식

계획은 한 번에 크게 확정하지 않고, 결정 하나씩 진행한다.

각 단계는 다음 순서로 진행한다.

1. 목표를 적는다.
2. 범위를 적는다.
3. 제외할 것을 적는다.
4. 하나의 집중 질문을 한다.
5. 사용자 답변을 기록한다.
6. 답변을 확정 결정 또는 미해결 항목으로 바꾼다.
7. 현재 항목이 명확해진 뒤 다음 질문으로 넘어간다.

## 부트스트랩 완료 조건

1. `README.md` 생성 또는 정리 완료. 상태: 완료.
2. root `AGENTS.md` 생성 완료. 상태: 완료.
3. OpenAI 원천 기준의 `.agent/PLANS.md` 생성 완료. 상태: 완료.
4. 병렬 Codex 조정 방식 확정. 상태: `docs/current.md` 폐기, GitHub Issues/branch/worktree 중심으로 조정.
5. 결정 기록 문서 위치 확정. 상태: `docs/decisions/` + `index.md` 방식 채택.
6. Matt skills tmp smoke 계획 확정. 상태: 완료.
7. 첫 custom skill 후보 결정. 상태: AI gap review 이후 확정.
8. 첫 hook dry-run/warn 기준 확정. 상태: smoke 이후 적용 범위 확정.
9. Unity MCP 사용 규칙 확정. 상태: Unity 환경 확인 후 도구와 범위 확정.
10. first playable 범위와 완료 기준 문서 생성. 상태: 완료.

## 가까운 진행 단계

1. AI gap review를 진행하고 첫 custom skill을 고른다.
2. 첫 hook dry-run/warn smoke test를 설계한다.
3. Unity MCP 사용 규칙을 정한다.
4. first playable의 미정 항목을 확정한다.
5. 그 다음 Unity 구현을 시작한다.

## Matt skills smoke 결과

smoke 위치: `/private/tmp/svm-matt-skills-smoke.RTA92s`

관찰 결과:

- setup skill은 root `AGENTS.md` 또는 `CLAUDE.md`에 `Agent skills` 블록을 추가한다.
- setup skill은 `docs/agents/issue-tracker.md`, `docs/agents/triage-labels.md`, `docs/agents/domain.md`를 만든다.
- issue tracker는 setup 단계에서 고른다. GitHub remote가 있으면 GitHub Issues가 기본 후보이고, remote가 없거나 사용자가 원하면 local markdown을 쓸 수 있다.
- local markdown 방식은 `.scratch/<feature-slug>/PRD.md`와 `.scratch/<feature-slug>/issues/<NN>-<slug>.md`를 사용한다.
- `to-prd`와 `to-issues`는 tracker 위치를 새로 정하는 스킬이 아니라, setup에서 정한 issue tracker 규칙을 소비한다.

SVM 반영 판단:

- issue tracker는 GitHub Issues를 1순위 후보로 둔다.
- local markdown은 fallback으로만 본다.
- SVM에는 Matt skills 산출물 경로를 미리 박지 않는다.
- local markdown을 쓰더라도 `.scratch/`는 작업 산출물 후보이지 영구 docs 구조로 보지 않는다.

## 현재 상태

- final-selection tag 이후 Prompts Lab raw files는 제거했다.
- 현재 전환 작업은 이 문서에서 이어간다.
- 이 결정들로부터 시작된 Unity gameplay 구현은 아직 없다.
