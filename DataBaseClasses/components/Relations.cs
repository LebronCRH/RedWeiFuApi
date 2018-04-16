using System;
namespace RADinfo_MIS_COST.Model
{
	/// <summary>
	/// 实体类Relations 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class Relations
	{
		public Relations()
		{}
		#region Model
		private int _id;
		private int _messageid;
		private int _messageid2;
		private DateTime _createtime;
		private int _masterid;
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
		public int MessageId
		{
			set{ _messageid=value;}
			get{return _messageid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MessageId2
		{
			set{ _messageid2=value;}
			get{return _messageid2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MasterId
		{
			set{ _masterid=value;}
			get{return _masterid;}
		}
		#endregion Model

	}
}

