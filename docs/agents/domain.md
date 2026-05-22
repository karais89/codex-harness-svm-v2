# Domain Docs

Engineering skills가 이 repo의 domain documentation을 읽는 기준이다.

## Layout

이 repo는 single-context layout으로 다룬다.

- `README.md`: 사람용 현재 상태와 진입점
- `docs/first-playable.md`: Safe Village Micro first playable의 gameplay 용어, 범위, 완료 기준
- `docs/bootstrap-plan.md`: bootstrap 단계에서만 쓰는 전환 계획과 진행 상태
- `docs/decisions/`: 장기 결정 기록. 필요할 때만 만들고 `docs/decisions/index.md`를 함께 갱신한다.

Matt skills 문서에서 `ADR` 또는 `docs/adr/`를 언급하면, 이 repo에서는 `docs/agents/decision-policy.md`의 `docs/decisions/` 규칙으로 해석한다.

`CONTEXT.md` 또는 `CONTEXT-MAP.md`는 기본 필수 파일이 아니다. 나중에 `/grill-with-docs` 같은 producer workflow가 실제 glossary gap을 해결하기 위해 만들면 그때부터 참고한다. 파일 부재 자체를 문제로 보고하지 않는다.

## Before exploring, read these

- `README.md`
- 작업이 gameplay first playable에 닿으면 `docs/first-playable.md`
- bootstrap 운영 결정에 닿으면 `docs/bootstrap-plan.md`
- 장기 결정과 충돌 가능성이 있으면 `docs/agents/decision-policy.md`와, 존재하는 경우 `docs/decisions/index.md`

## Use the project vocabulary

Issue title, refactor proposal, hypothesis, test name에서 domain concept를 부를 때는 `docs/first-playable.md`의 용어를 우선 사용한다.

현재 핵심 gameplay 용어는 `Food`, `Wall`, `Villagers`, `Forage`, `Guard`, `Repair`, `DayStart`, `Assignment`, `DayAction`, `NightCheck`, `DayEnd`다.

필요한 concept가 문서에 없으면 둘 중 하나로 본다.

- 프로젝트가 쓰지 않는 말을 새로 만들고 있을 수 있으므로 재검토한다.
- 실제 gap일 수 있으므로 `/grill-with-docs`에서 정리할 후보로 기록한다.

## Flag decision conflicts

기존 decision 또는 bootstrap 결정과 충돌하는 출력이 필요하면 조용히 덮어쓰지 말고 충돌을 명시한다.
