namespace TestBoreholes.WaterSources.Boreholes.Statuses.Services;

class BeyondRepair : Service
{
    public BeyondRepair(decimal totalRepairCost)
    {
        TotalRepairCost = totalRepairCost;
    }

    public decimal TotalRepairCost { get; init; }

    public void Deconstruct(out decimal totalRepairCost)
    {
        totalRepairCost = TotalRepairCost;
    }
}