using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBoreholes
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
