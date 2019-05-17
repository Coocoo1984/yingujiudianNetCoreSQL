using DAL;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_SQL
{
    public class Common
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="WechatID"></param>
        /// <param name="routeData"></param>
        /// <param name="requestParma">listQuoteStateIDs</param>
        /// <returns></returns>
        public static bool CheckPermission(string WechatID, RouteData routeData, string requestParma)
        {
            bool result = false;

            //List<object> list = routeData.Values.Values.ToList();
            //判断路由
            string strController = Convert.ToString(routeData.Values.Values.ToList()[1]);

            DataTable dt = BL.GetPermissionsByWechatID(WechatID, null);

            if (dt != null && dt.Rows.Count > 0)
            {
                if (strController == "PurchasingPlanCount4Audit")
                {
                    //计划初审
                    if (dt.Select("permission_id" + "=" + (int)BaseSettings.PermissionDefine.PurchaceAudit).Length > 0)
                        result = true;
                }
                if (strController == "PurchasingPlanCount4Audit2")
                {
                    //计划复审
                    if (dt.Select("permission_id" + "=" + (int)BaseSettings.PermissionDefine.PurchaceAudit2).Length > 0)
                        result = true;
                }
                if (strController == "PurchasingPlanCount4Audit3")
                {
                    //计划三审
                    if (dt.Select("permission_id" + "=" + (int)BaseSettings.PermissionDefine.PurchaceAudit3).Length > 0)
                        result = true;
                }
                if (strController == "GetDetailByQuoteID")
                {
                    //报价明细查看
                    if (dt.Select("permission_id" + "=" + (int)BaseSettings.PermissionDefine.QuoteDetailRead).Length > 0)
                        result = true;
                }
                if (strController == "QuoteListAll")
                {
                    if(requestParma.Contains("2"))
                    {
                        //报价初审
                        if (dt.Select("permission_id" + "=" + (int)BaseSettings.PermissionDefine.QuoteAudit).Length > 0)
                            result = true;
                    }
                    if (requestParma.Contains("4"))
                    {
                        //报价复审
                        if (dt.Select("permission_id" + "=" + (int)BaseSettings.PermissionDefine.QuoteAudit2).Length > 0)
                            result = true;
                    }

                }

            }



            return result;
        }
    }
}
