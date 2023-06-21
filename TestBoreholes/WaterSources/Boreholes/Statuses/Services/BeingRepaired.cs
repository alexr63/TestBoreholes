namespace TestBoreholes.WaterSources.Boreholes.Statuses.Services;

class BeingRepaired : Service
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