using HarmonyLib;
using Mafi;
using Mafi.Base;
using Mafi.Collections;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Game;
using Mafi.Core.Mods;
using Mafi.Core.Prototypes;
using Mafi.Localization;
using System;
//using static UnityEngine.UI.Image;
namespace BetterLife_RoadsAndSigns
{
    public sealed class BetterLife_RoadsAndSigns : IDisposable, IMod, IModConfig
    {
        public readonly Harmony HarmonyInstance;
        private ModManifest manifest;

        public ModManifest Manifest
        {
            get
            {
                return this.manifest;
            }
        }
        public void ChangeConfigs(Lyst<IConfig> configs)
        {
        }
        public void EarlyInit(DependencyResolver resolver)
        {
        }


        public void Dispose()
        {
        }
        public void MigrateJsonConfig(VersionSlim savedVersion, Dict<string, object> savedValues)
        {
        }
        public Option<IConfig> ModConfig { get; }

        public static Version ModVersion
        {
            get
            {
                return typeof(BetterLife_RoadsAndSigns).Assembly.GetName().Version;
            }
        }
        public string Name
        {
            get
            {
                return typeof(BetterLife_RoadsAndSigns).Assembly.GetName().Name;
            }
        }

        // Token: 0x17000002 RID: 2
        // (get) Token: 0x0600000E RID: 14 RVA: 0x00002240 File Offset: 0x00000440
        public int Version
        {
            get
            {
                return typeof(BetterLife_RoadsAndSigns).Assembly.GetName().Version.Major * 100 + typeof(BetterLife_RoadsAndSigns).Assembly.GetName().Version.Minor * 10 + typeof(BetterLife_RoadsAndSigns).Assembly.GetName().Version.Build;
            }
        }


        public ModJsonConfig JsonConfig
        {
            get
            {
                return new ModJsonConfig(this);
            }
        }

        public BetterLife_RoadsAndSigns(ModManifest modManifest)

        {
            this.manifest = modManifest;
            //Log.Info($"BetterLife: Applying harmony patch...");
            //HarmonyInstance = new Harmony("RoadsAndSigns Harmony Patch");
            //HarmonyInstance.PatchCategory("ClearancePatch");
            //HarmonyInstance.PatchCategory("IoPortPatchCategory");
            //Log.Info($"BetterLife: Harmony patch finished...");
        }

        public bool IsUiOnly => false;

        public void RegisterPrototypes(ProtoRegistrator registrator)
        {
            ProtosDb prototypesDb = registrator.PrototypesDb;

            Log.Info("$BetterLife: Registering toolbars...");
            ToolbarCategoryProto toolbarParent = prototypesDb.Add<ToolbarCategoryProto>(new ToolbarCategoryProto(BetterLIDs.ToolBars.RoadsParent, Proto.CreateStr(BetterLIDs.ToolBars.RoadsParent, "Roads"), 110f, "Assets/BetterLife/Icons/Toolbar/Roads.png", false, "ROADS", null, null, null));
            Proto.ID roadindustrial1 = BetterLIDs.ToolBars.RoadsIndustrial;
            Proto.Str str1 = Proto.CreateStr(BetterLIDs.ToolBars.RoadsIndustrial, "Roads Bidrectional", "", null);

            ToolbarCategoryProto parentCategory1 = toolbarParent;
            prototypesDb.Add<ToolbarCategoryProto>(new ToolbarCategoryProto(roadindustrial1, str1, 110f, "Assets/BetterLife/Icons/Toolbar/toolbar_roadbidir.png", false, "", null, null, parentCategory1));
            Proto.ID roadindustrial2 = BetterLIDs.ToolBars.RoadsDirt;
            Proto.Str str2 = Proto.CreateStr(BetterLIDs.ToolBars.RoadsDirt, "Roads One Way", "", null);

            ToolbarCategoryProto parentCategory2 = toolbarParent;
            prototypesDb.Add<ToolbarCategoryProto>(new ToolbarCategoryProto(roadindustrial2, str2, 110f, "Assets/BetterLife/Icons/Toolbar/toolbar_roadoneway.png", false, "", null, null, parentCategory2));

            Proto.ID roadBridgeSegements = BetterLIDs.ToolBars.RoadsBridgeSegments;
            Proto.Str bridgeSeg = Proto.CreateStrFromLocalized(roadBridgeSegements, "Road Bridge Segments", "To get over train tracks".AsLoc(), null);
            ToolbarCategoryProto parentCategory3 = toolbarParent;
            prototypesDb.Add<ToolbarCategoryProto>(new ToolbarCategoryProto(roadBridgeSegements, bridgeSeg, 110f, "Assets/BetterLife/Icons/Toolbar/toolbar_roadbridgeseg.png", false, "", null, null, parentCategory3));

            // transPORT Toolbars parents

            prototypesDb.Add(new ToolbarCategoryProto(BetterLIDs.ToolBars.Signs, Proto.CreateStr(BetterLIDs.ToolBars.Signs, "Signs", null, ""), 110f, "Assets/BetterLife/Icons/Toolbar/Toolbar_Signs.png", isTransportBuildAllowed: false));


            //registrator.RegisterData<productData>();

            registrator.RegisterData<TerrainDef>();

            //registrator.RegisterData<RoadsAndSignsData>();

            //registrator.RegisterData<MachineDef>();

            registrator.RegisterData<SignsData>();

            registrator.RegisterData<IndustryRoads>();

            //registrator.RegisterData<Bridges>();

            registrator.RegisterDataWithInterface<IResearchNodesData>();

        }
        public bool GameWasLoaded;
        private bool disposedValue;

        public void RegisterDependencies(DependencyResolverBuilder depBuilder, ProtosDb protosDb, bool gameWasLoaded)

        {




        }

        public void Initialize(DependencyResolver resolver, bool gameWasLoaded)
        {
            GameWasLoaded = gameWasLoaded;
            //Option<InputScheduler> isc = resolver.GetResolvedInstance<InputScheduler>();
            //if (isc.HasValue)
            //{
            //    //isc.Value.ScheduleInputCmd<GameConsoleCmd>(new GameConsoleCmd("also_log_to_console"));
            //}
            //Option<ProtosDb> protosDb = resolver.GetResolvedInstance<ProtosDb>();

            ////IEnumerable<blZipperProto> myProtos = protosDb.Value.All<blZipperProto>();
            //IEnumerable<blZipperProto> myProtos = protosDb.Value.All<blZipperProto>();

            //foreach (blZipperProto proto in myProtos)
            //{
            //    if (proto.Strings.Name.ToString().Contains("Balancer"))
            //    {
            //        ImmutableArray<IoPortTemplate> ioPortTemplate = proto.Ports;
            //        foreach (IoPortTemplate port in ioPortTemplate)
            //        {
            //            var disconnectedField1 = port.Shape.Graphics.GetType().GetField("DisconnectedPortPrefabPath", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            //            var connectedField1 = port.Shape.Graphics.GetType().GetField("ConnectedPortPrefabPath", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            //            var disconnectedField2 = port.Shape.Graphics.GetType().GetField("DisconnectedPortPrefabPathLod3", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            //            var connectedField2 = port.Shape.Graphics.GetType().GetField("ConnectedPortPrefabPathLod3", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            //            var graphics1 = port.Shape.Graphics;
            //            disconnectedField1.SetValue(graphics1, "Assets/BetterLife/Transports/ports/port.prefab");
            //            connectedField1.SetValue(graphics1, "Assets/BetterLife/Transports/ports/port.prefab");
            //            disconnectedField2.SetValue(graphics1, "Assets/BetterLife/Transports/ports/port.prefab");
            //            connectedField2.SetValue(graphics1, "Assets/BetterLife/Transports/ports/port.prefab");

            //        }

            //    }

            //}
        }


        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }


        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

}
