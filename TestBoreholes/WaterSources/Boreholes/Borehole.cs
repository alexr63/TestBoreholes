using Newtonsoft.Json;
using TestBoreholes.Formatters;
using TestBoreholes.WaterSources.Boreholes.BoreholeStatuses;

namespace TestBoreholes.WaterSources.Boreholes;

public class Borehole : WaterSource
{
    public Borehole(int id, string owner, BoreholeStatus boreholeStatus)
    {
        Id = id;
        Owner = owner;
        BoreholeStatus = boreholeStatus;
    }

    [JsonProperty]
    public int Id { get; init; }
    [JsonProperty]
    public string Owner { get; init; }

    [JsonProperty(TypeNameHandling = TypeNameHandling.Objects)]
    public BoreholeStatus BoreholeStatus { get; init; }

    public override string ToString()
    {
        return $"Borehole {Id} is owned by {Owner}, current boreholeStatus is {BoreholeStatus.Format()}.";
    }
}