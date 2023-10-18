using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUATRv2
{
    public class Function
    {
        public delegate void Method(object[] args, Callback callback);
        public Method function;
        public object[] args;
        public Callback callback;

        public Function(Method function, object[] args)
        {
            this.function = function;
            if (args != null) { this.args = args; }
            else { args = new object[] { }; }
            
        }
        public void AddCallback(Callback callback)
        {
            this.callback = callback;
        }
        public void Call()
        {
            if (callback != null)
            {
                function(args, callback);
            }
            else { Console.WriteLine("Callback function not defined"); }
        }
    }
}
