using System;
using System.Collections.Generic;
using System.Text;

namespace RADinfo_MIS_COST.Model
{
    public class FeeType
    {

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _feeid;

        public string Feeid
        {
            get { return _feeid; }
            set { _feeid = value; }
        }
        private string _feetypename;

        public string Feetypename
        {
            get { return _feetypename; }
            set { _feetypename = value; }
        }
        private string _feetype_desc;

        public string Feetype_desc
        {
            get { return _feetype_desc; }
            set { _feetype_desc = value; }
        }
    }
}
