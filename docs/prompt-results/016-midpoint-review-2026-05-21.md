# Prompt Result: 016. 중간 학습 정리

## 실험 번호

`016`

## 실험 주제

`중간 학습 정리`

## 실행 일시

`2026-05-21 22:43 KST`

## 실행 모드

일반/튜터 중 정확히 하나만 선택한다.

- [x] 일반
- [ ] 튜터

## 사용자 명령

```text
'/Users/kaya/Documents/Codex/codex-harness-svm-v2/docs/prompts/016-midpoint-review.md' 이걸 할때가 온건가 9번 까지 진행했는데? 아니면 나중에 하면 되나?

진행하자 그럼
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

`docs/prompts/016-midpoint-review.md`

## 모델/클라이언트/실행 환경

- 모델: `GPT-5 계열 Codex, 세부 모델명 확인 불가`
- 클라이언트: `Codex coding agent`
- 실행 환경: `macOS zsh, repo root /Users/kaya/Documents/Codex/codex-harness-svm-v2, KST`

## 실행 조건

- 파일 수정 허용 여부: `실험 실행 단계 파일 수정 금지, 기록 단계에서 docs/prompt-results/016-midpoint-review-2026-05-21.md 생성 허용`
- 사용한 skill/tool: `shell로 docs/prompts/README.md, docs/prompts/016-midpoint-review.md, docs/prompt-results/001-009 및 006a 결과 확인, apply_patch로 결과 파일 생성`
- 별도 제약: `Unity 파일 수정 금지, 새로운 구현 계획 생성 금지, docs/prompt-results를 우선 근거로 사용, 각 결론에 근거 파일과 confidence 표시`

## Codex 응답 요약

016은 지금 실행할 타이밍이라고 판단했다. `docs/prompts/README.md`는 3-5개 실험마다 016 중간 정리를 권장하고, 현재는 `001-009`와 `006a`까지 결과가 쌓여 있기 때문이다. 중간 정리 결과, 현재까지 채택할 수 있는 것은 "가벼운 AGENTS.md 중심 운영, 반복성이 검증된 skill 후보만 좁혀 검토, hook은 보호 경로처럼 기계적으로 판정 가능한 위험에 한정"이라는 방향이다. 아직 최종 확정하면 안 되는 것은 Matt skills 세부 채택, custom skill 실제 생성, parent repo hook 도입, final docs tree 적용이다.

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

### 누락된 결과 파일

- 현재 checkpoint인 `001-009` 및 `006a` 기준으로는 누락 없음. confidence: 높음.
- 아직 미실행 상태로 남은 후속 실험: `010`, `011`, `012`, `012a`, `013`, `013a`, `014`, `015`. 이 항목들은 현재 누락 오류가 아니라 이후 실행 대상이다. 근거: `docs/prompts/README.md`, confidence: 높음.

### 내가 이해한 개념 목록

| 이해한 개념 | 근거 | confidence |
| --- | --- | --- |
| Codex는 repo 전체를 항상 알고 있는 존재가 아니라, 필요한 파일을 찾아 읽고 context에 들어온 근거로 판단하는 에이전트다. | `001-llm-codex-structure.md` | 높음 |
| AGENTS.md는 모든 지식을 담는 문서가 아니라, Codex가 항상 지켜야 할 짧은 행동 규칙과 문서 지도를 담는 진입점이다. | `002-agents-md.md`, `003-docs-responsibility.md` | 높음 |
| 문서 후보의 역할 정의와 실제 채택 여부는 분리해야 한다. 후보 문서를 설명하는 것만으로 도입이 확정된 것은 아니다. | `003-docs-responsibility.md` | 높음 |
| Skill은 반복 작업을 재현하기 위한 절차 묶음이고, 넓은 이름보다 대상과 역할이 좁은 description이 중요하다. | `004-skill-concepts.md`, `005-skill-value-check.md` | 높음 |
| Custom skill은 "좋아 보이는 아이디어"가 아니라 반복성, 피해 규모, 방지 가능성이 확인된 workflow에만 적합하다. | `005-skill-value-check.md` | 높음 |
| Hook은 자연어 지침을 반복하는 장치가 아니라 좁고 결정적인 조건을 자동 확인하는 guard다. | `006-hooks-concepts.md`, `006a-hooks-guard-practice.md`, `007-llm-failure-modes.md` | 높음 |
| `test`는 Codex 전용 기능이 아니라 unit test, Unity compile check, smoke check, diff check 같은 검증 수단 전체를 뜻한다. | `007-llm-failure-modes.md` | 높음 |
| SVM workflow는 무거운 DBZ-v0식 절차를 그대로 가져오는 것도 아니고, 문서 없이 바로 구현하는 것도 아니다. 가벼운 repo-local 규칙을 기본으로 두고 Matt skills는 전체 설치 가능성과 실제 기본 채택 범위를 분리해서 검토하는 방향이다. | `008-unity-workflow.md` | 중간 |
| `docs/prompts`와 `docs/prompt-results`는 실제 프로젝트 문서가 아니라 Codex workflow 실험 문서이며, 장기적으로는 `experiments/codex-workflow/`로 분리하는 후보가 됐다. | `009-project-structure.md` | 중간 |

### 아직 헷갈리는 개념 목록

| 헷갈리는 지점 | 근거 | confidence |
| --- | --- | --- |
| AGENTS.md에 직접 적을 핵심 규칙과 docs README로 넘길 세부 규칙의 경계가 아직 완전히 고정되지 않았다. | `002-agents-md.md`, `009-project-structure.md` | 높음 |
| 실제 SVM 개발 문서로 `project-goal`, `decisions`, `status`, `README/template` 등을 언제 만들지 아직 결정되지 않았다. | `003-docs-responsibility.md`, `009-project-structure.md` | 높음 |
| `mistake-to-guardrail-reviewer`가 실제 반복 workflow인지, AGENTS.md/checklist로 충분한지, instruction-only skill이 필요한지는 아직 010 이후 판단해야 한다. | `005-skill-value-check.md`, `007-llm-failure-modes.md` | 높음 |
| Parent repo에 실제 hook을 켤지, `ProjectSettings/`, `Packages/`, Scene/Prefab 변경을 어느 수준에서 block할지는 아직 확정되지 않았다. | `006-hooks-concepts.md`, `006a-hooks-guard-practice.md`, `007-llm-failure-modes.md` | 높음 |
| Matt skills 중 어떤 것을 기본/조건부/보류로 나눌지 아직 결정되지 않았다. | `008-unity-workflow.md` | 높음 |
| Plan mode, ExecPlan, Matt의 `to-prd`/`to-issues`/`grill-with-docs` 사이의 경계는 아직 정리되지 않았다. | `008-unity-workflow.md` | 높음 |
| 최종 docs tree의 `30-production`과 `40-engineering` 경계, 각 폴더 README/template 책임 분리는 아직 별도 논의가 필요하다. | `009-project-structure.md` | 높음 |

### 추가 실험이 필요한 항목

| 추가 실험 | 이유 | 근거 | confidence |
| --- | --- | --- | --- |
| `010-custom-skill-draft` | custom skill을 실제로 만들지 말지 판단하려면 `mistake-to-guardrail-reviewer` 같은 후보를 더 좁혀야 한다. | `005-skill-value-check.md`, `007-llm-failure-modes.md` | 높음 |
| `011-matt-skills-review` | 008에서 Matt skills는 가장 검토 가치가 큰 후보로 남았다. 다만 전체 설치 가능성과 모든 skill의 기본 workflow 채택은 구분해서 판단해야 한다. | `008-unity-workflow.md`, `009-project-structure.md` | 높음 |
| `014-execplan-plans` | Plan mode, ExecPlan, Matt skills 경계가 아직 흐리다. | `008-unity-workflow.md` | 중간 |
| `012/012a` MCP 실험 | Unity Editor 상태 확인과 Scene/Prefab 검증은 Matt skills만으로 해결되지 않아 MCP 또는 수동 검증 기준을 별도로 봐야 한다. | `001-llm-codex-structure.md`, `008-unity-workflow.md` | 중간 |

### 실제 Safe Village Micro 개발에 채택할 후보

| 채택 후보 | 의미 | 근거 | confidence |
| --- | --- | --- | --- |
| Root AGENTS.md 하나를 짧은 작업 계약과 문서 지도로 쓰기 | 하위 AGENTS.md는 반복 실패가 확인될 때만 검토한다. | `002-agents-md.md`, `003-docs-responsibility.md` | 높음 |
| Prompt와 AGENTS.md를 기본값으로 두고, skill/hook/MCP/plugin은 필요가 확인될 때 단계적으로 도입 | 초반부터 모든 확장을 켜면 학습과 운영 기준이 섞인다. | `001-llm-codex-structure.md` | 높음 |
| Skill은 반복 workflow에 한정하고 instruction-only 후보부터 검토 | script 포함 skill은 반복 파일 생성/검사가 분명해진 뒤가 맞다. | `004-skill-concepts.md`, `005-skill-value-check.md` | 높음 |
| Hook은 보호 경로 변경처럼 기계적으로 판정 가능한 위험에 한정해 후보로 둠 | `PreToolUse` path guard는 후보지만 parent repo 도입은 아직 아니다. | `006-hooks-concepts.md`, `006a-hooks-guard-practice.md`, `007-llm-failure-modes.md` | 높음 |
| SVM은 TGR-v1의 경량 흐름을 기본으로 하되 Matt skills는 전체 설치 가능성과 기본 채택 범위를 분리해 검토 | DBZ-v0식 무거운 절차와 무문서 구현 사이의 중간값이다. 설치는 넓게 할 수 있어도 실제 호출/기본 workflow 편입은 좁혀야 한다. | `008-unity-workflow.md` | 중간 |
| 실험 문서와 프로젝트 문서 분리 | `docs/prompts`와 `docs/prompt-results`는 장기적으로 `experiments/codex-workflow/` 격리 후보로 둔다. | `009-project-structure.md` | 중간 |

### 보류할 후보

| 보류 후보 | 보류 이유 | 근거 | confidence |
| --- | --- | --- | --- |
| Plugin 도입 | 현재는 여러 구성요소를 묶어 재사용/배포할 단계가 아니다. | `001-llm-codex-structure.md` | 높음 |
| 실제 parent repo hook 활성화 | mock과 disposable smoke는 했지만, parent repo 정책과 trust 대상은 아직 확정하지 않았다. | `006a-hooks-guard-practice.md` | 높음 |
| 모든 Scene/Prefab/Unity 파일 변경 block | 실제 개발 단계에서 필요한 작업까지 막을 수 있다. | `007-llm-failure-modes.md`, `006a-hooks-guard-practice.md` | 높음 |
| Matt skills 전체를 기본 workflow로 채택 | 전체 설치 자체는 검토 가능하지만, 모든 skill을 기본 운영 규칙처럼 쓰면 workflow 운영이 SVM 목적보다 커질 위험이 있다. | `008-unity-workflow.md` | 높음 |
| Spec Kit, BMad/BMad Game Dev Studio, Superpowers 같은 큰 workflow | 현재 작은 Unity playable loop 검증에는 프레임워크 자체가 과제가 될 수 있다. | `008-unity-workflow.md` | 중간 |
| 현재 repo에서 즉시 Unity project를 하위 폴더로 이동 | 009는 구조 논의였고 실제 폴더 생성/이동은 금지했다. | `009-project-structure.md` | 높음 |

### 다음 1-2개 실험 추천

1. `010-custom-skill-draft.md`
   - 이유: `mistake-to-guardrail-reviewer` 같은 custom skill 후보가 005와 007에서 남아 있다.
   - 조건: 실제 skill 파일을 만들지 말고, AGENTS.md/checklist/skill/hook 중 어디가 적합한지 먼저 비교한다.

2. `011-matt-skills-review.md`
   - 이유: 008과 009가 모두 Matt skills와 docs 구조 충돌 여부를 다음 큰 쟁점으로 남겼다.
   - 조건: Matt skills 전체 설치 가능성은 열어두되, 모든 skill을 기본 workflow로 채택한다고 가정하지 말고 SVM에 필요한 항목만 기본/조건부/보류로 나눈다.

## 내가 이해한 점

- 현재까지의 학습은 "도구를 많이 붙이기"가 아니라, prompt, AGENTS.md, skill, hook, MCP, plugin을 어떤 실패나 반복에 대응시키는지 구분하는 방향으로 수렴했다.
- 사용자는 `AGENTS.md`를 짧은 상시 지침과 문서 지도처럼 쓰고 싶어 하며, 문서/skill/hook을 너무 빨리 확정하는 것을 경계한다.
- Hook은 실제 가능성을 확인했지만, parent repo에 바로 도입할 정도로 정책이 확정된 것은 아니다.
- 현재 가장 중요한 다음 판단은 Matt skills와 custom skill 후보를 SVM의 가벼운 workflow 안에 어떤 수준으로 편입할지다. 특히 Matt skills는 전체 설치와 기본 채택을 분리해서 봐야 한다.

## 실제로 도움 된 점

- `016`을 지금 실행해도 되는 타이밍이라는 판단이 확인됐다.
- 001-009 결과를 한 번 묶어, 채택 후보와 보류 후보를 분리했다.
- 다음 실험은 넓게 흩어지기보다 순서대로 `010`을 먼저 실행하고, 그 다음 `011`로 Matt skills를 검토하는 것이 좋다는 결론을 얻었다.
- 최종 선택인 `017`로 바로 가지 않고, Matt skills/custom skill/ExecPlan/MCP 관련 남은 근거를 더 쌓아야 한다는 점이 분명해졌다.

## 헷갈린 점

- `010` 이후 custom skill 후보가 얼마나 남는지에 따라 `011`에서 Matt skills와 비교할 기준이 달라질 수 있다.
- 실제 SVM repo에서 `experiments/codex-workflow/`로 파일을 이동할지는 아직 논의 결과일 뿐 실행 결정이 아니다.
- Unity 검증 체계는 아직 문서/skill/hook만으로 닫히지 않았고, MCP 또는 수동 검증 기준을 후속 실험에서 봐야 한다.

## 위험하거나 과해 보인 점

- 지금 `017-final-selection`으로 바로 가면 Matt skills, custom skill, ExecPlan, MCP 판단 근거가 부족하다.
- 지금 parent repo hook이나 skill 파일을 실제로 만들면 "실험 결과가 기록되기 전까지 채택하지 않는다"는 운영 규칙과 충돌할 수 있다.
- 009에서 정리한 docs tree를 즉시 폴더 생성/이동으로 실행하면 구조 논의가 구현 작업으로 커질 수 있다.
- DBZ-v0식 안전장치를 그대로 가져오면 SVM의 경량 실험 목적과 충돌할 수 있다.

## 채택 여부

채택/보류/폐기 중 정확히 하나만 선택한다. 추가 실험 필요 여부는 후속 작업으로 분리해서 기록한다.

- [x] 채택
- [ ] 보류
- [ ] 폐기

## 채택/보류/폐기 이유

이 중간 정리는 001-009와 006a 결과를 근거로 지금까지의 이해, 남은 혼동, 채택 후보, 보류 후보를 분리했다. 특히 다음 실험을 순서대로 `010`부터 진행하고, `017-final-selection`은 아직 이르다는 판단을 남긴 점이 유효하다. 실제 workflow나 repo 구조를 확정한 것은 아니며, 다음 실험을 위한 정리 결과로 채택한다.

## 다음 실험 프롬프트

```text
docs/prompts/010-custom-skill-draft.md를 튜터 모드로 실행해줘.
005와 007 결과를 근거로 mistake-to-guardrail-reviewer 후보를 검토하되,
실제 skill 파일은 만들지 말고 AGENTS.md/checklist/skill/hook 중 어디가 적합한지 비교해줘.
```

그 다음:

```text
docs/prompts/011-matt-skills-review.md를 튜터 모드로 실행해줘.
008과 009 결과를 근거로, Matt skills 전체 설치 가능성은 열어두되
모든 skill을 기본 workflow로 채택한다고 가정하지 말고
SVM에 필요한 항목만 기본/조건부/보류로 나눠 검토해줘.
특히 docs/00-brief, docs/10-design, docs/20-art, docs/30-production,
docs/40-engineering, docs/90-decisions 구조와 충돌하는지 확인해줘.
파일 수정과 설치 명령 실행은 하지 마라.
```

## 후속 작업

- [x] 문서 갱신 필요
- [x] AGENTS.md 반영 검토
- [x] skill 후보 검토
- [x] hook 후보 검토
- [x] 추가 실험 필요
- [ ] 추가 리서치 필요

후속 작업 메모:

`다음 실험은 사용자 선호에 따라 순서대로 010을 먼저 실행한다. 010에서 custom skill 후보를 좁힌 뒤 011에서 Matt skills와 비교한다. 017-final-selection은 010/011/014 및 필요 시 012 계열 결과가 기록된 뒤 실행한다.`
