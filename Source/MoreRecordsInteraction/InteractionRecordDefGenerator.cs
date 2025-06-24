using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreRecordsInteraction;

public class InteractionRecordDefGenerator
{
    private const string InteractRecordDefPrefix = "TMB_Interact";
    private const string InteractedRecordDefPrefix = "TMB_Interacted";

    private static string getInteractRecordDefName(InteractionDef interactionDef)
    {
        return $"{InteractRecordDefPrefix}_{interactionDef.defName}";
    }

    private static string getInteractedRecordDefName(InteractionDef interactionDef)
    {
        return $"{InteractedRecordDefPrefix}_{interactionDef.defName}";
    }

    public static RecordDef GetInteractRecordDef(InteractionDef interactionDef)
    {
        return DefDatabase<RecordDef>.GetNamed(getInteractRecordDefName(interactionDef));
    }

    public static RecordDef GetInteractedRecordDef(InteractionDef interactionDef)
    {
        return DefDatabase<RecordDef>.GetNamed(getInteractedRecordDefName(interactionDef));
    }

    public static IEnumerable<RecordDef> ImpliedRecordDefs()
    {
        foreach (var interactionDef in DefDatabase<InteractionDef>.AllDefs)
        {
            var interactDef = baseInteractionRecord();
            interactDef.defName = getInteractRecordDefName(interactionDef);
            interactDef.label = "MoreRecordsInteraction.InteractRecordLabel".Translate(interactionDef.label);
            interactDef.description =
                "MoreRecordsInteraction.InteractRecordDescription".Translate(interactionDef.label);
            interactDef.descriptionHyperlinks = [new DefHyperlink(interactionDef)];
            yield return interactDef;

            var interactedDef = baseInteractionRecord();
            interactedDef.defName = getInteractedRecordDefName(interactionDef);
            interactedDef.label = "MoreRecordsInteraction.InteractedRecordLabel".Translate(interactionDef.label);
            interactedDef.description =
                "MoreRecordsInteraction.InteractedRecordDescription".Translate(interactionDef.label);
            interactedDef.descriptionHyperlinks = [new DefHyperlink(interactionDef)];
            yield return interactedDef;
        }
    }

    private static RecordDef baseInteractionRecord()
    {
        return new RecordDef
        {
            type = RecordType.Int
        };
    }
}