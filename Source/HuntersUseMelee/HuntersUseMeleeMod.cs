using Mlie;
using UnityEngine;
using Verse;

namespace HuntersUseMelee;

internal class HuntersUseMeleeMod : Mod
{
    public static HuntersUseMeleeSettings Settings;
    private static string currentVersion;

    public HuntersUseMeleeMod(ModContentPack content)
        : base(content)
    {
        Settings = GetSettings<HuntersUseMeleeSettings>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    public override string SettingsCategory()
    {
        return "HuntersUseMeleeCategoryLabel".Translate();
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(inRect);
        listingStandard.verticalSpacing = 8f;
        listingStandard.Label("HuntersUseMeleeFistFightDesc".Translate());
        listingStandard.CheckboxLabeled("HuntersUseMeleeFistFightingLabel".Translate() + ": ",
            ref Settings.EnableFistFighting);
        if (HuntersUseMeleeMain.SimpleSidearmsLoaded)
        {
            listingStandard.Label("HuntersUseMeleeSidearmsDesc".Translate());
            listingStandard.CheckboxLabeled("HuntersUseMeleeSimpleSidearmsLabel".Translate() + ": ",
                ref Settings.EnableSimpleSidearms);
        }

        if (currentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("HuntersUseMeleeCurrentModVersionLabel".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
        Settings.Write();
    }
}