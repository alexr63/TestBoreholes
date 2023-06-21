namespace TestBoreholes.WaterSources.Boreholes.Statuses;

public class Damaged : Status
{
    public Damaged(DamageType damageType, List<ServiceType> requiredServiceTypes, decimal estimatedRepairCost, TimeSpan estimatedRepairTime)
    {
        DamageType = damageType;
        RequiredServiceTypes = requiredServiceTypes;
        EstimatedRepairCost = estimatedRepairCost;
        EstimatedRepairTime = estimatedRepairTime;
    }

    public DamageType DamageType { get; init; }
    public List<ServiceType> RequiredServiceTypes { get; init; }
    public decimal EstimatedRepairCost { get; init; }
    public TimeSpan EstimatedRepairTime { get; init; }
}