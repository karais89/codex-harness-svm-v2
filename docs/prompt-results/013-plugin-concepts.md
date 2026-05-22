# Prompt Result: 013. Plugin 개념 이해

## 실험 번호

`013`

## 실험 주제

`Plugin 개념 이해`

## 실행 일시

`2026-05-22 19:05 KST`

## 실행 모드

일반/튜터 중 정확히 하나만 선택한다.

- [ ] 일반
- [x] 튜터

## 사용자 명령

```text
'/Users/kaya/Documents/Codex/codex-harness-svm-v2/docs/prompts/013-plugin-concepts.md' 튜텨 모드로 실행하자

1. skill, hooks 등 하나의 패키지 형태로 모아 둔 것
2. 이게 왜 필요할까?
3. 아직은 만들려는 생각은 안했지만, 아마 만든다면, 내가 앞으로 개발할 mvp 게임에 유용한 기능들을 모아두는 하나의 집합체로 만들지 않을까?

모르겠음 다음으로 넘어가보자

이번 문서 정리해줘
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
- 사용자가 "모르겠음 다음으로 넘어가보자"라고 답한 뒤에는 반복 질문을 줄이고 설명과 요약으로 마무리함.
- 기록 단계에서만 docs/prompt-results/013-plugin-concepts.md 생성을 허용함.
```

## 참조한 프롬프트 파일

`docs/prompts/013-plugin-concepts.md`

## 모델/클라이언트/실행 환경

- 모델: `GPT-5 계열 Codex, 세부 모델명 확인 불가`
- 클라이언트: `Codex coding agent`
- 실행 환경: `macOS zsh, repo root /Users/kaya/Documents/Codex/codex-harness-svm-v2, KST`

## 실행 조건

- 파일 수정 허용 여부: `실험 실행 단계 파일 수정 금지, 기록 단계에서 docs/prompt-results/013-plugin-concepts.md 생성 허용`
- 사용한 skill/tool: `shell로 prompts README, 013 프롬프트, 기존 prompt results, 결과 템플릿 확인; plugin-creator skill 문서 일부 확인; apply_patch로 결과 파일 생성`
- 별도 제약: `Unity 파일 수정 금지, 실제 plugin 생성 금지, marketplace/global config/.codex 설정 수정 금지, Safe Village Micro 구현 task로 확장하지 않기`

## Codex 응답 요약

Codex는 plugin을 skill, hook, MCP, scripts, assets, 설정 등을 설치/공유/재사용 가능한 경계로 묶는 상위 패키지로 설명했다. skill은 하나의 작업법, hook은 특정 lifecycle 시점의 자동 검사, MCP는 외부 도구 연결이고, plugin은 이 구성요소들을 함께 배포하거나 켤 수 있게 묶는 단위라고 구분했다. 현재 Safe Village Micro 단계에서는 어떤 skill, hook, MCP, script가 실제로 반복 가치가 있는지 아직 검증되지 않았기 때문에 plugin 제작은 이르다고 판단했다. 나중에 여러 MVP 게임 프로젝트에서 반복되는 Unity workflow가 안정되면 `unity-mvp-workflow`나 `mvp-game-dev-kit` 같은 plugin 후보를 검토할 수 있다고 정리했다.

## 튜터 모드 상호작용 요약

일반 모드 실행이면 모든 항목에 `해당 없음`을 적는다. 튜터 모드 실행이면 전체 대화 전문을 붙여넣지 말고 핵심만 요약한다.

### Codex가 한 확인 질문

- plugin을 현재 어떻게 이해하고 있는지 물었다.
- plugin에서 가장 헷갈리는 지점이 `skill과 차이`, `MCP와 차이`, `왜 지금 만들면 이른지` 중 어디인지 물었다.
- Safe Village Micro 이후 MVP 게임 개발 workflow에서 plugin을 만든다면 무엇을 묶고 싶은지 물었다.
- plugin보다 먼저 검증해야 할 것이 무엇인지 teach-back 질문으로 확인했다.

### 사용자 답변 요약

- 사용자는 plugin을 skill, hooks 등을 하나의 패키지 형태로 모아둔 것으로 이해하고 있었다.
- 가장 헷갈리는 지점은 "이게 왜 필요할까?"였다.
- 아직 plugin을 만들 생각은 없지만, 나중에 만든다면 앞으로 개발할 MVP 게임에 유용한 기능들을 모아둔 집합체가 될 것 같다고 답했다.
- teach-back 질문에는 잘 모르겠다고 답했고, 다음으로 넘어가자고 요청했다.

### teach-back 결과 또는 아직 헷갈린 지점

- plugin이 "기능 모음"이라는 큰 방향은 이해했지만, "설치/공유/재사용 가능한 경계"라는 필요성은 아직 완전히 체감되지 않았다.
- 사용자는 현재 plugin 제작 의사가 없으므로, 지금은 깊은 구현 절차보다 "왜 아직 이른가"와 "무엇이 먼저 검증되어야 하는가"를 정리하는 것이 더 적합했다.
- Codex는 plugin 전에 skill, hook, MCP, script, prompt template 각각이 실제 MVP 개발에서 반복적으로 도움이 되는지 먼저 확인해야 한다고 설명했다.

### 다음 복습 질문

`지금 단계에서 plugin을 만들면 왜 "검증된 도구 묶음"이 아니라 "희망사항 모음"이 될 위험이 있는가?`

## 내가 이해한 점

- plugin은 skill, hook, MCP, scripts, assets, 설정 등을 함께 담을 수 있는 상위 패키지다.
- plugin의 핵심 가치는 단순 보관이 아니라 설치, 공유, 재사용 가능한 경계를 만드는 데 있다.
- skill은 작업법, hook은 자동 검사, MCP는 외부 도구 연결, plugin은 이들을 묶을 수 있는 배포 단위로 구분할 수 있다.
- Safe Village Micro 현재 단계에서는 어떤 구성요소가 실제 반복 workflow인지 아직 확인 중이다.
- plugin은 반복 workflow가 안정된 뒤에 고려해야 하며, 지금은 구성요소별 실험과 채택 판단이 먼저다.

## 실제로 도움 된 점

- "plugin이 왜 필요한가"를 여러 기능을 한 번에 설치하고 재사용하기 위한 단계로 좁혀 이해했다.
- 나중에 만들 plugin 후보는 "MVP 게임 개발에 유용한 기능 집합"이라는 방향으로 잡을 수 있다.
- 현재는 plugin 제작보다 skill, hook, MCP, prompt template, validation script가 각각 실제로 쓸모 있는지 검증하는 것이 우선이라는 기준이 생겼다.
- plugin을 성급하게 만들면 검증된 workflow가 아니라 아직 바뀔 수 있는 희망사항을 패키지화할 위험이 있음을 확인했다.

## 헷갈린 점

- plugin의 필요성은 아직 직접적인 체감이 크지 않다.
- 어떤 시점이 "여러 프로젝트에서 반복된다"고 판단할 만큼 충분한지 기준은 아직 실제 MVP 개발 반복을 봐야 한다.
- plugin bundle 안에 어느 수준까지 포함해야 하는지, 예를 들어 skill만 묶을지 MCP, hooks, scripts까지 묶을지는 아직 후보 단계다.

## 위험하거나 과해 보인 점

- 지금 plugin을 만들면 아직 검증되지 않은 skill, hook, MCP, script를 유지보수 대상으로 고정할 수 있다.
- Safe Village Micro 구현 전 단계에서 plugin 제작으로 넘어가면 prompts lab의 학습 목적과 실제 Unity MVP 구현 준비가 섞일 수 있다.
- custom MCP나 hook이 실제로 반복 가치가 있는지 확인하기 전에 plugin으로 묶으면 복잡도만 늘어날 수 있다.
- "내가 앞으로 쓸 것 같은 기능"을 너무 일찍 묶으면, 실제 MVP 개발에서 필요한 기능과 어긋날 수 있다.

## 채택 여부

채택/보류/폐기 중 정확히 하나만 선택한다. 추가 실험 필요 여부는 후속 작업으로 분리해서 기록한다.

- [ ] 채택
- [x] 보류
- [ ] 폐기

## 채택/보류/폐기 이유

plugin 개념 자체는 유효하지만, 현재 Safe Village Micro 단계에서 실제 plugin 제작은 보류한다. 아직 plugin에 넣을 skill, hook, MCP, script, prompt template이 반복 workflow로 검증되지 않았고, 사용자는 지금 plugin을 만들 생각도 없다고 답했다. 따라서 지금은 plugin 제작보다 개별 구성요소의 유용성과 반복성을 먼저 확인하는 편이 맞다.

## 다음 실험 프롬프트

```text
docs/prompts/013a-plugin-bundle-practice.md를 튜터 모드로 실행해줘.

목표:
- 실제 global plugin이나 marketplace 설정은 수정하지 않는다.
- plugin이 어떤 파일과 경계로 구성될 수 있는지 작은 bundle 구조만 이해한다.
- 지금 만들 수 있는 것과 실제 채택해야 하는 것을 구분한다.
```

또는

```text
docs/prompts/014-execplan-plans.md를 튜터 모드로 실행해줘.

목표:
- plugin 실습을 건너뛰고 실제 구현 전 계획 문서 기준을 먼저 정리한다.
- prompts lab 결과와 Safe Village Micro 구현 계획을 섞지 않는다.
```

## 후속 작업

- [ ] 문서 갱신 필요
- [ ] AGENTS.md 반영 검토
- [ ] skill 후보 검토
- [ ] hook 후보 검토
- [x] 추가 실험 필요
- [ ] 추가 리서치 필요

후속 작업 메모:

`plugin 제작은 현재 보류한다. 다음 단계는 013a-plugin-bundle-practice로 작은 bundle 구조를 실습하거나, plugin 실습을 건너뛰고 014-execplan-plans로 실제 구현 전 계획 문서 기준을 정리하는 것이다. 013a를 실행하더라도 실제 global plugin, marketplace, .codex 설정은 수정하지 않고 tmp/prompts-lab/013a-plugin-bundle-practice/ 아래 실습으로 제한한다.`
