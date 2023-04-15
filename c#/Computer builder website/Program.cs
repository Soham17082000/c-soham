using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_builder_website
{
    class Hardware
    {
        public string Processor { get; set; }
        public int Memory { get; set; }
     
    }

    class Software
    {
        public string OS { get; set; }
        public string Antivirus { get; set; }
      
    }

    class Computer
    {
        public Hardware Hardware { get; set; }
        public Software Software { get; set; }

        public Computer(Hardware hardware, Software software)
        {
            Hardware = hardware;
            Software = software;
        }

        public void Print()
        {
            Console.WriteLine("Computer Hardware:");
            Console.WriteLine($"Processor: {Hardware.Processor}");
            Console.WriteLine($"Memory: {Hardware.Memory}");
           

            Console.WriteLine("Computer Software:");
            Console.WriteLine($"OS: {Software.OS}");
            Console.WriteLine($"Antivirus: {Software.Antivirus}");
    
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
           
            Hardware hardware = new Hardware { Processor = "Intel Core i7", Memory = 16 };
            Software software = new Software { OS = "Windows 10", Antivirus = "Norton" };

       
            Computer computer = new Computer(hardware, software);

     
            computer.Print();
        }
    }
}

