using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL;

namespace WebAPI_SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasingPlanVendorQuoteDetailController : ControllerBase
    {
        // GET: api/PurchasingPlanQuoteDetail
        public string Get(int purchasiongPlanID, int vendorID, int PageIndex, int PageSize)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetPurchasingPlanVendorQuoteDetail(
                purchasiongPlanID,
                vendorID),
                PageIndex, PageSize));
        }
    }
}
