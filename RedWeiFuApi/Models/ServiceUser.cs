using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedWeiFuApi.Models
{
    public class ServiceUser
    {
        public string UserID { get; set; }

        public string UserName { get; set; }

        public string UserLoginName { get; set; }

        public string UserPrivilege { get; set; }

        public string UserIdentity { get; set; }

        public string UserPassword { get; set; }

        public string UserDept { get; set; }
    }
}