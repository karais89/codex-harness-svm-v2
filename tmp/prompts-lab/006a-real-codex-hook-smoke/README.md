# 006a Real Codex Hook Smoke

This is a disposable follow-up to the mock 006a hook practice.

Goal:

- Verify whether Codex actually calls `UserPromptSubmit`, `PreToolUse`, and
  `Stop` hooks from a project-local `.codex/hooks.json`.
- Keep all real hook configuration inside `subject/.codex/`.
- Do not modify the parent repo `.codex/`, Unity files, `Packages/`, or
  `ProjectSettings/`.

## What This Experiment Adds

The mock practice proves script logic. This smoke test proves the missing
integration layer:

- Codex discovers project-local hooks.
- Codex asks for hook trust before running them.
- Codex sends real event JSON to the hook script.
- Codex respects the hook output for context, blocking, and continuation.

This is why both experiments exist. The mock is cheap and repeatable; the real
smoke checks whether the same idea actually connects to Codex.

## File Roles

- `subject/.codex/hooks.json`: disposable real hook configuration. It registers
  one command hook for `UserPromptSubmit`, `PreToolUse`, and `Stop`.
- `subject/.codex/hooks/real_hook_probe.py`: the hook script Codex actually
  runs. It logs each event and returns small test outputs.
- `subject/.codex/hook-log.jsonl`: evidence captured from actual Codex runs.
- `subject/README.md`: warning that this is only a disposable subject repo.

The parent repo has no `.codex/` hook config from this experiment.

## Real Hook Code Walkthrough

The real hook has two pieces: registration and behavior.

### Registration: `subject/.codex/hooks.json`

`hooks.json` tells Codex which event should run which command.

- `UserPromptSubmit`: runs before the submitted user prompt is sent into the
  model. This experiment uses it to inject a visible context marker.
- `PreToolUse`: runs before selected tools execute. The matcher is
  `Bash|apply_patch|Edit|Write`, so the script can inspect shell commands and
  file-edit tool calls before they happen.
- `Stop`: runs when Codex is about to finish the turn. This experiment uses it
  to force one continuation.

Every event points to the same script:

```json
"command": "python3 \"$(git rev-parse --show-toplevel)/.codex/hooks/real_hook_probe.py\""
```

That command matters because Codex may start from a subdirectory. Resolving
from `git rev-parse --show-toplevel` keeps the script path tied to the
disposable subject repo root.

### Behavior: `real_hook_probe.py`

The script is intentionally small:

1. `load_event()` reads the JSON event from stdin. This is the real Codex hook
   input.
2. `log_event()` writes a compact record to `.codex/hook-log.jsonl`. This is
   the evidence file proving what Codex actually sent.
3. `main()` checks `hook_event_name` and routes to one of three handlers.

The three handlers demonstrate three different hook outcomes.

`handle_user_prompt_submit(event)` returns additional context:

```json
{
  "hookSpecificOutput": {
    "hookEventName": "UserPromptSubmit",
    "additionalContext": "..."
  }
}
```

Codex does not block the prompt. It adds this context to the turn, which is why
the final answer included `USER_PROMPT_HOOK_SEEN`.

`handle_pre_tool_use(event)` reads `tool_input`, converts it into searchable
text, and denies the tool call when it sees `CODEX_HOOK_BLOCK_ME` or
`ProjectSettings/`:

```json
{
  "hookSpecificOutput": {
    "hookEventName": "PreToolUse",
    "permissionDecision": "deny",
    "permissionDecisionReason": "..."
  }
}
```

This is the closest practice version of a "guard". In the real smoke, Codex
tried to run `echo CODEX_HOOK_BLOCK_ME`, the hook saw that string before Bash
ran, and Codex reported the command as blocked.

`handle_stop(event)` checks `stop_hook_active`:

- If `false`, it returns `decision: "block"` with a reason. For `Stop`, that
  means "continue once", not "reject a tool".
- If `true`, it returns nothing so Codex can finish. This prevents an infinite
  Stop continuation loop.

This is why the log has two Stop entries: first `false`, then `true`.

### What Problem The Code Solved

The code answered the user's main doubt: "How can we know the mock behaves like
Codex?"

The answer is that we cannot know from the mock alone. The real hook code
proved the missing parts:

- Codex really sends JSON on stdin to the hook script.
- `UserPromptSubmit` context is model-visible.
- `PreToolUse` can deny a Bash command before it runs.
- `Stop` can cause one continuation and marks that continuation with
  `stop_hook_active`.

## Actual Flow

The successful flow looked like this:

1. Codex started in `subject/`.
2. Codex discovered `subject/.codex/hooks.json`.
3. The TUI showed a hook review prompt for three changed hooks.
4. After trust, Codex submitted the user prompt.
5. `UserPromptSubmit` ran and returned additional context.
6. Codex attempted the requested Bash command.
7. `PreToolUse` ran before the command and denied it.
8. Codex produced a final message saying the command was blocked.
9. `Stop` ran with `stop_hook_active: false` and asked Codex to continue once.
10. Codex continued, included `STOP_HOOK_CONTINUED`, and then `Stop` ran again
    with `stop_hook_active: true`.

That flow directly answers the original doubt: the mock did not prove Codex
integration, but this disposable smoke did.

## Hook Output Used

`UserPromptSubmit` returned additional context:

```json
{
  "hookSpecificOutput": {
    "hookEventName": "UserPromptSubmit",
    "additionalContext": "..."
  }
}
```

`PreToolUse` denied the Bash command:

```json
{
  "hookSpecificOutput": {
    "hookEventName": "PreToolUse",
    "permissionDecision": "deny",
    "permissionDecisionReason": "..."
  }
}
```

`Stop` requested one continuation:

```json
{
  "decision": "block",
  "reason": "..."
}
```

For `Stop`, `decision: "block"` does not reject a tool call. It asks Codex to
continue the turn with the provided reason.

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

## What Remains Unsolved

This experiment does not decide whether the parent project should adopt hooks.
That still needs a separate product decision:

- Is `ProjectSettings/` blocking too strict during real Unity work?
- Should `Stop` verification checks run for every task or only implementation
  tasks?
- Should Prompts Lab scope drift be blocked or just warned?

Those questions belong in the final selection step, not in this smoke test.
