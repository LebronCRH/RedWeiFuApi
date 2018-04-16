using System;
using System.Collections.Generic;
using System.Text;

using RADinfo_MIS_COST.Model;
using RADinfo_MIS_COST.DBDAL;
using System.Security.Cryptography;
using System.Collections;

namespace RADinfo_MIS_COST.BusinessClasses
{
    public class ActionGroupBLL:BusinessObject
    {
        public int _id;
        public int _actionid;
        public int _groupid;
        public int _masterid;
        public string _mastername;
        public DateTime _createdate;

        /// <summary>
        ///  添加数据
        /// </summary>
        /// <returns></returns>
        public int Add()
        {
            ActionGroupDAL dal = new ActionGroupDAL(connectionString);
            _id = dal.Add(_actionid,_groupid,_masterid,_mastername,_createdate);
            return _id;
        }
    }
}
