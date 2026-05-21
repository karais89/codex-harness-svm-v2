# 008. Unity 개발 Workflow 비교

## 목적

Codex를 사용하는 Unity 개발 workflow 후보들을 비교한다.

## 실행 규칙

기본 실행 모드: 튜터 모드

Codex에게 `이 파일을 docs/prompts/README.md의 튜터 모드로 실행해줘`라고 요청한다. 모드를 생략해도 이 파일은 튜터 모드로 실행한다. 수동 실행할 때만 README의 튜터 모드 wrapper를 프롬프트 본문 앞에 붙인다.

## 결과 기록 위치

`docs/prompt-results/008-unity-workflow.md`

## 프롬프트 본문

```text
Codex를 사용한 Unity 개발 workflow를 이해하고 싶다.

Safe Village Micro를 예시로 하되, 구현하지 말고 workflow만 설계해줘.

비교할 workflow:
1. 문서 없이 바로 구현
2. README + AGENTS만 두고 구현
3. PRD + ExecPlan 후 구현
4. skills/hooks까지 붙이고 구현
5. MCP까지 붙이고 구현

평가 기준:
- 속도
- 안전성
- 학습 가치
- Unity 오류 대응
- scope creep 방지
- 포트폴리오 설명 가능성

출력:
- 각 workflow의 장단점
- 내 상황에 맞는 추천 순서
- 지금 실험해야 할 것
- 나중에 미뤄야 할 것

중요:
- 이 비교는 가상의 workflow 비교이며 실제 구현 task를 만들지 않는다.
- Unity 작업 티켓, 파일 변경 계획, 마이그레이션 계획으로 확장하지 않는다.

파일 수정은 하지 마라.
```
