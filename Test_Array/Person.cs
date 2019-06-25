using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Array {
    class Person {
        ArrayList list;
        public ArrayList List { get => list; set => list = value; }

        public Person(ArrayList list) {
            List = list;
            foreach (var item in List) {
                Console.WriteLine(item);
            }

        }
        /*
        public override string ToString() {
            string result = "";
            foreach (var item in List) {
                result += item + "\n";
            }
            return result.ToString();
        }
        */
    }
}
