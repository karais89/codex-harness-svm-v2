#!/usr/bin/env python3
"""Run the mock hook guard against every fixture."""

from __future__ import annotations

import json
import subprocess
import sys
from pathlib import Path
from typing import Any


ROOT = Path(__file__).resolve().parent
GUARD = ROOT / "hooks" / "mock_guard.py"
FIXTURES = ROOT / "fixtures"


def classify(event: dict[str, Any], stdout: str, stderr: str, returncode: int) -> str:
    if returncode == 2:
        if event.get("hook_event_name") == "Stop":
            return "continued"
        return "blocked"

    if not stdout.strip() and not stderr.strip() and returncode == 0:
        return "passed"

    try:
        payload = json.loads(stdout)
    except json.JSONDecodeError:
        return "errored"

    if payload.get("decision") == "block":
        if event.get("hook_event_name") == "Stop":
            return "continued"
        return "blocked"

    hook_output = payload.get("hookSpecificOutput") or {}
    if hook_output.get("permissionDecision") == "deny":
        return "blocked"
    if hook_output.get("additionalContext"):
        return "context"
    if payload.get("systemMessage"):
        return "warning"
    return "passed"


def run_fixture(path: Path) -> tuple[str, str, str]:
    event = json.loads(path.read_text(encoding="utf-8"))
    expected = event.get("_lab", {}).get("expected", "unknown")
    proc = subprocess.run(
        [sys.executable, str(GUARD)],
        input=json.dumps(event, ensure_ascii=False),
        text=True,
        capture_output=True,
        check=False,
    )
    actual = classify(event, proc.stdout, proc.stderr, proc.returncode)
    return expected, actual, proc.stdout.strip() or proc.stderr.strip()


def main() -> int:
    failed = False
    for path in sorted(FIXTURES.glob("*.json")):
        expected, actual, detail = run_fixture(path)
        ok = expected == actual
        failed = failed or not ok
        marker = "PASS" if ok else "FAIL"
        print(f"{marker} {path.name}: expected={expected} actual={actual}")
        if detail:
            compact = " ".join(detail.split())
            print(f"  detail: {compact[:220]}")

    return 1 if failed else 0


if __name__ == "__main__":
    raise SystemExit(main())
