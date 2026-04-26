using Mafi;
using Mafi.Core;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Notifications;
using Mafi.Core.Roads;
using Mafi.Serialization;

namespace BetterLife_RoadsAndSigns;

[GenerateSerializer(false, null, 0, null)]
public class blRoadEntityBase : LayoutEntityBase, IRoadGraphEntity, ILayoutEntity, IStaticEntity, IEntityWithPosition,
        IAreaSelectableEntity, IRenderedEntity, IEntity, IObjectWithTitle, IIsSafeAsHashKey
{
    private EntityNotificator m_badConnectionNotif;

    public int RoadLanesCount
    {
        get
        {
            return this.RoadProto.LanesData.Length;
        }
    }
    IRoadGraphEntityProto IRoadGraphEntity.RoadProto
    {
        get
        {
            return this.RoadProto;
        }
    }

    public blRoadEntityProtoBase RoadProto { get; private set; }

    public bool HasBadConnection
    {
        get
        {
            return this.m_badConnectionNotif.IsActive;
        }
    }

    public override bool CanBePaused => true;

    public blRoadEntityBase(EntityId id, blRoadEntityProtoBase proto, TileTransform transform, EntityContext context)
        : base(id, proto, transform, context)
    {
        Log.Info($"BETTERLIFE DEBUG: RoadEntityBase parameters: id:{id}, proto:{proto}, transform:{transform}, context:{context} ");
        this.RoadProto = proto;
        this.m_badConnectionNotif = context.NotificationsManager.CreateNotificatorFor(IdsCore.Notifications.RoadHasInvalidConnection);
    }

    public RoadLaneMetadata GetRawRoadLaneMetadata(int laneIndex)
    {
        return this.RoadProto.LanesData[laneIndex];
    }

    public RoadLaneTrajectory GetTransformedRoadLane(int laneIndex)
    {
        return this.RoadProto.GetTransformedLane(base.Transform, laneIndex);
    }
    public void GetLaneNodes(int laneIndex, out RoadGraphNodeKey startNodeKey, out RoadGraphNodeKey endNodeKey)
    {
        startNodeKey = this.RoadProto.GetTransformedStartGraphNode(laneIndex, base.Transform);
        endNodeKey = this.RoadProto.GetTransformedEndGraphNode(laneIndex, base.Transform);
    }
    public void NotifyBadConnection(bool notify)
    {
        this.m_badConnectionNotif.NotifyIff(notify, this);
    }
    //public override string ToString()
    //{
    //    return string.Format("{0} #{1} {2} {3}", new object[]
    //    {
    //            base.GetType().Name,
    //            base.Id,
    //            this.RoadProto.Id,
    //            base.IsDestroyed ? " (destroyed)" : ""
    //    });
    //}
    protected override void SerializeData(BlobWriter writer)
    {
        base.SerializeData(writer);
        EntityNotificator.Serialize(this.m_badConnectionNotif, writer);
        writer.WriteGeneric<blRoadEntityProtoBase>(this.RoadProto);
    }
    protected override void DeserializeData(BlobReader reader)
    {
        base.DeserializeData(reader);
        this.m_badConnectionNotif = EntityNotificator.Deserialize(reader);
        this.RoadProto = reader.ReadGenericAs<blRoadEntityProtoBase>();
    }
}