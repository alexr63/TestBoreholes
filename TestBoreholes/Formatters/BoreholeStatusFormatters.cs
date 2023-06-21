using TestBoreholes.WaterSources.Boreholes.BoreholeStatuses;

namespace TestBoreholes.Formatters;

static class BoreholeStatusFormatters
{
    public static string Format(this BoreholeStatus boreholeStatus) => boreholeStatus switch
    {
        Pumping pumping =>
            $"Pumping with volume {pumping.Volume} and estimated daily operations cost {pumping.EstimatedDailyOperationsCost}",
        Damaged damaged => $"Damaged with damage type {damaged.DamageType} {damaged.Service.Format()}",
        _ => throw new NotImplementedException()
    };
}