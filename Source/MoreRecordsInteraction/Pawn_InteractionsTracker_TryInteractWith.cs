using HarmonyLib;
using RimWorld;
using Verse;

namespace MoreRecordsInteraction;

[HarmonyPatch(typeof(Pawn_InteractionsTracker), nameof(Pawn_InteractionsTracker.TryInteractWith))]
public class Pawn_InteractionsTracker_TryInteractWith
{
    private static void Postfix(bool __result, Pawn ___pawn, Pawn recipient, InteractionDef intDef)
    {
        if (!__result)
        {
            return;
        }

        ___pawn?.records.Increment(InteractionRecordDefGenerator.GetInteractRecordDef(intDef));

        recipient?.records.Increment(InteractionRecordDefGenerator.GetInteractedRecordDef(intDef));
    }
}