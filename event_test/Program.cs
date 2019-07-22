using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace event_test {

    //Это класс - в котором производится счет.
    class ClassCounter {
        //Синтаксис по сигнатуре метода, на который мы создаем делегат: 
        //delegate <выходной тип> ИмяДелегата(<тип входных параметров>);
        //Мы создаем на void Message(). Он должен запуститься, когда условие выполнится.
        public delegate void MethodContainer();

        //Событие OnCount c типом делегата MethodContainer.
        public event MethodContainer onCount;

        public void Count() {
            //Здесь будет производиться счет
            for (int i = 0; i < 100; i++) {
                if (i == 71) {
                    if (onCount != null)
                        onCount();
                }
            }
        }
    }

    //Это класс, реагирующий на событие (счет равен 71) записью строки в консоли.
    class Handler_I {
        public void Message() {
            Console.WriteLine("Пора действовать, ведь уже 71!");
        }
    }

    class Handler_II {
        public void Message() {
            Console.WriteLine("Точно, уже 71!");
        }
    }


    class Program {
        static void Main(string[] args) {
            ClassCounter Counter = new ClassCounter();
            Handler_I Handler1 = new Handler_I();
            Handler_II Handler2 = new Handler_II();

            //Подписались на событие
            Counter.onCount += Handler1.Message;
            Counter.onCount += Handler2.Message;

            //Запустили счетчик
            Counter.Count();
        }
    }
}
