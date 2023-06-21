using TestBoreholes;
using TestBoreholes.WaterSources;
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
    new Location("Budapest", "Hungary", 47.4979, 19.0402, new Pond("Lake Balaton", 1000)),
    new Location("Warsaw", "Poland", 52.2297, 21.0122, new Rain(1000)),
    new Location("Kiev", "Ukraine", 50.4501, 30.5234, new Rain(2000)),
    new Location("Ibadan", "Nigeria", 7.3117, 3.9026, new Rain(3000)),
};

foreach (var location in locations)
{
    Console.WriteLine(location);
}

