//using static BetterLife.Prototypes.blRoadEntity;
using Mafi.Base;
using Mafi.Core.Entities.Static;
using Mafi.Core.Factory.Transports;
using Mafi.Core.Ports.Io;
using Mafi.Core.Roads;
using static BetterLife_RoadsAndSigns.CustomEntity;
using MachineID = Mafi.Core.Factory.Machines.MachineProto.ID;

namespace BetterLife_RoadsAndSigns
{
    public partial class BetterLIDs
    {
        public partial class dPath
        {
            public dPath(string v1, string v2)
            {
                asset = v1;
                icon = v2;
            }

            public string asset { get; set; }
            public string icon { get; set; }

            public static dPath balancer0_flat = new dPath("Assets/BetterLife/Transports/balancer0/balancer0Flat.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerflat/balancer0flat.png");
            public static dPath balancer1_flat = new dPath("Assets/BetterLife/Transports/balancer1/balancer1flat.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerflat/balancer1flat.png");
            public static dPath balancer2_flat = new dPath("Assets/BetterLife/Transports/balancer2/balancer2flat.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerflat/balancer2flat.png");
            public static dPath balancer3_flat = new dPath("Assets/BetterLife/Transports/balancer3/balancer3flat.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerflat/balancer3flat.png");
            public static dPath balancer4_flat = new dPath("Assets/BetterLife/Transports/balancer4/balancer4flat.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerflat/balancer4flat.png");
            public static dPath balancer5_flat = new dPath("Assets/BetterLife/Transports/balancer5/balancer5flat.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerflat/balancer5flat.png");

            public static dPath balancer0_loose = new dPath("Assets/BetterLife/Transports/balancer0/balancer0loose.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerloose/balancer0loose.png");
            public static dPath balancer1_loose = new dPath("Assets/BetterLife/Transports/balancer1/balancer1loose.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerloose/balancer1loose.png");
            public static dPath balancer2_loose = new dPath("Assets/BetterLife/Transports/balancer2/balancer2loose.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerloose/balancer2loose.png");
            public static dPath balancer3_loose = new dPath("Assets/BetterLife/Transports/balancer3/balancer3loose.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerloose/balancer3loose.png");
            public static dPath balancer4_loose = new dPath("Assets/BetterLife/Transports/balancer4/balancer4loose.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerloose/balancer4loose.png");
            public static dPath balancer5_loose = new dPath("Assets/BetterLife/Transports/balancer5/balancer5loose.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerloose/balancer5loose.png");

            public static dPath balancer0_pipe = new dPath("Assets/BetterLife/Transports/balancer0/balancer0pipe.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerPipe.png");
            public static dPath balancer1_pipe = new dPath("Assets/BetterLife/Transports/balancer1/balancer1pipe.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerPipe.png");
            public static dPath balancer2_pipe = new dPath("Assets/BetterLife/Transports/balancer2/balancer2pipe.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerPipe.png");
            public static dPath balancer3_pipe = new dPath("Assets/BetterLife/Transports/balancer3/balancer3pipe.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerPipe.png");
            public static dPath balancer4_pipe = new dPath("Assets/BetterLife/Transports/balancer4/balancer4pipe.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerPipe.png");
            public static dPath balancer5_pipe = new dPath("Assets/BetterLife/Transports/balancer5/balancer5pipe.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerPipe.png");


            public static dPath balancer0_molten = new dPath("Assets/BetterLife/Transports/balancer0/balancer0molten.prefab", "Assets/BetterLife/Icons/TransportIcons/balancer0_molten.png");
            public static dPath balancer1_molten = new dPath("Assets/BetterLife/Transports/balancer1/balancer1molten.prefab", "Assets/BetterLife/Icons/TransportIcons/balancer0_molten.png");
            public static dPath balancer2_molten = new dPath("Assets/BetterLife/Transports/balancer2/balancer2molten.prefab", "Assets/BetterLife/Icons/TransportIcons/balancer0_molten.png");
            public static dPath balancer3_molten = new dPath("Assets/BetterLife/Transports/balancer3/balancer3molten.prefab", "Assets/BetterLife/Icons/TransportIcons/balancer0_molten.png");
            public static dPath balancer4_molten = new dPath("Assets/BetterLife/Transports/balancer4/balancer4molten.prefab", "Assets/BetterLife/Icons/TransportIcons/balancer0_molten.png");
            public static dPath balancer5_molten = new dPath("Assets/BetterLife/Transports/balancer5/balancer5molten.prefab", "Assets/BetterLife/Icons/TransportIcons/balancer0_molten.png");

            public static dPath balancer0_shaft = new dPath("Assets/BetterLife/Transports/balancer0/balancer0shaft.prefab", "Assets/BetterLife/Icons/TransportIcons/balancer0shaft.png");
            public static dPath balancer1_shaft = new dPath("Assets/BetterLife/Transports/balancer1/balancer1shaft.prefab", "Assets/BetterLife/Icons/TransportIcons/balancer0shaft.png");
            public static dPath balancer2_shaft = new dPath("Assets/BetterLife/Transports/balancer2/balancer2shaft.prefab", "Assets/BetterLife/Icons/TransportIcons/balancer0shaft.png");
            public static dPath balancer3_shaft = new dPath("Assets/BetterLife/Transports/balancer3/balancer3shaft.prefab", "Assets/BetterLife/Icons/TransportIcons/balancer0shaft.png");
            public static dPath balancer4_shaft = new dPath("Assets/BetterLife/Transports/balancer4/balancer4shaft.prefab", "Assets/BetterLife/Icons/TransportIcons/balancer0shaft.png");
            public static dPath balancer5_shaft = new dPath("Assets/BetterLife/Transports/balancer5/balancer5shaft.prefab", "Assets/BetterLife/Icons/TransportIcons/balancer0shaft.png");

            public static dPath loader1_flat = new dPath("Assets/BetterLife/Transports/loader1/loader1Flat.prefab", "Assets/BetterLife/Icons/TransportIcons/loader1Flat.png");
            public static dPath loader1_loose = new dPath("Assets/BetterLife/Transports/loader1/loader1.prefab", "Assets/BetterLife/Icons/TransportIcons/loader_loose.png");
            public static dPath loader1_pipe = new dPath("Assets/BetterLife/Transports/loader1/loader1.prefab", "Assets/BetterLife/Icons/TransportIcons/loader_pipe.png");
            public static dPath loader1_molten = new dPath("Assets/BetterLife/Transports/loader1/loader1.prefab", "Assets/BetterLife/Icons/TransportIcons/loader_molten.png");
            public static dPath loader1_shaft = new dPath("Assets/BetterLife/Transports/loader1/loader1.prefab", "Assets/BetterLife/Icons/TransportIcons/loader_shaft.png");

            public static dPath transBar4flat = new dPath("Assets/BetterLife/Transports/transportbars/bar4m/tbar4flat.prefab", "Assets/BetterLife/Icons/TransportIcons/transbar4flat.png");
            public static dPath transBar4loose = new dPath("Assets/BetterLife/Transports/transportbars/bar4m/tbar4flat.prefab", "Assets/BetterLife/Icons/TransportIcons/transbar4loose.png");
            public static dPath transBar4pipe = new dPath("Assets/BetterLife/Transports/transportbars/bar10m/transportBar4flat.prefab", "Assets/BetterLife/Icons/TransportIcons/transbar4pipe.png");
            public static dPath transBar4molten = new dPath("Assets/BetterLife/Transports/transportbars/bar10m/transportBar4flat.prefab", "Assets/BetterLife/Icons/TransportIcons/transbar4molten.png");
            public static dPath transBar4shaft = new dPath("Assets/BetterLife/Transports/transportbars/bar10m/transportBar4flat.prefab", "Assets/BetterLife/Icons/TransportIcons/transbar4shaft.png");
            public static dPath transBar10flat = new dPath("Assets/BetterLife/Transports/transportbars/bar10m/transportBar10flat.prefab", "Assets/BetterLife/Icons/TransportIcons/transbar4flat.png");

            public static dPath meter1 = new dPath("Assets/BetterLife/Misc/Meter/meter1.prefab", "Assets/BetterLife/Icons/Misc/meter1.png");
            public static dPath meter2 = new dPath("Assets/BetterLife/Misc/Meter/meter2.prefab", "Assets/BetterLife/Icons/Misc/meter2.png");
            public static dPath meter3 = new dPath("Assets/BetterLife/Misc/Meter/meter3.prefab", "Assets/BetterLife/Icons/Misc/meter3.png");
            public static dPath meter4 = new dPath("Assets/BetterLife/Misc/Meter/meter4.prefab", "Assets/BetterLife/Icons/Misc/meter4.png");

            public static dPath sign_coi1 = new dPath("Assets/BetterLife/Signs/signcoi1.prefab", "Assets/BetterLife/Icons/Signs/coisign1.png");
            public static dPath ind_light1 = new dPath("Assets/BetterLife/Misc/IndusLight1/IndLight1.prefab", "Assets/BetterLife/Icons/Misc/indLight1.png");

            public static dPath sign_wrongWay = new dPath("Assets/BetterLife/Signs/Sign_WrongWay.prefab", "Assets/BetterLife/Icons/Signs/prohibidoelpaso.png");
            public static dPath sign_directional1 = new dPath("Assets/BetterLife/Signs/Sign_BiDirectional.prefab", "Assets/BetterLife/Icons/Signs/DobleSentido2.png");

            public static dPath transPORT20_flat = new dPath("Assets/BetterLife/Transports/transport20/transport20.prefab", "Assets/BetterLife/Icons/TransportIcons/transport20_flat.png");
            public static dPath transPORT20_loose = new dPath("", "");
            public static dPath transPORT20_pipe = new dPath("", "");
            public static dPath transPORT20_molten = new dPath("", "");
            public static dPath transPORT20_shaft = new dPath("", "");

            public static dPath transPORT40_flat = new dPath("Assets/BetterLife/Transports/transport40/transport40_flat.prefab", "Assets/BetterLife/Icons/TransportIcons/transport40_flat.png");
            public static dPath transPORT40_loose = new dPath("", "");
            public static dPath transPORT40_pipe = new dPath("", "");
            public static dPath transPORT40_molten = new dPath("", "");
            public static dPath transPORT40_shaft = new dPath("", "");

            public static dPath transPORT100_flat = new dPath("", "");
            public static dPath transPORT100_loose = new dPath("", "");
            public static dPath transPORT100_pipe = new dPath("", "");
            public static dPath transPORT100_molten = new dPath("", "");
            public static dPath transPORT100_shaft = new dPath("", "");

            public static dPath wall1type1 = new dPath("Assets/BetterLife/Walls/WallA/straight1.prefab", "Assets/BetterLife/Icons/Walls/WallA_Straight.png");
            public static dPath wall1crosstype1 = new dPath("Assets/BetterLife/Walls/WallA/cross1.prefab", "Assets/BetterLife/Icons/Walls/WalLA_Cross.png");
            public static dPath wall1teetype1 = new dPath("Assets/BetterLife/Walls/WallA/tee1.prefab", "Assets/BetterLife/Icons/Walls/WallA_Tee.png");
            public static dPath wall1cornertype1 = new dPath("Assets/BetterLife/Walls/WallA/corner1.prefab", "Assets/BetterLife/Icons/Walls/WallA_Corner.png");
        }

        public partial class RoadEntities
        {
            public static readonly StaticEntityProto.ID road1 = new StaticEntityProto.ID("road1");
            public static readonly StaticEntityProto.ID roadEntrance1 = new StaticEntityProto.ID("roadEntrance1");
            public static dPath onewayEntrance = new dPath("Assets/BetterLife/Roads/Industrial/OneWaySet/onewayEntrance.prefab", "Assets/BetterLife/Icons/RoadIndustrial/onewayEntrance.png");
            public static dPath onewayExit = new dPath("Assets/BetterLife/Roads/Industrial/OneWaySet/onewayExit.prefab", "Assets/BetterLife/Icons/RoadIndustrial/exit.png");
            public static dPath onewayStraight = new dPath("Assets/BetterLife/Roads/Industrial/OneWaySet/onewayStraight.prefab", "Assets/BetterLife/Icons/RoadIndustrial/oneway_straight.png");
            public static dPath onewayCorner = new dPath("Assets/BetterLife/Roads/Industrial/OneWaySet/onewayCorner.prefab", "Assets/BetterLife/Icons/RoadIndustrial/onewayCorner.png");
            public static dPath onewayCross = new dPath("Assets/BetterLife/Roads/Industrial/OneWaySet/onewayCross.prefab", "Assets/BetterLife/Icons/RoadIndustrial/onewayCross.png");
            public static dPath onewayBridge = new dPath("Assets/BetterLife/Roads/Industrial/OneWaySet/onewayBridgeSeg1.prefab", "Assets/BetterLife/Icons/RoadIndustrial/onewayBridge1.png");
            public static dPath onewayTSection = new dPath("Assets/BetterLife/Roads/Industrial/OneWaySet/onewayTee.prefab", "Assets/BetterLife/Icons/RoadIndustrial/onewayTee.png");

            public static dPath onewayTrainBridgeEntrance1 = new dPath("Assets/BetterLife/Roads/Industrial/OneWaySet/onewayTrainBridgeEntrance1.prefab", "Assets/BetterLife/Icons/RoadIndustrial/onewayBridgeEntrance1.png");
            public static dPath onewayTrainBridgeStraight1 = new dPath("Assets/BetterLife/Roads/Industrial/OneWaySet/onewayTrainBridgeStraight1.prefab", "Assets/BetterLife/Icons/RoadIndustrial/onewayTrainBridgeStraight1.png");
            public static dPath onewayTrainBridgeStraight2x = new dPath("Assets/BetterLife/Roads/Industrial/OneWaySet/onewayTrainBridgeStraight2x.prefab", "Assets/BetterLife/Icons/RoadIndustrial/onewayTrainBridgeStraight2x.png");
            public static dPath onewayTrainBridgeCorner1 = new dPath("Assets/BetterLife/Roads/Industrial/OneWaySet/onewayTrainBridgeCorner1.prefab", "Assets/BetterLife/Icons/RoadIndustrial/onewayTrainBridgeCorner1.png");
            public static dPath onewayTrainBridgeExit1 = new dPath("Assets/BetterLife/Roads/Industrial/OneWaySet/onewayTrainBridgeExit1.prefab", "Assets/BetterLife/Icons/RoadIndustrial/onewayBridgeExit.png");

            public static dPath bidirEntrance = new dPath("Assets/BetterLife/Roads/Industrial/bidirEntrance.prefab", "Assets/BetterLife/Icons/RoadIndustrial/entrance.png");
            public static dPath bidirStraight = new dPath("Assets/BetterLife/Roads/Industrial/bidirStraight.prefab", "Assets/BetterLife/Icons/RoadIndustrial/straight.png");
            public static dPath bidirCross = new dPath("Assets/BetterLife/Roads/Industrial/bidirCross.prefab", "Assets/BetterLife/Icons/RoadIndustrial/cross.png");
            public static dPath bidirTee = new dPath("Assets/BetterLife/Roads/Industrial/bidirTSection.prefab", "Assets/BetterLife/Icons/RoadIndustrial/tsection.png");
            public static dPath bidirCorner = new dPath("Assets/BetterLife/Roads/Industrial/bidirCorner.prefab", "Assets/BetterLife/Icons/RoadIndustrial/corner.png");
            public static dPath bidirStraightL = new dPath("Assets/BetterLife/Roads/Industrial/bidirStraightLarge.prefab", "Assets/BetterLife/Icons/RoadIndustrial/largeStraight.png");
            public static dPath bidirBridge1 = new dPath("Assets/BetterLife/Roads/Industrial/bidirBridge1.prefab", "Assets/BetterLife/Icons/RoadIndustrial/indRoadBridge1.png");

            public static dPath roadTODO = new dPath("TODO", "TODO");

            public static dPath fuelStation1 = new dPath("Assets/BetterLife/Buildings/FuelStation1/FuelStation1.prefab", "Assets/BetterLife/Icons/Buildings/fuelstation1.png");
        }

        public partial class PortShapes
        {
            public static readonly IoPortShapeProto.ID mFlat = new IoPortShapeProto.ID("mFlat");
            public static readonly IoPortShapeProto.ID mLoose = new IoPortShapeProto.ID("mLoose");
            public static readonly IoPortShapeProto.ID mPipe = new IoPortShapeProto.ID("mPipe");
            public static readonly IoPortShapeProto.ID mMolten = new IoPortShapeProto.ID("mMolten");
            public static readonly IoPortShapeProto.ID mShaft = new IoPortShapeProto.ID("mShaft");
        }

        public partial class newTransports
        {
            public static readonly TransportProto.ID newtransFlat = new TransportProto.ID("transportFlat");
        }

        public partial class Storages
        {
            public static readonly CustomEntityPrototype.ID indStorage1 = new CustomEntityPrototype.ID("indStorage1");
        }

        public partial class Machines
        {
            public static readonly MachineID AssemblyBlt1 = Ids.Machines.CreateId("AssemblyBlt1");
            public static readonly MachineID AssemblyBlt2 = Ids.Machines.CreateId("AssemblyBlt2");
            //            public static readonly MachineID AssemblyBlt3 = Ids.Machines.CreateId("AssemblyBlt3");
            public static readonly StaticEntityProto.ID fuelstation1 = new StaticEntityProto.ID("fuelStation1");
        }

        public partial class transPorts
        {

        }

        public partial class IndustrialRoads
        {
            public static readonly RoadEntityProto.ID bidirEntrance = new RoadEntityProto.ID("bidirEntrance");
            public static readonly RoadEntityProto.ID bidirStraight = new RoadEntityProto.ID("bidirStraight");
            public static readonly RoadEntityProto.ID bidirStraightL = new RoadEntityProto.ID("bidirStraightL");
            public static readonly RoadEntityProto.ID bidirCorner = new RoadEntityProto.ID("bidirCorner");
            public static readonly RoadEntityProto.ID bidirTSection = new RoadEntityProto.ID("bidirTSection");
            public static readonly RoadEntityProto.ID bidirCross = new RoadEntityProto.ID("bidirCross");
            public static readonly RoadEntityProto.ID bidirBridge1 = new RoadEntityProto.ID("bidirBridge1");


            public static readonly RoadEntityProto.ID onewayEntrance = new RoadEntityProto.ID("onewayEntrance");
            public static readonly RoadEntityProto.ID onewayExit = new RoadEntityProto.ID("onewayExit");
            public static readonly RoadEntityProto.ID onewayStraight = new StaticEntityProto.ID("onewayStraight");
            public static readonly RoadEntityProto.ID onewayCorner = new StaticEntityProto.ID("onewayCorner");
            public static readonly RoadEntityProto.ID onewayCross = new StaticEntityProto.ID("onewayCross");
            public static readonly RoadEntityProto.ID onewayTSection = new StaticEntityProto.ID("onewayTSection");
            public static readonly RoadEntityProto.ID onewayBridge1 = new StaticEntityProto.ID("onewayBridge1");
            public static readonly RoadEntityProto.ID oneWayTrainBridgeEntrance1 = new RoadEntityProto.ID("onewayTrainBridgeEntrance1");
            public static readonly RoadEntityProto.ID oneWayTrainBridgeStraight1 = new RoadEntityProto.ID("onewayTrainBridgeStraight1");
            public static readonly RoadEntityProto.ID oneWayTrainBridgeStraight2x = new RoadEntityProto.ID("onewayTrainBridgeStraight2x");
            public static readonly RoadEntityProto.ID oneWayTrainBridgeCorner1 = new RoadEntityProto.ID("onewayTrainBridgeCorner1");
            public static readonly RoadEntityProto.ID oneWayTrainBridgeExit1 = new RoadEntityProto.ID("onewayTrainBridgeExit1");

            public static readonly RoadEntityProto.ID roadWayPoint = new RoadEntityProto.ID("roadWayPoint");

        }

        public partial class Roads
        {
            public static readonly RoadEntityProto.ID Road1Entrance = new RoadEntityProto.ID("Road1Entrance");
            public static readonly RoadEntityProto.ID Road1EntranceShort = new RoadEntityProto.ID("Road1EntranceShort");
            public static readonly RoadEntityProto.ID Road1Straight = new RoadEntityProto.ID("Road1Straight");
            public static readonly RoadEntityProto.ID Road1StraightSmall = new RoadEntityProto.ID("Road1StraightSmall");
            public static readonly RoadEntityProto.ID Road1LargeStraight = new RoadEntityProto.ID("Road1LargeStraight");
            public static readonly RoadEntityProto.ID Road1Corner = new RoadEntityProto.ID("Road1Corner");
            public static readonly RoadEntityProto.ID Road1CornerSmall = new RoadEntityProto.ID("Road1CornerSmall");
            public static readonly RoadEntityProto.ID Road1CrossFiller = new RoadEntityProto.ID("Road1CrossFiller");
            public static readonly RoadEntityProto.ID Road1TSection = new RoadEntityProto.ID("Road1TSection");
            public static readonly RoadEntityProto.ID Road1Cross = new RoadEntityProto.ID("Road1Cross");
            public static readonly RoadEntityProto.ID Road1ShortBridge1 = new RoadEntityProto.ID("Road1ShortBridge1");
            //public static readonly RoadEntityProto.ID Road1Single = new RoadEntityProto.ID("Road1Single");
            //public static readonly RoadEntityProto.ID Road1Short = new RoadEntityProto.ID("Road1Short");
            public static readonly RoadEntityProto.ID Road1Pillar = new RoadEntityProto.ID("Road1Pillar");
        }


        public partial class Buildings
        {
            public static readonly CustomEntityPrototype.ID MineTowerDecor = new CustomEntityPrototype.ID("eMineTowerDecor");
            public static readonly CustomEntityPrototype.ID BillBoard1 = new CustomEntityPrototype.ID("eBillBoard1");
            public static readonly MachineID FuelStation1 = Ids.Machines.CreateId("FuelStation1");
            public static readonly CustomEntityPrototype.ID VehDepot1 = new CustomEntityPrototype.ID("vehicleDepot");
            //public static readonly CustomEntityPrototype.ID RadioTower1 = new CustomEntityPrototype.ID("radiotower");
        }


        public partial class Tools
        {
            //       public static readonly CustomEntityPrototype.ID Tool1 = new CustomEntityPrototype.ID("eTool1");
        }

        public partial class Signs
        {
            public static readonly CustomEntityPrototype.ID Sign_Stop = new CustomEntityPrototype.ID("eStop");
            public static readonly CustomEntityPrototype.ID Sign_Fwd = new CustomEntityPrototype.ID("eSignFwd");
            public static readonly CustomEntityPrototype.ID Sign_Lft = new CustomEntityPrototype.ID("eSignLft");
            public static readonly CustomEntityPrototype.ID Sign_Rocks = new CustomEntityPrototype.ID("eSignRocks");
            public static readonly CustomEntityPrototype.ID Sign_Drop = new CustomEntityPrototype.ID("eSignDrop");
            public static readonly CustomEntityPrototype.ID Sign_Highway = new CustomEntityPrototype.ID("eSignHighway");
            public static readonly CustomEntityPrototype.ID Sign_Limit50 = new CustomEntityPrototype.ID("eSignLimit50");
            public static readonly CustomEntityPrototype.ID Sign_Limit80 = new CustomEntityPrototype.ID("eSignLimit80");
            public static readonly CustomEntityPrototype.ID Sign_Limit100 = new CustomEntityPrototype.ID("eSignLimit100");
            public static readonly CustomEntityPrototype.ID Sign_Limit120 = new CustomEntityPrototype.ID("eSignLimit120");
            public static readonly CustomEntityPrototype.ID Sign_Pedestian = new CustomEntityPrototype.ID("eSignPedestian");
            public static readonly CustomEntityPrototype.ID Sign_Train = new CustomEntityPrototype.ID("eSignTrain");
            public static readonly CustomEntityPrototype.ID Sign_Tunnel = new CustomEntityPrototype.ID("eSignTunnel");
            public static readonly CustomEntityPrototype.ID Sign_Workers = new CustomEntityPrototype.ID("eSignWorkers");
            public static readonly CustomEntityPrototype.ID Sign_Display = new CustomEntityPrototype.ID("eSignDisplay");
            public static readonly CustomEntityPrototype.ID Sign_COI1 = new CustomEntityPrototype.ID("eSigncoi1");
            public static readonly CustomEntityPrototype.ID Sign_WrongWay = new CustomEntityPrototype.ID("eWrongWay");
            public static readonly CustomEntityPrototype.ID Sign_Directional1 = new CustomEntityPrototype.ID("eDirectional1");


        }


    }
}