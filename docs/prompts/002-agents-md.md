# 002. AGENTS.md 이해

## 목적

AGENTS.md가 Codex 행동에 어떤 방식으로 영향을 주는지 이해한다.

## 실행 규칙

기본 실행 모드: 튜터 모드

Codex에게 `이 파일을 docs/prompts/README.md의 튜터 모드로 실행해줘`라고 요청한다. 모드를 생략해도 이 파일은 튜터 모드로 실행한다. 수동 실행할 때만 README의 튜터 모드 wrapper를 프롬프트 본문 앞에 붙인다.

## 결과 기록 위치

`docs/prompt-results/002-agents-md.md`

## 프롬프트 본문

```text
AGENTS.md의 역할을 이해하고 싶다.

현재 repo를 기준으로 다음을 설명해줘.

1. Codex는 AGENTS.md를 언제 읽는가?
2. global AGENTS.md와 repo AGENTS.md는 어떻게 다르게 작동하는가?
3. subdirectory AGENTS.md를 두면 어떤 일이 생기는가?
4. AGENTS.md에 넣어야 할 내용과 넣지 말아야 할 내용은 무엇인가?
5. Unity 프로젝트에서 AGENTS.md가 너무 길어질 때 어떤 문제가 생기는가?
6. Safe Village Micro 프로젝트라면 AGENTS.md는 어떤 역할까지만 맡아야 하는가?

출력:
- 핵심 설명
- 좋은 AGENTS.md 예시 구조
- 나쁜 AGENTS.md 예시 구조
- 내가 실험해볼 질문 3개

파일 수정은 하지 마라.
```
