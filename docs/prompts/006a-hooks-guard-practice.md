# 006a. Hooks Guard 실습

## 목적

실제 Codex hook을 활성화하지 않고, mock hook 입력 JSON과 작은 Python 스크립트로 "특정 상황에서 Codex tool 사용을 막거나 경고하는 방식"을 연습한다.

## 실행 규칙

기본 실행 모드: 튜터 모드

Codex에게 `이 파일을 docs/prompts/README.md의 튜터 모드로 실행해줘`라고 요청한다. 이 파일은 실습 프롬프트이므로, README의 실습 예외 규칙에 따라 `tmp/prompts-lab/006a-hooks-guard-practice/` 아래 파일 생성만 허용한다. 수동 실행할 때만 README의 튜터 모드 wrapper를 프롬프트 본문 앞에 붙인다.

## 결과 기록 위치

`docs/prompt-results/006a-hooks-guard-practice.md`

## 프롬프트 본문

```text
Codex hooks guard 실습을 하고 싶다.

목표:
- 실제 Codex hook을 만들거나 활성화하지 않는다.
- `.codex/config.toml`, `.codex/hooks/`, global config는 수정하지 않는다.
- mock hook 입력 JSON과 Python 스크립트만으로 hook이 특정 상황을 어떻게 막거나 경고하는지 이해한다.
- 최소 3개 상황을 실습한다. 더 좋은 상황이 있으면 이유를 설명하고 후보를 교체해도 된다.

먼저 시작 질문 1-2개로 내가 hook을 어떤 수준으로 이해하고 있는지, block과 warning 중 무엇이 헷갈리는지 확인해줘.

해야 할 일:
1. `docs/prompts/006-hooks-concepts.md`와 가능하면 `docs/prompt-results/006-hooks-concepts.md`를 확인한다.
2. 현재 repo 구조와 사용 가능한 로컬 실행 환경을 확인한다.
3. 다음 후보를 기본 후보로 삼되, 더 좋은 예시가 있으면 교체 이유를 먼저 설명한다.
   - `PreToolUse` path guard: `ProjectSettings/`, `Packages/manifest.json`, `Packages/packages-lock.json` 같은 Unity 보호 경로 변경을 mock 차단한다.
   - `Stop` verification guard: "수정/구현 완료"라고 말했지만 테스트/검증 언급이 없는 mock assistant message를 계속 진행하도록 만든다.
   - `UserPromptSubmit` scope guard: Prompts Lab 단계에서 Unity 구현으로 넘어가려는 mock prompt에 추가 context 또는 warning을 제공한다.
4. 각 후보마다 다음을 정리한다.
   - 상황
   - 막을 위험
   - hook 이벤트
   - 대상 tool 또는 입력 필드
   - block으로 둘지 warning/context로 둘지
   - 너무 과한 경우
5. 파일 생성이 필요하면 `tmp/prompts-lab/006a-hooks-guard-practice/` 아래에만 만든다.
6. 가능하면 다음 구조로 만든다.
   - `fixtures/`: mock hook 입력 JSON
   - `hooks/`: 학습용 Python hook 스크립트
   - `run_smoke_tests.py`: 각 fixture를 script stdin으로 넣어 결과를 확인하는 작은 runner
   - `README.md`: 만든 실습 구조와 실제 Codex hook과의 차이
7. 가능한 경우 외부 dependency 설치 없이 smoke test를 실행한다.
8. smoke test 결과에서 "차단됨", "경고/context 추가", "통과"를 구분한다.
9. 실제 Codex hook으로 활성화하려면 어떤 `.codex/config.toml` 설정이 추가로 필요한지 설명하되, 실제 설정 파일은 만들지 않는다.

허용:
- `tmp/prompts-lab/006a-hooks-guard-practice/` 아래 실습 파일 생성
- 로컬 smoke test 실행
- 결과 기록 단계에서 `docs/prompt-results/006a-hooks-guard-practice.md` 생성

금지:
- Unity 파일 수정
- `Assets/`, `Packages/`, `ProjectSettings/` 수정
- `.codex/`, global config, hook trust 설정 수정
- 실제 Codex hook 활성화
- dependency 설치
- 네트워크 사용
- 검증하지 않은 내용을 "실제 Codex hook으로 차단했다"고 표현하기

출력:
- 선택한 hook 후보 3개와 선택 이유
- 만든 실습 파일 구조 또는 만들지 못한 이유
- smoke test 결과
- mock 실습과 실제 Codex hook의 차이
- block과 warning/context를 나눈 기준
- 내가 이해해야 할 핵심 요약
- teach-back 질문 1개
- 다음에 실행할 만한 실험 1-2개
```
