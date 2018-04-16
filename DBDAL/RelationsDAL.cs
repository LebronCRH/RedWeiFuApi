using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using RADinfo_MIS_COST.Model;
using RADinfo_MIS_COST.DataBaseClasses;
using System.Collections;

namespace RADinfo_MIS_COST.DBDAL
{
    /// <summary>
    /// 用来访问Relations表的类
    /// </summary>
    public class RelationsDAL:SQLHelper
    {
        /// <summary>
        /// 构造函数，调用基类构造函数，使用指定的连接字符串创建数据连接对象
        /// </summary>
        /// <param name="connString"></param>
        public RelationsDAL(string connString)
            : base(connString)
        { }

        #region GetRelations
        /// <summary>
        /// 查询关联信息
        /// </summary>
        /// <param name="messageid"></param>
        /// <returns></returns>
        public ArrayList GetRelations(int messageid)
        {
            ArrayList lists = new ArrayList();
            SqlParameter[] parameters = { new SqlParameter("@messageid",SqlDbType.Int) };
            parameters[0].Value = messageid;
            SqlDataReader reader = RunProcedure("sp_S_Relations",parameters);
            while (reader.Read())
            {
                Messages model = new Messages();
                model.MessageId = Convert.ToInt32(reader["messageid"]);
                model.Title = reader["title"].ToString();
                lists.Add(model);
            }
            return lists;
        }
        #endregion

        #region Add
        /// <summary>
        /// 添加关联信息
        /// </summary>
        /// <param name="messageid">信息ID</param>
        /// <param name="messageid2">关联信息ID</param>
        /// <returns></returns>
        public int Add(int messageid,int messageid2)
        {
            int rowsAffected;
            SqlParameter[] parameters = { 
                                        new SqlParameter("@messageid",SqlDbType.Int),
                                        new SqlParameter("@messageid2",SqlDbType.Int),
                                        new SqlParameter("@id",SqlDbType.Int)
                                        };
            parameters[0].Value = messageid;
            parameters[1].Value = messageid2;
            parameters[2].Direction = ParameterDirection.Output;

            RunProcedure("sp_I_Relations", parameters, out rowsAffected);
            return Convert.ToInt32(parameters[2].Value);
        }
        #endregion

    }
}
