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
    public class QuoteListAllController : ControllerBase
    {
        // GET: api/QuoteListAll
        [HttpGet]
        public string Get(int PageIndex, int PageSize)
        {
            DateTime endTime = DateTime.Now;
            DateTime startTime = endTime.AddMonths(-3);

            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetQuoteListAll(
                DataHelper.GetDateTime(startTime),
                DataHelper.GetDateTime(endTime)),
                PageIndex, PageSize));
        }

        
    }
}