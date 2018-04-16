using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using RADinfo_MIS_COST.Model;
using RADinfo_MIS_COST.DataBaseClasses;

namespace RADinfo_MIS_COST.DBDAL
{
    /// <summary>
    /// 用来访问ActionGroup
    /// </summary>
    public class ActionGroupDAL:SQLHelper
    {
        /// <summary>
        /// 构造函数，调用基类构造函数，使用指定的连接字符串创建数据连接对象
        /// </summary>
        /// <param name="connString"></param>
        public ActionGroupDAL(string connString)
            : base(connString)
        { 
        }

        #region Add

        public int Add(int actionid,int groupid,int masterid,string mastername,DateTime createdate)
        {
            int rowsAffected;
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@actionid",SqlDbType.Int),
                    new SqlParameter("@groupid",SqlDbType.Int),
                    new SqlParameter("@masterid",SqlDbType.Int),
                    new SqlParameter("@mastername",SqlDbType.VarChar),
                    new SqlParameter("@createdate",SqlDbType.VarChar),
                    new SqlParameter("@id",SqlDbType.Int)
                };
            parameters[0].Value = actionid;
            parameters[1].Value = groupid;
            parameters[2].Value = masterid;
            parameters[3].Value = mastername;
            parameters[4].Value = createdate;
            parameters[5].Direction = ParameterDirection.Output;

            RunProcedure("sp_InsertActionGroup",parameters, out rowsAffected);
            return (int)parameters[5].Value;
        }
        #endregion

    }
}
