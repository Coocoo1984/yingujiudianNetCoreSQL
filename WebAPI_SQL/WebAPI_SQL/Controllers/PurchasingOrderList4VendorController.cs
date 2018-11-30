using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasingOrderList4VendorController : Controller
    {
        [HttpGet]
       
        public string GetPurchasingOrderList4Vendor(int bizTypeID, DateTime? startTime, DateTime? endTime, int vendorID, int PageIndex, int PageSize)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetPurchasingOrderList4Vendor(bizTypeID, startTime, endTime, vendorID), PageIndex, PageSize));
        }
    }
}