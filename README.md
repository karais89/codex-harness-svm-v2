# Safe Village Micro

Safe Village Micro는 작은 Unity first playable을 만들면서, SVM에 맞는 Codex 작업 하네스를 검증하는 프로젝트다.

이 README는 사람용 진입점이다. Codex 작업 규칙은 `AGENTS.md`를 기준으로 한다.

## 상태 확인

- 현재 작업 queue와 완료/진행 상태는 GitHub Issues를 기준으로 확인한다.
- 구현 진행과 검증 기록은 관련 ExecPlan을 기준으로 확인한다.
- README에는 구현 전/진행 중/완료 같은 휘발성 상태 문구를 두지 않는다.

## 주요 문서

사람은 이 목록에서 필요한 문서를 열어보면 된다. Codex 작업 규칙은 `AGENTS.md`가 기준이다.

- `AGENTS.md`: Codex가 항상 확인할 기본 작업 규칙
- `.agent/PLANS.md`: OpenAI ExecPlan 원문 기준
- `CONTEXT.md`: Safe Village Micro domain language와 용어 경계
- `docs/bootstrap-plan.md`: 부트스트랩 전환 기록
- `docs/agents/commit-policy.md`: 작업 완료 후 커밋 기준
- `docs/agents/decision-policy.md`: 장기 결정 기록 기준
- `docs/agents/ai-mistakes.md`: 재발하면 안 되는 AI 실수 guardrail
- `docs/agents/issue-tracker.md`: Matt skills가 사용할 GitHub Issues 기준
- `docs/agents/domain.md`: Matt skills가 읽을 domain 문서 기준
- `docs/first-playable.md`: Safe Village Micro first playable 범위와 완료 기준
- `docs/first-playable-execplan.md`: first playable 구현과 검증 기록
- `docs/2d-village-board-playable.md`: 2D 마을 보드 playable 미니 PRD
- `docs/2d-village-board-execplan.md`: 2D 마을 보드 playable 구현 계획과 진행 기록
- `docs/references/karpathy-guidelines.md`: 기본 코딩 행동 원칙 참조

## 다음 단계

1. `gh issue list --state open --limit 20`으로 다음 작업 issue를 확인한다.
2. 해당 issue의 기준 문서와 ExecPlan을 확인한 뒤 작업한다.
