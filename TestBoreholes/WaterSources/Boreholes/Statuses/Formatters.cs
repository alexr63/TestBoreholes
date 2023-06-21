namespace TestBoreholes.WaterSources.Boreholes.Statuses;

static class Formatters
{
    public static string Format(this Status boreholeStatus) => boreholeStatus switch
    {
        Repaired repaired =>
            $"Repaired with flow rate {repaired.FlowRate} and repair cost {repaired.RepairCost}",
        Pumping pumping =>
            $"Pumping with flow rate {pumping.FlowRate} and estimated daily operations cost {pumping.EstimatedDailyOperationsCost}",
        BeingRepaired beingRepaired =>
            $"Being repaired with damage type {beingRepaired.DamageType} and daily repair cost {beingRepaired.DailyRepairCost}",
        Damaged damaged => $"Damaged with damage type {damaged.DamageType}",
        _ => throw new NotImplementedException()
    };
}