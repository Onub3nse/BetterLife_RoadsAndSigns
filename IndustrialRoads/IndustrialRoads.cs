using Mafi;
using Mafi.Base;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Animations;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Factory.Transports;
using Mafi.Core.Mods;
using Mafi.Core.Prototypes;
using Mafi.Core.Roads;
using Mafi.Curves;
using System;
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

            ceRoadProto bidirTSection = CreateProto(registrator, BetterLIDs.IndustrialRoads.bidirTSection, "T-Section", btLayouts.Layouts.bidirTSection, BLCosts.Roads.Industrial,
                BetterLIDs.RoadEntities.bidirTee.asset, BetterLIDs.RoadEntities.bidirTee.icon, BetterLIDs.ToolBars.RoadsIndustrial, 0, 0, 0, noLoop);

            blRoadEntranceEntityProto bidirEntrance = CreateRoadEntrance(registrator, BetterLIDs.IndustrialRoads.bidirEntrance, "Entrance/Exit", btLayouts.Layouts.bidirEntrance, BLCosts.Roads.Industrial,
                BetterLIDs.RoadEntities.bidirEntrance.asset, BetterLIDs.RoadEntities.bidirEntrance.icon, BetterLIDs.ToolBars.RoadsIndustrial, 0, 0, 0, false, btLayouts.RoadLanes.bidirEntrance);

            ceRoadProto bidirStraight = CreateProto(registrator, BetterLIDs.IndustrialRoads.bidirStraight, "Straight", btLayouts.Layouts.bidirStraight, BLCosts.Roads.Industrial,
                BetterLIDs.RoadEntities.bidirStraight.asset, BetterLIDs.RoadEntities.bidirStraight.icon, BetterLIDs.ToolBars.RoadsIndustrial, 0, 0, 0, noLoop);

            ceRoadProto bidirCross = CreateProto(registrator, BetterLIDs.IndustrialRoads.bidirCross, "Cross", btLayouts.Layouts.bidirCross, BLCosts.Roads.Industrial,
                BetterLIDs.RoadEntities.bidirCross.asset, BetterLIDs.RoadEntities.bidirCross.icon, BetterLIDs.ToolBars.RoadsIndustrial, 0, 0, 0, noLoop);

            ceRoadProto bidirCorner = CreateProto(registrator, BetterLIDs.IndustrialRoads.bidirCorner, "Corner", btLayouts.Layouts.bidirCorner, BLCosts.Roads.Industrial,
                BetterLIDs.RoadEntities.bidirCorner.asset, BetterLIDs.RoadEntities.bidirCorner.icon, BetterLIDs.ToolBars.RoadsIndustrial, 0, 0, 0, noLoop);

            ceRoadProto bidirBridge1 = CreateProto(registrator, BetterLIDs.IndustrialRoads.bidirBridge1, "Bridge 1", btLayouts.Layouts.bidirStraight, BLCosts.Roads.Industrial,
                BetterLIDs.RoadEntities.bidirBridge1.asset, BetterLIDs.RoadEntities.bidirBridge1.icon, BetterLIDs.ToolBars.RoadsIndustrial, 0, 0, 0, noLoop);


            // One Way Industrial Roads Assets
            blRoadEntranceEntityProto onewayEntrance = CreateRoadEntrance(registrator, BetterLIDs.IndustrialRoads.onewayEntrance, "One Way Entrance", btLayouts.Layouts.onewayEntrance, roadCosts1,
                BetterLIDs.RoadEntities.onewayEntrance.asset, BetterLIDs.RoadEntities.onewayEntrance.icon, BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, false, btLayouts.RoadLanes.onewayEntrance);

            blRoadEntranceEntityProto onewayExit = CreateRoadEntrance(registrator, BetterLIDs.IndustrialRoads.onewayExit, "One Way Exit", btLayouts.Layouts.onewayExit, roadCosts1,
                BetterLIDs.RoadEntities.onewayExit.asset, BetterLIDs.RoadEntities.onewayExit.icon, BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, false, btLayouts.RoadLanes.onewayExit);

            ceRoadProto onewayStraight = CreateProto(registrator, BetterLIDs.IndustrialRoads.onewayStraight, "One Way Straight", btLayouts.Layouts.onewayStraight, roadCosts1,
                BetterLIDs.RoadEntities.onewayStraight.asset, BetterLIDs.RoadEntities.onewayStraight.icon, BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, noLoop);

            ceRoadProto onewayCorner = CreateProto(registrator, BetterLIDs.IndustrialRoads.onewayCorner, "One Way Corner", btLayouts.Layouts.onewayCorner, roadCosts1,
                BetterLIDs.RoadEntities.onewayCorner.asset, BetterLIDs.RoadEntities.onewayCorner.icon, BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, noLoop);

            ceRoadProto onewayCross = CreateProto(registrator, BetterLIDs.IndustrialRoads.onewayCross, "One Way Cross", btLayouts.Layouts.onewayCross, roadCosts1,
                BetterLIDs.RoadEntities.onewayCross.asset, BetterLIDs.RoadEntities.onewayCross.icon, BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, noLoop);

            ceRoadProto onewayTee = CreateProto(registrator, BetterLIDs.IndustrialRoads.onewayTSection, "One Way Tee", btLayouts.Layouts.onewayTee, roadCosts1,
                BetterLIDs.RoadEntities.onewayTSection.asset, BetterLIDs.RoadEntities.onewayTSection.icon, BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, noLoop);

            //ceRoadProto onewayBridge1 = CreateProto(registrator, BetterLIDs.IndustrialRoads.onewayBridge1, "One Way Bridge 1", btLayouts.Layouts.onewayBridge1, roadCosts1,
            //    BetterLIDs.RoadEntities.onewayBridge.asset, BetterLIDs.RoadEntities.onewayBridge.icon, BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, noLoop);

            // One Way Train Bridge Segments

            blRoadEntranceEntityProto onewayTrainBridgeEntrance1 = CreateRoadEntrance(registrator, BetterLIDs.IndustrialRoads.oneWayTrainBridgeEntrance1, "Train Bridge Entrance",
                btLayouts.Layouts.onewayTrainBridgeEntrance1, roadCosts1,
                BetterLIDs.RoadEntities.onewayTrainBridgeEntrance1.asset, BetterLIDs.RoadEntities.onewayTrainBridgeEntrance1.icon, BetterLIDs.ToolBars.RoadsBridgeSegments, 0, 0, 0, false,
                btLayouts.RoadLanes.onewayTrainBridgeEntrance1);

            ceRoadProto onewayTrainStraight = CreateProto(registrator, BetterLIDs.IndustrialRoads.oneWayTrainBridgeStraight1, "Bridge Straight",
                btLayouts.Layouts.onewayTrainBridgeStraight1, roadCosts1,
                BetterLIDs.RoadEntities.onewayTrainBridgeStraight1.asset, BetterLIDs.RoadEntities.onewayTrainBridgeStraight1.icon, BetterLIDs.ToolBars.RoadsBridgeSegments, 0, 0, 0, noLoop);

            ceRoadProto onewayTrainStraight2x = CreateProto(registrator, BetterLIDs.IndustrialRoads.oneWayTrainBridgeStraight2x, "Bridge Straight 2x",
                btLayouts.Layouts.onewayTrainBridgeStraight2x, roadCosts1,
                BetterLIDs.RoadEntities.onewayTrainBridgeStraight2x.asset, BetterLIDs.RoadEntities.onewayTrainBridgeStraight2x.icon, BetterLIDs.ToolBars.RoadsBridgeSegments, 0, 0, 0, noLoop);

            ceRoadProto onewayTrainCorner = CreateProto(registrator, BetterLIDs.IndustrialRoads.oneWayTrainBridgeCorner1, "Bridge Corner",
                btLayouts.Layouts.onewayTrainBridgeCorner1, roadCosts1,
                BetterLIDs.RoadEntities.onewayTrainBridgeCorner1.asset, BetterLIDs.RoadEntities.onewayTrainBridgeCorner1.icon, BetterLIDs.ToolBars.RoadsBridgeSegments, 0, 0, 0, noLoop);

            blRoadEntranceEntityProto onewayTrainBridgeExit1 = CreateRoadEntrance(registrator, BetterLIDs.IndustrialRoads.oneWayTrainBridgeExit1, "Bridge Exit",
                btLayouts.Layouts.onewayTrainBridgeExit1, roadCosts1,
                BetterLIDs.RoadEntities.onewayTrainBridgeExit1.asset, BetterLIDs.RoadEntities.onewayTrainBridgeExit1.icon, BetterLIDs.ToolBars.RoadsBridgeSegments, 0, 0, 0, false,
                btLayouts.RoadLanes.onewayTrainBridgeExit1);


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
            registrator.PrototypesDb.Add(bidirEntrance);
            registrator.PrototypesDb.Add(bidirStraight);
            registrator.PrototypesDb.Add(bidirCorner);
            registrator.PrototypesDb.Add(bidirTSection);
            registrator.PrototypesDb.Add(bidirCross);
            registrator.PrototypesDb.Add(bidirBridge1);

            // Oneway roads
            registrator.PrototypesDb.Add(onewayEntrance);
            registrator.PrototypesDb.Add(onewayStraight);
            registrator.PrototypesDb.Add(onewayCorner);
            registrator.PrototypesDb.Add(onewayCross);
            registrator.PrototypesDb.Add(onewayTee);
            registrator.PrototypesDb.Add(onewayExit);
            //registrator.PrototypesDb.Add(onewayBridge1);

            // Trainbridges 

            registrator.PrototypesDb.Add(onewayTrainBridgeEntrance1);
            registrator.PrototypesDb.Add(onewayTrainStraight);
            registrator.PrototypesDb.Add(onewayTrainStraight2x);
            registrator.PrototypesDb.Add(onewayTrainCorner);
            registrator.PrototypesDb.Add(onewayTrainBridgeExit1);

            // Road Utilities

            //registrator.PrototypesDb.Add(roadWayPoint);


            ProtosDb protosDb = registrator.PrototypesDb;

            EntityCostsTpl costs = Build.CP(5).MaintenanceT1(0).Priority(8).Workers(4);

            EntityCostsTpl costsFuelStation = Build.CP(5).MaintenanceT1(5).Priority(8).Workers(4);

            registrator.FuelStationProtoBuilder
                .Start("Better Fuel Station", BetterLIDs.Buildings.FuelStation1)
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
        public static CubicBezierCurve2f CreateCurve((double, double) start, (double, double) c1, (double, double) c2, (double, double) end)
        {
            return new CubicBezierCurve2f(ImmutableArray.Create(new Vector2f(start.Item1.ToFix32(), start.Item2.ToFix32()), new Vector2f(c1.Item1.ToFix32(), c1.Item2.ToFix32()), new Vector2f(c2.Item1.ToFix32(), c2.Item2.ToFix32()), new Vector2f(end.Item1.ToFix32(), end.Item2.ToFix32())));
        }
        private static CustomLayoutToken CreateHeightToken(string suffix, Fix32 baseOffset, Fix32 heightOffset)
        {
            return new CustomLayoutToken(
                $".0{suffix}",
                (p, h) => new LayoutTokenSpec(
                    heightFrom: h - 2,
                    heightToExcl: h + 2,
                    minTerrainHeight: -2,
                    maxTerrainHeight: h - 1,
                    vehicleHeight: baseOffset + (Fix32)(h - 1) * heightOffset,
                    surfaceId: BetterLIDs.Surfaces.surface1n.Id
                ));
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
            CreateHeightToken("C", 1, 0.125.ToFix32()),
            CreateHeightToken("D", 2, 0.125.ToFix32()),
            CreateHeightToken("E", 3, 0.125.ToFix32()),
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

        public ceRoadProto CreateProto(ProtoRegistrator registrato, StaticEntityProto.ID id, string coment, string[] el, EntityCostsTpl ecTpl, string asp, string ico, Proto.ID cat, Fix32 nX, Fix32 nY, Fix32 nZ, ImmutableArray<AnimationParams> ap)
        {
            //Predicate<LayoutTile> predicate = null;
            var customTokens = new[]
            {
              // === Original .0 series ===
            CreateHeightToken("A", 0, 0.125.ToFix32()),
            CreateHeightToken("B", 0, 0.14285.ToFix32()),
            CreateHeightToken("C", 2, 0.125.ToFix32()),
            CreateHeightToken("D", 3, 0.125.ToFix32()),
            CreateHeightToken("E", 4, 0.125.ToFix32()),

            // === New m0 series ===
            new CustomLayoutToken("m0A", (p, h) => new LayoutTokenSpec(
                heightFrom: 0,
                heightToExcl: h,
                LayoutTileConstraint.None,
                surfaceId: BetterLIDs.Surfaces.surface1n.Id,
                maxTerrainHeight: h - 1
            )),

            new CustomLayoutToken("m0B", (p, h) => new LayoutTokenSpec(
                heightFrom: -2,
                heightToExcl: h,
                LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse,
                surfaceId: BetterLIDs.Surfaces.surface1n.Id,
                minTerrainHeight: -2,
                maxTerrainHeight: h - 1,
                vehicleHeight: h - 1
            )),

            // === Special _0= token ===
            new CustomLayoutToken("_0=", (p, h) => new LayoutTokenSpec(
                heightFrom: h - 2,
                heightToExcl: h + 2,
                maxTerrainHeight: h - 1,
                vehicleHeight: (Fix32)(h - 1),
                surfaceId: BetterLIDs.Surfaces.surface1n.Id
            )),

            new CustomLayoutToken("xXx", (p, h) => new LayoutTokenSpec(
                heightFrom: -2,
                heightToExcl: h,
                maxTerrainHeight: h,
                vehicleHeight: EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value,
                surfaceId: BetterLIDs.Surfaces.surface1n.Id

            )),
            new CustomLayoutToken("x0x", (p, h) => new LayoutTokenSpec(
                heightFrom: -2,
                heightToExcl: h,
                maxTerrainHeight: h - 1,
                vehicleHeight: EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value
            )),




    };



            EntityLayoutParams entityLayoutParams = new EntityLayoutParams(
                customPlacementRange: new ThicknessIRange(0, TransportPillarProto.MAX_PILLAR_HEIGHT.Value - 1),
                customTokens: customTokens,
                enforceEmptySurface: true

                );

            //EntityLayoutParams entityLayoutParams = new EntityLayoutParams(null, null, false, Ids.TerrainTileSurfaces.Metal1, null, null, null, null, default(Option<IEnumerable<KeyValuePair<char, int>>>), false);


            string[] initLayoutString = el;
            EntityLayout ltemp = registrato.LayoutParser.ParseLayoutOrThrow(entityLayoutParams, el);

            ImmutableArray<ToolbarEntryData> categories = ImmutableArray<ToolbarEntryData>.Empty;
            if (cat != BetterLIDs.ToolBars.HiddenProto)
            {
                categories = ImmutableArray.Create(registrato.GetCategory(cat));
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
            return new ceRoadProto(id, ps, ltemp, ec, lg, ap);
        }

    }

}
