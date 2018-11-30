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
    public class GoodsClassQuoteCountController : ControllerBase
    {
        // GET: api/GoodsClassQuoteCount
        [HttpGet]
        public string Get(int bizTypeId, DateTime? StartTime, DateTime? EndTime)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetGoodsClassQuoteCount(
                bizTypeId, 
                DataHelper.GetDateTime(StartTime),
                DataHelper.GetDateTime(EndTime)),
                0, 0));
        }
    }
}
