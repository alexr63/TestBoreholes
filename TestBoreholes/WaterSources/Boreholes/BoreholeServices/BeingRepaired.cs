namespace TestBoreholes.WaterSources.Boreholes.BoreholeServices;

class BeingRepaired : BoreholeService
{
    public BeingRepaired(decimal dailyRepairCost)
    {
        DailyRepairCost = dailyRepairCost;
    }

    public decimal DailyRepairCost { get; init; }

    public void Deconstruct(out decimal dailyRepairCost)
    {
        dailyRepairCost = DailyRepairCost;
    }
}