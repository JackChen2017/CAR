using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace FounderTecInfoSys.Addin.CAR.ChildApproval
{
    public class DBHelper
    {
        public enum DBHost
        {
            富山 = 1,
            多层 = 2,
            越亚 = 3,
            速能 = 4,
            重庆 = 5,
            快板 = 6,
            报表 = 7,
            运营平台 = 98,
            测试区越亚 = 99,
            测试区人力 = 100
        }

        public DBHelper(int fid)
        {
            FID = fid;
        }

        private SqlConnection connection;
        private int fid;
        public int FID
        {
            get { return fid; }
            set { fid = value; }
        }
        public SqlConnection Connection
        {
            get
            {

                if (connection == null)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings[fid.ToString()].ConnectionString;
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
        }

        public int ExecuteCommand(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            int result = cmd.ExecuteNonQuery();
            return result;
        }

        public int ExecuteCommand(string sql, params SqlParameter[] values)
        {

            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            int result = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return result;
        }
        ///<sumary>
        ///执行存储过程
        ///</sumary>
        public int ExecuteCommandProc(string sql, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(values);
            cmd.ExecuteNonQuery();
            int result = 0;
            result = int.Parse(cmd.Parameters["@returnID"].Value.ToString());
            ///cmd.Parameters.Clear();
            return result;
        }

        public int GetScalar(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }

        public int GetScalar(string sql, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Parameters.Clear();
            return result;
        }

        public SqlDataReader GetReader(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public SqlDataReader GetReader(string sql, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            SqlDataReader reader = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            return reader;
        }

        public DataTable GetDataSet(string safeSql)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }

        public DataTable GetDataSet(string sql, params SqlParameter[] values)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            cmd.Parameters.Clear();
            return ds.Tables[0];
        }

        public void CloseConnection()
        {
            if (connection != null)
            {
                try
                {
                    connection.Close();
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
