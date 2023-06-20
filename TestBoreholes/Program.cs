
var boreholes = new List<Borehole>
{
    new FunctioningBorehole
    {
        Id = 1,
        Location = new Location
        {
            City = "London",
            Country = "United Kingdom"
        },
        Owner = "John Doe",
        EstimatedDailyOperationsCost = 100
    },
    new DamagedBorehole
    {
        Id = 2,
        Location = new Location
        {
            City = "Paris",
            Country = "France"
        },
        Owner = "Jane Doe",
        DamageType = DamageType.Major,
        RepairCost = 1000
    }
};

foreach (var borehole in boreholes)
{
    Console.WriteLine($"Borehole {borehole.Id} is owned by {borehole.Owner} and is located in {borehole.Location.City}, {borehole.Location.Country}.");
    switch (borehole)
    {
        case FunctioningBorehole functioningBorehole:
            Console.WriteLine($"It is functioning and will cost {functioningBorehole.EstimatedDailyOperationsCost} per day to operate.");
            break;
        case DamagedBorehole damagedBorehole:
            Console.WriteLine($"It is damaged ({damagedBorehole.DamageType}) and will cost {damagedBorehole.RepairCost} to repair.");
            break;
    }
}

public class Location
{
    public string City { get; set; }
    public string Country { get; set; }
    // Additional properties like latitude, longitude, etc.
}

public class Borehole
{
    public int Id { get; set; }
    public Location Location { get; set; }
    public string Owner { get; set; }
}

public class FunctioningBorehole : Borehole
{
    public decimal EstimatedDailyOperationsCost { get; set; }
}

public class DamagedBorehole : Borehole
{
    public DamageType DamageType { get; set; }
    public decimal RepairCost { get; set; }
}

public enum DamageType
{
    Minor,
    Major
}
