# 011. Matt Skills 검토

## 목적

Matt Pocock skills를 설치하기 전에 Safe Village Micro에 도입할 가치와 위험을 검토한다.

## 실행 규칙

기본 실행 모드: 튜터 모드

Codex에게 `이 파일을 docs/prompts/README.md의 튜터 모드로 실행해줘`라고 요청한다. 모드를 생략해도 이 파일은 튜터 모드로 실행한다. 수동 실행할 때만 README의 튜터 모드 wrapper를 프롬프트 본문 앞에 붙인다.

## 결과 기록 위치

`docs/prompt-results/011-matt-skills-review.md`

## 프롬프트 본문

```text
Matt Pocock skills를 Safe Village Micro 프로젝트에 도입할지 검토하고 싶다.

목표:
설치가 아니라 이해와 선택이다.

해야 할 일:
1. Matt skills를 전부 설치하는 방식의 장단점
2. 일부만 선택하는 방식의 장단점
3. grill-me, grill-with-docs, handoff, write-a-skill이 이 프로젝트에 어떻게 도움이 되는지
4. 내 custom skill과 충돌할 가능성
5. AGENTS.md / PLANS.md / Matt skills / custom skills의 역할 분리
6. 지금 단계에서 설치 전 실험할 수 있는 프롬프트 제안

출력:
- 확인된 사실과 추측을 분리
- 바로 설치해도 되는 것
- 먼저 검토해야 하는 것
- 지금은 보류할 것
- 추천 실험 순서

파일 수정과 설치 명령 실행은 하지 마라.
```
