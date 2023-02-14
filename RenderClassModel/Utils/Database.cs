using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuongNn.Db
{
    public class Database
    {
        public string server { get; }
        public string user { get; }
        public string password { get; }
        public string database { get; }

        public Database()
        {
            server = "";
            user = "";
            password = "";
            database = "";
        }

        public Database(string server, string user, string password, string database)
        {
            this.server =  server;
            this.user = user;
            this.password = password;
            this.database = database;
        }

        public string SQLCONNECTION
        {
            set
            {
                SQLCONNECTION = value;
            }

            get
            {
                return string.Format(@"Data Source={0};Initial Catalog={1}; User Id={2}; Password={3};", server, database, user, password);
            }
        }

        public decimal GetFirstFieldDec(string sql, Dictionary<string, object> attrs = null)
        {
            string data = GetFirstFieldString(sql, attrs);
            return data.Length == 0 ? 0 : decimal.Parse(data);
        }

        public int GetFirstFieldInt(string sql, Dictionary<string, object> attrs = null)
        {
            string data = GetFirstFieldString(sql, attrs);
            return data.Length == 0 ? 0 : int.Parse(data);
        }

        public string GetFirstFieldString(string sql, Dictionary<string, object> attrs = null)
        {
            object data = GetFirstField(sql, attrs);
            return data == null ? "" : data.ToString();
        }

        public object GetFirstField(string sql, Dictionary<string, object> attrs = null)
        {
            DataTable dt = GetTable(sql, attrs);
            if (dt == null || dt.Rows.Count == 0) return null;
            return dt.Rows[0][0];
        }

        public DataRow GetFirstRow(string sql, Dictionary<string, object> attrs = null)
        {
            DataTable dt = GetTable(sql, attrs);
            if (dt == null || dt.Rows.Count == 0) return null;
            return dt.Rows[0];
        }

        public DataTable GetTable(string sql, Dictionary<string, object> attrs = null)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = new SqlConnection(SQLCONNECTION);
                if (sqlConn.State == ConnectionState.Closed) sqlConn.Open();
                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                BuildCmdParameter(cmd, attrs);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConn != null && sqlConn.State == ConnectionState.Open) sqlConn.Close();
            }
        }

        public int ExSql(string sql, Dictionary<string, object> attrs = null)
        {
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = new SqlConnection(SQLCONNECTION);
                if (sqlConn.State == ConnectionState.Closed) sqlConn.Open();
                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                BuildCmdParameter(cmd, attrs);
                int countRows = cmd.ExecuteNonQuery();
                if (sqlConn.State == ConnectionState.Open) sqlConn.Close();
                return countRows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConn != null && sqlConn.State == ConnectionState.Open) sqlConn.Close();
            }
        }

        private void BuildCmdParameter(SqlCommand cmd, Dictionary<string, object> attrs)
        {
            if (attrs != null)
            {
                foreach (string key in attrs.Keys)
                {
                    object value = attrs[key];
                    if (value == null) continue;
                    Type typeData = value.GetType();
                    if (typeData == typeof(int)) cmd.Parameters.Add(key, SqlDbType.Int).Value = attrs[key];
                    else if (typeData == typeof(decimal)) cmd.Parameters.Add(key, SqlDbType.Decimal).Value = attrs[key];
                    else if (typeData == typeof(string)) cmd.Parameters.Add(key, SqlDbType.NVarChar).Value = attrs[key];
                    else if (typeData == typeof(DateTime)) cmd.Parameters.Add(key, SqlDbType.Date).Value = attrs[key];
                }
            }
        }
    }
}