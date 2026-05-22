# Safe Village Micro

Safe Village Micro는 작은 Unity first playable을 만들면서, SVM에 맞는 Codex 작업 하네스를 검증하는 프로젝트다.

현재는 gameplay 구현 전 부트스트랩 단계다. Prompts Lab 산출물은 정리했고, 실제 프로젝트 운영 문서와 작업 기준을 구성하는 중이다.

이 README는 사람용 진입점이다. Codex 작업 규칙은 `AGENTS.md`를 기준으로 한다.

## 현재 상태

- Unity gameplay 구현은 아직 시작하지 않았다.
- root `AGENTS.md`와 `.agent/PLANS.md`를 준비했다.
- Matt skills는 설치와 setup을 완료했고, GitHub Issues 기반 workflow를 사용한다.
- custom skill과 hooks는 first playable 이후 gap review와 smoke test에서 적용 범위를 정한다.
- Unity MCP는 `IvanMurzak/Unity-MCP`를 후보로 두되, smoke gate 통과 전에는 검증 완료로 보지 않는다.
- first playable 범위와 완료 기준은 `docs/first-playable.md`에 정리했다.

## 주요 문서

사람은 이 목록에서 필요한 문서를 열어보면 된다. Codex 작업 규칙은 `AGENTS.md`가 기준이다.

- `AGENTS.md`: Codex가 항상 확인할 기본 작업 규칙
- `.agent/PLANS.md`: OpenAI ExecPlan 원문 기준
- `docs/bootstrap-plan.md`: 현재 부트스트랩 전환 계획
- `docs/agents/commit-policy.md`: 작업 완료 후 커밋 기준
- `docs/agents/decision-policy.md`: 장기 결정 기록 기준
- `docs/agents/issue-tracker.md`: Matt skills가 사용할 GitHub Issues 기준
- `docs/agents/domain.md`: Matt skills가 읽을 domain 문서 기준
- `docs/first-playable.md`: Safe Village Micro first playable 범위와 완료 기준
- `docs/references/karpathy-guidelines.md`: 기본 코딩 행동 원칙 참조

## 다음 단계

1. `IvanMurzak/Unity-MCP` smoke gate를 진행한다.
2. first playable 구현 방식을 정한다.
3. 그 다음 Unity 구현을 시작한다.
