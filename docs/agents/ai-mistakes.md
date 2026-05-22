# AI Mistake Guardrails

## 목적

AI가 반복하면 안 되는 실수를 짧은 guardrail로 남긴다.

이 파일은 긴 회고나 작업 로그가 아니다. 모든 실수를 기록하지 않고, 다음 조건을 모두 만족하는 경우만 기록한다.

- 같은 종류의 실수가 다시 나면 프로젝트 문서나 workflow가 깨진다.
- 원인이 단순 부주의가 아니라 문서/도구 경계 오해다.
- 재발 방지 규칙을 한 문장으로 만들 수 있다.

## 기록 규칙

- 한 항목은 `Mistake`, `Impact`, `Guardrail`, `Rule location`만 적는다.
- 이미 별도 정책 문서에 규칙이 있으면 여기에는 링크만 둔다.
- 항목이 많아지면 오래된 사건 설명을 늘리지 말고, 공통 규칙을 hook, custom skill, policy 문서로 승격한다.
- 사람의 승인 없이 외부 원천 문서, 설치된 skill, setup 생성 문서의 의미를 바꾸는 실수는 항상 기록한다.

## Guardrails

### 2026-05-22 - Tool-owned docs must not be remapped

Mistake: Matt skills가 실제로 사용하는 `CONTEXT.md`와 `docs/adr/` 경로를 SVM의 `docs/decisions/` 정책으로 재해석하려 했다.

Impact: skill이 기대하는 glossary/ADR workflow를 깨고, 다른 agent가 잘못된 문서 경로를 따르게 만들 수 있었다.

Guardrail: 외부 원천 문서, 설치된 skill, setup 생성 문서의 의미와 경로는 원천 확인 없이 로컬 정책으로 치환하지 않는다. 충돌처럼 보이면 대체 관계가 아니라 별도 용도인지 먼저 확인한다.

Rule location: `docs/agents/documentation-policy.md`
