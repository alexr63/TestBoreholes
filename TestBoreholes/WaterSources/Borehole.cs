using Newtonsoft.Json;
using NodaMoney;
using TestBoreholes.WaterSources.Boreholes;
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
    public List<Service> Services { get; init; } = new();

    public override string ToString()
    {
        return $"Borehole {Id} is owned by {Owner}, current status is {Status.Format()}.";
    }

    public void RequireService(RequiredService requiredService)
    {
        Services.Add(requiredService);
    }

    public void PerformService(RequiredService requiredService, Money cost, TimeSpan duration, DateTimeOffset endDateTimeOffset)
    {
        var performedService = requiredService.Perform(cost, duration, endDateTimeOffset);
        Services.Remove(requiredService);
        Services.Add(performedService);
    }

    public void AddConsumption(Consumption consumption)
    {
        Consumptions[consumption.DateTimeOffset] = consumption.Value;
    }

    public void ChangeStatusToDamaged(DamageSeverity damageSeverity, Money estimatedRepairCost, TimeSpan estimatedRepairTime)
    {
        Status = new Damaged(damageSeverity, estimatedRepairCost, estimatedRepairTime);
    }

    public void ChangeStatusToPumping(double flowRate, Money estimatedDailyOperationsCost)
    {
        Status = new Pumping(flowRate, estimatedDailyOperationsCost);
    }

    public void ChangeStatusToBeingRepaired(DamageSeverity damageSeverity,
        Money estimatedRepairCost, TimeSpan estimatedRepairTime, Money dailyRepairCost)
    {
        Status = new BeingRepaired(damageSeverity, estimatedRepairCost, estimatedRepairTime, dailyRepairCost);
    }
}