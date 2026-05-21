# 012a. Mock MCP Tool 실습

## 목적

실제 Unity Editor 연동 없이, 아주 작은 mock tool을 통해 MCP가 "도구를 노출한다"는 감각을 얻는다.

## 실행 규칙

기본 실행 모드: 튜터 모드

Codex에게 `이 파일을 docs/prompts/README.md의 튜터 모드로 실행해줘`라고 요청한다. 이 파일은 실습 프롬프트이므로, README의 실습 예외 규칙에 따라 `tmp/prompts-lab/012a-mcp-mock-tool/` 아래 파일 생성만 허용한다. 수동 실행할 때만 README의 튜터 모드 wrapper를 프롬프트 본문 앞에 붙인다.

## 결과 기록 위치

`docs/prompt-results/012a-mcp-mock-tool.md`

## 프롬프트 본문

```text
작은 MCP mock tool 실습을 하고 싶다.

목표:
- Unity Editor 연동은 하지 않는다.
- MCP가 tool을 외부로 노출한다는 개념을 작은 예제로 이해한다.
- "hello" 또는 "repo 상태 요약" 수준의 아주 작은 tool만 다룬다.

먼저 시작 질문 1-2개로 내가 알고 있는 MCP 개념과 실습 기대치를 확인해줘.

해야 할 일:
1. 현재 repo 구조와 사용 가능한 로컬 실행 환경을 확인한다.
2. 이 실습에서 만들 mock tool의 최소 범위를 제안한다.
3. 파일 생성이 필요하면 `tmp/prompts-lab/012a-mcp-mock-tool/` 아래에만 만든다.
4. 가능하면 외부 dependency 설치 없이 실행 가능한 형태로 만든다.
5. 가능한 경우 로컬 smoke test를 실행한다.
6. 실제 MCP tool 호출로 검증한 것과, 단순 mock 또는 시뮬레이션으로 확인한 것을 명확히 구분한다.
7. Codex 세션에 실제 MCP server로 등록하려면 무엇이 추가로 필요한지 설명한다.

허용:
- `tmp/prompts-lab/012a-mcp-mock-tool/` 아래 실습 파일 생성
- 로컬 smoke test 실행
- 결과 기록 단계에서 `docs/prompt-results/012a-mcp-mock-tool.md` 생성

금지:
- Unity 파일 수정
- `Assets/`, `Packages/`, `ProjectSettings/` 수정
- `.codex/`, global config, MCP 등록 설정 수정
- dependency 설치
- 네트워크 사용
- 실제 Unity Editor 연동
- 검증하지 않은 내용을 "Codex가 MCP tool로 호출했다"고 표현하기

출력:
- 만든 것 또는 만들지 못한 이유
- smoke test 결과
- 실제 MCP와 mock의 차이
- 내가 이해해야 할 핵심 요약
- teach-back 질문 1개
- 다음에 실행할 만한 실험 1-2개
```
