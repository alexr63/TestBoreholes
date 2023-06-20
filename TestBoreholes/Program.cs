
using Newtonsoft.Json;

var boreholes = new List<Borehole>
{
    new Borehole(1, new Location
    {
        City = "London",
        Country = "United Kingdom"
    }, "John Doe",
        new Pumping(150.0, 100.00m)),
    new Borehole(2, new Location
    {
        City = "Paris",
        Country = "France"
    }, "Jane Doe",
        new Damaged(DamageType.Major, new RequiresService(1000.00m))),
    new Borehole(3, new Location
    {
        City = "Berlin",
        Country = "Germany"
    }, "John Doe",
               new Damaged(DamageType.Minor, new BeingRepaired(100.00m))),
    new Borehole(4, new Location
    {
        City = "Madrid",
        Country = "Spain"
    }, "Jane Doe",
                      new Damaged(DamageType.Major, new BeyondRepair(2000.00m)))
};

foreach (var borehole in boreholes)
{
    
}

foreach (var borehole in boreholes)
{
    Console.WriteLine(borehole);
    string json = JsonConvert.SerializeObject(borehole);
    var settings = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.Auto
    };
    var obj = JsonConvert.DeserializeObject<Borehole>(json, settings);
    Console.WriteLine(obj);
}

public class Location
{
    public string City { get; set; }
    public string Country { get; set; }
    // Additional properties like latitude, longitude, etc.
}

public abstract class Service
{
    protected Service()
    {
    }
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

public class Borehole
{
    public Borehole(int id, Location location, string owner, Status status)
    {
        Id = id;
        Location = location;
        Owner = owner;
        Status = status;
    }

    [JsonProperty]
    int Id { get; init; }
    [JsonProperty]
    Location Location { get; init; }
    [JsonProperty]
    string Owner { get; init; }

    [JsonProperty(TypeNameHandling = TypeNameHandling.Objects)]
    Status Status { get; init; }

    public override string ToString()
    {
        var line1 = $"Borehole {Id} is owned by {Owner} and is located in {Location.City}, {Location.Country}.";
        var line2 = Status.Format();
        return String.Join(" ", line1, line2);
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
