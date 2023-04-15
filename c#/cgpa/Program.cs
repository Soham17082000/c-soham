using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cgpa
{
    class Student
    {
        private int studentID;
        private string studentName;
        private DateTime studentDOB;
        private string studentRollNo;
        private string studentEmail;
        private double studentGPA;

        public Student(Student s)
        {
            studentID = s.studentID;
            studentName = s.StudentName;
            studentDOB = s.StudentDOB;
            studentRollNo = s.StudentRollNo;
            studentEmail = s.StudentEmail;
            studentGPA = s.StudentGPA;

        }
        enum GPALevel
        {
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4
        }



        public int StudentID
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

        public double StudentGPA
        {
            get { return studentGPA; }
            set { studentGPA = value; }
        }
        //public string name
        //{
        //    get;set;
        //}

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter three Student Details\n");
            List<Student> students = new List<Student>();

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine("Student " + i + " Data");
                Student student = new Student();
                student.getuserdata();
                students.Add(student);
            }

            foreach (Student student in students)
            {
                student.showdata();
                Console.WriteLine("");
            }
            double maxCGPA = double.MinValue;
            Student topStudent = null;

            foreach (Student student in students)
            {
                if (student.StudentGPA > maxCGPA)
                {
                    maxCGPA = student.StudentGPA;
                    topStudent = student;
                }
            }

            Console.WriteLine("CR of class: " + topStudent.StudentName);

            Student s = students[0] + students[1];

            //Console.WriteLine("CC : " + student4);

            Console.ReadLine();
        }

        public Student()
        {
        }

        public double CalculateCGPA(double[] gpas)
        {
            double totalGPA = 0;
            foreach (double gpa in gpas)
            {

                totalGPA += (double)gpa;
            }
            return totalGPA / gpas.Length;
        }


        public void getuserdata()
        {
            Console.Write("Enter Student ID:");
            StudentID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Student Name:");
            StudentName = Console.ReadLine();


            Console.Write("Enter Student DOB:");
            StudentDOB = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter Student Roll No:");
            StudentRollNo = Console.ReadLine();

            Console.Write("Enter Student Email:");
            StudentEmail = Console.ReadLine();

            double[] semesterGPAs = new double[5];
            for (int i = 0; i < semesterGPAs.Length; i++)
            {
                Console.Write("Enter GPA for Semester {0} (1-4): ", i + 1);
                int choice = Convert.ToInt32(Console.ReadLine());
                GPALevel g;
                switch (choice)
                {
                    case 1:
                        g = GPALevel.One;
                        break;
                    case 2:
                        g = GPALevel.Two;
                        break;
                    case 3:
                        g = GPALevel.Three;
                        break;
                    case 4:
                        g = GPALevel.Four;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Default value of 3 will be used.");
                        g = GPALevel.Three;
                        break;
                }
                semesterGPAs[i] = (double)g;
            }
            studentGPA = CalculateCGPA(semesterGPAs);

            Console.WriteLine("CGPA = " + studentGPA);
        }
        public static Student operator +(Student student1, Student student2)
        {
            Student s = new Student();
            s.StudentName = student1.StudentName + " " + student2.StudentName;
            s.studentRollNo = student1.studentRollNo + " " + student2.studentRollNo;
            s.StudentEmail = student1.StudentEmail + " " + student2.StudentEmail;
            Console.WriteLine("operator overloading");
            Console.WriteLine("studentname = " + s.StudentName);
            Console.WriteLine("studentRollNo = " + s.studentRollNo);
            Console.WriteLine("StudentEmail = " + s.StudentEmail);
            return s;
        }

        public static double GetMaxCGPA(Student[] students)
        {
            double maxCGPA = 0;
            foreach (Student s in students)
            {
                if (s.studentGPA > maxCGPA)
                {
                    maxCGPA = s.studentGPA;
                }
            }
            return maxCGPA;
        }
        //public  Student(Student student3)
        //{
        //    name = student3.StudentName;
        //}

        public void showdata()
        {
            Console.WriteLine("Student ID     : " + studentID);
            Console.WriteLine("Student Name   : " + studentName);
            Console.WriteLine("Student DOB    : " + studentDOB);
            Console.WriteLine("Student rollno:" + studentRollNo);
            Console.WriteLine("Student Email  : " + studentEmail);
            Console.WriteLine("Student CGPA   : " + studentGPA);
        }
    }
}

