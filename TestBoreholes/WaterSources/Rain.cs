namespace TestBoreholes.WaterSources;

public class Rain : WaterSource
{
    public Rain(double amount)
    {
        Amount = amount;
    }

    public double Amount { get; init; }
}