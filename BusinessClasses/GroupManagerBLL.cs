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
    public class GroupManagerBLL:BusinessObject
    {
        public int _groupid;
        public string _groupname;
        public string _groupinfo;
        public string _masterid;
        public string _mastername;
        public DateTime _createdate;

        /// <summary>
        /// 构造函数，创建一个空对象
        /// </summary>
        public GroupManagerBLL()
            : base()
        {
            _groupid = -1;
        }

        /// <summary>
        /// 构造函数，根据指定的角色ID创建对象
        /// </summary>
        /// <param name="groupid"></param>
        public GroupManagerBLL(int groupid)
            : base()
        {
            _groupid = -1;
            GroupManagerDAL dal = new GroupManagerDAL(connectionString);
            GroupManager model = dal.GetGroupManager(groupid);
            if (model != null)
            {
                _groupid = model.GroupId;
                _groupname = model.GroupName;
                _groupinfo = model.GroupInfo;
                //_masterid = model.MasterId;
                //_mastername = model.MasterName;
                //_createdate = model.CreateDate;
            }
        }
        /// <summary>
        /// 向角色中添加一个用户
        /// </summary>
        /// <param name="masterid"></param>
        /// <returns></returns>
        public bool AddUser(string masterid)
        {
            if (_groupid == -1)
                return false;

            GroupManagerDAL dal = new GroupManagerDAL(connectionString);
            return dal.AddRoleUser(_groupid, masterid);
        }

        /// <summary>
        /// 向角色中删除一个用户
        /// </summary>
        /// <param name="masterid"></param>
        /// <returns></returns>
        public bool RemoveUser(string masterid)
        {
            if (_groupid == -1)
                return false;

            GroupManagerDAL dal = new GroupManagerDAL(connectionString);
            return dal.DeleteRoleUser(_groupid, masterid);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            GroupManagerDAL dal = new GroupManagerDAL(connectionString);
            return dal.Delete(_groupid);
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <returns></returns>
        public int Add()
        {
            GroupManagerDAL dal = new GroupManagerDAL(connectionString);
             _groupid=dal.Add(_groupname, _groupinfo);
             return _groupid;
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            if (_groupid == -1)
            {
                return false;
            }
            GroupManagerDAL dal = new GroupManagerDAL(connectionString);
            return dal.Update(_groupid, _groupname, _groupinfo);
        }

        /// <summary>
        ///  获取角色列表（静态方法）
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetGroupManager()
        { 
            //从配置文件web.config中读取连接字符串
            AppSettingsReader configurationAppSettings = new AppSettingsReader();
            string connString=Convert.ToString(configurationAppSettings.GetValue("ConStr",typeof(string)));
            GroupManagerDAL dal=new GroupManagerDAL(connString);
            return dal.GetGroupManager();
        }

        /// <summary>
        /// 获取角色包含的所有用户
        /// </summary>
        /// <returns>返回一个用户列表</returns>
        public ArrayList GetMasters()
        {
            GroupManagerDAL dal = new GroupManagerDAL(connectionString);
            return dal.GetGroupManagerMasters(_groupid);
        }
        /// <summary>
        /// 获取不属于角色的所有用户
        /// </summary>
        /// <returns></returns>
        public ArrayList GetExcludeMasters()
        {
            GroupManagerDAL dal = new GroupManagerDAL(connectionString);
            return dal.GetRoleExcludeMasters(_groupid);
        }


    }
}
