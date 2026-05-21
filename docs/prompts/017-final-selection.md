# 017. 최종 선택

## 목적

prompts lab의 전체 결과를 바탕으로 Safe Village Micro 개발에 실제 채택할 최소 구성을 고른다.

## 실행 규칙

기본 실행 모드: 일반 모드

Codex에게 `이 파일을 docs/prompts/README.md의 일반 모드로 실행해줘`라고 요청한다. 모드를 생략해도 이 파일은 일반 모드로 실행한다. 수동 실행할 때만 README의 일반 모드 wrapper를 프롬프트 본문 앞에 붙인다.

## 결과 기록 위치

`docs/prompt-results/017-final-selection.md`

## 프롬프트 본문

```text
prompts lab의 모든 결과를 바탕으로 Safe Village Micro 개발에 실제 채택할 구성을 제안해줘.

읽을 문서:
- docs/prompts/README.md
- docs/prompts/
- docs/prompt-results/
- docs/decisions.md
- docs/progress.md

판단할 항목:
1. AGENTS.md 구조
2. PLANS.md / ExecPlan 사용 여부
3. Matt skills 도입 여부
4. custom skills 도입 여부
5. hooks 도입 여부
6. MCP 도입 시점
7. plugin 보류/진행 여부
8. docs/threads 유지 여부
9. 실제 Unity 구현 시작 조건

출력:
- 채택
- 보류
- 폐기
- 이유
- 다음 작업 순서
- 구현으로 넘어가기 전 체크리스트

중요:
- 새 기능 제안보다 실험 결과 기반 선택에 집중해라.
- 모든 것을 다 채택하지 마라.
- 작은 구성을 우선 추천해라.
```
