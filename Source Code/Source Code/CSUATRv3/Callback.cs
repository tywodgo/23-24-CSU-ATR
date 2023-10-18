using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUATRv3
{
    public class Callback
    {
        public delegate void Method(long id, bool status);
        private Method function;
        private long id;

        public Callback(Method function, long id)
        {
            this.function = function;
            this.id = id;
        }

        public void Call(bool status)
        {
            function(id, status);
        }
    }
}
