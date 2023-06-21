namespace TestBoreholes.WaterSources.Boreholes.BoreholeServices;

class BeyondRepair : BoreholeService
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