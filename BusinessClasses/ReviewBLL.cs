using System;
using System.Collections.Generic;
using System.Text;
using RADinfo_MIS_COST;
using RADinfo_MIS_COST.Model;
using RADinfo_MIS_COST.DBDAL;
using System.Security.Cryptography;
using System.Collections;
using System.Configuration;

namespace RADinfo_MIS_COST.BusinessClasses
{
    public class ReviewBLL : BusinessObject
    {
        public int _id;
        public int _feeappid;
        public int _masterid;
        public string _mastername;
        public DateTime _reviewtime;
        public string _advice;
        public bool _state;
        public string _foottime;

        public ReviewBLL()
            : base()
        {
            _id = -1;
        }

        /// <summary>
        /// 查询指定申请单的审核意见
        /// </summary>
        /// <param name="feeappid"></param>
        /// <returns></returns>
        public ArrayList Select()
        {
            ReviewDAL dal = new ReviewDAL(connectionString);
            return dal.Select(_feeappid);
        }

        /// <summary>
        /// 查询是否已审核了，则不能修改了
        /// </summary>
        /// <param name="feeappid"></param>
        /// <returns></returns>
        public bool GetYNSH()
        {
            ReviewDAL dal = new ReviewDAL(connectionString);
            bool flsh= dal.GetYNSH(_feeappid);
            return flsh;
        }

        /// <summary>
        /// 向数据库添加一条记录
        /// </summary>
        /// <param name="actionname"></param>
        /// <param name="actioncolumnid"></param>
        /// <param name="actionstr"></param>
        /// <param name="viewmode"></param>
        /// <returns>返回ID</returns>
        public int Add()
        {
            ReviewDAL dal = new ReviewDAL(connectionString);
            return dal.Add(_feeappid, _masterid, _mastername, _reviewtime, _advice, _state);
        }

        /// <summary>
        /// 查询副总经理是否审核通过
        /// </summary>
        /// <param name="feeappid"></param>
        /// <returns></returns>
        public bool GetFZstate()
        {
            ReviewDAL dal = new ReviewDAL(connectionString);
            return dal.GetFZstate(_feeappid);
        }

         /// <summary>
        /// 查询财务经理是否审核通过
        /// </summary>
        /// <param name="feeappid"></param>
        /// <returns></returns>
        public bool GetCWstate()
        {
            ReviewDAL dal = new ReviewDAL(connectionString);
            return dal.GetCWstate(_feeappid);
        }

        /// <summary>
        /// 审核状态
        /// </summary>
        /// <param name="feeappid"></param>
        /// <param name="groupname"></param>
        /// <returns></returns>
        public bool GetSHstate(int feeappid, string groupname)
        {
            ReviewDAL dal = new ReviewDAL(connectionString);
            return dal.GetSHstate(feeappid,groupname);
        }

        /// <summary>
        /// 如果副总经理和财务经理审核通过后就修改费用表的state字段，该申请单生效
        /// </summary>
        /// <param name="feeappid"></param>
        /// <returns></returns>
        public bool UpdateFeeApp()
        {

            ReviewDAL dal = new ReviewDAL(connectionString);
            return dal.UpdateFeeApp(_feeappid,_foottime);
        }

        /// <summary>
        /// 判断是否审核
        /// </summary>
        /// <param name="mastername"></param>
        /// <param name="feeappid"></param>
        /// <returns></returns>
        public bool GetYN(string mastername, int feeappid)
        {
            ReviewDAL dal = new ReviewDAL(connectionString);
            return dal.GetYN(mastername, feeappid);
        }
       
    }
}
