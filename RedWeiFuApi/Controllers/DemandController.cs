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
using System.Threading.Tasks;
using System.Web;
using System.Diagnostics;
using System.IO;

namespace RedWeiFuApi.Controllers
{
    [RoutePrefix("Demand")]
    public class DemandController : ApiController
    {
        protected string userName = eTools.GetCookie(eTools.userName);
        protected string userIdentity = eTools.GetCookie(eTools.userIdentity);
        protected string strDev = "";

        [HttpGet,Route("GetAllHospital")]
        public AddDemandReturn GetAllHospital()
        {
            List<UnitUser> sp = new List<UnitUser>();
            List<ServiceUser> sp2 = new List<ServiceUser>();
            string sql = "select * from `unit`";
            DataTable dt = MySqlHelper.mySqlExecuteQuery(sql, null, false);
            sp = (from y in dt.AsEnumerable()
                  select new UnitUser
                  {
                      Id = y.Field<int>("Id"),
                      UnitId = y.Field<string>("UnitId"),
                      UnitName = y.Field<string>("UnitName"),
                      Phone = y.Field<string>("Phone"),
                      PassWord = y.Field<string>("PassWord"),
                      Linkman = y.Field<string>("Linkman"),
                      BeginDate = y.Field<string>("BeginDate"),
                      EndDate = y.Field<string>("EndDate"),
                      UserName = y.Field<string>("UserName"),
                      ParentValue = y.Field<string>("ParentValue"),
                  }).ToList<UnitUser>();
            string sql2 = "select * from serviceuser  where UserDeptID='01'";
            DataTable dtUser = MySqlHelper.mySqlExecuteQuery(sql2, null, false);
            sp2 = (from y in dtUser.AsEnumerable()
                  select new ServiceUser
                  {
                      UserID = y.Field<int>("UserID").ToString(),
                      UserName = y.Field<string>("UserName"),
                      UserLoginName = y.Field<string>("UserLoginName"),
                      UserPrivilege = y.Field<string>("UserPrivilege"),
                      UserIdentity = y.Field<string>("UserIdentity"),
                      UserDept = y.Field<string>("UserDeptID"),
                  }).ToList<ServiceUser>();
            AddDemandReturn demandreturn = new AddDemandReturn()
            {
                listUser = sp2,
                listUnit = sp
            };
            return demandreturn;
        }

        
        [HttpPost,Route("PostDemand")]
        public async Task<Dictionary<string, string>> PostDemand(int id = 0)
        {

            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string root = HttpContext.Current.Server.MapPath("~/App_Data");//指定要将文件存入的服务器物理位置
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);

                // This illustrates how to get the file names.
                foreach (MultipartFileData file in provider.FileData)
                {//接收文件
                    Trace.WriteLine(file.Headers.ContentDisposition.FileName);//获取上传文件实际的文件名
                    Trace.WriteLine("Server file path: " + file.LocalFileName);//获取上传文件在服务上默认的文件名
                }//TODO:这样做直接就将文件存到了指定目录下，暂时不知道如何实现只接收文件数据流但并不保存至服务器的目录下，由开发自行指定如何存储，比如通过服务存到图片服务器
                foreach (var key in provider.FormData.AllKeys)
                {//接收FormData
                    dic.Add(key, provider.FormData[key]);
                }
            }
            catch
            {
                throw;
            }
            return dic;
        }

        [HttpPost, Route("AddDemandForm")]
        public int AddDemandForm()
        {
            try
            {
                string DemandTitle = HttpContext.Current.Request["DemandTitle"];
                string DemandContent = HttpContext.Current.Request["DemandContent"];
                string DemandServiceName = HttpContext.Current.Request["DemandName"];
                string DemandOrderNo = HttpContext.Current.Request["DemandOrderNo"];
                string DemandHosital = HttpContext.Current.Request["DemandHosital"];
                string DemandUser = HttpContext.Current.Request["DemandUser"];
                string DemandCreateTime = HttpContext.Current.Request["DemandCreateTime"];
                string DemandStatus = "登记";
                string DemandDeveloper = "";
                HttpFileCollection files = HttpContext.Current.Request.Files;
                string sql = null;
                string dateNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                sql = "select parentValue from `unit` where UnitName='" + DemandHosital.ToString() + "'";
                string parentValue = MySqlHelper.ExecuteScalar(sql, null, false).ToString();
                string attachUrl = null;
                //string TimePath = HttpContext.Current.Server.MapPath("~/RequireFile/ReqTrack/").ToString() + "\\";//获取上传路径的物理地址
                string TimePath= "D:\\公司维服系统\\ServiceInfo\\admin\\upload\\ReqTrack\\";
                if (!Directory.Exists(TimePath))//判断文件夹是否存在 
                {
                    Directory.CreateDirectory(TimePath);//不存在则创建文件夹 
                }
                //FtpHelper ftp = new FtpHelper("192.168.1.5:8087", "RequireFile", "administrator", "2008.R2");
                foreach (string f in files.AllKeys)
                {
                    HttpPostedFile file = files[f];

                    if (string.IsNullOrEmpty(file.FileName) == false)
                    {
                        //file.SaveAs(HttpContext.Current.Server.MapPath("~/RequireFile/") + file.FileName);
                        //string FileUrl = "http://192.168.1.5:8085/RequireFile/" + file.FileName;
                        file.SaveAs(@"D:\公司维服系统\ServiceInfo\admin\upload\ReqTrack\" + file.FileName);
                        //file.SaveAs(TimePath + file.FileName);
                        //ftp.Upload2(file);
                    }
                    attachUrl = "upload/ReqTrack/" + file.FileName;
                }

                sql = string.Format("insert into RequirementTrack (ReqTitle,ReqContent,ReqSource,ReqRegistrer,ReqDeveloper,ReqStatus,ReqTime,ReqReplyTime,ReqRemark,ReqAssignDev,ReqHospital,ReqHospitalParent,ReqClass,ReqServiceID,ReqServiceName,ReqAttach) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}',{12},'{13}','{14}','{15}')", DemandTitle, DemandContent, userIdentity, userName, DemandDeveloper, DemandStatus, dateNow, dateNow, "", DemandUser, DemandHosital, parentValue, 1, DemandOrderNo, DemandServiceName, attachUrl);
                int i = MySqlHelper.mySqlExecuteNonQuery(sql, null, false);
                sql = "select id from RequirementTrack where ReqTitle='" + DemandTitle + "' and ReqHospital='" + DemandHosital + "' and ReqRegistrer='" + userName + "' ";
                string hidId = MySqlHelper.ExecuteScalar(sql, null, false).ToString();
                sql = string.Format("insert into UserDialog (DiaReqID,diaUserName,diaContent,diaDateTime,diaClass) values('{0}','{1}','{2}','{3}',{4})", hidId, userName, "新增需求", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 0);
                MySqlHelper.mySqlExecuteNonQuery(sql, null, false);
                return Int32.Parse(hidId);
            }
            catch
            {
                return 0;
            }
        }

        [HttpGet, Route("GetDemandByID")]
        public RequirementTrack GetDemandByID(int id)
        {
            RequirementTrack rt = new RequirementTrack();
            string sql = "select * from RequirementTrack where reqDel=0 and id=" + id;
            DataTable dt = MySqlHelper.mySqlExecuteQuery(sql, null, false);
            rt = (from y in dt.AsEnumerable()
                  select new RequirementTrack
                  {
                      Id = id,
                      ReqTitle = y.Field<string>("ReqTitle"),
                      ReqAttach = y.Field<string>("ReqAttach"),
                      ReqContent = y.Field<string>("ReqContent"),
                      ReqHospital = y.Field<string>("ReqHospital"),
                      ReqSource = y.Field<string>("ReqSource"),
                      ReqAssignDev = y.Field<string>("ReqAssignDev"),
                      ReqRegistrer = y.Field<string>("ReqRegistrer"),
                      ReqDeveloper = y.Field<string>("ReqDeveloper"),
                      ReqStatus = y.Field<string>("ReqStatus"),
                      ReqTime = y.Field<DateTime?>("ReqTime").ToString(),
                      ReqReplyTime = y.Field<DateTime?>("ReqReplyTime").ToString(),
                      ReqRemark = y.Field<string>("ReqRemark"),
                      ReqDel = y.Field<int>("ReqDel"),
                      ReqHospitalParent = y.Field<string>("ReqHospitalParent"),
                      ReqResult = y.Field<string>("ReqResult"),
                      ReqReviewRemark = y.Field<string>("ReqReviewRemark"),
                      ReqFillBackReason = y.Field<string>("ReqFillBackReason"),
                      ReqReviewTime = y.Field<DateTime?>("ReqReviewTime").ToString(),
                      ReqServiceName = y.Field<string>("ReqServiceName"),
                      ReqServiceId = y.Field<string>("ReqServiceId"),
                      ReqTestSTime = y.Field<DateTime?>("ReqTestSTime").ToString(),
                      ReqTester = y.Field<string>("ReqTester"),
                      ReqTestETime = y.Field<DateTime?>("ReqTestETime").ToString(),
                      ReqTestReviewResult = y.Field<string>("ReqTestReviewResult"),
                      ReqTestReviewTime = y.Field<DateTime?>("ReqTestReviewTime").ToString(),
                      ReqTestReviewer = y.Field<string>("ReqTestReviewer"),
                      ReqClass = y.Field<int>("ReqClass"),
                      ReqFunModule = y.Field<string>("ReqFunModule"),
                      ReqEndResult = y.Field<string>("ReqEndResult"),
                      ReqEndReviewer = y.Field<string>("ReqEndReviewer"),
                      ReqEndTime = y.Field<DateTime?>("ReqEndTime").ToString(),
                  }).FirstOrDefault<RequirementTrack>();
            return rt;
        }

        [HttpGet, Route("GetDemandBySerach")]
        public List<RequirementTrack> GetDemandBySerach(string Source,string StarTime,string EndTime,string Hospital,string ZDR,string Area,string Status)
        {
            //try
            //{
                string sTime = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
                string eTime = DateTime.Now.ToString("yyyy-MM-dd");
                if (string.IsNullOrEmpty(StarTime))
                {
                    StarTime = sTime;
                }
                if (string.IsNullOrEmpty(EndTime))
                {
                    EndTime = eTime;
                }
                string strSql = "select * from RequirementTrack where reqDel=0 and reqclass=1 ";
                if (!string.IsNullOrEmpty(Source) && Source!="全部")
                    strSql += " and ReqSource='" + Source + "'";
                if (!string.IsNullOrEmpty(StarTime))
                    strSql += " and ReqTime>'" + Convert.ToDateTime(StarTime).ToString("yyyy-MM-dd 00:00:00") + "'";
                if (!string.IsNullOrEmpty(EndTime))
                    strSql += " and ReqTime<'" + Convert.ToDateTime(EndTime).ToString("yyyy-MM-dd 23:59:00") + "'";
                if (!string.IsNullOrEmpty(Hospital))
                    strSql += " and ReqHospital like '%" + Hospital + "%'";
                if (!string.IsNullOrEmpty(ZDR))
                    strSql += " and ReqAssignDev like '%" + ZDR.Trim() + "%'";
                if (!string.IsNullOrEmpty(ZDR))
                    strSql += " and ReqDeveloper like '%" + ZDR.Trim() + "%'";
                if (!string.IsNullOrEmpty(Area))
                    strSql += " and ReqHospitalParent like '%" + Area + "%'";
                if (!string.IsNullOrEmpty(Status) && Status != "全部")
                {
                    string[] arr = Status.Split(',');
                    string temp = null;
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (i == 0)
                            temp += "'" + arr[i].Trim() + "'";
                        else
                            temp += ",'" + arr[i].Trim() + "'";
                    }
                    strSql += " and ReqStatus in (" + temp + ")";
                }
                strSql += " order by ReqTime desc";
                DataTable dt = MySqlHelper.mySqlExecuteQuery(strSql, null, false);
                List<RequirementTrack> reqList = new List<RequirementTrack>();

                foreach (DataRow dr in dt.Rows)
                {
                    RequirementTrack item = new RequirementTrack();
                    if (dr["Id"] != null && dr["Id"] != DBNull.Value)
                        item.Id = Convert.ToInt32(dr["Id"]);
                    if (dr["ReqHospital"] != null && dr["ReqHospital"] != DBNull.Value)
                        item.ReqHospital = Convert.ToString(dr["ReqHospital"]);
                    if (dr["ReqHospitalParent"] != null && dr["ReqHospitalParent"] != DBNull.Value)
                        item.ReqHospitalParent = Convert.ToString(dr["ReqHospitalParent"]);
                    else
                        item.ReqHospitalParent = "";
                    if (dr["ReqTitle"] != null && dr["ReqTitle"] != DBNull.Value)
                        item.ReqTitle = Convert.ToString(dr["ReqTitle"]);
                    if (dr["ReqContent"] != null && dr["ReqContent"] != DBNull.Value)
                        item.ReqContent = Convert.ToString(dr["ReqContent"]);
                    if (dr["ReqSource"] != null && dr["ReqSource"] != DBNull.Value)
                        item.ReqSource = Convert.ToString(dr["ReqSource"]);
                    if (dr["ReqRegistrer"] != null && dr["ReqRegistrer"] != DBNull.Value)
                        item.ReqRegistrer = Convert.ToString(dr["ReqRegistrer"]);
                    if (dr["ReqAssignDev"] != null && dr["ReqAssignDev"] != DBNull.Value)
                        item.ReqAssignDev = Convert.ToString(dr["ReqAssignDev"]);
                    if (dr["ReqDeveloper"] != null && dr["ReqDeveloper"] != DBNull.Value)
                        item.ReqDeveloper = Convert.ToString(dr["ReqDeveloper"]);
                    if (dr["ReqStatus"] != null && dr["ReqStatus"] != DBNull.Value)
                        item.ReqStatus = Convert.ToString(dr["ReqStatus"]);
                    if (dr["ReqTime"] != null && dr["ReqTime"] != DBNull.Value)
                        item.ReqTime = Convert.ToDateTime(dr["ReqTime"]).ToString("yyyy-MM-dd");
                    if (dr["ReqReplyTime"] != null && dr["ReqReplyTime"] != DBNull.Value)
                        item.ReqReplyTime = Convert.ToDateTime(dr["ReqReplyTime"]).ToString("yyyy-MM-dd");
                    if (dr["ReqRemark"] != null && dr["ReqRemark"] != DBNull.Value)
                        item.ReqRemark = Convert.ToString(dr["ReqRemark"]);

                    if (dr["ReqServiceId"] != null && dr["ReqServiceId"] != DBNull.Value)
                        item.ReqServiceId = Convert.ToString(dr["ReqServiceId"]);
                    else
                        item.ReqServiceId = "";
                    if (dr["ReqServiceName"] != null && dr["ReqServiceName"] != DBNull.Value)
                        item.ReqServiceName = Convert.ToString(dr["ReqServiceName"]);
                    else
                        item.ReqServiceName = "";
                    if (dr["ReqResult"] != null && dr["ReqResult"] != DBNull.Value)
                        item.ReqResult = Convert.ToString(dr["ReqResult"]);
                    else
                        item.ReqResult = "";
                    if (dr["ReqReviewer"] != null && dr["ReqReviewer"] != DBNull.Value)
                        item.ReqReviewer = Convert.ToString(dr["ReqReviewer"]);
                    else
                        item.ReqReviewer = "";
                    if (dr["ReqReviewTime"] != null && dr["ReqReviewTime"] != DBNull.Value)
                        item.ReqReviewTime = Convert.ToString(dr["ReqReviewTime"]);
                    else
                        item.ReqReviewTime = "";
                    if (dr["ReqTester"] != null && dr["ReqTester"] != DBNull.Value)
                        item.ReqTester = Convert.ToString(dr["ReqTester"]);
                    else
                        item.ReqTester = "";
                    if (dr["ReqTestETime"] != null && dr["ReqTestETime"] != DBNull.Value)
                        item.ReqTestETime = Convert.ToString(dr["ReqTestETime"]);
                    else
                        item.ReqTestETime = "";
                    if (dr["ReqTestReviewer"] != null && dr["ReqTestReviewer"] != DBNull.Value)
                        item.ReqTestReviewer = Convert.ToString(dr["ReqTestReviewer"]);
                    else
                        item.ReqTestReviewer = "";
                    if (dr["ReqTestSTime"] != null && dr["ReqTestSTime"] != DBNull.Value)
                        item.ReqTestSTime = Convert.ToString(dr["ReqTestSTime"]);
                    else
                        item.ReqTestSTime = "";
                    if (dr["ReqTestReviewTime"] != null && dr["ReqTestReviewTime"] != DBNull.Value)
                        item.ReqTestReviewTime = Convert.ToString(dr["ReqTestReviewTime"]);
                    else
                        item.ReqTestReviewTime = "";
                    if (dr["ReqTestReviewResult"] != null && dr["ReqTestReviewResult"] != DBNull.Value)
                        item.ReqTestReviewResult = Convert.ToString(dr["ReqTestReviewResult"]);
                    else
                        item.ReqTestReviewResult = "";
                    if (dr["ReqEndResult"] != null && dr["ReqEndResult"] != DBNull.Value)
                        item.ReqEndResult = Convert.ToString(dr["ReqEndResult"]);
                    else
                        item.ReqEndResult = "";
                    if (dr["ReqEndReviewer"] != null && dr["ReqEndReviewer"] != DBNull.Value)
                        item.ReqEndReviewer = Convert.ToString(dr["ReqEndReviewer"]);
                    else
                        item.ReqEndReviewer = "";
                    if (dr["ReqEndTime"] != null && dr["ReqEndTime"] != DBNull.Value)
                        item.ReqEndTime = Convert.ToString(dr["ReqEndTime"]);
                    else
                        item.ReqEndTime = "";
                    reqList.Add(item);
                }
                return reqList;
            //}
            //catch
            //{
            //    return null;
            //}
        }
    }
}
