namespace TestBoreholes.WaterSources;

public class Stream : WaterSource
{
    public Stream(string name, double flowRate)
    {
        Name = name;
        FlowRate = flowRate;
    }

    public string Name { get; init; }
    public double FlowRate { get; init; }
}