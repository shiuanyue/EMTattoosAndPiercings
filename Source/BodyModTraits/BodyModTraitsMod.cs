using UnityEngine;
using Verse;

namespace BodyModTraits;

[StaticConstructorOnStartup]
internal class BodyModTraitsMod : Mod
{
    public static BodyModTraitsMod instance;

    private BodyModTraitsSettings settings;

    public BodyModTraitsMod(ModContentPack content)
        : base(content)
    {
        instance = this;
    }

    private BodyModTraitsSettings Settings
    {
        get
        {
            if (settings == null)
            {
                settings = GetSettings<BodyModTraitsSettings>();
            }

            return settings;
        }
        set => settings = value;
    }

    public override string SettingsCategory()
    {
        return "Scarification";
    }

    public override void DoSettingsWindowContents(Rect rect)
    {
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(rect);
        listing_Standard.Gap();
        listing_Standard.CheckboxLabeled("Count modifications as bad", ref Settings.IsBad,
            "If defined as bad, healing serums and similar items can remove them");
        listing_Standard.End();
    }

    public override void WriteSettings()
    {
        base.WriteSettings();
        Internal.updateHediffs();
    }
}