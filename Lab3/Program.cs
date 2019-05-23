using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab3 {
    class Program {
        static void Main(string[] args) {
            //int length = 10, d=0;
            //for (int i = 0; i < length; i++) {
            //    Console.WriteLine(d++);
            //}

            BigInteger big1 = new BigInteger(double.MaxValue);
            BigInteger big2 = new BigInteger(double.MaxValue);

            // Add the 2 values together.
            BigInteger double1 = BigInteger.Add(big1, big2);

            // Print the values of the BigIntegers.
            //Console.WriteLine("DOUBLE MAX: " + big1.ToString());
            Console.WriteLine("DOUBLE MAX * 2: " + double1.ToString());

            DateTime time = DateTime.Now;             // Use current time.
            string format = "dd.MM.yyyy HH:mm:ss";   // Use this format.
            Console.WriteLine(time.ToString(format)); // Write to console.
        }
    }
}
