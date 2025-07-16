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
        try
        {
            var type = AccessTools.TypeByName("PeteTimesSix.SimpleSidearms.Extensions");
            GetGuns = type.GetMethod("getCarriedWeapons");
        }
        catch
        {
            // ignored
        }

        new Harmony("net.netrve.huntersusemelee").PatchAll(Assembly.GetExecutingAssembly());
    }
}