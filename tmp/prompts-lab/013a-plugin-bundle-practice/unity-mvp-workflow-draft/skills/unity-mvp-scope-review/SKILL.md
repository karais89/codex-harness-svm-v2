---
name: unity-mvp-scope-review
description: Use when explicitly asked to review whether a Unity MVP task or diff stays inside the current playable-loop scope.
---

# Unity MVP Scope Review

This is a draft skill for a future plugin. It should be invoked explicitly, not automatically.

## Goal

Decide whether a requested Unity MVP change stays inside the current playable-loop scope.

## Inputs To Check

- The current user request.
- The current project goal or playable-loop note, if one exists.
- The changed file list or proposed file list.
- Any validation command or Unity Editor check requested by the user.

## Review Steps

1. State the assumed MVP scope in one or two sentences.
2. List the requested change in concrete terms.
3. Classify each part as `inside scope`, `borderline`, or `outside scope`.
4. For `borderline` or `outside scope` items, propose the smallest narrower version.
5. Name the verification step that would prove the scoped version works.

## Output Format

```text
Scope assumption:

Inside scope:

Borderline:

Outside scope:

Smallest useful version:

Verification:
```

## Non-Goals

- Do not edit Unity files.
- Do not expand the MVP.
- Do not create new systems only because they might be useful later.
- Do not replace project-specific AGENTS.md instructions.
