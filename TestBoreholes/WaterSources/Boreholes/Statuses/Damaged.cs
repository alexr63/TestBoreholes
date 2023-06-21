using Newtonsoft.Json;
using TestBoreholes.WaterSources.Boreholes.Statuses.Services;

namespace TestBoreholes.WaterSources.Boreholes.Statuses;

public class Damaged : Status
{
    public Damaged(DamageType damageType, Service service)
    {
        DamageType = damageType;
        Service = service;
    }

    public DamageType DamageType { get; init; }
    [JsonProperty(TypeNameHandling = TypeNameHandling.Objects)]
    public Service Service { get; init; }

    public void Deconstruct(out DamageType damageType, out Service service)
    {
        damageType = DamageType;
        service = Service;
    }
}