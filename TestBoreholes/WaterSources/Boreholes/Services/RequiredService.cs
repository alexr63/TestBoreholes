using NodaMoney;

namespace TestBoreholes.WaterSources.Boreholes.Services;

public class RequiredService
{
    public Money EstimatedCost { get; init; }
    public TimeSpan EstimatedDuration { get; init; }
    public DateTimeOffset DueDate { get; init; }

    public RequiredService(Money estimatedCost, TimeSpan estimatedDuration, DateTimeOffset dueDate)
    {
        EstimatedCost = estimatedCost;
        EstimatedDuration = estimatedDuration;
        DueDate = dueDate;
    }
}