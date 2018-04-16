using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedWeiFuApi.Models
{
    public class SysCodeValue
    {
        public SysCodeValue()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public int Id { get; set; }
        public string CodeClassified { get; set; }
        public string CodeValue { get; set; }
        public string CodeName { get; set; }
        public string Remark { get; set; }
    }
}