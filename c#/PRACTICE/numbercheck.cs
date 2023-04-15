using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICE
{
    internal class numbercheck
    {
        public double number()
        {
            double num;
            Console.WriteLine("\n----------  number check positive,negative and zero-----------------");
            Console.Write("\nEnter any number: ");
            num = Convert.ToDouble(Console.ReadLine());

            if (num > 0)
            {
                Console.WriteLine("number is positive ");
            }
            else if (num < 0)
            {
                Console.WriteLine("number is negative ");
            }
            else
            {
                Console.WriteLine("number is zero ");
            }

            Console.ReadLine();
            return num;
        }
    }
}

