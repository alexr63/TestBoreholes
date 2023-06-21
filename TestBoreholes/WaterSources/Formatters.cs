using TestBoreholes.WaterSources.Boreholes.Statuses;

namespace TestBoreholes.WaterSources;

static class Formatters
{
    public static string Format(this WaterSource waterSource) => waterSource switch
    {
        Borehole borehole => $"Borehole {borehole.Id} is owned by {borehole.Owner}, current boreholeStatus is {borehole.Status.Format()}.",
        Stream stream => $"Stream {stream.Name} with flow rate {stream.FlowRate}",
        Pond pond => $"Pond {pond.Name} with area {pond.Area}",
        _ => throw new NotImplementedException()
    };
}