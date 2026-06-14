using Mafi;
using Mafi.Base;
using Mafi.Base.Prototypes.Bridges;
using Mafi.Base.Prototypes.Trains;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core;
using Mafi.Core.Bridges;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Animations;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Factory.Transports;
using Mafi.Core.Mods;
using Mafi.Core.Prototypes;
using Mafi.Core.Roads;
using Mafi.Core.Trains;
using Mafi.Curves;
using Mafi.Localization;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Reflection;
using static BetterLife_RoadsAndSigns.ceRoadEntity;
//using static BetterLife.Prototypes.blRoadEntity;
//using UnityEditor;
//using UnityEngine;
namespace BetterLife_RoadsAndSigns
{
    internal class IndustryRoads : IModData
    {
        public static EntityCostsTpl.Builder Build => new EntityCostsTpl.Builder();



        roadsUtil.mLaneData[] bidirLargeStraightLane = new roadsUtil.mLaneData[]
        {
            // lane 1 left
            new roadsUtil.mLaneData(
                // start and end position of the lane
                vLaneTrajectory: CreateCurve((-10,-2),(-5,-2),(5,-2),(11,-2)),
                vTerrainTiles: new roadsUtil.terrainGraph[]
                {
                    new roadsUtil.terrainGraph(0, new RelTile2f(-2,2), true)
                },
                // as ramp ill define it the start as terrain connection and the end as elevated.
                vlanetype1: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                vlanetype2: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                vHeightCurve: CreateCurve((0,0), (25,0), (75,0), (100,0))
                ),
            // lane 2 right
            new roadsUtil.mLaneData(
                // start and end position of the lane
                vLaneTrajectory: CreateCurve((11,2),(5,2),(-5,2),(-10,2)),
                vTerrainTiles: new roadsUtil.terrainGraph[]
                {
                    new roadsUtil.terrainGraph(1, new RelTile2f(-2,4), false)
                },
                vlanetype1: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                vlanetype2: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                vHeightCurve: CreateCurve((100,0), (75,0), (25,0), (0,0))
                )
        };

        public void RegisterData(ProtoRegistrator registrator)
        {
            EntityCostsTpl roadCosts1 = BLCosts.Roads.Industrial;
            ImmutableArray<AnimationParams> noLoop = ImmutableArray.Create(new AnimationParams[]
            {
                AnimationParams.RepeatAutoTimes(Duration.FromYears(1))
            });

            // Industrial Roads

            // Set 1
            //blRoadEntranceEntityProto onewayEntrance = CreateRoadEntrance(registrator, BetterLIDs.dPath.IndustrialRoads.onewayEntrance, "Entrance", btLayouts.Layouts.onewayEntrance2, roadCosts1,
            //    BetterLIDs.dPath.RoadEntities.onewayEntrance.asset, BetterLIDs.dPath.RoadEntities.onewayEntrance.icon, BetterLIDs.ToolBars.RoadsIndustrial, 0, 0, 0, false, btLayouts.RoadLanes.onewayEntrance);

            //blRoadEntranceEntityProto onewayExit = CreateRoadEntrance(registrator, BetterLIDs.dPath.IndustrialRoads.onewayExit, "Exit", btLayouts.Layouts.onewayExit2, roadCosts1,
            //    BetterLIDs.dPath.RoadEntities.onewayExit.asset, BetterLIDs.dPath.RoadEntities.onewayExit.icon, BetterLIDs.ToolBars.RoadsIndustrial, 0, 0, 0, false, btLayouts.RoadLanes.onewayExit);

            //ceRoadProto onewayStraight = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.onewayStraight, "Straight", btLayouts.Layouts.onewayStraight2, roadCosts1,
            //    BetterLIDs.dPath.RoadEntities.onewayStraight.asset, BetterLIDs.dPath.RoadEntities.onewayStraight.icon, BetterLIDs.ToolBars.RoadsIndustrial, 0, 0, 0, noLoop);
            //ceRoadProto onewayStraightSmall = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.onewayStraightSmall, "Straight Small", btLayouts.Layouts.onewayStraightSmall, roadCosts1,
            //    BetterLIDs.dPath.RoadEntities.onewayStraightSmall.asset, BetterLIDs.dPath.RoadEntities.onewayStraightSmall.icon, BetterLIDs.ToolBars.RoadsIndustrial, 0, 0, 0, noLoop);

            //ceRoadProto onewayCorner = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.onewayCorner, "Corner", btLayouts.Layouts.onewayCorner, roadCosts1,
            //    BetterLIDs.dPath.RoadEntities.onewayCorner.asset, BetterLIDs.dPath.RoadEntities.onewayCorner.icon, BetterLIDs.ToolBars.RoadsIndustrial, 0, 0, 0, noLoop);

            //ceRoadProto onewayCross = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.onewayCross, "Cross", btLayouts.Layouts.onewayCross, roadCosts1,
            //    BetterLIDs.dPath.RoadEntities.onewayCross.asset, BetterLIDs.dPath.RoadEntities.onewayCross.icon, BetterLIDs.ToolBars.RoadsIndustrial, 0, 0, 0, noLoop);

            //ceRoadProto onewayTee = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.onewayTSection, "Tee", btLayouts.Layouts.onewayTee, roadCosts1,
            //    BetterLIDs.dPath.RoadEntities.onewayTSection.asset, BetterLIDs.dPath.RoadEntities.onewayTSection.icon, BetterLIDs.ToolBars.RoadsIndustrial, 0, 0, 0, noLoop);

            //ceRoadProto onewayLoadUnload = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.onewayLoadUnload, "Industrial Zone", btLayouts.Layouts.onewayStraight2, roadCosts1,
            //    BetterLIDs.dPath.RoadEntities.onewayLoadUnload.asset, BetterLIDs.dPath.RoadEntities.onewayLoadUnload.icon, BetterLIDs.ToolBars.RoadsIndustrial, 0, 0, 0, noLoop);

            //ceRoadProto onewaySlope1 = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.onewaySlope1, "Slope", btLayouts.Layouts.onewaySlope1, roadCosts1,
            //    BetterLIDs.dPath.RoadEntities.onewaySlope1.asset, BetterLIDs.dPath.RoadEntities.onewayStraightSmall.icon, BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, noLoop);

            //ceRoadProto onewaySlope1fake = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.onewaySlope1fake, "Slope fake", btLayouts.Layouts.onewaySlope1fake, roadCosts1,
            //    BetterLIDs.dPath.RoadEntities.onewaySlope1.asset, BetterLIDs.dPath.RoadEntities.onewayStraightSmall.icon, BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, noLoop);
             
            blRoadEntranceEntityProto onewayEntrance = CreateRoadEntrance(registrator, BetterLIDs.dPath.IndustrialRoads.onewayEntrance, "Entrance", btLayouts.Layouts.onewayEntrance, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayEntrance.asset, BetterLIDs.dPath.RoadEntities.onewayEntrance.icon, BetterLIDs.ToolBars.RoadsIndustrial, 0, 0, 0, false, btLayouts.RoadLanes.onewayEntrance);
             
            blRoadEntranceEntityProto onewayExit = CreateRoadEntrance(registrator, BetterLIDs.dPath.IndustrialRoads.onewayExit, "Exit", btLayouts.Layouts.onewayExit, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayExit.asset, BetterLIDs.dPath.RoadEntities.onewayExit.icon, BetterLIDs.ToolBars.RoadsIndustrial, 0, 0, 0, false, btLayouts.RoadLanes.onewayExit);
             
            ceRoadProto onewayStraight = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.onewayStraight, "Straight", btLayouts.Layouts.onewayStraight, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayStraight.asset, BetterLIDs.dPath.RoadEntities.onewayStraight.icon, BetterLIDs.ToolBars.RoadsIndustrial, 0, 0, 0, noLoop);
            ceRoadProto onewayStraightSmall = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.onewayStraightSmall, "Straight Small", btLayouts.Layouts.onewayStraightSmall, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayStraightSmall.asset, BetterLIDs.dPath.RoadEntities.onewayStraightSmall.icon, BetterLIDs.ToolBars.RoadsIndustrial, 0, 0, 0, noLoop);
               
            ceRoadProto onewayCorner = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.onewayCorner, "Corner", btLayouts.Layouts.onewayCorner, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayCorner.asset, BetterLIDs.dPath.RoadEntities.onewayCorner.icon, BetterLIDs.ToolBars.RoadsIndustrial, 0, 0, 0, noLoop);
             
            ceRoadProto onewayCross = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.onewayCross, "Cross", btLayouts.Layouts.onewayCross, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayCross.asset, BetterLIDs.dPath.RoadEntities.onewayCross.icon, BetterLIDs.ToolBars.RoadsIndustrial, 0, 0, 0, noLoop);
              
            ceRoadProto onewayTee = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.onewayTSection, "Tee", btLayouts.Layouts.onewayTee, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayTSection.asset, BetterLIDs.dPath.RoadEntities.onewayTSection.icon, BetterLIDs.ToolBars.RoadsIndustrial, 0, 0, 0, noLoop);
              
            ceRoadProto onewayLoadUnload = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.onewayLoadUnload, "Industrial Zone", btLayouts.Layouts.onewayCross, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayLoadUnload.asset, BetterLIDs.dPath.RoadEntities.onewayLoadUnload.icon, BetterLIDs.ToolBars.RoadsIndustrial, 0, 0, 0, noLoop);
             
            ceRoadProto onewaySlope1 = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.onewaySlope1, "Slope", btLayouts.Layouts.onewaySlope1, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewaySlope1.asset, BetterLIDs.dPath.RoadEntities.onewayStraightSmall.icon, BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, noLoop);

            ceRoadProto onewaySlope1fake = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.onewaySlope1fake, "Slope fake", btLayouts.Layouts.onewaySlope1fake, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewaySlope1.asset, BetterLIDs.dPath.RoadEntities.onewayStraightSmall.icon, BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, noLoop);




            //ceRoadProto onewayBridge1 = CreateProto(registrator, BetterLIDs.IndustrialRoads.onewayBridge1, "One Way Bridge 1", btLayouts.Layouts.onewayBridge1, roadCosts1,
            //    BetterLIDs.RoadEntities.onewayBridge.asset, BetterLIDs.RoadEntities.onewayBridge.icon, BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, noLoop);

            // One Way Train Bridge Segments

            blRoadEntranceEntityProto onewayEntrance2 = CreateRoadEntrance(registrator, BetterLIDs.dPath.IndustrialRoads.onewayEntrance2, "Entrance", btLayouts.Layouts.onewayEntrance, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayEntrance2.asset, BetterLIDs.dPath.RoadEntities.onewayEntrance2.icon, BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, false, btLayouts.RoadLanes.onewayEntrance);

            blRoadEntranceEntityProto onewayExit2 = CreateRoadEntrance(registrator, BetterLIDs.dPath.IndustrialRoads.onewayExit2, "Exit", btLayouts.Layouts.onewayExit, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayExit2.asset, BetterLIDs.dPath.RoadEntities.onewayExit2.icon, BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, false, btLayouts.RoadLanes.onewayExit);

            ceRoadProto onewayStraight2 = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.onewayStraight2, "Straight", btLayouts.Layouts.onewayStraight, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayStraight2.asset, BetterLIDs.dPath.RoadEntities.onewayStraight2.icon, BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, noLoop);
            ceRoadProto onewayStraightSmall2 = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.onewayStraightSmall2, "Straight Small", btLayouts.Layouts.onewayStraightSmall, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayStraightSmall2.asset, BetterLIDs.dPath.RoadEntities.onewayStraightSmall2.icon, BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, noLoop);

            ceRoadProto onewayCorner2 = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.onewayCorner2, "Corner", btLayouts.Layouts.onewayCorner, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayCorner2.asset, BetterLIDs.dPath.RoadEntities.onewayCorner2.icon, BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, noLoop);

            ceRoadProto onewayCross2 = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.onewayCross2, "Cross", btLayouts.Layouts.onewayCross, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayCross2.asset, BetterLIDs.dPath.RoadEntities.onewayCross2.icon, BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, noLoop);

            ceRoadProto onewayTee2 = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.onewayTSection2, "Tee", btLayouts.Layouts.onewayTee, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayTSection2.asset, BetterLIDs.dPath.RoadEntities.onewayTSection2.icon, BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, noLoop);

            ceRoadProto onewayLoadUnload2 = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.onewayLoadUnload2, "Industrial Zone", btLayouts.Layouts.onewayCross, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayLoadUnload2.asset, BetterLIDs.dPath.RoadEntities.onewayLoadUnload2.icon, BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, noLoop);


            blRoadEntranceEntityProto onewayEntranceExit = CreateRoadEntrance(registrator, BetterLIDs.dPath.IndustrialRoads.onewayEntranceExit, "Entrance/Exit", btLayouts.Layouts.onewayEntranceExit, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayEntranceExit.asset, BetterLIDs.dPath.RoadEntities.onewayEntranceExit.icon, BetterLIDs.ToolBars.RoadsIndustrial, 0, 0, 0, false,
                btLayouts.RoadLanes.onewayEntranceExit);
            //blRoadEntranceEntityProto onewayEntranceExit = CreateRoadEntrance(registrator, BetterLIDs.dPath.IndustrialRoads.onewayEntranceExit, "Entrance/Exit", btLayouts.Layouts.onewayEntranceExit, roadCosts1,
            //    BetterLIDs.dPath.RoadEntities.onewayEntranceExit.asset, BetterLIDs.dPath.RoadEntities.onewayEntranceExit.icon, BetterLIDs.ToolBars.RoadsIndustrial, 0, 0, 0, false,
            //    btLayouts.RoadLanes.onewayEntranceExit);


            blRoadEntranceEntityProto onewayEntranceExit2 = CreateRoadEntrance(registrator, BetterLIDs.dPath.IndustrialRoads.onewayEntranceExit2, "Entrance/Exit", btLayouts.Layouts.onewayEntranceExit, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayEntranceExit2.asset, BetterLIDs.dPath.RoadEntities.onewayEntranceExit2.icon, BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, false,
                btLayouts.RoadLanes.onewayEntranceExit);


            blRoadEntranceEntityProto onewayTrainBridgeEntrance1 = CreateRoadEntrance(registrator, BetterLIDs.dPath.IndustrialRoads.oneWayTrainBridgeEntrance1, "Entrance",
                btLayouts.Layouts.onewayTrainBridgeEntrance1, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayTrainBridgeEntrance1.asset, BetterLIDs.dPath.RoadEntities.onewayTrainBridgeEntrance1.icon, BetterLIDs.ToolBars.RoadsBridgeSegments, 0, 0, 0, false,
                btLayouts.RoadLanes.onewayTrainBridgeEntrance1);

            ceRoadProto onewayTrainStraight = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.oneWayTrainBridgeStraight1, "Straight",
                btLayouts.Layouts.onewayTrainBridgeStraight1, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayTrainBridgeStraight1.asset, BetterLIDs.dPath.RoadEntities.onewayTrainBridgeStraight1.icon, BetterLIDs.ToolBars.RoadsBridgeSegments, 0, 0, 0, noLoop);

            ceRoadProto onewayTrainStraight2x = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.oneWayTrainBridgeStraight2x, "Straight 2x",
                btLayouts.Layouts.onewayTrainBridgeStraight2x, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayTrainBridgeStraight2x.asset, BetterLIDs.dPath.RoadEntities.onewayTrainBridgeStraight2x.icon, BetterLIDs.ToolBars.RoadsBridgeSegments, 0, 0, 0, noLoop);

            ceRoadProto onewayTrainCorner = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.oneWayTrainBridgeCorner1, "Corner",
                btLayouts.Layouts.onewayTrainBridgeCorner1, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayTrainBridgeCorner1.asset, BetterLIDs.dPath.RoadEntities.onewayTrainBridgeCorner1.icon, BetterLIDs.ToolBars.RoadsBridgeSegments, 0, 0, 0, noLoop);

            blRoadEntranceEntityProto onewayTrainBridgeExit1 = CreateRoadEntrance(registrator, BetterLIDs.dPath.IndustrialRoads.oneWayTrainBridgeExit1, "Exit",
                btLayouts.Layouts.onewayTrainBridgeExit1, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayTrainBridgeExit1.asset, BetterLIDs.dPath.RoadEntities.onewayTrainBridgeExit1.icon, BetterLIDs.ToolBars.RoadsBridgeSegments, 0, 0, 0, false,
                btLayouts.RoadLanes.onewayTrainBridgeExit1);


            blRoadEntranceEntityProto onewayTrainBridgeEntrance12 = CreateRoadEntrance(registrator, BetterLIDs.dPath.IndustrialRoads.oneWayTrainBridgeEntrance12, "Entrance Set 2",
                btLayouts.Layouts.onewayTrainBridgeEntrance1, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayTrainBridgeEntrance12.asset, BetterLIDs.dPath.RoadEntities.onewayTrainBridgeEntrance1.icon, BetterLIDs.ToolBars.RoadsBridgeSegments, 0, 0, 0, false,
                btLayouts.RoadLanes.onewayTrainBridgeEntrance1);

            ceRoadProto onewayTrainStraight2 = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.oneWayTrainBridgeStraight12, "Straight Set 2",
                btLayouts.Layouts.onewayTrainBridgeStraight1, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayTrainBridgeStraight12.asset, BetterLIDs.dPath.RoadEntities.onewayTrainBridgeStraight12.icon, BetterLIDs.ToolBars.RoadsBridgeSegments, 0, 0, 0, noLoop);

            ceRoadProto onewayTrainStraight2x2 = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.oneWayTrainBridgeStraight2x2, "Straight 2x Set 2",
                btLayouts.Layouts.onewayTrainBridgeStraight2x, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayTrainBridgeStraight2x2.asset, BetterLIDs.dPath.RoadEntities.onewayTrainBridgeStraight2x2.icon, BetterLIDs.ToolBars.RoadsBridgeSegments, 0, 0, 0, noLoop);

            ceRoadProto onewayTrainCorner2 = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.oneWayTrainBridgeCorner12, "Corner Set 2",
                btLayouts.Layouts.onewayTrainBridgeCorner1, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayTrainBridgeCorner12.asset, BetterLIDs.dPath.RoadEntities.onewayTrainBridgeCorner12.icon, BetterLIDs.ToolBars.RoadsBridgeSegments, 0, 0, 0, noLoop);

            blRoadEntranceEntityProto onewayTrainBridgeExit12 = CreateRoadEntrance(registrator, BetterLIDs.dPath.IndustrialRoads.oneWayTrainBridgeExit12, "Exit Set 2",
                btLayouts.Layouts.onewayTrainBridgeExit1, roadCosts1,
                BetterLIDs.dPath.RoadEntities.onewayTrainBridgeExit12.asset, BetterLIDs.dPath.RoadEntities.onewayTrainBridgeExit12.icon, BetterLIDs.ToolBars.RoadsBridgeSegments, 0, 0, 0, false,
                btLayouts.RoadLanes.onewayTrainBridgeExit1);

            blRoadEntranceEntityProto rampStart1 = CreateRoadEntrance(registrator, BetterLIDs.dPath.IndustrialRoads.rampStart1, "Mini Ramp",
                btLayouts.Layouts.rampStart1, roadCosts1,
                BetterLIDs.dPath.RoadEntities.rampStart1.asset, BetterLIDs.dPath.RoadEntities.rampStart1.icon, BetterLIDs.ToolBars.RoadsBridgeSegments, 0, 0, 0, false,
                btLayouts.RoadLanes.rampStart1);

            //BridgeProto rampStart1 = bgRoadProtos.CreateStraightProto(registrator,BetterLIDs.dPath.IndustrialRoads.rampStart1,
            //        Proto.CreateStr(BetterLIDs.dPath.IndustrialRoads.rampStart1, "Mini Ramp", "Mini Bridge Ramp"),
            //        BetterLIDs.dPath.IndustrialRoads.rampStart1,
            //        6, new RelTile1f(5.ToFix32()), true, true, BetterLIDs.dPath.RoadEntities.rampStart1.asset, BetterLIDs.dPath.RoadEntities.rampStart1.icon);


            ceRoadProto rampMiddle1 = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.rampMiddle1, "Mini Bridge",
                btLayouts.Layouts.rampMiddle1, roadCosts1,
                BetterLIDs.dPath.RoadEntities.rampMiddle1.asset, BetterLIDs.dPath.RoadEntities.rampMiddle1.icon, BetterLIDs.ToolBars.RoadsBridgeSegments, 0, 0, 0, noLoop);



            //BridgeProto testRoad = bgRoadProtos.CreateStraightProto(registrator,
            //        BetterLIDs.dPath.RoadEntities.road1,
            //        Proto.CreateStr(BetterLIDs.dPath.RoadEntities.road1, "Test Road", "Test Bridge Road"),
            //        new StaticEntityProto.ID("troad1"),
            //        4, new RelTile1f(5.ToFix32()), true, true, BetterLIDs.dPath.RoadEntities.onewayStraight2.asset, BetterLIDs.dPath.RoadEntities.onewayStraight.icon);
            //registrator.PrototypesDb.Add(testRoad);


            //ceRoadProto industrial_light = CreateProto(registrator, BetterLIDs.dPath.IndustrialRoads.indLight1, "Industrial Light 1", btLayouts.Layouts.indLight1, BLCosts.Buildings.indLight1,
            //    BetterLIDs.dPath.RoadEntities.ind_light1.asset, BetterLIDs.dPath.RoadEntities.ind_light1.icon, BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, noLoop
            //    );
            // Road Utilities 

            //blRoadEntranceEntityProto roadWayPoint = CreateRoadEntrance(registrator, BetterLIDs.IndustrialRoads.roadWayPoint, "Terrain WayPoint",
            //    btLayouts.Layouts.roadWayPoint, roadCosts1,
            //    BetterLIDs.RoadEntities.roadTODO.asset, BetterLIDs.RoadEntities.roadTODO.icon, BetterLIDs.ToolBars.RoadsParent, 0, 0, 0, false,
            //    btLayouts.RoadLanes.roadWayPoint);


            //indEntrance.SetNextTierIndirect(indOneBlock);
            //indOneBlock.SetNextTierIndirect(indStraight);
            //indStraight.SetNextTierIndirect(indStraightLarge);
            //indStraightLarge.SetNextTierIndirect(indCorner);
            //indCorner.SetNextTierIndirect(indTSection);
            //indTSection.SetNextTierIndirect(indCross);


            // Bidirectional roads
            //registrator.PrototypesDb.Add(bidirEntrance);
            //registrator.PrototypesDb.Add(bidirStraight);
            //registrator.PrototypesDb.Add(bidirCorner);
            //registrator.PrototypesDb.Add(bidirTSection);
            //registrator.PrototypesDb.Add(bidirCross);
            //registrator.PrototypesDb.Add(bidirBridge1);

            // Oneway roads
            registrator.PrototypesDb.Add(onewayEntrance);
            registrator.PrototypesDb.Add(onewayStraight);
            registrator.PrototypesDb.Add(onewayStraightSmall);
            registrator.PrototypesDb.Add(onewayCorner);
            registrator.PrototypesDb.Add(onewayCross);
            registrator.PrototypesDb.Add(onewayTee);
            registrator.PrototypesDb.Add(onewayExit);
            registrator.PrototypesDb.Add(onewayEntranceExit);
            registrator.PrototypesDb.Add(onewayLoadUnload);
            //registrator.PrototypesDb.Add(onewaySlope1);
            //registrator.PrototypesDb.Add(onewaySlope1fake);

            registrator.PrototypesDb.Add(onewayEntrance2);
            registrator.PrototypesDb.Add(onewayStraight2);
            registrator.PrototypesDb.Add(onewayStraightSmall2);
            registrator.PrototypesDb.Add(onewayCorner2);
            registrator.PrototypesDb.Add(onewayCross2);
            registrator.PrototypesDb.Add(onewayTee2);
            registrator.PrototypesDb.Add(onewayExit2);
            registrator.PrototypesDb.Add(onewayEntranceExit2);
            registrator.PrototypesDb.Add(onewayLoadUnload2);
            //registrator.PrototypesDb.Add(onewaySlope12);
            //registrator.PrototypesDb.Add(onewaySlope1fake2);

            // Trainbridges 

            registrator.PrototypesDb.Add(onewayTrainBridgeEntrance1);
            registrator.PrototypesDb.Add(onewayTrainStraight);
            registrator.PrototypesDb.Add(onewayTrainStraight2x);
            registrator.PrototypesDb.Add(onewayTrainCorner);
            registrator.PrototypesDb.Add(onewayTrainBridgeExit1);

            registrator.PrototypesDb.Add(onewayTrainBridgeEntrance12);
            registrator.PrototypesDb.Add(onewayTrainStraight2);
            registrator.PrototypesDb.Add(onewayTrainStraight2x2);
            registrator.PrototypesDb.Add(onewayTrainCorner2);
            registrator.PrototypesDb.Add(onewayTrainBridgeExit12);


            registrator.PrototypesDb.Add(rampStart1);
            registrator.PrototypesDb.Add(rampMiddle1);

            // Road Utilities

            //registrator.PrototypesDb.Add(roadWayPoint);
            //registrator.PrototypesDb.Add(industrial_light);

            ProtosDb protosDb = registrator.PrototypesDb;

            EntityCostsTpl costs = Build.CP(5).MaintenanceT1(0).Priority(8).Workers(4);

            EntityCostsTpl costsFuelStation = Build.CP(5).MaintenanceT1(5).Priority(8).Workers(4);

            registrator.FuelStationProtoBuilder
                .Start("Better Fuel Station", BetterLIDs.dPath.Buildings.FuelStation1)
                .Description("Fuel Station T1")
                .SetCost(costsFuelStation)
                .SetCapacity(500)
                .SetFuelProto(Ids.Products.Diesel)
                .SetMaxTransferQuantityPerVehicle(80)
                .SetCategories(Ids.ToolbarCategories.Vehicles)

                .SetLayout
                    (
                    "   (1)(1)(1)(1)(1)",
                    "@A>(1)(1)(1)(1)(1)",
                    "   (1)(1)(1)(1)(1)",
                    "   (1)(1)(1)(1)(1)",
                    "   (1)(1)(1)(1)(1)",
                    "   (1)(1)(1)(1)(1)",
                    "   (1)(1)(1)(1)(1)",
                    "   (1)(1)(1)(1)(1)"
                    )
                .SetPrefabPath("Assets/BetterLife/Buildings/FuelStation1/FuelStation1.prefab")
                .SetCustomIconPath("Assets/BetterLife/Icons/Buildings/fuelstation1.png")

                .BuildAndAdd()
                .AddParam(new DrawArrowWileBuildingProtoParam(4f));

            Log.Info($"BETTERLIFES: Custom Fuelstation added...");


        }
        //  "xXXxXXxXXxXXxXXxXX"
        //  "1                 "
        //  "2                 "
        //  "3                 "
        //  "4                 "
        //  "5                 "
        //  "xXXxXXxXXxXXxXXxXX"


        public static CubicBezierCurve2f CreateCurve((double, double) start, (double, double) c1, (double, double) c2, (double, double) end)
        {
            return new CubicBezierCurve2f(ImmutableArray.Create(new Vector2f(start.Item1.ToFix32(), start.Item2.ToFix32()), new Vector2f(c1.Item1.ToFix32(), c1.Item2.ToFix32()), new Vector2f(c2.Item1.ToFix32(), c2.Item2.ToFix32()), new Vector2f(end.Item1.ToFix32(), end.Item2.ToFix32())));
        }


        // Helper for the new "m0" style tokens (more flexible)
        private static CustomLayoutToken CreateMToken(string suffix, Func<EntityLayoutParams, int, LayoutTokenSpec> specFactory)
        {
            return new CustomLayoutToken($"m0{suffix}", specFactory);
        }

        public blRoadEntranceEntityProto CreateRoadEntrance(ProtoRegistrator registrator, StaticEntityProto.ID id, string coment, string[] entLayout, EntityCostsTpl entCosts, string assetPath,
                                 string assetIcon, Proto.ID toolbarCategory, int assetXoffset, int assetYoffest, int assetZoffset,
                                 bool noPlayer, roadsUtil.mLaneData[] thisLane)
        {
            var customTokens = new[]
            {
              // === Original .0 series ===
            CreateHeightToken("A", 0, 0.125.ToFix32()),
            CreateHeightToken("B", 0, 0.14285.ToFix32()),
            CreateHeightToken("C", 0, 0.285.ToFix32()),
            CreateHeightToken("D", 2, 0.125.ToFix32()),
            CreateHeightToken("E", 0, 0.333.ToFix32()),
            CreateHeightToken("F", 4, 0.125.ToFix32()),
            CreateHeightToken("G", 5, 0.125.ToFix32()),

            //CreateHeightToken("a", 0, 0.125.ToFix32()),
            //CreateHeightToken("b", 1, 0.125.ToFix32()),
            //CreateHeightToken("c", 2, 0.125.ToFix32()),
            //CreateHeightToken("d", 3, 0.125.ToFix32()),
            //CreateHeightToken("e", 4, 0.125.ToFix32()),
            //CreateHeightToken("f", 5, 0.125.ToFix32()),
            //CreateHeightToken("g", 6, 0.125.ToFix32()),


            // === New m0 series ===
            new CustomLayoutToken("m0A", (p, h) => new LayoutTokenSpec(
                heightFrom: 0,
                heightToExcl: h,
                LayoutTileConstraint.None,
                maxTerrainHeight: h - 1
            )),

            new CustomLayoutToken("m0B", (p, h) => new LayoutTokenSpec(
                heightFrom: 0,
                heightToExcl: h,
                LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse,
                minTerrainHeight: -2,
                maxTerrainHeight: h-1,
                vehicleHeight: h-1
            )),

            // === Special _0= token ===
            new CustomLayoutToken("_0=", (p, h) => new LayoutTokenSpec(
                heightFrom: h - 1,
                heightToExcl: h,
                maxTerrainHeight: h - 1,
                vehicleHeight: (Fix32)(h - 1)
            )),

            new CustomLayoutToken("xXx", (p, h) => new LayoutTokenSpec(
                heightFrom: -2,
                heightToExcl: 2,
                maxTerrainHeight: 2,
                vehicleHeight: EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value
            )),
            new CustomLayoutToken("x0x", (p, h) => new LayoutTokenSpec(
                heightFrom: -2,
                heightToExcl: h-1,
                maxTerrainHeight: h-1,
                vehicleHeight: EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value
            )),

    };
            EntityLayoutParams layoutParams = new EntityLayoutParams(null, customTokens, portsCanOnlyConnectToTransports: false, null, null, null, null, null, null, default, true);
            EntityLayout layout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams, entLayout);


            ImmutableArray<RoadLaneSpec> lanespecs = ImmutableArray<RoadLaneSpec>.Empty;
            ImmutableArray<RoadLaneMetadata> lanesData = ImmutableArray<RoadLaneMetadata>.Empty;
            ImmutableArray<RoadLaneTrajectory> trajData = ImmutableArray<RoadLaneTrajectory>.Empty;
            ImmutableArray<LaneTerrainConnectionSpec> terrainConnections = ImmutableArray<LaneTerrainConnectionSpec>.Empty;
            bool result = false;

            roadsUtil.CreateLanes(thisLane, out lanespecs, out trajData, out lanesData, out terrainConnections, out result);

            StaticEntityProto.ID roadId = id;
            Proto.Str strings = Proto.CreateStr(roadId, coment, "BL Roads");
            EntityCosts none = entCosts.MapToEntityCosts(registrator);
            ImmutableArray<ToolbarEntryData> categories = ImmutableArray<ToolbarEntryData>.Empty;
            if (toolbarCategory != BetterLIDs.ToolBars.HiddenProto)
            {
                categories = ImmutableArray.Create(registrator.GetCategory(toolbarCategory));
            }
             
            blRoadEntranceEntityProto.Gfx graphics = new blRoadEntranceEntityProto.Gfx(assetPath, categories, new RelTile3f(assetXoffset, assetYoffest, assetZoffset), 45.Degrees());

            typeof(LayoutEntityProto.Gfx).GetProperty(nameof(LayoutEntityProto.Gfx.IconPath), BindingFlags.Public | BindingFlags.Instance).SetValue(graphics, assetIcon);
            typeof(LayoutEntityProto.Gfx).GetField(nameof(LayoutEntityProto.Gfx.IconIsCustom), BindingFlags.Public | BindingFlags.Instance).SetValue(graphics, true);

            blRoadEntranceEntityProto roadEntranceProto = new blRoadEntranceEntityProto(roadId, strings, layout, none, 0.5.Tiles(), lanespecs, lanesData, trajData, terrainConnections, graphics, true, false, false);
            roadEntranceProto.AddParam(new DrawArrowWileBuildingProtoParam(2f));


            return roadEntranceProto;

        }
        public blRoadEntityProto CreateRoadProto(ProtoRegistrator registrator, StaticEntityProto.ID id, string coment, string[] entLayout, EntityCostsTpl entCosts, string assetPath,
                                 string assetIcon, Proto.ID toolbarCategory, int assetXoffset, int assetYoffest, int assetZoffset,
                                 bool noPlayer, roadsUtil.mLaneData[] thisLane)
        {
            CustomLayoutToken[] customTokens = new CustomLayoutToken[]
            {
                new CustomLayoutToken("=0=", (EntityLayoutParams p, int h) => new LayoutTokenSpec(0, h, LayoutTileConstraint.None, 0, null, null, h - 1, null, null, false, false, 0)),
                new CustomLayoutToken(":0:", (EntityLayoutParams p, int h) => new LayoutTokenSpec(h - 1, h, LayoutTileConstraint.None | LayoutTileConstraint.DisableTerrainPhysics, null, null, null, (h + 1).ToFix32(),null,p.HardenedFloorSurfaceId)),
                new CustomLayoutToken("<0a", (EntityLayoutParams p, int h) => new LayoutTokenSpec(h - 1, h, LayoutTileConstraint.None | LayoutTileConstraint.DisableTerrainPhysics, null, null, null, 0.0.ToFix32(),null,p.HardenedFloorSurfaceId)),
                new CustomLayoutToken("<0b", (EntityLayoutParams p, int h) => new LayoutTokenSpec(h - 1, h, LayoutTileConstraint.None | LayoutTileConstraint.DisableTerrainPhysics, null, null, null, 0.250.ToFix32(), null, null)),
                new CustomLayoutToken("<0c", (EntityLayoutParams p, int h) => new LayoutTokenSpec(h - 1, h, LayoutTileConstraint.None | LayoutTileConstraint.DisableTerrainPhysics, null, null, null, 0.500.ToFix32(), null, null)),
                new CustomLayoutToken("<0d", (EntityLayoutParams p, int h) => new LayoutTokenSpec(h - 1, h, LayoutTileConstraint.None | LayoutTileConstraint.DisableTerrainPhysics, null, null, null, 0.750.ToFix32(), null, null)),
                new CustomLayoutToken("<0e", (EntityLayoutParams p, int h) => new LayoutTokenSpec(h - 1, h, LayoutTileConstraint.None | LayoutTileConstraint.DisableTerrainPhysics, null, null, null, 1.000.ToFix32(), null, null)),
                new CustomLayoutToken("<0f", (EntityLayoutParams p, int h) => new LayoutTokenSpec(h - 1, h, LayoutTileConstraint.None | LayoutTileConstraint.DisableTerrainPhysics, null, null, null, 1.250.ToFix32(), null, null)),
                new CustomLayoutToken("<0g", (EntityLayoutParams p, int h) => new LayoutTokenSpec(h - 1, h, LayoutTileConstraint.None | LayoutTileConstraint.DisableTerrainPhysics, null, null, null, 1.500.ToFix32(), null, null)),
                new CustomLayoutToken("<0h", (EntityLayoutParams p, int h) => new LayoutTokenSpec(h - 1, h, LayoutTileConstraint.None | LayoutTileConstraint.DisableTerrainPhysics, null, null, null, 1.750.ToFix32(), null, null)),
                new CustomLayoutToken("<0i", (EntityLayoutParams p, int h) => new LayoutTokenSpec(h - 1, h, LayoutTileConstraint.None | LayoutTileConstraint.DisableTerrainPhysics, null, null, null, 2.000.ToFix32(), null, null)),
                new CustomLayoutToken("<0j", (EntityLayoutParams p, int h) => new LayoutTokenSpec(h - 1, h, LayoutTileConstraint.None | LayoutTileConstraint.DisableTerrainPhysics, null, null, null, 2.250.ToFix32(), null, null)),
                new CustomLayoutToken("<0k", (EntityLayoutParams p, int h) => new LayoutTokenSpec(h - 1, h, LayoutTileConstraint.None | LayoutTileConstraint.DisableTerrainPhysics, null, null, null, 2.500.ToFix32(), null, null)),
                new CustomLayoutToken("<0l", (EntityLayoutParams p, int h) => new LayoutTokenSpec(h - 1, h, LayoutTileConstraint.None | LayoutTileConstraint.DisableTerrainPhysics, null, null, null, 2.750.ToFix32(), null, null)),
                new CustomLayoutToken("<0m", (EntityLayoutParams p, int h) => new LayoutTokenSpec(h - 1, h, LayoutTileConstraint.None | LayoutTileConstraint.DisableTerrainPhysics, null, null, null, 3.000.ToFix32(), null, null)),
                new CustomLayoutToken("h0.", (EntityLayoutParams p, int h) => new LayoutTokenSpec(h - 1, h, LayoutTileConstraint.None,null, null,h-1,h-1,null,null, false,false,0)),
                new CustomLayoutToken("m0A", (EntityLayoutParams p, int h) => new LayoutTokenSpec(0,h,LayoutTileConstraint.None,null,null,h-1,null,null,null,false,false,0)),
                new CustomLayoutToken("_0=", (EntityLayoutParams p, int h) => new LayoutTokenSpec(h-1,h,LayoutTileConstraint.None,null,null,h-1,h-1,null,null,false,false,0)),

            };
            //array[5] = new CustomLayoutToken("h0.", delegate (EntityLayoutParams p, int h)
            //{
            //    return new LayoutTokenSpec(h - 1, h, LayoutTileConstraint.None, null, null, h - 1, h - 1, null, null, false, false, 0);
            //});

            EntityLayoutParams layoutParams = new EntityLayoutParams(null, customTokens, portsCanOnlyConnectToTransports: false, IdsCore.TerrainTileSurfaces.DefaultConcrete, null, null, null, null, null, default);
            EntityLayout layout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams, entLayout);


            ImmutableArray<RoadLaneSpec> lanespecs = ImmutableArray<RoadLaneSpec>.Empty;
            ImmutableArray<RoadLaneMetadata> lanesData = ImmutableArray<RoadLaneMetadata>.Empty;
            ImmutableArray<RoadLaneTrajectory> trajData = ImmutableArray<RoadLaneTrajectory>.Empty;
            ImmutableArray<LaneTerrainConnectionSpec> terrainConnections = ImmutableArray<LaneTerrainConnectionSpec>.Empty;
            bool result = false;

            roadsUtil.CreateLanes(thisLane, out lanespecs, out trajData, out lanesData, out terrainConnections, out result);

            StaticEntityProto.ID roadId = id;
            Proto.Str strings = Proto.CreateStr(roadId, coment, "BL Roads");
            EntityCosts none = entCosts.MapToEntityCosts(registrator);
            ImmutableArray<ToolbarEntryData> categories = ImmutableArray<ToolbarEntryData>.Empty;
            if (toolbarCategory != BetterLIDs.ToolBars.HiddenProto)
            {
                categories = ImmutableArray.Create(registrator.GetCategory(toolbarCategory));
            }

            blRoadEntityProto.Gfx graphics = new blRoadEntityProto.Gfx(assetPath, categories, new RelTile3f(0, 0, 0), 45.Degrees());

            typeof(LayoutEntityProto.Gfx).GetProperty(nameof(LayoutEntityProto.Gfx.IconPath), BindingFlags.Public | BindingFlags.Instance).SetValue(graphics, assetIcon);
            typeof(LayoutEntityProto.Gfx).GetField(nameof(LayoutEntityProto.Gfx.IconIsCustom), BindingFlags.Public | BindingFlags.Instance).SetValue(graphics, true);

            blRoadEntityProto roadProto = new blRoadEntityProto(roadId, strings, layout, none, 3.5.Tiles(), lanespecs, lanesData, trajData, graphics, true, false, false);
            roadProto.AddParam(new DrawArrowWileBuildingProtoParam(2f));

            return roadProto;
        }
        //private static CustomLayoutToken CreateHeightToken(string suffix, Fix32 baseOffset, Fix32 heightOffset)
        //{
        //    return new CustomLayoutToken(
        //        $".0{suffix}",
        //        (p, h) =>
        //        {
        //            Fix32 rawVehicleHeight = baseOffset + (Fix32)(h - 1) * heightOffset;

        //            // === BOOST EARLY SEGMENTS ===
        //            Fix32 vehicleHeight = rawVehicleHeight;

        //            if (h <= 2)
        //                vehicleHeight = baseOffset + 0.1.ToFix32();           // minimum entry height

        //            return new LayoutTokenSpec(
        //                heightFrom: h - 1,
        //                heightToExcl: h,
        //                maxTerrainHeight: h,
        //                vehicleHeight: vehicleHeight
        //            );
        //        });
        //}
        private static CustomLayoutToken CreateHeightToken(string suffix, Fix32 baseOffset, Fix32 heightOffset)
        {
            return new CustomLayoutToken(
                $".0{suffix}",
                (p, h) =>

                new LayoutTokenSpec(
                    heightFrom: h - 12,
                    heightToExcl: h + 2 ,
                    minTerrainHeight: h - 12,
                    maxTerrainHeight: h + 1 ,
                    vehicleHeight: (baseOffset + (Fix32)(h - 1) * heightOffset) 
                //surfaceId: BetterLIDs.Surfaces.surface1n.Id
                ));
        }

        public ceRoadProto CreateProto(ProtoRegistrator registrato, StaticEntityProto.ID id, string coment, string[] el, EntityCostsTpl ecTpl, string asp, string ico, Proto.ID cat, Fix32 nX, Fix32 nY, Fix32 nZ, ImmutableArray<AnimationParams> ap)
        {
            //Predicate<LayoutTile> predicate = null;
            var customTokens = new[]
            {
              // === Original .0 series ===
            CreateHeightToken("A", 0, 0.125.ToFix32()),
            CreateHeightToken("B", 0, 0.14285.ToFix32()),
            CreateHeightToken("C", 0, 0.250.ToFix32()),
            CreateHeightToken("D", 2, 0.125.ToFix32()),
            CreateHeightToken("E", 4, 0.125.ToFix32()),

            // === New m0 series ===
            new CustomLayoutToken("m0A", (p, h) => new LayoutTokenSpec(
                heightFrom: 0,
                heightToExcl: h,
                surfaceId: BetterLIDs.Surfaces.surface1n.Id,
                maxTerrainHeight: h - 1
            )),

            new CustomLayoutToken("m0B", (p, h) => new LayoutTokenSpec(
                heightFrom: -2,
                heightToExcl: h,
                //surfaceId: BetterLIDs.Surfaces.surface1n.Id,
                minTerrainHeight: -25,
                maxTerrainHeight: h-1 ,
                vehicleHeight: h-1 
            )),

            // === Special _0= token ===
            new CustomLayoutToken("_0=", (p, h) => new LayoutTokenSpec(
                heightFrom: h - 1,
                heightToExcl: h ,
                maxTerrainHeight: h - 1,
                vehicleHeight: (Fix32)(h - 1)
            )),

            new CustomLayoutToken("xXx", (p, h) => new LayoutTokenSpec(
                heightFrom: -2,
                heightToExcl: h,
                maxTerrainHeight: h,
                vehicleHeight: EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value
//                surfaceId: BetterLIDs.Surfaces.surface1n.Id

            )),
            new CustomLayoutToken("x0x", (p, h) => new LayoutTokenSpec(
                heightFrom: -25,
                heightToExcl: h + 1 ,
                maxTerrainHeight: h - 1,
                vehicleHeight: EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value
            )),
    };
            EntityLayoutParams entityLayoutParams = new EntityLayoutParams(
                customPlacementRange: new ThicknessIRange(0, TransportPillarProto.MAX_PILLAR_HEIGHT.Value - 1),
                customTokens: customTokens,
                enforceEmptySurface: false

                );
            //EntityLayoutParams entityLayoutParams = new EntityLayoutParams(null, null, false, Ids.TerrainTileSurfaces.Metal1, null, null, null, null, default(Option<IEnumerable<KeyValuePair<char, int>>>), false);
            string[] initLayoutString = el;
            EntityLayout ltemp = registrato.LayoutParser.ParseLayoutOrThrow(entityLayoutParams, el);

            ImmutableArray<ToolbarEntryData> categories = ImmutableArray<ToolbarEntryData>.Empty;
            if (cat != BetterLIDs.ToolBars.HiddenProto)
            {
                categories = ImmutableArray.Create(registrato.GetCategory(cat));
            }
            else
            {
                categories = ImmutableArray<ToolbarEntryData>.Empty;
            }


            Proto.Str ps = Proto.CreateStr(id, coment);
            EntityCosts ec = ecTpl.MapToEntityCosts(registrato);
            LayoutEntityProto.Gfx lg = new LayoutEntityProto.Gfx(
                prefabPath: asp,
                prefabOrigin: new RelTile3f(nX, nY, nZ),
                customIconPath: ico,
                categories: categories



                );
            //LayoutEntityProto.Gfx lg = new LayoutEntityProto.Gfx(asp, default(RelTile3f), ico, default(ColorRgba), false, null, new ImmutableArray<ToolbarCategoryProto>?(registrato.GetCategoriesProtos(cat)), false, false, null, null, default(ImmutableArray<string>), int.MaxValue, false);

            //registrato.PrototypesDb.Add<ceRoadEntity>(new ceRoadEntity(id, ps, ltemp, ec, lg, ap));
            ceRoadProto roadProto = new ceRoadProto(id, ps, ltemp, ec, lg, ap);
            roadProto.AddParam(new DrawArrowWileBuildingProtoParam(1f, 0f));

            return roadProto;
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
        private static (string[] layout, RelTile3i centerTop)[] NoPillars(
            TrainTrackTrajectoryData traj
        )
        {
            return new (string[] layout, RelTile3i centerTop)[0];
        }
        private static readonly ImmutableArray<RelTile1f> ROAD_LANE_OFFSETS =
        ImmutableArray.Create(
                                    new RelTile1f((-1).ToFix32()),
                                    new RelTile1f(1.ToFix32())
                                );



    }

}
