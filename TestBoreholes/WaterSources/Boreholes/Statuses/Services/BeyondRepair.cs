namespace TestBoreholes.WaterSources.Boreholes.Statuses.Services;

class BeyondRepair : Service
{
    public BeyondRepair(decimal TotalRepairCost)
    {
        this.TotalRepairCost = TotalRepairCost;
    }

    public decimal TotalRepairCost { get; init; }

    public void Deconstruct(out decimal TotalRepairCost)
    {
        TotalRepairCost = this.TotalRepairCost;
    }
}