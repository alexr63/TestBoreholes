
var boreholes = new List<Borehole>
{
    new Borehole(1, new Location
    {
        City = "London",
        Country = "United Kingdom"
    }, "John Doe", new Pumping(150.00, 100)),
    new Borehole(2, new Location
    {
        City = "Paris",
        Country = "France"
    }, "Jane Doe", new Damaged(DamageType.Major))
};

foreach (var borehole in boreholes)
{
    Console.WriteLine(borehole);
}

public class Location
{
    public string City { get; set; }
    public string Country { get; set; }
    // Additional properties like latitude, longitude, etc.
}

public abstract record OperationalType;
public record Pumping(double Volume, decimal EstimatedDailyOperationsCost) : OperationalType;
public record Damaged(DamageType DamageType) : OperationalType;


public abstract record RequireService();
record ServiceRequired(decimal RepairCost) : RequireService;

public class Borehole
{
    public Borehole(int id, Location location, string owner, OperationalType operationalType)
    {
        Id = id;
        Location = location;
        Owner = owner;
        OperationalType = operationalType;
    }

    int Id { get; init; }
    Location Location { get; init; }
    string Owner { get; init; }

    OperationalType OperationalType { get; init; }

    public override string ToString()
    {
        var line1 = $"Borehole {Id} is owned by {Owner} and is located in {Location.City}, {Location.Country}.";
        var line2 = OperationalType.Format();
        return line1 + Environment.NewLine + line2;
    }
}

public enum DamageType
{
    Minor,
    Major
}

static class OperationTypeFormatters
{
    public static string Format(this OperationalType operationalType) => operationalType switch
    {
        Pumping pumping =>
            $"Pumping with volume {pumping.Volume} and estimated daily operations cost {pumping.EstimatedDailyOperationsCost}",
        Damaged damaged => $"Damaged with damage type {damaged.DamageType}",
        _ => throw new NotImplementedException()
    };
}
