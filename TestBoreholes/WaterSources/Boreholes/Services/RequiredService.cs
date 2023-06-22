namespace TestBoreholes.WaterSources.Boreholes.Services;

public class RequiredService : Service
{
    public ServiceType ServiceType { get; init; }
    public decimal EstimatedCost { get; init; }
    public TimeSpan EstimatedDuration { get; init; }

    public RequiredService(ServiceType serviceType, decimal estimatedCost, TimeSpan estimatedDuration)
    {
        ServiceType = serviceType;
        EstimatedCost = estimatedCost;
        EstimatedDuration = estimatedDuration;
    }

    public PerformedService Perform(decimal cost, TimeSpan duration, DateTimeOffset endDateTimeOffset)
    {
        return new PerformedService(ServiceType, cost, duration, endDateTimeOffset);
    }
}