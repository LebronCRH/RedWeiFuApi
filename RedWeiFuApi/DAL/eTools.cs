using System;
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Configuration;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Data;
using RedWeiFuApi.Models;

namespace RedWeiFuApi.DAL
{
    public class eTools
    {
        //登录名
        public static string userName = "_userName";
        //姓名
        public static string userLoginName = "_userLoginName";
        //权限
        public static string userPrivilege = "_userPrivilege";
        //身份
        public static string userIdentity = "_userIdentity";
        //编号
        public static string userID = "_userID";
        //部门
        public static string userDept = "_userDept";

        public static string sysuname = eTools.DecodePassword(ConfigurationManager.AppSettings["superadminname"]);
        public static string syspwd = eTools.DecodePassword(ConfigurationManager.AppSettings["superadminpwd"]);

        //用户名
        public static string unitName = "_unitName";
        //电话
        public static string unitPhone = "_unitPhone";
        //维服开始日期
        public static string unitBeginDate = "_unitBeginDate";
        //维服结束日期
        public static string unitEndDate = "_unitEndDate";
        //联系人
        public static string linkMan = "_linkMan";
        //index
        public static string unitID = "_unitID";





        /// <summary>
        /// 判断是否为超级管理员
        /// </summary>
        /// <returns></returns>
        public static bool CheckSuper(string name, string pass)
        {
            if (sysuname.Equals(name) && syspwd.Equals(pass))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 读取cookie值
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static string GetCookie(string strName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie != null)
            {
                return HttpUtility.UrlDecode(cookie.Value.ToString(), System.Text.Encoding.GetEncoding("gb2312"));
            }
            return "";
        }
        /// <summary>
        /// 写入cookie值
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strValue"></param>
        public static void SetCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = HttpUtility.UrlEncode(strValue, System.Text.Encoding.GetEncoding("gb2312"));
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static string DecodePassword(string strInput)
        {
            string strOutput = "";
            try
            {
                if (string.IsNullOrEmpty(strInput))
                    return strOutput;

                string strAscii = "", strBuffer = "";

                int nLength = strInput.Length;

                int nRand;
                strBuffer = strInput.Substring(0, 1);
                nRand = Convert.ToInt16(strBuffer);
                nRand += 3;

                int nValue, nIncrease = nRand;

                for (int i = 1; i < nLength; i++)
                {
                    strBuffer = strInput.Substring(i, 1);
                    nValue = Int32.Parse(strBuffer, System.Globalization.NumberStyles.HexNumber);
                    nValue -= nIncrease;
                    nIncrease--;

                    if (nIncrease == 1)
                        nIncrease = nRand;

                    if (nValue < 0)
                        nValue += 16;

                    strBuffer = String.Format("{0:X}", nValue);
                    strAscii += strBuffer;
                }

                nLength = strAscii.Length;
                for (int i = 0; i < nLength; i += 2)
                {
                    strBuffer = strAscii.Substring(i, 2);
                    int nHexValue = Convert.ToInt32(strBuffer, 16);
                    strBuffer = Char.ConvertFromUtf32(nHexValue);
                    strOutput += strBuffer;
                }

            }
            catch (Exception ex)
            {

                return "";

            }

            return strOutput;
        }

        public static string EncodePassword(string strInput)
        {
            string strOutput = "";

            string strAscii = "", strBuffer = "";

            char[] cValues = strInput.ToCharArray();
            foreach (char ch in cValues)
            {
                int nCharValue = Convert.ToInt32(ch);
                strBuffer = String.Format("{0:X2}", nCharValue);
                strAscii += strBuffer;
            }

            Random rand = new Random();
            int nRand = rand.Next(9);
            strOutput = String.Format("{0:D}", nRand);

            nRand += 3;

            int nValue, nIncrease = nRand;

            int nLength = strAscii.Length;
            for (int i = 0; i < nLength; i++)
            {
                strBuffer = strAscii.Substring(i, 1);
                nValue = Int32.Parse(strBuffer, System.Globalization.NumberStyles.HexNumber);
                nValue += nIncrease;
                nIncrease--;
                if (nIncrease == 1)
                    nIncrease = nRand;
                if (nValue > 15)
                    nValue -= 16;
                strBuffer = String.Format("{0:X}", nValue);
                strOutput += strBuffer;
            }

            return strOutput;
        }

        /// <summary>
        /// 判断登录账号是否已经存在
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public static ServiceUser GetInfo(string loginName)
        {
            string sql = string.Format("select * from ServiceUser where ISDel=0 and UserLoginName = '{0}' LIMIT 0 , 1 ", loginName);
            DataTable dt = new DataTable();
            dt = MySqlHelper.mySqlExecuteQuery(sql, null, false);
            ServiceUser user = new ServiceUser();
            if (dt.Rows.Count > 0)
            {
                user.UserID = dt.Rows[0]["UserID"].ToString();
                user.UserName = dt.Rows[0]["UserName"].ToString();
                user.UserLoginName = dt.Rows[0]["UserLoginName"].ToString();
                user.UserPrivilege = dt.Rows[0]["UserPrivilege"].ToString();
                user.UserIdentity = dt.Rows[0]["UserIdentity"].ToString();
                user.UserPassword = dt.Rows[0]["UserPassword"].ToString();
                user.UserDept = dt.Rows[0]["UserDeptID"].ToString();
                return user;
            }
            else
                return null;
        }

        public static void AlertMessage(string message, Page page)
        {
            string js = "<script language='javascript'>alert('{0}');</script>";
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "MESSAGE"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "MESSAGE", string.Format(js, message));
            }
        }

        public static UnitUser GetUnit(string userName)
        {
            string sql = string.Format("select * from unit where phone = '{0}' or userName='{1}'", userName, userName);
            DataTable dt = new DataTable();
            dt = MySqlHelper.mySqlExecuteQuery(sql, null, false);
            UnitUser unit = new UnitUser();
            if (dt.Rows.Count > 0)
            {
                unit.UnitId = dt.Rows[0]["Id"].ToString();
                unit.UnitName = dt.Rows[0]["UnitName"].ToString();
                unit.Phone = dt.Rows[0]["Phone"].ToString();
                unit.BeginDate = dt.Rows[0]["BeginDate"].ToString();
                unit.EndDate = dt.Rows[0]["EndDate"].ToString();
                unit.PassWord = dt.Rows[0]["PassWord"].ToString();
                unit.Linkman = dt.Rows[0]["Linkman"].ToString();
                unit.UserName = dt.Rows[0]["UserName"].ToString();
                return unit;
            }
            else
                return null;
        }

        public static UnitUser GetInnerUser(string userName)
        {
            string sql = string.Format("select * from ServiceUser where userloginname = '{0}'", userName);
            DataTable dt = new DataTable();
            dt = MySqlHelper.mySqlExecuteQuery(sql, null, false);
            UnitUser unit = new UnitUser();
            if (dt.Rows.Count > 0)
            {
                unit.UnitId = dt.Rows[0]["UserID"].ToString();
                unit.UnitName = dt.Rows[0]["UserName"].ToString();
                unit.Phone = "";
                unit.BeginDate = "";
                unit.EndDate = "";
                unit.PassWord = dt.Rows[0]["UserPassword"].ToString();
                unit.Linkman = "";
                return unit;
            }
            else
                return null;
        }
    }
}