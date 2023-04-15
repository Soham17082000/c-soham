
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace task_8
{
    internal class Program
    {

        class Employee
        {
            //private int id;
            private string firstName;
                        private string lastName;
                        private string gender;
                        private string emailAddress;
                        private int phoneNumber;
            private DesignationType designation;
            private double salary;
            //public int Id
            //{
            //    get { return id; }
            //    set { id = value; }
            //}
            public string FirstName
            {
                get { return firstName; }
                set { firstName = value; }
            }

            public string LastName
            {
                get { return lastName; }
                set { lastName = value; }
            }

            public string Gender
            {
                get { return gender; }
                set { gender = value; }
            }

            public string EmailAddress
            {
                get { return emailAddress; }
                set { emailAddress = value; }
            }

            public int PhoneNumber
            {
                get { return phoneNumber; }
                set { phoneNumber = value; }
            }

            public DesignationType Designation
            {
                get { return designation; }
                set { designation = value; }
            }
           

            public double Salary
            {
                get { return salary; }
                set { salary = value; }
            }
         
        }
        enum DesignationType
        {
            QA,
            Developer
        }

        static void Main(string[] args)
        {

            List<Employee> employees = new List<Employee>();
            string userInput = "y";


            do
            {
                Console.WriteLine("1). Add");
                Console.WriteLine("2)..Display");
                Console.WriteLine("3)..jsonconvert");

                var ch = Convert.ToInt32(Console.ReadLine());
                if (ch == 1)
                {
                    Console.Write("Enter the number of employees: ");
                    int count = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < count; i++)
                    {
                        Employee emp = new Employee();

                        //emp.Id = employees.Count + 1;

                        //Console.WriteLine($"\nEnter details for Employee {emp.Id}:");
                 

                        Console.Write("Enter the Firstname: ");
                        string firstNameInput = Console.ReadLine();
                        while (string.IsNullOrEmpty(firstNameInput))
                        {
                            Console.WriteLine("First Name is required. Please enter again: ");
                            firstNameInput = Console.ReadLine();
                        }
                        emp.FirstName = firstNameInput;


                        Console.Write("Enter the Lastname: ");
                        string lastNameInput = Console.ReadLine();
                        while (string.IsNullOrEmpty(lastNameInput))
                        {
                            Console.WriteLine("last Name is required. Please enter again: ");
                            lastNameInput = Console.ReadLine();
                        }
                        emp.LastName = lastNameInput;

                        Console.Write("Enter the gender: ");
                        string gender = Console.ReadLine();
                        while (string.IsNullOrEmpty(gender) || (gender.ToLower() != "male" && gender.ToLower() != "female" && gender.ToLower() != "other"))
                        {
                            if (string.IsNullOrEmpty(gender))
                            {
                                Console.WriteLine("Gender is required. Please enter again: ");
                            }
                            else
                            {
                                Console.WriteLine("Gender is invalid. Please enter again: ");
                            }
                            gender = Console.ReadLine();
                        }
                        emp.Gender = gender;

                        Console.Write("Enter the email address: ");
                        string emailInput = Console.ReadLine();
                        while (string.IsNullOrEmpty(emailInput) || !Regex.IsMatch(emailInput, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                        {
                            Console.WriteLine("Email Address is required and must be valid. Please enter again: ");
                            emailInput = Console.ReadLine();
                        }
                        emp.EmailAddress = emailInput;


                        int phoneNumber = 0;
                        bool validPhoneNumber = false;
                        while (!validPhoneNumber)
                        {
                            Console.Write("Enter the phone number (10 digits): ");
                            string phoneNumberString = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(phoneNumberString) || !int.TryParse(phoneNumberString, out phoneNumber))
                            {
                                Console.WriteLine("Invalid phone number! Please enter a 10-digit number.");
                            }
                            else if (phoneNumber.ToString().Length != 10)
                            {
                                Console.WriteLine("Invalid phone number! Please enter a 10-digit number.");
                            }
                            else
                            {
                                validPhoneNumber = true;
                            }
                        }
                        emp.PhoneNumber = phoneNumber;



                        //Console.Write("Enter the Designation (0 for QA, 1 for Developer): ");
                        //int designationInput = Convert.ToInt32(Console.ReadLine());
                        //if (designationInput == 0)
                        //{
                        //    emp.Designation = DesignationType.QA;
                        //    Console.WriteLine("Designation: QA");
                        //}
                        //else if (designationInput == 1)
                        //{
                        //    emp.Designation = DesignationType.Developer;
                        //    Console.WriteLine("Designation: Developer");
                        //}

                        bool validInput = false;
                        while (!validInput)
                        {
                            Console.Write("Enter the Designation (0 for QA, 1 for Developer): ");
                            string input = Console.ReadLine();

                            if (string.IsNullOrEmpty(input))
                            {
                                Console.WriteLine("Designation input cannot be null or empty. Please try again.");
                            }
                            else if (!int.TryParse(input, out int designationInput))
                            {
                                Console.WriteLine("Invalid input. Please enter a numeric value.");
                            }
                            else if (designationInput != 0 && designationInput != 1)
                            {
                                Console.WriteLine("Invalid input. Please enter either 0 for QA or 1 for Developer.");
                            }
                            else
                            {
                                if (designationInput == 0)
                                {
                                    emp.Designation = DesignationType.QA;
                                    Console.WriteLine("Designation: QA");
                                }
                                else
                                {
                                    emp.Designation = DesignationType.Developer;
                                    Console.WriteLine("Designation: Developer");
                                }
                                validInput = true;
                            }
                        }








                        double salary = 0;
                        bool validSalary = false;

                        while (!validSalary)
                        {
                            Console.Write("Enter the salary (Min 10,000 & Max 50,000): ");
                            string input = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(input))
                            {
                                Console.WriteLine("Salary cannot be empty. Please enter a value between 10,000 and 50,000.");
                            }
                            else
                            {
                                salary = Convert.ToDouble(input);

                                if (salary < 10000 || salary > 50000)
                                {
                                    Console.WriteLine("Invalid salary! Please enter a value between 10,000 and 50,000.");
                                }
                                else
                                {
                                    validSalary = true;
                                }
                            }
                        }

                        emp.Salary = salary;



                        employees.Add(emp);
                    }
                

                }

                else if (ch == 2)
                {
                    Console.WriteLine("\nEmployee details:");

                    foreach (Employee emp in employees)
                    {
                        //Console.WriteLine("\nID: {0}", emp.Id);
                        Console.WriteLine("\nFirst Name: {0}", emp.FirstName);
                        Console.WriteLine("Last Name: {0}", emp.LastName);
                        Console.WriteLine("Gender: {0}", emp.Gender);
                        Console.WriteLine("Email Address: {0}", emp.EmailAddress);
                        Console.WriteLine("Phone Number: {0}", emp.PhoneNumber);
                        Console.WriteLine("Designation: {0}", emp.Designation);
                        Console.WriteLine("Salary: {0}", emp.Salary);
                    }
                }

              else  if (ch == 3)
                {
                    string jsonfile = @"D:\c#\task_8\data.json";
                    string json = JsonConvert.SerializeObject(employees);
                    //File.WriteAllText(jsonfile, json);
                    File.AppendAllText(jsonfile, json);
                    Console.WriteLine($"\nData written to {jsonfile}");
                }
               
                Console.WriteLine("Do you want to do something else? Enter y for yes or n for no.");
                userInput = Console.ReadLine();
                Console.ReadKey();
            } while (userInput == "y");
        }
    }
}
