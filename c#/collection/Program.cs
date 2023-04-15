using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collection
{
    class Program
    {
       
        static void Main(string[] args)
        {
            ArrayList personList = new ArrayList();
            personList.Add("Soham");
            personList.Add("Raval");
            foreach (var item in personList)
            {
                string arrayItem = string.Format($"Name  is {item}");
                Console.WriteLine(arrayItem);
            }
            personList.Insert(2, "S");
            foreach (var item in personList)
            {
                string arrayItem = string.Format($"Name  is {item}");
                Console.WriteLine(arrayItem);
            }
            personList.Remove("Soham");
            foreach (var item in personList)
            {
                string arrayItem = string.Format($"Name  is {item}");
                Console.WriteLine(arrayItem);
            }

            Hashtable hshTable = new Hashtable();
            hshTable.Add("Author1", "Mahesh Chand");
            hshTable.Add("Author2", "James Brand");
            hshTable.Add("Author3", "Meke Gold");
            hshTable.Add("Author4", "Mbke Gold");
            hshTable.Add("Author5", "Mcke Gold");
            hshTable.Add("Author6", "Mdke Gold");
            


            foreach (DictionaryEntry d in hshTable)
            {
            //DictonaryEntry: is a class whose object represents the data in a combination of key & value pairs.
            Console.WriteLine(d.Key + " " + d.Value);
                Console.WriteLine("");
            }

            hshTable.Remove("Author1");
            foreach (DictionaryEntry d in hshTable)
            {
                Console.WriteLine(d.Key + " " + d.Value);
                Console.WriteLine("");
            }

            SortedList<int, string> sortedlist = new SortedList<int, string>();
            //add the elements in sortedlist  
            sortedlist.Add(1, "Sunday");
            sortedlist.Add(2, "Monday");
            sortedlist.Add(3, "Tuesday");
            sortedlist.Add(4, "Wednesday");
            sortedlist.Add(5, "Thusday");
            sortedlist.Add(6, "Friday");
            sortedlist.Add(7, "Saturday");
            //display the elements of the sortedlist  
            Console.WriteLine("The elements in the SortedList are:");
            foreach (KeyValuePair<int, string> pair in sortedlist)
            {
                Console.WriteLine("{0} => {1}", pair.Key, pair.Value);
            }
            Console.WriteLine("The capacity is:" + sortedlist.Capacity);
            Console.WriteLine("The total number of elements in the sortedlist are:" + sortedlist.Count);
            IList<int> ilistKeys = sortedlist.Keys;
            Console.WriteLine();
            Console.WriteLine("The keys are:");
            Console.Write("{");
            foreach (int i in ilistKeys)
            {
                Console.Write(i + ",");
            }
            Console.WriteLine("}");
            Console.WriteLine("The key 1 contain in the SortedList:" + sortedlist.ContainsKey(1));
            Console.WriteLine("The key 50 contain in the SortedList:" + sortedlist.ContainsKey(50));
            Console.WriteLine("The value Sunday contain in the SortedList:" + sortedlist.ContainsValue("Sunday"));
            Console.WriteLine("The value Feb contain in the SortedList:" + sortedlist.ContainsValue("Feb"));
            Console.WriteLine("The index value of the key 2 is:" + sortedlist.IndexOfKey(2));
            Console.WriteLine("The index value of the value Sunday is:" + sortedlist.IndexOfValue("Sunday"));
            sortedlist.Remove(3);
            Console.WriteLine("After remove some elements the sortedlist is as:");
            foreach(KeyValuePair<int, string> pair in sortedlist)
            {
                Console.WriteLine("{0} => {1}", pair.Key, pair.Value);
            }
            sortedlist.Clear();
            Console.WriteLine("After clear method the elements in the sortedlist are:" + sortedlist.Count);

            Stack stk = new Stack();
            stk.Push("cs.net");
            stk.Push("vb.net");
            stk.Push("asp.net");
            stk.Push("sqlserver");

            Console.Write("stack" + "\n");

            foreach (object o in stk)
            {
                Console.Write(o + "\n ");
            }
            Queue q = new Queue();
            q.Enqueue("cs.net");
            q.Enqueue("vb.net");
            q.Enqueue("asp.net");
            q.Enqueue("sqlserver");
            q.Dequeue();
            Console.Write("queue" + "\n");
            foreach (object o in q)
            {
                Console.Write(o + "\n");
            }
            Console.Read();
        }
    }
}
