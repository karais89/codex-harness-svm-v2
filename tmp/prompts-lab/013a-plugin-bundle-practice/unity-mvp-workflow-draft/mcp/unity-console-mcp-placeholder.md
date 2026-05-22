# Unity Console MCP Placeholder

This is a placeholder, not a running MCP server.

It represents a future read-only MCP component that could expose Unity Console entries to Codex during MVP development.

## Source Experiment

The related prompts-lab experiment is `docs/prompt-results/012a-mcp-mock-tool.md`.

That experiment verified a learning implementation where:

- Unity Editor bridge code reads Console entries from `UnityEditor.LogEntries`.
- A Python MCP-shaped server exposes a `get_unity_console_logs` tool.
- A smoke test checks bridge health, `initialize`, `tools/list`, and `tools/call`.

## Future Plugin Role

If this became part of a real plugin, the MCP component would be responsible for:

- starting or documenting a read-only Unity Console log server,
- exposing a narrow `get_unity_console_logs` tool,
- keeping mutation out of the default workflow,
- separating actual MCP registration from local learning scripts.

## Not Verified Here

- Codex MCP server registration.
- Current MCP config format.
- Transport compatibility beyond the previous learning smoke test.
- Plugin-managed MCP server lifecycle.
