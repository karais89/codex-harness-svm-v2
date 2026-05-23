# AGENTS.md

## Base Principles

기본 코딩 행동 원칙은 `docs/references/karpathy-guidelines.md`를 기준으로 한다.

## Language

- 새로 작성하는 프로젝트 문서와 작업 보고는 한국어로 작성한다.
- PRD, ExecPlan, GitHub Issue 제목/본문/코멘트도 프로젝트 작업 문서로 보고 한국어로 작성한다.
- 코드 식별자, 명령어, 경로, 외부 원문 제목은 필요한 경우 영어를 유지한다.

## ExecPlans

When writing complex features or significant refactors, use an ExecPlan (as described in .agent/PLANS.md) from design to implementation.

- 큰 작업, 여러 단계 검증이 필요한 작업, 위험한 Unity asset/config 변경에는 `.agent/PLANS.md`의 ExecPlan 기준을 따른다.
- 사소한 수정이나 명확한 단일 변경에는 ExecPlan을 만들지 않는다.

## Matt Skills

- Matt skills 설정이 완료된 뒤에는 PRD, issues, triage, domain 규칙을 `docs/agents/*.md`에서 확인한다.
- GitHub Issues를 1순위 issue tracker 후보로 보고, local markdown은 fallback으로만 본다.

## Unity MCP

- Unity Editor 자동화에는 smoke gate를 통과한 `IvanMurzak/Unity-MCP`를 사용할 수 있다.
- Scene, prefab, UI, asset, ProjectSettings 변경은 MCP tool output, Console log, screenshot, Play Mode 중 적절한 증거로 검증한다.
- Gameplay rule과 핵심 상태 전이는 C# 코드와 문서 기준으로 판단한다.

## Gameplay Implementation

- Safe Village Micro first playable은 순수 C# domain first, Unity UI thin adapter 방식으로 구현한다.
- 하루 루프와 자원/주민/판정 규칙은 MonoBehaviour나 UI 컴포넌트가 아니라 domain 코드에 둔다.

## AI Mistake Guardrails

재발하면 안 되는 AI 실수 guardrail은 `docs/agents/ai-mistakes.md`를 따른다.

## Agent skills

### Issue tracker

이 repo의 issues와 PRD는 GitHub Issues에서 관리한다. See `docs/agents/issue-tracker.md`.

### Triage labels

기본 5개 triage label vocabulary를 그대로 사용한다. See `docs/agents/triage-labels.md`.

### Domain docs

Single-context layout을 사용한다. See `docs/agents/domain.md`.

## Commit Policy

작업 완료 후 커밋 기준은 `docs/agents/commit-policy.md`를 따른다.

## Decision Policy

장기 결정 기록 기준은 `docs/agents/decision-policy.md`를 따른다.

## Parallel Work

- 병렬 Codex 작업이 필요하면 별도 branch 또는 git worktree와 GitHub Issue/PR 범위로 조정한다.
- 같은 Unity scene, asset, prefab, ProjectSettings를 동시에 수정하지 않는다.
