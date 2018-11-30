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
    public class StockIn4DeptController : ControllerBase
    {
        // GET: api/StockIn4Dept
        [HttpGet]
        public string Get(int bizTypeId, DateTime? startTime, DateTime? endTime, string listIntGoodsIds, int deparmentId, int PageIndex, int PageSize)
        {
            return JSONHelper.ToJSONString(PagingHelper.GetPagedTable(BL.GetStockIn4Dept(
                bizTypeId,
                DataHelper.GetDateTime(startTime),
                DataHelper.GetDateTime(endTime), 
                DataHelper.GetListInt(listIntGoodsIds), 
                deparmentId),
                PageIndex, PageSize));
        }
    }
}