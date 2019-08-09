//using Oracle.ManagedDataAccess.Client;
//using Oracle.DataAccess.Client;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Data;
using System.Collections;

namespace Oracle_test {
    class Program {

        [Obsolete]
        static void Main(string[] args) {

            OracleClient Db = new OracleClient("SRTEST2", "ISCARDUSER", "Gbr18k6P");
            //OracleClient Db = new OracleClient("sbdp-center-o07.bank.lan", "1521", "srtest2", "ISCARDUSER", "Gbr18k6P");
            OracleConnection conn = Db.OpenConection();
            Console.WriteLine("State: {0}", conn.State);

            ArrayList param = new ArrayList();
            param.Add(new AddParametrs("I_ID", 5244, OracleType.Int32, ParameterDirection.Input));
            param.Add(new AddParametrs("I_REF_ROLE", 3724, OracleType.Int32, ParameterDirection.Input));

            //OracleCommand cmd = new OracleCommand();
            //cmd.Connection = conn;
            //cmd.CommandText = strSql;
            //cmd.CommandType = CommandType.Text;
            //OracleParameterCollection prm = cmd.Parameters;
            //Db.AddParameter("I_ID", 5244, OracleType.Int32, prm);
            //Db.AddParameter("I_REF_ROLE", 3724, OracleType.Int32, prm);
            //cmd.Prepare();
            //OracleDataReader dr = cmd.ExecuteReader();

            string strSql = "select t.* from SR_BANK.SR_USER t where t.ID =:I_ID and t.REF_ROLE =:I_REF_ROLE";
            //string strSql = "select t.* from SR_BANK.SR_USER t";

            OracleDataReader dr = Db.OracleExecuteQuery(strSql, param);
            while (dr.Read()) {
                Console.Write("{0}\t{1} \n", dr[0], dr[1]);
            }
            dr.Close();

            Db.CloseConnection();
            Console.WriteLine("State: {0}", conn.State);
        }
    }
}
