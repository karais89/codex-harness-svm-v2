# 004. Skill 개념 이해

## 목적

Codex skill이 prompt, AGENTS.md, hook과 어떻게 다른지 이해한다.

## 실행 규칙

기본 실행 모드: 튜터 모드

Codex에게 `이 파일을 docs/prompts/README.md의 튜터 모드로 실행해줘`라고 요청한다. 모드를 생략해도 이 파일은 튜터 모드로 실행한다. 수동 실행할 때만 README의 튜터 모드 wrapper를 프롬프트 본문 앞에 붙인다.

## 결과 기록 위치

`docs/prompt-results/004-skill-concepts.md`

## 프롬프트 본문

```text
Codex skill의 개념을 이해하고 싶다.

다음을 설명해줘.

1. skill은 일반 prompt와 무엇이 다른가?
2. skill은 AGENTS.md와 무엇이 다른가?
3. skill은 언제 자동으로 선택되는가?
4. SKILL.md의 name과 description은 왜 중요한가?
5. instruction-only skill과 script가 포함된 skill은 어떻게 다른가?
6. Unity 개발 workflow에서 skill로 만들 만한 것과 만들면 안 되는 것은 무엇인가?
7. Safe Village Micro 프로젝트에서 skill 후보를 5개 제안해줘.

중요:
- 파일 수정은 하지 마라.
- 실제 skill 생성은 하지 마라.
- 먼저 개념 이해에 집중해줘.
```
