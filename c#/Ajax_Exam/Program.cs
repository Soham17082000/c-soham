
using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.Text;
using System.Net.Mail;
using Newtonsoft.Json;
using System.Xml;
using Newtonsoft.Json.Converters;

namespace Ajax_Exam
{

    public static class StringExtensions
    {
        public static bool IsNullOrEmptyText(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            return !Regex.IsMatch(value, @"^[a-zA-Z]+$");
        }

        public static bool IsDateFormatted(this string value)
        {
            DateTime date;
            return DateTime.TryParseExact(value, "dd-MMM-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date);
                                                                                                                                                                //set value to date variable
        }

        //public static bool IsValidEmailAddress(this string value)
        //{
        //    return !string.IsNullOrEmpty(value) && Regex.IsMatch(value, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        //}
        public static bool IsValidEmailAddress(this string value)
        {
            return !string.IsNullOrEmpty(value) && Regex.IsMatch(value, @"^([\w\.\-]+)@([\w\-]+)((\.com|\.org|\.in)+)$");
        }

        public static bool IsValidPhoneNumber(this string value)
        {
            return !string.IsNullOrEmpty(value) && Regex.IsMatch(value, @"^[0-9]{10}$");
        }
        public static bool IsValidGenderInput(this string value)
        {
            return !string.IsNullOrEmpty(value) && (value == "M" || value == "F");
        }
        public static bool IsValiddepartmentInput(this string value)
        {
            return !string.IsNullOrEmpty(value) && (value == "0" || value == "1" || value == "2" || value == "3" || value == "4" || value == "5");
        }
        public static bool IsValidSalary(this double value)
        {
            return value >= 10000 && value <= 500000;
        }
        public static bool IsValidPostcode(this string postcode)
        {
            if (string.IsNullOrEmpty(postcode))
            {
                return false;
            }

         if (!Regex.IsMatch(postcode, @"^[a-zA-Z0-9]{10}$"))
          {
               return false;
          }


      
            return true;
        }


    }

    public class Employee
    {

        private static int nextId = 1;
        private int id;
        private string Name;
        private DateTime DOB;
        private GenderType gender;
        private string designation;
        private string city;
        private string state;
        private string postcode;
        private long phone;
        private string email;
        private DateTime dateOfJoining;
        private int totalExperience;
        private string remarks;
        private DepartmentType department;
        private double monthlySalary;


        public Employee()
        {
            this.id = nextId++;
        }

        [JsonProperty("id")]
        public int Id
        {
            get { return id; }
        }
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        public DateTime DateOfBirth
        {
            get { return DOB; }
            set { DOB = value; }
        }
        [JsonConverter(typeof(StringEnumConverter))]
        public GenderType Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public string State
        {
            get { return state; }
            set { state = value; }
        }


        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }

        public long PhoneNumber
        {
            get { return phone; }
            set { phone = value; }
        }
        public string EmailAddress
        {
            get { return email; }
            set { email = value; }
        }
        public DateTime DateOfJoining
        {
            get;set;
        }

        public string TotalExperience
        {
            get;set;
        }
        //public void CalculateExperience()
        //{
            
        //}
        //public void CalculateExperience()
        //{
        //    TimeSpan span = DateTime.Now.Subtract(DateOfJoining);
        //    TotalExperience = (int)span.TotalDays / 30;
        //}
        public void UpdateId(int newIndex)
        {
            id = newIndex + 1;
        }

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        [JsonConverter(typeof(StringEnumConverter))]
        public DepartmentType Department
        {
            get { return department; }
            set { department = value; }
        }

        public double MonthlySalary
        {
            get { return monthlySalary; }
            set { monthlySalary = value; }
        }

    }

    public enum GenderType
    {
        Male,
        Female
    }
    public enum DepartmentType
    {
        Sales,
        Marketing,
        Development,
        QA,
        HR,
        SEO
    }
    internal class Program
    {

        static void Main(string[] args)
        {

            List<Employee> employees = new List<Employee>();
            string userInput = "y";


            do
            {
                Console.WriteLine("1). Add");
                Console.WriteLine("2).Delete data from id");
                Console.WriteLine("3). Exit");



                var ch = Convert.ToInt32(Console.ReadLine());
                if (ch == 1)
                {



                    Employee emp = new Employee();
                    Console.WriteLine($"\nEnter details for Employee:");

                    Console.WriteLine("Employee ID: {0}", emp.Id);
                    Console.Write("Enter the name: ");
                    string NameInput = Console.ReadLine();
                    while (NameInput.IsNullOrEmptyText())
                    {
                        Console.WriteLine("Invalid input. Please enter a valid name (letters only):");
                        NameInput = Console.ReadLine();
                    }
                    emp.name = NameInput;

                    Console.Write("Enter the Date of Birth (dd-MMM-yyyy): ");
                    string dobInput = Console.ReadLine();
                    while (!dobInput.IsDateFormatted())
                    {
                        Console.WriteLine("Invalid date format. Please enter a valid date (dd-MMM-yyyy):");
                        dobInput = Console.ReadLine();
                    }
                    emp.DateOfBirth = DateTime.ParseExact(dobInput, "dd-MMM-yyyy", System.Globalization.CultureInfo.InvariantCulture);


                    bool validInput = false;
                    while (!validInput)
                    {
                        Console.Write("Enter the Gender (M for Male, F for Female): ");
                        string input = Console.ReadLine();

                        if (!input.ToUpper().IsValidGenderInput())

                        {
                            Console.WriteLine("Invalid input. Please enter either M for male or F for female.");
                        }
                        else
                        {
                            if (input == "M" )
                            {
                                emp.Gender = GenderType.Male;
                                Console.WriteLine("Gender: Male");
                            }
                            else if(input=="F")
                            {
                                emp.Gender = GenderType.Female;
                                Console.WriteLine("Gender: Female");
                            }
                            validInput = true;
                        }
                    }

                    Console.Write("Enter the Designation: ");
                    string Designationget = Console.ReadLine();
                    while (Designationget.IsNullOrEmptyText())
                    {
                        Console.WriteLine("Invalid input. Please enter a valid Designation (letters only) ");
                        Designationget = Console.ReadLine();
                    }
                    emp.Designation = Designationget;


                    Console.Write("Enter the City: ");
                    string cityget = Console.ReadLine();
                    while (cityget.IsNullOrEmptyText())
                    {
                        Console.WriteLine("Invalid input. Please enter a valid city (letters only) ");
                        cityget = Console.ReadLine();
                    }

                    emp.City = cityget;

                    Console.Write("Enter the State: ");
                    string stateget = Console.ReadLine();
                    while (stateget.IsNullOrEmptyText())
                    {
                        Console.WriteLine("Invalid input. Please enter a valid city (letters only)");
                        stateget = Console.ReadLine();
                    }
                    emp.State = stateget;

                    Console.Write("Enter the postcode: ");
                    string postcode = Console.ReadLine();
                    while (!postcode.IsValidPostcode())
                    {
                        Console.WriteLine("Invalid input. Please enter a valid postcode (10 digits only): ");
                        postcode = Console.ReadLine();
                    }
                    emp.Postcode = postcode;


                    Console.Write("Enter the phone number (10 digits): ");
                    string phoneNumberString = Console.ReadLine();
                    while (!phoneNumberString.IsValidPhoneNumber())
                    {
                        Console.WriteLine("Phone Number is invalid. Please enter a 10-digit number.");
                        phoneNumberString = Console.ReadLine();
                    }
                    emp.PhoneNumber = long.Parse(phoneNumberString);


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

                    DateTime doj = DateTime.MinValue; // set a default value for DOJ
                    bool isDojValid = false;
                    while (!isDojValid)
                    {
                        Console.Write("Enter the Date of Joining (dd-MMM-yyyy): ");
                        string dojInput = Console.ReadLine();

                        // Validate the date format and parse it into a DateTime object
                        while (!dojInput.IsDateFormatted())
                        {
                            Console.WriteLine("Invalid date format. Please enter a valid date (dd-MMM-yyyy):");
                            dojInput = Console.ReadLine();
                        }

                        doj = DateTime.ParseExact(dojInput, "dd-MMM-yyyy", System.Globalization.CultureInfo.InvariantCulture);

                        // Check if DOJ is valid (i.e., after DOB)
                        if (doj >= emp.DateOfBirth)
                        {
                            isDojValid = true;
                        }
                        else
                        {
                            Console.WriteLine("Date of Joining cannot be before Date of Birth. Please enter a valid date.");
                        }
                    }
                    emp.DateOfJoining = doj;
                    // Calculate the total experience in years and months
                    DateTime today = DateTime.Today;
                    int months = ((today.Year - doj.Year) * 12) + (today.Month - doj.Month);
                    int years = months / 12;
                    months = months % 12;
                    emp.TotalExperience = years + " years and " + months + " months";

                    // Print the total experience in years and months
                    Console.WriteLine("Total Experience: {0} years and {1} months", years, months);


                    Console.Write("Enter the Remarks: ");
                    string remarksget = Console.ReadLine();
                    while (remarksget.IsNullOrEmptyText())
                    {
                        Console.WriteLine("Invalid input. Please enter a valid remarks (letters only) ");
                        remarksget = Console.ReadLine();
                    }
                    emp.Remarks = remarksget;

                    bool validInputs = false;
                    while (!validInputs)
                    {
                        Console.Write("Enter the Department (0 for Sales, 1 for Marketing, 2 for Development, 3 for QA, 4 for HR, 5 for SEO): ");
                        string inputs = Console.ReadLine();

                        if (!inputs.IsValiddepartmentInput())
                        {
                            Console.WriteLine("Invalid input. Please enter between 0 to 5.");
                        }
                        else
                        {
                            if (inputs == "0")
                            {
                                emp.Department = DepartmentType.Sales;
                                Console.WriteLine("DepartmentType: Sales");
                            }
                            else if (inputs == "1")
                            {
                                emp.Department = DepartmentType.Marketing;
                                Console.WriteLine("DepartmentType: Marketing");
                            }
                            else if (inputs == "2")
                            {
                                emp.Department = DepartmentType.Development;
                                Console.WriteLine("DepartmentType: Development");
                            }
                            else if (inputs == "3")
                            {
                                emp.Department = DepartmentType.QA;
                                Console.WriteLine("DepartmentType: QA");
                            }
                            else if (inputs == "4")
                            {
                                emp.Department = DepartmentType.HR;
                                Console.WriteLine("DepartmentType: HR");
                            }
                            else if (inputs == "5")
                            {
                                emp.Department = DepartmentType.SEO;
                                Console.WriteLine("DepartmentType: SEO");
                            }
                            validInputs = true;
                        }
                    }

                    double monthlySalary = 0;
                    bool validSalary = false;

                    while (!validSalary)
                    {
                        Console.Write("Enter the salary (Min 10,000 & Max 5,00,000): ");
                        string input = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(input))
                        {
                            Console.WriteLine("Salary cannot be empty. Please enter a value between 10,000 and 50,000.");
                        }
                        else
                        {
                            monthlySalary = Convert.ToDouble(input);

                            if (!monthlySalary.IsValidSalary())
                            {
                                Console.WriteLine("Invalid salary! Please enter a value between 10,000 and 5,00,000.");
                            }
                            else
                            {
                                validSalary = true;
                            }
                        }
                    }
                    emp.MonthlySalary = monthlySalary;


                    bool employeeExists = employees.Any(e => e.name == emp.name && e.DateOfBirth == emp.DateOfBirth && e.Gender == emp.Gender && e.Designation == emp.Designation && e.City == emp.City && e.State == emp.State && e.Postcode == emp.Postcode && e.PhoneNumber == emp.PhoneNumber && e.EmailAddress == emp.EmailAddress && emp.DateOfJoining == emp.DateOfJoining && e.Remarks == emp.Remarks && e.Department == emp.Department && e.MonthlySalary == emp.MonthlySalary);
                    if (employeeExists)
                    {
                        Console.WriteLine("Employee already exists. Duplicate data not allowed.");
                    }

                    else
                    {
                        employees.Add(emp);
                        string jsonfile = ConfigurationManager.AppSettings["JsonFilePath"];
                        string todayDate = DateTime.Today.ToString("ddMMyyyy");
                        jsonfile = jsonfile.Replace("$(TodayDate)", todayDate);

                        if (File.Exists(jsonfile))
                        {
                            string existingJsonData = File.ReadAllText(jsonfile);
                            List<Employee> existingEmployees = JsonConvert.DeserializeObject<List<Employee>>(existingJsonData);


                        
                            if (!existingEmployees.Any(e => e.name == emp.name && e.DateOfBirth == emp.DateOfBirth && e.Gender == emp.Gender && e.Designation == emp.Designation && e.City == emp.City && e.State == emp.State && e.Postcode == emp.Postcode && e.PhoneNumber == emp.PhoneNumber && e.EmailAddress == emp.EmailAddress && emp.DateOfJoining == emp.DateOfJoining && e.Remarks == emp.Remarks && e.Department == emp.Department && e.MonthlySalary == emp.MonthlySalary))
                            {
                                employees.AddRange(existingEmployees);
                            }
                        }

                        employees = employees.OrderByDescending(e => e.MonthlySalary).ToList();

                    

                        string jsonString = JsonConvert.SerializeObject(employees, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings
                        {
                            Converters = { new IsoDateTimeConverter { DateTimeFormat = "dd-MMM-yyyy" } }
                        }); // serialize the updated employee list
                        File.WriteAllText(jsonfile, jsonString); // write the updated JSON data to the file
                        Console.WriteLine("All data saved in json file");

                    }

                }
                else if (ch == 2)
                {
                    // Load existing data from JSON file
                    string jsonfile = ConfigurationManager.AppSettings["JsonFilePath"];
                    string todayDate = DateTime.Today.ToString("ddMMyyyy");
                    jsonfile = jsonfile.Replace("$(TodayDate)", todayDate);

                    if (File.Exists(jsonfile))
                    {
                        string existingJsonData = File.ReadAllText(jsonfile);
                        employees = JsonConvert.DeserializeObject<List<Employee>>(existingJsonData);
                    }
                    else
                    {
                        Console.WriteLine("No employee data found.");
                        return;
                    }

                    Console.Write("\nEnter the Employee ID to delete: ");
                    string employeeIdInput = Console.ReadLine();
                    int employeeId;
                    while (!int.TryParse(employeeIdInput, out employeeId))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer value: ");
                        employeeIdInput = Console.ReadLine();
                    }

                    Employee empToDelete = employees.Find(e => e.Id == employeeId);
                    if (empToDelete != null)
                    {
                        employees.Remove(empToDelete);
                        Console.WriteLine("\nEmployee with ID {0} deleted successfully.", employeeId);



                        // Serialize the updated employee list and write to the JSON file
                        string jsonString = JsonConvert.SerializeObject(employees, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings
                        {
                            Converters = { new IsoDateTimeConverter { DateTimeFormat = "dd-MMM-yyyy" } }
                        });
                        File.WriteAllText(jsonfile, jsonString);

                        Console.WriteLine("All data saved in json file");
                    }
                    else
                    {
                        Console.WriteLine("\nEmployee not found for ID {0}.", employeeId);
                    }
                }
                else if (ch == 3)
                {
                    break;
                }

                Console.WriteLine("Do you want to do something else? Enter y for yes or n for no.");
                userInput = Console.ReadLine();
                Console.ReadKey();
            } while (userInput == "y");
        }
    }
} 