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

            //------------------------------------------------------
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


            //------------------------------------------------------
            Console.WriteLine("903.Найти сумму всех четных элементов Двумерного массива целых чисел A[10, 10]");
            const int M = 10, N = 10;
            int[,] arrto;
            int sumA = 0;
            arrto = createToArr(M, N);
            // перебираем строки
            for (int row = 0; row < M; row++) {
                // перебираем столбцы в строке
                for (int column = 0; column < N; column++) {
                    if (arrto[row, column] % 2 == 0) {
                        sumA += arrto[row, column];
                    }
                }
            }
            Console.WriteLine($"сумму всех четных элементов Двумерного массива целых чисел A[10, 10] {sumA}");
            Console.WriteLine();


            //------------------------------------------------------
            Console.WriteLine("904.Найти наибольший и наименьший элементы Двумерного массива вещественных чисел В[m, n]");
            int min, max = min = arrto[0, 0];
            for (int row = 0; row < M; row++) {
                // перебираем столбцы в строке
                for (int column = 0; column < N; column++) {
                    if (arrto[row, column] < min)
                        min = arrto[row, column];
                    if (arrto[row, column] > max)
                        max = arrto[row, column];
                }
            }
            Console.WriteLine($"Минимальный элемент массива: {min}");
            Console.WriteLine($"Максимальный элемент массива: {max}");
            Console.WriteLine();


            //------------------------------------------------------
            Console.WriteLine("909.Найти номер строки и столбца Двумерного массива для максимального элемента этого массива");
            max = arrto[0, 0];
            int r1 = 0, c1 = 0;
            for (int row = 0; row < M; row++) {
                // перебираем столбцы в строке
                for (int column = 0; column < N; column++) {
                    if (arrto[row, column] > max) {
                        max = arrto[row, column];
                        r1 = row;
                        c1 = column;
                    }
                }
            }
            Console.WriteLine($"Максимальный элемент массива: {max}");
            Console.WriteLine($"номер строки {r1} и столбца {c1}");
        }

        private static int[,] createToArr(int M, int N) {
            int[,] arrto = new int[M, N];
            Random rnd = new Random();
            // перебираем строки
            for (int row = 0; row < M; row++) {
                // перебираем столбцы в строке
                for (int column = 0; column < N; column++) {
                    // присваиваем очередному элементу массива случайное значение в интервале (0..100)
                    arrto[row, column] = rnd.Next(1, 100);
                    Console.Write(arrto[row, column] + "\t");
                }
                Console.WriteLine();
            }
            return arrto;
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

