using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace office_management_system
{
    public abstract class Employee
    {
        private string name;
        private string phoneno;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Phoneno
        {
            get { return phoneno; }
            set { phoneno = value; }
        }
        public abstract void leaves();
    }

    public class HR : Employee
    {
        public override void leaves()
        {
            Console.WriteLine("HR " + Name + " has 10 leaves remaining");
        }
        public void performTask(string task)
        {
            Console.WriteLine($"{Name} is performing {task} task");
        }
    }

    public class Developer : Employee
    {
        public override void leaves()
        {
            Console.WriteLine("Developer " + Name + " has 12 leaves remaining");
        }
        public void performTask(string task, int hours)
        {
            Console.WriteLine($"{Name} is performing {task} task for {hours} hours");
        }
    }

    public class QA : Employee
    {
        public override void leaves()
        {
            Console.WriteLine("QA " + Name + " has 8 leaves remaining");
        }
        public void performTask(string task, int hours)
        {
            Console.WriteLine($"{Name} is performing {task} task for {hours} hours");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
      
            HR hr = new HR();
            hr.Name = "abc";
            hr.Phoneno = "1234567890";
           



            Developer dev = new Developer();
            dev.Name = "sdf";
            dev.Phoneno = "9876543210";
          


            QA qa = new QA();
            qa.Name = "opq";
            qa.Phoneno = "5555555555";
          



            Console.WriteLine("HR Name: " + hr.Name);
            Console.WriteLine("HR Phoneno: " + hr.Phoneno);
            hr.leaves();
            hr.performTask("recruiting");

            Console.WriteLine("Developer Name: " + dev.Name);
            Console.WriteLine("Developer Phoneno: " + dev.Phoneno);
            dev.leaves();
            dev.performTask("coding", 8);

            Console.WriteLine("QA Name: " + qa.Name);
            Console.WriteLine("QA Phoneno: " + qa.Phoneno);
            qa.leaves();
            qa.performTask("testing", 4);
        }
    }
}
