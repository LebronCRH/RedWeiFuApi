using System;
using System.Collections;
using System.Security;
using System.Security.Cryptography;
using System.Data;

using RADinfo_MIS_COST.Model;

namespace RADinfo_MIS_COST.Accounts
{
    /// <summary>
    /// MyPrincipal的摘要说明
    /// </summary>
    public class MyPrincipal:System.Security.Principal.IPrincipal
    {
        protected ArrayList actions;  //数组元素为action权限对象
        protected ArrayList groupmanagers;   //数组元素为groupmanager(管理组)角色对象
        public MyIdentity identity;
        public MyPrincipal(){}

        //构造函数
        public void MyPrincipalByMasterid(string masterid)
        {
            identity = new MyIdentity();
            identity.MyIdentityByMasterid(masterid);

            //如果成功创建对象
            if (identity.Bll._id !=-1)
            {
                actions = identity.Bll.GetActions();
                groupmanagers = identity.Bll.GetGroupmanager();

            }
            else
            {
                identity = null;
                actions = null;
                groupmanagers = null;
            }
        }

        public MyPrincipal(string mastername)
        {
            identity = new MyIdentity(mastername);

            //如果成功创建对象
            if (identity.masterid != -1)
            {
                actions = identity.Bll.GetActions();
                groupmanagers = identity.Bll.GetGroupmanager();

            }
            else
            {
                identity = null;
                actions = null;
                groupmanagers = null;
            }
        }

        #region IPrincipal 成员
        public System.Security.Principal.IIdentity Identity
        {
            get
            {
                return identity;
            }

        }

        public bool IsInRole(string role)
        {
            if (groupmanagers == null)
                return false;

            foreach (GroupManager r in groupmanagers)
            {
                if (r.GroupName == role)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        public static MyPrincipal ValidateLogin(string mastername, string password)
        {
            MyPrincipal prin = new MyPrincipal(mastername);
            if (prin.Identity == null)
            {
                return null;
            }
            if (((MyIdentity)(prin.Identity)).TestPassword(password))
                return prin;
            else
                return null;
        }

        #region HasAction
        /// <summary>
        /// 判断主体对象是否具有指定的权限
        /// </summary>
        /// <param name="actionName"></param>
        /// <returns></returns>
        public bool HasAction(string actionName)
        {
            if (actions == null)
                return false;

            foreach (RADinfo_MIS_COST.Model.Action p in actions)
            {
                if (p.ActionName == actionName)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
