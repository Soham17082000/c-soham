using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fileexample
{

    public static class DateTimeExtensions
    {
        public static string DateFormat(this DateTime date, string format)
        {
            return date.ToString(format);
        }
    }
    internal class Program
    {
        public static string Encrypt(string email)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(email);
            return Convert.ToBase64String(bytes, Base64FormattingOptions.None);
        }
        public static string Decrypt(string encryptedEmail)
        {
            byte[] bytes = Convert.FromBase64String(encryptedEmail);
            return Encoding.UTF8.GetString(bytes);
        }

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("1).Write a program in C# Sharp to create a file and add some text.");
                Console.WriteLine("2).Write a program in C# Sharp to create a file with text and read the file.");
                Console.WriteLine("3).Write a program in C# Sharp to create a file and write an array of strings to the file.");
                Console.WriteLine("4).Write a program in C# Sharp to append some text to an existing file. ");
                Console.WriteLine("5).Write a program in C# Sharp to read the first line from a file.");
                Console.WriteLine("6). Write a program in C# Sharp to count the number of lines in a file.");
                Console.WriteLine("7).Throw a Simple Exception and handle it.");
                Console.WriteLine("8).Create a program to ask the user for two numbers and display their division. Errors must be trapped using \"try..catch\".(Hint here used DivideByZeroException)\r\n");
                Console.WriteLine("9).C# Create one extension method called DateFormate() which returns today's date in user given date format.(means user will pass date format the function will return date in that format).");
                Console.WriteLine("10).Throw ArgumentNullException and handle it.");
                Console.WriteLine("11).Write a Program in C# to Create one File and store User Email Address in encrypted format. Also read that file and retrieve its original format.");
                Console.WriteLine("12).. C# Write a program to retrieve the user password from the Configuration file and encrypt it and store it in file.");


                Console.Write("Enter number:");
                int tasks = Convert.ToInt32(Console.ReadLine());
                switch (tasks)
                {
                    case 1:
                        string filePath = @"D:\c#\Fileexample\readfiletext.txt"; 

                        Console.Write("Enter some text to write to the file: ");
                        string text = Console.ReadLine();

                        using (StreamWriter sw = File.CreateText(filePath))
                        {
                            sw.WriteLine(text);
                        }

                        Console.WriteLine("File created and text written successfully!");
                        Console.ReadLine();
                        Console.ReadKey();

                        break;
                    case 2:
                        string fileName = @"D:\c#\Fileexample\SOHAM.txt";

                        try
                        {
                      
                            using (StreamWriter sw = File.CreateText(fileName))
                            {
                                sw.WriteLine("New file created: {0}", DateTime.Now.ToString());
                                sw.WriteLine("Author: soham");
                                sw.WriteLine("Hello soham");
                                sw.WriteLine("Hii ");
                                sw.WriteLine("Done! ");
                            }

                            using (StreamReader sr = File.OpenText(fileName))
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
                        Console.ReadKey();

                        break;
                    case 3:
                        Console.WriteLine("Enter the number of strings you want to enter:");
                        int numStrings = int.Parse(Console.ReadLine());
                        string[] stringsArray = new string[numStrings];
                        string filedestination = @"D:\c#\Fileexample\writearraytostringtxt.txt";

                        Console.WriteLine("Enter strings:");
                        for (int i = 0; i < numStrings; i++)
                        {
                            stringsArray[i] = Console.ReadLine();
                        }

                        try
                        {
                            using (StreamWriter writer = new StreamWriter(filedestination))
                            {
                                foreach (string str in stringsArray)
                                {
                                    writer.WriteLine(str);
                                }
                            }

                            Console.WriteLine("Strings written to file successfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error writing to file: " + ex.Message);
                        }
                        Console.ReadKey();

                        break;
                    case 4:
                        string Name = @"D:\c#\Fileexample\appendtext.txt";

                        try
                        {
                            
                            using (StreamWriter sw = File.AppendText(Name))
                            {
                                Console.WriteLine("Enter text to append:");
                                string userInput = Console.ReadLine();
                                sw.WriteLine(userInput);
                            }

                             
                            using (StreamReader sr = File.OpenText(Name))
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
                        Console.ReadKey();

                        break;

                    case 5:
                        string filesName = @"D:\c#\Fileexample\readfirsttext.txt";

                        try
                        {

                            using (StreamWriter sw = File.CreateText(filesName))
                            {
                               
                                //sw.WriteLine("Hello soham");
                                sw.WriteLine("Hii ");
                                sw.WriteLine("Done! ");
                            }

                            using (StreamReader sr = new StreamReader(filesName))
                            {
                                string firstLine = sr.ReadLine(); // Read the first line of the file
                                Console.WriteLine(firstLine); // Print the first line to the console
                            }

                        }
                        catch (Exception Ex)
                        {
                            Console.WriteLine(Ex.ToString());
                        }
                        Console.ReadKey();

                        break;
                    case 6:
                        string fName = @"D:\c#\Fileexample\readalltext.txt";
                        int linescount = 0;

                        try
                        {

                            using (StreamWriter sw = File.CreateText(fName))
                            {

                                sw.WriteLine("Hello soham");
                                sw.WriteLine("Hii ");
                                sw.WriteLine("Done! ");
                            }

                            using (StreamReader sr = new StreamReader(fName))
                            {
                                while (sr.ReadLine() != null)
                                {
                                    linescount++;
                                }
                            }
                            Console.WriteLine("The file has {0} lines.", linescount);

                        }
                        catch (Exception Ex)
                        {
                            Console.WriteLine(Ex.ToString());
                        }
                        Console.ReadKey();

                        break;

                    case 7:
                        try
                        {
                            int a = 10;
                            int b = 0;
                            int result = a / b; 
                        }
                        catch (Exception ex)
                        {
                          
                            Console.WriteLine("An error occurred: " + ex.Message);
                        }
                        Console.ReadKey();

                        break;
                    case 8:
                        try
                        {
                            Console.Write("Enter the first number: ");
                            int num1 = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter the second number: ");
                            int num2 = Convert.ToInt32(Console.ReadLine());

                            int result = num1 / num2;
                            Console.WriteLine($"The result of {num1} / {num2} = {result}");
                        }
                        //catch (DivideByZeroException)
                        //{
                        //    Console.WriteLine("Error: Cannot divide by zero.");
                        //}
                        catch (Exception ex)
                        {
                            Console.WriteLine("An error occurred: " + ex.Message);
                        }
                        Console.ReadKey();
                        break;

                    case 9:


                        //DateTime today = DateTime.Today;
                        //Console.Write("Enter date format (e.g. MM/dd/yyyy): ");
                        //string userFormat = Console.ReadLine();

                        //string formattedDate = today.ToString(userFormat);

                        //Console.WriteLine(formattedDate);
                        //Console.ReadKey();
                        try
                        {
                            Console.WriteLine("Enter date format(e.g. MM/dd/yyyy):");
                            string format = Console.ReadLine();
                            Console.WriteLine("");

                            DateTime today = DateTime.Now;
                            string formatdate = today.DateFormat(format);
                            Console.WriteLine(formatdate);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("error" + ex.Message);
                            Console.WriteLine();
                        }


                        break;
                    case 10:
                        string abc = null;
                        if (abc == null)
                        {
                            throw new ArgumentNullException("The string argument cannot be null.");
                        }
                        Console.ReadKey();

                        break;
                    case 11:
                        string nameoffile = @"D:\c#\Fileexample\emailencrypted.txt";
                        try
                        {
                            Console.Write("Enter the email: ");
                            string email = Console.ReadLine();

                            string encryptedEmail = Encrypt(email); // encrypt the email

                            using (StreamWriter sw = File.CreateText(nameoffile))
                            {
                                sw.WriteLine("EncryptedEmail:" + encryptedEmail); // write the encrypted email to the file
                            }
                            string decryptedEmail = Decrypt(encryptedEmail);
                            using (StreamWriter sw = File.AppendText(nameoffile))
                            {
                                sw.WriteLine("DecryptedEmail:" + decryptedEmail); // write the decrypted email to the file
                            }
                            using (StreamReader sr = File.OpenText(nameoffile))
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
                        Console.ReadKey();
                        break;
                    case 12:
                        //var encryptpass = EncryptedString(configvalue1);


                        string nameoffiles = @"D:\c#\Fileexample\passwordencrypted.txt";
                        try
                        {
                            string configvalue1 = ConfigurationManager.AppSettings["password"];


                            string encryptedEmail = Encrypt(configvalue1); // encrypt the email

                            using (StreamWriter sw = File.CreateText(nameoffiles))
                            {
                                sw.WriteLine("EncryptedEmail:" + encryptedEmail); // write the encrypted email to the file
                            }
                            string decryptedEmail = Decrypt(encryptedEmail);
                            using (StreamWriter sw = File.AppendText(nameoffiles))
                            {
                                sw.WriteLine("DecryptedEmail:" + decryptedEmail); // write the decrypted email to the file
                            }
                            using (StreamReader sr = File.OpenText(nameoffiles))
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
                        Console.ReadKey();


                        break;
                }
            } while (true);

        }
            
    }
}





