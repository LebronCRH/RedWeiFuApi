using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedWeiFuApi.Models
{
    public class WeeklyNotes
    {
        public string Name { get; set; }

        public string Note { get; set; }

        public string NoteDate { get; set; }

        public string Remarks { get; set; }

        public string Checker { get; set; }

        public string CheckDate { get; set; }

        public string CheckOpinion { get; set; }

        public string CheckFlag { get; set; }

        public string attendance { get; set; }

        public string workingload { get; set; }

        public string location { get; set; }

        public string score1 { get; set; }

        public string score2 { get; set; }

        public string score3 { get; set; }
    }
}