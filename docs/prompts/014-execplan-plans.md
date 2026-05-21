# 014. ExecPlan / PLANS.md 이해

## 목적

ExecPlan과 PLANS.md를 언제 써야 하는지, prompts lab 단계와 구현 단계에서 어떻게 달라지는지 이해한다.

## 실행 규칙

기본 실행 모드: 튜터 모드

Codex에게 `이 파일을 docs/prompts/README.md의 튜터 모드로 실행해줘`라고 요청한다. 모드를 생략해도 이 파일은 튜터 모드로 실행한다. 수동 실행할 때만 README의 튜터 모드 wrapper를 프롬프트 본문 앞에 붙인다.

## 결과 기록 위치

`docs/prompt-results/014-execplan-plans.md`

## 프롬프트 본문

```text
ExecPlan과 PLANS.md의 역할을 이해하고 싶다.

다음을 설명해줘.

1. 일반 plan과 ExecPlan은 무엇이 다른가?
2. ExecPlan이 필요한 작업과 필요 없는 작업은 어떻게 나누는가?
3. Unity 프로젝트에서 ExecPlan이 특히 필요한 순간은 언제인가?
4. skills나 grill-me가 있으면 ExecPlan이 필요 없어지는가?
5. Safe Village Micro에서 ExecPlan을 너무 일찍 만들면 어떤 문제가 생기는가?
6. prompt 실험 단계와 실제 구현 단계에서 PLANS.md는 어떻게 달라야 하는가?

출력:
- 설명
- 판단 기준
- 좋은 ExecPlan 사용 예
- 나쁜 ExecPlan 사용 예
- 지금 단계에서의 결론

파일 수정은 하지 마라.
```
