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
using Mafi.Unity;
using Mafi.Unity.Entities;
using Mafi.Unity.Entities.Static;
using Mafi.Unity.Ui;
using Mafi.Unity.Ui.Library;
using Mafi.Unity.Ui.Library.Inspectors;
using Mafi.Unity.UiStatic.Inspectors.Vehicles;
using Mafi.Unity.UiToolkit.Component;
using Mafi.Unity.UiToolkit.Library;
using System;
using System.Runtime.Remoting.Contexts;
using UnityEngine;
using UnityEngine.UIElements;

namespace BetterLife_RoadsAndSigns
{
    [GenerateSerializer(false, null, 0)]
    public class CustomEntity : LayoutEntity, IEntityWithWorkers, IEntityWithSimUpdate, IStaticEntity

    {
       
        private CustomEntityPrototype _proto;
        public enum State
        {
            None,
            Working,
            Paused,
            NotEnoughWorkers,
        }
        public float rotationAngle = 90f;
        public bool rotateOnce = false;
        public bool moveOnce = false;
        public float offsetx = 0f;
        public float offsety = 0f;
        public float offsetxTotal = 0f;
        public float offsetyTotal = 0f;
        public bool fromSaved = false;
        public Quaternion currentRotation = new Quaternion(0,0,0,0);
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

        public int _pushCount = 1;
        public int pushCount
        {
            get { return _pushCount; }
        }

        public CustomEntity(EntityId id, CustomEntityPrototype proto, TileTransform transform, EntityContext context) : base(id, proto, transform, context)

        {
            _proto = proto;
        }

        public new CustomEntityPrototype Prototype
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

        public static void Serialize(CustomEntity value, BlobWriter writer)
        {
            if (writer.TryStartClassSerialization(value))
            {
                writer.EnqueueDataSerialization(value, s_serializeDataDelayedAction);
            }
        }
        public static CustomEntity Deserialize(BlobReader reader)
        {
            if (reader.TryStartClassDeserialization(out CustomEntity obj, (Func<BlobReader, Type, CustomEntity>)null))
            {
                reader.EnqueueDataDeserialization(obj, s_deserializeDataDelayedAction);
            }
            return obj;
        }

        protected override void SerializeData(BlobWriter writer)
        {
            base.SerializeData(writer);
            if (_pushCount == 0) _pushCount = 1;
            writer.WriteGeneric(_proto);
            writer.WriteInt(_pushCount);
            writer.WriteFloat(offsetxTotal);
            writer.WriteFloat(offsetyTotal);
            writer.WriteFloat(this.currentRotation.x);
            writer.WriteFloat(this.currentRotation.y);
            writer.WriteFloat(this.currentRotation.z);
            writer.WriteFloat(this.currentRotation.w);
        }
        protected override void DeserializeData(BlobReader reader)
        {
            base.DeserializeData(reader);
            reader.SetField(this, "_proto", reader.ReadGenericAs<CustomEntityPrototype>());
            reader.SetField(this, "_pushCount", reader.ReadInt());

            if (_pushCount >= 1)
            {
                reader.SetField(this, "offsetxTotal", reader.ReadFloat());
                reader.SetField(this, "offsetyTotal", reader.ReadFloat());
                float x = reader.ReadFloat();
                float y = reader.ReadFloat();
                float z = reader.ReadFloat();
                float w = reader.ReadFloat();

                this.currentRotation = new Quaternion(x, y, z, w);

            }
            reader.RegisterInitAfterLoad<CustomEntity>(this, nameof(initSelf), InitPriority.Normal);
        }
        [InitAfterLoad(InitPriority.Normal)]
        private void initSelf(int saveVersion, DependencyResolver resolver)
        {
            this.fromSaved = true;
        }
        static CustomEntity()
        {
            s_serializeDataDelayedAction = delegate (object obj, BlobWriter writer)
            {
                ((CustomEntity)obj).SerializeData(writer);
            };
            s_deserializeDataDelayedAction = delegate (object obj, BlobReader reader)
            {
                ((CustomEntity)obj).DeserializeData(reader);
            };
        }
    }



    public class CustomEntityPrototype : LayoutEntityProto, IProto, IProtoWithAnimation, IProtoWithTiers
    {

        public CustomEntityPrototype(ID id, Str strings, EntityLayout layout, EntityCosts costs, Gfx graphics, ImmutableArray<AnimationParams> ap)
             : base(id, strings, layout, costs, graphics)
        {
            this.TierData = new TierData(this);
            _animationParameters = ap;
        }

        ImmutableArray<AnimationParams> IProtoWithAnimation.AnimationParams => _animationParameters;
        private ImmutableArray<AnimationParams> _animationParameters;

        public override Type EntityType => typeof(CustomEntity);
        public int actionDuration;
        public ITierData TierData { get; }

    }
    



    [GlobalDependency(RegistrationMode.AsAllInterfaces, false, false)]
    internal class customEntityInspector : BaseInspector<CustomEntity>
    {
        private ButtonText CreateButton(string label, Action onClick)
        {
            return new ButtonText(label.AsLoc(), null).TextAlign(Mafi.Unity.UiToolkit.Component.TextAlignment.CenterMiddle).OnClick(onClick, false).FlexGrow(1f);
        }
        public customEntityInspector(UiContext context) : base(context)
        {

            // Set window size
            WindowSize(600.px(), Px.Auto);

            base.AddPanelRow(delegate (Row row)
            {
                row.JustifyItemsSpaceBetween<Row>();
            }, new UiComponent[]
            {
                 this.CreateButton("Rotate -", delegate { this.RotateMinus(); }),
                 this.CreateButton("Rotate +", delegate { this.RotatePlus(); })
            });
            base.AddPanelRow(delegate (Row row)
            {
                row.JustifyItemsSpaceBetween<Row>();
            }, new UiComponent[]
            {
                 this.CreateButton("X-", delegate { this.MoveXMinus(); }),
                 this.CreateButton("X+", delegate { this.MoveXPlus(); }),
                 this.CreateButton("Y-", delegate { this.MoveYMinus(); }),
                 this.CreateButton("Y+", delegate { this.MoveYPlus(); })
            });

        }

        private void RotateMinus()
        {
            this.Entity.rotationAngle = 90f;
            this.Entity.rotateOnce = true;
        }
        private void RotatePlus()
        {
            this.Entity.rotationAngle = -90f;
            this.Entity.rotateOnce = true;
        }
        private void MoveXMinus()
        {
            this.Entity.offsetx = -0.5f;
            this.Entity.offsety = 0f;
            this.Entity.offsetxTotal += -0.5f;
            this.Entity.moveOnce = true;
        }
        private void MoveXPlus()
        {
            this.Entity.offsetx = 0.5f;
            this.Entity.offsety = 0f;
            this.Entity.offsetxTotal += 0.5f;
            this.Entity.moveOnce = true;
        }
        private void MoveYMinus()
        {
            this.Entity.offsetx = 0f;
            this.Entity.offsety = -0.5f;
            this.Entity.offsetyTotal += -0.5f;
            this.Entity.moveOnce = true;
        }
        private void MoveYPlus()
        {
            this.Entity.offsetx = 0f;
            this.Entity.offsety = 0.5f;
            this.Entity.offsetyTotal += 0.5f;
            this.Entity.moveOnce = true;
        }
    }
    [GlobalDependency(RegistrationMode.AsAllInterfaces, false, false)]
    public class customEntityMbFactory :
        IEntityMbFactory<CustomEntity>,
        IFactory<CustomEntity, EntityMb>
    {

        private readonly ProtoModelFactory modelFactory;
        private EntitiesManager m_entitiesManager;

        public customEntityMbFactory(ProtoModelFactory mFactory, EntitiesManager entitiesManager)
        {
            modelFactory = mFactory;
            m_entitiesManager = entitiesManager;
        }

        public EntityMb Create(CustomEntity transp)
        {
            customEntityMb transpMb = modelFactory.CreateModelFor<CustomEntityPrototype>(transp.Prototype).AddComponent<customEntityMb>();
            transpMb.Initialize(transp, m_entitiesManager);
            return (EntityMb)transpMb;
        }
    }
    public class customEntityMb : StaticEntityMb, IEntityMbWithSyncUpdate, IEntityMb, IDestroyableEntityMb
    {
        CustomEntity thisEntity;
        private EntitiesManager m_entitiesManager;
        private Transform thisTransform;
        public void SyncUpdate(GameTime time)
        {
            if (this.thisTransform != null)
            {

            if (thisEntity.rotateOnce == true )
                {
                    thisEntity.rotateOnce = false;
                    thisTransform.Rotate(0, thisEntity.rotationAngle, 0);
                    thisEntity.currentRotation = new Quaternion(thisTransform.rotation.x, thisTransform.rotation.y, thisTransform.rotation.z, thisTransform.rotation.w);
                }
                if (thisEntity.moveOnce == true )
                {
                    thisEntity.moveOnce = false;
                    thisTransform.position += new Vector3(thisEntity.offsetx, 0, thisEntity.offsety);
                }
                if (thisEntity.fromSaved == true)
                {
                    float originalX = thisEntity.Position3f.X.ToFloat();
                    float originalY = thisEntity.Position3f.Y.ToFloat();
                    
                    Vector3 offset = new Vector3(thisEntity.offsetxTotal + thisTransform.localPosition.x, thisEntity.offsetyTotal + thisTransform.localPosition.y);

                    thisTransform.position += new Vector3(thisEntity.offsetxTotal, 0, thisEntity.offsetyTotal);
                    thisTransform.rotation = new Quaternion(thisEntity.currentRotation.x, thisEntity.currentRotation.y, thisEntity.currentRotation.z,thisEntity.currentRotation.w);
                    thisEntity.fromSaved = false;
                } 
            } 
        }
        public void Initialize(CustomEntity customEnt, EntitiesManager entitiesManager)
        {
            base.Initialize((ILayoutEntity)customEnt);
            thisEntity = customEnt;
            Log.Info($"Initialize MB - > Actual position: {customEnt.offsetxTotal} / {customEnt.offsetyTotal} Rotation:{customEnt.Transform.Rotation.Angle}");

            m_entitiesManager = entitiesManager;
            thisTransform = base.gameObject.transform;

            float originalX = customEnt.Position3f.X.ToFloat();
            float originalY = customEnt.Position3f.Y.ToFloat();


            Vector3 offset = new Vector3(thisEntity.offsetxTotal + originalX, thisEntity.offsetyTotal + originalY);

            //UnityEngine.Object.Instantiate(thisTransform, transform.position + offset, Quaternion.identity);

            Log.Info($"original x/y {originalX}/{originalY}");

            Log.Info($"Initialize MB - > {thisTransform.position.x} / {thisTransform.position.y} Rotation:{thisTransform.rotation.eulerAngles}");


            if (thisTransform == null)
                Log.Info("Error obtaining transform of sign");

            if (thisTransform != null)
            {

            }
        }
        static customEntityMb()
        {

        }
    }
    public static class insideGOUtility
    {
        /// <summary>
        /// Finds the first material with the specified name from MeshRenderer components in a GameObject and its children.
        /// </summary>
        /// <param name="parent">The root GameObject to start the search from.</param>
        /// <param name="materialName">The name of the material to find.</param>
        /// <param name="includeInactive">Whether to include MeshRenderers on inactive GameObjects.</param>
        /// <returns>The first matching Material, or null if not found.</returns>

        public static Material FindMaterialByName(this GameObject parent, string materialName, bool includeInactive = false)
        {

            MeshRenderer[] renderers = parent.GetComponentsInChildren<MeshRenderer>(includeInactive);
            //Log.Info($"FindMaterialByName: Found {renderers.Length} MeshRenderers in {parent.name}.");



            string searchNameLower = materialName.Trim().ToLower();
            foreach (MeshRenderer renderer in renderers)
            {
                if (renderer != null && renderer.materials != null)
                {
                    //      Log.Info($"FindMaterialByName: Processing MeshRenderer on {renderer.gameObject.name} with {renderer.sharedMaterials.Length} materials.");

                    foreach (Material material in renderer.materials)
                    {
                        if (material != null && material.name != null)
                        {
                            // Handle Unity's potential "(Instance)" suffix and trim whitespace
                            string materialNameLower = material.name.Replace("(Instance)", "").Trim().ToLower();
                            //            Log.Info($"FindMaterialByName: Checking material '{material.name}' (normalized: '{materialNameLower}') against search '{searchNameLower}'.");

                            if (materialNameLower.Contains(searchNameLower))
                            {
                                //              Log.Info($"FindMaterialByName: Matched material '{material.name}' on GameObject '{renderer.gameObject.name}'.");
                                return material;
                            }
                        }
                        else
                        {
                            //        Log.Info($"FindMaterialByName: Skipping null material or null material name in {renderer.gameObject.name}.");
                        }
                    }
                }
                else
                {
                    //    Log.Info($"FindMaterialByName: Skipping null MeshRenderer or sharedMaterials in {renderer?.gameObject.name ?? "null"}.");
                }
            }
            // Log.Info($"FindMaterialByName: Found {materials.Count} matching materials for '{materialName}'.");
            return null;
        }
        /// <summary>
        /// Finds the first component on a GameObject with the specified name in a GameObject and its children.
        /// </summary>
        /// <param name="parent">The root GameObject to start the search from.</param>
        /// <param name="gameObjectName">The name of the GameObject containing the component to find.</param>
        /// <param name="includeInactive">Whether to include components on inactive GameObjects.</param>
        /// <returns>The first matching Component, or null if not found.</returns>
        public static Component FindComponentByName(this GameObject parent, string gameObjectName, bool includeInactive = false)
        {
            // Validate input
            if (parent == null || string.IsNullOrEmpty(gameObjectName))
            {
                //Log.Info("FindComponentByName: Invalid input - null parent or empty GameObject name.");
                return null;
            }

            // Get all components of any type in the parent and its children
            Component[] components = parent.GetComponentsInChildren<Component>(includeInactive);
            //Log.Info($"FindComponentByName: Found {components.Length} components in {parent.name}.");

            string searchNameLower = gameObjectName.Trim().ToLower();
            foreach (Component component in components)
            {
                if (component != null)
                {
                    // Get the GameObject's name and normalize it
                    string goNameLower = component.gameObject.name.Trim().ToLower();
                    //Log.Info($"FindComponentByName: Checking GameObject '{component.gameObject.name}' (normalized: '{goNameLower}') against search '{searchNameLower}'.");

                    if (goNameLower.Contains(searchNameLower))
                    {
                        //Log.Info($"FindComponentByName: Matched component '{component.GetType().Name}' on GameObject '{component.gameObject.name}'.");
                        return component;
                    }
                }
                else
                {
                    //Log.Info("FindComponentByName: Skipping null component.");
                }
            }

            //Log.Info($"FindComponentByName: No matching component found for GameObject name '{gameObjectName}'.");
            return null;
        }
    }
}