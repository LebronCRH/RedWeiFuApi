using System;
namespace RADinfo_MIS_COST.Model
{
	/// <summary>
	/// ʵ����GroupManager ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class GroupManager
	{
		public GroupManager()
		{}
		#region Model
		private int _groupid;
		private string _groupname;
		private string _groupinfo;
		private int _masterid;
		private string _mastername;
		private DateTime _createdate;
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
		public string GroupName
		{
			set{ _groupname=value;}
			get{return _groupname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GroupInfo
		{
			set{ _groupinfo=value;}
			get{return _groupinfo;}
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

