# MatchThree

## What This Is

A 2D plane Match-3 puzzle game built with Unity. Players swap adjacent tiles to create matches of 3 or more identical tiles. The game features cascade mechanics where matched tiles disappear, tiles fall from above, and chain reactions can occur. Win condition combines a time limit with a target score. Built with Unity's built-in Sprite system for a white-box approach, designed for easy art asset replacement later.

## Core Value

A playable, functional Match-3 game that runs in Unity with minimal manual configuration, demonstrating core mechanics (matching, cascading, scoring, timer) before any art polish.

## Requirements

### Validated

- ✓ **Classic Match-3 Mechanics**: Swap adjacent tiles to match 3+ identical tiles — Phase 1
- ✓ **Cascade System**: After matches clear, tiles fall from above to fill gaps; new tiles spawn at top — Phase 1
- ✓ **Chain Reaction**: Falling tiles that create new matches automatically trigger additional matches — Phase 1
- ✓ **Scoring System**: Points awarded based on match size (3=100, 4=200, 5=500) with combo multipliers — Phase 1
- ✓ **Time Limit**: Countdown timer (60 seconds) — game ends when timer reaches zero — Phase 1
- ✓ **Target Score Win Condition**: Player wins if score reaches target (5000) before time expires — Phase 1
- ✓ **Win/Lose States**: Clear feedback for victory and defeat — Phase 1
- ✓ **White-Box Visuals**: Unity built-in sprites with 6 distinct colors — Phase 1
- ✓ **Grid System**: 8x8 tile grid as the playfield — Phase 1
- ✓ **ScriptableTileConfig**: Centralized tile configuration — Phase 1

### Out of Scope

- **Special tiles** (bombs, lightning) — classic mechanics only
- **Power-ups or boosters** — scope control
- **Sound/Audio** — can be added later
- **Multiple game modes** — single timedsurvivor mode
- **Particle effects or animations** — white-box phase only
- **Leaderboards or online features** — single-player only

## Context

- **Tech Stack**: Unity 2022+ with built-in 2D Sprite system
- **Art Strategy**: White-box first using solid-color sprites; swap textures later without changing logic
- **No existing code**: Brand new Unity project
- **Target platform**: Unity Play mode (editor testing sufficient for v1)

## Constraints

- **Tech Stack**: Unity built-in sprites only — no external assets or packages
- **Minimal Manual Config**: Game should be playable immediately upon script import, with sensible defaults
- **Easy Asset Swap**: All visual configs in one place (ScriptableTileConfig), no hardcoded colors in game logic
- **2D Plane**: Top-down 2D view, no perspective or 3D elements

## Key Decisions

| Decision | Rationale | Outcome |
|----------|-----------|---------|
| 8x8 grid | Standard Match-3 size; not too small (boring) not too large (overwhelming) | — Pending |
| 6 tile colors | Enough variety for interesting matches without overwhelming | — Pending |
| 60 second timer | Good balance for quick rounds | — Pending |
| 100/200/500 points for 3/4/5 match | Exponential reward for bigger matches | — Pending |
| Cascade combo multiplier | 1.5x multiplier per chain level | — Pending |

---

*Last updated: 2026-03-26 after Phase 1 completion*
