using HarmonyLib;
using RimWorld;
using Verse;

namespace HuntersUseMelee;

[HarmonyPatch(typeof(Alert_HunterLacksRangedWeapon), MethodType.Constructor)]
public static class Patch_HuntersLacksWeaponAlert
{
    private static void Postfix(ref string ___defaultLabel, ref string ___defaultExplanation)
    {
        ___defaultLabel = "HUMHunterLacksWeapon".Translate();
        ___defaultExplanation = "HUMHunterLacksWeaponDesc".Translate();
    }
}