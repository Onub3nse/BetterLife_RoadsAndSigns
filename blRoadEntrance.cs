using Mafi;
using Mafi.Collections;
using Mafi.Core;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Static;
using Mafi.Core.Roads;
using Mafi.Serialization;
using System;

namespace BetterLife_RoadsAndSigns;

[GenerateSerializer(false, null, 0, null)]
public class blRoadEntranceEntity : blRoadEntityBase, IRoadGraphTerrainConnector, IRoadGraphEntity, ILayoutEntity, IStaticEntity, IEntityWithPosition, IAreaSelectableEntity, IRenderedEntity, IEntity, IObjectWithTitle, IIsSafeAsHashKey, ICloseableRoadGraphEntity, IEntityWithSimUpdate
{
    private readonly RoadsManager m_roadsManager;
    private static readonly Action<object, BlobWriter> s_serializeDataDelayedAction;
    private static readonly Action<object, BlobReader> s_deserializeDataDelayedAction;
    public override bool CanBePaused
    {
        get
        {
            return true;
        }
    }
    public int RoadTerrainConnectionsCount
    {
        get
        {
            return this.Prototype.TerrainConnections.Length;
        }
    }
    public bool IsRoadGloballyClosed { get; private set; }
    public bool IsRoadClosedSelf
    {
        get
        {
            return false;
        }
    }
    public Percent GateClosedPercentage { get; private set; }
    public new blRoadEntranceEntityProto Prototype { get; private set; }
    public blRoadEntranceEntity(EntityId id, blRoadEntranceEntityProto proto, TileTransform transform, EntityContext context, RoadsManager roadsManager)
        : base(id, proto, transform, context)
    {
        this.m_roadsManager = roadsManager;
        this.Prototype = proto;
    }
    public RoadTerrainConnection GetRoadTerrainConnection(int index)
    {
        LaneTerrainConnectionSpec laneTerrainConnectionSpec = this.Prototype.TerrainConnections[index];
        RoadGraphNodeKey roadGraphNodeKey = (laneTerrainConnectionSpec.IsAtLaneStart ? base.RoadProto.GetTransformedStartGraphNode(laneTerrainConnectionSpec.LaneIndex, base.Transform) : base.RoadProto.GetTransformedEndGraphNode(laneTerrainConnectionSpec.LaneIndex, base.Transform));
        return new RoadTerrainConnection(this.Prototype.Layout.Transform(laneTerrainConnectionSpec.LayoutTile, base.Transform), roadGraphNodeKey, laneTerrainConnectionSpec.IsAtLaneStart);
    }
    public Tile2i? TryGetRoadTerrainConnectionForLane(int laneIndex)
    {
        for (int i = 0; i < this.Prototype.TerrainConnections.Length; i++)
        {
            LaneTerrainConnectionSpec laneTerrainConnectionSpec = this.Prototype.TerrainConnections[i];
            if (laneTerrainConnectionSpec.LaneIndex == laneIndex)
            {
                return new Tile2i?(this.Prototype.Layout.Transform(laneTerrainConnectionSpec.LayoutTile, base.Transform));
            }
        }
        return null;
    }
    public void SetEntireRoadIsClosed(bool isClosed)
    {
        this.IsRoadGloballyClosed = isClosed;
    }
    public void SimUpdate()
    {
        if (this.IsRoadGloballyClosed || !this.CanPathfindThrough())
        {
            this.GateClosedPercentage = (this.GateClosedPercentage + 5.Percent()).Min(Percent.Hundred);
            return;
        }
        this.GateClosedPercentage = (this.GateClosedPercentage - 5.Percent()).Max(Percent.Zero);
    }
    public override void SetPaused(bool isPaused)
    {
        if (base.IsPaused == isPaused)
        {
            return;
        }
        base.SetPaused(isPaused);
        Set<IRoadGraphEntity> set = new Set<IRoadGraphEntity>(0, null);
        this.m_roadsManager.GetAllRoadConnectedEntities(this, set);
        foreach (IRoadGraphEntity roadGraphEntity in set)
        {
            blRoadEntranceEntity roadEntranceEntity = roadGraphEntity as blRoadEntranceEntity;
            if (roadEntranceEntity != null)
            {
                roadEntranceEntity.SetPaused(isPaused);
            }
        }
    }
    public static void Serialize(blRoadEntranceEntity value, BlobWriter writer)
    {
        if (writer.TryStartClassSerialization<blRoadEntranceEntity>(value))
        {
            writer.EnqueueDataSerialization(value, blRoadEntranceEntity.s_serializeDataDelayedAction);
        }
    }
    protected override void SerializeData(BlobWriter writer)
    {
        base.SerializeData(writer);
        Percent.Serialize(this.GateClosedPercentage, writer);
        writer.WriteBool(this.IsRoadGloballyClosed);
        writer.WriteGeneric<blRoadEntranceEntityProto>(this.Prototype);
    }
    public static blRoadEntranceEntity Deserialize(BlobReader reader)
    {
        blRoadEntranceEntity roadEntranceEntity;
        if (reader.TryStartClassDeserialization<blRoadEntranceEntity>(out roadEntranceEntity, null, null, false))
        {
            reader.EnqueueDataDeserialization(roadEntranceEntity, blRoadEntranceEntity.s_deserializeDataDelayedAction, null);
        }
        return roadEntranceEntity;
    }
    protected override void DeserializeData(BlobReader reader)
    {
        base.DeserializeData(reader);
        this.GateClosedPercentage = Percent.Deserialize(reader);
        this.IsRoadGloballyClosed = reader.ReadBool();
        reader.RegisterResolvedMember<blRoadEntranceEntity>(this, "m_roadsManager", typeof(RoadsManager), true, null);
        this.Prototype = reader.ReadGenericAs<blRoadEntranceEntityProto>();
    }
    static blRoadEntranceEntity()
    {
        blRoadEntranceEntity.s_serializeDataDelayedAction = delegate (object obj, BlobWriter writer)
        {
            ((blRoadEntranceEntity)obj).SerializeData(writer);
        };
        blRoadEntranceEntity.s_deserializeDataDelayedAction = delegate (object obj, BlobReader reader)
        {
            ((blRoadEntranceEntity)obj).DeserializeData(reader);
        };
    }
}

