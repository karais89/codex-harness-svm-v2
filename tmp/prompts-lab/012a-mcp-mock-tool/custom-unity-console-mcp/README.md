# Custom Unity Console MCP

This is the corrected practice artifact.

It does not use a prebuilt Unity MCP package. It demonstrates the smallest custom path:

```text
MCP client
  -> server.py
    -> http://127.0.0.1:17651/console
      -> Assets/Editor/PromptsLab/SvmConsoleLogBridge.cs
        -> UnityEditor.LogEntries
```

## Unity Side

`Assets/Editor/PromptsLab/SvmConsoleLogBridge.cs` starts a local read-only HTTP bridge inside Unity Editor.

Endpoints:

- `GET /health`
- `GET /console?level=error&count=20`

The bridge reflects `UnityEditor.LogEntries`, which is the closest minimal way to read the actual Unity Console panel entries.

## MCP Side

`server.py` is a tiny stdio MCP server that exposes:

- `get_unity_console_logs`

The MCP server calls the Unity bridge, formats the returned Console entries, and returns MCP `content`.

## Smoke Test

Open this Unity project first so the Editor script compiles and starts the bridge. Then run:

```sh
python3 -B tmp/prompts-lab/012a-mcp-mock-tool/custom-unity-console-mcp/smoke_test.py
```

## Limits

- This is a learning implementation, not a production Unity MCP package.
- It only exposes one read-only tool.
- It does not register the MCP server in Codex config.
- `UnityEditor.LogEntries` is an internal Unity API and may change across Unity versions.
