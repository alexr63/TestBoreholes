using FluentAssertions;
using Newtonsoft.Json;
using TestBoreholes.WaterSources;

namespace TestBoreholes.Tests
{
    public class SerializationTest
    {
        private readonly Location _ibadan;

        public SerializationTest()
        {
            _ibadan = new Location("Ibadan", "Nigeria", 7.3117, 3.9026, new Rain(3000));
        }

        [Fact]
        public void SerializeLocation()
        {
            var json = JsonConvert.SerializeObject(_ibadan);
            json.Should().Be("{\"City\":\"Ibadan\",\"Country\":\"Nigeria\",\"Latitude\":7.3117,\"Longitude\":3.9026,\"WaterSource\":{\"$type\":\"TestBoreholes.WaterSources.Rain, TestBoreholes\",\"Rate\":3000.0}}");
        }

        [Fact]
        public void DeserializeLocation()
        {
            var json = "{\"City\":\"Ibadan\",\"Country\":\"Nigeria\",\"Latitude\":7.3117,\"Longitude\":3.9026,\"WaterSource\":{\"$type\":\"TestBoreholes.WaterSources.Rain, TestBoreholes\",\"Rate\":3000.0}}";
            var location = JsonConvert.DeserializeObject<Location>(json);
            location.Should().BeEquivalentTo(_ibadan);
        }
    }
}
