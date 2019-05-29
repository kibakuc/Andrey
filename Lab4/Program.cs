using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("221.Удалить из массива все повторяющиеся элементы, оставив их первые вхождения, то есть в массиве должны остаться только разные элементы.");
            int i = 10;
            int[] arr;
            arr = createArr(i, 0, i);
            Console.WriteLine("Исходный массив:");
            printArr(arr);
            Console.WriteLine();
            Console.WriteLine("Результат:");
            int[] result = arr.Distinct().ToArray();
            printArr(result);
            Console.WriteLine();

            Console.WriteLine("223.Данные о росте 25 учеников класса, упорядоченные по убыванию, записаны в массиве. В начале учебного года в класс поступили два новых ученика.");
            Console.WriteLine("    Получить аналогичный массив, учитывающий рост новых учеников. Каков должен быть максимальный размер исходного массива ?");
            Console.WriteLine("Исходный массив:");
            arr = createArr(25, 150, 180);
            Array.Reverse(arr);
            printArr(arr);
            //Console.WriteLine();
            Array.Resize(ref arr, (25 + 2));
            arr.SetValue(145, 25);
            arr.SetValue(156, 26);
            printArr(arr);
            Console.WriteLine($"размер массива {arr.Length}");
        }

        private static void printArr(int[] arr) {
            foreach (int item in arr) {
                Console.WriteLine(item);
            }
        }

        private static int[] createArr(int i, int min, int max) {
            int[] arr = new int[i];
            Random rnd = new Random();
            for (i = 0; i < arr.Length; arr[i++] = rnd.Next(min, max))
                ;
            return arr;
        }
    }
}
