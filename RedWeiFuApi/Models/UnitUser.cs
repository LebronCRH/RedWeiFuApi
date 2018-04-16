using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedWeiFuApi.Models
{
    public class UnitUser
    {
        public int Id { get; set; }

        public string UnitId { get; set; }

        public string UnitName { get; set; }

        public string Phone { get; set; }

        public string PassWord { get; set; }

        public string Linkman { get; set; }

        public string BeginDate { get; set; }

        public string EndDate { get; set; }

        public string UserName { get; set; }

        public string ParentValue { get; set; }
    }
}