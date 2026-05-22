#!/usr/bin/env python3
"""Minimal custom MCP server that asks our Unity Editor bridge for Console logs."""

from __future__ import annotations

import json
import sys
import urllib.parse
import urllib.request
from typing import Any


BRIDGE_URL = "http://127.0.0.1:17651"
PROTOCOL_VERSION = "2025-06-18"


def write(message: dict[str, Any]) -> None:
    sys.stdout.write(json.dumps(message, separators=(",", ":")) + "\n")
    sys.stdout.flush()


def result(request_id: str | int, payload: dict[str, Any]) -> dict[str, Any]:
    return {"jsonrpc": "2.0", "id": request_id, "result": payload}


def error(request_id: str | int | None, code: int, message: str) -> dict[str, Any]:
    return {"jsonrpc": "2.0", "id": request_id, "error": {"code": code, "message": message}}


def tools() -> dict[str, Any]:
    return {
        "tools": [
            {
                "name": "get_unity_console_logs",
                "title": "Get Unity Console Logs",
                "description": "Read live Unity Console panel entries through the custom Editor bridge.",
                "inputSchema": {
                    "type": "object",
                    "properties": {
                        "level": {"type": "string", "enum": ["error", "warning", "log"]},
                        "count": {"type": "integer", "minimum": 1, "maximum": 100},
                    },
                    "required": [],
                    "additionalProperties": False,
                },
            }
        ]
    }


def call_tool(name: str, args: dict[str, Any]) -> dict[str, Any]:
    if name != "get_unity_console_logs":
        return text(f"Unknown tool: {name}", is_error=True)

    level = str(args.get("level") or "error")
    count = int(args.get("count") or 20)
    query = urllib.parse.urlencode({"level": level, "count": count})
    url = f"{BRIDGE_URL}/console?{query}"

    try:
        with urllib.request.urlopen(url, timeout=5) as response:
            body = response.read().decode("utf-8")
    except Exception as exc:
        return text(f"Unity Console bridge is not reachable: {exc}", is_error=True)

    data = json.loads(body)
    lines = data.get("logs") or []
    if lines:
        rendered = "\n".join(f"- {line}" for line in lines)
    else:
        rendered = "- no matching Unity Console entries"

    return text(
        f"source: {data.get('source')}\n"
        f"level: {data.get('level')}\n"
        f"matched: {data.get('count')}\n"
        f"{rendered}"
    )


def text(value: str, *, is_error: bool = False) -> dict[str, Any]:
    return {"content": [{"type": "text", "text": value}], "isError": is_error}


def handle(message: dict[str, Any]) -> dict[str, Any] | None:
    request_id = message.get("id")
    method = message.get("method")

    if request_id is None:
        return None

    if method == "initialize":
        return result(
            request_id,
            {
                "protocolVersion": message.get("params", {}).get("protocolVersion") or PROTOCOL_VERSION,
                "capabilities": {"tools": {"listChanged": False}},
                "serverInfo": {"name": "svm-custom-unity-console-mcp", "version": "0.1.0"},
            },
        )

    if method == "tools/list":
        return result(request_id, tools())

    if method == "tools/call":
        params = message.get("params", {})
        return result(request_id, call_tool(str(params.get("name")), params.get("arguments") or {}))

    return error(request_id, -32601, f"Method not found: {method}")


def main() -> int:
    for line in sys.stdin:
        if not line.strip():
            continue
        try:
            reply = handle(json.loads(line))
        except json.JSONDecodeError as exc:
            write(error(None, -32700, f"Parse error: {exc}"))
            continue

        if reply is not None:
            write(reply)
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
