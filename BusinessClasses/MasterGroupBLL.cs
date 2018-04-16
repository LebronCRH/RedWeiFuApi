using System;
using System.Collections.Generic;
using System.Text;

using RADinfo_MIS_COST.Model;
using RADinfo_MIS_COST.DBDAL;
using System.Security.Cryptography;
using System.Collections;

namespace RADinfo_MIS_COST.BusinessClasses
{
    public class MasterGroupBLL:BusinessObject
    {
        public int _id;
        public int _masterid;
        public string _mastername;
        public int _groupid;
        public int _masterid2;
        public string _mastername2;
        public DateTime _createdate;

        #region Add
        /// <summary>
        /// 添加（管理组）角色分配
        /// </summary>
        /// <returns></returns>
        public int Add()
        {
            MasterGroupDAL dal = new MasterGroupDAL(connectionString);
            _id = dal.Add(_masterid,_mastername,_groupid,_masterid2,_mastername2,_createdate);
            return _id;
        }
        #endregion
    }
}
