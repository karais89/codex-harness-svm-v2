# Prompt Result: 012a. Mock MCP Tool 실습

## 실험 번호

`012a`

## 실험 주제

`Mock MCP Tool 실습`

## 실행 일시

`2026-05-22 17:58 KST`

## 실행 모드

일반/튜터 중 정확히 하나만 선택한다.

- [ ] 일반
- [x] 튜터

## 사용자 명령

```text
다음으로 넘어가자. 커스텀 mcp를 만들고 싶은 이유는 mcp의 동작 방식을 조금 더 깊이 있게 이해하고 싶어서야.
그래서 가장 간단한 mcp를 만들어보고 싶어
```

## 적용한 실행 모드 wrapper

```text
docs/prompts/README.md의 튜터 모드 wrapper와 012a 실습 예외 규칙을 적용했다.

- Safe Village Micro 구현으로 넘어가지 않음.
- 처음에는 Unity Editor 연동 없이 mock으로 진행했으나, 사용자 지적 이후 실제 Unity Console panel 로그를 읽는 custom bridge 실습으로 범위를 수정함.
- Unity gameplay code, Scene, Packages/manifest.json, ProjectSettings/를 수정하지 않음.
- 실제 Unity Console bridge를 위해 Assets/Editor/PromptsLab/SvmConsoleLogBridge.cs 추가를 허용함.
- .codex 설정, global config, MCP 등록 설정을 수정하지 않음.
- dependency 설치는 하지 않음.
- 파일 생성은 tmp/prompts-lab/012a-mcp-mock-tool/ 아래 실습 파일, Assets/Editor/PromptsLab 아래 Unity Editor bridge, 결과 기록 파일로 제한함.
- 실제 MCP tool 호출과 mock/simulation을 명확히 구분함.
```

## 참조한 프롬프트 파일

`docs/prompts/012a-mcp-mock-tool.md`

## 모델/클라이언트/실행 환경

- 모델: `GPT-5 계열 Codex, 세부 모델명 확인 불가`
- 클라이언트: `Codex coding agent`
- 실행 환경: `macOS zsh, repo root /Users/kaya/Documents/Codex/codex-harness-svm-v2, KST`

## 실행 조건

- 파일 수정 허용 여부: `tmp/prompts-lab/012a-mcp-mock-tool/ 아래 실습 파일 생성 허용, 사용자 지적 이후 Assets/Editor/PromptsLab/SvmConsoleLogBridge.cs 추가 허용, 기록 단계에서 docs/prompt-results/012a-mcp-mock-tool.md 수정 허용`
- 사용한 skill/tool: `shell로 Python/Node/npm 버전과 tmp 구조 확인; MCP 공식 문서 검색으로 JSON-RPC, initialize, tools/list, tools/call 흐름 확인; apply_patch로 실습 파일, Unity Editor bridge, 결과 파일 생성; unity-mcp-cli open으로 Unity Editor 실행; python3로 localhost bridge 및 MCP smoke test 실행`
- 별도 제약: `기존 Unity-MCP 플러그인 사용 금지, .codex/global config/MCP 등록 설정 수정 금지, dependency 설치 금지, Packages/manifest.json 변경 되돌림`

## Codex 응답 요약

Codex는 처음에 dependency 설치 없이 Python 표준 라이브러리만 사용해 stdio JSON-RPC 방식의 MCP-shaped server를 만들었다. 그러나 사용자는 mock/fixture 방식으로는 이해가 어렵고 실제 Unity Console panel 로그를 읽어야 한다고 지적했다. 이후 기존 Unity-MCP 플러그인을 설치하려던 잘못된 시도를 되돌리고, 직접 만든 `SvmConsoleLogBridge.cs`가 Unity Editor 내부에서 `UnityEditor.LogEntries`를 읽고 Python MCP server가 이를 `get_unity_console_logs` tool로 노출하는 구조로 교정했다. 최종 smoke test는 bridge health, MCP initialize, tools/list, tools/call을 모두 통과했고 결과 source가 `UnityEditor.LogEntries`임을 확인했다.

## 튜터 모드 상호작용 요약

일반 모드 실행이면 모든 항목에 `해당 없음`을 적는다. 튜터 모드 실행이면 전체 대화 전문을 붙여넣지 말고 핵심만 요약한다.

### Codex가 한 확인 질문

- 012에서 이미 사용자의 실습 기대치를 확인했으므로, 012a에서는 추가 질문을 하나로 줄이고 "학습용 가장 작은 custom MCP"를 목표로 진행한다고 안내했다.
- 실제 Codex MCP 등록이 아니라 로컬 smoke client로 `initialize -> tools/list -> tools/call` 흐름을 확인하는 실습임을 구분했다.
- 사용자가 mock과 fixture가 부족하다고 지적한 뒤, 실제 Unity Console panel을 읽으려면 Unity Editor 내부 bridge가 필요하다고 정정했다.

### 사용자 답변 요약

- 사용자는 custom MCP를 만들고 싶은 이유가 프로젝트 즉시 도입이 아니라 MCP 동작 방식을 더 깊이 이해하기 위한 것이라고 답했다.
- 가장 간단한 MCP를 만들어보고 싶다고 요청했다.
- 사용자는 기존 Unity-MCP 플러그인을 쓰는 것이 아니라 직접 Unity MCP/plugin을 만들어야 한다고 정정했다.
- 사용자는 Unity 로그 파일이나 fixture가 아니라 실제 Unity panel의 로그를 읽어야 한다고 지적했다.

### teach-back 결과 또는 아직 헷갈린 지점

- 아직 사용자의 별도 teach-back 답변은 받지 않았다.
- 현재 확인된 핵심 구분은 "Unity Editor bridge가 실제 Unity Console panel을 읽는 역할"과 "Python MCP server가 그 기능을 tool로 노출하는 역할"이다.
- `UnityEditor.LogEntries`는 Unity main thread에서 읽어야 하므로, HTTP listener thread에서 바로 호출하지 않고 `EditorApplication.update` queue로 넘겨야 한다는 점을 실습으로 확인했다.

### 다음 복습 질문

`이번 custom Unity Console MCP에서 Unity Editor bridge, Python MCP server, MCP client/smoke_test는 각각 어떤 책임을 맡는가?`

## 내가 이해한 점

- MCP의 최소 감각은 JSON-RPC 요청/응답, lifecycle 초기화, tool 목록 노출, tool 호출 결과 반환으로 확인할 수 있다.
- SDK 없이도 학습 목적으로는 stdio JSON-RPC 메시지를 직접 주고받아 MCP-shaped 흐름을 이해할 수 있다.
- 실제 MCP server 등록은 별도 설정 단계이며, 이번 실습 파일 작성과 smoke test만으로 "Codex가 MCP tool로 호출했다"고 말하면 안 된다.
- Unity MCP와 custom MCP tool은 분리해서 봐야 한다. Unity MCP는 사용할 전제이고, custom MCP는 학습 또는 반복 검증 필요가 생겼을 때 좁게 만든다.
- 실제 Unity panel 데이터를 읽으려면 MCP server만으로는 부족하고, Unity Editor 안에서 실행되는 bridge/plugin 코드가 필요하다.
- Unity Editor API는 main thread 제약이 있으므로, 외부 HTTP/MCP 요청을 받는 thread와 Unity API를 호출하는 main thread를 분리해야 한다.

## 실제로 도움 된 점

- `initialize`, `tools/list`, `tools/call`이 어떤 순서로 이어지는지 코드와 smoke test로 확인했다.
- MCP server가 LLM에게 보여주는 핵심 표면은 tool name, description, inputSchema, call result라는 점이 구체화됐다.
- 실제 Unity Editor panel 로그를 `UnityEditor.LogEntries`에서 읽는 최소 bridge 구조를 확인했다.
- 기존 MCP package 없이도 custom Unity Editor bridge + MCP server 조합으로 작은 read-only tool을 만들 수 있음을 확인했다.

## 헷갈린 점

- stdio transport의 정확한 framing, 최신 protocol revision 호환성, SDK 기반 구현과 직접 JSON-RPC 구현의 차이는 더 깊은 실습이 필요하다.
- 실제 Codex 세션에 이 server를 등록할 때 필요한 config 형식과 승인 흐름은 이번 실습 범위 밖이다.
- Unity MCP처럼 대형 MCP server가 제공하는 resources, prompts, tools, screenshots, Editor 상태 관리가 이 최소 예제와 어떻게 확장 연결되는지는 다음 단계에서 비교해야 한다.
- `UnityEditor.LogEntries`는 Unity internal API라 버전 변경에 취약하다.

## 위험하거나 과해 보인 점

- 이 실습 결과를 실제 production-ready MCP server로 착각하면 안 된다.
- 실제 MCP 등록 없이 "Codex가 이 tool을 MCP로 호출했다"고 기록하면 검증 수준을 과장하게 된다.
- custom MCP를 프로젝트 공식 도구로 먼저 만들면 Unity MCP 기본 tool과 CLI/checklist로 충분한 단계까지 불필요하게 복잡해질 수 있다.
- repo 상태 요약 tool은 read-only지만, 향후 mutating tool을 추가할 때는 승인, scope, dry-run, 로그가 필요하다.
- Unity Editor bridge를 자동 시작하게 하면 편하지만, 프로젝트에 상시 localhost listener가 생기므로 실전 도입 전에는 명시적 start/stop 정책이 필요하다.

## 채택 여부

채택/보류/폐기 중 정확히 하나만 선택한다. 추가 실험 필요 여부는 후속 작업으로 분리해서 기록한다.

- [x] 채택
- [ ] 보류
- [ ] 폐기

## 채택/보류/폐기 이유

학습용 custom MCP 실습으로는 채택한다. 최종 형태는 실제 Unity Console panel entries를 `UnityEditor.LogEntries`에서 읽고, 이를 Python MCP server가 `get_unity_console_logs` tool로 노출하는 구조를 검증했기 때문이다. 다만 이 결과는 실제 Codex MCP config 등록이나 SVM 공식 custom MCP tool 채택을 의미하지 않으며, 프로젝트 공식 도입은 반복 필요와 운영 정책이 확인된 뒤 별도 판단한다.

## 다음 실험 프롬프트

```text
docs/prompts/013-plugin-concepts.md를 튜터 모드로 실행해줘.

또는 별도 후속 실습:
방금 만든 tmp/prompts-lab/012a-mcp-mock-tool/custom-unity-console-mcp/server.py를 실제 Codex MCP server로 등록하려면 어떤 설정, 승인, 검증 절차가 필요한지 설명해줘. 단, 아직 설정 파일은 수정하지 마라.
```

## 후속 작업

- [ ] 문서 갱신 필요
- [ ] AGENTS.md 반영 검토
- [ ] skill 후보 검토
- [ ] hook 후보 검토
- [x] 추가 실험 필요
- [ ] 추가 리서치 필요

후속 작업 메모:

`tmp/prompts-lab/012a-mcp-mock-tool/ 아래에 server.py, smoke_test.py, README.md를 만들었다. smoke test는 PASS initialize, PASS tools/list, PASS tools/call hello, PASS tools/call repo_status를 확인했다. 이후 사용자가 mock 예시만으로는 이해가 어렵다고 지적해, 같은 목표를 MCP 호출 방식과 CLI 호출 방식으로 비교하는 추가 실습을 tmp/prompts-lab/012a-mcp-mock-tool/unity-console-compare/ 아래에 만들었다. 이 추가 실습은 Unity Editor log fixture를 읽는 get_unity_console_logs MCP-shaped server와 동일 기능의 unity_console_cli.py를 비교하며, smoke test에서 두 방식 모두 NullReferenceException과 asset load error를 반환함을 확인했다. 사용자는 fixture/log file 방식도 실제 Unity panel 로그가 아니라는 점을 지적했다. 이에 따라 기존 Unity-MCP 플러그인을 설치하는 잘못된 방향을 되돌리고, 직접 만든 최소 Unity Editor bridge + MCP server 구조를 추가했다. 실제 구현은 Assets/Editor/PromptsLab/SvmConsoleLogBridge.cs가 UnityEditor.LogEntries를 main thread에서 읽고, tmp/prompts-lab/012a-mcp-mock-tool/custom-unity-console-mcp/server.py가 get_unity_console_logs MCP tool로 노출하는 방식이다. 최종 smoke test는 PASS bridge /health, PASS MCP initialize, PASS MCP tools/list, PASS MCP tools/call get_unity_console_logs를 확인했고, 결과 source는 UnityEditor.LogEntries였다. 다음에는 013-plugin-concepts로 넘어가거나, 이 custom MCP server를 Codex config에 등록하는 별도 실험을 진행할 수 있다.`
