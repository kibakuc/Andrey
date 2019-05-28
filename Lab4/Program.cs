using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4 {
    class Program {
        static void Main(string[] args) {
            //int[] a1 = new int[5];
            //int[] a1 = { 1, 3, 5, 7 };
            //Array arr = a1;

            //Console.WriteLine(arr.Rank);
            //Console.WriteLine(arr.Length);
            //arr.GetLength
            //Console.WriteLine(58 % 6);
            int va = 0, vb = 0, vc = 0, vd = 0;
            for (int a = 1; a < 100; a++) {

                if (a % 3 == 1)
                    va++;
                if (a % 4 == 2)
                    vb++;
                if (a % 5 == 3)
                    vc++;
                if (a % 6 == 4)
                    vd++;
                /*
                if (a % 3 == 1)
                    if (a % 4 == 2)
                        if (a % 5 == 3)
                            if (a % 6 == 4)
                                Console.WriteLine(a);
                    */
            }
            Console.WriteLine($"а) - {va}");
            Console.WriteLine($"б) - {vb}");
            Console.WriteLine($"в) - {vc}");
            Console.WriteLine($"г) - {vd}");
            Console.WriteLine($"Итого - {va + vb + vc + vd}");

        }
    }
}
