using BetterLife.Prototypes;
using Mafi;
using Mafi.Base;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core.Entities.Animations;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Mods;
using Mafi.Core.Ports.Io;
using Mafi.Core.Prototypes;
using Mafi.Localization;
using Mafi.Unity.Ui;
using Mafi.Unity.Ui.Library.Inspectors;
using Mafi.Unity.UiToolkit.Component;
using Mafi.Unity.UiToolkit.Library;
using System;
using static BetterLife.Prototypes.BridgeEntity;

namespace BetterLife_RoadsAndSigns
{
    internal class Bridges : IModData
    {
        public static EntityCostsTpl.Builder Build => new EntityCostsTpl.Builder();
        public static EntityCosts RoadCosts => new EntityCosts();

        public void RegisterData(ProtoRegistrator registrator)
        {
            string[] Bridge1Lay =
            {
            "(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)",
            "(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)",
            "(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)",
            "(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)",
            "(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)",
            "(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)",
            "(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)",
            "(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)",
            "(W)(W)(W)(W)(W)(W)(W)(W)(W)(W)",
        };
            string[] Bridge1LayChanged =
            {
            "[1][1][1][1][1][1][1][1][1][1]",
            ">1>>1>>1>>1>>1>>1>>1>>1>>1>>1>",
            ">1>>1>>1>>1>>1>>1>>1>>1>>1>>1>",
            ">1>>1>>1>>1>>1>>1>>1>>1>>1>>1>",
            "<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<",
            "<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<",
            "<1<<1<<1<<1<<1<<1<<1<<1<<1<<1<",
            "[1][1][1][1][1][1][1][1][1][1]"
        };
            IoPortShapeProto shapeFlat = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Mafi.Base.Ids.IoPortShapes.FlatConveyor);
            IoPortShapeProto shapeLoose = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Mafi.Base.Ids.IoPortShapes.LooseMaterialConveyor);
            IoPortShapeProto shapePipe = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Mafi.Base.Ids.IoPortShapes.Pipe);

            IoPortTemplate[] ports1 = new IoPortTemplate[]
            {
            new IoPortTemplate(new PortSpec('A', IoPortType.Input, shapeFlat, false), new RelTile3i(1, 1, 0), Direction90.MinusY),
            new IoPortTemplate(new PortSpec('B', IoPortType.Input, shapeFlat, false), new RelTile3i(2, 1, 0), Direction90.MinusY),
            new IoPortTemplate(new PortSpec('C', IoPortType.Input, shapeLoose, false), new RelTile3i(3, 1, 0), Direction90.MinusY),
            new IoPortTemplate(new PortSpec('D', IoPortType.Input, shapeLoose, false), new RelTile3i(4, 1, 0), Direction90.MinusY),
            new IoPortTemplate(new PortSpec('E', IoPortType.Input, shapePipe, false), new RelTile3i(5, 1, 0), Direction90.MinusY),
            new IoPortTemplate(new PortSpec('F', IoPortType.Input, shapePipe, false), new RelTile3i(6, 1, 0), Direction90.MinusY),

            new IoPortTemplate(new PortSpec('G', IoPortType.Output, shapeFlat, false), new RelTile3i(1, 8, 0), Direction90.PlusY),
            new IoPortTemplate(new PortSpec('H', IoPortType.Output, shapeFlat, false), new RelTile3i(2, 8, 0), Direction90.PlusY),
            new IoPortTemplate(new PortSpec('I', IoPortType.Output, shapeLoose, false), new RelTile3i(3, 8, 0), Direction90.PlusY),
            new IoPortTemplate(new PortSpec('J', IoPortType.Output, shapeLoose, false), new RelTile3i(4, 8, 0), Direction90.PlusY),
            new IoPortTemplate(new PortSpec('K', IoPortType.Output, shapePipe, false), new RelTile3i(5, 8, 0), Direction90.PlusY),
            new IoPortTemplate(new PortSpec('L', IoPortType.Output, shapePipe, false), new RelTile3i(6, 8, 0), Direction90.PlusY)

            };


            EntityCostsTpl roadCosts1 = Build.MaintenanceT1(0).Priority(8).Workers(0).CP(20).Product(10, Ids.Products.Dirt).Product(10, Ids.Products.Rock);
            EntityCostsTpl roadCosts2 = Build.MaintenanceT1(0).Priority(8).Workers(0).CP(40).Product(25, Ids.Products.Dirt).Product(25, Ids.Products.Rock);
            EntityCostsTpl wallCosts1 = Build.MaintenanceT1(0).Priority(8).Workers(0).CP(10).Product(10, Ids.Products.Dirt).Product(15, Ids.Products.Rock);
            EntityCostsTpl wallCosts2 = Build.MaintenanceT1(0).Priority(8).Workers(0).CP(20).Product(10, Ids.Products.Dirt).Product(15, Ids.Products.Rock);
            EntityCostsTpl signCosts1 = Build.MaintenanceT1(0).Priority(8).Workers(0).CP(8);
            EntityCostsTpl powerplantCosts1 = Build.MaintenanceT1(8).Priority(8).Workers(12).CP2(100).Product(240, Ids.Products.Iron).Product(80, Ids.Products.Rubber).Product(400, Ids.Products.ConcreteSlab);

            ImmutableArray<AnimationParams> Loop = ImmutableArray.Create(new AnimationParams[]
            {
            AnimationParams.Loop(100.Percent(),true,"Rotating")
            });


            //CreateBridge(registrator, BetterLIDs.Bridges.Bridge1Chg, "Bridge Type 1 Driveable", Bridge1LayChanged, roadCosts1, "Assets/BetterLife/Bridges/Bridge1.prefab", "Assets/BetterLife/Icons/Buildings/Bridge1.png", BetterLIDs.ToolBars.WallA, 5, 0, 0, Loop, false, ports1);
            //CreateWallProto(registrator, BetterLIDs.Bridges.Bridge1, "Bridge Builder Type 1", "Bridge Type 1", Bridge1Lay, "Assets/BetterLife/Bridges/BridgeBuilder.prefab", "Assets/BetterLife/Icons/Buildings/Bridge1Builder.png", BetterLIDs.ToolBars.WallA, 5, 0, 0);

        }

        public void CreateWallProto(ProtoRegistrator registrato, StaticEntityProto.ID staticId, string protoString, string coment, string[] el, string asp, string ico, Proto.ID cat, int nx, int ny, int nz)
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

            protosDb.Add<BridgePrototype>(new BridgePrototype(id, str2, layoutParser.ParseLayoutOrThrow(new EntityLayoutParams(predicate, array, false, null, null, delegate (TerrainVertexRel v, char c)
            {
                if (c != '#')
                {
                    return v;
                }
                return v.WithExtraConstraint(LayoutTileConstraint.DisableTerrainPhysics);

            }, null, null, null, default), el), entityCosts, new LayoutEntityProto.Gfx(asp, new RelTile3f(nx, ny, nz), ico, default(ColorRgba), false, null, immutableArray, true, false, null, null, default(ImmutableArray<string>), null, int.MaxValue)), false);
        }

        public void CreateBridge(ProtoRegistrator registrato, StaticEntityProto.ID id, string coment, string[] el, EntityCostsTpl ecTpl, string asp, string ico, Proto.ID cat, Fix32 nX, Fix32 nY, Fix32 nZ, ImmutableArray<AnimationParams> ap, bool isRamp, IoPortTemplate[] ports)
        {


            Predicate<LayoutTile> predicate = null;
            CustomLayoutToken[] array = new CustomLayoutToken[4];
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
            array[3] = new CustomLayoutToken("-0-", delegate (EntityLayoutParams p, int h)
            {
                return new LayoutTokenSpec(0, h);
            });

            EntityLayoutParams entityLayoutParams = new EntityLayoutParams(predicate, array, false, null, null, null, null, null, null, default);
            //EntityLayoutParams entityLayoutParams = new EntityLayoutParams(null, null, false, Ids.TerrainTileSurfaces.Metal1, null, null, null, null, default(Option<IEnumerable<KeyValuePair<char, int>>>), false);
            EntityCostsTpl costs = Build.MaintenanceT1(0).Priority(8).Workers(4).CP(20).Product(100, Ids.Products.Bricks).Product(50, Ids.Products.Rock);

            string[] initLayoutString = el;

            EntityLayout ltemp = registrato.LayoutParser.ParseLayoutOrThrow(entityLayoutParams, el);


            if (isRamp == true)
            {
                EntityLayout entLayout = new EntityLayout(el.ToString(), ltemp.LayoutTiles, ltemp.TerrainVertices, ports.ToImmutableArray(), entityLayoutParams, ltemp.CollapseVerticesThreshold, null);
                Proto.Str ps1 = Proto.CreateStr(id, coment);
                EntityCosts ec1 = ecTpl.MapToEntityCosts(registrato);
                LayoutEntityProto.Gfx lg1 = new LayoutEntityProto.Gfx(
                    prefabPath: asp,
                    prefabOrigin: new RelTile3f(nX, nY, nZ),
                    customIconPath: ico,
                    categories: registrato.GetCategoriesProtos(cat)
                    );

                registrato.PrototypesDb.Add<BridgePrototype>(new BridgePrototype(id, ps1, entLayout, ec1, lg1));
            }
            else
            {
                Proto.Str ps = Proto.CreateStr(id, coment);
                EntityCosts ec = ecTpl.MapToEntityCosts(registrato);
                LayoutEntityProto.Gfx lg = new LayoutEntityProto.Gfx(
                prefabPath: asp,
                prefabOrigin: new RelTile3f(nX, nY, nZ),
                    customIconPath: ico,
                    categories: registrato.GetCategoriesProtos(cat)
                    );
                registrato.PrototypesDb.Add<BridgePrototype>(new BridgePrototype(id, ps, ltemp, ec, lg));

            }
        }

    }
    [GlobalDependency(RegistrationMode.AsAllInterfaces, false, false)]
    internal class bridgeInspector : BaseInspector<BridgeEntity>
    {
        public bridgeInspector(UiContext context) : base(context)
        {
            Label aLabel = new Label().FontBold();
            WindowSize(400.px(), Px.Auto);
            //AddPanelWithHeader(aLabel)
            //   .Title("ROAD".AsLoc());
        }
    }
}