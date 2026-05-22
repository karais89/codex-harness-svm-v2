# 0001 - Issue Execution Slices and ExecPlan Context

Status: proposed
Date: 2026-05-23
Tags: workflow, execplan, issues

## Context

Safe Village Micro first playable은 현재 `docs/first-playable.md`를 범위 기준으로 두고, `docs/first-playable-execplan.md`를 전체 구현 계획으로 두며, GitHub Issues `#2`부터 `#5`까지를 vertical slice 작업 큐로 둔다.

이 구조에는 헷갈릴 수 있는 지점이 있다. `ExecPlan`을 "한 번에 끝까지 실행하는 문서"로 보면 issue 분해가 중복처럼 보인다. 반대로 issue만 실제 작업 단위로 쓰면 ExecPlan이 꼭 필요한지 의문이 생긴다.

이 decision은 아직 확정이 아니다. 다음 구현을 시작하기 전에, issue와 ExecPlan의 역할을 계속 분리할지, 아니면 더 가볍게 issue 중심으로 줄일지 논의하기 위한 초안이다.

## Decision

제안안은 다음과 같다.

GitHub Issue는 기본 실행 단위로 사용한다. 사용자가 `#2를 진행해줘`처럼 특정 issue를 지시하면, agent는 해당 issue의 acceptance criteria를 만족하는 범위에서 멈추고 보고한다.

ExecPlan은 여러 issue에 걸친 전체 맥락을 유지하는 기준 문서로 사용한다. 여기에는 domain rule 숫자, 성공/실패 경로, domain-first와 Unity UI thin adapter 경계, 검증 순서, 예상 위험, 진행 기록을 둔다.

따라서 기본 명령은 다음처럼 해석한다.

```text
#2를 docs/first-playable-execplan.md 기준으로 진행해줘.
```

이 명령은 `#2`만 실행한다. ExecPlan은 참조 기준이다.

반대로 다음 명령은 별도 의미를 가진다.

```text
docs/first-playable-execplan.md 전체를 끝까지 실행해줘.
```

이 명령은 `#2`부터 `#5`까지 이어서 진행해도 된다는 명시적 요청으로 본다.

## Consequences

이 방식을 채택하면 작업 범위 통제가 쉬워진다. 각 issue가 이번 턴의 완료 조건을 정하고, ExecPlan은 여러 issue 사이에서 흔들리면 안 되는 규칙을 보존한다.

대신 문서 두 종류를 유지해야 한다. issue와 ExecPlan이 같은 내용을 길게 반복하면 유지 비용이 커지고, 둘이 어긋날 수 있다. 따라서 issue에는 해당 slice의 acceptance criteria만 두고, 반복되는 domain rule과 검증 철학은 ExecPlan에 둔다.

만약 `#2`를 실행해 본 뒤 ExecPlan을 거의 읽지 않아도 문제가 없고, issue body와 `docs/first-playable.md`만으로 충분하다고 판단되면 이 decision은 `rejected`로 바꾸고 ExecPlan을 축소하거나 폐기한다.

만약 중간 context 손실, domain rule drift, 검증 누락이 실제로 발생하면 이 decision을 `accepted`로 바꾸고, "issue별 실행 + ExecPlan 참조"를 SVM first playable의 기본 운영 방식으로 확정한다.

## Open Questions

- `#2` 실행 후에도 ExecPlan이 실제로 context-loss 방지에 도움이 되는가?
- issue body가 충분히 자세해지면 ExecPlan이 중복 문서가 되는가?
- final verification issue인 `#5`까지 끝난 뒤, 이 방식을 다음 SVM milestone에도 유지할 가치가 있는가?
