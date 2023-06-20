
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
        Owner = "John Doe",
        OperationalType = new Functioning(100)
    },
    new Borehole
    {
        Id = 2,
        Location = new Location
        {
            City = "Paris",
            Country = "France"
        },
        Owner = "Jane Doe",
        OperationalType = new Damaged(DamageType.Major, 1000)
    }
};

foreach (var borehole in boreholes)
{
    Console.WriteLine($"Borehole {borehole.Id} is owned by {borehole.Owner} and is located in {borehole.Location.City}, {borehole.Location.Country}.");
    Console.WriteLine($"It is currently {borehole.OperationalType switch
    {
        Functioning => "functioning",
        Damaged => "damaged",
        _ => "unknown"
    }}.");
}

public class Location
{
    public string City { get; set; }
    public string Country { get; set; }
    // Additional properties like latitude, longitude, etc.
}

public record OperationalType();
public record Functioning(decimal EstimatedDailyOperationsCost) : OperationalType;
public record Damaged(DamageType DamageType, decimal RepairCost) : OperationalType;

public class Borehole
{
    public int Id { get; set; }
    public Location Location { get; set; }
    public string Owner { get; set; }

    public OperationalType OperationalType { get; set; }
}

public enum DamageType
{
    Minor,
    Major
}
