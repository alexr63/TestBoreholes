
var boreholes = new List<Borehole>
{
    new Borehole(1, new Location
    {
        City = "London",
        Country = "United Kingdom"
    }, "John Doe",
        new Pumping(150.00, 100)),
    new Borehole(2, new Location
    {
        City = "Paris",
        Country = "France"
    }, "Jane Doe",
        new Damaged(DamageType.Major, new RequiresService(1000))),
    new Borehole(3, new Location
    {
        City = "Berlin",
        Country = "Germany"
    }, "John Doe",
               new Damaged(DamageType.Minor, new BeingRepaired(100))),
    new Borehole(4, new Location
    {
        City = "Madrid",
        Country = "Spain"
    }, "Jane Doe",
                      new Damaged(DamageType.Major, new BeyondRepair(10000)))
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

public abstract record ServiceType();
record RequiresService(decimal EstimatedRepairCost) : ServiceType;
record BeingRepaired(decimal DailyRepairCost) : ServiceType;
record BeyondRepair(decimal RepairCost) : ServiceType;

public abstract record OperationalType;
public record Pumping(double Volume, decimal EstimatedDailyOperationsCost) : OperationalType;
public record Damaged(DamageType DamageType, ServiceType ServiceType) : OperationalType;

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
        Damaged damaged => $"Damaged with damage type {damaged.DamageType} {damaged.ServiceType.Format()}",
        _ => throw new NotImplementedException()
    };
}

static class ServiceTypeFormatters
{
    public static string Format(this ServiceType serviceType) => serviceType switch
    {
        RequiresService requiresService => $"Requires service with estimated repair cost {requiresService.EstimatedRepairCost}",
        BeingRepaired beingRepaired => $"Being repaired with daily repair cost {beingRepaired.DailyRepairCost}",
        BeyondRepair beyondRepair => $"Beyond repair with repair cost {beyondRepair.RepairCost}",
        _ => throw new NotImplementedException()
    };
}
