# Safe Village Micro 진행 계획

## 목적

이 문서는 제거된 Prompts Lab 작업 파일을 대체하는 현재 계획 문서다.

확정된 운영 결정과, 앞으로의 계획을 사용자 확인 질문을 통해 단계별로 도출하는 방식을 기록한다. 아직 게임 구현 계획서가 아니다.

## 확정된 운영 결정

1. `AGENTS.md`는 채택한다.
   - root `AGENTS.md` 하나를 둔다.
   - 즉시 지켜야 할 행동 규칙과 프로젝트 문서 링크만 짧게 둔다.
   - 하위 `AGENTS.md`는 폴더별 반복 실패가 확인된 뒤에만 검토한다.

2. `PLANS.md`와 ExecPlan은 채택한다.
   - OpenAI의 원문 글 또는 공식 가이드를 원천 기준으로 사용한다.
   - `PLANS.md`는 템플릿과 운영 규칙 문서로 둔다.
   - active ExecPlan은 first playable 구현, 큰 리팩터링, 위험한 Unity asset/config 변경처럼 여러 단계와 검증이 필요한 작업에만 만든다.

3. Matt skills는 채택한다.
   - SVM v1의 기본 workflow 후보로 본다.
   - tmp smoke test로 생성 파일과 문서 경계를 확인하기 전에는 setup 결과를 공식 repo에 바로 반영하지 않는다.

4. custom skills는 채택한다.
   - 프로젝트 전용 custom skill은 자동 trigger 방식으로 만들지 않는다.
   - review/evaluator skill은 사용자가 `$`로 명시 호출하는 방식을 우선한다.
   - 첫 custom skill은 AI gap review 이후 선정한다.
   - 현재 1순위 후보는 `ai-persona-architect-evaluator`다.
   - 보조 후보는 `mistake-to-guardrail-reviewer`, `unity-micro-scope-guard`다.

5. hooks는 채택한다.
   - hooks는 필수 guardrail 계층으로 본다. 단, 완전한 보안 경계로 보지는 않는다.
   - 첫 실용 후보는 `Stage Router Hook`과 `Protected Unity Edit Guard`다.
   - parent repo에서 blocking 동작을 켜기 전에 dry-run 또는 warning smoke test를 거친다.
   - 후속 후보는 completion verification, permission/escalation guard, decision capture다.

6. MCP는 채택한다.
   - 구현 단계에서 Editor 상태 검증에는 검증된 Unity MCP를 사용한다.
   - Scene, GameObject, Component, Console, Play Mode 상태 확인은 MCP 대상이다.
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
     - `PLANS.md`
     - Matt skills tmp smoke
     - 첫 custom skill 후보 결정
     - 첫 hook dry-run/warn 설계
     - Unity MCP 사용 규칙
     - first playable 범위와 완료 기준

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

## 가까운 진행 단계

1. 영구 docs 구조를 결정한다.
2. root `AGENTS.md`를 작성한다.
3. OpenAI 원천 기준으로 `PLANS.md`를 작성한다.
4. Matt skills tmp smoke test를 설계한다.
5. AI gap review를 진행하고 첫 custom skill을 고른다.
6. 첫 hook dry-run/warn smoke test를 설계한다.
7. Unity MCP 사용 규칙을 정한다.
8. first playable 범위와 완료 기준을 정한다.
9. 그 다음 Unity 구현을 시작한다.

## 현재 상태

- final-selection tag 이후 Prompts Lab raw files는 제거했다.
- 현재 계획은 이 문서에서 이어간다.
- 이 결정들로부터 시작된 Unity gameplay 구현은 아직 없다.
