using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vehiclerenting
{

    public class customer
    {
        private string name;
        private string address;
        private string phoneno;


        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Phoneno
        {
            get { return phoneno; }
            set { phoneno = value; }
        }
    }
    public class driver : customer
    {
        public driver(string name, string address, string phoneno)
        {
            Name = name;
            Address = address;
            Phoneno = phoneno;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            driver Driver = new driver("John Doe", "123 Main St", "555-555-5555");

            Console.WriteLine("Customer name: " + Driver.Name);
            Console.WriteLine("Customer address: " + Driver.Address);
            Console.WriteLine("Customer phone number: " + Driver.Phoneno);
        }
    }

}
