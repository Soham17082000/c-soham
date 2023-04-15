using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICE
{
    internal class calculator
    {
        public void calculate()
        {
            Console.Write("\ncalculator");
            Console.Write("\nEnter first number:");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter second number:");
            double num2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter symbol(/,+,-,*):");
            string symbol = Console.ReadLine();
            double res;
            switch (symbol)
            {
                case "+":
                    res = num1 + num2;
                    Console.WriteLine("Addition:" + res);
                    break;
                case "-":
                    res = num1 - num2;
                    Console.WriteLine("Subtraction:" + res);
                    break;
                case "*":
                    res = num1 * num2;
                    Console.WriteLine("Multiplication:" + res);
                    break;
                case "/":
                    res = num1 / num2;
                    Console.WriteLine("Division:" + res);
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    break;
            }
            Console.ReadLine();
        }

    }
}
