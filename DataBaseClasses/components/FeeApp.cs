using System;
namespace RADinfo_MIS_COST.Model
{
	/// <summary>
	/// 实体类FeeApp 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class FeeApp
	{
		public FeeApp()
		{}
		#region Model
		
		private int _feeappid;
		private string _feeapptype;
		private string _guestid;
		private string _guestname;
		private string _itemid;
		private string _itemname;
		private string _deptid;
		private string _mastername;
		private string _use;
		private decimal _money;
		private DateTime _registertime;
        private DateTime _starttime;
        private string _special;
        private bool _sh;
        private string _deptname;
        private string _foottime;

        public string Foottime
        {
            get { return _foottime; }
            set { _foottime = value; }
        }

        public string Deptname
        {
            get { return _deptname; }
            set { _deptname = value; }
        }

        public bool Sh
        {
            get { return _sh; }
            set { _sh = value; }
        }


        public string Special
        {
            get { return _special; }
            set { _special = value; }
        }
       
        private DateTime _endtime;

       
        private string _remarks;
        private bool _state;
        private int _updaterid;
        private DateTime _updatetime;
 public DateTime Endtime
        {
            get { return _endtime; }
            set { _endtime = value; }
        }
 public DateTime Starttime
        {
            get { return _starttime; }
            set { _starttime = value; }
        }
        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }
		
		
		/// <summary>
		/// 
		/// </summary>
		public int FeeAppId
		{
			set{ _feeappid=value;}
			get{return _feeappid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FeeAppType
		{
			set{ _feeapptype=value;}
			get{return _feeapptype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GuestId
		{
			set{ _guestid=value;}
			get{return _guestid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GuestName
		{
			set{ _guestname=value;}
			get{return _guestname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ItemId
		{
			set{ _itemid=value;}
			get{return _itemid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ItemName
		{
			set{ _itemname=value;}
			get{return _itemname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DeptId
		{
			set{ _deptid=value;}
			get{return _deptid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MasterName
		{
			set{ _mastername=value;}
			get{return _mastername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string USE
		{
			set{ _use=value;}
			get{return _use;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Decimal Money
		{
			set{ _money=value;}
			get{return _money;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime RegisterTime
		{
			set{ _registertime=value;}
			get{return _registertime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool State
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int UpdateRId
		{
			set{ _updaterid=value;}
			get{return _updaterid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		#endregion Model

	}
}

