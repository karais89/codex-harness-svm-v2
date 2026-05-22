# Prompt Result: 016. 중간 학습 정리

## 실험 번호

`016`

## 실험 주제

`중간 학습 정리`

## 실행 일시

`2026-05-22 19:54 KST`

## 실행 모드

일반/튜터 중 정확히 하나만 선택한다.

- [x] 일반
- [ ] 튜터

## 사용자 명령

```text
'/Users/kaya/Documents/Codex/codex-harness-svm-v2/docs/prompts/016-midpoint-review.md' 중간점검하자

15까지 포함해줄래

기록 하고 커밋해줘
```

## 적용한 실행 모드 wrapper

```text
docs/prompts/README.md의 일반 모드 wrapper를 적용했다.

- Safe Village Micro 구현으로 넘어가지 않음.
- 실험 실행 단계에서는 파일을 생성/수정하지 않음.
- 현재 repo 구조를 먼저 확인하고, 확인된 사실과 추측을 분리함.
- Unity gameplay code, Scene, Packages/manifest.json, ProjectSettings/를 수정하지 않음.
- 질문에 대해 빠르게 설명하고, 비교나 판단이 필요한 부분은 근거를 짧게 정리함.
- 001-015 prompt results를 우선 근거로 사용함.
- 기록 단계에서만 docs/prompt-results/016-midpoint-review-2026-05-22.md 생성을 허용함.
```

## 참조한 프롬프트 파일

`docs/prompts/016-midpoint-review.md`

## 모델/클라이언트/실행 환경

- 모델: `GPT-5 계열 Codex, 세부 모델명 확인 불가`
- 클라이언트: `Codex coding agent`
- 실행 환경: `macOS zsh, repo root /Users/kaya/Documents/Codex/codex-harness-svm-v2, KST`

## 실행 조건

- 파일 수정 허용 여부: `실험 실행 단계 파일 수정 금지, 기록 단계에서 docs/prompt-results/016-midpoint-review-2026-05-22.md 생성 허용`
- 사용한 skill/tool: `shell로 prompts README, 016 프롬프트, 010-015 및 이전 016 결과 확인; apply_patch로 결과 파일 생성`
- 별도 제약: `Unity 파일 수정 금지, 새로운 Unity 구현 계획 생성 금지, docs/prompt-results를 우선 근거로 사용, 각 결론에 근거 파일과 confidence 표시`

## Codex 응답 요약

이번 016 중간점검은 `001-015` 결과를 포함해 Prompts Lab의 학습 상태를 다시 정리했다. 이전 016 이후 핵심 변화는 Matt skills가 제한 후보가 아니라 SVM v1의 기본 workflow 후보로 올라갔고, Unity MCP는 사용 전제로 정리됐으며, plugin/custom MCP/subagents는 학습 또는 조건부 후보로 분리됐다는 점이다. ExecPlan은 `PLANS.md` 템플릿과 active ExecPlan을 분리해서 이해했고, active ExecPlan은 first playable처럼 큰 구현 작업에만 쓰는 기준이 생겼다. 현재는 `017-final-selection`으로 넘어갈 수 있지만, Matt skills workflow smoke test와 Unity 검증 체계는 채택 전 조건으로 남는다.

## 튜터 모드 상호작용 요약

일반 모드 실행이면 모든 항목에 `해당 없음`을 적는다. 튜터 모드 실행이면 전체 대화 전문을 붙여넣지 말고 핵심만 요약한다.

### Codex가 한 확인 질문

- 해당 없음

### 사용자 답변 요약

- 해당 없음

### teach-back 결과 또는 아직 헷갈린 지점

- 해당 없음

### 다음 복습 질문

`해당 없음`

## 중간 정리 결과

### 확인한 결과 파일

- `docs/prompt-results/001-llm-codex-structure.md`
- `docs/prompt-results/002-agents-md.md`
- `docs/prompt-results/003-docs-responsibility.md`
- `docs/prompt-results/004-skill-concepts.md`
- `docs/prompt-results/005-skill-value-check.md`
- `docs/prompt-results/006-hooks-concepts.md`
- `docs/prompt-results/006a-hooks-guard-practice.md`
- `docs/prompt-results/007-llm-failure-modes.md`
- `docs/prompt-results/008-unity-workflow.md`
- `docs/prompt-results/009-project-structure.md`
- `docs/prompt-results/010-custom-skill-draft.md`
- `docs/prompt-results/011-matt-skills-review.md`
- `docs/prompt-results/012-mcp-concepts.md`
- `docs/prompt-results/012a-mcp-mock-tool.md`
- `docs/prompt-results/013-plugin-concepts.md`
- `docs/prompt-results/013a-plugin-bundle-practice.md`
- `docs/prompt-results/014-execplan-plans.md`
- `docs/prompt-results/015-subagents.md`
- `docs/prompt-results/016-midpoint-review-2026-05-21.md`

### 누락된 결과 파일

- `001-015` 기준 누락 없음. 근거: `docs/prompts/README.md`, `docs/prompt-results/`, confidence: 높음.
- 아직 미실행 상태로 남은 후속 실험: `017-final-selection.md`, `018-ai-gap-map.md`. 이는 누락 오류가 아니라 이후 실행 대상이다. 근거: `docs/prompts/README.md`, confidence: 높음.

### 내가 이해한 개념 목록

| 이해한 개념 | 근거 | confidence |
| --- | --- | --- |
| Codex는 repo 전체를 자동으로 완전히 아는 존재가 아니라, 필요한 파일을 찾아 읽고 context에 들어온 근거로 판단하는 에이전트다. | `001-llm-codex-structure.md` | 높음 |
| AGENTS.md는 모든 지식을 담는 문서가 아니라, 짧은 상시 행동 규칙과 문서 지도를 담는 진입점이다. | `002-agents-md.md`, `003-docs-responsibility.md` | 높음 |
| Prompts Lab 운영 문서, prompt 결과 기록, 실제 프로젝트 문서는 분리해야 한다. | `003-docs-responsibility.md`, `009-project-structure.md` | 높음 |
| Skill은 반복 workflow를 재현하기 위한 절차 묶음이며, 자동 trigger보다 명시 호출형이 현재 사용자 선호에 더 맞다. | `004-skill-concepts.md`, `005-skill-value-check.md`, `010-custom-skill-draft.md` | 높음 |
| Hook은 자연어 지침을 반복하는 장치가 아니라, 보호 경로와 명확한 위험을 자동 확인하는 결정적 guard다. | `006-hooks-concepts.md`, `006a-hooks-guard-practice.md`, `007-llm-failure-modes.md` | 높음 |
| `test`는 Codex 전용 기능명이 아니라 unit test, Unity compile check, smoke check, diff check 같은 검증 수단 전체다. | `007-llm-failure-modes.md` | 높음 |
| Matt skills는 SVM v1에서 제한 후보가 아니라 기본 workflow 후보에 가깝다. 단, 산출물을 공식 문서 구조에 반영할지는 분리해야 한다. | `011-matt-skills-review.md` | 높음 |
| Unity MCP는 SVM v1에서 사용 전제다. Scene, GameObject, Component, Console, Play Mode 같은 live Editor 상태 확인에 필요하다. | `012-mcp-concepts.md`, `012a-mcp-mock-tool.md` | 높음 |
| Custom MCP는 학습용 최소 실습으로는 가치가 있지만, 공식 프로젝트 도입은 반복 필요와 운영 정책 확인 뒤 판단해야 한다. | `012a-mcp-mock-tool.md` | 높음 |
| Plugin은 skill, MCP, hooks 등을 설치/배포 가능한 경계로 묶는 상위 단위지만, 현재는 learning draft 수준에 머무는 것이 맞다. | `013-plugin-concepts.md`, `013a-plugin-bundle-practice.md` | 높음 |
| `PLANS.md`는 템플릿/운영 규칙으로 상시 존재할 수 있지만, active ExecPlan은 큰 구현 작업에만 만든다. | `014-execplan-plans.md` | 높음 |
| Subagent는 구현 분담보다 read-only 리뷰, 리서치, 다방면 기획 비교에 먼저 쓰는 것이 안전하다. | `015-subagents.md` | 중간 |

### 아직 헷갈리는 개념 목록

| 헷갈리는 지점 | 근거 | confidence |
| --- | --- | --- |
| Matt skills 산출물을 SVM 공식 문서 구조에 어디까지 반영할지 아직 확정되지 않았다. | `011-matt-skills-review.md`, `009-project-structure.md` | 높음 |
| `/setup-matt-pocock-skills -> /grill-with-docs -> /to-prd -> /to-issues -> /triage -> /tdd` 흐름이 Unity playable slice에 실제로 맞는지는 smoke test 전이다. | `011-matt-skills-review.md` | 높음 |
| Unity 검증을 수동 체크리스트, MCP, hook, custom skill 중 어디까지 맡길지 아직 결정되지 않았다. | `007-llm-failure-modes.md`, `012-mcp-concepts.md`, `012a-mcp-mock-tool.md` | 높음 |
| `$unity-micro-scope-guard` 같은 custom skill 후보를 실제 skill로 만들지, AGENTS.md fallback checklist로 둘지 아직 확정되지 않았다. | `010-custom-skill-draft.md` | 높음 |
| AI Persona Architect / Evaluator 후보가 실제로 AI 격차를 줄이는지 확인할 rubric과 test prompt가 아직 없다. | `011-matt-skills-review.md` | 중간 |
| Read-only subagent 리뷰가 비용 대비 유의미한지는 아직 작은 실험 전이다. | `015-subagents.md` | 중간 |
| Plugin을 실제 installable 구조로 만들 시점과 marketplace/personal plugin 경계는 아직 판단 전이다. | `013a-plugin-bundle-practice.md` | 높음 |

### 추가 실험이 필요한 항목

| 추가 실험 | 이유 | 근거 | confidence |
| --- | --- | --- | --- |
| `017-final-selection` | 001-015 결과가 모두 쌓였으므로 실제 채택/보류/폐기 목록을 최소 구성으로 정리할 수 있다. | `docs/prompts/README.md`, `014-execplan-plans.md`, `015-subagents.md` | 높음 |
| Matt skills workflow smoke test | Matt skills가 기본 workflow 후보로 올라왔지만 Unity playable slice 적합성은 아직 검증되지 않았다. | `011-matt-skills-review.md` | 높음 |
| Unity 검증 체계 결정 | Play Mode, Console, Scene/Prefab 검증을 어떤 도구와 절차가 맡을지 정해야 한다. | `007-llm-failure-modes.md`, `012-mcp-concepts.md`, `012a-mcp-mock-tool.md` | 높음 |
| AI Persona Architect / Evaluator 설계 | 사용자가 제기한 핵심 custom skill 후보지만 역할 계약서, rubric, test prompt가 아직 없다. | `011-matt-skills-review.md` | 중간 |
| Read-only subagent 리뷰 실험 | 구현 분담은 보류지만 문서 일관성, 구현 위험, 과한 자동화 검토에 쓸 수 있는지 확인할 가치가 있다. | `015-subagents.md` | 중간 |

### 실제 Safe Village Micro 개발에 채택할 후보

| 채택 후보 | 의미 | 근거 | confidence |
| --- | --- | --- | --- |
| 짧은 root AGENTS.md | 상시 규칙과 문서 지도 역할. 하위 AGENTS.md는 반복 실패가 확인될 때만 검토한다. | `002-agents-md.md`, `003-docs-responsibility.md` | 높음 |
| Prompts Lab과 실제 프로젝트 문서 분리 | `docs/prompts`와 `docs/prompt-results`는 실험 기록이고, 실제 SVM 문서와 섞지 않는다. | `003-docs-responsibility.md`, `009-project-structure.md` | 높음 |
| Matt skills 기본 workflow 후보 | SVM v1에서 적극 사용 후보로 둔다. 단, 산출물의 공식 반영은 별도 검토한다. | `011-matt-skills-review.md` | 높음 |
| Unity MCP 사용 전제 | Editor live state, Console, Scene/GameObject/Component 확인에 사용한다. | `012-mcp-concepts.md`, `012a-mcp-mock-tool.md` | 높음 |
| PLANS.md 템플릿/운영 규칙 | active ExecPlan 작성 기준을 담는 템플릿으로 둘 수 있다. | `014-execplan-plans.md` | 높음 |
| Active ExecPlan 조건부 사용 | first playable처럼 범위, 결정, 검증이 여러 세션에 걸치는 큰 구현 작업에만 만든다. | `014-execplan-plans.md` | 높음 |
| Hooks 조건부 사용 | 보호 경로, 명확한 위험, 승인 없는 큰 변경처럼 기계적으로 판정 가능한 범위에 한정한다. | `006a-hooks-guard-practice.md`, `007-llm-failure-modes.md` | 중간 |
| Subagents 조건부 사용 | read-only 리뷰, 리서치, 다방면 기획 비교에 한정해 먼저 검토한다. | `015-subagents.md` | 중간 |

### 보류할 후보

| 보류 후보 | 보류 이유 | 근거 | confidence |
| --- | --- | --- | --- |
| Custom skill 실제 생성 | 명시 호출형 review mode가 유효하지만 AGENTS.md fallback checklist로 충분할 수 있다. | `010-custom-skill-draft.md` | 높음 |
| Custom MCP 공식 도입 | 학습용 실습은 성공했지만 Codex MCP config 등록, 운영 정책, 반복 필요가 아직 확인되지 않았다. | `012a-mcp-mock-tool.md` | 높음 |
| Plugin 실제 제작/설치 | 반복 workflow가 안정되기 전에는 희망사항 묶음이 될 위험이 크다. | `013-plugin-concepts.md`, `013a-plugin-bundle-practice.md` | 높음 |
| Subagent 구현 분담 | Unity Scene/Prefab/ProjectSettings/package 상태는 의미 충돌과 검증 부담이 크다. | `015-subagents.md` | 높음 |
| 모든 Unity 파일 변경 block | 실제 개발에 필요한 정상 변경까지 막을 수 있다. | `006a-hooks-guard-practice.md`, `007-llm-failure-modes.md` | 높음 |
| 큰 workflow 프레임워크 | Spec Kit, BMad, Superpowers 등은 현재 작은 playable loop 검증보다 절차 운영이 커질 수 있다. | `008-unity-workflow.md`, `011-matt-skills-review.md` | 중간 |

### 다음 1-2개 실험 추천

1. `docs/prompts/017-final-selection.md`
   - 이유: `001-015` 결과가 모두 기록되어 있고, 이제 채택/보류/폐기를 최소 구성으로 정리할 근거가 충분하다.
   - 조건: Unity 구현으로 넘어가지 말고 governance 단계로 제한한다. Matt skills는 기본 workflow 후보로 보되, smoke test 필요 조건을 남긴다.

2. Matt skills workflow smoke test 설계
   - 이유: 017 전에 더 엄격하게 확인하려면 `/grill-with-docs -> /to-prd -> /to-issues -> /triage -> /tdd` 흐름이 Unity playable slice에 맞는지 tmp 실험으로 확인해야 한다.
   - 조건: 실제 SVM 공식 문서에 반영하지 않고, tmp 또는 별도 실험 결과로만 다룬다.

## 내가 이해한 점

- 001-015를 포함하면 Prompts Lab은 "도구 개념 이해"를 넘어 "SVM v1에 무엇을 실제 채택할지 고를 수 있는 단계"까지 왔다.
- 가장 강한 채택 후보는 짧은 AGENTS.md, Matt skills 기본 workflow 후보, Unity MCP 사용 전제, PLANS.md 템플릿/active ExecPlan 분리다.
- 가장 강한 보류 후보는 custom skill 실제 생성, custom MCP 공식 도입, plugin 실제 제작, subagent 구현 분담이다.
- 015 결과를 포함하면 subagents는 구현 분담이 아니라 read-only 리뷰/리서치 후보로 분명히 제한된다.

## 실제로 도움 된 점

- 이전 016에서 남아 있던 `010-015` 쟁점이 모두 결과 파일 기준으로 채워졌다.
- Matt skills와 Unity MCP는 채택 후보로 올라갔지만, custom skill/MCP/plugin/subagents는 "학습 또는 조건부 후보"로 분리됐다.
- `017-final-selection`으로 넘어갈 수 있는 근거가 생겼고, 동시에 Matt skills workflow smoke test라는 검증 조건도 분명해졌다.
- active ExecPlan은 지금 만들 것이 아니라 큰 구현 작업 시점에 만드는 것으로 정리되어 prompt lab과 구현 계획이 섞이는 위험을 줄였다.

## 헷갈린 점

- Matt skills를 기본 workflow 후보로 둘 때, 실제 repo에 어떤 파일과 문서를 남길지는 아직 017에서 결정해야 한다.
- Unity 검증 체계는 MCP 사용 전제까지는 정리됐지만, 수동 체크리스트, hook, skill, Play Mode 검증의 구체적 조합은 아직 미정이다.
- AI Persona Architect / Evaluator를 먼저 설계할지, 017에서 최종 선택을 먼저 할지는 선택이 필요하다.

## 위험하거나 과해 보인 점

- Matt skills를 기본 workflow 후보로 채택하더라도, 산출물을 검토 없이 공식 SVM 문서로 편입하면 Prompts Lab과 실제 프로젝트 문서가 다시 섞일 수 있다.
- Unity MCP와 custom MCP 실습을 혼동하면 검증 수준을 과장하게 된다.
- Plugin learning draft를 실제 installable plugin으로 착각하면 유지보수 대상이 너무 빨리 생긴다.
- Subagent를 Unity 구현 분담에 바로 쓰면 파일 충돌이 없어도 Scene/Prefab/reference 의미 충돌이 생길 수 있다.
- 지금 017을 실행하더라도 Unity 구현 task로 넘어가면 안 되고, 채택 결정과 운영 규칙 정리까지만 해야 한다.

## 채택 여부

채택/보류/폐기 중 정확히 하나만 선택한다. 추가 실험 필요 여부는 후속 작업으로 분리해서 기록한다.

- [x] 채택
- [ ] 보류
- [ ] 폐기

## 채택/보류/폐기 이유

이 중간 정리는 `001-015` 결과를 모두 포함해 현재 학습 상태, 채택 후보, 보류 후보, 다음 실험을 다시 정리했다. 특히 이전 016 이후 추가된 `010-015` 결과를 반영해 Matt skills, Unity MCP, plugin, ExecPlan, subagents의 위치를 갱신했다. 실제 SVM 구현 계획을 새로 만든 것은 아니며, `017-final-selection`으로 넘어가기 위한 checkpoint로 채택한다.

## 다음 실험 프롬프트

```text
docs/prompts/017-final-selection.md를 일반 모드로 실행해줘.

조건:
- docs/prompt-results/001-015와 016 중간점검을 우선 근거로 사용한다.
- Matt skills는 SVM v1의 기본 workflow 후보로 보되, 산출물의 공식 문서 반영은 별도 판단한다.
- Unity MCP는 사용 전제로 보되, custom MCP 공식 도입은 별도 보류 후보로 판단한다.
- subagents는 구현 분담이 아니라 read-only 리뷰/리서치 후보로 판단한다.
- plugin은 learning draft와 실제 installable plugin을 분리해서 판단한다.
- Unity 구현으로 넘어가지 말고 채택 결정, 운영 규칙 정리, 구현 전 checklist 같은 governance 단계로 제한한다.
```

## 후속 작업

- [x] 문서 갱신 필요
- [x] AGENTS.md 반영 검토
- [x] skill 후보 검토
- [x] hook 후보 검토
- [x] 추가 실험 필요
- [ ] 추가 리서치 필요

후속 작업 메모:

`다음 단계는 017-final-selection으로 001-015 결과를 바탕으로 최소 운영 구성을 고르는 것이다. 017 전 또는 017 후에 Matt skills workflow smoke test를 tmp 실험으로 설계할 수 있다. 실제 Unity 구현, plugin 설치, custom MCP 공식 등록, subagent 구현 분담은 아직 진행하지 않는다.`
