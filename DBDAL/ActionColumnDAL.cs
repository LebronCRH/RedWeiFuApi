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
    /// 用来访问ActionColumn的类
    /// </summary>
    public class ActionColumnDAL:SQLHelper
    {
        /// <summary>
        /// 构造函数，调用基类构造函数，使用指定的连接字符串创建数据连接对象
        /// </summary>
        /// <param name="connString"></param>
        public ActionColumnDAL(string connString)
            : base(connString)
        { }

        //删除指定权限分栏
        public bool DeleteActionColumn(int actioncolumnid)
        {
            int rowsAffected;
            SqlParameter[] parameters={new SqlParameter("@actioncolumnid",SqlDbType.Int)};
            parameters[0].Value=actioncolumnid;
            RunProcedure("sp_D_ActionColumn",parameters,out rowsAffected);
            return rowsAffected > 0 ? true : false;
        }
        //查询指定的分栏中是否有权限
        public bool Select(int actioncolumnid)
        {
            SqlParameter[] parameters ={ new SqlParameter("@actioncolumnid",SqlDbType.Int)};
            parameters[0].Value = actioncolumnid;
            using (SqlDataReader reader = RunProcedure("sp_S_ActionColumn_Action", parameters))
            {
                if (reader.Read())
                {
                    return true;
                }
            }
            return false;
        }

        //查询所有的权限分栏
        public ArrayList Select()
        {
            ArrayList lists = new ArrayList();
            using (SqlDataReader reader = RunProcedure("sp_S_ActionColumns", null))
            {
                while (reader.Read())
                {
                    ActionColumn model = new ActionColumn();
                    model.ActionColumnid = Convert.ToInt32(reader["actioncolumnid"]);
                    model.ActionColumnName = Convert.ToString(reader["actioncolumnname"]);
                    model.Link = Convert.ToString(reader["link"]);
                    lists.Add(model);
                }
            }
            return lists;
        }

        #region Add
        /// <summary>
        /// 添加权限分栏信息
        /// </summary>
        /// <param name="actioncolumnname"></param>
        /// <returns></returns>
        public int Add(string actioncolumnname,string link)
        {
            int rowsAffected;
            SqlParameter[] parameters = 
                {
                    new SqlParameter("@actioncolumnname", SqlDbType.VarChar),
                    new SqlParameter("@link",SqlDbType.VarChar),
                    new SqlParameter("@actioncolumnid",SqlDbType.Int)
                };
            parameters[0].Value = actioncolumnname;
            parameters[1].Value = link;
            parameters[2].Direction=ParameterDirection.Output;

            
            RunProcedure("sp_InsertActioncolumn", parameters, out rowsAffected);            
            return (int)parameters[2].Value;
        }
        #endregion

        public bool Update(int actioncolumnid, string actioncolumnname, string link)
        {
            int rowsAffected;
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@actioncolumnid",SqlDbType.Int),
                    new SqlParameter("@actioncolumnname",SqlDbType.VarChar),
                    new SqlParameter("@link",SqlDbType.VarChar)
                };
            parameters[0].Value = actioncolumnid;
            parameters[1].Value = actioncolumnname;
            parameters[2].Value = link;

            RunProcedure("sp_UpdateActioncolumn",parameters,out rowsAffected);
            return (rowsAffected == 1);
        }

        public bool Delete(int actioncolumnid)
        {
            int rowsAffected;
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@actioncolumnid",SqlDbType.Int)
                };
            parameters[0].Value = actioncolumnid;

            RunProcedure("sp_DeleteActioncolumn",parameters,out rowsAffected);
            return (rowsAffected==1);
        }

        #region GetActionColumn
        /// <summary>
        /// 获取指定的ID权限分栏信息
        /// </summary>
        /// <param name="actioncolumnid"></param>
        /// <returns></returns>
        public ActionColumn GetActionColumn(int actioncolumnid)
        {
            ActionColumn model = null;

            SqlParameter[] parameters =
                {
                    new SqlParameter("@actioncolumnid",SqlDbType.Int)
                };
            parameters[0].Value = actioncolumnid;

            using (SqlDataReader reader =
                RunProcedure("sp_SelectActioncolumn", parameters))
            {
                if (reader.Read())
                {
                    model = new ActionColumn();
                    model.ActionColumnid = Convert.ToInt32(reader["actioncolumnid"]);
                    model.ActionColumnName = Convert.ToString(reader["actioncolumnname"]);
                    model.Link = Convert.ToString(reader["link"]);

                }
            }

            return model;
        }
        #endregion

        #region GetActionColumn
        /// <summary>
        /// 查询所有的分栏信息
        /// </summary>
        /// <returns></returns>
        public ArrayList GetActionColumn()
        {
            ArrayList actioncolumns = new ArrayList();
            using (SqlDataReader reader =
                RunProcedure("sp_GetActionColumns", null))
            {
                while (reader.Read())
                {
                    ActionColumn model = new ActionColumn();
                    model.ActionColumnid = Convert.ToInt32(reader["actioncolumnid"]);
                    model.ActionColumnName = Convert.ToString(reader["actioncolumnname"]);
                    model.Link = Convert.ToString(reader["link"]);
                    actioncolumns.Add(model);
                }
            }
            return actioncolumns;
        }
        #endregion
        /// <summary>
        /// 获取指定权限分栏中的所有权限
        /// </summary>
        /// <param name="actioncolumnid"></param>
        /// <returns></returns>
        public ArrayList GetActions(int actioncolumnid)
        {
            ArrayList actions = new ArrayList();
            SqlParameter[] parameters =
                { new SqlParameter("@actioncolumnid",SqlDbType.Int)};
            parameters[0].Value = actioncolumnid;
            using (SqlDataReader reader =
                RunProcedure("sp_GetAction_columnid", parameters))
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
        /// <summary>
        /// 获取指定权限分栏外的所有权限
        /// </summary>
        /// <param name="actioncolumnid"></param>
        /// <returns></returns>
        public ArrayList GetExcludeActions(int actioncolumnid)
        {
              ArrayList actions = new ArrayList();
            SqlParameter[] parameters =
                { new SqlParameter("@actioncolumnid",SqlDbType.Int)};
            parameters[0].Value = actioncolumnid;
            using (SqlDataReader reader =
                RunProcedure("sp_GetExcludeAction_columnid", parameters))
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

        //删除分栏中的权限
        public bool RemoveActions(int actionid)
        {
            int rowsAffected;
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@actionid",SqlDbType.Int)
                };
            parameters[0].Value = actionid;

            RunProcedure("sp_RemoveActions", parameters, out rowsAffected);
            return (rowsAffected == 1);
        }
        //添加分栏中的权限
        public bool AddActions(int actionid, int actioncolumnid)
        {
            int rowsAffected;
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@actionid",SqlDbType.Int),
                    new SqlParameter("@actioncolumnid",SqlDbType.Int)
                };
            parameters[0].Value = actionid;
            parameters[1].Value = actioncolumnid;

            RunProcedure("sp_AddActions",parameters,out rowsAffected);
            return (rowsAffected == 1);
        }

    }
}
