using System;
using System.Collections.Generic;
using System.Text;

using RADinfo_MIS_COST.DBDAL;
using RADinfo_MIS_COST.Model;
using System.Collections;

namespace RADinfo_MIS_COST.BusinessClasses
{
    public class DepartmentBLL:RADinfo_MIS_COST.BusinessClasses.BusinessObject
    {
        public int _id;
        public string _deptid;
		public string _deptname;
		public bool _state;

        public DepartmentBLL()
            : base()
        {
            _id = -1;
        }

        public DepartmentBLL(string id)
            : base()
        {
            LoadFormID(id);
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
            DepartmentDAL dal = new DepartmentDAL(connectionString);
            return dal.GetDepartment1(deptname);
        }

        private void LoadFormID(string id)
        {
            DepartmentDAL dal = new DepartmentDAL(connectionString);
            Department model = dal.GetDepartment(id);
            if (model != null)
            {
                _id = model.Id;
                _deptid = model.DeptId;
                _deptname = model.DeptName;
                _state = model.state;
            }
        }

        public Department GetDepartment(string deptid)
        {
            DepartmentDAL dal = new DepartmentDAL(connectionString);
            return dal.GetDepartment(deptid);
        }

          //修改部门信息
        public bool Update()
        {
            DepartmentDAL dal = new DepartmentDAL(connectionString);
            return dal.Update(_id,_deptid, _deptname, _state);
        }

        //删除指定部门信息
        public bool Delete()
        {
            DepartmentDAL dal = new DepartmentDAL(connectionString);
            return dal.Delete(_deptid);
        }
         //查询指定部门中是否有用户信息
        public bool Select(string deptid)
        {
            DepartmentDAL dal = new DepartmentDAL(connectionString);
            return dal.Select(deptid);
        }

        //查询所有的部门信息
        public ArrayList Select()
        {
            DepartmentDAL dal=new DepartmentDAL(connectionString);
            return dal.Select();
        }

        /// <summary>
        /// 添加一个部门
        /// </summary>
        /// <returns>返回新部门的ID</returns>
        public int Add()
        {
            DepartmentDAL dal = new DepartmentDAL(connectionString);
            _id = dal.Add(_deptid,_deptname, _state);
            return _id;
        }

    }
}
