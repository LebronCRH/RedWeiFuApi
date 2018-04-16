using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using RADinfo_MIS_COST.Model;
using RADinfo_MIS_COST.DataBaseClasses;
using System.Collections;

namespace RADinfo_MIS_COST.DBDAL
{
    /// <summary>
    /// 用来访问Message表的类
    /// </summary>
    public class MessageDAL:SQLHelper
    {
        public MessageDAL(string connString)
            : base(connString)
        { 
        
        }

        #region Update
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
        public bool Update(string type, string keyword, string title, string content, bool state, int messageid,string adjunct)
        {
            int rowsAffected;
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@type",SqlDbType.VarChar),
                    new SqlParameter("@keyword",SqlDbType.VarChar),
                    new SqlParameter("@title",SqlDbType.VarChar),
                    new SqlParameter("@content",SqlDbType.VarChar),                    
                    new SqlParameter("@state",SqlDbType.Bit),
                    new SqlParameter("@messageid",SqlDbType.Int),
                    new SqlParameter("@Adjunct",SqlDbType.VarChar)
                };
            parameters[0].Value = type;
            parameters[1].Value = keyword;
            parameters[2].Value = title;
            parameters[3].Value = content;            
            parameters[4].Value = state;
            parameters[5].Value = messageid;
            parameters[6].Value = adjunct;

            RunProcedure("sp_U_Messages",parameters,out rowsAffected);
            return (rowsAffected == 1);
        }
        #endregion

        #region Add
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <returns>返回ID</returns>
        public int Add(string type,string Keyword, string title, string content, DateTime createtime, string mastername, string Adjunct,string Adjunct1,string Adjunct2,string Adjunct3,string Adjunct4)
        {
            int rowsAffected;
            SqlParameter[] parameters=
                {
                    new SqlParameter("@type",SqlDbType.VarChar),
                    new SqlParameter("@Keyword",SqlDbType.VarChar),
                    new SqlParameter("@title",SqlDbType.VarChar),
                    new SqlParameter("@content",SqlDbType.VarChar),
                    new SqlParameter("@createtime",SqlDbType.DateTime),
                    new SqlParameter("@mastername",SqlDbType.VarChar),
                    new SqlParameter("@Adjunct",SqlDbType.VarChar),
                    new SqlParameter("@Adjunct1",SqlDbType.VarChar),
                    new SqlParameter("@Adjunct2",SqlDbType.VarChar),
                    new SqlParameter("@Adjunct3",SqlDbType.VarChar),
                    new SqlParameter("@Adjunct4",SqlDbType.VarChar),
                    new SqlParameter("@messageID",SqlDbType.Int)
                };
            parameters[0].Value=type;
            parameters[1].Value = Keyword;
            parameters[2].Value=title;
            parameters[3].Value=content;
            parameters[4].Value = createtime;
            parameters[5].Value = mastername;
            parameters[6].Value = Adjunct;
            parameters[7].Value = Adjunct1;
            parameters[8].Value = Adjunct2;
            parameters[9].Value = Adjunct3;
            parameters[10].Value = Adjunct4;
            parameters[11].Direction = ParameterDirection.Output;

            RunProcedure("sp_InsertMessages", parameters, out rowsAffected);
            return (int)parameters[11].Value;

        }
        #endregion

        /// <summary>
        /// 查询分栏的前10条信息
        /// </summary>
        /// <param name="type">信息类别</param>
        /// <param name="state">是否审核</param>
        /// <returns></returns>
        public ArrayList GetMessage(string type, bool state)
        {
            ArrayList messages = new ArrayList();
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@type",SqlDbType.VarChar),
                    new SqlParameter("@state",SqlDbType.Bit)
                };
            parameters[0].Value = type;
            parameters[1].Value = state;

            SqlDataReader reader =
                RunProcedure("sp_GetTopMessages", parameters);
            while (reader.Read())
            {
                Messages model = new Messages();
                model.Adjunct = reader["adjunct"].ToString();
                model.Content = reader["content"].ToString();
                model.CreateTime = Convert.ToDateTime(reader["createtime"]);
                model.Mastername = reader["mastername"].ToString();
                model.MessageId = Convert.ToInt32(reader["messageid"]);
                model.State = Convert.ToBoolean(reader["state"]);
                model.Title = reader["title"].ToString();
                model.Type = reader["type"].ToString();
                //model.Name = reader["name"].ToString();
                messages.Add(model);
            }
            return messages;

        }

        /// <summary>
        /// 查询所有的信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="xuanze"></param>
        /// <param name="createtime"></param>
        /// <returns></returns>
        public ArrayList GetMessage(string type,string state, string createtime1, string createtime2,string mastername)
        {
            ArrayList messages = new ArrayList();
            SqlDataReader reader = null;
            SqlParameter[] parameters =
                                { 
                                    new SqlParameter("@type",SqlDbType.VarChar),
                                    new SqlParameter("@state",SqlDbType.VarChar),
                                    new SqlParameter("@createtime1",SqlDbType.VarChar),
                                    new SqlParameter("@createtime2",SqlDbType.VarChar),
                                    new SqlParameter("@mastername",SqlDbType.VarChar)
                                };
                parameters[0].Value = type;
                parameters[1].Value = state;
                parameters[2].Value = createtime1;
                parameters[3].Value = createtime2;
                parameters[4].Value = mastername;
                reader = RunProcedure("sp_S_Messages", parameters);
          
            while (reader.Read())
            {
                Messages model = new Messages();
                model.Adjunct = reader["adjunct"].ToString();
                model.Adjunct1 = reader["adjunct1"].ToString();
                model.Adjunct2 = reader["adjunct2"].ToString();
                model.Adjunct3 = reader["adjunct3"].ToString();
                model.Adjunct4 = reader["adjunct4"].ToString();
                model.Content = reader["content"].ToString();
                model.CreateTime = Convert.ToDateTime(reader["createtime"]);
                model.Mastername = reader["mastername"].ToString();
                model.MessageId = Convert.ToInt32(reader["messageid"]);
                model.State = Convert.ToBoolean(reader["state"]);
                model.Title = reader["title"].ToString();
                model.Type = reader["type"].ToString();
                model.Name = reader["name"].ToString();
                model.Keyword = reader["Keyword"].ToString();

                messages.Add(model);
            }
            return messages;
        }

        /// <summary>
        /// 查询指定的信息
        /// </summary>
        /// <param name="messageid"></param>
        /// <returns></returns>
        public Messages GetMessage(int messageid)
        {
            Messages model = null;
            SqlParameter[] parameters ={ new SqlParameter("@messageid",SqlDbType.Int)};
            parameters[0].Value = messageid;

            SqlDataReader reader = RunProcedure("sp_S_Messages", parameters);
            if (reader.Read())
            {
                model = new Messages();
                model.Adjunct = reader["adjunct"].ToString();
                model.Adjunct1 = reader["adjunct1"].ToString();
                model.Adjunct2 = reader["adjunct2"].ToString();
                model.Adjunct3 = reader["adjunct3"].ToString();
                model.Adjunct4 = reader["adjunct4"].ToString();
                model.Content = reader["content"].ToString();
                model.CreateTime = Convert.ToDateTime(reader["createtime"]);
                model.Mastername = reader["mastername"].ToString();
                model.MessageId = Convert.ToInt32(reader["messageid"]);
                model.State = Convert.ToBoolean(reader["state"]);
                model.Title = reader["title"].ToString();
                model.Type = reader["type"].ToString();
                model.Name = reader["name"].ToString();
                model.Keyword = reader["Keyword"].ToString();
                
                
            }
            return model;
        }

        /// <summary>
        /// 查询相关的信息
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public ArrayList GetRelated(string keyWord,string keyword1,string keyword2,int messageid)
        {
            ArrayList messages = new ArrayList();
            SqlParameter[] parameters ={
                                           new SqlParameter("@keyword", SqlDbType.VarChar),
                                           new SqlParameter("@keyword1",SqlDbType.VarChar),
                                           new SqlParameter("@keyword2",SqlDbType.VarChar),
                                           new SqlParameter("@messageid",SqlDbType.Int) };
            parameters[0].Value = keyWord;
            parameters[1].Value = keyword1;
            parameters[2].Value = keyword2;
            parameters[3].Value = messageid;

            SqlDataReader reader = RunProcedure("sp_GetMessages", parameters);
            while(reader.Read())
            {
                Messages model = new Messages();
                model.Adjunct = reader["adjunct"].ToString();
                model.Adjunct1 = reader["adjunct1"].ToString();
                model.Adjunct2 = reader["adjunct2"].ToString();
                model.Adjunct3 = reader["adjunct3"].ToString();
                model.Adjunct4 = reader["adjunct4"].ToString();
                model.Content = reader["content"].ToString();
                model.CreateTime = Convert.ToDateTime(reader["createtime"]);
                model.Mastername = reader["mastername"].ToString();
                model.MessageId = Convert.ToInt32(reader["messageid"]);
                model.State = Convert.ToBoolean(reader["state"]);
                model.Title = reader["title"].ToString();
                model.Type = reader["type"].ToString();
               
                model.Keyword = reader["Keyword"].ToString();
    
                messages.Add(model);
            }
            return messages;
        }

        /// <summary>
        /// 删除指定信息
        /// </summary>
        /// <param name="messageid"></param>
        /// <returns></returns>
        public bool DeleteMessage(int messageid)
        {
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@messageid",SqlDbType.Int)
                };
            parameters[0].Value = messageid;

            int rowsAffected;
            RunProcedure("sp_D_Message", parameters, out rowsAffected);
            return rowsAffected > 0?true:false;
        }
    }
}