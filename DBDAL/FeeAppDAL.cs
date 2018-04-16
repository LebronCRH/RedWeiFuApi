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
    public class FeeAppDAL:SQLHelper
    {
        /// <summary>
        /// 构造函数，调用基类构造函数，使用指定的连接字符串创建数据连接对象
        /// </summary>
        /// <param name="connString"></param>
        public FeeAppDAL(string connString)
            : base(connString)
        { }

        //查询是否有修改权限的方法
        public string XGQX(int feeappid)
        {
            string mastername="";
            SqlParameter[] parameters = { new SqlParameter("@feeappid",SqlDbType.Int)};
            parameters[0].Value = feeappid;

            SqlDataReader reader = RunProcedure("sp_XGQX", parameters);
            if (reader.Read())
            {
                mastername = reader[0].ToString();
            }
            return mastername;

        }

        /// <summary>
        /// 删除申请单
        /// </summary>
        /// <param name="feeappid"></param>
        /// <returns></returns>
        public bool DeleteFeeApp(int feeappid)
        {
            int rowsAffected;
            SqlParameter[] parameters=
            {
                new SqlParameter("@feeappid",SqlDbType.Int)
            };
            parameters[0].Value = feeappid;

            RunProcedure("sp_D_FeeApp", parameters, out rowsAffected);
            return rowsAffected>0?true:false;
        }

        /// <summary>
        /// 更新申请单
        /// </summary>
        /// <param name="feeapptype"></param>
        /// <param name="deptid"></param>
        /// <param name="mastername"></param>
        /// <param name="use"></param>
        /// <param name="money"></param>
        /// <param name="registertime"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="remarks"></param>
        /// <param name="special"></param>
        /// <param name="feeappid"></param>
        /// <returns></returns>
        public bool UpdateFeeApp(string feeapptype,string guestId,string itemId,string deptid,string mastername,string use,decimal money,DateTime registertime,DateTime starttime,DateTime endtime,string remarks,string special,int feeappid)
        {
            int rowsAffected;
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@FeeAppType",SqlDbType.VarChar),
                    new SqlParameter("@GuestId",SqlDbType.VarChar),
                    new SqlParameter("@ItemId",SqlDbType.VarChar),
                    new SqlParameter("@Deptid",SqlDbType.VarChar),
                    new SqlParameter("@Mastername",SqlDbType.VarChar),
                    new SqlParameter("@Use",SqlDbType.VarChar),
                    new SqlParameter("@Money",SqlDbType.Money),
                    new SqlParameter("@RegisterTime",SqlDbType.DateTime),
                    new SqlParameter("@StartTime",SqlDbType.DateTime),
                    new SqlParameter("@EndTime",SqlDbType.DateTime),
                    new SqlParameter("@Remarks",SqlDbType.VarChar),
                    new SqlParameter("@Special",SqlDbType.VarChar),
                    new SqlParameter("@FeeAppID",SqlDbType.Int),

                };
            parameters[0].Value = feeapptype;
            parameters[1].Value = guestId;
            parameters[2].Value = itemId;
            parameters[3].Value = deptid;
            parameters[4].Value = mastername;
            parameters[5].Value = use;
            parameters[6].Value = money;
            parameters[7].Value = registertime;
            parameters[8].Value = starttime;
            parameters[9].Value = endtime;
            parameters[10].Value = remarks;
            parameters[11].Value = special;
            parameters[12].Value = feeappid;

            RunProcedure("sp_U_FeeApp_id", parameters, out rowsAffected);
            return (rowsAffected == 1);

        }

        //查询指定申请单
        public FeeApp Select(int feeappid)
        {
            FeeApp model = new FeeApp();
            SqlParameter[] parameters ={ new SqlParameter("@feeappid",SqlDbType.Int)};
            parameters[0].Value = feeappid;
            SqlDataReader reader=RunProcedure("sp_S_FeeApp_id",parameters);
            if (reader.Read())
            {
                model.DeptId = Convert.ToString(reader["deptid"]);
                model.Endtime = Convert.ToDateTime(reader["endtime"]);
                model.FeeAppId = Convert.ToInt32(reader["feeappid"]);
                model.FeeAppType = Convert.ToString(reader["feeapptype"]);
                model.GuestId = Convert.ToString(reader["guestid"]);
                model.ItemId = Convert.ToString(reader["itemid"]);
                model.MasterName = Convert.ToString(reader["mastername"]);
                model.Money = Convert.ToDecimal(reader["money"]);
                model.RegisterTime = Convert.ToDateTime(reader["registertime"]);
                model.Remarks = Convert.ToString(reader["remarks"]);
                model.Special = Convert.ToString(reader["special"]);
                model.Starttime = Convert.ToDateTime(reader["starttime"]);
                model.State = Convert.ToBoolean(reader["state"]);
                //model.UpdateRId = Convert.ToInt32(reader["updaterid"]);
                //model.UpdateTime = Convert.ToDateTime(reader["updatetime"]);
                model.USE = Convert.ToString(reader["use"]);
                model.Foottime = Convert.ToString(reader["foottime"]); 
            }
            return model;
        }

        #region Add
        /// <summary>
        /// 添加申请单
        /// </summary>
        /// <returns></returns>
        public int Add(string feeapptype,string GuestId,string ItemId,string deptid,string mastername,string use,decimal money,DateTime registertime,DateTime starttime,DateTime endtime ,string remarks,string special)
        {
            int rowsAffected;
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@FeeAppType",SqlDbType.VarChar),
                    new SqlParameter("@GuestId",SqlDbType.VarChar),
                    new SqlParameter("@ItemId",SqlDbType.VarChar),
                    new SqlParameter("@Deptid",SqlDbType.VarChar),
                    new SqlParameter("@Mastername",SqlDbType.VarChar),
                    new SqlParameter("@Use",SqlDbType.VarChar),
                    new SqlParameter("@Money",SqlDbType.Money),
                    new SqlParameter("@RegisterTime",SqlDbType.DateTime),
                    new SqlParameter("@StartTime",SqlDbType.DateTime),
                    new SqlParameter("@EndTime",SqlDbType.DateTime),
                    new SqlParameter("@Remarks",SqlDbType.VarChar),
                    new SqlParameter("@Special",SqlDbType.VarChar),
                    new SqlParameter("@FeeAppID",SqlDbType.Int)
                };
            parameters[0].Value = feeapptype;
            parameters[1].Value = GuestId;
            parameters[2].Value = ItemId;
            parameters[3].Value = deptid;
            parameters[4].Value = mastername;
            parameters[5].Value = use;
            parameters[6].Value = money;
            parameters[7].Value = registertime;
            parameters[8].Value = starttime;
            parameters[9].Value = endtime;
            parameters[10].Value = remarks;
            parameters[11].Value = special;
            parameters[12].Direction = ParameterDirection.Output;

            RunProcedure("sp_InsertFeeApp", parameters, out rowsAffected);

            return (int)parameters[12].Value;
        }
        #endregion
        /// <summary>
        /// 获取指定用户已经通过审核后的申请单
        /// </summary>
        /// <param name="mastername"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public ArrayList GetYFeeApp(string mastername,bool state,DateTime registertime,string xuanze)
        {
            ArrayList feeapps = new ArrayList();
            SqlDataReader reader=null;
            if(registertime==Convert.ToDateTime("0001-01-01"))
            {
                SqlParameter[] parameters=
                    {
                        new SqlParameter("@mastername",SqlDbType.VarChar),
                        new SqlParameter("@state",SqlDbType.Bit)
                    };
                parameters[0].Value=mastername;
                parameters[1].Value=state;
                reader=RunProcedure("sp_GetYFeeApp",parameters);
            }
            else
            {
                SqlParameter[] parameters =
                    {
                        new SqlParameter("@mastername",SqlDbType.VarChar),
                        new SqlParameter("@state",SqlDbType.Bit),
                        new SqlParameter("@registertime",SqlDbType.DateTime),
                        new SqlParameter("@xuanze",SqlDbType.VarChar)
                    };
                parameters[0].Value = mastername;
                parameters[1].Value = state;
                parameters[2].Value = registertime;
                parameters[3].Value = xuanze;
                reader = RunProcedure("sp_GetYFeeApp", parameters);
            }
                
            while (reader.Read())
            {
                FeeApp model = new FeeApp();
                model.FeeAppId = Convert.ToInt32(reader["FeeAppid"]);
                model.FeeAppType = Convert.ToString(reader["FeeAppType"]);
                model.GuestId = Convert.ToString(reader["guestid"]);
                model.GuestName = Convert.ToString(reader["guestname"]);
                model.ItemId = Convert.ToString(reader["itemid"]);
                model.ItemName = Convert.ToString(reader["itemname"]);
                model.DeptId = Convert.ToString(reader["deptid"]);
                model.MasterName = Convert.ToString(reader["mastername"]);
                model.USE = Convert.ToString(reader["use"]);
                model.Money = Convert.ToDecimal(reader["money"]);
                model.RegisterTime = Convert.ToDateTime(reader["registertime"]);
                model.Starttime = Convert.ToDateTime(reader["starttime"]);
                model.Endtime = Convert.ToDateTime(reader["endtime"]);
                model.Remarks = Convert.ToString(reader["remarks"]);
                model.State = Convert.ToBoolean(reader["state"]);
                model.Special = Convert.ToString(reader["special"]);
    
                feeapps.Add(model);
            }
            reader.Close();
            return feeapps;
        }        


        /// <summary>
        /// 指定部门的所有申请单
        /// </summary>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public ArrayList GetBMFeeApp(string deptid,string feeapptype,string state,string registertime1,string registertime2,string mastername)
        {
            ArrayList feeapps = new ArrayList();
            SqlDataReader reader = null;
            SqlParameter[] parameters ={ new SqlParameter("@deptid",SqlDbType.VarChar),
                                        new SqlParameter("@feeapptype",SqlDbType.VarChar),
                                        new SqlParameter("@state",SqlDbType.VarChar),
                                        new SqlParameter("@registertime1",SqlDbType.VarChar),
                                        new SqlParameter("@registertime2",SqlDbType.VarChar),
                                       new SqlParameter("@mastername",SqlDbType.VarChar)};
            parameters[0].Value = deptid;
            parameters[1].Value = feeapptype;
            parameters[2].Value = state;
            parameters[3].Value = registertime1;
            parameters[4].Value = registertime2;
            parameters[5].Value = mastername;
            reader = RunProcedure("sp_S_BMFeeApp", parameters);       
            
            while (reader.Read())
            {
                FeeApp model = new FeeApp();
                model.FeeAppId = Convert.ToInt32(reader["FeeAppid"]);
                model.FeeAppType = Convert.ToString(reader["FeeAppType"]);
                model.GuestId = Convert.ToString(reader["guestid"]);
                model.GuestName = Convert.ToString(reader["guestname"]);
                model.ItemId = Convert.ToString(reader["itemid"]);
                model.ItemName = Convert.ToString(reader["itemname"]);
                model.DeptId = Convert.ToString(reader["deptid"]);
                model.MasterName = Convert.ToString(reader["mastername"]);
                model.USE = Convert.ToString(reader["use"]);
                model.Money = Convert.ToDecimal(reader["money"]);
                model.RegisterTime = Convert.ToDateTime(reader["registertime"]);
                model.Starttime = Convert.ToDateTime(reader["starttime"]);
                model.Endtime = Convert.ToDateTime(reader["endtime"]);
                model.Remarks = Convert.ToString(reader["remarks"]);
                model.State = Convert.ToBoolean(reader["state"]);
                model.Special = Convert.ToString(reader["special"]);
                model.Deptname = Convert.ToString(reader["deptname"]);
                feeapps.Add(model);
            }
            reader.Close();
            return feeapps;
        }
        /// <summary>
        /// 查询公司的申请单
        /// </summary>
        /// <returns></returns>
        public ArrayList GetGSFeeApp(string state,string feeapptype, string registertime1, string registertime2,string mastername)
        {
            ArrayList feeapps = new ArrayList();
            SqlDataReader reader = null;
            SqlParameter[] parameters =
                {
                    new SqlParameter("@state",SqlDbType.VarChar),
                    new SqlParameter("@feeapptype",SqlDbType.VarChar),
                new SqlParameter("@registertime1",SqlDbType.VarChar),
                new SqlParameter("@registertime2",SqlDbType.VarChar),
                new SqlParameter("@mastername",SqlDbType.VarChar)};
            parameters[0].Value = state;
            parameters[1].Value = feeapptype;
            parameters[2].Value = registertime1;
            parameters[3].Value = registertime2;
            parameters[4].Value = mastername;
            reader = RunProcedure("sp_S_GSFeeApp", parameters);

            while (reader.Read())
            {
                FeeApp model = new FeeApp();
                model.FeeAppId = Convert.ToInt32(reader["FeeAppid"]);
                model.FeeAppType = Convert.ToString(reader["FeeAppType"]);
                model.GuestId = Convert.ToString(reader["guestid"]);
                
                model.ItemId = Convert.ToString(reader["itemid"]);
                model.DeptId = Convert.ToString(reader["deptid"]);
                model.MasterName = Convert.ToString(reader["mastername"]);
                model.USE = Convert.ToString(reader["use"]);
                model.Money = Convert.ToDecimal(reader["money"]);
                model.RegisterTime = Convert.ToDateTime(reader["registertime"]);
                model.Starttime = Convert.ToDateTime(reader["starttime"]);
                model.Endtime = Convert.ToDateTime(reader["endtime"]);
                model.Remarks = Convert.ToString(reader["remarks"]);
                model.State = Convert.ToBoolean(reader["state"]);
                model.Special = Convert.ToString(reader["special"]);
                model.Deptname = Convert.ToString(reader["deptname"]);
                feeapps.Add(model);
            }
            reader.Close();
            return feeapps;
        }

        /// <summary>
        /// 查询公司所有的已审核通过的，和未审核的
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public ArrayList GetYNGSAll(bool state,DateTime registertime,string xuanze)
        {
            ArrayList feeapps = new ArrayList();
            
             SqlDataReader reader = null;
             if (registertime == Convert.ToDateTime("0001-01-01"))
             {
                 SqlParameter[] parameters =
                {
                    new SqlParameter("@state",SqlDbType.Bit)
                };
                 parameters[0].Value = state;
                 reader =
                     RunProcedure("sp_GetYNGSAll", parameters);
             }
             else
             {
                 SqlParameter[] parameters =
                {
                    new SqlParameter("@state",SqlDbType.Bit),
                    new SqlParameter("@registertime",SqlDbType.DateTime),
                    new SqlParameter("xuanze",SqlDbType.VarChar)
                };
                 parameters[0].Value = state;
                 parameters[1].Value = registertime;
                 parameters[2].Value = xuanze;
                 reader =
                     RunProcedure("sp_GetYNGSAll", parameters);
             }
            while (reader.Read())
            {
                FeeApp model = new FeeApp();
                model.FeeAppId = Convert.ToInt32(reader["FeeAppid"]);
                model.FeeAppType = Convert.ToString(reader["FeeAppType"]);
                model.GuestId = Convert.ToString(reader["guestid"]);
                model.GuestName = Convert.ToString(reader["guestname"]);
                model.ItemId = Convert.ToString(reader["itemid"]);
                model.ItemName = Convert.ToString(reader["itemname"]);
                model.DeptId = Convert.ToString(reader["deptid"]);
                model.MasterName = Convert.ToString(reader["mastername"]);
                model.USE = Convert.ToString(reader["use"]);
                model.Money = Convert.ToDecimal(reader["money"]);
                model.RegisterTime = Convert.ToDateTime(reader["registertime"]);
                model.Starttime = Convert.ToDateTime(reader["starttime"]);
                model.Endtime = Convert.ToDateTime(reader["endtime"]);
                model.Remarks = Convert.ToString(reader["remarks"]);
                model.State = Convert.ToBoolean(reader["state"]);
                model.Special = Convert.ToString(reader["special"]);
               
                feeapps.Add(model);
            }
            reader.Close();
            return feeapps;
        }

            /// <summary>
        /// 查询该部门所有的已审核通过的，和未审核的
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public ArrayList GetYNBMFeeApp(string deptid,bool state,DateTime registertime,string xuanze)
        {
            ArrayList feeapps = new ArrayList();
            SqlDataReader reader = null;
            if (registertime == Convert.ToDateTime("0001-01-01"))
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@deptid",SqlDbType.Int),
                    new SqlParameter("@state",SqlDbType.Bit)
                };
                parameters[0].Value = deptid;
                parameters[1].Value = state;
                reader =
                    RunProcedure("sp_GetYNBMFeeApp", parameters);
            }
            else
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@deptid",SqlDbType.Int),
                    new SqlParameter("@state",SqlDbType.Bit),
                    new SqlParameter("@registertime",SqlDbType.DateTime),
                    new SqlParameter("@xuanze",SqlDbType.VarChar)
                };
                parameters[0].Value = deptid;
                parameters[1].Value = state;
                parameters[2].Value = registertime;
                parameters[3].Value = xuanze;
                reader =
                    RunProcedure("sp_GetYNBMFeeApp", parameters);
            }
            while (reader.Read())
            {
                FeeApp model = new FeeApp();
                model.FeeAppId = Convert.ToInt32(reader["FeeAppid"]);
                model.FeeAppType = Convert.ToString(reader["FeeAppType"]);
                model.GuestId = Convert.ToString(reader["guestid"]);
                model.GuestName = Convert.ToString(reader["guestname"]);
                model.ItemId = Convert.ToString(reader["itemid"]);
                model.ItemName = Convert.ToString(reader["itemname"]);
                model.DeptId = Convert.ToString(reader["deptid"]);
                model.MasterName = Convert.ToString(reader["mastername"]);
                model.USE = Convert.ToString(reader["use"]);
                model.Money = Convert.ToDecimal(reader["money"]);
                model.RegisterTime = Convert.ToDateTime(reader["registertime"]);
                model.Starttime = Convert.ToDateTime(reader["starttime"]);
                model.Endtime = Convert.ToDateTime(reader["endtime"]);
                model.Remarks = Convert.ToString(reader["remarks"]);
                model.State = Convert.ToBoolean(reader["state"]);
                model.Special = Convert.ToString(reader["special"]);
              
                feeapps.Add(model);
            }
            reader.Close();
            return feeapps;
        }
    }
}
