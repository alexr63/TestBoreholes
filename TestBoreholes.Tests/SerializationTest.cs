using FluentAssertions;
using Newtonsoft.Json;
using TestBoreholes.WaterSources;
using TestBoreholes.WaterSources.Boreholes.Statuses;

namespace TestBoreholes.Tests
{
    public class SerializationTest
    {
        private readonly Location _ibadan;

        public SerializationTest()
        {
            _ibadan = new Location("Ibadan", "Nigeria", 7.3117, 3.9026, new Borehole("NG-OY-1353", "FairAction Nigeria",
                new Pumping(300, 400)));
        }

        [Fact]
        public void SerializeLocation()
        {
            var json = JsonConvert.SerializeObject(_ibadan);
            json.Should().Be("{\"City\":\"Ibadan\",\"Country\":\"Nigeria\",\"Latitude\":7.3117,\"Longitude\":3.9026,\"WaterSource\":{\"$type\":\"TestBoreholes.WaterSources.Borehole, TestBoreholes\",\"Id\":\"NG-OY-1353\",\"Owner\":\"FairAction Nigeria\",\"Status\":{\"$type\":\"TestBoreholes.WaterSources.Boreholes.Statuses.Pumping, TestBoreholes\",\"FlowRate\":300.0,\"EstimatedDailyOperationsCost\":{\"amount\":\"400\",\"currency\":\"USD\"}},\"Consumptions\":{},\"Services\":[]}}");
        }

        [Fact]
        public void DeserializeLocation()
        {
            var json = "{\"City\":\"Ibadan\",\"Country\":\"Nigeria\",\"Latitude\":7.3117,\"Longitude\":3.9026,\"WaterSource\":{\"$type\":\"TestBoreholes.WaterSources.Borehole, TestBoreholes\",\"Id\":\"NG-OY-1353\",\"Owner\":\"FairAction Nigeria\",\"Status\":{\"$type\":\"TestBoreholes.WaterSources.Boreholes.Statuses.Pumping, TestBoreholes\",\"FlowRate\":300.0,\"EstimatedDailyOperationsCost\":{\"amount\":\"400\",\"currency\":\"USD\"}},\"Consumptions\":{},\"Services\":[]}}";
            var location = JsonConvert.DeserializeObject<Location>(json);
            location.Should().BeEquivalentTo(_ibadan);
        }
    }
}
