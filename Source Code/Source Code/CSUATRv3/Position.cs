using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUATRv3
{
    public class Position
    {
        public double horizontal { get; set; } = 0;
        public double vertical { get; set; } = 0;
        public double depth { get; set; } = 0;
        public double azimuth { get; set; } = 0;
        public double elevation { get; set; } = 0;
        public double polarization { get; set; } = 0;
    }
}
