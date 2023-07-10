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
    public List<PerformedService> PerformedServices { get; init; } = new();

    public override string ToString()
    {
        return $"Borehole {Id} is owned by {Owner}, current status is {Status.Format()}.";
    }
}