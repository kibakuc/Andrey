using Morpher.Generic;
using Morpher.Russian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Con_Test {
    class Program {

        class Worker {
            //Переменная для демонстрации работы оператора lock
            private int value = 0;
            //Переменная "локер", которая служит для блокировки value
            private object valueLocker = new object();

            //Метод запускающий потоки
            public void Run() {
                for (int i = 0; i < 5; ++i) {
                    Thread thread = new Thread(ThreadFunction);
                    thread.Start();
                }
            }

            private void ThreadFunction() {
                //Блокируем доступ к локеру
                lock (valueLocker) {
                    //Выводим значение value
                    Console.WriteLine(value);
                    //Увеличиваем его на единицу
                    ++value;
                }
            }
        }

        static void Main(string[] args) {

            /*            Thread thread = new Thread(ThreadFunction);
                        thread.Start();
                        int count = 3;
                        while (count > 0) {
                            Console.WriteLine("Это главный поток программы!");
                            --count;
                        }
                        Console.Read();
            */
            /*            //Создаем в цикле 10 потоков
                        for (int i = 0; i < 10; ++i) {
                            Thread thread = new Thread(ThreadFunction);
                            thread.Start();
                        }
                        Console.WriteLine("Создание потоков завершено!");
                        Console.Read();
            */
            /*            //Создаем поток
                        Thread thread = new Thread(ThreadFunction);
                        thread.Start();
                        //Вызываем этот же метод без создания потока
                        ThreadFunction();
                        Console.Read();
            */
            //Создаем объект нашего класса
            Worker worker = new Worker();
            //Запускаем создание потоков
            worker.Run();
            //Ждем ввода от пользователя, что бы не закрылась консоль
            Console.Read();

        }


        /*        static void ThreadFunction() {
        */
        /*            //Аналогично главному потоку выводим три раза текст
                    int count = 3;
                    while (count > 0) {
                        Console.WriteLine("Это дочерний поток программы!");
                        --count;
                    }
        */
        //Просто выводим что-нибудь в консоль для наглядности
        /*            Console.WriteLine("Я поток!");
        */
        /*            int count = 5;
                    //Выводим пять раз значение count
                    while (count > 0) {
                        Console.WriteLine(count);
                        --count;
                    }
        */
        /*        }
        */

    }

}
