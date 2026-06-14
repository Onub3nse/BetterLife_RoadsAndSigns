using HarmonyLib;
using Mafi;
using Mafi.Base;
using Mafi.Collections;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Game;
using Mafi.Core.Mods;
using Mafi.Core.Prototypes;
using Mafi.Localization;
using System;
using System.Reflection;
//using static UnityEngine.UI.Image;
namespace BetterLife_RoadsAndSigns
{
    public sealed class BetterLife_RoadsAndSigns : IDisposable, IMod, IModConfig
    {
        public readonly Harmony HarmonyInstance;
        private ModManifest manifest;
        public static int SavedModVersion = 0;
        public void OnConfigLoaded(ModJsonConfig config)
        {
            Log.Info("Config loaded");
        }

        public ModManifest Manifest
        {
            get
            {
                return this.manifest;
            }
        }
        //public void ChangeConfigs(Lyst<IConfig> configs)
        //{
        //}
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
            //HarmonyInstance = new Harmony("RoadsAndSigns Harmony Patch");
            //HarmonyInstance.PatchCategory("RoadSlopePatcher");

        }
        //[HarmonyPatch(typeof(EntitiesManager), "TryAddEntity")]
        //[HarmonyPatchCategory("RoadSlopePatcher")]
        //public static class slopePatcher
        //{
        //    public static bool Prefix(ref IEntity entity, ProtoRegistrator reg)
        //    {
        //        //if (entity.Id == BetterLIDs.dPath.IndustrialRoads.onewaySlope1)
        //        //{
        //        //    var newProto = reg.PrototypesDb.GetOrThrow<StaticEntityProto>(BetterLIDs.dPath.IndustrialRoads.onewaySlope1fake);
        //        //    if (newProto != null)
        //        //    {
        //        //        Traverse.Create(addRequest).Property("Proto").SetValue(newProto);
        //        //        Log.Info("[Slope Patch] Proto swapped via TryAddEntity");
        //        //    }
        //        //}
        //        Log.Info($"Entity: {entity.Prototype.Id.ToString()}");
        //        return false;
        //    }
        //}
        public bool IsUiOnly => false;

        public void RegisterPrototypes(ProtoRegistrator registrator)
        {
            ProtosDb prototypesDb = registrator.PrototypesDb;



            Log.Info("$BetterLife - Roads and Signs: Registering toolbars...");
            ToolbarCategoryProto toolbarParent = prototypesDb.Add<ToolbarCategoryProto>(new ToolbarCategoryProto(BetterLIDs.ToolBars.RoadsParent, Proto.CreateStr(BetterLIDs.ToolBars.RoadsParent, "Roads"), 110f, "Assets/BetterLife/IconsRoad/Toolbar/Roads.png", false, "", null, null, null));
            Proto.ID roadindustrial1 = BetterLIDs.ToolBars.RoadsIndustrial;
            Proto.Str str1 = Proto.CreateStr(BetterLIDs.ToolBars.RoadsIndustrial, "Road Set 1", "", null);

            ToolbarCategoryProto parentCategory1 = toolbarParent;
            prototypesDb.Add<ToolbarCategoryProto>(new ToolbarCategoryProto(roadindustrial1, str1, 110f, "Assets/BetterLife/IconsRoad/Toolbar/toolbar_roadbidir.png", false, "", null, null, parentCategory1));
            Proto.ID roadindustrial2 = BetterLIDs.ToolBars.RoadsDirt;
            Proto.Str str2 = Proto.CreateStr(BetterLIDs.ToolBars.RoadsDirt, "Roads Set 2", "", null);

            ToolbarCategoryProto parentCategory2 = toolbarParent;
            prototypesDb.Add<ToolbarCategoryProto>(new ToolbarCategoryProto(roadindustrial2, str2, 110f, "Assets/BetterLife/IconsRoad/Toolbar/toolbar_roadoneway.png", false, "", null, null, parentCategory2));

            Proto.ID roadBridgeSegements = BetterLIDs.ToolBars.RoadsBridgeSegments;
            Proto.Str bridgeSeg = Proto.CreateStrFromLocalized(roadBridgeSegements, "Road Bridge Segments", "To get over train tracks".AsLoc(), null);
            ToolbarCategoryProto parentCategory3 = toolbarParent;
            prototypesDb.Add<ToolbarCategoryProto>(new ToolbarCategoryProto(roadBridgeSegements, bridgeSeg, 110f, "Assets/BetterLife/IconsRoad/Toolbar/toolbar_roadbridgeseg.png", false, "", null, null, parentCategory3));

            // signs parent Toolbars parents

            ToolbarCategoryProto toolbar_signs = new ToolbarCategoryProto(BetterLIDs.ToolBars.Signs, Proto.CreateStr(BetterLIDs.ToolBars.Signs, "Signs", null, ""), 110f, "Assets/BetterLife/IconsRoad/Toolbar/Toolbar_Signs.png", isTransportBuildAllowed: false);
            prototypesDb.Add(toolbar_signs);
            prototypesDb.Add(new ToolbarCategoryProto(BetterLIDs.ToolBars.Signs_SpeedLimits, Proto.CreateStr(BetterLIDs.ToolBars.Signs_SpeedLimits, "Speed Limits", null, ""), 110f, "Assets/BetterLife/IconsRoad/Toolbar/Toolbar_Signs.png", isTransportBuildAllowed: false, "", null, null, toolbar_signs));
            prototypesDb.Add(new ToolbarCategoryProto(BetterLIDs.ToolBars.Signs_Directions, Proto.CreateStr(BetterLIDs.ToolBars.Signs_Directions,"Directions", null, ""), 110f, "Assets/BetterLife/IconsRoad/Toolbar/Toolbar_Signs.png", isTransportBuildAllowed: false, "", null, null, toolbar_signs));
            prototypesDb.Add(new ToolbarCategoryProto(BetterLIDs.ToolBars.Signs_Buildings, Proto.CreateStr(BetterLIDs.ToolBars.Signs_Buildings, "Buildings", null, ""), 110f, "Assets/BetterLife/IconsRoad/Toolbar/Toolbar_Signs.png", isTransportBuildAllowed: false, "", null, null, toolbar_signs));
            prototypesDb.Add(new ToolbarCategoryProto(BetterLIDs.ToolBars.Signs_Misc, Proto.CreateStr(BetterLIDs.ToolBars.Signs_Misc, "Misc", null, ""), 110f, "Assets/BetterLife/IconsRoad/Toolbar/Toolbar_Signs.png", isTransportBuildAllowed: false, "", null, null, toolbar_signs));


            registrator.RegisterData<TerrainDef>();

            registrator.RegisterData<SignsData>();

            registrator.RegisterData<IndustryRoads>();

            // Modular road pieces (straight, corner, tee, crossing, elevated crossing)
            registrator.RegisterData<BetterLife_RoadsAndSigns.ModularRoads.ModularRoadPieceRegistrar>();

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
