    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace PRACTICE
    {
        internal class maxmin
        {
        public void Maxmin()
        {
            Console.WriteLine("Find maximum and minimum of two numbers");
            Console.Write("Enter first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter 'max' or 'min': ");
            string input = Console.ReadLine();

            if (input == "max")
            {
                double max = num1 > num2 ? num1 : num2;
                Console.WriteLine("Maximum is: " + max);
            }
            else if (input == "min")
            {
                double min = num1 < num2 ? num1 : num2;
                Console.WriteLine("Minimum is: " + min);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'max' or 'min'.");
            }

            Console.ReadLine();
        }
    }
}


