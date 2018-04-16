using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedWeiFuApi.Models
{
    public class AddDemandReturn
    {
        public IList<ServiceUser> listUser { get; set; }
        public IList<UnitUser> listUnit{ get; set; }
    }
}