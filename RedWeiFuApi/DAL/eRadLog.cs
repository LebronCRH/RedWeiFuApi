using System;
using System.Collections;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace RedWeiFuApi.DAL
{
    public class eRadLog
    {
        // Methods

        #region 创建日志文件
        /****************************************
         * 函数名称：CreateLogFile
         * 功能说明：创建日志文件
         * 参    数：
        *****************************************/
        private static string CreateLogFile()
        {
            string strLogFileName = string.Empty;
            string strBuffer = string.Empty, strLogPath = string.Empty;

            strLogPath = string.Format("{0}LOG", AppDomain.CurrentDomain.BaseDirectory);

            if (!Directory.Exists(strLogPath))
                Directory.CreateDirectory(strLogPath);

            strBuffer = string.Format("{0}\\log{1}.TXT", strLogPath, DateTime.Now.ToString("dd"));

            if (!File.Exists(strBuffer))
            {
                FileStream streamFile = File.Create(strBuffer);
                streamFile.Close();
                streamFile.Dispose();
                strLogFileName = strBuffer;
            }
            else
            {
                FileInfo infoFile = new FileInfo(strBuffer);

                if (DateTime.Now.ToString("yyyyMMdd") == infoFile.LastWriteTime.ToString("yyyyMMdd"))
                {
                    strLogFileName = strBuffer;
                }
                else
                {
                    File.Delete(strBuffer);

                    FileStream streamFile = File.Create(strBuffer);
                    streamFile.Close();
                    streamFile.Dispose();
                    strLogFileName = strBuffer;
                }
            }

            return strLogFileName;
        }
        #endregion

        #region 日志记录
        /****************************************
         * 函数名称：DoLog
         * 功能说明：日志记录
         * 参    数：
        *****************************************/
        private static void AppendLog(string strLogContent)
        {
            string strLogFileName = string.Empty;

            strLogFileName = CreateLogFile();

            if (!string.IsNullOrEmpty(strLogFileName))
            {
                StreamWriter writerStream = File.AppendText(strLogFileName);
                writerStream.Write(strLogContent);
                writerStream.Flush();
                writerStream.Close();
                writerStream.Dispose();
            }
        }

        public static void DoLog(string strLogTitle, string strLogMessage, string strLogTrace)
        {
            string strLogText = string.Empty;

            strLogText = string.Format("-------------[{0} {1}] [{2}]-----------\n MSG:{3} [{4}]\r\n\n", DateTime.Now.ToString("MM-dd"), DateTime.Now.ToString("HH:mm:ss.fff"), strLogTitle, strLogMessage, strLogTrace);

            AppendLog(strLogText);
        }

        public static void DoLog(string strLogTitle, string strLogMessage)
        {
            string strLogText = string.Empty;

            strLogText = string.Format("-------------[{0} {1}] [{2}]-------------\n MSG:{3}\r\n\n", DateTime.Now.ToString("MM-dd"), DateTime.Now.ToString("HH:mm:ss.fff"), strLogTitle, strLogMessage);

            AppendLog(strLogText);
        }

        public static void DoLog(string strLogMessage)
        {
            string strLogText = string.Empty;

            strLogText = string.Format("-------------[{0} {1}]-------------\n MSG:{2}\r\n", DateTime.Now.ToString("MM-dd"), DateTime.Now.ToString("HH:mm:ss.fff"), strLogMessage);

            AppendLog(strLogText);
        }

        #endregion

        #region 日志记录至eRadIHELog数据表
        /****************************************
         * 函数名称：DoDBLog
         * 功能说明：日志记录
         * 参    数：
        *****************************************/
        public static void DoDBLog(string strLogOperate, string strLogUserName, string strLogContent)
        {
            try
            {
                string strSql = string.Format("INSERT INTO cmlog (LogOperate,LogUserName,LogContent,LogTS) VALUES ('{0}', '{1}', '{2}', '{3}')", strLogOperate, strLogUserName, strLogContent, DateTime.Now.ToString("yyyyMMddHHmmss"));
                MySqlHelper.mySqlExecuteNonQuery(strSql, null, false);
            }
            catch (Exception ex)
            {
                DoLog("写入数据库日志异常", ex.Message, ex.StackTrace);
                return;
            }
        }

        #endregion

        #region 获取日志级别
        public static string GetLogLevelTXT(int nLogLevel)
        {
            string strReturnValue = "";
            Hashtable m_LevelTXT = new Hashtable();
            m_LevelTXT.Add(1, "信息");
            m_LevelTXT.Add(2, "错误");
            m_LevelTXT.Add(3, "警告");
            m_LevelTXT.Add(3, "记录");
            if (!m_LevelTXT.ContainsKey(nLogLevel))
                return strReturnValue;

            strReturnValue = m_LevelTXT[nLogLevel].ToString();
            return strReturnValue;
        }
        #endregion
    }
}