# PotatoGame Design Notes

## Worlds & Themes

| World | Name          | Theme Description                 | Signature Mechanic |
|-------|---------------|-----------------------------------|--------------------|
| 1     | TomatoLand    | Cozy farmlands and tutorial hills | Intro combat       |
| 2     | CabbageWorld  | Windy plains with moving hazards  | Gust platforms     |
| 3     | CucumberCity  | Vertical metropolis of scaffolds  | Wall-runs          |
| 4     | MetroOrange   | Neon subway bazaar                | Conveyor belts     |
| 5     | YamYork       | Nocturnal rooftops                | Dynamic weather    |

## Enemy Unlock Order

1. **Soldiers** – Baseline melee unit. Introduced in level 1 of each world.
2. **Spear Throwers** – Ranged ground unit. Added in level 2.
3. **Mages** – Area denial and buffs. Added in level 3.
4. **Kings** – Boss encounters concluding level 4.

## Progression Goals

- Unlock one new potato power at the end of each world.
- Increase enemy health/damage per world to scale difficulty.
- Introduce new traversal gimmick per world to leverage the Bouncy/Gyro mechanics.

## Boss Fight Pillars

- **Readable Telegraphs** – Each king winds up before heavy attacks.
- **Phase Escalation** – Two phases per king, with modifiers in phase two.
- **Power Utilization** – Encourage swapping potatoes (e.g., Ice to freeze adds, Bouncy to evade).

## Steam Release Checklist

- Implement achievements for completing each world and mastering powers.
- Integrate leaderboards for speed-run times.
- Support controller input and rebindable keys.
- Provide localization scaffolding via `Game/Localization`.
