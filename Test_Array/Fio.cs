using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Array {
    class Fio {
        int id;
        string fname;


        public int Id { get => id; set => id = value; }
        public string Fname { get => fname; set => fname = value; }

        public Fio(int id, string fname) {
            Id = id;
            Fname = fname;
        }

        public Fio(Fio arr) {
            this.Id = arr.id;
            this.Fname = arr.fname;
        }

        public override string ToString() {
            return $"Id: {Id} Fio: {Fname}";
        }
    }
}
