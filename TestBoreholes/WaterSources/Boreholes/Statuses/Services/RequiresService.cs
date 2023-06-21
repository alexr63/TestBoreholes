﻿namespace TestBoreholes.WaterSources.Boreholes.Statuses.Services;

public class RequiresService : Service
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