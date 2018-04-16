using System;
namespace RADinfo_MIS_COST.Model
{
	/// <summary>
	/// 实体类Messages 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class Messages
	{
		public Messages()
		{}
		#region Model

        private int _messageid;
        private string _mastername;
        private string _name;
        private string _keyword;

        public string Keyword
        {
            get { return _keyword; }
            set { _keyword = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Mastername
        {
            get { return _mastername; }
            set { _mastername = value; }
        }      
		private string _type;
		private string _title;
		private string _content;
		private DateTime _createtime;
		private bool _state;
        private string _adjunct="";
        private string _adjunct1="";

        public string Adjunct1
        {
            get { return _adjunct1; }
            set { _adjunct1 = value; }
        }
        private string _adjunct2="";

        public string Adjunct2
        {
            get { return _adjunct2; }
            set { _adjunct2 = value; }
        }
        private string _adjunct3="";

        public string Adjunct3
        {
            get { return _adjunct3; }
            set { _adjunct3 = value; }
        }
        private string _adjunct4="";

        public string Adjunct4
        {
            get { return _adjunct4; }
            set { _adjunct4 = value; }
        }
        public string Adjunct
        {
            get { return _adjunct; }
            set { _adjunct = value; }
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
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
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

