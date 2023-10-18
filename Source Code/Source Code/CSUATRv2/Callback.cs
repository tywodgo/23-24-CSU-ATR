using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUATRv2
{
    public class Callback
    {
        public delegate void Method(long id, bool status);
        public Method function { get; set; }
        public long id { get; set; }

        public Callback(Method function, long id)
        {
            this.function = function;
            this.id = id;
        }

        public void Call(bool status = true)
        {
            function(id, status);
        }
    }
}
