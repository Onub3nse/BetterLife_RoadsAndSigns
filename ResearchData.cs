using BetterLife_RoadsAndSigns;
using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;
using Mafi.Core.Research;

namespace BetterLife

{
    internal class ResearchDt : IResearchNodesData
    {
        public void RegisterData(ProtoRegistrator registrator)
        {


            //ResearchNodeProto barrierNodeProto =
            //    registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(Ids.Research.VehicleCapIncrease3);

            ResearchNodeProto nodeProto = registrator.ResearchNodeProtoBuilder

                .Start("Industrial Roads, Signs", BetterLIDs.Research.IndustrialRoads, 6)
                .Description("WarmUP with fresh new roads and signs: +25% Max Speed, -20% Maintenance.")
                //                .AddIcon(Option<ResearchNodeProto>(BetterLIDs.Research.AlterRecipesT1a), "Assets/BetterLife/Icons/BL_Logo2.png")

                // oneway roads
                .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.onewayEntrance)
                .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.onewayExit)
                .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.onewayStraight)
                .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.onewayCorner)
                .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.onewayCross)
                .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.onewayTSection)
                //.AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.onewayBridge1)

                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_Stop)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_Fwd)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_Lft)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_Rocks)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_Drop)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_Highway)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_Limit50)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_Limit80)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_Limit100)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_Limit120)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_Pedestian)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_Train)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_Tunnel)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_Workers)

                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_WrongWay)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_Directional1)

                //.AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_Display)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_COI1)

                .BuildAndAdd();

            nodeProto.GridPosition = new Vector2i(0, -4);
            nodeProto.AddParent(registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(Ids.Research.CpPacking));


            ResearchNodeProto nodeProto1b = registrator.ResearchNodeProtoBuilder
                .Start("Two Way Roads", BetterLIDs.Research.CobblestoneRoads, 8)
                .Description("Two Way Roads.")


                .AddMachineToUnlock(BetterLIDs.Buildings.FuelStation1)
                .AddRequiredProto(Ids.Research.Trains)
                .AddRequirementForLifetimeProduction(Ids.Products.Cement, 100)
                // oneway train bridges
                .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.oneWayTrainBridgeEntrance1)
                .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.oneWayTrainBridgeStraight1)
                .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.oneWayTrainBridgeStraight2x)
                .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.oneWayTrainBridgeCorner1)
                .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.oneWayTrainBridgeExit1)

                // Bidrectional roads
                .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.bidirEntrance)
                .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.bidirStraight)
                .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.bidirCorner)
                .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.bidirTSection)
                .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.bidirCross)
                .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.bidirBridge1)

                .AddLayoutEntityToUnlock(BetterLIDs.Buildings.FuelStation1) // fuel station


                .BuildAndAdd();

            nodeProto1b.GridPosition = nodeProto.GridPosition.AddX(4);
            nodeProto1b.AddParent(registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(BetterLIDs.Research.CobblestoneRoads));

            ResearchNodeProto nodeProto1c = registrator.ResearchNodeProtoBuilder
                .Start("One way train bridges", BetterLIDs.Research.RoadBridges, 8)
                .Description("Bridges to pass over train rails...")


                .AddRequiredProto(Ids.Research.Trains)
                .AddRequirementForLifetimeProduction(Ids.Products.RailParts, 50)
                // oneway train bridges
                .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.oneWayTrainBridgeEntrance1)
                .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.oneWayTrainBridgeStraight1)
                .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.oneWayTrainBridgeStraight2x)
                .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.oneWayTrainBridgeCorner1)
                .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.oneWayTrainBridgeExit1)

                .BuildAndAdd();

            nodeProto1c.GridPosition = nodeProto1b.GridPosition.AddX(4);
            nodeProto1c.AddParent(registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(BetterLIDs.Research.IndustrialRoads));


        }
    }
}
