using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUATRv2
{
    public class Measurement
    {
        // TODO: make exception for dealing with this data when it is still null
        public double[] frequency { get; set; } = null;
        public double[] real { get; set; } = null;
        public double[] imaginary { get; set; } = null;
    }
}
