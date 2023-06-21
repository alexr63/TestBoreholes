namespace TestBoreholes.WaterSources.Boreholes.BoreholeStatuses;

public class Pumping : BoreholeStatus
{
    public Pumping(double volume, decimal estimatedDailyOperationsCost)
    {
        Volume = volume;
        EstimatedDailyOperationsCost = estimatedDailyOperationsCost;
    }

    public double Volume { get; init; }
    public decimal EstimatedDailyOperationsCost { get; init; }

    public void Deconstruct(out double volume, out decimal estimatedDailyOperationsCost)
    {
        volume = Volume;
        estimatedDailyOperationsCost = EstimatedDailyOperationsCost;
    }
}