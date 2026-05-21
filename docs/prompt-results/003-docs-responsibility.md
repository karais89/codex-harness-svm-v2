# Prompt Result: 003. 문서 역할 분리

## 실험 번호

`003`

## 실험 주제

`문서 역할 분리`

## 실행 일시

`2026-05-21 18:40 KST`

## 실행 모드

일반/튜터 중 정확히 하나만 선택한다.

- [ ] 일반
- [x] 튜터

## 사용자 명령

```text
/docs/prompts/003-docs-responsibility.md 이 파일을 docs/prompts/README.md의 튜터 모드로 실행해줘

현재까지 내용 기록해줘
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

`docs/prompts/003-docs-responsibility.md`

## 모델/클라이언트/실행 환경

- 모델: `GPT-5 계열 Codex, 세부 모델명 확인 불가`
- 클라이언트: `Codex coding agent, 세부 클라이언트명 확인 불가`
- 실행 환경: `macOS zsh, repo root /Users/kaya/Documents/Codex/codex-harness-svm-v2, KST`

## 실행 조건

- 파일 수정 허용 여부: `실험 실행 단계 파일 수정 금지, 기록 단계에서 docs/prompt-results/ 아래 결과 파일 생성 허용`
- 사용한 skill/tool: `shell, apply_patch`
- 별도 제약: `Unity 파일 수정 금지, Safe Village Micro 구현 계획으로 넘어가지 않기, 확인된 사실과 추측 분리`

## Codex 응답 요약

Codex는 처음에 `003-docs-responsibility`를 문서 구조 설계 실험으로 설명했지만, prompts lab용 최소 문서 세트와 실제 Safe Village Micro 개발 문서 세트를 섞어 설명하는 오류가 있었다. 사용자는 이 프로젝트가 아직 문서 구조를 확정하는 단계가 아니라, v1 프로젝트와 Matt skill set을 포함한 Codex/LLM workflow 실험 프로젝트라는 점을 정정했다. 이후 Codex는 문서 후보를 "만든다면 어떤 책임인가"와 "지금 채택할 것인가"로 분리해서 봐야 한다고 정리했다. 현재 결론은 문서를 확정하거나 새로 도입하는 것이 아니라, 후보 문서들의 책임과 겹침 위험을 이해하고 모든 prompts lab 실험 이후 채택 여부를 결정한다는 것이다.

## 튜터 모드 상호작용 요약

일반 모드 실행이면 모든 항목에 `해당 없음`을 적는다. 튜터 모드 실행이면 전체 대화 전문을 붙여넣지 말고 핵심만 요약한다.

### Codex가 한 확인 질문

- 이번 실험의 최종 결론에서 가장 중요하게 볼 기준이 무엇인지 물었다.
- 현재 없는 문서 후보도 "만든다면 어떤 책임이어야 하는가"까지 평가할지 물었다.
- Codex가 매 세션 자동으로 읽어야 하는 문서를 얼마나 작게 잡을지 물었다.
- `README.md`, `AGENTS.md`, `docs/project-goal.md`의 차이를 사용자 말로 설명하게 했다.
- `docs/prompt-results/`와 `docs/decisions.md`의 차이를 사용자 말로 설명하게 했다.

### 사용자 답변 요약

- 사용자는 이번 실험의 우선순위를 "각 문서의 역할을 명확히 나누는 것"으로 정했다.
- 현재 없는 문서도 "만든다면 어떤 책임이어야 하는가"까지 판단하되, 실제 도입 결정은 아직 하지 않는다고 답했다.
- Codex가 매 세션 읽는 문서는 아주 작게, `AGENTS.md` 하나 중심으로 잡고 싶다고 답했다.
- `README.md`는 사람이 읽는 문서, `AGENTS.md`는 에이전트가 읽는 문서로 이해한다고 답했다.
- `docs/project-goal.md`는 프로젝트 목표나 PRD에 가까운 문서 후보지만, 실제 추가 여부는 아직 결정하지 않았다고 답했다.
- `docs/prompt-results/`는 실험을 돌려보고 나온 결과를 저장하는 곳이고, `docs/decisions.md`는 만든다면 프로젝트 결정 사항을 저장하는 문서라고 설명했다.
- 현재는 어떤 형태로 문서를 만들지 확정하지 않았고, 확정은 모든 실험이 완료된 후 진행할 것이라고 정리했다.

### teach-back 결과 또는 아직 헷갈린 지점

- 사용자는 `README.md`, `AGENTS.md`, `docs/project-goal.md`의 기본 역할 차이를 설명할 수 있었다.
- 사용자는 `docs/prompt-results/`와 `docs/decisions.md`를 "실험 결과"와 "확정 결정"으로 구분할 수 있었다.
- 중요한 교정 지점은 Codex가 후보 문서의 역할 정의를 실제 도입 결정처럼 말하면 안 된다는 점이었다.
- 또 다른 교정 지점은 prompts lab을 운영하기 위한 문서 세트와 실제 Safe Village Micro 개발에 필요한 문서 세트를 섞으면 안 된다는 점이었다.
- 아직 남은 쟁점은 전체 prompts lab이 끝난 뒤 어떤 문서를 실제로 채택할지 결정하는 기준이다.

### 다음 복습 질문

`후보 문서를 평가할 때 "만든다면 책임", "겹침 위험", "현재 판단"을 각각 어떻게 구분해서 말할 수 있는가?`

## 내가 이해한 점

- 003 실험은 문서 구조를 확정하는 실험이 아니라, 후보 문서들의 책임과 겹침 위험을 이해하는 실험이다.
- 현재 repo는 Safe Village Micro를 바로 구현하는 곳이 아니라, v1 프로젝트와 Matt skill set을 포함한 Codex/LLM workflow를 실험하는 prompts lab 성격이 강하다.
- `docs/project-goal.md`, `docs/decisions.md`, `PLANS.md`, `docs/progress.md` 등은 아직 도입 확정 문서가 아니라 역할 후보로 봐야 한다.
- `docs/prompt-results/`는 이미 존재하는 실험 출력 보관소이고, `docs/decisions.md`는 만든다면 확정된 프로젝트 결정만 담는 후보 문서다.
- 문서 후보는 "역할 정의"와 "채택 여부"를 분리해서 평가해야 한다.

## 실제로 도움 된 점

- 문서 책임을 prompts lab 운영 문서, 실제 SVM/v1 프로젝트 문서, Codex 운영 문서로 나눠 봐야 한다는 기준이 생겼다.
- 후보 문서를 설명할 때 "만든다면"이라는 조건을 명시해야 한다는 점이 확인되었다.
- `AGENTS.md` 하나 중심의 아주 작은 매 세션 진입점을 선호한다는 기준이 확인되었다.
- 모든 prompts lab 실험이 끝나기 전에는 `decisions.md`나 `project-goal.md` 같은 후보 문서를 확정하지 않는다는 운영 기준이 정리되었다.

## 헷갈린 점

- 초반에는 "최소 세트"라는 표현이 prompts lab 운영에 필요한 최소 문서 세트인지, 실제 SVM 개발에 필요한 최소 문서 세트인지 불명확했다.
- `docs/project-goal.md`가 PRD에 가까운 목표 문서 후보라는 점은 이해했지만, 실제 도입 시점은 아직 실험 완료 후 판단해야 한다.
- `docs/decisions.md`는 역할 후보로는 설명할 수 있지만, 현재 도입 여부를 확정하면 안 된다.

## 위험하거나 과해 보인 점

- 후보 문서의 역할을 설명하다가 실제 도입 결정처럼 말하면 문서 구조가 너무 일찍 굳어질 위험이 있다.
- prompts lab 문서와 실제 게임 개발 문서를 섞으면, 현재 실험의 목적과 나중에 필요한 개발 문서가 혼동될 수 있다.
- `AGENTS.md`에 project-goal, decisions, progress 성격의 내용을 모두 넣으면 매 세션 문서가 무거워질 수 있다.
- 모든 후보 문서를 한꺼번에 만들면 실험 결과를 바탕으로 최소 구성을 고르기 어렵다.

## 채택 여부

채택/보류/폐기 중 정확히 하나만 선택한다. 추가 실험 필요 여부는 후속 작업으로 분리해서 기록한다.

- [ ] 채택
- [x] 보류
- [ ] 폐기

## 채택/보류/폐기 이유

이 실험은 아직 전체 prompts lab 중간 단계이며, 문서 구조를 확정하는 단계가 아니다. 현재까지는 후보 문서들의 책임과 겹침 위험을 이해하는 데 도움이 되었지만, 실제 문서 채택 여부는 모든 실험이 끝난 뒤 결정하기로 했다. 따라서 `docs/decisions.md`, `docs/project-goal.md`, `PLANS.md` 같은 후보 문서는 도입 확정이 아니라 보류 상태로 남긴다.

## 다음 실험 프롬프트

```text
docs/prompts/004-skill-concepts.md를 튜터 모드로 실행해줘.
```

## 후속 작업

- [ ] 문서 갱신 필요
- [ ] AGENTS.md 반영 검토
- [ ] skill 후보 검토
- [ ] hook 후보 검토
- [x] 추가 실험 필요
- [ ] 추가 리서치 필요

후속 작업 메모:

`모든 prompts lab 실험이 완료된 뒤, 후보 문서들의 실제 채택 여부를 다시 판단한다. 다음 실험에서는 skill이 prompt, AGENTS.md, hook과 어떻게 다른지 이해한다.`
