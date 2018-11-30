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
    public class QuoteDetailList4Vendor2QuoteController : ControllerBase
    {
        // GET: api/QuoteDetailList4Vendor2Quote
        [HttpGet]
        public string Get(int vendorID, string listIntBizTypeID, int PageIndex, int PageSize)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetQuoteDetailList4Vendor2Quote(vendorID, DataHelper.GetListInt(listIntBizTypeID)),
                PageIndex, PageSize));
        }

    }
}