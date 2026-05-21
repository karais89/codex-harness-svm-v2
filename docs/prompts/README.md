# Prompts Lab

이 폴더는 Safe Village Micro를 실제 구현하기 전에 Codex/LLM workflow를 이해하기 위한 실험 프롬프트 모음이다.

목표는 바로 게임을 만드는 것이 아니라, 작은 실험을 통해 AGENTS.md, PLANS.md, skills, hooks, MCP, plugin, subagents의 역할을 이해하고 이 프로젝트에 채택할 최소 구성을 고르는 것이다.

## 실행 모드

Prompts Lab은 두 가지 실행 모드를 사용한다.

### 일반 모드

빠른 설명, 비교, 판단 정리에 사용한다. Codex는 확인된 사실과 추측을 분리하고, 핵심 결론과 다음 실험 제안을 간결하게 남긴다.

### 튜터 모드

학습용 개념 실험에 사용한다. Codex는 바로 긴 설명을 시작하지 않고 먼저 시작 질문 1-3개를 던진 뒤, 개념 단위로 설명하고 teach-back으로 이해를 확인한다. 사용자가 헷갈린 부분은 다시 설명하고, 마지막에는 복습 질문 1개를 남긴다.

### 기본 모드

- 001-015 프롬프트: 튜터 모드
- 016-017 프롬프트: 일반 모드
- 모드를 생략하면 위 기본 모드로 실행한다.

사용 예:

```text
docs/prompts/001-llm-codex-structure.md를 튜터 모드로 실행해줘.
docs/prompts/008-unity-workflow.md를 일반 모드로 실행해줘.
docs/prompts/012-mcp-concepts.md를 실행해줘.
```

## 실행 순서

가장 쉬운 사용법은 프롬프트 본문을 직접 복사하지 않고, Codex에게 파일명과 실행 모드를 지정하는 것이다.

기본 흐름은 다음과 같다.

1. `docs/prompts/NNN-topic-name.md`에서 실행할 프롬프트를 고른다.
2. Codex에게 `이 파일을 튜터 모드로 실행해줘` 또는 `이 파일을 일반 모드로 실행해줘`라고 요청한다.
3. 실험 실행 단계에서는 Codex가 파일을 생성/수정하지 않는다.
4. 실행한 모든 실험은 `docs/prompt-results/NNN-topic-name.md`에 요약 기록을 남긴다.
5. 결과 기록 단계에서만 `docs/prompt-results/` 아래 파일 생성/수정이 허용된다.
6. 3-5개 실험마다 `016-midpoint-review.md`로 중간 정리를 한다.

## 일반 모드 Wrapper

일반 모드 wrapper는 빠른 설명, 비교, 판단 정리에 사용한다. 일반 사용 시 매번 직접 복사하지 말고, `일반 모드로 실행해줘`라고 요청한다.

```text
이 작업은 prompts lab 일반 모드 실험이다.
Safe Village Micro 구현으로 넘어가지 마라.
파일을 생성/수정하지 마라.
현재 repo 구조를 먼저 확인하고, 확인된 사실과 추측을 분리해서 답해라.
Unity gameplay code, Scene, Packages/manifest.json, ProjectSettings/는 건드리지 마라.
질문에 대해 빠르게 설명하고, 비교나 판단이 필요한 부분은 근거를 짧게 정리해라.
답변 끝에는 "다음에 실행할 만한 실험 1-2개"만 제안해라.
```

## 튜터 모드 Wrapper

튜터 모드 wrapper는 학습용 개념 실험에 사용한다. 일반 사용 시 매번 직접 복사하지 말고, `튜터 모드로 실행해줘`라고 요청한다.

```text
이 작업은 prompts lab 튜터 모드 실험이다.
Safe Village Micro 구현으로 넘어가지 마라.
파일을 생성/수정하지 마라.
현재 repo 구조를 먼저 확인하고, 확인된 사실과 추측을 분리해서 답해라.
Unity gameplay code, Scene, Packages/manifest.json, ProjectSettings/는 건드리지 마라.
바로 긴 설명을 시작하지 말고, 먼저 시작 질문 1-3개로 사용자의 현재 이해 수준을 확인해라.
개념을 한 번에 모두 설명하지 말고, 개념 단위로 나누어 설명해라.
각 주요 개념 뒤에는 사용자가 자기 말로 설명하게 하는 teach-back 질문을 포함해라.
사용자가 헷갈린 부분은 같은 표현을 반복하지 말고 다른 예시나 구조로 다시 설명해라.
마지막에는 핵심 요약과 복습 질문 1개를 남겨라.
답변 끝에는 "다음에 실행할 만한 실험 1-2개"만 제안해라.
```

## 결과 기록 프롬프트

실행한 실험은 반드시 요약 기록을 남긴다. 튜터 모드의 전체 대화 전문은 저장하지 않고 핵심 질문, 사용자 답변 요약, 이해 확인 결과만 기록한다.

```text
방금 실험 결과를 docs/prompt-results/NNN-topic-name.md에 기록해줘.

규칙:
- docs/prompt-results/000-template.md 형식을 따른다.
- 사용한 프롬프트 원문, 실행 모드, 실행 조건, Codex 응답 요약, 내가 이해한 점, 헷갈린 점, 위험 요소, 채택 여부를 채운다.
- 튜터 모드였다면 전체 대화 전문 대신 핵심 질문, 사용자 답변 요약, teach-back 결과 또는 아직 헷갈린 지점, 다음 복습 질문만 기록한다.
- Unity 파일은 수정하지 않는다.
- docs/prompt-results/ 아래 결과 파일만 생성 또는 수정한다.
```

## 결과 템플릿 사용법

- `docs/prompt-results/000-template.md`를 복사해서 대응되는 결과 파일을 만든다.
- 파일명은 프롬프트 파일과 같은 번호와 topic name을 사용한다.
- 예: `docs/prompts/001-llm-codex-structure.md` 실행 결과는 `docs/prompt-results/001-llm-codex-structure.md`에 기록한다.
- 대괄호 placeholder는 실제 내용으로 바꾼다.
- 해당 없는 항목은 비워두지 말고 `없음` 또는 `해당 없음`으로 적는다.

## 운영 규칙

- 기본값은 파일 수정 없음이다.
- 실험 실행 단계에서는 파일을 생성/수정하지 않는다.
- 결과 기록 파일을 만들 때만 `docs/prompt-results/` 수정이 허용된다.
- 실행한 모든 실험은 `docs/prompt-results/NNN-topic-name.md`에 요약 기록을 남긴다.
- 튜터 모드 결과는 전체 대화 전문이 아니라 핵심 질문, 사용자 답변 요약, 이해 확인 결과만 기록한다.
- Unity gameplay code, Scene, `Packages/manifest.json`, `ProjectSettings/`는 별도 승인 전 수정하지 않는다.
- `Assets/`, `Packages/`, `ProjectSettings/` 아래 파일은 실험 중 수정하지 않는다.
- Safe Village Micro 구현 계획이나 실제 구현으로 넘어가지 않는다.
- Codex 답변은 확인된 사실과 추측을 분리해서 평가한다.
- 실험 결과가 기록되기 전까지 skills, hooks, MCP, plugin은 채택하지 않는다.
- `docs/prompts-lab-plan.md`는 원래 계획 보존 문서로 유지한다.

## 프롬프트 목록

| 번호 | 기본 모드 | 프롬프트 파일 | 결과 파일 |
| --- | --- | --- | --- |
| 001 | 튜터 | `docs/prompts/001-llm-codex-structure.md` | `docs/prompt-results/001-llm-codex-structure.md` |
| 002 | 튜터 | `docs/prompts/002-agents-md.md` | `docs/prompt-results/002-agents-md.md` |
| 003 | 튜터 | `docs/prompts/003-docs-responsibility.md` | `docs/prompt-results/003-docs-responsibility.md` |
| 004 | 튜터 | `docs/prompts/004-skill-concepts.md` | `docs/prompt-results/004-skill-concepts.md` |
| 005 | 튜터 | `docs/prompts/005-skill-value-check.md` | `docs/prompt-results/005-skill-value-check.md` |
| 006 | 튜터 | `docs/prompts/006-hooks-concepts.md` | `docs/prompt-results/006-hooks-concepts.md` |
| 007 | 튜터 | `docs/prompts/007-llm-failure-modes.md` | `docs/prompt-results/007-llm-failure-modes.md` |
| 008 | 튜터 | `docs/prompts/008-unity-workflow.md` | `docs/prompt-results/008-unity-workflow.md` |
| 009 | 튜터 | `docs/prompts/009-project-structure.md` | `docs/prompt-results/009-project-structure.md` |
| 010 | 튜터 | `docs/prompts/010-custom-skill-draft.md` | `docs/prompt-results/010-custom-skill-draft.md` |
| 011 | 튜터 | `docs/prompts/011-matt-skills-review.md` | `docs/prompt-results/011-matt-skills-review.md` |
| 012 | 튜터 | `docs/prompts/012-mcp-concepts.md` | `docs/prompt-results/012-mcp-concepts.md` |
| 013 | 튜터 | `docs/prompts/013-plugin-concepts.md` | `docs/prompt-results/013-plugin-concepts.md` |
| 014 | 튜터 | `docs/prompts/014-execplan-plans.md` | `docs/prompt-results/014-execplan-plans.md` |
| 015 | 튜터 | `docs/prompts/015-subagents.md` | `docs/prompt-results/015-subagents.md` |
| 016 | 일반 | `docs/prompts/016-midpoint-review.md` | `docs/prompt-results/016-midpoint-review.md` |
| 017 | 일반 | `docs/prompts/017-final-selection.md` | `docs/prompt-results/017-final-selection.md` |
