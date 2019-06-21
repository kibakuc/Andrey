using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7 {
    class Driver {
        //Водитель (ФИО, дом.адрес,  телефон, дата рождения)
        string name, homeaddress, telephone;
        DateTime birthday;

        public string Name { get => name; set => name = value; }
        public string Homeaddress { get => homeaddress; set => homeaddress = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }


        public Driver(string name, string homeaddress, string telephone, DateTime birthday) {
            Name = name;
            Homeaddress = homeaddress;
            Telephone = telephone;
            Birthday = birthday;
        }

        public Driver() { }

        public Driver Clone() {
            Driver clone = new Driver();
            clone.Name = this.name;
            clone.Homeaddress = this.homeaddress;
            clone.Telephone = this.telephone;
            clone.Birthday = this.birthday;
            return clone;
        }

        public override string ToString() {
            return $"ФИО: {Name}\nДомашний адрес: {Homeaddress}\nТелефон: {Telephone}\nДата рождения: {Birthday}\n-----------";
        }

    }
}
