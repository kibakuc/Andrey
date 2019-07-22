using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;

namespace Oracle_test {

    //https://www.oracle.com/webfolder/technetwork/tutorials/obe/db/dotnet/GettingStartedNETVersion/GettingStartedNETVersion.htm
    //https://o7planning.org/ru/10519/working-with-oracle-database-using-csharp#a1815145
    //https://docs.microsoft.com/en-us/dotnet/api/system.data.oracleclient.oracletransaction?view=netframework-4.8
    //https://pravsdatums.wordpress.com/2014/01/30/simple-dataaccess-class-for-c-and-oracle/
    //https://codereview.stackexchange.com/questions/194954/calling-an-oracle-stored-procedure-with-c-code
    //https://www.c-sharpcorner.com/article/calling-oracle-stored-procedures-from-microsoft-net/
    //https://stackoverflow.com/questions/31168652/how-can-i-call-a-oracle-connection-method-in-c-sharp-with-paramaters

    class OracleClient {
        private string connectionstring;
        private bool disposed = false;

        [Obsolete]
        private static OracleConnection conn = null;
        [Obsolete]
        private OracleCommand cmd = null;
        private OracleTransaction tran = null;


        public OracleClient() {
        }

        public OracleClient(string datasource, string user, string password) {
            this.connectionstring = "Data Source=" + datasource + ";User Id=" + user + ";Password=" + password + ";";
        }

        public OracleClient(string host, string port, string sid, string user, string password) {
            this.connectionstring = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;
        }

        [Obsolete]
        public OracleConnection OpenConection() {
            try {
                if ((conn == null) || (conn.State == System.Data.ConnectionState.Closed)) {
                    conn = new OracleConnection(this.connectionstring);
                    conn.Open();
                    //OracleGlobalization oracleSession = conn.GetSessionInfo();
                    //oracleSession.DateFormat = "dd.mm.yyyy hh24:mi:ss";
                    //conne.SetSessionInfo(oracleSession);
                    return conn;
                }
                return null;
            } catch (Exception) {
                return null;
            }
        }

        [Obsolete]
        public void CloseConnection() {
            conn.Close();
        }

        [Obsolete]
        public OracleCommand CommandOracle(string SqlStr) {
            cmd = new OracleCommand(SqlStr, conn);
            return cmd;
        }

        /*
                [Obsolete]
                public void Dispose() {
                    if (!this.disposed) {
                        //cmd.Parameters.Clear();
                        //cmd.Dispose();
                        //tran.Dispose();
                        conn.Close();
                        conn.Dispose();
                    }
                    this.disposed = true;
                    GC.SuppressFinalize(this);
                }
        */
        /*      

        OracleTransaction tran;
        tran = conn.BeginTransaction(IsolationLevel.ReadCommitted);
        cmd.Transaction = tran;
        try {
            cmd.CommandText = "INSERT INTO Dept (DeptNo, Dname, Loc) values (50, 'TECHNOLOGY', 'DENVER')";
            cmd.ExecuteNonQuery();
            tran.Commit();
        } catch (Exception e) {
            transaction.Rollback();
        }
*/

    }
}
