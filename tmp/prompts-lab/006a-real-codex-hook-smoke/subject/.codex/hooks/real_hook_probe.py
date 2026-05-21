#!/usr/bin/env python3
"""Disposable real Codex hook probe for prompts lab 006a.

This script is intentionally stored under tmp/.../subject/.codex/ and is used
only with `codex exec --dangerously-bypass-hook-trust` in this disposable repo.
"""

from __future__ import annotations

import json
import sys
from datetime import datetime, timezone
from pathlib import Path
from typing import Any


def load_event() -> dict[str, Any]:
    raw = sys.stdin.read()
    if not raw.strip():
        return {"_error": "empty stdin"}
    return json.loads(raw)


def compact(value: Any, limit: int = 300) -> str:
    text = json.dumps(value, ensure_ascii=False, sort_keys=True)
    if len(text) <= limit:
        return text
    return text[: limit - 3] + "..."


def log_event(event: dict[str, Any]) -> None:
    cwd = Path(event.get("cwd") or ".")
    log_path = cwd / ".codex" / "hook-log.jsonl"
    record = {
        "ts": datetime.now(timezone.utc).isoformat(),
        "event": event.get("hook_event_name"),
        "turn_id": event.get("turn_id"),
        "tool_name": event.get("tool_name"),
        "stop_hook_active": event.get("stop_hook_active"),
        "prompt": event.get("prompt"),
        "last_assistant_message": event.get("last_assistant_message"),
        "tool_input_compact": compact(event.get("tool_input")) if "tool_input" in event else None,
    }
    with log_path.open("a", encoding="utf-8") as handle:
        handle.write(json.dumps(record, ensure_ascii=False) + "\n")


def print_json(payload: dict[str, Any]) -> None:
    print(json.dumps(payload, ensure_ascii=False))


def handle_user_prompt_submit(event: dict[str, Any]) -> None:
    print_json(
        {
            "hookSpecificOutput": {
                "hookEventName": "UserPromptSubmit",
                "additionalContext": (
                    "REAL_HOOK_USERPROMPT_CONTEXT: include marker "
                    "USER_PROMPT_HOOK_SEEN in the final response."
                ),
            }
        }
    )


def handle_pre_tool_use(event: dict[str, Any]) -> None:
    tool_input = event.get("tool_input") or {}
    haystack = compact(tool_input, limit=2000)
    if "CODEX_HOOK_BLOCK_ME" in haystack or "ProjectSettings/" in haystack:
        print_json(
            {
                "hookSpecificOutput": {
                    "hookEventName": "PreToolUse",
                    "permissionDecision": "deny",
                    "permissionDecisionReason": (
                        "REAL_HOOK_PRETOOL_BLOCKED: disposable hook denied "
                        "the requested tool call."
                    ),
                }
            }
        )


def handle_stop(event: dict[str, Any]) -> None:
    if event.get("stop_hook_active"):
        return
    print_json(
        {
            "decision": "block",
            "reason": (
                "REAL_HOOK_STOP_CONTINUE: continue once and include marker "
                "STOP_HOOK_CONTINUED in the final response."
            ),
        }
    )


def main() -> int:
    event = load_event()
    log_event(event)
    event_name = event.get("hook_event_name")

    if event_name == "UserPromptSubmit":
        handle_user_prompt_submit(event)
    elif event_name == "PreToolUse":
        handle_pre_tool_use(event)
    elif event_name == "Stop":
        handle_stop(event)

    return 0


if __name__ == "__main__":
    raise SystemExit(main())
