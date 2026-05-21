# 010. Custom Skill 초안 생성

## 목적

실제 파일 생성 없이 custom skill의 구조와 위험을 초안으로 이해한다.

## 실행 규칙

기본 실행 모드: 튜터 모드

Codex에게 `이 파일을 docs/prompts/README.md의 튜터 모드로 실행해줘`라고 요청한다. 모드를 생략해도 이 파일은 튜터 모드로 실행한다. 수동 실행할 때만 README의 튜터 모드 wrapper를 프롬프트 본문 앞에 붙인다.

## 결과 기록 위치

`docs/prompt-results/010-custom-skill-draft.md`

## 프롬프트 본문

```text
이번에는 실제 파일을 만들지 말고, custom skill 초안만 작성해줘.

대상 skill:
unity-micro-scope-guard

목적:
Safe Village Micro가 본게임 수준으로 커지는 것을 막고, Codex가 Unity 구현 전에 scope를 줄이도록 돕는 skill.

해야 할 일:
1. 이 skill이 필요한 이유 설명
2. 사용되어야 하는 상황
3. 사용되면 안 되는 상황
4. SKILL.md front matter 초안
5. instruction 본문 초안
6. 예상되는 오작동
7. 이 skill을 AGENTS.md 규칙으로 대체할 수 있는지 평가

중요:
- 파일 생성하지 마라.
- 실제 구현하지 마라.
- 내가 skill 구조를 이해하는 것이 목적이다.
```
