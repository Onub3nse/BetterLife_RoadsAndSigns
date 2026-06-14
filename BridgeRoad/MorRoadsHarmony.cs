using System;
using HarmonyLib;
using Mafi;
using Mafi.Core.Mods;

namespace Mor_Roads
{
    using System.Reflection;
    using Mafi.Collections;
    using Mafi.Core.PathFinding;
    using Mafi.Core.Terrain;
    using Mafi.Core.Roads;
    [GlobalDependency(RegistrationMode.AsEverything, false, false)]
    public sealed class MorRoadsHarmony
    {
        [HarmonyPatch]
        public static class MorRoadsRoadDiscoveryPatch
        {
            private const int ROAD_DISCOVERY_RADIUS_TILES = 12;

            private static readonly FieldInfo s_chunkRoadConnectionsField =
                typeof(ClearancePathabilityProvider).GetField(
                    "m_chunkRoadConnections",
                    BindingFlags.Instance | BindingFlags.NonPublic
                );

            private static readonly FieldInfo s_chunksCountXField =
                typeof(ClearancePathabilityProvider).GetField(
                    "m_chunksCountX",
                    BindingFlags.Instance | BindingFlags.NonPublic
                );

            [HarmonyPatch(
                typeof(ClearancePathabilityProvider),
                "AreRoadNetworkConnectionsNearby"
            )]
            [HarmonyPrefix]
            public static bool AreRoadNetworkConnectionsNearbyPrefix(
                ClearancePathabilityProvider __instance,
                VehiclePfNode node,
                ref bool __result
            )
            {
                __result = HasRoadConnectionsInExpandedArea(
                    __instance,
                    node.Area,
                    ROAD_DISCOVERY_RADIUS_TILES
                );

                return false;
            }

            [HarmonyPatch(
    typeof(ClearancePathabilityProvider),
    "GetRoadNetworkConnectionsInArea"
)]
            [HarmonyPrefix]
            public static bool GetRoadNetworkConnectionsInAreaPrefix(
    ClearancePathabilityProvider __instance,
    RectangleTerrainArea2i area,
    VehiclePathFindingParams pfParams,
    bool fromTerrainToRoad,
    Lyst<Tile2iSlim> connTiles
)
            {
                AddRoadConnectionsInExpandedArea(
                    __instance,
                    area,
                    pfParams,
                    fromTerrainToRoad,
                    connTiles,
                    ROAD_DISCOVERY_RADIUS_TILES
                );

                return false;


            }
            private static bool HasRoadConnectionsInExpandedArea(
                ClearancePathabilityProvider provider,
                RectangleTerrainArea2i area,
                int radius
            )
            {
                Dict<int, Lyst<GraphTerrainConnection>> connectionsByChunk =
                    GetConnectionsByChunk(provider);

                if (connectionsByChunk == null)
                {
                    return false;
                }

                int chunksCountX = GetChunksCountX(provider);
                if (chunksCountX <= 0)
                {
                    return false;
                }

                int minChunkX = MaxInt(0, (area.Origin.X - radius) >> 3);
                int minChunkY = MaxInt(0, (area.Origin.Y - radius) >> 3);
                int maxChunkX = MaxInt(0, (area.Origin.X + area.Size.X - 1 + radius) >> 3);
                int maxChunkY = MaxInt(0, (area.Origin.Y + area.Size.Y - 1 + radius) >> 3);

                for (int chunkY = minChunkY; chunkY <= maxChunkY; chunkY++)
                {
                    for (int chunkX = minChunkX; chunkX <= maxChunkX; chunkX++)
                    {
                        int key = chunkX + chunkY * chunksCountX;

                        if (connectionsByChunk.TryGetValue(
                                key,
                                out Lyst<GraphTerrainConnection> connections
                            ) &&
                            connections.IsNotEmpty)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            private static void AddRoadConnectionsInExpandedArea(
    ClearancePathabilityProvider provider,
    RectangleTerrainArea2i area,
    VehiclePathFindingParams pfParams,
    bool fromTerrainToRoad,
    Lyst<Tile2iSlim> connTiles,
    int radius
)
            {
                Dict<int, Lyst<GraphTerrainConnection>> connectionsByChunk =
                    GetConnectionsByChunk(provider);

                if (connectionsByChunk == null)
                {
                    return;
                }

                int chunksCountX = GetChunksCountX(provider);
                if (chunksCountX <= 0)
                {
                    return;
                }

                int minChunkX = MaxInt(0, (area.Origin.X - radius) >> 3);
                int minChunkY = MaxInt(0, (area.Origin.Y - radius) >> 3);
                int maxChunkX = MaxInt(0, (area.Origin.X + area.Size.X - 1 + radius) >> 3);
                int maxChunkY = MaxInt(0, (area.Origin.Y + area.Size.Y - 1 + radius) >> 3);

                for (int chunkY = minChunkY; chunkY <= maxChunkY; chunkY++)
                {
                    for (int chunkX = minChunkX; chunkX <= maxChunkX; chunkX++)
                    {
                        int key = chunkX + chunkY * chunksCountX;

                        if (!connectionsByChunk.TryGetValue(
                                key,
                                out Lyst<GraphTerrainConnection> connections
                            ))
                        {
                            continue;
                        }

                        Lyst<GraphTerrainConnection>.Enumerator enumerator =
                            connections.GetEnumerator();

                        while (enumerator.MoveNext())
                        {
                            GraphTerrainConnection connection = enumerator.Current;

                            if (connection.IsFromTerrainToRoad != fromTerrainToRoad)
                            {
                                continue;
                            }

                            if (!pfParams.CanUseRoadType(connection.RoadLaneType))
                            {
                                continue;
                            }

                            Tile2i connectionTileInCornerSpace =
                                pfParams.ConvertToCornerTileSpace(connection.TerrainTile);

                            if (!IsTileInsideExpandedArea(
                                    area,
                                    connectionTileInCornerSpace,
                                    radius
                                ))
                            {
                                continue;
                            }

                            if (!ContainsTile(connTiles, connection.TerrainTile))
                            {
                                connTiles.Add(connection.TerrainTile);
                            }
                        }
                    }
                }
            }

            private static bool IsTileInsideExpandedArea(
                RectangleTerrainArea2i area,
                Tile2i tile,
                int radius
            )
            {
                int minX = area.Origin.X - radius;
                int minY = area.Origin.Y - radius;
                int maxXExclusive = area.Origin.X + area.Size.X + radius;
                int maxYExclusive = area.Origin.Y + area.Size.Y + radius;

                return
                    tile.X >= minX &&
                    tile.Y >= minY &&
                    tile.X < maxXExclusive &&
                    tile.Y < maxYExclusive;
            }

            private static bool ContainsTile(
                Lyst<Tile2iSlim> tiles,
                Tile2iSlim tile
            )
            {
                Lyst<Tile2iSlim>.Enumerator enumerator =
                    tiles.GetEnumerator();

                while (enumerator.MoveNext())
                {
                    if (enumerator.Current.Equals(tile))
                    {
                        return true;
                    }
                }

                return false;
            }
            private static Dict<int, Lyst<GraphTerrainConnection>> GetConnectionsByChunk(
                ClearancePathabilityProvider provider
            )
            {
                if (s_chunkRoadConnectionsField == null)
                {
                    Log.Warning("Mor Roads: m_chunkRoadConnections field not found.");
                    return null;
                }

                return s_chunkRoadConnectionsField.GetValue(provider)
                    as Dict<int, Lyst<GraphTerrainConnection>>;
            }

            private static int GetChunksCountX(ClearancePathabilityProvider provider)
            {
                if (s_chunksCountXField == null)
                {
                    Log.Warning("Mor Roads: m_chunksCountX field not found.");
                    return 0;
                }

                object value = s_chunksCountXField.GetValue(provider);

                if (value is int result)
                {
                    return result;
                }

                return 0;
            }

            private static int MaxInt(int a, int b)
            {
                return a > b ? a : b;
            }
        }
        public MorRoadsHarmony()
        {
            try
            {
                Harmony harmony = new Harmony("Mor_Roads.Harmony");
                harmony.PatchAll(typeof(MorRoadsHarmony).Assembly);

                Log.Info("Mor Roads: Harmony patches applied.");
            }
            catch (Exception ex)
            {
                Log.Warning("Mor Roads: Failed to apply Harmony patches: " + ex);
            }
        }
    }
}