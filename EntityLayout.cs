using Mafi;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core.Roads;
using Mafi.Curves;

namespace BetterLife_RoadsAndSigns
{
    public partial class btLayouts
    {
        public partial class Layouts
        {
            public static string[] indLight1 =
            {
                "xXx"
            };
            public static string[] bidirCorner =
            {
                "xXxxXxxXxxXxxXxxXxxXxxXxxXx",
                "m2Bm2Bm2Bm2Bm2Bm2Bm2Bm2BxXx",
                "m2Bm2Bm2Bm2Bm2Bm2Bm2Bm2BxXx",
                "m2Bm2Bm2Bm2Bm2Bm2Bm2Bm2BxXx",
                "xXxxXxxXxxXxxXxm2Bm2Bm2BxXx",
                "m2Bm2Bm2Bm2BxXxm2Bm2Bm2BxXx",
                "m2Bm2Bm2Bm2BxXxm2Bm2Bm2BxXx",
                "m2Bm2Bm2Bm2BxXxm2Bm2Bm2BxXx",
                "m2Bm2Bm2Bm2BxXxm2Bm2Bm2BxXx",
            };
            public static string[] bidirTSection =
            {
                "xXxxXxxXxxXxxXxxXxxXxxXxxXx",
                "m2Bm2Bm2Bm2Bm2Bm2Bm2Bm2Bm2B",
                "m2Bm2Bm2Bm2Bm2Bm2Bm2Bm2Bm2B",
                "m2Bm2Bm2Bm2Bm2Bm2Bm2Bm2Bm2B",
                "m2Bm2Bm2Bm2Bm2Bm2Bm2Bm2Bm2B",
                "m2Bm2Bm2Bm2Bm2Bm2Bm2Bm2Bm2B",
                "m2Bm2Bm2Bm2Bm2Bm2Bm2Bm2Bm2B",
                "m2Bm2Bm2Bm2Bm2Bm2Bm2Bm2Bm2B",
                "xXxm2Bm2Bm2Bm2Bm2Bm2Bm2BxXx",
            };
            public static string[] bidirCross =
            {
                "xXxm2Bm2Bm2Bm2Bm2Bm2Bm2BxXx",
                "m2Bm2Bm2Bm2Bm2Bm2Bm2Bm2Bm2B",
                "m2Bm2Bm2Bm2Bm2Bm2Bm2Bm2Bm2B",
                "m2Bm2Bm2Bm2Bm2Bm2Bm2Bm2Bm2B",
                "m2Bm2Bm2Bm2Bm2Bm2Bm2Bm2Bm2B",
                "m2Bm2Bm2Bm2Bm2Bm2Bm2Bm2Bm2B",
                "m2Bm2Bm2Bm2Bm2Bm2Bm2Bm2Bm2B",
                "m2Bm2Bm2Bm2Bm2Bm2Bm2Bm2Bm2B",
                "xXxm2Bm2Bm2Bm2Bm2Bm2Bm2BxXx",
            };
            public static string[] bidirEntrance =
            {
                ".1B.2B.3B.4B.5B.6B.7B",
                ".1B.2B.3B.4B.5B.6B.7B",
                ".1B.2B.3B.4B.5B.6B.7B",
                ".1B.2B.3B.4B.5B.6B.7B",
                ".1B.2B.3B.4B.5B.6B.7B",
                ".1B.2B.3B.4B.5B.6B.7B",
                ".1B.2B.3B.4B.5B.6B.7B",
                ".1B.2B.3B.4B.5B.6B.7B",
                ".1B.2B.3B.4B.5B.6B.7B",
            };
            public static string[] onewayEntrance =
            {
                "x1xx1xx1xx1x",
                ".1A.1A.1A.1A",
                ".1A.1A.1A.1A",
                ".1A.1A.1A.1A",
                ".1A.1A.1A.1A",
                ".1A.1A.1A.1A",
                "x1xx1xx1xx1x",
            };
            public static string[] onewayEntrance2 =
            {
                "x1xx1xx1xx1x",
                ".1A.1A.1A.1A",
                ".1A.1A.1A.1A",
                ".1A.1A.1A.1A",
                ".1A.1A.1A.1A",
                ".1A.1A.1A.1A",
                "x1xx1xx1xx1x",
            };
            public static string[] onewayExit =
            {
                "x1xx1xx1xx1x",
                ".1A.1A.1A.1A",
                ".1A.1A.1A.1A",
                ".1A.1A.1A.1A",
                ".1A.1A.1A.1A",
                ".1A.1A.1A.1A",
                "x1xx1xx1xx1x",
            };  
            public static string[] onewayExit2 =
            {    
                "x1xx1xx1xx1x",
                ".1A.1A.1A.1A",
                ".1A.1A.1A.1A",
                ".1A.1A.1A.1A",
                ".1A.1A.1A.1A",
                ".1A.1A.1A.1A", 
                "x1xx1xx1xx1x",
            };   
            public static string[] onewayCorner =
            {
                "xXxxXxxXxxXxxXxxXxxXx",
                "m1Bm1Bm1Bm1Bm1Bm1BxXx",
                "m1Bm1Bm1Bm1Bm1Bm1BxXx",
                "m1Bm1Bm1Bm1Bm1Bm1BxXx",
                "m1Bm1Bm1Bm1Bm1Bm1BxXx",
                "m1Bm1Bm1Bm1Bm1Bm1BxXx",
                "m1Bm1Bm1Bm1Bm1Bm1BxXx",
            };
            public static string[] onewayCross =
            {
                "xXxm1Bm1Bm1Bm1Bm1BxXx",
                "m1Bm1Bm1Bm1Bm1Bm1Bm1B",
                "m1Bm1Bm1Bm1Bm1Bm1Bm1B",
                "m1Bm1Bm1Bm1Bm1Bm1Bm1B",
                "m1Bm1Bm1Bm1Bm1Bm1Bm1B",
                "m1Bm1Bm1Bm1Bm1Bm1Bm1B",
                "xXxm1Bm1Bm1Bm1Bm1BxXx",
            };
            public static string[] onewayStraight =
            {
                "x1xx1xx1xx1xx1xx1xx1x",
                "m1Bm1Bm1Bm1Bm1Bm1Bm1B",
                "m1Bm1Bm1Bm1Bm1Bm1Bm1B",
                "m1Bm1Bm1Bm1Bm1Bm1Bm1B",
                "m1Bm1Bm1Bm1Bm1Bm1Bm1B",
                "m1Bm1Bm1Bm1Bm1Bm1Bm1B",
                "x1xx1xx1xx1xx1xx1xx1x",
            }; 
            public static string[] onewayStraight2 =
            { 
                "x1xx1xx1xx1xx1x",
                "m1Bm1Bm1Bm1Bm1B",
                "m1Bm1Bm1Bm1Bm1B",
                "m1Bm1Bm1Bm1Bm1B",
                "m1Bm1Bm1Bm1Bm1B",
                "m1Bm1Bm1Bm1Bm1B",
                "x1xx1xx1xx1xx1x",
            };
            public static string[] onewaySlope1 =
            {
                ".1C.2C.3C.4C.5C.6C.7C.8C",
                ".1C.2C.3C.4C.5C.6C.7C.8C",
                ".1C.2C.3C.4C.5C.6C.7C.8C",
                ".1C.2C.3C.4C.5C.6C.7C.8C",
                ".1C.2C.3C.4C.5C.6C.7C.8C",
                ".1C.2C.3C.4C.5C.6C.7C.8C",
                ".1C.2C.3C.4C.5C.6C.7C.8C",

            };
            public static string[] onewaySlope1fake =
            {
                ".1C.1C.1C.1C.1C.1C.1C.1C",
                ".1C.1C.1C.1C.1C.1C.1C.1C",
                ".1C.1C.1C.1C.1C.1C.1C.1C",
                ".1C.1C.1C.1C.1C.1C.1C.1C",
                ".1C.1C.1C.1C.1C.1C.1C.1C",
                ".1C.1C.1C.1C.1C.1C.1C.1C",
                ".1C.1C.1C.1C.1C.1C.1C.1C",
            };
            public static string[] onewayStraightSmall =
            {
                "x1x",
                "m1B",
                "m1B",
                "m1B",
                "m1B",
                "m1B",
                "x1x",
            };
            public static string[] bidirStraight =
            {
                "_2=_2=xXxxXxxXxxXxxXx_2=_2=",
                "_2=m2Bm2Bm2Bm2Bm2Bm2Bm2B_2=",
                "_2=m2Bm2Bm2Bm2Bm2Bm2Bm2B_2=",
                "_2=m2Bm2Bm2Bm2Bm2Bm2Bm2B_2=",
                "_2=m2Bm2Bm2Bm2Bm2Bm2Bm2B_2=",
                "_2=m2Bm2Bm2Bm2Bm2Bm2Bm2B_2=",
                "_2=m2Bm2Bm2Bm2Bm2Bm2Bm2B_2=",
                "_2=m2Bm2Bm2Bm2Bm2Bm2Bm2B_2=",
                "_2=_2=xXxxXxxXxxXxxXx_2=_2=",
            };
            public static string[] onewayTee =
            {
                "xXxxXxxXxxXxxXxxXxxXx",
                "m1Bm1Bm1Bm1Bm1Bm1Bm1B",
                "m1Bm1Bm1Bm1Bm1Bm1Bm1B",
                "m1Bm1Bm1Bm1Bm1Bm1Bm1B",
                "m1Bm1Bm1Bm1Bm1Bm1Bm1B",
                "m1Bm1Bm1Bm1Bm1Bm1Bm1B",
                "m1Bm1Bm1Bm1Bm1Bm1Bm1B",
            };
            public static string[] onewayBridge1 =
            {
                "m1B_1=_1=_1=_1=_1=m1B",
                "m1B_1=_1=_1=_1=_1=m1B",
                "m1B_1=_1=_1=_1=_1=m1B",
                "m1B_1=_1=_1=_1=_1=m1B",
                "m1B_1=_1=_1=_1=_1=m1B",
                "m1B_1=_1=_1=_1=_1=m1B",
                "m1B_1=_1=_1=_1=_1=m1B",
            };
            public static string[] onewayEntranceExit =
            {
                "x1xx1xx1xx1x",
                ".1A.1A.1A.1A",
                ".1A.1A.1A.1A",
                ".1A.1A.1A.1A",
                ".1A.1A.1A.1A",
                ".1A.1A.1A.1A",
                "x1xx1xx1xx1x",
            };

            public static string[] onewayEntranceExit2 =
            {
                "x1xx1xx1x",
                ".1A.1A.1A",
                ".1A.1A.1A",
                ".1A.1A.1A",
                ".1A.1A.1A",
                ".1A.1A.1A",
                "x1xx1xx1x",
            };
            public static string[] onewayTrainBridgeEntrance1 =
            {
                "_1__1_.1A.2A.7A.3C.7C.2D.6D.2E.6E.2F.6F.8F_6=_6=",
                "_1__1_.1A.2A.7A.3C.7C.2D.6D.2E.6E.2F.6F.8F_6=_6=",
                "_1__1_.1A.2A.7A.3C.7C.2D.6D.2E.6E.2F.6F.8F_6=_6=",
                "_1__1_.1A.2A.7A.3C.7C.2D.6D.2E.6E.2F.6F.8F_6=_6=",
                "_1__1_.1A.2A.7A.3C.7C.2D.6D.2E.6E.2F.6F.8F_6=_6=",
                "_1__1_.1A.2A.7A.3C.7C.2D.6D.2E.6E.2F.6F.8F_6=_6=",
                "_1__1_.1A.2A.7A.3C.7C.2D.6D.2E.6E.2F.6F.8F_6=_6="
            };
            public static string[] onewayTrainBridgeExit1 =
            {
                "_6=_6=.8F.6F.2F.6E.2E.6D.2D.7C.3C.7A.2A.1A_1__1_",
                "_6=_6=.8F.6F.2F.6E.2E.6D.2D.7C.3C.7A.2A.1A_1__1_",
                "_6=_6=.8F.6F.2F.6E.2E.6D.2D.7C.3C.7A.2A.1A_1__1_",
                "_6=_6=.8F.6F.2F.6E.2E.6D.2D.7C.3C.7A.2A.1A_1__1_",
                "_6=_6=.8F.6F.2F.6E.2E.6D.2D.7C.3C.7A.2A.1A_1__1_",
                "_6=_6=.8F.6F.2F.6E.2E.6D.2D.7C.3C.7A.2A.1A_1__1_",
                "_6=_6=.8F.6F.2F.6E.2E.6D.2D.7C.3C.7A.2A.1A_1__1_"
            };
            public static string[] onewayTrainBridgeStraight1 =
            {
                "m6B_6=_6=_6=_6=_6=m6B",
                "m6B_6=_6=_6=_6=_6=m6B",
                "m6B_6=_6=_6=_6=_6=m6B",
                "m6B_6=_6=_6=_6=_6=m6B",
                "m6B_6=_6=_6=_6=_6=m6B",
                "m6B_6=_6=_6=_6=_6=m6B",
                "m6B_6=_6=_6=_6=_6=m6B", 
            };
            public static string[] onewayTrainBridgeStraight2x =
            {
                "_6=x6x_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=x6x_6=",
                "_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=",
                "_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=",
                "_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=",
                "_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=",
                "_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=",
                "_6=x6x_6=_6=_6=_6=_6=_6=_6=_6=_6=_6=x6x_6=",
            };
            public static string[] onewayTrainBridgeCorner1 =
            {
                "xXxxXxxXxxXxxXxxXxxXx",
                "_6=_6=_6=_6=_6=_6=xXx",
                "_6=_6=_6=_6=_6=_6=xXx",
                "_6=_6=_6=_6=_6=_6=xXx",
                "_6=_6=_6=_6=_6=_6=xXx",
                "_6=_6=_6=_6=_6=_6=xXx",
                "xXx_6=_6=_6=_6=_6=xXx",
            };
            public static string[] roadWayPoint =
            {
                "xXx"
            };

            public static string[] roadFuelStation1 =
            {
                "   (1)(1)(1)(1)(1)",
                "@A>(1)(1)(1)(1)(1)",
                "   (1)(1)(1)(1)(1)",
                "   (1)(1)(1)(1)(1)",
                "   (1)(1)(1)(1)(1)",
                "   (1)(1)(1)(1)(1)",
                "   (1)(1)(1)(1)(1)",
                "   (1)(1)(1)(1)(1)"
            };
            public static string[] rampStart1 =
            {
                ".1E.2E.3E.4E.5E.6E",
                ".1E.2E.3E.4E.5E.6E",
                ".1E.2E.3E.4E.5E.6E",
                ".1E.2E.3E.4E.5E.6E",
                ".1E.2E.3E.4E.5E.6E",
                ".1E.2E.3E.4E.5E.6E",
                ".1E.2E.3E.4E.5E.6E",
            };
            public static string[] rampEnd1 =
            { 
                ".5E.4E.3E.2E.1E_1_",
            };
             public static string [] rampMiddle1 =
             {
                "_3=_3=_3=_3=",
                "_3=_3=_3=_3=",
                "_3=_3=_3=_3=",
                "_3=_3=_3=_3=",
                "_3=_3=_3=_3=",
                "_3=_3=_3=_3=",
                "_3=_3=_3=_3=",
             };
        }
        public partial class RoadLanes
        {
            public static CubicBezierCurve2f CreateCurve((double, double) start, (double, double) c1, (double, double) c2, (double, double) end)
            {
                return new CubicBezierCurve2f(ImmutableArray.Create(new Vector2f(start.Item1.ToFix32(), start.Item2.ToFix32()), new Vector2f(c1.Item1.ToFix32(), c1.Item2.ToFix32()), new Vector2f(c2.Item1.ToFix32(), c2.Item2.ToFix32()), new Vector2f(end.Item1.ToFix32(), end.Item2.ToFix32())));
            }

            public static roadsUtil.mLaneData[] bidirEntrance = new roadsUtil.mLaneData[]
            {
                new roadsUtil.mLaneData(
                    vLaneTrajectory: CreateCurve((-3,-1),(-1,-1),(2,-1),(4,-1)),

                    vTerrainTiles: new roadsUtil.terrainGraph[]
                    {
                        new roadsUtil.terrainGraph(0, new RelTile2f(-3,3), true),
                        new roadsUtil.terrainGraph(0, new RelTile2f(10,3), false)

                    },
                    vlanetype1: RoadLaneType.TerrainConnectionFlag | RoadLaneType.MaskAllowAll,
                    vlanetype2: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                    vHeightCurve: CreateCurve((0,0), (0.25,0), (0.75,0), (1.0,0))
                    ),
                new roadsUtil.mLaneData(
                    vLaneTrajectory: CreateCurve((4,2),(2,2),(-1,2),(-3,2)),
                    vTerrainTiles: new roadsUtil.terrainGraph[]
                    {
                        new roadsUtil.terrainGraph(1, new RelTile2f(10,5), true),
                        new roadsUtil.terrainGraph(1, new RelTile2f(-3,5), false)

                    },
                    vlanetype1: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                    vlanetype2: RoadLaneType.TerrainConnectionFlag| RoadLaneType.MaskAllowAll,
                    vHeightCurve: CreateCurve((1,0), (0.75,0), (0.25,0), (0,0))
                    )
            };

            public static roadsUtil.mLaneData[] onewayEntrance = new roadsUtil.mLaneData[]
            {
            // lane 1 left
            new roadsUtil.mLaneData(
                // start and end position of the lane
                vLaneTrajectory: CreateCurve((-2,1),(-1,1),(0,1),(2,1)),
                vTerrainTiles: new roadsUtil.terrainGraph[]
                {
                    new roadsUtil.terrainGraph(0, new RelTile2f(-3,3), true),
                    new roadsUtil.terrainGraph(0, new RelTile2f(6,3), false)

                }, 
                // as ramp ill define it the start as terrain connection and the end as elevated.
                vlanetype1: RoadLaneType.TerrainConnectionFlag | RoadLaneType.MaskAllowAll,
                vlanetype2: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                vHeightCurve: CreateCurve((0,0), (0.25,0), (0.75,0.5), (1.0,1))
                )

            };

            public static roadsUtil.mLaneData[] onewayExit = new roadsUtil.mLaneData[]
            {
            new roadsUtil.mLaneData(

                vLaneTrajectory: CreateCurve((-2,1),(-1,1),(0,1),(2,1)),
                vTerrainTiles: new roadsUtil.terrainGraph[]
                {
                    new roadsUtil.terrainGraph(0, new RelTile2f(6,3), false),
                    new roadsUtil.terrainGraph(0, new RelTile2f(-3,3), true)

                },
                vlanetype1: RoadLaneType.TerrainConnectionFlag| RoadLaneType.MaskAllowAll,
                vlanetype2: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                vHeightCurve: CreateCurve((0,0), (0.25,0), (0.75,0), (1.0,0))
                )
            };

            public static roadsUtil.mLaneData[] onewayTrainBridgeEntrance1 = new roadsUtil.mLaneData[]
            {
            // lane 1 left
            new roadsUtil.mLaneData(
                // start and end position of the lane
                vLaneTrajectory: CreateCurve((-8,1),(-2,1),(2,1),(8,1)),
                vTerrainTiles: new roadsUtil.terrainGraph[]
                {
                    new roadsUtil.terrainGraph(0, new RelTile2f(-3,3), true),
                    new roadsUtil.terrainGraph(0, new RelTile2f(19,3), false)

                },
                // as ramp ill define it the start as terrain connection and the end as elevated.
                vlanetype1: RoadLaneType.TerrainConnectionFlag | RoadLaneType.MaskAllowAll,
                vlanetype2: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                vHeightCurve: CreateCurve((0,0), (0.25,0), (0.75,0.5), (1.0,1))
                )

            };
            public static roadsUtil.mLaneData[] onewayTrainBridgeExit1 = new roadsUtil.mLaneData[]
            {
            new roadsUtil.mLaneData(

                vLaneTrajectory: CreateCurve((-8,1),(-2,1),(2,1),(8,1)),
                vTerrainTiles: new roadsUtil.terrainGraph[]
                {
                    new roadsUtil.terrainGraph(0, new RelTile2f(18,3), false),
                    new roadsUtil.terrainGraph(0, new RelTile2f(-3,3), true)

                },
                vlanetype1: RoadLaneType.ElevatedLaneFlag| RoadLaneType.MaskAllowAll,
                vlanetype2: RoadLaneType.TerrainConnectionFlag | RoadLaneType.MaskAllowAll,
                vHeightCurve: CreateCurve((0,0), (0.25,0), (0.75,0), (1.0,0))
                )
            };

            public static roadsUtil.mLaneData[] roadWayPoint = new roadsUtil.mLaneData[]
            {
                new roadsUtil.mLaneData
                (
                    vLaneTrajectory: CreateCurve((-1, -1), (0, -1), (1, -1), (2, -1)),
                    vTerrainTiles: new roadsUtil.terrainGraph[]
                    {
                        new roadsUtil.terrainGraph(0, new RelTile2f(-4, -2), true),
                        new roadsUtil.terrainGraph(0, new RelTile2f(4, -2), false),

                    },
                    vlanetype1: RoadLaneType.TerrainConnectionFlag | RoadLaneType.MaskAllowAll,
                    vlanetype2: RoadLaneType.TerrainConnectionFlag | RoadLaneType.MaskAllowAll,
                    vHeightCurve: CreateCurve((0, 0), (0.25, 0), (0.75, 0), (1.0, 0))

                ),
                new roadsUtil.mLaneData
                (
                    vLaneTrajectory: CreateCurve((2, 1), (1, 1), (0, 1), (-1, 1)),
                    vTerrainTiles: new roadsUtil.terrainGraph[]
                    {
                        new roadsUtil.terrainGraph(1, new RelTile2f(4, 2), true),
                        new roadsUtil.terrainGraph(1, new RelTile2f(-4, 2), false),

                    },
                    vlanetype1: RoadLaneType.TerrainConnectionFlag | RoadLaneType.MaskAllowAll,
                    vlanetype2: RoadLaneType.TerrainConnectionFlag | RoadLaneType.MaskAllowAll,
                    vHeightCurve: CreateCurve((0, 0), (0.25, 0), (0.75, 0), (1.0, 0))

                )

            };
            public static roadsUtil.mLaneData[] onewayEntranceExit = new roadsUtil.mLaneData[]
            {
                new roadsUtil.mLaneData(
                    vLaneTrajectory: CreateCurve((-2,0),(-1,0),(0, 0), (2, 0)),

                    vTerrainTiles: new roadsUtil.terrainGraph[]
                    {
                        new roadsUtil.terrainGraph(0, new RelTile2f(-3,3), true),
                        new roadsUtil.terrainGraph(0, new RelTile2f(6,2), false)

                    },
                    vlanetype1: RoadLaneType.TerrainConnectionFlag | RoadLaneType.MaskAllowAll,
                    vlanetype2: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                    vHeightCurve: CreateCurve((0,0), (0.25,0), (0.75,0), (1.0,0))
                    ),
                new roadsUtil.mLaneData(
                    vLaneTrajectory: CreateCurve((2,1),(0,1),(-1,1),(-2,1)),
                    vTerrainTiles: new roadsUtil.terrainGraph[]
                    {
                        new roadsUtil.terrainGraph(1, new RelTile2f(6,4), true),
                        new roadsUtil.terrainGraph(1, new RelTile2f(-3,3), false)

                    },
                    vlanetype1: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                    vlanetype2: RoadLaneType.TerrainConnectionFlag| RoadLaneType.MaskAllowAll,
                    vHeightCurve: CreateCurve((1,0), (0.75,0), (0.25,0), (0,0))
                    )
            };
            public static roadsUtil.mLaneData[] rampStart1 = new roadsUtil.mLaneData[]
            {
                new roadsUtil.mLaneData(
                    vLaneTrajectory: CreateCurve((-3,0),(-1,0),(1, 0), (3, 0)),

                    vTerrainTiles: new roadsUtil.terrainGraph[]
                    {
                        new roadsUtil.terrainGraph(0, new RelTile2f(-3,2), true),
                        new roadsUtil.terrainGraph(0, new RelTile2f(9,3), false)

                    },
                    vlanetype1: RoadLaneType.TerrainConnectionFlag | RoadLaneType.MaskAllowAll,
                    vlanetype2: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                    vHeightCurve: CreateCurve((0,0), (0.25,0), (0.75,0), (1.0,0))
                    ),
                new roadsUtil.mLaneData(
                    vLaneTrajectory: CreateCurve((3,1),(1,1),(-1,1),(-3,1)),
                    vTerrainTiles: new roadsUtil.terrainGraph[]
                    {
                        new roadsUtil.terrainGraph(1, new RelTile2f(9,3), true),
                        new roadsUtil.terrainGraph(1, new RelTile2f(-3,4), false)
  
                    },
                    vlanetype1: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                    vlanetype2: RoadLaneType.TerrainConnectionFlag| RoadLaneType.MaskAllowAll,
                    vHeightCurve: CreateCurve((1,0), (0.75,0), (0.25,0), (0,0))
                    ) 
            };

            public static roadsUtil.mLaneData[] onewaySlope1 = new roadsUtil.mLaneData[]
            {
                new roadsUtil.mLaneData(
                    vLaneTrajectory: CreateCurve((-3,-1),(-1,-1),(2,-1),(4,-1)),

                    vTerrainTiles: new roadsUtil.terrainGraph[]
                    {
                        new roadsUtil.terrainGraph(0, new RelTile2f(-1, 1.3.ToFix32()), true),
                        new roadsUtil.terrainGraph(0, new RelTile2f(7,1.3.ToFix32()), false)

                    },
                    vlanetype1: RoadLaneType.TerrainConnectionFlag | RoadLaneType.MaskAllowAll,
                    vlanetype2: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                    vHeightCurve: CreateCurve((0,0), (0.25,0), (0.75,0), (1.0,0))
                    ),
                new roadsUtil.mLaneData(
                    vLaneTrajectory: CreateCurve((-3,2),(-1,2),(2,2),(4,2)),
                    vTerrainTiles: new roadsUtil.terrainGraph[]
                    {
                        new roadsUtil.terrainGraph(1, new RelTile2f(7,4), true),
                        new roadsUtil.terrainGraph(1, new RelTile2f(-1,4), false)

                    },
                    vlanetype1: RoadLaneType.ElevatedLaneFlag | RoadLaneType.MaskAllowAll,
                    vlanetype2: RoadLaneType.TerrainConnectionFlag| RoadLaneType.MaskAllowAll,
                    vHeightCurve: CreateCurve((1,0), (0.75,0), (0.25,0), (0,0))
                    )
            };

        }
    }

}
