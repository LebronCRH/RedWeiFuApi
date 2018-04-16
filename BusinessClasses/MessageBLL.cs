using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;
using RADinfo_MIS_COST.Model;
using RADinfo_MIS_COST.DBDAL;
using System.Security.Cryptography;
using System.Collections;
using System.Configuration;
using System.IO;

namespace RADinfo_MIS_COST.BusinessClasses
{
    public class MessageBLL : BusinessObject
    {
        public int _messageid;
        public string _mastername;
        public string _type;
        public string _title;
        public string _content;
        public DateTime _createtime;
        public bool _state;
        public string _adjunct;
        public string _keyword;
        public string _xuanze;
        public string _adjunct1;
        public string _adjunct2;
        public string _adjunct3;
        public string _adjunct4;

        /// <summary>
        /// 更新消息表
        /// </summary>
        /// <param name="type"></param>
        /// <param name="keyword"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="adjunct"></param>
        /// <param name="state"></param>
        /// <param name="messageid"></param>
        /// <returns></returns>
        public bool Update()
        {
            MessageDAL dal = new MessageDAL(connectionString);
            return dal.Update(_type, _keyword, _title, _content, _state, _messageid,_adjunct);
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <returns></returns>
        public int Add()
        {
            MessageDAL dal = new MessageDAL(connectionString);
            return dal.Add(_type,_keyword, _title, _content, _createtime, _mastername, _adjunct,_adjunct1,_adjunct2,_adjunct3,_adjunct4);
        }

        /// <summary>
        /// 查询分栏的前10条信息
        /// </summary>
        /// <param name="type">信息类别</param>
        /// <param name="state">是否审核</param>
        /// <returns></returns>
        public ArrayList GetMessage()
        {
            MessageDAL dal = new MessageDAL(connectionString);
            return dal.GetMessage(_type, _state);
        }

        /// <summary>
        /// 查询指定的信息
        /// </summary>
        /// <param name="messageid"></param>
        /// <returns></returns>
        public Messages GetMessage(int messageid)
        {
            MessageDAL dal = new MessageDAL(connectionString);
            return dal.GetMessage(messageid);

        }

         /// <summary>
        /// 查询相关的信息
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public ArrayList GetRelated(string keyWord,string keyword1,string keyword2,int messageid)
        {
            MessageDAL dal = new MessageDAL(connectionString);
            return dal.GetRelated(keyWord,keyword1,keyword2,messageid);
        }

         /// <summary>
        /// 查询所有的信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="xuanze"></param>
        /// <param name="createtime"></param>
        /// <returns></returns>
        public ArrayList GetMessage(string type,string state,string createtime1,string createtime2,string mastername)
        {
            MessageDAL dal = new MessageDAL(connectionString);
            return dal.GetMessage(type,state,createtime1, createtime2,mastername);
        }

          /// <summary>
        /// 删除指定信息
        /// </summary>
        /// <param name="messageid"></param>
        /// <returns></returns>
        public bool DeleteMessage()
        {
            MessageDAL dal = new MessageDAL(connectionString);
            return dal.DeleteMessage(_messageid);
        }

        #region 上传文件
        /// <summary> 
        /// 上传文件 使用方法 Core.File.upload(File1, new string[] { "gif", "jpg", "png", "bmp" }, "imgs/uploadimages/"); 
        /// </summary> 
        /// <param name="File1">上传的控件</param> 
        /// <param name="str">要隔离的后缀名</param> 
        /// <param name="path">保存的路径</param> 
        /// <returns>保存到数据库的路径 后面加\\ 前面不用加</returns> 
        public  Messages upload(string[] str, string path)
        {
            Messages adjuncts = new Messages();
            string serverPath = System.Web.HttpContext.Current.Server.MapPath(".") + "//";//服务器路径 
            string savePath = "";//用于返回的路径 保存到数据库的 
            string upPath = "";//上传的路径; 
            bool bl = false;//用于判断文件后缀 
            HttpFileCollection files = HttpContext.Current.Request.Files;
            StringBuilder strmsg = new StringBuilder("");
            int ifile;
            for (ifile = 0; ifile < files.Count; ifile++)
            {
                if (files[ifile].FileName.Length > 0)
                { 
                    HttpPostedFile postedfile=files[ifile];
                    if (postedfile.ContentLength / 1024 > 10240)//单个文件不能大于10M
                    {
                        strmsg.Append(Path.GetFileName(postedfile.FileName)+"---不能大于10M<br>");
                        break;
                    }
                    string fex=Path.GetExtension(postedfile.FileName);
                    //判断文件格式是否正确 
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (fex == str[i].ToString())
                        {
                            bl = true;
                            break;
                        }
                    }
                    if (bl == false)
                    {
                        strmsg.Append(Path.GetFileName(postedfile.FileName) + "文件格式不对!<br>");
                        break;
                    }
                }
            }
            if (strmsg.Length <= 0)//说明文件大小格式都正确
            {
                for (int i = 0; i < files.Count; i++)
                { 
                    HttpPostedFile myFile=files[i];
                    string filename = Path.GetFileName(myFile.FileName);
                    string FileExtention = "";
                    string newname = DateTime.Now.ToString("yyyyMMddHHmmssffff")+i.ToString();//重新命名 
                    if (filename.Length > 0)//有文件才执行上传操作再保存到数据库
                    { 
                        FileExtention=Path.GetExtension(myFile.FileName);
                        savePath=path+newname+FileExtention;
                        upPath = HttpContext.Current.Server.MapPath("~/") + savePath;
                        myFile.SaveAs(upPath); //上传图片
                    }
                    if (i == 0)
                    {
                        adjuncts.Adjunct = savePath;
                    }
                    else if (i == 1)
                    {
                        adjuncts.Adjunct1 = savePath;

                    }
                    else if (i == 2)
                    {
                        adjuncts.Adjunct2 = savePath;
                    }
                    else if (i == 3)
                    {
                        adjuncts.Adjunct3 = savePath;
                    }
                    else if (i == 4)
                    {
                        adjuncts.Adjunct4 = savePath;
                    }

                }
            }
         
            return adjuncts;
        }
        /// <summary> 
        /// 上传文件 使用方法 Core.File.upload(File1, new string[] { "gif", "jpg", "png", "bmp" }, "imgs/uploadimages/",150); 
        /// </summary> 
        /// <param name="File1">上传的控件</param> 
        /// <param name="str">要隔离的后缀名</param> 
        /// <param name="path">保存的路径 (最后要加 "/")</param> 
        /// <param name="number">图片的大小</param> 
        /// <returns>保存到数据库的路径 后面加\\ 前面不用加</returns> 
        public  string upload(System.Web.UI.HtmlControls.HtmlInputFile File1, string[] str, string path, int number)
        {
            string serverPath = System.Web.HttpContext.Current.Server.MapPath(".") + "//";//服务器路径 
            string savePath = "";//用于返回的路径 保存到数据库的 
            string upPath = "";//上传的路径; 
            string name = DateTime.Now.ToString("yyyyMMddHHmmss");//重新命名 
            bool bl = false;//用于判断文件后缀 
            if (File1.Value != "")
            {
                string str1 = File1.Value;//用户给的路径 
                string houzhui = str1.Substring(str1.LastIndexOf(".") + 1).ToLowerInvariant();//后缀名 
                if (houzhui.Length < 3 && houzhui.Length >= 0)
                {
                    houzhui.PadRight(3);
                }
                //判断图片格式是否正确 
                for (int i = 0; i < str.Length; i++)
                {
                    if (houzhui == str[i].ToString())
                    {
                        bl = true;
                        break;
                    }
                }
                if (bl)
                {
                    savePath = path + name + "." + houzhui;
                    upPath = System.Web.HttpContext.Current.Server.MapPath("~/") + path + name + "." + houzhui;
                    File1.PostedFile.SaveAs(upPath);//上传截图 
                }
            }

            //生成缩略图 

            //string houzhui = File1.Value.Substring(File1.Value.LastIndexOf('.'));//得到后缀 
            //System.Threading.Thread.Sleep(1000);//挂起10毫秒时间 
            //string savePath = DateTime.Now.ToString("yyyyMMddHHmmss") + houzhui;//得到新生成的图片 

            System.Drawing.Bitmap image2 = new System.Drawing.Bitmap(System.Web.HttpContext.Current.Server.MapPath("~/") + savePath);//原图 

            int width = image2.Width;//得到原图的宽 
            int height = image2.Height;//得到原图的高 

            //判断图片宽高 
            if (width > height)//如果宽比高大 则按照宽等比例缩小或放大 
            {
                if (width >= number)//如果宽要比规定的大 则缩小 
                {
                    width = number;//得到宽度 
                    height = number * image2.Height / image2.Width;//得到等比例缩小的高度 
                }
            }
            else
            {
                if (height >= number)//如果高要比规定的大 则缩小 
                {
                    height = number;//得到高度 
                    width = number * image2.Width / image2.Height;//得到等比例缩小的宽度 
                }
            }

            System.Drawing.Image image = image2.GetThumbnailImage(width, height, null, new IntPtr());//给图片创建缩略图 
            image2.Dispose();

            //Core.File.Delete(System.Web.HttpContext.Current.Server.MapPath("~/") + savePath);//删除原有图片 

            image.Save(System.Web.HttpContext.Current.Server.MapPath("~/") + savePath, System.Drawing.Imaging.ImageFormat.Bmp);//保存绘画好的图片 

            image.Dispose();
            return savePath;
        }
        #endregion

        #region 下载文件
        /// <summary> 
        /// 下载文件 
        /// </summary> 
        /// <param name="fileName">文件路径</param> 
        /// <returns></returns> 
        public static void FileDownLoad(System.Web.UI.Page page, string fileName)
        {
            FileInfo DownloadFile = new FileInfo(fileName); //设置要下载的文件 
            page.Response.Clear(); //清除缓冲区流中的所有内容输出 
            page.Response.ClearHeaders(); //清除缓冲区流中的所有头 
            page.Response.Buffer = false; //设置缓冲输出为false 
            //设置输出流的 HTTP MIME 类型为application/octet-stream 
            page.Response.ContentType = "application/octet-stream";
            //将 HTTP 头添加到输出流 
            page.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(DownloadFile.FullName, System.Text.Encoding.UTF8));
            page.Response.AppendHeader("Content-Length", DownloadFile.Length.ToString());
            //将指定的文件直接写入 HTTP 内容输出流。 
            page.Response.WriteFile(DownloadFile.FullName);
            page.Response.Flush(); //向客户端发送当前所有缓冲的输出 
            page.Response.End(); //将当前所有缓冲的输出发送到客户端 
        }
        #endregion 



    }
}
