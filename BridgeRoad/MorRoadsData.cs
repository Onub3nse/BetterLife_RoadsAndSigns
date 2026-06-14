//using Mafi;
//using Mafi.Base;
//using Mafi.Base.Prototypes.Bridges;
//using Mafi.Base.Prototypes.Trains;
//using Mafi.Collections;
//using Mafi.Collections.ImmutableCollections;
//using Mafi.Core;
//using Mafi.Core.Bridges;
//using Mafi.Core.Entities;
//using Mafi.Core.Entities.Static;
//using Mafi.Core.Mods;
//using Mafi.Core.Prototypes;
//using Mafi.Core.Simulation;
//using Mafi.Core.Trains;
//using Mafi.Curves;
//using System;
//using System.Reflection;

//namespace Mor_Roads
//{
//    public class MorRoadsData : IModData
//    {
//        private static readonly RelTile1f ROAD_WIDTH =
//            new RelTile1f(2.ToFix32());

//        private static readonly ImmutableArray<RelTile1f> ROAD_LANE_OFFSETS =
//            ImmutableArray.Create(
//                new RelTile1f((-1).ToFix32()),
//                new RelTile1f(1.ToFix32())
//            );

//        public void RegisterData(ProtoRegistrator registrator)
//        {
//            RegisterGroundBridgeRoadProto(registrator);
//            RegisterGroundBridgeRoadPieces(registrator);
//        }

//        private static void RegisterGroundBridgeRoadProto(ProtoRegistrator registrator)
//        {
//            registrator.PrototypesDb.Add(
//                new BridgeProto(
//                    MorRoadsIds.Roads.GroundBridgeRoad,
//                    Proto.CreateStr(
//                        MorRoadsIds.Roads.GroundBridgeRoad,
//                        "Ground road",
//                        "Bridge-derived road that can be built on land."
//                    ),
//                    slimId: 250,
//                    gridSizeXy: 1,
//                    gridSizeZ: 1,
//                    slopeStartDeltaHeight: 0,
//                    minHeightAboveGround: 0,
//                    turnRadius: 3,
//                    pillarsAtEnds: false,
//                    pillarExtentsAlongTrajectory: 0,
//                    footMinDepthBelowDeck: 0.TilesThick(),
//                    pillarMaxDepth: 1.TilesThick(),
//                    graphics: new BridgeProto.Gfx("Assets/Base/Bridges/Icons/Truss2.svg")
//                )
//            );
//        }

//        private static void RegisterGroundBridgeRoadPieces(ProtoRegistrator registrator)
//        {
//            BridgeProto bridgeProto =
//                registrator.PrototypesDb.GetOrThrow<BridgeProto>(
//                    MorRoadsIds.Roads.GroundBridgeRoad
//                );

//            // Entrances. These are planner-created end pieces, not normal toolbar pieces.
//            RegisterPiece(registrator, bridgeProto, "Entrance_8", CreateStraightCurve(8), true, true);
//            RegisterPiece(registrator, bridgeProto, "Entrance_12", CreateStraightCurve(12), true, true);

//            // Straight road spans.
//            RegisterPiece(registrator, bridgeProto, "Straight_8", CreateStraightCurve(8), false, true);
//            RegisterPiece(registrator, bridgeProto, "Straight_16", CreateStraightCurve(16), false, true);
//            RegisterPiece(registrator, bridgeProto, "Straight_24", CreateStraightCurve(24), false, true);
//            RegisterPiece(registrator, bridgeProto, "Straight_32", CreateStraightCurve(32), false, true);
//            RegisterPiece(registrator, bridgeProto, "Straight_40", CreateStraightCurve(40), false, true);
//            RegisterPiece(registrator, bridgeProto, "Straight_48", CreateStraightCurve(48), false, true);

//            // 45-degree straight connectors.
//            RegisterPiece(registrator, bridgeProto, "Straight45_8", CreateStraight45Curve(8), false, true);
//            RegisterPiece(registrator, bridgeProto, "Straight45_16", CreateStraight45Curve(16), false, true);

//            // Existing transition curves. Keep these IDs stable.
//            RegisterPiece(registrator, bridgeProto, "Curve_Tight_8x4", CreateTightCurve8x4(), false, false);
//            RegisterPiece(registrator, bridgeProto, "Curve_Gentle_16x8", CreateGentleCurve16x8(), false, false);

//            // New sharper 90-degree turns. R8 is sharpest; R12/R16 are safer fallbacks.
//            RegisterPiece(registrator, bridgeProto, "Curve_90_R8", CreateCurve90R8(), false, false);
//            RegisterPiece(registrator, bridgeProto, "Curve_90_R12", CreateCurve90R12(), false, false);
//            RegisterPiece(registrator, bridgeProto, "Curve_90_R16", CreateCurve90R16(), false, false);
//        }

//        private static StaticEntityProto.ID PieceId(string suffix)
//        {
//            return new StaticEntityProto.ID("MorRoads_GroundRoad_" + suffix);
//        }

//        private static CubicBezierCurve2f CreateStraightCurve(int length)
//        {
//            return TrainTracksData.CreateCurve(
//                (0.0, 0.0),
//                (length * 0.25, 0.0),
//                (length * 0.75, 0.0),
//                ((double)length, 0.0)
//            );
//        }

//        private static CubicBezierCurve2f CreateStraight45Curve(int length)
//        {
//            return TrainTracksData.CreateCurve(
//                (0.0, 0.0),
//                (length * 0.25, length * 0.25),
//                (length * 0.75, length * 0.75),
//                ((double)length, (double)length)
//            );
//        }

//        private static CubicBezierCurve2f CreateTightCurve8x4()
//        {
//            return TrainTracksData.CreateCurve(
//                (0.0, 0.0),
//                (4.0, 0.0),
//                (6.0, 2.0),
//                (8.0, 4.0)
//            );
//        }

//        private static CubicBezierCurve2f CreateGentleCurve16x8()
//        {
//            return TrainTracksData.CreateCurve(
//                (0.0, 0.0),
//                (8.0, 0.0),
//                (12.0, 4.0),
//                (16.0, 8.0)
//            );
//        }

//        private static CubicBezierCurve2f CreateCurve90R8()
//        {
//            return TrainTracksData.CreateCurve(
//                (0.0, 0.0),
//                (5.0, 0.0),
//                (8.0, 3.0),
//                (8.0, 8.0)
//            );
//        }

//        private static CubicBezierCurve2f CreateCurve90R12()
//        {
//            return TrainTracksData.CreateCurve(
//                (0.0, 0.0),
//                (7.5, 0.0),
//                (12.0, 4.5),
//                (12.0, 12.0)
//            );
//        }

//        private static CubicBezierCurve2f CreateCurve90R16()
//        {
//            return TrainTracksData.CreateCurve(
//                (0.0, 0.0),
//                (10.0, 0.0),
//                (16.0, 6.0),
//                (16.0, 16.0)
//            );
//        }

//        private static void RegisterPiece(
//            ProtoRegistrator registrator,
//            BridgeProto bridgeProto,
//            string idSuffix,
//            CubicBezierCurve2f curve,
//            bool isEntrance,
//            bool isStraight
//        )
//        {
//            BridgesSegmentsData.CreateBridgeSegmentProto(
//                registrator,
//                PieceId(idSuffix),
//                bridgeProto,
//                curve,
//                pillarsFactory: NoPillars,
//                width: ROAD_WIDTH,
//                deckThickness: 0.TilesThick(),
//                maxPillarFootUndermine: 0.TilesThick(),
//                minHeightAboveOcean: 0.TilesThick(),
//                relaxPillarHeightReq: 0.TilesThick(),
//                baseCosts: EntityCosts.None,
//                pillarCosts: EntityCosts.None,
//                laneRightOffsets: ROAD_LANE_OFFSETS,
//                prefabPath: "EMPTY",
//                iconPath: Option<string>.None,
//                explicitLayout: null,
//                samplesPer10Tiles: 10,
//                shorterEntranceCurve: null,
//                isEntrance: isEntrance,
//                startHeightDelta: ThicknessTilesF.Zero,
//                endHeightDelta: ThicknessTilesF.Zero,
//                startGradeFactor: TrainTrackGradeFactor.G0,
//                endGradeFactor: TrainTrackGradeFactor.G0,
//                isStraight: isStraight,
//                allowNonIntegerStart: false,
//                allowNonIntegerEnd: false
//            );
//        }

//        private static (string[] layout, RelTile3i centerTop)[] NoPillars(
//            TrainTrackTrajectoryData traj
//        )
//        {
//            return new (string[] layout, RelTile3i centerTop)[0];
//        }
//    }

//    [GlobalDependency(RegistrationMode.AsEverything, false, false)]
//    public sealed class MorGroundBridgeRoadAutoLaneManager
//    {
//        private readonly ProtosDb m_protosDb;

//        private readonly Lyst<BridgeSegment> m_pendingSegments =
//            new Lyst<BridgeSegment>();

//        private int m_delayTicks;

//        public MorGroundBridgeRoadAutoLaneManager(
//            EntitiesManager entitiesManager,
//            ProtosDb protosDb,
//            ISimLoopEvents simLoopEvents
//        )
//        {
//            m_protosDb = protosDb;

//            entitiesManager.StaticEntityAdded.AddNonSaveable(
//                this,
//                OnStaticEntityAdded
//            );

//            simLoopEvents.Update.AddNonSaveable(
//                this,
//                SimUpdate
//            );
//        }

//        private void OnStaticEntityAdded(IStaticEntity entity)
//        {
//            if (!(entity is BridgeSegment segment))
//            {
//                return;
//            }

//            if (segment.Prototype.BridgeProto.Id != MorRoadsIds.Roads.GroundBridgeRoad)
//            {
//                return;
//            }

//            m_pendingSegments.AddIfNotPresent(segment);

//            // Wait for the bridge planner to finish placing/connecting the full chain.
//            m_delayTicks = 2;
//        }

//        private void SimUpdate()
//        {
//            if (m_pendingSegments.IsEmpty)
//            {
//                return;
//            }

//            if (m_delayTicks > 0)
//            {
//                m_delayTicks--;
//                return;
//            }

//            BridgeLaneProto roadTwoWay =
//                m_protosDb.GetOrThrow<BridgeLaneProto>(
//                    Ids.Bridges.LaneTypes.RoadTwoWay
//                );

//            Lyst<BridgeSegment> entrancesToApply =
//                new Lyst<BridgeSegment>();

//            Lyst<BridgeSegment>.Enumerator enumerator =
//                m_pendingSegments.GetEnumerator();

//            while (enumerator.MoveNext())
//            {
//                BridgeSegment segment = enumerator.Current;

//                if (segment == null)
//                {
//                    continue;
//                }

//                if (segment.Prototype.BridgeProto.Id != MorRoadsIds.Roads.GroundBridgeRoad)
//                {
//                    continue;
//                }

//                if (!segment.Prototype.IsEntrance)
//                {
//                    continue;
//                }

//                if (segment.HasAnyConfiguredLanes())
//                {
//                    continue;
//                }

//                entrancesToApply.AddIfNotPresent(segment);
//            }

//            Lyst<BridgeSegment>.Enumerator entranceEnumerator =
//                entrancesToApply.GetEnumerator();

//            while (entranceEnumerator.MoveNext())
//            {
//                BridgeSegment entrance = entranceEnumerator.Current;

//                if (entrance == null)
//                {
//                    continue;
//                }

//                if (entrance.HasAnyConfiguredLanes())
//                {
//                    continue;
//                }

//                entrance.SetLaneLayoutAndPropagate(
//                    0,
//                    roadTwoWay.SomeOption()
//                );
//            }

//            m_pendingSegments.Clear();
//        }
//        [GlobalDependency(RegistrationMode.AsEverything, false, false)]
//        public sealed class MorRoadsPathCostTuner
//        {
//            public MorRoadsPathCostTuner()
//            {
//                TrySetRoadDistanceMultiplier(0.00f);
//            }

//            private static void TrySetRoadDistanceMultiplier(float multiplier)
//            {
//                try
//                {
//                    Type vehiclePathFinderType = Type.GetType(
//                        "Mafi.Core.PathFinding.VehiclePathFinder, Mafi.Core"
//                    );

//                    if (vehiclePathFinderType == null)
//                    {
//                        Log.Warning("Mor Roads: Could not find Mafi.Core.PathFinding.VehiclePathFinder.");
//                        return;
//                    }

//                    FieldInfo field = vehiclePathFinderType.GetField(
//                        "ROAD_DISTANCE_MULT",
//                        BindingFlags.Public |
//                        BindingFlags.NonPublic |
//                        BindingFlags.Static
//                    );

//                    if (field == null)
//                    {
//                        Log.Warning("Mor Roads: Could not find ROAD_DISTANCE_MULT field.");
//                        return;
//                    }

//                    field.SetValue(
//                        null,
//                        Fix32.FromFloat(multiplier)
//                    );

//                    Log.Info("Mor Roads: ROAD_DISTANCE_MULT set to " + multiplier);
//                }
//                catch (Exception ex)
//                {
//                    Log.Warning("Mor Roads: Failed to set road distance multiplier: " + ex);
//                }
//            }
//        }
//    }
//}
