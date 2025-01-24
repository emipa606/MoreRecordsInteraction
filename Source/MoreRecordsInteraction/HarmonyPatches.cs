using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace MoreRecordsInteraction;

[StaticConstructorOnStartup]
public class HarmonyPatches
{
    static HarmonyPatches()
    {
        new Harmony("com.tammybee.morerecords.interaction").PatchAll(Assembly.GetExecutingAssembly());

        foreach (var def in InteractionRecordDefGenerator.ImpliedRecordDefs())
        {
            DefGenerator.AddImpliedDef(def);
        }
    }
}