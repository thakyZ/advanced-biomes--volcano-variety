using System;
using System.Reflection;
using System.Collections.Generic;
using Harmony;
using RimWorld;
using RimWorld.Planet;
using Verse;
using UnityEngine;
using BiomesPlus;

namespace VolcanoVariety
{
    [StaticConstructorOnStartup]
    class Main
    {
        static Main()
        {
            var harmony = HarmonyInstance.Create("thakyz.volcanovariety");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(BiomeWorker_Volcano), "GetScore")]
    class VolcanoVarietyPatch
    {
        [HarmonyPostfix]
        static float GetScore(float __result,Tile tile)
        {
            if (__result == -100f && tile.elevation > 1000f && (int)tile.hilliness > 1)
                return 22.5f + (tile.temperature - 20f) * 2.2f + (tile.rainfall - 600f) / 100f;
            else
                return __result;
        }
    }
}
