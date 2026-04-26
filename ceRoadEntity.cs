using Mafi;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Animations;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Population;
using Mafi.Core.Prototypes;
using Mafi.Localization;
using Mafi.Serialization;
using Mafi.Unity.Ui;
using Mafi.Unity.Ui.Library.Inspectors;
using Mafi.Unity.UiToolkit.Component;
using Mafi.Unity.UiToolkit.Library;
using System;


namespace BetterLife_RoadsAndSigns
{
    [GenerateSerializer(false, null, 0)]
    public class ceRoadEntity : LayoutEntity, IEntityWithWorkers, IEntityWithSimUpdate, IStaticEntity

    {
        private ceRoadProto _proto;
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
            if (Entity.IsMissingWorkers(this))
            {
                return State.NotEnoughWorkers;
            }
            return State.Working;
        }

        private int _pushCount = 0;
        public int pushCount
        {
            get { return _pushCount; }
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

        public ceRoadEntity(EntityId id, ceRoadProto proto, TileTransform transform, EntityContext context) : base(id, proto, transform, context)

        {
            _proto = proto;
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

        protected override void OnAddedToWorld(EntityAddReason reason)
        {
            base.OnAddedToWorld(reason);




            CurrentState = updateState();
        }


        int IEntityWithWorkers.WorkersNeeded => Prototype.Costs.Workers;
        [DoNotSave(0, null)]
        bool IEntityWithWorkers.HasWorkersCached { get; set; }


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

    [GlobalDependency(RegistrationMode.AsAllInterfaces, false, false)]
    internal class ceRoadEntityInspector : BaseInspector<ceRoadEntity>
    {
        public ceRoadEntityInspector(UiContext context) : base(context)
        {
            Label upointsLabel = new Label().FontBold();
            WindowSize(400.px(), Px.Auto);
            AddPanelWithHeader(upointsLabel)
                .Title("BetterLife Roads & Signs".AsLoc());
            //this.Observe(() => Entity.UPointsGenerated)
            //    .Do(upoints => upointsLabel.Value($"McDonalds: {upoints:F0} upoints generated".AsLoc()));
        }
    }
}
