# Unity 项目设置指南（中文）

## 第一步：创建配置资产（Config Assets）

在 Unity 菜单中依次进行：

1. 在 **Project 窗口**（左侧）空白处右键
2. 选择 **Create → MatchThree → TileConfig**
3. 再右键，选择 **Create → MatchThree → GridConfig**
4. 再右键，选择 **Create → MatchThree → GameConfig**

完成后你会看到 3 个蓝色配置文件：
- `TileConfig`
- `GridConfig`
- `GameConfig`

---

## 第二步：创建 Tile 预制体（Prefab）

1. 在 **Project 窗口** 右键
2. 选择 **Create → Prefab**，命名为 `Tile`
3. 双击打开这个预制体，进入预制体编辑模式

在预制体中添加组件：

4. 点击 **Add Component**（在 Inspector 窗口）
5. 搜索 `Image`（需要使用 UI 组件），点击添加
   - 在 Image 组件中，设置 Color 为白色（255,255,255,255）
   - 设置 Width=100, Height=100

6. 再点击 **Add Component**
7. 搜索 `Tile`（我们创建的脚本），点击添加
   - 重要：Inspector 中 Tile 字段保持为空，运行时由 GridManager 自动填充

8. 再点击 **Add Component**
9. 搜索 `TileInputHandler`，点击添加
   - 重要：Inspector 中 Tile 字段保持为空，运行时由 GridManager 自动填充

完成！预制体应该看起来像这样：
```
Tile (Prefab)
├── Image (组件)  →  Color: 白色, Width: 100, Height: 100
├── Tile (组件)   →  Tile 字段: 空（运行时填充）
└── TileInputHandler (组件)  →  Tile 字段: 空（运行时填充）
```

点击左上角的 **←** 返回按钮退出预制体编辑模式。

---

## 第三步：设置 MainScene 场景

打开 `Assets/Scenes/MainScene.unity` 场景

### 3.1 创建画布引用

1. 在 **Hierarchy 窗口** 找到 **GridContainer**（如果你看到的话）
2. 如果没有，创建一个空的 GameObject：
   - 右键 **Canvas** → **Create Empty Child**
   - 命名为 `GridContainer`
   - 拖动到 Canvas 下面

### 3.2 设置 GridManager

1. 在 Hierarchy 中点击 **GridContainer**
2. 在 **Inspector 窗口** 点击 **Add Component**
3. 搜索 `GridManager`，添加

现在需要填入引用：
4. 找到 `Tile Config` 字段，把 Project 窗口中的 `TileConfig` 拖进去
5. 找到 `Grid Config` 字段，把 `GridConfig` 拖进去
6. 找到 `Game Config` 字段，把 `GameConfig` 拖进去
7. 找到 `Tile Prefab` 字段，把刚才创建的 `Tile` 预制体拖进去
8. 找到 `Grid Container` 字段，把 Hierarchy 中的 `GridContainer` 拖进去

### 3.3 设置 ScoreManager

1. 在 Hierarchy 中右键 **Canvas**
2. 选择 **Create Empty Child**，命名为 `ScoreManager`
3. 点击添加 **ScoreManager** 组件

填入引用：
4. `Score Text` → 找到 Scene 中的 **ScoreText**（Canvas 下的）拖进去
5. `Game Config` → 把 `GameConfig` 拖进去

### 3.4 设置 TimerDisplay

1. 在 Canvas 下创建一个空物体 `TimerManager`
2. 添加 **TimerDisplay** 组件

填入引用：
3. `Timer Text` → 找到 Scene 中的 **TimerText** 拖进去
4. `Game Config` → 把 `GameConfig` 拖进去
5. `Game Manager` → 把 `GameManager` 拖进去

### 3.5 设置 GameManager

1. 在 Canvas 下创建一个空物体 `GameManager`
2. 添加 **GameManager** 组件

填入引用：
3. `Game Config` → 把 `GameConfig` 拖进去
4. `Win Screen` → 找到 **WinScreen** 拖进去（先点击 WinScreen 在 Scene 中让它不激活状态）
5. `Lose Screen` → 找到 **LoseScreen** 拖进去

---

## 第四步：添加 EventSystem（用于点击）

如果 Scene 中没有 EventSystem：

1. 右键 Hierarchy 空白处
2. 选择 **UI → Event System**

---

## 第五步：检查设置

确认你的设置：

### GridManager
| 字段 | 应该填入 |
|------|----------|
| Tile Config | TileConfig (资产) |
| Grid Config | GridConfig (资产) |
| Game Config | GameConfig (资产) |
| Tile Prefab | Tile (预制体) |
| Grid Container | GridContainer (场景物体) |

### ScoreManager
| 字段 | 应该填入 |
|------|----------|
| Score Text | ScoreText (UI Text) |
| Game Config | GameConfig (资产) |

### TimerDisplay
| 字段 | 应该填入 |
|------|----------|
| Timer Text | TimerText (UI Text) |
| Game Config | GameConfig (资产) |
| Game Manager | GameManager (场景物体) |

### GameManager
| 字段 | 应该填入 |
|------|----------|
| Game Config | GameConfig (资产) |
| Win Screen | WinScreen (UI Panel) |
| Lose Screen | LoseScreen (UI Panel) |

---

## 第六步：运行游戏

1. 点击 Unity 上方的 **Play 按钮**（三角形）
2. 如果设置正确，你应该看到：
   - 8x8 的彩色格子棋盘居中显示
   - 左上角显示 "Score: 0 / 5000"
   - 右上角显示 "01:00"
3. 点击两个相邻的格子可以交换它们
4. 如果交换后能形成 3 个或更多相同颜色的连成一排/列，它们会消失并得分
