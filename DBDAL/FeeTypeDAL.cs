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
    public class FeeTypeDAL:SQLHelper
    {
               /// <summary>
        /// 构造函数，调用基类构造函数，使用指定的连接字符串创建数据连接对象
        /// </summary>
        /// <param name="connString"></param>
        public FeeTypeDAL(string connString)
            : base(connString)
        { }

        #region Add
        /// <summary>
        /// 添加数据 
        /// </summary>
        /// <param name="feeid"></param>
        /// <param name="feetypename"></param>
        /// <param name="feetype_desc"></param>
        /// <returns></returns>
        public int Add(string feeid,string feetypename,string feetype_desc)
        { 
            int rowsAffected;
            SqlParameter[] parameters={
                                      new SqlParameter("@feeid",SqlDbType.VarChar),
                                      new SqlParameter("@feetypename",SqlDbType.VarChar),
                                      new SqlParameter("@feetype_desc",SqlDbType.VarChar),
                                      new SqlParameter("@id",SqlDbType.Int)
                                      };
            parameters[0].Value=feeid;
            parameters[1].Value=feetypename;
            parameters[2].Value=feetype_desc;
            parameters[3].Direction=ParameterDirection.Output;
            RunProcedure("sp_I_FeeType", parameters, out rowsAffected);
            return Convert.ToInt32(parameters[3].Value);
        }
        #endregion

        #region Select
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="feetypename"></param>
        /// <returns></returns>
        public ArrayList Select(string feetypename,string id)
        {
            ArrayList lists = new ArrayList();
            SqlParameter[] parameters={
                                      new SqlParameter("@feetypename",SqlDbType.VarChar),
                                      new SqlParameter("@id",SqlDbType.VarChar)
                                      };
            parameters[0].Value=feetypename;
            parameters[1].Value = id;
            SqlDataReader reader= RunProcedure("sp_S_FeeType",parameters);
            while (reader.Read())
            {
                FeeType model = new FeeType();
                model.Feeid = Convert.ToString(reader["feeid"]);
                model.Feetypename = Convert.ToString(reader["feetypename"]);
                model.Feetype_desc = Convert.ToString(reader["feetype_desc"]);
                model.Id = Convert.ToInt32(reader["id"]);
                lists.Add(model);
            }
            return lists;
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除制定数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            int rowsAffected;
            SqlParameter[] parameters = { 
                                        new SqlParameter("@id",SqlDbType.Int)
                                        };
            parameters[0].Value = id;
            RunProcedure("sp_D_FeeType",parameters,out rowsAffected);
            return (rowsAffected == 1);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="feeid"></param>
        /// <param name="feetypename"></param>
        /// <param name="feetype_desc"></param>
        /// <returns></returns>
        public bool Update(int id,string feeid,string feetypename,string feetype_desc)
        {
            int rowsAffected;
            SqlParameter[] parameters={
                                        new SqlParameter("@feeid",SqlDbType.VarChar),
                                        new SqlParameter("@feetypename",SqlDbType.VarChar),
                                        new SqlParameter("@feetype_desc",SqlDbType.VarChar),
                                        new SqlParameter("@id",SqlDbType.Int)
                                      };
            parameters[0].Value=feeid;
            parameters[1].Value=feetypename;
            parameters[2].Value=feetype_desc;
            parameters[3].Value=id;
            RunProcedure("sp_U_FeeType",parameters,out rowsAffected);
            return (rowsAffected == 1);
        }

        #endregion

    }
}
