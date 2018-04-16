using System;
namespace RADinfo_MIS_COST.Model
{
	/// <summary>
	/// 实体类Department 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class Department
	{
		public Department()
		{}
		#region Model
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
		private string _deptid;
		private string _deptname;
		private bool _state;
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
		public string DeptName
		{
			set{ _deptname=value;}
			get{return _deptname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool state
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model

	}
}

