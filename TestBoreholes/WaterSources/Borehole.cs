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

    public void AddConsumption(Consumption consumption)
    {
        Consumptions.Add(consumption);
    }

    public double GetConsumption(DateTime dateTime)
    {
        return Consumptions.Where(c => c.DateTime == dateTime).Sum(c => c.Value);
    }

    public void SetStatus(Status status)
    {
        Status = status;
    }
}