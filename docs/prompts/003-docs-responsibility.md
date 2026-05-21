# 003. 문서 역할 분리

## 목적

프로젝트 문서들의 책임을 나누고 Codex가 언제 어떤 문서를 읽어야 하는지 정리한다.

## 실행 규칙

기본 실행 모드: 튜터 모드

Codex에게 `이 파일을 docs/prompts/README.md의 튜터 모드로 실행해줘`라고 요청한다. 모드를 생략해도 이 파일은 튜터 모드로 실행한다. 수동 실행할 때만 README의 튜터 모드 wrapper를 프롬프트 본문 앞에 붙인다.

## 결과 기록 위치

`docs/prompt-results/003-docs-responsibility.md`

## 프롬프트 본문

```text
이 프로젝트의 문서 역할을 분리해줘.

문서 후보:
- README.md
- AGENTS.md
- PLANS.md
- docs/project-goal.md
- docs/prompts/README.md
- docs/prompts/
- docs/prompt-results/
- docs/threads/
- docs/decisions.md
- docs/progress.md
- docs/ai-mistakes.md
- docs/research/

해야 할 일:
1. 각 문서의 책임을 1문장으로 정의
2. 겹치는 책임이 있는지 찾기
3. 어떤 문서는 없애도 되는지 판단
4. Codex가 매 세션 읽어야 하는 문서와 필요할 때만 읽을 문서 구분
5. 문서가 너무 많아질 때의 위험 설명
6. 최소 문서 세트와 확장 문서 세트 제안

파일 수정은 하지 마라.
```
