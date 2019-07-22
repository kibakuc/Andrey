using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;

namespace acc2prj {
    class FBDatabase : IDisposable {
        private string ConnectionString;
        FbConnection conn;
        private bool disposed = false;

        public FBDatabase() // пассивный конструктор
        {
            ConnectionString = "";
        }
        public FBDatabase(String ConnStr) {
            ConnectionString = ConnStr;
        }
        public void OpenConection() {
            conn = new FbConnection(ConnectionString);
            conn.Open();
        }
        public void CloseConnection() {
            conn.Close();
        }
        public void ExecuteQueries(string SqlStr) {
            //FbParameter
            FbTransaction tran = conn.BeginTransaction();
            FbCommand cmd = new FbCommand(SqlStr, conn, tran);
            cmd.ExecuteNonQuery();
        }
        public FbCommand ReturnFbCommand(string SqlStr) {
            FbTransaction tran = conn.BeginTransaction();
            FbCommand cmd = new FbCommand(SqlStr, conn, tran);
            return cmd;
        }

        // название процедуры
        //FbTransaction trn = fb.BeginTransaction();
        //FbCommand prc = new FbCommand("PR_ADD_ITEM", fb, trn);
        //try
        //{
        //prc.CommandType = System.Data.CommandType.StoredProcedure;
        //prc.Parameters.Add("@p_cur_date", FbDbType.Date).Value = "1901.01.01";
        //prc.Parameters.Add("@p_name", FbDbType.VarChar).Value = "впааппап";
        //prc.Parameters.Add("@p_matcol", FbDbType.Integer).Value = "1214";
        //prc.Parameters.Add("@p_matcen", FbDbType.Float).Value = "16";
        //prc.Prepare();
        //prc.ExecuteNonQuery(); 
        //trn.Commit();
        //}catch (FbException){ //catch (SqlException sqlError)
        //  trn.Rollback();
        //  throw;
        //}finally{
        //  trn.Dispose();
        //  fb.Close();
        //}

        //string sqlExpression = "sp_InsertUser";
        //cmd.CommandText = sqlExpression;
        //cmd.Transaction = tran;
        // указываем, что команда представляет хранимую процедуру
        //cmd.CommandType = System.Data.CommandType.StoredProcedure;
        // параметр для ввода имени
        //FbParameter nameParam = new FbParameter
        //{
        //    ParameterName = "@name",
        //    Value = name
        //};
        // добавляем параметр
        //cmd.Parameters.Add(nameParam);
        // добавляем параметр
        //cmd.Parameters.Add(nameParam);
        // параметр для ввода возраста
        //FbParameter ageParam = new FbParameter
        //{
        //    ParameterName = "@age",
        //    Value = age
        //};
        //cmd.Parameters.Add(ageParam);

        //var result = cmd.ExecuteScalar();
        //var result = cmd.ExecuteReader();
        // если нам не надо возвращать id

        //var result = cmd.ExecuteNonQuery();
        //tran.Commit();
        //tran.Rollback();

        public FbDataReader DataReader(string SqlStr) {
            FbTransaction tran = conn.BeginTransaction();
            FbCommand cmd = new FbCommand(SqlStr, conn, tran);
            FbDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public object ShowDataInGridView(string SqlStr) {
            FbDataAdapter dr = new FbDataAdapter(SqlStr, ConnectionString);
            DataSet ds = new DataSet();
            dr.Fill(ds); // Заполняем Dataset
            object dataum = ds.Tables[0];
            return dataum;
        }
        ~FBDatabase() {
            //Console.WriteLine("Finalized");
            this.Dispose();
        }
        public void Dispose() {
            if (!this.disposed) {
                conn.Dispose();
            }
            this.disposed = true;
            GC.SuppressFinalize(this);
        }

    }
}
