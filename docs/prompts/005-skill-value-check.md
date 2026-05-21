# 005. Skill 후보 가치 판단

## 목적

여러 후보가 실제 Codex skill로 만들 가치가 있는지 평가한다.

## 실행 규칙

기본 실행 모드: 튜터 모드

Codex에게 `이 파일을 docs/prompts/README.md의 튜터 모드로 실행해줘`라고 요청한다. 모드를 생략해도 이 파일은 튜터 모드로 실행한다. 수동 실행할 때만 README의 튜터 모드 wrapper를 프롬프트 본문 앞에 붙인다.

## 결과 기록 위치

`docs/prompt-results/005-skill-value-check.md`

## 프롬프트 본문

```text
아래 후보들이 Codex skill로 만들 가치가 있는지 평가해줘.

후보:
1. Socratic clarification
2. Unity scope guard
3. Harness retrospective
4. Unity validation checklist
5. PRD generator
6. ExecPlan reviewer
7. AI mistake logger
8. Portfolio writeup helper
9. MCP experiment planner

평가 기준:
- 반복 사용 가능성
- instruction-only로 충분한지
- script가 필요한지
- AGENTS.md에 두는 게 나은지
- docs/prompts/에만 두는 게 나은지
- 너무 범용적이라 오히려 위험한지
- Safe Village Micro에 직접 도움이 되는지

출력:
- 채택 후보
- 보류 후보
- 폐기 후보
- 각 후보의 이유
- 첫 번째로 실험할 skill 1개 추천

파일 수정은 하지 마라.
```
