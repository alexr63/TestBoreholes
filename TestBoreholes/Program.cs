using Newtonsoft.Json;
using TestBoreholes;
using TestBoreholes.WaterSources;
using TestBoreholes.WaterSources.Boreholes;
using TestBoreholes.WaterSources.Boreholes.Statuses;
using TestBoreholes.WaterSources.Boreholes.Statuses.Services;
using Stream = TestBoreholes.WaterSources.Stream;

var locations = new List<Location>
{
    new Location("London", "United Kingdom", 51.5074, -0.1278, new Borehole(1, "John", new Pumping(100, 100))),
    new Location("Paris", "France", 48.8566, 2.3522, new Borehole(2, "Jane", new Damaged(DamageType.Major, new RequiresService(1000)))),
    new Location("Berlin", "Germany", 52.5200, 13.4050, new Borehole(3, "Jack", new Damaged(DamageType.Minor, new BeingRepaired(100)))),
    new Location("Madrid", "Spain", 40.4168, -3.7038, new Borehole(4, "Jill", new Damaged(DamageType.Major, new BeyondRepair(10000)))),
    new Location("Rome", "Italy", 41.9028, 12.4964, new Borehole(5, "Joe", new Pumping(200, 200))),
    new Location("Vienna", "Austria", 48.2082, 16.3738, new Stream("Danube", 1000)),
    new Location("Budapest", "Hungary", 47.4979, 19.0402, new Pond("Lake Balaton", 1000))
};

var waterSource = locations[0].WaterSource;
if (waterSource is Borehole borehole)
{
    borehole.SetStatus(new Pumping(200, 200));
    borehole.AddConsumption(new Consumption(new DateTime(2021, 1, 1), 100));
    borehole.AddConsumption(new Consumption(new DateTime(2021, 1, 2), 200));
}

bool first = true;
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
    if (first)
    {
        first = false;
        Console.WriteLine(json);
    }
}