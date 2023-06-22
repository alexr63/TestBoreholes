using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBoreholes.WaterSources
{
    public class Well
    {
        public Well(string name, double depth)
        {
            Name = name;
            Depth = depth;
        }

        public string Name { get; init; }
        public double Depth { get; init; }
    }
}
