using Mafi;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core;
using Mafi.Core.Bridges;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Static;
using Mafi.Core.Roads;
using Mafi.Serialization;
using System;
using System.Collections.Generic;

namespace BetterLife_RoadsAndSigns;

[GenerateSerializer(false, null, 0, null)]
public class blRoadEntity : blRoadEntityBase, IBridgeLaneEntity, IEntityWithOwner, IEntityWithOwnerFriend
{
    public static readonly RelTile1f DISCRETIZATION_STEP;

    public const int ROAD_LAYOUT_HEIGHT = 3;

    private static readonly Action<object, BlobWriter> s_serializeDataDelayedAction;

    private static readonly Action<object, BlobReader> s_deserializeDataDelayedAction;
    public Option<IEntity> Owner { get; private set; }

    private readonly RoadsManager m_roadsManager;

    public new blRoadEntityProto Prototype { get; private set; }

    public override bool CanBePaused => false;

    public bool CanBeReplaced()
    {
        return !this.m_roadsManager.AnyVehiclesOn(this);
    }

    public blRoadEntity(EntityId id, blRoadEntityProto proto, TileTransform transform, EntityContext context, RoadsManager roadsManager)
        : base(id, proto, transform, context)
    {
        Log.Info($"BETTERLIFE DEBUG: RoadEntityConstructor id:{id} proto:{proto} transform:{transform} context:{context}");
        this.Prototype = proto;
        this.m_roadsManager = roadsManager;

    }
    void IEntityWithOwnerFriend.SetOwner(Option<IEntity> owner)
    {
        this.Owner = owner;
    }

    public override ImmutableArray<ConstrCubeSpec> GetConstructionCubesSpec(out int totalCubesVolume)
    {
        int limitVerticalSizeTo = (base.RoadProto.LanesTrajectories[0].LaneCenterSamples.First.Z - base.RoadProto.LanesTrajectories[0].LaneCenterSamples.Last.Z).Abs().ToIntCeiled() + 1;
        ImmutableArray<KeyValuePair<Vector2i, OccupiedColumn>> columns = ConstructionCubesHelper.ComputeOptimizedConstructionCubeColumns(this.OccupiedTiles, 100, limitVerticalSizeTo);
        return ConstructionCubesHelper.ConvertColumnsToCubes(base.CenterTile, columns, generateGroundLevelSeparately: true, out totalCubesVolume, base.Context.TerrainManager);
    }

    public static void Serialize(blRoadEntity value, BlobWriter writer)
    {
        if (writer.TryStartClassSerialization(value))
        {
            writer.EnqueueDataSerialization(value, blRoadEntity.s_serializeDataDelayedAction);
        }
    }

    protected override void SerializeData(BlobWriter writer)
    {
        base.SerializeData(writer);
        writer.WriteGeneric(this.Prototype);
    }

    public static blRoadEntity Deserialize(BlobReader reader)
    {
        if (reader.TryStartClassDeserialization(out blRoadEntity obj, (Func<BlobReader, Type, blRoadEntity>)null, (Func<BlobReader, string, blRoadEntity>)null, nullObjIsOk: false))
        {
            reader.EnqueueDataDeserialization(obj, blRoadEntity.s_deserializeDataDelayedAction);
        }
        return obj;
    }

    protected override void DeserializeData(BlobReader reader)
    {
        base.DeserializeData(reader);
        this.Prototype = reader.ReadGenericAs<blRoadEntityProto>();
    }

    static blRoadEntity()
    {
        blRoadEntity.DISCRETIZATION_STEP = 0.25.Tiles();
        blRoadEntity.s_serializeDataDelayedAction = delegate (object obj, BlobWriter writer)
        {
            ((blRoadEntity)obj).SerializeData(writer);
        };
        blRoadEntity.s_deserializeDataDelayedAction = delegate (object obj, BlobReader reader)
        {
            ((blRoadEntity)obj).DeserializeData(reader);
        };
    }
}
