# Prompt Result: 014. ExecPlan / PLANS.md 이해

## 실험 번호

`014`

## 실험 주제

`ExecPlan / PLANS.md 이해`

## 실행 일시

`2026-05-22 19:18 KST`

## 실행 모드

일반/튜터 중 정확히 하나만 선택한다.

- [ ] 일반
- [x] 튜터

## 사용자 명령

```text
'/Users/kaya/Documents/Codex/codex-harness-svm-v2/docs/prompts/014-execplan-plans.md' 튜터 모드로 실행

1. 복잡한 작업에서 시행되는 살아 있는 문서. 이 문서를 codex가 갱신하면서 맥락을 잃지 않음
2. PLANS.md는 항상 있어야 됨. 왜냐하면 이거 자체는 템플릿이야.
3. 헷갈리는 것 없음.

이번 내용 기록 해주고 커밋 해줘.
```

## 적용한 실행 모드 wrapper

```text
docs/prompts/README.md의 튜터 모드 wrapper를 적용했다.

- Safe Village Micro 구현으로 넘어가지 않음.
- 실험 실행 단계에서는 파일을 생성/수정하지 않음.
- 현재 repo 구조와 기존 prompt result를 확인하고, 확인된 사실과 추측을 분리함.
- Unity gameplay code, Scene, Packages/manifest.json, ProjectSettings/를 수정하지 않음.
- 바로 긴 설명을 시작하지 않고 시작 질문으로 현재 이해 수준을 확인함.
- 개념 단위로 나누어 설명하고 teach-back 질문으로 이해를 확인함.
- 기록 단계에서만 docs/prompt-results/014-execplan-plans.md 생성을 허용함.
```

## 참조한 프롬프트 파일

`docs/prompts/014-execplan-plans.md`

## 모델/클라이언트/실행 환경

- 모델: `GPT-5 계열 Codex, 세부 모델명 확인 불가`
- 클라이언트: `Codex coding agent`
- 실행 환경: `macOS zsh, repo root /Users/kaya/Documents/Codex/codex-harness-svm-v2, KST`

## 실행 조건

- 파일 수정 허용 여부: `실험 실행 단계 파일 수정 금지, 기록 단계에서 docs/prompt-results/014-execplan-plans.md 생성 허용`
- 사용한 skill/tool: `shell로 prompts README, 014 프롬프트, 기존 prompt results, 결과 템플릿 확인; apply_patch로 결과 파일 생성`
- 별도 제약: `Unity 파일 수정 금지, Safe Village Micro 구현으로 넘어가지 않기, active ExecPlan 생성 금지, prompt lab 결과와 실제 구현 계획 섞지 않기`

## Codex 응답 요약

Codex는 ExecPlan을 복잡한 작업에서 목적, 현재 상태, 결정 이유, 검증 방법, 남은 일, 변경 이력을 계속 갱신하는 살아 있는 실행 문서로 설명했다. 일반 plan은 보통 한 턴 안에서 끝낼 작업 순서이고, ExecPlan은 여러 시간이나 여러 세션을 지나도 이어갈 수 있게 만드는 작업 기준서라고 구분했다. PLANS.md는 항상 존재하는 템플릿이나 운영 규칙 문서일 수 있지만, 모든 작은 작업에 active ExecPlan이 필요한 것은 아니라고 정리했다. skills나 grill-me는 요구사항 정리와 반복 workflow를 돕지만, 큰 작업의 실행 상태와 결정 이력을 보존하는 ExecPlan을 대체하지는 않는다고 설명했다. 현재 014 단계에서는 active ExecPlan을 만들지 않고, first playable처럼 범위와 검증이 명확해진 큰 구현 작업에서 사용 기준을 적용하는 것이 맞다고 결론 내렸다.

## 튜터 모드 상호작용 요약

일반 모드 실행이면 모든 항목에 `해당 없음`을 적는다. 튜터 모드 실행이면 전체 대화 전문을 붙여넣지 말고 핵심만 요약한다.

### Codex가 한 확인 질문

- ExecPlan을 현재 어떤 것으로 이해하고 있는지 물었다.
- PLANS.md가 항상 있어야 한다고 느끼는지, 큰 작업 때만 있어야 한다고 느끼는지 물었다.
- 가장 헷갈리는 경계가 일반 plan vs ExecPlan, AGENTS.md vs PLANS.md, skills/grill-me vs ExecPlan, prompt 실험 단계 vs 실제 구현 단계 중 어디인지 물었다.
- 설명 뒤에는 PLANS.md가 항상 있어도 작은 수정마다 active ExecPlan을 만들 필요는 없는 이유를 한 문장으로 설명해보라고 물었다.
- 마무리 복습 질문으로 grill-me, skill, ExecPlan을 각각 한 단어로 줄이면 무엇인지 물었다.

### 사용자 답변 요약

- 사용자는 ExecPlan을 복잡한 작업에서 시행되는 살아 있는 문서이며, Codex가 갱신하면서 맥락을 잃지 않게 하는 문서로 이해하고 있었다.
- 사용자는 PLANS.md는 항상 있어야 하며, 그 자체가 템플릿이라고 답했다.
- 사용자는 현재 헷갈리는 것은 없다고 답했다.
- 이후 사용자는 이번 내용을 결과 파일로 기록하고 커밋해 달라고 요청했다.

### teach-back 결과 또는 아직 헷갈린 지점

- ExecPlan이 복잡한 작업의 살아 있는 문서라는 핵심 이해는 맞았다.
- 추가로 정리된 구분은 `PLANS.md가 항상 존재할 수 있다`와 `모든 작업에 active ExecPlan이 필요하다`는 같은 말이 아니라는 점이다.
- 사용자가 헷갈리는 지점은 없다고 답했기 때문에, 튜터 모드는 설명과 기준 정리 중심으로 마무리했다.
- 마무리 복습 질문은 제시했지만, 사용자가 바로 기록과 커밋을 요청해 별도 답변은 받지 않았다.

### 다음 복습 질문

`PLANS.md가 항상 있어도 작은 수정마다 active ExecPlan을 만들 필요는 없는 이유를 한 문장으로 설명하면 어떻게 말할 수 있는가?`

## 내가 이해한 점

- ExecPlan은 복잡한 작업에서 Codex가 맥락을 잃지 않도록 계속 갱신하는 살아 있는 실행 문서다.
- 일반 plan은 한 턴 안에서 끝나는 작업 순서에 가깝고, ExecPlan은 여러 세션과 여러 검증 단계를 이어주는 기준서에 가깝다.
- PLANS.md는 항상 둘 수 있는 템플릿/운영 규칙 문서일 수 있지만, active ExecPlan은 작업 규모가 충분히 클 때만 만드는 것이 맞다.
- grill-me는 요구사항을 선명하게 하는 질문 도구이고, skill은 반복 workflow를 돕는 지침/도구 묶음이며, ExecPlan은 큰 작업의 실행 상태와 결정 이력을 보존하는 문서다.
- Safe Village Micro에서는 prompt lab 단계와 실제 구현 단계를 섞지 않는 것이 중요하다.

## 실제로 도움 된 점

- `PLANS.md 상시 존재`와 `active ExecPlan 상시 생성`을 분리해서 볼 수 있게 됐다.
- Safe Village Micro에서 first playable 같은 큰 Unity 구현에는 ExecPlan이 유용하지만, 014 같은 학습 실험에는 필요 없다는 기준이 생겼다.
- Unity Scene, Prefab, asset, ProjectSettings, package 변경처럼 되돌리기와 검증이 어려운 작업에서 ExecPlan 가치가 크다는 점을 확인했다.
- skills나 grill-me를 도입하더라도 ExecPlan의 역할이 사라지지 않고, 서로 다른 층위의 도구로 봐야 한다는 기준이 정리됐다.

## 헷갈린 점

- 사용자는 헷갈리는 지점이 없다고 답했다.
- 다만 실제 SVM 구현 단계에서 어느 작업부터 active ExecPlan을 만들지는 017-final-selection 또는 구현 시작 조건 정리 때 다시 확정해야 한다.

## 위험하거나 과해 보인 점

- prompt lab 단계에서 active ExecPlan을 만들면 학습 실험이 실제 구현 계획처럼 굳어질 수 있다.
- PLANS.md 템플릿이 있다는 이유로 모든 작은 작업에 ExecPlan을 만들면 운영 부담이 커지고 SVM의 경량 실험 목적과 충돌할 수 있다.
- grill-me, skills, ExecPlan을 모두 기본 workflow로 강제하면 도구 선택 실험이 아니라 절차 운영 자체가 과제가 될 수 있다.
- Safe Village Micro의 구현 범위가 확정되기 전에 ExecPlan을 만들면 아직 채택되지 않은 docs 구조나 기능 범위를 확정한 것처럼 보일 수 있다.

## 채택 여부

채택/보류/폐기 중 정확히 하나만 선택한다. 추가 실험 필요 여부는 후속 작업으로 분리해서 기록한다.

- [x] 채택
- [ ] 보류
- [ ] 폐기

## 채택/보류/폐기 이유

ExecPlan과 PLANS.md의 역할 구분은 Safe Village Micro의 이후 구현 단계에 필요한 운영 기준으로 채택한다. 특히 PLANS.md는 템플릿/운영 규칙으로 상시 존재할 수 있지만, active ExecPlan은 first playable처럼 범위와 검증이 명확한 큰 작업에만 만든다는 기준이 유효하다. 다만 이번 014 실험 자체에서는 active ExecPlan을 만들지 않고, prompt lab 결과 기록으로만 남기는 것이 맞다.

## 다음 실험 프롬프트

```text
docs/prompts/015-subagents.md를 튜터 모드로 실행해줘.

목표:
- 큰 작업에서 subagent를 언제 쓰면 좋은지 확인한다.
- Unity 구현 작업에서 subagent 결과를 어떻게 검증해야 하는지 이해한다.
- prompts lab 단계와 실제 구현 단계를 섞지 않는다.
```

또는

```text
docs/prompts/017-final-selection.md를 일반 모드로 실행해줘.

조건:
- 014 결과를 반영해 PLANS.md와 active ExecPlan의 경계를 분리한다.
- Matt skills, custom skills, hooks, MCP, plugin, subagents를 모두 기본 채택하지 말고 최소 구성으로 판단한다.
- Safe Village Micro 구현으로 바로 넘어가지 않는다.
```

## 후속 작업

- [ ] 문서 갱신 필요
- [ ] AGENTS.md 반영 검토
- [ ] skill 후보 검토
- [ ] hook 후보 검토
- [x] 추가 실험 필요
- [ ] 추가 리서치 필요

후속 작업 메모:

`014 결과는 이후 017-final-selection에서 SVM의 최소 운영 구성 판단에 반영한다. 현재는 PLANS.md 템플릿이나 active ExecPlan 파일을 새로 만들지 않는다. 다음 실험은 015-subagents를 실행하거나, 충분하다고 판단하면 017-final-selection에서 지금까지의 실험 결과를 바탕으로 실제 채택 범위를 정한다.`
