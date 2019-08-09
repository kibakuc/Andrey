using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lab13 {
    class GetWeather {
        public static string lastError = "";
        public static string weather = "";


        public static async Task GetWeatherDataAsync() {
            lastError = "";
            try {
                WebClient client = new WebClient();
                StreamReader reader = new StreamReader(await client.OpenReadTaskAsync(new Uri("https://api.openweathermap.org/data/2.5/forecast?q=Odessa,ua&appid=dac392b2d2745b3adf08ca26054d78c4&lang=ru&units=metric", UriKind.Absolute)));
                weather = reader.ReadLine();
                lastError = "successfuly";
            } catch (Exception e) {
                lastError = e.Message;
            }
        }

        public static DateTime FromUnixTime(long unixTime) {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

    }
}
