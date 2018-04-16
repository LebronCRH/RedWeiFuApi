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
    /// 用来访问MasterGroup表的类
    /// </summary>
    public class MasterGroupDAL:SQLHelper
    {
         /// <summary>
        /// 构造函数，调用基类构造函数，使用指定的连接字符串创建数据连接对象
        /// </summary>
        /// <param name="connString"></param>
        public MasterGroupDAL(string connString)
            : base(connString)
        { }

        #region Add
        /// <summary>
        /// 添加管理组（角色）分配 
        /// </summary>
        /// <returns></returns>
        public int Add(int masterid,string mastername,int groupid,int masterid2,string mastername2,DateTime createdate)
        {
            int rowAffected;

            SqlParameter[] parameters =
                {
                    new SqlParameter("@masterid",SqlDbType.Int),
                    new SqlParameter("@mastername",SqlDbType.VarChar),
                    new SqlParameter("@groupid",SqlDbType.Int),
                    new SqlParameter("@masterid2",SqlDbType.Int),
                    new SqlParameter("@mastername2",SqlDbType.VarChar),
                    new SqlParameter("@createdate",SqlDbType.DateTime),
                    new SqlParameter("@id",SqlDbType.Int)
                };
            parameters[0].Value = masterid;
            parameters[1].Value = mastername;
            parameters[2].Value = groupid;
            parameters[3].Value = masterid2;
            parameters[4].Value = mastername2;
            parameters[5].Value = createdate;
            parameters[6].Direction = ParameterDirection.Output;

            RunProcedure("sp_InsertMasterGroup",parameters,out rowAffected);
            return (int)parameters[6].Value;
        }
        #endregion
    }
}
