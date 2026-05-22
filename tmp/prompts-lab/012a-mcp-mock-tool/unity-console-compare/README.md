# Unity Console Log: MCP vs CLI

This practice folder compares two ways to expose the same read-only Unity log task.

## Version A: MCP-Shaped Tool

`unity_console_mcp_server.py` exposes one tool:

- `get_unity_console_logs`

The MCP-shaped flow is:

1. Client sends `initialize`.
2. Client sends `tools/list`.
3. Server describes `get_unity_console_logs`.
4. Client sends `tools/call` with arguments like `level`, `count`, and `log_file`.
5. Server returns text content.

This shows how Codex would see a tool menu and decide to call a tool.

## Version B: Non-MCP CLI

`unity_console_cli.py` exposes the same behavior as a normal terminal command:

```sh
python3 tmp/prompts-lab/012a-mcp-mock-tool/unity-console-compare/unity_console_cli.py \
  --level error \
  --count 5 \
  --log-file tmp/prompts-lab/012a-mcp-mock-tool/unity-console-compare/fixtures/editor.log
```

This is simpler when the caller already knows which command to run.

## Smoke Test

```sh
python3 tmp/prompts-lab/012a-mcp-mock-tool/unity-console-compare/smoke_test.py
```

## Important Limits

- This reads a Unity Editor log file, not the live Unity Console panel API.
- This does not modify Unity files.
- This does not register a real MCP server with Codex.
- This does not connect to the existing Unity MCP package.
- A real live Unity Console MCP would need Unity Editor/plugin access or an existing Unity MCP tool that can query Console logs.
