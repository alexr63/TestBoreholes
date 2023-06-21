namespace TestBoreholes.WaterSources.Boreholes;

public class Consumption
{
    public Consumption(DateTime dateTime, double value)
    {
        DateTime = dateTime;
        Value = value;
    }

    public DateTime DateTime { get; init; }
    public double Value { get; init; }
}