# 015. Subagents 이해

## 목적

Codex subagents를 언제 쓰면 좋고 Unity 구현 작업에서는 왜 위험할 수 있는지 이해한다.

## 실행 규칙

기본 실행 모드: 튜터 모드

Codex에게 `이 파일을 docs/prompts/README.md의 튜터 모드로 실행해줘`라고 요청한다. 모드를 생략해도 이 파일은 튜터 모드로 실행한다. 수동 실행할 때만 README의 튜터 모드 wrapper를 프롬프트 본문 앞에 붙인다.

## 결과 기록 위치

`docs/prompt-results/015-subagents.md`

## 프롬프트 본문

```text
Codex subagents가 무엇인지 이해하고 싶다.

Safe Village Micro 프로젝트에서 subagents를 쓸 수 있는 상황과 쓰면 안 되는 상황을 설명해줘.

다음을 구분해줘.

1. 일반 Codex 단일 세션으로 충분한 작업
2. subagent를 쓰면 좋은 리서치 작업
3. subagent를 쓰면 오히려 위험한 구현 작업
4. Unity 프로젝트에서 subagent 결과를 검증하는 방법
5. docs/threads 구조와 subagents의 관계

출력:
- subagents 개념 설명
- 좋은 사용 예
- 나쁜 사용 예
- 지금 단계에서 실험할 prompt 2개
- 보류해야 할 이유

파일 수정은 하지 마라.
```
