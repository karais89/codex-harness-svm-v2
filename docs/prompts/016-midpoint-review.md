# 016. 중간 학습 정리

## 목적

진행한 prompts lab 결과를 바탕으로 이해한 점, 헷갈리는 점, 추가 실험이 필요한 항목을 정리한다.

## 실행 규칙

기본 실행 모드: 일반 모드

Codex에게 `이 파일을 docs/prompts/README.md의 일반 모드로 실행해줘`라고 요청한다. 모드를 생략해도 이 파일은 일반 모드로 실행한다. 수동 실행할 때만 README의 일반 모드 wrapper를 프롬프트 본문 앞에 붙인다.

## 결과 기록 위치

`docs/prompt-results/016-midpoint-review-YYYY-MM-DD.md`

같은 날 여러 번 실행하면 `-02`, `-03` suffix를 붙인다.

## 프롬프트 본문

```text
지금까지의 prompts lab 결과를 바탕으로 내가 무엇을 이해했고 무엇을 아직 헷갈려 하는지 정리해줘.

읽을 문서:
- docs/prompts/README.md
- docs/prompts/
- docs/prompt-results/ (우선 근거)

해야 할 일:
1. 내가 이해한 개념 목록
2. 아직 헷갈리는 개념 목록
3. 추가 실험이 필요한 항목
4. 실제 Safe Village Micro 개발에 채택할 후보
5. 보류할 후보
6. 다음 1-2개 실험 추천

중요:
- 새로운 구현 계획을 만들지 마라.
- docs/prompt-results/를 우선 근거로 사용해라.
- 누락된 결과 파일은 별도로 표시해라.
- 각 결론에는 근거 파일과 confidence(높음/중간/낮음)를 붙여라.
- 추측과 확인된 사실을 분리해라.
```
