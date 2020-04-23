using System;
using System.Reflection;
using System.Collections.Generic;
using HarmonyLib;
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
      new Harmony("nekoboinick.advancedbiomes.volcanovariety").PatchAll(Assembly.GetExecutingAssembly());
      Log.Message("Volcano Variety Framework initialized. This mod uses Harmony (all patches are non-destructive): BiomesPlus.BiomeWorker_Volcano.Get_Score", false);
    }
  }

  [HarmonyPatch(typeof(BiomeWorker_Volcano), "GetScore", null)]
  class VolcanoVarietyPatch
  {
    [HarmonyPostfix]
    static float GetScore(float __result,Tile tile)
    {
      if (__result == -100f && tile.elevation > 750f && (int)tile.hilliness > 1)
      {
        return 22.5f + (tile.temperature - 20f) * 2.2f + (tile.rainfall - 600f) / 100f;
      }
      else
      {
        return __result;
      }
    }
  }
}
