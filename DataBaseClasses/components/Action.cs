using System;
namespace RADinfo_MIS_COST.Model
{
	/// <summary>
	/// 实体类Action 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class Action
	{
		public Action()
		{}
		#region Model
		private int _actionid;
		private string _actionname;
		private int _actioncolumnid;
		private string _actionstr;
		private bool _viewmode;
        private string _link;
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
		public string ActionName
		{
			set{ _actionname=value;}
			get{return _actionname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ActionColumnid
		{
			set{ _actioncolumnid=value;}
			get{return _actioncolumnid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ActionStr
		{
			set{ _actionstr=value;}
			get{return _actionstr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool ViewMode
		{
			set{ _viewmode=value;}
			get{return _viewmode;}
		}

        public string Link
        {
            set { _link = value; }
            get { return _link;}
        }
		#endregion Model

	}
}

