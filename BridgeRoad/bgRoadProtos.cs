using Mafi;
using Mafi.Base;
using Mafi.Base.Prototypes.Bridges;
using Mafi.Base.Prototypes.Trains;
using Mafi.Collections;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core;
using Mafi.Core.Bridges;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Static;
using Mafi.Core.Mods;
using Mafi.Core.Prototypes;
using Mafi.Core.Simulation;
using Mafi.Core.Trains;
using Mafi.Curves;
using System;
using System.Reflection;

namespace BetterLife_RoadsAndSigns
{
    public static class bgRoadProtos
    {
        private static readonly ImmutableArray<RelTile1f> ROAD_LANE_OFFSETS =
        ImmutableArray.Create(
                                    new RelTile1f((-1).ToFix32()),
                                    new RelTile1f(1.ToFix32())
                                );

        public static BridgeProto CreateStraightProto(ProtoRegistrator registrator, StaticEntityProto.ID id, Proto.Str protoStr, StaticEntityProto.ID protoSuffix, int curveLength,
            RelTile1f roadWidth, bool isEntrance, bool isStraight, string assetPath, string assetIcon)
        {

            BridgeProto bgProto = new BridgeProto(
                id,
                protoStr,
                slimId: 250,
                gridSizeXy: 1,
                gridSizeZ: 1,
                slopeStartDeltaHeight: 0,
                minHeightAboveGround: 0,
                turnRadius: 3,
                pillarsAtEnds: false,
                pillarExtentsAlongTrajectory: 0,
                footMinDepthBelowDeck: 0.TilesThick(),
                pillarMaxDepth: 1.TilesThick(),
                graphics: new BridgeProto.Gfx(assetIcon)
            );

            BridgesSegmentsData.CreateBridgeSegmentProto(
                registrator,
                BetterLIDs.dPath.IndustrialRoads.rampMiddle1,
                bgProto,
                CreateStraightCurve(4),
                pillarsFactory: NoPillars,
                width: roadWidth,
                deckThickness: 0.TilesThick(),
                maxPillarFootUndermine: 0.TilesThick(),
                minHeightAboveOcean: 0.TilesThick(),
                relaxPillarHeightReq: 0.TilesThick(),
                baseCosts: EntityCosts.None,
                pillarCosts: EntityCosts.None,
                laneRightOffsets: ROAD_LANE_OFFSETS,
                prefabPath: BetterLIDs.dPath.RoadEntities.rampMiddle1.asset,
                iconPath: BetterLIDs.dPath.RoadEntities.rampMiddle1.icon,
                //iconPath: Option<string>.None,
                explicitLayout: null,
                samplesPer10Tiles: 10,
                shorterEntranceCurve: null,
                isEntrance: true,
                startHeightDelta: ThicknessTilesF.Zero,
                endHeightDelta: ThicknessTilesF.Zero,
                startGradeFactor: TrainTrackGradeFactor.G0,
                endGradeFactor: TrainTrackGradeFactor.G0,
                isStraight: true,
                allowNonIntegerStart: false,
                allowNonIntegerEnd: false
            );
            BridgesSegmentsData.CreateBridgeSegmentProto(
                registrator,
                BetterLIDs.dPath.IndustrialRoads.rStraightMid,
                bgProto,
                CreateStraightCurve(7),
                pillarsFactory: NoPillars,
                width: roadWidth,
                deckThickness: 0.TilesThick(),
                maxPillarFootUndermine: 0.TilesThick(),
                minHeightAboveOcean: 0.TilesThick(),
                relaxPillarHeightReq: 0.TilesThick(),
                baseCosts: EntityCosts.None,
                pillarCosts: EntityCosts.None,
                laneRightOffsets: ROAD_LANE_OFFSETS,
                prefabPath: BetterLIDs.dPath.RoadEntities.onewayStraight2.asset,
                iconPath: Option<string>.None,
                explicitLayout: null,
                samplesPer10Tiles: 10,
                shorterEntranceCurve: null,
                isEntrance: false,
                startHeightDelta: ThicknessTilesF.Zero,
                endHeightDelta: ThicknessTilesF.Zero,
                startGradeFactor: TrainTrackGradeFactor.G0,
                endGradeFactor: TrainTrackGradeFactor.G0,
                isStraight: true,
                allowNonIntegerStart: false,
                allowNonIntegerEnd: false
            );
            //BridgesSegmentsData.CreateBridgeSegmentProto(
            //    registrator,
            //    BetterLIDs.dPath.IndustrialRoads.rCorner,
            //    bgProto,
            //    CreateCurve90R8(),
            //    pillarsFactory: NoPillars,
            //    width: roadWidth,
            //    deckThickness: 0.TilesThick(),
            //    maxPillarFootUndermine: 0.TilesThick(),
            //    minHeightAboveOcean: 0.TilesThick(),
            //    relaxPillarHeightReq: 0.TilesThick(),
            //    baseCosts: EntityCosts.None,
            //    pillarCosts: EntityCosts.None,
            //    laneRightOffsets: ROAD_LANE_OFFSETS,
            //    prefabPath: BetterLIDs.dPath.RoadEntities.onewayCorner2.asset,
            //    iconPath: Option<string>.None,
            //    explicitLayout: null,
            //    samplesPer10Tiles: 10,
            //    shorterEntranceCurve: null,
            //    isEntrance: false,
            //    startHeightDelta: ThicknessTilesF.Zero,
            //    endHeightDelta: ThicknessTilesF.Zero,
            //    startGradeFactor: TrainTrackGradeFactor.G0,
            //    endGradeFactor: TrainTrackGradeFactor.G0,
            //    isStraight: false,
            //    allowNonIntegerStart: false,
            //    allowNonIntegerEnd: false
            //);

            return bgProto;

        }
        private static CubicBezierCurve2f CreateStraightCurve(int length)
        {
            return TrainTracksData.CreateCurve(
                (0.0, 0.0),
                (length * 0.25, 0.0),
                (length * 0.75, 0.0),
                ((double)length, 0.0)
            );
        }
        private static CubicBezierCurve2f CreateCurve90R8()
        {
            return TrainTracksData.CreateCurve(
                (0.0, 0.0),
                (5.0, 0.0),
                (8.0, 3.0),
                (8.0, 8.0)
            );
        }

        private static (string[] layout, RelTile3i centerTop)[] NoPillars(
            TrainTrackTrajectoryData traj
        )
        {
            return new (string[] layout, RelTile3i centerTop)[0];
        }

    }
    [GlobalDependency(RegistrationMode.AsEverything, false, false)]
    public sealed class MorGroundBridgeRoadAutoLaneManager
    {
        private readonly ProtosDb m_protosDb;

        private readonly Lyst<BridgeSegment> m_pendingSegments =
            new Lyst<BridgeSegment>();

        private int m_delayTicks;

        public MorGroundBridgeRoadAutoLaneManager(
            EntitiesManager entitiesManager,
            ProtosDb protosDb,
            ISimLoopEvents simLoopEvents
        )
        {
            m_protosDb = protosDb;

            entitiesManager.StaticEntityAdded.AddNonSaveable(
                this,
                OnStaticEntityAdded
            );

            simLoopEvents.Update.AddNonSaveable(
                this,
                SimUpdate
            );
        }

        private void OnStaticEntityAdded(IStaticEntity entity)
        {
            if (!(entity is BridgeSegment segment))
            {
                return;
            }

            if (segment.Prototype.BridgeProto.Id != BetterLIDs.dPath.RoadEntities.road1)
            {
                return;
            }

            m_pendingSegments.AddIfNotPresent(segment);

            // Wait for the bridge planner to finish placing/connecting the full chain.
            m_delayTicks = 2;
        }

        private void SimUpdate()
        {
            if (m_pendingSegments.IsEmpty)
            {
                return;
            }

            if (m_delayTicks > 0)
            {
                m_delayTicks--;
                return;
            }

            BridgeLaneProto roadTwoWay =
                m_protosDb.GetOrThrow<BridgeLaneProto>(
                    Ids.Bridges.LaneTypes.RoadTwoWay
                );

            Lyst<BridgeSegment> entrancesToApply =
                new Lyst<BridgeSegment>();

            Lyst<BridgeSegment>.Enumerator enumerator =
                m_pendingSegments.GetEnumerator();

            while (enumerator.MoveNext())
            {
                BridgeSegment segment = enumerator.Current;

                if (segment == null)
                {
                    continue;
                }

                if (segment.Prototype.BridgeProto.Id != BetterLIDs.dPath.RoadEntities.road1)
                {
                    continue;
                }

                if (!segment.Prototype.IsEntrance)
                {
                    continue;
                }

                if (segment.HasAnyConfiguredLanes())
                {
                    continue;
                }

                entrancesToApply.AddIfNotPresent(segment);
            }

            Lyst<BridgeSegment>.Enumerator entranceEnumerator =
                entrancesToApply.GetEnumerator();

            while (entranceEnumerator.MoveNext())
            {
                BridgeSegment entrance = entranceEnumerator.Current;

                if (entrance == null)
                {
                    continue;
                }

                if (entrance.HasAnyConfiguredLanes())
                {
                    continue;
                }

                entrance.SetLaneLayoutAndPropagate(
                    0,
                    roadTwoWay.SomeOption()
                );
            }

            m_pendingSegments.Clear();
        }

        [GlobalDependency(RegistrationMode.AsEverything, false, false)]
        public sealed class MorRoadsPathCostTuner
        {
            public MorRoadsPathCostTuner()
            {
                TrySetRoadDistanceMultiplier(0.00f);
            }

            private static void TrySetRoadDistanceMultiplier(float multiplier)
            {
                try
                {
                    Type vehiclePathFinderType = Type.GetType(
                        "Mafi.Core.PathFinding.VehiclePathFinder, Mafi.Core"
                    );

                    if (vehiclePathFinderType == null)
                    {
                        Log.Warning("Mor Roads: Could not find Mafi.Core.PathFinding.VehiclePathFinder.");
                        return;
                    }

                    FieldInfo field = vehiclePathFinderType.GetField(
                        "ROAD_DISTANCE_MULT",
                        BindingFlags.Public |
                        BindingFlags.NonPublic |
                        BindingFlags.Static
                    );

                    if (field == null)
                    {
                        Log.Warning("Mor Roads: Could not find ROAD_DISTANCE_MULT field.");
                        return;
                    }

                    field.SetValue(
                        null,
                        Fix32.FromFloat(multiplier)
                    );

                    Log.Info("Mor Roads: ROAD_DISTANCE_MULT set to " + multiplier);
                }
                catch (Exception ex)
                {
                    Log.Warning("Mor Roads: Failed to set road distance multiplier: " + ex);
                }
            }
        }
    }
}
