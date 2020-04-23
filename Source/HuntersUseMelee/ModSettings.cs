using Verse;
using UnityEngine;

namespace HuntersUseMelee
{
    public class HuntersUseMeleeSettings : ModSettings
    {
        public bool enableSimpleSidearms;
        public bool enableFistFighting;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref enableFistFighting, "HuntersUseMeleeFistFightingLabel");
            Scribe_Values.Look(ref enableSimpleSidearms, "HuntersUseMeleeSimpleSidearmsLabel");
        }
    }
    
    class HuntersUseMeleeMod : Mod
    {
        public static HuntersUseMeleeSettings settings;

        public HuntersUseMeleeMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<HuntersUseMeleeSettings>();
        }

        public override string SettingsCategory() => "HuntersUseMeleeCategoryLabel".Translate();

        public override void DoSettingsWindowContents(Rect inRect)
        {
            var listing_Standard = new Listing_Standard();
            listing_Standard.Begin(inRect);
            listing_Standard.verticalSpacing = 8f;
            listing_Standard.Label("HuntersUseMeleeFistFightDesc".Translate());
            listing_Standard.CheckboxLabeled("HuntersUseMeleeFistFightingLabel".Translate() + ": ", ref settings.enableFistFighting);
            listing_Standard.Label("HuntersUseMeleeSidearmsDesc".Translate());
            listing_Standard.CheckboxLabeled("HuntersUseMeleeSimpleSidearmsLabel".Translate() + ": ", ref settings.enableSimpleSidearms);
            listing_Standard.End();
            settings.Write();
        }
    }
}