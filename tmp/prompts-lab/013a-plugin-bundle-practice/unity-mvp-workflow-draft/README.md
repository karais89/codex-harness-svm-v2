# Unity MVP Workflow Draft

This is a prompts-lab learning draft, not an installable Codex plugin.

It shows how a future Unity MVP workflow plugin could group a small skill, an MCP placeholder, and a manifest-like description into one reusable package boundary.

## Bundle Contents

- `plugin-manifest.draft.json`: learning-only manifest describing the bundle boundary.
- `skills/unity-mvp-scope-review/SKILL.md`: draft skill for reviewing MVP scope before implementation or review.
- `mcp/unity-console-mcp-placeholder.md`: placeholder describing how a future MCP server could expose Unity Console logs.

## What This Teaches

A plugin is not the same thing as a skill or MCP server. A skill describes a repeatable workflow. An MCP server exposes external tools or data. A plugin can package those pieces together so the same workflow can be reused across projects.

## What This Does Not Do

- It does not install a plugin.
- It does not register anything in Codex.
- It does not edit `.codex`, global config, marketplace, Unity files, or package settings.
- It does not prove that the manifest matches the current Codex plugin schema.

## Future Installability Requirements

Before this could become a real plugin, the manifest schema, folder layout, plugin registry or marketplace path, authentication policy, and MCP server launch configuration would need to be verified against current Codex plugin documentation or tooling.
