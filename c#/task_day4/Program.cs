using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static task_day4.Student;

namespace task_day4
{

    public class Student
    {
        private string studentID;
        private string studentName;
        private DateTime studentDOB;
        private string studentRollNo;
        private string studentEmail;
        private int[] studentGPA = new int[5];

        public string StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }

        public string StudentName
        {
            get { return studentName; }
            set { studentName = value; }
        }

        public DateTime StudentDOB
        {
            get { return studentDOB; }
            set { studentDOB = value; }
        }

        public string StudentRollNo
        {
            get { return studentRollNo; }
            set { studentRollNo = value; }
        }

        public string StudentEmail
        {
            get { return studentEmail; }
            set { studentEmail = value; }
        }

        public int[] StudentGPA
        {
            get { return studentGPA; }
            set { studentGPA = value; }
        }
        public enum GPARange
        {
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4
        };


        // Constructor
        public Student(string id, string name, DateTime dob, string rollNo, string email)
        {
            this.StudentID = id;
            this.StudentName = name;
            this.StudentDOB = dob;
            this.StudentRollNo = rollNo;
            this.StudentEmail = email;
        }

        // Methods
        public void SetGPA(int semester, GPARange gpa)
        {
            this.StudentGPA[semester-1] = (int)gpa;
        }
        public float CalculateCGPA()
        {
            float sum = 0;
            for (int i = 0; i < 5; i++)
            {
                sum += (int)this.StudentGPA[i];
            }
            return sum / 5;
        }
     
        public static Student GetClassRepresentative(Student[] students)
        {
            Student cr = null;
            float highestCGPA = 0;

            foreach (Student student in students)
            {
                float cgpa = student.CalculateCGPA();
                if (cgpa > highestCGPA)
                {
                    highestCGPA = cgpa;
                    cr = student;
                }
            }

            return cr;
        }


    }

    internal class Program
    {

        static double Add(double num1, double num2)
        {
            return num1 + num2;
        }
        static double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        static double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        static double Divide(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero");
            }

            return num1 / num2;
        }
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("1). calculate add, subtract, multiply and division");
                Console.WriteLine("2).Create a class of student that stores characteristics of a student, like studentID, studentName, studentDOB, studentRollNo, studentEmail, studentGPA of the last 5 semesters and other related information of the student.");

                Console.Write("Enter number:");
                int tasks = Convert.ToInt32(Console.ReadLine());

                switch (tasks)
                {
                    case 1:

                        Console.Write("Enter the first number: ");
                        double num1 = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter the second number: ");
                        double num2 = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("The sum  is="+ Add(num1, num2), num1, num2 );
                        Console.WriteLine("The difference is="+ Subtract(num1, num2), num1, num2 );
                        Console.WriteLine("The product  is="+ Multiply(num1, num2), num1, num2 );
                        Console.WriteLine("The quotient is="+ Divide(num1, num2), num1, num2 );
                        break;
                    case 2:
                            Student[] students = new Student[3];

                            for (int i = 0; i < 3; i++)
                            {
                                Console.WriteLine($"Enter details for student {i + 1}:");
                                Console.Write("Student ID: ");
                                string id = Console.ReadLine();
                                Console.Write("Student name: ");
                                string name = Console.ReadLine();
                                Console.Write("Student date of birth (yyyy-mm-dd): ");
                                DateTime dob = DateTime.Parse(Console.ReadLine());
                                Console.Write("Student roll number: ");
                                string rollNo = Console.ReadLine();
                                Console.Write("Student email: ");
                                string email = Console.ReadLine();

                                students[i] = new Student(id, name, dob, rollNo, email);

                                Console.WriteLine($"Enter GPA for each of the last 5 semesters for student {i + 1}:");
                                for (int j = 1; j <= 5; j++)
                                {
                                    Console.Write($"Semester {j} GPA: ");
                                GPARange gpa = GPARange.Parse(Console.ReadLine());
                                    students[i].SetGPA(j, gpa);
                                }
                                Console.WriteLine();
                            }
                      
                        foreach (Student student in students)
                        {
                            Console.WriteLine($"CGPA for {student.StudentName}: {student.CalculateCGPA()}");
                        }
                  

                        Student cr = Student.GetClassRepresentative(students);
                        Console.WriteLine($"The class representative is {cr.StudentName} with a CGPA of {cr.CalculateCGPA()}.");


                        break;
                }

            } while (true);

        }
    }
}


