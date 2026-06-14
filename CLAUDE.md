# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Overview

This is the **BeTTerLife: Roads and Signs** mod for Captain of Industry (COI), authored by MaViTTo. It adds custom road systems, bridge segments, modular roads, and decorative signs to the game.

The companion Unity project for asset bundles lives at `D:\Modding\CaptainOfIndustry\BetterLife_RoadsAndSigns_Unity\`.

## Build & Deploy

### Prerequisites
- `COI_ROOT` environment variable must point to the Captain of Industry game folder (e.g. `C:\Program Files (x86)\Steam\steamapps\common\Captain of Industry`)
- `COI_MODS` defaults to `%APPDATA%\Captain of Industry\Mods`
- Target framework: **.NET 4.8** (`net48`)

### Build
```
msbuild BetterLife_RoadsAndSigns.sln /p:Configuration=Release
```

On successful build, the `.csproj` automatically:
1. Copies the `.dll` + `.pdb` to `BetterLife_RoadsAndSigns_Unity\Assets\Dlls\`
2. Copies the `.dll`, `manifest.json`, asset bundles, `changelog.txt`, `readme.txt`, and `Thumbnail.png` to `%APPDATA%\Captain of Industry\Mods\BetterLife_RoadsAndSigns\`

`DeployToModsFolder=true` is set by default — set to `false` in the `.csproj` to skip live deployment.

### Versioning
Version is read at build time from `manifest.json` (`"version": "1.0.9"`). Format: `major.minor.patch[letter]` → parsed into a four-part assembly version. **Always bump `manifest.json`** before releasing.

### Asset Bundles
3D models are built in Blender (`D:\Modding\CaptainOfIndustry\BlenderModels\`), imported into the Unity project, then exported to `BetterLife_RoadsAndSigns_Unity\AssetBundles\`. The build copies them to the mods folder automatically. Asset paths in code follow the pattern `"Assets/BetterLife/<category>/<file>.prefab"` — these must match exactly what is exported from Unity.

## Mod Architecture

The entry point is `BetterLife_RoadsAndSigns` class implementing `IMod`, `IModConfig`, `IDisposable`. The key lifecycle method is `RegisterPrototypes`, which registers all game entities and delegates to sub-data classes:

```csharp
registrator.RegisterData<TerrainDef>();
registrator.RegisterData<SignsData>();
registrator.RegisterData<IndustryRoads>();
registrator.RegisterData<ModularRoadPieceRegistrar>();
registrator.RegisterDataWithInterface<IResearchNodesData>();
```

Each of these implements `IModData` and contains the actual proto definitions for its feature area.

### ID System
All entity IDs are in `IDs/`, split by type (`IDsBuildings.cs`, `IDsMachines.cs`, `IDsRecipes.cs`, `IDsResearch.cs`, `IDsTerrains.cs`, `IDsToolbars.cs`).

The `BetterLIDs` outer class uses nested `partial class` to organize by area:
- `BetterLIDs.dPath` — asset path pairs (prefab path + icon path), e.g. `dPath.sign_stop`, `dPath.RoadEntities.onewayStraight`
- `BetterLIDs.dPath.IndustrialRoads` — `RoadEntityProto.ID` constants for road pieces (Set 1 and Set 2)
- `BetterLIDs.dPath.Roads` — modular road piece IDs
- `BetterLIDs.Signs` — `CustomEntityPrototype.ID` constants for all sign entities
- `BetterLIDs.ToolBars` — toolbar category IDs

### Road System
Custom roads extend `blRoadEntityProtoBase` → `blRoadEntityProto`. Road pieces are defined by **lane specs** (`RoadLaneSpec`) with:
- A 2D Bézier trajectory curve (xy position along the road)
- A height curve (elevation profile)

`blRoadEntityProto.TryCreateProto(...)` handles the full pipeline: Bézier sampling → layout tile computation → `RoadLaneMetadata` → final proto. `blRoadEntityProto.TryCreateLanes(...)` can be used standalone when you need lane data without a full proto.

Road data is organized in three files:
- `IndustrialRoads/IndustrialRoads.cs` — one-way and bi-directional industrial road sets (Set 1 and Set 2), bridge segments
- `ModularRoads/ModularRoadSystem.cs` — modular straight/corner/tee/cross pieces
- `BridgeRoad/` — bridge road protos and Harmony patches for bridge behavior

### Signs
Signs are `CustomEntityPrototype` instances registered in `BetterLifesSignsDef.cs`. The `dPath` struct pairs the Unity prefab path with the UI icon path.

### Harmony Patches
`0Harmony.dll` is bundled and listed in `manifest.json` under `primary_dlls`. Patch classes use standard `[HarmonyPatch]` attributes. The vehicle patcher is in `Patcher/VehiclePatcher.cs`.

## Key Conventions

- `Log.Info(...)` for all debug output (COI's built-in logger from `Mafi` namespace).
- Commented-out code is intentional — old road sets and experimental features are kept in place. Large blocks of excluded files are listed in the `.csproj` `<Compile Remove="...">` section.
- `BLCosts.cs` centralizes construction cost definitions reused across protos.
- `utility.cs` / `HarmonyExtensions.cs` / `ReflectionExtensions.cs` contain shared helpers.
