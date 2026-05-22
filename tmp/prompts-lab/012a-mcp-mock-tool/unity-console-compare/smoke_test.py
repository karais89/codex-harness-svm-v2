#!/usr/bin/env python3
"""Compare the MCP-shaped server and non-MCP CLI against the same fixture."""

from __future__ import annotations

import json
import subprocess
import sys
from pathlib import Path
from typing import Any


HERE = Path(__file__).resolve().parent
REPO_ROOT = HERE.parents[3]
SERVER = HERE / "unity_console_mcp_server.py"
CLI = HERE / "unity_console_cli.py"
FIXTURE = HERE / "fixtures" / "editor.log"


def send(proc: subprocess.Popen[str], message: dict[str, Any]) -> None:
    assert proc.stdin is not None
    proc.stdin.write(json.dumps(message) + "\n")
    proc.stdin.flush()


def receive(proc: subprocess.Popen[str]) -> dict[str, Any]:
    assert proc.stdout is not None
    line = proc.stdout.readline()
    if not line:
        raise RuntimeError("server closed stdout")
    return json.loads(line)


def request(proc: subprocess.Popen[str], message: dict[str, Any]) -> dict[str, Any]:
    send(proc, message)
    reply = receive(proc)
    if reply.get("id") != message.get("id"):
        raise AssertionError(f"response id mismatch: {reply}")
    if "error" in reply:
        raise AssertionError(f"unexpected error: {reply}")
    return reply


def smoke_mcp() -> str:
    proc = subprocess.Popen(
        [sys.executable, str(SERVER)],
        cwd=REPO_ROOT,
        stdin=subprocess.PIPE,
        stdout=subprocess.PIPE,
        stderr=subprocess.PIPE,
        text=True,
    )
    try:
        request(
            proc,
            {
                "jsonrpc": "2.0",
                "id": 1,
                "method": "initialize",
                "params": {
                    "protocolVersion": "2025-06-18",
                    "capabilities": {},
                    "clientInfo": {"name": "console-compare-smoke", "version": "0.1.0"},
                },
            },
        )
        send(proc, {"jsonrpc": "2.0", "method": "notifications/initialized"})

        tools = request(proc, {"jsonrpc": "2.0", "id": 2, "method": "tools/list"})
        names = [tool["name"] for tool in tools["result"]["tools"]]
        assert names == ["get_unity_console_logs"], names

        result = request(
            proc,
            {
                "jsonrpc": "2.0",
                "id": 3,
                "method": "tools/call",
                "params": {
                    "name": "get_unity_console_logs",
                    "arguments": {
                        "level": "error",
                        "count": 5,
                        "log_file": str(FIXTURE),
                    },
                },
            },
        )
        text = result["result"]["content"][0]["text"]
        assert "NullReferenceException" in text
        return text
    finally:
        proc.terminate()
        try:
            proc.wait(timeout=2)
        except subprocess.TimeoutExpired:
            proc.kill()


def smoke_cli() -> str:
    result = subprocess.run(
        [
            sys.executable,
            str(CLI),
            "--level",
            "error",
            "--count",
            "5",
            "--log-file",
            str(FIXTURE),
        ],
        cwd=REPO_ROOT,
        text=True,
        capture_output=True,
        check=True,
    )
    assert "NullReferenceException" in result.stdout
    return result.stdout


def main() -> int:
    mcp_text = smoke_mcp()
    cli_text = smoke_cli()

    print("PASS MCP version: tools/list + tools/call returned fixture error")
    print("PASS CLI version: command returned fixture error")
    print("\nMCP result excerpt:")
    print(mcp_text)
    print("\nCLI result excerpt:")
    print(cli_text.strip())
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
