using TestBoreholes.WaterSources;
using TestBoreholes.WaterSources.Boreholes;
using Stream = TestBoreholes.WaterSources.Stream;

namespace TestBoreholes.Formatters;

static class WaterSourceFormatters
{
    public static string Format(this WaterSource waterSource) => waterSource switch
    {
        Borehole borehole => $"Borehole {borehole.Id} is owned by {borehole.Owner}, current boreholeStatus is {borehole.BoreholeStatus.Format()}.",
        Stream stream => $"Stream {stream.Name} with flow rate {stream.FlowRate}",
        Pond pond => $"Pond {pond.Name} with area {pond.Area}",
        _ => throw new NotImplementedException()
    };
}