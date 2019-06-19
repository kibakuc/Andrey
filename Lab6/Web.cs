using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Lab6 {
    class Web {
        string strurl;


        public string Strurl { get => strurl; set => strurl = value; }
        public string[] arr = new string[26];

        public Web(string strurl) {
            Strurl = strurl;

            WebClient c = new WebClient();
            string json = @"[" + c.DownloadString(Strurl).Replace("[", "").Replace("]", "") + "]";

            Console.WriteLine(json);

            JArray blogPostArray = JArray.Parse(json);
            IList<BlogPost> blogPosts = blogPostArray.Select(p => new BlogPost {
                Coordlon = (string)p["coord"]["lon"],
                Coordlat = (string)p["coord"]["lat"],
                Weatherid = (string)p["weather"]["id"],
                Weathermain = (string)p["weather"]["main"],
                Weatherdescription = (string)p["weather"]["description"],
                Weathericon = (string)p["weather"]["icon"],
                Sbase = (string)p["base"],
                Maintemp = (string)p["main"]["temp"],
                Mainpressure = (string)p["main"]["pressure"],
                Mainhumidity = (string)p["main"]["humidity"],
                Maintemp_min = (string)p["main"]["temp_min"],
                Maintemp_max = (string)p["main"]["temp_max"],
                Visibility = (string)p["visibility"],
                Windspeed = (string)p["wind"]["speed"],
                Winddeg = (string)p["wind"]["deg"],
                Cloudsall = (string)p["clouds"]["all"],
                Dt = (string)p["dt"],
                Systype = (string)p["sys"]["type"],
                Sysid = (string)p["sys"]["id"],
                Sysmessage = (string)p["sys"]["message"],
                Syscountry = (string)p["sys"]["country"],
                Syssunrise = (string)p["sys"]["sunrise"],
                Syssunset = (string)p["sys"]["sunset"],
                Timezone = (string)p["timezone"],
                Id = (string)p["id"],
                Name = (string)p["name"],
                Cod = (string)p["cod"]
            }).ToList();
            arr[0] = blogPosts[0].Coordlon;
            arr[1] = blogPosts[0].Coordlat;
            arr[2] = blogPosts[0].Weatherid;
            arr[3] = blogPosts[0].Weatherdescription;
            arr[4] = blogPosts[0].Weathericon;
            arr[5] = blogPosts[0].Sbase;
            arr[6] = blogPosts[0].Maintemp;
            arr[7] = blogPosts[0].Mainpressure;
            arr[8] = blogPosts[0].Mainhumidity;
            arr[9] = blogPosts[0].Maintemp_min;
            arr[10] = blogPosts[0].Maintemp_max;
            arr[11] = blogPosts[0].Visibility;
            arr[12] = blogPosts[0].Windspeed;
            arr[13] = blogPosts[0].Winddeg;
            arr[14] = blogPosts[0].Cloudsall;
            arr[15] = blogPosts[0].Dt;
            arr[16] = blogPosts[0].Systype;
            arr[17] = blogPosts[0].Sysid;
            arr[18] = blogPosts[0].Sysmessage;
            arr[19] = blogPosts[0].Syscountry;
            arr[20] = blogPosts[0].Syssunrise;
            arr[21] = blogPosts[0].Syssunset;
            arr[22] = blogPosts[0].Timezone;
            arr[23] = blogPosts[0].Id;
            arr[24] = blogPosts[0].Name;
            arr[25] = blogPosts[0].Cod;
        }

        public DateTime FromUnixTime(long unixTime) {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

    }
}
