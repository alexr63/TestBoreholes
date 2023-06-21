using Newtonsoft.Json;
using TestBoreholes.WaterSources.Boreholes;
using TestBoreholes.WaterSources.Boreholes.Statuses;

namespace TestBoreholes.WaterSources;

public class Borehole : WaterSource
{
    public Borehole(int id, string owner, Status status)
    {
        Id = id;
        Owner = owner;
        Status = status;
    }

    public int Id { get; init; }
    public string Owner { get; init; }

    [JsonProperty(TypeNameHandling = TypeNameHandling.Objects)]
    public Status Status { get; private set; }
    public List<Consumption> Consumptions { get; init; } = new();
    public List<Service> Services { get; init; } = new();

    public override string ToString()
    {
        return $"Borehole {Id} is owned by {Owner}, current status is {Status.Format()}.";
    }

    public void RequireService(RequiredService requiredService)
    {
        Services.Add(requiredService);
    }

    public void PerformService(RequiredService requiredService, decimal cost, TimeSpan duration, DateTimeOffset endDateTimeOffset)
    {
        var performedService = requiredService.Perform(cost, duration, endDateTimeOffset);
        Services.Remove(requiredService);
        Services.Add(performedService);
    }

    public void AddConsumption(Consumption consumption)
    {
        Consumptions.Add(consumption);
    }

    public double GetConsumption(DateTimeOffset dateTimeOffset)
    {
        return Consumptions.Where(c => c.DateTimeOffset == dateTimeOffset).Sum(c => c.Value);
    }

    public void ChangeStatusToDamaged(DamageSeverity damageSeverity, decimal estimatedRepairCost, TimeSpan estimatedRepairTime)
    {
        Status = new Damaged(damageSeverity, estimatedRepairCost, estimatedRepairTime);
    }

    public void ChangeStatusToPumping(double flowRate, decimal estimatedDailyOperationsCost)
    {
        Status = new Pumping(flowRate, estimatedDailyOperationsCost);
    }

    public void ChangeStatusToBeingRepaired(DamageSeverity damageSeverity,
        decimal estimatedRepairCost, TimeSpan estimatedRepairTime, decimal dailyRepairCost)
    {
        Status = new BeingRepaired(damageSeverity, estimatedRepairCost, estimatedRepairTime, dailyRepairCost);
    }
}