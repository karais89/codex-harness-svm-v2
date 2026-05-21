# Prompt Result: 004. Skill 개념 이해

## 실험 번호

`004`

## 실험 주제

`Skill 개념 이해`

## 실행 일시

`2026-05-21 18:53 KST`

## 실행 모드

일반/튜터 중 정확히 하나만 선택한다.

- [ ] 일반
- [x] 튜터

## 사용자 명령

```text
004-skill-concepts.md 튜터 모드로 실행해줘.

방금 실험 결과를 docs/prompt-results/004-skill-concepts.md에 기록해줘
```

## 적용한 실행 모드 wrapper

```text
docs/prompts/README.md의 튜터 모드 wrapper를 적용했다.

- Safe Village Micro 구현으로 넘어가지 않음.
- 실험 실행 단계에서는 파일을 생성/수정하지 않음.
- 현재 repo 구조를 먼저 확인하고, 확인된 사실과 추측을 분리함.
- Unity gameplay code, Scene, Packages/manifest.json, ProjectSettings/를 수정하지 않음.
- 바로 긴 설명을 시작하지 않고 시작 질문으로 현재 이해 수준을 확인함.
- 개념 단위로 나누어 설명하고 teach-back 질문으로 이해를 확인함.
- 마지막에는 핵심 요약, 복습 질문 1개, 다음 실험 제안 순서로 마무리함.
```

## 참조한 프롬프트 파일

`docs/prompts/004-skill-concepts.md`

## 모델/클라이언트/실행 환경

- 모델: `GPT-5 계열 Codex, 세부 모델명 확인 불가`
- 클라이언트: `Codex coding agent, 세부 클라이언트명 확인 불가`
- 실행 환경: `macOS zsh, repo root /Users/kaya/Documents/Codex/codex-harness-svm-v2, KST`

## 실행 조건

- 파일 수정 허용 여부: `실험 실행 단계 파일 수정 금지, 기록 단계에서 docs/prompt-results/ 아래 결과 파일 생성 허용`
- 사용한 skill/tool: `전용 skill 없음. repo 확인과 기록을 위해 shell, apply_patch 사용`
- 별도 제약: `Unity 파일 수정 금지, 실제 skill 생성 금지, Safe Village Micro 구현 계획으로 넘어가지 않기, 확인된 사실과 추측 분리`

## Codex 응답 요약

Codex는 skill을 "반복 작업용 프롬프트"에 가깝지만, 단순 프롬프트보다 구조화된 작업 패키지라고 설명했다. Prompt는 이번 한 번의 지시이고, AGENTS.md는 repo 전체에 항상 적용되는 규칙이며, skill은 특정 반복 작업에 선택되는 절차 묶음으로 구분했다. `SKILL.md`의 name은 사람이 부르기 쉬운 식별자이고 description은 Codex가 언제 skill을 선택해야 하는지 판단하는 핵심 신호라고 설명했다. Instruction-only skill은 판단, 설명, 리뷰, 절차 진행에 적합하고, script 포함 skill은 반복적인 파일 생성, 검사, 변환에 적합하다고 설명했다. Safe Village Micro 후보로는 prompts lab 결과 기록, 작업 계약 작성, Unity 테스트 실패 검토, 씬 변경 검토, 디자인 노트 검토 skill을 제안했다.

## 튜터 모드 상호작용 요약

일반 모드 실행이면 모든 항목에 `해당 없음`을 적는다. 튜터 모드 실행이면 전체 대화 전문을 붙여넣지 말고 핵심만 요약한다.

### Codex가 한 확인 질문

- 사용자가 skill을 현재 어떤 개념으로 이해하고 있는지 물었다.
- prompt, AGENTS.md, hook, plugin 중 skill과의 경계에서 헷갈리는 부분이 있는지 확인했다.
- Unity workflow 예시를 문서/실험 운영, Unity 구현/검증, 둘 다 중 어디에 맞출지 물었다.
- prompt와 skill의 차이를 일회성, 반복성, 포함할 수 있는 것 관점에서 다시 설명하게 했다.
- AGENTS.md에 적합한 규칙과 skill에 적합한 반복 절차를 예시로 구분하게 했다.
- `description: Unity 작업을 도와준다`가 왜 나쁜 skill description인지 설명하게 했다.
- Prompts Lab 결과 기록 skill을 instruction-only로 시작할지 script 포함으로 시작할지 판단하게 했다.
- `Unity 개발 skill`이라는 이름이 왜 나쁜 후보인지, 더 좋은 이름으로 어떻게 좁힐지 묻게 했다.
- 마지막 복습 질문으로 AGENTS.md에 넣을 규칙과 skill로 만들 반복 절차를 각각 예로 들게 했다.

### 사용자 답변 요약

- 사용자는 skill을 "반복해서 작업하는 프롬프트를 쉽게 호출 가능하게 만든 것"으로 이해하고 있었다.
- skill과 다른 개념 사이에서 특별히 헷갈리는 경계는 없다고 답했다.
- Unity workflow 예시는 문서/실험 운영과 Unity 구현/검증을 모두 다루길 원했다.
- prompt는 일회성이고 skill은 반복하는 것이라고 정리했다.
- "Prompts Lab 실험 중에는 Assets, Packages, ProjectSettings를 수정하지 않는다"는 AGENTS.md에, "Unity 테스트 실패 시 로그와 코드를 순서대로 확인한다"는 skill에 적합하다고 답했다.
- 모호한 description은 skill이 호출될 가능성이 낮기 때문에 나쁘다고 답했다.
- Prompts Lab 결과 기록 skill은 스크립트가 필요 없는 작업이므로 instruction-only로 시작해도 된다고 답했다.
- `Unity 개발 skill`은 명확하지 않은 이름이므로 역할을 바로 알 수 있게 좁혀야 한다고 답했다.
- AGENTS.md 예시로 "모든 문서는 한글로 작성하라", skill 예시로 "PRD 만들기"를 들었다.

### teach-back 결과 또는 아직 헷갈린 지점

- 사용자는 prompt와 skill의 핵심 차이를 "일회성"과 "반복성"으로 설명할 수 있었다.
- 사용자는 AGENTS.md가 상시 규칙이고 skill이 특정 반복 절차라는 차이를 예시로 구분할 수 있었다.
- 사용자는 skill description이 너무 넓으면 맞는 상황에서 선택되지 않거나 잘못 선택될 수 있다는 점을 이해했다.
- 사용자는 instruction-only skill로 시작할 수 있는 작업과 script가 나중에 필요한 작업을 구분할 수 있었다.
- 보완할 지점은 skill 이름을 만들 때 `prd 만들기`처럼 넓은 표현보다 `safe-village-prd-drafter`처럼 대상과 역할을 더 명확히 좁히는 것이다.
- 실제 skill 생성이나 채택은 아직 하지 않았고, 후보 수준으로만 정리했다.

### 다음 복습 질문

`AGENTS.md에 넣어야 할 상시 규칙 하나와 skill로 만들 반복 절차 하나를 각각 더 좁고 구체적인 이름으로 다시 써보기.`

## 내가 이해한 점

- Skill은 반복 작업을 다시 실행하기 좋게 만든 작업 패키지이며, 단순 prompt보다 name, description, 절차, 보조 파일을 포함할 수 있다.
- Prompt는 이번 한 번의 지시이고, AGENTS.md는 repo 전체에 항상 적용되는 규칙이며, skill은 특정 반복 작업에 선택되는 절차 묶음이다.
- `SKILL.md`의 description은 자동 선택 여부와 오선택 위험을 좌우하므로 넓은 표현보다 사용 조건과 제외 조건이 분명해야 한다.
- Instruction-only skill은 판단과 절차 중심 작업에 적합하고, script 포함 skill은 반복적인 파일 생성, 검사, 변환에 적합하다.
- Safe Village Micro 초반에는 실제 skill 생성보다 instruction-only 후보를 검토하는 단계가 적절하다.

## 실제로 도움 된 점

- Prompts Lab 결과 기록, 작업 계약 작성, Unity 테스트 실패 검토처럼 반복되는 업무가 skill 후보가 될 수 있음을 확인했다.
- "Unity 개발 skill"처럼 넓은 이름은 피하고, `unity-editmode-test-runner`, `unity-test-failure-review`, `safe-village-prd-drafter`처럼 대상과 역할이 드러나는 이름을 써야 한다는 기준이 생겼다.
- AGENTS.md에 넣을 상시 규칙과 skill로 만들 반복 절차를 구분하는 판단 기준이 생겼다.
- 지금 단계에서는 script 자동화보다 instruction-only skill 후보를 먼저 검토하는 편이 안전하다는 기준을 얻었다.

## 헷갈린 점

- skill 이름과 description을 얼마나 좁혀야 실제 자동 선택에 적합한지는 다음 실험에서 더 검토할 필요가 있다.
- `PRD 만들기` 같은 반복 작업 후보가 실제 skill로 만들 만큼 자주 반복될지는 아직 검증되지 않았다.

## 위험하거나 과해 보인 점

- 너무 넓은 skill은 잘못 선택되거나 선택되지 않아 오히려 작업 품질을 낮출 수 있다.
- 초반부터 script 포함 skill을 만들면 학습 목적보다 자동화 구조가 앞서고 유지보수 부담이 커질 수 있다.
- Unity 씬, prefab, ProjectSettings를 자동으로 수정하는 skill은 실패 비용이 크므로 검토용 skill과 수정용 자동화를 구분해야 한다.
- 실제 반복성이 확인되기 전에 `Safe Village Micro 전체 개발 skill` 같은 큰 skill을 만들면 scope creep이 생길 수 있다.

## 채택 여부

채택/보류/폐기 중 정확히 하나만 선택한다. 추가 실험 필요 여부는 후속 작업으로 분리해서 기록한다.

- [x] 채택
- [ ] 보류
- [ ] 폐기

## 채택/보류/폐기 이유

이 실험은 skill을 prompt, AGENTS.md, script 자동화와 구분하는 기준을 만들었고, 현재 Prompts Lab 단계에서 쓸 수 있는 skill 후보 평가 기준을 제공했다. 다만 채택하는 것은 "skill 개념 구분 기준"이지 실제 skill 생성이나 프로젝트 도입이 아니다. 실제 skill 후보의 가치와 도입 여부는 다음 실험인 `005-skill-value-check`에서 별도로 검토한다.

## 다음 실험 프롬프트

```text
docs/prompts/005-skill-value-check.md를 튜터 모드로 실행해줘.
```

## 후속 작업

- [ ] 문서 갱신 필요
- [ ] AGENTS.md 반영 검토
- [x] skill 후보 검토
- [ ] hook 후보 검토
- [x] 추가 실험 필요
- [ ] 추가 리서치 필요

후속 작업 메모:

`005-skill-value-check에서 prompts-lab-result-recorder, codex-task-contract-writer, unity-test-failure-review, unity-scene-change-checker, safe-village-design-note-review, safe-village-prd-drafter 같은 후보가 실제로 skill로 만들 가치가 있는지 검토한다.`
