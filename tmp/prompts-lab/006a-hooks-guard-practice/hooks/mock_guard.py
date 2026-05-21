#!/usr/bin/env python3
"""Learning-only Codex hook guard mock.

This script reads one mock hook event JSON object from stdin and prints a
Codex-like hook response. It is not installed as a real Codex hook.
"""

from __future__ import annotations

import json
import re
import sys
from typing import Any


PROTECTED_PATHS = (
    "ProjectSettings/",
    "Packages/manifest.json",
    "Packages/packages-lock.json",
)

COMPLETION_RE = re.compile(
    r"(completed|complete|done|fixed|implemented|수정 완료|구현 완료|완료|해결)",
    re.IGNORECASE,
)
VERIFICATION_RE = re.compile(
    r"(test|tests|pytest|smoke|build|lint|verified|verification|검증|테스트|통과|실행)",
    re.IGNORECASE,
)
UNITY_IMPLEMENTATION_RE = re.compile(
    r"(Unity 구현|유니티 구현|게임 구현|Safe Village Micro 구현|Assets/|ProjectSettings/|Scene|씬 수정|gameplay)",
    re.IGNORECASE,
)


def read_event() -> dict[str, Any]:
    raw = sys.stdin.read()
    if not raw.strip():
        raise SystemExit("expected hook event JSON on stdin")
    return json.loads(raw)


def iter_strings(value: Any):
    if isinstance(value, str):
        yield value
    elif isinstance(value, dict):
        for item in value.values():
            yield from iter_strings(item)
    elif isinstance(value, list):
        for item in value:
            yield from iter_strings(item)


def emit(value: dict[str, Any]) -> None:
    print(json.dumps(value, ensure_ascii=False, indent=2))


def pre_tool_use(event: dict[str, Any]) -> None:
    tool_name = event.get("tool_name", "")
    tool_input = event.get("tool_input", {})
    haystack = "\n".join(iter_strings(tool_input))

    if tool_name in {"apply_patch", "Bash"}:
        for path in PROTECTED_PATHS:
            if path in haystack:
                emit(
                    {
                        "hookSpecificOutput": {
                            "hookEventName": "PreToolUse",
                            "permissionDecision": "deny",
                            "permissionDecisionReason": (
                                f"Protected Unity path blocked in Prompts Lab: {path}"
                            ),
                        }
                    }
                )
                return


def stop(event: dict[str, Any]) -> None:
    if event.get("stop_hook_active"):
        return

    message = event.get("last_assistant_message") or ""
    if COMPLETION_RE.search(message) and not VERIFICATION_RE.search(message):
        emit(
            {
                "decision": "block",
                "reason": (
                    "Completion was claimed without verification. Continue and "
                    "either run an available check or explicitly report why no "
                    "check was possible."
                ),
            }
        )


def user_prompt_submit(event: dict[str, Any]) -> None:
    prompt = event.get("prompt") or ""
    if UNITY_IMPLEMENTATION_RE.search(prompt):
        emit(
            {
                "hookSpecificOutput": {
                    "hookEventName": "UserPromptSubmit",
                    "additionalContext": (
                        "Prompts Lab scope guard: do not modify Unity assets, "
                        "ProjectSettings, Packages, or gameplay code unless the "
                        "user explicitly exits Prompts Lab."
                    ),
                }
            }
        )


def main() -> int:
    event = read_event()
    event_name = event.get("hook_event_name")

    if event_name == "PreToolUse":
        pre_tool_use(event)
    elif event_name == "Stop":
        stop(event)
    elif event_name == "UserPromptSubmit":
        user_prompt_submit(event)
    else:
        emit({"systemMessage": f"No mock guard implemented for {event_name!r}."})

    return 0


if __name__ == "__main__":
    raise SystemExit(main())
