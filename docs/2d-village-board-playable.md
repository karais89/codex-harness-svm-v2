# 2D 마을 보드 Playable 미니 PRD

상태: 승인됨
날짜: 2026-05-23

## 목적

현재 first playable은 하루 생존 루프를 검증하지만, 화면 경험은 게임보다 UI 검증물에 가깝다. 이 개선은 기존 domain rule을 유지하면서 `SafeVillageMicro`를 2D 마을 보드 playable로 바꾸는 것이다.

## 현재 합의

- 기존 하루 생존 루프와 `Forage`, `Guard`, `Repair` 규칙은 유지한다.
- 새 gameplay rule, 새 자원, 주민 능력, 스토리 이벤트는 추가하지 않는다.
- 화면은 고정 한 화면 마을 보드로 구성한다.
- 주민 배치는 클릭 선택 배치로 조작한다.
- 작업 장소는 `Forage`, `Guard`, `Repair`를 나타내는 세 곳으로 둔다.
- 주민은 이름과 능력 차이가 없는 동일한 주민 토큰 3개로 표현한다.
- 결과 피드백은 로그보다 보드 변화가 우선이다.
- 간단한 보드 피드백 애니메이션은 포함한다.
- 구현은 Unity UI 도형, 색, 텍스트를 먼저 사용한다.
- DOTween 같은 tween dependency는 필요할 때 설치할 수 있지만, 처음부터 필수 전제로 두지는 않는다.
- 단, 방향성을 잡기 위한 컨셉 아트 이미지 1장은 만든다.
- 컨셉 아트 이미지는 Unity에 바로 넣는 runtime asset이 아니라 보드 레이아웃과 분위기 기준을 잡는 reference image로 둔다.
- 컨셉 아트 이미지는 `docs/references/2d-village-board-concept.png`에 둔다.
- 컨셉 아트는 탑다운 또는 살짝 비스듬한 2D 보드게임 화면으로 만들며, `HUD`, 세 작업 장소, 주민 토큰, 벽과 마을 중심부가 보이게 한다.

## 제외 범위

- 드래그 앤 드롭
- 3D 마을
- 캐릭터 애니메이션
- 복잡한 연출 시퀀스
- 새 자원
- 주민별 능력
- 스토리 이벤트
- 장기 캠페인
- 복잡한 아트 에셋 제작

## 최소 화면 기준

- `Day`, `Food`, `Wall`, `Outcome`을 보여주는 HUD
- 주민 토큰 3개
- `Forage` 작업 장소
- `Guard` 작업 장소
- `Repair` 작업 장소
- `Resolve Day`, `Restart` 조작

## 최소 애니메이션 기준

- 주민 토큰이 배치 장소로 짧게 이동하거나 강조된다.
- `Food` 또는 `Wall` 숫자나 막대가 바뀔 때 짧게 강조된다.
- `Victory` 또는 `Failure`가 보드 중앙에 짧게 나타난다.

## 완료 기준

- Play Mode에서 주민 토큰을 클릭하고 작업 장소를 클릭해 주민 배치를 바꿀 수 있다.
- Play Mode에서 `Resolve Day`를 실행하면 기존 domain rule에 맞게 하루 생존 루프가 진행된다.
- 하루 결과는 로그보다 보드 변화로 먼저 이해할 수 있다.
- Victory 또는 Failure에 도달하면 보드 중앙에 terminal outcome이 표시된다.
- Game View screenshot에서 HUD, 작업 장소 3곳, 주민 토큰 3개, 보드 중앙 결과 영역이 보인다.
- 최종 검증 run에서 Unity Console Error와 Exception이 없다.

## 검증 방식

- Domain rule은 기존 `SafeVillage.Core.Tests`를 유지한다.
- Play Mode에서 `주민 선택 -> 장소 배치 -> Resolve Day -> 보드 피드백 -> Victory/Failure 중 하나 도달` 흐름을 검증한다.
- Unity MCP 또는 수동 확인으로 Game View screenshot을 남긴다.
- Console Error와 Exception log를 확인한다.

## 진행 방식

이 개선은 하나의 큰 구현으로 바로 진행하지 않고, mini PRD를 확정한 뒤 GitHub Issues로 나누어 진행한다.

초기 issue 분해 후보는 다음과 같다.

1. 컨셉 아트 reference 생성 및 보드 레이아웃 확정
2. 기존 Runtime UI를 2D 마을 보드 구조로 교체
3. 클릭 선택 배치와 간단한 피드백 애니메이션 검증
