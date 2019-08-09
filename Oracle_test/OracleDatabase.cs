using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Data;
using System.Collections;

namespace Oracle_test {

    //https://www.oracle.com/webfolder/technetwork/tutorials/obe/db/dotnet/GettingStartedNETVersion/GettingStartedNETVersion.htm
    //https://o7planning.org/ru/10519/working-with-oracle-database-using-csharp#a1815145
    //https://docs.microsoft.com/en-us/dotnet/api/system.data.oracleclient.oracletransaction?view=netframework-4.8
    //https://pravsdatums.wordpress.com/2014/01/30/simple-dataaccess-class-for-c-and-oracle/
    //https://codereview.stackexchange.com/questions/194954/calling-an-oracle-stored-procedure-with-c-code
    //https://www.c-sharpcorner.com/article/calling-oracle-stored-procedures-from-microsoft-net/
    //https://stackoverflow.com/questions/31168652/how-can-i-call-a-oracle-connection-method-in-c-sharp-with-paramaters
    //https://csharp.hotexamples.com/ru/site/file?hash=0xac08661749b3b119fc40d702d2367caa9b0fe6bc7e6a8c1fc334cb916883dfe1&fullName=OrclDBManager.cs&project=hahaer222/EvaluationSys

    class AddParametrs {
        string name;
        object val;
        OracleType type;
        ParameterDirection direction;



        public AddParametrs(string name, object val, OracleType type, ParameterDirection direction) {
            Name = name;
            Val = val;
            Type = type;
            Direction = direction;
        }

        public string Name { get => name; set => name = value; }
        public object Val { get => val; set => val = value; }
        public OracleType Type { get => type; set => type = value; }
        public ParameterDirection Direction { get => direction; set => direction = value; }
    }

    class OracleClient {
        private string connectionstring;
        //private bool disposed = false;

        [Obsolete]
        private static OracleConnection conn = null;

        //[Obsolete]
        //private OracleCommand cmd = null;
        //private OracleTransaction tran = null;


        public OracleClient() {
        }

        public OracleClient(string alias, string user, string password) {
            this.connectionstring = "Data Source=" + alias + ";User Id=" + user + ";Password=" + password + ";";
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
            if (conn.State == System.Data.ConnectionState.Open) {
                conn.Close();
                conn.Dispose();
            }
        }

        public void AddParameter(string name, object value, OracleType oracleType, OracleParameterCollection parameters) {
            OracleParameter p = new OracleParameter(name, oracleType);
            p.Direction = ParameterDirection.Input;
            p.ParameterName = name;
            p.OracleType = oracleType;
            p.Value = value;
            parameters.Add(p);
        }

        [Obsolete]
        public OracleDataReader OracleExecuteQuery(string SqlStr, ArrayList parameters = null) {
            OracleCommand cmd = new OracleCommand(SqlStr, conn);
            cmd.CommandText = SqlStr;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            if (parameters != null) {
                OracleParameterCollection prm = cmd.Parameters;
                foreach (var param in parameters) {
                    //int q = parameters.IndexOf(param);
                    OracleParameter p = new OracleParameter();
                    p.Direction = ((AddParametrs)(param)).Direction;
                    p.ParameterName = ((AddParametrs)(param)).Name;
                    p.OracleType = ((AddParametrs)(param)).Type;
                    p.Value = ((AddParametrs)(param)).Val;
                    prm.Add(p);
                }
            }
            cmd.Prepare();

            OracleDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
                return rdr;
            return null;
        }

        [Obsolete]
        public object OracleExecuteNonQuery(OracleTransaction tran, string SqlStr, ArrayList parameters = null) {
            //OracleTransaction tran = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand(SqlStr, conn);
            cmd.Transaction = tran;
            try {
                cmd.CommandText = SqlStr;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                string prmName = null;
                if (parameters != null) {
                    OracleParameterCollection prm = cmd.Parameters;
                    foreach (var param in parameters) {
                        //int q = parameters.IndexOf(param);
                        OracleParameter p = new OracleParameter();
                        p.Direction = ((AddParametrs)(param)).Direction;
                        p.ParameterName = ((AddParametrs)(param)).Name;
                        if (p.Direction != ParameterDirection.Input) {
                            prmName = ((AddParametrs)(param)).Name;
                        }
                        p.OracleType = ((AddParametrs)(param)).Type;
                        p.Value = ((AddParametrs)(param)).Val;
                        prm.Add(p);
                    }

                }

                cmd.ExecuteNonQuery();
                if (!string.IsNullOrEmpty(prmName))
                    return cmd.Parameters[prmName].Value;
                return null;
                //tran.Commit();
            } catch (Exception e) {
                return -1;
                //tran.Rollback();
            } finally {
                cmd.Parameters.Clear();
                cmd.Dispose();
                //tran.Dispose();
            }

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
