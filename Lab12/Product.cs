using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12 {
    class Product {
        int id;
        string name;
        int price;

        public Product(int id, string name, int price) {
            Id = id;
            Name = name;
            Price = price;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }

    }
}
