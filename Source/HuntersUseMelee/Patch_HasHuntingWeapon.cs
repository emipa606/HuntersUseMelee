using HarmonyLib;
using RimWorld;
using Verse;

namespace HuntersUseMelee;

[HarmonyPatch(typeof(WorkGiver_HunterHunt), nameof(WorkGiver_HunterHunt.HasHuntingWeapon))]
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
                   p.equipment.PrimaryEq.PrimaryVerb.HarmsHealth() &&
                   !p.equipment.Primary.def.defName.ToLower().Contains("shield");
        if (__result || !HuntersUseMeleeMod.settings.enableSimpleSidearms ||
            !HuntersUseMeleeMain.SimpleSidearmsLoaded || HarmonyPatches.GetGuns == null)
        {
            return;
        }

        if (Find.TickManager.TicksGame % 60 == 0 && HarmonyPatches.GetGuns.Invoke(null, [p, true, false]) != null)
        {
            __result = true;
        }
    }
}