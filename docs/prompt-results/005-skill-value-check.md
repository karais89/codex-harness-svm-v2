# Prompt Result: 005. Skill 후보 가치 판단

## 실험 번호

`005`

## 실험 주제

`Skill 후보 가치 판단`

## 실행 일시

`2026-05-21 19:13 KST`

## 실행 모드

일반/튜터 중 정확히 하나만 선택한다.

- [ ] 일반
- [x] 튜터

## 사용자 명령

```text
005-skill-value-check 튜터 모드로 실행해줘

그래 현재 까지 내용 기록해줘.
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

`docs/prompts/005-skill-value-check.md`

## 모델/클라이언트/실행 환경

- 모델: `GPT-5 계열 Codex, 세부 모델명 확인 불가`
- 클라이언트: `Codex coding agent, 세부 클라이언트명 확인 불가`
- 실행 환경: `macOS zsh, repo root /Users/kaya/Documents/Codex/codex-harness-svm-v2, KST`

## 실행 조건

- 파일 수정 허용 여부: `실험 실행 단계 파일 수정 금지, 기록 단계에서 docs/prompt-results/ 아래 결과 파일 생성 허용`
- 사용한 skill/tool: `전용 skill 없음. repo 확인과 기록을 위해 shell, apply_patch 사용`
- 별도 제약: `Unity 파일 수정 금지, 실제 skill 생성 금지, Safe Village Micro 구현 계획으로 넘어가지 않기, 확인된 사실과 추측 분리`

## Codex 응답 요약

Codex는 9개 후보를 억지로 채택하는 것이 아니라 skill로 만들 가치가 없는 후보를 걸러내는 실험으로 접근했다. 사용자의 기준인 "2-3번 이상 반복되는 실제 workflow"와 "기존 skill/prompt/AGENTS.md보다 나은 호출 가치"를 기준으로 후보를 평가했다. 9개 후보 대부분은 그대로 채택하기보다 보류하거나 AGENTS.md, docs/prompts, 후속 실험으로 넘기는 편이 적절하다고 정리했다. 특히 `AI mistake logger`는 단순 기록기라면 약하지만, `mistake-to-guardrail-reviewer`로 고도화하면 Prompts Lab의 첫 custom skill 후보가 될 수 있다고 설명했다.

## 튜터 모드 상호작용 요약

일반 모드 실행이면 모든 항목에 `해당 없음`을 적는다. 튜터 모드 실행이면 전체 대화 전문을 붙여넣지 말고 핵심만 요약한다.

### Codex가 한 확인 질문

- "Codex skill로 만들 가치가 있다"는 말을 어떻게 이해하는지 물었다.
- 후보 9개 중 가장 끌리는 것과 가장 과해 보이는 것을 고르게 했다.
- skill과 AGENTS.md의 차이를 한 문장으로 설명하게 했다.
- `AI mistake logger`를 docs/prompts나 AGENTS.md에 두는 것과 skill로 두는 것의 차이를 물었다.
- `mistake-to-guardrail-reviewer`의 최종 출력이 단순 로그여야 하는지, 다음부터 막는 방법까지 포함해야 하는지 물었다.
- 실제 skill을 지금 만들지 않고 010까지 미루는 이유를 "반복 사례"와 "학습 순서"로 설명하게 했다.

### 사용자 답변 요약

- 사용자는 반복해서 작업하는 workflow가 있고 2-3번 이상 반복된다면 skill로 만들 가치가 있다고 답했다.
- 가장 끌리는 후보는 처음에는 7번 `AI mistake logger`라고 답했고, 1번 `Socratic clarification`과 5번 `PRD generator`도 좋아 보이지만 기존 Matt skill을 넘기 어렵다고 보았다.
- 9번 `MCP experiment planner`는 과해 보인다고 답했고, 사실 9개 후보 전체가 크게 끌리지는 않는다고 말했다.
- skill은 반복되는 내용을 쉽게 호출하는 것이고, AGENTS.md는 프로젝트 지침이라고 정리했다.
- `AI mistake logger`는 AGENTS.md에 관련 지침을 넣는 것만으로도 어느 정도 처리할 수 있지만, skill로 만들면 원하는 기록 동작과 판단 절차를 더 강하게 유도할 수 있다고 보았다.
- `mistake-to-guardrail-reviewer`라면 기록할 가치 판단, 보류 이유 로깅, 기존 유사 항목 확인, 승격 판단, hook 생성 제안까지 포함하면 좋은 skill이 될 것 같다고 답했다.

### teach-back 결과 또는 아직 헷갈린 지점

- 사용자는 skill 가치 기준을 반복성 중심으로 설명할 수 있었다.
- 사용자는 AGENTS.md와 skill의 차이를 "프로젝트 지침"과 "반복 호출 가능한 절차"로 구분할 수 있었다.
- `AI mistake logger`와 `mistake-to-guardrail-reviewer`는 완전히 다른 후보라기보다 고도화 단계 차이로 이해했다.
- 아직 사용자가 직접 판단하기 어려운 지점은 "어떤 실수를 기록할 가치가 있는가"였다.
- Codex는 기록 가치 기준을 반복성, 피해 규모, 방지 가능성으로 제안했다.
- 실제 skill 생성은 지금 바로 하지 않고 006 hooks, 007 failure modes, 010 custom skill draft 이후로 미루는 편이 안전하다고 정리했다.

### 다음 복습 질문

`AI mistake logger`와 `mistake-to-guardrail-reviewer`의 차이를 "단순 기록"과 "가드레일 승격 판단"이라는 말로 한 문장으로 정리해보기.`

## 내가 이해한 점

- Skill 후보는 "좋아 보이는 아이디어"가 아니라 실제 반복 workflow와 호출 가치가 있어야 한다.
- AGENTS.md는 짧은 상시 규칙과 문서 지도로 두고, 긴 판단 절차는 skill 후보나 별도 문서로 분리하는 편이 낫다.
- `AI mistake logger`는 단순히 실수를 저장하는 수준이면 AGENTS.md 규칙과 기록 양식으로 충분하다.
- `mistake-to-guardrail-reviewer`는 실수를 기록할지, 보류할지, AGENTS.md/prompt/checklist/hook/test/skill 중 어디로 승격할지 판단하는 운영 리뷰 skill이다.
- 기록 가치 기준은 반복성, 피해 규모, 방지 가능성으로 잡는 것이 실용적이다.

## 실제로 도움 된 점

- 9개 후보 중 그대로 즉시 채택할 skill은 거의 없다는 판단을 얻었다.
- `AI mistake logger`를 그대로 채택하지 않고 `mistake-to-guardrail-reviewer`로 재정의해야 가치가 생긴다는 기준이 생겼다.
- 실수 기록은 단순 로그가 아니라 보류 이유와 승격 판단까지 남겨야 나중에 운영 규칙 개선에 연결될 수 있음을 확인했다.
- hook은 skill이 직접 만드는 대상이 아니라, 반복성과 피해 규모가 충분할 때 사용자 승인 후 제안할 수 있는 강한 가드레일로 분리했다.
- 실제 custom skill 생성은 010 이후로 미루고, 005에는 후보 판단 결과만 남기는 편이 Prompts Lab 흐름에 맞다는 결론을 얻었다.

## 헷갈린 점

- 현재 repo에서 실제 실수 사례가 충분히 쌓이지 않았기 때문에 `mistake-to-guardrail-reviewer`가 반복 workflow인지 아직 완전히 검증되지는 않았다.
- `AI mistake logger`를 AGENTS.md 규칙과 문서 양식으로 둘지, instruction-only skill로 둘지의 최종 결정은 007 failure modes와 010 custom skill draft 이후에 다시 판단해야 한다.
- 기록할 가치가 낮은 항목을 어디까지 보류 로그에 남겨야 문서가 과해지지 않을지는 추가 기준이 필요하다.

## 위험하거나 과해 보인 점

- 단순 실수 기록을 바로 custom skill로 만들면 AGENTS.md와 문서 양식으로 충분한 일을 과하게 구조화할 수 있다.
- 모든 실수를 `ai-mistakes.md` 같은 문서에 넣으면 기록 문서가 금방 노이즈가 될 수 있다.
- 한 번의 실수만 보고 바로 hook이나 test를 만들면 자동화가 과해지고 유지보수 부담이 커질 수 있다.
- `MCP experiment planner`는 현재 단계에서 너무 이르고, Prompts Lab의 핵심 학습 흐름을 흐릴 수 있다.
- `Socratic clarification`과 `PRD generator`는 유용해 보이지만 기존 Matt skill과 겹칠 가능성이 있어 직접 custom skill로 만들 가치는 낮을 수 있다.

## 채택 여부

채택/보류/폐기 중 정확히 하나만 선택한다. 추가 실험 필요 여부는 후속 작업으로 분리해서 기록한다.

- [ ] 채택
- [x] 보류
- [ ] 폐기

## 채택/보류/폐기 이유

9개 후보 중 기존 이름과 범위 그대로 즉시 채택할 skill은 확정하지 않았다. 다만 7번 `AI mistake logger`는 `mistake-to-guardrail-reviewer`로 고도화하면 가장 유력한 custom skill 후보가 될 수 있다고 판단했다. 실제 skill 생성은 아직 반복 사례와 hook/failure mode 판단 근거가 부족하므로 006, 007, 010 실험 이후로 미룬다.

## 다음 실험 프롬프트

```text
docs/prompts/006-hooks-concepts.md를 튜터 모드로 실행해줘.
```

010 실행 시에는 010 프롬프트 파일을 미리 수정하지 않고, 실행 요청문에 다음 조건을 붙인다.

```text
docs/prompts/010-custom-skill-draft.md를 튜터 모드로 실행하되,
기존 대상인 unity-micro-scope-guard와 005에서 나온 mistake-to-guardrail-reviewer 중
어느 쪽이 custom skill 초안 대상으로 더 적절한지 먼저 비교한 뒤 진행해줘.
```

## 후속 작업

- [ ] 문서 갱신 필요
- [x] AGENTS.md 반영 검토
- [x] skill 후보 검토
- [x] hook 후보 검토
- [x] 추가 실험 필요
- [ ] 추가 리서치 필요

후속 작업 메모:

`mistake-to-guardrail-reviewer는 지금 만들지 않고 010-custom-skill-draft의 비교 후보로 넘긴다. 006-hooks-concepts와 007-llm-failure-modes를 먼저 실행한 뒤, 어떤 실수는 AGENTS.md/checklist로 충분하고 어떤 실수는 hook/test까지 필요한지 다시 판단한다. 010 실행 시에는 unity-micro-scope-guard와 mistake-to-guardrail-reviewer를 먼저 비교하고, 더 적절한 하나를 custom skill 초안 대상으로 삼는다. AGENTS.md에는 나중에 "실수 기록 요청 시 관련 절차 또는 문서를 확인한다"는 짧은 진입 규칙만 둘지 검토한다.`
