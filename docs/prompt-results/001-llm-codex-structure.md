# Prompt Result: 001. LLM/Codex 구조 이해

## 실험 번호

`001`

## 실험 주제

`LLM/Codex 구조 이해`

## 실행 일시

`2026-05-21 12:46 KST`

## 실행 모드

일반/튜터 중 정확히 하나만 선택한다.

- [ ] 일반
- [x] 튜터

## 사용자 명령

```text
001-llm-codex-structure.md 이 파일을 docs/prompts/README.md의 튜터 모드로 실행해줘.

기록해줘
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

`docs/prompts/001-llm-codex-structure.md`

## 모델/클라이언트/실행 환경

- 모델: `GPT-5 계열 Codex, 세부 모델명 확인 불가`
- 클라이언트: `Codex coding agent, 세부 클라이언트명 확인 불가`
- 실행 환경: `macOS zsh, repo root /Users/kaya/Documents/Codex/codex-harness-svm-v2, KST`

## 실행 조건

- 파일 수정 허용 여부: `실험 실행 단계 파일 수정 금지, 기록 단계에서 docs/prompt-results/ 아래 결과 파일 생성 허용`
- 사용한 skill/tool: `전용 skill 없음. repo 확인과 기록을 위해 shell, apply_patch 사용`
- 별도 제약: `Unity 파일 수정 금지, Safe Village Micro 구현 계획으로 넘어가지 않기, 확인된 사실과 추측 분리`

## Codex 응답 요약

Codex는 일반 ChatGPT와 Codex의 차이를 "대화 중심 LLM 인터페이스"와 "repo와 도구를 사용하는 코딩 에이전트"로 구분해 설명했다. Codex는 repo 전체를 항상 아는 것이 아니라 필요한 파일을 찾아 읽고, 현재 context와 도구 실행 결과를 바탕으로 판단한다고 설명했다. AGENTS.md는 프로젝트에 반복 적용되는 상시 작업 규칙이고, prompt는 현재 대화의 이번 작업 지시라고 정리했다. skill은 반복 workflow를 재사용하기 위한 지침/리소스 묶음, hook은 특정 시점에 검증이나 자동 실행을 강제하는 장치로 구분했다. MCP는 외부 도구 연결, plugin은 skill/MCP/설정을 묶어 재사용 또는 배포할 때 필요하다고 설명했다.

## 튜터 모드 상호작용 요약

일반 모드 실행이면 모든 항목에 `해당 없음`을 적는다. 튜터 모드 실행이면 전체 대화 전문을 붙여넣지 말고 핵심만 요약한다.

### Codex가 한 확인 질문

- 일반 ChatGPT와 Codex의 차이를 현재 어떻게 이해하는지 물었다.
- Codex가 repo 전체를 항상 아는지, 필요한 파일을 찾아 읽는 방식에 가까운지 확인했다.
- AGENTS.md, skill, hook, MCP, plugin 중 가장 헷갈리는 개념을 물었다.
- 각 개념 설명 뒤 AGENTS.md와 prompt, skill과 hook, MCP와 plugin, Unity에서 Codex가 잘하는 일과 약한 일을 사용자 말로 다시 설명하게 했다.

### 사용자 답변 요약

- 사용자는 일반 ChatGPT와 Codex가 같은 계열의 모델을 쓰지만, Codex는 로컬 컴퓨터와 repo에 대한 접근 권한이 있다는 의미로 이해하고 있었다.
- Codex는 필요한 파일을 찾아 읽는 방식에 가깝다고 답했다.
- 기본 개념은 알고 있고, MCP와 plugin은 만드는 방법을 잘 모른다고 답했다.
- AGENTS.md는 프로젝트 내에 항상 적용되는 지침 파일이고, prompt는 현재 대화에서 내리는 지침이라고 정리했다.
- skill은 반복할 때 쓰고, hook은 강제할 때 쓴다고 정리했다.
- MCP는 외부 도구 통합이 필요할 때 쓰고, plugin은 여러 구성요소를 종합적으로 관리하고 싶을 때 쓴다고 답했다.
- Unity에서 Codex가 잘하는 일은 데이터이고, 약한 일은 비주얼이라고 답했다.

### teach-back 결과 또는 아직 헷갈린 지점

- 사용자는 "로컬에서 동작하는 LLM"이라는 표현이 부정확하다는 점을 이해했고, Codex를 "원격 LLM이 로컬 작업 환경에 연결된 에이전트"로 보는 쪽으로 수정했다.
- AGENTS.md와 prompt의 차이, skill과 hook의 차이, MCP와 plugin의 큰 경계는 자기 말로 설명할 수 있었다.
- plugin은 "관리"보다 "skill/MCP/설정을 묶어서 재사용 또는 배포"하는 개념으로 더 좁게 이해할 필요가 있었다.
- MCP와 plugin의 제작 방법은 아직 실습이 필요하다고 확인했다.
- 초반 도입 순서는 prompt와 AGENTS.md를 기본값으로 두고, skill은 반복 workflow가 확인될 때, hook과 MCP는 실제 필요가 생길 때 실험하며, plugin은 미뤄도 된다고 정리했다.

### 다음 복습 질문

`지금 Unity 프로젝트 초반 workflow에서 prompt, AGENTS.md, skill, hook, MCP, plugin을 각각 어느 시점에 도입해야 하는지 한 문장씩 설명해보기.`

## 내가 이해한 점

- Codex는 repo 전체를 자동으로 항상 알고 있는 존재가 아니라, 필요한 파일을 찾아 읽고 context에 들어온 근거로 판단한다.
- AGENTS.md는 반복되는 repo 규칙이고, prompt는 현재 작업 지시다.
- skill은 반복 workflow를 LLM이 재현하게 만드는 데 적합하고, hook은 특정 검증이나 자동 실행을 강제할 때 적합하다.
- MCP는 Unity Editor 같은 외부 도구 상태와 연결이 필요할 때 의미가 있다.
- plugin은 여러 구성요소를 묶어 재사용하거나 배포할 단계가 되었을 때 고려하면 된다.

## 실제로 도움 된 점

- 프로젝트 초반에는 prompt와 AGENTS.md를 우선 사용하고, skill/hook/MCP/plugin은 필요가 확인될 때 단계적으로 실험하는 기준이 생겼다.
- Unity에서 Codex가 강한 영역은 코드, 로그, 설정, 문서처럼 텍스트/데이터로 확인 가능한 일이고, 약한 영역은 화면 구성, 조작감, 연출, Inspector 상태처럼 실제 Editor나 플레이 화면으로 봐야 하는 일이라고 구분했다.
- MCP와 plugin은 개념 설명만으로 끝내지 말고 나중에 작은 mock 실습으로 분리하는 것이 좋다는 방향을 확인했다.

## 헷갈린 점

- MCP와 plugin을 실제로 어떻게 만드는지는 아직 실습 전이라 구체성이 부족하다.
- hook과 MCP는 필요성이 생겼을 때 실험해야 하지만, 어떤 실패나 반복이 "도입 신호"인지 더 구체적인 기준이 필요하다.

## 위험하거나 과해 보인 점

- 초반부터 hook, MCP, plugin을 모두 채택하면 학습 실험과 실제 프로젝트 운영 기준이 섞일 위험이 있다.
- Unity Editor 연동 MCP를 너무 일찍 실습하면 Unity 설정, transport, Editor 상태 문제가 함께 얽혀 MCP 개념 자체를 이해하기 어려울 수 있다.
- plugin은 현재 프로젝트에 즉시 필요하지 않은데도 도입하면 유지보수 부담이 커질 수 있다.

## 채택 여부

채택/보류/폐기 중 정확히 하나만 선택한다. 추가 실험 필요 여부는 후속 작업으로 분리해서 기록한다.

- [x] 채택
- [ ] 보류
- [ ] 폐기

## 채택/보류/폐기 이유

이 실험은 Codex/LLM의 기본 구조와 도구별 역할 구분을 초반 의사결정 기준으로 정리하는 데 도움이 되었다. 특히 prompt와 AGENTS.md를 기본값으로 두고, skill/hook/MCP/plugin은 필요성이 확인될 때 단계적으로 실험한다는 기준을 얻었다. 실제 구현이나 Unity 파일 수정으로 넘어가지 않았고, prompts lab의 학습 목적에도 맞았다.

## 다음 실험 프롬프트

```text
docs/prompts/002-agents-md.md를 튜터 모드로 실행해줘.

또는

docs/prompts/003-docs-responsibility.md를 튜터 모드로 실행해줘.
```

## 후속 작업

- [ ] 문서 갱신 필요
- [ ] AGENTS.md 반영 검토
- [ ] skill 후보 검토
- [ ] hook 후보 검토
- [x] 추가 실험 필요
- [ ] 추가 리서치 필요

후속 작업 메모:

`012-mcp-concepts 이후 작은 mock MCP 만들기 실습, 013-plugin-concepts 이후 작은 plugin 만들기 실습을 별도 prompts lab 항목으로 추가할지 검토한다.`
