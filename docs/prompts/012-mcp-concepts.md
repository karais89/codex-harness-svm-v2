# 012. MCP 개념 이해

## 목적

Unity 프로젝트에서 MCP가 필요한 순간과 아직 필요하지 않은 순간을 구분한다.

## 실행 규칙

기본 실행 모드: 튜터 모드

Codex에게 `이 파일을 docs/prompts/README.md의 튜터 모드로 실행해줘`라고 요청한다. 모드를 생략해도 이 파일은 튜터 모드로 실행한다. 수동 실행할 때만 README의 튜터 모드 wrapper를 프롬프트 본문 앞에 붙인다.

## 결과 기록 위치

`docs/prompt-results/012-mcp-concepts.md`

## 프롬프트 본문

```text
MCP를 이해하고 싶다.

Unity 프로젝트에서 Codex를 사용할 때 MCP가 왜 필요한지, 언제 필요하지 않은지 설명해줘.

다음을 구분해줘.

1. Codex가 repo 파일만 읽어도 되는 작업
2. Unity Editor 상태를 알아야 하는 작업
3. 외부 문서나 툴 접근이 필요한 작업
4. MCP가 있으면 좋은 작업
5. MCP 없이 먼저 실험해야 하는 작업
6. custom MCP tool을 만들 가치가 있는 작업

출력:
- MCP의 역할
- Unity 개발에서 MCP 후보
- 지금은 보류해야 하는 이유
- 나중에 실험할 순서
- 첫 custom MCP tool 후보 3개

파일 수정과 MCP 설정은 하지 마라.
```
