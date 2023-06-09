
var boreholes = new List<Borehole>
{
    new Borehole
    {
        Id = 1,
        Location = new Location
        {
            City = "London",
            Country = "United Kingdom"
        },
        Owner = "John Doe"
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
    if (borehole is DamagedBorehole damagedBorehole)
    {
        Console.WriteLine($"It is damaged ({damagedBorehole.DamageType}) and will cost {damagedBorehole.RepairCost} to repair.");
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
