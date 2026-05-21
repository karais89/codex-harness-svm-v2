# 009. Project Structure 논의

## 목적

Unity 프로젝트 위치, docs 구조, Codex가 읽기 쉬운 repo tree를 논의한다.

## 실행 규칙

기본 실행 모드: 튜터 모드

Codex에게 `이 파일을 docs/prompts/README.md의 튜터 모드로 실행해줘`라고 요청한다. 모드를 생략해도 이 파일은 튜터 모드로 실행한다. 수동 실행할 때만 README의 튜터 모드 wrapper를 프롬프트 본문 앞에 붙인다.

## 결과 기록 위치

`docs/prompt-results/009-project-structure.md`

## 프롬프트 본문

```text
Safe Village Micro repo 구조를 논의하고 싶다.

목표:
구현 전에 repo 구조, docs 구조, Unity project 위치를 결정하기 위한 토론이다.

현재 사실:
- Unity project는 repo root에 있다.
- repo root에는 Assets/, Packages/, ProjectSettings/가 있다.
- prompts 실험은 docs/prompts/와 docs/prompt-results/를 사용한다.
- 나중에 skills와 hooks를 추가할 수 있다.

해야 할 일:
1. 현재 root Unity 구조의 장단점 평가
2. Unity project를 repo root에 바로 두는 방식과 unity/SafeVillageMicro/ 하위에 두는 방식 비교
3. 지금 단계에서 구조를 옮기는 것이 좋은지 판단
4. docs/threads와 docs/prompt-results의 차이 정리
5. skills와 hooks를 어디에 두는 것이 좋은지 제안
6. Codex가 읽기 쉬운 추천 tree 제안

금지:
- 실제 폴더 생성하지 마라.
- 추천 tree는 개념 제안만 하며, 폴더 이동/생성/마이그레이션 계획으로 확장하지 마라.
- Unity 파일 수정하지 마라.
```
