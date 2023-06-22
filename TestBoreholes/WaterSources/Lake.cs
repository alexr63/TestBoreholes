using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
