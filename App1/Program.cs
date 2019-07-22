using Echovoice.JSON;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1 {
    class Wrapper {
        public string StyleNumber { get; set; }
        public string ColorLongDesc { get; set; }
        public string DistroDesc { get; set; }
        public string Status { get; set; }
    }
    class Program {
        static void Main(string[] args) {

            List<Wrapper> respmsg = new List<Wrapper>();
            respmsg.Add(new Wrapper { ColorLongDesc = "BLUE", StyleNumber = "124578", DistroDesc = "MARIO BRACKEN", Status = "SUCCESS" });
            //respmsg.Add(new Wrapper { ColorLongDesc = "BLUE", StyleNumber = "124578", DistroDesc = "MARIO BRACKEN", Status = "SUCCESS" });
            string sJSONResponse = JsonConvert.SerializeObject(respmsg);
            Console.WriteLine(sJSONResponse);

            string[] result = JSONDecoders.DecodeJsStringArray(sJSONResponse);
            string result1 = JSONEncoders.EncodeJsObjectArray(result);
            Console.WriteLine(result1);

            string math = "((100 * 5) - 2)";
            string value = new DataTable().Compute(math, null).ToString();
            Console.WriteLine(value);
        }
    }
}
