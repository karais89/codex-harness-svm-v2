# 006a Hooks Guard Practice

This directory is a learning-only mock. It does not activate real Codex hooks
and does not create `.codex/config.toml`, `.codex/hooks/`, or global config.

## Files

- `fixtures/`: mock hook input JSON
- `hooks/mock_guard.py`: learning-only guard script
- `run_smoke_tests.py`: runner that feeds each fixture to the guard

## What To Read First

Read this practice in this order:

1. `fixtures/*.json`: each file is one fake Codex hook event.
2. `hooks/mock_guard.py`: this is the policy logic that inspects the event.
3. `run_smoke_tests.py`: this shows how each event is fed into the guard and
   how the output is classified.

The important point is that hook code is ordinary deterministic code. Codex
sends event-shaped JSON, the script checks a few fields, and the script prints
JSON that tells Codex whether to block, add context, continue, or pass.

## Code Map

`hooks/mock_guard.py` has three policy branches:

- `pre_tool_use(event)`: looks at `tool_name` and `tool_input`; blocks edits or
  commands that mention protected Unity paths.
- `stop(event)`: looks at `last_assistant_message`; asks Codex to continue when
  it claims completion without mentioning verification.
- `user_prompt_submit(event)`: looks at `prompt`; adds Prompts Lab scope context
  when the user prompt tries to move into Unity implementation.

`run_smoke_tests.py` does not test Codex itself. It tests only this policy
logic:

1. Load each fixture JSON.
2. Run `mock_guard.py` with the fixture as stdin.
3. Read stdout/stderr.
4. Classify the result as `blocked`, `continued`, `context`, `warning`, or
   `passed`.
5. Compare that classification with the fixture's `_lab.expected` value.

## What This Solves

This mock practice answers policy questions before touching real Codex config:

- Which situations are concrete enough for a hook?
- Should a situation be blocked, continued, or only given context?
- Can the guard script distinguish dangerous and acceptable examples?

It does not prove that Codex will call the hook. That is why the separate
`../006a-real-codex-hook-smoke/` experiment exists.

## Selected hook candidates

| Situation | Risk | Event | Decision | Why |
| --- | --- | --- | --- | --- |
| Protected Unity path edit | Accidental edits to `ProjectSettings/`, `Packages/manifest.json`, or lockfiles can destabilize the project | `PreToolUse` | block | The risky input is visible before the tool runs |
| Completion without verification | Codex may claim work is done without running or reporting checks | `Stop` | continue | The turn should not end until verification is run or explicitly impossible |
| Prompts Lab scope drift into Unity implementation | The lab can accidentally become gameplay implementation before the prompt sequence is done | `UserPromptSubmit` | context | Usually a reminder is enough; block would be too rigid unless the repo has formally frozen Unity edits |

## Minimum guideline

Use a hook only when the trigger is concrete enough to check deterministically.

- Minimum useful guard: protect high-risk paths with `PreToolUse`.
- Good quality guard: use `Stop` to require verification before a completion claim.
- Good scope guard: use `UserPromptSubmit` to add project context when prompts drift outside the current phase.

Avoid hooks for vague style preferences, broad refactors, or checks that need
slow tooling on every small action. Those usually belong in `AGENTS.md`, a
skill, or a manual verification step.

## Real Codex hook difference

This mock script is run manually by `run_smoke_tests.py`. A real Codex hook
would need hook configuration in `hooks.json` or inline `[hooks]` tables inside
`config.toml`, and non-managed project hooks would need trust review before
running.

Example shape only, not created by this practice:

```toml
[[hooks.PreToolUse]]
matcher = "^apply_patch$"

[[hooks.PreToolUse.hooks]]
type = "command"
command = '/usr/bin/python3 "$(git rev-parse --show-toplevel)/.codex/hooks/pre_tool_use_policy.py"'
timeout = 30
statusMessage = "Checking protected paths"
```

## Run

```sh
python3 tmp/prompts-lab/006a-hooks-guard-practice/run_smoke_tests.py
```
