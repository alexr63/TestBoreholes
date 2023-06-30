using GeoTimeZone;
using Newtonsoft.Json;
using TestBoreholes.WaterSources;
using TimeZoneConverter;

namespace TestBoreholes;

public class Location
{
    public Location(string city, string country, double latitude, double longitude, WaterSource waterSource)
    {
        City = city;
        Country = country;
        Latitude = latitude;
        Longitude = longitude;
        WaterSource = waterSource;
    }

    public Location(string city, string country, double latitude, double longitude)
    {
        City = city;
        Country = country;
        Latitude = latitude;
        Longitude = longitude;
    }

    public Location()
    {
    }

    public int Id { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    [JsonProperty(TypeNameHandling = TypeNameHandling.Objects)]
    public WaterSource? WaterSource { get; set; }

    public override string ToString()
    {
        return $"Location: {City}, {Country}, {Latitude}, {Longitude} {WaterSource?.Format()}";
    }

    public TimeZoneInfo GetTimeZoneInfo()
    {
        string timeZoneId = TimeZoneLookup.GetTimeZone(Latitude, Longitude).Result;
        TimeZoneInfo timeZoneInfo = TZConvert.GetTimeZoneInfo(timeZoneId);

        return timeZoneInfo;
    }
}