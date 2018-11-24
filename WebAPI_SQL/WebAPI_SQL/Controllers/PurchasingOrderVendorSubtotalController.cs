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
        public string Get(int vendorID)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetPurchasingOrderVendorSubtotal(vendorID),
                0, 0));
        }
    }
}
