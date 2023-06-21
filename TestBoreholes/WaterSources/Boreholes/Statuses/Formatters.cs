namespace TestBoreholes.WaterSources.Boreholes.Statuses;

static class Formatters
{
    public static string Format(this Status boreholeStatus) => boreholeStatus switch
    {
        Pumping pumping =>
            $"Pumping with flow rate {pumping.FlowRate} and estimated daily operations cost {pumping.EstimatedDailyOperationsCost}",
        BeingRepaired beingRepaired =>
            $"Being repaired with damage type {beingRepaired.DamageSeverity} and daily repair cost {beingRepaired.DailyRepairCost}",
        Damaged damaged => $"Damaged with damage type {damaged.DamageSeverity}",
        _ => throw new NotImplementedException()
    };
}