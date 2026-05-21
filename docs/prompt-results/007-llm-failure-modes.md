# Prompt Result: 007. LLM Failure Mode 분석

## 실험 번호

`007`

## 실험 주제

`LLM Failure Mode 분석`

## 실행 일시

`2026-05-21 21:53 KST`

## 실행 모드

일반/튜터 중 정확히 하나만 선택한다.

- [ ] 일반
- [x] 튜터

## 사용자 명령

```text
'/Users/kaya/Documents/Codex/codex-harness-svm-v2/docs/prompts/007-llm-failure-modes.md' 튜터 모드로 실행해줘.

1. 이건 너무 많이 대답해서.. 넘어가면 안되나? test는 뭔지 모르겠다.
2. 모르겠네? 위험하다고 느낄 정도의 그게 있나? 파일 삭제 하는 정도가 위험하지 않을까 싶긴한데

test? unit test를 말하는건가? 아니면 진짜 codex에 test 라는게 있는건가?

hooks 강제 할 수 있어서

이건 어렵네 AGENTS.md에 명확히 지시하고, skill로 매번 검증하는 용도를 취해야 되지 않을까?

hooks 쪽이 괜찮을 것 같은데 agents.md 추가하면 좋을듯? 마지막 질문인가? 그럼 정리해줘.

이 007 결과를 docs/prompt-results/007-llm-failure-modes.md에 기록
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

`docs/prompts/007-llm-failure-modes.md`

## 모델/클라이언트/실행 환경

- 모델: `GPT-5 계열 Codex, 세부 모델명 확인 불가`
- 클라이언트: `Codex coding agent`
- 실행 환경: `macOS zsh, repo root /Users/kaya/Documents/Codex/codex-harness-svm-v2, KST`

## 실행 조건

- 파일 수정 허용 여부: `실험 실행 단계 파일 수정 금지, 기록 단계에서 docs/prompt-results/007-llm-failure-modes.md 생성 허용`
- 사용한 skill/tool: `shell로 repo/템플릿 확인, apply_patch로 결과 파일 생성`
- 별도 제약: `Unity 파일 수정 금지, Safe Village Micro 구현으로 넘어가지 않기, 결과 기록 외 파일 수정 금지`

## Codex 응답 요약

Codex는 Unity 프로젝트에서 발생할 수 있는 반복 실수를 범위 과확장, 보호 파일 변경, 검증 없는 완료 주장, Scene/Prefab 손상, 패키지/버전 착각, 과한 추상화, 문서-구현 불일치, 삭제/이동 실수로 나눴다. 각 실수는 `prompt`, `AGENTS.md`, `skill`, `hook`, `test/check`가 서로 다른 층위에서 대응한다고 설명했다. 특히 `test`는 Codex 전용 기능명이 아니라 unit test, Unity compile check, smoke check, diff check 같은 검증 수단 전체라고 정리했다. 명확한 위험 행동은 hook이 강하지만, 과한 구조화나 의미상 정상인 Scene 변경 여부 같은 맥락 판단은 AGENTS.md, skill, manual review가 함께 필요하다고 설명했다.

## 튜터 모드 상호작용 요약

일반 모드 실행이면 모든 항목에 `해당 없음`을 적는다. 튜터 모드 실행이면 전체 대화 전문을 붙여넣지 말고 핵심만 요약한다.

### Codex가 한 확인 질문

- AGENTS.md, skill, hook, prompt, test의 차이를 어떻게 이해하고 있는지 물었다.
- Unity 프로젝트에서 어떤 실수가 위험하게 느껴지는지 물었다.
- `ProjectSettings/` 실수 변경은 AGENTS.md, hook, test/check 중 무엇으로 막는 것이 좋은지 물었다.
- Codex가 과하게 구조를 키우는 실수는 어떤 장치로 막는 것이 좋은지 물었다.
- Scene/Prefab이 의도치 않게 크게 바뀌는 실수는 어떤 조합으로 다루는 것이 좋은지 물었다.

### 사용자 답변 요약

- 사용자는 AGENTS.md, skill, hook, prompt 구분은 이미 여러 번 답했으므로 넘어가고 싶다고 했고, `test`의 의미가 헷갈린다고 답했다.
- 사용자는 위험한 실수로는 파일 삭제 정도가 떠오른다고 답했다.
- 사용자는 `test`가 unit test를 말하는지, Codex에 `test`라는 별도 기능이 있는지 질문했다.
- 사용자는 `ProjectSettings/` 같은 보호 경로 변경은 hook으로 강제 차단할 수 있어서 hook이 적절하다고 답했다.
- 사용자는 과한 구조화는 AGENTS.md에 명확히 지시하고 skill로 매번 검증하는 방식이 적절하다고 답했다.
- 사용자는 Scene/Prefab 변경은 hook 쪽이 괜찮고 AGENTS.md도 추가하면 좋겠다고 답했다.

### teach-back 결과 또는 아직 헷갈린 지점

- 사용자는 `ProjectSettings/` 보호처럼 기계적으로 판단 가능한 위험은 hook이 적합하다는 점을 설명할 수 있었다.
- 사용자는 과한 구조화처럼 맥락 판단이 필요한 실수는 hook보다 AGENTS.md와 skill 조합이 더 적합하다는 방향을 잡았다.
- 사용자는 Scene/Prefab 변경은 hook과 AGENTS.md를 함께 쓰는 후보로 보았고, Codex는 여기에 manual review/check가 필요하다고 보완했다.
- `test`는 Codex 전용 기능이 아니라 프로젝트 검증 수단 전체라는 점을 새로 정리했다.

### 다음 복습 질문

`Scene/Prefab 변경은 hook으로 전부 막는 것보다 "승인 없는 변경은 막고, 승인된 변경은 diff/manual review로 확인한다"가 더 낫다고 보는 이유를 한 문장으로 설명해보기.`

## 내가 이해한 점

- `test`는 Codex의 별도 기능명이 아니라 unit test, Unity compile check, PlayMode/EditMode test, smoke check, diff check 같은 검증 수단 전체를 뜻한다.
- `prompt`, `AGENTS.md`, `skill`은 주로 실수를 예방하고, `hook`은 명확한 위험 행동을 자동 차단하며, `test/check`는 결과가 실제로 맞는지 사후 발견한다.
- 파일 삭제, 보호 경로 변경, 승인 없는 Scene/Prefab 변경처럼 기계적으로 판정 가능한 위험은 hook 후보가 된다.
- 과한 구조화, 범위 과확장, 문서-구현 불일치처럼 맥락 판단이 필요한 문제는 AGENTS.md와 skill 기반 검토가 더 적합하다.
- Unity에서는 `.unity`, `.prefab`, `.asset`, `.meta`, `ProjectSettings/` 같은 파일이 텍스트 diff만으로 의미 파악이 어려워 일반 코드보다 수동 리뷰와 check가 중요하다.

## 실제로 도움 된 점

- Safe Village Micro에서 최소 guard 후보를 "보호 경로와 승인 없는 Unity 자산 변경은 hook 후보, 범위/추상화 문제는 AGENTS.md와 skill 후보"로 나누어 볼 수 있게 됐다.
- `docs/ai-mistakes.md`를 만든다면 상황, 실제 실수, 영향, 원인 추정, 재발 방지, 채택 여부 형식으로 기록하는 방향을 얻었다.
- 실제 hook 도입 여부를 확정하기 전에도 어떤 실패 모드가 hook에 적합하고 어떤 실패 모드가 skill/checklist에 적합한지 분리할 수 있게 됐다.
- "위험"을 파일 삭제뿐 아니라 되돌리기 어려운 Unity 설정/자산 변경과 조용한 문서-구현 불일치까지 포함해서 볼 수 있게 됐다.

## 헷갈린 점

- Scene/Prefab 변경을 어느 수준부터 hook으로 막고, 어느 수준부터 승인된 변경으로 볼지 기준은 아직 구체화되지 않았다.
- `docs/ai-mistakes.md`를 실제로 만들지, AGENTS.md나 skill 후보 문서에 먼저 반영할지는 아직 결정하지 않았다.
- 과한 구조화 판단을 어떤 skill/checklist 항목으로 만들면 충분히 가볍고 반복 가능할지는 후속 실험이 필요하다.

## 위험하거나 과해 보인 점

- 모든 Scene/Prefab 변경을 hook으로 막으면 실제 개발 단계에서 필요한 작업까지 막을 수 있다.
- Hook으로 맥락 판단까지 하려 하면 false positive가 많아지고, Prompts Lab의 목적보다 자동화 유지보수가 앞설 수 있다.
- Test/check만 믿으면 "동작은 하지만 구조가 과한" 문제를 놓칠 수 있다.
- Unity 파일은 컴파일 성공만으로 충분히 검증되지 않으므로, compile check를 만능 검증으로 오해하면 안 된다.

## 채택 여부

채택/보류/폐기 중 정확히 하나만 선택한다. 추가 실험 필요 여부는 후속 작업으로 분리해서 기록한다.

- [x] 채택
- [ ] 보류
- [ ] 폐기

## 채택/보류/폐기 이유

이 실험은 Codex 실패 모드를 대응 수단별로 나누는 기준을 만들었고, 특히 hook이 적합한 문제와 AGENTS.md/skill이 적합한 문제를 구분하는 데 도움이 되었다. 채택하는 것은 "실패 모드 분류와 대응 수단 매핑"이며, 실제 hook이나 AGENTS.md 규칙을 즉시 도입한다는 뜻은 아니다. 구체적인 도입 여부는 후속 프롬프트와 최종 선택 단계에서 다시 판단한다.

## 다음 실험 프롬프트

```text
docs/prompts/008-unity-workflow.md를 튜터 모드로 실행해줘.
```

## 후속 작업

- [x] 문서 갱신 필요
- [x] AGENTS.md 반영 검토
- [x] skill 후보 검토
- [x] hook 후보 검토
- [x] 추가 실험 필요
- [ ] 추가 리서치 필요

후속 작업 메모:

`docs/ai-mistakes.md` 형식 후보는 상황, 실제 실수, 영향, 원인 추정, 재발 방지, 채택 여부로 둔다. 후속 판단에서는 보호 경로와 승인 없는 Scene/Prefab 변경은 hook 후보로, 범위 과확장과 과한 추상화는 AGENTS.md 및 skill/checklist 후보로 검토한다. 실제 반영은 Prompts Lab 후속 실험과 final selection 이후로 미룬다.
