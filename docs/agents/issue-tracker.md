# Issue tracker: GitHub

이 repo의 issues와 PRD는 GitHub Issues에서 관리한다. 모든 issue tracker 작업은 `gh` CLI를 사용한다.

## Conventions

- Issue 생성: `gh issue create --title "..." --body "..."`
- Issue 조회: `gh issue view <number> --comments`
- Issue 목록: `gh issue list --state open --json number,title,body,labels,comments`
- Comment 추가: `gh issue comment <number> --body "..."`
- Label 적용/제거: `gh issue edit <number> --add-label "..."` / `--remove-label "..."`
- Close: `gh issue close <number> --comment "..."`

Repo는 `git remote -v` 기준으로 추론한다. clone 내부에서 실행하면 `gh`가 보통 자동으로 처리한다.

## When a skill says "publish to the issue tracker"

GitHub issue를 생성한다.

## When a skill says "fetch the relevant ticket"

`gh issue view <number> --comments`를 실행한다.
