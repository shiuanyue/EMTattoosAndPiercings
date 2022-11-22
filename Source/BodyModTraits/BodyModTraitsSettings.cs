using Verse;

namespace BodyModTraits;

internal class BodyModTraitsSettings : ModSettings
{
    public bool IsBad;

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref IsBad, "IsBad");
    }
}