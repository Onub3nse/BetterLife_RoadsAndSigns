using Mafi.Base;
using ResNodeID = Mafi.Core.Research.ResearchNodeProto.ID;

namespace BetterLife_RoadsAndSigns;


public partial class BetterLIDs
{
    public partial class Research
    {
        public static readonly ResNodeID IndustrialRoads = Ids.Research.CreateId("IndustrialRoads");
        public static readonly ResNodeID CobblestoneRoads = Ids.Research.CreateId("CobblestoneRoads");
        public static readonly ResNodeID RoadBridges = Ids.Research.CreateId("RoadBridges");
        public static readonly ResNodeID Transports = Ids.Research.CreateId("Transports");

    }
}
