// =============================================================================
// ModularRoadSystem.cs  —  BetterLife_RoadsAndSigns
//
// Adds a modular, hijack-driven road system on top of the existing
// blRoadEntityProtoBase / blRoadEntityBase / roadsUtil infrastructure.
//
// Sections:
//   1.  ModularLaneWaypoint       — per-point XY + height delta + speed limit
//   2.  ModularLaneDef            — one lane in proto-local (layout) space
//   3.  PiecePort                 — one connection face of a piece
//   4.  BakedWaypoint / BakedLane — pre-rotated, still layout-relative
//   5.  WorldLaneWaypoint / WorldLane — fully world-space
//   6.  ModularRoadPieceProto     — extends blRoadEntityProtoBase; bakes 4 rotations
//   7.  ModularRoadPieceEntity    — extends blRoadEntityBase; world-space lanes
//   8.  ModularRoadLayouts        — ASCII EntityLayout helpers per shape
//   9.  ModularRoadPieceRegistrar — IModData registration; wires into BetterLife.cs
//  10.  VehicleHijackState        — shared HashSet for Harmony patches
//  11.  Harmony patches           — canDriveForwards / canDriveBackwards bypass
//  12.  WaypointJobProvider       — IJobProvider<Truck>; per-waypoint speed + height
//  13.  VehicleHijacker           — high-level TakeControl / ReleaseControl API
//  14.  RoadPieceShapes           — lane waypoint data for each shape
// =============================================================================

using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using Mafi;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Dynamic;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Mods;
using Mafi.Core.PathFinding;
using Mafi.Core.Prototypes;
using Mafi.Core.Roads;
using Mafi.Core.Vehicles.Jobs;
using Mafi.Core.Vehicles.Trucks;
using Mafi.Localization;

namespace BetterLife_RoadsAndSigns.ModularRoads
{

// =============================================================================
// 1. ModularLaneWaypoint
//    One control point in proto-local (layout) space.
//    HeightDelta      : tiles above terrain (0 = ground, positive = elevated).
//    SpeedLimitPerTick: tiles/tick cap at this waypoint. Zero = use proto default.
// =============================================================================
public readonly struct ModularLaneWaypoint
{
    public readonly RelTile2f LocalXY;
    public readonly RelTile1f HeightDelta;
    public readonly RelTile1f SpeedLimitPerTick;

    public ModularLaneWaypoint(
        RelTile2f xy,
        RelTile1f heightDelta       = default,
        RelTile1f speedLimitPerTick = default)
    {
        LocalXY            = xy;
        HeightDelta        = heightDelta;
        SpeedLimitPerTick  = speedLimitPerTick;
    }

    /// Convenience: ground-level waypoint with explicit speed.
    public static ModularLaneWaypoint AtSpeed(RelTile2f xy, RelTile1f speed)
        => new ModularLaneWaypoint(xy, default, speed);

    /// Convenience: elevated waypoint with explicit speed.
    public static ModularLaneWaypoint Elevated(RelTile2f xy, RelTile1f height, RelTile1f speed)
        => new ModularLaneWaypoint(xy, height, speed);
}

// =============================================================================
// 2. ModularLaneDef
//    One driveable lane in proto-local (layout) space.
// =============================================================================
public readonly struct ModularLaneDef
{
    public readonly ImmutableArray<ModularLaneWaypoint> Waypoints;
    public readonly Direction90  LocalEntryDir;
    public readonly Direction90  LocalExitDir;
    public readonly RoadLaneType LaneType;

    public ModularLaneDef(
        ImmutableArray<ModularLaneWaypoint> waypoints,
        Direction90  localEntryDir,
        Direction90  localExitDir,
        RoadLaneType laneType = default)
    {
        Waypoints     = waypoints;
        LocalEntryDir = localEntryDir;
        LocalExitDir  = localExitDir;
        LaneType      = laneType;
    }
}

// =============================================================================
// 3. PiecePort
//    One connection face of a piece (layout-local space).
// =============================================================================
public readonly struct PiecePort
{
    public readonly Direction90  LocalSide;
    public readonly RelTile2f    LocalPosition;
    public readonly RoadLaneType AcceptedTypes;

    public PiecePort(Direction90 localSide, RelTile2f localPosition, RoadLaneType acceptedTypes)
    {
        LocalSide     = localSide;
        LocalPosition = localPosition;
        AcceptedTypes = acceptedTypes;
    }
}

// =============================================================================
// 4. BakedWaypoint / BakedLane
//    Lane after one Rotation90 is applied, still layout-relative.
// =============================================================================
public readonly struct BakedWaypoint
{
    public readonly RelTile2f LocalXY;
    public readonly RelTile1f HeightDelta;
    public readonly RelTile1f SpeedLimitPerTick;

    public BakedWaypoint(RelTile2f xy, RelTile1f height, RelTile1f speed)
    {
        LocalXY           = xy;
        HeightDelta       = height;
        SpeedLimitPerTick = speed;
    }
}

public readonly struct BakedLane
{
    public readonly ImmutableArray<BakedWaypoint> Waypoints;
    public readonly Direction90  LocalEntryDir;
    public readonly Direction90  LocalExitDir;
    public readonly RoadLaneType LaneType;

    public BakedLane(
        ImmutableArray<BakedWaypoint> waypoints,
        Direction90  localEntryDir,
        Direction90  localExitDir,
        RoadLaneType laneType)
    {
        Waypoints     = waypoints;
        LocalEntryDir = localEntryDir;
        LocalExitDir  = localExitDir;
        LaneType      = laneType;
    }
}

// =============================================================================
// 5. WorldLaneWaypoint / WorldLane
//    Fully world-space lane ready for vehicle consumption.
// =============================================================================
public readonly struct WorldLaneWaypoint
{
    /// X, Y = absolute world tile coords. Z = height delta above terrain.
    public readonly RelTile3f WorldPos;
    public readonly RelTile1f SpeedLimitPerTick;

    public WorldLaneWaypoint(RelTile3f worldPos, RelTile1f speedLimitPerTick)
    {
        WorldPos          = worldPos;
        SpeedLimitPerTick = speedLimitPerTick;
    }

    public Tile2f XY => new Tile2f(WorldPos.X, WorldPos.Y);
}

public readonly struct WorldLane
{
    public readonly ImmutableArray<WorldLaneWaypoint> Waypoints;
    public readonly RoadGraphNodeKey StartNode;
    public readonly RoadGraphNodeKey EndNode;
    public readonly Direction90  EntryDir;
    public readonly RoadLaneType LaneType;

    public WorldLane(
        ImmutableArray<WorldLaneWaypoint> waypoints,
        RoadGraphNodeKey startNode,
        RoadGraphNodeKey endNode,
        Direction90  entryDir,
        RoadLaneType laneType)
    {
        Waypoints = waypoints;
        StartNode = startNode;
        EndNode   = endNode;
        EntryDir  = entryDir;
        LaneType  = laneType;
    }
}

// =============================================================================
// 6. ModularRoadPieceProto
//    Extends blRoadEntityProtoBase (so it plugs into the existing road graph).
//    Bakes all 4 Rotation90 variants at construction time.
// =============================================================================
public class ModularRoadPieceProto : blRoadEntityProtoBase
{
    public readonly ImmutableArray<ModularLaneDef> ModularLanes;
    public readonly ImmutableArray<PiecePort>      Ports;
    public readonly RoadPieceShape                 Shape;

    // [rotationIndex 0..3][laneIndex]
    private readonly BakedLane[][] m_rotatedLanes;

    public ModularRoadPieceProto(
        StaticEntityProto.ID           id,
        Proto.Str                      strings,
        EntityLayout                   layout,
        EntityCosts                    costs,
        ImmutableArray<ModularLaneDef> modularLanes,
        ImmutableArray<PiecePort>      ports,
        RoadPieceShape                 shape,
        blRoadEntityProtoBase.Gfx      graphics)
        // Pass empty lane arrays to base — our custom lanes replace them at runtime.
        : base(id, strings, layout, costs,
               maxVehicleSpeedPerTick: RelTile1f.MaxValue,
               lanesSpecs:        ImmutableArray<RoadLaneSpec>.Empty,
               lanesData:         ImmutableArray<RoadLaneMetadata>.Empty,
               lanesTrajectories: ImmutableArray<RoadLaneTrajectory>.Empty,
               graphics:          graphics,
               useTerrainHeightForVehicles: false)
    {
        ModularLanes   = modularLanes;
        Ports          = ports;
        Shape          = shape;
        m_rotatedLanes = BakeAllRotations(modularLanes, layout);
    }

    public override Type EntityType => typeof(ModularRoadPieceEntity);

    /// Returns pre-baked lanes for a rotation index (0 = Identity, 1 = CW90, ...).
    public BakedLane[] GetBakedLanes(Rotation90 rotation) => m_rotatedLanes[rotation.AsIndex()];

    // -------------------------------------------------------------------------
    // Baking
    // -------------------------------------------------------------------------

    private static BakedLane[][] BakeAllRotations(
        ImmutableArray<ModularLaneDef> lanes,
        EntityLayout layout)
    {
        var result = new BakedLane[4][];
        var rotations = new[]
        {
            Rotation90.Identity,
            Rotation90.Cw90,
            Rotation90.Cw180,
            Rotation90.Cw270,
        };

        for (int r = 0; r < 4; r++)
        {
            var rot           = rotations[r];
            var dummyTransform = new TileTransform(Tile2i.Zero, rot, isReflected: false);
            var baked         = new BakedLane[lanes.Length];

            for (int i = 0; i < lanes.Length; i++)
            {
                var lane = lanes[i];
                var wps  = ImmutableArray.CreateBuilder<BakedWaypoint>(lane.Waypoints.Length);

                foreach (var wp in lane.Waypoints)
                {
                    RelTile2f rotXY = layout.TransformRelativeF_Point(wp.LocalXY, dummyTransform);
                    wps.Add(new BakedWaypoint(rotXY, wp.HeightDelta, wp.SpeedLimitPerTick));
                }

                baked[i] = new BakedLane(
                    waypoints:    wps.MoveToImmutable(),
                    localEntryDir: dummyTransform.Transform(lane.LocalEntryDir),
                    localExitDir:  dummyTransform.Transform(lane.LocalExitDir),
                    laneType:      lane.LaneType
                );
            }

            result[r] = baked;
        }

        return result;
    }

    internal static TrainTrackNodeDirection ToTrackDir(Direction90 d)
        => (TrainTrackNodeDirection)d.Index;
}

// =============================================================================
// 7. ModularRoadPieceEntity
//    Extends blRoadEntityBase; resolves world-space lanes on construction.
// =============================================================================
public class ModularRoadPieceEntity : blRoadEntityBase
{
    public new ModularRoadPieceProto RoadProto { get; }

    private readonly WorldLane[] m_worldLanes;

    public ModularRoadPieceEntity(
        EntityId              id,
        ModularRoadPieceProto proto,
        TileTransform         transform,
        EntityContext         context)
        : base(id, proto, transform, context)
    {
        RoadProto    = proto;
        m_worldLanes = BuildWorldLanes(proto, transform);
    }

    // -------------------------------------------------------------------------
    // Lane access for the hijack system
    // -------------------------------------------------------------------------

    public ImmutableArray<WorldLaneWaypoint> GetLaneWaypoints(int laneIndex)
        => m_worldLanes[laneIndex].Waypoints;

    /// Picks the lane whose entry direction matches vehicleFacingDir.
    public bool TryGetLaneForApproach(
        Direction90 vehicleFacingDir,
        out int laneIndex,
        out ImmutableArray<WorldLaneWaypoint> waypoints)
    {
        for (int i = 0; i < m_worldLanes.Length; i++)
        {
            if (m_worldLanes[i].EntryDir == vehicleFacingDir)
            {
                laneIndex = i;
                waypoints = m_worldLanes[i].Waypoints;
                return true;
            }
        }
        laneIndex = -1;
        waypoints = default;
        return false;
    }

    // -------------------------------------------------------------------------
    // Construction
    // -------------------------------------------------------------------------

    private static WorldLane[] BuildWorldLanes(
        ModularRoadPieceProto proto,
        TileTransform         transform)
    {
        var bakedLanes = proto.GetBakedLanes(transform.Rotation);
        var worldLanes = new WorldLane[bakedLanes.Length];
        var originX    = (Fix32)transform.Position.X;
        var originY    = (Fix32)transform.Position.Y;
        var worldZ     = (short)transform.Position.Z;

        for (int i = 0; i < bakedLanes.Length; i++)
        {
            var baked = bakedLanes[i];
            var wps   = ImmutableArray.CreateBuilder<WorldLaneWaypoint>(baked.Waypoints.Length);

            foreach (var bwp in baked.Waypoints)
            {
                var worldPos = new RelTile3f(
                    originX + bwp.LocalXY.X,
                    originY + bwp.LocalXY.Y,
                    bwp.HeightDelta.Value);
                wps.Add(new WorldLaneWaypoint(worldPos, bwp.SpeedLimitPerTick));
            }

            var built     = wps.MoveToImmutable();
            var firstWp   = built[0];
            var lastWp    = built[built.Length - 1];
            var startNode = MakeNodeKey(firstWp, worldZ, baked.LocalEntryDir, baked.LaneType);
            var endNode   = MakeNodeKey(lastWp,  worldZ, baked.LocalExitDir,  baked.LaneType);

            worldLanes[i] = new WorldLane(
                waypoints: built,
                startNode: startNode,
                endNode:   endNode,
                entryDir:  baked.LocalEntryDir,
                laneType:  baked.LaneType
            );
        }

        return worldLanes;
    }

    private static RoadGraphNodeKey MakeNodeKey(
        WorldLaneWaypoint wp,
        short             worldZ,
        Direction90       exitDir,
        RoadLaneType      laneType)
    {
        return new RoadGraphNodeKey(
            x:         new RelTile1f(wp.WorldPos.X),
            y:         new RelTile1f(wp.WorldPos.Y),
            z:         worldZ,
            direction: ModularRoadPieceProto.ToTrackDir(exitDir),
            laneType:  laneType);
    }
}

// =============================================================================
// 8. ModularRoadLayouts
//    Builds an EntityLayout per shape using the project's existing
//    CustomLayoutToken conventions (matching BetterLifesMachineDef.cs patterns).
//
//    Each piece uses a 4x4-tile footprint (origin at low-XY corner).
//    'h4.' token  = elevated tile at height 4 with vehicle surface
//                   (same token used extensively in IndustrialRoads).
//    All pieces use IdsCore.TerrainTileSurfaces.DefaultConcrete surface.
// =============================================================================
public static class ModularRoadLayouts
{
    // Shared layout params — mirrors the pattern in BetterLifesMachineDef.cs.
    private static EntityLayoutParams MakeParams()
    {
        var tokens = new CustomLayoutToken[]
        {
            new CustomLayoutToken("h4.", (EntityLayoutParams p, int h) =>
                new LayoutTokenSpec(h - 1, h, LayoutTileConstraint.None, null, null, null,
                    2 + ((h - 1) * 0.250).ToFix32(), null, null, false, false, 0)),

            new CustomLayoutToken("_4=", (EntityLayoutParams p, int h) =>
            {
                int heightFrom = h - 1;
                int? maxTerrainHeight = h - 1;
                Fix32? vehicleHeight  = h - 1;
                return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.None,
                    null, null, maxTerrainHeight, vehicleHeight);
            }),
        };
        return new EntityLayoutParams(null, tokens,
            portsCanOnlyConnectToTransports: false,
            IdsCore.TerrainTileSurfaces.DefaultConcrete,
            null, null, null, null, null, default);
    }

    // -------------------------------------------------------------------------
    // STRAIGHT — 4x4, all tiles driveable (matches Road1StraightSmall footprint)
    // -------------------------------------------------------------------------
    public static EntityLayout Straight(IEntityLayoutParser layoutParser)
        => layoutParser.ParseLayoutOrThrow(MakeParams(), new[]
        {
            "h4.h4.h4.h4.",
            "h4.h4.h4.h4.",
            "h4.h4.h4.h4.",
            "h4.h4.h4.h4.",
        });

    // -------------------------------------------------------------------------
    // CORNER — 4x4, triangular fill (South + East ports)
    // -------------------------------------------------------------------------
    public static EntityLayout Corner(IEntityLayoutParser layoutParser)
        => layoutParser.ParseLayoutOrThrow(MakeParams(), new[]
        {
            "h4.h4.",
            "h4.h4.h4.",
            "h4.h4.h4.h4.",
            "h4.h4.h4.h4.",
        });

    // -------------------------------------------------------------------------
    // TEE — 4x4, full width straight + 2-tile branch stem (West + East + South)
    // -------------------------------------------------------------------------
    public static EntityLayout Tee(IEntityLayoutParser layoutParser)
        => layoutParser.ParseLayoutOrThrow(MakeParams(), new[]
        {
            "h4.h4.h4.h4.",
            "h4.h4.h4.h4.",
            "h4.h4.",
            "h4.h4.",
        });

    // -------------------------------------------------------------------------
    // CROSSING — cross-shaped (West + East + North + South)
    // -------------------------------------------------------------------------
    public static EntityLayout Crossing(IEntityLayoutParser layoutParser)
        => layoutParser.ParseLayoutOrThrow(MakeParams(), new[]
        {
            "   h4.h4.",
            "h4.h4.h4.h4.",
            "h4.h4.h4.h4.",
            "   h4.h4.",
        });

    // -------------------------------------------------------------------------
    // ELEVATED CROSSING — same ground footprint as Crossing
    //   (height handled by waypoint HeightDelta, not the layout)
    // -------------------------------------------------------------------------
    public static EntityLayout ElevatedCrossing(IEntityLayoutParser layoutParser)
        => Crossing(layoutParser);
}

// =============================================================================
// 9. ModularRoadPieceRegistrar  (IModData)
//    Call registrator.RegisterData<ModularRoadPieceRegistrar>() from
//    BetterLife_RoadsAndSigns.RegisterPrototypes() to activate.
//
//    IDs are placed under BetterLIDs.dPath.IndustrialRoads namespace
//    (extend IDsBuildings.cs with the new IDs below).
// =============================================================================
public class ModularRoadPieceRegistrar : IModData
{
    public void RegisterData(ProtoRegistrator registrator)
    {
        var parser = registrator.LayoutParser;
        var costs  = BLCosts.Roads.Industrial;

        // Toolbar: reuse the existing RoadsIndustrial category.
        var toolbar = BetterLIDs.ToolBars.RoadsIndustrial;

        var straight = Build(registrator, parser,
            id:     ModularRoadIds.Straight,
            name:   "Modular Straight",
            layout: ModularRoadLayouts.Straight(parser),
            lanes:  RoadPieceShapes.Straight(),
            ports:  StraightPorts(),
            shape:  RoadPieceShape.Straight,
            costs:  costs,
            asset:  "Assets/BetterLife/Roads/Modular/straight.prefab",
            icon:   "Assets/BetterLife/IconsRoad/RoadIndustrial/oneway_straight.png",
            cat:    toolbar);

        var corner = Build(registrator, parser,
            id:     ModularRoadIds.Corner,
            name:   "Modular Corner",
            layout: ModularRoadLayouts.Corner(parser),
            lanes:  RoadPieceShapes.Corner(),
            ports:  CornerPorts(),
            shape:  RoadPieceShape.Corner,
            costs:  costs,
            asset:  "Assets/BetterLife/Roads/Modular/corner.prefab",
            icon:   "Assets/BetterLife/IconsRoad/RoadIndustrial/onewayCorner.png",
            cat:    toolbar);

        var tee = Build(registrator, parser,
            id:     ModularRoadIds.Tee,
            name:   "Modular T-Junction",
            layout: ModularRoadLayouts.Tee(parser),
            lanes:  RoadPieceShapes.Tee(),
            ports:  TeePorts(),
            shape:  RoadPieceShape.Tee,
            costs:  costs,
            asset:  "Assets/BetterLife/Roads/Modular/tee.prefab",
            icon:   "Assets/BetterLife/IconsRoad/RoadIndustrial/onewayTee.png",
            cat:    toolbar);

        var crossing = Build(registrator, parser,
            id:     ModularRoadIds.Crossing,
            name:   "Modular Crossing",
            layout: ModularRoadLayouts.Crossing(parser),
            lanes:  RoadPieceShapes.Crossing(),
            ports:  CrossingPorts(),
            shape:  RoadPieceShape.Crossing,
            costs:  costs,
            asset:  "Assets/BetterLife/Roads/Modular/crossing.prefab",
            icon:   "Assets/BetterLife/IconsRoad/RoadIndustrial/onewayCross.png",
            cat:    toolbar);

        var elevatedCrossing = Build(registrator, parser,
            id:     ModularRoadIds.ElevatedCrossing,
            name:   "Modular Elevated Crossing",
            layout: ModularRoadLayouts.ElevatedCrossing(parser),
            lanes:  RoadPieceShapes.ElevatedCrossing(),
            ports:  CrossingPorts(),
            shape:  RoadPieceShape.ElevatedCrossing,
            costs:  costs,
            asset:  "Assets/BetterLife/Roads/Modular/elevatedCrossing.prefab",
            icon:   "Assets/BetterLife/IconsRoad/RoadIndustrial/onewayCross.png",
            cat:    toolbar);

        registrator.PrototypesDb.Add(straight);
        registrator.PrototypesDb.Add(corner);
        registrator.PrototypesDb.Add(tee);
        registrator.PrototypesDb.Add(crossing);
        registrator.PrototypesDb.Add(elevatedCrossing);
    }

    private static ModularRoadPieceProto Build(
        ProtoRegistrator               registrator,
        IEntityLayoutParser            parser,
        StaticEntityProto.ID           id,
        string                         name,
        EntityLayout                   layout,
        ImmutableArray<ModularLaneDef> lanes,
        ImmutableArray<PiecePort>      ports,
        RoadPieceShape                 shape,
        EntityCostsTpl                 costs,
        string                         asset,
        string                         icon,
        Proto.ID                       cat)
    {
        var categories = cat != BetterLIDs.ToolBars.HiddenProto
            ? ImmutableArray.Create(registrator.GetCategory(cat))
            : ImmutableArray<ToolbarEntryData>.Empty;

        var gfx = new blRoadEntityProtoBase.Gfx(asset, categories, default, null, false);

        // Stamp the icon path via reflection (same pattern as the rest of the project).
        typeof(LayoutEntityProto.Gfx)
            .GetProperty(nameof(LayoutEntityProto.Gfx.IconPath), BindingFlags.Public | BindingFlags.Instance)
            ?.SetValue(gfx, icon);
        typeof(LayoutEntityProto.Gfx)
            .GetField(nameof(LayoutEntityProto.Gfx.IconIsCustom), BindingFlags.Public | BindingFlags.Instance)
            ?.SetValue(gfx, true);

        return new ModularRoadPieceProto(
            id:           id,
            strings:      Proto.CreateStr(id, name, "BL Modular Roads"),
            layout:       layout,
            costs:        costs.MapToEntityCosts(registrator),
            modularLanes: lanes,
            ports:        ports,
            shape:        shape,
            graphics:     gfx);
    }

    // Port definitions — midpoints of each side of the 4x4 layout.
    private static ImmutableArray<PiecePort> StraightPorts() => ImmutableArray.Create(
        new PiecePort(Direction90.MinusX, new RelTile2f(0f, 2f), RoadLaneType.BasicLaneFlag),
        new PiecePort(Direction90.PlusX,  new RelTile2f(4f, 2f), RoadLaneType.BasicLaneFlag));

    private static ImmutableArray<PiecePort> CornerPorts() => ImmutableArray.Create(
        new PiecePort(Direction90.MinusY, new RelTile2f(2f, 0f), RoadLaneType.BasicLaneFlag),
        new PiecePort(Direction90.PlusX,  new RelTile2f(4f, 2f), RoadLaneType.BasicLaneFlag));

    private static ImmutableArray<PiecePort> TeePorts() => ImmutableArray.Create(
        new PiecePort(Direction90.MinusX, new RelTile2f(0f, 2f), RoadLaneType.BasicLaneFlag),
        new PiecePort(Direction90.PlusX,  new RelTile2f(4f, 2f), RoadLaneType.BasicLaneFlag),
        new PiecePort(Direction90.MinusY, new RelTile2f(2f, 0f), RoadLaneType.BasicLaneFlag));

    private static ImmutableArray<PiecePort> CrossingPorts() => ImmutableArray.Create(
        new PiecePort(Direction90.MinusX, new RelTile2f(0f, 2f), RoadLaneType.BasicLaneFlag),
        new PiecePort(Direction90.PlusX,  new RelTile2f(4f, 2f), RoadLaneType.BasicLaneFlag),
        new PiecePort(Direction90.MinusY, new RelTile2f(2f, 0f), RoadLaneType.BasicLaneFlag),
        new PiecePort(Direction90.PlusY,  new RelTile2f(2f, 4f), RoadLaneType.BasicLaneFlag));
}

/// Proto IDs — add these to IDsBuildings.cs under BetterLIDs.dPath.IndustrialRoads.
public static class ModularRoadIds
{
    public static readonly RoadEntityProto.ID Straight        = new RoadEntityProto.ID("modularStraight");
    public static readonly RoadEntityProto.ID Corner          = new RoadEntityProto.ID("modularCorner");
    public static readonly RoadEntityProto.ID Tee             = new RoadEntityProto.ID("modularTee");
    public static readonly RoadEntityProto.ID Crossing        = new RoadEntityProto.ID("modularCrossing");
    public static readonly RoadEntityProto.ID ElevatedCrossing = new RoadEntityProto.ID("modularElevatedCrossing");
}

public enum RoadPieceShape { Straight, Corner, Tee, Crossing, ElevatedCrossing }

// =============================================================================
// 10. VehicleHijackState
//     Shared set checked by Harmony patches.
// =============================================================================
public static class VehicleHijackState
{
    private static readonly HashSet<DrivingEntity> s_hijacked = new HashSet<DrivingEntity>();

    public static void Register(DrivingEntity v)   => s_hijacked.Add(v);
    public static void Unregister(DrivingEntity v) => s_hijacked.Remove(v);
    public static bool IsHijacked(DrivingEntity v) => s_hijacked.Contains(v);
}

// =============================================================================
// 11. Harmony patches
//     Bypasses canDriveForwards / canDriveBackwards for hijacked vehicles.
//     Apply via: new Harmony("BetterLife.ModularRoads").PatchAll(Assembly);
//     (add this call to BetterLife_RoadsAndSigns constructor if not done yet)
// =============================================================================
[HarmonyPatch(typeof(DrivingEntity), "canDriveForwards")]
internal static class PatchCanDriveForwards
{
    static bool Prefix(DrivingEntity __instance, ref bool __result)
    {
        if (!VehicleHijackState.IsHijacked(__instance)) return true;
        __result = true;
        return false;
    }
}

[HarmonyPatch(typeof(DrivingEntity), "canDriveBackwards")]
internal static class PatchCanDriveBackwards
{
    static bool Prefix(DrivingEntity __instance, ref bool __result)
    {
        if (!VehicleHijackState.IsHijacked(__instance)) return true;
        __result = true;
        return false;
    }
}

// =============================================================================
// 12. WaypointJobProvider
//     IJobProvider<Truck>: feeds DriveToJob waypoints one by one,
//     applying per-waypoint speed via reflection on m_speedLimitPerTick.
// =============================================================================
public class WaypointJobProvider : IJobProvider<Truck>
{
    private static readonly FieldInfo s_speedLimitField =
        typeof(DrivingEntity).GetField(
            "m_speedLimitPerTick",
            BindingFlags.Instance | BindingFlags.NonPublic)
        ?? throw new InvalidOperationException(
            "m_speedLimitPerTick not found on DrivingEntity — game may have updated.");

    private readonly ImmutableArray<WorldLaneWaypoint> m_waypoints;
    private readonly DriveToJob.Factory                m_driveToJobFactory;
    private readonly Action                            m_onDone;
    private readonly RelTile1f                         m_defaultSpeedPerTick;
    private int                                        m_index;

    public WaypointJobProvider(
        ImmutableArray<WorldLaneWaypoint> waypoints,
        DriveToJob.Factory                driveToJobFactory,
        Action                            onDone,
        RelTile1f                         defaultSpeedPerTick)
    {
        m_waypoints           = waypoints;
        m_driveToJobFactory   = driveToJobFactory;
        m_onDone              = onDone;
        m_defaultSpeedPerTick = defaultSpeedPerTick;
        m_index               = 0;
    }

    public IVehicleJob TryGetJobFor(Truck truck)
    {
        if (m_index >= m_waypoints.Length)
        {
            m_onDone?.Invoke();
            return null;
        }

        var wp      = m_waypoints[m_index];
        bool isLast = m_index == m_waypoints.Length - 1;

        var speed = wp.SpeedLimitPerTick.Value > Fix32.Zero
            ? wp.SpeedLimitPerTick
            : m_defaultSpeedPerTick;
        s_speedLimitField.SetValue(truck.DrivingEntity, speed);

        // Height (Z) is applied visually — DrivingEntity.SetDrivingTarget is 2D.
        // If you need to move the visual Z for ramps, do so here or in a SimUpdate hook.
        m_index++;

        return m_driveToJobFactory.CreateJob(
            vehicle:        truck,
            goal:           wp.XY,
            isTerminal:     isLast,
            tolerance:      new RelTile1f(0.5f),
            driveBackwards: false,
            timeout:        null);
    }
}

// =============================================================================
// 13. VehicleHijacker
//     High-level take/release API used by your entity's SimUpdate.
// =============================================================================
public class VehicleHijacker
{
    private readonly DriveToJob.Factory m_driveToJobFactory;
    private readonly HashSet<Truck>     m_hijackedTrucks = new HashSet<Truck>();

    public VehicleHijacker(DriveToJob.Factory driveToJobFactory)
    {
        m_driveToJobFactory = driveToJobFactory;
    }

    /// Call when a vehicle enters your road piece's capture radius.
    public void TakeControl(
        Truck                  truck,
        ModularRoadPieceEntity roadPiece,
        RelTile1f              defaultSpeed)
    {
        if (m_hijackedTrucks.Contains(truck)) return;

        var approachDir = Direction90.FromAngle(truck.DrivingEntity.Rotation);

        ImmutableArray<WorldLaneWaypoint> waypoints;
        if (!roadPiece.TryGetLaneForApproach(approachDir, out _, out waypoints))
            waypoints = roadPiece.GetLaneWaypoints(0);

        truck.JobsOld.CancelAll();

        if (truck is PathFindingEntity pfe)
            pfe.StopNavigating(clearRoadState: true);

        truck.DrivingEntity.ClearRoadDrivingState();

        VehicleHijackState.Register(truck.DrivingEntity);
        m_hijackedTrucks.Add(truck);

        truck.SetJobProvider(new WaypointJobProvider(
            waypoints:           waypoints,
            driveToJobFactory:   m_driveToJobFactory,
            onDone:              () => ReleaseControl(truck),
            defaultSpeedPerTick: defaultSpeed));
    }

    /// Called automatically when the last waypoint is reached.
    public void ReleaseControl(Truck truck)
    {
        if (!m_hijackedTrucks.Contains(truck)) return;

        VehicleHijackState.Unregister(truck.DrivingEntity);
        m_hijackedTrucks.Remove(truck);

        truck.DrivingEntity.StopDriving();
        truck.ResetJobProvider();
    }

    public bool IsControlling(Truck truck) => m_hijackedTrucks.Contains(truck);
}

// =============================================================================
// 14. RoadPieceShapes
//     Waypoint data for each shape on a 4x4-tile footprint.
//     Origin (0,0) = low-XY corner; centre of piece ≈ (2, 2).
//     Speeds in tiles/tick.  Heights in tiles above terrain.
// =============================================================================
public static class RoadPieceShapes
{
    // -------------------------------------------------------------------------
    // STRAIGHT — West(-X) <-> East(+X)
    //   Left lane  W->E at Y+0.25 (above centre)
    //   Right lane E->W at Y-0.25 (below centre)
    // -------------------------------------------------------------------------
    public static ImmutableArray<ModularLaneDef> Straight() => ImmutableArray.Create(

        new ModularLaneDef(
            waypoints: ImmutableArray.Create(
                ModularLaneWaypoint.AtSpeed(new RelTile2f(0f, 2.25f), speed: new RelTile1f(0.8f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(2f, 2.25f), speed: new RelTile1f(0.8f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(4f, 2.25f), speed: new RelTile1f(0.8f))),
            localEntryDir: Direction90.MinusX,
            localExitDir:  Direction90.PlusX),

        new ModularLaneDef(
            waypoints: ImmutableArray.Create(
                ModularLaneWaypoint.AtSpeed(new RelTile2f(4f, 1.75f), speed: new RelTile1f(0.8f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(2f, 1.75f), speed: new RelTile1f(0.8f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(0f, 1.75f), speed: new RelTile1f(0.8f))),
            localEntryDir: Direction90.PlusX,
            localExitDir:  Direction90.MinusX)
    );

    // -------------------------------------------------------------------------
    // CORNER — South(-Y) -> East(+X)
    //   Vehicles slow at the apex.
    // -------------------------------------------------------------------------
    public static ImmutableArray<ModularLaneDef> Corner() => ImmutableArray.Create(

        new ModularLaneDef(
            waypoints: ImmutableArray.Create(
                ModularLaneWaypoint.AtSpeed(new RelTile2f(2.25f, 0f),    speed: new RelTile1f(0.8f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(2.25f, 1.0f),  speed: new RelTile1f(0.5f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(2.25f, 1.75f), speed: new RelTile1f(0.3f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(3.0f,  2.25f), speed: new RelTile1f(0.5f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(4f,    2.25f), speed: new RelTile1f(0.8f))),
            localEntryDir: Direction90.MinusY,
            localExitDir:  Direction90.PlusX),

        new ModularLaneDef(
            waypoints: ImmutableArray.Create(
                ModularLaneWaypoint.AtSpeed(new RelTile2f(4f,    1.75f), speed: new RelTile1f(0.8f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(3.0f,  1.75f), speed: new RelTile1f(0.5f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(1.75f, 1.75f), speed: new RelTile1f(0.3f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(1.75f, 1.0f),  speed: new RelTile1f(0.5f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(1.75f, 0f),    speed: new RelTile1f(0.8f))),
            localEntryDir: Direction90.PlusX,
            localExitDir:  Direction90.MinusY)
    );

    // -------------------------------------------------------------------------
    // TEE — West(-X), East(+X), South(-Y) ports
    //   Straight W<->E + branch South->East + West->South
    // -------------------------------------------------------------------------
    public static ImmutableArray<ModularLaneDef> Tee() => ImmutableArray.Create(

        new ModularLaneDef(   // W->E straight
            waypoints: ImmutableArray.Create(
                ModularLaneWaypoint.AtSpeed(new RelTile2f(0f, 2.25f), new RelTile1f(0.8f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(2f, 2.25f), new RelTile1f(0.8f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(4f, 2.25f), new RelTile1f(0.8f))),
            localEntryDir: Direction90.MinusX,
            localExitDir:  Direction90.PlusX),

        new ModularLaneDef(   // E->W straight
            waypoints: ImmutableArray.Create(
                ModularLaneWaypoint.AtSpeed(new RelTile2f(4f, 1.75f), new RelTile1f(0.8f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(2f, 1.75f), new RelTile1f(0.8f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(0f, 1.75f), new RelTile1f(0.8f))),
            localEntryDir: Direction90.PlusX,
            localExitDir:  Direction90.MinusX),

        new ModularLaneDef(   // South->East merge
            waypoints: ImmutableArray.Create(
                ModularLaneWaypoint.AtSpeed(new RelTile2f(2.25f, 0f),    new RelTile1f(0.8f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(2.25f, 1.5f),  new RelTile1f(0.4f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(3.0f,  2.25f), new RelTile1f(0.6f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(4f,    2.25f), new RelTile1f(0.8f))),
            localEntryDir: Direction90.MinusY,
            localExitDir:  Direction90.PlusX),

        new ModularLaneDef(   // West->South peel-off
            waypoints: ImmutableArray.Create(
                ModularLaneWaypoint.AtSpeed(new RelTile2f(0f,    2.25f), new RelTile1f(0.8f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(1.0f,  2.25f), new RelTile1f(0.6f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(1.75f, 1.5f),  new RelTile1f(0.4f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(1.75f, 0f),    new RelTile1f(0.8f))),
            localEntryDir: Direction90.MinusX,
            localExitDir:  Direction90.MinusY)
    );

    // -------------------------------------------------------------------------
    // CROSSING — all four ports; slow at centre
    // -------------------------------------------------------------------------
    public static ImmutableArray<ModularLaneDef> Crossing() => ImmutableArray.Create(

        new ModularLaneDef(   // W->E
            waypoints: ImmutableArray.Create(
                ModularLaneWaypoint.AtSpeed(new RelTile2f(0f, 2.25f), new RelTile1f(0.8f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(2f, 2.25f), new RelTile1f(0.5f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(4f, 2.25f), new RelTile1f(0.8f))),
            localEntryDir: Direction90.MinusX,
            localExitDir:  Direction90.PlusX),

        new ModularLaneDef(   // E->W
            waypoints: ImmutableArray.Create(
                ModularLaneWaypoint.AtSpeed(new RelTile2f(4f, 1.75f), new RelTile1f(0.8f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(2f, 1.75f), new RelTile1f(0.5f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(0f, 1.75f), new RelTile1f(0.8f))),
            localEntryDir: Direction90.PlusX,
            localExitDir:  Direction90.MinusX),

        new ModularLaneDef(   // N->S
            waypoints: ImmutableArray.Create(
                ModularLaneWaypoint.AtSpeed(new RelTile2f(2.25f, 4f), new RelTile1f(0.8f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(2.25f, 2f), new RelTile1f(0.5f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(2.25f, 0f), new RelTile1f(0.8f))),
            localEntryDir: Direction90.PlusY,
            localExitDir:  Direction90.MinusY),

        new ModularLaneDef(   // S->N
            waypoints: ImmutableArray.Create(
                ModularLaneWaypoint.AtSpeed(new RelTile2f(1.75f, 0f), new RelTile1f(0.8f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(1.75f, 2f), new RelTile1f(0.5f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(1.75f, 4f), new RelTile1f(0.8f))),
            localEntryDir: Direction90.MinusY,
            localExitDir:  Direction90.PlusY)
    );

    // -------------------------------------------------------------------------
    // ELEVATED CROSSING — EW arcs over NS at height +1.5 tiles
    // -------------------------------------------------------------------------
    public static ImmutableArray<ModularLaneDef> ElevatedCrossing() => ImmutableArray.Create(

        new ModularLaneDef(   // W->E elevated
            waypoints: ImmutableArray.Create(
                ModularLaneWaypoint.Elevated(new RelTile2f(0f, 2.25f), new RelTile1f(0.0f), new RelTile1f(0.8f)),
                ModularLaneWaypoint.Elevated(new RelTile2f(1f, 2.25f), new RelTile1f(0.8f), new RelTile1f(0.6f)),
                ModularLaneWaypoint.Elevated(new RelTile2f(2f, 2.25f), new RelTile1f(1.5f), new RelTile1f(0.5f)),
                ModularLaneWaypoint.Elevated(new RelTile2f(3f, 2.25f), new RelTile1f(0.8f), new RelTile1f(0.6f)),
                ModularLaneWaypoint.Elevated(new RelTile2f(4f, 2.25f), new RelTile1f(0.0f), new RelTile1f(0.8f))),
            localEntryDir: Direction90.MinusX,
            localExitDir:  Direction90.PlusX,
            laneType:      RoadLaneType.ElevatedLaneFlag),

        new ModularLaneDef(   // E->W elevated
            waypoints: ImmutableArray.Create(
                ModularLaneWaypoint.Elevated(new RelTile2f(4f, 1.75f), new RelTile1f(0.0f), new RelTile1f(0.8f)),
                ModularLaneWaypoint.Elevated(new RelTile2f(3f, 1.75f), new RelTile1f(0.8f), new RelTile1f(0.6f)),
                ModularLaneWaypoint.Elevated(new RelTile2f(2f, 1.75f), new RelTile1f(1.5f), new RelTile1f(0.5f)),
                ModularLaneWaypoint.Elevated(new RelTile2f(1f, 1.75f), new RelTile1f(0.8f), new RelTile1f(0.6f)),
                ModularLaneWaypoint.Elevated(new RelTile2f(0f, 1.75f), new RelTile1f(0.0f), new RelTile1f(0.8f))),
            localEntryDir: Direction90.PlusX,
            localExitDir:  Direction90.MinusX,
            laneType:      RoadLaneType.ElevatedLaneFlag),

        new ModularLaneDef(   // N->S ground
            waypoints: ImmutableArray.Create(
                ModularLaneWaypoint.AtSpeed(new RelTile2f(2.25f, 4f), new RelTile1f(0.7f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(2.25f, 2f), new RelTile1f(0.7f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(2.25f, 0f), new RelTile1f(0.7f))),
            localEntryDir: Direction90.PlusY,
            localExitDir:  Direction90.MinusY),

        new ModularLaneDef(   // S->N ground
            waypoints: ImmutableArray.Create(
                ModularLaneWaypoint.AtSpeed(new RelTile2f(1.75f, 0f), new RelTile1f(0.7f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(1.75f, 2f), new RelTile1f(0.7f)),
                ModularLaneWaypoint.AtSpeed(new RelTile2f(1.75f, 4f), new RelTile1f(0.7f))),
            localEntryDir: Direction90.MinusY,
            localExitDir:  Direction90.PlusY)
    );
}

} // namespace BetterLife_RoadsAndSigns.ModularRoads
