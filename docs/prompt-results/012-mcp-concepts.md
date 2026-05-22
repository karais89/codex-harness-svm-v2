# Prompt Result: 012. MCP 개념 이해

## 실험 번호

`012`

## 실험 주제

`MCP 개념 이해`

## 실행 일시

`2026-05-22 17:56 KST`

## 실행 모드

일반/튜터 중 정확히 하나만 선택한다.

- [ ] 일반
- [x] 튜터

## 사용자 명령

```text
'/Users/kaya/Documents/Codex/codex-harness-svm-v2/docs/prompts/012-mcp-concepts.md' 튜터 모드로 실행해줘.

1. 외부 도구와 llm의 연결. 외부 도구가 어떻게 동작하는지 llm이 이해할 수 있음.
2. unity mcp가 할 수 있는 역할. 물론 mcp 마다 다르겠지만. unity cli와의 차이도 궁금
3. 토큰 소모? 필요 없어서? github의 경우도 초기에는 mcp를 만들었지만 요즘에는 cli로 많이 대체하는 느낌

unity mcp는 사용할거야 이미 검증된 mcp 들이 많은데, 굳이 사용하지 않을 이유는 없을 것 같아.

다음으로 넘어가자. 커스텀 mcp를 만들고 싶은 이유는 mcp의 동작 방식을 조금 더 깊이 있게 이해하고 싶어서야.
그래서 가장 간단한 mcp를 만들어보고 싶어
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
- 기록 단계에서만 docs/prompt-results/012-mcp-concepts.md 생성을 허용함.
```

## 참조한 프롬프트 파일

`docs/prompts/012-mcp-concepts.md`

## 모델/클라이언트/실행 환경

- 모델: `GPT-5 계열 Codex, 세부 모델명 확인 불가`
- 클라이언트: `Codex coding agent`
- 실행 환경: `macOS zsh, repo root /Users/kaya/Documents/Codex/codex-harness-svm-v2, KST`

## 실행 조건

- 파일 수정 허용 여부: `실험 실행 단계 파일 수정 금지, 기록 단계에서 docs/prompt-results/012-mcp-concepts.md 생성 허용`
- 사용한 skill/tool: `shell로 repo 구조, prompts README, prompt result template, 기존 결과 확인; unity-mcp-orchestrator skill 지침 확인; web으로 MCP 공식 문서, Unity command line 문서, GitHub CLI/MCP 공식 자료 확인; apply_patch로 결과 파일 생성`
- 별도 제약: `Unity 파일 수정 금지, MCP 설정 수정 금지, Safe Village Micro 구현 task로 확장하지 않기`

## Codex 응답 요약

Codex는 MCP를 "LLM이 외부 도구 내부를 완전히 이해하는 장치"가 아니라, 외부 도구가 노출한 tool/resource/prompt의 이름, 설명, 입력 스키마, 실행 결과를 보고 사용할 수 있게 하는 연결 규격으로 설명했다. Unity 개발에서는 repo 파일만으로 가능한 작업, Unity CLI/batchmode에 맞는 작업, Unity MCP가 필요한 live Editor 상태 확인 작업을 구분했다. 사용자는 Unity MCP 자체는 사용할 계획이며, 검증된 MCP를 굳이 사용하지 않을 이유는 없다고 정정했다. 최종 결론은 "Unity MCP는 사용 전제로 두되, custom MCP tool의 실제 프로젝트 도입은 반복 필요가 확인될 때까지 보류하고, 학습 목적의 최소 MCP 실습은 012a로 진행한다"로 정리됐다.

## 튜터 모드 상호작용 요약

일반 모드 실행이면 모든 항목에 `해당 없음`을 적는다. 튜터 모드 실행이면 전체 대화 전문을 붙여넣지 말고 핵심만 요약한다.

### Codex가 한 확인 질문

- MCP가 무엇으로 느껴지는지, Codex가 Unity 프로젝트를 도울 때 가장 궁금한 상황이 무엇인지, MCP 없이 먼저 실험해야 한다는 말의 이유를 어떻게 예상하는지 물었다.
- Unity에서 Codex가 파일만 읽어도 되는 작업과 Unity MCP가 필요한 작업을 각각 한 문장씩 설명해보라고 요청했다.

### 사용자 답변 요약

- 사용자는 MCP를 외부 도구와 LLM의 연결로 이해했고, 외부 도구가 어떻게 동작하는지 LLM이 이해할 수 있게 해주는 구조라고 답했다.
- Unity MCP가 할 수 있는 역할과 Unity CLI와의 차이가 궁금하다고 답했다.
- MCP를 바로 쓰지 않는 이유로 토큰 소모, 아직 필요하지 않음, GitHub의 경우 CLI가 MCP 일부를 대체하는 흐름을 예상했다.
- 이후 Unity MCP는 사용할 것이며, 검증된 MCP가 많으므로 굳이 사용하지 않을 이유는 없다고 정정했다.
- custom MCP를 만들고 싶은 이유는 프로젝트 즉시 도입보다 MCP 동작 방식을 더 깊이 이해하기 위한 것이며, 가장 간단한 MCP를 만들어보고 싶다고 답했다.

### teach-back 결과 또는 아직 헷갈린 지점

- MCP와 CLI의 차이를 "LLM이 도구를 상황에 맞게 고르는 연결 규격"과 "정해진 명령을 실행하는 터미널 자동화"로 구분하는 방향이 잡혔다.
- Unity MCP는 Scene, GameObject, Component, Console, Play Mode 같은 live Editor 상태를 확인할 때 의미가 크다는 점을 이해했다.
- "MCP를 보류한다"는 표현은 사용자의 의도와 맞지 않았고, 실제 결론은 "Unity MCP는 사용 전제, custom MCP tool의 실전 도입은 보류, 학습용 최소 MCP 실습은 진행"으로 수정됐다.
- 아직 헷갈릴 수 있는 지점은 실제 MCP tool 호출과 mock/simulation의 경계, 그리고 Codex 세션에 MCP server를 등록하는 단계가 실습 파일 작성과 어떻게 다른지이다.

### 다음 복습 질문

`가장 작은 MCP 실습에서 "tool을 노출했다"는 사실과 "Codex가 실제 MCP tool로 호출했다"는 사실은 각각 무엇으로 검증해야 하는가?`

## 내가 이해한 점

- MCP는 외부 시스템의 기능과 데이터를 LLM이 사용할 수 있도록 tool/resource/prompt 형태로 노출하는 연결 규격이다.
- LLM은 외부 도구의 내부 구현을 직접 아는 것이 아니라, 노출된 설명, 스키마, 결과를 보고 도구 사용을 판단한다.
- Unity CLI는 정해진 명령 실행, batchmode test/build, CI 자동화에 잘 맞는다.
- Unity MCP는 현재 열린 Editor의 Scene, GameObject, Component, Console, Play Mode 상태처럼 repo 파일만으로 확정하기 어려운 정보를 다룰 때 강하다.
- SVM v1에서는 Unity MCP를 사용 전제로 두는 것이 현재 사용자 판단에 맞다.
- custom MCP tool은 프로젝트 도입 여부와 별개로, MCP 동작 방식을 이해하기 위한 작은 실습으로 먼저 다룰 수 있다.

## 실제로 도움 된 점

- "MCP를 쓰지 말자"가 아니라 "Unity MCP는 사용하되, 모든 작업을 MCP로 시작하지는 않는다"는 운영 기준이 생겼다.
- repo 파일/CLI/MCP/custom MCP tool의 역할 분리가 명확해졌다.
- custom MCP tool 후보는 곧바로 프로젝트 공식 도구로 채택하기보다, 먼저 012a에서 mock 또는 최소 tool 실습으로 MCP 구조를 이해하는 방향이 정리됐다.
- GitHub 예시를 통해 정해진 작업은 CLI가 단순하고, AI가 여러 기능을 탐색하고 조합해야 하는 흐름은 MCP가 유리하다는 구분이 생겼다.

## 헷갈린 점

- 실제 MCP server를 Codex 세션에 등록하는 절차와, 로컬에서 JSON-RPC 형태를 흉내 내는 mock 실습의 차이는 아직 실습 전이다.
- Unity MCP의 검증된 기본 tool만으로 충분한 단계와, SVM 전용 custom MCP tool이 필요한 단계의 경계는 아직 실제 개발 반복을 봐야 한다.
- MCP tool 수와 결과 크기가 토큰 사용량과 tool 선택 품질에 어느 정도 영향을 주는지는 구체적인 실험 전이다.

## 위험하거나 과해 보인 점

- Unity MCP가 연결되어 있다는 사실만으로 실제 Editor 검증이 끝났다고 착각할 수 있다.
- repo 파일만으로 충분한 문서/코드 판단까지 MCP로 우회하면 느리고 복잡해질 수 있다.
- custom MCP tool을 너무 빨리 프로젝트 공식 도구로 만들면 아직 반복성이 검증되지 않은 절차가 유지보수 대상이 될 수 있다.
- 실제 Unity Editor 연동까지 바로 시도하면 MCP 개념 학습보다 transport, 권한, Editor 상태 문제가 먼저 얽힐 수 있다.

## 채택 여부

채택/보류/폐기 중 정확히 하나만 선택한다. 추가 실험 필요 여부는 후속 작업으로 분리해서 기록한다.

- [x] 채택
- [ ] 보류
- [ ] 폐기

## 채택/보류/폐기 이유

Unity MCP는 SVM v1에서 사용 전제로 채택한다. Scene, GameObject, Component, Console, Play Mode 같은 live Editor 상태는 repo 파일이나 CLI만으로 안정적으로 확인하기 어렵고, 사용자는 이미 검증된 Unity MCP를 활용할 의지가 분명하다. 다만 custom MCP tool의 프로젝트 도입은 아직 채택하지 않고, MCP 동작 방식을 이해하기 위한 가장 작은 실습을 012a에서 먼저 진행한다.

## 다음 실험 프롬프트

```text
docs/prompts/012a-mcp-mock-tool.md를 튜터 모드로 실행해줘.

목표:
- Unity Editor 연동은 하지 않는다.
- 실제 MCP 설정은 수정하지 않는다.
- dependency 설치 없이 가능한 가장 작은 mock 또는 minimal MCP 형태로 tool 노출 구조를 이해한다.
- 검증 결과를 "실제 MCP tool 호출"과 "mock/simulation"으로 명확히 구분한다.
```

## 후속 작업

- [ ] 문서 갱신 필요
- [ ] AGENTS.md 반영 검토
- [ ] skill 후보 검토
- [ ] hook 후보 검토
- [x] 추가 실험 필요
- [ ] 추가 리서치 필요

후속 작업 메모:

`012a-mcp-mock-tool.md를 실행해 가장 작은 MCP mock tool 또는 dependency-free minimal MCP 형태를 만든다. 실습 파일은 tmp/prompts-lab/012a-mcp-mock-tool/ 아래에만 만들고, .codex 설정, global config, Unity 파일, 실제 Unity Editor 연동은 하지 않는다. 이후 실제 MCP server 등록이 필요해질 때 별도 실험으로 분리한다.`
