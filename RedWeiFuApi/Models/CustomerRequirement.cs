using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedWeiFuApi.Models
{
    public class CustomerRequirement
    {
        public string Id { get; set; }

        public string MaintenanceServiceId { get; set; }

        public string CustomerName { get; set; }

        public string Title { get; set; }

        public string Reply { get; set; }

        public string ReplyTime { get; set; }
    }
}