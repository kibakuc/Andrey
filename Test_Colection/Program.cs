using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test {
    class Program {
        static void Main(string[] args) {
            List<int> numbers = new List<int>();
            foreach (int number in new int[12] { 10, 9, 8, 7, 7, 6, 5, 10, 4, 3, 2, 1 }) {
                numbers.Add(number);
            }
            show(numbers);

            numbers.Insert(numbers.Count, 99);
            show(numbers);

            Console.WriteLine(numbers.Remove(3));
            numbers.RemoveAt(6);
            numbers.Sort();
            show(numbers);

            string[] students1 = { "Henry", "David", "Tom" };
            List<string> list1 = new List<string>(students1);
            foreach (var stu in list1) {
                Console.WriteLine(stu);
            }


            LinkedList<int> llnumbers = new LinkedList<int>();
            foreach (int number in new int[] { 10, 8, 6, 4, 2 }) {
                llnumbers.AddFirst(number);
            }
            llshow(llnumbers);
            //Console.WriteLine(llnumbers.First.Value);
            llnumbers.AddBefore(llnumbers.Last, 99);
            llnumbers.AddAfter(llnumbers.First, 0);
            llnumbers.AddLast(5);
            llshow(llnumbers);
            llnumbers.Remove(llnumbers.First);
            llshow(llnumbers);

            string[] students = { "Henry", "David", "Tom" };
            LinkedList<string> list = new LinkedList<string>(students);
            foreach (var stu in list) {
                Console.WriteLine(stu);
            }
            var newNode = list.AddLast("Brad");
            list.AddBefore(newNode, "Emma");
            Console.WriteLine("LinkedList after adding new nodes...");
            foreach (var stu in list) {
                Console.WriteLine(stu);
            }

            Queue<int> qnumbers = new Queue<int>();
            foreach (int number in new int[4] { 9, 3, 7, 2 }) {
                qnumbers.Enqueue(number);
                Console.WriteLine($"{number} has joined the queue");
            }
            foreach (int number in qnumbers) {
                Console.WriteLine(number);
            }
            while (qnumbers.Count > 0) {
                int number = qnumbers.Dequeue();
                Console.WriteLine($"{number} has left the queue");
            }

            Stack<int> snumbers = new Stack<int>();
            foreach (int number in new int[4] { 9, 3, 7, 2 }) {
                snumbers.Push(number);
                Console.WriteLine($"{number} has been pushed on the stack");
            }
            foreach (int number in snumbers) {
                Console.WriteLine(number);
            }
            while (snumbers.Count > 0) {
                int number = snumbers.Pop();
                Console.WriteLine($"{number} has been popped off the stack");
            }

            //Dictionary<string, int> ages = new Dictionary<string, int>();
            SortedList<string, int> ages = new SortedList<string, int>();
            ages.Add("John", 51); // Использование метода Add
            ages.Add("Diana", 50);
            ages["James"] = 23; // Использование такой же системы записи, что и у массивов
            ages["Francesca"] = 21;
            Console.WriteLine("The Dictionary contains:");
            foreach (KeyValuePair<string, int> element in ages) {
                string name = element.Key;
                int age = element.Value;
                Console.WriteLine($"Name: {name}, Age: {age}");
            }

            HashSet<string> employees = new HashSet<string>(new string[] { "Fred", "Bert", "Harry", "John" });
            HashSet<string> customers = new HashSet<string>(new string[] { "John", "Sid", "Harry", "Diana" });
            employees.Add("James");
            customers.Add("Francesca");
            Console.WriteLine("Employees:");
            foreach (string name in employees) {
                Console.WriteLine(name);
            }
            Console.WriteLine("\nCustomers:");
            foreach (string name in customers) {
                Console.WriteLine(name);
            }
            Console.WriteLine("\nCustomers who are also employees:");
            customers.IntersectWith(employees);
            foreach (string name in customers) {
                Console.WriteLine(name);
            }
        }

        static void show(List<int> numbers) {
            Console.WriteLine("-------------------");
            foreach (int item in numbers) {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------");
        }
        static void llshow(LinkedList<int> numbers) {
            Console.WriteLine("-------------------");
            foreach (int item in numbers) {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------");
        }

    }
}
