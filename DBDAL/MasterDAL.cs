using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using RADinfo_MIS_COST.DataBaseClasses;
using RADinfo_MIS_COST.Model;
using System.Collections;

namespace RADinfo_MIS_COST.DBDAL
{
    public class MasterDAL:SQLHelper
    {
        
        /// <summary>
        /// 构造函数，调用基类构造函数，使用制定的连接字符串创建数据库连接对象
        /// </summary>
        /// <param name="connString"></param>
        public MasterDAL(string connString)
            : base(connString)
        { }

       
        #region AddMaster        
        /// <summary>
        /// 向数据库表Master中添加一条新记录
        /// </summary>
        /// <param name="?"></param>
        /// <returns>返回新用户的ID</returns>
        public int AddMaster(string masterid,
            string mastername, byte[] password, string truename, string sex,
            DateTime birthday, string deptid, string position, string position_desc,
            string office_phone, string mobile, string home_phone, string email,
            int createid, string createname, DateTime createdate, DateTime ruzhitime
           )
        {
            int rowsAffected;
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@masterid",SqlDbType.VarChar),
                    new SqlParameter("@mastername",SqlDbType.VarChar),
                    new SqlParameter("@password",SqlDbType.VarBinary),
                    new SqlParameter("@truename",SqlDbType.VarChar),
                    new SqlParameter("@sex",SqlDbType.VarChar),
                    new SqlParameter("@birthday",SqlDbType.DateTime),
                    new SqlParameter("@deptid",SqlDbType.VarChar),
                    new SqlParameter("@position",SqlDbType.VarChar),
                    new SqlParameter("@position_desc",SqlDbType.VarChar),
                    new SqlParameter("@office_phone",SqlDbType.VarChar),
                    new SqlParameter("@mobile",SqlDbType.VarChar),
                    new SqlParameter("@home_phone",SqlDbType.VarChar),
                    new SqlParameter("@email",SqlDbType.VarChar),
                    new SqlParameter("@createname",SqlDbType.VarChar),
                    new SqlParameter("@createdate",SqlDbType.DateTime),
                    new SqlParameter("@ruzhitime",SqlDbType.DateTime),
                    //new SqlParameter("@lizhitime",SqlDbType.DateTime),
                    new SqlParameter("@id",SqlDbType.Int)
                };
            parameters[0].Value = masterid;
            parameters[1].Value = mastername;
            parameters[2].Value = password;
            parameters[3].Value = truename;
            parameters[4].Value = sex;
            parameters[5].Value = birthday;
            parameters[6].Value = deptid;
            parameters[7].Value = position;
            parameters[8].Value = position_desc;
            parameters[9].Value = office_phone;
            parameters[10].Value = mobile;
            parameters[11].Value = home_phone;
            parameters[12].Value = email;
            parameters[13].Value = createname;
            parameters[14].Value = createdate;
            parameters[15].Value = ruzhitime;
            //parameters[15].Value = lizhitime;
            parameters[16].Direction = ParameterDirection.Output;

            RunProcedure("sp_InsertMaster", parameters, out rowsAffected);
            return (int)parameters[16].Value;
        }
        #endregion

        #region  修改密码
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="masterid"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool UpdatePassWord(string masterid, byte[] password)
        {
            int rowsAffected;
            SqlParameter[] parameters = { 
                                        new SqlParameter("@masterid",SqlDbType.VarChar),
                                        new SqlParameter("@password",SqlDbType.Binary)
                                        };
            parameters[0].Value = masterid;
            parameters[1].Value = password;
            RunProcedure("sp_U_PassWord", parameters, out rowsAffected);
            return (rowsAffected==1);
        }
        #endregion

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="masterid"></param>
        /// <param name="mastername"></param>
        /// <param name="password"></param>
        /// <param name="truename"></param>
        /// <param name="sex"></param>
        /// <param name="birthday"></param>
        /// <param name="deptid"></param>
        /// <param name="position"></param>
        /// <param name="position_desc"></param>
        /// <param name="office_phone"></param>
        /// <param name="mobile"></param>
        /// <param name="home_phone"></param>
        /// <param name="email"></param>
        /// <param name="createid"></param>
        /// <param name="createname"></param>
        /// <param name="createdate"></param>
        /// <param name="ruzhitime"></param>
        /// <param name="lizhitime"></param>
        /// <returns></returns>
        public bool Update(string masterid,
           string mastername, string truename, string sex,
           DateTime birthday, string deptid, string position, string position_desc,
           string office_phone, string mobile, string home_phone, string email,
           DateTime ruzhitime)
        {
            int rowsAffected;
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@masterid",SqlDbType.VarChar),
                    new SqlParameter("@mastername",SqlDbType.VarChar),
                    //new SqlParameter("@password",SqlDbType.VarBinary),
                    new SqlParameter("@truename",SqlDbType.VarChar),
                    new SqlParameter("@sex",SqlDbType.VarChar),
                    new SqlParameter("@birthday",SqlDbType.DateTime),
                    new SqlParameter("@deptid",SqlDbType.VarChar),
                    new SqlParameter("@position",SqlDbType.VarChar),
                    new SqlParameter("@position_desc",SqlDbType.VarChar),
                    new SqlParameter("@office_phone",SqlDbType.VarChar),
                    new SqlParameter("@mobile",SqlDbType.VarChar),
                    new SqlParameter("@home_phone",SqlDbType.VarChar),
                    new SqlParameter("@email",SqlDbType.VarChar),
                    new SqlParameter("@ruzhitime",SqlDbType.DateTime),
                    //new SqlParameter("@lizhitime",SqlDbType.DateTime),
                   
                };
            parameters[0].Value = masterid;
            parameters[1].Value = mastername;
            parameters[2].Value = truename;
            parameters[3].Value = sex;
            parameters[4].Value = birthday;
            parameters[5].Value = deptid;
            parameters[6].Value = position;
            parameters[7].Value = position_desc;
            parameters[8].Value = office_phone;
            parameters[9].Value = mobile;
            parameters[10].Value = home_phone;
            parameters[11].Value = email;
            parameters[12].Value = ruzhitime;
            //parameters[13].Value = lizhitime;


            RunProcedure("sp_U_Master", parameters, out rowsAffected);
            return (rowsAffected == 1);
        }

        #region GetMaster
        /// <summary>
        /// 获取指定MasterId用户的详细信息
        /// </summary>
        /// <param name="masterid">用户ID</param>
        /// <returns></returns>
        public Master GetMasterByMasterid(string masterid)
        {
            Master model = null;
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@masterid",SqlDbType.VarChar)
                };
            parameters[0].Value = masterid;

            using (SqlDataReader reader =
                RunProcedure("sp_S_Master", parameters))
            {

                if (reader.Read())
                {
                    model = new Master();
                    model.MasterId = reader["masterid"].ToString();
                    model.MasterName = Convert.ToString(reader["mastername"]);
                    model.Mobile = Convert.ToString(reader["mobile"]);
                    model.Office_phone = Convert.ToString(reader["office_phone"]);
                    model.Password = (byte[])(reader["password"]);
                    model.Position = Convert.ToString(reader["position"]);
                    model.Position_Desc = Convert.ToString(reader["position_desc"]);
                    model.RuzhiTime = Convert.ToDateTime(reader["ruzhitime"]);
                    model.Sex = Convert.ToString(reader["sex"]);
                    model.TrueName = Convert.ToString(reader["truename"]);
                    //model.LizhiTime = Convert.ToDateTime(reader["lizhitime"]);
                    model.Home_Phone = Convert.ToString(reader["home_phone"]);
                    model.Email = Convert.ToString(reader["email"]);
                    model.DeptId = Convert.ToString(reader["deptid"]);
                    model.CreateName = Convert.ToString(reader["createname"]);

                    model.CreateDate = Convert.ToDateTime(reader["createdate"]);
                    model.Birthday = Convert.ToDateTime(reader["birthday"]);
                }
            }
            return model;
        }
        #endregion

        #region GetMaster
        /// <summary>
        /// 获取指定MasterName用户的详细信息
        /// </summary>
        /// <param name="mastername">用户name</param>
        /// <returns></returns>
        public Master GetMaster(string mastername)
        {
            Master model = null;
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@mastername",SqlDbType.VarChar)
                };
            parameters[0].Value = mastername;

            using (SqlDataReader reader =
                RunProcedure("sp_S_Master", parameters))
            {
                if (reader.Read())
                {
                    model = new Master();
                    model.MasterId = reader["masterid"].ToString();
                    model.MasterName = Convert.ToString(reader["mastername"]);
                    model.Mobile = Convert.ToString(reader["mobile"]);
                    model.Office_phone = Convert.ToString(reader["office_phone"]);
                    model.Password = (byte[])(reader["password"]);
                    model.Position = Convert.ToString(reader["position"]);
                    model.Position_Desc = Convert.ToString(reader["position_desc"]);
                    model.RuzhiTime = Convert.ToDateTime(reader["ruzhitime"]);
                    model.Sex = Convert.ToString(reader["sex"]);
                    model.TrueName = Convert.ToString(reader["truename"]);
                    //model.LizhiTime = Convert.ToDateTime(reader["lizhitime"]);
                    model.Home_Phone = Convert.ToString(reader["home_phone"]);
                    model.Email = Convert.ToString(reader["email"]);
                    model.DeptId = Convert.ToString(reader["deptid"]);
                    //model.CreateName = Convert.ToString(reader["createname"]);
                    //model.CreateId = Convert.ToInt32(reader["createid"]);
                    //model.CreateDate = Convert.ToDateTime(reader["createdate"]);
                    model.Birthday = Convert.ToDateTime(reader["birthday"]);
                }
            }
            return model;
        }
        #endregion


        public ArrayList Select(string truename,string deptid,string position)
        {
            SqlParameter[] parameters = { 
                                        new SqlParameter("@truename",SqlDbType.VarChar),
                                        new SqlParameter("@deptid",SqlDbType.VarChar),
                                        new SqlParameter("@position",SqlDbType.VarChar)
                                        };
            parameters[0].Value = truename;
            parameters[1].Value = deptid;
            parameters[2].Value = position;
            ArrayList lists = new ArrayList();
            using (SqlDataReader reader = RunProcedure("sp_S_Masters", parameters))
            {
                
                while (reader.Read())
                {
                    Master model = new Master();
                    model.Birthday = Convert.ToDateTime(reader["birthday"]);
                    model.CreateDate = Convert.ToDateTime(reader["createdate"]);
                    //model.CreateId = Convert.ToInt32(reader["createid"]);
                    model.CreateName = Convert.ToString(reader["createname"]);
                    model.DeptId = Convert.ToString(reader["deptid"]);
                    model.Deptname = Convert.ToString(reader["deptname"]);
                    model.Email = Convert.ToString(reader["email"]);
                    model.Home_Phone = Convert.ToString(reader["home_phone"]);
                    //model.LizhiTime = Convert.ToDateTime(reader["lizhitime"]);
                    model.MasterId = reader["masterid"].ToString();
                    model.MasterName = Convert.ToString(reader["mastername"]);
                    model.Mobile = Convert.ToString(reader["mobile"]);
                    model.Office_phone = Convert.ToString(reader["office_phone"]);
                    model.Password = (byte[])(reader["password"]);
                    model.Position = Convert.ToString(reader["position"]);
                    model.Position_Desc = Convert.ToString(reader["position_desc"]);
                    model.RuzhiTime = Convert.ToDateTime(reader["ruzhitime"]);
                    model.Sex = Convert.ToString(reader["sex"]);
                    model.TrueName = Convert.ToString(reader["truename"]);
                    lists.Add(model);
                }
            }
            return lists;
        }

        


        #region GetGroupManager
        /// <summary>
        /// 从数据库获取包含指定用户的角色（管理组）
        /// </summary>
        /// <returns></returns>
        public ArrayList GetGroupManager(string masterid)
        {
            ArrayList roles = new ArrayList();

            SqlParameter[] parameters =
                { 
                    new SqlParameter("@masterid",SqlDbType.VarChar)
                };
            parameters[0].Value = masterid;


            using (SqlDataReader reader = RunProcedure("sp_GetGroupManager", parameters))
            {
                while (reader.Read())
                {
                    GroupManager model = new GroupManager();
                    model.GroupId = Convert.ToInt32(reader["groupid"]);
                    model.GroupName = Convert.ToString(reader["groupname"]);

                    roles.Add(model);
                }
            }
            return roles;
        }
        #endregion

        #region GetAction
        /// <summary>
        /// 获取指定用户的所有权限
        /// </summary>
        /// <param name="masterid"></param>
        /// <returns></returns>
        public ArrayList GetAction(string masterid)
        {
            ArrayList actions = new ArrayList();

            SqlParameter[] parameters =
                {
                    new SqlParameter("@masterid",SqlDbType.VarChar)
                };
            parameters[0].Value = masterid;

            using (SqlDataReader reader =
                RunProcedure("sp_GetAction_Master", parameters))
            {
                while (reader.Read())
                {
                    RADinfo_MIS_COST.Model.Action action = new RADinfo_MIS_COST.Model.Action();
                    action.ActionId = Convert.ToInt32(reader["actionid"]);
                    action.ActionName = Convert.ToString(reader["actionname"]);
                    action.Link = Convert.ToString(reader["link"]);
                    actions.Add(action);
                }
            }
            return actions;
        }
        #endregion

        #region GetActionColumns
        
        /// <summary>
        /// 获取指定用户的权限分栏
        /// </summary>
        /// <param name="masterid"></param>
        /// <returns></returns>
        public ArrayList GetActionColumns(string masterid)
        {
            ArrayList actioncolumns = new ArrayList();
            SqlParameter[] parameters =
                {
                    new SqlParameter("@masterid",SqlDbType.VarChar)
                };
            parameters[0].Value = masterid;
            using (SqlDataReader reader =
                RunProcedure("sp_GetActioncolumn", parameters))
            {
                while (reader.Read())
                {
                    ActionColumn model = new ActionColumn();
                    model.ActionColumnid = Convert.ToInt32(reader["actioncolumnid"]);
                    model.ActionColumnName = Convert.ToString(reader["actioncolumnname"]);
                    model.Link = Convert.ToString(reader["link"]);
                    actioncolumns.Add(model);
                }
            }
            return actioncolumns;
        }
        #endregion

        #region Select
        /// <summary>
        /// 获取所有用户的信息
        /// </summary>
        /// <returns></returns>
        public ArrayList Select()
        {
            ArrayList masters = new ArrayList();
            using (SqlDataReader reader =
                RunProcedure("sp_GetMasters", null))
            {
                while (reader.Read())
                {
                    Master model = new Master();
                    model.MasterId = reader["masterid"].ToString();
                    model.MasterName = Convert.ToString(reader["mastername"]);
                    model.Birthday = Convert.ToDateTime(reader["birthday"]);
                    model.CreateDate = Convert.ToDateTime(reader["createdate"]);
                    model.CreateName = Convert.ToString(reader["createname"]);
                    model.DeptId = Convert.ToString(reader["deptid"]);
                    model.Email = Convert.ToString(reader["email"]);
                    model.Home_Phone = Convert.ToString(reader["home_phone"]);
                    //model.LizhiTime = Convert.ToDateTime(reader["lizhitime"]);
                    model.Mobile = Convert.ToString(reader["mobile"]);
                    model.Office_phone = Convert.ToString(reader["office_phone"]);
                    model.Password = (byte[])(reader["password"]);
                    model.Position = Convert.ToString(reader["position"]);
                    model.Position_Desc = Convert.ToString(reader["position_desc"]);
                    model.RuzhiTime = Convert.ToDateTime(reader["ruzhitime"]);
                    model.Sex = Convert.ToString(reader["sex"]);
                    model.TrueName = Convert.ToString(reader["truename"]);
                    model.Deptname = Convert.ToString(reader["deptname"]);
                    masters.Add(model);
                }
            }
            return masters;
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除指定用户信息
        /// </summary>
        /// <param name="masterid"></param>
        /// <returns></returns>
        public bool Delete(string masterid)
        {
            int rowsAffected;
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@masterid",SqlDbType.VarChar)
                };
            parameters[0].Value = masterid;
            RunProcedure("sp_D_Master",parameters,out rowsAffected);
            return rowsAffected > 0 ? true : false;
        }
        #endregion
    }
}
