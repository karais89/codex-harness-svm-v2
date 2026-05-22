#!/usr/bin/env python3
"""Shared read-only Unity log helpers for the MCP-vs-CLI comparison."""

from __future__ import annotations

import os
from pathlib import Path


LEVEL_MARKERS = {
    "error": ("error", "exception", "failed", "assertion"),
    "warning": ("warning", "warn"),
    "log": (),
}


def candidate_log_paths(repo_root: Path) -> list[Path]:
    paths: list[Path] = []

    explicit = os.environ.get("UNITY_EDITOR_LOG")
    if explicit:
        paths.append(Path(explicit).expanduser())

    paths.extend(
        [
            repo_root / "Library" / "Logs" / "Unity" / "Editor.log",
            Path.home() / "Library" / "Logs" / "Unity" / "Editor.log",
            Path.home() / "Library" / "Logs" / "Unity" / "Editor-prev.log",
        ]
    )
    return paths


def resolve_log_path(repo_root: Path, log_file: str | None) -> Path:
    if log_file:
        return Path(log_file).expanduser().resolve()

    for path in candidate_log_paths(repo_root):
        if path.exists():
            return path

    checked = "\n".join(str(path) for path in candidate_log_paths(repo_root))
    raise FileNotFoundError(f"No Unity Editor log found. Checked:\n{checked}")


def read_recent_unity_logs(
    repo_root: Path,
    *,
    level: str = "error",
    count: int = 20,
    log_file: str | None = None,
) -> dict[str, object]:
    if level not in LEVEL_MARKERS:
        raise ValueError("level must be one of: error, warning, log")
    if count < 1:
        raise ValueError("count must be >= 1")

    path = resolve_log_path(repo_root, log_file)
    lines = path.read_text(encoding="utf-8", errors="replace").splitlines()
    markers = LEVEL_MARKERS[level]

    if markers:
        matched = [line for line in lines if any(marker in line.lower() for marker in markers)]
    else:
        matched = lines

    recent = matched[-count:]
    return {
        "source": str(path),
        "level": level,
        "count": len(recent),
        "logs": recent,
    }


def format_log_summary(summary: dict[str, object]) -> str:
    logs = summary["logs"]
    assert isinstance(logs, list)

    if logs:
        body = "\n".join(f"- {line}" for line in logs)
    else:
        body = "- no matching log lines"

    return (
        f"source: {summary['source']}\n"
        f"level: {summary['level']}\n"
        f"matched: {summary['count']}\n"
        f"{body}"
    )
