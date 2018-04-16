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
    /// <summary>
    /// 用来访问Department类的表
    /// </summary>
    public class DepartmentDAL:SQLHelper
    {
        public DepartmentDAL():base()
        { }


        public DepartmentDAL(string connString)
            : base(connString)
        { }

        //修改部门信息
        public bool Update(int id,string deptid, string deptname, bool state)
        {
            int rowsAffected;
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@id",SqlDbType.Int),
                    new SqlParameter("@deptid",SqlDbType.VarChar),
                    new SqlParameter("@deptname",SqlDbType.VarChar),
                    new SqlParameter("@state",SqlDbType.Bit)
                };
            parameters[0].Value = id;
            parameters[1].Value = deptid;
            parameters[2].Value = deptname;
            parameters[3].Value = state;
            RunProcedure("sp_U_Department",parameters,out rowsAffected);
            return (rowsAffected == 1);
        }

        //删除指定部门信息
        public bool Delete(string deptid)
        {
            int rowsAffected;
            SqlParameter[] parameters =
                { 
                    new SqlParameter("@deptid",SqlDbType.VarChar)
                };
            parameters[0].Value = deptid;
            RunProcedure("sp_D_Department",parameters,out rowsAffected);
            return (rowsAffected >=1);
        }

        //查询指定部门中是否有用户信息
        public bool Select(string deptid)
        {
            SqlParameter[] parameters=
            {   
                new SqlParameter("@deptid",SqlDbType.VarChar)
            };
            parameters[0].Value = deptid;
            using (SqlDataReader reader = RunProcedure("sp_S_Dept_Masters", parameters))
            {
                if (reader.Read())
                {
                    return true;
                }
            }
            return false;
        }

        //查询所有的部门信息
        public ArrayList Select()
        {
            ArrayList departments = new ArrayList();
            using (SqlDataReader reader = RunProcedure("sp_S_Department", null))
            {
                while (reader.Read())
                {
                    Department model = new Department();
                    model.Id = Convert.ToInt32(reader["id"]);
                    model.DeptId = Convert.ToString(reader["deptid"]);
                    model.DeptName = Convert.ToString(reader["deptname"]);
                    model.state = Convert.ToBoolean(reader["state"]);
                    departments.Add(model);
                }
            }
            return departments;
        }

        /// <summary>
        /// 向数据库中添加一个部门，并返回新部门的ID
        /// </summary>
        /// <param name="deptname"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int Add(string deptid,string deptname, bool state)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("@deptid",SqlDbType.VarChar),
                    new SqlParameter("@deptname",SqlDbType.VarChar),
                    new SqlParameter("@state",SqlDbType.Bit),
                    new SqlParameter("@id",SqlDbType.Int)
                };
            parameters[0].Value = deptid;
            parameters[1].Value = deptname;
            parameters[2].Value = state;
            parameters[3].Direction = ParameterDirection.Output;
            
            int rowsAffected;
            RunProcedure("sp_InsertDepartment", parameters, out rowsAffected);

            return((int)(parameters[3].Value));
        }

        /// <summary>
        /// 根据特定ID,获取部门信息
        /// </summary>
        /// <param name="deptid"></param>
        /// <param name="deptname"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public Department GetDepartment(string id)
        {
           Department dept = null;

            SqlParameter[] parameters =
                {
                    new SqlParameter("@deptid",SqlDbType.VarChar),
                  
                };
            parameters[0].Value = id;


            using (SqlDataReader reader =
                RunProcedure("sp_S_Department", parameters))
            {
                if (reader.Read())
                {
                    dept = new Department();
                    dept.Id = Convert.ToInt32(reader["id"]);
                    dept.DeptId = Convert.ToString(reader["deptid"]);
                    dept.DeptName = Convert.ToString(reader["deptname"]);
                    dept.state = Convert.ToBoolean(reader["state"]);
                }
            }
            return dept;
        }

        /// <summary>
        /// 根据特定NAME获取部门信息
        /// </summary>
        /// <param name="deptid"></param>
        /// <param name="deptname"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public Department GetDepartment1(string deptname)
        {
            Department dept = null;

            SqlParameter[] parameters =
                {
                    new SqlParameter("@deptname",SqlDbType.VarChar),
                  
                };
            parameters[0].Value = deptname;


            SqlDataReader reader =
                RunProcedure("sp_S_Department", parameters);
            if (reader.Read())
            {
                dept = new Department();
                dept.Id = Convert.ToInt32(reader["id"]);
                dept.DeptId = Convert.ToString(reader["deptid"]);
                dept.DeptName = Convert.ToString(reader["deptname"]);
                dept.state = Convert.ToBoolean(reader["state"]);
            }
            return dept;
        }

    }
}
