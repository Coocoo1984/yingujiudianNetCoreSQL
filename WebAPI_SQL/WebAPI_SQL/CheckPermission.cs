using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_SQL
{
    public class Common
    {

        public static bool CheckPermission(string WechatID, RouteData routeData)
        {
            bool result = false;

            List<object> list = routeData.Values.Values.ToList();
            //判断路由
            string strController = Convert.ToString(list[1]);

            if (strController == "GetDetailByQuoteID")
            {
                //查询数据库
                if (WechatID == "HeYan")
                {
                    result = true;
                }
            }

            

            return result;
        }
    }
}
