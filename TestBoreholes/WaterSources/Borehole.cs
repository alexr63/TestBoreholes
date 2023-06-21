using Newtonsoft.Json;
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

    [JsonProperty]
    public int Id { get; init; }
    [JsonProperty]
    public string Owner { get; init; }

    [JsonProperty(TypeNameHandling = TypeNameHandling.Objects)]
    public Status Status { get; init; }

    public override string ToString()
    {
        return $"Borehole {Id} is owned by {Owner}, current status is {Status.Format()}.";
    }
}