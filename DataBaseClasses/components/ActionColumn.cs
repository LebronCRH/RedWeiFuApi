using System;
namespace RADinfo_MIS_COST.Model
{
	/// <summary>
	/// ʵ����ActionColumn ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class ActionColumn
	{
		public ActionColumn()
		{}
		#region Model
		private int _actioncolumnid;
		private string _actioncolumnname;
        private string _link;
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
		public string ActionColumnName
		{
			set{ _actioncolumnname=value;}
			get{return _actioncolumnname;}
		}

        public string Link
        {
            set { _link=value ;}
            get { return _link; }
        }
		#endregion Model

	}
}

