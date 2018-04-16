using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedWeiFuApi.Models
{
    public class SummaryAndPlan
    {
        public string Writer { get; set; }

        public string Summary { get; set; }

        public string Plan { get; set; }

        public string WriteDate { get; set; }

        public string Checker { get; set; }

        public string CheckDate { get; set; }

        public string CheckOpinion { get; set; }

        public string CheckFlag { get; set; }
    }
}