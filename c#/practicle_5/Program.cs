
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace practicle_5
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public City City { get; set; }
        public Person()
        {
        }
        public Person(string name, int age, City city)
        {
            Name = name;
            Age = age;
            City = city;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, {City.ToString()}";
        }
    }

    public class City
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public City()
        {
            // default constructor needed for XmlSerializer
        }

        public City(string name, int population)
        {
            Name = name;
            Population = population;
        }

        public override string ToString()
        {
            return $"City name: {Name}, Population: {Population}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the person's name: ");
            string name = Console.ReadLine();
            Console.Write("Enter the person's age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter the city's name: ");
            string cityName = Console.ReadLine();
            Console.Write("Enter the city's population: ");
            int cityPopulation = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            City city = new City(cityName, cityPopulation);
            Person person = new Person(name, age, city);
            Console.WriteLine(person.ToString());

            string jsonfile = @"D:\c#\practicle_5\data.json";
            string jsonString = JsonConvert.SerializeObject(person);
            File.WriteAllText(jsonfile, jsonString);
            
            // deserialize from JSON and write to XML file
            string xmlfile = @"D:\c#\practicle_5\dataxml.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            using (StreamWriter writer = new StreamWriter(xmlfile))
            {
                serializer.Serialize(writer, person);
            }

            // deserialize from XML and read back to object
            using (StreamReader reader = new StreamReader(xmlfile))
            {
                Person personObj = (Person)serializer.Deserialize(reader);
                Console.WriteLine("personname:" + personObj.Name);
                Console.WriteLine("personage:" + personObj.Age);
                Console.WriteLine(personObj.City);
            }

            Console.ReadLine();
        }
    }
}