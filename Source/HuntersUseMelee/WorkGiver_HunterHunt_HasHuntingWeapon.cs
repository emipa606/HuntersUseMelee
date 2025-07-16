using HarmonyLib;
using RimWorld;
using Verse;

namespace HuntersUseMelee;

[HarmonyPatch(typeof(WorkGiver_HunterHunt), nameof(WorkGiver_HunterHunt.HasHuntingWeapon))]
internal static class WorkGiver_HunterHunt_HasHuntingWeapon
{
    public static bool Prefix(ref bool __result)
    {
        if (!HuntersUseMeleeMod.Settings.EnableFistFighting)
        {
            return true;
        }

        __result = true;
        return false;
    }

    public static void Postfix(Pawn p, ref bool __result)
    {
        if (__result)
        {
            return;
        }

        __result = p.equipment.Primary != null && p.equipment.Primary.def.IsMeleeWeapon &&
                   p.equipment.PrimaryEq.PrimaryVerb.HarmsHealth() &&
                   !p.equipment.Primary.def.defName.ToLower().Contains("shield");
        if (__result || !HuntersUseMeleeMod.Settings.EnableSimpleSidearms ||
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