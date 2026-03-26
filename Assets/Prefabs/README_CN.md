# Unity 项目设置指南（中文）

## 目录

1. [创建配置资产](#第一步创建配置资产config-assets)
2. [创建 Tile 预制体](#第二步创建-tile-预制体prefab)
3. [设置 MainScene 场景](#第三步设置-mainscene-场景)
4. [添加 Win/Lose 屏幕文本](#第四步添加-win-lose-屏幕文本)
5. [检查设置](#第五步检查设置)
6. [运行游戏](#第六步运行游戏)

---

## 第一步：创建配置资产（Config Assets）

在 Unity 菜单中依次进行：

1. 在 **Project 窗口**（左侧）空白处右键
2. 选择 **Create → MatchThree → TileConfig**
3. 再右键，选择 **Create → MatchThree → GridConfig**
4. 再右键，选择 **Create → MatchThree → GameConfig**

完成后你会看到 3 个蓝色配置文件：
- `TileConfig` - 定义格子颜色和类型
- `GridConfig` - 定义棋盘大小和间距
- `GameConfig` - 定义游戏规则（时间、目标分数、得分）

### 配置文件说明

#### TileConfig
| 字段 | 说明 | 默认值 |
|------|------|--------|
| Tile Types | 6种格子颜色配置 | 红、蓝、绿、黄、紫、橙 |

#### GridConfig
| 字段 | 说明 | 默认值 |
|------|------|--------|
| Grid Width | 棋盘宽度（列数） | 8 |
| Grid Height | 棋盘高度（行数） | 8 |
| Tile Size | 格子大小 | 1 |
| Tile Spacing | 格子间距 | 0.1 |
| Grid Offset | 棋盘偏移位置 | (0, 0) |

#### GameConfig
| 字段 | 说明 | 默认值 |
|------|------|--------|
| Game Duration | 游戏时间（秒） | 60 |
| Target Score | 胜利目标分数 | 5000 |
| Points Match3 | 3连消得分 | 100 |
| Points Match4 | 4连消得分 | 200 |
| Points Match5 | 5连消得分 | 500 |
| Cascade Multiplier | 连击倍数 | 1.5 |

---

## 第二步：创建 Tile 预制体（Prefab）

1. 在 **Project 窗口** 右键
2. 选择 **Create → Prefab**，命名为 `Tile`
3. 双击打开这个预制体，进入预制体编辑模式

### 添加组件

4. 点击 **Add Component**（在 Inspector 窗口）
5. 搜索 `Image`，点击添加
   - 设置 **Color** 为白色（255,255,255,255）
   - 设置 **Width = 100**，**Height = 100**

6. 再点击 **Add Component**
7. 搜索 `Tile`（脚本），点击添加
   - ⚠️ **Image 字段**：拖入同一个 GameObject 上的 Image 组件
   - ⚠️ **其他字段**：保持为空，运行时由 GridManager 自动填充

8. 再点击 **Add Component**
9. 搜索 `TileInputHandler`，点击添加
   - ⚠️ **Tile 字段**：保持为空，运行时由 GridManager 自动填充

### 预制体结构

```
Tile (Prefab)
├── Image (组件)     →  Color: 白色, Width: 100, Height: 100
├── Tile (组件)       →  Image: 拖入Image组件, 其他字段留空
└── TileInputHandler (组件)  →  Tile字段留空
```

完成后点击左上角 **←** 返回按钮退出预制体编辑模式。

---

## 第三步：设置 MainScene 场景

打开 `Assets/Scenes/MainScene.unity` 场景

### 3.1 确保场景有 Canvas

场景中应该已有一个 **Canvas**。如果没有：
1. 右键 Hierarchy → **UI → Canvas**

### 3.2 创建 GridContainer

1. 在 Hierarchy 中右键 **Canvas**
2. 选择 **Create Empty Child**
3. 命名为 `GridContainer`

### 3.3 设置 GridManager

1. 点击 **GridContainer**
2. **Inspector** → **Add Component**
3. 搜索 `GridManager`，添加

填入引用：

| 字段 | 拖入对象 |
|------|----------|
| Tile Config | Project 中的 `TileConfig` |
| Grid Config | Project 中的 `GridConfig` |
| Game Config | Project 中的 `GameConfig` |
| Tile Prefab | Project 中的 `Tile` 预制体 |
| Grid Container | Hierarchy 中的 `GridContainer` |

### 3.4 设置 ScoreManager

1. 在 Canvas 下创建空物体：`Create Empty Child`，命名为 `ScoreManager`
2. 添加 **ScoreManager** 组件

填入引用：

| 字段 | 拖入对象 |
|------|----------|
| Score Text | Scene 中的 **ScoreText**（UI Text） |
| Game Config | Project 中的 `GameConfig` |

### 3.5 设置 TimerDisplay

1. 在 Canvas 下创建空物体：`Create Empty Child`，命名为 `TimerManager`
2. 添加 **TimerDisplay** 组件

填入引用：

| 字段 | 拖入对象 |
|------|----------|
| Timer Text | Scene 中的 **TimerText**（UI Text） |
| Game Config | Project 中的 `GameConfig` |
| Game Manager | Hierarchy 中的 `GameManager` |

### 3.6 设置 GameManager

1. 在 Canvas 下创建空物体：`Create Empty Child`，命名为 `GameManager`
2. 添加 **GameManager** 组件

填入引用：

| 字段 | 拖入对象 |
|------|----------|
| Game Config | Project 中的 `GameConfig` |
| Win Screen | Scene 中的 **WinScreen**（UI Panel） |
| Lose Screen | Scene 中的 **LoseScreen**（UI Panel） |

### 3.7 添加 EventSystem（用于点击检测）

如果 Scene 中没有 EventSystem：

1. 右键 Hierarchy 空白处
2. 选择 **UI → Event System**

---

## 第四步：添加 Win/Lose 屏幕文本

### 4.1 WinScreen 文本

1. 在 Hierarchy 中找到 **WinScreen**（Canvas 下）
2. 点击 **Add Component** → 搜索 `Text`，添加 **Text (Legacy)**
3. 配置 Text 组件：

| 字段 | 设置值 |
|------|--------|
| Text | `You Win!` |
| Font Size | 64 |
| Alignment | Center, Middle |
| Color | 白色 |

### 4.2 LoseScreen 文本

1. 在 Hierarchy 中找到 **LoseScreen**（Canvas 下）
2. 点击 **Add Component** → 搜索 `Text`，添加 **Text (Legacy)**
3. 配置 Text 组件：

| 字段 | 设置值 |
|------|--------|
| Text | `Time's Up!` |
| Font Size | 64 |
| Alignment | Center, Middle |
| Color | 白色 |

### 4.3 添加 WinScreen/LoseScreen 脚本

1. 点击 **WinScreen** → **Add Component** → 搜索 `WinScreen`，添加
2. 点击 **LoseScreen** → **Add Component** → 搜索 `LoseScreen`，添加

---

## 第五步：检查设置

### 完整配置清单

#### GridManager (GridContainer 上)
| 字段 | 类型 | 拖入对象 |
|------|------|----------|
| Tile Config | ScriptableTileConfig | TileConfig.asset |
| Grid Config | GridConfig | GridConfig.asset |
| Game Config | GameConfig | GameConfig.asset |
| Tile Prefab | GameObject | Tile.prefab |
| Grid Container | Transform | GridContainer |

#### ScoreManager (Canvas/ScoreManager 上)
| 字段 | 类型 | 拖入对象 |
|------|------|----------|
| Score Text | Text | ScoreText |
| Game Config | GameConfig | GameConfig.asset |

#### TimerDisplay (Canvas/TimerManager 上)
| 字段 | 类型 | 拖入对象 |
|------|------|----------|
| Timer Text | Text | TimerText |
| Game Config | GameConfig | GameConfig.asset |
| Game Manager | GameManager | GameManager |

#### GameManager (Canvas/GameManager 上)
| 字段 | 类型 | 拖入对象 |
|------|------|----------|
| Game Config | GameConfig | GameConfig.asset |
| Win Screen | WinScreen | WinScreen |
| Lose Screen | LoseScreen | LoseScreen |

#### Tile 预制体
| 组件 | 字段 | 设置 |
|------|------|------|
| Image | Color | 白色(255,255,255,255) |
| Image | Width | 100 |
| Image | Height | 100 |
| Tile | Image | 拖入 Image 组件 |
| Tile | 其他字段 | 留空 |
| TileInputHandler | Tile | 留空 |

#### WinScreen / LoseScreen
| 组件 | 字段 | 设置 |
|------|------|------|
| Image | Color | 半透明黑色背景（可选） |
| Text | Text | "You Win!" / "Time's Up!" |
| Text | Font Size | 64 |
| Text | Alignment | Center, Middle |
| Text | Color | 白色 |
| WinScreen/LoseScreen | 无需配置字段 | - |

---

## 第六步：运行游戏

1. 点击 Unity 上方 **Play 按钮**（三角形）
2. 如果设置正确，你应该看到：
   - 8×8 的彩色格子棋盘居中显示
   - 左上角显示 `Score: 0 / 5000`
   - 右上角显示 `01:00`
3. 点击两个相邻的格子可以交换它们
4. 如果交换后能形成 3 个或更多相同颜色的连成一排/列，它们会消失并得分

### 常见问题

**Q: 点击格子没有反应**
A: 确保场景中有 EventSystem（UI → Event System）

**Q: 格子显示为白色**
A: 确保 TileConfig 中配置了 6 种颜色，确保 Tile 组件的 Image 字段已拖入 Image 组件

**Q: 游戏不计时**
A: 检查 TimerDisplay 的 Game Manager 字段是否已拖入 GameManager

**Q: 无法消除格子**
A: 检查 ScoreManager 和 GridManager 的 Game Config 是否正确设置
