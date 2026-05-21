# Prompt Result: 010. Custom Skill 초안 생성

## 실험 번호

`010`

## 실험 주제

`Custom Skill 초안 생성`

## 실행 일시

`2026-05-22 08:03 KST`

## 실행 모드

일반/튜터 중 정확히 하나만 선택한다.

- [ ] 일반
- [x] 튜터

## 사용자 명령

```text
'/Users/kaya/Documents/Codex/codex-harness-svm-v2/docs/prompts/010-custom-skill-draft.md' 튜터 모드로 실행해줘.

우선 기록 정리해줘.
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

`docs/prompts/010-custom-skill-draft.md`

## 모델/클라이언트/실행 환경

- 모델: `GPT-5 계열 Codex, 세부 모델명 확인 불가`
- 클라이언트: `Codex coding agent`
- 실행 환경: `macOS zsh, repo root /Users/kaya/Documents/Codex/codex-harness-svm-v2, KST`

## 실행 조건

- 파일 수정 허용 여부: `실험 실행 단계 파일 수정 금지, 기록 단계에서 docs/prompt-results/010-custom-skill-draft.md 생성 허용`
- 사용한 skill/tool: `skill-creator 지침 확인, shell로 prompts README와 템플릿 확인, apply_patch로 결과 파일 생성`
- 별도 제약: `Unity 파일 수정 금지, 실제 skill 생성 금지, 실제 구현 금지, custom skill 구조 이해에 집중`

## Codex 응답 요약

Codex는 `unity-micro-scope-guard`를 실제 생성하지 않고, custom skill의 front matter와 instruction 본문이 어떤 역할을 하는지 설명했다. 초기에는 자동 trigger를 전제로 한 description 초안을 제시했지만, 사용자가 자동 trigger를 선호하지 않는다고 밝히면서 설계 방향을 명시 호출형으로 수정했다. 최종 초안은 `$unity-micro-scope-guard`처럼 사용자가 직접 호출할 때만 작동하는 scope review 도구로 정리됐다. AGENTS.md에는 skill 이름만 적는 대신, 명시 호출 규칙과 skill이 없을 때의 짧은 fallback checklist를 함께 두는 방식이 더 안정적이라고 판단했다. 강한 guardrail은 skill보다 hook, CI/check, scheduled audit, milestone review 쪽이 더 적합할 수 있다고 정리했다.

## 튜터 모드 상호작용 요약

일반 모드 실행이면 모든 항목에 `해당 없음`을 적는다. 튜터 모드 실행이면 전체 대화 전문을 붙여넣지 말고 핵심만 요약한다.

### Codex가 한 확인 질문

- `skill`과 `AGENTS.md 규칙`의 차이를 어떻게 이해하는지 물었다.
- `unity-micro-scope-guard`가 가장 먼저 막아야 할 scope expansion이 무엇인지 물었다.
- 초안에서 `front matter / trigger 조건`과 `instruction 본문 / 행동 규칙` 중 무엇에 더 집중하고 싶은지 물었다.
- `description`에 사용 금지 상황을 넣어야 하는 이유를 teach-back 질문으로 물었다.
- `너무 자주 켜지는 것`과 `너무 늦게 켜지는 것` 중 어느 쪽이 더 위험한지 물었다.
- 명시 호출형 skill이 자동 trigger 방식보다 workflow에 더 맞는 이유를 물었다.

### 사용자 답변 요약

- 사용자는 `skill`과 `AGENTS.md` 차이는 이미 많이 답했으므로 생략하겠다고 했다.
- `unity-micro-scope-guard`가 막아야 할 구체적 범위 확장은 아직 생각해본 적이 없다고 답했다.
- 초안 학습에서는 `front matter / trigger 조건`에 더 집중하고 싶다고 답했다.
- 자동 trigger 방식은 마음에 들지 않으며, `$` 표시를 사용해 직접 호출하는 방식이 가장 좋다고 밝혔다.
- 원하지 않는 상태에서 skill이 호출되는 것은 쓸데없는 개입처럼 느껴진다고 했다.
- 범위 제한을 진짜 guardrail로 둔다면 skill 자동 trigger보다 agent 규칙, hooks, scheduled check, 특정 build/tag 시점의 명시적 audit이 더 나을 수 있다고 판단했다.

### teach-back 결과 또는 아직 헷갈린 지점

- 사용자는 `너무 자주 켜지는 것`이 더 위험하다고 정리했다.
- 이유는 의도하지 않은 동작이 업무 흐름을 방해하기 때문이라고 설명했다.
- custom skill의 자동 trigger 자체에 대한 거부감이 확인됐다.
- 이 실험 이후 `unity-micro-scope-guard`는 자동 개입형이 아니라 `$` 명시 호출형 review mode로 보는 것이 사용자의 workflow에 더 맞는 방향으로 정리됐다.

### 다음 복습 질문

`$unity-micro-scope-guard`처럼 직접 호출하는 방식으로 바꾸면 자동 trigger 방식에 비해 무엇을 잃고, 무엇을 얻는지 한 문장씩 정리해보기.

## 내가 이해한 점

- custom skill의 front matter는 사람에게 보이는 소개문보다 Codex가 skill을 언제 사용할지 판단하는 routing 조건에 가깝다.
- `description`이 너무 넓으면 skill이 과하게 trigger되고, 너무 좁으면 필요한 순간에 작동하지 않을 수 있다.
- guard 성격의 skill은 잘못 켜졌을 때 도움보다 방해가 커질 수 있으므로, 자동 trigger보다 명시 호출형이 더 적합할 수 있다.
- `instruction` 본문은 skill이 켜진 뒤의 행동 순서를 정하는 부분이며, 추상적 경고보다 체크리스트형 절차가 더 안정적이다.
- scope 제한은 의미 판단이 필요한 영역과 기계적 차단이 가능한 영역을 분리해서 다뤄야 한다.

## 실제로 도움 된 점

- `unity-micro-scope-guard`를 자동 guardrail로 만들기보다 `$unity-micro-scope-guard`로 직접 호출하는 review mode로 설계하는 방향이 생겼다.
- AGENTS.md에는 skill 이름만 적기보다, "자동 적용하지 않는다", "명시 호출할 때만 사용한다", "skill이 없을 때의 fallback checklist"를 함께 두는 방식이 더 낫다는 기준이 생겼다.
- hook은 `Packages/manifest.json`, `ProjectSettings`, 금지 파일 생성처럼 기계적으로 확인 가능한 영역에 더 적합하다는 구분이 생겼다.
- milestone, tag, build 시점에 scheduled scope audit을 실행하는 방식이 평소 작업 흐름을 덜 방해하는 guardrail 후보로 떠올랐다.

## 헷갈린 점

- `unity-micro-scope-guard`를 실제 skill로 만들지, AGENTS.md 규칙과 체크리스트만으로 둘지는 아직 확정하지 않았다.
- `$` 직접 호출형 skill이 현재 Codex 환경에서 얼마나 안정적으로 사용 가능한지, 실제 설치/호출 방식은 아직 검증하지 않았다.
- scheduled scope audit을 hooks, CI, 수동 프롬프트, 태그 기반 체크 중 어디에 둘지는 아직 정하지 않았다.
- AGENTS.md에 넣을 정확한 문구와 fallback checklist의 길이는 추가 정리가 필요하다.

## 위험하거나 과해 보인 점

- 자동 trigger skill은 사용자가 원하지 않는 시점에 개입해서 업무 흐름을 방해할 수 있다.
- 범위 축소를 너무 강하게 적용하면 핵심 playable loop에 필요한 요소까지 잘라낼 수 있다.
- AGENTS.md, skill, hooks, scheduled check가 모두 같은 규칙을 들고 있으면 중복과 drift가 생길 수 있다.
- 작은 SVM v1 단계에서 custom skill까지 만드는 것은 AGENTS.md 규칙만으로 충분한 문제를 과하게 구조화하는 것일 수 있다.

## 채택 여부

채택/보류/폐기 중 정확히 하나만 선택한다. 추가 실험 필요 여부는 후속 작업으로 분리해서 기록한다.

- [ ] 채택
- [x] 보류
- [ ] 폐기

## 채택/보류/폐기 이유

`unity-micro-scope-guard`의 방향성은 유효하지만, 지금 단계에서 실제 custom skill로 채택하기에는 아직 과할 수 있다. 특히 사용자는 자동 trigger를 원하지 않고 `$` 명시 호출 방식을 선호하므로, skill보다 AGENTS.md의 명시 호출 규칙과 fallback checklist만으로 충분한지 먼저 확인하는 편이 낫다. 강한 guardrail이 필요하다면 skill이 아니라 hooks, scheduled audit, milestone review 쪽이 더 적합한지 후속 실험에서 비교해야 한다.

## 다음 실험 프롬프트

```text
docs/prompts/011-matt-skills-review.md를 튜터 모드로 실행해줘.

다만 이번 010 결과를 반영해서, skill을 자동 trigger 도구로 전제하지 말고
사용자가 $로 명시 호출하는 review mode 또는 AGENTS.md fallback checklist로 대체 가능한지 함께 검토해줘.
```

## 후속 작업

- [x] 문서 갱신 필요
- [x] AGENTS.md 반영 검토
- [x] skill 후보 검토
- [x] hook 후보 검토
- [x] 추가 실험 필요
- [ ] 추가 리서치 필요

후속 작업 메모:

`현재는 unity-micro-scope-guard skill을 실제로 만들지 않는다. 후속 정리에서 AGENTS.md에 "자동 적용하지 않음", "$unity-micro-scope-guard 명시 호출 시에만 사용", "skill이 없을 때의 fallback checklist"를 넣을지 검토한다. hook/check 쪽은 기계적으로 감지 가능한 범위 확장, 예를 들어 Packages/manifest.json, ProjectSettings, save/load, inventory, shop/currency, multi-scene progression 관련 파일 또는 패턴을 어느 수준에서 경고할지 별도 실험으로 검토한다.`
