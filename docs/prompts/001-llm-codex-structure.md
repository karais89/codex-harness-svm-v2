# 001. LLM/Codex 구조 이해

## 목적

Codex/LLM의 기본 구조와 Unity 프로젝트에서의 역할을 초보자 관점에서 이해한다.

## 실행 규칙

기본 실행 모드: 튜터 모드

Codex에게 `이 파일을 docs/prompts/README.md의 튜터 모드로 실행해줘`라고 요청한다. 모드를 생략해도 이 파일은 튜터 모드로 실행한다. 수동 실행할 때만 README의 튜터 모드 wrapper를 프롬프트 본문 앞에 붙인다.

## 결과 기록 위치

`docs/prompt-results/001-llm-codex-structure.md`

## 프롬프트 본문

```text
현재 나는 Codex를 사용해서 Unity 프로젝트를 개발하려고 한다.
하지만 지금은 구현이 아니라 Codex/LLM의 구조를 이해하는 것이 목적이다.

다음을 초보자가 이해할 수 있게 설명해줘.

1. 일반 ChatGPT와 Codex의 차이
2. Codex가 repo를 읽고 작업하는 방식
3. AGENTS.md가 Codex 행동에 영향을 주는 방식
4. skill과 prompt의 차이
5. hook과 skill의 차이
6. MCP와 plugin이 필요한 순간
7. Unity 프로젝트에서 Codex가 잘하는 일과 못하는 일

중요:
- 실제 파일을 수정하지 마라.
- Safe Village Micro 구현 계획으로 넘어가지 마라.
- 설명 후, 다음에 실행할 만한 실험 1-2개를 제안해줘.
```
