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

Codex는 `docs/prompt-results/`의 `001`-`016` 결과를 우선 근거로 삼아 Safe Village Micro에 실제 채택할 최소 운영 구성을 정리했다. 최종 선택은 root `AGENTS.md`, 제한적 `PLANS.md`/ExecPlan 기준, Matt skills 기본 workflow 후보, Unity MCP 사용 전제를 채택하는 쪽이다. 반대로 custom skills, parent repo hooks, plugin, subagent 구현 분담, `docs/threads`는 보류 또는 폐기로 정리했다. 구현으로 바로 넘어가지 않고, 017 결과 기록, 결정 문서 위치 선택, root `AGENTS.md`, `PLANS.md` 템플릿, Matt workflow smoke, 018 실행 같은 governance 단계를 먼저 진행해야 한다고 판단했다.

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
| Matt skills | 채택, 검증 필요 | SVM v1의 기본 workflow 후보로 둔다. 다만 Matt skills 산출물을 곧바로 공식 project docs로 승격하지 않고 tmp/smoke 후 반영한다. | `008-unity-workflow.md`, `011-matt-skills-review.md`, `014-execplan-plans.md` | 중간 |
| custom skills | 보류 | 자동 trigger는 사용자 선호와 맞지 않고, 현재 반복 workflow가 충분히 검증되지 않았다. 필요하면 `$` 명시 호출형 review skill만 후보로 둔다. | `005-skill-value-check.md`, `010-custom-skill-draft.md`, `011-matt-skills-review.md` | 높음 |
| hooks | 보류 | mock과 disposable real smoke는 성공했지만 parent repo 도입 정책은 아직 확정되지 않았다. 1순위 후보는 `PreToolUse` 보호 경로 guard다. | `006-hooks-concepts.md`, `006a-hooks-guard-practice.md`, `007-llm-failure-modes.md` | 높음 |
| MCP | 부분 채택 | 검증된 Unity MCP는 실제 Unity 검증 단계부터 사용 전제로 둔다. custom MCP는 학습 결과만 채택하고 공식 도입은 보류한다. | `012-mcp-concepts.md`, `012a-mcp-mock-tool.md` | 중간 |
| plugin | 보류 | 아직 plugin에 묶을 skill, hook, MCP, script가 반복 workflow로 검증되지 않았다. 013a 산출물은 learning draft로만 둔다. | `013-plugin-concepts.md`, `013a-plugin-bundle-practice.md` | 높음 |
| docs/threads 유지 여부 | 폐기 | 사용자가 `docs/threads` 개념을 원하지 않았고, 실험 문서와 프로젝트 문서 분리가 더 중요하다. | `009-project-structure.md` | 높음 |
| 실제 Unity 구현 시작 조건 | 보류 | governance 기록, 최소 운영 규칙, Matt workflow smoke, Unity 검증 기준 정리 전에는 구현으로 넘어가지 않는다. | `011-matt-skills-review.md`, `014-execplan-plans.md`, `016-midpoint-review-2026-05-21.md` | 높음 |

## 내가 이해한 점

- Safe Village Micro의 최소 구성은 "작은 repo-local 규칙 + Matt skills 후보 + Unity 검증 기준"으로 시작해야 한다.
- 모든 확장 도구를 채택하는 것이 아니라, AGENTS.md와 PLANS.md는 가볍게 채택하고 custom skill, hook, plugin, subagent 구현 분담은 보류하는 쪽이 현재 근거와 맞다.
- Matt skills는 workflow 후보로 긍정하지만, 산출물의 공식 문서 반영은 별도 규칙이 필요하다.
- Unity MCP는 live Editor 상태 확인에 필요하지만, custom MCP를 공식 도구로 승격하려면 반복 필요와 운영 정책이 더 필요하다.

## 실제로 도움 된 점

- Prompts Lab의 실험 결과가 실제 개발 전 governance 선택으로 압축됐다.
- 구현 시작 전에 필요한 문서 작업 순서가 정리됐다.
- root `AGENTS.md`, `PLANS.md` 템플릿, Matt workflow smoke, 018 실행이 다음 단계로 분리됐다.
- hook, custom skill, plugin을 "좋아 보이므로 도입"하지 않고 보류할 근거가 명확해졌다.

## 헷갈린 점

- `docs/decisions.md`를 단일 파일로 만들지, 009에서 논의한 `docs/90-decisions/` 구조로 갈지는 아직 확정되지 않았다.
- Matt skills 설치 후 생성되는 문서 구조가 SVM의 future docs 구조와 얼마나 충돌하는지는 아직 smoke test 전이다.
- Unity MCP 사용 시점과 custom MCP 도입 기준은 실제 Unity 구현 반복을 봐야 더 정확해진다.

## 위험하거나 과해 보인 점

- final selection 직후 바로 Unity 구현으로 넘어가면 Prompts Lab 결과가 실제 운영 규칙으로 정리되지 않은 채 흩어질 수 있다.
- Matt skills 산출물을 검토 없이 공식 project docs로 받아들이면 실험 문서와 프로젝트 문서가 다시 섞일 수 있다.
- parent repo hook을 너무 일찍 켜면 필요한 Unity 작업까지 막거나 trust/운영 부담이 생길 수 있다.
- custom skill과 plugin을 지금 만들면 반복성이 검증되지 않은 workflow를 유지보수 대상으로 고정할 수 있다.

## 채택 여부

채택/보류/폐기 중 정확히 하나만 선택한다. 추가 실험 필요 여부는 후속 작업으로 분리해서 기록한다.

- [x] 채택
- [ ] 보류
- [ ] 폐기

## 채택/보류/폐기 이유

017 최종 선택은 지금까지의 Prompts Lab 결과를 실제 Safe Village Micro 개발 전 최소 운영 구성으로 압축하는 데 성공했다. 채택하는 것은 이 결과 자체와 다음 governance 순서이며, Unity 구현 시작이나 custom skill/hook/plugin의 즉시 도입은 아니다. 현재 근거상 가장 안전한 선택은 root `AGENTS.md`와 제한적 `PLANS.md` 기준을 먼저 정하고, Matt skills와 Unity MCP는 검증 단계로 가져가되 나머지 확장 도구는 보류하는 것이다.

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

`다음 governance 순서는 017 결과 기록, 결정 문서 위치 선택, root AGENTS.md 초안, PLANS.md 템플릿, Matt workflow smoke, 018-ai-gap-map 실행이다. custom skills, parent repo hooks, plugin, subagent 구현 분담은 기본 비활성/보류 상태로 둔다. Unity 구현은 first playable 범위와 완료 기준을 governance 문서로 잠근 뒤 시작한다.`
