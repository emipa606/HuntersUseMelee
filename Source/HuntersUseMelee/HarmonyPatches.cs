using System.Reflection;
using HarmonyLib;
using Verse;

namespace HuntersUseMelee;

[StaticConstructorOnStartup]
internal static class HarmonyPatches
{
    public static readonly MethodInfo GetGuns;

    static HarmonyPatches()
    {
        var harmony = new Harmony("net.netrve.huntersusemelee");
        try
        {
            var type = AccessTools.TypeByName("PeteTimesSix.SimpleSidearms.Extensions");
            GetGuns = type.GetMethod("getCarriedWeapons");
        }
        catch
        {
            Log.Message("[HuM] Could not find Simple Sidearms, support disabled.");
        }

        harmony.PatchAll();
    }
}