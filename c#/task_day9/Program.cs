using System;
using System.Configuration;

using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Text;
//using Newtonsoft.Json;

namespace task_day9
{

    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsValidEmailAddress(this string value)
        {
            return !string.IsNullOrEmpty(value) && Regex.IsMatch(value, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        public static bool IsValidPhoneNumber(this string value)
        {
            return !string.IsNullOrEmpty(value) && Regex.IsMatch(value, @"^[0-9]{10}$");
        }
        public static bool IsValidGenderInput(this string value)
        {
            return !string.IsNullOrEmpty(value) && (value == "0" || value == "1");
        }
        public static bool IsValidSalary(this double value)
        {
            return value >= 10000 && value <= 50000;
        }
    }

    public class Employee
    {
        private static int nextId = 1;
        private int id;
        private string firstName;
        private string lastName;
        private GenderType gender;
        private string emailAddress;
        private long phoneNumber;
        private string address;


        public Employee()
        {
            address = "N/A";
            this.id = nextId++;
        }


        public int Id
        {
            get { return id; }
        }
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

        public GenderType Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        public long PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }


        public List<Employee> EmployeesList { get; set; }
    }

    public enum GenderType
    {
        Male,
        Female
    }
    internal class Program
    {
        public static string Encrypt(string encryptedphone)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(encryptedphone);
            return Convert.ToBase64String(bytes, Base64FormattingOptions.None);
        }
        public static string Decrypt(string decryptedphone
)
        {
            byte[] bytes = Convert.FromBase64String(decryptedphone);
            return Encoding.UTF8.GetString(bytes);
        }
        static void Main(string[] args)
        {

            List<Employee> employees = new List<Employee>();
            string userInput = "y";
          

            do
            {
                Console.WriteLine("1). Add");
                Console.WriteLine("2)..Display");
                Console.WriteLine("3).Get data from id");
                Console.WriteLine("4).Delete data from id");
                Console.WriteLine("5).xml convert");

                var ch = Convert.ToInt32(Console.ReadLine());
                if (ch == 1)
                {
                    Console.Write("Enter the number of employees: ");
                    int count = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < count; i++)
                    {
                        Employee emp = new Employee();
                        Console.WriteLine($"\nEnter details for Employee: {i}:");

                        Console.WriteLine("Employee ID: {0}", emp.Id);
                        Console.Write("Enter the Firstname: ");
                        string firstNameInput = Console.ReadLine();
                        while (firstNameInput.IsNullOrEmpty())
                        {
                            Console.WriteLine("First Name is required. Please enter again: ");
                            firstNameInput = Console.ReadLine();
                        }
                        emp.FirstName = firstNameInput;
                        Console.Write("Enter the Lastname: ");
                        string lastNameInput = Console.ReadLine();
                        while (lastNameInput.IsNullOrEmpty())
                        {
                            Console.WriteLine("Last Name is required. Please enter again: ");
                            lastNameInput = Console.ReadLine();
                        }
                        emp.LastName = lastNameInput;

                        bool validInput = false;
                        while (!validInput)
                        {
                            Console.Write("Enter the Gender (0 for Male, 1 for Female): ");
                            string input = Console.ReadLine();

                            if (!input.IsValidGenderInput())
                            {
                                Console.WriteLine("Invalid input. Please enter either 0 for male or 1 for female.");
                            }
                            else
                            {
                                if (input == "0")
                                {
                                    emp.Gender = GenderType.Male;
                                    Console.WriteLine("Gender: Male");
                                }
                                else
                                {
                                    emp.Gender = GenderType.Female;
                                    Console.WriteLine("Gender: Female");
                                }
                                validInput = true;
                            }
                        }
                        bool isDuplicateEmail = false;
                        do
                        {
                            Console.Write("Enter the email address: ");
                            string emailInput = Console.ReadLine();
                            while (!emailInput.IsValidEmailAddress())
                            {
                                Console.WriteLine("Email Address is required and must be valid. Please enter again: ");
                                emailInput = Console.ReadLine();
                            }
                            if (employees.Exists(e => e.EmailAddress == emailInput))
                            {
                                Console.WriteLine("Email Address already exists. Please enter a different email address: ");
                                isDuplicateEmail = true;
                            }
                            else
                            {
                                emp.EmailAddress = emailInput;
                                isDuplicateEmail = false;
                            }
                        } while (isDuplicateEmail);

                        Console.Write("Enter the phone number (10 digits): ");
                        string phoneNumberString = Console.ReadLine();
                        while (!phoneNumberString.IsValidPhoneNumber())
                        {
                            Console.WriteLine("Phone Number is invalid. Please enter a 10-digit number.");
                            phoneNumberString = Console.ReadLine();
                        }
                        emp.PhoneNumber = long.Parse(phoneNumberString);

                        //

                        try
                        {
                            string configvalue1 = ConfigurationManager.AppSettings["XmlFilePath"];


                            string encryptedphone = Encrypt(configvalue1);

                            using (StreamWriter sw = File.CreateText(configvalue1))
                            {
                                sw.WriteLine("EncryptedEmail:" + encryptedphone); // write the encrypted email to the file
                            }
                            string decryptedphone = Decrypt(encryptedphone);
                            using (StreamWriter sw = File.AppendText(configvalue1))
                            {
                                sw.WriteLine("DecryptedEmail:" + decryptedphone); // write the decrypted email to the file
                            }
                            using (StreamReader sr = File.OpenText(configvalue1))
                            {
                                string s = "";
                                while ((s = sr.ReadLine()) != null)
                                {
                                    Console.WriteLine(s);
                                }
                                Console.ReadLine();
                            }

                        }
                        catch (Exception Ex)
                        {
                            Console.WriteLine(Ex.ToString());
                        }
                        //





                        Console.Write("Enter the Address (optional): ");
                        string addressInput = Console.ReadLine();
                        if (!addressInput.IsNullOrEmpty())
                        {
                            emp.Address = addressInput;
                        }

                        employees.Add(emp);
                    }
                    Console.Write("admission is done");
                    //string xmlfile = @"D:\c#\dataxml.xml";
                    string xmlFilePath = ConfigurationManager.AppSettings["XmlFilePath"];

                    XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));

                    using (TextWriter writer = new StreamWriter(xmlFilePath))
                    {
                        serializer.Serialize(writer, employees);
                    }

                    Console.WriteLine($"\nData written to {xmlFilePath}");
                }

                else if (ch == 2)
                {
                    Console.WriteLine("\nEmployee details:");
                    foreach (Employee emp in employees)
                    {
                        Console.WriteLine("\nEmployee ID: {0}", emp.Id);
                        Console.WriteLine("\nFirst Name: {0}", emp.FirstName);
                        Console.WriteLine("Last Name: {0}", emp.LastName);
                        Console.WriteLine("Full Name: {0}", emp.FirstName + " " + emp.LastName);
                        Console.WriteLine("Gender: {0}", emp.Gender);
                        Console.WriteLine("Email Address: {0}", emp.EmailAddress);
                        Console.WriteLine("Phone Number: {0}", emp.PhoneNumber);
                        Console.WriteLine("Address: {0}", emp.Address);
                    }
                }
                else if (ch == 3)
                {
                    Console.Write("\nEnter the Student ID to search: ");
                    string studentIdInput = Console.ReadLine();
                    int studentId;
                    while (!int.TryParse(studentIdInput, out studentId))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer value: ");
                        studentIdInput = Console.ReadLine();
                    }

                    Employee emp = employees.Find(e => e.Id == studentId);
                    if (emp != null)
                    {
                        Console.WriteLine("\nStudent details for ID {0}:", studentId);
                        Console.WriteLine("First Name: {0}", emp.FirstName);
                        Console.WriteLine("Last Name: {0}", emp.LastName);
                        Console.WriteLine("Full Name: {0}", emp.FirstName + " " + emp.LastName);
                        Console.WriteLine("Gender: {0}", emp.Gender);
                        Console.WriteLine("Email Address: {0}", emp.EmailAddress);
                        Console.WriteLine("Phone Number: {0}", emp.PhoneNumber);
                        Console.WriteLine("Address: {0}", emp.Address);
                    }
                    else
                    {
                        Console.WriteLine("\nStudent not found for ID {0}.", studentId);
                    }
                }
                else if (ch == 4)
                {
                    Console.Write("\nEnter the Student ID to delete: ");
                    string studentIdInput = Console.ReadLine();
                    int studentId;
                    while (!int.TryParse(studentIdInput, out studentId))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer value: ");
                        studentIdInput = Console.ReadLine();
                    }

                    Employee emp = employees.Find(e => e.Id == studentId);
                    if (emp != null)
                    {
                        employees.Remove(emp);
                        Console.WriteLine("\nEmployee with ID {0} deleted successfully.", studentId);
                    }
                    else
                    {
                        Console.WriteLine("\nEmployee not found for ID {0}.", studentId);
                    }
                }

                Console.WriteLine("Do you want to do something else? Enter y for yes or n for no.");
                userInput = Console.ReadLine();
                Console.ReadKey();
            } while (userInput == "y");
        }

  
    }
}
