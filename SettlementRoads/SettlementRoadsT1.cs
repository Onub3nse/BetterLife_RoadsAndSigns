using Mafi;
using Mafi.Base;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core.Buildings.Settlements;
using Mafi.Core.Entities.Animations;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Mods;
using Mafi.Core.Prototypes;
using System;


namespace BetterLife_RoadsAndSigns
{
    internal class SettlementsRoadsT1 : IModData
    {
        public static EntityCostsTpl.Builder Build => new EntityCostsTpl.Builder();

        public void RegisterData(ProtoRegistrator registrator)
        {

            string[] Road1Straight =
                {
                "[1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1]",
                "[1]                                                            [1]               [1]",
                "[1]                                                            [1]               [1]",
                "[1]                                                            [1]               [1]",
                "[1]                                                            [1]               [1]",
                "[1]                                             [1]                              [1]",
                "[1]            [1][1][1]                        [1]                              [1]",
                "[1]            [1]                              [1]                              [1]",
                "[1]            [1]                              [1]                              [1]",
                "[1]            [1]                              [1]                              [1]",
                "[1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1]",
                "<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<",
                "<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<",
                "<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<",
                ">1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>",
                ">1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>",
                ">1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>>1>",
                "[1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1]",
                "[1]                        [1]                           [1]                     [1]",
                "[1]                        [1]                           [1]                     [1]",
                "[1]                        [1]                           [1]                     [1]",
                "[1]                        [1]                                                   [1]",
                "[1]                        [1]                                                   [1]",
                "[1]         [1][1][1][1][1][1]         [1]                                       [1]",
                "[1]                                    [1]                                       [1]",
                "[1]                                    [1]                                       [1]",
                "[1]                                    [1]                                       [1]",
                "[1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1]"
            };

            string[] Road1Cross =
                {
                "[1][1][1][1][1][1][1][1][1][1][1]<1><1><1><1><1><1>[1][1][1][1][1][1][1][1][1][1][1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]            [1]            [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]            [1]            [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]            [1]            [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]            [1]            [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]            [1]            [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]            [1]            [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]            [1]            [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]            [1]            [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]            [1]            [1]",
                "[1][1][1][1][1][1][1][1][1][1][1]<1><1><1><1><1><1>[1][1][1][1][1][1][1][1][1][1][1]",
                "<1<<1<<1<<1<<1<<1<<1<<1<<1<<1><1><1><1><1><1><1><1><1><1><1<<1<<1<<1<<1<<1<<1<<1<<1<",
                "<1<<1<<1<<1<<1<<1<<1<<1<<1<<1><1><1><1><1><1><1><1><1><1><1<<1<<1<<1<<1<<1<<1<<1<<1<",
                "<1<<1<<1<<1<<1<<1<<1<<1<<1<<1><1><1><1><1><1><1><1><1><1><1<<1<<1<<1<<1<<1<<1<<1<<1<",
                ">1>>1>>1>>1>>1>>1>>1>>1>>1><1><1><1><1><1><1><1><1><1><1>>1>>1>>1>>1>>1>>1>>1>>1>>1>",
                ">1>>1>>1>>1>>1>>1>>1>>1>>1><1><1><1><1><1><1><1><1><1><1>>1>>1>>1>>1>>1>>1>>1>>1>>1>",
                ">1>>1>>1>>1>>1>>1>>1>>1>>1><1><1><1><1><1><1><1><1><1><1>>1>>1>>1>>1>>1>>1>>1>>1>>1>",
                "[1][1][1][1][1][1][1][1][1][1][1]<1><1><1><1><1><1>[1][1][1][1][1][1][1][1][1][1][1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]                           [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]                           [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]                           [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]                           [1]",
                "[1][1][1][1][1]               [1]<1><1><1><1><1><1>[1]                           [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]                           [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]                           [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]                           [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]                           [1]",
                "[1][1][1][1][1][1][1][1][1][1][1]<1><1><1><1><1><1>[1][1][1][1][1][1][1][1][1][1][1]"
            };

            string[] Road1TSection =
                {
                "[1][1][1][1][1][1][1][1][1][1][1]<1><1><1><1><1><1>[1][1][1][1][1][1][1][1][1][1][1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]                           [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]                           [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]                           [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]                           [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1][1][1][1][1][1][1]         [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]               [1]         [1]",
                "[1]         [1]               [1]<1><1><1><1><1><1>[1]               [1]         [1]",
                "[1]         [1]               [1]<1><1><1><1><1><1>[1]               [1]         [1]",
                "[1]         [1]               [1]<1><1><1><1><1><1>[1]               [1]         [1]",
                "[1][1][1][1][1][1][1][1][1][1][1]<1><1><1><1><1><1>[1][1][1][1][1][1][1][1][1][1][1]",
                "<1<<1<<1<<1<<1<<1<<1<<1<<1<<1><1><1><1><1><1><1><1><1><1><1<<1<<1<<1<<1<<1<<1<<1<<1<",
                "<1<<1<<1<<1<<1<<1<<1<<1<<1<<1><1><1><1><1><1><1><1><1><1><1<<1<<1<<1<<1<<1<<1<<1<<1<",
                "<1<<1<<1<<1<<1<<1<<1<<1<<1<<1><1><1><1><1><1><1><1><1><1><1<<1<<1<<1<<1<<1<<1<<1<<1<",
                ">1>>1>>1>>1>>1>>1>>1>>1>>1><1><1><1><1><1><1><1><1><1><1>>1>>1>>1>>1>>1>>1>>1>>1>>1>",
                ">1>>1>>1>>1>>1>>1>>1>>1>>1><1><1><1><1><1><1><1><1><1><1>>1>>1>>1>>1>>1>>1>>1>>1>>1>",
                ">1>>1>>1>>1>>1>>1>>1>>1>>1><1><1><1><1><1><1><1><1><1><1>>1>>1>>1>>1>>1>>1>>1>>1>>1>",
                "[1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1]",
                "[1]                              [1]                        [1]                  [1]",
                "[1]                              [1]                        [1]                  [1]",
                "[1]                              [1]                        [1]                  [1]",
                "[1]                              [1]                        [1]                  [1]",
                "[1]                              [1]                                             [1]",
                "[1]                              [1]                                             [1]",
                "[1]                              [1]                                             [1]",
                "[1]                              [1]                                             [1]",
                "[1]                              [1]                                             [1]",
                "[1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1]"
            };

            string[] Road1Corner =
                {
                "[1][1][1][1][1][1][1][1][1][1][1]<1><1><1><1><1><1>[1][1][1][1][1][1][1][1][1][1][1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]                           [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]                           [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]                           [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]                           [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]                           [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]                           [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]                           [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]                           [1]",
                "[1]                           [1]<1><1><1><1><1><1>[1]                           [1]",
                "[1][1][1][1][1][1][1][1][1][1][1]<1><1><1><1><1><1>[1][1][1][1][1][1][1][1][1][1][1]",
                "<1<<1<<1<<1<<1<<1<<1<<1<<1<<1><1><1><1><1><1><1><1>[1]                           [1]",
                "<1<<1<<1<<1<<1<<1<<1<<1<<1<<1><1><1><1><1><1><1><1>[1]                           [1]",
                "<1<<1<<1<<1<<1<<1<<1<<1<<1<<1><1><1><1><1><1><1><1>[1]                           [1]",
                ">1>>1>>1>>1>>1>>1>>1>>1>>1><1><1><1><1><1><1><1><1>[1]                           [1]",
                ">1>>1>>1>>1>>1>>1>>1>>1>>1><1><1><1><1><1><1><1><1>[1]                           [1]",
                ">1>>1>>1>>1>>1>>1>>1>>1>>1><1><1><1><1><1><1><1><1>[1]                           [1]",
                "[1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1]                           [1]",
                "[1]                                       [1]                                    [1]",
                "[1]                                       [1]                                    [1]",
                "[1]                                       [1]                                    [1]",
                "[1]            [1]                        [1]                                    [1]",
                "[1]            [1]                        [1]                                    [1]",
                "[1]            [1]                                                               [1]",
                "[1]            [1]                                                               [1]",
                "[1]            [1]                                                               [1]",
                "[1]            [1]                                                               [1]",
                "[1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1]"
            };



        }
        public void CreateSetProto(ProtoRegistrator registrator, StaticEntityProto.ID id, string coment, string[] el, string asp, string ico)
        {
            ImmutableArray<AnimationParams> noLoop = ImmutableArray.Create(new AnimationParams[]
            {
            AnimationParams.RepeatAutoTimes(Duration.FromYears(1))
            });

            Predicate<LayoutTile> predicate = null;
            CustomLayoutToken[] array = new CustomLayoutToken[3];

            array[0] = new CustomLayoutToken("<0<", delegate (EntityLayoutParams p, int h)
            {
                int heightFrom = h - 1;
                int? maxTerrainHeight3 = new int?(h - 1);
                Fix32? vehicleHeight2 = new Fix32?(h - 1);
                int? minTerrainHeight3 = new int?(-5);
                return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.DisableTerrainPhysics | LayoutTileConstraint.NoRubbleAfterCollapse | LayoutTileConstraint.None, 0, minTerrainHeight3, maxTerrainHeight3, vehicleHeight2, null, BetterLIDs.Surfaces.speed1r, false, false, 0);
            });
            array[1] = new CustomLayoutToken(">0>", delegate (EntityLayoutParams p, int h)
            {
                int heightFrom = h - 1;
                int? maxTerrainHeight4 = new int?(h - 1);
                Fix32? vehicleHeight2 = new Fix32?(h - 1);
                int? minTerrainHeight4 = new int?(-5);
                return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.DisableTerrainPhysics | LayoutTileConstraint.NoRubbleAfterCollapse | LayoutTileConstraint.None, 0, minTerrainHeight4, maxTerrainHeight4, vehicleHeight2, null, BetterLIDs.Surfaces.speed1l, false, false, 0);
            });
            array[2] = new CustomLayoutToken("<0>", delegate (EntityLayoutParams p, int h)
            {
                int heightFrom = h - 1;
                int? maxTerrainHeight5 = new int?(h - 1);
                Fix32? vehicleHeight2 = new Fix32?(h - 1);
                int? minTerrainHeight5 = new int?(-5);
                return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.DisableTerrainPhysics | LayoutTileConstraint.NoRubbleAfterCollapse | LayoutTileConstraint.None, 0, minTerrainHeight5, maxTerrainHeight5, vehicleHeight2, null, BetterLIDs.Surfaces.speed1n, false, false, 0);
            });
            /*            array[3] = new CustomLayoutToken("[0]", delegate (EntityLayoutParams p, int h)
                        {
                            int heightFrom = h - 1;
                            int? maxTerrainHeight5 = new int?(h - 1);
                            Fix32? vehicleHeight2 = new Fix32?(h - 1);
                            int? minTerrainHeight5 = new int?(-5);
                            return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.DisableTerrainPhysics | LayoutTileConstraint.NoRubbleAfterCollapse | LayoutTileConstraint.Ground, 0, minTerrainHeight5, maxTerrainHeight5,0, new Proto.ID?(Ids.TerrainTileSurfaces.Cobblestone), new Proto.ID?(Ids.TerrainTileSurfaces.SettlementPaths), false, false, 0);
                        });
            */
            EntityLayoutParams entityLayoutParams = new EntityLayoutParams(predicate, array, false, null, null, null, null, null, null, default);
            EntityLayout ltemp = registrator.LayoutParser.ParseLayoutOrThrow(entityLayoutParams, el);
            EntityCostsTpl roadCosts1 = Build.MaintenanceT1(0).Priority(8).Workers(0).CP(20).Product(20, Ids.Products.Dirt).Product(40, Ids.Products.Rock);
            Proto.Str ps = Proto.CreateStr(id, coment);
            EntityCosts ec = roadCosts1.MapToEntityCosts(registrator);
            LayoutEntityProto.Gfx lg = new LayoutEntityProto.Gfx
                (
                prefabPath: asp,
                prefabOrigin: new RelTile3f(0, 0, 0),
                customIconPath: ico,
                categories: registrator.GetCategoriesProtos(Ids.ToolbarCategories.Housing)
                );

            registrator.PrototypesDb.Add<SettlementDecorationModuleProto>(new SettlementDecorationModuleProto
                (
                id: id,
                strings: ps,
                layout: ltemp,
                costs: ec,
                upointsBonusToNearbyHousing: new Upoints(0.5.ToFix32()),
                bonusRange: 1,
                graphics: lg
                ));
        }

    }

}
