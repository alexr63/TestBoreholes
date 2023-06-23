using NodaMoney;

namespace TestBoreholes.WaterSources.Boreholes.Statuses;

public class BeingRepaired : Status
{
    public BeingRepaired(Money dailyRepairCost)
    {
        DailyRepairCost = dailyRepairCost;
    }

    public Money DailyRepairCost { get; init; }
}