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
    public class FeeAppBLL:BusinessObject
    {
        public int _feeappid;
        public string _feeapptype;
        public string _guestid;
        public string _guestname;
        public string _itemid;
        public string _itemname;
        public string _deptid;
        public string _mastername;
        public string _use;
        public decimal _money;
        public DateTime _registertime;
        public string _remarks;
        public bool _state;
        public int _updaterid;
        public DateTime _updatetime;
        public DateTime _starttime;
        public DateTime _endtime;
        public string _special;
        public DateTime _foottime;

        public FeeAppBLL()
            : base()
        {
            _feeappid=-1;
        }

         //查询是否有修改权限的方法
        public string XGQX()
        {
            FeeAppDAL dal = new FeeAppDAL(connectionString);
            return dal.XGQX(_feeappid);
        }

        /// <summary>
        /// 删除申请单
        /// </summary>
        /// <param name="feeappid"></param>
        /// <returns></returns>
        public bool DeleteFeeApp()
        {
            FeeAppDAL dal = new FeeAppDAL(connectionString);
            return dal.DeleteFeeApp(_feeappid);
        }

           /// <summary>
        /// 更新申请单
        /// </summary>
        /// <param name="feeapptype"></param>
        /// <param name="deptid"></param>
        /// <param name="mastername"></param>
        /// <param name="use"></param>
        /// <param name="money"></param>
        /// <param name="registertime"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="remarks"></param>
        /// <param name="special"></param>
        /// <param name="feeappid"></param>
        /// <returns></returns>
        public bool UpdateFeeApp()
        {
            FeeAppDAL dal = new FeeAppDAL(connectionString);
            return dal.UpdateFeeApp(_feeapptype,_guestid,_itemid, _deptid, _mastername, _use, _money, _registertime, _starttime, _endtime, _remarks, _special, _feeappid);
        }

        //查询指定申请单
        public FeeApp Select()
        {
            FeeAppDAL dal = new FeeAppDAL(connectionString);
            return dal.Select(_feeappid);
        }

        /// <summary>
        /// 添加申请单
        /// </summary>
        /// <returns></returns>
        public int Add()
        {
            FeeAppDAL dal = new FeeAppDAL(connectionString);
            return dal.Add(_feeapptype,_guestid,_itemid, _deptid, _mastername, _use, _money, _registertime,_starttime,_endtime, _remarks,_special);
        }

        /// <summary>
        /// 获取指定用户已经通过审核后的申请单
        /// </summary>
        /// <param name="mastername"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public ArrayList GetYFeeApp(string mastername,bool state,DateTime registertime,string xuanze)
        {
            FeeAppDAL dal = new FeeAppDAL(connectionString);
            return dal.GetYFeeApp(mastername,state,registertime,xuanze);
        }


         /// <summary>
        /// 指定部门的所有申请单
        /// </summary>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public ArrayList GetBMFeeApp(string deptid,string feeapptype, string state, string registertime1, string registertime2,string mastername)
        {
            FeeAppDAL dal = new FeeAppDAL(connectionString);
            return dal.GetBMFeeApp(deptid,feeapptype,state,registertime1,registertime2,mastername);
        }

         /// <summary>
        /// 查询公司所有的申请单
        /// </summary>
        /// <returns></returns>
        public ArrayList GetGSFeeApp(string state,string feeapptype, string registertime1, string registertime2,string mastername)
        {
            FeeAppDAL dal = new FeeAppDAL(connectionString);
            return dal.GetGSFeeApp(state,feeapptype ,registertime1, registertime2,mastername);
        }

        /// <summary>
        /// 查询指定用户已审核后的申请单
        /// </summary>
        /// <returns></returns>
        public bool GetEndReview(int feeappid, int masterid)
        {
            ReviewDAL dal = new ReviewDAL(connectionString);
            return dal.GetEndReview(feeappid, masterid);
        }
    }
}
