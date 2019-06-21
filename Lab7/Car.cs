using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7 {
    class Car {
        //Автомобиль (регистрационный номер, марка, модель, тип, цвет, водители (массив), состояние, цена)
        string regnumber, make, model, cartype, carcolor;
        Driver[] drivers;
        Program.Condition condition;
        float price;

        public string Regnumber { get => regnumber; set => regnumber = value; }
        public string Make { get => make; set => make = value; }
        public string Model { get => model; set => model = value; }
        public string Cartype { get => cartype; set => cartype = value; }
        public string Carcolor { get => carcolor; set => carcolor = value; }
        internal Driver[] Drivers { get => drivers; set => drivers = value; }
        public float Price { get => price; set => price = value; }
        internal Program.Condition Condition { get => condition; set => condition = value; }

        public Car() { }

        public Car Clone() {
            Car clone = new Car();
            clone.Regnumber = this.regnumber;
            clone.Make = this.make;
            clone.Model = this.model;
            clone.Cartype = this.cartype;
            clone.Carcolor = this.carcolor;
            clone.Drivers = this.drivers;
            clone.Condition = this.condition;
            clone.Price = this.price;
            return clone;
        }

        public Car(string regnumber, string make, string model, string cartype, string carcolor, Driver[] drivers, Program.Condition condition, float price) {
            Regnumber = regnumber;
            Make = make;
            Model = model;
            Cartype = cartype;
            Carcolor = carcolor;
            Drivers = drivers;
            Condition = condition;
            Price = price;
        }

        public override string ToString() {
            string strDr = "";
            if (Drivers != null)
                foreach (Driver dr in Drivers)
                    strDr += "\n" + dr.ToString();

            return $"Регистрационный номер: {Regnumber}\nМарка: {Make}\nМодель: {Model}\nТип: {Cartype}\nЦвет: {Carcolor}\nВодители:\n----------- {strDr}\nСостояние: {Condition}\nЦена: {Price}\n";
        }
    }
}
