namespace TestBoreholes.WaterSources.Boreholes.Statuses;

static class Queries
{
    public static List<ServiceType> RequiredServices(this Status boreholeStatus) => boreholeStatus switch
    {
        Repaired repaired => new List<ServiceType>(),
        Pumping pumping => new List<ServiceType>(),
        BeingRepaired beingRepaired => beingRepaired.RequiredServiceTypes,
        Damaged damaged => damaged.RequiredServiceTypes,
        _ => throw new NotImplementedException()
    };

    public static List<ServiceType> PerformedServices(this Status boreholeStatus) => boreholeStatus switch
    {
        Repaired repaired => repaired.PerformedServiceTypes,
        Pumping pumping => new List<ServiceType>(),
        BeingRepaired beingRepaired => new List<ServiceType>(),
        Damaged damaged => new List<ServiceType>(),
        _ => throw new NotImplementedException()
    };
}