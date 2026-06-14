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


            public static dPath sign_coi1 = new dPath("Assets/BetterLife/Signs/signcoi1.prefab", "Assets/BetterLife/Icons/Signs/coisign1.png");

            public static dPath sign_wrongWay = new dPath("Assets/BetterLife/Signs/sign_wrongway.prefab", "Assets/BetterLife/IconsRoad/Signs/prohibidoelpaso.png");
            public static dPath sign_50plus = new dPath("Assets/BetterLife/Signs/sign_50plus.prefab", "Assets/BetterLife/IconsRoad/Signs/Sign_50plus.svg");
            public static dPath sign_80plus = new dPath("Assets/BetterLife/Signs/sign_80plus.prefab", "Assets/BetterLife/IconsRoad/Signs/Sign_80plus.svg");
            public static dPath sign_100plus = new dPath("Assets/BetterLife/Signs/sign_100plus.prefab", "Assets/BetterLife/IconsRoad/Signs/Sign_100plus.svg");
            public static dPath sign_120plus = new dPath("Assets/BetterLife/Signs/sign_120plus.prefab", "Assets/BetterLife/IconsRoad/Signs/Sign_120plus.svg");

            public static dPath sign_100m = new dPath("Assets/BetterLife/Signs/sign_100m.prefab", "Assets/BetterLife/IconsRoad/Signs/sign_100m.png");
            public static dPath sign_200m = new dPath("Assets/BetterLife/Signs/sign_200m.prefab", "Assets/BetterLife/IconsRoad/Signs/sign_200m.png");
            public static dPath sign_300m = new dPath("Assets/BetterLife/Signs/sign_300m.prefab", "Assets/BetterLife/IconsRoad/Signs/sign_300m.png");
            public static dPath sign_deadend = new dPath("Assets/BetterLife/Signs/sign_deadend.prefab", "Assets/BetterLife/IconsRoad/Signs/Sign_EndOfRoad.svg");
            public static dPath sign_deadendLeft = new dPath("Assets/BetterLife/Signs/sign_deadendleft.prefab", "Assets/BetterLife/IconsRoad/Signs/Sign_DeadEndLeft.svg");
            public static dPath sign_forwardRight = new dPath("Assets/BetterLife/Signs/sign_forwardright.prefab", "Assets/BetterLife/IconsRoad/Signs/Sign_ForwardRight.svg");
            public static dPath sign_fueldiesel = new dPath("Assets/BetterLife/Signs/sign_fueldiesel.prefab", "Assets/BetterLife/IconsRoad/Signs/Sign_FuelDiesel.svg");
            public static dPath sign_fuelh2 = new dPath("Assets/BetterLife/Signs/sign_fuelh2.prefab", "Assets/BetterLife/IconsRoad/Signs/Sign_FuelH2.svg");
            public static dPath sign_hospital = new dPath("Assets/BetterLife/Signs/sign_hospital.prefab", "Assets/BetterLife/IconsRoad/Signs/Sign_Hospital.svg");
            public static dPath sign_leftright = new dPath("Assets/BetterLife/Signs/sign_leftright.prefab", "Assets/BetterLife/IconsRoad/Signs/Sign_LeftRight.svg");
            public static dPath sign_levelcrossing = new dPath("Assets/BetterLife/Signs/sign_levelcrossing.prefab", "Assets/BetterLife/IconsRoad/Signs/Sign_LevelCrossing.svg");
            public static dPath sign_noright = new dPath("Assets/BetterLife/Signs/sign_rightnotallowed.prefab", "Assets/BetterLife/IconsRoad/Signs/Sign_NoRightTurn.svg");
            public static dPath sign_parking = new dPath("Assets/BetterLife/Signs/sign_parking.prefab", "Assets/BetterLife/IconsRoad/Signs/Sign_Parking.svg");
            public static dPath sign_port = new dPath("Assets/BetterLife/Signs/sign_port.prefab", "Assets/BetterLife/IconsRoad/Signs/Sign_Port.svg");
            public static dPath sign_pref = new dPath("Assets/BetterLife/Signs/sign_giveway.prefab", "Assets/BetterLife/IconsRoad/Signs/Sign_CedaElPaso.png");
            public static dPath sign_youpref = new dPath("Assets/BetterLife/Signs/sign_romboamarillo.prefab", "Assets/BetterLife/IconsRoad/Signs/Zeichen_306_-_Vorfahrtstraße,_StVO_1970.svg");
            public static dPath sign_stop = new dPath("Assets/BetterLife/Signs/sign_stop.prefab", "Assets/BetterLife/IconsRoad/Signs/Sign_Stop.svg");
            public static dPath sign_trainModern = new dPath("Assets/BetterLife/Signs/sign_train2.prefab", "Assets/BetterLife/IconsRoad/Signs/Sign_TrainModern.svg");
            public static dPath sign_directional1 = new dPath("Assets/BetterLife/Signs/sign_bothdirections.prefab", "Assets/BetterLife/IconsRoad/Signs/DobleSentido2.png");
            public static dPath sign_priority = new dPath("Assets/BetterLife/Signs/sign_priority.prefab", "Assets/BetterLife/IconsRoad/Signs/Sign_BiDirectional.svg");
            //public static dPath sign_ = new dPath("", "");



            public partial class RoadEntities
            {
                public static readonly StaticEntityProto.ID road1 = new StaticEntityProto.ID("road1");
                public static readonly StaticEntityProto.ID roadEntrance1 = new StaticEntityProto.ID("roadEntrance1");
                //public static dPath onewayEntrance = new dPath("Assets/BetterLife/Roads/Industrial/Set3/onewayEntrance.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/onewayEntrance.png");
                //public static dPath onewayExit = new dPath("Assets/BetterLife/Roads/Industrial/Set3/onewayExit.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/onewayExit.png");
                //public static dPath onewayStraight = new dPath("Assets/BetterLife/Roads/Industrial/Set3/onewayStraight.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/oneway_straight.png");
                //public static dPath onewayStraightSmall = new dPath("Assets/BetterLife/Roads/Industrial/Set3/onewayStraightSmall.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/oneway_straightSmall.png");
                //public static dPath onewaySlope1 = new dPath("Assets/BetterLife/Roads/Industrial/OneWaySet/slope1.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/oneway_straightSmall.png");
                //public static dPath onewayCorner = new dPath("Assets/BetterLife/Roads/Industrial/Set3/onewayCorner.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/onewayCorner.png");
                //public static dPath onewayCross = new dPath("Assets/BetterLife/Roads/Industrial/Set3/onewayCross.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/onewayCross.png");
                //public static dPath onewayBridge = new dPath("Assets/BetterLife/Roads/Industrial/OneWaySet/onewayBridgeSeg1.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/onewayBridge1.png");
                //public static dPath onewayTSection = new dPath("Assets/BetterLife/Roads/Industrial/Set3/onewayTee.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/onewayTee.png");
                //public static dPath onewayEntranceExit = new dPath("Assets/BetterLife/Roads/Industrial/Set3/onewayEntranceExit.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/oneway_EntranceExit.png");

                public static dPath onewayEntrance = new dPath("Assets/BetterLife/Roads/Industrial/Set1/onewayEntrance.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/onewayEntrance.png");
                public static dPath onewayExit = new dPath("Assets/BetterLife/Roads/Industrial/Set1/onewayExit.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/onewayExit.png");
                public static dPath onewayStraight = new dPath("Assets/BetterLife/Roads/Industrial/Set1/onewayStraight.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/oneway_straight.png");
                public static dPath onewayStraightSmall = new dPath("Assets/BetterLife/Roads/Industrial/Set1/onewayStraightSmall.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/oneway_straightSmall.png");
                public static dPath onewaySlope1 = new dPath("Assets/BetterLife/Roads/Industrial/OneWaySet/slope1.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/oneway_straightSmall.png");
                public static dPath onewayCorner = new dPath("Assets/BetterLife/Roads/Industrial/Set1/onewayCorner.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/onewayCorner.png");
                public static dPath onewayCross = new dPath("Assets/BetterLife/Roads/Industrial/Set1/onewayCross.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/onewayCross.png");
                public static dPath onewayBridge = new dPath("Assets/BetterLife/Roads/Industrial/OneWaySet/onewayBridgeSeg1.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/onewayBridge1.png");
                public static dPath onewayTSection = new dPath("Assets/BetterLife/Roads/Industrial/Set1/onewayTee.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/onewayTee.png");
                public static dPath onewayEntranceExit = new dPath("Assets/BetterLife/Roads/Industrial/Set1/onewayEntranceExit.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/oneway_EntranceExit.png");
         
                public static dPath onewayEntrance2 = new dPath("Assets/BetterLife/Roads/Industrial/Set2/onewayEntrance.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/set2/oneway_entrance.png");
                public static dPath onewayExit2 = new dPath("Assets/BetterLife/Roads/Industrial/Set2/onewayExit.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/set2/oneway_exit.png");
                public static dPath onewayStraight2 = new dPath("Assets/BetterLife/Roads/Industrial/Set2/onewayStraight.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/set2/oneway_straight.png");
                public static dPath onewayStraightSmall2 = new dPath("Assets/BetterLife/Roads/Industrial/Set2/onewayStraightSmall.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/set2/oneway_straightsmall.png");
                public static dPath onewayCorner2 = new dPath("Assets/BetterLife/Roads/Industrial/Set2/onewayCorner.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/set2/oneway_corner.png");
                public static dPath onewayCross2 = new dPath("Assets/BetterLife/Roads/Industrial/Set2/onewayCross.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/set2/oneway_cross.png");
                public static dPath onewayTSection2 = new dPath("Assets/BetterLife/Roads/Industrial/Set2/onewayTee.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/set2/oneway_tsection.png");
                public static dPath onewayEntranceExit2 = new dPath("Assets/BetterLife/Roads/Industrial/Set2/onewayEntranceExit.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/set2/oneway_entranceexit.png");

                public static dPath onewayTrainBridgeEntrance1 = new dPath("Assets/BetterLife/Roads/Industrial/Set1/onewayTrainBridgeEntrance1.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/onewayBridgeEntrance1.png");
                public static dPath onewayTrainBridgeStraight1 = new dPath("Assets/BetterLife/Roads/Industrial/Set1/onewayTrainBridgeStraight1.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/onewayTrainBridgeStraight1.png");
                public static dPath onewayTrainBridgeStraight2x = new dPath("Assets/BetterLife/Roads/Industrial/Set1/onewayTrainBridgeStraight2x.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/onewayBridgeStraight2x.png");
                public static dPath onewayTrainBridgeCorner1 = new dPath("Assets/BetterLife/Roads/Industrial/Set1/onewayTrainBridgeCorner1.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/onewayTrainBridgeCorner.png");
                public static dPath onewayTrainBridgeExit1 = new dPath("Assets/BetterLife/Roads/Industrial/Set1/onewayTrainBridgeExit1.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/onewayBridgeExit.png");
                   
                public static dPath onewayTrainBridgeEntrance12 = new dPath("Assets/BetterLife/Roads/Industrial/Set2/onewayTrainBridgeEntrance1.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/set2/oneway_bridgeentrance.png");
                public static dPath onewayTrainBridgeStraight12 = new dPath("Assets/BetterLife/Roads/Industrial/Set2/onewayTrainBridgeStraight1.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/set2/oneway_bridgestraight.png");
                public static dPath onewayTrainBridgeStraight2x2 = new dPath("Assets/BetterLife/Roads/Industrial/Set2/onewayTrainBridgeStraight2x.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/set2/oneway_bridgestraight2x.png");
                public static dPath onewayTrainBridgeCorner12 = new dPath("Assets/BetterLife/Roads/Industrial/Set2/onewayTrainBridgeCorner1.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/set2/oneway_bridgecorner.png");
                public static dPath onewayTrainBridgeExit12 = new dPath("Assets/BetterLife/Roads/Industrial/Set2/onewayTrainBridgeExit1.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/set2/oneway_bridgeexit.png");
                 
                public static dPath bidirEntrance = new dPath("Assets/BetterLife/Roads/Industrial/bidirEntrance.prefab", "Assets/BetterLife/Icons/RoadIndustrial/entrance.png");
                public static dPath bidirStraight = new dPath("Assets/BetterLife/Roads/Industrial/bidirStraight.prefab", "Assets/BetterLife/Icons/RoadIndustrial/straight.png");
                public static dPath bidirCross = new dPath("Assets/BetterLife/Roads/Industrial/bidirCross.prefab", "Assets/BetterLife/Icons/RoadIndustrial/cross.png");
                public static dPath bidirTee = new dPath("Assets/BetterLife/Roads/Industrial/bidirTSection.prefab", "Assets/BetterLife/Icons/RoadIndustrial/tsection.png");
                public static dPath bidirCorner = new dPath("Assets/BetterLife/Roads/Industrial/bidirCorner.prefab", "Assets/BetterLife/Icons/RoadIndustrial/corner.png");
                public static dPath bidirStraightL = new dPath("Assets/BetterLife/Roads/Industrial/bidirStraightLarge.prefab", "Assets/BetterLife/Icons/RoadIndustrial/largeStraight.png");
                public static dPath bidirBridge1 = new dPath("Assets/BetterLife/Roads/Industrial/bidirBridge1.prefab", "Assets/BetterLife/Icons/RoadIndustrial/indRoadBridge1.png");

                public static dPath rampStart1 = new dPath("Assets/BetterLife/Roads/ramp1/rampStart1.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/rampStart1.png");
                public static dPath rampMiddle1 = new dPath("Assets/BetterLife/Roads/ramp1/rampMiddle1.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/rampMiddle1.png");


                public static dPath roadTODO = new dPath("TODO", "TODO");

                public static dPath fuelStation1 = new dPath("Assets/BetterLife/Buildings/FuelStation1/FuelStation1.prefab", "Assets/BetterLife/IconsRoad/Buildings/fuelstation1.png");
                public static dPath ind_light1 = new dPath("Assets/BetterLife/Roads/Industrial/indLight1.prefab", "Assets/BetterLife/IconsRoad/Misc/indLight1.png");
                public static dPath onewayLoadUnload = new dPath("Assets/BetterLife/Roads/Industrial/Set1/onewayIndustrialZone.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/onewayLoadUnLoad.png");
                public static dPath onewayLoadUnload2 = new dPath("Assets/BetterLife/Roads/Industrial/Set2/onewayIndustrialZone.prefab", "Assets/BetterLife/IconsRoad/RoadIndustrial/onewayLoadUnLoad.png");

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
                //public static readonly RoadEntityProto.ID bidirEntrance = new RoadEntityProto.ID("bidirEntrance");
                //public static readonly RoadEntityProto.ID bidirStraight = new RoadEntityProto.ID("bidirStraight");
                //public static readonly RoadEntityProto.ID bidirStraightL = new RoadEntityProto.ID("bidirStraightL");
                //public static readonly RoadEntityProto.ID bidirCorner = new RoadEntityProto.ID("bidirCorner");
                //public static readonly RoadEntityProto.ID bidirTSection = new RoadEntityProto.ID("bidirTSection");
                //public static readonly RoadEntityProto.ID bidirCross = new RoadEntityProto.ID("bidirCross");
                //public static readonly RoadEntityProto.ID bidirBridge1 = new RoadEntityProto.ID("bidirBridge1");

                // Set 1
                public static readonly RoadEntityProto.ID onewayEntrance = new RoadEntityProto.ID("onewayEntrance");
                public static readonly RoadEntityProto.ID onewayExit = new RoadEntityProto.ID("onewayExit");
                public static readonly RoadEntityProto.ID onewayStraight = new StaticEntityProto.ID("onewayStraight");
                public static readonly RoadEntityProto.ID onewayStraightSmall = new StaticEntityProto.ID("onewayStraightSmall");
                public static readonly RoadEntityProto.ID onewaySlope1 = new StaticEntityProto.ID("onewaySlope1");
                public static readonly RoadEntityProto.ID onewaySlope1fake = new StaticEntityProto.ID("onewaySlope1fake");
                public static readonly RoadEntityProto.ID onewayCorner = new StaticEntityProto.ID("onewayCorner");
                public static readonly RoadEntityProto.ID onewayCross = new StaticEntityProto.ID("onewayCross");
                public static readonly RoadEntityProto.ID onewayTSection = new StaticEntityProto.ID("onewayTSection");
                public static readonly RoadEntityProto.ID onewayBridge1 = new StaticEntityProto.ID("onewayBridge1");
                public static readonly RoadEntityProto.ID oneWayTrainBridgeEntrance1 = new RoadEntityProto.ID("onewayTrainBridgeEntrance1");
                public static readonly RoadEntityProto.ID oneWayTrainBridgeStraight1 = new RoadEntityProto.ID("onewayTrainBridgeStraight1");
                public static readonly RoadEntityProto.ID oneWayTrainBridgeStraight2x = new RoadEntityProto.ID("onewayTrainBridgeStraight2x");
                public static readonly RoadEntityProto.ID oneWayTrainBridgeCorner1 = new RoadEntityProto.ID("onewayTrainBridgeCorner1");
                public static readonly RoadEntityProto.ID oneWayTrainBridgeExit1 = new RoadEntityProto.ID("onewayTrainBridgeExit1");
                public static readonly RoadEntityProto.ID onewayEntranceExit = new RoadEntityProto.ID("onewayEntranceExit");
                public static readonly RoadEntityProto.ID roadWayPoint = new RoadEntityProto.ID("roadWayPoint");
                public static readonly RoadEntityProto.ID onewayLoadUnload = new RoadEntityProto.ID("onewayLoadUnload");
                public static readonly StaticEntityProto.ID rStraightStart = new StaticEntityProto.ID("rStraightStart");
                public static readonly StaticEntityProto.ID rStraightMid = new StaticEntityProto.ID("rStraightMid");
                public static readonly StaticEntityProto.ID rCorner = new StaticEntityProto.ID("rCorner");

                //public static readonly StaticEntityProto.ID indLight1 = new StaticEntityProto.ID("indLight1");

                // Set 2
                public static readonly RoadEntityProto.ID onewayEntrance2 = new RoadEntityProto.ID("onewayEntrance2");
                public static readonly RoadEntityProto.ID onewayExit2 = new RoadEntityProto.ID("onewayExit2");
                public static readonly RoadEntityProto.ID onewayStraight2 = new StaticEntityProto.ID("onewayStraight2");
                public static readonly RoadEntityProto.ID onewayStraightSmall2 = new StaticEntityProto.ID("onewayStraightSmall2");
                public static readonly RoadEntityProto.ID onewaySlope12 = new StaticEntityProto.ID("onewaySlope12");
                public static readonly RoadEntityProto.ID onewaySlope1fake2 = new StaticEntityProto.ID("onewaySlope1fake2");
                public static readonly RoadEntityProto.ID onewayCorner2 = new StaticEntityProto.ID("onewayCorner2");
                public static readonly RoadEntityProto.ID onewayCross2 = new StaticEntityProto.ID("onewayCross2");
                public static readonly RoadEntityProto.ID onewayTSection2 = new StaticEntityProto.ID("onewayTSection2");
                public static readonly RoadEntityProto.ID onewayBridge12 = new StaticEntityProto.ID("onewayBridge12");
                public static readonly RoadEntityProto.ID oneWayTrainBridgeEntrance12 = new RoadEntityProto.ID("onewayTrainBridgeEntrance12");
                public static readonly RoadEntityProto.ID oneWayTrainBridgeStraight12 = new RoadEntityProto.ID("onewayTrainBridgeStraight12");
                public static readonly RoadEntityProto.ID oneWayTrainBridgeStraight2x2 = new RoadEntityProto.ID("onewayTrainBridgeStraight2x2");
                public static readonly RoadEntityProto.ID oneWayTrainBridgeCorner12 = new RoadEntityProto.ID("onewayTrainBridgeCorner12");
                public static readonly RoadEntityProto.ID oneWayTrainBridgeExit12 = new RoadEntityProto.ID("onewayTrainBridgeExit12");
                public static readonly RoadEntityProto.ID onewayEntranceExit2 = new RoadEntityProto.ID("onewayEntranceExit2");
                public static readonly RoadEntityProto.ID roadWayPoint2 = new RoadEntityProto.ID("roadWayPoint2");
                public static readonly RoadEntityProto.ID onewayLoadUnload2 = new RoadEntityProto.ID("onewayLoadUnload2");
                public static readonly RoadEntityProto.ID rampStart1 = new RoadEntityProto.ID("rampStart1");
                public static readonly RoadEntityProto.ID rampMiddle1 = new RoadEntityProto.ID("rampMiddle1");


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
            public static readonly CustomEntityPrototype.ID Sign_50plus = new CustomEntityPrototype.ID("eSign50plus");
            public static readonly CustomEntityPrototype.ID Sign_80plus = new CustomEntityPrototype.ID("eSign80plus");
            public static readonly CustomEntityPrototype.ID Sign_100plus = new CustomEntityPrototype.ID("eSign100plus");
            public static readonly CustomEntityPrototype.ID Sign_120plus = new CustomEntityPrototype.ID("eSign120plus");
            public static readonly CustomEntityPrototype.ID Sign_BiDir = new CustomEntityPrototype.ID("eSignBiDir");
            public static readonly CustomEntityPrototype.ID Sign_CedaElPaso = new CustomEntityPrototype.ID("eSignCedaElPaso");
            public static readonly CustomEntityPrototype.ID Sign_MainRoad = new CustomEntityPrototype.ID("eSignMainRoad");
            public static readonly CustomEntityPrototype.ID Sign_DeadEndLeft = new CustomEntityPrototype.ID("eSignDeadEndLeft");
            public static readonly CustomEntityPrototype.ID Sign_DeadEndRight = new CustomEntityPrototype.ID("eSignDeadEndRight");
            public static readonly CustomEntityPrototype.ID Sign_DeadEnd = new CustomEntityPrototype.ID("eSignDeadEnd");
            public static readonly CustomEntityPrototype.ID Sign_ForwardRight = new CustomEntityPrototype.ID("eSignForwardRight");
            public static readonly CustomEntityPrototype.ID Sign_FuelDiesel = new CustomEntityPrototype.ID("eSignFuelDiesel");
            public static readonly CustomEntityPrototype.ID Sign_FuelH2 = new CustomEntityPrototype.ID("eSignFuelH2");
            public static readonly CustomEntityPrototype.ID Sign_LeftRight = new CustomEntityPrototype.ID("eSignLeftRight");
            public static readonly CustomEntityPrototype.ID Sign_LevelCrossing = new CustomEntityPrototype.ID("eSignLevelCrossing");
            public static readonly CustomEntityPrototype.ID Sign_NoRight = new CustomEntityPrototype.ID("eSignNoRight");
            public static readonly CustomEntityPrototype.ID Sign_Parking = new CustomEntityPrototype.ID("eSignParking");
            public static readonly CustomEntityPrototype.ID Sign_Port = new CustomEntityPrototype.ID("eSignPort");
            public static readonly CustomEntityPrototype.ID Sign_Hospital = new CustomEntityPrototype.ID("eSignHospital");
            public static readonly CustomEntityPrototype.ID Sign_TrainModern = new CustomEntityPrototype.ID("eSignTrainModern");
            public static readonly CustomEntityPrototype.ID Sign_100m = new CustomEntityPrototype.ID("eSign100m");
            public static readonly CustomEntityPrototype.ID Sign_200m = new CustomEntityPrototype.ID("eSign200m");
            public static readonly CustomEntityPrototype.ID Sign_300m = new CustomEntityPrototype.ID("eSign300m");


        }

    }
}