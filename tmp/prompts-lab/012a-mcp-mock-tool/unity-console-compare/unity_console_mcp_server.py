#!/usr/bin/env python3
"""Minimal MCP-shaped server exposing a Unity console log reader tool.

This is a learning artifact. It is not registered with Codex and it does not
connect to the live Unity Console panel. The tool reads a Unity Editor log file.
"""

from __future__ import annotations

import json
import sys
from pathlib import Path
from typing import Any

from log_source import format_log_summary, read_recent_unity_logs


SERVER_INFO = {"name": "svm-unity-console-log-mcp", "version": "0.1.0"}
PROTOCOL_VERSION = "2025-06-18"
REPO_ROOT = Path(__file__).resolve().parents[4]


def write_message(message: dict[str, Any]) -> None:
    sys.stdout.write(json.dumps(message, separators=(",", ":")) + "\n")
    sys.stdout.flush()


def response(request_id: str | int, result: dict[str, Any]) -> dict[str, Any]:
    return {"jsonrpc": "2.0", "id": request_id, "result": result}


def error(request_id: str | int | None, code: int, message: str) -> dict[str, Any]:
    return {"jsonrpc": "2.0", "id": request_id, "error": {"code": code, "message": message}}


def tool_list() -> dict[str, Any]:
    return {
        "tools": [
            {
                "name": "get_unity_console_logs",
                "title": "Get Unity Console Logs",
                "description": "Read recent Unity Editor log lines filtered by level.",
                "inputSchema": {
                    "type": "object",
                    "properties": {
                        "level": {
                            "type": "string",
                            "enum": ["error", "warning", "log"],
                            "description": "Filter level to return.",
                        },
                        "count": {
                            "type": "integer",
                            "description": "Maximum number of matching lines to return.",
                            "minimum": 1,
                            "maximum": 100,
                        },
                        "log_file": {
                            "type": "string",
                            "description": "Optional explicit log file path for deterministic tests.",
                        },
                    },
                    "required": [],
                    "additionalProperties": False,
                },
            }
        ]
    }


def call_tool(name: str, arguments: dict[str, Any]) -> dict[str, Any]:
    if name != "get_unity_console_logs":
        return text_result(f"Unknown tool: {name}", is_error=True)

    try:
        summary = read_recent_unity_logs(
            REPO_ROOT,
            level=str(arguments.get("level") or "error"),
            count=int(arguments.get("count") or 20),
            log_file=arguments.get("log_file"),
        )
    except Exception as exc:
        return text_result(str(exc), is_error=True)

    return text_result(format_log_summary(summary))


def text_result(text: str, *, is_error: bool = False) -> dict[str, Any]:
    return {"content": [{"type": "text", "text": text}], "isError": is_error}


def handle(message: dict[str, Any]) -> dict[str, Any] | None:
    method = message.get("method")
    request_id = message.get("id")

    if request_id is None:
        return None

    if method == "initialize":
        params = message.get("params", {})
        return response(
            request_id,
            {
                "protocolVersion": params.get("protocolVersion") or PROTOCOL_VERSION,
                "capabilities": {"tools": {"listChanged": False}},
                "serverInfo": SERVER_INFO,
            },
        )

    if method == "tools/list":
        return response(request_id, tool_list())

    if method == "tools/call":
        params = message.get("params", {})
        return response(request_id, call_tool(str(params.get("name")), params.get("arguments") or {}))

    return error(request_id, -32601, f"Method not found: {method}")


def main() -> int:
    for line in sys.stdin:
        if not line.strip():
            continue
        try:
            message = json.loads(line)
        except json.JSONDecodeError as exc:
            write_message(error(None, -32700, f"Parse error: {exc}"))
            continue

        result = handle(message)
        if result is not None:
            write_message(result)
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
