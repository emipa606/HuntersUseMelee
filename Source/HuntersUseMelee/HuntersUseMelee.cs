// This project is subject to the terms of the Mozilla Public License v2.0
// If a copy of the MPL was not distributed with this file,
// You can obtain one at https://mozilla.org/MPL/2.0/

using System;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace HuntersUseMelee
{
    [StaticConstructorOnStartup]
    public static class HuntersUseMeleeMain
    {
        public static bool SimpleSidearmsLoaded => ModsConfig.ActiveModsInLoadOrder.Any(m => m.Name == "Simple sidearms" || m.PackageId == "petetimessix.simplesidearms");
    }

    [StaticConstructorOnStartup]
    static class HarmonyPatches
    {
        private static Type simpleExtensions => AccessTools.TypeByName("SimpleSidearms.Extensions");
        private static MethodInfo getGuns => simpleExtensions.GetMethod("getCarriedWeapons");
        
        static HarmonyPatches()
        {
            var harmony = new Harmony("net.netrve.huntersusemelee");

            // We patch all as we use annotations
            harmony.PatchAll();
        }

        // We patch the WorkGiver for Hunting, more specifically 
        // The check used to see if a pawn has a hunting weapon
        [HarmonyPatch(typeof(WorkGiver_HunterHunt), "HasHuntingWeapon")]
        internal static class Patch_HasHuntingWeapon
        {
            static bool Prefix(ref bool __result)
            {
                // If Fist Fighting is disabled, we continue normally
                if (!HuntersUseMeleeMod.settings.enableFistFighting) return true;
                
                // If Fist Fighting is enabled, we return true and skip the rest of the original function
                __result = true;
                return false;
            }
            
            static void Postfix(Pawn p, ref bool __result)
            {
                // No need to run if the result already is true
                if (__result) return;

                // Check if primary is a valid, damaging melee weapon
                // Automatically assign the result
                __result = p.equipment.Primary != null && p.equipment.Primary.def.IsMeleeWeapon &&
                           p.equipment.PrimaryEq.PrimaryVerb.HarmsHealth();

                // Simple Sidearms support
                // As above, we skip if result is already true, but we also skip if setting is off
                // Or Simple Sidearms isn't loaded
                if (__result || !HuntersUseMeleeMod.settings.enableSimpleSidearms || !HuntersUseMeleeMain.SimpleSidearmsLoaded || getGuns == null) return;

                // If the pawn can carry sidearms and has any, they are good to go
                // p.getCarriedWeapons().Any()
                if (getGuns.Invoke(null, new object[] {p, true, false}) != null)
                    __result = true;
            }

            // No need to redo the Alert, we simply change the text to fit the changed behavior
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
}
