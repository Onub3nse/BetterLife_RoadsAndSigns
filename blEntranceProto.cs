using Mafi;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Prototypes;
using Mafi.Core.Roads;
using System;

namespace BetterLife_RoadsAndSigns;

public class blRoadEntranceEntityProto : blRoadEntityProtoBase, IProtoWithTiers, IProtoWithIcon, IProto
{
    public readonly ImmutableArray<LaneTerrainConnectionSpec> TerrainConnections;

    public override Type EntityType
    {
        get
        {
            return typeof(blRoadEntranceEntity);
        }
    }

    public ITierData TierData { get; }
    public blRoadEntranceEntityProto(StaticEntityProto.ID id, Proto.Str strings, EntityLayout layout, EntityCosts costs, RelTile1f maxVehiclesSpeedPerTick, ImmutableArray<RoadLaneSpec> lanesSpecs, ImmutableArray<RoadLaneMetadata> lanesData, ImmutableArray<RoadLaneTrajectory> lanesTrajectories, ImmutableArray<LaneTerrainConnectionSpec> terrainConnections, blRoadEntityProtoBase.Gfx graphics, bool useTerrainHeightForVehicles, bool cannotBeBuiltByPlayer = false, bool cannotBeDestroyedByFlood = false)
        : base(id, strings, layout, costs, maxVehiclesSpeedPerTick, lanesSpecs, lanesData, lanesTrajectories, graphics, null, null, useTerrainHeightForVehicles, cannotBeBuiltByPlayer, cannotBeDestroyedByFlood, false, false, false)
    {
        this.TerrainConnections = terrainConnections;
        this.TierData = new TierData(this, 0);
        foreach (LaneTerrainConnectionSpec laneTerrainConnectionSpec in terrainConnections)
        {
            RoadLaneSpec roadLaneSpec = lanesSpecs[laneTerrainConnectionSpec.LaneIndex];
            if (laneTerrainConnectionSpec.IsAtLaneStart)
            {
                Assert.That<int>((int)(roadLaneSpec.StartType & RoadLaneType.TerrainConnectionFlag)).IsNotZero(string.Format("Lane {0} of road '{1}' has terrain connection at start ", laneTerrainConnectionSpec.LaneIndex, id) + "but the lane type flag 'TerrainConnectionFlag' is not set.");
            }
            else
            {
                Assert.That<int>((int)(roadLaneSpec.EndType & RoadLaneType.TerrainConnectionFlag)).IsNotZero(string.Format("Lane {0} of road '{1}' has terrain connection at start ", laneTerrainConnectionSpec.LaneIndex, id) + "but the lane type flag 'TerrainConnectionFlag' is not set.");
            }
        }
    }
}
