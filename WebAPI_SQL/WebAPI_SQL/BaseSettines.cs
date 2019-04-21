using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_SQL
{
    public class BaseSettines
    {
        //是否需要关闭全局SQL检索时的表记录启用标志位判断 如果启用 Controller自动添加 disable = value 的查询条件
        public static bool IsGlobalSelectTableRecordDisableClosed = false;
        //value 默认值
        public static bool DefualtDisableValue = false;
        //导出订单的默认值状态值
        public static string listDefualtPOStateIDs = "6";

        public static string NoPermissionString = "没有访问权限";

    }

}
