using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using RedWeiFuApi.Models;
using RedWeiFuApi.DAL;

namespace RedWeiFuApi.Controllers
{
    [RoutePrefix("WorkWeekly")]
    public class WorkWeeklyController : ApiController
    {
        SaveEntity se = new SaveEntity();
        string FD;
        //周报表头
        string[] title = new string[] { "日期", "记录", "去向", "备注", "相关项目", "出勤", "操作" };
        //总结和计划表头
        string[] title1 = new string[] { "类别", "内容" };
        protected string userName = eTools.GetCookie(eTools.userName);
        //protected string userName = "陈昱汶";

        [HttpGet,Route("GetWeeklyNotes")]
        public List<WeeklyNotes> GetWeeklyNotes(string UserName,string DateSelect="")
        {
            DateTime Day;
            if (string.IsNullOrEmpty(DateSelect))
            {
                 Day = DateTime.Today;
            }
            else
            {
                 Day = DateTime.Parse(DateSelect);
            }
            if (!string.IsNullOrEmpty(userName))
            {
                UserName = userName;
            }
            //获取本周第一天  
            int Weeknow = Convert.ToInt32(Day.DayOfWeek);
            //因为是以星期一为第一天，所以要判断weeknow等于0时，要向前推6天。  
            Weeknow = (Weeknow == 0 ? (7 - 1) : (Weeknow - 1));
            int Daydiff = (-1) * Weeknow;
            //本周第一天  
            string FirstDay = Day.AddDays(Daydiff).ToString("yyyy-MM-dd");
            FD = FirstDay;
            //获取本周最后一天
            int Weeknow1 = Convert.ToInt32(Day.DayOfWeek);
            Weeknow1 = (Weeknow1 == 0 ? 7 : Weeknow1);
            Daydiff = (7 - Weeknow1);
            //本周最后一天  
            string LastDay = Day.AddDays(Daydiff).ToString("yyyy-MM-dd");

            List<WeeklyNotes> weeklynotes2 = new List<WeeklyNotes>();
            DataTable dt = new DataTable();
            StringBuilder select = new StringBuilder();
            select.AppendFormat("select * from weeklynotes where notedate >='{0}' and notedate <='{1}' and Name = '{2}'", FirstDay, LastDay, UserName);
            dt = MySqlHelper.mySqlExecuteQuery(select.ToString(), null, false);
            weeklynotes2 = (from x in dt.AsEnumerable()
                            orderby x.Field<string>("NoteDate")
                            select new WeeklyNotes
                            {
                                Name = x.Field<string>("Name"),
                                Note = x.Field<string>("Note"),
                                NoteDate = x.Field<string>("NoteDate"),
                                CheckOpinion = x.Field<string>("CheckOpinion"),
                                CheckFlag = x.Field<string>("CheckFlag"),
                                Remarks = x.Field<string>("Remarks"),
                                attendance = x.Field<string>("attendance"),
                                location = x.Field<string>("location"),
                            }).ToList<WeeklyNotes>();
            List<WeeklyNotes> weeklynotes3 = new List<WeeklyNotes>();
            DateTime day = DateTime.Parse(FirstDay);
            string[] WeekDays = new string[7];
            for (int I = 0; I < 7; I++)//7行
            {
                WeeklyNotes weeklyItem = new WeeklyNotes();
                string day1 = day.AddDays(I - 0).ToString("yyyy-MM-dd");
                WeekDays[I] = day1;
                var Flag = true;
                foreach (var Item in weeklynotes2)
                {
                    if (Item.NoteDate == WeekDays[I])
                    {
                        weeklynotes3.Add(Item);
                        Flag = false;
                        break;
                    }
                }
                if (Flag)
                {
                    weeklyItem.NoteDate = day1;
                    weeklyItem.Name = UserName;
                    weeklynotes3.Add(weeklyItem);
                }
            }
            return weeklynotes3;
        }

        /// <summary>
        /// 获取总结和计划信息
        /// </summary>
        /// <param name="FirstDay">日期</param>
        /// <returns></returns>
        [HttpGet,Route("GetSummaryAndPlan")]
        public SummaryAndPlan GetSummaryAndPlan(string UserName, string DateSelect = "")
        {
            DateTime Day;
            if (string.IsNullOrEmpty(DateSelect))
            {
                Day = DateTime.Today;
            }
            else
            {
                Day = DateTime.Parse(DateSelect);
            }
            if (!string.IsNullOrEmpty(userName))
            {
                UserName = userName;
            }
            //获取本周第一天  
            int Weeknow = Convert.ToInt32(Day.DayOfWeek);
            //因为是以星期一为第一天，所以要判断weeknow等于0时，要向前推6天。  
            Weeknow = (Weeknow == 0 ? (7 - 1) : (Weeknow - 1));
            int Daydiff = (-1) * Weeknow;
            //本周第一天  
            string FirstDay = Day.AddDays(Daydiff).ToString("yyyy-MM-dd");
            FD = FirstDay;
            //获取本周最后一天
            int Weeknow1 = Convert.ToInt32(Day.DayOfWeek);
            Weeknow1 = (Weeknow1 == 0 ? 7 : Weeknow1);
            Daydiff = (7 - Weeknow1);
            //本周最后一天  
            string LastDay = Day.AddDays(Daydiff).ToString("yyyy-MM-dd");
            List<SummaryAndPlan> sp = new List<SummaryAndPlan>();
            DataTable dt2 = new DataTable();
            StringBuilder select2 = new StringBuilder();
            select2.AppendFormat("select * from summaryandplan where writedate = '{0}' and writer = '{1}'", FirstDay, UserName);
            dt2 = MySqlHelper.mySqlExecuteQuery(select2.ToString(), null, false);
            sp = (from y in dt2.AsEnumerable()
                  select new SummaryAndPlan
                  {
                      Plan = y.Field<string>("Plan"),
                      Summary = y.Field<string>("summary")
                  }).ToList<SummaryAndPlan>();
            if (sp.FirstOrDefault() != null)
            {
                return sp.FirstOrDefault();
            }
            else
            {
                SummaryAndPlan sp2 = new SummaryAndPlan();
                return sp2;
            }
        }

        [HttpPost, Route("SaveNote")]
        public WeeklyNotes SaveNote([FromBody]WeeklyNotes value)
        {
            SaveEntity se = new SaveEntity();
            if (se.SaveWeeklyNote(value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        [HttpPost, Route("SaveSummaryAndPlan")]
        public int SaveSummaryAndPlan([FromBody]SummaryAndPlan value) {
            SaveEntity se = new SaveEntity();
            if (se.SaveSummary(value))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        [HttpPost, Route("SaveNoteAndSumAndPlan")]
        public NoteAndSummary SaveNoteAndSumAndPlan([FromBody]NoteAndSummary value) {
            NoteAndSummary Item =(NoteAndSummary)value;
            SaveEntity se = new SaveEntity();
            if (value == null)
            {
                return value;
            }
            if (se.SaveWeeklyNote(Item.notes) && se.SaveSummary(Item.sumandplan))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        [HttpGet, Route("UserLogin")]
        public ServiceUser UserLogin(string UserName, string UserPassword)
        {
            ServiceUser user = new ServiceUser();
            try
            {
                user = eTools.GetInfo(UserName);
            }
            catch (Exception ex)
            {
            }
            if (user != null && eTools.DecodePassword(user.UserPassword).Equals(UserPassword))
            {
                eTools.SetCookie(eTools.userName, user.UserName);
                eTools.SetCookie(eTools.userLoginName, user.UserLoginName);
                eTools.SetCookie(eTools.userPrivilege, user.UserPrivilege);
                eTools.SetCookie(eTools.userIdentity, user.UserIdentity);
                eTools.SetCookie(eTools.userID, user.UserID);
                eTools.SetCookie(eTools.userDept, user.UserDept);
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
