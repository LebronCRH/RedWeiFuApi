using System;
namespace RADinfo_MIS_COST.Model
{
	/// <summary>
	/// 实体类Master 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class Master
	{
		public Master()
		{}
		#region Model
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
		private string _masterid;
		private string _mastername;
		private byte[] _password;
		private string _truename;
		private string _sex;
		private DateTime _birthday;
		private string _deptid;
		private string _position;
		private string _position_desc;
		private string _office_phone;
		private string _mobile;
		private string _home_phone;
		private string _email;
		private int _createid;
		private string _createname;
		private DateTime _createdate;
		private DateTime _ruzhitime;
		private DateTime _lizhitime;
        private string _deptname;

        public string Deptname
        {
            get { return _deptname; }
            set { _deptname = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string MasterId
		{
			set{ _masterid=value;}
			get{return _masterid;}
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
		public byte[] Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TrueName
		{
			set{ _truename=value;}
			get{return _truename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
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
		public string Position
		{
			set{ _position=value;}
			get{return _position;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Position_Desc
		{
			set{ _position_desc=value;}
			get{return _position_desc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Office_phone
		{
			set{ _office_phone=value;}
			get{return _office_phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Home_Phone
		{
			set{ _home_phone=value;}
			get{return _home_phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CreateId
		{
			set{ _createid=value;}
			get{return _createid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CreateName
		{
			set{ _createname=value;}
			get{return _createname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime RuzhiTime
		{
			set{ _ruzhitime=value;}
			get{return _ruzhitime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime LizhiTime
		{
			set{ _lizhitime=value;}
			get{return _lizhitime;}
		}
		#endregion Model

	}
}

