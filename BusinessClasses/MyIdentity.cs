using System;
using System.Collections;
using System.Security;
using System.Security.Cryptography;
using System.Security.Principal;
using RADinfo_MIS_COST.BusinessClasses;


namespace RADinfo_MIS_COST.Accounts
{
    /// <summary>
    /// MyIdentity的摘要说明
    /// </summary>
    public class MyIdentity:System.Security.Principal.IIdentity
     {
        private MasterBLL bll;

        public MyIdentity()
        {
            bll = null;
        }

        /// <summary>
        /// 构造函数，分别通过用户ID或登录名来创建用户对象
        /// </summary>
        /// <param name="masterid"></param>
        public void MyIdentityByMasterid(string masterid)
        {
            bll = new MasterBLL();
            bll.LoadFromID(masterid);
        }

        public MyIdentity(string mastername)
        {
            bll = new MasterBLL(mastername);
        }

        #region IIdentity 成员

        public bool IsAuthenticated
        {
            get
            {
                return true;
            }
        }

        public string Name
        {
            get
            {
                return bll._mastername;
            }
        }

        public string AuthenticationType
        {
            get
            {
                return "自定义身份验证";
            }
        }
        #endregion

        #region 自定义属性
        public byte[] password
        {
            get
            {
                return bll._password;
            }
        }

        public int masterid
        {
            get
            {
                return bll._id;
            }
        }

        public string TrueName
        {
            get {
                return bll._truename;
            }
        }
        
        public BusinessClasses.MasterBLL Bll
        {
            get { return bll; }
            set { bll = value; }

        }
        #endregion

        /// <summary>
        /// 测试给出的密码是否正确
        /// </summary>
        /// <param name="pass">要测试的明文密码</param>
        /// <returns>如果正确，返回TRUE;否则返回FALSE</returns>
        public bool TestPassword(string pass)
        {
            byte[] encryptPass = bll.Encrypt(pass);
            for (int i = 0; i < encryptPass.Length; i++)
            {
                if (encryptPass[i] != bll._password[i])
                    return false;
            }
            return true;
        }
    }
}
