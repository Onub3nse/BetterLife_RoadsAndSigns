using Mafi;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Prototypes;
using Mafi.Core.Roads;

namespace BetterLife_RoadsAndSigns;

public abstract class blRoadEntityProtoBase : LayoutEntityProto, IRoadGraphEntityProto, ILayoutEntityProto, IStaticEntityProto, IEntityProto, IProto
{
    private readonly ImmutableArray<RoadLaneTrajectory>[] m_transformedTrajectoriesCache;
    public RelTile1f MaxVehicleSpeedPerTick { get; }
    public bool UseTerrainHeightForVehicles { get; }
    public ImmutableArray<RoadLaneSpec> LanesSpecs { get; }
    public ImmutableArray<RoadLaneMetadata> LanesData { get; }
    public ImmutableArray<RoadLaneTrajectory> LanesTrajectories { get; }
    public RelTile1f RoadTotalWidth { get; }
    public new blRoadEntityProtoBase.Gfx Graphics { get; }

    public blRoadEntityProtoBase(StaticEntityProto.ID id, Proto.Str strings, EntityLayout layout, EntityCosts costs, RelTile1f maxVehicleSpeedPerTick, ImmutableArray<RoadLaneSpec> lanesSpecs, ImmutableArray<RoadLaneMetadata> lanesData, ImmutableArray<RoadLaneTrajectory> lanesTrajectories, blRoadEntityProtoBase.Gfx graphics, Duration? constructionDurationPerProduct = null, Upoints? boostCost = null, bool useTerrainHeightForVehicles = false, bool cannotBeBuiltByPlayer = false, bool cannotBeDestroyedByFlood = false, bool isUnique = false, bool cannotBeReflected = false, bool doNotStartConstructionAutomatically = false)
        : base(id, strings, layout, costs, graphics, constructionDurationPerProduct, boostCost, cannotBeBuiltByPlayer, cannotBeDestroyedByFlood, isUnique, cannotBeReflected, false, doNotStartConstructionAutomatically, false, false, null, null, null)
    {

        Assert.That<int>(lanesData.Length).IsEqualTo(lanesTrajectories.Length, "");
        Assert.That<int>(lanesData.Length).IsEqualTo(lanesSpecs.Length, "");
        this.MaxVehicleSpeedPerTick = maxVehicleSpeedPerTick;
        this.LanesSpecs = lanesSpecs;
        this.LanesData = lanesData;
        this.LanesTrajectories = lanesTrajectories;
        this.Graphics = graphics;
        this.UseTerrainHeightForVehicles = useTerrainHeightForVehicles;
        this.RoadTotalWidth = lanesSpecs.Sum((RoadLaneSpec x) => x.GetWidth().Value).ToFix32().Tiles();
        this.m_transformedTrajectoriesCache = new ImmutableArray<RoadLaneTrajectory>[8];
    }
    public RoadLaneTrajectory GetTransformedLane(TileTransform transform, int laneIndex)
    {
        return this.GetTransformedLanes(transform)[laneIndex];
    }
    public RoadGraphNodeKey GetTransformedStartGraphNode(int laneIndex, TileTransform transform)
    {
        RoadLaneMetadata roadLaneMetadata = this.LanesData[laneIndex];
        return RoadGraphNodeKey.FromPosition(base.Layout.TransformPoint_RelToCenterTile(roadLaneMetadata.StartPosition, transform), roadLaneMetadata.StartDirection.Transformed(transform), roadLaneMetadata.StartType);
    }
    public RoadGraphNodeKey GetTransformedEndGraphNode(int laneIndex, TileTransform transform)
    {
        RoadLaneMetadata roadLaneMetadata = this.LanesData[laneIndex];
        return RoadGraphNodeKey.FromPosition(base.Layout.TransformPoint_RelToCenterTile(roadLaneMetadata.EndPosition, transform), roadLaneMetadata.EndDirection.Transformed(transform), roadLaneMetadata.EndType);
    }
    public ImmutableArray<RoadLaneTrajectory> GetTransformedLanes(TileTransform transform)
    {
        int rawValue = (int)transform.Transform90RotFlip.RawValue;
        ImmutableArray<RoadLaneTrajectory> immutableArray = this.m_transformedTrajectoriesCache[rawValue];
        if (immutableArray.IsNotValid)
        {
            immutableArray = (this.m_transformedTrajectoriesCache[rawValue] = this.ComputeTransformedTrajectory(transform));
        }
        return immutableArray;
    }
    protected ImmutableArray<RoadLaneTrajectory> ComputeTransformedTrajectory(TileTransform transform)
    {
        return this.LanesTrajectories.Map<RoadLaneTrajectory, TileTransform>(transform, (RoadLaneTrajectory x, TileTransform tr) => new RoadLaneTrajectory(x.LaneCenterSamples.Map<RelTile3f, TileTransform>(tr, (RelTile3f s, TileTransform t) => base.Layout.TransformRelativeF_Point_RelToCenterTile(s, t)), x.LaneDirectionSamples.Map<RelTile3f, TileTransform>(tr, (RelTile3f s, TileTransform t) => base.Layout.TransformDirection(s, t)), x.SegmentLengthsPrefixSums));
    }
    public new class Gfx : LayoutEntityProto.Gfx
    {
        public new static blRoadEntityProtoBase.Gfx Empty;

        public Gfx(string prefabPath, ImmutableArray<ToolbarEntryData> categories, RelTile3f prefabOrigin = default(RelTile3f), AngleDegrees1f? yawForGeneratedIcon = null, bool useInstancedRendering = false)
            : base(prefabPath, prefabOrigin, default(Option<string>), default(ColorRgba), false, null, categories, useInstancedRendering, false, null, null, default(ImmutableArray<string>), null, int.MaxValue, false, false, yawForGeneratedIcon, false)
        {
            //            ImmutableArray<ToolbarEntryData>? immutableArray = new ImmutableArray<ToolbarEntryData>?(categories);

        }
        static Gfx()
        {
            blRoadEntityProtoBase.Gfx.Empty = new blRoadEntityProtoBase.Gfx("EMPTY", ImmutableArray<ToolbarEntryData>.Empty, default(RelTile3f), null, false);
        }
    }
}
