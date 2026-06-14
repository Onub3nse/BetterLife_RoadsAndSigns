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
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.onewayEntrance)
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.onewayExit)
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.onewayStraight)
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.onewayStraightSmall)
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.onewayCorner)
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.onewayCross)
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.onewayTSection)
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.onewayEntranceExit)
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.onewayLoadUnload)
                //.AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.onewaySlope1)

                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.onewayEntrance2)
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.onewayExit2)
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.onewayStraight2)
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.onewayStraightSmall2)
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.onewayCorner2)
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.onewayCross2)
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.onewayTSection2)
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.onewayEntranceExit2)
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.onewayLoadUnload2)

                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.rampStart1)
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.rampMiddle1)

                //.AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.onewaySlope12)

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
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_50plus)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_80plus)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_100plus)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_120plus)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_BiDir)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_CedaElPaso)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_MainRoad)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_DeadEndLeft)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_DeadEnd)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_DeadEndLeft)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_ForwardRight)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_FuelDiesel)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_FuelH2)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_Hospital)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_LeftRight)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_LevelCrossing)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_NoRight)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_Parking)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_Port)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_TrainModern)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_100m)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_200m)
                .AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_300m)

                //.AddLayoutEntityToUnlock(BetterLIDs.Signs.)


                //.AddLayoutEntityToUnlock(BetterLIDs.Signs.Sign_COI1)

                .BuildAndAdd();

            nodeProto.GridPosition = new Vector2i(0, -4);
            nodeProto.AddParent(registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(Ids.Research.CpPacking));


            //ResearchNodeProto nodeProto1b = registrator.ResearchNodeProtoBuilder
            //    .Start("Two Way Roads", BetterLIDs.Research.CobblestoneRoads, 8)
            //    .Description("Two Way Roads.")


            //    .AddMachineToUnlock(BetterLIDs.Buildings.FuelStation1)
            //    .AddRequiredProto(Ids.Research.Trains)
            //    .AddRequirementForLifetimeProduction(Ids.Products.Cement, 100)
            //    // oneway train bridges
            //    .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.oneWayTrainBridgeEntrance1)
            //    .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.oneWayTrainBridgeStraight1)
            //    .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.oneWayTrainBridgeStraight2x)
            //    .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.oneWayTrainBridgeCorner1)
            //    .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.oneWayTrainBridgeExit1)
             
            //    // Bidrectional roads
            //    .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.bidirEntrance)
            //    .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.bidirStraight)
            //    .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.bidirCorner)
            //    .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.bidirTSection)
            //    .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.bidirCross)
            //    .AddLayoutEntityToUnlock(BetterLIDs.IndustrialRoads.bidirBridge1)

            //    .AddLayoutEntityToUnlock(BetterLIDs.Buildings.FuelStation1) // fuel station


            //    .BuildAndAdd();

            //nodeProto1b.GridPosition = nodeProto.GridPosition.AddX(4);
            //nodeProto1b.AddParent(registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(BetterLIDs.Research.CobblestoneRoads));

            ResearchNodeProto nodeProto1c = registrator.ResearchNodeProtoBuilder
                .Start("One way train bridges", BetterLIDs.Research.RoadBridges, 8)
                .Description("Bridges to pass over train rails...")


                .AddRequiredProto(Ids.Research.Trains)
                .AddRequirementForLifetimeProduction(Ids.Products.RailParts, 50)
                // oneway train bridges
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.oneWayTrainBridgeEntrance1)
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.oneWayTrainBridgeStraight1)
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.oneWayTrainBridgeStraight2x)
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.oneWayTrainBridgeCorner1)
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.oneWayTrainBridgeExit1)

                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.oneWayTrainBridgeEntrance12)
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.oneWayTrainBridgeStraight12)
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.oneWayTrainBridgeStraight2x2)
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.oneWayTrainBridgeCorner12)
                .AddLayoutEntityToUnlock(BetterLIDs.dPath.IndustrialRoads.oneWayTrainBridgeExit12)



                .AddLayoutEntityToUnlock(BetterLIDs.dPath.Buildings.FuelStation1)


                .BuildAndAdd();    

            nodeProto1c.GridPosition = nodeProto.GridPosition.AddX(4);
            nodeProto1c.AddParent(registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(BetterLIDs.Research.IndustrialRoads));


        }
    }
}
