namespace TestBoreholes.WaterSources.Boreholes.Statuses;

public class BeingRepaired : Damaged
{
    public BeingRepaired(DamageSeverity damageSeverity, decimal estimatedRepairCost, TimeSpan estimatedRepairTime, decimal dailyRepairCost) : base(damageSeverity, estimatedRepairCost, estimatedRepairTime)
    {
        DailyRepairCost = dailyRepairCost;
    }

    public decimal DailyRepairCost { get; init; }
}