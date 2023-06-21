using Newtonsoft.Json;
using TestBoreholes.WaterSources.Boreholes.BoreholeServices;

namespace TestBoreholes.WaterSources.Boreholes.BoreholeStatuses;

public class Damaged : BoreholeStatus
{
    public Damaged(DamageType damageType, BoreholeService service)
    {
        DamageType = damageType;
        Service = service;
    }

    public DamageType DamageType { get; init; }
    [JsonProperty(TypeNameHandling = TypeNameHandling.Objects)]
    public BoreholeService Service { get; init; }

    public void Deconstruct(out DamageType damageType, out BoreholeService service)
    {
        damageType = DamageType;
        service = Service;
    }
}