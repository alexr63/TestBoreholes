using FluentAssertions;
using TestBoreholes.WaterSources;
using TestBoreholes.WaterSources.Boreholes;
using TestBoreholes.WaterSources.Boreholes.Statuses;

namespace TestBoreholes.Tests
{
    public class ConsumptionTest
    {
        private readonly Location _ibadan;

        public ConsumptionTest()
        {
            _ibadan = new Location("Ibadan", "Nigeria", 7.3117, 3.9026, new Rain(3000));
        }

        [Fact]
        public void ConsumptionTimeZoneShouldBeInTargetFormat()
        {
            // change the water source to a borehole
            _ibadan.WaterSource = new Borehole("NG-OY-1353", "FairAction Nigeria", new Pumping(100, 100));
            var ibadanBorehole = (Borehole)_ibadan.WaterSource;
            var timeZoneInfo = _ibadan.GetTimeZoneInfo();

            // add a consumption
            ibadanBorehole.AddConsumption(new Consumption(new DateTimeOffset(2021, 1, 1, 10, 30, 0, timeZoneInfo.BaseUtcOffset), 100));

            // display the consumption using the time zone of the target country
            const string targetTimeZoneId = "FLE Standard Time";

            // get the time zone info
            var targetTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(targetTimeZoneId);

            // get the time zone offset
            var targetTimeZoneOffset = targetTimeZoneInfo.GetUtcOffset(DateTime.UtcNow);

            // display the consumption
            var consumption = ibadanBorehole.Consumptions.First();
            var dateTimeOffset = consumption.Key;
            var dateTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dateTimeOffset, targetTimeZoneId);

            dateTime.Should().Be(new DateTimeOffset(2021, 1, 1, 12, 30, 0, targetTimeZoneOffset));
        }


    }
}
