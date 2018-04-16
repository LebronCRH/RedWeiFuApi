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
    /// 用来访问ACTION表的类
    /// </summary>
    public class ActionDAL:SQLHelper
    {
       
        /// <summary>
        /// 构造函数，调用基类构造函数，使用指定的连接字符串创建数据连接对象
        /// </summary>
        /// <param name="connString"></param>
        public ActionDAL(string connString)
            : base(connString)
        { }

        #region Add      
        /// <summary>
        /// 向数据库添加一条记录
        /// </summary>
        /// <param name="actionname"></param>
        /// <param name="actioncolumnid"></param>
        /// <param name="actionstr"></param>
        /// <param name="viewmode"></param>
        /// <returns>返回ID</returns>
        public int Add(string actionname, int actioncolumnid, string actionstr,string link)
        {
            int rowsAffected;
            SqlParameter[] parameters =
                { 
                new SqlParameter("@actionname",SqlDbType.VarChar),
                    new SqlParameter("@actioncolumnid",SqlDbType.Int),
                    new SqlParameter("@actionstr",SqlDbType.VarChar),
                    new SqlParameter("@link",SqlDbType.VarChar),
                    new SqlParameter("@actionid",SqlDbType.Int)
                };
            parameters[0].Value = actionname;
            parameters[1].Value = actioncolumnid;
            parameters[2].Value = actionstr;
            parameters[3].Value = link;
            parameters[4].Direction = ParameterDirection.Output;

            RunProcedure("sp_InserAction",parameters,out rowsAffected);
            return (int)parameters[4].Value;
        }
        #endregion

        #region Update
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionid"></param>
        /// <param name="actionname"></param>
        /// <param name="actioncolumnid"></param>
        /// <param name="actionstr"></param>
        /// <returns></returns>
        public bool Update(int actionid, string actionname, int actioncolumnid, string actionstr,string link)
        {
            int rowsAffected;
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@actionid",SqlDbType.Int),
                    new SqlParameter("@actionname",SqlDbType.VarChar),
                    new SqlParameter("@actioncolumnid",SqlDbType.Int),
                    new SqlParameter("@actionstr",SqlDbType.VarChar),
                    new SqlParameter("@link",SqlDbType.VarChar)
                };
            parameters[0].Value = actionid;
            parameters[1].Value = actionname;
            parameters[2].Value = actioncolumnid;
            parameters[3].Value = actionstr;
            parameters[4].Value = link;

            RunProcedure("sp_UpdateAction",parameters,out rowsAffected);
            return (rowsAffected == 1);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除指定的权限
        /// </summary>
        /// <param name="actionid"></param>
        /// <returns></returns>
        public bool Delete(int actionid)
        {
            int rowsAffected;
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@actionid",SqlDbType.Int)
                };
            parameters[0].Value = actionid;

            RunProcedure("sp_DeleteAction",parameters,out rowsAffected);
            return (rowsAffected >0);
        }
        #endregion

        #region GetActions()
        /// <summary>
        /// 获取所有的权限
        /// </summary>
        /// <returns></returns>
        public ArrayList GetActions()
        {
            ArrayList actions = new ArrayList();
            using (SqlDataReader reader = RunProcedure("sp_GetAllAction", null))
            {
                while (reader.Read())
                {
                    RADinfo_MIS_COST.Model.Action model = new RADinfo_MIS_COST.Model.Action();
                    model.ActionId = Convert.ToInt32(reader["actionid"]);
                    model.ActionName = Convert.ToString(reader["actionname"]);
                    actions.Add(model);
                }
            }
            return actions;
        }
        #endregion

        #region GetDetails
        /// <summary>
        /// 获取指定权限的详细信息
        /// </summary>
        /// <param name="actionid"></param>
        /// <returns></returns>
        
        public RADinfo_MIS_COST.Model.Action GetDetails(int actionid)
        {
            RADinfo_MIS_COST.Model.Action model = new RADinfo_MIS_COST.Model.Action();
            SqlParameter[] parameters=
                {
                    new SqlParameter("@actionid",SqlDbType.Int)
                };
            parameters[0].Value = actionid;
            using (SqlDataReader reader = RunProcedure("sp_GetAction", parameters))
            {
                if (reader.Read())
                {
                    model.ActionId = Convert.ToInt32(reader["actionid"]);
                    model.ActionName = Convert.ToString(reader["actionname"]);
                    model.ActionStr = Convert.ToString(reader["actionstr"]);
                    model.ActionColumnid = Convert.ToInt32(reader["actioncolumnid"]);
                    model.Link = Convert.ToString(reader["link"]);
                }
            }
            return model;
        }
        #endregion

        #region GetRoles
        /// <summary>
        /// 获取分配了指定权限的所有角色
        /// </summary>
        /// <param name="actionID"></param>
        /// <returns></returns>
        public ArrayList GetRoles(int actionID)
        {
            ArrayList roles = new ArrayList();
            SqlParameter[] parameters =
                {
                    new SqlParameter("@actionid",SqlDbType.Int),
                };
            parameters[0].Value = actionID;
            using (SqlDataReader reader =
                RunProcedure("sp_GetGrantRoles", parameters))
            {
                while (reader.Read())
                {
                    GroupManager model = new GroupManager();
                    model.GroupId = Convert.ToInt32(reader["groupid"]);
                    model.GroupName = Convert.ToString(reader["groupname"]);
                    roles.Add(model);
                }
            }
            return roles;
        }
        #endregion

        #region GetExcludeRoles
        /// <summary>
        /// 获取未分配了指定权限的所有角色
        /// </summary>
        /// <param name="actionID"></param>
        /// <returns></returns>
        public ArrayList GetExcludeRoles(int actionID)
        {
            ArrayList roles = new ArrayList();
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@actionid",SqlDbType.Int)
                };
            parameters[0].Value = actionID;
            using (SqlDataReader reader =
                RunProcedure("sp_GetNotGrantRoles", parameters))
            {
                while (reader.Read())
                {
                    GroupManager model = new GroupManager();
                    model.GroupId = Convert.ToInt32(reader["groupid"]);
                    model.GroupName = Convert.ToString(reader["groupname"]);
                    roles.Add(model);
                }
            }
            return roles;
        }
        #endregion

        #region DeletePermissionGrant
        /// <summary>
        /// 删除一条权限分配记录
        /// </summary>
        /// <param name="actionID"></param>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public bool DeletePermissionGrant(int actionID, int groupID)
        {
            int rowsAffected;
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@actionID",SqlDbType.Int),
                    new SqlParameter("@groupID",SqlDbType.Int)
                };
            parameters[0].Value = actionID;
            parameters[1].Value = groupID;

            RunProcedure("sp_DeleteActionGroup",parameters,out rowsAffected);
            return (rowsAffected==1);

        }
        #endregion

        #region AddPermissionGrant
        /// <summary>
        /// 添加一条权限分配记录
        /// </summary>
        /// <param name="actionID"></param>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public bool AddPermissionGrant(int actionID, int groupID)
        {
            int rowsAffected;
            SqlParameter[] parameters =
                {
                    new SqlParameter("@actionID",SqlDbType.Int),
                    new SqlParameter("@groupID",SqlDbType.Int)
                };
            parameters[0].Value = actionID;
            parameters[1].Value = groupID;

            RunProcedure("sp_AddActionGroup",parameters, out rowsAffected);
            return (rowsAffected == 1);
        
        }
        #endregion


       
    }
}
