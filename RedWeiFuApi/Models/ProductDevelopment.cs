using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedWeiFuApi.Models
{
    public class ProductDevelopment
    {
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
        /// ProName
        /// </summary>		
        private string _proname;
        public string ProName
        {
            get { return _proname; }
            set { _proname = value; }
        }
        /// <summary>
        /// ProFunctionDes
        /// </summary>		
        private string _profunctiondes;
        public string ProFunctionDes
        {
            get { return _profunctiondes; }
            set { _profunctiondes = value; }
        }
        /// <summary>
        /// ProApprovalFilePath
        /// </summary>		
        private string _proapprovalfilepath;
        public string ProApprovalFilePath
        {
            get { return _proapprovalfilepath; }
            set { _proapprovalfilepath = value; }
        }
        /// <summary>
        /// ProApprovalTime
        /// </summary>		
        private string _proapprovaltime;
        public string ProApprovalTime
        {
            get { return _proapprovaltime; }
            set { _proapprovaltime = value; }
        }
        /// <summary>
        /// ProDevFilePath
        /// </summary>		
        private string _prodevfilepath;
        public string ProDevFilePath
        {
            get { return _prodevfilepath; }
            set { _prodevfilepath = value; }
        }
        /// <summary>
        /// ProDevDesigner
        /// </summary>		
        private string _prodevdesigner;
        public string ProDevDesigner
        {
            get { return _prodevdesigner; }
            set { _prodevdesigner = value; }
        }
        /// <summary>
        /// ProDevTime
        /// </summary>		
        private string _prodevtime;
        public string ProDevTime
        {
            get { return _prodevtime; }
            set { _prodevtime = value; }
        }
        /// <summary>
        /// ProDevReviewer
        /// </summary>		
        private string _prodevreviewer;
        public string ProDevReviewer
        {
            get { return _prodevreviewer; }
            set { _prodevreviewer = value; }
        }
        /// <summary>
        /// ProDevReviewTime
        /// </summary>		
        private string _prodevreviewtime;
        public string ProDevReviewTime
        {
            get { return _prodevreviewtime; }
            set { _prodevreviewtime = value; }
        }
        /// <summary>
        /// ProDevReviewResult
        /// </summary>		
        private string _prodevreviewresult;
        public string ProDevReviewResult
        {
            get { return _prodevreviewresult; }
            set { _prodevreviewresult = value; }
        }
        /// <summary>
        /// ProDevLeader
        /// </summary>		
        private string _prodevleader;
        public string ProDevLeader
        {
            get { return _prodevleader; }
            set { _prodevleader = value; }
        }
        /// <summary>
        /// ProDeveloper
        /// </summary>		
        private string _prodeveloper;
        public string ProDeveloper
        {
            get { return _prodeveloper; }
            set { _prodeveloper = value; }
        }
        /// <summary>
        /// ProManualUser
        /// </summary>		
        private string _promanualuser;
        public string ProManualUser
        {
            get { return _promanualuser; }
            set { _promanualuser = value; }
        }
        /// <summary>
        /// ProManualTime
        /// </summary>		
        private string _promanualtime;
        public string ProManualTime
        {
            get { return _promanualtime; }
            set { _promanualtime = value; }
        }
        /// <summary>
        /// ProManualFilePath
        /// </summary>		
        private string _promanualfilepath;
        public string ProManualFilePath
        {
            get { return _promanualfilepath; }
            set { _promanualfilepath = value; }
        }
        /// <summary>
        /// ProStatus
        /// </summary>		
        private string _prostatus;
        public string ProStatus
        {
            get { return _prostatus; }
            set { _prostatus = value; }
        }
        /// <summary>
        /// ProInsideReviewer
        /// </summary>		
        private string _proinsidereviewer;
        public string ProInsideReviewer
        {
            get { return _proinsidereviewer; }
            set { _proinsidereviewer = value; }
        }

        public string ProTime { get; set; }
    }
}