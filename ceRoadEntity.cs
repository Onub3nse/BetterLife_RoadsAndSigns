using Mafi;
using Mafi.Collections;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core;
using Mafi.Core.Buildings.Settlements;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Animations;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Entities.Validators;
using Mafi.Core.Population;
using Mafi.Core.Prototypes;
using Mafi.Core.Terrain;
using Mafi.Localization;
using Mafi.Serialization;
using Mafi.Unity.Ui;
using Mafi.Unity.Ui.Library.Inspectors;
using Mafi.Unity.UiToolkit.Component;
using Mafi.Unity.UiToolkit.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;

namespace BetterLife_RoadsAndSigns
{
    [GenerateSerializer(false, null, 0)]
    public class ceRoadEntity : LayoutEntity, IEntityWithSimUpdate, IStaticEntity

    {
        private ceRoadProto _proto;
        private TerrainManager _terrainManager;
        private EntitiesBuilder _entitiesBuilder;
        private ImmutableArray<KeyValuePair<Tile2i, HeightTilesF>> _oldVehicleHeightsToApply;
        private static ImmutableArray<KeyValuePair<Tile2i, HeightTilesF>> _pendingVehicleHeights = ImmutableArray<KeyValuePair<Tile2i, HeightTilesF>>.Empty;
        public enum State
        {
            None,
            Working,
            Paused,
            NotEnoughWorkers,
        }

        public State CurrentState { get; private set; }

        void IEntityWithSimUpdate.SimUpdate()
        {
            CurrentState = updateState();
        }

        private State updateState()
        {

            if (!base.IsEnabled)
            {
                return State.Paused;
            }
            return State.Working;
        }

        private int _pushCount = 0;
        public int pushCount
        {
            get { return _pushCount; }
        }

        public ceRoadEntity(EntityId id, ceRoadProto proto, TileTransform transform, EntityContext context, TerrainManager terrainManager, EntitiesBuilder entitiesBuilder) : base(id, proto, transform, context)

        {
            _proto = proto;
            _terrainManager = terrainManager;
            _entitiesBuilder = entitiesBuilder;
        }

        public new ceRoadProto Prototype
        {
            get
            {
                return _proto;
            }
            protected set
            {
                _proto = value;
                base.Prototype = value;
            }
        }

        public override bool CanBePaused => true;

        private void AdjustTerrainToVehicleHeights()
        {
            if (this.Prototype.Id == BetterLIDs.dPath.IndustrialRoads.onewaySlope1)
            {
                var vehicleHeights = Prototype.Layout.GetVehicleSurfaceHeights(this.Transform);   // or GetVehicleHeights()

                foreach (var kvp in vehicleHeights)
                {
                    Tile3i absTile = new Tile3i(kvp.Key.X, kvp.Key.Y, Prototype.Layout.LayoutTiles.First.TerrainHeight.Value.Value);                    // Absolute world coordinates
                    HeightTilesF targetHeight = kvp.Value;       // Absolute desired terrain height
                    Tile2iAndIndex tileIdx = new Tile2iAndIndex(
                        (ushort)absTile.X,
                        (ushort)absTile.Y,
                        absTile.Tile2i.ExtendIndex(_terrainManager).IndexRaw
                    );
                    _terrainManager.SetHeight(tileIdx, targetHeight);
                    _terrainManager.StopTerrainPhysicsSimulationAt(tileIdx);
                }
                base.Context.EntitiesManager.RemoveAndDestroyEntityNoChecks(this, new EntityRemoveReason());
                StaticEntityProto.ID newID = BetterLIDs.dPath.IndustrialRoads.onewaySlope1fake;
                Tile3i location = new Tile3i(Position3f.X.IntegerPart, Position3f.Y.IntegerPart, Position3f.Z.IntegerPart);
                Rotation90 rotation = new Rotation90(Transform.Rotation.AngleIndex);
                Option<LayoutEntity> newLayoutEntity = _entitiesBuilder.TryBuildLayoutEntity<LayoutEntity>(newID, new TileTransform(location, rotation, false), true, false, false);
            }
        }
        private void ApplyOldVehicleHeights(ImmutableArray<KeyValuePair<StaticEntityProto.ID, HeightTilesF>> heights)
        {
            if (heights == null || heights.Length == 0) return;

            if (_oldVehicleHeightsToApply == null) return;

            foreach (var kvp in _oldVehicleHeightsToApply)
            {
                Tile2i absTile = kvp.Key;
                HeightTilesF targetHeight = kvp.Value;

                Tile2iAndIndex tileIdx = new Tile2iAndIndex(
                    (ushort)absTile.X,
                    (ushort)absTile.Y,
                    absTile.ExtendIndex(_terrainManager).IndexRaw
                );

                _terrainManager.SetHeight(tileIdx, targetHeight);
                _terrainManager.StopTerrainPhysicsSimulationAt(tileIdx);
            }

            // Clear after use
            _oldVehicleHeightsToApply = default;
        }
        protected override void OnAddedToWorld(EntityAddReason reason)
        {
            base.OnAddedToWorld(reason);
            //StaticEntityProto.ID key = Prototype.Id;   // Use Tile2i as key

            //if (Prototype.Id == BetterLIDs.dPath.IndustrialRoads.onewaySlope1)
            //{
            //    _pendingVehicleHeights = this.Prototype.Layout.GetVehicleSurfaceHeights(this.Transform);
            //    base.Context.EntitiesManager.RemoveAndDestroyEntityNoChecks(this, new EntityRemoveReason());
            //    StaticEntityProto.ID newID = BetterLIDs.dPath.IndustrialRoads.onewaySlope1fake;
            //    Tile3i location = new Tile3i(Position3f.X.IntegerPart, Position3f.Y.IntegerPart, Position3f.Z.IntegerPart);
            //    Rotation90 rotation = new Rotation90(Transform.Rotation.AngleIndex);
            //    Option<LayoutEntity> newLayoutEntity = _entitiesBuilder.TryBuildLayoutEntity<LayoutEntity>(newID, new TileTransform(location, rotation, false), true, false, false);
            //}

            //if (Prototype.Id != BetterLIDs.dPath.IndustrialRoads.onewaySlope1fake)
            //{
            //    // NEW entity (replacement) → apply old terrain data
            //    //ApplyOldVehicleHeights(oldHeights);
            //    //_pendingTerrainData.Remove(key);   // cleanup
            //}
            //else if (Prototype.Id != BetterLIDs.dPath.IndustrialRoads.onewaySlope1fake)
            //{
            //    // OLD entity → trigger automatic replacement
            //    Log.Info("Start Automatic Replacement ");
            //}
        }
        public string getLabelTxt()
        {
            return $"The button has been pushed {_pushCount} times, simUpdateCount";
        }

        public void buttonAction()
        {
            _pushCount++;
        }

        private static readonly Action<object, BlobWriter> s_serializeDataDelayedAction;

        private static readonly Action<object, BlobReader> s_deserializeDataDelayedAction;

        public static void Serialize(ceRoadEntity value, BlobWriter writer)
        {
            if (writer.TryStartClassSerialization(value))
            {
                writer.EnqueueDataSerialization(value, s_serializeDataDelayedAction);
            }
        }

        protected override void SerializeData(BlobWriter writer)
        {
            base.SerializeData(writer);
            writer.WriteGeneric(_proto);
            writer.WriteInt(_pushCount);
        }

        public static ceRoadEntity Deserialize(BlobReader reader)
        {
            if (reader.TryStartClassDeserialization(out ceRoadEntity obj, (Func<BlobReader, Type, ceRoadEntity>)null))
            {
                reader.EnqueueDataDeserialization(obj, s_deserializeDataDelayedAction);
            }
            return obj;
        }

        protected override void DeserializeData(BlobReader reader)
        {
            base.DeserializeData(reader);
            reader.SetField(this, "_proto", reader.ReadGenericAs<ceRoadProto>());
            reader.SetField(this, "_pushCount", reader.ReadInt());
        }

        static ceRoadEntity()
        {
            s_serializeDataDelayedAction = delegate (object obj, BlobWriter writer)
            {
                ((ceRoadEntity)obj).SerializeData(writer);
            };
            s_deserializeDataDelayedAction = delegate (object obj, BlobReader reader)
            {
                ((ceRoadEntity)obj).DeserializeData(reader);
            };
        }

    }
    public class ceRoadProto : LayoutEntityProto, IProto, IProtoWithAnimation, IProtoWithTiers
    {

        public ceRoadProto(ID id, Str strings, EntityLayout layout, EntityCosts costs, Gfx graphics, ImmutableArray<AnimationParams> ap)
             : base(id, strings, layout, costs, graphics)
        {
            this.TierData = new TierData(this);
            _animationParameters = ap;
        }

        ImmutableArray<AnimationParams> IProtoWithAnimation.AnimationParams => _animationParameters;
        private ImmutableArray<AnimationParams> _animationParameters;
        public override Type EntityType => typeof(ceRoadEntity);
        public int actionDuration;
        public ITierData TierData { get; }

    }

    [GlobalDependency(RegistrationMode.AsAllInterfaces, false, false)]
    internal class ceRoadEntityInspector : BaseInspector<ceRoadEntity>
    {
        public ceRoadEntityInspector(UiContext context) : base(context)
        {
            Label upointsLabel = new Label().FontBold();
            WindowSize(600.px(), Px.Auto);
            AddPanelWithHeader(upointsLabel)
                .Title("BetterLife Roads & Signs".AsLoc());
            //this.Observe(() => Entity.UPointsGenerated)
            //    .Do(upoints => upointsLabel.Value($"McDonalds: {upoints:F0} upoints generated".AsLoc()));
        }
    }
    [GlobalDependency(RegistrationMode.AsAllInterfaces, false, false)]
    [GenerateSerializer(false, null, 0)]
    public class ceRoadEntityValidator : IEntityAdditionValidator<LayoutEntityAddRequest>, IEntityAdditionValidator
    {
        private static EntitiesManager entitiesManager;

        public ceRoadEntityValidator(EntitiesManager em)
        {
            entitiesManager = em;
        }

        public EntityValidationResult CanAdd(LayoutEntityAddRequest addRequest)
        {
            
            if (!(addRequest.Proto.Strings.Name.ToString() is "One Way Slope1"))
                return EntityValidationResult.Success;

            Log.Info($"{addRequest.Proto.Strings.Name}");

            
            
            return EntityValidationResult.Success;
        }

        public EntityValidatorPriority Priority => EntityValidatorPriority.Default;
    }

}
