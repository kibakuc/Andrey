using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6 {
    class Weather {
        /*Решить задачу хранения информации о погоде в виде класса с полями:*/
        DateTime dat;           //дата
        int tmin;               //температура минимальная  
        int tmax;               //температура максимальная   
        string overcast;        //облачность enum 
        string precipitation;   //осадки     enum  
        int humidity;           //влажность
        int windforce;          //сила ветра
        string directionwind;   //направление ветра enum
        string moonphase;       //фаза луны         enum


        public DateTime Dat { get => dat; set => dat = value; }
        public int Tmin { get => tmin; set => tmin = value; }
        public int Tmax { get => tmax; set => tmax = value; }
        public string Overcast { get => overcast; set => overcast = value; }
        public string Precipitation { get => precipitation; set => precipitation = value; }
        public int Humidity { get => humidity; set => humidity = value; }
        public int Windforce { get => windforce; set => windforce = value; }
        public string Directionwind { get => directionwind; set => directionwind = value; }
        public string Moonphase { get => moonphase; set => moonphase = value; }

        public Weather(DateTime dat, int tmin, int tmax, string overcast, string precipitation, int humidity, int windforce, string directionwind, string moonphase) {
            Dat = dat;
            Tmin = tmin;
            Tmax = tmax;
            Overcast = overcast;
            Precipitation = precipitation;
            Humidity = humidity;
            Windforce = windforce;
            Directionwind = directionwind;
            Moonphase = moonphase;
        }

        public override string ToString() {
            string result = "";
            result += "Дата " + Dat.ToString() + "\n";
            result += "Температура минимальная " + Tmin + "\n";
            result += "Температура максимальная " + Tmax + "\n";
            result += "Облачность " + Overcast + "\n";
            result += "Осадки " + Precipitation + "\n";
            result += "Влажность " + Humidity + "\n";
            result += "Сила ветра " + Windforce + "\n";
            result += "Направление ветра " + Directionwind + "\n";
            result += "Фаза луны " + Moonphase + "\n";
            return result;
        }
    }
}
