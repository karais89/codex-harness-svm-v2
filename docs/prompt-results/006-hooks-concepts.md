# Prompt Result: 006. Hooks 개념 이해

## 실험 번호

`006`

## 실험 주제

`Hooks 개념 이해`

## 실행 일시

`2026-05-21 21:09 KST`

## 실행 모드

일반/튜터 중 정확히 하나만 선택한다.

- [ ] 일반
- [x] 튜터

## 사용자 명령

```text
docs/prompts/006-hooks-concepts.md를 튜터 모드로 실행 해줘.

ok 알았다 다음으로 넘어가자 근데 이런 식으로 hooks 상황별로 후보 생성해서 만들면 좋을 것 같아 실습으로

모르겠고 이거 나중에 실습 하도록 추가해줘 3개 전부 혹은 더 좋은 예시 상황. 생각해서 추가해주면 좋을 것 같기도하고

결과 정리 하고 커밋 까지 해줘.
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

`docs/prompts/006-hooks-concepts.md`

## 모델/클라이언트/실행 환경

- 모델: `GPT-5 계열 Codex, 세부 모델명 확인 불가`
- 클라이언트: `Codex coding agent, 세부 클라이언트명 확인 불가`
- 실행 환경: `macOS zsh, repo root /Users/kaya/Documents/Codex/codex-harness-svm-v2, KST`

## 실행 조건

- 파일 수정 허용 여부: `실험 실행 단계 파일 수정 금지, 기록 단계에서 docs/prompt-results/ 아래 결과 파일 생성 허용. 후속 요청으로 docs/prompts/006a-hooks-guard-practice.md와 docs/prompts/README.md 문서 갱신 수행`
- 사용한 skill/tool: `openai-docs MCP로 Codex hooks 공식 문서 확인, shell로 repo/환경 확인, apply_patch로 결과 및 후속 실습 프롬프트 기록`
- 별도 제약: `Unity 파일 수정 금지, 실제 hook 생성/활성화 금지, .codex/config.toml 및 .codex/hooks 수정 금지, Safe Village Micro 구현 계획으로 넘어가지 않기`

## Codex 응답 요약

Codex는 hook을 "특정 이벤트 전후에 자동 실행되는 검사/차단/알림 장치"로 설명했다. AGENTS.md는 상시 지침, skill은 반복 workflow, hook은 특정 상황에서 실행되는 강제 가드레일로 구분했다. Codex hooks는 `SessionStart`, `UserPromptSubmit`, `PreToolUse`, `PermissionRequest`, `PostToolUse`, `Stop` 같은 이벤트에서 command handler를 실행할 수 있으며, 보통 Python 스크립트가 JSON 입력을 받아 검사 결과를 JSON으로 반환하는 형태라고 설명했다. `ProjectSettings/` 같은 경로 차단은 자연어 지시가 아니라 `PreToolUse`에서 `apply_patch`나 `Bash` 입력을 검사해 deny하는 방식이며, 완전한 보안 경계가 아니라 실수 방지용 가드레일로 보아야 한다고 정리했다. 후속 요청에 따라 실제 hook 활성화가 아닌 mock 실습 프롬프트 `006a-hooks-guard-practice`를 추가했다.

## 튜터 모드 상호작용 요약

일반 모드 실행이면 모든 항목에 `해당 없음`을 적는다. 튜터 모드 실행이면 전체 대화 전문을 붙여넣지 말고 핵심만 요약한다.

### Codex가 한 확인 질문

- 사용자가 hook을 현재 어떤 개념으로 이해하는지 물었다.
- hook과 skill의 차이에서 헷갈리는 부분이 있는지 물었다.
- Unity 프로젝트에서 자동으로 막아야 할 위험으로 무엇이 떠오르는지 물었다.
- AGENTS.md, skill, hook의 차이를 Safe Village Micro 예시로 다시 설명하게 했다.
- `ProjectSettings/` 수정을 막을 때 왜 AGENTS.md만으로는 약하고 `PreToolUse` hook이 더 강한지 물었다.

### 사용자 답변 요약

- 사용자는 hook을 "특정 상황에 콜백처럼 동작하는 것"으로 이해한다고 답했다.
- skill과 hook의 차이는 크게 헷갈리지 않는다고 답했다.
- Unity 프로젝트의 자동 guard 후보로는 컴파일 에러, lint, unit test, formatting을 떠올렸지만, 위험까지는 크지 않을 수 있다고 보았다.
- AGENTS.md는 지침, skill은 반복, hook은 특정 상황 강제라고 정리했다.
- hook이 Python 스크립트를 호출하는 형태인지, Codex에게 특정 경로를 막으라고 명령할 수 있는지, `codex exec`와는 어떻게 다른지 추가로 물었다.
- 실제 예시와 ASCII 흐름도를 통해 `PreToolUse`가 `apply_patch` 입력을 검사해 특정 경로를 막는 흐름을 이해했다.

### teach-back 결과 또는 아직 헷갈린 지점

- 사용자는 AGENTS.md, skill, hook의 핵심 차이를 "지침 / 반복 / 특정 상황 강제"로 설명할 수 있었다.
- 사용자는 AGENTS.md가 무시될 수 있기 때문에 hook이 더 강한 가드레일이 될 수 있다는 점을 이해했다.
- 사용자는 `patch`가 Codex의 파일 수정 tool 입력이며, 실제 파일 수정 직전에 hook이 그 입력을 검사할 수 있다는 점을 이해했다.
- 아직 실제 hook 이벤트별 block/warning 기준은 직접 고르기 어렵다고 답했다.
- 이 헷갈림을 해소하기 위해 실제 활성화가 아닌 mock JSON과 Python 스크립트를 쓰는 `006a-hooks-guard-practice` 실습을 후속 프롬프트로 추가했다.

### 다음 복습 질문

`PreToolUse` path guard, `Stop` verification guard, `UserPromptSubmit` scope guard 중 어떤 것은 block으로 두고 어떤 것은 warning/context로 두는 편이 좋은지, 각 이유를 한 문장씩 정리해보기.`

## 내가 이해한 점

- Hook은 Codex lifecycle의 특정 이벤트에서 실행되는 command 기반 확장 지점이다.
- Codex hook은 보통 Python 같은 로컬 스크립트가 JSON 입력을 받아 검사하고, JSON 출력이나 exit code로 allow, deny, warning/context, continue 여부를 전달하는 방식으로 동작한다.
- `matcher`는 주로 tool 이름이나 session source를 거르는 장치이고, 경로 차단은 hook 스크립트 내부에서 `tool_input`을 직접 검사해야 한다.
- `PreToolUse`는 `apply_patch`, Bash, MCP tool 실행 전에 개입할 수 있어 보호 경로 차단 실습에 적합하다.
- `Stop`은 턴 종료 직전에 검증 언급 누락을 잡는 데 적합하지만, 실제 side effect를 되돌리는 용도는 아니다.
- `UserPromptSubmit`은 사용자 요청을 보고 추가 context를 주거나 prompt를 차단할 수 있어 Prompts Lab 범위 guard 후보가 될 수 있다.
- `codex exec`는 Codex 실행 방식이고, hook은 실행 중 lifecycle에 끼어드는 검사 장치라 서로 층위가 다르다.

## 실제로 도움 된 점

- `ProjectSettings/`나 `Packages/manifest.json` 같은 Unity 보호 경로는 AGENTS.md 지침만 두는 것보다 `PreToolUse` guard 후보로 검토할 수 있음을 확인했다.
- 컴파일, lint, unit test, formatting은 무조건 hook으로 강제하기보다 실행 비용과 false positive 가능성을 보고 `Stop` 또는 특정 단계 guard로 좁혀야 한다는 기준을 얻었다.
- Hook은 처음부터 실제 활성화하기보다 mock 입력 JSON과 Python 스크립트로 block/warning/context 기준을 먼저 실습하는 편이 안전하다는 결론을 얻었다.
- 후속 실습 프롬프트 `006a-hooks-guard-practice`를 추가해, 실제 `.codex/` 설정을 건드리지 않고 path guard, verification guard, scope guard를 연습할 수 있게 했다.

## 헷갈린 점

- Hook 이벤트별로 block과 warning/context를 나누는 기준은 아직 실제 실습 전이라 충분히 검증되지 않았다.
- `PreToolUse`가 완전한 보안 경계가 아니라는 한계는 이해했지만, Safe Village Micro에서 어느 수준까지 guard로 충분한지는 추가 실습이 필요하다.
- 컴파일/테스트를 hook으로 강제할지, 종료 전 검증 누락만 잡을지는 Unity 실행 비용을 확인한 뒤 판단해야 한다.

## 위험하거나 과해 보인 점

- 초반부터 실제 `.codex/config.toml`과 hook script를 활성화하면 Prompts Lab의 학습 목적보다 자동화 구조가 앞설 수 있다.
- 모든 Unity 파일 변경을 block하면 실제 개발 단계에서 C# 코드 수정이나 씬 작업을 방해할 수 있다.
- lint, unit test, Unity compile을 매 tool call마다 강제하면 너무 느리고 false positive가 많아질 수 있다.
- 경로 문자열 검사 hook은 실수 방지에는 유용하지만 완전한 보안 장치로 오해하면 안 된다.
- Hook이 많아질수록 유지보수와 trust review 부담이 생기므로, mock 실습으로 후보를 좁힌 뒤 실제 도입해야 한다.

## 채택 여부

채택/보류/폐기 중 정확히 하나만 선택한다. 추가 실험 필요 여부는 후속 작업으로 분리해서 기록한다.

- [x] 채택
- [ ] 보류
- [ ] 폐기

## 채택/보류/폐기 이유

이 실험은 hook을 AGENTS.md와 skill에서 구분하는 실용적 기준을 만들었고, Codex hook이 실제로 어느 이벤트에서 어떤 방식으로 개입하는지 이해하는 데 도움이 되었다. 다만 채택하는 것은 "hook 개념 구분 기준과 mock 실습 방향"이지 실제 hook 활성화가 아니다. 실제 hook 도입 여부는 `006a-hooks-guard-practice`에서 block/warning/context 기준을 검증한 뒤 다시 판단한다.

## 다음 실험 프롬프트

```text
docs/prompts/006a-hooks-guard-practice.md를 튜터 모드로 실행해줘.
```

그 다음 기본 흐름으로는 다음 프롬프트를 실행한다.

```text
docs/prompts/007-llm-failure-modes.md를 튜터 모드로 실행해줘.
```

## 후속 작업

- [x] 문서 갱신 필요
- [ ] AGENTS.md 반영 검토
- [ ] skill 후보 검토
- [x] hook 후보 검토
- [x] 추가 실험 필요
- [ ] 추가 리서치 필요

후속 작업 메모:

`docs/prompts/006a-hooks-guard-practice.md를 추가했다. 다음에는 실제 hook 활성화 없이 tmp/prompts-lab/006a-hooks-guard-practice/ 아래에서 mock hook 입력 JSON, Python guard script, smoke test runner를 만들어 path guard, verification guard, scope guard를 실습한다. 006a 결과를 기록하기 전까지 실제 .codex/config.toml이나 .codex/hooks는 만들지 않는다.`
