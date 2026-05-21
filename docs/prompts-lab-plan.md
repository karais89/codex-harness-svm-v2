# Archive Notice

이 문서는 Prompts Lab의 원래 계획을 남겨두는 보존 문서다.
현재 운영 기준은 `docs/prompts/README.md`와 `docs/prompts/`의 numbered prompt files이다.
본문 안의 `docs/prompts.md` 참조는 historical context로 보존한다.

맞아. 이제 방향이 더 선명해졌어.

이번 `docs/prompts.md`는 **“Codex에게 실제 작업을 시키는 프롬프트 모음”**이 아니라, **네가 Codex/LLM의 구조와 사용법에 익숙해지기 위한 실험 프롬프트 카탈로그**로 만드는 게 맞다.

즉 3번째 프로젝트 초반 목표는 이거야.

> **Safe Village Micro를 바로 만들지 않는다.**
> Unity 프로젝트는 만들어두되, 먼저 Codex에게 여러 종류의 질문과 실험을 던져서
> skills, hooks, AGENTS, project structure, MCP, plugin, LLM workflow를 이해한다.
> 모든 실험 결과를 기록한 뒤, 실제로 무엇을 채택할지 결정한다.

이 흐름이 좋은 이유는 공식 Codex 구조와도 맞아. Codex customization은 대략 **AGENTS.md → hooks/linters → plugin/skill → MCP → subagents** 순서로 확장할 수 있고, skills는 반복 workflow를 재사용 가능한 지침/리소스/스크립트로 묶는 구조다. hooks는 Codex lifecycle 중 deterministic script를 실행하는 확장 지점이다. 그래서 처음부터 “정답 구성”을 고르기보다, 작은 실험을 통해 무엇이 실제로 도움 되는지 확인하는 게 훨씬 안전하다. ([OpenAI Developers][1])

---

# 1. 추천 문서 구조

나는 이렇게 두는 걸 추천해.

```text
docs/
  prompts.md
  prompt-results/
    000-template.md
    001-llm-mental-model.md
    002-agents-md.md
    003-skills.md
    004-matt-skills.md
    005-custom-skill.md
    006-hooks.md
    007-project-structure.md
    008-mcp.md
    009-plugin.md
    010-unity-workflow.md
```

`docs/prompts.md`는 **실험용 프롬프트 목록**이고, `docs/prompt-results/*.md`는 실제로 Codex에 던진 뒤 결과를 기록하는 곳이야.

지금 단계에서는 `SafeVillageMicro` Unity 프로젝트를 만든 뒤, 구현이 아니라 **LLM 실험실**처럼 쓰면 된다.

---

# 2. `docs/prompts.md`의 기본 형태

아래 내용을 그대로 `docs/prompts.md` 초안으로 써도 좋다.

```md
# Prompts Lab

이 문서는 Safe Village Micro를 실제 구현하기 전에, Codex/LLM의 작동 방식과 프로젝트 확장 도구를 이해하기 위한 실험 프롬프트 모음이다.

## 목적

- Codex가 프로젝트 문서를 어떻게 읽고 따르는지 확인한다.
- AGENTS.md, PLANS.md, skills, hooks, MCP, plugin의 역할 차이를 이해한다.
- Matt skills와 사용자 정의 skills 중 무엇이 실제로 도움이 되는지 실험한다.
- Unity 프로젝트에서 Codex가 어떤 방식으로 계획/리서치/검증을 잘하는지 확인한다.
- 실험 결과를 기록한 뒤, 실제 Safe Village Micro 개발에 채택할 구성을 결정한다.

## 공통 실험 규칙

- 기본값은 파일 수정 없음이다.
- 파일 생성/수정이 필요한 실험은 프롬프트에 명시한다.
- Unity Scene, C# gameplay code, Packages/manifest.json은 별도 승인 전 수정하지 않는다.
- 각 실험 후 `docs/prompt-results/`에 결과를 기록한다.
- 실험이 끝나기 전까지 특정 skill/hook/MCP/plugin을 정답으로 확정하지 않는다.

## 결과 기록 기준

각 실험은 다음 기준으로 평가한다.

- 이해도: 내가 LLM 구조를 더 잘 이해했는가?
- 실용성: 실제 Unity 개발에 도움이 되는가?
- 안정성: scope creep이나 오작동 위험이 낮은가?
- 반복성: 다음 프로젝트에도 재사용 가능한가?
- 비용: 설정/유지보수 부담이 과하지 않은가?
```

---

# 3. 결과 기록 템플릿

`docs/prompt-results/000-template.md`는 이렇게 만들면 좋다.

````md
# Prompt Result Template

## 실험 번호

## 실험 주제

## 사용한 프롬프트

```text

````

## Codex 응답 요약

## 내가 이해한 점

## 실제로 도움 된 점

## 헷갈린 점

## 위험하거나 과해 보인 점

## 채택 여부

* [ ] 채택
* [ ] 보류
* [ ] 폐기
* [ ] 추가 실험 필요

## 다음 실험 프롬프트

````

이 템플릿이 중요한 이유는, 네가 지금 하려는 게 단순 학습이 아니라 **하네스 설계 실험**이기 때문이야. 실험을 기록하지 않으면 나중에 “뭐가 실제로 좋았는지”가 흐려진다.

---

# 4. 실험 프롬프트 목록

아래부터는 `docs/prompts.md`에 넣을 수 있는 실제 프롬프트들이야.

---

## 01. LLM/Codex 구조 이해 프롬프트

```text
현재 나는 Codex를 사용해서 Unity 프로젝트를 개발하려고 한다.
하지만 지금은 구현이 아니라 Codex/LLM의 구조를 이해하는 것이 목적이다.

다음을 초보자가 이해할 수 있게 설명해줘.

1. 일반 ChatGPT와 Codex의 차이
2. Codex가 repo를 읽고 작업하는 방식
3. AGENTS.md가 Codex 행동에 영향을 주는 방식
4. skill과 prompt의 차이
5. hook과 skill의 차이
6. MCP와 plugin이 필요한 순간
7. Unity 프로젝트에서 Codex가 잘하는 일과 못하는 일

중요:
- 실제 파일을 수정하지 마라.
- Safe Village Micro 구현 계획으로 넘어가지 마라.
- 설명 후, 내가 직접 해볼 수 있는 작은 실험 3개를 제안해줘.
````

**추천 이유:**
이건 가장 먼저 해야 하는 실험이야. 네가 지금 이해하려는 건 “Codex에게 무슨 일을 시킬까?”가 아니라 “Codex가 어떤 구조로 움직이는가?”이기 때문이야. 특히 AGENTS, skills, hooks, MCP, plugin을 한꺼번에 다루면 헷갈리기 쉬워서, 처음에는 개념 지도를 만들어야 한다.

---

## 02. AGENTS.md 이해 실험

```text
AGENTS.md의 역할을 이해하고 싶다.

현재 repo에서 AGENTS.md가 있다고 가정하고, 다음을 설명해줘.

1. Codex는 AGENTS.md를 언제 읽는가?
2. global AGENTS.md와 repo AGENTS.md는 어떻게 다르게 작동하는가?
3. subdirectory AGENTS.md를 두면 어떤 일이 생기는가?
4. AGENTS.md에 넣어야 할 내용과 넣지 말아야 할 내용은 무엇인가?
5. Unity 프로젝트에서 AGENTS.md가 너무 길어질 때 어떤 문제가 생기는가?
6. Safe Village Micro 프로젝트라면 AGENTS.md는 어떤 역할까지만 맡아야 하는가?

출력:
- 핵심 설명
- 좋은 AGENTS.md 예시 구조
- 나쁜 AGENTS.md 예시 구조
- 내가 실험해볼 질문 3개

파일 수정은 하지 마라.
```

**추천 이유:**
Codex는 작업 전 `AGENTS.md`를 읽고, global → project → 현재 디렉터리 방향으로 instruction chain을 구성한다. 더 가까운 디렉터리의 지침이 나중에 붙기 때문에 우선권을 갖는 구조다. 그래서 Unity 프로젝트에서는 repo root와 `unity/SafeVillageMicro` 하위 지침을 어떻게 나눌지 이해하는 게 중요하다. ([OpenAI Developers][2])

---

## 03. 좋은 AGENTS.md와 나쁜 AGENTS.md 비교 프롬프트

```text
Safe Village Micro 프로젝트를 기준으로 좋은 AGENTS.md와 나쁜 AGENTS.md를 비교해줘.

상황:
- 나는 Codex로 Unity 프로젝트를 개발하려고 한다.
- 하지만 지금은 구현보다 LLM workflow를 이해하는 단계다.
- AGENTS.md가 너무 길어지거나, 게임 기획서처럼 변질되는 것을 피하고 싶다.

해야 할 일:
1. 좋은 AGENTS.md 예시를 보여줘.
2. 나쁜 AGENTS.md 예시를 보여줘.
3. 왜 나쁜지 설명해줘.
4. AGENTS.md에 두면 안 되는 내용은 어디로 보내야 하는지 알려줘.
5. Safe Village Micro에서 AGENTS.md / PLANS.md / docs/project-goal.md / docs/prompts.md의 역할을 분리해줘.

파일 수정은 하지 마라.
```

**추천 이유:**
공식 best practices에서도 짧고 정확한 AGENTS.md가 긴 추상 지침보다 유용하고, 반복 실수가 생길 때 갱신하는 쪽을 권장한다. 또한 AGENTS.md가 커지면 planning, code review, architecture 같은 task-specific 문서로 분리하는 게 낫다. ([OpenAI Developers][3])

---

## 04. skill 개념 이해 프롬프트

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

**추천 이유:**
Codex skill은 반복 workflow를 담는 구조이고, Codex는 처음에 skill의 name, description, path만 보고 필요할 때 전체 `SKILL.md`를 읽는 progressive disclosure 방식을 사용한다. 그래서 “좋은 skill”은 긴 설명보다 **정확한 trigger description**이 중요하다. ([OpenAI Developers][4])

---

## 05. “이건 skill로 만들 가치가 있는가?” 판단 프롬프트

```text
아래 후보들이 Codex skill로 만들 가치가 있는지 평가해줘.

후보:
1. Socratic clarification
2. Unity scope guard
3. Harness retrospective
4. Unity validation checklist
5. PRD generator
6. ExecPlan reviewer
7. AI mistake logger
8. Portfolio writeup helper
9. MCP experiment planner

평가 기준:
- 반복 사용 가능성
- instruction-only로 충분한지
- script가 필요한지
- AGENTS.md에 두는 게 나은지
- docs/prompts.md에만 두는 게 나은지
- 너무 범용적이라 오히려 위험한지
- Safe Village Micro에 직접 도움이 되는지

출력:
- 채택 후보
- 보류 후보
- 폐기 후보
- 각 후보의 이유
- 첫 번째로 실험할 skill 1개 추천

파일 수정은 하지 마라.
```

**추천 이유:**
너는 이전에도 “custom skill이 너무 많이 간다”는 감각을 가졌어. 이 프롬프트는 skill을 만들기 전에 **정말 skill로 만들 가치가 있는지** 판단하게 해준다. skill은 많이 만들수록 좋은 게 아니라, 반복 workflow를 안정화할 때만 가치가 있다.

---

## 06. custom skill 초안 생성 실험

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

**추천 이유:**
첫 custom skill은 실제로 만들지 말고 “초안 작성 실험”으로 시작하는 게 좋아. Codex가 어떤 내용을 skill로 담으려 하는지 보고, 너무 넓거나 과한지 판단할 수 있다.

---

## 07. Matt skills 검토 프롬프트

```text
Matt Pocock skills를 Safe Village Micro 프로젝트에 도입할지 검토하고 싶다.

목표:
설치가 아니라 이해와 선택이다.

해야 할 일:
1. Matt skills를 전부 설치하는 방식의 장단점
2. 일부만 선택하는 방식의 장단점
3. grill-me, grill-with-docs, handoff, write-a-skill이 이 프로젝트에 어떻게 도움이 되는지
4. 내 custom skill과 충돌할 가능성
5. AGENTS.md / PLANS.md / Matt skills / custom skills의 역할 분리
6. 지금 단계에서 설치 전 실험할 수 있는 프롬프트 제안

출력:
- 바로 설치해도 되는 것
- 먼저 검토해야 하는 것
- 지금은 보류할 것
- 추천 실험 순서

파일 수정과 설치 명령 실행은 하지 마라.
```

**추천 이유:**
Matt skills는 네가 관심 있는 “질문을 통해 명세를 명확히 하는 방식”과 잘 맞지만, 전부 설치하면 하네스 실험 결과가 흐려질 수 있다. 먼저 어떤 skill이 어떤 역할을 맡을지 분리해야 한다.

---

## 08. grill-me 스타일을 직접 흉내 내는 프롬프트

```text
grill-me 스타일의 인터뷰가 내 프로젝트에 맞는지 실험하고 싶다.

너는 지금 Safe Village Micro 프로젝트의 기획 인터뷰어다.
하지만 구현 계획을 만들지 말고, 질문 품질만 실험한다.

규칙:
- 질문은 최대 7개
- 가장 큰 불확실성부터 질문
- 내가 이미 말한 내용을 반복 질문하지 말 것
- 답변이 없어도 다음 단계로 진행 가능한 질문은 하지 말 것
- 각 질문 옆에 “왜 이 질문이 필요한지”를 써줘

주제:
Safe Village Micro를 Unity 2D 마이크로 프로젝트로 만들 때, first playable 전에 반드시 확정해야 할 것.

출력:
- 질문 목록
- 질문별 이유
- 질문에 답하면 어떤 문서가 갱신되는지
- 이 방식이 skill로 만들 가치가 있는지 평가
```

**추천 이유:**
이건 실제 Matt skill 설치 전, “질문형 skill이 나한테 맞는지” 확인하는 실험이야. 네가 원하는 건 단순 브레인스토밍보다 **명세를 좁히는 질문**이니까, 질문 품질을 먼저 평가하는 게 좋다.

---

## 09. hooks 개념 이해 프롬프트

```text
Codex hooks의 개념을 이해하고 싶다.

다음을 설명해줘.

1. hook은 skill과 무엇이 다른가?
2. hook은 AGENTS.md와 무엇이 다른가?
3. hook은 언제 실행되는가?
4. hook이 잘하는 일과 못하는 일은 무엇인가?
5. Unity 프로젝트에서 hook으로 막으면 좋은 위험은 무엇인가?
6. hook으로 막으면 오히려 개발을 방해할 수 있는 것은 무엇인가?
7. Safe Village Micro에서 처음 실험할 hook 3개를 제안해줘.

중요:
- hooks 파일을 만들지 마라.
- 실제 활성화하지 마라.
- 개념 이해와 실험 설계만 해줘.
```

**추천 이유:**
hooks는 skill과 정반대 성격에 가깝다. skill은 “모델이 참고할 workflow”이고, hook은 “항상 실행되는 deterministic guardrail”이다. 공식 문서에서도 hooks는 Codex lifecycle 중 custom script를 주입해 prompt 검사, validation check, logging 같은 작업을 하도록 하는 확장 프레임워크로 설명된다. ([OpenAI Developers][5])

---

## 10. hooks 설계 검토 프롬프트

```text
Safe Village Micro 프로젝트에서 사용할 hook 후보를 설계해줘.

목표:
구현이 아니라 hook 설계 감각을 익히는 것이다.

상황:
- Unity 프로젝트가 repo 안에 있다.
- 아직 gameplay 구현 전이다.
- Codex가 실수로 C# 코드나 Scene을 수정하는 것을 막고 싶다.
- 나중에는 Unity validation에도 hook을 쓰고 싶다.

해야 할 일:
1. 지금 단계에서 hook이 필요한 위험을 나열
2. hook 없이 AGENTS.md로 충분한 항목 분리
3. hook으로 막아야 하는 항목 분리
4. hook이 너무 과해지는 경우 설명
5. dry-run hook과 blocking hook의 차이 설명
6. 첫 hook 실험 3개 제안

출력:
- hook 후보 표
- 우선순위
- false positive 위험
- 실험 방법
- 채택 여부 판단 기준

파일 생성은 하지 마라.
```

**추천 이유:**
처음부터 hook을 강하게 만들면 Codex가 제대로 움직이지 못한다. 그래서 dry-run, warning, blocking의 차이를 이해해야 한다. 특히 Unity는 `Packages`, `ProjectSettings`, `Assets` 변경이 크기 때문에 hook 설계가 중요하다.

---

## 11. project structure 논의 프롬프트

```text
Safe Village Micro repo 구조를 논의하고 싶다.

목표:
구현 전에 repo 구조, docs 구조, Unity project 위치를 결정하기 위한 토론이다.

현재 가정:
- repo root에 AGENTS.md, PLANS.md, README.md, docs/
- Unity project는 unity/SafeVillageMicro/
- prompts 실험은 docs/prompts.md와 docs/prompt-results/
- 나중에 skills와 hooks를 추가할 수 있음

해야 할 일:
1. 이 구조의 장단점 평가
2. Unity project를 repo root에 바로 두는 방식과 unity/ 하위에 두는 방식 비교
3. docs/threads와 docs/prompt-results의 차이 정리
4. skills와 hooks를 어디에 두는 것이 좋은지 제안
5. Codex가 읽기 쉬운 구조인지 평가
6. 추천 tree 제안

금지:
- 실제 폴더 생성하지 마라.
- Unity 파일 수정하지 마라.
```

**추천 이유:**
이건 꼭 해야 한다. Unity 프로젝트를 root에 바로 두면 단순하지만 repo가 지저분해지고, `unity/SafeVillageMicro` 아래에 두면 문서/하네스와 Unity 파일을 분리하기 쉽다. 네 경우는 하네스 실험이 목적이므로 분리 구조가 더 낫다.

---

## 12. docs 역할 분리 프롬프트

```text
이 프로젝트의 문서 역할을 분리해줘.

문서 후보:
- README.md
- AGENTS.md
- PLANS.md
- docs/project-goal.md
- docs/prompts.md
- docs/prompt-results/
- docs/threads/
- docs/decisions.md
- docs/progress.md
- docs/ai-mistakes.md
- docs/research/

해야 할 일:
1. 각 문서의 책임을 1문장으로 정의
2. 겹치는 책임이 있는지 찾기
3. 어떤 문서는 없애도 되는지 판단
4. Codex가 매 세션 읽어야 하는 문서와 필요할 때만 읽을 문서 구분
5. 문서가 너무 많아질 때의 위험 설명
6. 최소 문서 세트와 확장 문서 세트 제안

파일 수정은 하지 마라.
```

**추천 이유:**
너는 문서 기반 workflow를 선호하지만, 문서가 많아질수록 Codex가 “무엇을 기준으로 삼아야 하는지” 헷갈릴 수 있다. 이 프롬프트는 문서 책임을 쪼개는 데 좋다.

---

## 13. LLM failure mode 분석 프롬프트

```text
Codex가 Unity 프로젝트에서 자주 할 수 있는 실수를 예측해줘.

상황:
- Safe Village Micro는 작은 Unity 2D 프로젝트다.
- 나는 직접 코딩보다 Codex 중심 workflow를 실험하고 싶다.
- 지금은 구현 전이다.

해야 할 일:
1. Codex가 할 수 있는 실수를 유형별로 나눠라.
2. 각 실수를 AGENTS.md, skill, hook, prompt, test 중 무엇으로 막을 수 있는지 제안해라.
3. 막기 어려운 실수는 무엇인지 말해라.
4. Unity 특유의 위험을 따로 정리해라.
5. `docs/ai-mistakes.md`에 어떤 형식으로 기록하면 좋을지 제안해라.

파일 수정은 하지 마라.
```

**추천 이유:**
이건 네 하네스 실험에 매우 중요하다. 좋은 하네스는 “멋진 도구 모음”이 아니라 **반복 실수를 줄이는 구조**다. 실패 모드를 먼저 예측하면 AGENTS, skill, hook을 어디에 써야 하는지 보인다.

---

## 14. MCP 개념 이해 프롬프트

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

**추천 이유:**
공식 문서상 MCP는 모델을 third-party documentation이나 developer tools 같은 외부 context/tool에 연결하기 위한 구조다. Unity에서는 Editor 상태, Console, Scene 정보 같은 “repo 파일만으로 알 수 없는 정보”를 다룰 때 의미가 커진다. ([OpenAI Developers][6])

---

## 15. plugin 개념 이해 프롬프트

```text
Codex plugin을 이해하고 싶다.

다음을 설명해줘.

1. plugin은 skill과 무엇이 다른가?
2. plugin은 MCP와 무엇이 다른가?
3. plugin은 언제 만들 가치가 있는가?
4. 지금 Safe Village Micro 단계에서 plugin을 만들면 왜 이른가?
5. 나중에 내 Unity workflow를 plugin으로 묶는다면 무엇을 포함할 수 있는가?
6. plugin 제작 전 어떤 실험이 먼저 끝나야 하는가?

출력:
- plugin 개념 설명
- 지금 하지 말아야 할 이유
- 나중에 만들 수 있는 plugin 후보
- 선행 실험 체크리스트

파일 생성은 하지 마라.
```

**추천 이유:**
plugin은 처음부터 만드는 게 아니라, 검증된 skill, app integration, MCP server를 재사용 가능한 단위로 묶을 때 의미가 있다. 공식 문서에서도 plugin은 skills, apps, MCP servers를 묶는 설치 가능한 workflow 단위로 설명한다. ([OpenAI Developers][7])

---

## 16. Unity 개발 workflow 실험 프롬프트

```text
Codex를 사용한 Unity 개발 workflow를 이해하고 싶다.

Safe Village Micro를 예시로 하되, 구현하지 말고 workflow만 설계해줘.

비교할 workflow:
1. 문서 없이 바로 구현
2. README + AGENTS만 두고 구현
3. PRD + ExecPlan 후 구현
4. skills/hooks까지 붙이고 구현
5. MCP까지 붙이고 구현

평가 기준:
- 속도
- 안전성
- 학습 가치
- Unity 오류 대응
- scope creep 방지
- 포트폴리오 설명 가능성

출력:
- 각 workflow의 장단점
- 내 상황에 맞는 추천 순서
- 지금 실험해야 할 것
- 나중에 미뤄야 할 것

파일 수정은 하지 마라.
```

**추천 이유:**
너는 “코드를 안 쓰고 Codex로 Unity 게임을 만들 수 있는가”를 확인하고 싶어 한다. 그러려면 workflow 자체를 비교해야 한다. 이 프롬프트는 v0/v1/v2 실험의 차이를 정리하는 데 좋다.

---

## 17. ExecPlan/PLANS.md 이해 프롬프트

```text
ExecPlan과 PLANS.md의 역할을 이해하고 싶다.

다음을 설명해줘.

1. 일반 plan과 ExecPlan은 무엇이 다른가?
2. ExecPlan이 필요한 작업과 필요 없는 작업은 어떻게 나누는가?
3. Unity 프로젝트에서 ExecPlan이 특히 필요한 순간은 언제인가?
4. skills나 grill-me가 있으면 ExecPlan이 필요 없어지는가?
5. Safe Village Micro에서 ExecPlan을 너무 일찍 만들면 어떤 문제가 생기는가?
6. prompt 실험 단계와 실제 구현 단계에서 PLANS.md는 어떻게 달라야 하는가?

출력:
- 설명
- 판단 기준
- 좋은 ExecPlan 사용 예
- 나쁜 ExecPlan 사용 예
- 지금 단계에서의 결론

파일 수정은 하지 마라.
```

**추천 이유:**
OpenAI의 PLANS.md/ExecPlan 글에서도 “ExecPlan”은 Codex가 원래부터 아는 고유 기능명이 아니라, 사용자가 AGENTS.md 등에서 정의해 사용하는 planning shorthand라고 설명한다. 즉 네 프로젝트에서 ExecPlan을 어떻게 정의하느냐가 중요하다. ([OpenAI Developers][8])

---

## 18. subagents 이해 프롬프트

```text
Codex subagents가 무엇인지 이해하고 싶다.

Safe Village Micro 프로젝트에서 subagents를 쓸 수 있는 상황과 쓰면 안 되는 상황을 설명해줘.

다음을 구분해줘.
1. 일반 Codex 단일 세션으로 충분한 작업
2. subagent를 쓰면 좋은 리서치 작업
3. subagent를 쓰면 오히려 위험한 구현 작업
4. Unity 프로젝트에서 subagent 결과를 검증하는 방법
5. docs/threads 구조와 subagents의 관계

출력:
- subagents 개념 설명
- 좋은 사용 예
- 나쁜 사용 예
- 지금 단계에서 실험할 prompt 2개
- 보류해야 할 이유

파일 수정은 하지 마라.
```

**추천 이유:**
Codex subagents는 명시적으로 요청했을 때만 spawn되는 구조이고, 여러 agent 결과를 모아주는 방식이다. 그래서 지금처럼 여러 갈래 리서치를 하고 싶을 때는 매력적이지만, Unity 파일 수정 작업에 바로 쓰기에는 검증 부담이 크다. ([OpenAI Developers][9])

---

## 19. “내가 뭘 배웠는지” 점검 프롬프트

```text
지금까지의 prompts lab 결과를 바탕으로 내가 무엇을 이해했고 무엇을 아직 헷갈려 하는지 정리해줘.

읽을 문서:
- docs/prompts.md
- docs/prompt-results/

해야 할 일:
1. 내가 이해한 개념 목록
2. 아직 헷갈리는 개념 목록
3. 추가 실험이 필요한 항목
4. 실제 Safe Village Micro 개발에 채택할 후보
5. 보류할 후보
6. 다음 3개 실험 추천

중요:
- 새로운 구현 계획을 만들지 마라.
- 실험 결과를 근거로 판단해라.
- 추측과 확인된 사실을 분리해라.
```

**추천 이유:**
실험이 많아질수록 결론이 흐려진다. 중간에 “학습 정리”를 한 번 해야 다음 실험을 줄일 수 있다.

---

## 20. 최종 선택 프롬프트

```text
prompts lab의 모든 결과를 바탕으로 Safe Village Micro 개발에 실제 채택할 구성을 제안해줘.

읽을 문서:
- docs/prompts.md
- docs/prompt-results/
- docs/decisions.md
- docs/progress.md

판단할 항목:
1. AGENTS.md 구조
2. PLANS.md / ExecPlan 사용 여부
3. Matt skills 도입 여부
4. custom skills 도입 여부
5. hooks 도입 여부
6. MCP 도입 시점
7. plugin 보류/진행 여부
8. docs/threads 유지 여부
9. 실제 Unity 구현 시작 조건

출력:
- 채택
- 보류
- 폐기
- 이유
- 다음 작업 순서
- 구현으로 넘어가기 전 체크리스트

중요:
- 새 기능 제안보다 실험 결과 기반 선택에 집중해라.
- 모든 것을 다 채택하지 마라.
- 작은 구성을 우선 추천해라.
```

**추천 이유:**
이게 prompts lab의 마지막 목적지야. “좋아 보이는 도구를 다 붙이는 것”이 아니라, **실험 결과에 따라 가장 작은 유효 구성을 고르는 것**이 최종 목표다.

---

# 5. 내가 추천하는 실험 순서

처음에는 이 순서가 좋아.

```text
1. LLM/Codex 구조 이해
2. AGENTS.md 이해
3. skill 개념 이해
4. skill 후보 가치 판단
5. hooks 개념 이해
6. project structure 논의
7. docs 역할 분리
8. Matt skills 검토
9. custom skill 초안 생성
10. hooks 설계 검토
11. MCP 이해
12. plugin 이해
13. Unity workflow 비교
14. 중간 학습 정리
15. 최종 선택
```

이 순서의 핵심은 **AGENTS → skills → hooks → project structure → MCP/plugin**이야. 바로 MCP나 plugin으로 가면 너무 커진다.

---

# 6. 이 방식에서 중요한 운영 규칙

`docs/prompts.md` 맨 위에 이 문장을 넣는 걸 추천해.

```md
이 prompts lab의 목적은 즉시 정답을 고르는 것이 아니다.
각 프롬프트는 Codex/LLM의 작동 방식을 이해하기 위한 실험이다.
실험 결과가 기록되기 전까지 skills, hooks, MCP, plugin은 채택하지 않는다.
```

그리고 Codex에게 매번 이렇게 시작하게 해도 좋아.

```text
이 프롬프트는 구현 지시가 아니라 prompts lab 실험이다.
파일 수정 없이 개념 설명, 비교, 평가, 다음 실험 제안만 해줘.
```

이 한 줄이 있으면 Codex가 갑자기 구현이나 설치로 넘어가는 걸 줄일 수 있다.

---

# 7. 내 결론

지금 네 판단이 맞아.

**Unity 프로젝트는 만들어둔다.**
하지만 바로 Safe Village Micro를 구현하지 않는다.

대신 `docs/prompts.md`를 만들고, Codex에게 하나씩 실험 프롬프트를 던져서 다음을 익힌다.

```text
- Codex는 프로젝트를 어떻게 읽는가
- AGENTS.md는 어느 정도까지 써야 하는가
- skill은 언제 유용한가
- Matt skills는 정말 필요한가
- 내 custom skill은 어떤 문제를 해결해야 하는가
- hook은 어떤 실수를 막는가
- MCP/plugin은 지금 필요한가, 나중에 필요한가
- Unity 개발 workflow는 어느 정도 문서화해야 안정적인가
```

이 실험이 끝난 뒤에야 실제 개발 구성, 즉 **AGENTS + PLANS + selected skills + selected hooks + maybe MCP**를 고르는 게 좋다. 이러면 3번째 프로젝트가 그냥 또 하나의 게임 개발이 아니라, 네가 LLM 개발 방식 자체를 몸에 익히는 실험장이 된다.

[1]: https://developers.openai.com/codex/concepts/customization?utm_source=chatgpt.com "Customization – Codex"
[2]: https://developers.openai.com/codex/guides/agents-md?utm_source=chatgpt.com "Custom instructions with AGENTS.md – Codex"
[3]: https://developers.openai.com/codex/learn/best-practices?utm_source=chatgpt.com "Best practices – Codex"
[4]: https://developers.openai.com/codex/skills?utm_source=chatgpt.com "Agent Skills – Codex"
[5]: https://developers.openai.com/codex/hooks?utm_source=chatgpt.com "Hooks – Codex"
[6]: https://developers.openai.com/codex/mcp?utm_source=chatgpt.com "Model Context Protocol – Codex"
[7]: https://developers.openai.com/codex/plugins?utm_source=chatgpt.com "Plugins – Codex"
[8]: https://developers.openai.com/cookbook/articles/codex_exec_plans?utm_source=chatgpt.com "Using PLANS.md for multi-hour problem solving"
[9]: https://developers.openai.com/codex/subagents?utm_source=chatgpt.com "Subagents – Codex"
