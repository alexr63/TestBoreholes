using TestBoreholes.WaterSources.Boreholes.BoreholeServices;

namespace TestBoreholes.Formatters;

static class BoreholeServiceFormatters
{
    public static string Format(this BoreholeService service) => service switch
    {
        RequiresService requiresService => $"Requires service with estimated repair cost {requiresService.EstimatedRepairCost}",
        BeingRepaired beingRepaired => $"Being repaired with daily repair cost {beingRepaired.DailyRepairCost}",
        BeyondRepair beyondRepair => $"Beyond repair with total repair cost {beyondRepair.TotalRepairCost}",
        _ => throw new NotImplementedException()
    };
}