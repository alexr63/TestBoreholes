using NodaMoney;

namespace TestBoreholes.WaterSources.Boreholes.Services;

public class RequiredService : Service
{
    public ServiceType ServiceType { get; init; }
    public Money EstimatedCost { get; init; }
    public TimeSpan EstimatedDuration { get; init; }

    public RequiredService(ServiceType serviceType, Money estimatedCost, TimeSpan estimatedDuration)
    {
        ServiceType = serviceType;
        EstimatedCost = estimatedCost;
        EstimatedDuration = estimatedDuration;
    }

    public PerformedService Perform(Money cost, TimeSpan duration, DateTimeOffset endDateTimeOffset)
    {
        return new PerformedService(ServiceType, cost, duration, endDateTimeOffset);
    }
}