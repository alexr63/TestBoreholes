﻿using NodaMoney;

namespace TestBoreholes.WaterSources.Boreholes.Services;

public class PerformedService : Service
{
    public ServiceType ServiceType { get; init; }
    public Money Cost { get; init; }
    public TimeSpan Duration { get; init; }
    public DateTimeOffset EndDateTimeOffset { get; init; }

    public PerformedService(ServiceType serviceType, Money cost, TimeSpan duration, DateTimeOffset endDateTimeOffset)
    {
        ServiceType = serviceType;
        Cost = cost;
        Duration = duration;
        EndDateTimeOffset = endDateTimeOffset;
    }
}