using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace HuntersUseMelee;

[StaticConstructorOnStartup]
internal static class HarmonyPatches
{
    private static readonly MethodInfo getGuns;

    static HarmonyPatches()
    {
        var harmony = new Harmony("net.netrve.huntersusemelee");
        try
        {
            var type = AccessTools.TypeByName("PeteTimesSix.SimpleSidearms.Extensions");
            getGuns = type.GetMethod("getCarriedWeapons");
        }
        catch
        {
            Log.Warning("[HuM] Could not find Simple Sidearms, support disabled.");
        }

        harmony.PatchAll();
    }

    [HarmonyPatch(typeof(WorkGiver_HunterHunt), "HasHuntingWeapon")]
    internal static class Patch_HasHuntingWeapon
    {
        private static bool Prefix(ref bool __result)
        {
            if (!HuntersUseMeleeMod.settings.enableFistFighting)
            {
                return true;
            }

            __result = true;
            return false;
        }

        private static void Postfix(Pawn p, ref bool __result)
        {
            if (__result)
            {
                return;
            }

            __result = p.equipment.Primary != null && p.equipment.Primary.def.IsMeleeWeapon &&
                       p.equipment.PrimaryEq.PrimaryVerb.HarmsHealth();
            if (__result || !HuntersUseMeleeMod.settings.enableSimpleSidearms ||
                !HuntersUseMeleeMain.SimpleSidearmsLoaded || getGuns == null)
            {
                return;
            }

            if (Find.TickManager.TicksGame % 60 == 0 && getGuns.Invoke(null, new object[] { p, true, false }) != null)
            {
                __result = true;
            }
        }

        [HarmonyPatch(typeof(Alert_HunterLacksRangedWeapon))]
        [HarmonyPatch(MethodType.Constructor)]
        internal static class Patch_HuntersLacksWeaponAlert
        {
            private static void Postfix(ref string ___defaultLabel, ref string ___defaultExplanation)
            {
                ___defaultLabel = "HUMHunterLacksWeapon".Translate();
                ___defaultExplanation = "HUMHunterLacksWeaponDesc".Translate();
            }
        }
    }
}