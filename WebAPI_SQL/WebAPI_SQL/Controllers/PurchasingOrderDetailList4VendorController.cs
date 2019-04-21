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
    public class PurchasingOrderDetailList4VendorController : ControllerBase
    {
        // GET: api/PurchasingOrderDetailList4Vendor

        [HttpGet]
        public string Get(int purchasingOrderID, int PageIndex, int PageSize, string WechatID)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetPurchasingOrderDetailList4Vendor(purchasingOrderID),
                PageIndex, PageSize));
        }

    }
}
