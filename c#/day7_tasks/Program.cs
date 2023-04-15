using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace day7_tasks
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("1).create a new list from a given list of integers where each integer value is added to 2 and the result value is multiplied by 5");
                Console.WriteLine("2).If you have a large set of numbers that are used as references, it can be useful to group them into a series of smaller ranges,  This approach is commonly seen each containing the adjacent numbers. in document indexes. It is also used in document editing software when specifying that you wish to print a specific set of pages.");
                Console.WriteLine("3). Write C# program for admission of students in college. After admission is done, print a simple message and total number of students. Now some of the students are leaving college due to  some reason so remove them from college. Some of the students are getting awards for best students so print them as well.");

                Console.Write("Enter number:");
                int tasks = Convert.ToInt32(Console.ReadLine());
                switch (tasks)
                {
                    case 1:
                        Console.Write("Enter the number of integers you want to insert into the list: ");
                        int count = Convert.ToInt32(Console.ReadLine());

                        List<int> mylist = new List<int>();
                        for (int i = 0; i < count; i++)
                        {
                            Console.Write("Enter an integer: ");
                            int num = Convert.ToInt32(Console.ReadLine());
                            mylist.Add(num);
                        }

                        List<int> result = mylist.Select(x => 5 * (x + 2)).ToList();
                        //.ToList() converts values to  new List<int>.
                        foreach (var i in result)
                        {
                            Console.WriteLine(i + " ");
                        }
                        break;

                    case 2:
                        Console.Write("Enter the number of integers you want to insert into the list: ");
                        int counts = Convert.ToInt32(Console.ReadLine());

                        List<int> numbers = new List<int>();
                        for (int i = 0; i < counts; i++)
                        {
                            Console.Write("Enter an integer: ");
                            int num = Convert.ToInt32(Console.ReadLine());
                            numbers.Add(num);
                        }

                        numbers.Sort(); // sort the list of numbers

                        List<string> ranges = new List<string>();

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            // set the starting value of the range to that number, and the ending value to the same number
                            int start = numbers[i];
                            int end = start;

                            // next number in the list is the current end value + 1
                            while (i < numbers.Count - 1 && numbers[i + 1] == end + 1)
                            {
                                end = numbers[i + 1];
                                i++;
                            }

                            if (start == end)
                            {
                                ranges.Add(start.ToString());
                            }
                            else
                            {
                                ranges.Add(start + "-" + end);
                            }
                        }
                        Console.WriteLine("Ranges: " + string.Join(", ", ranges));


                        break;

                    case 3:


                        Dictionary<int, string> myDictionary = new Dictionary<int, string>();
                        string userInput = "y";
                        int lastKey = 0;

                        do
                        {
                            Console.WriteLine("1). Add");
                            Console.WriteLine("2)..Delete");
                            Console.WriteLine("3)..Display");
                            var ch = Convert.ToInt32(Console.ReadLine());

                            if (ch == 1)
                            {
                                Console.WriteLine("Welcome to my College!");
                                Console.Write("Enter the number of students whose admission is done: ");
                                int numStudents = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine($"Admission is confirmed for {numStudents} students.");

                                for (int i = 0; i < numStudents; i++)
                                {
                                    Console.Write($"Enter the name of student {i + 1}: ");
                                    string name = Convert.ToString(Console.ReadLine());
                                    Console.Write($"Enter the marks of student {i + 1}: ");
                                    int marks = Convert.ToInt32(Console.ReadLine());

                                    myDictionary.Add(lastKey, $"{name} ({marks})");
                                    lastKey++;
                                }

                                Console.WriteLine("The following students have been admitted:");
                            }
                            else if (ch == 2)
                            {
                                Console.Write("Enter the number of students to remove: ");
                                int numToRemove = Convert.ToInt32(Console.ReadLine());
                                List<int> idsToRemove = new List<int>();

                                for (int i = 0; i < numToRemove; i++)
                                {
                                    Console.Write($"Enter the ID of student {i + 1}: ");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    idsToRemove.Add(id);
                                }

                                foreach (int id in idsToRemove)
                                {
                                    if (myDictionary.ContainsKey(id))
                                    {
                                        myDictionary.Remove(id);
                                        Console.WriteLine($"Student {id} has been removed from the college.");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Student {id} was not found in the college.");
                                    }
                                }
                            }
                            else if (ch == 3)
                            {
                                Console.WriteLine("Updated list of admitted students:");

                                foreach (KeyValuePair<int, string> kvp in myDictionary)
                                {
                                    Console.WriteLine($"ID: {kvp.Key}, Name: {kvp.Value}");
                                }
                            }

                            Console.WriteLine("Do you want to do something else? Enter y for yes or n for no.");
                            userInput = Console.ReadLine();
                        } while (userInput == "y");

                        break;

                }
            } while (true);
        }
    }
}


