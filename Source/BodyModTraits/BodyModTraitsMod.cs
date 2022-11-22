using Mlie;
using UnityEngine;
using Verse;

namespace BodyModTraits;

[StaticConstructorOnStartup]
internal class BodyModTraitsMod : Mod
{
    public static BodyModTraitsMod instance;
    private static string currentVersion;

    private BodyModTraitsSettings settings;

    public BodyModTraitsMod(ModContentPack content)
        : base(content)
    {
        instance = this;
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(
                ModLister.GetActiveModWithIdentifier("Mlie.EMTattoosAndPiercings"));
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
        listing_Standard.CheckboxLabeled("EMTP_CountAsBad".Translate(), ref Settings.IsBad,
            "EMTP_CountAsBad_Tooltip".Translate());
        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("EMTP_CurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
    }

    public override void WriteSettings()
    {
        base.WriteSettings();
        Internal.updateHediffs();
    }
}