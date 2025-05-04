# CrossyRoad

# Crossy Road in Unity

This is a **3D Crossy Road-style endless runner** built in Unity. Players dodge cars and navigate dynamically generated road segments while progressing through multiple levels. This project highlights clean Unity development practices, procedural terrain generation, modular prefab systems, and interactive UI with drag-and-drop audio support.

---

## 🎮 Features

- 🛣️ **Procedural Segment Generation**
  - Dynamic road, grass, and pavement generation using multiple prefab variations.
  - Spawns segments randomly and aligns them seamlessly along the Z-axis.

- 🚗 **Moving Vehicles**
  - Cars move in both directions across road segments.
  - Easily swap cube placeholders with real car models from the Unity Asset Store.

- 🌍 **Multiple Levels**
  - Main Menu includes level selection (Level 1 and Level 2).
  - Automatically loads new scenes when reaching the end of a level.

- 🔊 **Audio Integration**
  - Background music and sound effects (jump, walk, etc.).
  - Added via Unity’s drag-and-drop Audio Source system (no code required).

- 🧩 **Modular Design**
  - Game architecture supports adding new segment types, cars, or level logic with minimal changes.

---

## 🧰 Tech Stack

| Tool        | Purpose                            |
|-------------|------------------------------------|
| Unity       | Game development engine            |
| C#          | Game logic and component scripting |
| Unity UI    | Buttons, text, and scene flow      |
| Animator    | Handling animations and events     |
| Asset Store | 3D models and sounds               |

---

## 🚀 Getting Started

### 🧩 Open in Unity

1. Open **Unity Hub**.
2. Click `Add`, then select the cloned project folder.

### ▶️ Play the Game

1. Press the **▶️ Play** button in the Unity editor.
2. Use the following controls to play:
   - `W`, `A`, `S`, `D` – Move
   - `Spacebar` – Jump

### 🔧 Build Settings

1. Go to `File > Build Settings`.
2. Add all scenes to the build:
   - `MainMenu`
   - `Level1`
   - `Level2`
3. Click **Build** to create a standalone version.

---

## 📁 Project Structure

```plaintext
Assets/
├── Prefabs/            # Segment prefabs (grass, road, combo pieces)
├── Scripts/            # C# scripts (MainMenu.cs, SegmentGenerator.cs, etc.)
├── Scenes/             # MainMenu, Level1, Level2
├── Audio/              # Music and SFX (jump, walk, theme)
├── Models/             # Car models from Asset Store
└── Materials/Textures/ # Materials and environment assets

---

🔮 Future Improvements
Add a score system and high score leaderboard.
Integrate character customization options.
Add mobile support with on-screen touch controls.
Implement day-night cycle and weather effects.