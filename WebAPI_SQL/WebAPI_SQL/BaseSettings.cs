using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_SQL
{
    public class BaseSettings
    {
        //是否需要关闭全局SQL检索时的表记录启用标志位判断 如果启用 Controller自动添加 disable = value 的查询条件
        public static bool IsGlobalSelectTableRecordDisableClosed = false;
        //value 默认值
        public static bool DefualtDisableValue = false;
        //导出订单的默认值状态值
        public static string listDefualtPOStateIDs = "6,7,8,9,10,11";

        public static string NoPermissionString = "没有访问权限";

        public enum PermissionDefine
        {
            QuoteDetailRead = 1,
            QuoteAudit = 2,
            QuoteAudit2 = 3,
            PurchaceAudit = 4,
            PurchaceAudit2 = 5,
            PurchaceAudit3 = 6,
            ChargeBack = 7,
            DepotAdmin = 8
        }

    }

}
