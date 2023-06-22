namespace TestBoreholes.WaterSources.Boreholes.Statuses;

public class Damaged : Status
{
    public Damaged(DamageSeverity damageSeverity, decimal estimatedRepairCost, TimeSpan estimatedRepairTime)
    {
        DamageSeverity = damageSeverity;
        EstimatedRepairCost = estimatedRepairCost;
        EstimatedRepairTime = estimatedRepairTime;
    }

    public DamageSeverity DamageSeverity { get; init; }
    public decimal EstimatedRepairCost { get; init; }
    public TimeSpan EstimatedRepairTime { get; init; }
}