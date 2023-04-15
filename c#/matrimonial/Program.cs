using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace matrimonial
{
    interface IPerson
    {
        string Name { get; set; }
        string City { get; set; }
        int Age { get; set; }
    }

    class Boy : IPerson
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int Age { get; set; }

        public Boy(string name, string city, int age)
        {
            Name = name;
            City = city;
            Age = age;
        }

        public void PrintDetails()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("City: " + City);
            Console.WriteLine("Age: " + Age);
        }
    }

    class Girl : IPerson
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int Age { get; set; }

        public Girl(string name, string city, int age)
        {
            Name = name;
            City = city;
            Age = age;
        }

        public void PrintDetails()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("City: " + City);
            Console.WriteLine("Age: " + Age);
        }

    }

    class Match
    {
        public static void MatchAge(IPerson person1, IPerson person2)
        {
            if (person1.Age == person2.Age)
            {
                Console.WriteLine("This is perfect!");
            }
            else
            {
                Console.WriteLine("Sorry, age doesn't match!");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Boy boy = new Boy("abc", "New York", 25);
            Girl girl = new Girl("xyz", "Los Angeles", 25);

            Match.MatchAge(boy, girl);
        }
    }

}
