using NodaMoney;

namespace TestBoreholes.WaterSources.Boreholes.Services;

public class PerformedService
{
    public ServiceType ServiceType { get; init; }
    public Money Cost { get; init; }
    public TimeSpan Duration { get; init; }
    public DateTimeOffset EndDate { get; init; }

    public PerformedService(ServiceType serviceType, Money cost, TimeSpan duration, DateTimeOffset endDate)
    {
        ServiceType = serviceType;
        Cost = cost;
        Duration = duration;
        EndDate = endDate;
    }
}