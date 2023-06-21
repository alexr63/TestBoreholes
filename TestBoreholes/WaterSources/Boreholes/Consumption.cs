namespace TestBoreholes.WaterSources.Boreholes;

public class Consumption
{
    public Consumption(DateTimeOffset dateTimeOffset, double value)
    {
        DateTimeOffset = dateTimeOffset;
        Value = value;
    }

    public DateTimeOffset DateTimeOffset { get; init; }
    public double Value { get; init; }
}