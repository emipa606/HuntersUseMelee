// This project is subject to the terms of the Mozilla Public License v2.0
// If a copy of the MPL was not distributed with this file,
// You can obtain one at https://mozilla.org/MPL/2.0/
using HarmonyLib;
using RimWorld;
using Verse;

namespace HuntersUseMelee
{    
    [StaticConstructorOnStartup]
    static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            var harmony = new Harmony("net.netrve.huntersusemelee");

            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(WorkGiver_HunterHunt), "HasHuntingWeapon")]
        internal static class Patch_HasHuntingWeapon
        { 
            static void Postfix(Pawn p, ref bool __result)
            {
                if (!__result)
                    __result = p.equipment.Primary != null && p.equipment.Primary.def.IsMeleeWeapon && (p.equipment.PrimaryEq.PrimaryVerb.HarmsHealth());
            }
        }
    
        [HarmonyPatch(typeof(Alert_HunterLacksRangedWeapon))]
        [HarmonyPatch(MethodType.Constructor)]
        internal static class Patch_HuntersLacksWeaponAlert
        { 
            static void Postfix(ref string ___defaultLabel, ref string ___defaultExplanation)
            {
                ___defaultLabel = "HUMHunterLacksWeapon".Translate();
                ___defaultExplanation = "HUMHunterLacksWeaponDesc".Translate();
            }
        }
    }
}
