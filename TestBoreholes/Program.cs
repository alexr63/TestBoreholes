using NodaMoney;
using TestBoreholes;
using TestBoreholes.WaterSources;
using TestBoreholes.WaterSources.Boreholes.Services;
using TestBoreholes.WaterSources.Boreholes.Statuses;
using Stream = TestBoreholes.WaterSources.Stream;

var locations = new List<Location>
{
    new Location("London", "United Kingdom", 51.5074, -0.1278, new Borehole("L1", "John", new Pumping(100, Money.Euro(100.0m)))),
    new Location("Paris", "France", 48.8566, 2.3522, new Borehole("P1", "Jane",
        new Damaged(DamageSeverity.Low, Money.Euro(1000.0m), TimeSpan.FromDays(5)))),
    new Location("Berlin", "Germany", 52.5200, 13.4050, new Borehole("B1", "Jack",
        new Damaged(DamageSeverity.Medium, Money.Euro(1500.0m), TimeSpan.FromDays(3)))),
    new Location("Madrid", "Spain", 40.4168, -3.7038, new Borehole("M1", "Jill",
        new BeingRepaired(DamageSeverity.High, Money.Euro(1000.0m), TimeSpan.FromDays(5), Money.Euro(200.0m)))),
    new Location("Rome", "Italy", 41.9028, 12.4964, new Borehole("R1", "Joe", new Pumping(200, Money.Euro(200.0m)))),
    new Location("Vienna", "Austria", 48.2082, 16.3738, new Stream("Danube", 1000)),
    new Location("Budapest", "Hungary", 47.4979, 19.0402, new Pond("Lake Balaton", 1000)),
    new Location("Warsaw", "Poland", 52.2297, 21.0122, new Rain(1000)),
    new Location("Kiev", "Ukraine", 50.4501, 30.5234, new Rain(2000)),
    new Location("Ibadan", "Nigeria", 7.3117, 3.9026, new Rain(3000)),
};

if (locations[1].WaterSource is Borehole borehole1)
{
    borehole1.RequireService(new RequiredService(ServiceType.Concrete, Money.Euro(123.45m), TimeSpan.FromDays(4)));
}

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

        Console.WriteLine($"Borehole {borehole.Id} has {borehole.Services.Count} services.");
        foreach (var service in borehole.Services)
        {
            Console.WriteLine(service.Format());
        }
    }
}

