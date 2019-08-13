using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13 {
    class Program {
        static void Main(string[] args) {
            GetWeather.GetWeatherDataAsync().Wait();

            /*
            //JObject details = JObject.Parse(GetWeather.weather);
            //Console.WriteLine(details);
            //Console.WriteLine("Async data load: " + GetWeather.lastError);
            //Console.WriteLine(GetWeather.weather);
            JObject details = JObject.Parse(GetWeather.weather);
            //Console.WriteLine(details);
            Console.WriteLine(details.GetValue("city").Value<String>("name"));
            Console.WriteLine(details.GetValue("city").Value<String>("country"));

            Console.WriteLine(details.GetValue("list").ToList<JToken>().Count);

            Console.WriteLine(details.GetValue("list")[0]);

            JObject list_result = (JObject)details.GetValue("list")[0];
            Console.WriteLine(list_result.GetValue("main").Value<String>("temp"));

            Console.WriteLine(list_result.GetValue("clouds").Value<String>("all"));


            //Console.WriteLine(list_result.GetValue("weather").ToList<JToken>().Count);
            //Console.WriteLine(list_result.GetValue("weather"));

            //JObject weather_result = (JObject)list_result.GetValue("weather")[0];
            //Console.WriteLine(weather_result.GetValue("id"));
            */

            Rootobject data = JsonConvert.DeserializeObject<Rootobject>(GetWeather.weather);
            Console.WriteLine($"{data.cod} {data.message} {data.cnt}");
            Console.WriteLine($"{ data.city.id} {data.city.name} {data.city.country} {data.city.coord.lat} - {data.city.coord.lon} {data.city.population} {data.city.timezone}");
            Console.WriteLine("-------------");

            foreach (var item in data.list) {
                Console.WriteLine(GetWeather.FromUnixTime(Convert.ToInt32(item.dt)));
                Console.WriteLine($"{item.main.temp} {item.main.temp_min} {item.main.temp_max} {item.main.pressure} {item.main.sea_level} {item.main.grnd_level} {item.main.humidity} {item.main.temp_kf}");
                foreach (var w in item.weather) {
                    Console.WriteLine($"{w.id} {w.main} {w.description} {w.icon}");
                }
                //Console.WriteLine($"{item.clouds.all} {item.wind.speed} {item.wind.deg} {item.sys.pod} {DateTime.ParseExact((item.dt_txt, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToString()}");
                Console.WriteLine($"{item.clouds.all} {item.wind.speed} {item.wind.deg} {item.sys.pod} {DateTime.ParseExact(item.dt_txt, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.GetCultureInfo("uk-UA")).ToString()}");
                Console.WriteLine("-------------");
            }

        }
    }
}
