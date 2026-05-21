# 018. AI Gap Map

## 목적

prompts lab 결과를 바탕으로 새 도구를 더 고르는 것이 아니라, Safe Village Micro를 구현하기 전에 필요한 AI 운영 능력을 계측 가능한 기준으로 정리한다.

## 실행 규칙

기본 실행 모드: 일반 모드

`017-final-selection` 결과를 `docs/prompt-results/017-final-selection.md`에 기록한 뒤 실행한다.

Codex에게 `이 파일을 docs/prompts/README.md의 일반 모드로 실행해줘`라고 요청한다. 모드를 생략해도 이 파일은 일반 모드로 실행한다. 수동 실행할 때만 README의 일반 모드 wrapper를 프롬프트 본문 앞에 붙인다.

## 결과 기록 위치

`docs/prompt-results/018-ai-gap-map.md`

## 프롬프트 본문

```text
prompts lab의 모든 결과를 바탕으로 Safe Village Micro 구현 전에 필요한 AI 운영 능력을 AI Gap Map으로 평가해줘.

읽을 문서:
- docs/prompts/README.md
- docs/prompts/
- docs/prompt-results/ 전체
- docs/decisions.md (있으면)
- docs/progress.md (있으면)

중요:
- 새 도구를 더 고르는 것이 목적이 아니다.
- 구현 계획을 만들지 마라.
- Safe Village Micro 구현 task로 넘어가지 마라.
- Unity gameplay code, Scene, Packages/manifest.json, ProjectSettings/는 수정하지 마라.
- docs/ai-gap-map.md, docs/workflow-metrics.md, docs/ai-mistakes.md 같은 운영 문서를 만들지 마라. 이번 출력에서는 후보만 제안한다.
- 확인된 사실과 추정을 분리해라.
- 각 판단에는 근거 파일과 confidence(높음/중간/낮음)를 붙여라.

평가 기준:
1. AI에게 작업을 위임하는 능력
2. 프로젝트 컨텍스트를 정리하는 능력
3. AI 결과를 검증하는 능력
4. Unity 씬/프리팹/컴포넌트 변경을 통제하는 능력
5. 플레이 가능한 작은 게임을 끝까지 완성하는 능력
6. 과정을 포트폴리오/이력서 언어로 바꾸는 능력

점수 기준:
- 0 = 모른다 / 해본 적 없다
- 1 = 개념은 안다
- 2 = 한 프로젝트에서 써봤다
- 3 = 두 번 이상 반복했고 결과와 실패 사례를 기록했다

출력:
1. AI Gap Map 0-3점 평가
   - 기준
   - 점수
   - 확인된 사실
   - 추정
   - 근거 파일
   - confidence
2. 점수별 근거 파일
   - 0점 근거 또는 누락
   - 1점 근거
   - 2점 근거
   - 3점 근거
3. 부족한 운영 능력
4. 다음 Safe Village Micro 구현 전에 측정할 지표
5. 채택할 계측 문서 후보
6. 보류할 계측 문서 후보
7. 포트폴리오 증거로 전환 가능한 항목

답변 형식:
- "확인된 사실" 섹션과 "추정" 섹션을 분리해라.
- 평가 표에는 6개 기준을 모두 포함해라.
- 근거가 부족한 항목은 점수를 높게 주지 말고, 누락된 결과 파일이나 불충분한 기록을 명시해라.
- 마지막에는 다음 작업을 1-3개만 제안하되, 구현 계획이 아니라 기록/계측/governance 작업으로 제한해라.
```
