using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2 {
    class Program {
        static void Main(string[] args) {
            //59.Известны год и номер месяца рождения человека, а также год и номер месяца сегодняшнего дня(январь — 1 и т.д.).
            //Определить возраст человека(число полных лет). В случае совпадения указанных месяцев считать, что прошел полный год.
            int ty = 2019, tm = 5;
            int yy = 1963, mm = 2;
            if (tm >= mm) {
                Console.WriteLine($"возраст человека : {ty - yy}");
            }

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
