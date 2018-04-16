using System;
namespace RADinfo_MIS_COST.Model
{
	/// <summary>
	/// 实体类ActionGroup 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class ActionGroup
	{
		public ActionGroup()
		{}
		#region Model
		private int _id;
		private int _actionid;
		private int _groupid;
		private int _masterid;
		private string _mastername;
		private DateTime _createdate;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ActionId
		{
			set{ _actionid=value;}
			get{return _actionid;}
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
		public DateTime CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

