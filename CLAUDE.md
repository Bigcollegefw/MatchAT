<!-- GSD:project-start source:PROJECT.md -->
## Project

**MatchThree**

A 2D plane Match-3 puzzle game built with Unity. Players swap adjacent tiles to create matches of 3 or more identical tiles. The game features cascade mechanics where matched tiles disappear, tiles fall from above, and chain reactions can occur. Win condition combines a time limit with a target score. Built with Unity's built-in Sprite system for a white-box approach, designed for easy art asset replacement later.

**Core Value:** A playable, functional Match-3 game that runs in Unity with minimal manual configuration, demonstrating core mechanics (matching, cascading, scoring, timer) before any art polish.

### Constraints

- **Tech Stack**: Unity built-in sprites only — no external assets or packages
- **Minimal Manual Config**: Game should be playable immediately upon script import, with sensible defaults
- **Easy Asset Swap**: All visual configs in one place (ScriptableTileConfig), no hardcoded colors in game logic
- **2D Plane**: Top-down 2D view, no perspective or 3D elements
<!-- GSD:project-end -->

<!-- GSD:stack-start source:STACK.md -->
## Technology Stack

Technology stack not yet documented. Will populate after codebase mapping or first phase.
<!-- GSD:stack-end -->

<!-- GSD:conventions-start source:CONVENTIONS.md -->
## Conventions

Conventions not yet established. Will populate as patterns emerge during development.
<!-- GSD:conventions-end -->

<!-- GSD:architecture-start source:ARCHITECTURE.md -->
## Architecture

Architecture not yet mapped. Follow existing patterns found in the codebase.
<!-- GSD:architecture-end -->

<!-- GSD:workflow-start source:GSD defaults -->
## GSD Workflow Enforcement

Before using Edit, Write, or other file-changing tools, start work through a GSD command so planning artifacts and execution context stay in sync.

Use these entry points:
- `/gsd:quick` for small fixes, doc updates, and ad-hoc tasks
- `/gsd:debug` for investigation and bug fixing
- `/gsd:execute-phase` for planned phase work

Do not make direct repo edits outside a GSD workflow unless the user explicitly asks to bypass it.
<!-- GSD:workflow-end -->



<!-- GSD:profile-start -->
## Developer Profile

> Profile not yet configured. Run `/gsd:profile-user` to generate your developer profile.
> This section is managed by `generate-claude-profile` -- do not edit manually.
<!-- GSD:profile-end -->
