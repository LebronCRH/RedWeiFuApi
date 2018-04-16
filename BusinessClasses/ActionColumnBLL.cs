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
        /// ����ָ����ID�������ݿ��ж�ȡ������Ϣ
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
        /// �����ݿ����������
        /// </summary>
        /// <returns></returns>
        public int Add()
        {
            ActionColumnDAL dal = new ActionColumnDAL(connectionString);
            _actioncolumnid = dal.Add(_actioncolumnname, _link);

            return _actioncolumnid;
        }

        //ɾ��ָ��Ȩ�޷���
        public bool DeleteActionColumn()
        {
            ActionColumnDAL dal = new ActionColumnDAL(connectionString);
            return dal.DeleteActionColumn(_actioncolumnid);
        }

        //��ѯָ���ķ������Ƿ���Ȩ��
        public bool Select(int actioncolumnid)
        {
            ActionColumnDAL dal = new ActionColumnDAL(connectionString);
            return dal.Select(actioncolumnid);
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            ActionColumnDAL dal = new ActionColumnDAL(connectionString);
            return dal.Update(_actioncolumnid, _actioncolumnname, _link);
        }
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            ActionColumnDAL dal = new ActionColumnDAL(connectionString);
            return dal.Delete(_actioncolumnid);
        }

        #region GetActionColumns
        /// <summary>
        /// ��ȡ���е�Ȩ�޷�����Ϣ
        /// </summary>
        /// <returns></returns>
        public ArrayList GetActionColumns()
        {
            ActionColumnDAL dal = new ActionColumnDAL(connectionString);
            return dal.GetActionColumn();
        }
        #endregion

        /// <summary>
        /// ��ȡָ��Ȩ�޷����е�����Ȩ��
        /// </summary>
        /// <returns></returns>
        public ArrayList GetActions()
        {
            ActionColumnDAL dal = new ActionColumnDAL(connectionString);
            return dal.GetActions(_actioncolumnid);
        }
        /// <summary>
        /// ��ȡָ��Ȩ�޷����������Ȩ��
        /// </summary>
        /// <returns></returns>
        public ArrayList GetExcludeActions()
        {
            ActionColumnDAL dal = new ActionColumnDAL(connectionString);
            return dal.GetExcludeActions(_actioncolumnid);
        }

        //��ѯ���е�Ȩ�޷���
        public ArrayList Select()
        {
            ActionColumnDAL dal = new ActionColumnDAL(connectionString);
            return dal.Select();
        }


    }
}
