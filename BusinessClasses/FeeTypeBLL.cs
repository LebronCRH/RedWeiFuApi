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
    public class FeeTypeBLL : BusinessObject
    {
        public int _id;
        public string _feeid;
        public string _feetypname;
        public string _feetype_desc;

        public FeeTypeBLL()
            : base()
        {
            _id = -1;
        }
         /// <summary>
        /// 添加数据 
        /// </summary>
        /// <param name="feeid"></param>
        /// <param name="feetypename"></param>
        /// <param name="feetype_desc"></param>
        /// <returns></returns>
        public int Add()
        {
            FeeTypeDAL dal = new FeeTypeDAL(connectionString);
            _id= dal.Add(_feeid, _feetypname, _feetype_desc);
            return _id;
        }

              /// <summary>
        /// 查询
        /// </summary>
        /// <param name="feetypename"></param>
        /// <returns></returns>
        public ArrayList Select(string feetypename,string id)
        {
            FeeTypeDAL dal = new FeeTypeDAL(connectionString);
            return dal.Select(feetypename,id);
        }

          /// <summary>
        /// 删除制定数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete()
        {
            FeeTypeDAL dal = new FeeTypeDAL(connectionString);
            return dal.Delete(_id);
        }

          /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="feeid"></param>
        /// <param name="feetypename"></param>
        /// <param name="feetype_desc"></param>
        /// <returns></returns>
        public bool Update()
        {
            FeeTypeDAL dal = new FeeTypeDAL(connectionString);
            return dal.Update(_id, _feeid, _feetypname, _feetype_desc);
        }

    }
}
