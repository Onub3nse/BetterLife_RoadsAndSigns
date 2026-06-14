using Mafi;
using Mafi.Base;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core.Entities.Animations;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Mods;
using Mafi.Core.Prototypes;
using System;
using static BetterLife_RoadsAndSigns.CustomEntity;


namespace BetterLife_RoadsAndSigns
{
    internal class SignsData : IModData
    {
        public static EntityCostsTpl.Builder Build => new EntityCostsTpl.Builder();


        public void RegisterData(ProtoRegistrator registrator)
        {
            //string[] signLayout =
            //{
            //    "_1="
            //};
            string[] signLayout =
            {
                "_1="
            };
            string[] signLayout2 =
            {
                "|1|"
            };

            string[] indLightLayout =
            {
                "(1)"
            };

            string[] meterLayout =
            {
                "a1="
            };

            ImmutableArray<AnimationParams> infiniLoop = ImmutableArray.Create(new AnimationParams[]
            {
                AnimationParams.RepeatAutoTimes(Duration.FromYears(1))

            });


            EntityCostsTpl costs = Build.CP(2).MaintenanceT1(0).Priority(8).Workers(0);
            
            CreateProto(registrator, BetterLIDs.Signs.Sign_Stop, "STOP", signLayout, costs, "Assets/BetterLife/Signs/sign_stop.prefab", "Assets/BetterLife/IconsRoad/Signs/Sign_Stop.png", BetterLIDs.ToolBars.Signs_Directions, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_Fwd, "Forward", signLayout, costs, "Assets/BetterLife/Signs/sign_forward.prefab", "Assets/BetterLife/IconsRoad/Signs/Sign_Fwd.png", BetterLIDs.ToolBars.Signs_Directions, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_Lft, "Left/Right", signLayout, costs, "Assets/BetterLife/Signs/sign_left.prefab", "Assets/BetterLife/IconsRoad/Signs/Sign_Lft.png", BetterLIDs.ToolBars.Signs_Directions, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_Rocks, "Rocks", signLayout, costs, "Assets/BetterLife/Signs/sign_rocks.prefab", "Assets/BetterLife/IconsRoad/Signs/Sign_Rocks.png", BetterLIDs.ToolBars.Signs_Misc, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_Drop, "Drop", signLayout, costs, "Assets/BetterLife/Signs/sign_drop.prefab", "Assets/BetterLife/IconsRoad/Signs/Sign_Drop.png", BetterLIDs.ToolBars.Signs_Misc, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_Highway, "Highway", signLayout, costs, "Assets/BetterLife/Signs/Sign_Highway.prefab", "Assets/BetterLife/IconsRoad/Signs/highway.png", BetterLIDs.ToolBars.Signs_Misc, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_Limit50, "Limit 50", signLayout, costs, "Assets/BetterLife/Signs/sign_50.prefab", "Assets/BetterLife/IconsRoad/Signs/limit50.png", BetterLIDs.ToolBars.Signs_SpeedLimits, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_Limit80, "Limit 80", signLayout, costs, "Assets/BetterLife/Signs/sign_80.prefab", "Assets/BetterLife/IconsRoad/Signs/limit80.png", BetterLIDs.ToolBars.Signs_SpeedLimits, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_Limit100, "Limit 100", signLayout, costs, "Assets/BetterLife/Signs/sign_100.prefab", "Assets/BetterLife/IconsRoad/Signs/limit100.png", BetterLIDs.ToolBars.Signs_SpeedLimits, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_Limit120, "Limit 120", signLayout, costs, "Assets/BetterLife/Signs/sign_120.prefab", "Assets/BetterLife/IconsRoad/Signs/limit120.png", BetterLIDs.ToolBars.Signs_SpeedLimits, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_Pedestian, "Pedestian", signLayout, costs, "Assets/BetterLife/Signs/sign_pedestian.prefab", "Assets/BetterLife/IconsRoad/Signs/pedestian.png", BetterLIDs.ToolBars.Signs_Misc, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_Train, "Train", signLayout, costs, "Assets/BetterLife/Signs/Sign_Train.prefab", "Assets/BetterLife/IconsRoad/Signs/Sign_Train.png", BetterLIDs.ToolBars.Signs_Misc, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_Tunnel, "Tunnel", signLayout, costs, "Assets/BetterLife/Signs/sign_tunnel.prefab", "Assets/BetterLife/IconsRoad/Signs/tunnel.png", BetterLIDs.ToolBars.Signs_Misc, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_Workers, "Workers", signLayout, costs, "Assets/BetterLife/Signs/sign_workers.prefab", "Assets/BetterLife/IconsRoad/Signs/workers.png", BetterLIDs.ToolBars.Signs_Misc, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_WrongWay, "Wrong Way", signLayout, costs, BetterLIDs.dPath.sign_wrongWay.asset, BetterLIDs.dPath.sign_wrongWay.icon, BetterLIDs.ToolBars.Signs_Directions, 0, 0, 0, infiniLoop);

            CreateProto(registrator, BetterLIDs.Signs.Sign_50plus, "Limit > 50", signLayout, costs, BetterLIDs.dPath.sign_50plus.asset, BetterLIDs.dPath.sign_50plus.icon, BetterLIDs.ToolBars.Signs_SpeedLimits, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_80plus, "Limit > 80", signLayout, costs, BetterLIDs.dPath.sign_80plus.asset, BetterLIDs.dPath.sign_80plus.icon, BetterLIDs.ToolBars.Signs_SpeedLimits, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_100plus, "Limit > 100", signLayout, costs, BetterLIDs.dPath.sign_100plus.asset, BetterLIDs.dPath.sign_100plus.icon, BetterLIDs.ToolBars.Signs_SpeedLimits, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_120plus, "Limit > 120 ", signLayout, costs, BetterLIDs.dPath.sign_120plus.asset, BetterLIDs.dPath.sign_120plus.icon, BetterLIDs.ToolBars.Signs_SpeedLimits, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_Port, "Port", signLayout, costs, BetterLIDs.dPath.sign_port.asset, BetterLIDs.dPath.sign_port.icon, BetterLIDs.ToolBars.Signs_Buildings, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_Parking, "Parking", signLayout, costs, BetterLIDs.dPath.sign_parking.asset, BetterLIDs.dPath.sign_parking.icon, BetterLIDs.ToolBars.Signs_Buildings, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_BiDir, "Priority", signLayout, costs, BetterLIDs.dPath.sign_priority.asset, BetterLIDs.dPath.sign_priority.icon, BetterLIDs.ToolBars.Signs_Directions, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_Directional1, "Directional", signLayout, costs, BetterLIDs.dPath.sign_directional1.asset, BetterLIDs.dPath.sign_directional1.icon, BetterLIDs.ToolBars.Signs_Directions, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_CedaElPaso, "Give Way", signLayout, costs, BetterLIDs.dPath.sign_pref.asset, BetterLIDs.dPath.sign_pref.icon, BetterLIDs.ToolBars.Signs_Directions, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_MainRoad, "Main Road", signLayout, costs, BetterLIDs.dPath.sign_youpref.asset, BetterLIDs.dPath.sign_youpref.icon, BetterLIDs.ToolBars.Signs_Directions, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_DeadEndLeft, "Dead End Left", signLayout, costs, BetterLIDs.dPath.sign_deadendLeft.asset, BetterLIDs.dPath.sign_deadendLeft.icon, BetterLIDs.ToolBars.Signs_Directions, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_DeadEnd, "Dead End", signLayout, costs, BetterLIDs.dPath.sign_deadend.asset, BetterLIDs.dPath.sign_deadend.icon, BetterLIDs.ToolBars.Signs_Directions, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_ForwardRight, "Forward / Right", signLayout, costs, BetterLIDs.dPath.sign_forwardRight.asset, BetterLIDs.dPath.sign_forwardRight.icon, BetterLIDs.ToolBars.Signs_Directions, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_FuelDiesel, "Fuel Diesel", signLayout, costs, BetterLIDs.dPath.sign_fueldiesel.asset, BetterLIDs.dPath.sign_fueldiesel.icon, BetterLIDs.ToolBars.Signs_Buildings, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_FuelH2, "Fuel H2", signLayout, costs, BetterLIDs.dPath.sign_fuelh2.asset, BetterLIDs.dPath.sign_fuelh2.icon, BetterLIDs.ToolBars.Signs_Buildings, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_Hospital, "Hospital", signLayout, costs, BetterLIDs.dPath.sign_hospital.asset, BetterLIDs.dPath.sign_hospital.icon, BetterLIDs.ToolBars.Signs_Buildings, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_LeftRight, "Left / Right", signLayout, costs, BetterLIDs.dPath.sign_leftright.asset, BetterLIDs.dPath.sign_leftright.icon, BetterLIDs.ToolBars.Signs_Directions, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_LevelCrossing, "Level Crossing", signLayout, costs, BetterLIDs.dPath.sign_levelcrossing.asset, BetterLIDs.dPath.sign_levelcrossing.icon, BetterLIDs.ToolBars.Signs_Buildings, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_NoRight, "Right Not Allowed", signLayout, costs, BetterLIDs.dPath.sign_noright.asset, BetterLIDs.dPath.sign_noright.icon, BetterLIDs.ToolBars.Signs_Directions, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_TrainModern, "Train 2", signLayout, costs, BetterLIDs.dPath.sign_trainModern.asset, BetterLIDs.dPath.sign_trainModern.icon, BetterLIDs.ToolBars.Signs_Buildings, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_100m, "Distance 100m", signLayout, costs, BetterLIDs.dPath.sign_100m.asset, BetterLIDs.dPath.sign_100m.icon, BetterLIDs.ToolBars.Signs_Misc, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_200m, "Distance 200m", signLayout, costs, BetterLIDs.dPath.sign_200m.asset, BetterLIDs.dPath.sign_200m.icon, BetterLIDs.ToolBars.Signs_Misc, 0, 0, 0, infiniLoop);
            CreateProto(registrator, BetterLIDs.Signs.Sign_300m, "Distance 300m", signLayout, costs, BetterLIDs.dPath.sign_300m.asset, BetterLIDs.dPath.sign_300m.icon, BetterLIDs.ToolBars.Signs_Misc, 0, 0, 0, infiniLoop);
        }


        public void CreateProto(ProtoRegistrator registrato, StaticEntityProto.ID id, string coment, string[] el, EntityCostsTpl ecTpl, string asp, string ico, Proto.ID cat, Fix32 nX, Fix32 nY, Fix32 nZ, ImmutableArray<AnimationParams> ap)
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
            array[2] = new CustomLayoutToken("---", delegate (EntityLayoutParams p0, int p1)
            {
                int? minTerrainHeight = new int?(-10);
                int? maxTerrainHeight = new int?(3);
                int num = -9;
                int num2 = 3;
                LayoutTileConstraint layoutTileConstraint = LayoutTileConstraint.None;
                int? num3 = minTerrainHeight;
                int? num4 = maxTerrainHeight;
                return new LayoutTokenSpec(num, num2, layoutTileConstraint, null, num3, num4, null, null, null, false, false, 0);
            });
            array[3] = new CustomLayoutToken("_0=", delegate (EntityLayoutParams p, int h)
            {
                int heightFrom = h - 1;
                int? maxTerrainHeight3 = new int?(h - 1);
                Fix32? vehicleHeight2 = new Fix32?(h - 1);
                return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.None | LayoutTileConstraint.Ocean, null, null, maxTerrainHeight3, vehicleHeight2, null, null, false, false, 0);
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
            array[5] = new CustomLayoutToken("a0=", delegate (EntityLayoutParams param, int height)
            {
                return new LayoutTokenSpec(0, height, LayoutTileConstraint.None | LayoutTileConstraint.NoRubbleAfterCollapse, null, null, null);
            });

            Predicate<LayoutTile> predicate = null;
            EntityLayoutParams entityLayoutParams = new EntityLayoutParams(predicate, array, false, null, null, null, null, null, null, default);
            //            EntityLayoutParams entityLayoutParams = new EntityLayoutParams(
            ////                customPlacementRange: new ThicknessIRange(0, TransportPillarProto.MAX_PILLAR_HEIGHT.Value - 1),
            //                customPlacementRange: new ThicknessIRange(0, 2),
            //                customTokens: array
            //                );

            //EntityLayoutParams entityLayoutParams = new EntityLayoutParams(null, null, false, Ids.TerrainTileSurfaces.Metal1, null, null, null, null, default(Option<IEnumerable<KeyValuePair<char, int>>>), false);


            string[] initLayoutString = el;
            EntityLayout ltemp = registrato.LayoutParser.ParseLayoutOrThrow(entityLayoutParams, el);

            Proto.Str ps = Proto.CreateStr(id, coment);
            EntityCosts ec = ecTpl.MapToEntityCosts(registrato);
            if (cat != BetterLIDs.ToolBars.HiddenProto)
            {
                LayoutEntityProto.Gfx lg = new LayoutEntityProto.Gfx(
                    prefabPath: asp,
                    prefabOrigin: new RelTile3f(nX, nY, nZ),
                    customIconPath: ico,
                    categories: registrato.GetCategoriesProtos(cat)
                    );
                registrato.PrototypesDb.Add<CustomEntityPrototype>(new CustomEntityPrototype(id, ps, ltemp, ec, lg, ap));
            }
            else
            {
                LayoutEntityProto.Gfx lg = new LayoutEntityProto.Gfx(
                    prefabPath: asp,
                    prefabOrigin: new RelTile3f(nX, nY, nZ),
                    customIconPath: ico,
                    categories: ImmutableArray<ToolbarEntryData>.Empty
                    );
                registrato.PrototypesDb.Add<CustomEntityPrototype>(new CustomEntityPrototype(id, ps, ltemp, ec, lg, ap));
            }
            //LayoutEntityProto.Gfx lg = new LayoutEntityProto.Gfx(asp, default(RelTile3f), ico, default(ColorRgba), false, null, new ImmutableArray<ToolbarCategoryProto>?(registrato.GetCategoriesProtos(cat)), false, false, null, null, default(ImmutableArray<string>), int.MaxValue, false);





        }



    }
}
