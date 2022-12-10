using Mlie;
using UnityEngine;
using Verse;

namespace HuntersUseMelee;

internal class HuntersUseMeleeMod : Mod
{
    public static HuntersUseMeleeSettings settings;
    private static string currentVersion;

    public HuntersUseMeleeMod(ModContentPack content)
        : base(content)
    {
        settings = GetSettings<HuntersUseMeleeSettings>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    public override string SettingsCategory()
    {
        return "HuntersUseMeleeCategoryLabel".Translate();
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(inRect);
        listing_Standard.verticalSpacing = 8f;
        listing_Standard.Label("HuntersUseMeleeFistFightDesc".Translate());
        listing_Standard.CheckboxLabeled("HuntersUseMeleeFistFightingLabel".Translate() + ": ",
            ref settings.enableFistFighting);
        if (HuntersUseMeleeMain.SimpleSidearmsLoaded)
        {
            listing_Standard.Label("HuntersUseMeleeSidearmsDesc".Translate());
            listing_Standard.CheckboxLabeled("HuntersUseMeleeSimpleSidearmsLabel".Translate() + ": ",
                ref settings.enableSimpleSidearms);
        }

        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("HuntersUseMeleeCurrentModVersionLabel".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
        settings.Write();
    }
}
