# Decision Policy

## 기본 원칙

장기 결정은 단일 `docs/decisions.md`에 누적하지 않는다.

결정 기록이 필요하면 `docs/decisions/` 폴더에 결정별 파일을 만들고, `docs/decisions/index.md`를 함께 갱신한다.

## 언제 기록하나

다음 조건을 모두 만족할 때만 decision 파일을 만든다.

- 한 작업이나 한 ExecPlan을 넘어 유지될 결정이다.
- 나중에 왜 그렇게 했는지 다시 확인할 가능성이 높다.
- `AGENTS.md`, `.agent/PLANS.md`, `docs/agents/*.md`, PRD, issue, ExecPlan 중 적절한 위치에만 두면 찾기 어렵다.

다음은 decision 파일로 만들지 않는다.

- 사소한 작업 판단
- 임시 논의
- 이미 PRD, issue, ExecPlan에 충분히 들어간 작업 내부 결정
- 아직 확정되지 않은 후보나 아이디어

## 파일 구조

```text
docs/decisions/
  index.md
  0001-short-title.md
  0002-short-title.md
```

## `index.md` 규칙

`docs/decisions/index.md`는 decision 본문을 복사하지 않는 라우팅 문서다.

새 decision 파일을 만들거나 상태를 바꾸면 반드시 `index.md`도 갱신한다.

`index.md`에는 다음만 둔다.

- ID
- Status
- Date
- Tags
- Title
- 한 줄 Summary
- 파일 링크

본문, 긴 근거, 회고, 대화 요약은 `index.md`에 넣지 않는다.

## Decision 파일 형식

각 decision 파일은 다음 최소 형식을 사용한다.

```md
# 0001 - Short Title

Status: accepted
Date: YYYY-MM-DD
Tags: docs, workflow

## Context

## Decision

## Consequences
```

## 상태 값

- `proposed`: 아직 확정 전
- `accepted`: 채택됨
- `superseded`: 다른 decision으로 대체됨
- `rejected`: 검토 후 폐기됨

## AGENTS.md와의 관계

`AGENTS.md`에는 이 정책 파일 링크만 둔다. Decision 기록 규칙 본문을 `AGENTS.md`에 복사하지 않는다.
