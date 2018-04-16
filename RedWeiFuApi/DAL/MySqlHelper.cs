using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.Web;
using MySql.Data.MySqlClient;

namespace RedWeiFuApi.DAL
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

        public static object ExecuteScalar(string sql, MySqlParameter[] parametes, bool isProc)
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
                var val = cmd.ExecuteScalar();
                return val;
            }
        }

        public static MySqlDataReader ExecuteReader(string sql, MySqlParameter[] parametes, bool isProc)
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

                return cmd.ExecuteReader();
            }
        }
    }
}