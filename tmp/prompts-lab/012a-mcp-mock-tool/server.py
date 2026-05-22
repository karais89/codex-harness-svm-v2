#!/usr/bin/env python3
"""Tiny dependency-free MCP-shaped stdio server for Prompts Lab 012a.

This intentionally implements only enough JSON-RPC to show how an MCP server
announces tools and handles tool calls. It is not registered with Codex.
"""

from __future__ import annotations

import json
import subprocess
import sys
from pathlib import Path
from typing import Any


SERVER_INFO = {"name": "svm-tiny-mcp", "version": "0.1.0"}
PROTOCOL_VERSION = "2025-06-18"


def write_message(message: dict[str, Any]) -> None:
    sys.stdout.write(json.dumps(message, separators=(",", ":")) + "\n")
    sys.stdout.flush()


def make_response(request_id: str | int, result: dict[str, Any]) -> dict[str, Any]:
    return {"jsonrpc": "2.0", "id": request_id, "result": result}


def make_error(request_id: str | int | None, code: int, message: str) -> dict[str, Any]:
    error: dict[str, Any] = {"code": code, "message": message}
    return {"jsonrpc": "2.0", "id": request_id, "error": error}


def list_tools() -> dict[str, Any]:
    return {
        "tools": [
            {
                "name": "hello",
                "title": "Hello Tool",
                "description": "Return a small greeting from the tiny MCP server.",
                "inputSchema": {
                    "type": "object",
                    "properties": {
                        "name": {
                            "type": "string",
                            "description": "Name to greet.",
                        }
                    },
                    "required": [],
                    "additionalProperties": False,
                },
            },
            {
                "name": "repo_status",
                "title": "Repo Status Summary",
                "description": "Return the current working directory and short git status.",
                "inputSchema": {
                    "type": "object",
                    "properties": {},
                    "required": [],
                    "additionalProperties": False,
                },
            },
        ]
    }


def call_tool(name: str, arguments: dict[str, Any]) -> dict[str, Any]:
    if name == "hello":
        target = str(arguments.get("name") or "MCP learner")
        return text_result(f"Hello, {target}. This came from a tool call.")

    if name == "repo_status":
        cwd = Path.cwd()
        status = subprocess.run(
            ["git", "status", "--short"],
            cwd=cwd,
            text=True,
            capture_output=True,
            check=False,
        )
        summary = status.stdout.strip() or "clean"
        return text_result(f"cwd: {cwd}\ngit status --short: {summary}")

    return {
        "content": [{"type": "text", "text": f"Unknown tool: {name}"}],
        "isError": True,
    }


def text_result(text: str) -> dict[str, Any]:
    return {"content": [{"type": "text", "text": text}], "isError": False}


def handle_request(message: dict[str, Any]) -> dict[str, Any] | None:
    method = message.get("method")
    request_id = message.get("id")

    if request_id is None:
        # Notifications, including notifications/initialized, do not get a reply.
        return None

    if method == "initialize":
        requested = message.get("params", {}).get("protocolVersion")
        return make_response(
            request_id,
            {
                "protocolVersion": requested or PROTOCOL_VERSION,
                "capabilities": {"tools": {"listChanged": False}},
                "serverInfo": SERVER_INFO,
            },
        )

    if method == "tools/list":
        return make_response(request_id, list_tools())

    if method == "tools/call":
        params = message.get("params", {})
        return make_response(
            request_id,
            call_tool(str(params.get("name")), params.get("arguments") or {}),
        )

    return make_error(request_id, -32601, f"Method not found: {method}")


def main() -> int:
    for line in sys.stdin:
        if not line.strip():
            continue
        try:
            message = json.loads(line)
        except json.JSONDecodeError as exc:
            write_message(make_error(None, -32700, f"Parse error: {exc}"))
            continue

        response = handle_request(message)
        if response is not None:
            write_message(response)

    return 0


if __name__ == "__main__":
    raise SystemExit(main())
