using Newtonsoft.Json;
using NodaMoney;
using TestBoreholes.WaterSources.Boreholes.Services;
using TestBoreholes.WaterSources.Boreholes.Statuses;

namespace TestBoreholes.WaterSources;

public class Borehole : WaterSource
{
    public Borehole(string id, string owner, Status status)
    {
        Id = id;
        Owner = owner;
        Status = status;
    }

    public string Id { get; init; }
    public string Owner { get; init; }

    [JsonProperty(TypeNameHandling = TypeNameHandling.Objects)]
    public Status Status { get; private set; }
    public SortedDictionary<DateTimeOffset, double> Consumptions { get; init; } = new();
    public List<PerformedService> PerformedServices { get; init; } = new();
    public Dictionary<ServiceType, RequiredService> RequiredServices { get; init; } = new();

    public override string ToString()
    {
        return $"Borehole {Id} is owned by {Owner}, current status is {Status.Format()}.";
    }

    public void AddRequiredService(ServiceType serviceType, RequiredService requiredService)
    {
        RequiredServices[serviceType] = requiredService;
    }
    
    public void AddConsumption(DateTimeOffset dateTimeOffset, double value)
    {
        Consumptions[dateTimeOffset] = value;
    }

    public void PerformService(ServiceType serviceType, Money cost, TimeSpan duration, DateTimeOffset endDateTimeOffset)
    {
        if (RequiredServices.ContainsKey(serviceType))
        {
            RequiredServices.Remove(serviceType);

            var performedService = new PerformedService(serviceType, cost, duration, endDateTimeOffset);
            PerformedServices.Add(performedService);
        }
    }
}