using System;
using System.Collections.Generic;
using System.Text;

using RADinfo_MIS_COST.Model;
using RADinfo_MIS_COST.DBDAL;
using System.Security.Cryptography;
using System.Collections;
using System.Configuration;

namespace RADinfo_MIS_COST.BusinessClasses
{ 
    public class ActionBLL:BusinessObject
    {
        public int _actionid;
        public string _actionname;
        public int _actioncolumnid;
        public string _actionstr;
        public bool _viewmode;
        public string _link;

        /// <summary>
        /// 构造函数，使用ID创建新对象
        /// </summary>
        public ActionBLL()
            : base()
        {
            _actionid = -1;
        }

        
        /// <summary>
        /// 获取指定权限的详细信息
        /// </summary>
        /// <param name="actionid"></param>
        public ActionBLL(int actionid)
            : base()
        {
            _actionid = -1;
            ActionDAL dal = new ActionDAL(connectionString);
            RADinfo_MIS_COST.Model.Action model= dal.GetDetails(actionid);
            if (model != null)
            {
                _actionid = model.ActionId;
                _actionname = model.ActionName;
                _actionstr = model.ActionStr;
                _actioncolumnid = model.ActionColumnid;
                _link = model.Link;
            }
        }

        public string GetActionColumn()
        {
            ActionColumnDAL dal = new ActionColumnDAL(connectionString);
            ActionColumn model= dal.GetActionColumn(_actioncolumnid);
            return model.ActionColumnName;
        }


     
        #region Add
        
        
        /// <summary>
        /// 添加一个权限
        /// </summary>
        /// <returns></returns>
        public int Add()
        {
            ActionDAL dal = new ActionDAL(connectionString);
            _actionid = dal.Add(_actionname, _actioncolumnid, _actionstr,_link);
            return _actionid;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新权限
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            if (_actionid == -1)
            {
                return false;
            }
            ActionDAL dal = new ActionDAL(connectionString);
            return dal.Update(_actionid, _actionname, _actioncolumnid, _actionstr,_link);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除权限
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            ActionDAL dal = new ActionDAL(connectionString);
            bool result = dal.Delete(_actionid);
            if (result)     //删除后把ID设置为-1
                _actionid = -1;

            return result;
        }
        #endregion

        #region GetActions

        /// <summary>
        /// 返回所有的权限列表（静态方法）
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetActions()
        { 
            //从配置文件web.config中读取连接字符串
            AppSettingsReader configurationAppSettings = new AppSettingsReader();
            string connString = ((string)(configurationAppSettings.GetValue("ConStr", typeof(string))));

            ActionDAL dal = new ActionDAL(connString);
            return dal.GetActions();
        }
        #endregion

        #region GetRoles
        /// <summary>
        /// 返回已分配权限的角色
        /// </summary>
        /// <returns></returns>
        public ArrayList GetRoles()
        {
            ActionDAL dal = new ActionDAL(connectionString);
            return dal.GetRoles(_actionid);
        }
        #endregion

        #region GetExcludeRoles
        /// <summary>
        /// 返回未分配权限的角色
        /// </summary>
        /// <returns></returns>
        public ArrayList GetExcludeRoles()
        {
            ActionDAL dal = new ActionDAL(connectionString);
            return dal.GetExcludeRoles(_actionid);
        }
        #endregion

        #region DeleteGrant
        /// <summary>
        /// 删除一个权限分配
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public bool DeleteGrant(int groupID)
        {
            if (_actionid == -1)
                return false;

            ActionDAL dal = new ActionDAL(connectionString);
            return dal.DeletePermissionGrant(_actionid, groupID);
        }
        #endregion

        #region AddGrant
        /// <summary>
        /// 添加一个权限分配
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public bool AddGrant(int groupID)
        {
            if (_actionid == -1)
                return false;

            ActionDAL dal = new ActionDAL(connectionString);
            return dal.AddPermissionGrant(_actionid,groupID);
        }
        #endregion

        //删除分栏中的权限
        public bool RemoveActions()
        {
            ActionColumnDAL dal = new ActionColumnDAL(connectionString);
            return dal.RemoveActions(_actionid);
        }

         //添加分栏中的权限
        public bool AddActions(int actionid,int actioncolumnid)
        {
            ActionColumnDAL dal = new ActionColumnDAL(connectionString);
            return dal.AddActions(actionid,actioncolumnid);
        }
    }
}
