# Prompt Result: 006a. Hooks Guard 실습

## 실험 번호

`006a`

## 실험 주제

`Hooks Guard 실습`

## 실행 일시

`2026-05-21 21:16 KST`

## 실행 모드

일반/튜터 중 정확히 하나만 선택한다.

- [ ] 일반
- [x] 튜터

## 사용자 명령

```text
006a-hooks-guard-practice 이 파일을 튜터 모드로 실행해줘.

1. 특정 상황에서 이벤트를 가로 챌 수 있는 것 으로 이해
2. 어떤 hooks이 좋은 hooks인지 상황별로 어떤 hooks를 사용하면 좋을지. 최소한 이거는 사용해야 한다 가이드 라인. 그리고 이건 좋다 팁.

mock으로도 충분한건가? 어떻게 codex랑 동일하게동작한다고 생각할수 있지?

그래 tmp에서 만들면 되겟네 왜 굳이 mock을 만들었데 위 처럼 진행해봐
```

## 적용한 실행 모드 wrapper

```text
docs/prompts/README.md의 튜터 모드 wrapper를 적용했다.

- Safe Village Micro 구현으로 넘어가지 않음.
- 기본적으로 파일을 생성/수정하지 않되, 006a 실습 예외에 따라 tmp/prompts-lab/006a-hooks-guard-practice/ 아래 실습 파일 생성을 허용함.
- 현재 repo 구조와 로컬 실행 환경을 확인함.
- Unity gameplay code, Scene, Packages/manifest.json, ProjectSettings/를 수정하지 않음.
- 시작 질문으로 hook 이해 수준과 헷갈린 지점을 확인함.
- 개념을 후보별로 나누고 block/warning/context 기준을 설명함.
- 마지막에 핵심 요약, 복습 질문, 다음 실험 제안 순서로 마무리함.
```

## 참조한 프롬프트 파일

`docs/prompts/006a-hooks-guard-practice.md`

## 모델/클라이언트/실행 환경

- 모델: `GPT-5 계열 Codex, 세부 모델명 확인 불가`
- 클라이언트: `Codex coding agent`
- 실행 환경: `macOS zsh, repo root /Users/kaya/Documents/Codex/codex-harness-svm-v2, Python 3.14.2, KST`

## 실행 조건

- 파일 수정 허용 여부: `tmp/prompts-lab/006a-hooks-guard-practice/ 아래 mock 실습 파일 생성 허용, 후속 요청에 따라 tmp/prompts-lab/006a-real-codex-hook-smoke/ 아래 disposable 실제 hook smoke 파일 생성 허용, 결과 기록 단계에서 docs/prompt-results/006a-hooks-guard-practice.md 생성 허용`
- 사용한 skill/tool: `openai-docs, shell, apply_patch`
- 별도 제약: `Unity 파일 수정 금지, Assets/ Packages/ ProjectSettings/ 수정 금지, parent repo .codex/ 및 global config 수정 금지, dependency 설치 금지. 실제 hook은 후속 요청에 따라 disposable subject repo의 subject/.codex/ 안에서만 생성하고 trust review를 거쳐 검증함`

## Codex 응답 요약

Codex는 사용자의 이해를 바탕으로 hook을 "특정 상황에서 Codex lifecycle 이벤트를 가로채는 장치"로 잡고, 좋은 hook의 기준을 "결정적이고 좁고 실행 비용이 낮으며 피해가 명확한 상황"으로 정리했다. 실습 후보는 `PreToolUse` path guard, `Stop` verification guard, `UserPromptSubmit` scope guard 세 가지로 유지했다. 먼저 `tmp/prompts-lab/006a-hooks-guard-practice/` 아래 mock JSON, Python guard script, smoke test runner, README를 만들었고, smoke test는 차단, 계속 진행, context 추가, 통과 케이스를 모두 기대값대로 통과했다. 이후 사용자 지적에 따라 `tmp/prompts-lab/006a-real-codex-hook-smoke/subject/` 안에 disposable 실제 `.codex/hooks.json`과 hook script를 만들고, Codex CLI에서 실제 `UserPromptSubmit`, `PreToolUse`, `Stop` 호출을 확인했다.

## 튜터 모드 상호작용 요약

일반 모드 실행이면 모든 항목에 `해당 없음`을 적는다. 튜터 모드 실행이면 전체 대화 전문을 붙여넣지 말고 핵심만 요약한다.

### Codex가 한 확인 질문

- hook을 Codex의 특정 이벤트에서 JSON 입력을 받아 검사하고 결과를 돌려주는 장치로 이해하는지 물었다.
- 더 헷갈리는 지점이 block 기준, warning/context 기준, 이벤트 차이 중 무엇인지 물었다.

### 사용자 답변 요약

- 사용자는 hook을 "특정 상황에서 이벤트를 가로챌 수 있는 것"으로 이해한다고 답했다.
- 사용자는 hook 문법보다 "좋은 hook이 무엇인지", "상황별로 어떤 hook을 쓰면 좋은지", "최소 사용 가이드라인과 팁"을 알고 싶다고 답했다.
- 사용자는 mock만으로 Codex와 동일 동작을 보장할 수 없다고 지적했고, tmp 아래 disposable repo에서 실제 hook smoke를 진행하자고 했다.

### teach-back 결과 또는 아직 헷갈린 지점

- 사용자는 hook의 큰 개념은 이해했지만, 실제 프로젝트 운영에서 block과 context를 나누는 기준을 더 알고 싶어 했다.
- 사용자는 mock이 검증하는 범위와 실제 Codex lifecycle 검증 범위를 구분해야 한다는 점을 확인했다.
- Codex는 마지막에 `ProjectSettings/` 보호, 검증 누락, Prompts Lab 범위 이탈 세 상황을 각각 어떤 이벤트와 decision으로 둘지 설명해보는 teach-back 질문을 남겼다.

### 다음 복습 질문

`ProjectSettings/` 보호, 검증 누락, Prompts Lab 범위 이탈 세 상황을 각각 block, continue, context 중 무엇으로 둘지 한 문장씩 설명해보기.

## 내가 이해한 점

- 좋은 hook은 자연어 지침을 반복하는 장치가 아니라, 좁고 결정적인 조건을 자동으로 확인하는 가드레일이다.
- `PreToolUse`는 tool 실행 전 입력을 볼 수 있으므로 보호 경로 차단처럼 실제 피해가 생기기 전 막아야 하는 상황에 적합하다.
- `Stop`은 작업 종료 직전의 품질 기준을 확인하는 데 적합하지만 이미 실행된 side effect를 되돌리는 장치는 아니다.
- `UserPromptSubmit`은 사용자 요청을 보고 추가 context를 주거나 명백히 위험한 요청을 막는 데 적합하다.
- mock 실습은 정책과 script logic을 검증하고, 실제 Codex hook smoke는 hook discovery, trust review, event 호출, 출력 해석을 검증한다.
- 이번 실제 smoke에서 TUI 경로는 project-local hook review를 띄웠고, trust 이후 `codex exec`에서도 같은 hook이 호출됐다.

## 실제로 도움 된 점

- Prompts Lab 단계에서 최소 hook 후보는 `PreToolUse` 보호 경로 guard 하나로 좁혀볼 수 있다.
- `Stop` 검증 guard는 유용하지만 false positive가 생기기 쉬우므로 "완료 주장 + 검증 언급 없음"처럼 좁은 조건으로 시작하는 편이 낫다.
- `UserPromptSubmit` scope guard는 처음부터 block보다 context 추가로 시작하는 편이 덜 방해된다.
- 실제 활성화 전에도 mock fixture와 smoke test로 hook 정책을 먼저 검증할 수 있음을 확인했다.
- 실제 Codex hook smoke 결과 `subject/.codex/hook-log.jsonl`에 `UserPromptSubmit`, `PreToolUse` with `tool_name: "Bash"`, `Stop` with `stop_hook_active: false/true`가 기록됐다.
- `PreToolUse`는 `echo CODEX_HOOK_BLOCK_ME` Bash command를 실제로 deny했고, `Stop`은 한 번 continuation을 만든 뒤 다음 Stop에서는 통과했다.

## 코드와 실제 흐름 이해 가이드

### mock 실습 코드가 해결한 것

`tmp/prompts-lab/006a-hooks-guard-practice/`는 Codex와 연결되지 않은 순수 로직 실습이다.

- `fixtures/*.json`: Codex가 hook script에 보낼 법한 입력 JSON을 손으로 만든 예시다.
- `hooks/mock_guard.py`: 입력 JSON을 검사해 block, continue, context, pass 중 하나로 반응한다.
- `run_smoke_tests.py`: 각 fixture를 `mock_guard.py` stdin으로 넣고 결과가 기대값과 맞는지 확인한다.

이 단계가 해결한 질문은 "이 상황을 hook으로 잡는 게 맞나?", "block과 context 중 무엇이 맞나?", "스크립트가 위험한 예시와 통과 예시를 구분하나?"이다.

### 실제 Codex smoke가 해결한 것

`tmp/prompts-lab/006a-real-codex-hook-smoke/subject/`는 실제 Codex hook 연결을 확인하기 위한 disposable repo다.

- `subject/.codex/hooks.json`: 실제 Codex가 읽는 hook 설정이다.
- `subject/.codex/hooks/real_hook_probe.py`: 실제 Codex가 실행한 hook script다.
- `subject/.codex/hook-log.jsonl`: hook script가 받은 실제 event를 기록한 증거다.

이 단계가 해결한 질문은 "Codex가 이 hook을 실제로 발견하나?", "trust review가 필요한가?", "PreToolUse가 Bash 실행 전에 실제로 막을 수 있나?", "Stop hook이 실제로 continuation을 만들 수 있나?"이다.

### 실제 호출 순서

실제 성공 흐름은 다음과 같았다.

1. Codex TUI를 `subject/`에서 실행했다.
2. Codex가 `subject/.codex/hooks.json`을 발견하고 `3 hooks are new or changed` review를 띄웠다.
3. trust 후 `UserPromptSubmit`이 실행되어 prompt context를 추가했다.
4. Codex가 `echo CODEX_HOOK_BLOCK_ME` Bash command를 실행하려고 했다.
5. `PreToolUse`가 먼저 실행되어 `tool_name: "Bash"`와 `tool_input.command`를 받았다.
6. hook script가 `permissionDecision: "deny"`를 반환했고 Bash command는 차단됐다.
7. Codex가 "command was blocked"라는 응답을 만들었다.
8. `Stop`이 `stop_hook_active: false` 상태로 실행되어 한 번 더 이어가라고 요청했다.
9. Codex가 continuation 응답을 만든 뒤 `Stop`이 `stop_hook_active: true` 상태로 다시 실행됐다.

### 그래서 무엇이 검증됐나

- mock은 "정책과 코드 로직"을 검증했다.
- 실제 smoke는 "Codex lifecycle과 hook 출력 해석"을 검증했다.
- parent repo에 hook을 도입해도 된다는 결론은 아직 아니다. 도입 여부는 `017-final-selection`에서 별도 판단해야 한다.

## 헷갈린 점

- 실제 개발 단계로 넘어간 뒤에도 `ProjectSettings/`와 `Packages/`를 계속 block할지, 승인 기반 예외를 둘지는 아직 결정하지 않았다.
- `Stop` verification guard가 어느 정도의 검증 문구를 충분하다고 볼지는 프로젝트별로 더 좁혀야 한다.
- `UserPromptSubmit`이 context만 줄지, Prompts Lab 종료 전 Unity 구현 요청을 block할지는 운영 방식에 따라 달라진다.
- project-local hook은 trust review가 필요하다. 실제 smoke에서 trust 전 `codex exec`는 hook log를 만들지 않았고, TUI에서 trust 후 `codex exec`가 hook을 실행했다.

## 위험하거나 과해 보인 점

- 너무 많은 hook을 초기에 켜면 학습보다 자동화 유지보수가 앞설 수 있다.
- 모든 Unity 경로를 block하면 실제 구현 단계에서 필요한 작업까지 막을 수 있다.
- 검증 guard가 모든 응답에 과하게 개입하면 짧은 설명이나 문서 작업에도 불필요한 continuation이 생길 수 있다.
- parent repo의 실제 `.codex/config.toml`과 hook trust 설정을 조기에 만들면 Prompts Lab의 "mock으로 먼저 검증" 원칙을 깨게 된다.
- disposable repo의 hook trust도 사용자 state에 남을 수 있으므로, 실제 프로젝트 도입 전에는 hook 파일 경로와 trust 대상을 명확히 제한해야 한다.

## 채택 여부

채택/보류/폐기 중 정확히 하나만 선택한다. 추가 실험 필요 여부는 후속 작업으로 분리해서 기록한다.

- [x] 채택
- [ ] 보류
- [ ] 폐기

## 채택/보류/폐기 이유

이번 실습은 mock으로 세 가지 hook 후보의 decision 기준을 검증했고, 후속 실제 smoke로 Codex CLI가 같은 종류의 hook 이벤트를 실제로 호출한다는 점도 확인했다. 따라서 "mock으로 정책을 먼저 좁히고, disposable repo에서 실제 lifecycle smoke로 검증한다"는 실습 방식은 채택한다. 다만 parent repo에 실제 hook을 도입하는 것은 아직 채택하지 않고, 이후 final selection 단계에서 다시 판단한다.

## 다음 실험 프롬프트

```text
docs/prompts/007-llm-failure-modes.md를 튜터 모드로 실행해줘.
```

## 후속 작업

- [x] 문서 갱신 필요
- [ ] AGENTS.md 반영 검토
- [ ] skill 후보 검토
- [x] hook 후보 검토
- [x] 추가 실험 필요
- [x] 추가 리서치 필요

후속 작업 메모:

`tmp/prompts-lab/006a-hooks-guard-practice/` 아래 mock guard 실습 파일을 만들었다. 이후 `tmp/prompts-lab/006a-real-codex-hook-smoke/subject/` 아래 disposable 실제 hook smoke를 만들고, TUI trust review 후 `codex exec`에서도 실제 hook 호출을 확인했다. 이후 최종 선택 단계에서 최소 hook 후보로 PreToolUse 보호 경로 guard를 검토하고, Stop verification guard와 UserPromptSubmit scope guard는 false positive와 운영 부담을 보고 선택한다.`
