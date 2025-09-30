# PotatoGame

PotatoGame is a Unity project concept that blends the joyful platforming energy of *Rayman Legends* with the precise combat rhythms of *Mario* titles. You play as Bob, a heroic potato farmer whose arsenal of empowered spuds expands as you clear each of five vegetable-themed worlds. Every world introduces new enemy archetypes and culminates in a climactic king encounter.

## Project Structure

```
Game/
  Assets/           # Art, audio, and tilemap placeholders
  Scripts/          # Gameplay scripts grouped by responsibility
  Levels/           # Wave definitions and per-world sub-folders
  Config/           # JSON configuration samples for tuning
  Localization/     # Reserved for future translations
  Build/            # Place generated builds here
  Saves/            # Player save data (or use OS-specific location)
```

## Core Features

- **Expressive Platforming** – Run, jump (with coyote time), and optionally wall-slide across handcrafted levels.
- **Potato Power Loadout** – Equip up to three potatoes at once. Powers unlock as you beat worlds:
  1. Regular Potato – Boomerang-style projectile with light damage.
  2. Ice Potato – Freezes enemies in place.
  3. Explosive Potato – Area-of-effect blast on impact.
  4. Bouncy Potato – Launches Bob skyward after a ground slam.
  5. Golden Potato – Grants 10 seconds of invulnerability on a 30 second cooldown.
- **Vegetable Legions** – Each world features soldiers, spear throwers, mages, and a world-specific king boss.
- **Escalating Level Flow** – Four levels per world: introductory soldiers, spear throwers added, mages added, then a survival gauntlet that finishes with the king fight.

## Getting Started

1. **Create the Unity Project**
   - Open Unity Hub and create a new 2D URP project named `PotatoGame`.
   - Close Unity after generation and replace the auto-generated `Assets` folder with this repository's `Game` folder contents (or copy them into `Assets`).
2. **Import Scripts**
   - Ensure the C# scripts inside `Game/Scripts` are inside your Unity project's `Assets/Scripts` directory so Unity can compile them.
   - Create ScriptableObject assets for each potato power (`Create > PotatoGame > Powers > ...`) and the enemy registry (`Create > PotatoGame > Enemy Registry`).
3. **Build the Worlds**
   - Use the `Game/Config/*.json` files as references while building prefabs, tuning enemy stats, and scripting wave patterns.
   - Populate the `Game/Levels` sub-folders with tilemaps, prefabs, and wave configs for each level.
4. **Hook Up Systems**
   - Add `PlayerController` and `PotatoPowerManager` components to the player prefab.
   - Configure `WaveSpawner` components with spawn points and an `EnemyRegistry` asset that maps IDs to prefabs.
   - Use `LevelFlowManager` to sequence level stages and trigger boss fights.

## Roadmap Suggestions

- Flesh out remaining vegetable enemy variants by swapping art, stats, and behaviors per world.
- Design cinematic introductions for each king boss fight.
- Add cooperative multiplayer, speed-run timers, and cosmetic unlocks.
- Implement Steamworks integration for achievements and cloud saves.

## Requirements & Tooling

- Unity 2022 LTS (or newer) with 2D packages.
- Git LFS for large binary assets when real art/audio is added.
- Optional: Rider, Visual Studio, or VS Code for C# editing.

## License

This project inherits the root `LICENSE` file. Review it before shipping or distributing builds.
