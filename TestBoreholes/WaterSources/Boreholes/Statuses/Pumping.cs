namespace TestBoreholes.WaterSources.Boreholes.Statuses;

public class Pumping : Status
{
    public Pumping(double flowRate, decimal estimatedDailyOperationsCost)
    {
        FlowRate = flowRate;
        EstimatedDailyOperationsCost = estimatedDailyOperationsCost;
    }

    public double FlowRate { get; init; }
    public decimal EstimatedDailyOperationsCost { get; init; }
}