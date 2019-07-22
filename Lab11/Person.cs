using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11 {
    class Person {
        int id;
        string clientname;
        int age;

        public Person(int id, string clientname, int age) {
            Id = id;
            Clientname = clientname;
            Age = age;
        }

        public int Id { get => id; set => id = value; }
        public string Clientname { get => clientname; set => clientname = value; }
        public int Age { get => age; set => age = value; }


    }
}
