//===============================================================================
// 
//    数据层类的基类 
// 
//===============================================================================

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;



namespace RADinfo_MIS_COST.DataBaseClasses
{
    /// <summary>
    /// 数据库访问类
    /// </summary>
    public abstract class SQLHelper
    {
        protected SqlConnection Connection;
       
        private string connectionString;

        //定义两个构造函数
        public SQLHelper()
        { }

        public SQLHelper(string connString)
        {
            connectionString = connString;
            Connection = new SqlConnection(connectionString);
        }

        protected string ConnectionString
        {
            get { return connectionString; }
        }

       

        
        /// <summary>
        /// //根据制定的存储过程名称和参数生成对应的SQL命令对象
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private SqlCommand BuildQeryCommand(string storedProcName, SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = this.Connection;
            command.CommandText = "[" + storedProcName.Trim() + "]";
            command.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
            {
                foreach (SqlParameter p in parameters)
                {
                    command.Parameters.Add(p);
                }
            }
            return command;
        }

        //
        /// <summary>
        /// 执行不返回结果的存储过程
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <param name="rowsAffected"></param>
        /// <returns></returns>
        protected int RunProcedure(string storedProcName, SqlParameter[] parameters,out int rowsAffected)
        {
            int result;
            SqlCommand cmd = BuildQeryCommand(storedProcName,parameters);
            //添加返回值参数
            cmd.Parameters.Add(
                new SqlParameter(
                "@RETURN_VALUE",//参数名
                SqlDbType.Int,  //参数类型
                4,              //参数长度
                ParameterDirection.ReturnValue,   //参数方向
                false,                            //是否可以空
                ((System.Byte)(0)),               //精度
                ((System.Byte)(0)),               //小数位数
                "",                               //源列的名称
                DataRowVersion.Current,           //行版本
                null                              //参数值
                ));
            Connection.Open();
            rowsAffected = cmd.ExecuteNonQuery();
            result = (int)(cmd.Parameters["@RETURN_VALUE"].Value);
            Connection.Close();

            return result;
        }

        //
        /// <summary>
        /// 执行返回结果的存储过程，最后返回一个SqlDataReader对象
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected SqlDataReader RunProcedure(
            string storedProcName, SqlParameter[] parameters)
        {
            SqlDataReader reader;

            SqlCommand cmd = BuildQeryCommand(storedProcName, parameters);
            Connection.Open();
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

    }
}