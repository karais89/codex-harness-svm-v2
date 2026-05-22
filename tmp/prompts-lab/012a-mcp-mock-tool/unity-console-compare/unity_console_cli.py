#!/usr/bin/env python3
"""Non-MCP CLI version of the same Unity log reader."""

from __future__ import annotations

import argparse
from pathlib import Path

from log_source import format_log_summary, read_recent_unity_logs


REPO_ROOT = Path(__file__).resolve().parents[4]


def main() -> int:
    parser = argparse.ArgumentParser(description="Read recent Unity Editor log lines.")
    parser.add_argument("--level", choices=["error", "warning", "log"], default="error")
    parser.add_argument("--count", type=int, default=20)
    parser.add_argument("--log-file", help="Optional explicit Unity Editor log file path.")
    args = parser.parse_args()

    summary = read_recent_unity_logs(
        REPO_ROOT,
        level=args.level,
        count=args.count,
        log_file=args.log_file,
    )
    print(format_log_summary(summary))
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
