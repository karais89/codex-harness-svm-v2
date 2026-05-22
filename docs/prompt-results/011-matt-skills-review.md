# Prompt Result: 011. Matt Skills 검토

## 실험 번호

`011`

## 실험 주제

`Matt Skills 검토`

## 실행 일시

`2026-05-22 12:46 KST`

## 실행 모드

일반/튜터 중 정확히 하나만 선택한다.

- [ ] 일반
- [x] 튜터

## 사용자 명령

```text
011-matt-skills-review.md 튜터 모드로 실행해줘

그래 논의한 대로 진행하고 이번 튜터 결과도 기록해줘.
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
- 마지막에는 핵심 요약, 복습 질문 1개, 다음 실험 제안 순서로 마무리함.
- 기록 단계에서만 docs/prompt-results/011-matt-skills-review.md 생성을 허용함.
```

## 참조한 프롬프트 파일

`docs/prompts/011-matt-skills-review.md`

## 모델/클라이언트/실행 환경

- 모델: `GPT-5 계열 Codex, 세부 모델명 확인 불가`
- 클라이언트: `Codex coding agent`
- 실행 환경: `macOS zsh, repo root /Users/kaya/Documents/Codex/codex-harness-svm-v2, KST`

## 실행 조건

- 파일 수정 허용 여부: `실험 실행 단계 파일 수정 금지, 기록 단계에서 docs/prompt-results/011-matt-skills-review.md 생성 허용`
- 사용한 skill/tool: `shell로 repo 구조, prompts README, 기존 prompt results, result template 확인; web으로 Matt Pocock skills GitHub와 OpenAI/Unity 관련 공개 자료 확인; apply_patch로 결과 파일 생성`
- 별도 제약: `Unity 파일 수정 금지, Matt skills 설치 명령 실행 금지, Safe Village Micro 구현 task로 확장하지 않기`

## Codex 응답 요약

Codex는 처음에 Matt skills 전체 설치와 기본 workflow 채택을 분리해서 봐야 한다고 설명했지만, 사용자는 Matt skills 자체를 기본 workflow로 적극 사용할 수 있다고 정정했다. 이후 결론은 "Matt skills를 제한적으로 쓸지"가 아니라 "v1 + Matt skills를 기본 workflow로 두고 Unity 검증, hooks, custom skill을 어디에 붙일지 판단한다"로 바뀌었다. 사용자와 Codex는 SVM v1의 중심을 `Unity playable prototype repo`로 두고, workflow는 게임 개발을 돕는 보조 수단으로 해석했다. 또한 사용자는 AI 격차를 줄이기 위해 최신성, 근거성, Game/Unity 적용성 및 확장성, 위험 판단, 검증 설계를 갖춘 상위 `AI Persona Architect / Evaluator` 필요성을 제기했다.

## 튜터 모드 상호작용 요약

일반 모드 실행이면 모든 항목에 `해당 없음`을 적는다. 튜터 모드 실행이면 전체 대화 전문을 붙여넣지 말고 핵심만 요약한다.

### Codex가 한 확인 질문

- Matt skills 검토에서 가장 중요한 기준이 명세 좁히기, 상태/인수인계 유지, custom skill 대체 가능성 중 무엇인지 물었다.
- `grill-with-docs`의 문서 생성 성향을 현재 repo에 허용할지, tmp 실험으로만 볼지 물었다.
- Matt skills 전체 설치와 기본 workflow 채택을 어떻게 구분해야 하는지 물었다.
- `grill-me`와 `grill-with-docs`의 차이를 사용자가 자기 말로 설명하게 했다.
- SVM v1의 중심 페르소나가 Unity playable prototype repo인지, Codex workflow experiment repo인지, 학습/블로그 기록 repo인지 물었다.
- AI 전문가 페르소나가 직접 코드를 짜는 역할인지, AI 활용 판단과 검증 기준을 세우는 역할인지 물었다.
- AI Persona Architect / Evaluator의 평가 기준에서 SVM 한정 적용성이 너무 좁은지 확인했다.
- 이 페르소나를 처음부터 custom agent로 만들지 않고 skill로 시작하는 이유를 확인했다.

### 사용자 답변 요약

- 사용자는 명세를 좁히는 능력과 작업 상태/인수인계 유지가 중요하다고 답했다.
- custom skill은 Matt skills와 별개이며, 프로젝트에 필요한 custom skill은 직접 만들어야 한다고 보았다.
- `grill-with-docs`는 현재 프로젝트 직접 반영 여부는 미정이지만, tmp 폴더에서 테스트하는 것은 허용한다고 답했다.
- Matt skills를 기본 workflow로 써도 SVM이 과해지지는 않을 것 같고, skill set 자체가 마음에 든다고 정정했다.
- `grill-me`는 대화 세션에서 정답을 찾는 역할, `grill-with-docs`는 문서화까지 진행하는 역할로 설명했다.
- 사용자는 `/setup-matt-pocock-skills -> /grill-with-docs -> /to-prd -> /to-issues -> /triage -> /tdd -> Unity Play Mode 검증 -> /diagnose -> /handoff` 흐름을 검토 대상으로 제시했다.
- SVM v1은 게임 개발이 목적이며, workflow는 언제든 바뀔 수 있고 실제로 어떤 방식으로 게임을 개발할 수 있는지 파악하기 위한 것이라고 답했다.
- 사용자는 최신 AI/LLM/game-dev 트렌드와 정확한 근거를 기반으로 AI 활용 방향을 판단하는 전문 페르소나가 가장 중요하다고 말했다.
- 이 페르소나는 Unity 전문 페르소나 같은 하위 페르소나를 설계하고, rubric과 테스트 프롬프트로 일정 점수 이상일 때만 통과시키는 역할일 수 있다고 보았다.
- 페르소나의 신뢰성 자체가 불안하므로 최신성, 근거성, 사실/추론/추측 분리, 방향 오류 가능성까지 평가해야 한다고 답했다.

### teach-back 결과 또는 아직 헷갈린 지점

- 사용자는 `grill-me`와 `grill-with-docs`의 차이를 "대화 안에서 정답을 찾는 것"과 "문서화까지 진행하는 것"으로 정확히 구분했다.
- 사용자는 Matt skills 전체 사용 자체가 SVM을 과하게 만드는 것은 아니며, 문제는 산출물을 어디까지 프로젝트 공식 구조로 인정할지라고 정리했다.
- SVM v1의 목적은 workflow 자체가 아니라 게임 개발이며, workflow는 게임 개발 방식과 AI 활용 가능성을 파악하기 위한 실험 장치라고 정리했다.
- AI Persona Architect / Evaluator는 직접 구현자보다 "어떤 AI 활용이 맞는지 판단하고 검증 기준을 세우는 역할"에 가깝다고 이해했다.
- 아직 헷갈린 지점은 이 페르소나가 실제로 도움이 되는지, AI 격차를 줄이는 명확한 솔루션을 줄 수 있는지, 근거 기반인지 추측 기반인지, 방향 자체가 틀릴 가능성을 어떻게 검증할지이다.

### 다음 복습 질문

`AI Persona Architect / Evaluator가 "그럴듯한 AI 전문가 흉내"가 아니라 실제로 도움이 되는지 판단하려면, 어떤 테스트 프롬프트와 통과 기준을 먼저 만들어야 하는가?`

## 내가 이해한 점

- Matt skills는 SVM v1에서 제한적 후보가 아니라 기본 workflow 후보로 긍정하는 쪽이 현재 판단에 더 가깝다.
- 다만 Matt skills의 사용과 프로젝트 공식 문서 구조 반영은 분리해야 한다.
- SVM v1의 중심은 `Unity playable prototype repo`이며, Codex workflow와 블로그/학습 기록은 이를 돕는 보조 성격이다.
- 사용자가 원하는 것은 단순한 프롬프트 팁이 아니라, Unity/game-dev에서 AI를 어떻게 적용할지 판단하는 상위 전문 역할이다.
- `AI Persona Architect / Evaluator`는 SVM 한정이 아니라 Unity/게임 개발 전반의 AI 활용 판단, 하위 페르소나 설계, 평가 rubric, 테스트 프롬프트를 다루는 후속 custom skill 후보로 보는 것이 맞다.
- 이 페르소나는 최신성, 근거성, Game/Unity 적용성 및 확장성, 위험 판단, 검증 설계 기준을 통과해야 한다.

## 실제로 도움 된 점

- 011의 초점이 "Matt skills를 전부 설치하면 과한가"에서 "v1 + Matt skills를 기본 workflow로 두고 Unity 검증과 custom 확장을 어디에 붙일 것인가"로 정리됐다.
- `/setup-matt-pocock-skills`, `/grill-with-docs`, `/to-prd`, `/to-issues`, `/triage`, `/tdd`, Unity Play Mode 검증, `/diagnose`, `/handoff` 흐름을 SVM v1의 후보 workflow로 볼 수 있게 됐다.
- Matt skills와 custom skill의 관계가 경쟁 관계가 아니라 상하/보완 관계로 정리됐다.
- hooks는 Matt skills 대체가 아니라, 반복되는 위험을 기계적으로 막는 guard로 남겼다.
- AI Persona Architect / Evaluator를 즉시 custom agent로 만들지 않고, 먼저 custom skill 후보로 역할 계약서와 평가 rubric을 만들어 검증한다는 방향이 생겼다.

## 헷갈린 점

- Matt skills의 실제 `/setup-matt-pocock-skills` 실행 결과가 SVM repo에 어떤 파일 구조를 만들려 할지는 아직 직접 확인하지 않았다.
- `grill-with-docs`가 만드는 문서 구조가 009에서 논의한 future docs 구조와 얼마나 잘 맞는지는 tmp 실험이 필요하다.
- `/to-prd`, `/to-issues`, `/triage`, `/tdd`가 Unity playable slice에서 어느 정도까지 자연스럽게 이어지는지는 아직 실제 workflow smoke test 전이다.
- Unity Play Mode 검증을 수동 체크리스트로 둘지, custom skill로 둘지, MCP나 hook까지 붙일지는 아직 판단 전이다.
- AI Persona Architect / Evaluator가 실제로 AI 격차를 줄이는 데 도움이 되는지 검증할 평가 문항과 점수 기준은 아직 만들어지지 않았다.

## 위험하거나 과해 보인 점

- Matt skills가 만드는 산출물을 검토 없이 SVM 공식 문서 구조로 받아들이면, 게임 개발 문서와 workflow 실험 문서가 섞일 수 있다.
- AI 전문가 페르소나가 최신성이나 근거 없이 자신감 있게 말하면 오히려 잘못된 방향을 강화할 수 있다.
- AI Persona Architect / Evaluator를 처음부터 custom agent로 만들면, 아직 검증되지 않은 역할에 구조를 과하게 부여할 위험이 있다.
- Unity 개발에서 Matt skills만 믿고 Play Mode, Scene/Prefab/Input/ProjectSettings 검증을 생략하면 실제 playable 상태를 놓칠 수 있다.
- 최신 트렌드를 따라가는 것과 현재 Unity prototype에 적용 가능한 것을 구분하지 않으면 workflow가 연구 자체로 커질 수 있다.

## 채택 여부

채택/보류/폐기 중 정확히 하나만 선택한다. 추가 실험 필요 여부는 후속 작업으로 분리해서 기록한다.

- [x] 채택
- [ ] 보류
- [ ] 폐기

## 채택/보류/폐기 이유

Matt skills는 SVM v1의 기본 workflow 후보로 채택한다. 사용자 경험과 현재 판단상 skill set 자체는 프로젝트 목적과 잘 맞으며, 문제는 설치/사용 여부가 아니라 Unity 검증과 프로젝트 공식 문서 반영을 어떻게 분리할지에 있다. 단, `AI Persona Architect / Evaluator`는 이번 실험에서 바로 채택하지 않고, 최신성/근거성/Game-Unity 적용성 및 확장성/위험 판단/검증 설계를 평가하는 후속 custom skill 후보로 남긴다.

## 다음 실험 프롬프트

```text
AI Persona Architect / Evaluator custom skill 후보를 설계하고 싶다.

목표:
실제 skill 파일을 바로 만들지 말고, 먼저 역할 계약서, 평가 rubric, 테스트 프롬프트 3-5개를 만든다.

해야 할 일:
1. 이 페르소나가 줄이려는 AI 격차를 정의한다.
2. 최신성, 근거성, Game/Unity 적용성 및 확장성, 위험 판단, 검증 설계 기준으로 rubric을 만든다.
3. Unity playable prototype, Unity 프로토타이핑 workflow, 더 큰 Unity 프로젝트 아키텍처 확장 가능성을 분리해서 평가한다.
4. 하위 페르소나 예시(Unity Gameplay Engineer, Unity Play Mode QA, Blog/Handoff Editor 등)를 설계 대상으로 제안한다.
5. 페르소나가 실패했는지 판단할 폐기 기준을 포함한다.

출력:
- 역할 계약서 초안
- 평가 rubric
- 테스트 프롬프트 3-5개
- 통과 기준
- custom skill로 만들 조건
- custom agent로 승격할 조건

파일 수정과 실제 skill 생성은 하지 마라.
```

## 후속 작업

- [x] 문서 갱신 필요
- [x] AGENTS.md 반영 검토
- [x] skill 후보 검토
- [x] hook 후보 검토
- [x] 추가 실험 필요
- [x] 추가 리서치 필요

후속 작업 메모:

`Matt skills는 SVM v1의 기본 workflow 후보로 채택한다. 다음 단계에서는 실제 설치/실행 전에 tmp 또는 별도 실험에서 /setup-matt-pocock-skills, /grill-with-docs, /to-prd, /to-issues, /triage, /tdd, Unity Play Mode 검증, /diagnose, /handoff 흐름이 Unity playable prototype 개발에 맞는지 smoke test한다. AI Persona Architect / Evaluator는 SVM 한정 도구가 아니라 Unity/게임 개발 전반의 AI 활용 판단 페르소나로 후속 실험한다. 이 페르소나는 처음에는 custom skill 후보로 설계하고, 독립 리서치/하위 페르소나 생성/장기 eval 관리가 필요해질 때 custom agent 후보로 승격한다.`
