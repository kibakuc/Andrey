using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6 {
    class Program {
        static void Main(string[] args) {
            string sURL = "https://api.openweathermap.org/data/2.5/weather?q=Odessa,ua&APPID=2a86bb8ee3924816aaa98071110d078c&units=metric";
            Web w1 = new Web(sURL);
            Weather w2 = new Weather(w1.FromUnixTime(Convert.ToInt32(w1.arr[15])),
                                     Convert.ToInt32(w1.arr[9]),
                                     Convert.ToInt32(w1.arr[10]),
                                     w1.arr[14],
                                     w1.arr[7],
                                     Convert.ToInt32(w1.arr[8]),
                                     Convert.ToInt32(w1.arr[12]),
                                     w1.arr[13],
                                     w1.arr[5]
                                     );

            Console.WriteLine(w2);

        }

    }
}
