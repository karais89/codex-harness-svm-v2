# Prompt Result: 017. 최종 선택

## 실험 번호

`017`

## 실험 주제

`최종 선택`

## 실행 일시

`2026-05-22 19:58 KST`

## 실행 모드

일반/튜터 중 정확히 하나만 선택한다.

- [x] 일반
- [ ] 튜터

## 사용자 명령

```text
017-final-selection.md 실행해줘.

커밋해줘. 그리고 내용 요약해서 알려줘
```

## 적용한 실행 모드 wrapper

```text
docs/prompts/README.md의 일반 모드 wrapper를 적용했다.

- Safe Village Micro 구현으로 넘어가지 않음.
- 실험 실행 단계에서는 파일을 생성/수정하지 않음.
- 현재 repo 구조를 먼저 확인하고, 확인된 사실과 추측을 분리함.
- Unity gameplay code, Scene, Packages/manifest.json, ProjectSettings/를 수정하지 않음.
- 질문에 대해 빠르게 설명하고, 비교나 판단이 필요한 부분은 근거를 짧게 정리함.
- 마지막에는 다음에 실행할 만한 실험 1-2개를 짧게 제안함.
```

## 참조한 프롬프트 파일

`docs/prompts/017-final-selection.md`

## 모델/클라이언트/실행 환경

- 모델: `GPT-5 계열 Codex, 세부 모델명 확인 불가`
- 클라이언트: `Codex coding agent`
- 실행 환경: `macOS zsh, repo root /Users/kaya/Documents/Codex/codex-harness-svm-v2, KST`

## 실행 조건

- 파일 수정 허용 여부: `실험 실행 단계 파일 수정 금지, 기록 단계에서 docs/prompt-results/017-final-selection.md 생성 허용`
- 사용한 skill/tool: `shell로 prompts README, 017 프롬프트, prompt results, git 상태 확인; apply_patch로 결과 파일 생성`
- 별도 제약: `Unity 파일 수정 금지, Safe Village Micro 구현으로 넘어가지 않기, docs/prompt-results를 우선 근거로 사용, 누락 문서 표시, 모든 항목에 근거와 confidence 표시`

## Codex 응답 요약

Codex는 `docs/prompt-results/`의 `001`-`016` 결과를 우선 근거로 삼아 Safe Village Micro에 실제 채택할 운영 구성을 초안으로 정리했다. 이후 사용자가 017의 각 항목은 하나씩 확인받아야 한다고 정정했고, `AGENTS.md`, `PLANS.md`/ExecPlan, Matt skills, custom skills, hooks, MCP, plugin, `docs/threads`, Unity 구현 시작 조건을 순서대로 확정했다. 최종 선택은 root `AGENTS.md`, OpenAI 원문 기준의 `PLANS.md`/ExecPlan, Matt skills, `$` 명시 호출형 custom skills, practical hooks, Unity MCP를 채택하는 쪽이다. plugin은 지금 만들지 않되 SVM v1 완료 후 pluginization checkpoint를 필수로 두고, `docs/threads`는 폐기한다. Unity 구현은 governance 문서와 검증 기준이 잠긴 뒤 시작한다.

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

## 최종 선택 결과

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

### 누락된 읽기 대상

- `docs/decisions.md`: 현재 repo에 없음. confidence: 높음.
- `docs/progress.md`: 현재 repo에 없음. confidence: 높음.
- `docs/prompt-results/017-final-selection.md`: 실행 당시에는 없었고, 이 기록 단계에서 생성함. confidence: 높음.

### 항목별 판단

| 항목 | 결론 | 이유 | 근거 | confidence |
| --- | --- | --- | --- | --- |
| AGENTS.md 구조 | 채택 | root `AGENTS.md` 하나를 짧은 행동 규칙과 문서 지도로 둔다. 하위 AGENTS.md는 특정 폴더에서 반복 실패가 확인될 때만 검토한다. | `002-agents-md.md`, `003-docs-responsibility.md`, `016-midpoint-review-2026-05-21.md` | 높음 |
| PLANS.md / ExecPlan | 채택, 제한 | `PLANS.md`는 템플릿/운영 규칙 문서로 둘 수 있지만 active ExecPlan은 first playable처럼 범위와 검증이 명확한 큰 작업에만 만든다. | `014-execplan-plans.md` | 높음 |
| Matt skills | 채택, 검증 필요 | SVM v1의 기본 workflow 후보로 채택한다. 단, official repo 반영은 tmp smoke에서 installer/setup 산출물과 문서 경계가 확인된 뒤 진행한다. | `008-unity-workflow.md`, `011-matt-skills-review.md`, Matt skills upstream read-only inspection | 높음 |
| custom skills | 채택, 첫 skill 별도 선정 | Matt skills가 커버하지 못하는 SVM/Unity/AI 활용 판단 영역을 custom skill이 맡는다. 자동 trigger는 금지하고 `$` 명시 호출형 review/evaluator skill로 만든다. 첫 후보는 018 이후 `ai-persona-architect-evaluator`를 1순위로 검토한다. | `005-skill-value-check.md`, `010-custom-skill-draft.md`, `011-matt-skills-review.md` | 높음 |
| hooks | 채택, 단계적 활성화 | SVM에는 stage routing, Unity 보호 파일 guard, 완료 검증, 권한 상승 guard, 결정 기록 보조처럼 실용적인 guardrail이 필요하다. 첫 구현 후보는 `Stage Router Hook`과 `Protected Unity Edit Guard`로 두고, parent repo 활성화 전 dry-run/warn smoke를 거친다. | `006-hooks-concepts.md`, `006a-hooks-guard-practice.md`, `007-llm-failure-modes.md`, OpenAI Codex hooks docs | 높음 |
| MCP | 채택, 단계적 도입 | 검증된 Unity MCP는 구현 검증 단계부터 사용한다. Scene, GameObject, Component, Console, Play Mode 상태 확인은 MCP 대상이다. custom MCP는 학습 결과만 보존하고 반복 필요가 생긴 뒤 별도 승인으로 만든다. | `012-mcp-concepts.md`, `012a-mcp-mock-tool.md` | 높음 |
| plugin | 보류, 완료 후 checkpoint 채택 | 지금 plugin을 만들지는 않는다. 다만 SVM v1 완료 후 pluginization checkpoint를 필수 후속 단계로 두고, 실제 반복 사용된 AGENTS 규칙, custom skill, hooks, MCP, scripts, templates만 plugin 후보로 선별한다. | `013-plugin-concepts.md`, `013a-plugin-bundle-practice.md` | 높음 |
| docs/threads 유지 여부 | 폐기 | 사용자가 `docs/threads` 개념을 원하지 않았고, 실험 문서와 프로젝트 문서 분리가 더 중요하다. | `009-project-structure.md` | 높음 |
| 실제 Unity 구현 시작 조건 | 채택, 조건 충족 후 시작 | 구현 시작 조건을 공식 운영 기준으로 채택한다. 017 확정 결과 기록, 결정 문서 위치 선택, root `AGENTS.md`, OpenAI 원문 기준 `PLANS.md`, Matt smoke, 첫 custom skill 후보, 첫 hook dry-run/warn smoke, Unity MCP 기준, first playable 범위와 완료 기준을 잠근 뒤 구현을 시작한다. | `011-matt-skills-review.md`, `014-execplan-plans.md`, `016-midpoint-review-2026-05-21.md` | 높음 |

### 사용자 확인 반영 결과

| 번호 | 항목 | 사용자 확인 결과 |
| --- | --- | --- |
| 1 | AGENTS.md 구조 | 채택 확정. root `AGENTS.md` 하나를 짧은 행동 규칙과 문서 지도로 둔다. |
| 2 | PLANS.md / ExecPlan | 채택 확정. OpenAI 원문/공식 글을 원천 기준으로 사용한다. |
| 3 | Matt skills | 채택 확정. 단, official repo 반영 전 tmp smoke로 setup 산출물과 문서 경계를 확인한다. |
| 4 | custom skills | 채택 확정. 자동 trigger 없이 `$` 명시 호출형으로 만들고, 첫 skill은 018 이후 선정한다. |
| 5 | hooks | 채택 확정. Stage Router Hook과 Protected Unity Edit Guard를 우선 후보로 둔다. |
| 6 | MCP | 채택 확정. Unity MCP부터 단계적으로 도입하고, custom MCP는 반복 필요가 생긴 뒤 별도 판단한다. |
| 7 | plugin | 보류 확정. 단, SVM v1 완료 후 pluginization checkpoint를 필수로 둔다. |
| 8 | docs/threads | 폐기 확정. 대화 흐름 기록 폴더는 만들지 않는다. |
| 9 | Unity 구현 시작 조건 | 채택 확정. 구현 시작 전 governance/검증 조건을 공식 기준으로 잠근다. |

## 내가 이해한 점

- Safe Village Micro의 최소 운영 구성은 "root AGENTS.md + OpenAI 원문 기준 PLANS.md/ExecPlan + Matt skills + 명시 호출형 custom skill + practical hooks + Unity MCP"로 정리됐다.
- custom skills와 hooks는 보류가 아니라 채택이다. 다만 첫 skill/hook은 별도로 선정하고 dry-run/smoke를 거친다.
- Matt skills는 workflow로 채택하지만, 산출물의 공식 문서 반영은 tmp smoke 후 결정해야 한다.
- Unity MCP는 live Editor 상태 확인에 필요하지만, custom MCP를 공식 도구로 승격하려면 반복 필요와 운영 정책이 더 필요하다.
- plugin은 지금 만들지 않지만, SVM v1 완료 후 pluginization checkpoint를 강제한다.

## 실제로 도움 된 점

- Prompts Lab의 실험 결과가 실제 개발 전 governance 선택으로 압축됐다.
- 항목별 사용자 확인을 거쳐 초안 판단과 최종 확정 판단을 분리했다.
- 구현 시작 전에 필요한 문서 작업 순서가 정리됐다.
- root `AGENTS.md`, `PLANS.md` 템플릿, Matt workflow smoke, 018 실행, 첫 custom skill/hook 후보 선정이 다음 단계로 분리됐다.
- plugin은 지금 만들지 않되 프로젝트 완료 후 재사용 가능한 workflow 묶음으로 검토할 강제 checkpoint가 생겼다.

## 헷갈린 점

- `docs/decisions.md`를 단일 파일로 만들지, 009에서 논의한 `docs/90-decisions/` 구조로 갈지는 아직 확정되지 않았다.
- Matt skills 설치 후 생성되는 문서 구조가 SVM의 future docs 구조와 얼마나 충돌하는지는 아직 smoke test 전이다.
- 첫 custom skill을 `ai-persona-architect-evaluator`, `mistake-to-guardrail-reviewer`, `unity-micro-scope-guard` 중 무엇으로 할지는 018 이후 확정해야 한다.
- 첫 hook을 Stage Router와 Unity Edit Guard 중 어떤 순서로 구현할지는 dry-run/warn smoke 설계 때 정한다.

## 위험하거나 과해 보인 점

- final selection 직후 바로 Unity 구현으로 넘어가면 Prompts Lab 결과가 실제 운영 규칙으로 정리되지 않은 채 흩어질 수 있다.
- Matt skills 산출물을 검토 없이 공식 project docs로 받아들이면 실험 문서와 프로젝트 문서가 다시 섞일 수 있다.
- parent repo hook을 너무 강하게 켜면 필요한 Unity 작업까지 막거나 trust/운영 부담이 생길 수 있다.
- custom skill을 자동 trigger로 만들면 사용자가 원하지 않는 시점에 개입할 위험이 있다.
- plugin을 지금 만들면 반복성이 검증되지 않은 workflow를 유지보수 대상으로 고정할 수 있다.

## 채택 여부

채택/보류/폐기 중 정확히 하나만 선택한다. 추가 실험 필요 여부는 후속 작업으로 분리해서 기록한다.

- [x] 채택
- [ ] 보류
- [ ] 폐기

## 채택/보류/폐기 이유

017 최종 선택은 지금까지의 Prompts Lab 결과를 실제 Safe Village Micro 개발 전 운영 구성으로 압축하는 데 성공했다. 사용자 확인을 거쳐 `AGENTS.md`, `PLANS.md`/ExecPlan, Matt skills, custom skills, hooks, MCP, 구현 시작 조건은 채택으로 확정했다. plugin은 지금 제작하지 않지만 SVM v1 완료 후 pluginization checkpoint를 필수로 두며, `docs/threads`는 폐기한다. 채택은 즉시 무차별 적용이 아니라, 각 항목을 governance 문서와 smoke/dry-run 절차로 안전하게 반영한다는 뜻이다.

## 다음 실험 프롬프트

```text
docs/prompts/018-ai-gap-map.md를 일반 모드로 실행해줘.

조건:
- 017-final-selection 결과를 근거로 사용한다.
- 실제 Unity 구현으로 넘어가지 않는다.
- AI 활용에서 아직 불안정한 지점, 검증 공백, 추가로 필요한 persona/skill 후보를 정리한다.
```

## 후속 작업

- [x] 문서 갱신 필요
- [x] AGENTS.md 반영 검토
- [x] skill 후보 검토
- [x] hook 후보 검토
- [x] 추가 실험 필요
- [ ] 추가 리서치 필요

후속 작업 메모:

`다음 governance 순서는 사용자 확인 반영본 커밋과 태그, 결정 문서 위치 선택, root AGENTS.md 초안, OpenAI 원문 기준 PLANS.md 템플릿, Matt workflow tmp smoke, 018-ai-gap-map 실행, 첫 custom skill 후보 선정, Stage Router/Unity Edit Guard dry-run 설계다. plugin 제작은 지금 하지 않고 SVM v1 완료 후 pluginization checkpoint에서 검토한다. Unity 구현은 first playable 범위와 완료 기준을 governance 문서로 잠근 뒤 시작한다.`
