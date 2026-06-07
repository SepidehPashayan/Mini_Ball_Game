# 🎮 Mini Ball Game

> A physics-based 3D platformer developed in Unity and C#.  
> Control a ball through obstacles, collect coins, and reach the finish line — without falling off.

![Unity](https://img.shields.io/badge/Engine-Unity-black?logo=unity)
![C#](https://img.shields.io/badge/Language-C%23-purple?logo=csharp)
![Genre](https://img.shields.io/badge/Genre-3D%20Platformer-pink)
![Status](https://img.shields.io/badge/Status-Complete-brightgreen)

---

## 🕹️ Gameplay

The player controls a ball using keyboard input, navigating through a level filled with obstacles and collectibles.

| Goal | Description |
|---|---|
| 🏁 Win | Reach the finish line |
| 💀 Lose | Fall off the platform |
| 🔄 Restart | Level resets automatically on failure |
| 🪙 Collect | Pick up coins during the run |

---

## ⚙️ Core Mechanics

- **Physics-driven movement** — Rigidbody-based ball controller responding to keyboard input
- **Obstacle navigation** — physics collisions with environmental objects
- **Coin collection** — trigger-based pickup system
- **Win / lose detection** — collision and fall-off detection tied to game state
- **Auto-restart** — scene reloads automatically after losing

---

## 🧱 Technical Implementation

| Area | Detail |
|---|---|
| Engine | Unity |
| Language | C# |
| Movement | `Rigidbody.AddForce` / physics-based |
| Collision | `OnTriggerEnter` / `OnCollisionEnter` |
| Scene control | `SceneManager.LoadScene` for restart |
| Structure | Unity best practices — separated scripts per responsibility |

---

## 🎬 Game Flow

```
Start
  └─→ Player moves ball with keyboard
        └─→ Navigate through obstacles
              ├─→ Collect coins (optional)
              ├─→ Reach finish line ──→ 🏆 Win
              └─→ Fall off platform ──→ 💀 Lose ──→ 🔄 Auto-restart
```

---

## 📁 Project Structure

```
MiniBallGame/
├── Assets/
│   ├── Scripts/        # C# gameplay scripts
│   ├── Scenes/         # Unity scene files
│   ├── Prefabs/        # Ball, obstacles, coins, finish line
│   └── Materials/      # Visual materials
├── ProjectSettings/
└── README.md
```

---

## 🚀 Getting Started

### Requirements

- Unity **2021.3 LTS** or newer

### Run the project

1. Clone or download the repository
2. Open the project folder in **Unity Hub**
3. Open the main scene from `Assets/Scenes/`
4. Press **Play** in the Unity Editor

---

## 👩‍💻 Author

**Sepideh Pashayan**
