# Prompt Result: 015. Subagents 이해

## 실험 번호

`015`

## 실험 주제

`Subagents 이해`

## 실행 일시

`2026-05-22 19:53 KST`

## 실행 모드

일반/튜터 중 정확히 하나만 선택한다.

- [ ] 일반
- [x] 튜터

## 사용자 명령

```text
015-subagents.md 튜터 모드로 실행해줘.

1. 서브에이전트 그냥 다른 공간에서 에이전트 생성해서 호출한다 정도로 알고 있음 완전히 새로운 컨텍스트에서
2. 리뷰 할때? 다방면 기획할때?
3. 아니 위험할 일은 없을 것 같은데

동시에 작업물을 건드릴 수 있기 때문에? 근데 그건 당연한 얘기라 대답안한거긴해

파일의 동시성 문제

기록해줘 그리고 커밋 해줘
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
- 사용자가 "위험할 일은 없을 것 같다"고 답한 지점을 중심으로 Unity 구현에서의 기준 상태 분기 위험을 다시 설명함.
- 기록 단계에서만 docs/prompt-results/015-subagents.md 생성을 허용함.
```

## 참조한 프롬프트 파일

`docs/prompts/015-subagents.md`

## 모델/클라이언트/실행 환경

- 모델: `GPT-5 계열 Codex, 세부 모델명 확인 불가`
- 클라이언트: `Codex coding agent`
- 실행 환경: `macOS zsh, repo root /Users/kaya/Documents/Codex/codex-harness-svm-v2, KST`

## 실행 조건

- 파일 수정 허용 여부: `실험 실행 단계 파일 수정 금지, 기록 단계에서 docs/prompt-results/015-subagents.md 생성 허용`
- 사용한 skill/tool: `openai-docs skill과 OpenAI developer docs MCP로 Codex subagents 공식 문서 확인; shell로 prompts README, 015 프롬프트, 기존 prompt results, git 상태 확인; apply_patch로 결과 파일 생성`
- 별도 제약: `Unity 파일 수정 금지, 실제 subagent spawn 실험 없음, Safe Village Micro 구현 task로 확장하지 않기`

## Codex 응답 요약

Codex는 subagent를 부모 세션이 일을 쪼개 별도 agent thread에 맡기고 결과를 다시 회수하는 구조로 설명했다. 사용자의 "다른 공간에서 에이전트를 생성해서 호출한다"는 이해는 대체로 맞지만, 부모 세션이 필요한 맥락과 지시를 넘기므로 "완전히 무관한 새 컨텍스트"라기보다는 별도 thread에 필요한 맥락을 위임하는 구조라고 보정했다. 리뷰, 리서치, 다방면 기획처럼 결과를 참고 의견으로 모을 수 있는 작업에는 유용하지만, Unity 구현 분담에는 파일 충돌뿐 아니라 각 agent가 서로 다른 기준 상태를 전제로 판단하거나 구현하는 위험이 있다고 설명했다. 현재 단계에서는 subagent를 구현 분담 도구가 아니라 read-only 리뷰, 리서치, 기획 비교 도구 후보로 보는 것이 적절하다고 정리했다.

## 튜터 모드 상호작용 요약

일반 모드 실행이면 모든 항목에 `해당 없음`을 적는다. 튜터 모드 실행이면 전체 대화 전문을 붙여넣지 말고 핵심만 요약한다.

### Codex가 한 확인 질문

- subagent를 "Codex가 여러 작업자를 병렬로 띄우는 것" 정도로 이해하는지, agent/thread 개념부터 애매한지 물었다.
- Safe Village Micro에서 subagent를 써보고 싶은 상황이 문서/리서치 비교, 코드 리뷰, Unity 구현 분담, 아직 모름 중 어디에 가까운지 물었다.
- Unity 구현 작업에서 subagent를 여러 개 쓰면 왜 위험할 수 있을지 추측해보라고 물었다.
- 이후 "동시 파일 수정"보다 더 정확한 위험을 자기 말로 설명하게 하는 teach-back 질문을 던졌다.

### 사용자 답변 요약

- 사용자는 subagent를 "다른 공간에서 에이전트를 생성해서 호출하는 것"이며, 완전히 새로운 컨텍스트에서 실행되는 것으로 이해하고 있었다.
- 사용처로는 리뷰할 때와 다방면 기획할 때를 떠올렸다.
- 처음에는 Unity 구현에서 위험할 일은 없을 것 같다고 답했다.
- 이후 "동시에 작업물을 건드릴 수 있기 때문에" 또는 "파일의 동시성 문제"라고 답했다.

### teach-back 결과 또는 아직 헷갈린 지점

- 사용자는 subagent가 별도 공간의 작업자라는 큰 개념과 리뷰/다방면 기획에 잘 맞는다는 점은 이해했다.
- Unity 구현 위험을 처음에는 단순 파일 동시성 문제로 이해했다.
- Codex는 더 정확한 위험을 "각 subagent가 서로 다른 기준 상태를 전제로 판단하거나 구현할 수 있기 때문"이라고 다시 설명했다.
- Scene, Prefab, serialized field, meta, package 상태가 함께 맞아야 하는 Unity 프로젝트에서는 파일이 병합되어도 의미 충돌이나 Editor 연결 깨짐이 생길 수 있다는 점을 추가로 설명했다.

### 다음 복습 질문

`파일 충돌은 없었는데도 subagent 결과가 Unity에서 깨질 수 있는 이유는 무엇인가?`

## 내가 이해한 점

- subagent는 부모 Codex 세션이 일을 나누어 별도 agent thread에 맡기고 결과를 회수하는 구조다.
- Codex subagents는 사용자가 명시적으로 요청할 때 쓰는 병렬 작업 방식이며, 자동으로 무분별하게 spawn되는 구조가 아니다.
- 리뷰, 리서치, 기획 비교처럼 서로 독립적인 관점의 결과를 모으는 작업에는 subagent가 유용하다.
- Unity 구현에서는 파일 충돌보다 "각 agent가 서로 다른 기준 상태를 본다"는 의미 충돌이 더 큰 위험이다.
- subagent 결과의 최종 통합과 검증 책임은 부모 세션에 남는다.

## 실제로 도움 된 점

- Safe Village Micro에서 subagent는 구현 분담 도구가 아니라 read-only 리뷰, 리서치, 기획 비교 도구로 먼저 보는 기준이 생겼다.
- 코드 리뷰에서는 Unity 구조, 문서 일관성, 구현 리스크 같은 관점을 나누어 볼 수 있다.
- 기획 검토에서는 게임 루프, UI/UX, 구현 난이도, 테스트 가능성처럼 서로 다른 관점을 병렬로 검토할 수 있다.
- Unity 구현에 사용하더라도 부모 세션이 하나의 기준 상태로 통합하고 `git diff`, Unity compile, console error, 필요 시 Play Mode까지 확인해야 한다는 검증 책임을 분리했다.

## 헷갈린 점

- subagent의 위험을 처음에는 "파일 동시성 문제" 정도로만 이해했다.
- 파일 충돌이 없더라도 Unity Editor의 Scene/Prefab/reference 상태가 깨질 수 있다는 의미 충돌 개념은 추가 복습이 필요하다.
- 실제로 read-only subagent 리뷰를 언제 비용 대비 유의미하다고 판단할지는 아직 작은 실험이 필요하다.

## 위험하거나 과해 보인 점

- 여러 subagent가 동시에 `Assets/`, Scene, Prefab, `Packages/manifest.json`, `ProjectSettings/`를 수정하면 Unity 상태가 갈라질 수 있다.
- 각 subagent가 자기 작업만 맞다고 판단하면 전체 compile, Scene 연결, Play Mode 검증이 빠질 수 있다.
- 지금 단계에서 subagent 구현 분담을 채택하면 prompts lab의 학습 목적보다 병렬 구현 실험이 앞서갈 수 있다.
- docs/threads 같은 새 기록 구조를 subagent 때문에 바로 만들면, 이미 정리한 `docs/prompts`와 `docs/prompt-results` 실험 경계가 흐려질 수 있다.

## 채택 여부

채택/보류/폐기 중 정확히 하나만 선택한다. 추가 실험 필요 여부는 후속 작업으로 분리해서 기록한다.

- [ ] 채택
- [x] 보류
- [ ] 폐기

## 채택/보류/폐기 이유

subagent 개념은 유용하지만, 현재 Safe Village Micro 단계에서 실제 구현 분담 방식으로 채택하는 것은 보류한다. 특히 Unity Scene, Prefab, ProjectSettings, package 상태는 여러 agent가 동시에 수정하기에 검증 부담이 크다. 다만 read-only 리뷰, 리서치, 다방면 기획 비교 용도는 작은 실험 후보로 남긴다.

## 다음 실험 프롬프트

```text
docs/prompts/017-final-selection.md를 일반 모드로 실행해줘.

목표:
- 지금까지의 prompts lab 결과를 바탕으로 AGENTS.md, PLANS.md, skills, hooks, MCP, plugin, subagents 중 무엇을 실제 Safe Village Micro에 채택할지 고른다.
- subagents는 구현 분담이 아니라 read-only 리뷰/리서치 후보로만 평가한다.
- Prompts Lab 결과와 실제 Unity 구현 계획을 섞지 않는다.
```

또는

```text
Safe Village Micro 현재 문서와 prompt-results를 대상으로 read-only subagent 리뷰 실험 프롬프트를 설계해줘.

조건:
- 실제 subagent를 아직 spawn하지 않는다.
- 파일을 수정하지 않는다.
- 문서 일관성, 구현 위험, 과한 자동화 여부를 각각 독립 관점으로 나누는 프롬프트만 만든다.
```

## 후속 작업

- [ ] 문서 갱신 필요
- [ ] AGENTS.md 반영 검토
- [ ] skill 후보 검토
- [ ] hook 후보 검토
- [x] 추가 실험 필요
- [ ] 추가 리서치 필요

후속 작업 메모:

`017-final-selection.md에서 subagents를 "구현 분담은 보류, read-only 리뷰/리서치 후보"로 평가할지 검토한다.`
