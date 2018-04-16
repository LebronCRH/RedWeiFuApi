using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;
using Qing;


namespace DataBaseClasses
{
    public abstract class MySqlHelper
    {
        private static string _connectionstring = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        public static DataTable mySqlExecuteQuery(string sql, MySqlParameter[] parametes, bool isProc)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection())
                {

                    con.ConnectionString = _connectionstring;
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.CommandType = (isProc) ? CommandType.StoredProcedure : CommandType.Text;
                    if (parametes != null)
                    {
                        foreach (MySqlParameter p in parametes)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dt);
                    return dt;
                }

            }
            catch (Exception ee)
            {
                return dt;

            }

        }

        public static int mySqlExecuteNonQuery(string sql, MySqlParameter[] parametes, bool isProc)
        {
            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = _connectionstring;
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = (isProc) ? CommandType.StoredProcedure : CommandType.Text;
                if (parametes != null)
                {
                    foreach (MySqlParameter p in parametes)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                return cmd.ExecuteNonQuery();
            }
        }



        public static object ExecuteScalar(string sql, SqlParameter[] parametes, bool isProc)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = _connectionstring;
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = (isProc) ? CommandType.StoredProcedure : CommandType.Text;
                if (parametes != null)
                {
                    foreach (SqlParameter p in parametes)
                    {
                        cmd.Parameters.Add(p);
                    }
                }

                return cmd.ExecuteScalar();
            }
        }

        public static SqlDataReader ExecuteReader(string sql, SqlParameter[] parametes, bool isProc)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = _connectionstring;
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = (isProc) ? CommandType.StoredProcedure : CommandType.Text;
                if (parametes != null)
                {
                    foreach (SqlParameter p in parametes)
                    {
                        cmd.Parameters.Add(p);
                    }
                }

                return cmd.ExecuteReader();
            }
        }
    }
}
