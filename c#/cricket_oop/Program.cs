    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;

    namespace cricket_oop
    {
       public abstract class team
    {
        public void TeamName()
        {
            Console.WriteLine("India");
        }

        public abstract void CalculateSalary();
    }

        class kit
        {
            //encapsulation
            private string bat;
            private string ball;
            private string stumps;
            private string shoes;

            public string Bat
            {
                get { return bat; }
                set { bat = value; }
            }

            public string Ball
            {
                get { return ball; }
                set { ball = value; }
            }

            public string Stumps
            {
                get { return stumps; }
                set { stumps = value; }
            }

            public string Shoes
            {
                get { return shoes; }
                set { shoes = value; }
            }
        }

        //inheritance
        public class cricket:team
        {
            kit cricketKit = new kit();

            public void SetBat(string bat)
            {
                cricketKit.Bat = bat;
            }

            public void SetBall(string ball)
            {
                cricketKit.Ball = ball;
            }

            public void SetStumps(string stumps)
            {
                cricketKit.Stumps = stumps;
            }

            public void SetShoes(string shoes)
            {
                cricketKit.Shoes = shoes;
            }

            public string GetBat()
            {
                return cricketKit.Bat;
            }

            public string GetBall()
            {
                return cricketKit.Ball;
            }

            public string GetStumps()
            {
                return cricketKit.Stumps;
            }

            public string GetShoes()
            {
                return cricketKit.Shoes;
            }
            public void ShowKit()
            {
                Console.WriteLine("Bat: {0}", cricketKit.Bat);
                Console.WriteLine("Ball: {0}", cricketKit.Ball);
                Console.WriteLine("Stumps: {0}", cricketKit.Stumps);
                Console.WriteLine("Shoes: {0}", cricketKit.Shoes);
            }
            public void score()
            {
                Console.WriteLine("scored");
            }
            public void win()
            {
                Console.WriteLine("Won!");

            }

        //method overloading
        public void playerdetail(string name, int age, int run)
        {
            Console.WriteLine("Name: {0}, Age: {1}, Run: {2}", name, age, run);
           
        }
        public void playerdetail(string name, int age)
        {
            Console.WriteLine("Name: {0}, Age: {1}", name, age);
           
        }
        public override void CalculateSalary()
        {
            // add the code to calculate the salary of the players
            Console.WriteLine("Calculating player salaries...");
        }
    }
    internal class Program
        {
            static void Main(string[] args)
            {
                cricket Sport = new cricket();
                  Sport.SetBat("MRF");
                  Sport.SetBall("SG");
                  Sport.SetStumps("Kookaburra");
                  Sport.SetShoes("Nike");
                Sport.ShowKit();
                Sport.score();
                   Sport.win();
                 Sport.TeamName();
                Sport.playerdetail("soham", 22, 50);
                Sport.playerdetail("soham", 22);
            Sport.CalculateSalary();


            }
        }
    }

