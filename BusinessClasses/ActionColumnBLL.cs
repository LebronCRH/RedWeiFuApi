using System;
using System.Collections.Generic;
using System.Text;

using RADinfo_MIS_COST.Model;
using RADinfo_MIS_COST.DBDAL;
using System.Security.Cryptography;
using System.Collections;

namespace RADinfo_MIS_COST.BusinessClasses
{
    public class ActionColumnBLL : BusinessObject
    {

        public int _actioncolumnid;
        public string _actioncolumnname;
        public string _link;
        public ActionColumnBLL()
            : base()
        {

        }

        public ActionColumnBLL(int id)
            : base()
        {

            _actioncolumnid = LoadFromID(id);
        }
        /// <summary>
        /// 根据指定的ID，从数据库中读取分栏信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int LoadFromID(int id)
        {
            ActionColumnDAL dal = new ActionColumnDAL(connectionString);
            ActionColumn model = dal.GetActionColumn(id);
            if (model == null)
                return -1;

            id = model.ActionColumnid;
            _actioncolumnid = model.ActionColumnid;
            _actioncolumnname = model.ActionColumnName;
            _link = model.Link;
            return model.ActionColumnid;
        }

        public ActionColumn GetActionColumn(int actioncolumnid)
        {
            ActionColumnDAL dal = new ActionColumnDAL(connectionString);
            return dal.GetActionColumn(actioncolumnid);
        }

        /// <summary>
        /// 向数据库中添加数据
        /// </summary>
        /// <returns></returns>
        public int Add()
        {
            ActionColumnDAL dal = new ActionColumnDAL(connectionString);
            _actioncolumnid = dal.Add(_actioncolumnname, _link);

            return _actioncolumnid;
        }

        //删除指定权限分栏
        public bool DeleteActionColumn()
        {
            ActionColumnDAL dal = new ActionColumnDAL(connectionString);
            return dal.DeleteActionColumn(_actioncolumnid);
        }

        //查询指定的分栏中是否有权限
        public bool Select(int actioncolumnid)
        {
            ActionColumnDAL dal = new ActionColumnDAL(connectionString);
            return dal.Select(actioncolumnid);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            ActionColumnDAL dal = new ActionColumnDAL(connectionString);
            return dal.Update(_actioncolumnid, _actioncolumnname, _link);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            ActionColumnDAL dal = new ActionColumnDAL(connectionString);
            return dal.Delete(_actioncolumnid);
        }

        #region GetActionColumns
        /// <summary>
        /// 获取所有的权限分栏信息
        /// </summary>
        /// <returns></returns>
        public ArrayList GetActionColumns()
        {
            ActionColumnDAL dal = new ActionColumnDAL(connectionString);
            return dal.GetActionColumn();
        }
        #endregion

        /// <summary>
        /// 获取指定权限分栏中的所有权限
        /// </summary>
        /// <returns></returns>
        public ArrayList GetActions()
        {
            ActionColumnDAL dal = new ActionColumnDAL(connectionString);
            return dal.GetActions(_actioncolumnid);
        }
        /// <summary>
        /// 获取指定权限分栏外的所有权限
        /// </summary>
        /// <returns></returns>
        public ArrayList GetExcludeActions()
        {
            ActionColumnDAL dal = new ActionColumnDAL(connectionString);
            return dal.GetExcludeActions(_actioncolumnid);
        }

        //查询所有的权限分栏
        public ArrayList Select()
        {
            ActionColumnDAL dal = new ActionColumnDAL(connectionString);
            return dal.Select();
        }


    }
}
