using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Thread_Test {
    //    Однорукий бандит - 3 потока, 
    //        генерирующие числа от 0 до 9. 
    //        По нажатию кнопки потоки останавливаются и результат анализируется.
    //        При анализе использовать следующие комбинации (
    //            три одинаковых числа, 
    //            два одинаковых числа, 
    //            три единицы, 
    //            три семерки, 
    //            две единицы, 
    //            имеется четверка)

    class Program {
        static Random r;
        static void GenN(int x, ParallelLoopState p) {
            Console.WriteLine($"Однорукий бандит - {x} - {r.Next(0, 9)}");
            if (x > 6) {
                p.Break();
            }
        }

        static void Main(string[] args) {
            r = new Random();
            ParallelLoopResult result = Parallel.For(0, 9, GenN);
            if (result.IsCompleted) {
                Console.WriteLine("Выполнение цикла прошло успешно.");
            } else {
                Console.WriteLine($"Выполнение цикла завершено на итерации {result.LowestBreakIteration}");
            }
        }


    }
}

