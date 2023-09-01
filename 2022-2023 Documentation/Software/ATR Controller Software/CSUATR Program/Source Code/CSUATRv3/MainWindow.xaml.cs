using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSUATRv3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Function> events;

        public MainWindow()
        {
            InitializeComponent();

            events = new List<Function>();

            object[] args = { "hello" };
            Function function = new Function(Method, args);
            events.Add(function);
            events.Add(new Function(Method, new object[]{ "Hi" }));

            CallFunctions();
        }
        public void CallFunctions()
        {
            long id = 0;
            foreach(Function function in events)
            {
                id++;
                function.AddCallback(new Callback(Return, id));
                function.Call();
            }
        }


        public void Return(long i)
        {
            Console.WriteLine(string.Format("Callback: {0}", i));
        }

        public void Method(object[] args, Callback callback)
        {
            string param = args[0].ToString();
            Console.WriteLine(string.Format("Method: {0}", param)); // Do something
            callback.Call();
        }


    }
}
