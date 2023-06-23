using NodaMoney;

namespace TestBoreholes.WaterSources.Boreholes.Services;

public class RequiredService
{
    public Money EstimatedCost { get; init; }
    public TimeSpan EstimatedDuration { get; init; }
    public DateTimeOffset PlannedStartDateTimeOffset { get; init; }

    public RequiredService(Money estimatedCost, TimeSpan estimatedDuration, DateTimeOffset plannedStartDateTimeOffset)
    {
        EstimatedCost = estimatedCost;
        EstimatedDuration = estimatedDuration;
        PlannedStartDateTimeOffset = plannedStartDateTimeOffset;
    }
}