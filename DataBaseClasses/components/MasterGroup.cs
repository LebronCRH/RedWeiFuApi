using System;
namespace RADinfo_MIS_COST.Model
{
	/// <summary>
	/// 实体类MasterGroup 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class MasterGroup
	{
		public MasterGroup()
		{}
		#region Model
		private int _id;
		private int _masterid;
		private string _mastername;
		private int _groupid;
		private int _masterid2;
		private string _mastername2;
		private DateTime _createdate;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MasterId
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
		public int GroupId
		{
			set{ _groupid=value;}
			get{return _groupid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MasterId2
		{
			set{ _masterid2=value;}
			get{return _masterid2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MasterName2
		{
			set{ _mastername2=value;}
			get{return _mastername2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

