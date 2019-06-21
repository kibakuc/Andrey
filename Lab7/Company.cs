using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7 {
    class Company {
        //Таксопарк(массив автомобилей) [добавить авто с номером, удалить авто с номером, отредактировать авто с номером, очистить таксопарк, заполнить таксопарк, setter и getter для каждого поля, несколько видов конструкторов, статистические методы(например, поиск авто по номеру)]

        Car[] car;
        Driver[] drivers;
        bool[] deletedCar;
        bool[] deletedDriver;

        uint totalTransportsQuantity = 0, currentTransportsQuantity = 0;
        uint[] totalWorkersQuantity = new uint[10], currentWorkersQuantity;

        internal Car[] Car { get => car; set => car = value; }
        public uint TotalTransportsQuantity { get => totalTransportsQuantity; }
        public uint CurrentTransportsQuantity { get => currentTransportsQuantity; }


        public Company(uint totalTransportsQuantity) {
            this.totalTransportsQuantity = totalTransportsQuantity;
            car = new Car[totalTransportsQuantity];
            deletedCar = new bool[totalTransportsQuantity];
            drivers = new Driver[totalTransportsQuantity];
            deletedDriver = new bool[totalTransportsQuantity];
            totalWorkersQuantity = new uint[totalTransportsQuantity];
            currentWorkersQuantity = new uint[totalTransportsQuantity];

            for (int i = 0; i < deletedCar.Length; i++)
                deletedCar[i] = true;
        }


        public void AddCar(Car cars, uint totalWorkersQuantity) {
            //bool result = false;
            if (currentTransportsQuantity < totalTransportsQuantity) {
                deletedCar[currentTransportsQuantity] = false;
                car[currentTransportsQuantity] = cars;
                currentTransportsQuantity++;
            }
        }

        public void RemoveCar(uint transportNumber) {
            //bool result = false;

            if ((transportNumber < currentTransportsQuantity) && (transportNumber > 0)) {
                deletedCar[transportNumber - 1] = true;

                //for (int i = 0; i < deletedWorkers[transportNumber - 1].Length; i++)
                //    deletedWorkers[transportNumber - 1][i] = true;

                //result = true;
            }

            //return result;
        }


        public override string ToString() {
            string result = string.Empty;
            for (int i = 0; i < currentTransportsQuantity; i++) {
                if (this.deletedCar[i] == false) {
                    result += "Транспорт №" + (i + 1) + '\n' + Car[i] + '\n';
                }
            }
            return result;

        }
    }
}
