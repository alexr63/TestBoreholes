using TestBoreholes.WaterSources.Boreholes.Statuses.Services;

namespace TestBoreholes.WaterSources.Boreholes.Statuses;

static class Formatters
{
    public static string Format(this Status boreholeStatus) => boreholeStatus switch
    {
        Pumping pumping =>
            $"Pumping with flow rate {pumping.FlowRate} and estimated daily operations cost {pumping.EstimatedDailyOperationsCost}",
        Damaged damaged => $"Damaged with damage type {damaged.DamageType} {damaged.Service.Format()}",
        _ => throw new NotImplementedException()
    };
}