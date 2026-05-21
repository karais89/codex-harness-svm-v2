# 006a Real Codex Hook Smoke

This is a disposable follow-up to the mock 006a hook practice.

Goal:

- Verify whether Codex actually calls `UserPromptSubmit`, `PreToolUse`, and
  `Stop` hooks from a project-local `.codex/hooks.json`.
- Keep all real hook configuration inside `subject/.codex/`.
- Do not modify the parent repo `.codex/`, Unity files, `Packages/`, or
  `ProjectSettings/`.

Expected proof:

- `subject/.codex/hook-log.jsonl` contains hook events written by the real
  Codex hook process.
- The final `codex exec` output includes markers requested by hook-provided
  context or continuation prompts.

## Result

Verified on 2026-05-21 KST with Codex CLI `0.132.0`.

Observed sequence:

1. Running `codex exec` before trusting the project hooks did not produce
   `subject/.codex/hook-log.jsonl`.
2. Running the normal Codex TUI from `subject/` showed `3 hooks are new or
   changed`; after choosing `Trust all and continue`, the hooks ran.
3. After trust, `codex exec` from `subject/` also ran the hooks.

Proof in `subject/.codex/hook-log.jsonl`:

- `UserPromptSubmit` logged the submitted prompt and supplied context that
  caused the final answer to include `USER_PROMPT_HOOK_SEEN`.
- `PreToolUse` logged `tool_name: "Bash"` and `tool_input.command:
  "echo CODEX_HOOK_BLOCK_ME"`, then denied the command.
- `Stop` ran once with `stop_hook_active: false`, returned continuation
  feedback, then ran again with `stop_hook_active: true`.

Important boundary:

- The earlier mock test proves policy/script logic.
- This smoke test proves real Codex lifecycle integration in this local CLI
  path after hook trust.
- It still does not prove this exact hook policy is safe enough for the parent
  Unity project.
