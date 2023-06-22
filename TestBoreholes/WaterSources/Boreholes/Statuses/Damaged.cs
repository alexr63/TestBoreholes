using NodaMoney;

namespace TestBoreholes.WaterSources.Boreholes.Statuses;

public class Damaged : Status
{
    public Damaged(DamageSeverity damageSeverity, Money estimatedRepairCost, TimeSpan estimatedRepairTime)
    {
        DamageSeverity = damageSeverity;
        EstimatedRepairCost = estimatedRepairCost;
        EstimatedRepairTime = estimatedRepairTime;
    }

    public DamageSeverity DamageSeverity { get; init; }
    public Money EstimatedRepairCost { get; init; }
    public TimeSpan EstimatedRepairTime { get; init; }
}