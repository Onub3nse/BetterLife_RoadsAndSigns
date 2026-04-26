namespace BetterLife
{
    /*public partial class BetterLIDs
    {
        public partial class Ramps
        {
            public static readonly BLRoadPrototype.ID ramp1 = new BLRoadPrototype.ID("ramp1");
            public static readonly BLRoadPrototype.ID ramp1Heights = new BLRoadPrototype.ID("ramp1Heights");

            public static readonly string[] ramp1w =
            {
                "<1><1><1><1><2><2><2><3><3><3><4><4><4><5><5><5><6><6><6><7><7><7><8><8><8><9><9><9>",
                "<1><1><1><1><2><2><2><3><3><3><4><4><4><5><5><5><6><6><6><7><7><7><8><8><8><9><9><9>",
                "<1><1><1><1><2><2><2><3><3><3><4><4><4><5><5><5><6><6><6><7><7><7><8><8><8><9><9><9>",
                "<1><1><1><1><2><2><2><3><3><3><4><4><4><5><5><5><6><6><6><7><7><7><8><8><8><9><9><9>",
                "<1><1><1><1><2><2><2><3><3><3><4><4><4><5><5><5><6><6><6><7><7><7><8><8><8><9><9><9>",
                "<1><1><1><1><2><2><2><3><3><3><4><4><4><5><5><5><6><6><6><7><7><7><8><8><8><9><9><9>",
                "<1><1><1><1><2><2><2><3><3><3><4><4><4><5><5><5><6><6><6><7><7><7><8><8><8><9><9><9>",
                "<1><1><1><1><2><2><2><3><3><3><4><4><4><5><5><5><6><6><6><7><7><7><8><8><8><9><9><9>",
                "<1><1><1><1><2><2><2><3><3><3><4><4><4><5><5><5><6><6><6><7><7><7><8><8><8><9><9><9>"
            };
        }
    }*/
    /*internal class Ramps : IModData
    {
        public static EntityCostsTpl.Builder Build => new EntityCostsTpl.Builder();
        public static EntityCosts RoadCosts => new EntityCosts();

        public void RegisterData(ProtoRegistrator registrator)
        {
            string[] ramp1Layout =
                {
                    "(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)",
                    "(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)",
                    "(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)",
                    "(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)",
                    "(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)",
                    "(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)",
                    "(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)",
                    "(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)",
                    "(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)",
                };

            EntityCostsTpl roadCosts1 = Build.MaintenanceT1(0).Priority(8).Workers(0).CP(2).Product(2, Ids.Products.Dirt).Product(4, Ids.Products.Rock);
            ImmutableArray<AnimationParams> Loop = ImmutableArray.Create(new AnimationParams[]
            {
                AnimationParams.Loop(null,false,null)
            });
            Predicate<LayoutTile> predicate = null;
            CustomLayoutToken[] array = new CustomLayoutToken[1];
            CustomLayoutToken[] array2 = new CustomLayoutToken[1];

            array[0] = new CustomLayoutToken("(W)", delegate
            {
                int? num = new int?(-14);
                int? num2 = new int?(6);
                int num3 = -13;
                int num4 = 5;
                LayoutTileConstraint layoutTileConstraint = LayoutTileConstraint.None;
                int? num5 = num;
                int? num6 = num2;
                return new LayoutTokenSpec(num3, num4, layoutTileConstraint, null, num5, num6, 0, Ids.TerrainMaterials.Dirt, null, false, false, 0);
            });

            EntityLayoutParser layoutParser = registrator.LayoutParser;
            ProtosDb protosDb = registrator.PrototypesDb;
            EntityCosts ec = roadCosts1.MapToEntityCosts(registrator);
            ImmutableArray<ToolbarCategoryProto> categoriesProtos = registrator.GetCategoriesProtos(new Proto.ID[] { BetterLIDs.ToolBars.RoadsDirt });
            ImmutableArray<ToolbarCategoryProto>? immutableArray = new ImmutableArray<ToolbarCategoryProto>?(categoriesProtos);

            protosDb.Add<BLRoadPrototype>(new BLRoadPrototype(BetterLIDs.Ramps.ramp1, Proto.CreateStr(BetterLIDs.Ramps.ramp1,"Ramp for Vehicles","Ramp Type 1"), layoutParser.ParseLayoutOrThrow(new EntityLayoutParams(predicate, array, false, null, null, delegate (TerrainVertexRel v, char c)
            {
                if (c != '#')
                {
                    return v;
                }
                return v.WithExtraConstraint(LayoutTileConstraint.DisableTerrainPhysics );

            }, null, null, default(Option<IEnumerable<KeyValuePair<char, int>>>), false), ramp1Layout), ec, new LayoutEntityProto.Gfx("Assets/BetterLife/Ramps/Ramp1.prefab", new RelTile3f(0, 0, 0),"TODO" , default(ColorRgba), false, null, immutableArray, true, false, null, null, default(ImmutableArray<string>), int.MaxValue, false)), false);


            array2[0] = new CustomLayoutToken("<0>", delegate (EntityLayoutParams p, int h)
            {
                int heightFrom = h - 1;
                int? maxTerrainHeight3 = new int?(h - 1);
                Fix32? vehicleHeight2 = new Fix32?(h - 1);
                int? minTerrainHeight3 = new int?(-5);
                return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.NoRubbleAfterCollapse | LayoutTileConstraint.None, null, minTerrainHeight3, maxTerrainHeight3, vehicleHeight2, null, BetterLIDs.Surfaces.speed1r, false, false, 0);
            });

            EntityLayoutParams entityLayoutParams = new EntityLayoutParams(predicate, array2, false, null, null, null, 2, null, default(Option<IEnumerable<KeyValuePair<char, int>>>), false);
            string[] initLayoutString = BetterLIDs.Ramps.ramp1w;
            EntityLayout ltemp = registrator.LayoutParser.ParseLayoutOrThrow(entityLayoutParams, initLayoutString);

            Proto.Str ps = Proto.CreateStr(BetterLIDs.Ramps.ramp1Heights, "fake ramp");
            LayoutEntityProto.Gfx lg = new LayoutEntityProto.Gfx(
                prefabPath: "TODO",
                prefabOrigin: new RelTile3f(0, 0, 0),
                customIconPath: "TODO",
                categories: registrator.GetCategoriesProtos(BetterLIDs.ToolBars.RoadsDirt)
                );
            registrator.PrototypesDb.Add<BLRoadPrototype>(new BLRoadPrototype(BetterLIDs.Ramps.ramp1Heights, ps, ltemp, ec, lg));


        }
        public void CreateRoad(ProtoRegistrator registrato, StaticEntityProto.ID id, string coment, string[] el, EntityCostsTpl ecTpl, string asp, string ico, Proto.ID cat, Fix32 nX, Fix32 nY, Fix32 nZ, ImmutableArray<AnimationParams> ap, bool isRamp)
        {


            Predicate<LayoutTile> predicate = null;
            CustomLayoutToken[] array = new CustomLayoutToken[3];
            array[0] = new CustomLayoutToken("<0<", delegate (EntityLayoutParams p, int h)
            {
                int heightFrom = h - 1;
                int? maxTerrainHeight3 = new int?(h - 1);
                Fix32? vehicleHeight2 = new Fix32?(h - 1);
                int? minTerrainHeight3 = new int?(-5);
                return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.NoRubbleAfterCollapse | LayoutTileConstraint.None, null, minTerrainHeight3, maxTerrainHeight3, vehicleHeight2, null, BetterLIDs.Surfaces.speed1r, false, false, 0);
            });
            array[1] = new CustomLayoutToken(">0>", delegate (EntityLayoutParams p, int h)
            {
                int heightFrom = h - 1;
                int? maxTerrainHeight4 = new int?(h - 1);
                Fix32? vehicleHeight2 = new Fix32?(h - 1);
                int? minTerrainHeight4 = new int?(-5);
                return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.NoRubbleAfterCollapse | LayoutTileConstraint.None, null, minTerrainHeight4, maxTerrainHeight4, vehicleHeight2, null, BetterLIDs.Surfaces.speed1l, false, false, 0);
            });
            array[2] = new CustomLayoutToken("<0>", delegate (EntityLayoutParams p, int h)
            {
                int heightFrom = h - 1;
                int? maxTerrainHeight5 = new int?(h - 1);
                Fix32? vehicleHeight2 = new Fix32?(h - 1);
                int? minTerrainHeight5 = new int?(-5);
                return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.NoRubbleAfterCollapse | LayoutTileConstraint.None, null, minTerrainHeight5, maxTerrainHeight5, vehicleHeight2, null, BetterLIDs.Surfaces.speed1n, false, false, 0);
            });

            EntityLayoutParams entityLayoutParams = new EntityLayoutParams(predicate, array, false, null, null, null, null, null, default(Option<IEnumerable<KeyValuePair<char, int>>>), true);
            //EntityLayoutParams entityLayoutParams = new EntityLayoutParams(null, null, false, Ids.TerrainTileSurfaces.Metal1, null, null, null, null, default(Option<IEnumerable<KeyValuePair<char, int>>>), false);
            EntityCostsTpl costs = Build.MaintenanceT1(0).Priority(8).Workers(4).CP(20).Product(100, Ids.Products.Bricks).Product(50, Ids.Products.Rock);

            string[] initLayoutString = el;
            EntityLayout ltemp = registrato.LayoutParser.ParseLayoutOrThrow(entityLayoutParams, el);

            Proto.Str ps = Proto.CreateStr(id, coment);
            EntityCosts ec = ecTpl.MapToEntityCosts(registrato);
            LayoutEntityProto.Gfx lg = new LayoutEntityProto.Gfx(
                prefabPath: asp,
                prefabOrigin: new RelTile3f(nX, nY, nZ),
                customIconPath: ico,
                categories: registrato.GetCategoriesProtos(cat)
                );
            //LayoutEntityProto.Gfx lg = new LayoutEntityProto.Gfx(asp, default(RelTile3f), ico, default(ColorRgba), false, null, new ImmutableArray<ToolbarCategoryProto>?(registrato.GetCategoriesProtos(cat)), false, false, null, null, default(ImmutableArray<string>), int.MaxValue, false);


            registrato.PrototypesDb.Add<BLRoadPrototype>(new BLRoadPrototype(id, ps, ltemp, ec, lg));

        }
    }
    */
}
