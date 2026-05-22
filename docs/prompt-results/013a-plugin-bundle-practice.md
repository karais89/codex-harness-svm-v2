# Prompt Result: 013a. Plugin Bundle 실습

## 실험 번호

`013a`

## 실험 주제

`Plugin Bundle 실습`

## 실행 일시

`2026-05-22 19:12 KST`

## 실행 모드

일반/튜터 중 정확히 하나만 선택한다.

- [ ] 일반
- [x] 튜터

## 사용자 명령

```text
'/Users/kaya/Documents/Codex/codex-harness-svm-v2/docs/prompts/013a-plugin-bundle-practice.md' 튜터 모드로 실행

1번 추천안 파일 만들어도 되

혹시 내가 플러그인 개념에 대해 확인할 수 있는 공식 문서 있나? openai 쪽이면 좋겠는데 만드는 방법이나 기본 개념? 아니면 니가 읽고 더 쉽게 설명해주면 더 좋을 것 같고

이번 실험 결과를 docs/prompt-results/013a-plugin-bundle-practice.md에 기록
```

## 적용한 실행 모드 wrapper

```text
docs/prompts/README.md의 튜터 모드 wrapper와 013a 실습 예외 규칙을 적용했다.

- Safe Village Micro 구현으로 넘어가지 않음.
- 기본적으로 파일 생성/수정을 하지 않되, 013a 실습 프롬프트가 허용한 tmp/prompts-lab/013a-plugin-bundle-practice/ 아래 실습 파일 생성만 허용함.
- 현재 repo 구조, 013 결과, 012a MCP 실습 결과를 확인함.
- Unity gameplay code, Scene, Packages/manifest.json, ProjectSettings/를 수정하지 않음.
- .codex, global config, plugin registry, marketplace 파일을 수정하지 않음.
- 실제 plugin 설치 또는 등록을 하지 않음.
- 검증하지 않은 초안을 "설치 가능한 plugin"이라고 부르지 않고 "학습용 초안"으로 표시함.
- 기록 단계에서만 docs/prompt-results/013a-plugin-bundle-practice.md 생성을 허용함.
```

## 참조한 프롬프트 파일

`docs/prompts/013a-plugin-bundle-practice.md`

## 모델/클라이언트/실행 환경

- 모델: `GPT-5 계열 Codex, 세부 모델명 확인 불가`
- 클라이언트: `Codex coding agent`
- 실행 환경: `macOS zsh, repo root /Users/kaya/Documents/Codex/codex-harness-svm-v2, KST`

## 실행 조건

- 파일 수정 허용 여부: `tmp/prompts-lab/013a-plugin-bundle-practice/ 아래 실습 파일 생성 허용, 기록 단계에서 docs/prompt-results/013a-plugin-bundle-practice.md 생성 허용`
- 사용한 skill/tool: `shell로 prompts README, 013/012a 결과, 실습 파일 구조 확인; apply_patch로 학습용 bundle과 결과 파일 생성; python3 -m json.tool로 JSON 문법 검증; OpenAI Developer Docs MCP로 Codex Plugins/Build plugins/Skills/MCP 공식 문서 확인`
- 별도 제약: `Unity 파일 수정 금지, .codex/global config/plugin registry/marketplace 수정 금지, dependency 설치 금지, 실제 plugin 설치 또는 등록 금지`

## Codex 응답 요약

Codex는 013 결과를 바탕으로 `unity-mvp-workflow-draft`라는 학습용 plugin bundle 범위를 제안했다. 사용자가 추천안을 수락하고 파일 생성을 허용한 뒤, `tmp/prompts-lab/013a-plugin-bundle-practice/unity-mvp-workflow-draft/` 아래 README, 학습용 manifest 초안, MVP scope review skill 초안, Unity Console MCP placeholder를 만들었다. `plugin-manifest.draft.json`은 JSON 문법 검증을 통과했지만, 실제 Codex plugin manifest schema로 검증한 것이 아니므로 installable plugin이 아니라 learning draft로 표시했다. 이후 OpenAI 공식 문서 확인을 통해 plugin은 skills, app integrations, MCP servers를 재사용 workflow로 묶는 installable distribution unit이며, 실제 plugin은 `.codex-plugin/plugin.json`, `skills/`, optional `.mcp.json`, hooks, marketplace 연결 등이 필요하다고 정리했다.

## 튜터 모드 상호작용 요약

일반 모드 실행이면 모든 항목에 `해당 없음`을 적는다. 튜터 모드 실행이면 전체 대화 전문을 붙여넣지 말고 핵심만 요약한다.

### Codex가 한 확인 질문

- 이번 실습 bundle을 어떤 느낌으로 만들지 물었고, 추천안으로 `unity-mvp-workflow-draft`를 제안했다.
- 파일을 실제로 만들어도 되는지 확인했고, 생성 위치를 `tmp/prompts-lab/013a-plugin-bundle-practice/` 아래로 제한하겠다고 밝혔다.
- 실습 후에는 `SKILL.md`와 MCP placeholder가 plugin manifest 안에서 왜 따로 분리되어야 하는지 복습 질문으로 제시했다.

### 사용자 답변 요약

- 사용자는 추천안인 `unity-mvp-workflow-draft`를 선택했다.
- 허용된 실습 경로 아래 파일 생성을 승인했다.
- 이후 plugin 개념과 만드는 방법을 확인할 수 있는 OpenAI 공식 문서가 있는지 물었고, Codex가 읽고 쉽게 설명해주기를 원했다.
- 마지막으로 이번 실험 결과를 `docs/prompt-results/013a-plugin-bundle-practice.md`에 기록해달라고 요청했다.

### teach-back 결과 또는 아직 헷갈린 지점

- 별도의 사용자 teach-back 답변은 받지 않았다.
- 실습을 통해 plugin이 단일 기능이 아니라 skill, MCP placeholder, docs, manifest 같은 구성요소를 하나의 재사용 가능한 경계로 묶는 단위라는 점을 확인했다.
- 아직 헷갈릴 수 있는 지점은 "학습용 bundle 구조"와 "실제로 Codex에 설치 가능한 plugin 구조"의 차이다.
- OpenAI 공식 문서 확인 후, 실제 plugin에는 `.codex-plugin/plugin.json`과 marketplace 연결이 필요하다는 점이 학습용 초안과의 핵심 차이로 정리됐다.

### 다음 복습 질문

`이번 bundle에서 skill, MCP placeholder, manifest는 각각 어떤 책임을 맡고, 실제 plugin이 되려면 무엇이 더 필요할까?`

## 내가 이해한 점

- plugin은 reusable workflow를 설치 가능한 단위로 묶는 구조다.
- skill은 workflow authoring format이고, plugin은 installable distribution unit이다.
- MCP는 외부 도구 연결이고, plugin은 MCP server config를 포함할 수 있다.
- 실제 Codex plugin은 최소한 `.codex-plugin/plugin.json` manifest와 plugin root 구조가 필요하다.
- marketplace는 Codex가 plugin을 읽고 설치할 수 있게 하는 catalog 역할을 한다.
- 이번 실습 산출물은 공식 schema로 검증된 plugin이 아니라 plugin 개념을 이해하기 위한 learning draft다.

## 실제로 도움 된 점

- 추상적인 plugin 개념을 `unity-mvp-workflow-draft`라는 작은 폴더 구조로 확인했다.
- future Unity MVP workflow plugin에 어떤 것이 들어갈 수 있는지 구체화했다: scope review skill, Unity Console MCP placeholder, README, manifest.
- 012a에서 만든 Unity Console MCP 실습이 나중에 plugin에 들어갈 수 있는 MCP component 후보라는 연결이 생겼다.
- 공식 OpenAI 문서 기준으로 skill과 plugin의 차이를 "작성 형식"과 "설치/배포 단위"로 정리했다.
- 실제 plugin 제작 전에는 skill 반복성, MCP 등록 검증, plugin manifest schema, marketplace 연결을 별도로 확인해야 한다는 기준이 생겼다.

## 헷갈린 점

- 이번 `plugin-manifest.draft.json`은 JSON으로는 유효하지만 공식 `.codex-plugin/plugin.json` 형식으로 만든 것은 아니다.
- 실제 Codex plugin install flow에서 repo marketplace와 personal marketplace 중 무엇을 쓸지는 아직 결정하지 않았다.
- plugin hooks는 공식 문서상 plugin에 포함될 수 있지만, 현재 릴리스에서는 별도 feature flag와 trust/approval 고려가 필요하다.
- 현재 SVM repo에서 plugin까지 갈지, 또는 skill/MCP/hook 실험만 하고 014로 넘어갈지는 아직 선택해야 한다.

## 위험하거나 과해 보인 점

- 학습용 draft를 실제 installable plugin으로 오해하면 검증 수준을 과장하게 된다.
- 아직 반복 사용이 검증되지 않은 skill이나 MCP를 plugin으로 묶으면 유지보수 대상이 빨리 생긴다.
- marketplace나 global config를 실습 중 수정하면 prompts lab의 안전 경계를 벗어난다.
- Unity MVP 구현 전 단계에서 plugin 제작 자체에 시간을 쓰면 실제 playable loop 검증보다 도구 포장이 앞설 수 있다.

## 채택 여부

채택/보류/폐기 중 정확히 하나만 선택한다. 추가 실험 필요 여부는 후속 작업으로 분리해서 기록한다.

- [x] 채택
- [ ] 보류
- [ ] 폐기

## 채택/보류/폐기 이유

013a 실습 결과는 학습용 bundle로 채택한다. 허용된 `tmp/prompts-lab/013a-plugin-bundle-practice/` 경로 안에서만 README, skill 초안, MCP placeholder, manifest draft를 만들었고, JSON 문법 검증도 통과했다. 다만 실제 Codex plugin 제작이나 SVM workflow plugin 채택을 의미하지는 않으며, 실제 plugin 도입은 반복 workflow와 공식 manifest/marketplace 검증이 끝난 뒤 판단한다.

## 다음 실험 프롬프트

```text
docs/prompts/014-execplan-plans.md를 튜터 모드로 실행해줘.

목표:
- prompts lab 결과와 실제 Safe Village Micro 구현 계획을 구분한다.
- ExecPlan 또는 PLANS.md를 언제 써야 하는지 판단한다.
- plugin 실습에서 만든 learning draft를 실제 project operating rule로 과도하게 승격하지 않는다.
```

또는

```text
방금 만든 tmp/prompts-lab/013a-plugin-bundle-practice/unity-mvp-workflow-draft/ 구조를
OpenAI 공식 Build plugins 문서 기준의 실제 plugin 구조와 비교해줘.

단, 아직 .codex-plugin/plugin.json, marketplace, global config는 만들지 마라.
```

## 후속 작업

- [ ] 문서 갱신 필요
- [ ] AGENTS.md 반영 검토
- [x] skill 후보 검토
- [ ] hook 후보 검토
- [x] 추가 실험 필요
- [x] 추가 리서치 필요

후속 작업 메모:

`tmp/prompts-lab/013a-plugin-bundle-practice/unity-mvp-workflow-draft/ 아래에 README.md, plugin-manifest.draft.json, skills/unity-mvp-scope-review/SKILL.md, mcp/unity-console-mcp-placeholder.md를 만들었다. JSON 문법 검증은 통과했다. OpenAI 공식 문서로는 developers.openai.com/codex/plugins, /codex/plugins/build, /codex/skills, /codex/mcp, /codex/concepts/customization을 확인했다. 실제 plugin 구조와 비교하려면 공식 Build plugins 문서 기준으로 .codex-plugin/plugin.json, skills/, optional .mcp.json, hooks/, assets/, marketplace 연결을 별도 실험에서 비교한다.`
