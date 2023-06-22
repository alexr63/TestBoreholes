namespace TestBoreholes.WaterSources
{
    public class Spring
    {
        public Spring(string name, double flowRate)
        {
            Name = name;
            FlowRate = flowRate;
        }

        public string Name { get; init; }
        public double FlowRate { get; init; }
    }
}
