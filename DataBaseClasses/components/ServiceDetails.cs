using System;
using System.Collections.Generic;
using System.Text;
using Qing;

namespace DataBaseClasses.components
{
    [PrimaryKey("Id")]
    class ServiceDetails : baseEntity
    {
        private int? _Id;
        [Column(Qing.DataType.Interger)]
        public int? Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _AcceptNumber;
        public string AcceptNumber
        {
            get { return _AcceptNumber; }
            set { _AcceptNumber = value; }
        }
        private string _ServiceEngineer;
        public string ServiceEngineer
        {
            get { return _ServiceEngineer; }
            set { _ServiceEngineer = value; }
        }
        private string _Objection;
        public string Objection
        {
            get { return _Objection; }
            set { _Objection = value; }
        }
        private string _Plication;
        public string Plication
        {
            get { return _Plication; }
            set { _Plication = value; }
        }
        private string _PlicationTime;
        public string PlicationTime
        {
            get { return _PlicationTime; }
            set { _PlicationTime = value; }
        }
        private string _ServiceHours;
        public string ServiceHours
        {
            get { return _ServiceHours; }
            set { _ServiceHours = value; }
        }
        private string _Contactor;
        public string Contactor
        {
            get { return _Contactor; }
            set { _Contactor = value; }
        }
        private string _HandleMode;
        public string HandleMode
        {
            get { return _HandleMode; }
            set { _HandleMode = value; }
        }
        private string _CustomerOpinion;
        public string CustomerOpinion
        {
            get { return _CustomerOpinion; }
            set { _CustomerOpinion = value; }
        }
        private string _Remarks;
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
        private string _Checker;
        public string Checker
        {
            get { return _Checker; }
            set { _Checker = value; }
        }
        private string _CheckOpinion;
        public string CheckOpinion
        {
            get { return _CheckOpinion; }
            set { _CheckOpinion = value; }
        }
    }
}
