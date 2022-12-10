using Verse;

namespace HuntersUseMelee;

public class HuntersUseMeleeSettings : ModSettings
{
    public bool enableFistFighting;
    public bool enableSimpleSidearms;

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref enableFistFighting, "HuntersUseMeleeFistFightingLabel");
        Scribe_Values.Look(ref enableSimpleSidearms, "HuntersUseMeleeSimpleSidearmsLabel");
    }
}
