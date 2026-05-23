# 0001 - PRD, Issues, and Delivery ExecPlan Workflow

Status: proposed
Date: 2026-05-23
Tags: workflow, prd, issues, execplan

## Context

Safe Village Micro first playable은 현재 `docs/first-playable.md`를 범위 기준으로 두고, GitHub Issues `#2`부터 `#5`까지를 vertical slice 작업 큐로 둔다. `docs/first-playable-execplan.md`도 존재하지만, 이 문서가 PRD, issue queue, 구현 계획을 모두 먹어버리는 구조가 되면 issue와 ExecPlan의 역할이 흐려진다.

논의된 후보는 두 가지다.

첫 번째는 ExecPlan을 먼저 만들고, 그 안에서 `to-prd`, `to-issues`, 구현, 검증까지 모두 진행하는 방식이다. 이 방식은 자율 진행에는 강하지만, 승인 게이트가 흐려지고 한 문서에 계획과 구현이 과도하게 섞일 위험이 있다.

두 번째는 `to-prd`로 목표와 범위를 먼저 확정하고, `to-issues`로 실행 가능한 issue queue를 만든 뒤, 필요할 때만 그 issue queue를 끝내기 위한 Delivery ExecPlan을 만드는 방식이다. 이 방식은 문서 역할이 분리되고 issue 단위 실행이 쉬워진다.

이 decision은 아직 확정이 아니다. 다음 구현을 시작하기 전에, SVM의 기본 큰 작업 workflow를 어떤 순서로 둘지 논의하기 위한 초안이다.

## Decision

제안안은 다음과 같다.

큰 milestone이나 first playable급 작업은 기본적으로 다음 순서로 진행한다.

1. `to-prd`로 목표, 범위, 제외 범위, 완료 기준을 정한다.
2. `to-issues`로 PRD를 GitHub Issues 작업 큐로 분해한다.
3. issue queue를 기준으로 Delivery ExecPlan이 필요한지 판단한다.
4. Delivery ExecPlan이 필요하면 issue 실행 순서, issue 간 공유 규칙, 검증 evidence, scope drift 중단 기준을 기록한다.
5. 구현은 기본적으로 issue 단위로 진행한다.

이 구조에서 PRD, issue, ExecPlan의 역할은 다음처럼 나눈다.

```text
PRD = 무엇을 만들지
Issue = 이번에 어디까지 끝낼지
Delivery ExecPlan = issue queue를 어떤 순서와 검증 루프로 안전하게 끝낼지
```

ExecPlan 안에 `to-prd`와 `to-issues`를 넣을 수도 있다. 다만 이 경우 그 문서는 구현 ExecPlan이 아니라 planning/bootstrap ExecPlan으로 본다. planning/bootstrap ExecPlan은 PRD와 issue queue를 만든 뒤 구현 전 멈춰야 한다.

Delivery ExecPlan은 issue queue가 이미 만들어진 뒤에만 만든다. Delivery ExecPlan은 issue를 대체하지 않고, 여러 issue에 걸친 전체 맥락을 유지하는 기준 문서로 사용한다. 여기에는 domain rule 숫자, 성공/실패 경로, domain-first와 Unity UI thin adapter 경계, 검증 순서, 예상 위험, 진행 기록을 둔다.

따라서 기본 명령은 다음처럼 해석한다.

```text
#2를 docs/first-playable-execplan.md 기준으로 진행해줘.
```

이 명령은 `#2`만 실행한다. ExecPlan은 참조 기준이고, agent는 해당 issue의 acceptance criteria를 만족하는 범위에서 멈추고 보고한다.

반대로 다음 명령은 별도 의미를 가진다.

```text
docs/first-playable-execplan.md 전체를 끝까지 실행해줘.
```

이 명령은 `#2`부터 `#5`까지 이어서 진행해도 된다는 명시적 요청으로 본다.

작은 단일 issue는 ExecPlan 없이 진행할 수 있다. ExecPlan은 여러 단계 검증, 여러 파일 경계, 긴 세션, 중간 발견 기록, context-loss 방지가 실제로 필요할 때만 만든다.

## Consequences

이 방식을 채택하면 큰 작업의 승인 게이트가 명확해진다. PRD가 목표와 범위를 잠그고, issue가 실행 단위를 잠그며, ExecPlan은 실제로 필요한 경우에만 issue queue의 실행 운영 문서가 된다.

이 방식은 `ExecPlan -> to-issues`보다 가볍다. ExecPlan을 먼저 크게 쓰고 다시 issue로 쪼개는 중복을 줄이고, issue body와 ExecPlan이 서로 같은 내용을 길게 반복하는 문제를 피한다.

대신 Delivery ExecPlan이 언제 필요한지 매번 판단해야 한다. 모든 issue에 ExecPlan을 강제하면 다시 무거워진다. 반대로 모든 issue에서 ExecPlan을 생략하면 여러 issue에 걸친 domain rule drift, 검증 누락, context-loss가 발생할 수 있다.

만약 `#2`를 실행해 본 뒤 ExecPlan을 거의 읽지 않아도 문제가 없고, issue body와 `docs/first-playable.md`만으로 충분하다고 판단되면 이 decision은 `rejected`로 바꾸고 ExecPlan을 축소하거나 폐기한다.

만약 중간 context 손실, domain rule drift, 검증 누락이 실제로 발생하면 이 decision을 `accepted`로 바꾸고, `to-prd -> to-issues -> 필요 시 Delivery ExecPlan -> issue별 구현`을 SVM의 큰 작업 기본 workflow로 확정한다.

## Open Questions

- first playable의 기존 `docs/first-playable-execplan.md`는 Delivery ExecPlan으로 유지할 만큼 도움이 되는가, 아니면 너무 상세한 중복 문서인가?
- `#2` 실행 후에도 ExecPlan이 실제로 context-loss 방지에 도움이 되는가?
- 작은 issue와 큰 issue의 ExecPlan 필요 기준을 어디에 둘 것인가?
- final verification issue인 `#5`까지 끝난 뒤, 이 workflow를 다음 SVM milestone에도 유지할 가치가 있는가?
