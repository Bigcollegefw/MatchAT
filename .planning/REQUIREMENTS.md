# Requirements: MatchThree

**Defined:** 2026-03-26
**Core Value:** A playable, functional Match-3 game that runs in Unity with minimal manual configuration

## v1 Requirements

### Core Mechanics

- [ ] **CORE-01**: 8x8 grid of tiles is displayed on screen
- [ ] **CORE-02**: Player can swap adjacent tiles (horizontally or vertically adjacent only)
- [ ] **CORE-03**: Swapping only allowed if it creates a match of 3+ tiles
- [ ] **CORE-04**: Invalid swaps snap back to original position
- [ ] **CORE-05**: Matches of 3+ identical tiles in a row are detected and cleared
- [ ] **CORE-06**: Matches of 3+ identical tiles in a column are detected and cleared
- [ ] **CORE-07**: Cleared tiles are removed and tiles above fall down to fill gaps
- [ ] **CORE-08**: New tiles spawn at the top to fill empty spaces
- [ ] **CORE-09**: Cascade: tiles falling that create new matches trigger additional matches
- [ ] **CORE-10**: Cascade chain continues until no new matches are formed

### Scoring

- [ ] **SCOR-01**: Matching 3 tiles awards 100 points
- [ ] **SCOR-02**: Matching 4 tiles awards 200 points
- [ ] **SCOR-03**: Matching 5+ tiles awards 500 points
- [ ] **SCOR-04**: Cascade combos award 1.5x multiplier per chain level
- [ ] **SCOR-05**: Score display updates in real-time

### Game Flow

- [ ] **FLOW-01**: Game starts immediately on scene load
- [ ] **FLOW-02**: 60-second countdown timer displays on screen
- [ ] **FLOW-03**: Target score is 5000 points
- [ ] **FLOW-04**: Game ends when timer reaches 0 OR target score is reached
- [ ] **FLOW-05**: Win screen displays when target score reached before time expires
- [ ] **FLOW-06**: Lose screen displays when time expires before reaching target score

### Visual

- [ ] **VISU-01**: 6 distinct tile colors using Unity Sprites
- [ ] **VISU-02**: Tile colors are configurable via ScriptableTileConfig (no hardcoding)
- [ ] **VISU-03**: Grid is centered on screen
- [ ] **VISU-04**: UI elements (score, timer) are positioned clearly

### Configuration

- [ ] **CONF-01**: All tile colors defined in ScriptableTileConfig asset
- [ ] **CONF-02**: Grid dimensions (8x8) configurable in GridConfig
- [ ] **CONF-03**: Game rules (timer, target score) configurable in GameConfig
- [ ] **CONF-04**: No manual prefab wiring required — scripts reference config assets

## v2 Requirements

### Enhancements

- **V2-01**: Sound effects for match/cascade
- **V2-02**: Tile animation (scale/bounce on match)
- **V2-03**: Different target score per level

## Out of Scope

| Feature | Reason |
|---------|--------|
| Special tiles (bomb, lightning) | Classic mechanics only per user request |
| Power-ups or boosters | Scope control |
| Sound/Audio | White-box phase, add later |
| Particle effects | White-box phase, add later |
| Multiple game modes | Single timedsurvivor mode |
| Leaderboards | Single-player only |

## Traceability

Which phases cover which requirements. Updated during roadmap creation.

| Requirement | Phase | Status |
|-------------|-------|--------|
| CORE-01 | Phase 1 | Pending |
| CORE-02 | Phase 1 | Pending |
| CORE-03 | Phase 1 | Pending |
| CORE-04 | Phase 1 | Pending |
| CORE-05 | Phase 1 | Pending |
| CORE-06 | Phase 1 | Pending |
| CORE-07 | Phase 1 | Pending |
| CORE-08 | Phase 1 | Pending |
| CORE-09 | Phase 1 | Pending |
| CORE-10 | Phase 1 | Pending |
| SCOR-01 | Phase 1 | Pending |
| SCOR-02 | Phase 1 | Pending |
| SCOR-03 | Phase 1 | Pending |
| SCOR-04 | Phase 1 | Pending |
| SCOR-05 | Phase 1 | Pending |
| FLOW-01 | Phase 1 | Pending |
| FLOW-02 | Phase 1 | Pending |
| FLOW-03 | Phase 1 | Pending |
| FLOW-04 | Phase 1 | Pending |
| FLOW-05 | Phase 2 | Pending |
| FLOW-06 | Phase 2 | Pending |
| VISU-01 | Phase 1 | Pending |
| VISU-02 | Phase 1 | Pending |
| VISU-03 | Phase 1 | Pending |
| VISU-04 | Phase 2 | Pending |
| CONF-01 | Phase 1 | Pending |
| CONF-02 | Phase 1 | Pending |
| CONF-03 | Phase 1 | Pending |
| CONF-04 | Phase 1 | Pending |

**Coverage:**
- v1 requirements: 29 total
- Mapped to phases: 29
- Unmapped: 0 ✓

---
*Requirements defined: 2026-03-26*
*Last updated: 2026-03-26 after initial definition*
