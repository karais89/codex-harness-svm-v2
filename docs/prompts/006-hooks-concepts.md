# 006. Hooks 개념 이해

## 목적

Codex hook의 역할과 skill, AGENTS.md와의 차이를 이해한다.

## 실행 규칙

기본 실행 모드: 튜터 모드

Codex에게 `이 파일을 docs/prompts/README.md의 튜터 모드로 실행해줘`라고 요청한다. 모드를 생략해도 이 파일은 튜터 모드로 실행한다. 수동 실행할 때만 README의 튜터 모드 wrapper를 프롬프트 본문 앞에 붙인다.

## 결과 기록 위치

`docs/prompt-results/006-hooks-concepts.md`

## 프롬프트 본문

```text
Codex hooks의 개념을 이해하고 싶다.

다음을 설명해줘.

1. hook은 skill과 무엇이 다른가?
2. hook은 AGENTS.md와 무엇이 다른가?
3. hook은 언제 실행되는가?
4. hook이 잘하는 일과 못하는 일은 무엇인가?
5. Unity 프로젝트에서 hook으로 막으면 좋은 위험은 무엇인가?
6. hook으로 막으면 오히려 개발을 방해할 수 있는 것은 무엇인가?
7. Safe Village Micro에서 처음 실험할 hook 3개를 제안해줘.

중요:
- hooks 파일을 만들지 마라.
- 실제 활성화하지 마라.
- 개념 이해와 실험 설계만 해줘.
```
