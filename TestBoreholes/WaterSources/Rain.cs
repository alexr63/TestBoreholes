namespace TestBoreholes.WaterSources;

public class Rain : WaterSource
{
    public Rain(double rate)
    {
        Rate = rate;
    }

    public double Rate { get; init; }
}