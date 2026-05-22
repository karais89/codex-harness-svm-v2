# 012a Tiny MCP Mock Tool

This is a dependency-free Prompts Lab practice artifact.

It demonstrates the smallest useful MCP-shaped flow:

1. `initialize`
2. `notifications/initialized`
3. `tools/list`
4. `tools/call`

The server exposes two tools:

- `hello`: returns a greeting.
- `repo_status`: returns the current working directory and `git status --short`.

## Run

```sh
python3 tmp/prompts-lab/012a-mcp-mock-tool/smoke_test.py
```

## What This Verifies

- The server can receive JSON-RPC messages over stdio.
- The server can announce available tools.
- A local smoke client can call those tools and parse the result.

## What This Does Not Verify

- This is not registered in Codex as an MCP server.
- Codex did not call this tool through its MCP client.
- This does not connect to Unity Editor.
- This does not modify `.codex/`, global config, `Assets/`, `Packages/`, or `ProjectSettings/`.
