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
    /// 用来访问GroupManager表的类
    /// </summary>
     public class GroupManagerDAL:SQLHelper
    {
        /// <summary>
        /// 构造函数，调用基类构造函数，使用指定的连接字符串创建数据连接对象
        /// </summary>
        /// <param name="connString"></param>
         public GroupManagerDAL(string connString)
             : base(connString)
         { }

         #region GetGroupManager
         /// <summary>
         /// 获取所有的角色列表
         /// </summary>
         /// <returns>返回GroupManager对象数组列表</returns>
         public ArrayList GetGroupManager()
         {
             ArrayList groupmanagers = new ArrayList();
             SqlDataReader reader = RunProcedure("sp_GetGroupManagers",null);
             while (reader.Read())
             {
                 GroupManager model = new GroupManager();
                 model.GroupId = Convert.ToInt32(reader["groupid"]);
                 model.GroupName = Convert.ToString(reader["groupname"]);
                 groupmanagers.Add(model);
             }
             reader.Close();
             return groupmanagers;
         }
         #endregion

         #region GetGroupManager
         /// <summary>
         /// 根据指定的角色ID创建对象
         /// </summary>
         /// <param name="groupid"></param>
         /// <returns></returns>
         public GroupManager GetGroupManager(int groupid)
         {
             GroupManager model = new GroupManager();
             SqlParameter[] parameters ={ new SqlParameter("@groupid",SqlDbType.Int)};
             parameters[0].Value = groupid;
             SqlDataReader reader = RunProcedure("sp_GetGroupManager_groupid", parameters);
             if (reader.Read())
             {
                 model.GroupId = Convert.ToInt32(reader["groupid"]);
                 model.GroupName = Convert.ToString(reader["groupname"]);
                 model.GroupInfo = Convert.ToString(reader["groupinfo"]);
                 //model.MasterId = Convert.ToInt32(reader["masterid"]);
                 //model.MasterName = Convert.ToString(reader["mastername"]);
                 //model.CreateDate = Convert.ToDateTime(reader["createdate"]);
             }
             reader.Close();
             return model;
         }
         #endregion



         #region Add
         /// <summary>
         /// 插入数据
         /// </summary>
         /// <param name="groupname"></param>
         /// <param name="groupinfo"></param>
         /// <param name="masterid"></param>
         /// <param name="mastername"></param>
         /// <param name="createdate"></param>
         /// <returns></returns>
         public int Add(string groupname, string groupinfo)
         {
             int rowsAffected;
             SqlParameter[] parameters =
                 { 
                    new SqlParameter("@groupname",SqlDbType.VarChar),
                    new SqlParameter("@groupinfo",SqlDbType.VarChar),
                     //new SqlParameter("@masterid",SqlDbType.Int),
                     //new SqlParameter("@mastername",SqlDbType.VarChar),
                     //new SqlParameter("@createdate",SqlDbType.DateTime),
                     new SqlParameter("@groupid",SqlDbType.Int)
                 };
             parameters[0].Value = groupname;
             parameters[1].Value = groupinfo;
             //parameters[2].Value = masterid;
             //parameters[3].Value = mastername;
             //parameters[4].Value = createdate;
             parameters[2].Direction = ParameterDirection.Output;

             RunProcedure("sp_InsertGroupManager",parameters,out rowsAffected);
             return (int)parameters[2].Value;
         }
         #endregion

         #region GetGroupManager
         /// <summary>
         /// 获取属于指定角色的所有用户
         /// </summary>
         /// <param name="groupID">角色ID</param>
         /// <returns>用户列表</returns>
         public ArrayList GetGroupManagerMasters(int groupID)
         {
             ArrayList masters = new ArrayList();
             SqlParameter[] parameters =
                 {
                    new SqlParameter("@groupid",SqlDbType.Int)
                 };
             parameters[0].Value=groupID;
             SqlDataReader reader=
             RunProcedure("sp_GetGroupManagerMasters", parameters);
             while (reader.Read())
             {
                 Master model = new Master();
                 model.MasterId = reader["masterid"].ToString();
                 model.MasterName = Convert.ToString(reader["mastername"]);
                 masters.Add(model);
             }
             reader.Close();
             return masters;
         }
         #endregion

         #region GetExcluedeMasters()
         /// <summary>
         /// 获取不属于指定角色的所有用户
         /// </summary>
         /// <param name="groupID"></param>
         /// <returns></returns>
         public ArrayList GetRoleExcludeMasters(int groupID)
         {
             ArrayList masters = new ArrayList();
             SqlParameter[] parameters =
                 {
                    new SqlParameter("@groupid",SqlDbType.Int)
                 };
             parameters[0].Value=groupID;
             SqlDataReader reader =
                 RunProcedure("sp_GetGroupManagerExcludeMasters", parameters);
             while (reader.Read())
             {
                 Master model = new Master();
                 model.MasterId = reader["masterid"].ToString();
                 model.MasterName = Convert.ToString(reader["mastername"]);
                 masters.Add(model);
             }
             reader.Close();
             return masters;
         }
         #endregion

         #region Update
         /// <summary>
         /// 更新角色信息
         /// </summary>
         public bool Update(int groupid,string groupname,string groupinfo)
         { 
            SqlParameter[] parameters=
                {
                    new SqlParameter("@groupid",SqlDbType.Int),
                    new SqlParameter("@groupname",SqlDbType.VarChar),
                    new SqlParameter("@groupinfo",SqlDbType.VarChar)
                };
            parameters[0].Value = groupid;
            parameters[1].Value = groupname;
            parameters[2].Value = groupinfo;

            int rowsAffected;
            RunProcedure("sp_UpdateGroupManager",parameters,out rowsAffected);
            return (rowsAffected == 1);
         }
         #endregion

         #region Delete

         public bool Delete(int groupid)
         {
             SqlParameter[] parameters =
                {
                    new SqlParameter("@groupid",SqlDbType.Int)
                };
             parameters[0].Value = groupid;

             int rowsAffected;
             RunProcedure("sp_DeleteGroupManager", parameters, out rowsAffected);
             return (rowsAffected >= 1);
         }
         #endregion

         #region DeleteRoleUser
         /// <summary>
         /// 从角色中删除一个用户
         /// </summary>
         /// <param name="groupid"></param>
         /// <param name="masterid"></param>
         /// <returns></returns>
         public bool DeleteRoleUser(int groupid, string masterid)
         {
             int rowsAffected;
             SqlParameter[] parameters =
                 { 
                    new SqlParameter("@groupid",SqlDbType.Int),
                     new SqlParameter("@masterid",SqlDbType.VarChar)
                 };
             parameters[0].Value = groupid;
             parameters[1].Value = masterid;

             RunProcedure("sp_DeleteMasterGroup",parameters,out rowsAffected);
             return (rowsAffected == 1);
         }
         #endregion

         #region AddRoleUser
         /// <summary>
         /// 向角色中添加一个用户
         /// </summary>
         /// <param name="groupid"></param>
         /// <param name="masterid"></param>
         /// <returns></returns>
         public bool AddRoleUser(int groupid, string masterid)
         {
             int rowsAffected;
             SqlParameter[] parameters =
                 { 
                    new SqlParameter("@groupid",SqlDbType.Int),
                     new SqlParameter("@masterid",SqlDbType.VarChar)
                 };
             parameters[0].Value = groupid;
             parameters[1].Value = masterid;

             RunProcedure("sp_InsertMasterGroup",parameters,out rowsAffected);
             return (rowsAffected == 1);
         }
         #endregion
    }
}
