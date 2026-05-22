# Domain Docs

Engineering skills가 이 repo의 domain documentation을 읽는 기준이다.

## Layout

이 repo는 single-context layout을 사용한다.

- Root `CONTEXT.md`: repo 전체 domain language와 glossary
- `docs/adr/`: 장기 architecture decision records

현재 파일이 없으면 조용히 진행한다. 파일 부재 자체를 문제로 보고하지 않고, terms나 decisions가 실제로 정리될 때 producer workflow가 lazy-create한다.

## Before exploring, read these

- Root `CONTEXT.md`
- 작업 영역과 관련된 `docs/adr/` 문서

## Use the glossary's vocabulary

Issue title, refactor proposal, hypothesis, test name에서 domain concept를 부를 때는 `CONTEXT.md`에 정의된 용어를 우선 사용한다.

필요한 concept가 glossary에 없으면 둘 중 하나로 본다.

- 프로젝트가 쓰지 않는 말을 새로 만들고 있을 수 있으므로 재검토한다.
- 실제 gap일 수 있으므로 `/grill-with-docs`에서 정리할 후보로 기록한다.

## Flag ADR conflicts

기존 ADR과 충돌하는 출력이 필요하면 조용히 덮어쓰지 말고 충돌을 명시한다.
