using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using RedWeiFuApi.Models;

namespace RedWeiFuApi.DAL
{
    public class WeeklyHelper
    {
        public WeeklyNotes getWeeklyNoteInfo(NameValueCollection paras)
        {
            WeeklyNotes wn = new WeeklyNotes();
            wn.Note = paras["note"].Trim();
            wn.Remarks = paras["remark"].Trim();
            wn.NoteDate = paras["date"].Trim();
            wn.Name = paras["name"].Trim();
            wn.location = paras["location"].Trim();
            return wn;
        }

        public SummaryAndPlan getSummaryAndPlanInfo(NameValueCollection paras)
        {
            SummaryAndPlan sp = new SummaryAndPlan();
            sp.Summary = paras["summary"].Trim();
            sp.Plan = paras["plan"].Trim();
            sp.WriteDate = paras["date"].Trim();
            sp.Writer = paras["name"].Trim();
            return sp;
        }
    }
}