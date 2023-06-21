namespace TestBoreholes.WaterSources.Boreholes.Statuses;

static class Queries
{
    public static List<ServiceType> RequiredServices(this Status boreholeStatus) => boreholeStatus switch
    {
        Repaired repaired => repaired.PerformedServiceTypes,
        Pumping pumping => new List<ServiceType>(),
        BeingRepaired beingRepaired => beingRepaired.RequiredServiceTypes,
        Damaged damaged => damaged.RequiredServiceTypes,
        _ => throw new NotImplementedException()
    };
}