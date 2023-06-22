namespace TestBoreholes.WaterSources.Boreholes.Services;

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