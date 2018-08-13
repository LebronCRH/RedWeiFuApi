using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedWeiFuApi.Models
{
    public class NoteAndSummary
    {
        public WeeklyNotes notes { get; set; }
        public SummaryAndPlan sumandplan { get; set; }
    }
}