# Prompt Result: 002. AGENTS.md 이해

## 실험 번호

`002`

## 실험 주제

`AGENTS.md 이해`

## 실행 일시

`2026-05-21 14:11 KST`

## 실행 모드

일반/튜터 중 정확히 하나만 선택한다.

- [ ] 일반
- [x] 튜터

## 사용자 명령

```text
002-agents-md.md 을 docs/prompts/README.md의 튜터 모드로 실행해줘.

문서 정리 해야되지 않아? 다음 실험 전에
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

`docs/prompts/002-agents-md.md`

## 모델/클라이언트/실행 환경

- 모델: `GPT-5 계열 Codex, 세부 모델명 확인 불가`
- 클라이언트: `Codex coding agent, 세부 클라이언트명 확인 불가`
- 실행 환경: `macOS zsh, repo root /Users/kaya/Documents/Codex/codex-harness-svm-v2, KST`

## 실행 조건

- 파일 수정 허용 여부: `실험 실행 단계 파일 수정 금지, 기록 단계에서 docs/prompt-results/ 아래 결과 파일 생성 허용`
- 사용한 skill/tool: `openai-docs skill, OpenAI Developer Docs MCP, shell, apply_patch`
- 별도 제약: `Unity 파일 수정 금지, Safe Village Micro 구현 계획으로 넘어가지 않기, 확인된 사실과 추측 분리`

## Codex 응답 요약

Codex는 현재 repo에 root `AGENTS.md` 파일이 없다는 점을 먼저 확인하고, AGENTS.md를 "항상 지켜야 하는 짧은 행동 규칙과 문서 위치 지도"로 설명했다. AGENTS.md는 중요한 내용을 모두 넣는 장문 문서가 아니며, 긴 설계와 배경은 `docs/` 문서로 빼고 AGENTS.md에는 핵심 규칙과 링크만 남기는 편이 좋다고 정리했다. 하위 디렉터리 `AGENTS.md` 또는 `AGENTS.override.md`는 공식 OpenAI Codex 문서에 있는 개념이지만, 지금 repo에서는 root AGENTS.md 하나로 시작하고 반복 실패가 있을 때만 하위 지침을 검토하는 편이 적절하다고 설명했다. 사용자가 헷갈린 "문서로 나누기"와 "AGENTS.md로 나누기"의 차이를 행동 규칙, 문서 지도, 하위 디렉터리 예외 규칙으로 나누어 정리했다.

## 튜터 모드 상호작용 요약

일반 모드 실행이면 모든 항목에 `해당 없음`을 적는다. 튜터 모드 실행이면 전체 대화 전문을 붙여넣지 말고 핵심만 요약한다.

### Codex가 한 확인 질문

- 사용자가 AGENTS.md를 현재 어떤 개념으로 이해하고 있는지 물었다.
- global AGENTS.md, repo AGENTS.md, subdirectory AGENTS.md 중 무엇이 가장 헷갈리는지 확인했다.
- 현재 repo에 root `AGENTS.md`가 없다는 점을 기준으로 설명할지, 앞으로 만들 파일 기준으로 설명할지 물었다.
- AGENTS.md에 직접 들어갈 내용과 별도 docs 문서로 빠질 내용을 예시 문장으로 구분하게 했다.

### 사용자 답변 요약

- 사용자는 AGENTS.md를 "프로젝트에 항상 적용되는 프로젝트 지침"으로 이해하고 있었다.
- global AGENTS.md와 project AGENTS.md만 있다고 알고 있었고, AGENTS.md는 짧게 유지하고 문서 링크를 남기는 맵처럼 쓰는 것으로 이해하고 있었다.
- 현재 repo에 AGENTS.md 파일이 없다는 점을 기준으로 설명해달라고 요청했다.
- 첫 teach-back 질문은 추상적이라 이해하기 어렵다고 했고, 하위 디렉터리 AGENTS.md가 실제 OpenAI 문서에 있는 개념인지 검증을 요청했다.
- 예시 문제에서 "승인 전 Unity 파일 수정 금지"와 "docs 안에서만 적용되는 별도 행동 규칙"은 AGENTS.md에 직접 들어갈 내용으로 올바르게 구분했다.

### teach-back 결과 또는 아직 헷갈린 지점

- 사용자는 AGENTS.md가 "중요한 모든 내용"을 담는 곳이 아니라, Codex가 바로 지켜야 하는 행동 규칙과 문서 위치를 담는 곳이라는 점을 이해했다.
- "긴 설계 설명은 docs로 보내고, AGENTS.md에는 링크를 둔다"는 방향은 이해했다.
- 다만 "파일 수정 금지"처럼 docs/prompts/README.md에도 있는 운영 규칙을 AGENTS.md에 직접 한 줄로 다시 적어야 하는지 헷갈렸다.
- 최종적으로 "핵심 금지 규칙 한 줄은 AGENTS.md에 직접, 자세한 절차와 예외 설명은 docs/prompts/README.md"라는 구분으로 정리했다.

### 다음 복습 질문

`어떤 문장을 봤을 때 그것이 Codex의 즉시 행동을 제한하는 핵심 규칙인지, 아니면 필요할 때 참고할 긴 설명인지 구분해보기.`

## 내가 이해한 점

- AGENTS.md는 프로젝트의 모든 지식을 담는 파일이 아니라, Codex가 항상 지켜야 할 짧은 행동 규칙과 문서 위치를 알려주는 진입점이다.
- 긴 배경, 설계, 세계관, 실험 결과, 체크리스트는 docs 문서로 분리하고 AGENTS.md에는 필요한 위치만 안내한다.
- 하위 디렉터리 AGENTS.md는 공식적으로 가능한 구조지만, 특정 폴더에서만 항상 다른 행동 규칙이 필요할 때 쓰는 예외에 가깝다.
- 현재 repo에는 root AGENTS.md가 없으므로, 처음에는 root AGENTS.md 하나만 만들고 하위 AGENTS.md는 반복 실패가 확인될 때 검토하는 편이 적절하다.

## 실제로 도움 된 점

- 앞으로 만들 root AGENTS.md의 역할을 "짧은 작업 계약 + 문서 지도"로 좁힐 수 있었다.
- Prompts Lab 관련 핵심 금지 규칙은 AGENTS.md에 직접 한 줄로 두고, 자세한 실행 모드와 기록 규칙은 `docs/prompts/README.md`로 연결하는 방식이 정리되었다.
- 하위 AGENTS.md를 바로 만들지 않고, root AGENTS.md 하나로 시작한 뒤 실제 실패가 있을 때만 추가한다는 기준이 생겼다.
- OpenAI 공식 문서 확인을 통해 nested AGENTS 또는 override 개념이 실제 Codex instruction discovery 모델에 포함된다는 점을 검증했다.

## 헷갈린 점

- 처음에는 "문서 링크를 남기는 것"과 "핵심 규칙을 AGENTS.md에 직접 적는 것"의 경계가 불명확했다.
- `docs/prompts/README.md` 같은 세부 규칙 문서가 이미 있을 때, 어떤 문장을 AGENTS.md에 중복해서 요약해야 하는지 판단 기준이 필요했다.

## 위험하거나 과해 보인 점

- AGENTS.md에 세계관, 캐릭터, 맵 구조, 퍼즐 아이디어 같은 긴 설계를 직접 넣으면 행동 규칙과 참고 정보가 섞일 위험이 있다.
- 처음부터 `docs/AGENTS.md`나 `Assets/AGENTS.md`를 만들면 현재 실험 단계에 비해 구조가 과해질 수 있다.
- 하위 AGENTS.md를 너무 많이 두면 어떤 규칙이 실제로 적용되는지 추적하기 어려워질 수 있다.

## 채택 여부

채택/보류/폐기 중 정확히 하나만 선택한다. 추가 실험 필요 여부는 후속 작업으로 분리해서 기록한다.

- [x] 채택
- [ ] 보류
- [ ] 폐기

## 채택/보류/폐기 이유

이 실험은 AGENTS.md를 현재 repo에서 어떤 범위로 써야 하는지 구체적인 기준을 만들었다. root AGENTS.md를 짧은 행동 규칙과 문서 지도로 유지하고, 하위 AGENTS.md는 실제 반복 실패가 있을 때만 검토한다는 결론이 현재 Prompts Lab 단계에 맞다. 공식 OpenAI 문서 확인으로 subdirectory/nested instruction 개념도 검증했지만, 그 가능성을 지금 바로 구조 확장으로 연결하지 않기로 했다.

## 다음 실험 프롬프트

```text
docs/prompts/003-docs-responsibility.md를 튜터 모드로 실행해줘.
```

## 후속 작업

- [ ] 문서 갱신 필요
- [x] AGENTS.md 반영 검토
- [ ] skill 후보 검토
- [ ] hook 후보 검토
- [x] 추가 실험 필요
- [ ] 추가 리서치 필요

후속 작업 메모:

`root AGENTS.md를 만들 때 "핵심 행동 규칙 + 문서 지도" 구조를 반영할지 검토한다. 다음 실험으로 README, AGENTS.md, docs 문서의 책임 분리를 다루는 003-docs-responsibility를 실행한다.`
