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
    public class RelationsBLL:BusinessObject
    {
        public int _id;
        public int _messageid;
        public int _messageid2;

        public RelationsBLL()
            : base()
        {
            _id = -1;
        }

          /// <summary>
        /// 添加关联信息
        /// </summary>
        /// <param name="messageid">信息ID</param>
        /// <param name="messageid2">关联信息ID</param>
        /// <returns></returns>
        public int Add()
        {
            RelationsDAL dal = new RelationsDAL(connectionString);
            _id= dal.Add(_messageid, _messageid2);
            return _id;
        }

        /// <summary>
        /// 查询关联信息
        /// </summary>
        /// <param name="messageid"></param>
        /// <returns></returns>
        public ArrayList GetRelations()
        {
            RelationsDAL dal = new RelationsDAL(connectionString);
            return dal.GetRelations(_messageid);
        }
    }
}
