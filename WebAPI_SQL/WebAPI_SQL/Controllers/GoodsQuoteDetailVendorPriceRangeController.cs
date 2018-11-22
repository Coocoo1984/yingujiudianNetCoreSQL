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
    public class GoodsQuoteDetailVendorPriceRangeController : ControllerBase
    {
        // GET: api/GoodsQuoteDetailVendorPriceRange
        [HttpGet]
        public string Get(int bizTypeID, DateTime? startTime, DateTime? endTime, int PageIndex, int PageSize)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetGoodsQuoteDetailVendorPriceRange(bizTypeID, startTime, endTime),
                PageIndex, PageSize));
        }
    }
}
