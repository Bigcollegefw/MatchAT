# Roadmap: MatchThree

**Created:** 2026-03-26
**Granularity:** Coarse
**Parallelization:** true

## Summary

| Phase | Name | Goal | Requirements | Success Criteria |
|-------|------|------|--------------|-----------------|
| 1 | Core Mechanics | Grid, matching, cascading, scoring, config | 24 | 4 |
| 2 | Game Flow & UI | Win/lose states, UI layout | 5 | 3 |

**Total:** 2 phases | **29 requirements** | All covered ✓

---

## Phase 1: Core Mechanics

**Goal:** Implement the foundational Match-3 grid, tile matching logic, cascade system, and scoring. Create configuration assets for easy tweaking.

### Requirements
CORE-01, CORE-02, CORE-03, CORE-04, CORE-05, CORE-06, CORE-07, CORE-08, CORE-09, CORE-10, SCOR-01, SCOR-02, SCOR-03, SCOR-04, SCOR-05, VISU-01, VISU-02, VISU-03, CONF-01, CONF-02, CONF-03, CONF-04, FLOW-01, FLOW-02, FLOW-03, FLOW-04

### Success Criteria
1. Player can swap tiles and matches of 3+ are detected and cleared
2. Cascading works: tiles fall, new tiles spawn, chain reactions occur
3. Score updates correctly with combo multipliers
4. All tile colors configurable via ScriptableTileConfig

### Files to Create
- `Assets/Scripts/Configs/ScriptableTileConfig.cs` — tile color/type definitions
- `Assets/Scripts/Configs/GridConfig.cs` — grid dimensions
- `Assets/Scripts/Configs/GameConfig.cs` — timer, target score, points
- `Assets/Scripts/Grid/Tile.cs` — individual tile data
- `Assets/Scripts/Grid/GridManager.cs` — 8x8 grid, tile spawning
- `Assets/Scripts/Matching/MatchDetector.cs` — find matches (row/column)
- `Assets/Scripts/Matching/MatchClearer.cs` — remove matched tiles
- `Assets/Scripts/Matching/CascadeManager.cs` — handle falling tiles, chains
- `Assets/Scripts/Scoring/ScoreManager.cs` — points, combo multiplier
- `Assets/Scripts/UI/ScoreDisplay.cs` — show current score
- `Assets/Scripts/UI/TimerDisplay.cs` — show countdown timer

---

## Phase 2: Game Flow & UI

**Goal:** Implement win/lose conditions, end-game screens, and polish UI layout.

### Requirements
FLOW-05, FLOW-06, VISU-04

### Success Criteria
1. Win screen appears when target score (5000) reached before time expires
2. Lose screen appears when timer reaches 0 before target score
3. UI elements are clearly positioned and readable

### Files to Create
- `Assets/Scripts/GameFlow/GameStateManager.cs` — track game state (playing, won, lost)
- `Assets/Scripts/UI/WinScreen.cs` — victory overlay
- `Assets/Scripts/UI/LoseScreen.cs` — defeat overlay

---

## Phase Completion

| Phase | Status | Completed |
|-------|--------|-----------|
| Phase 1: Core Mechanics | [x] Complete | 2026-03-26 |
| Phase 2: Game Flow & UI | Pending | — |

---

*Roadmap created: 2026-03-26*
