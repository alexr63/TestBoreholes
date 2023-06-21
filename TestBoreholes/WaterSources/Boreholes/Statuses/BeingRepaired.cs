namespace TestBoreholes.WaterSources.Boreholes.Statuses;

public class BeingRepaired : Damaged
{
    public BeingRepaired(DamageType damageType, List<ServiceType> requiredServiceTypes, decimal estimatedRepairCost, TimeSpan estimatedRepairTime, decimal dailyRepairCost) : base(damageType, requiredServiceTypes, estimatedRepairCost, estimatedRepairTime)
    {
        DailyRepairCost = dailyRepairCost;
    }

    public decimal DailyRepairCost { get; init; }
}