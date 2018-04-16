using System;
using System.Collections.Generic;
using System.Text;

using RADinfo_MIS_COST.Model;
using RADinfo_MIS_COST.DBDAL;
using System.Security.Cryptography;
using System.Collections;

namespace RADinfo_MIS_COST.BusinessClasses
{
    public class MasterBLL:RADinfo_MIS_COST.BusinessClasses.BusinessObject
    {
        public int _id;
        public string _masterid;
        public string _mastername;
        public byte[] _password;
        public string _truename;
        public string _sex;
        public DateTime _birthday;
        public string _deptid;
        public string _position;
        public string _position_desc;
        public string _office_phone;
        public string _mobile;
        public string _home_phone;
        public string _email;
        public int _createid;
        public string _createname;
        public DateTime _createdate;
        public DateTime _ruzhitime;
        public DateTime _lizhitime;

        public MasterBLL()
            : base()
        {
            _id = -1;
            _masterid = "-1";
        }

        ///// <summary>
        ///// 构造函数，使用用户ID创建新对象
        ///// </summary>
        ///// <param name="masterid"></param>
        //public MasterBLL(int masterid)
        //    : base()
        //{
        //    _id = -1;
        //    _masterid = "-1";
        //    LoadFromID(masterid.ToString());
        //}

        
       
        /// <summary>
        /// 构造函数，使用登陆名创建新对象
        /// </summary>
        /// <param name="mastername"></param>
        public MasterBLL(string mastername)
            : base()
        {
            _id = -1;
            _masterid = "";
            MasterDAL dal = new MasterDAL(connectionString);
            Master model = dal.GetMaster(mastername);
            if (model != null)
            {
                _id = model.Id;
                _masterid = model.MasterId;
                _mastername = model.MasterName;
                
                _mobile = model.Mobile;
                _office_phone = model.Office_phone;
                _password = model.Password;
                _position = model.Position;
                _position_desc = model.Position_Desc;
                _ruzhitime = model.RuzhiTime;
                _sex = model.Sex;
                _truename = model.TrueName;
                _birthday = model.Birthday;
                _createdate = model.CreateDate;
                _createid = model.CreateId;
                _createname = model.CreateName;
                _deptid = model.DeptId;
                _email = model.Email;
                _home_phone = model.Home_Phone;
                _lizhitime = model.LizhiTime;
            }
        }

        public void LoadFromID(string masterid)
        {
            MasterDAL dal = new MasterDAL(connectionString);
            Master model = dal.GetMasterByMasterid(masterid);
            if (model != null)
            {
                _id = model.Id;
                _masterid = model.MasterId;
                _mastername = model.MasterName;
                _mobile = model.Mobile;
                _office_phone = model.Office_phone;
                _password = model.Password;
                _position = model.Position;
                _position_desc = model.Position_Desc;
                _ruzhitime = model.RuzhiTime;
                _sex = model.Sex;
                _truename = model.TrueName;
                _birthday = model.Birthday;
                _createdate = model.CreateDate;
                _createid = model.CreateId;
                _createname = model.CreateName;
                _deptid = model.DeptId;
                _email = model.Email;
                _home_phone = model.Home_Phone;
                _lizhitime = model.LizhiTime;
            }
        }

        /// <summary>
        /// 使用SHA1算法加密指定的字符串
        /// </summary>
        /// <param name="plainText">要加密的明文</param>
        /// <returns>返回加密的字节数</returns>
        public byte[] Encrypt(string plainText)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] hashBytes = encoding.GetBytes(plainText);

            //计算SHA-1散列值
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            return sha1.ComputeHash(hashBytes);
        }

        /// <summary>
        /// 返回包含用户的所有角色
        /// </summary>
        /// <returns></returns>
        public ArrayList GetGroupmanager()
        {
            if (_id == -1)
            {
                return null;
            }
            MasterDAL dal = new MasterDAL(connectionString);
            
            return dal.GetGroupManager(_masterid);;
        }

        /// <summary>
        /// 返回用户所拥有的权限
        /// </summary>
        /// <returns></returns>
        public ArrayList GetActions()
        {
            if (_id== -1)
            {
                return null;
            }
            MasterDAL dal = new MasterDAL(connectionString);
            return dal.GetAction(_masterid);
        }

        public ArrayList GetActionColumns()
        {
            if (_id == -1)
                return null;

            MasterDAL dal = new MasterDAL(connectionString);
            return dal.GetActionColumns(_masterid);
        }

        /// <summary>
        /// 设置用户的密码
        /// </summary>
        /// <param name="plainPassword">密码明文</param>
        public void SetPassword(string plainPassword)
        {
            _password = this.Encrypt(plainPassword);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="oldPassword">原密码明文</param>
        /// <param name="newPasswrod">新密码明文</param>
        /// <returns></returns>
        public bool ModifyPassword(string oldPassword, string newPasswrod)
        {
            byte[] shaOldPass = Encrypt(oldPassword);
            byte[] shaNewPass = Encrypt(newPasswrod);

            for (int i = 0; i < shaOldPass.Length; i++)
            {
                if (shaOldPass[i]!=_password[i])
                {
                    return false;
                }
            }
            _password = shaNewPass;
            UpdatePassWord();
            return true;
        }

         /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="masterid"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool UpdatePassWord()
        {
            MasterDAL dal = new MasterDAL(connectionString);
            return dal.UpdatePassWord(_masterid, _password);
        }

        /// <summary>
        /// 初始化密码
        /// </summary>
        /// <returns></returns>
        public bool UpdatePassWrod(string StrPass)
        {
            byte[] pass = Encrypt(StrPass);
            MasterDAL dal = new MasterDAL(connectionString);
            return dal.UpdatePassWord(_masterid, pass);
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        public bool Update()
        {
            

            MasterDAL dal = new MasterDAL(connectionString);
            return dal.Update(_masterid, _mastername, _truename, _sex, _birthday, _deptid, _position, _position_desc,
                _office_phone, _mobile, _home_phone, _email,  _ruzhitime);

        }


        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns>返回新用户的ID</returns>
        public int Add()
        {
            MasterDAL dal = new MasterDAL(connectionString);
            _id = dal.AddMaster(_masterid,_mastername, _password, _truename, _sex, _birthday, _deptid, _position,
                _position_desc, _office_phone, _mobile, _home_phone, _email, _createid, _createname, _createdate, _ruzhitime);
            return _id;
        }

        public ArrayList Select()
        {
            MasterDAL dal = new MasterDAL(connectionString);
            return dal.Select();
        }

          /// <summary>
        /// 删除指定用户信息
        /// </summary>
        /// <param name="masterid"></param>
        /// <returns></returns>
        public bool Delete()
        {
            MasterDAL dal = new MasterDAL(connectionString);
            return dal.Delete(_masterid);
        }

        public ArrayList Select(string truename, string deptid, string position)
        {
            MasterDAL dal = new MasterDAL(connectionString);
            return dal.Select(truename, deptid, position);
        }
    }
}
