using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2 {
    class Program {
        static void Main(string[] args) {
            //56.Если целое число m делится нацело на целое число n, то вывести на экран частное от деления, в противном случае вывести сообщение «m на n нацело не делится».
            int n = 10, m = 3;
            string cout;
            if (n > m) {
                if (n % m == 0)
                    cout = "Делится";
                else
                    cout = "Не делится";
            } else {
                if (m % n == 0)
                    cout = "Делится";
                else
                    cout = "Не делится";
            }
            Console.WriteLine($"число {cout}");

            //59.Известны год и номер месяца рождения человека, а также год и номер месяца сегодняшнего дня(январь — 1 и т.д.).
            //Определить возраст человека(число полных лет). В случае совпадения указанных месяцев считать, что прошел полный год.
            int ty = 2019, tm = 2;
            int yy = 1963, mm = 5;
            if (tm >= mm) {
                Console.WriteLine($"возраст человека : {(ty - yy)}");
            } else {
                Console.WriteLine($"возраст человека : {(ty - yy)-1}");
            }

            //62.Даны радиус круга и сторона квадрата.У какой фигуры площадь больше ?
            Double r = 10; //радиус круга
            Double k = 100; //сторона квадрата
            if (Math.PI * Math.Pow(r,2) > Math.Pow(k, 2))
                Console.WriteLine($"площадь круга {Math.PI * Math.Pow(r,2)} больше площади квадрата {Math.Pow(k, 2)}");
            else
                Console.WriteLine($"площадь квадрата {Math.Pow(k, 2)} больше площади круга {Math.PI * Math.Pow(r, 2)}");



            //66.Дано двузначное число. Определить:
            //а) какая из его цифр больше, первая или вторая;
            //б) одинаковы ли его цифры.
            int t = 99;
            int d = (t / 10) % 10;
            int e = t % 10;
            Console.WriteLine($"число {t}");
            Console.WriteLine((d > e) ? "Первая цифра больше" : ((d == e) ? "Цифры равны" : "Вторая цифра больше"));


        }
    }
}
