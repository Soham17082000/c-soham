using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{

    internal class Program
    {
      
        static void Main(string[] args)
        {
            Console.Write("Enter the Amount Invested: ");
            double invested = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the Amount Returned: ");
            double returned = Convert.ToDouble(Console.ReadLine());

         
            Console.WriteLine("enter dates or length : ");
            string getdata = Convert.ToString(Console.ReadLine());
            if (getdata == "length")
            {
                Console.WriteLine("Enter Years : ");
                double year = Convert.ToDouble(Console.ReadLine());

                var ROI = ((returned - invested) / invested) * 100;
                Console.WriteLine("ROI : " + ROI);

                var difference = returned - invested;
                if (difference > 0)
                {
                    Console.WriteLine("Investment Gain : " + difference);
                }
                else if (difference < 0)
                {
                    Console.WriteLine("Investment Loss : " + (difference));
                }
                Console.WriteLine("Investment Length : "+year);
            }

            else if (getdata == "dates")
            {
                Console.WriteLine("Enter from date (yyyy-mm-dd): ");
                DateTime fromDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter to date (yyyy-mm-dd): ");
                DateTime toDate = Convert.ToDateTime(Console.ReadLine());
                TimeSpan timeSpan = toDate - fromDate;
                double years = timeSpan.TotalDays / 365;
                Console.WriteLine("Investment Length : " + years+" years");
                var ROI = ((returned - invested) / invested) * 100;
                Console.WriteLine("ROI : " + ROI);
                var difference = returned - invested;
                if (difference > 0)
                {
                    Console.WriteLine("Investment Gain : " + difference);
                }
                else if (difference < 0)
                {
                    Console.WriteLine("Investment Loss : " + (difference));
                }
            }
            Console.ReadLine();
        }
    }
}
