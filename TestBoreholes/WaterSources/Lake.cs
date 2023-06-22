namespace TestBoreholes.WaterSources
{
    public class Lake
    {
        public Lake(string name, double area)
        {
            Name = name;
            Area = area;
        }

        public string Name { get; init; }
        public double Area { get; init; }
    }
}
