namespace TestBoreholes.WaterSources.Boreholes.Services;

static class Formatters
{
    public static string Format(this Service service) => service switch
    {
        RequiredService requiredService =>
            $"Required service of type {requiredService.ServiceType} with estimated cost {requiredService.EstimatedCost} and estimated duration {requiredService.EstimatedDuration}",
        PerformedService performedService =>
            $"Performed service of type {performedService.ServiceType} with cost {performedService.Cost} and duration {performedService.Duration}",
        _ => throw new NotImplementedException()
    };
}