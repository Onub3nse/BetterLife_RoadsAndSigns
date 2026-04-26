using Mafi;
using Mafi.Base;
using Mafi.Base.Prototypes.Buildings;
using Mafi.Base.Prototypes.Trains;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Animations;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Factory.Machines;
using Mafi.Core.Factory.Transports;
using Mafi.Core.Mods;
using Mafi.Core.Prototypes;
using Mafi.Core.Roads;
using Mafi.Core.Trains;
using Mafi.Curves;
using Mafi.Localization;
using System;
using System.Reflection;
using static BetterLife_RoadsAndSigns.CustomEntity;
//using static BetterLife.Prototypes.blRoadEntity;


namespace BetterLife_RoadsAndSigns;

internal class RoadsAndSignsData : IModData
{
    public static EntityCostsTpl.Builder Build => new EntityCostsTpl.Builder();
    public static EntityCosts RoadCosts => new EntityCosts();

    public static CubicBezierCurve2f CreateCurve((double, double) start, (double, double) c1, (double, double) c2, (double, double) end)
    {
        return new CubicBezierCurve2f(ImmutableArray.Create(new Vector2f(start.Item1.ToFix32(), start.Item2.ToFix32()), new Vector2f(c1.Item1.ToFix32(), c1.Item2.ToFix32()), new Vector2f(c2.Item1.ToFix32(), c2.Item2.ToFix32()), new Vector2f(end.Item1.ToFix32(), end.Item2.ToFix32())));
    }
    double NearHalf(double value)
    {
        return Math.Max(1, Math.Round(value * 2) / 2.0);
        //(value + multiple - 1) / multiple * multiple
    }
    public blRoadEntranceEntityProto CreateRoadEntranceProto(ProtoRegistrator registrator, StaticEntityProto.ID id, string coment, string[] entLayout, EntityCostsTpl entCosts, string assetPath,
                             string assetIcon, Proto.ID toolbarCategory, int assetXoffset, int assetYoffest, int assetZoffset,
                             bool noPlayer, roadsUtil.mLaneData[] thisLane)
    {
        CustomLayoutToken[] array = new CustomLayoutToken[17];
        array[0] = new CustomLayoutToken("x0x", delegate (EntityLayoutParams p, int h)

        {
            int heightFrom = h - 1;
            int heightToExcl = h;
            int? nullable1 = new int?(h - 1);
            Fix32? nullable2 = new Fix32?(EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value);
            Proto.ID? nullable3 = new Proto.ID?(p.HardenedFloorSurfaceId);
            int? terrainSurfaceHeight = new int?();
            int? minTerrainHeight = new int?();
            int? maxTerrainHeight = nullable1;
            Fix32? vehicleHeight = nullable2;
            Proto.ID? terrainMaterialId = new Proto.ID?();
            Proto.ID? surfaceId = nullable3;
            return new LayoutTokenSpec(heightFrom, heightToExcl, terrainSurfaceHeight: terrainSurfaceHeight, minTerrainHeight: minTerrainHeight, maxTerrainHeight: maxTerrainHeight, vehicleHeight: vehicleHeight, terrainMaterialId: terrainMaterialId, surfaceId: surfaceId);
        });

        array[1] = new CustomLayoutToken(":0:", delegate (EntityLayoutParams p, int h)
        {

            int num = 0;
            LayoutTileConstraint layoutTileConstraint = LayoutTileConstraint.None;
            int? num2 = new int?(0);
            Fix32? fix = new Fix32?(TrainTrackConstants.TRACK_RIDE_HEIGHT.Value);
            return new LayoutTokenSpec(num, h, layoutTileConstraint, num2, null, null, fix, null, null, false, false, 0);

        });
        array[2] = new CustomLayoutToken(".0.", delegate (EntityLayoutParams p, int h)
        {
            int num3 = 0;
            LayoutTileConstraint layoutTileConstraint2 = LayoutTileConstraint.None;
            int? num4 = new int?(0);
            Proto.ID? id = new Proto.ID?(p.HardenedFloorSurfaceId);
            Fix32? fix2 = new Fix32?(TrainTrackConstants.TRACK_RIDE_HEIGHT.Value / 2);
            return new LayoutTokenSpec(num3, h, layoutTileConstraint2, num4, null, null, fix2, null, id, false, false, 0);
        });

        array[3] = new CustomLayoutToken(".0a", delegate (EntityLayoutParams p, int h)
        { return new LayoutTokenSpec(h - 1, h, LayoutTileConstraint.None, null, null, null, ((h - 1) * 0.250).ToFix32(), null, null, false); });

        array[4] = new CustomLayoutToken(".0b", delegate (EntityLayoutParams p, int h)
        { return new LayoutTokenSpec(h - 1, h, LayoutTileConstraint.None, null, null, null, 1 + ((h - 1) * 0.250).ToFix32(), null, null); });

        array[5] = new CustomLayoutToken(".0c", delegate (EntityLayoutParams p, int h)
        { return new LayoutTokenSpec(h - 1, h, LayoutTileConstraint.Ground, null, null, null, 2 + ((h - 1) * 0.250).ToFix32(), null, null, false, false, 0); });

        array[6] = new CustomLayoutToken("uuu", delegate (EntityLayoutParams p, int h)
        { int h1 = ((h / 4) + 1).RoundToMultipleOf(1); return new LayoutTokenSpec(0, 1, LayoutTileConstraint.None, null, null, null, 0, null, null); });

        array[7] = new CustomLayoutToken("-0-", delegate (EntityLayoutParams p, int h)
        {
            LayoutTileConstraint layoutTileConstraint = LayoutTileConstraint.None;
            return new LayoutTokenSpec(0, h, layoutTileConstraint, null, null, new int?(h - 1), null, null, null, false, false, 0);
        });

        array[8] = new CustomLayoutToken("_0=", delegate (EntityLayoutParams p, int h)
        {
            int heightFrom = h - 1;
            int? maxTerrainHeight = h - 1;
            Fix32? vehicleHeight = h - 1;
            return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.None, null, null, maxTerrainHeight, vehicleHeight);
        });
        array[9] = new CustomLayoutToken("<R0", delegate (EntityLayoutParams p, int h)
        {
            int num17 = 0;
            int num18 = 1;
            LayoutTileConstraint layoutTileConstraint6 = LayoutTileConstraint.None;
            Proto.ID? id = new Proto.ID?(p.HardenedFloorSurfaceId);
            return new LayoutTokenSpec(num17, num18, layoutTileConstraint6, null, null, null, null, null, id, true, false, 0);
        });
        array[10] = new CustomLayoutToken("<R1", delegate (EntityLayoutParams p, int h)
        {
            int num19 = 0;
            int num20 = 2;
            LayoutTileConstraint layoutTileConstraint7 = LayoutTileConstraint.None;
            Proto.ID? id2 = null;
            return new LayoutTokenSpec(num19, num20, layoutTileConstraint7, null, null, null, null, null, id2, true, false, 0);
        });
        array[11] = new CustomLayoutToken("<R2", delegate (EntityLayoutParams p, int h)
        {
            int num21 = 1;
            int num22 = 3;
            LayoutTileConstraint layoutTileConstraint8 = LayoutTileConstraint.None;
            int? num23 = new int?(2);
            return new LayoutTokenSpec(num21, num22, layoutTileConstraint8, null, null, num23, null, null, null, true, false, 0);
        });
        array[12] = new CustomLayoutToken("<R3", delegate (EntityLayoutParams p, int h)
        {
            int num24 = 2;
            int num25 = 4;
            LayoutTileConstraint layoutTileConstraint9 = LayoutTileConstraint.None;
            int? num26 = new int?(2);
            return new LayoutTokenSpec(num24, num25, layoutTileConstraint9, null, null, num26, null, null, null, true, false, 0);
        });
        array[13] = new CustomLayoutToken("<R4", delegate (EntityLayoutParams p, int h)
        {
            int num27 = 3;
            int num28 = 5;
            LayoutTileConstraint layoutTileConstraint10 = LayoutTileConstraint.None;
            int? num29 = new int?(3);
            return new LayoutTokenSpec(num27, num28, layoutTileConstraint10, null, null, num29, null, null, null, true, false, 0);
        });
        array[14] = new CustomLayoutToken("a0c", delegate (EntityLayoutParams p, int h)
        {
            int heightFrom = 1;
            int? maxTerrainHeight = 1;
            Fix32? vehicleHeight = 1;
            return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.None, null, null, maxTerrainHeight, vehicleHeight);
        });
        array[15] = new CustomLayoutToken("(W)", delegate (EntityLayoutParams p, int h)
        {
            return new LayoutTokenSpec(-6, 8, LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse, minTerrainHeight: new int?(-5), maxTerrainHeight: new int?(7));
        });
        array[16] = new CustomLayoutToken("t0.", delegate (EntityLayoutParams p, int h)
        {
            return new LayoutTokenSpec(0, h, LayoutTileConstraint.None, null, null, null, h - 1, null, null);

        });


        EntityLayoutParams layoutParams = new EntityLayoutParams(null, array, portsCanOnlyConnectToTransports: false, IdsCore.TerrainTileSurfaces.DefaultConcrete, null, null, null, null, null, default);
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


        blRoadEntranceEntityProto.Gfx graphics = new blRoadEntranceEntityProto.Gfx(assetPath, categories, new RelTile3f(0, 0, 0), 45.Degrees());

        typeof(LayoutEntityProto.Gfx).GetProperty(nameof(LayoutEntityProto.Gfx.IconPath), BindingFlags.Public | BindingFlags.Instance).SetValue(graphics, assetIcon);
        typeof(LayoutEntityProto.Gfx).GetField(nameof(LayoutEntityProto.Gfx.IconIsCustom), BindingFlags.Public | BindingFlags.Instance).SetValue(graphics, true);

        blRoadEntranceEntityProto roadEntranceProto = new blRoadEntranceEntityProto(roadId, strings, layout, none, 0.5.Tiles(), lanespecs, lanesData, trajData, terrainConnections, graphics, true, false, false);
        roadEntranceProto.AddParam(new DrawArrowWileBuildingProtoParam(2f));

        if (roadEntranceProto == null)
            Log.Info("BETTERLIFE DEBUG: Error on creating road entrance proto...");


        return roadEntranceProto;
    }

    public blRoadEntityProto CreateRoadProto(ProtoRegistrator registrator, StaticEntityProto.ID id, string coment, string[] entLayout, EntityCostsTpl entCosts, string assetPath,
                             string assetIcon, Proto.ID toolbarCategory, int assetXoffset, int assetYoffest, int assetZoffset,
                             bool noPlayer, RoadLaneType laneTypeBase)
    {
        CustomLayoutToken[] array = new CustomLayoutToken[11];

        array[0] = new CustomLayoutToken("xbx", delegate (EntityLayoutParams p, int h)
        {
            //Fix32? vehicleHeight = EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value;
            Fix32? vehicleHeight = 3;
            Proto.ID? surfaceId = p.HardenedFloorSurfaceId;

            return new LayoutTokenSpec(0, 3, LayoutTileConstraint.None, null, null, 0, vehicleHeight, null, surfaceId);
        });

        array[1] = new CustomLayoutToken(":0:", delegate (EntityLayoutParams p, int h)
        {
            int? terrainSurfaceHeight = 0;
            Fix32? vehicleHeight = 8;

            return new LayoutTokenSpec(0, 8, LayoutTileConstraint.None, terrainSurfaceHeight, null, null, vehicleHeight);
        });



        array[2] = new CustomLayoutToken(".0a", delegate (EntityLayoutParams p, int h)
        {
            return new LayoutTokenSpec(0, 1, LayoutTileConstraint.None, null, null, 0, ((h - 1) * 0.250).ToFix32(), null, null);
        });

        array[3] = new CustomLayoutToken(".0b", delegate (EntityLayoutParams p, int h)
        {
            return new LayoutTokenSpec(0, 1, LayoutTileConstraint.None, null, null, 0, 1 + ((h - 1) * 0.250).ToFix32(), null, null);
        });

        array[4] = new CustomLayoutToken(".0c", delegate (EntityLayoutParams p, int h)
        {
            return new LayoutTokenSpec(0, 1, LayoutTileConstraint.None, null, null, 7, 2 + ((h - 1) * 0.250).ToFix32(), null, null);
        });

        array[5] = new CustomLayoutToken("uuu", delegate (EntityLayoutParams p, int h)
        {
            int h1 = ((h / 4) + 1).RoundToMultipleOf(1);
            return new LayoutTokenSpec(0, 1, LayoutTileConstraint.None, null, null, null, 0, null, null);
        });
        array[6] = new CustomLayoutToken("-0-", delegate (EntityLayoutParams p, int h)
        {
            return new LayoutTokenSpec(0, h, isRamp: true);
        });
        array[7] = new CustomLayoutToken("_0=", delegate (EntityLayoutParams p, int h)
        {
            int heightFrom = h - 1;
            int? maxTerrainHeight = h - 1;
            Fix32? vehicleHeight = h - 1;
            return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.None, null, null, maxTerrainHeight, vehicleHeight);
        });
        array[8] = new CustomLayoutToken("<R1", delegate (EntityLayoutParams p, int h)
        {
            Proto.ID? surfaceId = p.HardenedFloorSurfaceId;
            return new LayoutTokenSpec(0, 1, LayoutTileConstraint.None, null, null, null, null, null, surfaceId, isRamp: true);
        });
        array[9] = new CustomLayoutToken("<R2", delegate
        {
            int? maxTerrainHeight = 1;
            return new LayoutTokenSpec(1, 2, LayoutTileConstraint.None, null, null, maxTerrainHeight, null, null, null, isRamp: true);
        });
        array[10] = new CustomLayoutToken("<R3", delegate
        {
            int? maxTerrainHeight = 1;
            return new LayoutTokenSpec(2, 3, LayoutTileConstraint.None, null, null, maxTerrainHeight, null, null, null, isRamp: true);
        });




        EntityLayoutParams layoutParams = new EntityLayoutParams(null, array, portsCanOnlyConnectToTransports: false, IdsCore.TerrainTileSurfaces.DefaultConcrete, null, null, null, null, null, default);
        EntityLayout layout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams, entLayout);
        int roadWidth = 2;
        RoadLaneType terrainToRoad = laneTypeBase | RoadLaneType.TerrainConnectionFlag;
        RoadLaneType roadElevated = laneTypeBase | RoadLaneType.ElevatedLaneFlag;


        Fix32 maxLaneOffset = blRoadEntityProto.LANE_WIDTH_INNER.Value * Fix32.Half; // 0.9375 as Fix32
        Fix32 baseOffset = Fix32.FromInt(1) * Fix32.Half; // 0.5 as Fix32
        Fix32 rawLaneOffset = baseOffset * Fix32.FromInt(roadWidth / 2); // Raw offset based on roadWidth
        RoadLaneType roadLaneType = laneTypeBase | RoadLaneType.ElevatedLaneFlag;
        Fix32 laneOffset = Fix32.FromDouble(Math.Floor(rawLaneOffset.ToDouble() / 0.5) * 0.5).Min(maxLaneOffset); // Round down to nearest 0.5, cap at 0.9375
        //double scaledFirstLaneY = -laneOffset.ToDouble(); // e.g., -0.5 for roadWidth=2, -0.5 for roadWidth=4
        //double scaledSecondLaneY = laneOffset.ToDouble(); // e.g., 0.5 for roadWidth=2, 0.5 for roadWidth=4
        double scaledFirstLaneY = -8;
        double scaledSecondLaneY = 8;
        //double firstLaneY = -2;
        //double secondLaneY = 2;
        int x = layout.LayoutSize.X;
        int y = layout.LayoutSize.Y;
        int num = x / 2;
        int num2 = num - 1;
        //int num3 = layout.LayoutSize.X / 2;
        //int num4 = ((secondLaneY == (double)secondLaneY.FloorToInt()) ? (-1) : 0);

        double xMax = (layout.LayoutSize.X);
        double yMax = (layout.LayoutSize.Y);

        double xControl1 = NearHalf(x / 4);
        double xControl2 = xControl1 * 3;

        double yControl1 = NearHalf(y / 4);
        double yControl2 = yControl1 * 3;


        CubicBezierCurve2f heightCurve;
        CubicBezierCurve2f heightCurveElevated;
        //heightCurve = CreateCurve((-xMax, 0), (-xMax + xControl1, 0), ( -xMax + xControl2, 0), (xMax, 0));
        //heightCurveElevated = CreateCurve((-xMax, yMax), (-xMax + xControl1, yMax), (-xMax + xControl2, yMax), (xMax, yMax));
        heightCurve = CreateCurve((0.0, 0), (0.25, 0.0), (0.75, 0.0), (1.0, 0));
        heightCurveElevated = CreateCurve((0, -3), (0.25, -3), (0.75, -3), (1, -3));


        ImmutableArray<RoadLaneSpec> immutableArray;
        // ImmutableArray<LaneTerrainConnectionSpec> terrainConnections;

        //"            (1)(5)",
        //"_1__1__1__1_.1.:8:",
        //"_1__1__1__1_.1.:8:",
        //"_1__1__1__1_.1.:8:",
        //"_1__1__1__1_.1.:8:",
        //"_1__1__1__1_.1.:8:",
        //"_1__1__1__1_.1.:8:",
        //"_1__1__1__1_.1.:8:",
        //"_1__1__1__1_.1.:8:",
        //"_1__1__1__1_.1.:8:",
        //"_1__1__1__1_.1.:8:",
        //"            (1)(5)

        immutableArray = ImmutableArray.Create(
        new RoadLaneSpec(TrainTracksData.CreateCurve(
        (0, scaledFirstLaneY), (0.25, scaledFirstLaneY), (0.75, scaledFirstLaneY), (1, scaledFirstLaneY)),
        RelTile1f.Zero, heightCurve, roadElevated, roadElevated),

        new RoadLaneSpec(TrainTracksData.CreateCurve
        ((1, scaledSecondLaneY), (0.75, scaledSecondLaneY), (0.25, scaledSecondLaneY), (0, scaledSecondLaneY)),
        RelTile1f.Zero, heightCurve, roadElevated, roadElevated));




        if (!blRoadEntityProto.TryCreateLanes(immutableArray, out var lanesData, out var trajData, out var error, 20))
        {
            Log.Info("Failed to create road lanes: " + error);
            return null;
        }

        StaticEntityProto.ID roadId = id;
        Proto.Str strings = Proto.CreateStr(roadId, coment, "Roads");
        EntityCosts none = entCosts.MapToEntityCosts(registrator);
        ImmutableArray<ToolbarEntryData> categories = ImmutableArray<ToolbarEntryData>.Empty;
        if (toolbarCategory != BetterLIDs.ToolBars.HiddenProto)
        {
            categories = ImmutableArray.Create(registrator.GetCategory(toolbarCategory));
        }

        blRoadEntityProto.Gfx graphics = new blRoadEntityProto.Gfx(assetPath, categories, default(RelTile3f), null, false);

        typeof(LayoutEntityProto.Gfx).GetProperty(nameof(LayoutEntityProto.Gfx.IconPath), BindingFlags.Public | BindingFlags.Instance).SetValue(graphics, assetIcon);
        typeof(LayoutEntityProto.Gfx).GetField(nameof(LayoutEntityProto.Gfx.IconIsCustom), BindingFlags.Public | BindingFlags.Instance).SetValue(graphics, true);

        blRoadEntityProto roadProto = new blRoadEntityProto(roadId, strings, layout, none, 3.0.Tiles(), immutableArray, lanesData, trajData, graphics, true, true, true);
        roadProto.AddParam(new DrawArrowWileBuildingProtoParam(2f));
        //registrator.PrototypesDb.Add(roadProto);
        return roadProto;
    }
    public blRoadEntityProto CreateRoadProto2(ProtoRegistrator registrator, StaticEntityProto.ID id, string coment, string[] entLayout, EntityCostsTpl entCosts, string assetPath,
                             string assetIcon, Proto.ID toolbarCategory, int assetXoffset, int assetYoffest, int assetZoffset,
                             bool noPlayer, roadsUtil.mLaneData[] thisLane)
    {
        CustomLayoutToken[] array = new CustomLayoutToken[14];

        array[0] = new CustomLayoutToken("x0x", delegate (EntityLayoutParams p, int h)
        {
            int heightFrom = h - 1;
            int heightToExcl = h;
            int? nullable1 = new int?(h - 1);
            Fix32? nullable2 = new Fix32?(EntityLayout.VEHICLE_INACCESSIBLE_HEIGHT.Value);
            Proto.ID? nullable3 = new Proto.ID?(p.HardenedFloorSurfaceId);
            int? terrainSurfaceHeight = new int?();
            int? minTerrainHeight = new int?();
            int? maxTerrainHeight = nullable1;
            Fix32? vehicleHeight = nullable2;
            Proto.ID? terrainMaterialId = new Proto.ID?();
            Proto.ID? surfaceId = nullable3;
            return new LayoutTokenSpec(heightFrom, heightToExcl, terrainSurfaceHeight: terrainSurfaceHeight, minTerrainHeight: minTerrainHeight, maxTerrainHeight: maxTerrainHeight, vehicleHeight: vehicleHeight, terrainMaterialId: terrainMaterialId, surfaceId: surfaceId);
        });
        array[1] = new CustomLayoutToken(":0:", delegate (EntityLayoutParams p, int h)
        {
            int num = 0;
            LayoutTileConstraint layoutTileConstraint = LayoutTileConstraint.None;
            //int? num2 = new int?(0);
            //Fix32? fix = new Fix32?(TrainTrackConstants.TRACK_RIDE_HEIGHT.Value);
            int? num2 = new int?(2);
            Fix32? fix = new Fix32?(3);
            return new LayoutTokenSpec(num, h, layoutTileConstraint, num2, null, null, fix, null, null, false, false, 0);
        });
        array[2] = new CustomLayoutToken(".0a", delegate (EntityLayoutParams p, int h)
        {
            return new LayoutTokenSpec(h - 1, h, LayoutTileConstraint.None, null, null, null, ((h - 1) * 0.250).ToFix32(), null, null);
        });

        array[3] = new CustomLayoutToken(".0b", delegate (EntityLayoutParams p, int h)
        {
            return new LayoutTokenSpec(h - 1, h, LayoutTileConstraint.None, null, null, null, 1 + ((h - 1) * 0.250).ToFix32(), null, null);
        });

        array[4] = new CustomLayoutToken(".0c", delegate (EntityLayoutParams p, int h)
        {
            return new LayoutTokenSpec(h - 1, h, LayoutTileConstraint.Ground, h, null, null, 2 + ((h - 1) * 0.250).ToFix32(), null, null);

        });

        array[5] = new CustomLayoutToken("-0-", delegate (EntityLayoutParams p, int h)
        {
            LayoutTileConstraint layoutTileConstraint = LayoutTileConstraint.None;
            return new LayoutTokenSpec(0, h, layoutTileConstraint, null, null, new int?(h - 1), null, null, null, false, false, 0);
        });
        array[6] = new CustomLayoutToken("-0-", delegate (EntityLayoutParams p, int h)
        {
            return new LayoutTokenSpec(0, h, isRamp: true);
        });
        array[7] = new CustomLayoutToken("_0=", delegate (EntityLayoutParams p, int h)
        {

            int heightFrom = h - 1;
            int? maxTerrainHeight = h - 1;
            Fix32? vehicleHeight = h - 1;
            return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.None, null, null, maxTerrainHeight, vehicleHeight);
        });
        array[8] = new CustomLayoutToken("<R1", delegate (EntityLayoutParams p, int h)
        {
            Proto.ID? surfaceId = p.HardenedFloorSurfaceId;
            return new LayoutTokenSpec(0, 1, LayoutTileConstraint.None, null, null, null, null, null, surfaceId, isRamp: true);
        });
        array[9] = new CustomLayoutToken("<R2", delegate
        {
            int? maxTerrainHeight = 1;
            return new LayoutTokenSpec(1, 2, LayoutTileConstraint.None, null, null, maxTerrainHeight, null, null, null, isRamp: true);
        });
        array[10] = new CustomLayoutToken("<R3", delegate
        {
            int? maxTerrainHeight = 1;
            return new LayoutTokenSpec(2, 3, LayoutTileConstraint.None, null, null, maxTerrainHeight, null, null, null, isRamp: true);
        });
        array[11] = new CustomLayoutToken("a0c", delegate (EntityLayoutParams p, int h)
        {
            int heightFrom = 7;
            int? maxTerrainHeight = 8;
            Fix32? vehicleHeight = 8;
            return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.None, null, null, maxTerrainHeight, vehicleHeight);
        });
        array[12] = new CustomLayoutToken("(W)", delegate (EntityLayoutParams p, int h)
        {
            return new LayoutTokenSpec(-6, 8, LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse, minTerrainHeight: new int?(-5), maxTerrainHeight: new int?(7));
        });
        array[13] = new CustomLayoutToken("h0.", delegate (EntityLayoutParams p, int h)
        {
            return new LayoutTokenSpec(h - 1, h, LayoutTileConstraint.None, null, null, null, 2 + ((h - 1) * 0.250).ToFix32(), null, null, false, false, 0);
        });


        EntityLayoutParams layoutParams = new EntityLayoutParams(null, array, portsCanOnlyConnectToTransports: false, IdsCore.TerrainTileSurfaces.DefaultConcrete, null, null, null, null, null, default);
        EntityLayout layout = registrator.LayoutParser.ParseLayoutOrThrow(layoutParams, entLayout);

        ImmutableArray<RoadLaneSpec> immutableArray = ImmutableArray<RoadLaneSpec>.Empty;
        ImmutableArray<RoadLaneMetadata> lanesData = ImmutableArray<RoadLaneMetadata>.Empty;
        ImmutableArray<RoadLaneTrajectory> trajData = ImmutableArray<RoadLaneTrajectory>.Empty;
        ImmutableArray<LaneTerrainConnectionSpec> terrainConnections = ImmutableArray<LaneTerrainConnectionSpec>.Empty;
        bool result = false;

        roadsUtil.CreateLanes(thisLane, out immutableArray, out trajData, out lanesData, out terrainConnections, out result);




        StaticEntityProto.ID roadId = id;
        Proto.Str strings = Proto.CreateStr(roadId, coment, "Roads");
        EntityCosts none = entCosts.MapToEntityCosts(registrator);
        ImmutableArray<ToolbarEntryData> categories = ImmutableArray<ToolbarEntryData>.Empty;
        if (toolbarCategory != BetterLIDs.ToolBars.HiddenProto)
        {
            categories = ImmutableArray.Create(registrator.GetCategory(toolbarCategory));
        }

        blRoadEntityProto.Gfx graphics = new blRoadEntityProto.Gfx(assetPath, categories, default(RelTile3f), null, false);

        typeof(LayoutEntityProto.Gfx).GetProperty(nameof(LayoutEntityProto.Gfx.IconPath), BindingFlags.Public | BindingFlags.Instance).SetValue(graphics, assetIcon);
        typeof(LayoutEntityProto.Gfx).GetField(nameof(LayoutEntityProto.Gfx.IconIsCustom), BindingFlags.Public | BindingFlags.Instance).SetValue(graphics, true);

        blRoadEntityProto roadProto = new blRoadEntityProto(roadId, strings, layout, none, 0.5.Tiles(), immutableArray, lanesData, trajData, graphics, true, false, false);


        //BLRoadProto.TryCreateProto(roadId, strings, immutableArray, default, graphics, registrator.LayoutParser, out BLRoadProto rProto, out string error);

        //        Log.Info($"Erorr if any...{error}");
        roadProto.AddParam(new DrawArrowWileBuildingProtoParam(2f));
        //registrator.PrototypesDb.Add(roadProto);
        return roadProto;
    }

    public CustomEntityPrototype CreateProto(ProtoRegistrator registrato, StaticEntityProto.ID id, string coment, string[] el, EntityCostsTpl ecTpl, string asp, string ico, Proto.ID cat, Fix32 nX, Fix32 nY, Fix32 nZ, ImmutableArray<AnimationParams> ap)
    {
        //Predicate<LayoutTile> predicate = null;
        CustomLayoutToken[] array = new CustomLayoutToken[6];
        array[0] = new CustomLayoutToken("=0=", delegate (EntityLayoutParams p, int h)
        {
            int heightFrom = h - 1;
            int? maxTerrainHeight3 = new int?(h - 1);
            Fix32? vehicleHeight2 = new Fix32?(h - 1);
            return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse, 0, null, maxTerrainHeight3, vehicleHeight2, null, null, false, false, 0);
        });
        array[1] = new CustomLayoutToken("(W)", delegate (EntityLayoutParams p0, int p1)
        {
            int? minTerrainHeight = new int?(-10);
            int? maxTerrainHeight = new int?(3);
            int num = -9;
            int num2 = 3;
            LayoutTileConstraint layoutTileConstraint = LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse;
            int? num3 = minTerrainHeight;
            int? num4 = maxTerrainHeight;
            return new LayoutTokenSpec(num, num2, layoutTileConstraint, null, num3, num4, null, null, null, false, false, 0);
        });
        array[2] = new CustomLayoutToken("-0-", delegate (EntityLayoutParams p0, int h)
        {
            LayoutTileConstraint layoutTileConstraint = LayoutTileConstraint.None;
            return new LayoutTokenSpec(0, h, layoutTileConstraint, null, null, new int?(h - 1), null, null, null, false, false, 0);
        });
        array[3] = new CustomLayoutToken("_0=", delegate (EntityLayoutParams p, int h)
        {
            int heightFrom = h - 1;
            int? maxTerrainHeight3 = new int?(h - 1);
            Fix32? vehicleHeight2 = new Fix32?(h - 1);
            return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.UsingPillar, null, null, maxTerrainHeight3, vehicleHeight2, null, null, false, false, 0);
        });

        array[4] = new CustomLayoutToken("|0|", (param, height) =>
        {
            return new LayoutTokenSpec(
                constraint: LayoutTileConstraint.UsingPillar,
                heightFrom: 0,
                heightToExcl: height,
                maxTerrainHeight: 0,
                minTerrainHeight: 0
            );
        });
        array[5] = new CustomLayoutToken("h0.", delegate (EntityLayoutParams p, int h)
        {
            return new LayoutTokenSpec(h - 1, h, LayoutTileConstraint.None, null, null, h - 1, h - 1, null, null, false, false, 0);
        });



        EntityLayoutParams entityLayoutParams = new EntityLayoutParams(
            customPlacementRange: new ThicknessIRange(0, TransportPillarProto.MAX_PILLAR_HEIGHT.Value - 1),
            customTokens: array
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

        //registrato.PrototypesDb.Add<CustomEntityPrototype>(new CustomEntityPrototype(id, ps, ltemp, ec, lg, ap));
        return new CustomEntityPrototype(id, ps, ltemp, ec, lg, ap);
    }

    public void RegisterData(ProtoRegistrator registrator)
    {
        EntityCostsTpl entityRoadCosts = Build.MaintenanceT1(0).Priority(8).Workers(0);
        ImmutableArray<AnimationParams> noLoop2 = ImmutableArray.Create(new AnimationParams[]
        {
            AnimationParams.RepeatAutoTimes(Duration.FromYears(1))
        });

        //IoPortShapeProto shapeFlat = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Mafi.Base.Ids.IoPortShapes.FlatConveyor);
        //IoPortShapeProto shapeLoose = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Mafi.Base.Ids.IoPortShapes.LooseMaterialConveyor);
        //IoPortShapeProto shapePipe = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Mafi.Base.Ids.IoPortShapes.Pipe);
        //IoPortShapeProto shapeMolten = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Mafi.Base.Ids.IoPortShapes.MoltenMetalChannel);
        //IoPortShapeProto shapeShaft = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Mafi.Base.Ids.IoPortShapes.Shaft);

        //ProtosDb prototypesDb = registrator.PrototypesDb;


        //prototypesDb.Add(new IoPortShapeProto(PortIDs.myFlatShape, Proto.Str.Empty, '#', CountableProductProto.ProductType, new IoPortShapeProto.Gfx("Assets/BetterLife/BetterLifes.VisualPatch/ports/port.prefab", "Assets/Base/Transports/ConveyorUnit/Port-Lod3.prefab", false, shapeFlat.Graphics.DisconnectedPortPrefabPath, shapeFlat.Graphics.DisconnectedPortPrefabPathLod3), null), false);
        //prototypesDb.Add(new IoPortShapeProto(PortIDs.myLooseShape, Proto.Str.Empty, '~', LooseProductProto.ProductType, new IoPortShapeProto.Gfx("Assets/BetterLife/BetterLifes.VisualPatch/ports/port.prefab", "Assets/Base/Transports/ConveyorUnit/Port-Lod3.prefab", false, shapeLoose.Graphics.DisconnectedPortPrefabPath, shapeLoose.Graphics.DisconnectedPortPrefabPathLod3), null), false);
        //prototypesDb.Add(new IoPortShapeProto(PortIDs.myPipeShape, Proto.Str.Empty, '@', FluidProductProto.ProductType, new IoPortShapeProto.Gfx("Assets/BetterLife/BetterLifes.VisualPatch/ports/port.prefab", "Assets/Base/Transports/Pipes/Port-Lod3.prefab", showWhenTwoTransportsConnect: true)));
        //prototypesDb.Add(new IoPortShapeProto(PortIDs.myMoltenShape, Proto.Str.Empty, '\'', MoltenProductProto.ProductType, new IoPortShapeProto.Gfx("Assets/BetterLife/BetterLifes.VisualPatch/ports/port.prefab", "Assets/Base/Transports/MoltenChannel/Port-Lod3.prefab", showWhenTwoTransportsConnect: false, shapeMolten.Graphics.DisconnectedPortPrefabPath, shapeMolten.Graphics.DisconnectedPortPrefabPathLod3)));
        //prototypesDb.Add(new IoPortShapeProto(PortIDs.myShaftShape, Proto.Str.Empty, '|', ProductType.NONE, new IoPortShapeProto.Gfx("Assets/BetterLife/BetterLifes.VisualPatch/ports/port.prefab", "Assets/Base/Transports/Shaft/Port-Lod3.prefab"), new Tag[1] { CoreProtoTags.MechanicalShaft }));


        string[] laneplayground =
        {
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx:8::8::8::8::8:xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx",
            ".5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5cxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx:8::8::8::8::8:xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx",
            ".5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5cxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx:8::8::8::8::8:xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx",
            ".5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5cxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx:8::8::8::8::8:xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx",
            ".5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5cxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx:8::8::8::8::8:xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx",
            ".5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5cxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx:8::8::8::8::8:xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx",
            ".5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5cxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx:8::8::8::8::8:xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx.5c.5c.5c.5cxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx:8::8::8::8::8:xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx.5c.5c.5c.5cxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx.5c.5c.5c.5cxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx",
            "uuuuuuuuuuuuuuuuuuuuuuuuxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx.5c.5c.5c.5cxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx",
            "uuuuuuuuuuuuuuuuuuuuuuuuxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx.5c.5c.5c.5cxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx",
            "uuuuuuuuuuuuuuuuuuuuuuuuxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx.5c.5c.5c.5cxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx",
            "uuuuuuuuuuuuuuuuuuuuuuuuxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx.5c.5c.5c.5cxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx",
            "uuuuuuuuuuuuuuuuuuuuuuuuxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx.5c.5c.5c.5cxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx",
            "uuuuuuuuuuuuuuuuuuuuuuuuxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx.5c.5c.5c.5cxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx.5c.5c.5c.5cxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx.5c.5c.5c.5cxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx.5c.5c.5c.5cxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx.5c.5c.5c.5cxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx.5c.5c.5c.5cxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx.5c.5c.5c.5cxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5cuuuuuuuuuuuuuuuuuu",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5cuuuuuuuuuuuuuuuuuu",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5cuuuuuuuuuuuuuuuuuu",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5cuuuuuuuuuuuuuuuuuu",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbx.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5c.5cuuuuuuuuuuuuuuuuuu",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxuuuuuuuuuuuuuuuxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxuuuuuuuuuuuuuuuxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxuuuuuuuuuuuuuuuxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxuuuuuuuuuuuuuuuxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxuuuuuuuuuuuuuuuxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxuuuuuuuuuuuuuuuxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxuuuuuuuuuuuuuuuxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxuuuuuuuuuuuuuuuxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxuuuuuuuuuuuuuuuxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxuuuuuuuuuuuuuuuxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxuuuuuuuuuuuuuuuxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxuuuuuuuuuuuuuuuxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxuuuuuuuuuuuuuuuxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxuuuuuuuuuuuuuuuxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxuuuuuuuuuuuuuuuxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxuuuuuuuuuuuuuuuxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxuuuuuuuuuuuuuuuxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxuuuuuuuuuuuuuuuxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxuuuuuuuuuuuuuuuxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxuuuuuuuuuuuuuuuxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxuuuuuuuuuuuuuuuxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxuuuuuuuuuuuuuuuxbx",
            "xbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxxbxuuuuuuuuuuuuuuuxbx",
        };

        string[] Road1PillarLayout =
        {
            "_1="
        };

        roadsUtil.terrainGraph[] emptyGraphConnections = new roadsUtil.terrainGraph[]
        {
                new roadsUtil.terrainGraph(0, new RelTile2f(-100, -100), true)
        };

        string[] Road1LargeStraight =
           {
               "_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=",
               "_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=",
               "_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=",
               "_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=_4=",
               "_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5=_5="
            };



        roadsUtil.mLaneData[] laneRoad1LargeStraight = new roadsUtil.mLaneData[]
        {
            // lane 1 left
            new roadsUtil.mLaneData(
                // start and end position of the lane
                vLaneTrajectory: CreateCurve((-13,-1),(-6,-1),(7,-1),(14,-1)),
                vTerrainTiles: new roadsUtil.terrainGraph[]
                {
                    new roadsUtil.terrainGraph(0, new RelTile2f(-100,-100), true)
                },
               
                // as ramp ill define it the start as terrain connection and the end as elevated.
                vlanetype1: RoadLaneType.ElevatedLaneFlag| RoadLaneType.MaskAllowAll ,
                vlanetype2: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll ,
                vHeightCurve: CreateCurve((0,3), (6,3), (18,3), (27,3))
                ),
            // lane 2 right
            new roadsUtil.mLaneData(
                // start and end position of the lane
                vLaneTrajectory: CreateCurve((14,2),(7,2),(-6,2),(-13,2)),
                vTerrainTiles: new roadsUtil.terrainGraph[]
                {
                    new roadsUtil.terrainGraph(1, new RelTile2f(-100,-100), false)
                },
                vlanetype1: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                vlanetype2: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                vHeightCurve: CreateCurve((27,3), (18,3), (6,3), (0,3))
                )
        };

        string[] Road1Straight =
           {
               //"_4=_4=_4=_4=_4=_4=_4=_4=_4=",
               //"h3.h3.h3.h3.h3.h3.h3.h3.h3.",
               //"h3.h3.h3.h3.h3.h3.h3.h3.h3.",
               //"h3.h3.h3.h3.h3.h3.h3.h3.h3.",
               //"_5=_5=_5=_5=_5=_5=_5=_5=_5=",
               //"h3.h3.h3.h3.h3.h3.h3.h3.h3.",
               //"h3.h3.h3.h3.h3.h3.h3.h3.h3.",
               //"h3.h3.h3.h3.h3.h3.h3.h3.h3.",
               //"_4=_4=_4=_4=_4=_4=_4=_4=_4=",

               "h4.h4.h4.h4.h4.h4.h4.h4.h4.",
               "h4.h4.h4.h4.h4.h4.h4.h4.h4.",
               "h4.h4.h4.h4.h4.h4.h4.h4.h4.",
               "h4.h4.h4.h4.h4.h4.h4.h4.h4.",
               "h4.h4.h4.h4.h4.h4.h4.h4.h4.",
               "h4.h4.h4.h4.h4.h4.h4.h4.h4.",
               "h4.h4.h4.h4.h4.h4.h4.h4.h4.",
               "h4.h4.h4.h4.h4.h4.h4.h4.h4.",
               "h4.h4.h4.h4.h4.h4.h4.h4.h4.",
               "h4.h4.h4.h4.h4.h4.h4.h4.h4.",
               "h4.h4.h4.h4.h4.h4.h4.h4.h4.",
            };

        roadsUtil.mLaneData[] laneRoad1Straight = new roadsUtil.mLaneData[4]
        {
            // lane 1 left
            new roadsUtil.mLaneData(
                // start and end position of the lane
                vLaneTrajectory: CreateCurve((-4,-1),(-3,-1),(3,-1),(5,-1)),
                vTerrainTiles: new roadsUtil.terrainGraph[]
                {
                    new roadsUtil.terrainGraph(0, new RelTile2f(-100,-100), true)
                },
                // elevated on both ends
                vlanetype1: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                vlanetype2: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                vHeightCurve: CreateCurve((0,3), (2,3), (6,3), (9,3))
                ),
            // lane 2 right
            new roadsUtil.mLaneData(
                // start and end position of the lane
                vLaneTrajectory: CreateCurve((5,2),(3,2),(-3,2),(-4,2)),
                // no terrain tiles set to -100, this is a roadentityproto, not entrance.
                vTerrainTiles: new roadsUtil.terrainGraph[]
                {
                    new roadsUtil.terrainGraph(1, new RelTile2f(-100,-100), false)
                },
                vlanetype1: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                vlanetype2: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                vHeightCurve: CreateCurve((9,3), (6,3), (2,3), (0,3))
                ),
            // lane crossing the other two
            new roadsUtil.mLaneData(
                vLaneTrajectory: CreateCurve((-1,5), (-1,3), (-1,-1), (-1,-4)),
                vTerrainTiles: new roadsUtil.terrainGraph[]
                {
                    new roadsUtil.terrainGraph(2, new RelTile2f(-100,-100), true)
                },
                vlanetype1: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                vlanetype2: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                vHeightCurve: CreateCurve((0,3), (0.25,3), (0.75,3), (1,3))
                ),
            new roadsUtil.mLaneData(
                vLaneTrajectory: CreateCurve((2,-4), (2,-1), (2,3), (2,5)),
                vTerrainTiles: new roadsUtil.terrainGraph[]
                {
                    new roadsUtil.terrainGraph(3, new RelTile2f(-100,-100), false)
                },
                vlanetype1: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                vlanetype2: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                vHeightCurve: CreateCurve((0,3), (0.25,3), (0.75,3), (1,3))
                )
        };

        string[] Road1CornerLayout =
           {
               "h4.h4.h4.h4.h4.h4.h4.h4.h4.",
               "h4.h4.h4.h4.h4.h4.h4.h4.h4.",
               "h4.h4.h4.h4.h4.h4.h4.h4.h4.",
               "h4.h4.h4.h4.h4.h4.h4.h4.h4.",
               "h4.h4.h4.h4.h4.h4.h4.h4.h4.",
               "h4.h4.h4.h4.h4.h4.h4.h4.h4.",
               "h4.h4.h4.h4.h4.h4.h4.h4.h4.",
               "h4.h4.h4.h4.h4.h4.h4.h4.h4.",
               "h4.h4.h4.h4.h4.h4.h4.h4.h4.",
            };

        roadsUtil.mLaneData[] laneRoad1Corner = new roadsUtil.mLaneData[]
       {
            new roadsUtil.mLaneData(
                // start and end position of the lane
                vLaneTrajectory: CreateCurve((-4,-1),(-3,-2),(-1,-3),(-1,-4)),
                vTerrainTiles: new roadsUtil.terrainGraph[]
                {
                    new roadsUtil.terrainGraph(0, new RelTile2f(0,2), true)
                },
                // as ramp ill define it the start as terrain connection and the end as elevated.
                vlanetype1: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                vlanetype2: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                vHeightCurve: CreateCurve((0,3), (2,3), (8,3 ), (12, 3))
                ),
                new roadsUtil.mLaneData(
                // start and end position of the lane
                vLaneTrajectory: CreateCurve((2,-4),(1,-3),(-3,1),(-4,2)),
                vTerrainTiles: new roadsUtil.terrainGraph[]
                {
                    new roadsUtil.terrainGraph(1, new RelTile2f(0,6), false)
                },
                // as ramp ill define it the start as terrain connection and the end as elevated.
                vlanetype1: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                vlanetype2: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                vHeightCurve: CreateCurve((0,3), (2,3), (8, 3), (12, 3))
                )

            // lane 1 left
            //new roadsUtil.mLaneData(
            //    // start and end position of the lane
            //    vLaneTrajectory: CreateCurve((-4,-1),(-3,-1),(-2,-1),(-1,-1)),
            //    vTerrainTile: new RelTile2i(-100,-100),
            //    // as ramp ill define it the start as terrain connection and the end as elevated.
            //    vlanetype1: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
            //    vlanetype2: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
            //    vLaneIndex: 0,
            //    vIsAtStart: true,
            //    vHeightCurve: CreateCurve((0,3), (2,3), (8, 3), (12, 3))
            //    ),
            ////// lane 2 right
            //new roadsUtil.mLaneData(
            //    // start and end position of the lane
            //    vLaneTrajectory: CreateCurve((-1,-1),(-1,-2),(-1,-3),(-1,-4)),
            //    vTerrainTile: new RelTile2i(6,9),
            //    vlanetype1: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
            //    vlanetype2: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
            //    vLaneIndex: 1,
            //    vIsAtStart: false,
            //    vHeightCurve: CreateCurve((0,3), (2,3), (8, 3), (12, 3))
            //    ),
            //// lane 3 right
            //new roadsUtil.mLaneData(
            //    // start and end position of the lane
            //    vLaneTrajectory: CreateCurve((2,-4),(2,-2),(2,1),(2,2)),
            //    vTerrainTile: new RelTile2i(-100,-100),
            //    vlanetype1: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
            //    vlanetype2: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
            //    vLaneIndex: 2,
            //    vIsAtStart: true,
            //    vHeightCurve: CreateCurve((0,3), (2,3), (8,3), (12,3))
            //    ),
            //// lane 4 left
            //new roadsUtil.mLaneData(
            //    // start and end position of the lane
            //    vLaneTrajectory: CreateCurve((2,2),(-1,2),(-2,2),(-4,2)),
            //    vTerrainTile: new RelTile2i(-100,-100),
            //    vlanetype1: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
            //    vlanetype2: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
            //    vLaneIndex: 3,
            //    vIsAtStart: false,
            //    vHeightCurve: CreateCurve((0,3), (2,3), (8,3), (12,3))
            //    )
       };

        string[] Road1StraightSmall =
           {
               "_5=_5=_5=_5=_5=",
               "_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=",
               "_5=_5=_5=_5=_5=",
            };

        roadsUtil.mLaneData[] laneStraightSmall = new roadsUtil.mLaneData[]
{
            // lane 1 goin up
            new roadsUtil.mLaneData(
                // start and end position of the lane
                vLaneTrajectory: CreateCurve((-2,0),(-1,0),(1,0),(3,0)),
                vTerrainTiles: new roadsUtil.terrainGraph[]
                {
                    new roadsUtil.terrainGraph(0, new RelTile2f(-2,1), true),
                    new roadsUtil.terrainGraph(0, new RelTile2f(3,0), false)
                },
                // as ramp ill define it the start as terrain connection and the end as elevated.
                vlanetype1: RoadLaneType.MaskAllowAll | RoadLaneType.ElevatedLaneFlag ,
                vlanetype2: RoadLaneType.MaskAllowAll | RoadLaneType.ElevatedLaneFlag,
                // vreversed: If it is a 2nd lane for the returning lane on the same layout of the road.
                vHeightCurve: CreateCurve((0,3), (2,3), (6,3), (8,3))
                ),
            new roadsUtil.mLaneData(
                // start and end position of the lane
                vLaneTrajectory: CreateCurve((3,1),(1,1),(-1,1),(-2,1)),
                vTerrainTiles: new roadsUtil.terrainGraph[]
                {
                    new roadsUtil.terrainGraph(1, new RelTile2f(-2,3), false)
                },
                // as ramp ill define it the start as terrain connection and the end as elevated.
                vlanetype1: RoadLaneType.MaskAllowAll | RoadLaneType.ElevatedLaneFlag,
                vlanetype2: RoadLaneType.MaskAllowAll | RoadLaneType.ElevatedLaneFlag,
                // vreversed: If it is a 2nd lane for the returning lane on the same layout of the road.
                vHeightCurve: CreateCurve((0,3), (2,3), (6,3), (8,3))
                )
            //new roadsUtil.mLaneData(
            //    // start and end position of the lane
            //    vLaneTrajectory: CreateCurve((0,4),(0,2),(0,-2),(0,-5)),
            //    vTerrainTiles: new roadsUtil.terrainGraph[]
            //    {
            //        new roadsUtil.terrainGraph(2, new RelTile2f(0,7), true),
            //        new roadsUtil.terrainGraph(2, new RelTile2f(0,-5), false)
            //    },
            //    // as ramp ill define it the start as terrain connection and the end as elevated.
            //    vlanetype1: RoadLaneType.MaskAllowAll | RoadLaneType.ElevatedLaneFlag,
            //    vlanetype2: RoadLaneType.MaskAllowAll | RoadLaneType.ElevatedLaneFlag,
            //    // vreversed: If it is a 2nd lane for the returning lane on the same layout of the road.
            //    vHeightCurve: CreateCurve((0,1), (2,1), (6,1), (10,1))
            //    ),
            //new roadsUtil.mLaneData(
            //    // start and end position of the lane
            //    vLaneTrajectory: CreateCurve((1,-5),(1,-2),(1,2),(1,4)),
            //    vTerrainTiles: new roadsUtil.terrainGraph[]
            //    {
            //        new roadsUtil.terrainGraph(3, new RelTile2f(3,7), false)
            //    },
            //    // as ramp ill define it the start as terrain connection and the end as elevated.
            //    vlanetype1: RoadLaneType.MaskAllowAll | RoadLaneType.ElevatedLaneFlag,
            //    vlanetype2: RoadLaneType.MaskAllowAll | RoadLaneType.ElevatedLaneFlag,
            //    // vreversed: If it is a 2nd lane for the returning lane on the same layout of the road.
            //    vHeightCurve: CreateCurve((0,1), (2,1), (6,1), (10,1))
            //    )

};



        string[] Road1CornerLayoutSmall =
           {
               "_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=",
            };


        string[] Road1TSection =
        {
               "_4=_4=_4=_4=_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=_4=_4=_4=_4="

        };

        string[] Road1Cross =
        {
               "_4=_4=_4=_4=_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=_4=_4=_4=_4=",
               "_4=_4=_4=_4=_4=_4=_4=_4=_4="

        };
        string[] Road1Single =
        {
                "_4=_4=",
                "_4=_4=",
                "_4=_4=",
                "_4=_4=",
                "_4=_4=",
                "_4=_4=",
                "_4=_4="
        };

        string[] Road1Entrance =
{    // heights  0            1           2           3
  
                        //"_1__1_<R0<R0<R1<R1<R1<R2<R2<R2<R2<R3<R3<R3<R3_4=",
                        //"_1__1_<R0<R0<R1<R1<R1<R2<R2<R2<R2<R3<R3<R3<R3_4=",
                        //"_1__1_<R0<R0<R1<R1<R1<R2<R2<R2<R2<R3<R3<R3<R3_4=",
                        //"_1__1_<R0<R0<R1<R1<R1<R2<R2<R2<R2<R3<R3<R3<R3_4=",
                        //"_1__1_<R0<R0<R1<R1<R1<R2<R2<R2<R2<R3<R3<R3<R3_4=",
                        //"_1__1_<R0<R0<R1<R1<R1<R2<R2<R2<R2<R3<R3<R3<R3_4=",
                        //"_1__1_<R0<R0<R1<R1<R1<R2<R2<R2<R2<R3<R3<R3<R3_4=",
                        //"_1__1_<R0<R0<R1<R1<R1<R2<R2<R2<R2<R3<R3<R3<R3_4=",
                        //"_1__1_<R0<R0<R1<R1<R1<R2<R2<R2<R2<R3<R3<R3<R3_4=",

                        "_1__1_<R0<R0<R1<R1<R1<R2<R2<R2<R2<R3<R3<R3<R3_4=",
                        "_1__1_<R0<R0<R1<R1<R1<R2<R2<R2<R2<R3<R3<R3<R3_4=",
                        "_1__1_<R0<R0<R1<R1<R1<R2<R2<R2<R2<R3<R3<R3<R3_4=",
                        "_1__1_<R0<R0<R1<R1<R1<R2<R2<R2<R2<R3<R3<R3<R3_4=",
                        "_1__1_-5--5--5--5--5--5--5--5--5--5--5--5--5--5-",
                        "_1__1_<R0<R0<R1<R1<R1<R2<R2<R2<R2<R3<R3<R3<R3_4=",
                        "_1__1_<R0<R0<R1<R1<R1<R2<R2<R2<R2<R3<R3<R3<R3_4=",
                        "_1__1_<R0<R0<R1<R1<R1<R2<R2<R2<R2<R3<R3<R3<R3_4=",
                        "_1__1_<R0<R0<R1<R1<R1<R2<R2<R2<R2<R3<R3<R3<R3_4=",

                };

        roadsUtil.mLaneData[] laneRoad1Entrance = new roadsUtil.mLaneData[2]
        {
            // lane 1 goin up
            new roadsUtil.mLaneData(
                // start and end position of the lane
                vLaneTrajectory: CreateCurve((-5,-1),(-3,-1),(3,-1),(8,-1)),
                vTerrainTiles: new roadsUtil.terrainGraph[]
                {
                    new roadsUtil.terrainGraph(0, new RelTile2f(-2,2), true),
                    new roadsUtil.terrainGraph(0, new RelTile2f(16,2), false),
                    new roadsUtil.terrainGraph(1, new RelTile2f(16,6), true)
                },
                // as ramp ill define it the start as terrain connection and the end as elevated.
                vlanetype1: RoadLaneType.MaskAllowAll| RoadLaneType.TerrainConnectionFlag ,
                vlanetype2: RoadLaneType.MaskAllowAll | RoadLaneType.ElevatedLaneFlag ,
                vHeightCurve: CreateCurve((0,3), (4,3), (8,3), (15,3))
                ),

                new roadsUtil.mLaneData(
                // start and end position of the lane
                vLaneTrajectory: CreateCurve((8,2),(3,2),(-3,2),(-5,2)),
                //vTerrainTile: new RelTile2i(-1,7),
                vTerrainTiles: new roadsUtil.terrainGraph[]
                {
                    new roadsUtil.terrainGraph(1, new RelTile2f(-2,6), false)
                },
                // as ramp ill define it the start as terrain connection and the end as elevated.
                vlanetype1: RoadLaneType.MaskAllowAll | RoadLaneType.ElevatedLaneFlag,
                vlanetype2: RoadLaneType.MaskAllowAll | RoadLaneType.TerrainConnectionFlag,

                vHeightCurve: CreateCurve((15,3), (8,3), (4,3), (0,3))
                )
        };

        string[] Road1EntranceShort =
        {

                "(W)(W)(W)(W)(W)(W)(W)(W)",
                ".1a.3a.1b.3b.1c.3c.5c.5c",
                ".1a.3a.1b.3b.1c.3c.5c.5c",
                ".1a.3a.1b.3b.1c.3c.5c.5c",
                "(W)(W)(W)(W)(W)(W)(W)(W)",

        };
        roadsUtil.mLaneData[] entranceShort = new roadsUtil.mLaneData[]
        {
            // lane 1 goin up
            new roadsUtil.mLaneData(
                // start and end position of the lane
                vLaneTrajectory: CreateCurve((-4,0),(-1,0),(1,0),(4,0)),
                vTerrainTiles: new roadsUtil.terrainGraph[]
                {
                    new roadsUtil.terrainGraph(0, new RelTile2f(-2,1), true)
                },
                // as ramp ill define it the start as terrain connection and the end as elevated.
                vlanetype1: RoadLaneType.MaskAllowAll | RoadLaneType.TerrainConnectionFlag ,
                vlanetype2: RoadLaneType.MaskAllowAll | RoadLaneType.ElevatedLaneFlag,
                // vreversed: If it is a 2nd lane for the returning lane on the same layout of the road.
                vHeightCurve: CreateCurve((0,3), (2,3), (6,3), (8,3))
                ),
            new roadsUtil.mLaneData(
                // start and end position of the lane
                vLaneTrajectory: CreateCurve((4,1),(1,1),(-1,1),(-4,1)),
                vTerrainTiles: new roadsUtil.terrainGraph[]
                {
                    new roadsUtil.terrainGraph(1, new RelTile2f(-2,3), false)
                },
                // as ramp ill define it the start as terrain connection and the end as elevated.
                vlanetype1: RoadLaneType.MaskAllowAll | RoadLaneType.ElevatedLaneFlag,
                vlanetype2: RoadLaneType.MaskAllowAll | RoadLaneType.TerrainConnectionFlag,
                // vreversed: If it is a 2nd lane for the returning lane on the same layout of the road.
                vHeightCurve: CreateCurve((0,3), (2,3), (6,3), (8,3))
                )
        };
        string[] layRoad1ShortBrigde1 =
        {

                "(W)(W)(W)(W)(W)(W)(W)(W)_5=_5=_5=_5=_5=(W)(W)(W)(W)(W)(W)(W)(W)",
                ".1a.3a.1b.3b.1c.3c.5c.5c_4=_4=_4=_4=_4=.5c.5c.3c.1c.3b.1b.3a.1a",
                ".1a.3a.1b.3b.1c.3c.5c.5c_4=_4=_4=_4=_4=.5c.5c.3c.1c.3b.1b.3a.1a",
                ".1a.3a.1b.3b.1c.3c.5c.5c_4=_4=_4=_4=_4=.5c.5c.3c.1c.3b.1b.3a.1a",
                "(W)(W)(W)(W)(W)(W)(W)(W)_5=_5=_5=_5=_5=(W)(W)(W)(W)(W)(W)(W)(W)",

        };
        roadsUtil.mLaneData[] lanesRoad1ShortBridge1 = new roadsUtil.mLaneData[]
        {
            // lane 1 goin up
            new roadsUtil.mLaneData(
                // start and end position of the lane
                vLaneTrajectory: CreateCurve((-10,0),(-5,0),(9,0),(11,0)),
                vTerrainTiles: new roadsUtil.terrainGraph[]
                {
                    new roadsUtil.terrainGraph(0, new RelTile2f(-2,1), true)
                    //new roadsUtil.terrainGraph(0, new RelTile2f(22,1), false)
                },
                // as ramp ill define it the start as terrain connection and the end as elevated.
                vlanetype1: RoadLaneType.MaskAllowAll | RoadLaneType.TerrainConnectionFlag ,
                vlanetype2: RoadLaneType.MaskAllowAll | RoadLaneType.ElevatedLaneFlag,
                // vreversed: If it is a 2nd lane for the returning lane on the same layout of the road.
                vHeightCurve: CreateCurve((0,3), (10,3), (20,3), (40,3))
                ),
            new roadsUtil.mLaneData(
                // start and end position of the lane
                vLaneTrajectory: CreateCurve((11,1),(9,1),(-5,1),(-10,1)),
                vTerrainTiles: new roadsUtil.terrainGraph[]
                {
                    new roadsUtil.terrainGraph(1, new RelTile2f(-2,3), false)
                    //new roadsUtil.terrainGraph(1, new RelTile2f(22,3), true)
                },
                // as ramp ill define it the start as terrain connection and the end as elevated.
                vlanetype1: RoadLaneType.MaskAllowAll | RoadLaneType.ElevatedLaneFlag,
                vlanetype2: RoadLaneType.MaskAllowAll | RoadLaneType.TerrainConnectionFlag,
                // vreversed: If it is a 2nd lane for the returning lane on the same layout of the road.
                vHeightCurve: CreateCurve((0,3), (10,3), (20,3), (40,3))
                )
        };

        string[] layoutTestGround =
        {

                //"xbxxbxxbxxbxxbxxbxxbxxbx",
                //".1a.3a.1b.3b.1c.3c.5c.5c",
                //".1a.3a.1b.3b.1c.3c.5c.5c",
                //".1a.3a.1b.3b.1c.3c.5c.5c",
                //"xbxxbxxbxxbxxbxxbxxbxxbx"

            // based on center tile, may y have to change the layout to fit the center
            //   -2 -1  0  1  2
                "xbx.1a.1a.1a.1a.1a.1axbx", // -3
                "xbx.1a.1a.1a.1a.1a.1axbx", // -3
                "xbx.3a.3a.3a.3a.3a.3axbx", // -2
                "xbx.3a.3a.3a.3a.3a.3axbx", // -2
                "xbx.1b.1b.1b.1b.1b.1bxbx", // -1
                "xbx.1b.1b.1b.1b.1b.1bxbx", // -1
                "xbx.3b.3b.3b.3b.3b.3bxbx", //  0
                "xbx.3b.3b.3b.3b.3b.3bxbx", //  0
                "xbx.1c.1c.1c.1c.1c.1cxbx", //  1
                "xbx.1c.1c.1c.1c.1c.1cxbx", //  1
                "xbx.3c.3c.3c.3c.3c.3cxbx", //  2
                "xbx.3c.3c.3c.3c.3c.3cxbx", //  2
                "xbx.5c.5c.5c.5c.5c.5cxbx", //  3
                "xbx.5c.5c.5c.5c.5c.5cxbx", //  3
                "xbx.5c.5c.5c.5c.5c.5cxbx",  //  4
                "xbx.5c.5c.5c.5c.5c.5cxbx"  //  4
        };



        string[] Road1Short =
{
               "xbx",
               ".5c",
               ".5c",
               ".5c",
               ".5c",
               ".5c",
               "xbx"
        };



        string[] BillBoard1Lay =
        {
            "=1=[2][6]=1=",
            "=1=[2][6]=1=",
            "=1=[2][6]=1=",
            "=1=[2][6]=1=",
            "=1=[2][6]=1=",
            "=1=[2][6]=1=",
            "=1=[2][6]=1=",
            "=1=[2][6]=1=",
            "=1=[2][6]=1=",
            "=1=[2][6]=1="
        };



        string[] WallA1Blocklay =
        {
            "(W)"
        };


        string[] WallA1CornerLay =
        {
            "(W)"
        };

        string[] WallA1TeeLay =
        {
            "(W)"
        };

        string[] WallA1Largelay =
        {
            "(W)(W)(W)(W)(W)"
        };
        string[] WallA1Hugelay =
        {
            "(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)"
        };

        string[] SeaWall1Largelay =
        {
            "(W)(W)(W)(W)(W)(W)(W)(W)",
            "(W)(W)(W)(W)(W)(W)(W)(W)",
            "(W)(W)(W)(W)(W)(W)(W)(W)",
            "------------------------",
            "------------------------",
            "------------------------"

        };

        string[] SeaWall1LargervLay =
        {
            "........",
            "########",
            "........"
        };

        string[] SeaWall1SmallLay =
        {
            "(W)(W)",
            "(W)(W)",
            "(W)(W)",
            "------",
            "------",
            "------"
        };

        string[] SeaWall1SmallrLay =
        {
            "..",
            "##",
            ".."

        };

        string[] SeaWall1CornerLay =
        {
            "------------------",
            "------------------",
            "------------------",
            "------------------",
            "------------------",
            "------------------"
        };

        string[] SeaWall1CornerRLay =
        {
            ".....",
            "#####",
            "....."
        };

        string[] SeaWall1CornerInvLay =
        {
            "------------------",
            "------------------",
            "------------------",
            "------------------",
            "------------------",
            "------------------"
        };

        string[] SeaWall1CornerInvrLay =
        {
            ".#.",
            ".##",
            "..."
        };

        string[] GroundPeg =
        {
            "[1]"
        };

        string[] GreyStoneLay =
        {
            "------------",
            "------------",
            "------------",
            "------------"
        };

        /*        string[] Bridge1Lay =
                {

                       "(W)(W)(W)(W)(W)(W)(W)(W)",
                       "(W)(W)(W)(W)(W)(W)(W)(W)",
                       "(W)(W)(W)(W)(W)(W)(W)(W)",
                       "(W)(W)(W)(W)(W)(W)(W)(W)",
                       "(W)(W)(W)(W)(W)(W)(W)(W)",
                       "(W)(W)(W)(W)(W)(W)(W)(W)",
                       "(W)(W)(W)(W)(W)(W)(W)(W)",
                       "(W)(W)(W)(W)(W)(W)(W)(W)"
                };*/

        string[] Bridge1rLay =
        {

            "...........",
            "###########",
            "..........."
        };

        string[] MineTowerDecorLay =
            {
            "=1==1==1==1==1==1==1==1==1==1==1==1==1=",
            "=1=                  =1==1==1==1==1==1=",
            "=1=                  =1==1==1==1==1==1=",
            "=1=                  =1==1==1==1==1==1=",
            "=1=                  =1==1==1==1==1==1=",
            "=1=                  =1==1==1==1==1==1=",
            "=1=                  =1==1==1==1==1==1=",
            "=1==1==1==1==1==1==1==1==1==1==1==1==1="
        };

        //        string[] TerrainBuilderLay =
        //        {
        //            "T1TT1T",
        //            "T1TT1T"
        //        };

        //       string[] TerrainBuilderRVL =
        //       {
        //           ".#.",
        //           ".#.",
        //           ".#."
        //       };

        string[] RadioTower =
        {
            "=1==1==1==1==1==1==1==1==1==1=",
            "=1==1==1==1==1==1==1==1==1==1=",
            "=1==1==1==1==1==1==1==1==1==1=",
            "=1==1==1==1==1==1==1==1==1==1=",
            "=1==1==1==1==1==1==1==1==1==1=",
            "=1==1==1==1==1==1==1==1==1==1=",
            "=1==1==1==1==1==1==1==1==1==1=",
            "=1==1==1==1==1==1==1==1==1==1=",
            "=1==1==1==1==1==1==1==1==1==1=",
            "=1==1==1==1==1==1==1==1==1==1="
        };

        string[] windpowerlayout =
        {
            "=1==1==1=",
            "=1==1==1=",
            "=1==1==1="
        };

        EntityCostsTpl roadCosts1 = Build.MaintenanceT1(0).Priority(8).Workers(5).CP(10).Product(10, Ids.Products.ConcreteSlab);
        EntityCostsTpl roadCosts2 = Build.MaintenanceT1(0).Priority(8).Workers(5).CP(20).Product(25, Ids.Products.ConcreteSlab);
        EntityCostsTpl wallCosts1 = Build.MaintenanceT1(0).Priority(8).Workers(2).CP(10).Product(15, Ids.Products.ConcreteSlab);
        EntityCostsTpl wallCosts2 = Build.MaintenanceT1(0).Priority(8).Workers(2).CP(20).Product(15, Ids.Products.ConcreteSlab);
        EntityCostsTpl signCosts1 = Build.MaintenanceT1(0).Priority(8).Workers(1).CP(8);
        EntityCostsTpl powerplantCosts1 = Build.MaintenanceT1(8).Priority(8).Workers(12).CP2(100).Product(240, Ids.Products.Iron).Product(80, Ids.Products.Rubber).Product(400, Ids.Products.ConcreteSlab);


        ImmutableArray<AnimationParams> noLoop = ImmutableArray.Create(new AnimationParams[]
        {
            AnimationParams.RepeatAutoTimes(Duration.FromYears(1))
        });
        ImmutableArray<AnimationParams> Loop = ImmutableArray.Create(new AnimationParams[]
        {
            AnimationParams.Loop(100.Percent(),true,"Rotating")
        });



        // Buildings

        //CreateProto(registrator, BetterLIDs.Buildings.MineTowerDecor, "Mine Tower Decor",MineTowerDecorLay, costs, "Assets/BetterLife/Buildings/MineTowerDecor.prefab", "Assets/BetterLife/Icons/MineTowerDecor.png", BetterLIDs.ToolBars.WallA, 0, 0, 0,noLoop);
        //CreateProto(registrator, BetterLIDs.Buildings.BillBoard1, "BillBoard 1", BillBoard1Lay, costs, "Assets/BetterLife/Buildings/BillBoard1.prefab", "Assets/BetterLife/Icons/BillBoard1.png", BetterLIDs.ToolBars.WallA, 0, 0, 0, noLoop);

        // Roads
        //blRoadEntranceEntityProto T1EntranceShort = CreateRoadEntranceProto(registrator, BetterLIDs.Roads.Road1EntranceShort, "Entrance(small)", Road1EntranceShort, BLCosts.Roads.Tier1, "Assets/BetterLife/Roads/RoadsT1/rampSmall.prefab", "Assets/BetterLife/Icons/RoadsDirt/Road1SmallRamp.png", BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, false, entranceShort);
        ////BLRoadEntranceProto T1EntranceShort = CreateRoadEntranceProto2(registrator, BetterLIDs.Roads.Road1EntranceShort, "Entrance(short)", layoutTestGround, BLCosts.Roads.Tier1, "Assets/BetterLife/Roads/RoadsT1/testGround.prefab", "Assets/BetterLife/Icons/RoadsDirt/Road1SmallRamp.png", BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, false, RoadLaneType.MaskFourTileLane, entranceShort);
        //blRoadEntranceEntityProto T1Entrance = CreateRoadEntranceProto(registrator, BetterLIDs.Roads.Road1Entrance, "Entrance", Road1Entrance, BLCosts.Roads.Tier1, "Assets/BetterLife/Roads/RoadsT1/roadEntrance.prefab", "Assets/BetterLife/Icons/RoadsDirt/Road1LargeRamp.png", BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, false, laneRoad1Entrance);
        ////blRoadEntranceEntityProto T1ShortBridge1 = CreateRoadEntranceProto(registrator, BetterLIDs.Roads.Road1ShortBridge1, "Small Bridge 1", layRoad1ShortBrigde1, BLCosts.Roads.Tier1, "Assets/BetterLife/Roads/RoadsT1/smallBridge1.prefab", "Assets/BetterLife/Icons/RoadsDirt/Road1LargeRamp.png", BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, false, lanesRoad1ShortBridge1);
        ////CreateNewRoad(registrator, BetterLIDs.Roads.Road1Short, "1 block", Road1Short, roadCosts1, "Assets/BetterLife/Roads/RoadsT1/oneblock.prefab", "Assets/BetterLife/Icons/RoadsDirt/Road1StraightShort.png", BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, false, RoadLaneType.BasicLaneFlag,2);
        ////CreateNewRoad(registrator, BetterLIDs.Roads.Road1Single, "2 blocks", Road1Single, roadCosts1, "Assets/BetterLife/Roads/RoadsT1/twoblocks.prefab", "Assets/BetterLife/Icons/RoadsDirt/Road1StraightShort.png", BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, false, RoadLaneType.BasicLaneFlag, 2);


        //blRoadEntityProto T1Straight = CreateRoadProto2(registrator, BetterLIDs.Roads.Road1Straight, "Straight", Road1Straight, BLCosts.Roads.Tier1, "Assets/BetterLife/Roads/RoadsT1/straight.prefab", "Assets/BetterLife/Icons/RoadsDirt/Road1Straight.png", BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, false, laneRoad1Straight);
        ////BLRoadEntranceProto T1Straight = CreateRoadEntranceProto(registrator, BetterLIDs.Roads.Road1Straight, "Straight", Road1Straight, BLCosts.Roads.Tier1, "Assets/BetterLife/Roads/RoadsT1/straight.prefab", "Assets/BetterLife/Icons/RoadsDirt/Road1Straight.png", BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, false, laneRoad1Straight);


        //blRoadEntityProto T1StraightSmall = CreateRoadProto2(registrator, BetterLIDs.Roads.Road1StraightSmall, "Straight Small", Road1StraightSmall, BLCosts.Roads.Tier1, "Assets/BetterLife/Roads/RoadsT1/straightSmall.prefab", "Assets/BetterLife/Icons/RoadsDirt/Road1Straight.png", BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, false, laneStraightSmall);
        ////BLRoadEntranceProto T1StraightSmall = CreateRoadEntranceProto(registrator, BetterLIDs.Roads.Road1StraightSmall, "Straight Small", Road1StraightSmall, BLCosts.Roads.Tier1, "Assets/BetterLife/Roads/RoadsT1/straightSmall.prefab", "Assets/BetterLife/Icons/RoadsDirt/Road1Straight.png", BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, false, laneStraightSmall);

        //blRoadEntityProto T1StraightLarge = CreateRoadProto2(registrator, BetterLIDs.Roads.Road1LargeStraight, "Straight 3x", Road1LargeStraight, BLCosts.Roads.Tier1Large, "Assets/BetterLife/Roads/RoadsT1/largeStraight.prefab", "Assets/BetterLife/Icons/RoadsDirt/Road1StraightLong.png", BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, false, laneRoad1LargeStraight);

        ////BLRoadProto T1Corner = CreateRoadProto2(registrator, BetterLIDs.Roads.Road1Corner, "Corner", Road1CornerLayout, BLCosts.Roads.Tier1, "Assets/BetterLife/Roads/RoadsT1/corner.prefab", "Assets/BetterLife/Icons/RoadsDirt/Road1Corner.png", BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, false, laneRoad1Corner);

        //blRoadEntityProto T1Corner = CreateRoadProto2(registrator, BetterLIDs.Roads.Road1Corner, "Corner", Road1CornerLayout, BLCosts.Roads.Tier1, "Assets/BetterLife/Roads/RoadsT1/straight.prefab", "Assets/BetterLife/Icons/RoadsDirt/Road1Corner.png", BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, false, laneRoad1Corner);


        ////blRoadEntityProto T1CornerSmall = CreateRoadProto(registrator, BetterLIDs.Roads.Road1CornerSmall, "Corner Small", Road1CornerLayoutSmall, BLCosts.Roads.Tier1, "Assets/BetterLife/Roads/RoadsT1/cornerSmall.prefab", "Assets/BetterLife/Icons/RoadsDirt/Road1Corner.png", BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, false, RoadLaneType.MaskAllowAll);

        ////blRoadEntityProto T1TSection = CreateRoadProto(registrator, BetterLIDs.Roads.Road1TSection, "T", Road1TSection, BLCosts.Roads.Tier1, "Assets/BetterLife/Roads/RoadsT1/tsection.prefab", "Assets/BetterLife/Icons/RoadsDirt/Road1TSection.png", BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, false, RoadLaneType.MaskAllowAll);

        ////blRoadEntityProto T1Cross = CreateRoadProto(registrator, BetterLIDs.Roads.Road1Cross, "Cross", Road1Cross, BLCosts.Roads.Tier1, "Assets/BetterLife/Roads/RoadsT1/cross.prefab", "Assets/BetterLife/Icons/RoadsDirt/Road1Cross.png", BetterLIDs.ToolBars.HiddenProto, 0, 0, 0, false, RoadLaneType.MaskAllowAll);

        //CustomEntityPrototype T1Pillar = CreateProto(registrator, BetterLIDs.Roads.Road1Pillar, "Pillar", Road1PillarLayout, BLCosts.Roads.Tier1, "Assets/BetterLife/Roads/RoadsT1/pillar.prefab", "Assets/BetterLife/Icons/RoadsDirt/Road1Pillar.png", BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, noLoop);

        //CustomEntityPrototype T1TSection = CreateProto(registrator, BetterLIDs.Roads.Road1TSection, "Crossing", Road1Straight, BLCosts.Roads.Tier1, "Assets/BetterLife/Roads/RoadsT1/straight.prefab", "Assets/BetterLife/Icons/RoadsDirt/Road1Straight.png", BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, noLoop);

        //T1Entrance.SetNextTierIndirect(T1EntranceShort);
        //T1EntranceShort.SetNextTierIndirect(T1Straight);
        //T1Straight.SetNextTierIndirect(T1StraightLarge);
        //T1StraightLarge.SetNextTierIndirect(T1Corner);
        //T1Corner.SetNextTierIndirect(T1TSection);
        //T1TSection.SetNextTierIndirect(T1Cross);
        //T1Cross.SetNextTierIndirect(T1Pillar);
        //registrator.PrototypesDb.Add(T1EntranceShort);
        //registrator.PrototypesDb.Add(T1StraightSmall);
        ////registrator.PrototypesDb.Add(T1ShortBridge1);
        ////registrator.PrototypesDb.Add(T1CornerSmall);
        //registrator.PrototypesDb.Add(T1Entrance);
        //registrator.PrototypesDb.Add(T1Straight);
        //registrator.PrototypesDb.Add(T1StraightLarge);
        //registrator.PrototypesDb.Add(T1Corner);
        //registrator.PrototypesDb.Add(T1TSection);
        ////registrator.PrototypesDb.Add(T1Cross);
        //registrator.PrototypesDb.Add(T1Pillar);


        //Log.Info("BETTERLIFE ROADS AND SIGNS DEBUG: Finished adding road protos...");



        // Walls
        //Log.Info("BeTTerLife: -------------------------------------------------- Adding walls");

        //CreateWallProto(registrator, BetterLIDs.Walls.WallA1Block, "Wall A - Small", "Retaining Wall", WallA1Blocklay, "Assets/BetterLife/Walls/WallA/WallA_1Block.prefab", "Assets/BetterLife/Icons/Walls/WallA_1Block.png", BetterLIDs.ToolBars.WallA);
        //CreateWallProto(registrator, BetterLIDs.Walls.WallA1Corner, "Wall A - Corner", "Retaining Wall Corner", WallA1CornerLay, "Assets/BetterLife/Walls/WallA/WallA_Corner.prefab", "Assets/BetterLife/Icons/Walls/WallA_Corner.png", BetterLIDs.ToolBars.WallA);
        //CreateWallProto(registrator, BetterLIDs.Walls.WallA1Tee, "Wall A - Tee", "Retaining Wall Tee", WallA1TeeLay, "Assets/BetterLife/Walls/WallA/WallA_Tee.prefab", "Assets/BetterLife/Icons/Walls/WallA_Large.png", BetterLIDs.ToolBars.WallA);
        //CreateWallProto(registrator, BetterLIDs.Walls.WallA1Large, "Wall A - Large", "Retaining Wall Large", WallA1Largelay, "Assets/BetterLife/Walls/WallA/WallA_Large.prefab", "Assets/BetterLife/Icons/Walls/WallA_Large.png", BetterLIDs.ToolBars.WallA);
        //CreateWallProto(registrator, BetterLIDs.Walls.WallA1Huge, "Wall A - Huge", "Retaining Wall Huge", WallA1Hugelay, "Assets/BetterLife/Walls/WallA/WallA_Huge.prefab", "Assets/BetterLife/Icons/Walls/WallA_Huge.png", BetterLIDs.ToolBars.WallA);

        //CreateWallProto(registrator, BetterLIDs.Walls.WallB1Block, "Wall B - Small", "Retaining Wall", WallA1Blocklay, "Assets/BetterLife/Walls/WallB/WallB_1Block.prefab", "Assets/BetterLife/Icons/Walls/WallB_1Block.png", BetterLIDs.ToolBars.WallA);
        //CreateWallProto(registrator, BetterLIDs.Walls.WallB1Corner, "Wall B - Corner", "Retaining Wall Corner", WallA1CornerLay, "Assets/BetterLife/Walls/WallB/WallB_Corner.prefab", "Assets/BetterLife/Icons/Walls/WallB_Corner.png", BetterLIDs.ToolBars.WallA);
        //CreateWallProto(registrator, BetterLIDs.Walls.WallB1Tee, "Wall B - Tee", "Retaining Wall Tee", WallA1TeeLay, "Assets/BetterLife/Walls/WallB/WallB_Tee.prefab", "Assets/BetterLife/Icons/Walls/WallB_Tee.png", BetterLIDs.ToolBars.WallA);
        //CreateWallProto(registrator, BetterLIDs.Walls.WallB1Large, "Wall B - Large", "Retaining Wall Large", WallA1Largelay, "Assets/BetterLife/Walls/WallB/WallB_Large.prefab", "Assets/BetterLife/Icons/Walls/WallB_Large.png", BetterLIDs.ToolBars.WallA);


        // SeaWalls

        //CreateWallProto(registrator, BetterLIDs.Walls.SeaWall1Large, "SeaWall A - Large", SeaWall1Largelay, SeaWall1LargervLay, 8, 4, costs, "Assets/BetterLife/Buildings/SeaWalls/SeaWall1Large.prefab", "TODO", BetterLIDs.ToolBars.WallA,0,0,0);
        //CreateProto(registrator, BetterLIDs.Walls.SeaWall1Large, "SeaWall A - Large", SeaWall1Largelay, costs, "Assets/BetterLife/Buildings/SeaWalls/SeaWall1Large.prefab", "Assets/BetterLife/Icons/SeaWall1Large.png", BetterLIDs.ToolBars.WallA, 0, 0, 0, noLoop);
        //CreateProto(registrator, BetterLIDs.Walls.SeaWall1Short, "SeaWall A - Short", SeaWall1SmallLay, costs, "Assets/BetterLife/Buildings/SeaWalls/SeaWall1Short.prefab", "Assets/BetterLife/Icons/SeaWall1Short.png", BetterLIDs.ToolBars.WallA,0,0,0, noLoop);
        //CreateProto(registrator, BetterLIDs.Walls.SeaWall1Corner, "SeaWall A - Corner", SeaWall1CornerLay, costs, "Assets/BetterLife/Buildings/SeaWalls/SeaWall1Corner.prefab", "Assets/BetterLife/Icons/SeaWall1Corner.png", BetterLIDs.ToolBars.WallA, 0, 0, 0, noLoop);
        //CreateProto(registrator, BetterLIDs.Walls.SeaWall1CornerInv, "SeaWall A - Corner Inverted", SeaWall1CornerInvLay, costs, "Assets/BetterLife/Buildings/SeaWalls/SeaWall1CornerInv.prefab", "Assets/BetterLife/Icons/SeaWall1CornerInv.png", BetterLIDs.ToolBars.WallA, 0, 0, 0, noLoop);

        //CreateProto(registrator, BetterLIDs.Misc.GroundPeg, "Ground Peg", GroundPeg, costs, "Assets/BetterLife/Misc/Misc_GroundPeg.prefab", "Assets/BetterLife/Icons/GroundPeg1.png", BetterLIDs.ToolBars.RoadsDirt,0,0,0, noLoop);

        // Surfaces

        //CreateProto(registrator, BetterLIDs.Surfaces.GreyStone, "GreyStone 4x4", GreyStoneLay, costs, "Assets/BetterLife/Surfaces/Surface_GreyStonePath.prefab", "Assets/BetterLife/Surfaces/Icons/Surface_GreyStone.png", BetterLIDs.ToolBars.WallA, 0, 0, 0, noLoop);

        // Bridges
        //CreateWallProto(registrator, BetterLIDs.Bridges.Bridge1, "Bridge A", Bridge1Lay, Bridge1rLay,10,1, costs, "Assets/BetterLife/Roads/Bridge1.prefab", "TODO", BetterLIDs.ToolBars.RoadsDirt, 0, 0, 0, noLoop);
    }




    public void CreateWallProto(ProtoRegistrator registrato, StaticEntityProto.ID staticId, string protoString, string coment, string[] el, string asp, string ico, Proto.ID cat)
    {
        ProtosDb prototypesDb = registrato.PrototypesDb;
        Predicate<LayoutTile> predicate = null;
        CustomLayoutToken[] array = new CustomLayoutToken[1];
        LocStr1 locStr = Loc.Str1(staticId.ToString() + "__desc", coment, "description of Retaining Wall");
        LocStr locStr2 = LocalizationManager.LoadOrCreateLocalizedString0(staticId.ToString() + "_formatted", locStr.Format(5.ToString()).Value);
        Proto.Str str = Proto.CreateStr(staticId, protoString, locStr2, null);
        StaticEntityProto.ID wallId = staticId;
        ImmutableArray<ToolbarEntryData> categoriesProtos = registrato.GetCategoriesProtos(new Proto.ID[] { cat });
        ImmutableArray<ToolbarEntryData>? immutableArray = new ImmutableArray<ToolbarEntryData>?(categoriesProtos);
        ProtosDb protosDb = prototypesDb;
        StaticEntityProto.ID id = wallId;
        Proto.Str str2 = str;
        EntityLayoutParser layoutParser = (EntityLayoutParser)registrato.LayoutParser;
        EntityCosts entityCosts = Costs.Buildings.RetainingWall1.MapToEntityCosts(registrato);


        array[0] = new CustomLayoutToken("(W)", delegate
        {
            int? num = new int?(-14);
            int? num2 = new int?(6);
            int num3 = -13;
            int num4 = 5;
            LayoutTileConstraint layoutTileConstraint = LayoutTileConstraint.None;
            int? num5 = num;
            int? num6 = num2;
            return new LayoutTokenSpec(num3, num4, layoutTileConstraint, null, num5, num6, null, Ids.TerrainMaterials.Slag, null, false, false, 0);
        });

        protosDb.Add<RetainingWallProto>(new RetainingWallProto(id, str2, layoutParser.ParseLayoutOrThrow(new EntityLayoutParams(predicate, array, false, null, null, delegate (TerrainVertexRel v, char c)
        {
            if (c != '#')
            {
                return v;
            }
            return v.WithExtraConstraint(LayoutTileConstraint.DisableTerrainPhysics);

        }, null, null, null, default), el), entityCosts, new LayoutEntityProto.Gfx(asp, new RelTile3f(0, 0, 0), ico, default(ColorRgba), false, null, immutableArray, true, false, null, null, default(ImmutableArray<string>), null, int.MaxValue)), false);
    }

    // public void CreateWallProto2(ProtoRegistrator registrato, StaticEntityProto.ID id, string coment, string[] el, string[] rvl, int WallL, int collapseThreshold, EntityCostsTpl ecTpl, string asp, string ico, Proto.ID cat, Fix32 nX, Fix32 nY, Fix32 nZ, ImmutableArray<AnimationParams> ap)
    // {
    //     ProtosDb prototypesDB = registrato.PrototypesDb;
    //     LocStr1 locStr = Loc.Str1(coment, "Prevents the sea from eroding terrain boundaries.", "description of Sea Wall");
    //     Proto.Str strings = Proto.CreateStr(id, coment, null, null);
    //     EntityCosts costs = ecTpl.MapToEntityCosts(registrato, false);
    //     ProtosDb protosDb = prototypesDB;
    //     Proto.Str strings4 = strings;
    //     EntityLayoutParser layoutParser = registrato.LayoutParser;
    //     Predicate<LayoutTile> ignoreTilesForCore = null;
    //     CustomLayoutToken[] array = new CustomLayoutTokenxbx;

    //     array[0] = new CustomLayoutToken("(W)", delegate (EntityLayoutParams p, int q)
    //         {
    //             int? minTerrainHeight = new int?(-7);
    //             int? maxTerrainHeight = new int?(3);
    //             int heightFrom = -6;
    //             int heightToExcl = 1;
    //             LayoutTileConstraint constraint = LayoutTileConstraint.NoRubbleAfterCollapse;
    //             int? minTerrainHeight2 = minTerrainHeight;
    //             int? maxTerrainHeight2 = maxTerrainHeight;

    //             return new LayoutTokenSpec(heightFrom, heightToExcl, constraint, null, minTerrainHeight2, maxTerrainHeight2, null, null, null, false, false, 0);
    //         });

    //protosDb.Add<CustomEntityPrototype>(new CustomEntityPrototype(id, strings4, layoutParser.ParseLayoutOrThrow(new EntityLayoutParams(ignoreTilesForCore, array, false, null, null, delegate (TerrainVertexRel v, char c)
    //{
    //	if (c == '#')
    //	{
    //		return v.WithExtraConstraint(LayoutTileConstraint.DisableTerrainPhysics);
    //	}
    //	return v;
    //}, null, null, default(Option<IEnumerable<KeyValuePair<char, int>>>), false),el),
    //          costs, new LayoutEntityProto.Gfx(asp, new RelTile3f(nX, nY, nZ), default(Option<string>), default(ColorRgba), false, null, new ImmutableArray<ToolbarEntryData>?(registrato.GetCategoriesProtos(cat)), true, false, null, null, default(ImmutableArray<string>), int.MaxValue, false), ap),false);

    // }


}
internal class MachineDef : IModData
{
    public static EntityCostsTpl.Builder Build => new EntityCostsTpl.Builder();
    public static EntityCosts RoadCosts => new EntityCosts();




    public void RegisterData(ProtoRegistrator registrator)
    {

        MachineProto cpAssembly = registrator.PrototypesDb.GetOrThrow<MachineProto>(Ids.Machines.AssemblyManual);

        ProtosDb protosDb = registrator.PrototypesDb;

        /*
        ProtosDb prototypesDb = registrator.PrototypesDb;
        ProductProto orThrow = prototypesDb.GetOrThrow<ProductProto>(IdsCore.Products.Electricity);
        ProductProto orThrow2 = registrator.PrototypesDb.GetOrThrow<FluidProductProto>(Ids.Products.FuelGas);
        ProtosDb prototypesDb2 = registrator.PrototypesDb;
        EntityCostsTpl powerplantCosts1 = Build.MaintenanceT1(8).Priority(8).Workers(12).CP2(20).Product(40, Ids.Products.Iron).Product(10, Ids.Products.Rubber).Product(50, Ids.Products.ConcreteSlab);
        ProductProto orThrow3 = prototypesDb.GetOrThrow<ProductProto>(IdsCore.Products.Electricity);
        ProductProto orThrow4 = prototypesDb.GetOrThrow<ProductProto>(Ids.Products.FuelGas);
        ProductProto orThrow5 = prototypesDb.GetOrThrow<ProductProto>(Ids.Products.Water);
        Proto.Str str1 = Proto.CreateStr(BetterLIDs.Machines.ComPowerPlant, "Combined Cyclic Power Plant", "Cyclic Power...", null);

        EntityLayout entityLayout1 = registrator.LayoutParser.ParseLayoutOrThrow(new string[]
        {
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "@F>=1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "@G>=1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=>Y@",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   "
        });
        EntityCosts entityCosts = powerplantCosts1.MapToEntityCosts(registrator, false);
        prototypesDb.Add<Prototypes.PowerExchangerProto>(new Prototypes.PowerExchangerProto
            (BetterLIDs.Machines.ComPowerPlant, str1, entityLayout1, entityCosts, 600.Mw(), 10, orThrow4.WithQuantity(20), orThrow5.WithQuantity(15), orThrow, 10, 10.Seconds(), DestroyReason.UsedAsFuel, ImmutableArray.Empty, new Prototypes.PowerExchangerProto.Gfx
            ("Assets/BetterLife/Buildings/PowerPlant.prefab",
            ImmutableArray.Empty,
            "Assets/Base/Machines/PowerPlant/CombustionEngine/CombustionEngine_Sound.prefab",
            registrator.GetCategoriesProtos(new Proto.ID[] { Ids.ToolbarCategories.MachinesElectricity }), "Assets/BetterLife/Icons/Buildings/PowerPlant.png", false)), false);
        */
    }

}
