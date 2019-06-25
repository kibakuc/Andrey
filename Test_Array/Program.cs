using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Array {
    class Program {
        static void Main(string[] args) {
            Fio f1 = new Fio(1, "Петров");
            Fio f2 = new Fio(2, "Сидоров");
            Fio f3 = new Fio(3, "Личекака");
            ArrayList lst0 = new ArrayList();
            lst0.Add(f1);
            lst0.Add(f2);
            lst0.Add(f3);
            ArrayList lst1 = new ArrayList(lst0);
            lst1.Reverse();
            lst1.Sort();
            Person p = new Person(lst1);
            //Console.WriteLine(p);
        }
    }
}
