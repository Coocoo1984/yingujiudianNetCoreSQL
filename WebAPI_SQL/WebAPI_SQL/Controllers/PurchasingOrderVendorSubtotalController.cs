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
    public class PurchasingOrderVendorSubtotalController : ControllerBase
    {
        // GET: api/PurchasingOrderVendorSubtotal
        [HttpGet]
        public string Get(string listVendorIDs, string listBizTypeIDs, string listGoodsClassIDs, string listGoodsIDs, string listPOStateIDs, DateTime? startTime, DateTime? endTime)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetPurchasingOrderVendorSubtotal(
                DataHelper.GetListInt(listVendorIDs),
                DataHelper.GetListInt(listBizTypeIDs),
                DataHelper.GetListInt(listGoodsClassIDs),
                DataHelper.GetListInt(listGoodsIDs),
                DataHelper.GetListInt(listPOStateIDs),
                DataHelper.GetDateTime(startTime),
                DataHelper.GetDateTime(endTime)),
                0, 0));
        }
    }
}
