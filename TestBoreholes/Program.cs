using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using NodaMoney;
using TestBoreholes;
using TestBoreholes.ExchangeService;
using TestBoreholes.WaterSources;
using TestBoreholes.WaterSources.Boreholes.Services;
using TestBoreholes.WaterSources.Boreholes.Statuses;
using Stream = TestBoreholes.WaterSources.Stream;

var locations = new List<Location>
{
    new("London", "United Kingdom", 51.5074, -0.1278, new Borehole("L1", "John", new Pumping(100, Money.Euro(100.0m)))),
    new("Paris", "France", 48.8566, 2.3522, new Borehole("P1", "Jane",
        new Damaged(DamageSeverity.Low, Money.Euro(1000.0m), TimeSpan.FromDays(5)))),
    new("Berlin", "Germany", 52.5200, 13.4050, new Borehole("B1", "Jack",
        new Damaged(DamageSeverity.Medium, Money.Euro(1500.0m), TimeSpan.FromDays(3)))),
    new("Madrid", "Spain", 40.4168, -3.7038, new Borehole("M1", "Jill",
        new BeingRepaired(Money.Euro(200.0m)))),
    new("Rome", "Italy", 41.9028, 12.4964, new Borehole("R1", "Joe", new Pumping(200, Money.Euro(200.0m)))),
    new("Vienna", "Austria", 48.2082, 16.3738, new Stream("Danube", 1000)),
    new("Budapest", "Hungary", 47.4979, 19.0402, new Pond("Lake Balaton", 1000)),
    new("Warsaw", "Poland", 52.2297, 21.0122, new Rain(1000)),
    new("Kiev", "Ukraine", 50.4501, 30.5234, new Rain(2000)),
    new("Ibadan", "Nigeria", 7.3117, 3.9026, new Borehole("NG-OY-1353", "FairAction Nigeria",
        new Pumping(300, new Money(76.54m, "NGN")))),
};

if (locations[1].WaterSource is Borehole parisBorehole)
{
    var timeZoneInfo = locations[1].GetTimeZoneInfo();
    parisBorehole.AddRequiredService(ServiceType.Concrete,
        new RequiredService(Money.Euro(2000.00m), TimeSpan.FromDays(7), new DateTimeOffset(2021, 3, 1, 0, 0, 0, timeZoneInfo.BaseUtcOffset)));
    parisBorehole.AddRequiredService(ServiceType.Pump,
        new RequiredService(Money.Euro(5000.00m), TimeSpan.FromDays(10), new DateTimeOffset(2021, 4, 1, 0, 0, 0, timeZoneInfo.BaseUtcOffset)));
    parisBorehole.AddRequiredService(ServiceType.Electrical,
        new RequiredService(Money.Euro(1000.00m), TimeSpan.FromDays(1), new DateTimeOffset(2021, 4, 1, 0, 0, 0, timeZoneInfo.BaseUtcOffset)));
    parisBorehole.PerformService(ServiceType.Concrete, Money.Euro(2345.67m), TimeSpan.FromDays(5), new DateTimeOffset(2021, 3, 2, 10, 30, 0, timeZoneInfo.BaseUtcOffset));
}

if (locations.Last().WaterSource is Borehole ibadanBorehole)
{
    var timeZoneInfo = locations[1].GetTimeZoneInfo();
    ibadanBorehole.AddConsumption(new DateTimeOffset(2021, 1, 1, 10, 30, 0, timeZoneInfo.BaseUtcOffset), 100);
    ibadanBorehole.AddConsumption(new DateTimeOffset(2021, 1, 2, 10, 30, 0, timeZoneInfo.BaseUtcOffset), 200);
}

var json = JsonConvert.SerializeObject(locations);

const string connectionUri = "mongodb+srv://alex:dxoLSJzx72JgPpQe@cluster0.cb3bmdl.mongodb.net/?retryWrites=true&w=majority";

var settings = MongoClientSettings.FromConnectionString(connectionUri);

// Set the ServerApi field of the settings object to Stable API version 1
settings.ServerApi = new ServerApi(ServerApiVersion.V1);

// Create a new client and connect to the server
var client = new MongoClient(settings);

var database = client.GetDatabase("TestBoreholes");

var collection = database.GetCollection<Location>("Locations");
var list = await collection.Find(e => true).ToListAsync();

// display currency symbols correctly
Console.OutputEncoding = System.Text.Encoding.Unicode;

foreach (var location in locations)
{
    Console.WriteLine(location);
    if (location.WaterSource is Borehole borehole)
    {
        Console.WriteLine($"Borehole {borehole.Id} has {borehole.Consumptions.Count} consumptions.");
        foreach (var (dateTimeOffset, value) in borehole.Consumptions)
        {
            Console.WriteLine($"Consumption at {dateTimeOffset} was {value}.");
        }

        Console.WriteLine($"Borehole {borehole.Id} has {borehole.RequiredServices.Count} required services.");
        foreach (var (serviceType, requiredService) in borehole.RequiredServices)
        {
            Console.WriteLine($"Borehole {borehole.Id} requires {serviceType} service at {requiredService.DueDate}, estimated cost is {requiredService.EstimatedCost}, estimated duration is {requiredService.EstimatedDuration}.");
        }

        Console.WriteLine($"Borehole {borehole.Id} has {borehole.PerformedServices.Count} performed services.");
        foreach (var performedService in borehole.PerformedServices)
        {
            Console.WriteLine($"Borehole {borehole.Id} was serviced for {performedService.ServiceType} at {performedService.EndDate}, service cost was {performedService.Cost}, service duration was {performedService.Duration}.");
        }
    }
}

var exchangeService = new ExchangeService();
var naira10000 = new Money(10000m, "NGN");
Console.WriteLine($"{naira10000} in USD is {exchangeService.Convert(naira10000)}.");


