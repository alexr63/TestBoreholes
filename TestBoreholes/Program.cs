
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
                      new Damaged(DamageType.Major, new BeyondRepair(2000)))
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

public abstract record Service();
record RequiresService(decimal EstimatedRepairCost) : Service;
record BeingRepaired(decimal DailyRepairCost) : Service;
record BeyondRepair(decimal TotalRepairCost) : Service;

public abstract record Status;
public record Pumping(double Volume, decimal EstimatedDailyOperationsCost) : Status;
public record Damaged(DamageType DamageType, Service Service) : Status;

public class Borehole
{
    public Borehole(int id, Location location, string owner, Status status)
    {
        Id = id;
        Location = location;
        Owner = owner;
        Status = status;
    }

    int Id { get; init; }
    Location Location { get; init; }
    string Owner { get; init; }

    Status Status { get; init; }

    public override string ToString()
    {
        var line1 = $"Borehole {Id} is owned by {Owner} and is located in {Location.City}, {Location.Country}.";
        var line2 = Status.Format();
        return line1 + Environment.NewLine + line2;
    }
}

public enum DamageType
{
    Minor,
    Major
}

static class StatusFormatters
{
    public static string Format(this Status status) => status switch
    {
        Pumping pumping =>
            $"Pumping with volume {pumping.Volume} and estimated daily operations cost {pumping.EstimatedDailyOperationsCost}",
        Damaged damaged => $"Damaged with damage type {damaged.DamageType} {damaged.Service.Format()}",
        _ => throw new NotImplementedException()
    };
}

static class ServiceFormatters
{
    public static string Format(this Service service) => service switch
    {
        RequiresService requiresService => $"Requires service with estimated repair cost {requiresService.EstimatedRepairCost}",
        BeingRepaired beingRepaired => $"Being repaired with daily repair cost {beingRepaired.DailyRepairCost}",
        BeyondRepair beyondRepair => $"Beyond repair with total repair cost {beyondRepair.TotalRepairCost}",
        _ => throw new NotImplementedException()
    };
}
