namespace TestBoreholes.WaterSources.Boreholes.Statuses;

public enum ServiceType
{
    Concrete,
    Construction,
    Electrical,
    Mechanical,
    Plumbing,
    Pump,
    Steel,
    Other
}

public abstract class Service
{
}

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

public class PerformedService : Service
{
    public ServiceType ServiceType { get; init; }
    public decimal Cost { get; init; }
    public TimeSpan Duration { get; init; }
    public DateTimeOffset EndDateTimeOffset { get; init; }

    public PerformedService(ServiceType serviceType, decimal cost, TimeSpan duration, DateTimeOffset endDateTimeOffset)
    {
        ServiceType = serviceType;
        Cost = cost;
        Duration = duration;
        EndDateTimeOffset = endDateTimeOffset;
    }
}