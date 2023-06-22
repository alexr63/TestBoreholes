using NodaMoney;

namespace TestBoreholes.WaterSources.Boreholes.Statuses;

public class BeingRepaired : Damaged
{
    public BeingRepaired(DamageSeverity damageSeverity, Money estimatedRepairCost, TimeSpan estimatedRepairTime, Money dailyRepairCost) : base(damageSeverity, estimatedRepairCost, estimatedRepairTime)
    {
        DailyRepairCost = dailyRepairCost;
    }

    public Money DailyRepairCost { get; init; }
}