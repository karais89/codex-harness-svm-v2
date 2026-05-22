#!/usr/bin/env python3
"""Smoke test for the tiny MCP-shaped stdio server."""

from __future__ import annotations

import json
import subprocess
import sys
from pathlib import Path
from typing import Any


ROOT = Path(__file__).resolve().parents[3]
SERVER = Path(__file__).with_name("server.py")


def send(proc: subprocess.Popen[str], message: dict[str, Any]) -> None:
    assert proc.stdin is not None
    proc.stdin.write(json.dumps(message) + "\n")
    proc.stdin.flush()


def receive(proc: subprocess.Popen[str]) -> dict[str, Any]:
    assert proc.stdout is not None
    line = proc.stdout.readline()
    if not line:
        raise RuntimeError("server closed stdout before sending a response")
    return json.loads(line)


def request(proc: subprocess.Popen[str], message: dict[str, Any]) -> dict[str, Any]:
    send(proc, message)
    response = receive(proc)
    if response.get("id") != message.get("id"):
        raise AssertionError(f"response id mismatch: {response}")
    if "error" in response:
        raise AssertionError(f"unexpected error response: {response}")
    return response


def main() -> int:
    proc = subprocess.Popen(
        [sys.executable, str(SERVER)],
        cwd=ROOT,
        stdin=subprocess.PIPE,
        stdout=subprocess.PIPE,
        stderr=subprocess.PIPE,
        text=True,
    )

    try:
        init = request(
            proc,
            {
                "jsonrpc": "2.0",
                "id": 1,
                "method": "initialize",
                "params": {
                    "protocolVersion": "2025-06-18",
                    "capabilities": {},
                    "clientInfo": {"name": "012a-smoke-client", "version": "0.1.0"},
                },
            },
        )
        assert init["result"]["capabilities"]["tools"]["listChanged"] is False

        send(proc, {"jsonrpc": "2.0", "method": "notifications/initialized"})

        tools = request(proc, {"jsonrpc": "2.0", "id": 2, "method": "tools/list"})
        names = [tool["name"] for tool in tools["result"]["tools"]]
        assert names == ["hello", "repo_status"], names

        hello = request(
            proc,
            {
                "jsonrpc": "2.0",
                "id": 3,
                "method": "tools/call",
                "params": {"name": "hello", "arguments": {"name": "Safe Village"}},
            },
        )
        hello_text = hello["result"]["content"][0]["text"]
        assert "Safe Village" in hello_text

        status = request(
            proc,
            {
                "jsonrpc": "2.0",
                "id": 4,
                "method": "tools/call",
                "params": {"name": "repo_status", "arguments": {}},
            },
        )
        status_text = status["result"]["content"][0]["text"]
        assert "git status --short:" in status_text

        print("PASS initialize")
        print(f"PASS tools/list: {', '.join(names)}")
        print(f"PASS tools/call hello: {hello_text}")
        print("PASS tools/call repo_status")
    finally:
        proc.terminate()
        try:
            proc.wait(timeout=2)
        except subprocess.TimeoutExpired:
            proc.kill()

    return 0


if __name__ == "__main__":
    raise SystemExit(main())
