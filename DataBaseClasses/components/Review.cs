using System;
namespace RADinfo_MIS_COST.Model
{
	/// <summary>
	/// ʵ����Review ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class Review
	{
		public Review()
		{}
		#region Model
		private int _id;
		private int _feeappid;
		private int _masterid;
		private string _mastername;
		private DateTime _reviewtime;
		private string _advice;
		private bool _state;
        private string _groupname;
        private string _truename;

        public string Truename
        {
            get { return _truename; }
            set { _truename = value; }
        }

        public string Groupname
        {
            get { return _groupname; }
            set { _groupname = value; }
        }
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
		public int FeeAppId
		{
			set{ _feeappid=value;}
			get{return _feeappid;}
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
		public DateTime ReviewTime
		{
			set{ _reviewtime=value;}
			get{return _reviewtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Advice
		{
			set{ _advice=value;}
			get{return _advice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool State
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model

	}
}

