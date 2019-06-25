using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7 {
    class Program {
        public enum Condition { GoodCar, BadCar, NormalCar };

        static void Main(string[] args) {
            Company company = new Company(10);

            Driver d1 = new Driver("Сидоров", "Улица1", "340-670-890", DateTime.Parse("10.10.1989"));
            Driver d2 = new Driver("Петров", "Улица2", "341-671-891", DateTime.Parse("11.11.1990"));
            Driver d3 = new Driver("Шкаликов", "Улица3", "342-672-892", DateTime.Parse("12.12.1991"));
            Driver d4 = new Driver("Личекака", "Улица4", "343-673-893", DateTime.Parse("01.01.1992"));

            //Driver cd4 = (Driver)d4.Clone();
            //cd4.Name = "123456789";
            //Console.WriteLine(d4.Name);
            //Console.WriteLine(cd4.Name);



            //(регистрационный номер, марка, модель, тип, цвет, водители(массив), состояние, цена)
            Car c1 = new Car("000001", "Audi", "QW001", "01", "Red", new Driver[] { d1 }, Condition.GoodCar, 400000);
            Car c2 = new Car("000001", "Dacia", "QW002", "02", "Yellow", new Driver[] { d1 }, Condition.BadCar, 100000);
            Car c3 = new Car("000001", "Ford", "QW003", "03", "Green", new Driver[] { d1, d2 }, Condition.NormalCar, 200000);
            Car c4 = new Car("000001", "BMW", "QW004", "04", "Silver", new Driver[] { d3, d4 }, Condition.GoodCar, 300000);

            //Console.WriteLine(c4);
            Console.WriteLine("--------- start -----------\n");
            company.AddCar(c3, 5);
            company.AddCar(c4, 5);
            Console.WriteLine(company);
            Console.WriteLine("--------- del -----------\n");

            company.RemoveCar(1);
            Console.WriteLine(company);


        }

    }
}
