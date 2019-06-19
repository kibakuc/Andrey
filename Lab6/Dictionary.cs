using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6 {
    class Dictionary {

        public enum Overcast_enum {
            /*Облачность: Не определено(если информация не занесена), Ясно, Малооблачно, Облачно, Грозовые тучи.*/
            undefined,
            clear,
            partly_cloudy,
            cloudy,
            thunderclouds
        }
        public enum Precipitation_enum {
            /*Осадки: Не определено (если информация не занесена), Дождь, Снег, Дождь со снегом, Град, Снежная крупа, Роса, Иней, Изморозь, Гололед, Ледяные иглы*/
            undefined, rain, snow, rainwithsnow, hail, snowpellets, dew, hoarfrost, rime, ice, iceneedles
        }
        public enum Directionwind_enum {
            /*Направление ветра: Не определено (если информация не занесена), Север, Северо- восток, Восток, Юго-восток, Юг, Юго-запад, Запад, Северо-запад.*/
            undefined, north, northeast, east, southeast, south, southwest, west, northwest
        }
        public enum Moonphase_enum {
            /*Фаза луны: Не определено (если информация не занесена), Новолуние, Растущая, Полнолуние, Убывающая.*/
            undefined, newmoon, growing, fullMoon, waning
        }
    }
}
