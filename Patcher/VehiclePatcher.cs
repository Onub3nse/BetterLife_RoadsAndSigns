//namespace BetterLife_RoadAndSigns
//{
//    [GenerateSerializer(false, null, 0)]
//    [GlobalDependency(RegistrationMode.AsEverything)]
//    public class VehiclePatcher
//    {
//        private readonly TerrainOccupancyManager m_terrainOccupancyManager;
//        private readonly VehiclesManager m_vehiclesManager;
//        private readonly TerrainManager m_terrainManager;
//        private readonly EntitiesManager m_entitiesManager;
//        private readonly SimLoopEvents m_simLoopEvents;
//        private readonly UpointsManager m_upointsManager;
//        private readonly Lyst<IStaticEntity> m_entityCache = [];
//        private readonly MultiLineOverlayRendererHelper m_LineRenderer;
//        private readonly UiContext m_uiContext;
//        public RoadsManager m_roadsManager;
//        //private ImmutableArray<RoadPathSegment> m_roadPathSegments;
//        private readonly ConstructionManager m_constructionManager;
//        //private  EntityId m_entityId;
//        //Option<IRoadGraphEntity> roadEntity = new Option<IRoadGraphEntity>();
//        public static Stopwatch m_stopwatch = new Stopwatch();
//        //private static ImmutableArray<IAnimationState> animationStates;
//        public AssetsDb m_assetsDB;

//        public ImmutableArray<IAnimationStateImpl> m_animationStatesImpl;

//        public struct vehicleDataStruct
//        {
//            public EntityId vehicleId;
//            public bool isUnderControl = false;

//            public vehicleDataStruct(EntityId vehicleId, bool isUnderControl)
//            {
//                this.vehicleId = vehicleId;
//                this.isUnderControl = isUnderControl;
//            }
//        }

//        public Dict<EntityId, vehicleDataStruct> vehicleData;


//        public VehiclePatcher(TerrainOccupancyManager terrainOccupancyManager, VehiclesManager vehiclesManager, TerrainManager terrainManager,
//            EntitiesManager entitiesManager, UpointsManager upointsManager, SimLoopEvents simLoopEvents, AssetsDb assetsDb, UiContext uiContext, ConstructionManager constructionManager)
//        {
//            m_terrainOccupancyManager = terrainOccupancyManager;
//            m_vehiclesManager = vehiclesManager;
//            m_terrainManager = terrainManager;
//            m_upointsManager = upointsManager;
//            m_entitiesManager = entitiesManager;
//            m_simLoopEvents = simLoopEvents;
//            m_assetsDB = assetsDb;
//            m_uiContext = uiContext;
//            m_constructionManager = constructionManager;
//            m_LineRenderer = new MultiLineOverlayRendererHelper(uiContext.LinesFactory);
//            simLoopEvents.Update.Add(this, action: myNewSimUpdate);


//        }

//        private void myNewSimUpdate()
//        {
//            foreach (DrivingEntity vehicle in m_vehiclesManager.AllVehicles)
//            {

//                if (vehicle is not Truck)
//                {
//                    // continue;
//                }

//                if (vehicle.DrivingState is DrivingState.DrivingForwards)
//                {


//                    Tile2i vehicleAtTile = vehicle.Target.Value.Tile2i;
//                    Tile2iAndIndex tileWithIndex = vehicleAtTile.ExtendIndex(m_terrainManager);
//                    Tile3i vehicleAtTile3i = new Tile3i(vehicleAtTile.X, vehicleAtTile.Y, vehicle.Position3f.Z.IntegerPart);
//                    //Tile3i vehicleAtTile3i2 = new Tile3i(vehicleAtTile2.X, vehicleAtTile2.Y, vehicle.Position3f.Z.IntegerPart);
//                    Tile3f vehicleTargetPos = new Tile3f(vehicleAtTile.X, vehicleAtTile3i.Y, vehicle.Position3f.Z.IntegerPart);

//                    string VehType = vehicle.DefaultTitle.ToString();
//                    //Log.Info($"------------------------------------> Betterlife: Vehicle type: {VehType}");
//                    m_entityCache.Clear();
//                    //m_terrainOccupancyManager.GetAllOccupyingEntitiesInRange(tileWithIndex.Index, new HeightTilesI(2), new ThicknessTilesI(2), m_entityCache);
//                    m_terrainOccupancyManager.GetAllOccupiedEntitiesAt(tileWithIndex.Index, m_entityCache);

//                    //roadEntity = vehicle.CurrentRoadEntity;

//                    //m_roadPathSegments = vehicle.GetField<ImmutableArray<RoadPathSegment>>("m_roadSegments");

//                    foreach (var i in m_entityCache)
//                    {

//                        if (i.Prototype.Id == BetterLIDs.IndustrialRoads.bidirStraightL)
//                        {
//                            SmoothDriver m_SmoothDriver = vehicle.GetField<SmoothDriver>("m_speedDriver");



//                            AngleDegrees1f steerAngle = vehicle.SteeringAngle;
//                            //Log.Debug($"-> VehType: {VehType} LastStepSpeed: {m_SmoothDriver.LastStepSpeed}");
//                            //Log.Info($"LastStepSpeed {m_SmoothDriver.LastStepSpeed} TargetIsTerminal {vehicle.TargetIsTerminal.ToString()} SteerAngle {steerAngle.Abs.Degrees.ToString()}");

//                            if (m_SmoothDriver.LastStepSpeed > 0.8.ToFix32() && vehicle.TargetIsTerminal == false && steerAngle.Abs.Degrees < 2)
//                            {

//                                if (VehType == "Pickup" || VehType == "Small Excavator" || VehType == "Tree harvester" || VehType == "Tree planter")
//                                {
//                                    m_SmoothDriver.SetSpeed(1.25.ToFix32());
//                                    m_SmoothDriver.SetSpeedFactor(125.Percent());
//                                }
//                                if (VehType == "Truck")
//                                {
//                                    m_SmoothDriver.SetSpeed(1.35.ToFix32());
//                                    m_SmoothDriver.SetSpeedFactor(135.Percent());

//                                }
//                                if (VehType == "Amphibious truck" || VehType == "Amphibious excavator")
//                                {
//                                    m_SmoothDriver.SetSpeed(1.10.ToFix32());
//                                    m_SmoothDriver.SetSpeedFactor(110.Percent());

//                                }
//                                if (VehType == "Haul truck" || VehType == "Haul truck (tank)" || VehType == "Mega excavator" || VehType == "Large tree harvester")
//                                {
//                                    m_SmoothDriver.SetSpeed(1.15.ToFix32());
//                                    m_SmoothDriver.SetSpeedFactor(115.Percent());

//                                }
//                                if (VehType == "" || VehType == "Amphibious excavator")
//                                {
//                                    m_SmoothDriver.SetSpeed(1.10.ToFix32());
//                                    m_SmoothDriver.SetSpeedFactor(110.Percent());

//                                }
//                            }
//                        }
//                    }
//                }
//            }
//        }
//        public static void Serialize(VehiclePatcher value, BlobWriter writer)
//        {

//            if (!writer.TryStartClassSerialization(value))
//            {
//                return;
//            }

//            writer.EnqueueDataSerialization(obj: value, delegate { value.SerializeData(writer); });
//        }
//        protected void SerializeData(BlobWriter writer)
//        {
//            TerrainOccupancyManager.Serialize(m_terrainOccupancyManager, writer);
//            TerrainManager.Serialize(m_terrainManager, writer);
//            EntitiesManager.Serialize(m_entitiesManager, writer);
//            UpointsManager.Serialize(m_upointsManager, writer);
//            writer.WriteGeneric(m_vehiclesManager);
//            SimLoopEvents.Serialize(m_simLoopEvents, writer);
//            Lyst<IStaticEntity>.Serialize(m_entityCache, writer);
//        }

//        protected void DeserializeData(BlobReader reader)
//        {
//            reader.SetField(this, "m_terrainOccupancyManager", TerrainOccupancyManager.Deserialize(reader));
//            reader.SetField(this, "m_terrainManager", TerrainManager.Deserialize(reader));
//            reader.SetField(this, "m_entitiesManager", EntitiesManager.Deserialize(reader));
//            reader.SetField(this, "m_upointsManager", UpointsManager.Deserialize(reader));
//            reader.SetField(this, "m_vehiclesManager", reader.ReadGenericAs<VehiclesManager>());
//            reader.SetField(this, "m_simLoopEvents", SimLoopEvents.Deserialize(reader));
//            reader.SetField(this, "m_entityCache", Lyst<IStaticEntity>.Deserialize(reader));
//        }

//        public static VehiclePatcher Deserialize(BlobReader reader)
//        {
//            if (reader.TryStartClassDeserialization(out VehiclePatcher obj))
//            {
//                reader.EnqueueDataDeserialization(obj: obj, delegate
//                {
//                    obj.DeserializeData(reader);
//                });
//            }

//            return obj;
//        }

//    }
//}


