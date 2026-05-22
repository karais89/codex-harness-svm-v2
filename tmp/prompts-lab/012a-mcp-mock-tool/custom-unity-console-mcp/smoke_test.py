#!/usr/bin/env python3
"""Smoke test the custom MCP server against the live Unity Editor bridge."""

from __future__ import annotations

import json
import subprocess
import sys
import urllib.request
from pathlib import Path
from typing import Any


HERE = Path(__file__).resolve().parent
SERVER = HERE / "server.py"
BRIDGE_HEALTH = "http://127.0.0.1:17651/health"


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
    response = receive(proc)
    if response.get("id") != message.get("id"):
        raise AssertionError(f"response id mismatch: {response}")
    if "error" in response:
        raise AssertionError(f"unexpected JSON-RPC error: {response}")
    return response


def main() -> int:
    with urllib.request.urlopen(BRIDGE_HEALTH, timeout=5) as response:
        health = response.read().decode("utf-8")
    assert health == '{"ok":true}', health

    proc = subprocess.Popen(
        [sys.executable, str(SERVER)],
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
                    "clientInfo": {"name": "svm-console-smoke", "version": "0.1.0"},
                },
            },
        )
        send(proc, {"jsonrpc": "2.0", "method": "notifications/initialized"})

        listed = request(proc, {"jsonrpc": "2.0", "id": 2, "method": "tools/list"})
        names = [tool["name"] for tool in listed["result"]["tools"]]
        assert names == ["get_unity_console_logs"], names

        called = request(
            proc,
            {
                "jsonrpc": "2.0",
                "id": 3,
                "method": "tools/call",
                "params": {"name": "get_unity_console_logs", "arguments": {"level": "log", "count": 20}},
            },
        )
        text = called["result"]["content"][0]["text"]
        assert "UnityEditor.LogEntries" in text

        print("PASS bridge /health")
        print("PASS MCP initialize")
        print("PASS MCP tools/list: get_unity_console_logs")
        print("PASS MCP tools/call get_unity_console_logs")
        print("\nResult:")
        print(text)
    finally:
        proc.terminate()
        try:
            proc.wait(timeout=2)
        except subprocess.TimeoutExpired:
            proc.kill()

    return 0


if __name__ == "__main__":
    raise SystemExit(main())
