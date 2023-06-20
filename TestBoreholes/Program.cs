
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
    Console.WriteLine(borehole.ToString(new OperationTypeFormatter()));
}

public class Location
{
    public string City { get; set; }
    public string Country { get; set; }
    // Additional properties like latitude, longitude, etc.
}

public abstract record OperationalType
{
    public abstract T Accept<T>(IOperationalTypeVisitor<T> visitor);
}

public record Pumping(double Volume, decimal EstimatedDailyOperationsCost) : OperationalType
{
    public override T Accept<T>(IOperationalTypeVisitor<T> visitor) => visitor.Visit(this);
}

public record Damaged(DamageType DamageType) : OperationalType
{
    public override T Accept<T>(IOperationalTypeVisitor<T> visitor) => visitor.Visit(this);
}


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

    public string ToString(IOperationalTypeVisitor<string> formatter)
    {
        var line1 = $"Borehole {Id} is owned by {Owner} and is located in {Location.City}, {Location.Country}.";
        var line2 = OperationalType.Accept(formatter);
        return line1 + Environment.NewLine + line2;
    }
}

public enum DamageType
{
    Minor,
    Major
}

public interface IOperationalTypeVisitor<out T>
{
    T Visit(Pumping pumping);
    T Visit(Damaged damaged);
}

class OperationTypeFormatter : IOperationalTypeVisitor<string>
{
    public string Visit(Pumping pumping) => $"Pumping with volume {pumping.Volume} and estimated daily operations cost {pumping.EstimatedDailyOperationsCost}";
    public string Visit(Damaged damaged) => $"Damaged with damage type {damaged.DamageType}";
}

