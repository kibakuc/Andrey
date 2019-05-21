using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    class Program {
        static void Main(string[] args) {
            job2(a: 20, b: 20, c: 20, d: 20);
            job4(x: 20, y: 20);
        }

        private static void job2(Double a=10,Double b=10, Double c= 10,Double d=10) {
            Double result = (a / c) * (b / d) - (((a * b) - c) / (c * d));
            Console.WriteLine(result);
        }

        private static void job4(Double x = 10, Double y = 10) {
            Double result = ((x+y)/(y+1))-(((x*y)-12)/(34+x));
            Console.WriteLine(result);
        }
    }
}
