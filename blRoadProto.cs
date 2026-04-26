using Mafi;
using Mafi.Collections;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Prototypes;
using Mafi.Core.Roads;
using Mafi.Core.Trains;
using Mafi.Curves;
using System;
using System.Collections.Generic;


namespace BetterLife_RoadsAndSigns;

public class blRoadEntityProto : blRoadEntityProtoBase, IProtoWithTiers, IProtoWithIcon, IProto
{
    public static readonly RelTile1f LANE_WIDTH_OUTER;
    public static readonly RelTile1f DOUBLE_LANE_CENTER_OFFSET;
    public static readonly RelTile1f LANE_WIDTH_INNER;
    public static readonly ThicknessTilesF RAMP_HEIGHT_DELTA;
    private static readonly EntityLayoutParams LAYOUT_PARAMS;
    public override Type EntityType
    {
        get
        {
            return typeof(blRoadEntity);
        }
    }
    public ITierData TierData { get; }
    public blRoadEntityProto(StaticEntityProto.ID id, Proto.Str strings, EntityLayout layout, EntityCosts costs, RelTile1f maxVehiclesSpeedPerTick, ImmutableArray<RoadLaneSpec> lanesSpecs, ImmutableArray<RoadLaneMetadata> lanesData, ImmutableArray<RoadLaneTrajectory> lanesTrajectories, blRoadEntityProtoBase.Gfx graphics, bool useTerrainHeightForVehicles, bool cannotBeBuiltByPlayer = false, bool cannotBeDestroyedByFlood = false)
        : base(id, strings, layout, costs, maxVehiclesSpeedPerTick, lanesSpecs, lanesData, lanesTrajectories, graphics, null, null, useTerrainHeightForVehicles, cannotBeBuiltByPlayer, cannotBeDestroyedByFlood, false, false, false)
    {
        this.TierData = new TierData(this, 0);
    }
    public static bool TryCreateLanes(ImmutableArray<RoadLaneSpec> lanes, out ImmutableArray<RoadLaneMetadata> lanesData, out ImmutableArray<RoadLaneTrajectory> trajData, out string error, int segmentsPer10Tiles = 0)
    {
        ImmutableArrayBuilder<RoadLaneMetadata> immutableArrayBuilder = new ImmutableArrayBuilder<RoadLaneMetadata>(lanes.Length);
        ImmutableArrayBuilder<RoadLaneTrajectory> immutableArrayBuilder2 = new ImmutableArrayBuilder<RoadLaneTrajectory>(lanes.Length);
        lanesData = ImmutableArray<RoadLaneMetadata>.Empty;
        trajData = ImmutableArray<RoadLaneTrajectory>.Empty;
        error = "Unknown error";
        for (int i = 0; i < lanes.Length; i++)
        {
            RoadLaneTrajectory roadLaneTrajectory;
            if (!blRoadEntityProto.tryComputeLaneTrajectory(lanes[i], segmentsPer10Tiles, out roadLaneTrajectory, out error))
            {
                Log.Info("BETTERLIFE DEBUG: tryComputeLaneTrajectory failed...");
                return false;
            }
            immutableArrayBuilder2[i] = roadLaneTrajectory;
            RoadLaneMetadata roadLaneMetadata;
            if (!blRoadEntityProto.tryComputeRoadLaneMetadata(lanes[i], roadLaneTrajectory, out roadLaneMetadata, out error))
            {
                Log.Info("BETTERLIFE DEBUG: tryComputeRoadLaneMetadata failed...");
                return false;
            }
            immutableArrayBuilder[i] = roadLaneMetadata;
        }
        lanesData = immutableArrayBuilder.GetImmutableArrayAndClear();
        trajData = immutableArrayBuilder2.GetImmutableArrayAndClear();
        error = "";
        return true;
    }
    public static bool TryCreateProto(
      StaticEntityProto.ID id,
      Proto.Str strings,
      ImmutableArray<RoadLaneSpec> lanes,
      blRoadEntityProtoBase.Gfx graphics,
      EntityLayoutParser layoutParser,
      out blRoadEntityProto result,
      out string error,
      int segmentsPer10Tiles = 0)
    {
        result = (blRoadEntityProto)null;
        ImmutableArray<RoadLaneMetadata> lanesData1;
        ImmutableArray<RoadLaneTrajectory> trajData;
        if (!blRoadEntityProto.TryCreateLanes(lanes, out lanesData1, out trajData, out error, segmentsPer10Tiles))
            return false; Log.Info("BETTERLIFE DEBUG: (TryCreateProto) tryCreateLanes failed...");
        RelTile2i minLayoutTileCoord;
        EntityLayout layout = blRoadEntityProto.createLayout(trajData, layoutParser, out minLayoutTileCoord);
        RelTile2f offset = layout.TransformRelative(RelTile2i.Zero, TileTransform.Identity).RelTile2f;
        offset -= minLayoutTileCoord;
        Dict<CubicBezierCurve2f, CubicBezierCurve2f> translatedCurves = new Dict<CubicBezierCurve2f, CubicBezierCurve2f>();
        lanes = lanes.Map<RoadLaneSpec>((Func<RoadLaneSpec, RoadLaneSpec>)(x => new RoadLaneSpec(createdTranslatedCopy(x.TrajectoryCurve), x.CurveRightOffset, x.HeightCurve, x.StartType, x.EndType)));
        ImmutableArray<RoadLaneMetadata> lanesData2 = lanesData1.Map<RoadLaneMetadata>((Func<RoadLaneMetadata, RoadLaneMetadata>)(x => new RoadLaneMetadata(x.StartPosition + offset, x.EndPosition + offset, x.StartDirection, x.EndDirection, x.StartType, x.EndType, x.LaneLength)));
        ImmutableArray<RoadLaneTrajectory> lanesTrajectories = trajData.Map<RoadLaneTrajectory>((Func<RoadLaneTrajectory, RoadLaneTrajectory>)(x => new RoadLaneTrajectory(x.LaneCenterSamples.Map<RelTile3f>((Func<RelTile3f, RelTile3f>)(s => s + offset)), x.LaneDirectionSamples, x.SegmentLengthsPrefixSums)));
        result = new blRoadEntityProto(id, strings, layout, EntityCosts.None, RelTile1f.MaxValue, lanes, lanesData2, lanesTrajectories, graphics, true, false, true);
        error = "";
        return true;

        CubicBezierCurve2f createdTranslatedCopy(CubicBezierCurve2f curve)
        {
            CubicBezierCurve2f cubicBezierCurve2f;
            if (!translatedCurves.TryGetValue(curve, out cubicBezierCurve2f))
            {
                cubicBezierCurve2f = curve.CreatedTranslatedCopy(offset.Vector2f);
                translatedCurves.Add(curve, cubicBezierCurve2f);
            }
            return cubicBezierCurve2f;
        }
    }
    private static EntityLayout createLayout(
      ImmutableArray<RoadLaneTrajectory> lanes,
      EntityLayoutParser layoutParser,
      out RelTile2i minLayoutTileCoord)
    {
        Dict<RelTile2i, int> minOccupiedLayoutTiles = new Dict<RelTile2i, int>();
        Dict<RelTile2i, int> maxOccupiedLayoutTiles = new Dict<RelTile2i, int>();
        RelTile2f epsilon = new RelTile2f((1.0 / 16.0).ToFix32(), (1.0 / 16.0).ToFix32());
        Fix32 halfFast = blRoadEntityProto.LANE_WIDTH_INNER.Value.HalfFast;
        foreach (RoadLaneTrajectory lane in lanes)
        {
            int index = 0;
            for (int length = lane.LaneCenterSamples.Length; index < length; ++index)
            {
                RelTile3f laneCenterSample = lane.LaneCenterSamples[index];
                record(laneCenterSample);
                RelTile2f relTile2f1 = lane.LaneDirectionSamples[index].Xy;
                RelTile2f relTile2f2 = relTile2f1.Normalized * halfFast;
                record(laneCenterSample + relTile2f2.LeftOrthogonalVector);
                record(laneCenterSample + relTile2f2.RightOrthogonalVector);
                if (index > 0)
                {
                    RelTile3f relTile3f = laneCenterSample.Average(lane.LaneCenterSamples[index - 1]);
                    ref RelTile2f local = ref relTile2f2;
                    relTile2f1 = lane.LaneDirectionSamples[index - 1].Xy;
                    RelTile2f rhs = relTile2f1.Normalized * halfFast;
                    relTile2f1 = local.Average(rhs);
                    relTile2f2 = relTile2f1.Normalized;
                    record(relTile3f + relTile2f2.LeftOrthogonalVector);
                    record(relTile3f + relTile2f2.RightOrthogonalVector);
                }
            }
        }
        Lyst<RelTile3i> lyst = new Lyst<RelTile3i>();
        foreach (KeyValuePair<RelTile2i, int> keyValuePair in minOccupiedLayoutTiles)
        {
            int num;
            if (maxOccupiedLayoutTiles.TryGetValue(keyValuePair.Key, out num))
                lyst.Add(new RelTile3i(keyValuePair.Key, keyValuePair.Value.Min(num)));
        }
        RelTile2i relTile2i1 = RelTile2i.MaxValue;
        RelTile2i relTile2i2 = RelTile2i.MinValue;
        foreach (RelTile3i relTile3i in lyst)
        {
            relTile2i1 = relTile2i1.Min(relTile3i.Xy);
            relTile2i2 = relTile2i2.Max(relTile3i.Xy);
        }
        RelTile2i relTile2i3 = relTile2i2 - relTile2i1 + 1;
        int[][] array1 = new int[relTile2i3.Y][];
        for (int index1 = 0; index1 < relTile2i3.Y; ++index1)
        {
            int[] numArray = new int[relTile2i3.X];
            array1[index1] = numArray;
            for (int index2 = 0; index2 < numArray.Length; ++index2)
                numArray[index2] = int.MaxValue;
        }
        foreach (RelTile3i relTile3i in lyst)
        {
            if (relTile3i.Z < 0)
                throw new ProtoBuilderException("Road layout height should not go below 0."); Log.Info("BETTERLIFE DEBUG: Road layout height should not go below 0.");
            RelTile2i relTile2i4 = relTile3i.Xy - relTile2i1;
            array1[relTile2i4.Y][relTile2i4.X] = array1[relTile2i4.Y][relTile2i4.X].Min(relTile3i.Z);
        }
        string[] array2 = array1.MapArray<int[], string>((Func<int[], string>)(x => x.MapArray<int, string>((Func<int, string>)(h =>
        {
            if (h == int.MaxValue)
                return "   ";
            return h != -1 ? string.Format("={0}=", (object)(h + 1)) : "_1_";
        })).JoinStrings()));
        Array.Reverse(array2);
        minLayoutTileCoord = relTile2i1;
        return layoutParser.ParseLayoutOrThrow(blRoadEntityProto.LAYOUT_PARAMS, array2);

        void record(RelTile3f t)
        {
            bool exists1;
            ref int local1 = ref minOccupiedLayoutTiles.GetRefValue((t.Xy + epsilon).RelTile2iFloored, out exists1);
            local1 = exists1 ? local1.Min(t.Z.ToIntFloored()) : t.Z.ToIntFloored();
            bool exists2;
            ref int local2 = ref maxOccupiedLayoutTiles.GetRefValue((t.Xy - epsilon).RelTile2iFloored, out exists2);
            local2 = exists2 ? local2.Max(t.Z.ToIntFloored()) : t.Z.ToIntFloored();
        }
    }

    private static bool tryComputeLaneTrajectory(RoadLaneSpec laneSpec, int segmentsPer10Tiles, out RoadLaneTrajectory resultTraj, out string error)
    {
        CubicBezierCurve2f trajectoryCurve = laneSpec.TrajectoryCurve;
        CubicBezierCurve2f heightCurve = laneSpec.HeightCurve;
        Fix32 fix = trajectoryCurve.ApproximateCurveLength(10);
        int num = (2 * fix * segmentsPer10Tiles / 10).ToIntCeiled().Max(1);
        CubicBezierCurve2fSampler uniformSampler = trajectoryCurve.GetUniformSampler(num);
        CubicBezierCurve2fSampler uniformSampler2 = heightCurve.GetUniformSampler(num);
        int num2 = (uniformSampler.CurveLengthApprox * segmentsPer10Tiles / 10).ToIntRounded().Max(1);
        ImmutableArrayBuilder<RelTile3f> immutableArrayBuilder = new ImmutableArrayBuilder<RelTile3f>(num2 + 1);
        ImmutableArrayBuilder<RelTile3f> immutableArrayBuilder2 = new ImmutableArrayBuilder<RelTile3f>(num2 + 1);
        for (int i = 0; i <= num2; i++)
        {
            Percent percent = Percent.FromRatio(i, num2, false);
            RelTile2f relTile2f = new RelTile2f(uniformSampler.SampleUniform(percent));
            Fix32 y = uniformSampler2.SampleUniform(percent).Y;
            immutableArrayBuilder[i] = new RelTile3f(relTile2f.X, relTile2f.Y, y);
            RelTile2f relTile2f2 = new RelTile2f(uniformSampler.SampleDerivativeUniform(percent).Normalized);
            immutableArrayBuilder2[i] = new RelTile3f(relTile2f2.X, relTile2f2.Y, uniformSampler2.SampleDerivativeUniform(percent).Normalized.Y).Normalized;
        }
        ImmutableArray<RelTile3f> immutableArrayAndClear = immutableArrayBuilder.GetImmutableArrayAndClear();
        ImmutableArray<RelTile3f> immutableArrayAndClear2 = immutableArrayBuilder2.GetImmutableArrayAndClear();
        ImmutableArrayBuilder<RelTile1f> immutableArrayBuilder3 = new ImmutableArrayBuilder<RelTile1f>(immutableArrayAndClear.Length);
        for (int j = 1; j < immutableArrayAndClear.Length; j++)
        {
            immutableArrayBuilder3[j] = immutableArrayBuilder3[j - 1] + (immutableArrayAndClear[j - 1] - immutableArrayAndClear[j]).Length.Tiles();
        }
        resultTraj = new RoadLaneTrajectory(immutableArrayAndClear, immutableArrayAndClear2, immutableArrayBuilder3.GetImmutableArrayAndClear());
        error = "";
        return true;
    }
    private static bool tryComputeRoadLaneMetadata(
      RoadLaneSpec lane,
      RoadLaneTrajectory trajectory,
      out RoadLaneMetadata roadLaneMetadata,
      out string error)
    {
        RelTile3f resultPt1;
        RelTile3f resultPt2;
        TrainTrackNodeDirection resultDir1;
        TrainTrackNodeDirection resultDir2;
        if (!tryValidatePt(trajectory.LaneCenterSamples.First, out resultPt1, out error) || !tryValidatePt(trajectory.LaneCenterSamples.Last, out resultPt2, out error) || !tryValidateDir(trajectory.LaneDirectionSamples.First, out resultDir1, out error) || !tryValidateDir(trajectory.LaneDirectionSamples.Last, out resultDir2, out error))
        {
            Log.Info("BETTERLIFE DEBUG: (tryComputeRoadLaneMetadata) tryValidatePt failed...");
            roadLaneMetadata = new RoadLaneMetadata();
            return false;
        }
        roadLaneMetadata = new RoadLaneMetadata(resultPt1, resultPt2, resultDir1, resultDir2, lane.StartType, lane.EndType, trajectory.SegmentLengthsPrefixSums.Last);
        error = "";
        return true;

        static bool tryValidatePt(RelTile3f pt, out RelTile3f resultPt, out string error)
        {
            resultPt = new RelTile3f();
            RelTile2f relTile2f1 = pt.Xy;
            relTile2f1 = relTile2f1.Times2Fast;
            RelTile2i roundedRelTile2i = relTile2f1.RoundedRelTile2i;
            if (!roundedRelTile2i.Vector2f.IsNear(pt.Xy.Vector2f.Times2Fast))
            {
                Log.Info("BETTERLIFE DEBUG: (tryValidatePt) Lane point is not a multiple of 0.5 .");
                error = string.Format("Lane point {0} is not a multiple of 0.5.", (object)pt);
                return false;
            }
            ref RelTile3f local = ref resultPt;
            RelTile2f relTile2f2 = roundedRelTile2i.RelTile2f;
            relTile2f2 = relTile2f2.HalfFast;
            RelTile3f relTile3f = relTile2f2.ExtendZ(pt.Z);
            local = relTile3f;
            error = "";
            return true;
        }

        static bool tryValidateDir(
          RelTile3f direction,
          out TrainTrackNodeDirection resultDir,
          out string error)
        {
            Assert.That<Fix32>(direction.Z).IsZero("TODO: Non-zero grade not implemented.");
            return TrainTrackNodeDirection.TryCreateFromDirection(direction.Xy.Vector2f, TrainTrackGradeFactor.G0, out resultDir, out error);
        }
    }
    static blRoadEntityProto()
    {
        blRoadEntityProto.LANE_WIDTH_OUTER = 2.0.Tiles();
        blRoadEntityProto.DOUBLE_LANE_CENTER_OFFSET = 1.0.Tiles();
        blRoadEntityProto.LANE_WIDTH_INNER = 1.875.Tiles();
        blRoadEntityProto.RAMP_HEIGHT_DELTA = 0.25.TilesThick();
        blRoadEntityProto.LAYOUT_PARAMS = new EntityLayoutParams(null, new CustomLayoutToken[]
        {
                new CustomLayoutToken("=0=", (EntityLayoutParams p, int h) => new LayoutTokenSpec(h, h + 3, LayoutTileConstraint.None, null, null, null, null, null, null, false, false, 0)),
                new CustomLayoutToken("_0_", (EntityLayoutParams p, int h) => new LayoutTokenSpec(0, h, LayoutTileConstraint.None, new int?(0), null, null, null, null, null, false, false, 0))
        }, false, null, null, null, null, null, null, default(Option<IEnumerable<KeyValuePair<char, int>>>), false, null, null);
    }
}

