//using Oracle.ManagedDataAccess.Client;
//using Oracle.DataAccess.Client;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;

namespace Oracle_test {
    class Program {

        [Obsolete]
        static void Main(string[] args) {
            OracleClient Db = new OracleClient("SRTEST2", "ISCARDUSER", "Gbr18k6P");
            //OracleClient Db = new OracleClient("sbdp-center-o07.bank.lan", "1521", "srtest2", "ISCARDUSER", "Gbr18k6P");
            OracleConnection conn = Db.OpenConection();
            Console.WriteLine("State: {0}", conn.State);


            Db.CloseConnection();
            Console.WriteLine("State: {0}", conn.State);

        }

    }
}
