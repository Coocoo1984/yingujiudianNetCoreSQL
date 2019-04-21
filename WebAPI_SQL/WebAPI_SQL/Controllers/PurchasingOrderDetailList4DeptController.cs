using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasingOrderDetailList4DeptController : ControllerBase
    {
        // GET: api/PurchasingOrderDetailList4Dept
        public string Get(int orderID, string WechatID)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetPurchasingOrderDetailList4Dept(orderID),
                0, 0));
        }
    }
}
