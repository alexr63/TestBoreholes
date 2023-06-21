
using Newtonsoft.Json;

var locations = new List<Location>
{
    new Location("London", "United Kingdom", new Borehole(1, "John", new Pumping(100, 100))),
    new Location("Paris", "France", new Borehole(2, "Jane", new Damaged(DamageType.Major, new RequiresService(1000)))),
    new Location("Berlin", "Germany", new Borehole(3, "Jack", new Damaged(DamageType.Minor, new BeingRepaired(100)))),
    new Location("Madrid", "Spain", new Borehole(4, "Jill", new Damaged(DamageType.Major, new BeyondRepair(10000)))),
    new Location("Rome", "Italy", new Borehole(5, "Joe", new Pumping(200, 200))),
};

foreach (var location in locations)
{
    Console.WriteLine(location);
    string json = JsonConvert.SerializeObject(location);
    var settings = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.Auto
    };
    var obj = JsonConvert.DeserializeObject<Location>(json, settings);
    Console.WriteLine(obj);
}

public class Location
{
    public Location(string city, string country, WaterSource waterSource)
    {
        City = city;
        Country = country;
        WaterSource = waterSource;
    }

    public string City { get; set; }
    public string Country { get; set; }
    // Additional properties like latitude, longitude, etc.

    [JsonProperty(TypeNameHandling = TypeNameHandling.Objects)]
    public WaterSource WaterSource { get; set; }

    public override string ToString()
    {
        return $"Location: {City}, {Country}, {WaterSource.Format()}";
    }
}

public abstract class Service
{
}

class RequiresService : Service
{
    public RequiresService(decimal EstimatedRepairCost)
    {
        this.EstimatedRepairCost = EstimatedRepairCost;
    }

    public decimal EstimatedRepairCost { get; init; }

    public void Deconstruct(out decimal EstimatedRepairCost)
    {
        EstimatedRepairCost = this.EstimatedRepairCost;
    }
}

class BeingRepaired : Service
{
    public BeingRepaired(decimal DailyRepairCost)
    {
        this.DailyRepairCost = DailyRepairCost;
    }

    public decimal DailyRepairCost { get; init; }

    public void Deconstruct(out decimal DailyRepairCost)
    {
        DailyRepairCost = this.DailyRepairCost;
    }
}

class BeyondRepair : Service
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

public abstract class Status
{
}

public class Pumping : Status
{
    public Pumping(double Volume, decimal EstimatedDailyOperationsCost)
    {
        this.Volume = Volume;
        this.EstimatedDailyOperationsCost = EstimatedDailyOperationsCost;
    }

    public double Volume { get; init; }
    public decimal EstimatedDailyOperationsCost { get; init; }

    public void Deconstruct(out double Volume, out decimal EstimatedDailyOperationsCost)
    {
        Volume = this.Volume;
        EstimatedDailyOperationsCost = this.EstimatedDailyOperationsCost;
    }
}

public class Damaged : Status
{
    public Damaged(DamageType DamageType, Service Service)
    {
        this.DamageType = DamageType;
        this.Service = Service;
    }

    public DamageType DamageType { get; init; }
    [JsonProperty(TypeNameHandling = TypeNameHandling.Objects)]
    public Service Service { get; init; }

    public void Deconstruct(out DamageType DamageType, out Service Service)
    {
        DamageType = this.DamageType;
        Service = this.Service;
    }
}

public abstract class WaterSource
{
}

public class Borehole : WaterSource
{
    public Borehole(int id, string owner, Status status)
    {
        Id = id;
        Owner = owner;
        Status = status;
    }

    [JsonProperty]
    public int Id { get; init; }
    [JsonProperty]
    public string Owner { get; init; }

    [JsonProperty(TypeNameHandling = TypeNameHandling.Objects)]
    public Status Status { get; init; }

    public override string ToString()
    {
        return $"Borehole {Id} is owned by {Owner}, current status is {Status.Format()}.";
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

static class WaterSourceFormatters
{
    public static string Format(this WaterSource waterSource) => waterSource switch
    {
        Borehole borehole => $"Borehole {borehole.Id} is owned by {borehole.Owner}, current status is {borehole.Status.Format()}.",
        _ => throw new NotImplementedException()
    };
}
