# Prompt Result: 009. Project Structure 논의

## 실험 번호

`009`

## 실험 주제

`Project Structure 논의`

## 실행 일시

`2026-05-21 22:37 KST`

## 실행 모드

일반/튜터 중 정확히 하나만 선택한다.

- [ ] 일반
- [x] 튜터

## 사용자 명령

```text
'/Users/kaya/Documents/Codex/codex-harness-svm-v2/docs/prompts/009-project-structure.md' 튜터 모드로 실행
```

## 적용한 실행 모드 wrapper

```text
docs/prompts/README.md의 튜터 모드 wrapper를 적용했다.

- Safe Village Micro 구현으로 넘어가지 않음.
- 실험 실행 단계에서는 파일을 생성/수정하지 않음.
- 현재 repo 구조를 먼저 확인하고, 확인된 사실과 추측을 분리함.
- Unity gameplay code, Scene, Packages/manifest.json, ProjectSettings/를 수정하지 않음.
- 바로 긴 설명을 시작하지 않고 시작 질문으로 현재 이해 수준을 확인함.
- 개념 단위로 나누어 설명하고 teach-back 질문으로 이해를 확인함.
- 마지막에는 핵심 요약, 복습 질문 1개, 다음 실험 제안 순서로 마무리함.
```

## 참조한 프롬프트 파일

`docs/prompts/009-project-structure.md`

## 모델/클라이언트/실행 환경

- 모델: `GPT-5 계열 Codex, 세부 모델명 확인 불가`
- 클라이언트: `Codex coding agent`
- 실행 환경: `macOS zsh, repo root /Users/kaya/Documents/Codex/codex-harness-svm-v2, KST`

## 실행 조건

- 파일 수정 허용 여부: `실험 실행 단계 파일 수정 금지, 기록 단계에서 docs/prompt-results/009-project-structure.md 생성 허용`
- 사용한 skill/tool: `shell로 현재 repo 구조, docs/prompts/README.md, docs/prompt-results/000-template.md 확인, apply_patch로 결과 파일 생성`
- 별도 제약: `Unity 파일 수정 금지, 실제 폴더 생성 금지, Unity project 이동/마이그레이션 계획으로 확장하지 않기`

## Codex 응답 요약

Codex는 처음에 `docs/threads` 같은 대화 기록 폴더를 제안했지만, 사용자는 `docs/prompts`와 `docs/prompt-results`가 실제 프로젝트 문서가 아니라 실험 문서라는 점을 지적했다. 이후 실험 문서는 `docs/` 밖의 `experiments/codex-workflow/`로 격리하고, `docs/`는 실제 프로젝트 문서만 담는 방향으로 정리했다. 미래 반복 구조는 여러 프로젝트를 한 repo에서 관리하는 형태가 아니라, 하나의 프로젝트를 크게 관리하는 master repo로 보는 것이 맞다고 판단했다. 최종 후보는 번호가 붙은 실무형 문서 구조인 `docs/00-brief`, `docs/10-design`, `docs/20-art`, `docs/30-production`, `docs/40-engineering`, `docs/90-decisions`로 좁혔다.

## 튜터 모드 상호작용 요약

일반 모드 실행이면 모든 항목에 `해당 없음`을 적는다. 튜터 모드 실행이면 전체 대화 전문을 붙여넣지 말고 핵심만 요약한다.

### Codex가 한 확인 질문

- 현재 가장 결정하고 싶은 것이 Unity project 위치인지, docs 구조인지, Codex가 읽기 쉬운 tree인지, skills/hooks 위치인지 물었다.
- repo root에 Unity project가 바로 있는 구조가 단순해서 좋은지, docs와 Unity 파일이 섞여 불안한지 물었다.
- `docs/threads`가 있다면 어떤 용도로 상상하는지 물었다.
- 미래 master repo가 한 게임을 크게 관리하는 repo인지, 여러 게임/프로토타입을 관리하는 repo인지 물었다.
- 번호형 docs 구조에서 `90-decisions`가 뒤에 있는 이유를 복습 질문으로 물었다.

### 사용자 답변 요약

- 사용자는 우선순위를 docs 구조와 Codex가 읽기 쉬운 tree 쪽으로 잡았다.
- 현재 Unity project가 root에 있는 것은 크게 상관없지만, 원래는 기획, 아트, 스케줄 관리 등을 포함하는 master project 아래에 Unity 폴더를 두는 구상도 있었다고 답했다.
- 다만 Unity를 하위 폴더로 두면 Codex 세션을 repo root에서 열지 Unity 폴더에서 열지 애매해진다고 말했다.
- `docs/threads`라는 이름과 개념은 마음에 들지 않는다고 했고, `docs/prompts`와 `docs/prompt-results`는 현재 완전히 실험용 폴더라고 정정했다.
- 실험 문서는 `docs/`가 아니라 `experiments/`로 분리하는 쪽이 맞고, 이유는 다른 프로젝트에서 재사용할 표준 구조가 아니라 이 repo에서 헷갈리지 않기 위한 격리라고 정리했다.
- 이후 사용할 구조는 master repo를 지향하되, 여러 프로젝트를 한 repo에서 관리하는 것은 오버스펙이고 한 프로젝트를 크게 관리하는 형태가 맞다고 답했다.
- 최종 후보로 번호가 붙은 실무형 docs 구조에 동의했다.

### teach-back 결과 또는 아직 헷갈린 지점

- 사용자는 `experiments/`를 두는 이유를 "헷갈리지 않기 위함"으로 정리했다.
- `experiments/`는 다른 프로젝트에서 반드시 재사용할 구조가 아니라, 이 repo의 Codex workflow 실험물을 실제 프로젝트 문서와 분리하는 장치로 이해했다.
- `docs/creative`, `docs/design`, `docs/art`, `docs/development`처럼 바로 두는 구조는 의미가 조금 애매하고, AGENTS.md에 링크를 남기기에도 더 명확한 구분이 필요하다고 판단했다.
- 번호형 docs 구조는 Codex가 읽는 순서를 덜 헷갈리게 할 수 있다는 점에서 받아들였다.

### 다음 복습 질문

`10-design`과 `20-art`가 서로 다른 기준 문서여야 하는 이유를 한 문장으로 설명해보기.

## 내가 이해한 점

- `docs/prompts`와 `docs/prompt-results`는 실제 Safe Village Micro 프로젝트 문서가 아니라 Codex workflow 실험 문서다.
- 실험 문서를 `docs/` 안에 계속 두면 나중에 실제 프로젝트 문서와 섞여 Codex와 사람이 모두 헷갈릴 수 있다.
- `experiments/codex-workflow/`는 재사용용 표준 구조라기보다, 이 repo의 실험물을 실제 프로젝트 문서와 분리하기 위한 격리 공간이다.
- 미래 repo 구조는 여러 프로젝트를 품는 monorepo가 아니라, 하나의 프로젝트를 크게 관리하는 master repo를 기준으로 잡는 것이 맞다.
- AGENTS.md가 링크하기 쉬운 docs 구조는 단순한 분야명보다 읽는 순서와 역할이 드러나는 구조가 유리하다.

## 실제로 도움 된 점

- `docs/threads` 제안은 폐기하고, 실험 문서와 프로젝트 문서를 먼저 분리해야 한다는 기준이 생겼다.
- 현재 SVM repo의 Unity root 구조는 당장 옮기지 않아도 되지만, future template에서는 `unity/{ProjectName}/` 하위 구조를 검토할 수 있다는 판단이 정리됐다.
- 프로젝트 문서 후보를 `00-brief`, `10-design`, `20-art`, `30-production`, `40-engineering`, `90-decisions`로 좁혔다.
- AGENTS.md에 어떤 docs를 어떤 순서로 읽게 할지 연결할 수 있는 기준이 생겼다.

## 헷갈린 점

- 현재 SVM repo에서 실제로 `docs/prompts`와 `docs/prompt-results`를 언제 `experiments/codex-workflow/`로 이동할지는 아직 정하지 않았다.
- 현재 SVM repo도 future template 구조처럼 Unity project를 하위 폴더로 옮길지, 아니면 이 repo에서는 root Unity 구조를 유지할지는 아직 확정하지 않았다.
- `30-production`과 `40-engineering`의 경계, 특히 status/task/validation 문서를 어디에 둘지는 추가 정리가 필요하다.
- 최종 docs 구조를 AGENTS.md에 반영할 정확한 문구는 아직 작성하지 않았다.
- 최종 docs 구조를 선택할 경우 `docs/README.md`, 각 폴더별 `README.md`, `_template.md`, 실수 방지 규칙, 필요한 정보와 구체적 예시를 어디에 둘지도 별도 논의가 필요하다.

## 위험하거나 과해 보인 점

- 지금 바로 폴더 이동이나 Unity project 구조 변경을 실행하면 prompts lab의 목적을 벗어나고 불필요한 마이그레이션 작업이 될 수 있다.
- `docs/projects/`처럼 여러 프로젝트를 전제하는 구조는 현재 방향에서는 오버스펙이다.
- `creative`, `design`, `art`, `development` 같은 단순 분야명만 쓰면 Codex가 어떤 문서를 구현 기준으로 삼아야 하는지 헷갈릴 수 있다.
- 실험 문서를 `docs/`에 계속 쌓으면 실제 프로젝트 문서와 실험 결과가 같은 층위로 보여, 나중에 AGENTS.md 링크와 읽기 순서가 애매해질 수 있다.

## 채택 여부

채택/보류/폐기 중 정확히 하나만 선택한다. 추가 실험 필요 여부는 후속 작업으로 분리해서 기록한다.

- [x] 채택
- [ ] 보류
- [ ] 폐기

## 채택/보류/폐기 이유

이 실험은 실제 폴더 이동을 하지는 않았지만, 실험 문서와 프로젝트 문서를 분리해야 한다는 핵심 기준을 만들었다. 특히 `docs/prompts`와 `docs/prompt-results`를 영구적인 프로젝트 docs 구조로 보지 않고, `experiments/codex-workflow/`로 격리할 수 있는 실험 영역으로 재분류한 점이 유효했다. 또한 미래 master repo는 한 프로젝트를 크게 관리하는 구조로 보고, AGENTS.md가 읽기 쉬운 번호형 docs 구조를 최종 후보로 좁혔다.

## 다음 실험 프롬프트

```text
docs/prompts/011-matt-skills-review.md를 튜터 모드로 실행하되,
009에서 정리한 future docs 후보인 docs/00-brief, docs/10-design, docs/20-art,
docs/30-production, docs/40-engineering, docs/90-decisions 구조와 충돌하는지 확인해줘.
Matt skills를 전부 도입한다고 가정하지 말고, SVM에 필요한 skill만 기본/조건부/보류로 나눠 검토해줘.
파일 수정과 설치 명령 실행은 하지 마라.
```

## 후속 작업

- [x] 문서 갱신 필요
- [x] AGENTS.md 반영 검토
- [x] skill 후보 검토
- [ ] hook 후보 검토
- [x] 추가 실험 필요
- [ ] 추가 리서치 필요

후속 작업 메모:

`현재 SVM repo에서는 당장 폴더를 옮기지 않는다. 후속 정리 단계에서 docs/prompts와 docs/prompt-results를 experiments/codex-workflow 아래로 옮길지 검토한다. AGENTS.md에는 future docs 구조를 확정한 뒤, broad planning, gameplay design, visual work, validation, accepted decisions의 읽기 순서를 링크로 남기는 방안을 검토한다. 구조를 실제로 채택하기 전후로 docs/README.md, 각 폴더 README.md, _template.md, 실수 방지 규칙, 필요한 정보와 구체적 예시의 책임 분리도 별도 후속 논의로 다룬다.`
