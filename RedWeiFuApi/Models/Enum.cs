using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedWeiFuApi.Models
{
    public enum DialogEnum
    {
        系统消息 = 0,
        需求跟踪 = 1,
        维服申请 = 2,
        服务沟通 = 3
    }

    public enum TableNameEnum
    {
        需求跟踪 = 0,
        缺陷管理 = 1,
        产品管理 = 2
    }
}