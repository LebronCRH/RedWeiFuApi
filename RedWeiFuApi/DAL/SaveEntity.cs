using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

using System.Text;
using System.Web;
using RedWeiFuApi.Models;


namespace RedWeiFuApi.DAL
{
    public class SaveEntity
    {
        string score1 = ConfigurationManager.AppSettings["score1"].ToString();
        string score2 = ConfigurationManager.AppSettings["score2"].ToString();
        string score3 = ConfigurationManager.AppSettings["score3"].ToString();
        string checkAll = ConfigurationManager.AppSettings["checkAll"].ToString();


        public bool SaveWeeklyNote(WeeklyNotes weeklynote)
        {
            string Id = string.Empty;
            StringBuilder select = new StringBuilder();
            select.AppendFormat("select * from weeklynotes where name = '{0}' and notedate = '{1}'", weeklynote.Name, weeklynote.NoteDate);
            DataTable dt = MySqlHelper.mySqlExecuteQuery(select.ToString(), null, false);
            if (dt.Rows.Count > 0)
            {
                Id = dt.Rows[0]["ID"].ToString();
            }
            if (Id.Length > 0)
            {
                StringBuilder delete = new StringBuilder();
                delete.AppendFormat("delete from weeklynotes where Id = '{0}'", Id);
                int j = MySqlHelper.mySqlExecuteNonQuery(delete.ToString(), null, false);
            }
            StringBuilder insert = new StringBuilder();
            insert.Append("insert into weeklynotes (Name,Note,NoteDate,Remarks,location)");
            insert.AppendFormat(" values ('{0}','{1}','{2}','{3}','{4}')", weeklynote.Name, weeklynote.Note, weeklynote.NoteDate, weeklynote.Remarks, weeklynote.location);
            int i = MySqlHelper.mySqlExecuteNonQuery(insert.ToString(), null, false);
            return i > 0;
        }

        public bool SaveSummary(SummaryAndPlan summaryAndPlan)
        {
            string Id = string.Empty;
            StringBuilder select = new StringBuilder();
            select.AppendFormat("select * from SummaryAndPlan where Writer = '{0}' and WriteDate = '{1}'", summaryAndPlan.Writer, summaryAndPlan.WriteDate);
            DataTable dt = MySqlHelper.mySqlExecuteQuery(select.ToString(), null, false);
            if (dt.Rows.Count > 0)
            {
                Id = dt.Rows[0]["ID"].ToString();
            }
            if (Id.Length > 0)
            {
                StringBuilder delete = new StringBuilder();
                delete.AppendFormat("delete from SummaryAndPlan where Id = '{0}'", Id);
                int j = MySqlHelper.mySqlExecuteNonQuery(delete.ToString(), null, false);
            }
            StringBuilder insert = new StringBuilder();
            insert.Append("insert into SummaryAndPlan (Writer,Summary,Plan,WriteDate)");
            insert.AppendFormat(" values ('{0}','{1}','{2}','{3}')", summaryAndPlan.Writer, summaryAndPlan.Summary, summaryAndPlan.Plan, summaryAndPlan.WriteDate);
            int i = MySqlHelper.mySqlExecuteNonQuery(insert.ToString(), null, false);
            return i > 0;
        }

        public bool CheckWeeklyNote(WeeklyNotes weeklynote)
        {
            string c = "";
            string select = string.Format("select count(*) as count from weeklynotes where NoteDate = '{0}' and Name = '{1}' ", weeklynote.NoteDate, weeklynote.Name);
            DataTable dt = MySqlHelper.mySqlExecuteQuery(select.ToString(), null, false);
            if (dt.Rows.Count > 0)
            {
                c = dt.Rows[0]["count"].ToString();
            }
            if (int.Parse(c) > 0)
            {
                StringBuilder update = new StringBuilder();
                update.AppendFormat("update weeklynotes set CheckFlag = '{0}', workingload = '{1}', attendance = '{2}', Remarks = '{3}',Checker = '{4}' ", weeklynote.CheckFlag, weeklynote.workingload, weeklynote.attendance, weeklynote.Remarks, weeklynote.Checker);
                if (weeklynote.Checker == score1)
                    update.AppendFormat(", score1 = '{0}' ", weeklynote.score1);
                if (weeklynote.Checker == score2)
                    update.AppendFormat(", score2 = '{0}' ", weeklynote.score1);
                if (weeklynote.Checker == score3)
                    update.AppendFormat(", score3 = '{0}' ", weeklynote.score1);
                update.AppendFormat(" where NoteDate = '{0}' and Name = '{1}' ", weeklynote.NoteDate, weeklynote.Name);
                int i = MySqlHelper.mySqlExecuteNonQuery(update.ToString(), null, false);
                return i > 0;
            }
            else
            {
                StringBuilder insert = new StringBuilder();
                insert.AppendFormat("insert into weeklynotes (CheckFlag,workingload,attendance,Remarks,Checker,NoteDate,Name) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", weeklynote.CheckFlag, weeklynote.workingload, weeklynote.attendance, weeklynote.Remarks, weeklynote.Checker, weeklynote.NoteDate, weeklynote.Name);
                //insert.AppendFormat(" where NoteDate = '{0}' and Name = '{1}' ", weeklynote.NoteDate, weeklynote.Name);
                int i = MySqlHelper.mySqlExecuteNonQuery(insert.ToString(), null, false);
                return i > 0;
            }
        }

        public bool ModifyLocation(WeeklyNotes weeklynote)
        {
            string c = "";
            string select = string.Format("select count(*) as count from weeklynotes where NoteDate = '{0}' and Name = '{1}' ", weeklynote.NoteDate, weeklynote.Name);
            DataTable dt = MySqlHelper.mySqlExecuteQuery(select.ToString(), null, false);
            if (dt.Rows.Count > 0)
            {
                c = dt.Rows[0]["count"].ToString();
            }
            if (int.Parse(c) > 0)
            {
                StringBuilder update = new StringBuilder();
                update.AppendFormat("update weeklynotes set Location = '{0}' where NoteDate = '{1}' and Name = '{2}'", weeklynote.location, weeklynote.NoteDate, weeklynote.Name);
                int i = MySqlHelper.mySqlExecuteNonQuery(update.ToString(), null, false);
                return i > 0;
            }
            else
            {
                StringBuilder insert = new StringBuilder();
                insert.AppendFormat("insert into weeklynotes (Location,NoteDate,Name) values ('{0}','{1}','{2}')", weeklynote.location, weeklynote.NoteDate, weeklynote.Name);
                int i = MySqlHelper.mySqlExecuteNonQuery(insert.ToString(), null, false);
                return i > 0;
            }
        }

        public bool CheckAllWeeklyNotes(string begindate, string enddate, string name, string checker)
        {
            StringBuilder update = new StringBuilder();
            update.AppendFormat("update weeklynotes set CheckFlag = '1', Checker = '{0}' ", checker);
            update.AppendFormat(" where Name = '{0}' and NoteDate >= '{1}' and NoteDate <= '{2}'", name, begindate, enddate);
            int i = MySqlHelper.mySqlExecuteNonQuery(update.ToString(), null, false);
            return i > 0;
        }

        public bool CheckSummaryAndPlan(SummaryAndPlan sp)
        {
            string c = "";
            string select = string.Format("select count(*) as count from SummaryAndPlan where WriteDate = '{0}' and Writer = '{1}' ", sp.WriteDate, sp.Writer);
            DataTable dt = MySqlHelper.mySqlExecuteQuery(select.ToString(), null, false);
            if (dt.Rows.Count > 0)
            {
                c = dt.Rows[0]["count"].ToString();
            }
            if (int.Parse(c) > 0)
            {
                StringBuilder update = new StringBuilder();
                update.AppendFormat("update SummaryAndPlan set CheckFlag = '{0}', CheckOpinion = '{1}', Checker = '{2}' ", sp.CheckFlag, sp.CheckOpinion, sp.Checker);
                update.AppendFormat(" where WriteDate = '{0}' and Writer = '{1}' ", sp.WriteDate, sp.Writer);
                int i = MySqlHelper.mySqlExecuteNonQuery(update.ToString(), null, false);
                return i > 0;
            }
            else
            {
                StringBuilder insert = new StringBuilder();
                insert.AppendFormat("insert into SummaryAndPlan (CheckFlag,CheckOpinion,Checker,WriteDate,Writer) values ('{0}','{1}','{2}','{3}','{4}')", sp.CheckFlag, sp.CheckOpinion, sp.Checker, sp.WriteDate, sp.Writer);
                //insert.AppendFormat(" where NoteDate = '{0}' and Name = '{1}' ", weeklynote.NoteDate, weeklynote.Name);
                int i = MySqlHelper.mySqlExecuteNonQuery(insert.ToString(), null, false);
                return i > 0;
            }
        }
    }
}