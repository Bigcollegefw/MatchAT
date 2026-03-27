# AI 驱动游戏开发工作流 - MatchThree

> 本文档记录 MatchThree 项目的 AI 辅助开发工作流规范，适用于个人项目开发。

## 核心技术栈

| 工具 | 用途 | 集成方式 |
|------|------|----------|
| **Claude Code** | AI 编程助手，代码生成、调试、重构 | CLI + VSCode Extension |
| **GSD (Get Shit Done)** | 项目管理框架，需求→验证闭环 | Claude Code Skill (`/gsd:quick`, `/gsd:plan-phase`, `/gsd:execute-phase`) |
| **Bezi** | 场景编辑与可视化预览 | Unity Package (`com.bezi.explorer`) |
| **Unity** | 游戏引擎，运行时环境 | 本地安装 |

## 工作流架构

```
┌─────────────────────────────────────────────────────────────┐
│                     Claude Code (Orchestrator)               │
│  ┌─────────────┐  ┌─────────────┐  ┌─────────────────────┐  │
│  │ /gsd:quick  │  │/gsd:plan-phase│  │ /gsd:execute-phase │  │
│  │  快速修复    │  │   阶段规划   │  │     阶段执行        │  │
│  └─────────────┘  └─────────────┘  └─────────────────────┘  │
└───────────────────────────┬─────────────────────────────────┘
                            │
                            ▼
┌─────────────────────────────────────────────────────────────┐
│                    GSD Workflow System                        │
│  ┌──────────────┐  ┌──────────────┐  ┌──────────────────┐  │
│  │  .planning/  │  │  STATE.md    │  │   CONTEXT.md     │  │
│  │  需求文档化   │  │  进度追踪    │  │   决策记录       │  │
│  └──────────────┘  └──────────────┘  └──────────────────┘  │
└───────────────────────────┬─────────────────────────────────┘
                            │
                            ▼
┌─────────────────────────────────────────────────────────────┐
│                    Unity + Bezi                               │
│  ┌──────────────┐  ┌──────────────┐  ┌──────────────────┐  │
│  │   Assets/    │  │ ProjectSettings│ │    Bezi IDE     │  │
│  │   脚本/配置   │  │   场景配置    │  │   场景可视化    │  │
│  └──────────────┘  └──────────────┘  └──────────────────┘  │
└─────────────────────────────────────────────────────────────┘
```

## GSD 工作流规范

### 1. 快速修复 (`/gsd:quick`)

适用于小型任务：bug 修复、文档更新、配置调整。

```
用户请求 → /gsd:quick → 任务执行 → 提交 → 状态更新
```

**执行要点：**
- 任务保持原子性（单一职责）
- 自动原子提交
- 更新 STATE.md Quick Tasks 表格

### 2. 阶段规划 (`/gsd:plan-phase`)

适用于功能开发、架构重构。

```
研究 (可选) → 规划 → 验证 → 交付
```

**文档输出：**
- `phases/XX-XX-PLAN.md` - 阶段执行计划
- `phases/XX-XX-SUMMARY.md` - 阶段完成总结
- `VERIFICATION.md` - 目标达成验证

### 3. 阶段执行 (`/gsd:execute-phase`)

适用于复杂多任务执行。

```
计划发现 → 依赖分析 → 波次执行 → 验证 → 状态更新
```

**波次机制：**
- 自动分析任务依赖关系
- 并行执行无依赖任务
- 分波次控制执行节奏

## 项目规范

### 模块化 Page 架构

```
Assets/
├── Scripts/
│   ├── Configs/        # 配置数据 (ScriptableObject)
│   ├── GameFlow/       # 游戏流程控制
│   ├── Grid/           # 棋盘逻辑
│   ├── Matching/       # 匹配算法
│   ├── Scoring/        # 计分系统
│   └── UI/             # 界面逻辑
├── Prefabs/            # 预制体资源
├── Config/             # 配置文件 (.asset)
└── Scenes/             # 场景文件
```

**命名规范：**

| 类型 | 规范 | 示例 |
|------|------|------|
| 脚本类 | PascalCase | `GridManager.cs` |
| 配置类 | PascalCase + Config | `GameConfig.cs` |
| 配置文件 | PascalCase + Config.asset | `GameConfig.asset` |
| 预制体 | PascalCase | `Tile.prefab` |
| 场景 | PascalCase | `MainScene.unity` |
| 公开字段 | camelCase | `gameConfig` |
| 私有字段 | _camelCase (下划线前缀) | `_timeRemaining` |
| 静态变量 | s_CamelCase | `s_FirstSelected` |
| 常量 | k_CamelCase | `k_Match3Score` |

### 代码分层

```
┌─────────────────────────────────────────┐
│            Presentation Layer            │
│   UI/  - WinScreen, LoseScreen, Timer   │
└─────────────────┬───────────────────────┘
                  │
┌─────────────────▼───────────────────────┐
│            Game Flow Layer               │
│   GameFlow/  - GameManager, GameState   │
└─────────────────┬───────────────────────┘
                  │
┌─────────────────▼───────────────────────┐
│            Core Game Logic               │
│   Grid/, Matching/  - Tile, Match       │
└─────────────────┬───────────────────────┘
                  │
┌─────────────────▼───────────────────────┐
│            Data Layer                    │
│   Configs/, Scoring/  - Config, Score  │
└─────────────────────────────────────────┘
```

### 组件职责

| 组件 | 职责 | 依赖 |
|------|------|------|
| `GameManager` | 游戏状态控制，单例 | WinScreen, LoseScreen, ScoreManager, GridManager |
| `GridManager` | 棋盘创建、tile 放置 | TileConfig, GridConfig, Tile Prefab |
| `TileInputHandler` | 处理 tile 点击/拖拽 | GameManager.IsGameRunning |
| `ScoreManager` | 计分、目标检测 | GameConfig |
| `TimerDisplay` | 倒计时显示 | GameConfig, GameManager |
| `WinScreen/LoseScreen` | 结束界面显示 | Button.onClick |

## Bezi 集成

### 工作流程

1. **场景编辑** → 在 Bezi 中设计场景布局
2. **导出配置** → Bezi 生成 Unity 可识别的场景数据
3. **自动映射** → `Bezi.Explorer` Package 读取配置到 Unity
4. **运行时控制** → 脚本读取 Bezi 导出参数

### 当前项目 Bezi 配置

- **Bezi ID**: `.bezisidekick/`
- **Editor Settings**: `.bezisidekick/.settings.json`
- **User Settings**: `.bezisidekick/.user-settings.json`

## 信息管理

### 长对话上下文保持

1. **CLAUDE.md** - 项目级指令，定义技术栈、架构、约束
2. **.planning/STATE.md** - 当前阶段状态、已完成任务
3. **.planning/ROADMAP.md** - 项目路线图
4. **.planning/REQUIREMENTS.md** - 需求池
5. **CONTEXT.md** - 决策记录（使用 `/gsd:quick --discuss` 时生成）

### 上下文丢失恢复

当 AI 重启或对话压缩时：
1. 读取 `CLAUDE.md` 获取项目上下文
2. 读取 `STATE.md` 获取当前进度
3. 按需重建工作状态

## 版本控制策略

### Git 分支

```
main          # 稳定版本
├── develop   # 开发分支（可选）
└── feature/* # 功能分支（大型项目）
```

### 提交规范

```
<type>: <subject>

<body (optional)>

<footer (optional)>
```

**Type 类型：**
- `feat`: 新功能
- `fix`: Bug 修复
- `docs`: 文档更新
- `refactor`: 重构
- `chore`: 构建/工具变更
- `perf`: 性能优化

### .gitignore 规范

```
# Unity 生成（可重建）
/Library/
/Temp/
/Logs/
UserSettings/

# IDE
.vscode/
.idea/

# 构建产物
*.apk
*.unitypackage

# 内存转储
mono_crash*.blob
```

**必须保留：**
- `Assets/` - 源代码、资源
- `Packages/` - 依赖配置
- `ProjectSettings/` - 项目设置

## 质量保证

### 验证清单

每个阶段完成后验证：
- [ ] 所有编译错误已修复
- [ ] 游戏可正常运行（无运行时错误）
- [ ] 核心功能通过手动测试
- [ ] 代码符合命名规范
- [ ] 无硬编码魔法值
- [ ] 所有引用已配置（非 null）

### 调试日志规范

```csharp
Debug.Log($"[ClassName] MethodName() - condition: {value}");
Debug.LogError($"[ClassName] ErrorDescription");
```

日志格式：`[组件名] 方法名 - 状态信息`

## 工具链版本

记录当前使用的工具版本，便于复现：

| 工具 | 版本 | 说明 |
|------|------|------|
| Unity | 2022.3.x | LTS 版本 |
| Claude Code | Latest | 通过 npm 更新 |
| Bezi Explorer | Latest | Unity Package |

---

*本文档由 AI 辅助生成，最后更新：2026-03-28*
