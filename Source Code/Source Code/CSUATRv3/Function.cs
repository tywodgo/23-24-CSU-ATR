using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUATRv3
{
    public class Function
    {
        public delegate void Method(object[] args, Callback callback);
        private Method function;
        private object[] args;
        private Callback callback;

        public Function(Method function, object[] args)
        {
            this.function = function;
            this.args = args;
        }
        public void AddCallback(Callback callback)
        {
            this.callback = callback;
        }
        public void Call()
        {
            if (callback != null) { function(args, callback); }
            else { Console.WriteLine("Callback function not defined"); }
        }
    }
}
