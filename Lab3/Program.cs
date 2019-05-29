using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab3 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("8.Умножение числа а = 12345679 на числа 9, 18, 27, ... 81 дает интересные результаты.' Напишите программу получения этих произведений.'");
            //8.Умножение числа а = 12345679 на числа 9, 18, 27, ... 81 дает интересные результаты.' Напишите программу получения этих произведений.'
            int x = 12345679;
            int[] fibarray = new int[] { 9, 18, 27, 36, 45, 54, 63, 72, 81 };
            foreach (int element in fibarray)
                Console.WriteLine(element * x);

            Console.WriteLine("9.Одна штука некоторого товара стоит 20,4 грн.Напечатать таблицу стоимости 2, 3, ..., 20 штук …этого товара.");
            //9.Одна штука некоторого товара стоит 20,4 грн.Напечатать таблицу стоимости 2, 3, ..., 20 штук …этого товара.
            double x1 = 20.4;
            double[] fibarray1 = new double[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            foreach (int element in fibarray1)
                Console.WriteLine(element * x1);

            Console.WriteLine("13.Напечатать таблицу перевода 1, 2, ..., 20 долларов США в гривни по текущему курсу(курс вводится с клавиатуры)");
            //13.	Напечатать таблицу перевода 1, 2, ..., 20 долларов США в гривни по текущему курсу (курс вводится с клавиатуры).
            // Ввести курс гривны с клавиатуры
            Console.Write("Ввести курс гривны и нажать Enter:\n");
            // Получение строки курса
            string kursString = Console.ReadLine().Replace('.', ',');
            // Преобразование строки в число
            double kursgrn = Convert.ToDouble(kursString);
            double[] usdarray = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            foreach (int element in usdarray)
                Console.WriteLine($"{element} USD = {element * kursgrn} UAH");

            Console.Write("347.Даны натуральные числа m и n.Вычислить 1n + 2n + ... +mn = ");
            //347.Даны натуральные числа m и n.Вычислить 1n + 2n + ... +mn.
            int n = 10, m = 11, i = 1;
            Double r = 0;
            for (i = 1; i < m; i++) {
                r += Math.Pow(i, n);
            }
            Console.WriteLine($"{r}");
        }
    }
}
