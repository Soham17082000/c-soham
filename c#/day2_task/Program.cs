using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day2_task
{
    internal class Program
    {
        static int Add(int x, int y)
        {
            return x + y;
        }

        static int Add(int x, int y, int z)
        {
            return x + y + z;
        }

        static double Add(double x, double y)
        {
            return x + y;
        }
        static string Print(string x)
        {
            return x;
        }

        static double Print(double x, double y)
        {
            return x + y;
        }
        //static int Print(string x, int y)
        //{
        //    return Convert.ToInt32(x)+return y ;
        //}


        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("1).C# program to write your name 5 times.");
                Console.WriteLine("2).Write a method that returns a string of even numbers greater than 0 and less than 50. (do not print 2,12,22,32,42)");
                Console.WriteLine("3).C# program to count negative elements in array -> int[] myNum = { 10, 20, 30, 40, -9, -8, -3, 4 }; Output = 3 get numbers from user input  not use static");
                Console.WriteLine("4).C# program to find maximum and minimum element in array -> int[] myNum = { 10, 20, 30, 40, -9, -8, -3, 4 }; Maximum = 40, minimum = -9 get numbers from user input  not use static");
                Console.WriteLine("5).C# program to count even and odd elements in array -> int[] myNum = { 10, 20, 30, 40, -9, -8, -3, 4 }; Even : 6 Odd: 2 get numbers from user input  not use static");
                Console.WriteLine("6).c# program to print int, string and int, string value by function overloading - use same method name (Ex : Print)");
                Console.WriteLine("7).c# program to sum of two integer value, three integer value and three double values - use same method name (Ex : Add)");
                Console.Write("Enter number:");
                int tasks = Convert.ToInt32(Console.ReadLine());

                switch (tasks)
                {
                    case 1:
                        try
                        {
                            Console.Write("Enter your name: ");
                            string name = Console.ReadLine();
                            for (int p = 0; p < 5; p++)
                            {
                                Console.WriteLine(name);
                            }
                            Console.ReadLine();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Err");
                        }
                        break;

                    case 2:

                        Console.WriteLine("Even Numbers :");
                        for (int k = 1; k < 50; k++)
                        {
                            if (k % 2 == 0)
                            {
                                if (k == 2 || k == 12 || k == 22 || k == 32 || k == 42)
                                {
                                    continue;
                                }
                                Console.Write(k + " ");
                            }
                        }
                        Console.WriteLine();
                        break;
                    case 3:
                        int i, num, count = 0;

                        Console.WriteLine("Enter size of the array: ");
                        num = Convert.ToInt32(Console.ReadLine());
                        double[] arr = new double[num];
                        Console.WriteLine("Enter elements in array: ");
                        for (i = 0; i < num; i++)
                        {
                            arr[i] = Convert.ToDouble((Console.ReadLine()));
                        }
                        for (i = 0; i < num; i++)
                        {
                            if (arr[i] < 0)
                            {

                                count++;
                            }
                        }
                        Console.WriteLine("Total number of negative elements in the array: " + count);
                        Console.ReadLine();
                        break;
                    case 4:
                        int number, max, min;
                        Console.WriteLine("Enter size of the array:");
                        number = Convert.ToInt32(Console.ReadLine());
                        int[] array = new int[number];
                        Console.WriteLine("Enter Elements in array:");
                        for (int l = 0; l < number; l++)
                        {
                            array[l] = Convert.ToInt32(Console.ReadLine());
                        }
                        max = array[0];
                        min = array[0];
                        for (int l = 1; l < number; l++)
                        {
                            if (array[l] > max)
                            {
                                max = array[l];
                            }
                            if (array[l] < min)
                            {
                                min = array[l];
                            }
                        }
                        Console.WriteLine("Maximum element in the array: " + max);
                        Console.WriteLine("Minimum element in the array: " + min);
                        break;
                    case 5:
                        try
                        {
                            int n, evenCount = 0, oddCount = 0;
                            Console.WriteLine("Enter size of the array:");
                            n = Convert.ToInt32(Console.ReadLine());
                            int[] a = new int[n];
                            Console.WriteLine("Enter Elements in array:");
                            for (int l = 0; l < n; l++)
                            {
                                a[l] = Convert.ToInt32(Console.ReadLine());
                            }
                            for (int l = 0; l < n; l++)
                            {
                                if (a[l] % 2 == 0)
                                {
                                    evenCount++;
                                }
                                else
                                {
                                    oddCount++;
                                }
                            }
                            Console.WriteLine("Number of even elements in the array: " + evenCount);
                            Console.WriteLine("Number of odd elements in the array: " + oddCount);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error");
                        }
                        break;
                    case 6:
                        string myNumber1 = Print("soham");
                        double myNumber2 = Print(4.3, 6.26);
                       //string myNumber3=Print("s",34);
                        Console.WriteLine("String: " + myNumber1);
                        Console.WriteLine("Double: " + myNumber2);
                        //Console.WriteLine("intstr: " + (myNumber3);
                        break;
                    case 7:
                        int myNum1, myNum2, x, y, z;
                        double myNum3, xDouble, yDouble;
                        Console.WriteLine("Enter two integers:");
                        x = int.Parse(Console.ReadLine());
                        y = int.Parse(Console.ReadLine());
                        myNum1 = Add(x, y);
                        Console.WriteLine("Int: " + myNum1);
                        Console.WriteLine("Enter three integers:");
                        x = int.Parse(Console.ReadLine());
                        y = int.Parse(Console.ReadLine());
                        z = int.Parse(Console.ReadLine());
                        myNum2 = Add(x, y, z);
                        Console.WriteLine("Int: " + myNum2);
                        Console.WriteLine("Enter two doubles:");
                        xDouble = double.Parse(Console.ReadLine());
                        yDouble = double.Parse(Console.ReadLine());
                        myNum3 = Add(xDouble, yDouble);
                        Console.WriteLine("Double: " + myNum3);
                        Console.ReadLine();
                        break;
                }
            }
            while (true);
        }

    }
}








 
      
    

  

