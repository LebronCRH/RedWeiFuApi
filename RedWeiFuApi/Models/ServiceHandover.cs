using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedWeiFuApi.Models
{
    public class ServiceHandover
    {
        public ServiceHandover()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }


        /// <summary>
        /// auto_increment
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// SerHandClass
        /// </summary>		
        private string _serhandclass;
        public string SerHandClass
        {
            get { return _serhandclass; }
            set { _serhandclass = value; }
        }
        /// <summary>
        /// SerHospitalName
        /// </summary>		
        private string _serhospitalname;
        public string SerHospitalName
        {
            get { return _serhospitalname; }
            set { _serhospitalname = value; }
        }
        /// <summary>
        /// SerHospitalArea
        /// </summary>		
        private string _serhospitalarea;
        public string SerHospitalArea
        {
            get { return _serhospitalarea; }
            set { _serhospitalarea = value; }
        }
        /// <summary>
        /// SerStatus
        /// </summary>		
        private string _serstatus;
        public string SerStatus
        {
            get { return _serstatus; }
            set { _serstatus = value; }
        }
        /// <summary>
        /// SerLinkman
        /// </summary>		
        private string _serlinkman;
        public string SerLinkman
        {
            get { return _serlinkman; }
            set { _serlinkman = value; }
        }
        /// <summary>
        /// SerLinkPhone
        /// </summary>		
        private string _serlinkphone;
        public string SerLinkPhone
        {
            get { return _serlinkphone; }
            set { _serlinkphone = value; }
        }
        /// <summary>
        /// SerProposer
        /// </summary>		
        private string _serproposer;
        public string SerProposer
        {
            get { return _serproposer; }
            set { _serproposer = value; }
        }
        /// <summary>
        /// SerProposeTime
        /// </summary>		
        private string _serproposetime;
        public string SerProposeTime
        {
            get { return _serproposetime; }
            set { _serproposetime = value; }
        }
        /// <summary>
        /// SerNature
        /// </summary>		
        private string _sernature;
        public string SerNature
        {
            get { return _sernature; }
            set { _sernature = value; }
        }
        /// <summary>
        /// SerContractNo
        /// </summary>		
        private string _sercontractno;
        public string SerContractNo
        {
            get { return _sercontractno; }
            set { _sercontractno = value; }
        }
        /// <summary>
        /// SerContractName
        /// </summary>		
        private string _sercontractname;
        public string SerContractName
        {
            get { return _sercontractname; }
            set { _sercontractname = value; }
        }
        /// <summary>
        /// SerCustomerUnit
        /// </summary>		
        private string _sercustomerunit;
        public string SerCustomerUnit
        {
            get { return _sercustomerunit; }
            set { _sercustomerunit = value; }
        }
        /// <summary>
        /// SerOnlyOne
        /// </summary>		
        private string _seronlyone;
        public string SerOnlyOne
        {
            get { return _seronlyone; }
            set { _seronlyone = value; }
        }
        /// <summary>
        /// SerConSDate
        /// </summary>		
        private string _serconsdate;
        public string SerConSDate
        {
            get { return _serconsdate; }
            set { _serconsdate = value; }
        }
        /// <summary>
        /// SerConEDate
        /// </summary>		
        private string _serconedate;
        public string SerConEDate
        {
            get { return _serconedate; }
            set { _serconedate = value; }
        }
        /// <summary>
        /// SerConContent
        /// </summary>		
        private string _serconcontent;
        public string SerConContent
        {
            get { return _serconcontent; }
            set { _serconcontent = value; }
        }
        /// <summary>
        /// SerPolling
        /// </summary>		
        private string _serpolling;
        public string SerPolling
        {
            get { return _serpolling; }
            set { _serpolling = value; }
        }
        /// <summary>
        /// SerPollingNum
        /// </summary>		
        private string _serpollingnum;
        public string SerPollingNum
        {
            get { return _serpollingnum; }
            set { _serpollingnum = value; }
        }
        /// <summary>
        /// SerPollFilePath
        /// </summary>		
        private string _serpollfilepath;
        public string SerPollFilePath
        {
            get { return _serpollfilepath; }
            set { _serpollfilepath = value; }
        }
        /// <summary>
        /// SerRemark
        /// </summary>		
        private string _serremark;
        public string SerRemark
        {
            get { return _serremark; }
            set { _serremark = value; }
        }
        /// <summary>
        /// SerReviewOpinion
        /// </summary>		
        private string _serreviewopinion;
        public string SerReviewOpinion
        {
            get { return _serreviewopinion; }
            set { _serreviewopinion = value; }
        }
        /// <summary>
        /// SerReviewer
        /// </summary>		
        private string _serreviewer;
        public string SerReviewer
        {
            get { return _serreviewer; }
            set { _serreviewer = value; }
        }
        /// <summary>
        /// SerReviewDate
        /// </summary>		
        private string _serreviewdate;
        public string SerReviewDate
        {
            get { return _serreviewdate; }
            set { _serreviewdate = value; }
        }
        /// <summary>
        /// SerAfterSaleOpinion
        /// </summary>		
        private string _seraftersaleopinion;
        public string SerAfterSaleOpinion
        {
            get { return _seraftersaleopinion; }
            set { _seraftersaleopinion = value; }
        }
        /// <summary>
        /// SerLevel
        /// </summary>		
        private string _serlevel;
        public string SerLevel
        {
            get { return _serlevel; }
            set { _serlevel = value; }
        }
        /// <summary>
        /// SerDutyUser
        /// </summary>		
        private string _serdutyuser;
        public string SerDutyUser
        {
            get { return _serdutyuser; }
            set { _serdutyuser = value; }
        }
        /// <summary>
        /// SerAfterSaleManager
        /// </summary>		
        private string _seraftersalemanager;
        public string SerAfterSaleManager
        {
            get { return _seraftersalemanager; }
            set { _seraftersalemanager = value; }
        }
        /// <summary>
        /// SerAffirmDate
        /// </summary>		
        private string _seraffirmdate;
        public string SerAffirmDate
        {
            get { return _seraffirmdate; }
            set { _seraffirmdate = value; }
        }
        /// <summary>
        /// SerRmind
        /// </summary>		
        private string _serrmind;
        public string SerRmind
        {
            get { return _serrmind; }
            set { _serrmind = value; }
        }
        /// <summary>
        /// SerMemo
        /// </summary>		
        private string _sermemo;
        public string SerMemo
        {
            get { return _sermemo; }
            set { _sermemo = value; }
        }
        /// <summary>
        /// SerLeftover
        /// </summary>		
        private string _serleftover;
        public string SerLeftover
        {
            get { return _serleftover; }
            set { _serleftover = value; }
        }
        /// <summary>
        /// SerOperator
        /// </summary>		
        private string _seroperator;
        public string SerOperator
        {
            get { return _seroperator; }
            set { _seroperator = value; }
        }
        /// <summary>
        /// SerDate
        /// </summary>		
        private string _serdate;
        public string SerDate
        {
            get { return _serdate; }
            set { _serdate = value; }
        }

    }
}