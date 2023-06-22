namespace TestBoreholes.WaterSources
{
    public class River
    {
        public River(string name, double flowRate)
        {
            Name = name;
            FlowRate = flowRate;
        }

        public string Name { get; init; }
        public double FlowRate { get; init; }
    }
}
