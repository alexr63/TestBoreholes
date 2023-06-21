namespace TestBoreholes.WaterSources.Boreholes.Statuses;

public class Repaired : Pumping
{
    public Repaired(double flowRate, decimal estimatedDailyOperationsCost, List<ServiceType> performedServiceTypes, decimal repairCost, TimeSpan repairTime) : base(flowRate, estimatedDailyOperationsCost)
    {
        PerformedServiceTypes = performedServiceTypes;
        RepairCost = repairCost;
        RepairTime = repairTime;
    }

    public List<ServiceType> PerformedServiceTypes { get; init; }
    public decimal RepairCost { get; init; }
    public TimeSpan RepairTime { get; init; }
}