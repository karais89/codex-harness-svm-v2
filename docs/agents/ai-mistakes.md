# AI Mistake Guardrails

## 목적

AI가 반복하면 안 되는 실수를 짧은 guardrail로 남긴다.

이 파일은 긴 회고나 작업 로그가 아니다. 모든 실수를 기록하지 않고, 다음 조건을 모두 만족하는 경우만 기록한다.

- 같은 종류의 실수가 다시 나면 프로젝트 문서나 workflow가 깨진다.
- 원인이 단순 부주의가 아니라 문서/도구 경계 오해다.
- 재발 방지 규칙을 한 문장으로 만들 수 있다.

## 기록 규칙

- 한 항목은 `Mistake`, `Impact`, `Guardrail`만 적는다.
- 항목이 많아지면 오래된 사건 설명을 늘리지 말고, 공통 규칙을 hook, custom skill, policy 문서로 승격한다.
- 사람의 승인 없이 외부 원천 문서, 설치된 skill, setup 생성 문서의 의미를 바꾸는 실수는 항상 기록한다.

## Guardrails

### 2026-05-22 - Tool-owned docs must not be remapped

Mistake: Matt skills가 실제로 사용하는 `CONTEXT.md`와 `docs/adr/` 경로를 SVM의 `docs/decisions/` 정책으로 재해석하려 했다.

Impact: skill이 기대하는 glossary/ADR workflow를 깨고, 다른 agent가 잘못된 문서 경로를 따르게 만들 수 있었다.

Guardrail: 외부 원천 문서, 설치된 skill, setup 생성 문서의 의미와 경로는 원천 확인 없이 로컬 정책으로 치환하지 않는다. 충돌처럼 보이면 대체 관계가 아니라 별도 용도인지 먼저 확인한다.

### 2026-05-23 - Direct button invocation is not click verification

Mistake: Unity UI 검증에서 `Button.onClick.Invoke()`를 실제 버튼 클릭 검증으로 취급해 `EventSystem`이 없는 상태를 놓쳤다.

Impact: Play Mode probe는 통과했지만 사용자가 마우스로 버튼을 누르면 입력 이벤트가 전달되지 않아 playable이 실제로 조작되지 않았다.

Guardrail: Unity UI 클릭 acceptance는 `EventSystem`/input module 존재와 실제 pointer event 또는 사람의 수동 클릭으로 검증하고, `onClick.Invoke()`는 gameplay callback smoke로만 취급한다.

### 2026-05-23 - GitHub Issues are project work documents

Mistake: repo의 Language 규칙을 프로젝트 문서에는 적용했지만, 새 GitHub Issue 제목과 본문에는 적용하지 않고 영어로 작성했다.

Impact: PRD와 issue queue가 repo의 한국어 작업 문서 기준에서 벗어나고, 사람용 planning 흐름이 불필요하게 이중 언어로 갈라졌다.

Guardrail: PRD, ExecPlan, GitHub Issue 제목/본문/코멘트는 프로젝트 작업 문서로 보고 한국어로 작성한다. 코드 식별자, 명령어, 경로, 외부 원문 제목만 필요한 경우 영어를 유지한다.

### 2026-05-23 - Commit policy is part of completion

Mistake: README 문서 변경을 완료하고도 repo의 commit policy 기본값을 적용하지 않아 사용자가 별도로 커밋을 요청하게 만들었다.

Impact: 작업 완료 상태와 git history가 분리되어 다음 agent가 완료된 변경인지 미완성 변경인지 다시 확인해야 했다.

Guardrail: 사용자가 코드나 문서 변경을 요청했고 작업이 완료되면 `docs/agents/commit-policy.md`의 예외에 해당하지 않는 한 검증 후 요청 범위 파일만 stage해서 커밋한다.
