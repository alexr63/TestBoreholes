namespace TestBoreholes.WaterSources.Boreholes.BoreholeServices;

class RequiresService : BoreholeService
{
    public RequiresService(decimal estimatedRepairCost)
    {
        EstimatedRepairCost = estimatedRepairCost;
    }

    public decimal EstimatedRepairCost { get; init; }

    public void Deconstruct(out decimal estimatedRepairCost)
    {
        estimatedRepairCost = EstimatedRepairCost;
    }
}