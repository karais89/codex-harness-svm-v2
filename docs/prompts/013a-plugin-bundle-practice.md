# 013a. Plugin Bundle 실습

## 목적

실제 설치나 배포 없이, 작은 skill과 mock MCP 설명을 묶어 plugin이 "재사용 가능한 패키지"라는 점을 이해한다.

## 실행 규칙

기본 실행 모드: 튜터 모드

Codex에게 `이 파일을 docs/prompts/README.md의 튜터 모드로 실행해줘`라고 요청한다. 이 파일은 실습 프롬프트이므로, README의 실습 예외 규칙에 따라 `tmp/prompts-lab/013a-plugin-bundle-practice/` 아래 파일 생성만 허용한다. 수동 실행할 때만 README의 튜터 모드 wrapper를 프롬프트 본문 앞에 붙인다.

## 결과 기록 위치

`docs/prompt-results/013a-plugin-bundle-practice.md`

## 프롬프트 본문

```text
작은 plugin bundle 실습을 하고 싶다.

목표:
- 실제 plugin 설치나 배포는 하지 않는다.
- plugin이 skill, MCP, 설정, 문서를 묶는 패키지라는 점을 이해한다.
- 작은 skill 1개와 mock MCP 설명 또는 placeholder를 묶는 수준으로 제한한다.

먼저 시작 질문 1-2개로 내가 plugin을 어떤 용도로 이해하고 있는지 확인해줘.

해야 할 일:
1. `docs/prompts/013-plugin-concepts.md`와 가능하면 `docs/prompt-results/013-plugin-concepts.md`를 확인한다.
2. `012a-mcp-mock-tool` 실습 결과가 있으면 참고하고, 없으면 없는 상태로 진행한다고 명시한다.
3. 만들 plugin bundle의 최소 범위를 제안한다.
4. 파일 생성이 필요하면 `tmp/prompts-lab/013a-plugin-bundle-practice/` 아래에만 만든다.
5. plugin 초안에는 최소한 다음을 포함한다.
   - plugin의 목적을 설명하는 README
   - 작은 skill 초안 1개
   - mock MCP server 또는 MCP 연결 설명 placeholder
   - plugin manifest 초안
6. manifest 형식이 현재 Codex plugin 형식과 확실히 일치하는지 확인할 수 없으면 "설치 가능한 plugin"이라고 말하지 말고 "학습용 초안"이라고 표시한다.
7. 가능하면 JSON이나 Markdown 형식만 로컬에서 검증한다.
8. 실제 plugin으로 설치하려면 무엇이 추가로 필요한지 설명한다.

허용:
- `tmp/prompts-lab/013a-plugin-bundle-practice/` 아래 실습 파일 생성
- 로컬 형식 검증
- 결과 기록 단계에서 `docs/prompt-results/013a-plugin-bundle-practice.md` 생성

금지:
- Unity 파일 수정
- `Assets/`, `Packages/`, `ProjectSettings/` 수정
- `.codex/`, global config, plugin registry, marketplace 파일 수정
- 실제 plugin 설치 또는 등록
- dependency 설치
- 네트워크 사용
- 검증하지 않은 초안을 "설치 가능한 plugin"이라고 표현하기

출력:
- 만든 bundle 구조
- skill, MCP placeholder, manifest가 각각 어떤 역할인지 설명
- 실제 plugin과 학습용 초안의 차이
- 내가 이해해야 할 핵심 요약
- teach-back 질문 1개
- 다음에 실행할 만한 실험 1-2개
```
