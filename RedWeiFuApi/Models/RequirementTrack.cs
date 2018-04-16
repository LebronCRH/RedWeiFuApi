using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedWeiFuApi.Models
{
    public class RequirementTrack
    {
        /// <summary>
        /// auto_increment
        /// </summary>		
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// ReqTitle
        /// </summary>		
        private string _reqtitle;
        public string ReqTitle
        {
            get { return _reqtitle; }
            set { _reqtitle = value; }
        }
        /// <summary>
        /// ReqContent
        /// </summary>		
        private string _reqcontent;
        public string ReqContent
        {
            get { return _reqcontent; }
            set { _reqcontent = value; }
        }
        /// <summary>
        /// ReqHospital
        /// </summary>		
        private string _reqhospital;
        public string ReqHospital
        {
            get { return _reqhospital; }
            set { _reqhospital = value; }
        }
        /// <summary>
        /// ReqSource
        /// </summary>		
        private string _reqsource;
        public string ReqSource
        {
            get { return _reqsource; }
            set { _reqsource = value; }
        }
        /// <summary>
        /// ReqAssignDev
        /// </summary>		
        private string _reqassigndev;
        public string ReqAssignDev
        {
            get { return _reqassigndev; }
            set { _reqassigndev = value; }
        }
        /// <summary>
        /// ReqRegistrer
        /// </summary>		
        private string _reqregistrer;
        public string ReqRegistrer
        {
            get { return _reqregistrer; }
            set { _reqregistrer = value; }
        }
        /// <summary>
        /// ReqDeveloper
        /// </summary>		
        private string _reqdeveloper;
        public string ReqDeveloper
        {
            get { return _reqdeveloper; }
            set { _reqdeveloper = value; }
        }
        /// <summary>
        /// ReqStatus
        /// </summary>		
        private string _reqstatus;
        public string ReqStatus
        {
            get { return _reqstatus; }
            set { _reqstatus = value; }
        }
        /// <summary>
        /// ReqTime
        /// </summary>		
        private string _reqtime;
        public string ReqTime
        {
            get { return _reqtime; }
            set { _reqtime = value; }
        }
        /// <summary>
        /// ReqReplyTime
        /// </summary>		
        private string _reqreplytime;
        public string ReqReplyTime
        {
            get { return _reqreplytime; }
            set { _reqreplytime = value; }
        }
        /// <summary>
        /// ReqRemark
        /// </summary>		
        private string _reqremark;
        public string ReqRemark
        {
            get { return _reqremark; }
            set { _reqremark = value; }
        }
        /// <summary>
        /// ReqDel
        /// </summary>		
        private int _reqdel;
        public int ReqDel
        {
            get { return _reqdel; }
            set { _reqdel = value; }
        }
        /// <summary>
        /// ReqHospitalParent
        /// </summary>		
        private string _reqhospitalparent;
        public string ReqHospitalParent
        {
            get { return _reqhospitalparent; }
            set { _reqhospitalparent = value; }
        }
        /// <summary>
        /// ReqResult
        /// </summary>		
        private string _reqresult;
        public string ReqResult
        {
            get { return _reqresult; }
            set { _reqresult = value; }
        }
        /// <summary>
        /// ReqReviewRemark
        /// </summary>		
        private string _reqreviewremark;
        public string ReqReviewRemark
        {
            get { return _reqreviewremark; }
            set { _reqreviewremark = value; }
        }
        /// <summary>
        /// ReqFillBackReason
        /// </summary>		
        private string _reqfillbackreason;
        public string ReqFillBackReason
        {
            get { return _reqfillbackreason; }
            set { _reqfillbackreason = value; }
        }
        /// <summary>
        /// ReqReviewTime
        /// </summary>		
        private string _reqreviewtime;
        public string ReqReviewTime
        {
            get { return _reqreviewtime; }
            set { _reqreviewtime = value; }
        }
        /// <summary>
        /// ReqReviewer
        /// </summary>		
        private string _reqreviewer;
        public string ReqReviewer
        {
            get { return _reqreviewer; }
            set { _reqreviewer = value; }
        }
        /// <summary>
        /// ReqServiceName
        /// </summary>		
        private string _reqservicename;
        public string ReqServiceName
        {
            get { return _reqservicename; }
            set { _reqservicename = value; }
        }
        /// <summary>
        /// ReqServiceId
        /// </summary>		
        private string _reqserviceid;
        public string ReqServiceId
        {
            get { return _reqserviceid; }
            set { _reqserviceid = value; }
        }
        /// <summary>
        /// ReqTestSTime
        /// </summary>		
        private string _reqteststime;
        public string ReqTestSTime
        {
            get { return _reqteststime; }
            set { _reqteststime = value; }
        }
        /// <summary>
        /// ReqTester
        /// </summary>		
        private string _reqtester;
        public string ReqTester
        {
            get { return _reqtester; }
            set { _reqtester = value; }
        }
        /// <summary>
        /// ReqTestETime
        /// </summary>		
        private string _reqtestetime;
        public string ReqTestETime
        {
            get { return _reqtestetime; }
            set { _reqtestetime = value; }
        }
        /// <summary>
        /// ReqTestReviewResult
        /// </summary>		
        private string _reqtestreviewresult;
        public string ReqTestReviewResult
        {
            get { return _reqtestreviewresult; }
            set { _reqtestreviewresult = value; }
        }
        /// <summary>
        /// ReqTestReviewTime
        /// </summary>		
        private string _reqtestreviewtime;
        public string ReqTestReviewTime
        {
            get { return _reqtestreviewtime; }
            set { _reqtestreviewtime = value; }
        }
        /// <summary>
        /// ReqTestReviewer
        /// </summary>		
        private string _reqtestreviewer;
        public string ReqTestReviewer
        {
            get { return _reqtestreviewer; }
            set { _reqtestreviewer = value; }
        }
        /// <summary>
        /// ReqClass
        /// </summary>		
        private int _reqclass;
        public int ReqClass
        {
            get { return _reqclass; }
            set { _reqclass = value; }
        }
        /// <summary>
        /// ReqFunModule
        /// </summary>		
        private string _reqfunmodule;
        public string ReqFunModule
        {
            get { return _reqfunmodule; }
            set { _reqfunmodule = value; }
        }
        public string ReqEndResult { get; set; }
        public string ReqEndReviewer { get; set; }
        public string ReqEndTime { get; set; }
    }
}