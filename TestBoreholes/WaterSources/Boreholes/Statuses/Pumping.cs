using NodaMoney;

namespace TestBoreholes.WaterSources.Boreholes.Statuses;

public class Pumping : Status
{
    public Pumping(double flowRate, Money estimatedDailyOperationsCost)
    {
        FlowRate = flowRate;
        EstimatedDailyOperationsCost = estimatedDailyOperationsCost;
    }

    public double FlowRate { get; init; }
    public Money EstimatedDailyOperationsCost { get; init; }
}