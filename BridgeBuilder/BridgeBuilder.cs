using Mafi;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Prototypes;
using Mafi.Core.Terrain;
using Mafi.Serialization;
using System;


namespace BetterLife.Prototypes
{
    [GenerateSerializer(false, null, 0)]
    public class BridgeEntity : LayoutEntity, IStaticEntity

    {
        public class BridgePrototype : LayoutEntityProto
        {
            public BridgePrototype(ID id, Str strings, EntityLayout layout, EntityCosts costs, Gfx graphics)
                 : base(id, strings, layout, costs, graphics)
            {

            }

            public override Type EntityType => typeof(BridgeEntity);
            public int actionDuration;
        }

        public BridgeEntity(EntityId id, BridgePrototype proto, TileTransform transform, EntityContext context,
            TerrainManager terrainManager,
            EntitiesBuilder entitiesBuilder,
            EntitiesManager entitiesManager
            ) : base(id, proto, transform, context)

        {
            _proto = proto;
            _terrainManager = terrainManager;
            _entitiesBuilder = entitiesBuilder;
            _entitiesManager = entitiesManager;


        }

        private BridgePrototype _proto;
        private TerrainManager _terrainManager;
        private EntitiesManager _entitiesManager;
        private EntitiesBuilder _entitiesBuilder;
        //private EntityLayoutParser _layoutParser;
        private int _pushCount = 0;
        public int pushCount
        {
            get { return _pushCount; }
        }

        public new BridgePrototype Prototype
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

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
        protected override void OnAddedToWorld(EntityAddReason reason)
        {
            base.OnAddedToWorld(reason);
        }

        public override bool CanBePaused => false;

        //        IUpgradeData IProtoWithUpgrade.UpgradeNonGeneric => throw new NotImplementedException();

        private static readonly Action<object, BlobWriter> s_serializeDataDelayedAction;

        private static readonly Action<object, BlobReader> s_deserializeDataDelayedAction;

        public static void Serialize(BridgeEntity value, BlobWriter writer)
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

        public static BridgeEntity Deserialize(BlobReader reader)
        {
            if (reader.TryStartClassDeserialization(out BridgeEntity obj, (Func<BlobReader, Type, BridgeEntity>)null))
            {
                reader.EnqueueDataDeserialization(obj, s_deserializeDataDelayedAction);
            }
            return obj;
        }

        protected override void DeserializeData(BlobReader reader)
        {
            base.DeserializeData(reader);
            reader.SetField(this, "_proto", reader.ReadGenericAs<BridgePrototype>());
            reader.SetField(this, "_pushCount", reader.ReadInt());
        }


        static BridgeEntity()
        {
            s_serializeDataDelayedAction = delegate (object obj, BlobWriter writer)
            {
                ((BridgeEntity)obj).SerializeData(writer);
            };
            s_deserializeDataDelayedAction = delegate (object obj, BlobReader reader)
            {
                ((BridgeEntity)obj).DeserializeData(reader);
            };
        }
    }
}