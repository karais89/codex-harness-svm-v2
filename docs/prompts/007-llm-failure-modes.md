# 007. LLM Failure Mode 분석

## 목적

Codex가 Unity 프로젝트에서 만들 수 있는 반복 실수와 대응 수단을 예측한다.

## 실행 규칙

기본 실행 모드: 튜터 모드

Codex에게 `이 파일을 docs/prompts/README.md의 튜터 모드로 실행해줘`라고 요청한다. 모드를 생략해도 이 파일은 튜터 모드로 실행한다. 수동 실행할 때만 README의 튜터 모드 wrapper를 프롬프트 본문 앞에 붙인다.

## 결과 기록 위치

`docs/prompt-results/007-llm-failure-modes.md`

## 프롬프트 본문

```text
Codex가 Unity 프로젝트에서 자주 할 수 있는 실수를 예측해줘.

상황:
- Safe Village Micro는 작은 Unity 2D 프로젝트다.
- 나는 직접 코딩보다 Codex 중심 workflow를 실험하고 싶다.
- 지금은 구현 전이다.

해야 할 일:
1. Codex가 할 수 있는 실수를 유형별로 나눠라.
2. 각 실수를 AGENTS.md, skill, hook, prompt, test 중 무엇으로 막을 수 있는지 제안해라.
3. 막기 어려운 실수는 무엇인지 말해라.
4. Unity 특유의 위험을 따로 정리해라.
5. docs/ai-mistakes.md에 어떤 형식으로 기록하면 좋을지 제안해라.

파일 수정은 하지 마라.
```
