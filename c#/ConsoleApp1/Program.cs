using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 100 + 50;
            Console.WriteLine(x);
            int value1 = 5;
            int value2 = 3;
            Console.WriteLine(value1 > value2);
            Console.WriteLine(Math.Max(5, 10));
            string txt = "soham";
            Console.WriteLine(txt.ToUpper());
            MyMethod("Liam");
        }
        static void MyMethod(string fname)
        {
            Console.WriteLine(fname + " Refsnes");
        }

    }
}
