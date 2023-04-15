using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace platform
{
    public abstract class OTT
    {
        public abstract string Name { get; set; }
        public abstract string Email { get; set; }
        public abstract string Password { get; set; }

        public abstract void SetCredentials(string name, string email, string password);
    }


    public class Netflix : OTT
    {
        public override string Name { get; set; }
        public override string Email { get; set; }
        public override string Password { get; set; }

      public void content()
        {
            string title = "Stranger Things";
            float rating = 8.7f;
            int price = 9;

            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Rating: {rating}");
            Console.WriteLine($"Price: {price}");
        }

        public override void SetCredentials(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }

    public class Primevideo : OTT
    {
        public override string Name { get; set; }
        public override string Email { get; set; }
        public override string Password { get; set; }

        public  void contents()
        {
            string title = "The Marvelous Mrs. Maisel";
            float rating = 8.7f;
            int price = 12;

            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Rating: {rating}");
            Console.WriteLine($"Price: {price}");
        }

        public override void SetCredentials(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Netflix netflix = new Netflix();
            Primevideo primevideo = new Primevideo();

          
            netflix.Name = "aa";
            netflix.Email = "aa@example.com";
            netflix.Password = "password123";

            primevideo.Name = "bb";
            primevideo.Email = "bb@example.com";
            primevideo.Password = "password456";

            netflix.content();
            primevideo.contents();

       

            Console.ReadLine();
        }
    }
}
