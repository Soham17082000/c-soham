using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICE
{
    internal class temprature
    {
        public void temp()
        {
            int num;
            Console.WriteLine("temparature find");
            Console.WriteLine("Enter any number: ");
            num = Convert.ToInt32(Console.ReadLine());
            if (num < 0)
            {
                Console.WriteLine(" Freezing weather");
            }
            else if (num >= 0 && num <= 10)
            {
                Console.WriteLine("Very Cold weather");
            }
            else if (num >= 10 && num <= 20)
            {
                Console.WriteLine("Cold weather");
            }
            else if (num >= 20 && num <= 30)
            {
                Console.WriteLine("Normal in Temp");
            }
            else if (num >= 30 && num <= 40)
            {
                Console.WriteLine("Hot");
            }
            else if (num >= 40)
            {
                Console.WriteLine("Very Hot");
            }



        }
    }
}
