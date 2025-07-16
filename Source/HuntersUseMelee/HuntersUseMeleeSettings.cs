using Verse;

namespace HuntersUseMelee;

public class HuntersUseMeleeSettings : ModSettings
{
    public bool EnableFistFighting;
    public bool EnableSimpleSidearms;

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref EnableFistFighting, "HuntersUseMeleeFistFightingLabel");
        Scribe_Values.Look(ref EnableSimpleSidearms, "HuntersUseMeleeSimpleSidearmsLabel");
    }
}