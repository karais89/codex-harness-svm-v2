# Prompt Result: 008. Unity 개발 Workflow 비교

## 실험 번호

`008`

## 실험 주제

`Unity 개발 Workflow 비교`

## 실행 일시

`2026-05-21 22:12 KST`

## 실행 모드

일반/튜터 중 정확히 하나만 선택한다.

- [ ] 일반
- [x] 튜터

## 사용자 명령

```text
docs/prompts/008-unity-workflow.md 튜터 모드 실행

1. 어떤 워크플로우가 좋은가?
2. 실제 게임 개발이 가능한가? 결국에 코덱스가 짠 코드 내가 이해 부족 할 것이고, 맥락을 잃는 부분. 작업을 어디 까지 했는지 모르는 부분? 내가 원하는 방식으로 개발 하는가?
3. 빠른 개발은 아닌 것 같고, 얼마나 가능성이 있는지? 코덱스로 게임 개발하는게

이 부분이 왜 업데이트가 안됐는지 모르겠다. 이미 실험한 레포가 있는데. 같은 레벨에 codex-harness-*로 시작하는 레포 2개 있거든?

현재 레포의 방향도 사실 어느 정도 결정했거든 이것 까지 알려줄게. 나머지 실험들이 의미가 있는지도 한번 체크해줘.
현재 프로젝트는 v1에서 matt의 스킬 셋을 쓸려고 하고 있어.(https://github.com/mattpocock/skills/tree/main) 아마 적극적으로 쓸 것 같아.

원래는 쓰려고했는데 이 방향이 맞을지에 대한 것도 좀 찾아보자는 의미긴 했어.

008은 닫아도 될까? 추가 논의 할게 없을까?

정리 하기 전에 matt 스킬 보다 더 괜찮은 워크 플로우는 없는걸끼

니가 알려준건 다 알고 있어 근데 적합하지 않은 것 같아 008 정리해줘.
```

## 적용한 실행 모드 wrapper

```text
docs/prompts/README.md의 튜터 모드 wrapper를 적용했다.

- Safe Village Micro 구현으로 넘어가지 않음.
- 실험 실행 단계에서는 파일을 생성/수정하지 않음.
- 현재 repo 구조와 관련 sibling 실험 repo를 확인하고, 확인된 사실과 추측을 분리함.
- Unity gameplay code, Scene, Packages/manifest.json, ProjectSettings/를 수정하지 않음.
- 바로 긴 설명을 시작하지 않고 시작 질문으로 현재 이해 수준을 확인함.
- 개념 단위로 나누어 설명하고 teach-back 질문으로 이해를 확인함.
- 마지막에는 핵심 요약, 복습 질문 1개, 다음 실험 제안 순서로 마무리함.
```

## 참조한 프롬프트 파일

`docs/prompts/008-unity-workflow.md`

## 모델/클라이언트/실행 환경

- 모델: `GPT-5 계열 Codex, 세부 모델명 확인 불가`
- 클라이언트: `Codex coding agent`
- 실행 환경: `macOS zsh, repo root /Users/kaya/Documents/Codex/codex-harness-svm-v2, KST`

## 실행 조건

- 파일 수정 허용 여부: `실험 실행 단계 파일 수정 금지, 기록 단계에서 docs/prompt-results/008-unity-workflow.md 생성 허용`
- 사용한 skill/tool: `shell로 현재 repo와 sibling repo 확인, web으로 Matt skills 및 대안 workflow 공식 자료 확인, apply_patch로 결과 파일 생성`
- 별도 제약: `Unity 파일 수정 금지, Safe Village Micro 구현 task로 확장하지 않기, Unity 작업 티켓/마이그레이션 계획 생성 금지`

## Codex 응답 요약

Codex는 처음에는 `README + AGENTS` 위에 작은 PRD/ExecPlan을 얹는 방향을 제안했지만, 사용자가 이미 `codex-harness-dbz-v0`와 `codex-harness-tgr-v1` 실험이 있음을 지적했다. 이후 sibling repo를 확인해 `DBZ-v0`는 안전하지만 무거운 문서/ExecPlan 중심 실험이고, `TGR-v1`은 더 가벼운 `AGENTS.md` 중심 실험이라는 점을 반영했다. 사용자는 현재 방향이 Matt Pocock skills 검토에 가깝지만, 그것도 확정 채택이 아니라 적합성 검증 대상이라고 정정했다. 최종적으로 008은 workflow 후보 비교로 닫고, Matt skills 및 다른 큰 workflow는 011에서 제한적 채택 가능성을 검토하는 쟁점으로 넘기기로 했다.

## 튜터 모드 상호작용 요약

일반 모드 실행이면 모든 항목에 `해당 없음`을 적는다. 튜터 모드 실행이면 전체 대화 전문을 붙여넣지 말고 핵심만 요약한다.

### Codex가 한 확인 질문

- Codex를 사용한 Unity 개발에서 궁금한 점이 workflow 선택인지, PRD/ExecPlan/skills/hooks/MCP의 필요성인지 물었다.
- Unity에서 Codex를 쓸 때 가장 불안한 지점이 범위 커짐, Scene/Prefab 손상, 컴파일 오류, 문서와 구현 불일치 중 무엇인지 물었다.
- Safe Village Micro 기준으로 빠른 첫 구현을 원하는지, 느려도 실수를 줄이는 구조 설계를 원하는지 물었다.
- DBZ-v0와 TGR-v1을 반영한 뒤, SVM은 무거운 절차와 가벼운 절차 중 어느 쪽을 기본값으로 삼아야 하는지 물었다.
- Matt skills보다 더 나은 workflow 후보를 검토해야 하는지 확인하고, Spec Kit, BMad/BMad Game Dev Studio, Superpowers 같은 대안을 비교했다.

### 사용자 답변 요약

- 사용자는 가장 궁금한 것이 "어떤 workflow가 좋은가"라고 답했다.
- 사용자는 실제 게임 개발이 가능한지, Codex가 짠 코드를 본인이 충분히 이해할 수 있을지, 맥락을 잃지 않을지, 작업이 어디까지 됐는지 알 수 있을지, 본인이 원하는 방식으로 개발되는지가 불안하다고 답했다.
- 사용자는 빠른 개발보다는 Codex로 게임 개발하는 가능성을 확인하는 것이 목적이라고 답했다.
- 사용자는 같은 레벨에 이미 `codex-harness-dbz-v0`, `codex-harness-tgr-v1` 실험 repo가 있는데 Codex가 이를 반영하지 않은 점을 지적했다.
- 사용자는 현재 방향이 v1에서 Matt skills를 쓰려는 쪽이지만, 그것이 정말 맞는지도 찾아보자는 의미였다고 정정했다.
- 사용자는 Spec Kit, BMad, Superpowers 같은 큰 workflow 후보는 이미 알고 있으며 현재 단계에는 적합하지 않은 것 같다고 판단했다.

### teach-back 결과 또는 아직 헷갈린 지점

- 사용자는 DBZ-v0와 TGR-v1의 차이를 이미 알고 있었고, 008 비교는 그 실험 결과를 전제로 해야 한다는 점을 분명히 했다.
- 사용자는 Matt skills를 "도입 확정"이 아니라 "SVM에 적합한지 검증할 후보"로 봐야 한다는 방향을 잡았다.
- 큰 workflow 대안들은 사용자가 이미 인지하고 있으며, 현재 작은 Unity playable loop 실험에는 부적합할 가능성이 높다는 결론으로 008을 닫기로 했다.
- 아직 남은 쟁점은 Matt skills 중 어떤 것을 기본/조건부/보류로 나눌지, 그리고 문서 구조와 Plan/ExecPlan 경계를 어떻게 둘지이다.

### 다음 복습 질문

`Safe Village Micro에서 "큰 workflow 프레임워크 채택"보다 "가벼운 repo-local 규칙 + 선택적 skill"이 더 맞다고 보는 이유를 한 문장으로 설명해보기.`

## 내가 이해한 점

- Safe Village Micro의 workflow 비교는 가상의 5개 후보만 놓고 보면 부족하고, 이미 실행한 `DBZ-v0`와 `TGR-v1` 실험 결과를 전제로 해야 한다.
- `DBZ-v0`는 맥락 유지와 인수인계에는 강하지만, 작은 게임 개발 실험에는 절차와 문서가 무거워질 수 있다.
- `TGR-v1`은 가벼운 하네스 방향의 기준이지만, 작업 상태 기록과 완료 기준이 약해지면 사용자가 걱정한 "어디까지 했는지 모름" 문제가 다시 생길 수 있다.
- Matt skills는 현재 가장 검토 가치가 큰 후보지만, 전부 채택하면 DBZ-v0와 비슷하게 절차가 커질 수 있다.
- Spec Kit, BMad, BMad Game Dev Studio, Superpowers는 유효한 대안이지만 현재 SVM의 작은 playable loop 검증에는 과할 가능성이 높다.

## 실제로 도움 된 점

- 008의 역할을 "최종 workflow 확정"이 아니라 "workflow 후보를 줄이고 다음 검토로 넘기는 단계"로 정리했다.
- 다음 실험의 중심이 `Matt skills를 쓸지 말지`가 아니라 `Matt skills를 얼마나 제한적으로 쓸지, 그리고 다른 큰 workflow를 왜 보류하는지`로 좁혀졌다.
- SVM의 기본 방향은 `문서 없이 바로 구현`도 아니고 `DBZ-v0식 무거운 절차 반복`도 아니라, `TGR-v1의 경량 흐름을 기본으로 하되 Matt skills를 검증 후보로 두는 방식`으로 정리됐다.
- 사용자 불안 요소가 "코드 작성 능력"보다 "작업 통제, 맥락 유지, 상태 추적, 원하는 방식으로 개발되는지"에 있다는 점이 명확해졌다.

## 헷갈린 점

- Matt skills 중 실제로 기본값으로 둘 skill과 요청 시에만 쓸 skill은 아직 정하지 않았다.
- `CONTEXT.md`, `docs/adr/`, `docs/agents/` 같은 Matt skills 친화 문서 구조를 SVM repo에 둘지, v1 repo에 둘지, 또는 별도 실험으로 둘지 아직 정하지 않았다.
- Plan mode, ExecPlan, Matt의 `to-prd`/`to-issues`/`grill-with-docs` 사이의 경계는 아직 정리되지 않았다.
- Unity Editor 상태 확인과 Scene/Prefab 검증은 Matt skills만으로 해결되지 않으므로 MCP 또는 수동 검증 기준을 별도로 판단해야 한다.

## 위험하거나 과해 보인 점

- Matt skills를 전부 설치하고 기본값으로 쓰면 SVM의 목적보다 workflow 운영이 커질 수 있다.
- Spec Kit, BMad, BMad Game Dev Studio, Superpowers는 맥락 관리에는 강하지만 현재 작은 playable loop 실험에는 프레임워크 자체가 과제가 될 위험이 있다.
- DBZ-v0에서 얻은 무거운 안전장치를 그대로 가져오면 TGR-v1에서 의도한 경량화 실험과 충돌한다.
- 반대로 TGR-v1처럼 너무 가볍게만 가면 사용자가 걱정한 작업 상태 추적, 맥락 유지, 완료 기준 문제가 다시 생길 수 있다.

## 채택 여부

채택/보류/폐기 중 정확히 하나만 선택한다. 추가 실험 필요 여부는 후속 작업으로 분리해서 기록한다.

- [x] 채택
- [ ] 보류
- [ ] 폐기

## 채택/보류/폐기 이유

이 실험은 SVM workflow를 확정하지는 않았지만, 비교 방향을 좁히는 데 성공했다. 채택하는 것은 "DBZ-v0와 TGR-v1 실험 결과를 전제로, 큰 workflow 프레임워크는 현재 보류하고 Matt skills는 제한적 검증 후보로 넘긴다"는 판단이다. 실제 Matt skills 도입 여부, 문서 구조, Plan/ExecPlan 경계는 011, 009, 014에서 별도로 판단한다.

## 다음 실험 프롬프트

```text
docs/prompts/011-matt-skills-review.md를 튜터 모드로 실행하되,
Matt skills를 적극 도입한다고 가정하지 말고,
Spec Kit, BMad/BMad Game Dev Studio, Superpowers 같은 큰 workflow는 현재 단계에 적합하지 않다는 사용자 판단을 전제로,
Matt skills 중 SVM에 정말 필요한 것만 기본/조건부/보류로 나눠 검토해줘.
파일 수정과 설치 명령 실행은 하지 마라.
```

## 후속 작업

- [x] 문서 갱신 필요
- [x] AGENTS.md 반영 검토
- [x] skill 후보 검토
- [x] hook 후보 검토
- [x] 추가 실험 필요
- [ ] 추가 리서치 필요

후속 작업 메모:

`008은 workflow 비교 실험으로 닫는다. 다음은 011에서 Matt skills를 제한적으로 검토하고, 009에서 repo/docs 구조를 정리하며, 014에서 Plan mode, ExecPlan, Matt skills의 경계를 정한다. Spec Kit, BMad/BMad Game Dev Studio, Superpowers는 현재 SVM 단계에서는 보류 후보로 남기고, 실제 채택 검토는 하지 않는다.`
