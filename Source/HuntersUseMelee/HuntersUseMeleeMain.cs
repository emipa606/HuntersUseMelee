using System.Linq;
using Verse;

namespace HuntersUseMelee;

[StaticConstructorOnStartup]
public static class HuntersUseMeleeMain
{
    public static bool SimpleSidearmsLoaded => ModsConfig.ActiveModsInLoadOrder.Any(m =>
        m.Name == "Simple sidearms" || m.PackageId == "petetimessix.simplesidearms");
}
