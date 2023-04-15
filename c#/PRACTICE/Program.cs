using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICE
{
    internal class Program
    {
  
        static void Main(string[] args)
        {
         

            numbercheck al = new numbercheck();
            al.number();

            weekdayshow day = new weekdayshow();
            day.weekdays();

            calculator maths = new calculator();
            maths.calculate();

            maxmin find = new maxmin();
            find.Maxmin();

            temprature t = new temprature();
            t.temp();
        }
    }
}