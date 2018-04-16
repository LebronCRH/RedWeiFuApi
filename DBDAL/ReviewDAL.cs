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
    /// 用来访问Review表的类
    /// </summary>
    public class ReviewDAL : SQLHelper
    {
         /// <summary>
        /// 构造函数，调用基类构造函数，使用指定的连接字符串创建数据连接对象
        /// </summary>
        /// <param name="connString"></param>
        public ReviewDAL(string connString)
            : base(connString)
        { }

        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="feeappid"></param>
        /// <param name="mastername"></param>
        /// <param name="reviewtime"></param>
        /// <param name="advice"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int Add(int feeappid,int masterid, string mastername, DateTime reviewtime, string advice, bool state)
        {
            int rowsAffected;
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@feeappid",SqlDbType.Int),
                    new SqlParameter("@masterid",SqlDbType.Int),
                    new SqlParameter("@mastername",SqlDbType.VarChar),
                    new SqlParameter("@reviewtime",SqlDbType.DateTime),
                    new SqlParameter("@advice",SqlDbType.VarChar),
                    new SqlParameter("@state",SqlDbType.Bit),
                    new SqlParameter("@id",SqlDbType.Int)
                };
            parameters[0].Value = feeappid;
            parameters[1].Value = masterid;
            parameters[2].Value = mastername;
            parameters[3].Value = reviewtime;
            parameters[4].Value = advice;
            parameters[5].Value = state;
            parameters[6].Direction = ParameterDirection.Output;

            RunProcedure("sp_InsertReview",parameters,out rowsAffected);
            return (int)rowsAffected;
        }

        /// <summary>
        /// 查询副总经理是否审核通过
        /// </summary>
        /// <param name="feeappid"></param>
        /// <returns></returns>
        public bool GetFZstate(int feeappid)
        {
            bool state=false;
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@feeappid",SqlDbType.Int)
                };
            parameters[0].Value = feeappid;

            SqlDataReader reader =
                RunProcedure("sp_GetFZstate",parameters);
            if (reader.Read())
            {
                state= Convert.ToBoolean(reader["state"]);
            }
            return state;
        }
        /// <summary>
        /// 查询财务经理是否审核通过
        /// </summary>
        /// <param name="feeappid"></param>
        /// <returns></returns>
        public bool GetCWstate(int feeappid)
        {
            bool state=false;
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@feeappid",SqlDbType.Int)
                };
            parameters[0].Value = feeappid;

            SqlDataReader reader =
                RunProcedure("sp_GetCWstate",parameters);
            if (reader.Read())
            {
                state = Convert.ToBoolean(reader["state"]);
            }
            return state;
        }

        /// <summary>
        /// 审核状态
        /// </summary>
        /// <param name="feeappid"></param>
        /// <param name="groupname"></param>
        /// <returns></returns>
        public bool GetSHstate(int feeappid, string groupname)
        {
            bool state = false;
            SqlParameter[] parameters = { 
                                        new SqlParameter("@feeappid",SqlDbType.Int),
                                        new SqlParameter("@groupname",SqlDbType.VarChar)
                                        };
            parameters[0].Value = feeappid;
            parameters[1].Value = groupname;
            SqlDataReader reader = RunProcedure("sp_GetSHstate",parameters);
            if (reader.Read())
            {
                state = Convert.ToBoolean(reader["state"]);
            }
            return state;
        }

        /// <summary>
        /// 如果副总经理和财务经理审核通过后就修改费用表的state字段，该申请单生效
        /// </summary>
        /// <param name="feeappid"></param>
        /// <returns></returns>
        public bool UpdateFeeApp(int feeappid,string foottime)
        {
           int rowsAffected;
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@feeappid",SqlDbType.Int),
                    new SqlParameter("@foottime",SqlDbType.DateTime)
                };
            parameters[0].Value = feeappid;
            parameters[1].Value = foottime;
            RunProcedure("sp_UpdateFeeApp", parameters, out rowsAffected);
            return (rowsAffected == 1);
        }
        /// <summary>
        /// 查询指定用户已审核后的申请单
        /// </summary>
        /// <returns></returns>
        public bool GetEndReview(int feeappid,int masterid)
        {
            bool state=false;
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@feeappid",SqlDbType.Int),
                    new SqlParameter("@masterid",SqlDbType.Int)
                };
            parameters[0].Value = feeappid;
            parameters[1].Value = masterid;
            SqlDataReader reader=
                RunProcedure("sp_GetEndReview",parameters);
            if (reader.Read())
            {
                state= Convert.ToBoolean(reader["state"]);
                return state;
            }
            return state;
        }
        
        /// <summary>
        /// 判断是否审核
        /// </summary>
        /// <param name="mastername"></param>
        /// <param name="feeappid"></param>
        /// <returns></returns>
        public bool GetYN(string mastername, int feeappid)
        {
            
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@mastername",SqlDbType.VarChar),
                    new SqlParameter("@feeappid",SqlDbType.Int)
                };
            parameters[0].Value = mastername;
            parameters[1].Value = feeappid;

            SqlDataReader reader= RunProcedure("sp_GetYN", parameters);
            bool b = reader.Read();
            return b;
        }

        /// <summary>
        /// 查询是否已审核了，则不能修改了
        /// </summary>
        /// <param name="feeappid"></param>
        /// <returns></returns>
        public bool GetYNSH(int feeappid)
        {
            int rowsAffected;
            SqlParameter[] parameters = { new SqlParameter("@feeappid",SqlDbType.Int),new SqlParameter("@outint",SqlDbType.Int) };

            parameters[0].Value = feeappid;
            parameters[1].Direction = ParameterDirection.Output;
            RunProcedure("sp_YNSH", parameters, out rowsAffected);
            return (Convert.ToInt32(parameters[1].Value) > 0)?true:false;
        }

        /// <summary>
        /// 查询指定申请单的审核意见
        /// </summary>
        /// <param name="feeappid"></param>
        /// <returns></returns>
        public ArrayList Select(int feeappid)
        {
            ArrayList lists=new ArrayList();
            
            SqlParameter[] parameters = { new SqlParameter("@feeappid",SqlDbType.Int) };
            parameters[0].Value = feeappid;

            SqlDataReader reader = RunProcedure("sp_GetReview", parameters);
            while (reader.Read())
            {
                Review model = new Review();
                model.FeeAppId = Convert.ToInt32(reader["feeappid"]);
                model.MasterId = Convert.ToInt32(reader["masterid"]);
                model.MasterName = reader["mastername"].ToString();
                model.ReviewTime = Convert.ToDateTime(reader["reviewtime"]);
                model.Advice = reader["advice"].ToString();
                model.State = Convert.ToBoolean(reader["state"]);
                model.Groupname = reader["groupname"].ToString();
                model.Truename = reader["truename"].ToString();
                lists.Add(model);
            }
            return lists;
        }

    }
}
