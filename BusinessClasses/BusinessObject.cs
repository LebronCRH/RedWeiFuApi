using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace RADinfo_MIS_COST.BusinessClasses
{
    public abstract class BusinessObject
    {
        protected string connectionString;
        public BusinessObject()
        { 
            //从配置文件web.config中读取连接字符串
            AppSettingsReader configurationAppSettings = new AppSettingsReader();
            connectionString = ((string)(configurationAppSettings.GetValue("ConStr", typeof(string))));
        }
    }
}
