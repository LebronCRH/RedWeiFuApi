using System;
using System.Collections.Generic;
using System.Text;
using Qing;

namespace DataBaseClasses.components
{
    [PrimaryKey("Id")]
    class MaintenanceService : baseEntity
    {
        private int? _Id;
        [Column(Qing.DataType.Interger)]
        public int? Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _HospitalName;
        public string HospitalName
        {
            get { return _HospitalName; }
            set { _HospitalName = value; }
        }
        private string _Contacts;
        public string Contacts
        {
            get { return _Contacts; }
            set { _Contacts = value; }
        }
        private string _Telephone;
        public string Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; }
        }
        private string _RequirementsDescription;
        public string RequirementsDescription
        {
            get { return _RequirementsDescription; }
            set { _RequirementsDescription = value; }
        }
        private string _Receiver;
        public string Receiver
        {
            get { return _Receiver; }
            set { _Receiver = value; }
        }
        private string _ReceiveTime;
        public string ReceiveTime
        {
            get { return _ReceiveTime; }
            set { _ReceiveTime = value; }
        }
        private string _Source;
        public string Source
        {
            get { return _Source; }
            set { _Source = value; }
        }
        private string _Judger;
        public string Judger
        {
            get { return _Judger; }
            set { _Judger = value; }
        }
        private string _JudgeTime;
        public string JudgeTime
        {
            get { return _JudgeTime; }
            set { _JudgeTime = value; }
        }
        private string _Judge;
        public string Judge
        {
            get { return _Judge; }
            set { _Judge = value; }
        }
        private string _IfAccept;
        public string IfAccept
        {
            get { return _IfAccept; }
            set { _IfAccept = value; }
        }
        private string _InvolveProduct;
        public string InvolveProduct
        {
            get { return _InvolveProduct; }
            set { _InvolveProduct = value; }
        }
        private string _AcceptNumber;
        public string AcceptNumber
        {
            get { return _AcceptNumber; }
            set { _AcceptNumber = value; }
        }
        private string _ServiceLeader;
        public string ServiceLeader
        {
            get { return _ServiceLeader; }
            set { _ServiceLeader = value; }
        }
        private string _IfBusiness;
        public string IfBusiness
        {
            get { return _IfBusiness; }
            set { _IfBusiness = value; }
        }
        private string _Seller;
        public string Seller
        {
            get { return _Seller; }
            set { _Seller = value; }
        }
        private string _SellerOpinion;
        public string SellerOpinion
        {
            get { return _SellerOpinion; }
            set { _SellerOpinion = value; }
        }
        private string _IfDevelop;
        public string IfDevelop
        {
            get { return _IfDevelop; }
            set { _IfDevelop = value; }
        }
        private string _Developer;
        public string Developer
        {
            get { return _Developer; }
            set { _Developer = value; }
        }
        private string _DeveloperOpinion;
        public string DeveloperOpinion
        {
            get { return _DeveloperOpinion; }
            set { _DeveloperOpinion = value; }
        }
        private string _DevelopLevel;
        public string DevelopLevel
        {
            get { return _DevelopLevel; }
            set { _DevelopLevel = value; }
        }
        private string _Revolution;
        public string Revolution
        {
            get { return _Revolution; }
            set { _Revolution = value; }
        }
        private string _Status;
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        private string _EndTime;
        public string EndTime
        {
            get { return _EndTime; }
            set { _EndTime = value; }
        }
        private string _Contract;
        public string Contract
        {
            get { return _Contract; }
            set { _Contract = value; }
        }
        private string _ContractAdd;
        public string ContractAdd
        {
            get { return _ContractAdd; }
            set { _ContractAdd = value; }
        }
        private string _Customer;
        public string Customer
        {
            get { return _Customer; }
            set { _Customer = value; }
        }
        private string _Manager;
        public string Manager
        {
            get { return _Manager; }
            set { _Manager = value; }
        }
        private string _Remarks;
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
        private string _Returner;
        public string Returner
        {
            get { return _Returner; }
            set { _Returner = value; }
        }
        private string _ReturnTime;
        public string ReturnTime
        {
            get { return _ReturnTime; }
            set { _ReturnTime = value; }
        }
        private string _ReturnResult;
        public string ReturnResult
        {
            get { return _ReturnResult; }
            set { _ReturnResult = value; }
        }
        private string _Reviewer;
        public string Reviewer
        {
            get { return _Reviewer; }
            set { _Reviewer = value; }
        }
        private string _ReviewTime;
        public string ReviewTime
        {
            get { return _ReviewTime; }
            set { _ReviewTime = value; }
        }
        private string _ReviewResult;
        public string ReviewResult
        {
            get { return _ReviewResult; }
            set { _ReviewResult = value; }
        }
    }
}
