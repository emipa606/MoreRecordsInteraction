using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MoreRecordsInteraction;

public class InteractionRecordDefGenerator
{
    private static readonly string InteractRecordDefPrefix = "TMB_Interact";
    private static readonly string InteractedRecordDefPrefix = "TMB_Interacted";

    public static string GetInteractRecordDefName(InteractionDef interactionDef)
    {
        return $"{InteractRecordDefPrefix}_{interactionDef.defName}";
    }

    public static string GetInteractedRecordDefName(InteractionDef interactionDef)
    {
        return $"{InteractedRecordDefPrefix}_{interactionDef.defName}";
    }

    public static RecordDef GetInteractRecordDef(InteractionDef interactionDef)
    {
        return DefDatabase<RecordDef>.GetNamed(GetInteractRecordDefName(interactionDef));
    }

    public static RecordDef GetInteractedRecordDef(InteractionDef interactionDef)
    {
        return DefDatabase<RecordDef>.GetNamed(GetInteractedRecordDefName(interactionDef));
    }

    public static IEnumerable<RecordDef> ImpliedRecordDefs()
    {
        foreach (var interactionDef in DefDatabase<InteractionDef>.AllDefs)
        {
            var interactDef = BaseInteractionRecord();
            interactDef.defName = GetInteractRecordDefName(interactionDef);
            interactDef.label = "MoreRecordsInteraction.InteractRecordLabel".Translate(interactionDef.label);
            interactDef.description =
                "MoreRecordsInteraction.InteractRecordDescription".Translate(interactionDef.label);
            interactDef.descriptionHyperlinks = [new DefHyperlink(interactionDef)];
            yield return interactDef;

            var interactedDef = BaseInteractionRecord();
            interactedDef.defName = GetInteractedRecordDefName(interactionDef);
            interactedDef.label = "MoreRecordsInteraction.InteractedRecordLabel".Translate(interactionDef.label);
            interactedDef.description =
                "MoreRecordsInteraction.InteractedRecordDescription".Translate(interactionDef.label);
            interactedDef.descriptionHyperlinks = [new DefHyperlink(interactionDef)];
            yield return interactedDef;
        }
    }

    private static RecordDef BaseInteractionRecord()
    {
        return new RecordDef
        {
            type = RecordType.Int
        };
    }
}