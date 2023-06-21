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

    public override string ToString()
    {
        return $"Borehole {Id} is owned by {Owner}, current status is {Status.Format()}.";
    }

    public List<ServiceType> RequiredServices()
    {
        return Status.RequiredServices();
    }
    
    public List<ServiceType> PerformedServices()
    {
        return Status.PerformedServices();
    }

    public void AddConsumption(Consumption consumption)
    {
        Consumptions.Add(consumption);
    }

    public double GetConsumption(DateTimeOffset dateTimeOffset)
    {
        return Consumptions.Where(c => c.DateTimeOffset == dateTimeOffset).Sum(c => c.Value);
    }

    public void SetStatus(Status status)
    {
        Status = status;
    }
}